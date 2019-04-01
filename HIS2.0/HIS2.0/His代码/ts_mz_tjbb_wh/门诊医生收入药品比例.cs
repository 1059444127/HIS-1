using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class frmmzysypbl : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public frmmzysypbl(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void frmmzysypbl_Load(object sender, EventArgs e)
        {
            if (!InstanceForm.BCurrentUser.IsAdministrator)
            {
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
            }
            this.WindowState = FormWindowState.Maximized;
            if (radioButtonzy.Checked)
                checkBox1.Visible = true;
            else
                checkBox1.Visible = false;


            BindListNotinXm();
            BindListNotinYp();
            BindListNotinKs();
            BindListinSSF();
        }

        private void btntj_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new DataTable();
            if (radioButtonmz.Checked)
            {
                ParameterEx[] parameter = new ParameterEx[3];
                parameter[0].Text = "@RQ1";
                parameter[0].Value = dtpbegin.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00";
                parameter[1].Text = "@RQ2";
                parameter[1].Value = dtpEnd.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59";
                parameter[2].Text = "@jgbm";
                parameter[2].Value = InstanceForm.BCurrentDept.Jgbm;
                dt = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_MZYS_YPSYBL", parameter, 100);
            }
            else
            {
                ParameterEx[] parameter = new ParameterEx[4];
                parameter[0].Text = "@RQ1";
                parameter[0].Value = dtpbegin.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00";
                parameter[1].Text = "@RQ2";
                parameter[1].Value = dtpEnd.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59";
                parameter[2].Text = "@jgbm";
                parameter[2].Value = InstanceForm.BCurrentDept.Jgbm;
                parameter[3].Text = "@SS_FLAG";
                parameter[3].Value = checkBox1.Checked ? 1 : 0;
                dt = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_ZY_TJ_YSYPSRBL", parameter, 100);
            }
            PubStaticFun.SetDataGridIncreaseRowNumber(dt, "���");
            dataGridView1.DataSource = dt;
        }
        private void BindListinSSF()
        {
            listinssf.Items.Clear();
            string ssql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='SSF' and deleted=0";
            string strarr = "(" + Convert.ToString(InstanceForm.BDatabase.GetDataResult(ssql)) + ")";
            if (strarr == "()")
                return;
            string sql = @"select rtrim(ITEM_NAME) from JC_STAT_ITEM where CODE in " + strarr + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
                listinssf.Items.Add(tb.Rows[i][0].ToString());
        }
        //�󶨲�������Ŀ
        private void BindListNotinXm()
        {
            listnotinxm.Items.Clear();
            string ssql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='XM' and deleted=0";
            string strarr = "(" + Convert.ToString(InstanceForm.BDatabase.GetDataResult(ssql)) + ")";
            if (strarr == "()")
                return;
            string sql = @"select rtrim(ITEM_NAME) from JC_STAT_ITEM where CODE in " + strarr + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
                listnotinxm.Items.Add(tb.Rows[i][0].ToString());
        }
        //�󶨲�����ҩƷ
        private void BindListNotinYp()
        {
            listnotinyp.Items.Clear();
            string ssql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='YP' and deleted=0";
            string strarr = "(" + Convert.ToString(InstanceForm.BDatabase.GetDataResult(ssql)) + ")";
            if (strarr == "()")
                return;
            string sql = @"select * from (select '����ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select 'Ƥ��ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select '����ҩƷ' name 
                                    union all 
                                    select '����ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select '����ҩƷ' name) a where a.name in " + strarr + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
                listnotinyp.Items.Add(tb.Rows[i][0].ToString());
        }
        //�󶨲���������
        private void BindListNotinKs()
        {
            listnotinks.Items.Clear();
            string ssql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='KS' and deleted=0";
            string strarr = "(" + Convert.ToString(InstanceForm.BDatabase.GetDataResult(ssql)) + ")";
            if (strarr == "()")
                return;
            string sql = @" select rtrim(NAME),PY_CODE,WB_CODE,DEPT_ID from JC_DEPT_PROPERTY where LAYER=3 and DELETED=0 and DEPT_ID in " + strarr + " ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
                listnotinks.Items.Add(tb.Rows[i][0].ToString());
        }
        private void radioButtonzy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonzy.Checked)
                checkBox1.Visible = true;
            else
                checkBox1.Visible = false;

        }

        private void btnsz1_Click(object sender, EventArgs e)
        {
            ts_mz_class.Frmxm frmxm = new ts_mz_class.Frmxm(_menuTag, "notinxm", _mdiParent, InstanceForm.BDatabase, InstanceForm.BCurrentUser);
            frmxm.ShowDialog();
            //���°󶨲�������Ŀ����
            BindListNotinXm();
        }

        private void btnsz2_Click(object sender, EventArgs e)
        {
            ts_mz_class.Frmxm frmxm = new ts_mz_class.Frmxm(_menuTag, "notinyp", _mdiParent, InstanceForm.BDatabase, InstanceForm.BCurrentUser);
            frmxm.ShowDialog();
            BindListNotinYp();
        }

        private void btnsz3_Click(object sender, EventArgs e)
        {
            ts_mz_class.Frmxm frmxm = new ts_mz_class.Frmxm(_menuTag, "notinks", _mdiParent, InstanceForm.BDatabase, InstanceForm.BCurrentUser);
            frmxm.ShowDialog();
            BindListNotinKs();
        }

        private void btnsz4_Click(object sender, EventArgs e)
        {
            ts_mz_class.Frmxm frmxm = new ts_mz_class.Frmxm(_menuTag, "inssf", _mdiParent, InstanceForm.BDatabase, InstanceForm.BCurrentUser);
            frmxm.ShowDialog();
            BindListinSSF();
        }

        private void btnesc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region �򵥴�ӡ

                this.btnexcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);
                Excel._Worksheet ws = (Excel._Worksheet)myExcel.ActiveSheet;
                //��ѯ����
                string xm = "";
                if (!checkBox1.Checked)
                    xm = "   ͳ������:����";
                else
                    xm = "   ͳ������:סԺ";
                string swhere = "���ڴ�:" + dtpbegin.Value.ToString() + " ��:" + dtpEnd.Value.ToString() + xm + "  ��������:" + InstanceForm.BCurrentDept.Jgbm; ;


                //д����ͷ
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {

                    SumColCount = SumColCount + 1;
                    myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName.Trim();

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 9;


                //����д�����ݣ�

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        ncol = ncol + 1;
                        myExcel.Cells[6 + i, ncol] = "" + tb.Rows[i][j].ToString().Trim();
                    }
                }

                //���ñ�����Ϊ����Ӧ���
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Font.Size = 9;

                //�ӱ߿�
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //��������
                string ss = Constant.HospitalName + _chineseName;
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
                this.btnexcel.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.btnexcel.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }


    }
}