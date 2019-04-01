using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using ts_mz_class;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class frmHtdwjedz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private int selIndex = 0; //�����б�ѡ����.
        private DataTable dt_htdw = new DataTable();

        public frmHtdwjedz()
        {
            InitializeComponent();
        }

        public frmHtdwjedz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvInfoList.AutoGenerateColumns = false;
        }

        private void frmHtdwjedz_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dt_now = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                dtpGzsjBeg.Value = dt_now.AddMonths(-1);
                dtpGzsjEnd.Value = dt_now;
                this.cmbZt.SelectedIndex = 0;
                FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
                FunAddComboBox.AddTypeOfContract(true, cmb_htlx, InstanceForm.BDatabase);
                M_Load_HTDW();
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ҳ�����:\n" + ex.Message);
            }
        }

        /// <summary>
        /// ����ʱ��ѯ��ͬ��λ��Ϣ
        /// </summary>
        private void M_Load_HTDW()
        {
            try
            {
                //ȡ�ú�ͬ��λ
                string sql = @"select DWMC as ��λ����,PYM as ƴ����,WBM as ����� from JC_HTDW where BQYBZ='1'  order by ID ";
                dt_htdw = InstanceForm.BDatabase.GetDataTable(sql);
                labelTextBox1.ShowCardProperty[0].ShowCardDataSource = dt_htdw;   
            }
            catch (Exception ex)
            {
                MessageBox.Show("��ʼ����ͬ��λ����: " + ex.Message);
            }
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            selIndex = 0;
            M_Bind();
        }
        private void M_Bind()
        {
            try
            {
                StringBuilder sbr_where = new StringBuilder();
                //��ͬ��λ����
                if (!string.IsNullOrEmpty(this.labelTextBox1.Text.Trim()))
                {
                    sbr_where.Append(" and jh.DWMC = '" + this.labelTextBox1.Text.Trim() + "'");
                }
                //��ͬ����
                if (this.cmb_htlx.Text != "ȫ��" && !String.IsNullOrEmpty(cmb_htlx.Text))
                {
                    sbr_where.Append(" and lx.ID =" + this.cmb_htlx.SelectedValue.ToString());
                }
                //�Һ�Ա
                if (this.cmbuser.Text != "ȫ��" && !String.IsNullOrEmpty(cmbuser.Text))
                {
                    sbr_where.Append(" and mf.SFY =" + this.cmbuser.SelectedValue.ToString());
                }
                //����ʱ��
                sbr_where.Append(" and mf.SFRQ between '" + this.dtpGzsjBeg.Value.ToShortDateString() + " 00:00:00" + "' and '" + this.dtpGzsjEnd.Value.ToShortDateString() + " 23:59:59" + "'");
                //״̬
                if (this.cmbZt.Text.Trim() == "δ����")
                {
                    sbr_where.Append(" and  case when mf.ZJE - mf.SRJE - ISNULL(hd.DZJE, '0.00') > 0 then 0 else 1 end =0");
                }
                else if (this.cmbZt.Text.Trim() == "�Ѻ���")
                {
                    sbr_where.Append(" and  case when mf.ZJE - mf.SRJE - ISNULL(hd.DZJE, '0.00') > 0 then 0 else 1 end = 1");
                }
                //��ʾ
                DataTable dt = GetData(sbr_where.ToString());
                decimal del_jzje = 0;
                decimal del_hsje = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dgvList.DataSource = dt;
                    DataGridViewRow dgvr = this.dgvList.Rows[selIndex];
                    dgvr.Selected = true;
                    this.dgvList.CurrentCell = dgvr.Cells[1];
                    //������ϸ
                    if (dgvr.Cells["clFpid"] != null && !String.IsNullOrEmpty(dgvr.Cells["clFpid"].Value.ToString()))
                    {
                        GetDzListInfo(dgvr.Cells["clFpid"].Value.ToString());
                    }
                    //�ϼƽ��
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        del_jzje += dt.Rows[i]["���"] == null ? 0 : decimal.Parse(dt.Rows[i]["���"].ToString());
                        del_hsje += dt.Rows[i]["���˽��"] == null ? 0 : decimal.Parse(dt.Rows[i]["���˽��"].ToString());
                    }
                }
                else
                {
                    dgvList.DataSource = null;
                    dgvInfoList.DataSource = null;
                }
                lb_total.Text = "Ӧ�������: " + del_jzje.ToString() + " Ԫ.   �Ѻ������: " + del_hsje.ToString() + " Ԫ. ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("��ѯ������Ϣ����: " + ex.Message);
            }
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
        private DataTable GetData(string strWhere)
        {
            DataTable dtTemp = new DataTable();
            string strSql = string.Format(@"SELECT ROW_NUMBER() OVER(ORDER BY jh.DWMC desc,mf.sfrq desc) AS ���,
       mf.FPID                     AS ��Ʊ���,
       mf.SFRQ                     AS ����ʱ��,
       mf.SFY                      AS ������Ա,
       dbo.fun_getEmpName(mf.SFY)  AS ������Ա����,
       lx.LXMC                     AS ��ͬ��λ����,
       jh.DWMC                     AS ��ͬ��λ����,
       mf.ZJE                      AS ���,
       mf.FPH                      AS ��Ʊ��,
       mf.BLH as �����,
       br.BRXM as ��������,
       ISNULL(hd.DZJE, '0.00')       AS ���˽��,
       case when mf.ZJE - ISNULL(hd.DZJE, '0.00') > 0 then 'δ����' else '�Ѻ���' end AS ���˱�ʶ
FROM   MZ_FPB                      AS mf
       INNER JOIN MZ_GHXX          AS mg
            ON  mf.GHXXID = mg.GHXXID  and ISNULL(mg.BQXGHBZ,0)=0
       INNER JOIN YY_BRXX          AS br
            ON  br.BRXXID=mg.BRXXID
       LEFT JOIN JC_HTDWLX AS lx 
            ON mg.HTDWLX = lx.ID
       INNER JOIN JC_HTDW          AS jh
            ON  mg.HTDWID = jh.ID
       LEFT JOIN (select FPID,SUM(JE) as DZJE from MZ_HTDW_DZLOG WHERE BWCBZ='1' group by FPID) AS hd
            ON  mf.FPID = hd.FPID
WHERE mf.JGBM=" + InstanceForm.BCurrentDept.Jgbm + " and  mf.QFGZ>0  and ISNULL(mf.BSCBZ,0) =0  and JLZT=0 ");
            strSql += strWhere;
            dtTemp = InstanceForm.BDatabase.GetDataTable(strSql);
            return dtTemp;
        }

        /// <summary>
        /// ȷ�ϵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQqdz_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null)
            {
                MessageBox.Show("��ѡ�������Ϣ���ٺ������!");
                return;
            }
            M_openPay();
        }
        /// <summary>
        /// ˫���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            M_openPay();
        }        

        /// <summary>
        /// �򿪽ɷ�ҳ��
        /// </summary>
        private void M_openPay()
        {
            try
            {
                DataGridViewRow dgr = dgvList.CurrentRow;
                if (dgr == null) return;
                dgr.Selected = true;
                if (dgr.Cells["clDzbs"].Value.ToString().Equals("�Ѻ���"))
                {
                    MessageBox.Show("�ù��˼�¼�Ѻ���!");
                    return;
                }
                decimal del_je = dgr.Cells["clJe"].Value == null ? 0 : decimal.Parse(dgr.Cells["clJe"].Value.ToString());
                decimal del_dzje = dgr.Cells["clDzje"].Value == null ? 0 : decimal.Parse(dgr.Cells["clDzje"].Value.ToString());
                string str_fpid = dgr.Cells["clFpid"].Value == null ? "" : dgr.Cells["clFpid"].Value.ToString();
                string str_fph = dgr.Cells["clFph"].Value == null ? "" : dgr.Cells["clFph"].Value.ToString();
                if (del_je - del_dzje <= 0)
                {
                    MessageBox.Show("�ù��˼�¼�Ѻ���!");
                    return;
                }
                frmHtdwdzje f = new frmHtdwdzje();
                f.Je = del_je - del_dzje;
                f.fpid = str_fpid;
                f.fph = str_fph;
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    selIndex = dgr.Index;
                    M_Bind();
                    GetDzListInfo(str_fpid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�����쳣:\n_____________\n " + ex.Message);
            }
        }

        /// <summary>
        /// ��Ԫ�񵥻��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgr = dgvList.CurrentRow;
                if (dgr == null) return;
                dgr.Selected = true;
                if (dgr.Index == selIndex) return;
                selIndex = dgr.Index;
                if (dgr.Cells["clFpid"] != null && !String.IsNullOrEmpty(dgr.Cells["clFpid"].Value.ToString()))
                {
                    GetDzListInfo(dgr.Cells["clFpid"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// ��ȡ������ϸ�б�
        /// </summary>
        /// <param name="fpid"></param>
        /// <returns></returns>
        private void GetDzListInfo(string fpid)
        {
            try
            {
                string cmd = String.Format(@"select DZID,FPID,FPH,JE,QRRQ,QRRYXM,case when BWCBZ='1' then '����' else 'δ����' end as DZBS,BZ from MZ_HTDW_DZLOG where FPID='{0}' order by QRRQ desc ", fpid);
                dgvInfoList.DataSource = InstanceForm.BDatabase.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ȡ�õ����������: \n_____________\n" + ex.Message);
            }
        }

       
    }
}