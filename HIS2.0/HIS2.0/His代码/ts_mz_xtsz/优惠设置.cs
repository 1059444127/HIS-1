using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace ts_mz_xtsz
{
    public partial class Frmyhlx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frmyhlx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void Frmklxsz_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FillData();
        }

        private void FillData()
        {
            string ssql = "select yhmc �Żݷ���,bz ��ע,bqybz ����,id from JC_yhlx order by id";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView1.DataSource = tb;
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                string ssql = "";

                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    int id = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["id"], "0"));
                    string yhmc = tb.Rows[i]["�Żݷ���"].ToString().Trim();
                    int bqybz = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["����"],"0"));
                    string bz = tb.Rows[i]["��ע"].ToString().Trim();

                    if (yhmc == "") throw new Exception("�Żݷ������Ʊ���");

                    if (id == 0)
                        ssql = "insert into JC_yhlx(yhmc,bz,bqybz)values('"+yhmc+"','" + bz  + "'," + bqybz  + ")";
                    else
                        ssql = "update JC_yhlx set yhmc='" + yhmc + "',bz='" + bz + "',bqybz=" + bqybz + " where id=" + id + "";
                    InstanceForm.BDatabase.DoCommand(ssql);
                }
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("����ɹ�");
                FillData();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


        private void butdel_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                if(MessageBox.Show("ɾ�����Żݷ��������������Ż���Ŀ��������ɾ������ȷ��Ҫɾ�� ["+Convertor.IsNull(tb.Rows[nrow]["�Żݷ���"],"")+"] �� ��","ѯ�ʴ�",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return;

                int id = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["id"], "0"));
                string ssql = "delete from JC_yhlx where id=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);
                ssql = "delete from JC_YHBL where yhlx=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);
                dataGridView1.Rows.Remove(dataGridView1.Rows[nrow]);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butnew_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataRow row = tb.NewRow();
            tb.Rows.Add(row);
            dataGridView1.DataSource = tb;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["�Żݷ���"];
            dataGridView1.Focus();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            DataTable tb = (DataTable)dataGridView1.DataSource;
            int nrow = dataGridView1.CurrentCell.RowIndex;
            if (tb.Rows.Count == 0)
            {
                return;
            }

            groupBox3.Text = tb.Rows[nrow]["�Żݷ���"].ToString();
            groupBox3.Tag = tb.Rows[nrow]["ID"].ToString();
            ShowData();
            //tabControl1.SelectTab(1);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                
                if (dataGridView1.CurrentCell.RowIndex != dataGridView1.Rows.Count-1) return;
                if (dataGridView1.CurrentCell.ColumnIndex + 1 <= dataGridView1.Columns.Count-1)
                {
                    if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex + 1].Width > 2)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex + 1];
                        return;
                    }
                }
                if (dataGridView1.CurrentCell.ColumnIndex + 1 > dataGridView1.Columns.Count - 2)
                {
                    butnew_Click(sender, e);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ShowData()
        {
            string sSql = "";
            DataTable tb = new DataTable();

            //��Ŀ�б�
            if (rbXM.Checked)
            {
                sSql = "select code CODE,item_name ����,0.00 �Żݱ��� from jc_stat_item where itemtype<>1 order by code";
            }
            else
            {
                sSql = "select cflx_code CODE,item_name ����,0.00 �Żݱ��� from jc_stat_item where itemtype=1 order by cflx_code";
            }
            tb = InstanceForm.BDatabase.GetDataTable(sSql);
            this.dataGridView2.DataSource = tb;
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            string sSql = "";
            string sCode = "";
            Guid yhlx = new Guid(Convertor.IsNull(this.groupBox3.Tag, "0"));
            DataTable tb = (DataTable)dataGridView2.DataSource;
            int nrow = 0;
            if (dataGridView2.CurrentCell != null)
            {
                nrow = dataGridView2.CurrentCell.RowIndex;
            }
            if (tb.Rows.Count == 0)
            {
                return;
            }

            sCode = tb.Rows[nrow]["CODE"].ToString();
            if (rbXM.Checked)
            {
                sSql = "select case when b.id is null then null else b.id end YHID,item_name ��Ŀ����,case when b.yhbl is null then 0.00 else b.yhbl end �Żݱ���,a.yhmc �Ż�����,c.item_id XMID,2 XMLX,a.id YHLX from JC_HSITEMDICTION c inner join (select * from JC_YHBL where xmly=2 and yhlx='"+yhlx.ToString()+"') b on b.xmid=c.item_id inner join JC_yhlx a on a.id=b.yhlx where c.statitem_code='"+sCode+"' order by YHID";
            }
            else
            {
                sSql = "select case when b.id is null then null else b.id end YHID,s_ypspm ��Ŀ����,case when b.yhbl is null then 0.00 else b.yhbl end �Żݱ���,a.yhmc �Ż�����,c.cjid XMID,1 XMLX,a.id YHLX from yp_ypcjd c inner join (select * from JC_YHBL where xmly=1  and yhlx='" + yhlx.ToString() + "') b on b.xmid=c.cjid inner join JC_yhlx a on a.id=b.yhlx where c.n_yplx=" + sCode + " order by YHID";
            }

            tb = InstanceForm.BDatabase.GetDataTable(sSql);
            this.dataGridView3.DataSource = tb;
        }

        private void rbXM_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void rbYP_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == this.tabPage2 && this.groupBox3.Text == "")
            {
                MessageBox.Show("��ѡ˫��ѡ���Ż�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            string sSql = "";
            string sCode = "";
            string sYhbl = "0.00";
            DataTable tb = (DataTable)dataGridView2.DataSource;
            int nrow = 0;
            if (dataGridView2.CurrentCell != null)
            {
                nrow = dataGridView2.CurrentCell.RowIndex;
            }
            if (tb.Rows.Count == 0)
            {
                return;
            }

            Guid yhlx = new Guid(Convertor.IsNull(this.groupBox3.Tag, "0"));
            sCode = tb.Rows[nrow]["CODE"].ToString();
            sYhbl = tb.Rows[nrow]["�Żݱ���"].ToString();
            if (rbXM.Checked)
            {
                sSql = "select case when b.id is null then -1 else b.id end YHID,item_name ��Ŀ����," + sYhbl + " �Żݱ���,case when a.yhmc is null then '" + groupBox3.Text + "' else a.yhmc end �Ż�����,c.item_id XMID,2 XMLX,case when a.id is null then " + yhlx.ToString() + " else a.id end YHLX from JC_HSITEMDICTION c left join (select * from JC_YHBL where xmly=2  and yhlx='" + yhlx.ToString() + "') b on b.xmid=c.item_id left join JC_yhlx a on a.id=b.yhlx where c.statitem_code='" + sCode + "' order by YHID";
            }
            else
            {
                sSql = "select case when b.id is null then -1 else b.id end YHID,s_ypspm ��Ŀ����," + sYhbl + " �Żݱ���,case when a.yhmc is null then '" + groupBox3.Text + "' else a.yhmc end �Ż�����,c.cjid XMID,1 XMLX,case when a.id is null then " + yhlx.ToString() + " else a.id end YHLX from yp_ypcjd c left join (select * from JC_YHBL where xmly=1 and yhlx='" + yhlx.ToString() + "') b on b.xmid=c.cjid left join JC_yhlx a on a.id=b.yhlx where c.n_yplx=" + sCode + " order by YHID";
            }

            tb = InstanceForm.BDatabase.GetDataTable(sSql);
            this.dataGridView3.DataSource = tb;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            string sSql = "";
            string sId = "";
            DataTable tb = (DataTable)dataGridView3.DataSource;
            int nrow = 0;
            if (tb.Rows.Count == 0)
            {
                return;
            }

            for(int i=0;i<tb.Rows.Count;i++)
            {
                sId = tb.Rows[i]["YHID"].ToString();
                if (sId == "-1")
                {
                    sSql = "insert into JC_YHBL(XMID, XMLY, YHBL, YHLX) values ('" + tb.Rows[i]["XMID"].ToString() + "'," + tb.Rows[i]["XMLX"].ToString() + "," + tb.Rows[i]["�Żݱ���"].ToString() + ",'" + tb.Rows[i]["YHLX"].ToString() + "')";
                }
                else
                {
                    sSql = "update JC_YHBL set YHBL=" + tb.Rows[i]["�Żݱ���"].ToString() + " where id='" + sId+"'";
                }

                InstanceForm.BDatabase.DoCommand(sSql);
            }

            ShowData();
            MessageBox.Show("����ɹ���");
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






    }
}