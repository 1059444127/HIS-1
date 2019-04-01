using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class Frm_MZ_BusinessReport : Form
    {
         private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//ͳ��ʱ��Ʊ��¼����
        private long Jkid = 0;//����ID
        private int _item = 0;


        private List<string> _dt;
        public Frm_MZ_BusinessReport(MenuTag menuTag, string chineseName, Form mdiParent,int item)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            label1.Text = _chineseName;
            this._item = item;


        }


        private void GetData()
        {
            try
            {

                    ParameterEx[] parameters = new ParameterEx[4];
                 

                    parameters[0].Text = "@rq1";
                    parameters[0].Value = dtpBjksj.Value.ToString();
     
                    parameters[1].Text = "@rq2";                
                    parameters[1].Value = dtpEjksj.Value.ToString();

                    parameters[2].Text = "@DeptID";
                    parameters[2].Value = "0";

                    parameters[3].Text = "@ksType";
                    if (this._item == 0)
                    {
                        parameters[3].Value = "0";
                    }
                    else
                    {
                        parameters[3].Value = cmbGroup.SelectedIndex == 2 ? 0 : (cmbGroup.SelectedIndex + 1);
                    }

                    DataSet dset = new DataSet();
                    if (this._item == 0)
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_Report_MZ_Bussiness", parameters, dset, "sfmx", 60);
                    }
                    else
                    {
                        TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_Report_MZ_Bussiness_mx", parameters, dset, "sfmx", 60);
                    }
                   

                    Fun.AddRowtNo(dset.Tables[0]); 
                    
                    this.dataGridView1.DataSource = dset.Tables[0];
                    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                    {
                        this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm")
                        {
                            this.dataGridView1.Columns[i].Visible = false;
                        }
                    }
              
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Frm_MZ_BusinessReport_Load(object sender, EventArgs e)
        {


            //FunAddComboBox.AddOperator(true, cmbuser);
            this.WindowState = FormWindowState.Maximized;

            
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");



            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');


            //cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            //if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            //if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
            //    this.cmbuser.SelectedValue = "0";
            //FullCmbSfDept(); 
            //FunAddComboBox.AddJgbm(true, cmbSource, InstanceForm.BDatabase);
   
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;

            if (this._item == 0)
            {
                label2.Visible = false;
                cmbGroup.Visible = false;
            }
            else
            {
                label2.Visible = true;
                cmbGroup.Visible = true;
            }
            cmbGroup.SelectedIndex = 0;
           

        }
        /// <summary>
        /// ����շѿ������� add by zp 2013-05-23 ����ʡֱ��ҽԺ����
        /// </summary>
        //private void FullCmbSfDept()
        //{
        //    try
        //    {
        //        SystemCfg cfg1086 = new SystemCfg(1086);
        //        string sql = @"select dept_id,name from jc_dept_property where dept_id in (" + cfg1086.Config + ")";
        //        DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
        //        DataRow dr = dt.NewRow();
        //        dr["dept_id"] = "-1";
        //        dr["name"] = "�����շѿ���";
        //        dt.Rows.InsertAt(dr, 0);
        //        //this.Cmb_SfDept.DataSource = dt;
        //        //this.Cmb_SfDept.DisplayMember = "name";
        //        //this.Cmb_SfDept.ValueMember = "dept_id";
        //        //this.Cmb_SfDept.SelectedIndex = 0;
        //    }
        //    catch (Exception ea)
        //    {
        //        MessageBox.Show("���ִ���!ԭ��:" + ea.ToString(), "����");
        //    }
        //}

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void buttj_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = null;
                string ss = "";
                tb = (DataTable)this.dataGridView1.DataSource;
                ss = this._chineseName;



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
                    colCount = colCount + 1;
                }


                //��ѯ����
                string swhere = "";
                swhere = " �Ƿ����ڴ�:" + dtpBjksj.Value.ToString() + "���� " + dtpEjksj.Value.ToString();


                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = ss;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // ��������
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;

                // ������������
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // ��ȡ�б���
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    objData[1, colIndex++] = tb.Columns[i].Caption;
                }
                // ��ȡ����
                objData[0, 0] = swhere;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
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
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butprint_Click(object sender, EventArgs e)
        {
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

                parameters[0].Text = "����";
                parameters[0].Value = this._chineseName;

                parameters[1].Text = "��ʼʱ��";
                parameters[1].Value = dtpBjksj.Value.ToString("yyyy-MM-dd");

                parameters[2].Text = "����ʱ��";
                parameters[2].Value = dtpBjksj.Value.ToString("yyyy-MM-dd");

                       

                TrasenFrame.Forms.FrmReportView f = null;

                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\�������뱨��(����).rpt", parameters);
              
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

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void buttj_Click_1(object sender, EventArgs e)
        {

        }

        private void butprint_Click_1(object sender, EventArgs e)
        {

        }

        private void butexcel_Click_1(object sender, EventArgs e)
        {

        }

        private void butquit_Click_1(object sender, EventArgs e)
        {

        }

        private void Frm_MZ_BusinessReport_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
            this.label1.Left = (this.Width - this.label1.Width) / 2;
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 40;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbDepartMentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ckbJkrq_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtpEjksj_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dtpBjksj_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Frm_MZ_BusinessReport_Resize_1(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 40;
            this.label1.Left = (this.Width - this.label1.Width) / 2;
        }

    }
}