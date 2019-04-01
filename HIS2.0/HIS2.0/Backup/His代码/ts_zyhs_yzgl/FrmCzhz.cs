using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_zyhs_yzgl
{
    public partial class FrmCzhz : Form
    {
        public FrmCzhz()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �������ݷ���
        /// </summary>
        CzDataAccess czDataAccess = new CzDataAccess();
        /// <summary>
        /// ����
        /// </summary>
        DataTable tbdept = new DataTable();

        /// <summary>
        /// �˳�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncx_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                //��ѯ����
                int deptid = Convert.ToInt32(this.combdept.SelectedValue);
                string starttime = this.dateTimePicker1.Value.ToShortDateString();
                string endtime = this.dateTimePicker2.Value.ToShortDateString();
                bool showxtcz = false;
                if (this.checkBox1.Checked)
                {
                    showxtcz = true;
                }
                DataTable tb = czDataAccess.GetCZStatistics(deptid, starttime, endtime, showxtcz);
                this.dataGridView1.DataSource = tb;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                #region �򵥴�ӡ
                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }
                Excel.Application myExcel = new Excel.ApplicationClass(); //new Excel.Application();
                //�ر�ʱ����ʾ��ʾ
                //myExcel.DefaultFilePath = "";
                //myExcel.DisplayAlerts = false;
                //myExcel.SheetsInNewWorkbook = 1;
                Excel.Workbook xlBook = myExcel.Application.Workbooks.Add(true);

                //��ѯ����
                string rq = "����:" + this.dateTimePicker1.Value.ToShortDateString() + " �� " + this.dateTimePicker2.Value.ToShortDateString();
                string ks = "���ң�" + combdept.Text;

                string swhere = rq;


                //д����ͷ

                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    if (this.dataGridView1.Columns[j].Visible)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = "" + this.dataGridView1.Columns[j].HeaderText;
                    }
                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;

                //����д�����ݣ�
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        if (this.dataGridView1.Columns[j].Visible)
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();
                            //if (tb.Columns[j].ColumnName.IndexOf("����") >= 0)
                            //{
                            //    myExcel.Cells[6 + i, ncol] = "'" + Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i][j].ToString().Trim()) * 100).ToString("0.00") + "%";
                            //}
                        }
                    }
                }

                //���ñ�����Ϊ����Ӧ���
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();//6
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();//6

                //�ӱ߿�
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //��������
                string ss = TrasenFrame.Classes.Constant.HospitalName + "����ͳ�Ʊ�";
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //�������ƿ��о���
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //��������
                myExcel.Cells[2, 1] = ks.Trim();
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[2, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[2, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //���һ��Ϊ��ɫ
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //xlBook.SaveCopyAs("d:\\yy.xls");
                //��Excel�ļ��ɼ�
                myExcel.Visible = true;
                //myExcel.Workbooks.Close();
                if (xlBook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                    xlBook = null;

                }
                if (myExcel != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel);
                    myExcel = null;
                    //xlApp.Quit(); 

                }
                GC.Collect();

                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                //this.btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void combdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btncx_Click(null, null);
        }

        private void FrmCzhz_Load(object sender, EventArgs e)
        {
           combdept.SelectedIndexChanged-=new EventHandler(combdept_SelectedIndexChanged);  
            this.WindowState = FormWindowState.Maximized;
            tbdept = czDataAccess.GetDeptInfo("");
            this.combdept.DisplayMember = "name";
            this.combdept.ValueMember = "id";
            this.combdept.DataSource = tbdept;
            //�ж��Ƿ���ڿ���
            if (czDataAccess.IsExistWardDept(FrmMdiMain.CurrentDept.DeptId.ToString()))
            {
                this.combdept.SelectedValue = FrmMdiMain.CurrentDept.DeptId;
                this.combdept.Enabled = false;
            }
            else
            {
                this.combdept.SelectedValue = -1;
            }
            combdept.SelectedIndexChanged -= new EventHandler(combdept_SelectedIndexChanged);  
        }
    }
}