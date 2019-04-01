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

namespace ts_yp_tj
{
    public partial class Frmtjwh : Form
    {

        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;


        public Frmtjwh(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
        }

        //��ѯ�ĺ�
        private void butref_Click(object sender, EventArgs e)
        {
            string strWhere="";
            
            if(chkdjh.Checked)//���ݺ�
            {
                if(txtdjh.Text.Trim()!="")
                {
                    strWhere+=string.Format(" and a.djh={0}",txtdjh.Text.Trim());
                }
            }

            if(chktjwh.Checked)//�ĺ�
            {
                if(txttjwh.Text.Trim()!="")
                {
                    strWhere+=string.Format(" and a.wh like '%{0}%'",txttjwh.Text.Trim());
                }
            }

            if(chkdjrq.Checked)//����
            {
                DateTime t1=dtp1.Value;
                DateTime t2=dtp2.Value;
                string s1=t1.ToShortDateString()+" 00:00:01";
                string s2=t2.ToShortDateString()+" 23:59:59";
                strWhere+=string.Format(" and a.djsj>='{0}' and a.djsj<='{1}'",s1,s2);
            }

            dg_wh.DataSource=GetTjwh(strWhere,InstanceForm.BDatabase);
        }


        //��õ����ĺ�
        public static DataTable GetTjwh(string str,TrasenClasses.DatabaseAccess.RelationalDatabase db)
        {
            string ssql = string.Format(@" select a.djh ���ݺ�,a.wh �ĺ�,
                    a.whrq �ĺ�����,a.whdw �ĺŵ�λ,dbo.fun_getEmpName(a.djy) �Ǽ���,
                    a.djsj �Ǽ�����,a.id,a.djy from yf_tjwh a where 1=1 ");
            ssql += str;
            DataTable tb_tjwh=db.GetDataTable(ssql);
            return tb_tjwh;
        }


        private void Frmtjws_Activated(object sender, EventArgs e)
        {
            butref_Click(0,e);
        }

        //��ѯ�ĺ���ϸ
        private void btnRef2_Click(object sender, EventArgs e)
        {
            string strWhere = "";

            if (chkdjh2.Checked)//���ݺ�
            {
                if (txtdjh2.Text.Trim() != "")
                {
                    strWhere += string.Format(" and b.djh={0}", txtdjh2.Text.Trim());
                }
            }

            if (chktjwh2.Checked)//�ĺ�
            {
                if (txttjwh2.Text.Trim() != "")
                {
                    strWhere += string.Format(" and b.wh like '%{0}%'", txttjwh2.Text.Trim());
                }
            }

            if (chkrq2.Checked)//����
            {
                DateTime t1 = dtprq1.Value;
                DateTime t2 = dtprq2.Value;
                string s1 = t1.ToShortDateString() + " 00:00:01";
                string s2 = t2.ToShortDateString() + " 23:59:59";
                strWhere += string.Format(" and b.djsj>='{0}' and b.djsj<='{1}'", s1, s2);
            }

            int cjid = Convert.ToInt32(Convertor.IsNull(txtdm.Tag,"0"));
            if (cjid > 0)
            {
                strWhere += string.Format(" and a.cjid={0}",cjid);
            }

            dg_whmx.DataSource = GetTjwhmx(strWhere, InstanceForm.BDatabase);
        }


        //��õ����ĺ���ϸ
        public static DataTable GetTjwhmx(string str, TrasenClasses.DatabaseAccess.RelationalDatabase db)
        {
            string ssql = string.Format(@" select
                                        b.djh ���ݺ�,b.wh �ĺ�,c.S_YPPM Ʒ��,c.S_YPGG ���,
                                        c.SCCJ ����,c.S_YPDW ��λ,a.LSH ��ˮ��,a.ZBJ �б��,
                                        a.ZGLSJ ������ۼ�,a.PXXH �������,a.CJID,a.ID,
                                        b.WHRQ �ĺ�����,b.WHDW �ĺŵ�λ,dbo.fun_getEmpName(b.djy) �Ǽ���,
                                        b.DJSJ �Ǽ�ʱ��,b.DJY,a.DJID 
                                        from yf_tjwhmx a 
                                        inner join yf_tjwh b on a.djid=b.id 
                                        inner join yp_ypcjd c on a.cjid=c.cjid where 1=1 "
                                    );

            ssql += str;
            DataTable tb_whmx = db.GetDataTable(ssql);
            return tb_whmx;
        }

        private void Frmtjwh_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void chktjwh_CheckedChanged(object sender, EventArgs e)
        {
            txttjwh.Enabled = chktjwh.Checked;
        }

        private void chkdjh_CheckedChanged(object sender, EventArgs e)
        {
            txtdjh.Enabled = chkdjh.Checked;
        }

        private void chkdjrq_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = chkdjrq.Checked;
            dtp2.Enabled = chkdjrq.Checked;
        }

        private void chktjwh2_CheckedChanged(object sender, EventArgs e)
        {
            chktjwh2.Enabled = chktjwh2.Checked;
        }

        private void chkdjh2_CheckedChanged(object sender, EventArgs e)
        {
            txtdjh2.Enabled = chkdjh2.Checked;
        }

        private void chkrq2_CheckedChanged(object sender, EventArgs e)
        {
            dtprq1.Enabled = chkrq2.Checked;
            dtprq2.Enabled = chkrq2.Checked;
        }

        private void butnew_Click(object sender, EventArgs e)
        {
            Frmtjwhmx frm = new Frmtjwhmx(_menuTag, _chineseName, _mdiParent);
            Point point = new Point(160, 75);
            frm.Location = point;
            frm.MdiParent = _mdiParent;
            frm.Show();
            frm.FillDj(Guid.Empty);
        }

        private void dg_wh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            DataTable tb = (DataTable)dg_wh.DataSource;
            if (tb.Rows.Count == 0) return;
            Frmtjwhmx f = new Frmtjwhmx(_menuTag, _chineseName, _mdiParent);
            Point point = new Point(160, 75);
            f.Location = point;
            f.Show();
            f.FillDj(new Guid(tb.Rows[e.RowIndex]["id"].ToString()));
        }




    }
}