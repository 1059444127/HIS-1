using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_mz_tjbb
{
    /// <summary>
    /// �����������ͳ��
    /// </summary>
    public partial class FrmJkpjtj: Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        /// <summary>
        /// ���캯��
        /// </summary>
        public FrmJkpjtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            dtp1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 0:00:00"));
            this.WindowState = FormWindowState.Maximized;
        }

        // ͳ��
        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtp1.Value > dtp2.Value)
                {
                    MessageBox.Show("��ʼ���ڲ��ܴ��ڽ������ڣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@bdate";
                parameters[0].Value = dtp1.Value;

                parameters[1].Text = "@edate";
                parameters[1].Value = dtp2.Value;

                parameters[2].Text = "@jky";
                parameters[2].Value = cmbsfy.SelectedValue;

                parameters[3].Text = "@lybz";
                if (rbMz.Checked)
                {
                    parameters[3].Value = 1;
                }
                else if (rbZy.Checked)
                {
                    parameters[3].Value = 2;
                }

                DataSet dset = new DataSet();
                FrmMdiMain.Database.AdapterFillDataSet("SP_GET_MZFPBB", parameters, dset, "kjpjtj", 30);

                dgvData.Columns.Clear();
                DataTable dt = dset.Tables[0];
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ͳ��ʱ��������" + Environment.NewLine + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // �ر�
        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ����
        private void Frmjzlscx_Load(object sender, EventArgs e)
        {
            // ����Ա��
            FunAddComboBox.AddOperator(true, cmbsfy, InstanceForm.BDatabase);      
            cmbsfy.SelectedIndex = 0;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if ( dgvData.DataSource == null )
                return;
            try
            {
                DataTable dt = dgvData.DataSource as DataTable;
                FrmReportView f = new FrmReportView(dt, Constant.ApplicationDirectory + "\\Report\\����Ʊ��ͳ��.rpt", null);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dgvData.DataSource == null )
                return;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.btnExcel.Enabled = false;
                DataTable tb = dgvData.DataSource as DataTable;

                string str = "";
                if (rbMz.Checked)
                    str = "����";
                else
                    str = "סԺ";
                string swhere = string.Format("������Դ��{0} ����Ա��{1}  ����ʱ�䣺{2} �� {3}", str,  cmbsfy.Text, dtp1.Text, dtp2.Text);
                ExportToExcel(tb, Constant.HospitalName + " " + this.Text, swhere);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("����Excelʱ��������" + Environment.NewLine + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.btnExcel.Enabled = true;
            }

        }

        /// <summary>
        /// �������ݱ�Excel
        /// </summary>
        /// <param name="table">���ݱ�</param>
        /// <param name="title">����</param>
        /// <param name="info">�����Ϣ</param>
        private void ExportToExcel(DataTable table, string title, string info)
        {
            if (table == null)
                return;

            Excel.Application myExcel = new Excel.Application();
            myExcel.Application.Workbooks.Add(true);

            //д����ͷ
            int sumRowCount = table.Rows.Count;
            int sumColCount = 0;

            for (int j = 0; j < table.Columns.Count; j++)
            {
                sumColCount += 1;
                myExcel.Cells[5, sumColCount] = table.Columns[j].ColumnName;
            }
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, sumColCount]).Font.Bold = true;
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, sumColCount]).Font.Size = 10;

            //����д������
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int ncol = 0;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    ncol = ncol + 1;
                    myExcel.Cells[6 + i, ncol] = "'" + table.Rows[i][j].ToString().Trim();
                }
            }

            //���ñ�����Ϊ����Ӧ���
            myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Columns.AutoFit();

            //�ӱ߿�
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Borders.LineStyle = 1;

            //��������
            myExcel.Cells[1, 1] = title;
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Font.Bold = true;
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Font.Size = 16;
            //�������ƿ��о���
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

            //��������
            myExcel.Cells[3, 1] = info.Trim();
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, sumColCount]).Font.Size = 10;
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, sumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            //���һ��Ϊ��ɫ
            //myExcel.get_Range(myExcel.Cells[5 + sumRowCount, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Interior.ColorIndex = 19;

            //��Excel�ļ��ɼ�
            myExcel.Visible = true;
        }

        private void FrmYbsrtj_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
                btnprint_Click(sender, e);
            else if (e.KeyCode == Keys.Q)
                this.Close();
            else if (e.KeyCode == Keys.E)
                butexcel_Click(sender, e);
            else if (e.KeyCode == Keys.T)
                butcx_Click(sender, e);
        }
    }
}