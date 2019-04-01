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
using YpClass;
using System.IO;

namespace ts_yp_tj
{
    public partial class FrmYptjCWBB : Form
    {
        
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuTag"></param>
        /// <param name="chineseName"></param>
        /// <param name="mdiParent"></param>
        public FrmYptjCWBB(MenuTag menuTag, string chineseName, Form mdiParent)
		{			
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;       
			
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmYptjCWBB_Load(object sender, EventArgs e)
        {
            DbComboYQ();
        }

        /// <summary>
        /// 
        /// </summary>
        public FrmYptjCWBB()
        {
            InitializeComponent();
        }

        private void DbComboYQ()
        {

            // 1 ҩ��  2 ҩ��

            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("id");
            DataColumn dc2 = new DataColumn("name");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            DataRow dr1 = dt.NewRow();
            dr1["id"] = "1";
            dr1["name"] = "ҩ��";

            DataRow dr2 = dt.NewRow();
            dr2["id"] = "2";
            dr2["name"] = "ҩ��";           

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);           

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";

        }

        /// <summary>
        /// ������������м�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butref_Click(object sender, EventArgs e)
        {
            string strYKYFFlag = comboBox1.SelectedValue.ToString();
            string strFromTime = dtp1.Value.ToString("yyyy-MM-dd");
            string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            fpgsymaster(strYKYFFlag, strFromTime, strEndTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="YKYFFlag"></param>
        /// <param name="strFromTime"></param>
        /// <param name="StrToTime"></param>
        private void fpgsymaster(string YKYFFlag,string strFromTime,string StrToTime)
        {
            try
            {
                // 1 ҩ��  2 ҩ��
                string ssql = string.Empty;

                if (YKYFFlag == "1")
                {
                    ssql = @"select
                           (CASE B.N_YPLX WHEN '1' THEN '��ҩ' WHEN '2' THEN '�г�ҩ' WHEN '3' THEN '�в�ҩ' WHEN '5' THEN '����' END) AS YPLXNAME,
                            B.N_YPLX AS YPLX,  SUM(Tpfzje) as pfjzje,'ҩ��' AS DeptName  from yk_tjgysmx as A left join YP_YPCJD as B on A.ypid=B.CJID 
                           left join  yk_tjgyszb AS  C on A.zbId=C.Id 
                           left join YP_YJKS AS D on A.Deptid=D.DEPTID
                           where D.KSLX='ҩ��'  and C.tjsj>='" + strFromTime + "' and C.tjsj<'" + StrToTime + "'  group by B.N_YPLX ";
                          
                }
                if (YKYFFlag == "2")
                {
                    ssql = @"select
                           (CASE B.N_YPLX WHEN '1' THEN '��ҩ' WHEN '2' THEN '�г�ҩ' WHEN '3' THEN '�в�ҩ' WHEN '5' THEN '����' END) AS YPLXNAME,
                            B.N_YPLX AS YPLX,  SUM(Tpfzje) as pfjzje,'ҩ��' AS DeptName  from yk_tjgysmx as A left join YP_YPCJD as B on A.ypid=B.CJID 
                           left join  yk_tjgyszb AS  C on A.zbId=C.Id 
                           left join YP_YJKS AS D on A.Deptid=D.DEPTID
                           where D.KSLX='ҩ��'  and C.tjsj>='" + strFromTime + "' and C.tjsj<'" + StrToTime + "'  group by B.N_YPLX ";
                }
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                this.dg_whmx.AutoGenerateColumns = false;
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.dg_whmx.DataSource = tbmx;

                //this.GrdiDetail.TableStyles[0].MappingName = "tbmx";
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��������" + err.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg_whmx_DoubleClick(object sender, EventArgs e)
        {
            butsh_Click(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butsh_Click(object sender, System.EventArgs e)
        {
            try
            {
                //int nrow = this.dg_whmx.CurrentCell.RowNumber;
                int nrow = this.dg_whmx.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.dg_whmx.DataSource;
                if (tb.Rows.Count == 0) return;
                string strYplxFlag = tb.Rows[nrow]["YPLX"].ToString();
                string strYKYFFlag = comboBox1.SelectedValue.ToString();
                string strFromTime = dtp1.Value.ToString("yyyy-MM-dd");
                string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                fpgsymaster_detail(strYKYFFlag, strYplxFlag, strFromTime, strEndTime);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��������" + err.Message);
            }
        }

        private void fpgsymaster_detail(string YKYFFlag,string YPLXFlag, string strFromTime, string StrToTime)
        {
            try
            {
                // 1 ҩ��  2 ҩ��
                string ssql = string.Empty;

                if (YKYFFlag == "1")
                {
                    ssql = @" select A.ypmc AS YPNAME,SUM(CONVERT(float, ypkcl)) AS YPSL,A.ypdw AS YPDW, SUM(Tpfzje) AS PFJZJE,
                               (select dbo.fun_getDeptname(A.Deptid)) AS DEPTNAME,
                               (select GHDWMC  from YP_GHDW where BDELETE=0 and id=C.gysid) AS GYSNAME  
                               from yk_tjgysmx as A left join YP_YPCJD as B on A.ypid=B.CJID 
                               left join  yk_tjgyszb AS  C on A.zbId=C.Id 
                               left join YP_YJKS AS D on A.Deptid=D.DEPTID 
                               where D.KSLX='ҩ��' and B.N_YPLX='" + YPLXFlag+"'   and C.tjsj>='" + strFromTime + "' and C.tjsj<'" + StrToTime + "'  group by A.ypmc,A.ypdw,A.Deptid,C.gysid " ; 
                              
                }
                if (YKYFFlag == "2")
                {
                    ssql = @"select A.ypmc AS YPNAME,SUM(CONVERT(float, ypkcl)) AS YPSL,A.ypdw AS YPDW, SUM(Tpfzje) AS PFJZJE,
                               (select dbo.fun_getDeptname(A.Deptid)) AS DEPTNAME,
                               (select GHDWMC  from YP_GHDW where BDELETE=0 and id=C.gysid) AS GYSNAME   
                               from yk_tjgysmx as A left join YP_YPCJD as B on A.ypid=B.CJID 
                               left join  yk_tjgyszb AS  C on A.zbId=C.Id 
                               left join YP_YJKS AS D on A.Deptid=D.DEPTID 
                               where D.KSLX='ҩ��' and B.N_YPLX='" + YPLXFlag + "'   and C.tjsj>='" + strFromTime + "' and C.tjsj<'" + StrToTime + "'  group by A.ypmc,A.ypdw,A.Deptid,C.gysid "; 
                }
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                this.GrdiDetail.AutoGenerateColumns = false;
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.GrdiDetail.DataSource = tbmx;

                //this.GrdiDetail.TableStyles[0].MappingName = "tbmx";
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��������" + err.Message);
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            DataToExcel(GrdiDetail);
        }

        /// <summary>
        /// ����EXCEL����
        /// </summary>
        /// <param name="m_DataView">ָ�������ݸ���ͼ����</param>
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



      
    }
}