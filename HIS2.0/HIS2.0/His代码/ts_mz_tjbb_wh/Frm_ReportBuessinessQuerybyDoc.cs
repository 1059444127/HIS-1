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
    public partial class Frm_ReportBuessinessQuerybyDoc : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_ReportBuessinessQuerybyDoc( MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            label1.Text = _chineseName;


        }

        private void Frm_ReportBuessinessQuerybyDoc_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

        }

        private void Frm_ReportBuessinessQuerybyDoc_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.panel1.Left = this.Width - this.panel1.Width - 20;
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 40;
            this.label1.Left = (this.Width - this.label1.Width) / 2;
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            try
            {

                ParameterEx[] parameters = new ParameterEx[3];


                parameters[0].Text = "@rq1";
                parameters[0].Value = dtpBjksj.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtpEjksj.Value.ToString();

                parameters[2].Text = "@DocId";
                parameters[2].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_ReportBuessinessQuerybyDoc", parameters, dset, "sfmx", 60);


                Fun.AddRowtNo(dset.Tables[0]);
                DataTable dt= dset.Tables[0];
                dt.Columns.Add("ҩƷ�ܶ�",typeof(decimal));
                dt.Columns.Add("ҩƷ����", typeof(decimal));
                dt.Columns.Add("��ҩ����", typeof(decimal));
                dt.Columns.Add("����ҩ����", typeof(decimal));
                dt.Columns.Add("�г�ҩ����", typeof(decimal));
                dt.Columns.Add("�в�ҩ����", typeof(decimal));
                dt.Columns.Add("�෽����", typeof(decimal));
                dt.Columns.Add("����ҩƷ����", typeof(decimal));
                if (dt.Rows.Count <= 1)
                {
                    dt.Rows[0]["ҩƷ�ܶ�"] = 0;
                    dt.Rows[0]["ҩƷ����"] = 0;
                    dt.Rows[0]["��ҩ����"] = 0;
                    dt.Rows[0]["����ҩ����"] = 0;
                    dt.Rows[0]["�г�ҩ����"] = 0;
                    dt.Rows[0]["�в�ҩ����"] = 0;
                    dt.Rows[0]["�෽����"] = 0;
                    dt.Rows[0]["����ҩƷ����"] = 0;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        decimal num = 0;
                        dt.Rows[i]["ҩƷ�ܶ�"] = Decimal.Parse(dt.Rows[i]["��ҩ"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["����ҩ"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["�г�ҩ"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["�в�ҩ"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["�෽"].ToString()) +
                                               Decimal.Parse(dt.Rows[i]["����ҩƷ"].ToString());
                        decimal total= Decimal.Parse(dt.Rows[i]["�ϼ�"].ToString());
                        if (total != 0)
                        {
                            num = Decimal.Parse(dt.Rows[i]["ҩƷ�ܶ�"].ToString()) / Decimal.Parse(dt.Rows[i]["�ϼ�"].ToString()) * 100;
                            dt.Rows[i]["ҩƷ����"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["��ҩ"].ToString()) / Decimal.Parse(dt.Rows[i]["�ϼ�"].ToString()) * 100;
                            dt.Rows[i]["��ҩ����"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["����ҩ"].ToString()) / Decimal.Parse(dt.Rows[i]["�ϼ�"].ToString()) * 100;
                            dt.Rows[i]["����ҩ����"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["�г�ҩ"].ToString()) / Decimal.Parse(dt.Rows[i]["�ϼ�"].ToString()) * 100;
                            dt.Rows[i]["�г�ҩ����"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["�в�ҩ"].ToString()) / Decimal.Parse(dt.Rows[i]["�ϼ�"].ToString()) * 100;
                            dt.Rows[i]["�в�ҩ����"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["�෽"].ToString()) / Decimal.Parse(dt.Rows[i]["�ϼ�"].ToString()) * 100;
                            dt.Rows[i]["�෽����"] = num.ToString("f2");

                            num = Decimal.Parse(dt.Rows[i]["����ҩƷ"].ToString()) / Decimal.Parse(dt.Rows[i]["�ϼ�"].ToString()) * 100;
                            dt.Rows[i]["����ҩƷ����"] = num.ToString("f2");
                        }
                        else
                        {
                            dt.Rows[i]["ҩƷ����"] =0;
                            dt.Rows[i]["��ҩ����"] = 0;
                            dt.Rows[i]["����ҩ����"] =0;
                            dt.Rows[i]["�г�ҩ����"] = 0;
                            dt.Rows[i]["�в�ҩ����"] =0;
                            dt.Rows[i]["�෽����"] = 0;
                            dt.Rows[i]["����ҩƷ����"] = 0;
                        }
                       

                    }
                }
                int col = 4;
                dt.Columns["ҩƷ�ܶ�"].SetOrdinal(col); ++col;
                dt.Columns["ҩƷ����"].SetOrdinal(col); ++col;
                dt.Columns["��ҩ"].SetOrdinal(col); ++col;
                dt.Columns["��ҩ����"].SetOrdinal(col); ++col;
                dt.Columns["����ҩ"].SetOrdinal(col); ++col;
                dt.Columns["����ҩ����"].SetOrdinal(col); ++col;
                dt.Columns["�г�ҩ"].SetOrdinal(col); ++col;
                dt.Columns["�г�ҩ����"].SetOrdinal(col); ++col;
                dt.Columns["�в�ҩ"].SetOrdinal(col); ++col;
                dt.Columns["�в�ҩ����"].SetOrdinal(col); ++col;
                dt.Columns["�෽"].SetOrdinal(col); ++col;
                dt.Columns["�෽����"].SetOrdinal(col); ++col;
                dt.Columns["����ҩƷ"].SetOrdinal(col); ++col;
                dt.Columns["����ҩƷ����"].SetOrdinal(col); ++col;

                this.dataGridView1.DataSource =dt;
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm" || this.dataGridView1.Columns[i].Name.ToLower() == "sort")
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}