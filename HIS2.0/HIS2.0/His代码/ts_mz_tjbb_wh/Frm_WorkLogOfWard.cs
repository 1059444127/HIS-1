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
    public partial class Frm_WorkLogOfWard : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_WorkLogOfWard(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void Frm_WorkLogOfWard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
     
        }

        private void Frm_WorkLogOfWard_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 40;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {

            ParameterEx[] parameters = new ParameterEx[4];

            parameters[0].Text = "@WARD_ID";
            parameters[0].Value = "0";

            parameters[1].Text = "@BDATE";
            parameters[1].Value = dtpBjksj.Value.ToString();

            parameters[2].Text = "@EDATE";
            parameters[2].Value = dtpEjksj.Value.ToString();

            parameters[3].Text = "@FLAG";
            parameters[3].Value = 0;




            DataSet dset = new DataSet();
            TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_ZYHS_WARDGZRZ", parameters, dset, "sfmx", 60);

            DataTable dt = dset.Tables[0];
            Fun.AddRowtNo(dt);
            this.dataGridView1.DataSource = dt;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm" || dset.Tables[0].Columns[i].ColumnName.ToLower() == "����")
                {
                    this.dataGridView1.Columns[i].Visible = false;
                }
            }


        }

        private DataTable ChangeColunm(DataTable dt, int ColIndex, int PreColIndex)
        {
            if (ColIndex > PreColIndex)
            {
                for (int i = ColIndex; i > PreColIndex + 1; i--)
                {
                    dt.Columns[i].SetOrdinal(i - 1);
                }
                return dt;
            }
            else
            {
                for (int i = ColIndex; i< PreColIndex; i++)
                {
                    dt.Columns[i].SetOrdinal(i - 1);
                }
                return dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}