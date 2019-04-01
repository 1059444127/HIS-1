using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_ClinicalPathWay
{
    public partial class FrmEmrItemRelation : Form
    {
        /// <summary>
        /// ͳ�ƴ���Ŀ
        /// </summary>
        DataTable dtJC_STAT_ITEM;
        /// <summary>
        /// �շ���Ŀ
        /// </summary>
        DataTable dtJC_HSITEM;
        /// <summary>
        /// ҩƷ
        /// </summary>
        DataTable dtVI_YF_KCMX;

        /// <summary>
        /// ������ҳ��Ŀ
        /// </summary>
        DataTable dtJC_BA_XM_NEW;

        /// <summary>
        /// ������Ŀ��Ӧ
        /// </summary>
        DataTable dtBA_XM_DY;

        /// <summary>
        /// ��ӦҩƷ����
        /// </summary>
        DataTable dtBA_XM_DY_YPSX;

        
        string sSqlJC_STAT_ITEM;
        string sSqlJC_HSITEM;
        string sSqlVI_YF_KCMX;

        string sSqlJC_BA_XM_NEW;

        string sSqlBA_XM_DY;
        string sSqlBA_XM_DY_YPSX;

        int iNowDYLX;
        string sBAXM_CODE;

        public FrmEmrItemRelation()
        {
            InitializeComponent();
        }

        void Init()
        {
            #region ���ز�����Ŀ

            this.sSqlJC_BA_XM_NEW = "SELECT CODE,NAME,WBM,PYM FROM dbo.JC_BA_XM_NEW where DELETED=0 order by sortid";
            this.dtJC_BA_XM_NEW = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(this.sSqlJC_BA_XM_NEW);
            DataRow[] drs = dtJC_BA_XM_NEW.Select("len(CODE) = 2");
            this.LoadBA_XM(drs, 2, null);
            //tvBA_XM.ExpandAll();

            #endregion

            #region ����ͳ�ƴ���Ŀ

            this.sSqlJC_STAT_ITEM = "SELECT CODE,ITEM_NAME AS NAME,PY_CODE AS ƴ����,WB_CODE AS ����� FROM JC_STAT_ITEM";
            this.dtJC_STAT_ITEM = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(this.sSqlJC_STAT_ITEM);
            this.dgvJC_STAT_ITEM.DataSource = dtJC_STAT_ITEM;

            #endregion

            #region �����շ���Ŀ

            this.sSqlJC_HSITEM = @"SELECT [ORDER_ID] AS CODE,
                                          a.[ORDER_NAME] AS NAME,
                                                    [BZ] AS ˵��,
                                          [RETAIL_PRICE] AS ����,
                                            [ORDER_UNIT] AS ��λ,
                                             a.[PY_CODE] AS ƴ����,
                                             a.[WB_CODE] AS �����,
                   CAST([ORDER_ID] AS VARCHAR(30)) +'_2' AS KEYCODE ,
                                            [ORDER_TYPE] AS ��Ŀ����
					               FROM [JC_HOITEMDICTION] a left join [JC_HOI_HDI] b on a.ORDER_ID=b.HOITEM_ID
                                   left join [JC_HSITEM] c on b.HDITEM_ID=c.ITEM_ID WHERE a.[DELETE_BIT] = 0 ORDER BY LEN(a.[PY_CODE])";
            this.dtJC_HSITEM = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(this.sSqlJC_HSITEM);
            this.dgvJC_HSITEM.DataSource = dtJC_HSITEM;

            #endregion

            #region ����ҩƷ

            this.sSqlVI_YF_KCMX = @"  SELECT [CJID] AS CODE,
                                           [S_YPPM] AS NAME,
                                           [S_YPJX] AS ����,
                                           [S_SCCJ] AS ˵��,
                                             [YPGG] AS ���,
                                             [HLXS] AS ����,
                            DBO.FUN_YP_YPDW([HLDW]) AS ��λ,
                                              [LSJ] AS ��װ����,
                            DBO.FUN_YP_YPDW([BZDW]) AS ��װ��λ,
                                              [KCL] AS �����,
                            DBO.FUN_YP_YPDW([ZXDW]) AS ��浥λ,
                                            B.[PYM] AS ƴ����,
                                            B.[WBM] AS �����,
                                CAST(isnull([CJID],0) AS VARCHAR(30)) + 
                                CAST(isnull(B.[ID],0) AS VARCHAR(20)) + '_' + 
                                CAST(isnull([DEPTID],0) AS VARCHAR(30)) + '_1' AS KEYCODE,
                                    [STATITEM_CODE] AS ҩƷ����,
                                           A.[GGID] AS ���ID
                                    FROM [VI_YF_KCMX] A LEFT JOIN [YP_YPBM] B ON A.[GGID]=B.[GGID] ORDER BY LEN(B.[PYM])";
            this.dtVI_YF_KCMX = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(this.sSqlVI_YF_KCMX);
            dgvVI_YF_KCMX.DataSource = dtVI_YF_KCMX;

            #endregion

            #region ����ҩƷ����

            this.sSqlBA_XM_DY_YPSX = "SELECT * FROM BA_XM_DY_YPSX";
            this.dtBA_XM_DY_YPSX = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(this.sSqlBA_XM_DY_YPSX);
            dgvYPSX.DataSource = dtBA_XM_DY_YPSX;

            #endregion

            #region ���ز�����Ŀ��Ӧ

            this.sSqlBA_XM_DY = "SELECT * FROM BA_XM_DY";
            this.dtBA_XM_DY = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(this.sSqlBA_XM_DY);
            dgvBA_XM_DY.DataSource = dtBA_XM_DY;

            #endregion

        }

        void LoadBA_XM(DataRow[] drs, int len,string parentKey)
        {
            foreach (DataRow dr in drs)
            {
                string key = dr["CODE"].ToString();
                string text = dr["NAME"].ToString();
                if (parentKey == null)
                {
                    tvBA_XM.Nodes.Add(key, text);
                }
                else
                {
                    tvBA_XM.Nodes.Find(parentKey,true)[0].Nodes.Add(key, text);
                }
                
                DataRow[] drsC =dtJC_BA_XM_NEW.Select(string.Format("len(CODE) = {0} and CODE like '{1}%'", len + 2, key));
                if (drsC.Length > 0)
                {
                    LoadBA_XM(drsC, len + 2, key);
                }
            }
        }

        private void FrmEmrItemRelation_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void tvBA_XM_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.sBAXM_CODE = e.Node.Name;

            dtBA_XM_DY.DefaultView.RowFilter = string.Format("BAXM_CODE = '{0}'", this.sBAXM_CODE);

            if (sBAXM_CODE.Length > 2)
            {
                plRight.Enabled = true;
            }
            else
            {
                plRight.Enabled = false;
            }

            if (dtBA_XM_DY.DefaultView.Count > 0)
            {
                this.iNowDYLX = (int)dtBA_XM_DY.DefaultView[0]["DYLX"];
                RadioCheck((int)dtBA_XM_DY.DefaultView[0]["DYLX"]);
            }
            else
            {
                ClaerCheck();
            }
        }

        void RadioCheck(int iDYLX)
        {
            switch (iDYLX)
            {
                case 1:
                    rbTJDXM.Checked = true;
                    break;
                case 2:
                    rbSFXM.Checked = true;
                    break;
                case 3:
                    rbYP.Checked = true;
                    break;
                case 4:
                    rbYPSS.Checked = true;
                    break;
            }
        }

        void ClaerCheck()
        {
            rbSFXM.Checked = rbTJDXM.Checked = rbYP.Checked = rbYPSS.Checked = false;
            this.iNowDYLX = 0;
        }

        private void rbTJDXM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTJDXM.Checked)
            {
                if (iNowDYLX != 1 && dgvBA_XM_DY.Rows.Count > 0)
                {
                    if (MessageBox.Show("����ѡ�����ͽ�ɾ��֮ǰ���ж�Ӧ��Ŀ,ȷ������?", "��ܰ��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataRow[] drsDel = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND BAXM_CODE = '{1}'", this.iNowDYLX, this.sBAXM_CODE));
                        foreach (DataRow dr in drsDel)
                        {
                            dr.Delete();
                        }

                    }
                    else
                    {
                        RadioCheck(iNowDYLX);
                        return;
                    }
                }
                this.tbSearch.Text = "";
                this.dtJC_STAT_ITEM.DefaultView.RowFilter = "";
                this.iNowDYLX = 1;
                this.dgvJC_STAT_ITEM.Show();
                this.dgvJC_HSITEM.Hide();
                this.dgvVI_YF_KCMX.Hide();
                this.plYPSX.Hide();
                this.tbSearch.Enabled = true;
            }
            else
            {
                HideAll();
            }
        }

        private void rbSFXM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSFXM.Checked)
            {
                if (iNowDYLX !=2 && dgvBA_XM_DY.Rows.Count > 0)
                {
                    if (MessageBox.Show("����ѡ�����ͽ�ɾ��֮ǰ���ж�Ӧ��Ŀ,ȷ������?", "��ܰ��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataRow[] drsDel = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND BAXM_CODE = '{1}'", this.iNowDYLX, this.sBAXM_CODE));
                        foreach (DataRow dr in drsDel)
                        {
                            dr.Delete();
                        }

                    }
                    else
                    {
                        RadioCheck(iNowDYLX);
                        return;
                    }
                }
                this.tbSearch.Text = "";
                this.dtJC_HSITEM.DefaultView.RowFilter = "";
                this.iNowDYLX = 2;
                this.dgvJC_STAT_ITEM.Hide();
                this.dgvJC_HSITEM.Show();
                this.dgvVI_YF_KCMX.Hide();
                this.plYPSX.Hide();
                this.tbSearch.Enabled = true;
            }
            else
            {
                HideAll();
            }
        }

        private void rbYP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYP.Checked)
            {
                if (iNowDYLX != 3 && dgvBA_XM_DY.Rows.Count > 0)
                {
                    if (MessageBox.Show("����ѡ�����ͽ�ɾ��֮ǰ���ж�Ӧ��Ŀ,ȷ������?", "��ܰ��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataRow[] drsDel = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND BAXM_CODE = '{1}'", this.iNowDYLX, this.sBAXM_CODE));
                        foreach (DataRow dr in drsDel)
                        {
                            dr.Delete();
                        }

                    }
                    else
                    {
                        RadioCheck(iNowDYLX);
                        return;
                    }
                }
                this.tbSearch.Text = "";
                this.dtVI_YF_KCMX.DefaultView.RowFilter = "";
                this.iNowDYLX = 3;
                this.dgvJC_STAT_ITEM.Hide();
                this.dgvJC_HSITEM.Hide();
                this.dgvVI_YF_KCMX.Show();
                this.plYPSX.Hide();
                this.tbSearch.Enabled = true;
            }
            else
            {
                HideAll();
            }
        }

        private void rbYPSS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYPSS.Checked)
            {
                if (iNowDYLX != 4 && dgvBA_XM_DY.Rows.Count > 0)
                {
                    if (MessageBox.Show("����ѡ�����ͽ�ɾ��֮ǰ���ж�Ӧ��Ŀ,ȷ������?", "��ܰ��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataRow[] drsDel = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND BAXM_CODE = '{1}'", this.iNowDYLX, this.sBAXM_CODE));
                        foreach (DataRow dr in drsDel)
                        {
                            dr.Delete();
                        }
                    }
                    else
                    {
                        RadioCheck(iNowDYLX);
                        return;
                    }
                }
                this.iNowDYLX = 4;
                this.dgvJC_STAT_ITEM.Hide();
                this.dgvJC_HSITEM.Hide();
                this.dgvVI_YF_KCMX.Hide();
                this.plYPSX.Show();
                this.tbSearch.Enabled = false;
            }
            else
            {
                HideAll();
            }
        }

        void HideAll()
        {
            this.dgvJC_STAT_ITEM.Hide();
            this.dgvJC_HSITEM.Hide();
            this.dgvVI_YF_KCMX.Hide();
            this.plYPSX.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (this.iNowDYLX)
            {
                case 1:
                    AddBA_XM_DY(dgvJC_STAT_ITEM);
                    break;
                case 2:
                    AddBA_XM_DY(dgvJC_HSITEM);
                    break;
                case 3:
                    AddBA_XM_DY(dgvVI_YF_KCMX);
                    break;
                case 4:
                    AddBA_XM_DY(dgvYPSX);
                    break;
            }
        }

        void AddBA_XM_DY(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgv.SelectedRows)
                {
                    if (dtBA_XM_DY.Select(string.Format("BAXM_CODE = '{0}' AND DYLX = '{1}' AND DY_CODE = '{2}'", this.sBAXM_CODE, this.iNowDYLX, dgvr.Cells[0].Value.ToString())).Length == 0)
                    {
                        dtBA_XM_DY.Rows.Add((dtBA_XM_DY.Compute("max(ID)", "").ToString() != "" ? (int)dtBA_XM_DY.Compute("max(ID)", "") : 0) + 1, this.sBAXM_CODE, this.iNowDYLX, dgvr.Cells[0].Value.ToString(), dgvr.Cells[1].Value.ToString());
                    }
                }
            }
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvBA_XM_DY.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("ȷ��ɾ��ѡ�����Ŀ?","��ܰ��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow dgvr in dgvBA_XM_DY.SelectedRows)
                    {
                        dtBA_XM_DY.Select(string.Format("ID = {0}", dgvr.Cells["ID"].Value))[0].Delete();
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = null;
            switch (this.iNowDYLX)
            {
                case 1:
                    dt = this.dtJC_STAT_ITEM;
                    break;
                case 2:
                    dt = this.dtJC_HSITEM;
                    break;
                case 3:
                    dt = this.dtVI_YF_KCMX;
                    break;
            }
            if (dt != null)
            {
                dt.DefaultView.RowFilter = string.Format("ƴ���� like '{0}%' or ƴ���� like '%{0}%' or NAME like '%{0}%'", this.tbSearch.Text.Trim());
            }
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        void Save()
        {
            try
            {
                if (this.dtBA_XM_DY.GetChanges() != null)
                {
                    if (MessageBox.Show("ȷ�����������ĸ���?", "��ܰ��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        this.BindingContext[this.dtBA_XM_DY].EndCurrentEdit();

                        int row = Trasen.Base.DbOpt.Update(this.dtBA_XM_DY, this.sSqlBA_XM_DY);
                        if (row > 0)
                        {
                            this.dtBA_XM_DY.AcceptChanges();
                            this.dtBA_XM_DY = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(this.sSqlBA_XM_DY);
                            dgvBA_XM_DY.DataSource = dtBA_XM_DY;
                            dtBA_XM_DY.DefaultView.RowFilter = string.Format("BAXM_CODE = '{0}'", this.sBAXM_CODE);
                            MessageBox.Show("����ɹ�!", "��ܰ��ʾ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ԭ��" + ex.Message, "����ʧ��");
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEmrItemRelation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dtBA_XM_DY.GetChanges() != null)
            {
                if (MessageBox.Show("�����ĸ�����δ����,�Ƿ����?", "��ܰ��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            List<string> listBA_XM_WDY = new List<string>();
            DataRow[] drsJC_BA_XM_NEW = dtJC_BA_XM_NEW.Select("len(CODE) > 2");
            foreach (DataRow dr in drsJC_BA_XM_NEW)
            {
                if (dtBA_XM_DY.Select(string.Format("BAXM_CODE = '{0}'", dr["CODE"].ToString())).Length == 0)
                {
                    listBA_XM_WDY.Add(dr["NAME"].ToString());
                }
            }
            if (listBA_XM_WDY.Count > 0)
            {
                string sMsg = "";
                foreach (string str in listBA_XM_WDY)
                {
                    sMsg += "[" + str + "]\r\n";
                }
                if (MessageBox.Show("��ǰ����δ���ö�Ӧ����Ŀ:\r\n" + sMsg + "�Ƿ����?", "��ܰ��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}