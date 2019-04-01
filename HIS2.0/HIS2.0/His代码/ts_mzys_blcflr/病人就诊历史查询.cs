using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_mzys_blcflr
{
    public partial class Frmjzlscx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmjzlscx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[11];

                parameters[0].Text = "@type";
                parameters[0].Value = 0;

                parameters[1].Text = "@klx";
                parameters[1].Value = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue,"0"));

                parameters[2].Text = "@kh";
                parameters[2].Value = txtkh.Text.Trim();

                parameters[3].Text = "@brxm";
                parameters[3].Value = txtbrxm.Text.Trim();

                parameters[4].Text = "@blh";
                parameters[4].Value = txtmzh.Text.Trim();

                parameters[5].Text = "@fph";
                parameters[5].Value = txtfph.Text.Trim();

                parameters[6].Text = "@jzks";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(txtjzks.Tag, "0"));

                parameters[7].Text = "@jzys";
                parameters[7].Value = Convert.ToInt32(Convertor.IsNull(txtjzys.Tag, "0"));

                parameters[8].Text = "@jzrq1";
                parameters[8].Value = dtpjzsj1.Value.ToString();

                parameters[9].Text = "@jzrq2";
                parameters[9].Value = dtpjzsj2.Value.ToString();

                parameters[10].Text = "@zdmc";
                parameters[10].Value = "";


                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_mzys_select_jzlscx", parameters, 30);
                //DataSet dt = new DataSet();
                //dt.Tables.Add(tb);
                Fun.AddRowtNo(tb);
                tb.TableName = "tb";
                this.dataGridView1.DataSource = tb;// (DataView)dt.Tables[0].DefaultView;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                Guid brxxid = new Guid(tb.Rows[nrow]["brxxid"].ToString());
                Guid jzid = new Guid(tb.Rows[nrow]["jzid"].ToString());
                Frmblcf_cx f = new Frmblcf_cx(_menuTag, "����������ʷ��ѯ", _mdiParent,brxxid,jzid);
                f.ShowDialog();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Frmjzlscx_Load(object sender, EventArgs e)
        {
            if (_menuTag.Function_Name == "Fun_ts_mzys_jzlscx")
            {
                txtjzks.Text = InstanceForm.BCurrentDept.DeptName;
                txtjzks.Tag = InstanceForm.BCurrentDept.DeptId.ToString();
                txtjzks.Enabled = false;
            }
            dtpjzsj1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortDateString() + " 00:00:00");
            dtpjzsj2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortDateString() + " 23:59:59");

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            this.WindowState = FormWindowState.Maximized;

            //�Զ�����Ƶ��
            string sbxh = ApiFunction.GetIniString("ҽԺ������", "�豸�ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }

        private void txtjzks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            int nkey = (int)e.KeyChar;
            if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "��������", "������", "ƴ����", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Fun.GetGhks(false, InstanceForm.BDatabase);
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                    return;
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                }
            }
        }

        private void txtjzys_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            int nkey = (int)e.KeyChar;
            if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
            if ((int)e.KeyChar != 13)
            {

                string[] headtext = new string[] { "ҽ������", "����", "����", "ƴ����", "�����", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "py_code", "wb_code" };//, "code" Modify By Tany 2008-12-19 ��һ���й���
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Fun.GetGhys(0, InstanceForm.BDatabase);
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                }
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 && txtkh.Text.Trim()!="")
            {
                txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text, InstanceForm.BDatabase);
                butcx_Click(sender, null);
            }
        }

        private void txtmzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 && txtmzh.Text.Trim() != "")
            {
                txtmzh.Text = Fun.returnMzh(txtmzh.Text, InstanceForm.BDatabase);
                butcx_Click(sender, null);
            }
        }

        private void txtbrxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 13 && control.Text.Trim() != "")
            {
                butcx_Click(sender, null);
            }
        }

        private void mnujzxx_Click(object sender, EventArgs e)
        {

        }

        private void mnubrxx_Click(object sender, EventArgs e)
        {

        }

        private void ����EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv;
                DataTable tb;

                System.Windows.Forms.DataGridView dgv;

                dgv = dataGridView1;
                tb = (DataTable)dgv.DataSource;







                // ����Excel���� 
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel�޷�����");
                    return;
                }
                // ����Excel������
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // ������������������������������
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count + 1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                        colCount = colCount + 1;
                }


                //��ѯ����
                string swhere = "";
                swhere = " ����ʱ���:" + dtpjzsj1.Value.ToString() + "���� " + dtpjzsj2.Value.ToString();
                if (txtjzks.Text.Trim()!="") swhere = "  �������:"+txtjzks.Text.Trim();
                if (txtjzys.Text.Trim() != "") swhere = "  ����ҽ��:" + txtjzys.Text.Trim();

                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "���˾����ѯ(" + InstanceForm.BCurrentDept.DeptName + ")";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // ��������
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;
                //xlApp.ActiveCell.FormulaR1C1 = swhere;
                //xlApp.ActiveCell.Font.Size = 20;
                //xlApp.ActiveCell.Font.Bold = true;
                //xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // ������������
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // ��ȡ�б���
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                        objData[1, colIndex++] = dgv.Columns[i].HeaderText;
                }
                // ��ȡ����
                objData[0, 0] = swhere;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        if (dgv.Columns[j].Visible == true)
                        {
                            if (tb.Columns[j].Caption == "�����" || tb.Columns[j].Caption == "���֤��" || tb.Columns[j].Caption == "��ϵ�绰")
                                objData[i + 2, colIndex++] = "'" + tb.Rows[i][j].ToString();
                            else
                                objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // д��Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //���ñ�����Ϊ����Ӧ���
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnexecl_Click(object sender, EventArgs e)
        {
            ����EXCELToolStripMenuItem_Click(sender, e);
        }
        //Ӱ����Ϣ��ѯ  Add by zp 2013-10-12
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.dataGridView1.CurrentRow == null)
                    {
                        MessageBox.Show("����ѡ���˼�¼!", "��ʾ");
                    }
                    if (ApiFunction.GetIniString("PACS", "�Ƿ�����", Constant.ApplicationDirectory + "\\pacs.ini").Trim() != "1")
                    {
                        MessageBox.Show("�Բ�����δ����PACS�ӿڣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string pacsName = ApiFunction.GetIniString("PACS", "PACS����", Constant.ApplicationDirectory + "\\pacs.ini");
                    ts_pacs_interface.Ipacs pacs = ts_pacs_interface.PacsFactory.Pacs(pacsName);

                    string _brid = this.dataGridView1.CurrentRow.Cells["BRXXID"].Value.ToString();
                    Guid brxxid = new Guid(_brid);
                    pacs.ShowPatPacsInfo(brxxid, ts_pacs_interface.PatientSource.����);

                    //GetPacsInfo(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("û���ҵ���Ч�ļ�¼�������²�֤��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("�����쳣!ԭ��:" + ea.Message,"��ʾ");
            }
        }
    }
}