using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using System.IO;

namespace ts_yp_tj
{
    public partial class FrmYpgysfpDetail : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public FrmYpgysfpDetail()
        {
            InitializeComponent();
        }



        public FrmYpgysfpDetail(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;

          /*  this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            ss = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

             klcfg = new SystemCfg(8024);

             //��ʼ��δ��ҩ�����б�
             FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
             FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tb1"); */
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

        //��䵥��
        public void FillDj(Guid id)
        {
            try
            {
                string ssql = "select * from yk_tjgyszb where id='" + id + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

                this.groupboxdrugdetail.Tag = tb.Rows[0]["id"].ToString();
                this.txtFph.Text = tb.Rows[0]["Fph"].ToString().Trim();
                this.txtZje.Text = tb.Rows[0]["fpzje"].ToString();
                this.txtMemo.Text = tb.Rows[0]["memo"].ToString();

               /* this.dtprq.Value = Convert.ToDateTime(tb.Rows[0]["tjsj"]);
                this.dtpsj.Value = Convert.ToDateTime(tb.Rows[0]["zxrq"]);
                long djh = Convert.ToInt64(tb.Rows[0]["djh"]);
                this.lbldjh.Text = djh.ToString("00000000");*/


                ssql = "SELECT  A.ID,A.ZBID,A.YPID,A.YPMC,A.YPGG,A.YPDW,A.YPKCL,A.YPCJ,A.YPFJ,A.XPFJ,A.TPFZJE,A.YLSJ,A.XLSJ,A.TLSJJE,A.YPPH,A.YPPCH,A.YPHH, " +
                       " (SELECT NAME FROM JC_DEPT_PROPERTY WHERE DEPT_ID=A.DEPTID) AS DEPTNAME,(SELECT GHDWMC FROM YP_GHDW WHERE ID=B.GYSID) AS GYSNAME " +
                       " From  YK_TJGYSMX AS A LEFT JOIN YK_TJGYSZB AS B ON A.ZBID=B.ID  " +
                       " WHERE 1=1 AND  A.ZBID='" + id + "' ORDER BY A.YPID,A.DEPTID ";
                this.GrdiDetail.AutoGenerateColumns = false;
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.GrdiDetail.DataSource = tbmx;   
               
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��������" + err.Message);
            }

        }


        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.GrdiDetail.DataSource;

                // ����Excel����                    --    
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
                string shzt = " ";

                string swhere = "ҩ������:" + " " + "    �ֿ�����:" + " " + "";
                // if (rdowsh.Checked == true) swhere = swhere + " �Ǽ�ʱ��:" + dtp1.Value.ToString() + " �� " + dtp2.Value.ToString();

                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "��Ӧ�̷�Ʊ��������" + shzt;
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
                        

                        //if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width>0)
                        //{
                        //if (tb.Columns[j].Caption == "�����")
                        //    objData[i + 2, colIndex++] = "'" + tb.Rows[i][j].ToString();
                        //else
                        //    objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                        //}
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
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ����EXCEL ����
        /// </summary>
        /// <param name="m_DataView"></param>
        public void DataToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "����EXECL�ļ�";
            kk.Filter = "EXECL�ļ�(*.xls) |*.xls |�����ļ�(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName + ".xls";
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }

                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "����EXCEL�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataToExcel(GrdiDetail);
        }


    }
}