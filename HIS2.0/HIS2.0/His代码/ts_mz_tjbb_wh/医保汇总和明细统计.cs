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

namespace ts_mz_tjbb
{
    public partial class Frmybhzmxtj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmybhzmxtj(MenuTag menuTag, string chineseName, Form mdiParent)
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
                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "@jgbm";
                parameters[0].Value = Convertor.IsNull(cmbjgbm.SelectedValue, "0");

                parameters[1].Text = "@yblx";
                parameters[1].Value = Convertor.IsNull(cmbyblx.SelectedValue, "0");

                parameters[2].Text = "@rq1";
                parameters[2].Value = dtp1.Value.ToString();

                parameters[3].Text = "@rq2";
                parameters[3].Value = dtp2.Value.ToString();

                parameters[4].Text = "@sfy";
                parameters[4].Value = Convertor.IsNull(cmbsfy.SelectedValue, "0");

                parameters[5].Text = "@brxm";
                parameters[5].Value = txtbrxm.Text.Trim();

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_YB_JSTJ", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                Fun.AddRowtNo(dset.Tables[1]);
                dataGridView1.DataSource = dset.Tables[0];
                dataGridView2.DataSource = dset.Tables[1];

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


        private void Frmjzlscx_Load(object sender, EventArgs e)
        {

            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            FunAddComboBox.AddOperator(true, cmbsfy, InstanceForm.BDatabase);
            FunAddComboBox.AddYblx(true, 0, cmbyblx, InstanceForm.BDatabase);
            cmbsfy.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if (cmbsfy.SelectedValue == null)
                cmbsfy.SelectedValue = "0";
            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtp1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtp2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);
            }
            this.WindowState = FormWindowState.Maximized;
            //Add By Zj 2012-11-06 ������ӡ��ʽ
            string ssql = @"select  1 as dyfs ,'�����������ӡ' as name
                            union 
                            select  2 as dyfs ,'����ϸ�����ӡ' as name
                            union 
                            select  3 as dyfs ,'��ӡ��ϸ����ҳ' as name
                            union 
                            select  4 as dyfs ,'���շ�Ա����' as name";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbdyfs.ValueMember = "dyfs";
            cmbdyfs.DisplayMember = "NAME";
            cmbdyfs.DataSource = tb;
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region �򵥴�ӡ

                this.butexcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //��ѯ����
                string xm = "";

                string swhere = "";

                xm = "    ����:" + cmbjgbm.Text + "  ҽ������:" + cmbyblx.Text + " �շ�Ա:" + cmbsfy.Text + " �շ�����:" + dtp1.Value.ToString() + " �� " + dtp2.Value.ToString();
                swhere = xm;

                //д����ͷ
                DataTable tb = null;
                if (tabControl1.SelectedTab == tabPage1)
                    tb = (DataTable)this.dataGridView1.DataSource;
                else
                    tb = (DataTable)this.dataGridView2.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    //if (checkBox1.Checked == true)
                    //{
                    //    if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "����" )
                    //    {
                    //        SumColCount = SumColCount + 1;
                    //        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    //    }
                    //}
                    //else
                    //{
                    SumColCount = SumColCount + 1;
                    myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    //}

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //����д�����ݣ�

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        //if (checkBox1.Checked == true)
                        //{
                        //    if (tb.Rows[tb.Rows.Count - 1][j].ToString().Trim() != "" && tb.Columns[j].ColumnName != "����" && tb.Columns[j].ColumnName != "ҽ��")
                        //    {
                        //        ncol = ncol + 1;
                        //        myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                        //    }
                        //}
                        //else
                        //{
                        ncol = ncol + 1;
                        myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                        //}
                    }
                }

                //���ñ�����Ϊ����Ӧ���
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //�ӱ߿�
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //��������
                string ss = Constant.HospitalName + "ҽ������ͳ��";
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //�������ƿ��о���
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //��������
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //���һ��Ϊ��ɫ
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;


                //��Excel�ļ��ɼ�
                myExcel.Visible = true;
                this.butexcel.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butexcel.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        private void butprinthz_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                DataTable tbmx = (DataTable)dataGridView1.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.�շ���Ŀ.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.�շ���Ŀ.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.�շ���Ŀ���.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                    }
                    Dset.�շ���Ŀ���.Rows.Add(myrow1);
                }


                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "ҽԺ����";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "�����";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                string ss = "����:" + cmbjgbm.Text;
                if (Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0") ss = ss + " ҽ������:" + cmbyblx.Text.Trim();
                if (Convertor.IsNull(cmbsfy.SelectedValue, "0") != "0") ss = ss + " �շ�Ա:" + cmbsfy.Text.Trim();
                ss = ss + " �շ�����:" + dtp1.Value.ToString() + " �� " + dtp2.Value.ToString();

                parameters[2].Text = "��ע";
                parameters[2].Value = ss;

                parameters[3].Text = "�ֽ��д";
                parameters[3].Value = "";

                parameters[4].Text = "����Ա";
                parameters[4].Value = InstanceForm.BCurrentUser.Name;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_ҽ������ͳ��(����).rpt", parameters);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void butprintmx_Click(object sender, EventArgs e)
        {
            if ( dataGridView2.DataSource == null )
                return;
            try
            {
                DataTable tbmx = (DataTable)dataGridView2.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.�շ���Ŀ.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.�շ���Ŀ.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    if (tbmx.Rows[nrow]["ҽ������"].ToString() != "�ܼ�")
                    {
                        DataRow myrow1 = Dset.�շ���Ŀ���.NewRow();
                        for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                        {
                            int x = i + 1;
                            string nm = "JE" + x.ToString();
                            myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();

                        }
                        Dset.�շ���Ŀ���.Rows.Add(myrow1);
                    }

                }


                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "ҽԺ����";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "�����";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                string ss = "����:" + cmbjgbm.Text;
                if (Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0") ss = ss + " ҽ������:" + cmbyblx.Text.Trim();
                if (Convertor.IsNull(cmbsfy.SelectedValue, "0") != "0") ss = ss + " �շ�Ա:" + cmbsfy.Text.Trim();
                ss = ss + " �շ�����:" + dtp1.Value.ToString() + " �� " + dtp2.Value.ToString();

                parameters[2].Text = "��ע";
                parameters[2].Value = ss;

                parameters[3].Text = "�ֽ��д";
                parameters[3].Value = "";

                parameters[4].Text = "����Ա";
                parameters[4].Value = InstanceForm.BCurrentUser.Name;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_ҽ������ͳ��(��ϸ).rpt", parameters);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnprintmxbfy_Click(object sender, EventArgs e)
        {
            if ( dataGridView2.DataSource == null )
                return;
            try
            {
                DataTable tbmx = (DataTable)dataGridView2.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.�շ���Ŀ.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.�շ���Ŀ.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {

                    DataRow myrow1 = Dset.�շ���Ŀ���.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();

                    }
                    Dset.�շ���Ŀ���.Rows.Add(myrow1);

                }


                ParameterEx[] parameters = new ParameterEx[1];

                parameters[0].Text = "ҽԺ����";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_ҽ������ͳ��(��ϸ����ҳ).rpt", parameters);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            int dyfs = Convert.ToInt32(cmbdyfs.SelectedValue);
            switch (dyfs)
            {
                case 1:
                    butprinthz_Click(sender, e);
                    break;
                case 2:
                    butprintmx_Click(sender, e);
                    break;
                case 3:
                    btnprintmxbfy_Click(sender, e);
                    break;
                case 4:
                    btnsfyhz_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void btnsfyhz_Click(object sender, EventArgs e)
        {
            if ( dataGridView2.DataSource == null )
                return;
            DataTable tb = (DataTable)dataGridView2.DataSource;

            string[] GroupbyField1 ={ "ҽ������", "����Ա" };
            string[] ComputeField1 ={ "������", "�ʻ�֧��", "ͳ��֧��", "����֧��", "�ֽ�֧��" };
            string[] CField1 ={ "sum", "sum", "sum", "sum", "sum" };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tb;
            DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            if (tbcf1.Rows.Count == 0) { return; }
            tbcf1.Columns.Remove("��Ʊ��");
            tbcf1.Columns.Remove("����");
            tbcf1.Columns.Remove("����ʱ��");
            try
            {
                DataTable tbmx = tbcf1;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.�շ���Ŀ.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                }
                Dset.�շ���Ŀ.Rows.Add(myrow);

                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {

                    DataRow myrow1 = Dset.�շ���Ŀ���.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();

                    }
                    Dset.�շ���Ŀ���.Rows.Add(myrow1);

                }


                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "ҽԺ����";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "����";
                parameters[1].Value = "�շ�����:" + dtp1.Value.ToString("yyyy-MM-dd HH:mm:ss") + " �� " + dtp2.Value.ToString("yyyy-MM-dd HH:mm:ss");

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_ҽ������ͳ��(���շ�Ա����).rpt", parameters);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmybhzmxtj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
                btnprint_Click(sender, e);
            if (e.KeyCode == Keys.Q)
                this.Close();
            if (e.KeyCode == Keys.E)
                butexcel_Click(sender, e);

        }

    }
}