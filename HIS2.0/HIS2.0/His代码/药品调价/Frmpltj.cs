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


namespace ts_yp_tj
{
    public partial class Frmpltj : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        //��-ƥ��  ��-¼��
        private string strpp = "��";
        private string strlr = "��";
        private string strjj = "��";
        private DataTable tb_whmx = new DataTable();

        public Frmpltj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void Frmpltj_Load(object sender, EventArgs e)
        {
            this.dg_tjmx.DataError += new DataGridViewDataErrorEventHandler(dg_tjmx_DataError);

            int deptid = InstanceForm.BCurrentDept.DeptId;
            string ssql = string.Format(@" select a.yppm Ʒ��,a.ypspm ��Ʒ��,a.ypgg ���,
                                        a.S_SCCJ ����,b.WBM �����,b.PYM ƴ����,a.CJID 
                                        from vi_yk_kcmx a inner join YP_YPBM b on a.GGID=b.GGID
                                        where a.deptid ={0} ",deptid);
            DataTable tb_kcmx = InstanceForm.BDatabase.GetDataTable(ssql);
            txtdm.ShowCardProperty[0].ShowCardDataSource = tb_kcmx;

            ssql = string.Format(@" select cast(b.zglsj as decimal(15,2)) ������ۼ�,cast(b.zbj as decimal(15,2)) �б��,a.djsj �Ǽ�����,
                                a.wh �ĺ�,a.whrq �ĺ�����,b.id,b.cjid from yf_tjwh a inner join yf_tjwhmx b on a.id=b.djid ");
            tb_whmx = InstanceForm.BDatabase.GetDataTable(ssql);
            dg_tjmx.ShowCardProperty[0].ShowCardDataSource = tb_whmx;
            txttjwh.Focus();
            
        }

        void dg_tjmx_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            if (tb_tjmx.Rows[e.RowIndex][e.ColumnIndex] is DBNull)
            {
                return;
            }
            if (e.RowIndex >= 0)
            {
                //tb_tjmx.Rows[e.RowIndex][e.ColumnIndex] = DBNull.Value;
                dg_tjmx.Rows[e.RowIndex].Cells[e.RowIndex].Value = tb_tjmx.Rows[e.RowIndex][e.ColumnIndex];
                
            }
            else
            {
                dg_tjmx.CancelEdit();
            }
        }

        #region ������Բ�ѯ��
        /// <summary>
        /// ���ҩƷ������
        /// </summary>
        private void AddTreeYplx()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;

            DataTable tb = Yp.SelectYPLX(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode node = treeView1.Nodes.Add(tb.Rows[i]["mc"].ToString());
                node.Tag = " and yplx=" + Convert.ToInt32(tb.Rows[i]["id"]) + "";
                node.ImageIndex = 0;
                DataTable tbc = Yp.SelectYpzlx(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(tb.Rows[i]["id"]), InstanceForm.BDatabase);
                for (int j = 0; j <= tbc.Rows.Count - 1; j++)
                {
                    TreeNode Cnode = node.Nodes.Add(tbc.Rows[j]["mc"].ToString());
                    Cnode.Tag = " and yplx=" + Convert.ToInt32(tb.Rows[i]["id"]) + " and ypzlx=" + Convert.ToInt32(tbc.Rows[j]["id"]);
                    Cnode.ImageIndex = 1;
                }
                node.Expand();
            }

            TreeNode node1 = treeView1.Nodes.Add("û�з����ҩƷ");
            node1.ImageIndex = 1;
            node1.Tag = " and (yplx=0 or ypzlx=0) ";
        }


        /// <summary>
        /// ���ҩƷ������
        /// </summary>
        private void AddTreeYpjx()
        {
            this.treeView1.Nodes.Clear();
            //			DataTable tb=Yp.SelectYPLX(InstanceForm.BCurrentDept.DeptId);
            //			for(int i=0 ;i<=tb.Rows.Count-1;i++)
            //			{
            TreeNode node = treeView1.Nodes.Add("����");
            node.Tag = "";
            //				node.Tag=" and yplx="+Convert.ToInt32(tb.Rows[i]["id"])+"";
            //				node.ImageIndex=0;
            //				DataTable tbc=Yp.SelectYpjx(Convert.ToInt32(tb.Rows[i]["id"]));
            DataTable tbc = Yp.SelectYpjx(0, InstanceForm.BDatabase);
            for (int j = 0; j <= tbc.Rows.Count - 1; j++)
            {
                TreeNode Cnode = node.Nodes.Add(tbc.Rows[j]["mc"].ToString());
                Cnode.Tag = "  and ypjx=" + Convert.ToInt32(tbc.Rows[j]["id"]);
                //Cnode.Tag=" and yplx="+Convert.ToInt32(tb.Rows[i]["id"])+" and ypjx="+Convert.ToInt32(tbc.Rows[j]["id"]);
                Cnode.ImageIndex = 1;
            }
            node.Expand();

            TreeNode node1 = treeView1.Nodes.Add("û�з����ҩƷ");
            node1.ImageIndex = 1;
            node1.Tag = " and (ypjx=0 or ypjx not in(select id from yp_ypjx) ) ";
            //			}
        }


        /// <summary>
        /// ������Ա�־��
        /// </summary>
        private void AddTreeYpsx()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;
            TreeNode node = treeView1.Nodes.Add("����״̬");
            node.Tag = "";
            TreeNode Cnode2 = node.Nodes.Add("����ҩƷ");
            Cnode2.Tag = " and djyp=1 ";
            Cnode2.ImageIndex = 1;
            TreeNode Cnode3 = node.Nodes.Add("����ҩƷ");
            Cnode3.Tag = " and mzyp=1 ";
            Cnode3.ImageIndex = 1;
            TreeNode Cnode4 = node.Nodes.Add("Ƥ��ҩƷ");
            Cnode4.Tag = " and psyp=1 ";
            Cnode4.ImageIndex = 1;
            TreeNode Cnode5 = node.Nodes.Add("����ҩƷ");
            Cnode5.Tag = " and jsyp=1 ";
            Cnode5.ImageIndex = 1;
            TreeNode Cnode6 = node.Nodes.Add("����ҩƷ");
            Cnode6.Tag = " and gzyp=1 ";
            Cnode6.ImageIndex = 1;

            TreeNode Cnode20 = node.Nodes.Add("����ҩƷ");
            Cnode20.Tag = " and wyyp=1 ";
            Cnode20.ImageIndex = 1;

            TreeNode Cnode7 = node.Nodes.Add("����ҩƷ");
            Cnode7.Tag = " and cfyp=1 ";
            Cnode7.ImageIndex = 1;

            TreeNode Cnode21 = node.Nodes.Add("����ҩƷ");
            Cnode21.Tag = " and rsyp=1 ";
            Cnode21.ImageIndex = 1;

            TreeNode Cnode22 = node.Nodes.Add("�б�ҩƷ");
            Cnode22.Tag = " and zbzt=1 ";
            Cnode22.ImageIndex = 1;

            TreeNode Cnode32 = node.Nodes.Add("����ҩ��");
            Cnode32.Tag = " and GJJBYW=1 ";
            Cnode32.ImageIndex = 1;

            TreeNode Cnode33 = node.Nodes.Add("��ΣҩƷ");
            Cnode33.Tag = " and GWYP=1 ";
            Cnode33.ImageIndex = 1;

            TreeNode Cnode13 = node.Nodes.Add("ͣ�õ�ҩƷ");
            Cnode13.Tag = " and b.BDELETE=1 ";
            Cnode13.ImageIndex = 1;

            TreeNode Cnode14 = node.Nodes.Add("�ﰴ��װȡ��");
            Cnode14.Tag = " and lyfs=1 ";
            Cnode14.ImageIndex = 1;
            TreeNode Cnode15 = node.Nodes.Add("�ﰴ�����ۼ�");
            Cnode15.Tag = " and lyfs=2 ";
            Cnode15.ImageIndex = 1;

            TreeNode Cnode16 = node.Nodes.Add("��������ҽʦ��ҩ");
            Cnode16.Tag = " and cfjb=1 ";
            Cnode16.ImageIndex = 1;
            TreeNode Cnode17 = node.Nodes.Add("��������ҽʦ��ҩ");
            Cnode17.Tag = " and cfjb=2 ";
            Cnode17.ImageIndex = 1;
            TreeNode Cnode18 = node.Nodes.Add("������ҽʦ��ҩ");
            Cnode18.Tag = " and cfjb=3 ";
            Cnode18.ImageIndex = 1;
            TreeNode Cnode19 = node.Nodes.Add("����ҽʦ��ҩ");
            Cnode19.Tag = " and cfjb=4 ";
            Cnode19.ImageIndex = 1;

            //ͳ�����
            string ssql = "select * from yp_tlfl ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode Cnode30 = node.Nodes.Add("��" + Convertor.IsNull(tb.Rows[i]["name"], ""));
                Cnode30.Tag = " and a.tlfl='" + Convertor.IsNull(tb.Rows[i]["code"], "") + "' ";

                Cnode30.ImageIndex = 1;
            }

            //modefy by lwl 2011-10-19
            //�����صȼ�
            string ksssql = "select * from YP_KSSDJ";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(ksssql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode Cnode31 = node.Nodes.Add("��" + Convertor.IsNull(dt.Rows[i]["KSSDJMC"], ""));
                Cnode31.Tag = " and a.KSSDJID='" + Convertor.IsNull(dt.Rows[i]["KSSDJID"], "") + "' ";

                Cnode31.ImageIndex = 1;
            }




            node.Expand();


        }

        /// <summary>
        /// ���ҩ�������
        /// </summary>
        /// <param name="tb">ҩ������</param>
        /// <param name="treeNode">��ǰ�ڵ�</param>
        /// <param name="fid">��ID</param>
        private void AddTreeYlfl(DataTable tb, TreeNode treeNode, long fid)
        {
            treeNode.Nodes.Clear();
            DataRow[] rows = tb.Select(" fid=" + fid + "");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                TreeNode Cnode = treeNode.Nodes.Add(rows[i]["flmc"].ToString());
                Cnode.Tag = " and ylfl=" + Convert.ToInt64(rows[i]["id"]) + " ";
                Cnode.Tag = " and ylfl in(select id from dbo.fun_tlfl_child(" + Convertor.IsNull(rows[i]["id"], "") + ")) ";
                if (rows[i]["yjdbz"].ToString() == "1") Cnode.ImageIndex = 1; else Cnode.ImageIndex = 0;
                AddTreeYlfl(tb, Cnode, Convert.ToInt64(rows[i]["id"]));
            }
        }



        /// <summary>
        /// ҩƷ����ѡ��ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex.ToString())
            {
                case "0":
                    this.AddTreeYpsx();
                    break;
                case "1":
                    this.AddTreeYplx();
                    break;
                case "2":
                    this.AddTreeYpjx();
                    break;
                case "3":
                    this.treeView1.Nodes.Clear();
                    this.treeView1.ImageList = this.imageList1;
                    TreeNode node = treeView1.Nodes.Add("ҩ�����Ŀ¼");
                    node.Tag = " and ylfl<>-1 ";
                    node.ImageIndex = 0;

                    TreeNode nodenull = treeView1.Nodes.Add("�� û�з����ҩƷ");
                    nodenull.Tag = " and ylfl=0 ";
                    nodenull.ImageIndex = 1;

                    DataTable tb = Yp.SelectYlfl(InstanceForm.BDatabase);
                    this.AddTreeYlfl(tb, node, 0);
                    node.Expand();
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void csdj(int shbz,Guid id)
        {
            DateTime tnow = Convert.ToDateTime(InstanceForm.BDatabase.GetDataRow(InstanceForm.BDatabase.GetServerTimeString())[0].ToString());//������ʱ��
            if (shbz == 0)
            {
                if (id == Guid.Empty)
                {
                    lbldjh.Text = "";
                    lblsdjh.Text = "";
                    txttjwh.Text = "";
                    dtprq.Value = tnow;
                    dtpsj.Value = tnow;
                    txtbz.Text = "";
                    txttjxs.Text = "";
                    chkbljzx.Checked = false;
                    lbldjh.Tag = null;
                }

                txtbz.Enabled = true;//��ע
                dtprq.Enabled = true;//����
                dtpsj.Enabled = true;//ʱ��
                txttjxs.Enabled = true;//ϵ��
                chkbljzx.Enabled = true;//����ִ��
                txttjwh.Enabled = true;//�ĺ�
                btnqxmx.Enabled = true;
                btnzx.Enabled = true;
            

            }
            else
            {
                txttjwh.Enabled = false;
                dtprq.Enabled = false;
                dtpsj.Enabled = false;
                txtbz.Enabled = false;
                txttjxs.Enabled = false;
                chkbljzx.Enabled = false;
                btnqxmx.Enabled = false;
                btnzx.Enabled = false;
            }
        }

        private void csdjmx(int shbz)
        { 
            
        }

        public void FillDj(Guid id,int zxbz)
        {
            int deptid = InstanceForm.BCurrentDept.DeptId;
            Guid zxdjid = Guid.Empty; //ִ�е���id
            string ssql = "";

            if (id == Guid.Empty)
            {
                col��������.Visible = false;
            }
            else
            {
                col��������.Visible = true;
            }
            if (zxbz == 0)
            {
                colss.Visible = true;
            }
            else
            {
                colss.Visible = false;
            }
            
            #region ��ȡ����ͷ��Ϣ
           
            ssql = string.Format(" select * from yf_tj where id='{0}'", id);
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                lbldjh.Text = row["djh"].ToString();
                lbldjh.Tag = id;
                //lblsdjh.Text = row["sdjh"].ToString();
                DateTime zxsj = Convert.ToDateTime(row["zxrq"].ToString());
                dtprq.Value = zxsj;
                dtpsj.Value = zxsj;
                chkbljzx.Checked = Convert.ToBoolean(row["bljzx"]);
                txttjwh.Text = row["tjwh"].ToString();
                txttjxs.Text = row["tjxs"].ToString();
                txtbz.Text = row["bz"].ToString();

                zxdjid = new Guid(Convertor.IsNull(row["zxdjid"], Guid.Empty.ToString()));
            }
            #endregion


            if (zxbz == 0)//δִ��
            {
                #region
                ssql = string.Format(@" select 

                                     0 ѡ��, b.id, 0 ���,
                                    (case b.id when (b.id is null or b.id=dbo.FUN_GETEMPTYGUID() then 0 else 1)
                                     a.yppm Ʒ��,a.ypspm ��Ʒ��,a.ypgg ���,a.s_sccj ����,s_ypdw ��λ,
                                    a.pfj ԭ������,a.pfj ��������,
                                    a.lsj ԭ���ۼ�, cast(b.xlsj as decimal(15,2)) �����ۼ�,
                                    '��' ��,
                                    '��' ss,
                                    cast( cast(c.zglsj as decimal(15,2)) as varchar(10)) ������ۼ�,
                                    a.mrjj ԭ����, 
                                    (case b.mrjhj when null then a.mrjj else cast(b.mrjhj as decimal(15,2)) end) �ֽ���, 
                                    a.kcl ҩ����,  
                                    a.kcl ��������,
                                    cast(0 as decimal(15,2)) ȫԺ���, 
                                    
                                   
                                    cast((b.xlsj-a.lsj)*a.kcl as decimal(15,2))  �����۽��,
                                    cast((b.mrjhj-b.scjhj)*a.kcl as decimal(15,2)) �����۽��,
                                    
                                    a.txm ����, 
                                    a.cjid,a.zxdw,a.dwbl ydwbl,
                                    b.whmxid 
                                    from VI_YK_KCMX a left join yf_tjmx b on a.cjid=b.cjid and a.deptid=b.deptid and b.djid='{1}'
                                    left join yf_tjwhmx c on b.whmxid=c.id  
                                    where a.deptid={0} order by b.id desc 
                                    ", deptid,id);
                DataTable tb_tjmx = InstanceForm.BDatabase.GetDataTable(ssql);
                dg_tjmx.DataSource=tb_tjmx;
                #endregion
            }
            else//��ִ��
            {
             
                #region ������ϸ
                ssql = string.Format(@" select 0 ѡ��, b.id, 0 ���,
                                     a.yppm Ʒ��,a.ypspm ��Ʒ��,a.ypgg ���,a.s_sccj ����,s_ypdw ��λ,
                                    b.ypfj ԭ������,b.xpfj ��������,
                                    b.ylsj ԭ���ۼ�, cast(b.xlsj as decimal(15,2)) �����ۼ�,
                                     '��' ��,
                                    '��' ss,
                                     cast( cast(c.zglsj as decimal(15,2)) as varchar(10)) ������ۼ�,
                                    cast(b.scjhj as decimal(15,2)) ԭ����, 
                                    cast(b.mrjhj as decimal(15,2)) �ֽ���, 
                                    a.kcl ҩ����,  
                                    b.tjsl ��������,
                                    cast(0 as decimal(15,2)) ȫԺ���, 
                                   
                                    cast((b.xlsj-b.xlsj)*b.tjsl as decimal(15,2)) �����۽��,
                                    cast((b.mrjhj-b.scjhj)*b.tjsl as decimal(15,2)) ���������,
                                    a.txm ����, 
                                    a.cjid,a.zxdw,b.ydwbl,
                                    b.whmxid 
                                    from VI_YK_KCMX a inner join yf_tjmx b on a.cjid=b.cjid and a.deptid=b.deptid and b.djid='{1}'
                                    left join yf_tjwhmx c on b.whmxid=c.id  
                                    where a.deptid={0} 
                                    ", deptid, id);
                DataTable tb_tjmx = InstanceForm.BDatabase.GetDataTable(ssql);
                dg_tjmx.DataSource = tb_tjmx;
                #endregion

                #region ������ϸ
                ssql = string.Format(" select ");
                #endregion
            }

            csdj(zxbz,id);
           
        }

        private void txtdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyChar);
            if (nkey == 13)
            {
                btndw_Click(0, e);
            }
         
        }

        //������ϸ
        private void btnSavemx_Click(object sender, EventArgs e)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(txtdm.SelectedValue,"0"));
            if (cjid <= 0) return;

            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;

            int index = 0;
            for (int i = 0; i < tb_tjmx.Rows.Count; i++)
            {
                if (Convert.ToInt32(tb_tjmx.Rows[i]["cjid"]) == cjid)
                {
                    index = i;
                    break;
                }
            }

            //if (txtxlsj.Text != "" || lblzglsj.Text != ""||txtxjhj.Text!="")
            //{
            //    if (txtxlsj.Text != "")
            //    {
            //        tb_tjmx.Rows[index]["�����ۼ�"] = Convert.ToDecimal(txtxlsj.Text);
            //        tb_tjmx.Rows[index]["ƥ¼"] = strlr;
            //    }
            //    else
            //    { 
                    
            //    }

            //    DataRow newrow = tb_tjmx.NewRow();
            //    newrow.ItemArray = tb_tjmx.Rows[index].ItemArray;
            //    tb_tjmx.Rows[index].Delete();
            //    tb_tjmx.AcceptChanges();
            //    tb_tjmx.Rows.InsertAt(newrow, 0);
            //    dg_tjmx.DataSource = tb_tjmx;
            //}

            csdjmx(0);
            txtdm.Focus();
        }

        //�������
        private void btnzx_Click(object sender, EventArgs e)
        {
            string ssql = "";
            bool bpltj = true;
            int err_code=0;
			string err_text="";
            DateTime tnow=Convert.ToDateTime(InstanceForm.BDatabase.GetDataResult(InstanceForm.BDatabase.GetServerTimeString()));
            bool bljzx = chkbljzx.Checked;
            string tjwh = txttjwh.Text;
            string bz = txtbz.Text;
            decimal tjxs = Convert.ToDecimal(Convertor.IsNull(txttjxs.Text,"1"));//����ϵ��
            DateTime zxsj = Convert.ToDateTime(dtprq.Value.ToShortDateString()+" "+dtpsj.Value.ToShortTimeString());
            int djy=InstanceForm.BCurrentUser.EmployeeId;
            string ywlx="005";
            Guid djid= new Guid(Convertor.IsNull(lbldjh.Tag,Guid.Empty.ToString()));//djid
            Guid djid_out;
            bool wcbz=false;
            int deptid=InstanceForm.BCurrentDept.DeptId;
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;

            DataRow[] rows=new DataRow[]{};
            if (djid == Guid.Empty)
            {
                rows = tb_tjmx.Select(string.Format("ƥ¼ in ('{0}','{1}','{2}')", strpp, strlr, strjj));
            }
            else
            {
                rows = tb_tjmx.Select(string.Format("ƥ¼ in ('{0}','{1}','{2}') or (id is not null or id <>'00000000-0000-0000-0000-000000000000' ) ", strpp, strlr, strjj));
            }
           
            if (rows.Length <= 0)
            {
                MessageBox.Show("û��Ҫ����ļ�¼��");
                return;
            }
            if (!bljzx)//������ִ��
            {
                if (tnow > zxsj)
                {
                    MessageBox.Show("������ִ��,ִ��ʱ�������ڵ�ǰ������ʱ�䣡");
                    return;
                }
            }

            #region �ж�δ��˵���

            if (bljzx)
            {
                if (rows.Length > 0) ssql = rows[0]["cjid"].ToString();
                for (int i = 1; i < rows.Length; i++)
                {
                    ssql = ssql + "," + rows[i]["cjid"].ToString();
                }
                DataTable tbsh = YF_TJ_TJMX.SelectWsh(ssql, out err_text, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                if (tbsh.Rows.Count > 0)
                {
                    Frmwshdj f = new Frmwshdj(_menuTag, _chineseName, _mdiParent);
                    Point point = new Point(400, 500);
                    f.Location = point;
                    f.tb = tbsh;
                    f.lblbz.Text = "";
                    f.ShowDialog();
                    return;
                }
            }
            #endregion


            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid _DJID = Guid.Empty;
            Guid _DJID_ZX = Guid.Empty;
            string sdjh = "";

            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                long djh = lbldjh.Text == "" ? Yp.SeekNewDjh("005", Convert.ToInt64(InstanceForm.BCurrentDept.DeptId), InstanceForm.BDatabase) : Convert.ToInt64(lbldjh.Text);//���ݺ�
                if (!bljzx)//������ִ��
                {
                    #region ����ͷ
                    YF_TJ_TJMX.SaveDJ(djid,
                       ywlx,
                       djh,
                       tjwh,
                       djy,
                       tnow.ToString(),
                       zxsj.ToString(),
                       0,
                       0,
                       deptid,
                       bz,
                       out djid_out,
                       out err_code,
                       out err_text,
                       InstanceForm._menuTag.Jgbm,
                       InstanceForm.BDatabase, bljzx,
                       Convert.ToDecimal(Convertor.IsNull(txttjxs.Text, "1")),
                       bpltj);
                    if (err_code != 0)
                    {
                        throw new System.Exception(err_text);
                    }
                    #endregion

                    #region ������ϸ
                    for (int i = 0; i < rows.Length; i++)
                    {
                        
                        DataRow row = rows[i];
                        bool ppbz = false;
                        if (row["ƥ¼"].ToString() == strpp)
                            ppbz = true;
                        Guid whmxid = new Guid(Convertor.IsNull(row["whmxid"], Guid.Empty.ToString()));
                        decimal tpfje = (Convert.ToDecimal(row["��������"]) - Convert.ToDecimal(row["ԭ������"])) * Convert.ToDecimal(row["ҩ����"]);

                        Guid _djmxid=new Guid(Convertor.IsNull(row["id"], Guid.Empty.ToString()));
                        if(_djmxid!=Guid.Empty&&row["ƥ¼"].ToString()=="")//�����ȡ�� ����Ҫɾ��
                        {
                             ssql = string.Format(" delete yf_tjmx where id= '{0}'",_djmxid);
                            if(InstanceForm.BDatabase.DoCommand(ssql)<=0)
                            {
                                throw new Exception("ȡ��������ϸʧ��");
                            }
                        }
                        else
                        {
                            decimal xlsj = 0;
                            if (row["�����ۼ�"] is DBNull)
                            {
                                if (ppbz)
                                {
                                    xlsj = Convert.ToDecimal(Convert.ToDecimal(Convertor.IsNull(row["������ۼ�"], "0")) * tjxs);
                                }
                                else
                                {
                                    xlsj = Convert.ToDecimal(row["ԭ���ۼ�"]);
                                }
                            }

                            YF_TJ_TJMX.SaveDJMX(new Guid(Convertor.IsNull(row["id"], Guid.Empty.ToString())),
                                         djid_out,
                                         Convert.ToInt32(row["cjid"]),
                                         Convert.ToDecimal(0),//��������
                                         row["��λ"].ToString(),
                                         Convert.ToInt32(row["ydwbl"]),
                                         Convert.ToDecimal(row["ԭ������"]),
                                         Convert.ToDecimal(row["��������"]),
                                         tpfje,
                                         Convert.ToDecimal(row["ԭ���ۼ�"]),
                                         Convert.ToDecimal(Convertor.IsNull(row["�����ۼ�"], row["ԭ���ۼ�"].ToString())),
                                         Convert.ToDecimal(Convertor.IsNull(row["���۽��"],"0")),
                                         Convert.ToInt64(deptid),
                                         djh,
                                         ywlx,
                                         Convert.ToDecimal(row["ԭ������"]),
                                         Convert.ToDecimal(Convertor.IsNull(row["�ֽ���"],row["ԭ����"].ToString())),
                                         "",
                                         out err_code,
                                         out err_text,
                                         InstanceForm.BDatabase,
                                         ppbz,
                                         whmxid,
                                         Convert.ToDecimal(Convertor.IsNull(row["������ۼ�"], "0"))
                                         );
                            if (err_code != 0)
                            {
                                throw new System.Exception(err_text);
                            }
                        }
                    }
                    #endregion

                    FillDj(djid_out, 0);


                }//����ִ��
                else
                {
                    #region ����ͷ
                    YF_TJ_TJMX.SaveDJ(djid,
                        ywlx,
                        djh,
                        tjwh,
                        djy,
                        tnow.ToString(),
                        tnow.ToString(),
                        1,
                        0,
                        deptid,
                        bz,
                        out djid_out,
                        out err_code,
                        out err_text,
                        InstanceForm._menuTag.Jgbm,
                        InstanceForm.BDatabase, bljzx,
                        Convert.ToDecimal(Convertor.IsNull(txttjxs.Text, "1")),
                        bpltj);
                    if (err_code != 0)
                    {
                        throw new System.Exception(err_text);
                    }
                    #endregion

                    #region ������ϸ
                    for (int i = 0; i < rows.Length; i++)
                    {
                        DataRow row = rows[i];
                        bool ppbz = false;
                        if (row["ƥ¼"].ToString() == strpp)
                            ppbz = true;
                        Guid whmxid = new Guid(Convertor.IsNull(row["whmxid"], Guid.Empty.ToString()));
                        decimal tpfje = (Convert.ToDecimal(row["��������"]) - Convert.ToDecimal(row["ԭ������"])) * Convert.ToDecimal(row["ҩ����"]);
                        decimal tlsje = (Convert.ToDecimal(row["�����ۼ�"]) - Convert.ToDecimal(row["ԭ���ۼ�"])) * Convert.ToDecimal(row["ҩ����"]);
                        YF_TJ_TJMX.SaveDJMX(new Guid(Convertor.IsNull(row["id"], Guid.Empty.ToString())),
                                     djid_out,
                                     Convert.ToInt32(row["cjid"]),
                                     Convert.ToDecimal(row["��������"]),
                                     row["��λ"].ToString(),
                                     Convert.ToInt32(row["ydwbl"]),
                                     Convert.ToDecimal(row["ԭ������"]),
                                     Convert.ToDecimal(row["��������"]),
                                     tpfje,
                                     Convert.ToDecimal(row["ԭ���ۼ�"]),
                                     Convert.ToDecimal(row["�����ۼ�"]),
                                     Convert.ToDecimal(Convertor.IsNull(row["�����۽��"], "0")),
                                     Convert.ToInt64(deptid),
                                     djh,
                                     ywlx,
                                     Convert.ToDecimal(row["ԭ����"]),
                                     Convert.ToDecimal(Convertor.IsNull(row["�ֽ���"], row["ԭ����"].ToString())),
                                     "",
                                     out err_code,
                                     out err_text,
                                     InstanceForm.BDatabase,
                                     ppbz,
                                     whmxid,
                                     Convert.ToDecimal(Convertor.IsNull(row["������ۼ�"], "0"))
                                     );
                        if (err_code != 0)
                        {
                            throw new System.Exception(err_text);
                        }
                        
                     
                    #region ���浥�� ������ϸ �޸��ֵ�
                    YF_TJ_TJMX.ExecQytj(djid_out, InstanceForm.BCurrentDept.DeptId, out sdjh, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                    if (err_code != 0) { throw new System.Exception(err_text); }
                    #endregion

                    #region ��Ժ���ݴ���
                    ts.Save_log(ts_HospData_Share.czlx.yp_ҩƷ����, InstanceForm.BCurrentDept.DeptName + "����,�����ĺ�:" + txttjwh.Text, "YF_TJ", "ID", djid.ToString(), InstanceForm._menuTag.Jgbm, -999, "", out _DJID, InstanceForm.BDatabase);
                    #endregion

                    #region ��������Ļ����ҵ�ǰ�����������Ļ��� ���͵���
                    if (InstanceForm._menuTag.Jgbm != TrasenFrame.Forms.FrmMdiMain.ZxJgbm && TrasenFrame.Forms.FrmMdiMain.ZxJgbm > 0)
                    ts.Save_log(ts_HospData_Share.czlx.yp_ҩƷ����, "�������ĵ�ҩƷ�ֵ�۸�: ���ۿ��� " + InstanceForm.BCurrentDept.DeptName + " ���۵���:" + djh + " �����ĺ�:" + txttjwh.Text, "YF_TJ", "ID", djid.ToString(), InstanceForm._menuTag.Jgbm, TrasenFrame.Forms.FrmMdiMain.ZxJgbm, 0, "����������ҩƷ�ֵ�", out _DJID_ZX, InstanceForm.BDatabase);
                     #endregion
            }
                    #endregion

                    FillDj(djid_out, 1);

                 }
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("����ɹ���");
                

            }
            catch (Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.ToString());
                return;
            }
        }

        //���������ϸ 
        private void dg_tjmx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                if (rowIndex < 0 || e.ColumnIndex < 0) return;
                DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
                DataRow row = tb_tjmx.Rows[rowIndex];
                int cjid = Convert.ToInt32(row["cjid"]);
                string yppm = row["Ʒ��"].ToString();//Ʒ��
                string ypgg = row["���"].ToString();
                string ypspm = row["��Ʒ��"].ToString();//��Ʒ��
                decimal kcl = Convert.ToDecimal(Convertor.IsNull(row["ҩ����"], "0"));
                string ypdw = row["��λ"].ToString();
                string ypcj = row["����"].ToString();
                string hh = row["����"].ToString();
                decimal ylsj = Convert.ToDecimal(row["ԭ���ۼ�"]);
                bool bxlsj = (row["�����ۼ�"] is DBNull) ? false : true; //�Ƿ��Ѿ�¼�������ۼ�
                decimal xlsj = Convert.ToDecimal(Convertor.IsNull(row["�����ۼ�"], "0"));

                decimal yjhj = Convert.ToDecimal(Convertor.IsNull(row["ԭ����"], "0"));
                bool bxjhj = (row["�ֽ���"] is DBNull) ? false : true;
                decimal xjhj = Convert.ToDecimal(Convertor.IsNull(row["�ֽ���"], "0"));//�ֽ�����

                bool bzglsj = (row["������ۼ�"] is DBNull) ? false : true;
                lblpm.Text = yppm;
                lblypmc.Text = ypspm;
                lblgg.Text = ypgg;
                lblcj.Text = ypcj;
                lblhh.Text = hh;
                lblylsj.Text = ylsj.ToString();
                lblyjhj.Text = yjhj.ToString();
                lblkc.Text = kcl.ToString();
                lbldw.Text = ypdw;
                //txtdm.SelectedValue = cjid;
                //txtdm.Text = "";
                txtdm.Tag = cjid;
                if (bxjhj)
                {
                    txtxjhj.Text = xjhj.ToString();
                }
                if (bxlsj)
                {
                    txtxlsj.Text = xlsj.ToString();
                }

                #region ��������
                if (dg_tjmx.Columns[e.ColumnIndex].Name == "col������ۼ�")//ƥ��¼���ĺ�
                {
                    //DataTable tb_whmx_temp = tb_whmx.Clone();
                    //DataRow[] rows_temp = tb_whmx.Select(string.Format("cjid={0}", cjid));
                    //for (int i = 0; i < rows_temp.Length; i++)
                    //{
                    //    tb_whmx_temp.ImportRow(rows_temp[i]);
                    //}
                    //dg_tjmx.ShowCardProperty[0].ShowCardDataSource = tb_whmx_temp;


                    //dg_tjmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = " ";
                    //dg_tjmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    //dg_tjmx.ShowCellErrors = false;

                }
                #endregion

                #region ����
                if (dg_tjmx.Columns[e.ColumnIndex].Name == "colss")
                {
                    if (bxjhj || bzglsj || bxlsj)
                    {
                        DataRow newrow = tb_tjmx.NewRow();
                        newrow.ItemArray = tb_tjmx.Rows[e.RowIndex].ItemArray;
                        tb_tjmx.Rows[e.RowIndex].Delete();
                        tb_tjmx.AcceptChanges();
                        tb_tjmx.Rows.InsertAt(newrow, 0);
                        dg_tjmx.DataSource = tb_tjmx;
                        txtdm.Focus();
                    }
                }
                #endregion

                #region ��ʽ
                if (dg_tjmx.Columns[e.ColumnIndex].Name == "col��")
                {
                    Rectangle rec = this.dg_tjmx.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    int x = pnlDjmx.Location.X;
                    int y = pnlDjmx.Location.Y;
                    Point p = new Point(x + rec.X, y + rec.Y - 30);
                    pnlgs.Location = p;
                    if ((p.Y + pnlgs.Size.Height + 100) > dg_pcmx.Size.Height)
                    {
                        pnlgs.Location = new Point(x + rec.X, x + rec.Y - pnlgs.Size.Height);
                    }
                    pnlgs.Visible = true;
                    decimal jhj = Convert.ToDecimal(row["ԭ����"]);
                    txtyjhj_gs.Text = jhj.ToString();
                    pnlgs.Tag = rowIndex;

                    txtxs_gs.Focus();
                }
                else
                {
                    pnlgs.Visible = false;
                }
                #endregion

                #region �б��ĺ�
                string ssql = string.Format(@" select a.cjid,a.lsh ��ˮ��,a.zbj �б��,a.zglsj ������ۼ�,b.s_ypjx ����,
                                            c.djsj �Ǽ����� 
                                            from yf_tjwhmx a inner join vi_yp_ypcd b on a.cjid=b.cjid 
                                            inner join yf_tjwh c on a.djid=c.id 
                                            where a.cjid={0} ",cjid);
                DataTable tb_whmx = InstanceForm.BDatabase.GetDataTable(ssql);
                dgwhmx.DataSource = tb_whmx;

                #endregion

            }
            catch (Exception err)
            {
                MessageBox.Show("��������:"+err.ToString());
            }

        }

        private int ppms = 0;//

        private void txtdm_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            if (selectedRow == null) return;
            csdjmx(0);
            int cjid = Convert.ToInt32(selectedRow["cjid"]);
            FindRow(cjid, ppms);
            txtdm.Text = "";
            txtdm.Tag = cjid;
        }

        private void FindRow(int cjid, int ppms)
        { 
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            for (int i = 0; i < tb_tjmx.Rows.Count; i++)
            {
                DataRow row = tb_tjmx.Rows[i];
                if (cjid == Convert.ToInt32(row["cjid"]))
                {
                    txtxlsj.Focus();
                    dg_tjmx.CurrentCell= dg_tjmx.Rows[i].Cells["col�����ۼ�"];
                    dg_tjmx.Focus();
                    return;
                }
            }
        }

        private void btnpp_Click(object sender, EventArgs e)
        {

        }

        //��λ
        private void btndw_Click(object sender, EventArgs e)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(txtdm.Tag, "0"));
            if (cjid > 0)
            {
                FindRow(cjid, ppms);
                this.txtdm.Text = "";
            }
        }

        private void chkpp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtxlsj_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            TextBox txtBox = (TextBox)sender;
            if (nkey != 13 && txtBox.Text.Trim() != "-" && txtBox.Text.Trim() != ".")
            {
                if (!Convertor.IsNumeric(txtBox.Text))
                {
                    txtBox.Text = "";
                }
            }
        }

        //ȡ��
        private void btnqxmx_Click(object sender, EventArgs e)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(txtdm.Tag,"0"));
            if (cjid <= 0)
            {
                MessageBox.Show("û��Ҫȡ���ļ�¼��");
            }
            DataTable tb_tjmx=(DataTable)dg_tjmx.DataSource;
            for (int i = 0; i < tb_tjmx.Rows.Count;i++ )
            {
                if (Convert.ToInt32(tb_tjmx.Rows[i]["cjid"]) == cjid)
                {
                    tb_tjmx.Rows[i]["�ֽ���"] = DBNull.Value;
                    tb_tjmx.Rows[i]["�����ۼ�"] = DBNull.Value;
                    tb_tjmx.Rows[i]["������ۼ�"] = DBNull.Value;
                    tb_tjmx.Rows[i]["whmxid"] = DBNull.Value;
                    tb_tjmx.Rows[i]["ƥ¼"] = "";
                    return;
                }
            }
        }

        //ƥ������ĺ���ϸ
        private void dg_tjmx_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            //if (selectedRow == null) return;
            //decimal zglsj = Convert.ToDecimal(selectedRow["������ۼ�"]);
            //Guid whmxid = new Guid(selectedRow["id"].ToString());
            //int rowIndex = dg_tjmx.CurrentCell.RowIndex;
            //dg_tjmx.Rows[rowIndex].Cells["col������ۼ�"].Value = zglsj;
            //dg_tjmx.Rows[rowIndex].Cells["colwhmxid"].Value = whmxid;
            //dg_tjmx.Rows[rowIndex].Cells["col�����ۼ�"].Value = Convert.ToDecimal(zglsj* Convert.ToDecimal(Convertor.IsNull(txttjxs.Text,"1")));

            ////int rowIndex = dg_tjmx.CurrentCell.RowIndex;
            //int colIndex = dg_tjmx.CurrentCell.ColumnIndex;

            //DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            //tb_tjmx.Rows[rowIndex]["������ۼ�"] = zglsj;
            //tb_tjmx.Rows[rowIndex]["whmxid"] = whmxid;

            //dg_tjmx.DataSource = tb_tjmx;
            //this.BindingContext[tb_tjmx].EndCurrentEdit();
            //dg_tjmx.EndEdit();

        }

        private void dg_tjmx_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void dg_tjmx_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            return;
            if (dg_tjmx.Rows.Count <= 0) return;

            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            string colName = dg_tjmx.Columns[colIndex].Name;

            if (colName == "col������ۼ�")
            {
                return;
            }
            if (Convertor.IsNull(dg_tjmx.Rows[rowIndex].Cells[colIndex].Value, "") == string.Empty)
            {
                if (colName == "col�����ۼ�"&&Convertor.IsNull(dg_tjmx.Rows[rowIndex].Cells["colƥ¼"].Value,"")==strlr)
                {
                    tb_tjmx.Rows[rowIndex]["ƥ¼"] = "";
                }
                //if (colName == "col������ۼ�" && Convertor.IsNull(dg_tjmx.Rows[rowIndex].Cells["colƥ¼"].Value, "") == strpp)
                //{
                //    tb_tjmx.Rows[rowIndex]["ƥ¼"] = "";
                //    tb_tjmx.Rows[rowIndex]["whmxid"] = DBNull.Value;
                //}
                if (colName == "col�ֽ���" && Convertor.IsNull(dg_tjmx.Rows[rowIndex].Cells["colƥ¼"].Value, "") == strjj)
                {
                    tb_tjmx.Rows[rowIndex]["ƥ¼"] = "";
                }
                dg_tjmx.DataSource = tb_tjmx;

                return;
            } 
            decimal value = Convert.ToDecimal(dg_tjmx.Rows[rowIndex].Cells[colIndex].Value);
            tb_tjmx.Rows[rowIndex][colIndex] = value;
            if (colName == "col�����ۼ�")
            {
                tb_tjmx.Rows[rowIndex]["ƥ¼"] = strlr;
                tb_tjmx.Rows[rowIndex]["������ۼ�"] = DBNull.Value;
                tb_tjmx.Rows[rowIndex]["whmxid"] = DBNull.Value;
            }
            if (colName == "col������ۼ�")
            {
                tb_tjmx.Rows[rowIndex]["ƥ¼"] = strpp;
                tb_tjmx.Rows[rowIndex]["whmxid"] = dg_tjmx.Rows[rowIndex].Cells["colwhmxid"].Value;
                tb_tjmx.Rows[rowIndex]["�����ۼ�"] = Convert.ToDecimal(value*Convert.ToDecimal(Convertor.IsNull( txttjxs.Text,"1")));
            }
            if (colName == "col�ֽ���")
            {
                if (Convertor.IsNull(tb_tjmx.Rows[rowIndex]["ƥ¼"], "") == "")
                {
                    tb_tjmx.Rows[rowIndex]["ƥ¼"] = strjj;
                }
            }

            //�ж�Ϊ��

            dg_tjmx.DataSource = tb_tjmx;
            txtdm.Focus();


        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl2.SelectedTab.Text == "��;����")
                {
                    DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;

                    Guid djid = new Guid(Convertor.IsNull(lbldjh.Tag, Guid.Empty.ToString()));//djid
                    string ssql = string.Format(" select * from yf_tj where id='{0}' and wcbj = 1 ", djid);
                    DataTable tb_wc = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb_wc.Rows.Count > 0)
                    {
                        return;
                    }

                    DataRow[] rows = new DataRow[] { };
                    if (djid == Guid.Empty)
                    {
                        rows = tb_tjmx.Select(string.Format("ѡ�� =1"));
                    }
                    else
                    {
                        rows = tb_tjmx.Select(string.Format("ѡ�� =1  or (id is not null or id <>'00000000-0000-0000-0000-000000000000' ) ", strpp, strlr, strjj));
                    }

                    ssql = "";
                    if (rows.Length > 0) ssql = rows[0]["cjid"].ToString();
                    for (int i = 1; i < rows.Length; i++)
                    {
                        ssql = ssql + "," + rows[i]["cjid"].ToString();
                    }
                    string err_text = "";
                    DataTable tbsh = YF_TJ_TJMX.SelectWsh(ssql, out err_text, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

                    dg_ztdj.DataSource = tbsh;
                }
                if (tabControl2.SelectedTab.Text == "������ϸ")
                {
                    DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
                    Guid djid = new Guid(Convertor.IsNull(lbldjh.Tag, Guid.Empty.ToString()));//djid
                    string ssql = string.Format(" select * from yf_tj where id='{0}' and wcbj = 1 ", djid);
                    DataTable tb_wz = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb_wz.Rows.Count > 0)
                    {
                        Guid zxdjid = new Guid(tb_wz.Rows[0]["zxdjid"].ToString());
                        ssql = string.Format(@"  select dbo.fun_getDeptname(b.deptid) ����,
                                            b.yppm ҩƷ����,b.ypgg ���,b.sccj ����,
                                            b.ypsl ����,b.ypdw ��λ,a.ylsj ԭ���ۼ�,a.xlsj �����ۼ�,
                                            a.scjhj ԭ����,a.mrjhj �ֽ���, b.yppch ���κ�,b.ypph ����,rtrim(b.ypxq) Ч��
                                            from yf_tjmx a 
                                            inner join yk_djmx b on a.cjid=b.cjid  and a.deptid=b.deptid and b.djid='{1}'
                                            where a.djid='{0}'  ", djid, zxdjid);
                        DataTable tb_pcmx = InstanceForm.BDatabase.GetDataTable(ssql);
                        dg_pcmx.DataSource = tb_pcmx;

                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dg_tjmx_MouseDown(object sender, MouseEventArgs e)
        {
             
        }

        private void dg_tjmx_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //e.Control.Text = "";
            
        }

        private void dg_tjmx_DataGridViewCellKeyPress(object sender, DataGridViewCell cell, KeyPressEventArgs e)
        {
            //e.KeyChar = (char)Keys.F2;
            //e.Handled = true ;
            //SendKeys.Send("{F2}"); 
        }

        private void txtxs_gs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control col = (Control)sender;
            if (e.KeyChar == 13)
            {
                if (col.Name == txtxs_gs.Name)
                {
                    if (Convertor.IsNumeric(txtxs_gs.Text))
                    {
                        txtje_gs.Focus();
                    }
                }

                if (col.Name == txtje_gs.Name)
                {
                    if (Convertor.IsNumeric(txtje_gs.Text))
                    {
                        btnok_gs.Focus();
                    }
                }
            }
        }

        private void txtxs_gs_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Name == txtxs_gs.Name)
            {
                if (Convertor.IsNumeric(txtxs_gs.Text.Trim()))
                {
                    txtxs_gs.Text = Convert.ToDecimal(txtxs_gs.Text).ToString("0.000");
                    txtje_gs.Focus();
                }
                else
                {
                    txtxs_gs.Text = "1.000";
                    return;
                }

            }
            if (txt.Name == txtje_gs.Name)
            {
                if (Convertor.IsNumeric(txtje_gs.Text.Trim()))
                {
                    txtje_gs.Text = Convert.ToDecimal(txtje_gs.Text).ToString("0.00");
                    btnok_gs.Focus();
                }
                else
                {
                    txtje_gs.Text = "0.00";
                }
            }
        }

        //��ʽȷ��
        private void btnok_gs_Click(object sender, EventArgs e)
        {
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            decimal jhj = Convert.ToDecimal(txtyjhj_gs.Text);
            decimal xs = Convert.ToDecimal(txtxs_gs.Text);
            decimal je = Convert.ToDecimal(Convertor.IsNull(txtje_gs.Text,"0"));
            decimal xlsj = Convert.ToDecimal(jhj * xs) + je;
            int rowIndex =Convert.ToInt32(pnlgs.Tag);
            tb_tjmx.Rows[rowIndex]["�����ۼ�"] = xlsj;
            tb_tjmx.Rows[rowIndex]["ƥ¼"] = strlr;
            dg_pcmx.DataSource = tb_tjmx;
            pnlgs.Visible = false;

            txtyjhj_gs.Text = "";
            txtxs_gs.Text = "";
            txtje_gs.Text = "";

        }

        //��ʽȡ��
        private void btnqx_gs_Click(object sender, EventArgs e)
        {
            pnlgs.Visible = false;

            txtyjhj_gs.Text = "";
            txtxs_gs.Text = "";
            txtje_gs.Text = "";
        }

        private void chkycfl_CheckedChanged(object sender, EventArgs e)
        {
            pnlfl.Visible = !chkycfl.Checked;
        }

        private void txtje_gs_Leave(object sender, EventArgs e)
        {
            DataTable tb_tjmx = (DataTable)dg_tjmx.DataSource;
            decimal jhj = Convert.ToDecimal(txtyjhj_gs.Text);
            decimal xs = Convert.ToDecimal(Convertor.IsNull(txtxs_gs.Text,"0.000"));
            txtxs_gs.Text = xs.ToString("0.000");
            decimal je = Convert.ToDecimal(Convertor.IsNull(txtje_gs.Text, "0.00"));
            txtje_gs.Text = je.ToString("0.00");
            decimal xlsj = Convert.ToDecimal(jhj * xs) + je;
            txtxlsj.Text = xlsj.ToString("0.00");

        }
    }
}