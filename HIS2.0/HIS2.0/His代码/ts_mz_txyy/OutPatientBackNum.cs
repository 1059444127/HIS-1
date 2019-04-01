using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using System.IO;
using TrasenClasses.GeneralClasses;

namespace ts_mz_txyy
{
    public partial class OutPatientBackNum : Form
    {
        public OutPatientBackNum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("��ѡ���������");
                return;
            }
            string yqid = comboBox1.SelectedValue.ToString();
            string starttime = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endtime = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string deptid = textBox1.Tag.ToString();
            OutPatientBackNumDAL.OutPatientBackNum(yqid, deptid, starttime, endtime, dataGridView1);
        }

        private void OutPatientBackNum_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.AutoGenerateColumns = false;
            OutPatientBackNumDAL.YQ(comboBox1);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            {
                try
                {
                    int nkey = Convert.ToInt32(e.KeyCode);
                    Control control = (Control)sender;

                    if (control.Text.Trim() == "")
                    {
                        control.Text = "";
                        control.Tag = "0";
                        return;
                    }
                    if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
                    { }
                    else
                    {
                        return;
                    }
                    Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);


                    string[] GrdMappingName = new string[] { "����", "ƴ����", "�����", "DEPT_ID", "MZ_FLAG", "ZY_FLAG" };
                    int[] GrdWidth = new int[] { 140, 60, 60, 0, 0, 0 };
                    string[] sfield = new string[] { "", "PY_CODE", "WB_CODE", "", "" };

                    string ssql = "select NAME ,PY_CODE ,WB_CODE ,DEPT_ID,MZ_FLAG,ZY_FLAG from JC_DEPT_PROPERTY where MZ_FLAG=1 and (YQID=0 or YQID='" + comboBox1.SelectedValue + "')";
                    Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                    f.Location = point;
                    f.Text = "����";
                    f.Width = 500;
                    f.ShowDialog();
                    DataRow row = f.dataRow;
                    if (row != null)
                    {
                        (sender as Control).Tag = row["DEPT_ID"].ToString();
                        (sender as Control).Text = row["NAME"].ToString();
                        this.SelectNextControl((Control)sender, true, false, true, true);
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("��������" + err.Message);
                }
            }


        }
        public void DataToExcel(DataGridView m_DataView)
        {
            DataTable dt = m_DataView.DataSource as DataTable;
            try
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    return;
                }

                this.Cursor = PubStaticFun.WaitCursor();
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
                int colCount = dt.Columns.Count;
                int RowCount = dt.Rows.Count;

                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 =textBox1 .Text+ "�����˺���ͳ��";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // ������������
                object[,] objData = new object[RowCount + 1, colCount];
                // ��ȡ�б���
                for (int i = 0; i <= colCount - 1; i++)
                {
                    objData[0, colIndex++] = dt.Columns[i].Caption;
                }
                // ��ȡ����

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= colCount - 1; j++)
                    {
                        objData[i + 1, colIndex++] = "" + dt.Rows[i][j].ToString().Trim();
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
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DataToExcel(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
                return;

            DataTable dt = dataGridView1.DataSource as DataTable;
            ts_mz_txyy.DataSet1 Dset = new ts_mz_txyy.DataSet1();
            DataRow myrow;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                myrow = Dset.��������˺���.NewRow();
                myrow["����"] = Convert.ToString(dt.Rows[i]["����"]);
                myrow["�˺���"] = Convert.ToString(dt.Rows[i]["�˺���"]);
                Dset.��������˺���.Rows.Add(myrow);

            }
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Text = "yq";
            parameters[0].Value = comboBox1.Text;
            parameters[1].Text = "kssj";
            parameters[1].Value = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            parameters[2].Text = "jssj";
            parameters[2].Value = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            parameters[3].Text = "dyr";
            parameters[3].Value = InstanceForm.BCurrentUser.Name;
            parameters[4].Text = "ks";
            parameters[4].Value = textBox1.Text;

            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\��������˺���ͳ��.rpt", parameters, true);

            if (f.LoadReportSuccess)
            {
                f.Show();
            }
            else
                f.Dispose();
        }
    }
}