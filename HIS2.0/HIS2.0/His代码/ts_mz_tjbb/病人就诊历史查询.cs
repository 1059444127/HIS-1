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
    public partial class Frmzdyzdcx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmzdyzdcx(MenuTag menuTag, string chineseName, Form mdiParent)
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
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@jzrq1";
                parameters[0].Value = dtpjzsj1.Value.ToString();

                parameters[1].Text = "@jzrq2";
                parameters[1].Value = dtpjzsj2.Value.ToString();

                parameters[2].Text = "@zdmc";
                parameters[2].Value = txtzdmc.Text;


                DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("SP_mz_select_zdyzdcx", parameters, 30);
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


        private void Frmjzlscx_Load(object sender, EventArgs e)
        {

            dtpjzsj1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortDateString() + " 00:00:00");
            dtpjzsj2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortDateString() + " 23:59:59");

            this.WindowState = FormWindowState.Maximized;
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( this.dataGridView1.DataSource == null )
                return;
            try
            {

                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                // ����Excel����                    --LeeWenjie    2006-11-29
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
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                        colCount = colCount + 1;
                }

                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = this.Text ;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // ������������
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // ��ȡ�б���
                for (int i = 0; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                        objData[0, colIndex++] = dataGridView1.Columns[i].HeaderText;
                }
                // ��ȡ����

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        if (dataGridView1.Columns[j].Visible == true)
                        {
                            if (dataGridView1.Columns[j].HeaderText == "�����" || dataGridView1.Columns[j].HeaderText == "���֤��" || dataGridView1.Columns[j].HeaderText == "����")
                                objData[i + 1, colIndex++] = "'" + tb.Rows[i][j].ToString();
                            else
                                objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // д��Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

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

    }
}