using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using YpClass;


namespace ts_yf_cx
{
    public partial class Frmgqyptj : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public Frmgqyptj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void Frmgqyptj_Load(object sender, EventArgs e)
        {
            try
            {

                Yp.AddcmbYjks(cmbyjks, DeptType.ҩ��, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);


                cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;

                if (cmbyjks.SelectedIndex < 0)
                    cmbyjks.Text = "ȫ��";




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTj_Click(object sender, EventArgs e)
        {
            try
            {
                string strph = "select a.deptid,dbo.fun_jc_deptname(a.deptid) ҩ������,a.shrq �������,a.DJH ���ݺ�,b.CJID,b.SHH ����," +
                    "b.YPPM Ʒ��,b.YPSPM ��Ʒ��,b.YPGG ���,b.YPDW ��λ,b.SCCJ ����, b.yppch ���κ�,b.YPPH ����,b.YPXQ ʧЧ����,cast(b.YPSL as float) �������,b.LSJ ���ۼ�," +
                    "cast((select KCL from Yf_KCMX where BDELETE=0 and DEPTID=a.DEPTID and CJID=b.CJID ) as float) ���п����   " +
                    "from YF_DJ a left join yf_djmx b on a.id=b.djid and a.DJH=b.DJH where a.YWLX='016' and b.YPPH<>'������' " +
                    " and SHRQ between '" + dtpshrqB.Value.ToString("yyyy-MM-dd") + "' and '" + dtpshrqE.Value.ToString("yyyy-MM-dd") + "'  "+
                    "and b.YPXQ<='" + dtpXQ.Value.ToString("yyyy-MM-dd") + "' and CJID in (select CJID from Yf_KCMX where BDELETE=0 and KCL>0 and DEPTID=a.DEPTID) ";

                strph += cmbyjks.Text != "ȫ��" ? "and a.DEPTID=" + cmbyjks.SelectedValue.ToString() : "";
                strph += " order by ҩ������,ʧЧ����,���ݺ�,cjid";

                DataTable dtrkmx = InstanceForm.BDatabase.GetDataTable(strph);
                this.dgvgqyp.DataSource = dtrkmx;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable tb = (DataTable)this.dgvgqyp.DataSource;

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
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= dgvgqyp.Columns.Count - 1; i++)
                {
                    if (dgvgqyp.Columns[i].Width > 0)
                        colCount = colCount + 1;
                }

                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = this.Text;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                //��ѯ����
                string bz = "";
                bz = bz + "ҩ������:" + cmbyjks.Text.Trim() + "    ������ڣ���" + dtpshrqB.Value.ToString("yyyy-MM-dd") + " �� " + dtpshrqE.Value.ToString("yyyy-MM-dd");
                bz = bz + "    ʧЧ���ڣ�" + dtpXQ.Value.ToString("yyyy-MM-dd");
                string swhere = "  " + bz;
                // ��������
                Excel.Range rangeT = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT = new object[1, 1];
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                objDataT[0, 0] = swhere;
                range.Value2 = objDataT;



                // ������������
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // ��ȡ�б���
                for (int i = 0; i <= dgvgqyp.Columns.Count - 1; i++)
                {
                    if (dgvgqyp.Columns[i].Width > 0)
                        objData[0, colIndex++] = dgvgqyp.Columns[i].HeaderText;
                }
                // ��ȡ����

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= dgvgqyp.Columns.Count - 1; j++)
                    {
                        if (dgvgqyp.Columns[j].Width > 0)
                        {
                            objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // д��Excel
                range = xlSheet.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Borders.LineStyle = 1;

                //���ñ�����Ϊ����Ӧ���
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Font.Size = 9;

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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}