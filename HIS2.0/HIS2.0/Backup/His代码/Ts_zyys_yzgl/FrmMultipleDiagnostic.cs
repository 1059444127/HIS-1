using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TrasenFrame.Classes;

namespace Ts_zyys_yzgl
{
    public partial class FrmMultipleDiagnostic : Form
    {
        private DataSet Dictionnary = new DataSet();
        SystemCfg cfg30000 = new SystemCfg(30000);
        private TextBox _curCtrl;
        //private int yblx = 0;
        //private int ybjklx = 0;
        private string diseaseID = "";
        private string inpatientID = "";
        private string babyID = "";
        private string ybjsID = "";
        private ArrayList _arrList = null;
        private DateTime timesever;

        public FrmMultipleDiagnostic()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �����¼��
        /// </summary>
        /// <param name="arrList">0=inpatient_id 1=inpatient_no 2=baby_id 3=ybjklx 4=yblx 5=""</param>
        public FrmMultipleDiagnostic(ArrayList arrList)
        {
            InitializeComponent();
            _arrList = arrList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable daTable = (DataTable)this.dataGridView1.DataSource;
                if (textBox1.Text.Trim() == "")
                    return;
                DataRow daRow = daTable.NewRow();
                if (this.dataGridView1.Rows.Count == 0)
                {
                    daRow[0] = "��2���";  //�����д��
                }
                else
                {
                    string str = daTable.Rows[daTable.Rows.Count - 1][0].ToString();
                    str = System.Text.RegularExpressions.Regex.Replace(str, @"[^\d.\d]", "");
                    int count = Convert.ToInt32(str.Trim()) + 1;
                    daRow[0] = "��" + count + "���";
                }
                //daRow[1] = _curCtrl.Text;
                //daRow[2] = _curCtrl.Tag;
                daRow[1] = textBox1.Text;
                daRow[2] = textBox1.Tag;
                daRow["ybjbbm"] = lblYbjbbm.Tag == null ? "" : lblYbjbbm.Tag.ToString().Trim();
                daRow["ybjbmc"] = lblYbjbbm.Text.Trim();
                daTable.Rows.Add(daRow);
                this.dataGridView1.DataSource = daTable;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                this.textBox1.Focus();
                this.textBox1.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                _curCtrl = (TextBox)sender;
                if (e.KeyChar == (char)13 && !cardGrid.Visible)
                {
                    switch (_curCtrl.Name)
                    {
                        case "textBox1":
                        case "txtZddm":
                            btnAdd.Focus();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                bool respondKey = false;
                _curCtrl = (TextBox)sender;
                string tableName = "";
                string otherFilter = "";
                string sort = "";
                switch (_curCtrl.Name)
                {
                    case "textBox1":
                        if (e.KeyCode == Keys.Escape)
                        {
                            lblYbjbbm.Text = "";
                            lblYbjbbm.Tag = "";
                            textBox1.Tag = "";
                            textBox1.Text = "";
                            break;
                        }
                        switch (TrasenFrame.Classes.Constant.CustomFilterType)
                        {
                            case TrasenFrame.Classes.FilterType.����:
                                sort = "PY_CODE,WB_CODE,yb_wbm,yb_pym,D_CODE,ITEMNAME";
                                break;
                            case TrasenFrame.Classes.FilterType.ƴ��:
                                sort = "PY_CODE";
                                break;
                            case TrasenFrame.Classes.FilterType.���:
                                sort = "WB_CODE";
                                break;
                            case TrasenFrame.Classes.FilterType.����:
                                sort = "D_CODE";
                                break;
                            default:
                                break;
                        }
                        sort = "py_len,wb_len," + sort;
                        tableName = "DiseaseDiction";
                        if (Convert.ToDateTime(cfg30000.Config.ToString()) > timesever)//2018_01-01 ������µ����Ŀ¼  alter  by chenli
                        {
                            if (Convert.ToInt32(_arrList[4]) > 0)
                            {
                                otherFilter = "ybjklx=" + Convert.ToInt32(_arrList[3]);
                            }
                            else
                            {
                                otherFilter = "ybjklx<=0";
                            }
                        }
                        else
                        {
                            otherFilter = "ybjklx<=0";
                        }
                        break;
                    default:
                        break;
                }
                DataRow dr = TrasenFrame.Classes.WorkStaticFun.GetCardData(_curCtrl, e.KeyValue, -1, cardGrid, 0, Dictionnary, tableName, TrasenFrame.Classes.Constant.CustomFilterType, TrasenFrame.Classes.Constant.CustomSearchType, ref respondKey, otherFilter, sort);



                if ((e.KeyValue == 13 || (e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)) && dr != null)
                {
                    lblYbjbbm.Tag = Convert.ToString(dr["ybjbbm"]);
                    lblYbjbbm.Text = Convert.ToString(dr["ybjbmc"]);
                    _curCtrl.Tag = Convert.ToString(dr["ITEMCODE"]);
                    _curCtrl.Text = Convert.ToString(dr["ITEMNAME"]);

                    textBox1.Tag = _curCtrl.Tag;
                    textBox1.Text = _curCtrl.Text;
                    switch (_curCtrl.Name)
                    {
                        case "textBox1":
                        case "txtZddm":
                            btnAdd.Focus();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = TrasenClasses.GeneralClasses.PubStaticFun.GetInputLanguage("��ʽ����");
        }

        private void LoadIllness()
        {
            
            DataTable dt_timesever=InstanceForm._database.GetDataTable("select getdate() as  time");
            string ssql = "";
            try
            {
                if (Convert.ToDateTime(cfg30000.Config.ToString()) > timesever)
                {
                     ssql = @"SELECT 0 AS ROWNO,CODING AS ITEMCODE,NAME AS ITEMNAME,PY_CODE,WB_CODE,CODING AS D_CODE,YBJKLX,len(py_code) py_len,len(wb_code) wb_len,'' as ybjbbm,'' as ybjbmc,'' as yb_pym,'' as yb_wbm FROM JC_DISEASE WHERE BSCBZ = 0";

                    int ybjklx = int.Parse(_arrList[3].ToString().Trim());
                    int yblx = int.Parse(_arrList[4].ToString().Trim());
                    if (ybjklx == 40 && yblx >= 0)
                    {
                        ssql = @"SELECT 0 AS ROWNO,a.CODING AS ITEMCODE,a.NAME AS ITEMNAME,a.PY_CODE,a.WB_CODE,a.CODING AS D_CODE,a.YBJKLX,len(a.py_code) py_len,len(a.wb_code) wb_len,b.ybjbbm ,b.ybjbmc,b.yb_pym,b.yb_wbm
                                                                        from jc_disease a
                                                                        inner join JC_DISEASE_YYYBDZ b on a.CODING=b.YYJBBM 
                                                                         WHERE a.BSCBZ = 0 and a.ybjklx ='" + ybjklx + "'";
                    }
                }
                else
                {
                    ssql = @"SELECT 0 AS ROWNO,JBBM AS ITEMCODE,JBMC AS ITEMNAME,PYM as PY_CODE,
                                    WBM as WB_CODE,JBBM AS D_CODE,0 YBJKLX,len(PYM) py_len,
                                    len(WBM) wb_len,JBBM as ybjbbm,JBMC as ybjbmc,'' as yb_pym,
                                    '' as yb_wbm FROM JC_Diagnosis_Dict ";
                }

                DataTable tb = InstanceForm._database.GetDataTable(ssql);
                if (tb == null)
                {
                    MessageBox.Show("����δ��ȡ�ü�����Ϣ��", "��ʾ");
                    return;
                }
                tb.TableName = "DiseaseDiction";
                Dictionnary.Tables.Add(tb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cardGrid_DoubleClick(object sender, EventArgs e)
        {
            //if(_curCtrl)
            if (_curCtrl != null)
            {
                _curCtrl.Focus();
                textBox1_KeyUp(_curCtrl, new KeyEventArgs(Keys.Enter));
            }
        }

        private void FrmMultipleDiagnostic_Load(object sender, EventArgs e)
        {
            DataTable dt_timesever=InstanceForm._database.GetDataTable("select getdate() as  time");
            timesever = Convert.ToDateTime(dt_timesever.Rows[0]["time"].ToString());
            int bit = 0;  //δ����
            if (_arrList[5].ToString() == "ҽ������ʱ��")
                bit = 1;



            /*
            if (new TrasenFrame.Classes.SystemCfg(2).Config.Trim() == "��ɳ����ҽҽԺ(��ɳ�еڰ�ҽԺ)")
            {
                string mandalaSql = " select '' as DISEASE_MARK,b.disease_name as DISEASE_NAME,b.disease_code as DISEASE_CODE,b.disease_id as DISEASE_ID,a.inpatient_id as INPATIENT_ID,inpatient_on as INPATIENT_NO,0 as BABY_ID, " + bit + " as YBJS_ID," + TrasenFrame.Forms.FrmMdiMain.Jgbm + " as JGBM from (select * from [172.16.1.200].[mandala].dbo.view_xyzd_his union all select * from [172.16.1.200].[mandala].dbo.view_zyzd_his) a inner join jc_emrvsyb_disease b on a.emr_code = b.emr_code  where inpatient_id = '" + _arrList[0].ToString() + "' and pp_state = 1 and deleted = 0 and disease_ybjklx = 8 ORDER BY emr_zdbz desc";
                DataTable mandalaTable = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(mandalaSql);
                
                //Modefy by Kevin 2014-05-06
                if (mandalaTable.Rows.Count > 0)
                {
                    this.btnAdd.Enabled = false;
                    this.btnDel.Enabled = false;
                    this.btnModify.Enabled = false;
                    this.button1.Enabled = false;
                    this.btnSave.Enabled = false;

                    DataTable dataCpoy = mandalaTable.Copy();

                    for (int i = 0; i < dataCpoy.Rows.Count; i++)
                    {
                        if (i <= 2)
                        {
                            dataCpoy.Rows[i].Delete();
                        }
                    }
                    dataCpoy.AcceptChanges();

                    int j = 4;
                    if (dataCpoy.Columns.Contains("DISEASE_MARK") == true)
                    {
                        for (int i = 0; i < dataCpoy.Rows.Count; i++)
                        {
                            dataCpoy.Rows[i]["DISEASE_MARK"] = "��" + j.ToString() + "���";
                            j++;
                        }
                    }

                    this.dataGridView1.DataSource = dataCpoy;


                }
                else
                {
                    this.btnAdd.Enabled = true;
                    this.btnDel.Enabled = true;
                    this.btnModify.Enabled = true;
                    this.button1.Enabled = true;
                    this.btnSave.Enabled = true;


                    string sSql = "SELECT DISEASE_MARK,DISEASE_NAME,DISEASE_CODE,DISEASE_ID,INPATIENT_ID,INPATIENT_NO,BABY_ID,YBJS_ID,JGBM FROM ZY_DISEASE_MANY WHERE DELETE_BIT = 0 AND JGBM = " + TrasenFrame.Forms.FrmMdiMain.Jgbm + " AND INPATIENT_ID = '" + _arrList[0].ToString() + "' AND YBJS_BIT =" + bit + "";
                    DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
                    this.dataGridView1.DataSource = tb;
                }

            }
            else
            {
                this.btnAdd.Enabled = true;
                this.btnDel.Enabled = true;
                this.btnModify.Enabled = true;
                this.button1.Enabled = true;
                this.btnSave.Enabled = true;
             *  */

            string sSql = "SELECT DISEASE_MARK,DISEASE_NAME,DISEASE_CODE,DISEASE_ID,INPATIENT_ID,INPATIENT_NO,BABY_ID,YBJS_ID,JGBM,YBJBBM,YBJBMC FROM ZY_DISEASE_MANY WHERE DELETE_BIT = 0 AND JGBM = " + TrasenFrame.Forms.FrmMdiMain.Jgbm + " AND INPATIENT_ID = '" + _arrList[0].ToString() + "' AND YBJS_BIT =" + bit + "";
            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
            this.dataGridView1.DataSource = tb;
            /*
            }
             * */



            LoadIllness();

            LoadMemo();
        }

        private void LoadMemo()
        {
            string ts = "1����Ժ�������ġ���Ժ����ϡ�Ϊ��һ��ϣ���¼��ϣ���\r\n";
            ts += "2���ڡ�������ơ�����ʹ�����������ƴ������˫�����߻س�ѡ����Ϻ󣬵���������޸İ�ť���Ὣ����������޸ĵ����Ͻ������ڡ�\r\n";
            ts += "3�������ظ��ڶ����Ĳ��������Ӹ���������Ϣ��\r\n";
            ts += "4��ѡ�����Ͻ������ڵ���ϣ������ɾ����������ɾ�������Ϣ��\r\n";
            ts += "5���������޸ĺ�ɾ������������Ҫ������水ť���������ݿ�����ݲ��ᷢ���ı䡣\r\n";
            ts += "6�������������ϡ���ť�ɻ�ȡ���Ӳ�����¼��������Ϣ����Щ��Ϣ�����ο���ҽ���ɸ��ݴ���Ϣ���ظ��ڶ����Ĳ���������ϡ�";

            txtMemo.Text = ts;
        }

        private void cardGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cardGrid_DoubleClick(null, null);
            }
        }

        private bool cardGrid_myKeyDown(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                cardGrid_DoubleClick(null, null);
            }
            return false;
        }

        private void cardGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            for (int i = 0; i < ((DataTable)grid.DataSource).Rows.Count; i++)
            {
                grid.UnSelect(i);
            }
            grid.Select(grid.CurrentCell.RowNumber);
        }

        /// <summary>
        /// ɾ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable daTable = (DataTable)this.dataGridView1.DataSource;
                if (daTable.Rows.Count > 0)
                {
                    if (TrasenClasses.GeneralClasses.Convertor.IsNull(daTable.Rows[this.dataGridView1.CurrentCell.RowIndex][3].ToString(), "") == "")
                    { }
                    else
                    {
                        if (textBox3.Text.Trim() == "")
                        {
                            textBox3.Text = daTable.Rows[this.dataGridView1.CurrentCell.RowIndex][3].ToString();
                        }
                        else
                        {
                            textBox3.Text += "," + daTable.Rows[this.dataGridView1.CurrentCell.RowIndex][3].ToString();
                        }
                    }

                    daTable.Rows.RemoveAt(this.dataGridView1.CurrentCell.RowIndex);
                }
                //�Ƴ���������֯��ϱ��
                for (int i = 0; i < daTable.Rows.Count; i++)
                {
                    if (i == 0)  //��һ��
                    {
                        daTable.Rows[i][0] = "��2���";
                    }
                    else
                    {
                        string str = daTable.Rows[i - 1][0].ToString();
                        str = System.Text.RegularExpressions.Regex.Replace(str, @"[^\d.\d]", "");
                        int count = Convert.ToInt32(str.Trim()) + 1;
                        daTable.Rows[i][0] = "��" + count + "���";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ���水ť����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sSql = "";
                //if (textBox2.Text.Trim() == "")  //���Ϊ�գ���ֱ��INSERT INTO 
                //{
                //    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                //    {
                //        sSql = String.Format(" INSERT INTO ZY_DISEASE_MANY (INPATIENT_ID ,INPATIENT_NO ,BABY_ID ,DISEASE_MARK ,DISEASE_CODE ,DISEASE_NAME ,JGBM) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6})", _arrList[0], _arrList[1], _arrList[2], this.dataGridView1.Rows[i].Cells[0].Value.ToString(), this.dataGridView1.Rows[i].Cells[2].Value.ToString(), this.dataGridView1.Rows[i].Cells[1].Value.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm);
                //        TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sSql);
                //    }
                //}
                //else  //�����Ϊ�գ��п���UPDAE��Ҳ�п���INSERT INTO
                //{
                //�ö���ȥ�ָ�

                //add pengyang 2015-10-26
                string jbbmcd = string.Empty;
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    jbbmcd += this.dataGridView1.Rows[i].Cells["ybjbbm"].Value.ToString();
                }
                if (jbbmcd.Length > 170)
                {
                    MessageBox.Show("��ҽ��Ҫ�������ܳ��Ȳ��ܳ������ƣ���������", "��ʾ");
                    return;
                }

                string modStr = textBox2.Text.Trim();
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    //if (str.IndexOf(this.dataGridView1.Rows[i].Cells[3].Value.ToString()) >= 0) //����
                    if (TrasenClasses.GeneralClasses.Convertor.IsNull(this.dataGridView1.Rows[i].Cells[3].Value.ToString(), "") != "")
                    {
                        if (modStr.Contains(this.dataGridView1.Rows[i].Cells[3].Value.ToString()))
                        {
                            sSql = " UPDATE ZY_DISEASE_MANY SET DISEASE_MARK = '" + this.dataGridView1.Rows[i].Cells[0].Value.ToString() + "',DISEASE_CODE = '" + this.dataGridView1.Rows[i].Cells[2].Value.ToString() + "',DISEASE_NAME = '" + this.dataGridView1.Rows[i].Cells[1].Value.ToString() + "',ybjbbm='" + this.dataGridView1.Rows[i].Cells["ybjbbm"].Value.ToString() + "',ybjbmc='" + this.dataGridView1.Rows[i].Cells["ybjbmc"].Value.ToString() + "' WHERE DISEASE_ID = '" + this.dataGridView1.Rows[i].Cells[3].Value.ToString() + "'";
                            TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sSql);
                        }
                    }
                    else
                    {
                        //if (this.dataGridView1.Rows[i].Cells[3].Value.ToString() == "" || this.dataGridView1.Rows[i].Cells[3].Value.ToString() == null)
                        //{
                        sSql = String.Format(" INSERT INTO ZY_DISEASE_MANY (INPATIENT_ID ,INPATIENT_NO ,BABY_ID ,DISEASE_MARK ,DISEASE_CODE ,DISEASE_NAME ,JGBM,ybjbbm,ybjbmc) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}')", _arrList[0], _arrList[1], _arrList[2], this.dataGridView1.Rows[i].Cells[0].Value.ToString(), this.dataGridView1.Rows[i].Cells[2].Value.ToString(), this.dataGridView1.Rows[i].Cells[1].Value.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, this.dataGridView1.Rows[i].Cells["ybjbbm"].Value.ToString(), this.dataGridView1.Rows[i].Cells["ybjbmc"].Value.ToString());
                        TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sSql);
                        // }
                    }
                }
                //}
                //Modify By Kevin 2014-01-18 ʼ�ռ�����Ҫɾ�����������
                if (textBox3.Text.Trim() != "")
                {
                    string[] delStr = textBox3.Text.Trim().Split(',');
                    for (int i = 0; i < delStr.Length; i++)
                    {
                        sSql = " DELETE ZY_DISEASE_MANY WHERE DISEASE_ID = " + Convert.ToInt32(delStr[i]) + " ";
                        TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sSql);
                    }
                }

                MessageBox.Show("����ɹ���");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblYbjbbm.Text = this.dataGridView1.CurrentRow.Cells["ybjbmc"].Value.ToString();
                lblYbjbbm.Tag = this.dataGridView1.CurrentRow.Cells["ybjbbm"].Value.ToString();
                textBox1.Tag = this.dataGridView1.CurrentRow.Cells["Column3"].Value.ToString();
                textBox1.Text = this.dataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
                diseaseID = this.dataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
                inpatientID = this.dataGridView1.CurrentRow.Cells["Column5"].Value.ToString();
                babyID = this.dataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
                ybjsID = this.dataGridView1.CurrentRow.Cells["Column8"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable daTable = (DataTable)this.dataGridView1.DataSource;
                //daTable.Rows[this.dataGridView1.CurrentCell.RowIndex][1] = _curCtrl.Text;
                //daTable.Rows[this.dataGridView1.CurrentCell.RowIndex][2] = _curCtrl.Tag;
                if (textBox1.Text.Trim() == "")
                    return;
                if (daTable.Rows.Count > 0)
                {
                    daTable.Rows[this.dataGridView1.CurrentCell.RowIndex][1] = textBox1.Text;
                    daTable.Rows[this.dataGridView1.CurrentCell.RowIndex][2] = textBox1.Tag;
                    daTable.Rows[this.dataGridView1.CurrentCell.RowIndex]["ybjbbm"] = lblYbjbbm.Tag == null ? "" : lblYbjbbm.Tag.ToString().Trim();
                    daTable.Rows[this.dataGridView1.CurrentCell.RowIndex]["ybjbmc"] = lblYbjbbm.Text.Trim();
                    if (textBox2.Text.Trim() == "")
                    {
                        textBox2.Text = diseaseID.ToString();
                    }
                    else
                    {
                        textBox2.Text += "," + diseaseID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string checkFrom = "  SELECT COUNT(1) Y FROM SYSOBJECTS WHERE NAME='BL_BA_NEW_DIAG_INFO' AND TYPE='U' ";
                DataTable dtFrom = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(checkFrom);
                if (Convert.ToInt32(dtFrom.Rows[0]["Y"]) == 1) //����
                {
                    string blSql = "  SELECT DIAG_NO,DIAG_NAME FROM BL_BA_NEW_DIAG_INFO WHERE INPATIENT_ID = '" + _arrList[0].ToString() + "' AND DIAG_METHOD = 4 ";
                    DataTable blTable = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(blSql);
                    this.dataGridView2.DataSource = blTable;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Add By Tany 2015-04-28 ��ȡEMR�����
        private void btEmrZD_Click(object sender, EventArgs e)
        {
            try
            {
                string sSql = "select * from VI_ZY_VINPATIENT_ALL where inpatient_id='" + _arrList[0] + "' and baby_id=" + _arrList[2];
                DataTable myTb = InstanceForm._database.GetDataTable(sSql);
                if (myTb.Rows.Count == 0) return;
                DataTable blTable = TrasenHIS.BLL.HisFunctions.GetEmrDiagnosoisDataTable(myTb.Rows[0]["inpatient_no"].ToString(), myTb.Rows[0]["inpatient_bano"].ToString());

                this.dataGridView2.DataSource = blTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            return;
        }
    }
}