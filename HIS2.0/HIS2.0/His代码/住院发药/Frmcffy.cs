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
using Ts_zyys_public;
using System.Threading;
using Ts_Hlyy_Interface;
using ts_mz_class;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using TrasenFrame.Forms;

namespace ts_yf_zyfy
{
    /// <summary>
    /// Frmcffy ��ժҪ˵����
    /// </summary>
    public class Frmcffy : System.Windows.Forms.Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.Label label5;
        private Crownwood.Magic.Controls.TabControl tabControl2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkbrxx;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private TrasenClasses.GeneralControls.DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbpyr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Button butfy;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Panel panelbrxx;
        private System.Windows.Forms.Button butcfcx;
        private System.Windows.Forms.RadioButton rdols;
        private System.Windows.Forms.RadioButton rdodq;
        private System.Windows.Forms.CheckBox chkrq;
        private System.Windows.Forms.DateTimePicker dtprq2;
        private System.Windows.Forms.DateTimePicker dtprq1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.TextBox txtzyh;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.Button butprinthz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblbedno;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblzyh;
        private System.Windows.Forms.Label lblsex;
        private System.Windows.Forms.Label lblage;
        private System.Windows.Forms.Label lblfb;
        private System.Windows.Forms.Label lblks;
        private System.Windows.Forms.Label lblyjj;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lblye;
        private System.Windows.Forms.CheckBox chkprintview;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lblbz;
        private System.Windows.Forms.Button button1;
        private Panel panel1;
        private ContextMenuStrip contextMenu1;
        private ToolStripMenuItem mnuall;
        private ToolStripMenuItem mnutyl;
        private ToolStripMenuItem mnutjs;
        private TextBox txtcfh;
        private ToolStripMenuItem mnuprint;
        private Button butjjty;
        private Button buthelp;
        private ImageList imageList2;
        private RadioButton rdoydy;
        private RadioButton rdowdy;
        private RadioButton rdoall;
        private YpConfig ss;

        private ThreadStart start;
        private Panel panel19;
        private RadioButton rdohz;
        private RadioButton rdomx;
        private RadioButton rdobdy;
        private Thread listenThread;

        private string cfghlyytype = "0";
        private HlyyInterface hlyyjk;
        bool bpcgl = false;
        private Panel panel20;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Panel panel10;
        private Panel panel9;
        private TreeListView treeListView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Splitter splitter4;
        private Panel panel18;
        private TreeListView treeListView3;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader17;
        private Panel panel11;
        private ComboBox cmbbs2;
        private Panel panel3;
        private Label label7;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Panel panel5;
        private TreeListView treeListView1;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private Panel panel4;
        private ComboBox cmbbs1;
        private Panel panel15;
        private Label label1;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Panel panel2;
        private Panel panel6;
        private Panel panel13;
        private RadioButton rdCydy;
        private RadioButton rdCffy;
        private Button btnRefreshMessage;
        private CheckBox chkaddpatient;
        private Label label6;
        private Label label8;
        private ComboBox cmbFylb;
        private Label label10;
        private Button btnJz;
        private Button button2;
        private DateTimePicker dtpjzrq1;
        private DateTimePicker dtpjzrq2;
        private CheckBox chkJzRq;
        private Label label12;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ��ؼ��һToolStripMenuItem;
        private ToolStripMenuItem ��ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem; //�Ƿ�������ι���
        private string pcglfs;

        public Frmcffy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            ss = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            buthelp.Dock = DockStyle.Right;
            buthelp.Cursor = Cursors.Hand;
            txtzyh.Controls.Add(buthelp);

            rdCydy.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if (rdCydy.Checked)
                {
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    tb.Rows.Clear();
                    GetMessage();
                }
            };

            rdCffy.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if (rdCffy.Checked)
                {
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    tb.Rows.Clear();
                    GetMessage();
                }
            };


            cmbbs1.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbbs1.Text == "")
                    {
                        cmbbs1.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm,b.ward_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
                    ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Ward_Id", "Name", "pym", "wbm" },
                                                                                       new string[] { "����", "����", "ƴ����", "�����", "���" },
                                                                                       new string[] { "Ward_Id", "Name", "PYM", "WBM", "Dept_id" }, new int[] { 80, 150, 80, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs1;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs1.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs1.Text = "";
                        cmbbs1.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };

            cmbbs2.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbbs2.Text == "")
                    {
                        cmbbs2.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm,b.ward_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
                    ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Ward_Id", "Name", "pym", "wbm" },
                                                                                       new string[] { "����", "����", "ƴ����", "�����", "���" },
                                                                                       new string[] { "Ward_Id", "Name", "PYM", "WBM", "Dept_id" }, new int[] { 80, 150, 80, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs2;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs2.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs2.Text = "";
                        cmbbs2.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };

        }

        DataTable tbMessage = null;



        private DataTable GetWardList(int dept_ly)
        {

            //��ȡ����
            string ssql = @" select name,a.dept_id,d_code from jc_dept_property a left join jc_ward  b on a.dept_id=b.dept_id
                            where a.dept_id in(
                            select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm + "  and a.DELETED = 0";
            if (dept_ly > 0)
                ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'99999999')";

            return InstanceForm.BDatabase.GetDataTable(ssql);
        }

        private void GetMessage()
        {
            try
            {
                //ParameterEx[] parameters = new ParameterEx[2];
                //parameters[0].Text = "@dept_ly";
                //parameters[0].Value = 0;
                //parameters[1].Text = "@zxks";
                //parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                //tbMessage = InstanceForm.BDatabase.GetDataTable( "SP_YF_SELECT_ZYCF_MESSAGE" , parameters , 30 );

                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@dept_ly";
                parameters[0].Value = 0;
                parameters[1].Text = "@zxks";
                parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                parameters[2].Text = "@tlfs";
                parameters[2].Value = rdCydy.Checked ? 3 : 5; //3:��Ժ��ҩ 5:����
                tbMessage = InstanceForm.BDatabase.GetDataTable("SP_YF_SELECT_ZYCF_MESSAGE_TLFS", parameters, 30);
                treeListView1.SmallImageList = imageList1;


                DataTable tbWard = this.GetWardList(Convert.ToInt32(Convertor.IsNull(this.cmbbs1.SelectedValue, "0")));

                treeListView1.BeginUpdate();
                treeListView1.Items.Clear();
                for (int i = 0; i < tbWard.Rows.Count; i++)
                {
                    string wardName = tbWard.Rows[i]["name"].ToString();
                    string deptly = Convertor.IsNull(tbWard.Rows[i]["dept_id"], "0");
                    DataRow[] rows = tbMessage.Select("dept_ly=" + deptly + "", "");
                    if (rows.Length > 0)
                    {
                        //��Ӳ���
                        TreeListViewItem itemA = new TreeListViewItem(tbWard.Rows[i]["name"].ToString(), 0);
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.Tag = tbWard.Rows[i]["dept_id"].ToString();
                        itemA.ForeColor = Color.Black;
                        itemA.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        //�����Ϣ
                        for (int j = 0; j < rows.Length; j++)
                        {
                            TreeListViewItem itemB = new TreeListViewItem("" + rows[j]["bz"].ToString() + "", 1);
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.Tag = rows.Length.ToString();
                            itemB.ForeColor = Color.Black;
                            itemB.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                            itemA.Items.Add(itemB);
                        }

                        treeListView1.Items.Add(itemA);
                    }
                }

                treeListView1.Columns[0].Width = treeListView1.Width - 20;
                treeListView1.EndUpdate();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmcffy));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer4 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer2 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.chkrq = new System.Windows.Forms.CheckBox();
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.rdols = new System.Windows.Forms.RadioButton();
            this.rdodq = new System.Windows.Forms.RadioButton();
            this.chkbrxx = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.panel19 = new System.Windows.Forms.Panel();
            this.rdobdy = new System.Windows.Forms.RadioButton();
            this.rdohz = new System.Windows.Forms.RadioButton();
            this.rdomx = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dtpjzrq1 = new System.Windows.Forms.DateTimePicker();
            this.dtpjzrq2 = new System.Windows.Forms.DateTimePicker();
            this.chkJzRq = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbFylb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buthelp = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.butcfcx = new System.Windows.Forms.Button();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.txtcfh = new System.Windows.Forms.TextBox();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.rdoydy = new System.Windows.Forms.RadioButton();
            this.rdowdy = new System.Windows.Forms.RadioButton();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.butfy = new System.Windows.Forms.Button();
            this.butjjty = new System.Windows.Forms.Button();
            this.chkprintview = new System.Windows.Forms.CheckBox();
            this.butprinthz = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.��ؼ��һToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblbz = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeListView1 = new System.Windows.Forms.TreeListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbbs1 = new System.Windows.Forms.ComboBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.treeListView2 = new System.Windows.Forms.TreeListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel18 = new System.Windows.Forms.Panel();
            this.treeListView3 = new System.Windows.Forms.TreeListView();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cmbbs2 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnRefreshMessage = new System.Windows.Forms.Button();
            this.rdCydy = new System.Windows.Forms.RadioButton();
            this.rdCffy = new System.Windows.Forms.RadioButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelbrxx = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblbedno = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblye = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lblzyh = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblyjj = new System.Windows.Forms.Label();
            this.lblsex = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.Label();
            this.lblage = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblfb = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.contextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuall = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutyl = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutjs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuprint = new System.Windows.Forms.ToolStripMenuItem();
            this.panel20 = new System.Windows.Forms.Panel();
            this.btnJz = new System.Windows.Forms.Button();
            this.chkaddpatient = new System.Windows.Forms.CheckBox();
            this.tabControl2.SuspendLayout();
            this.panel19.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel15.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelbrxx.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.contextMenu1.SuspendLayout();
            this.panel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkrq
            // 
            this.chkrq.AutoSize = true;
            this.chkrq.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkrq.ForeColor = System.Drawing.Color.Black;
            this.chkrq.Location = new System.Drawing.Point(8, 6);
            this.chkrq.Name = "chkrq";
            this.chkrq.Size = new System.Drawing.Size(82, 18);
            this.chkrq.TabIndex = 12;
            this.chkrq.Text = "��������";
            this.chkrq.CheckedChanged += new System.EventHandler(this.chkrq_CheckedChanged);
            // 
            // dtprq2
            // 
            this.dtprq2.Enabled = false;
            this.dtprq2.Location = new System.Drawing.Point(244, 5);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(117, 23);
            this.dtprq2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(222, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "��";
            // 
            // dtprq1
            // 
            this.dtprq1.Enabled = false;
            this.dtprq1.Location = new System.Drawing.Point(95, 4);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(121, 23);
            this.dtprq1.TabIndex = 7;
            // 
            // rdols
            // 
            this.rdols.AutoSize = true;
            this.rdols.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdols.ForeColor = System.Drawing.Color.Black;
            this.rdols.Location = new System.Drawing.Point(740, 29);
            this.rdols.Name = "rdols";
            this.rdols.Size = new System.Drawing.Size(47, 16);
            this.rdols.TabIndex = 11;
            this.rdols.Text = "��ʷ";
            this.rdols.CheckedChanged += new System.EventHandler(this.rdols_CheckedChanged);
            // 
            // rdodq
            // 
            this.rdodq.AutoSize = true;
            this.rdodq.Checked = true;
            this.rdodq.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdodq.ForeColor = System.Drawing.Color.Black;
            this.rdodq.Location = new System.Drawing.Point(740, 6);
            this.rdodq.Name = "rdodq";
            this.rdodq.Size = new System.Drawing.Size(47, 16);
            this.rdodq.TabIndex = 10;
            this.rdodq.TabStop = true;
            this.rdodq.Text = "��ǰ";
            this.rdodq.CheckedChanged += new System.EventHandler(this.rdols_CheckedChanged);
            // 
            // chkbrxx
            // 
            this.chkbrxx.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkbrxx.ForeColor = System.Drawing.Color.Navy;
            this.chkbrxx.Location = new System.Drawing.Point(861, 32);
            this.chkbrxx.Name = "chkbrxx";
            this.chkbrxx.Size = new System.Drawing.Size(47, 24);
            this.chkbrxx.TabIndex = 6;
            this.chkbrxx.Text = "��ʾ������Ϣ";
            this.chkbrxx.Visible = false;
            this.chkbrxx.CheckedChanged += new System.EventHandler(this.chkbrxx_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "��ҩ��";
            // 
            // tabControl2
            // 
            this.tabControl2.BoldSelectedPage = true;
            this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.Controls.Add(this.panel19);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl2.Location = new System.Drawing.Point(254, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SelectedTab = this.tabPage3;
            this.tabControl2.Size = new System.Drawing.Size(895, 428);
            this.tabControl2.TabIndex = 1;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage4});
            this.tabControl2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.TextInactiveColor = System.Drawing.Color.Black;
            this.tabControl2.SelectionChanged += new System.EventHandler(this.tabControl2_SelectionChanged);
            this.tabControl2.Click += new System.EventHandler(this.tabControl2_Click);
            // 
            // panel19
            // 
            this.panel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel19.BackColor = System.Drawing.Color.Transparent;
            this.panel19.Controls.Add(this.rdobdy);
            this.panel19.Controls.Add(this.rdohz);
            this.panel19.Controls.Add(this.rdomx);
            this.panel19.Location = new System.Drawing.Point(494, 1);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(398, 24);
            this.panel19.TabIndex = 24;
            // 
            // rdobdy
            // 
            this.rdobdy.AutoSize = true;
            this.rdobdy.Checked = true;
            this.rdobdy.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdobdy.ForeColor = System.Drawing.Color.Black;
            this.rdobdy.Location = new System.Drawing.Point(277, 4);
            this.rdobdy.Name = "rdobdy";
            this.rdobdy.Size = new System.Drawing.Size(119, 16);
            this.rdobdy.TabIndex = 26;
            this.rdobdy.TabStop = true;
            this.rdobdy.Text = "��ҩʱĬ�ϲ���ӡ";
            this.rdobdy.UseVisualStyleBackColor = true;
            this.rdobdy.CheckedChanged += new System.EventHandler(this.rdomx_CheckedChanged);
            // 
            // rdohz
            // 
            this.rdohz.AutoSize = true;
            this.rdohz.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdohz.ForeColor = System.Drawing.Color.Black;
            this.rdohz.Location = new System.Drawing.Point(140, 5);
            this.rdohz.Name = "rdohz";
            this.rdohz.Size = new System.Drawing.Size(131, 16);
            this.rdohz.TabIndex = 25;
            this.rdohz.Text = "��ҩʱĬ�ϴ�ӡ����";
            this.rdohz.UseVisualStyleBackColor = true;
            this.rdohz.CheckedChanged += new System.EventHandler(this.rdomx_CheckedChanged);
            // 
            // rdomx
            // 
            this.rdomx.AutoSize = true;
            this.rdomx.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdomx.ForeColor = System.Drawing.Color.Black;
            this.rdomx.Location = new System.Drawing.Point(3, 5);
            this.rdomx.Name = "rdomx";
            this.rdomx.Size = new System.Drawing.Size(131, 16);
            this.rdomx.TabIndex = 24;
            this.rdomx.Text = "��ҩʱĬ�ϴ�ӡ��ϸ";
            this.rdomx.UseVisualStyleBackColor = true;
            this.rdomx.CheckedChanged += new System.EventHandler(this.rdomx_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.panel8);
            this.tabPage3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(895, 403);
            this.tabPage3.StartFocus = this.dtprq1;
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "��Ϣ��ϸ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 325);
            this.panel1.TabIndex = 2;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myDataGrid1.Size = new System.Drawing.Size(895, 325);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeadersVisible = false;
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.dtpjzrq1);
            this.panel8.Controls.Add(this.dtpjzrq2);
            this.panel8.Controls.Add(this.chkJzRq);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.cmbFylb);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.buthelp);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Controls.Add(this.butcfcx);
            this.panel8.Controls.Add(this.txtzyh);
            this.panel8.Controls.Add(this.dtprq1);
            this.panel8.Controls.Add(this.txtcfh);
            this.panel8.Controls.Add(this.dtprq2);
            this.panel8.Controls.Add(this.rdols);
            this.panel8.Controls.Add(this.chkall);
            this.panel8.Controls.Add(this.rdodq);
            this.panel8.Controls.Add(this.chkrq);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(895, 78);
            this.panel8.TabIndex = 1;
            // 
            // dtpjzrq1
            // 
            this.dtpjzrq1.Enabled = false;
            this.dtpjzrq1.Location = new System.Drawing.Point(95, 27);
            this.dtpjzrq1.Name = "dtpjzrq1";
            this.dtpjzrq1.Size = new System.Drawing.Size(121, 23);
            this.dtpjzrq1.TabIndex = 29;
            // 
            // dtpjzrq2
            // 
            this.dtpjzrq2.Enabled = false;
            this.dtpjzrq2.Location = new System.Drawing.Point(244, 28);
            this.dtpjzrq2.Name = "dtpjzrq2";
            this.dtpjzrq2.Size = new System.Drawing.Size(117, 23);
            this.dtpjzrq2.TabIndex = 31;
            // 
            // chkJzRq
            // 
            this.chkJzRq.AutoSize = true;
            this.chkJzRq.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJzRq.ForeColor = System.Drawing.Color.Black;
            this.chkJzRq.Location = new System.Drawing.Point(8, 29);
            this.chkJzRq.Name = "chkJzRq";
            this.chkJzRq.Size = new System.Drawing.Size(82, 18);
            this.chkJzRq.TabIndex = 32;
            this.chkJzRq.Text = "�Ƿ�����";
            this.chkJzRq.CheckedChanged += new System.EventHandler(this.chkJzRq_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(222, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 14);
            this.label12.TabIndex = 30;
            this.label12.Text = "��";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(793, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 47);
            this.button2.TabIndex = 28;
            this.button2.Text = "ͬ������״̬";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 14);
            this.label10.TabIndex = 27;
            this.label10.Text = "(�в�ҩ�ϴ�ѡ��)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 26;
            this.label8.Text = "��ҩ���";
            // 
            // cmbFylb
            // 
            this.cmbFylb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFylb.Enabled = false;
            this.cmbFylb.FormattingEnabled = true;
            this.cmbFylb.Location = new System.Drawing.Point(129, 51);
            this.cmbFylb.Name = "cmbFylb";
            this.cmbFylb.Size = new System.Drawing.Size(116, 22);
            this.cmbFylb.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(367, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "������";
            // 
            // buthelp
            // 
            this.buthelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buthelp.ImageIndex = 0;
            this.buthelp.ImageList = this.imageList2;
            this.buthelp.Location = new System.Drawing.Point(554, 5);
            this.buthelp.Name = "buthelp";
            this.buthelp.Size = new System.Drawing.Size(23, 23);
            this.buthelp.TabIndex = 23;
            this.buthelp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buthelp.UseVisualStyleBackColor = true;
            this.buthelp.Click += new System.EventHandler(this.buthelp_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "VIEWER1.ICO");
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(664, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 47);
            this.button1.TabIndex = 22;
            this.button1.Text = "����";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butcfcx
            // 
            this.butcfcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butcfcx.ForeColor = System.Drawing.Color.Navy;
            this.butcfcx.Location = new System.Drawing.Point(583, 3);
            this.butcfcx.Name = "butcfcx";
            this.butcfcx.Size = new System.Drawing.Size(75, 47);
            this.butcfcx.TabIndex = 19;
            this.butcfcx.Text = "��ѯ(&F)";
            this.butcfcx.Click += new System.EventHandler(this.butcfcx_Click);
            // 
            // txtzyh
            // 
            this.txtzyh.BackColor = System.Drawing.Color.White;
            this.txtzyh.Location = new System.Drawing.Point(422, 4);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(157, 23);
            this.txtzyh.TabIndex = 17;
            this.txtzyh.TextChanged += new System.EventHandler(this.txtzyh_TextChanged);
            this.txtzyh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzyh_KeyPress);
            // 
            // txtcfh
            // 
            this.txtcfh.BackColor = System.Drawing.Color.White;
            this.txtcfh.Location = new System.Drawing.Point(422, 29);
            this.txtcfh.Name = "txtcfh";
            this.txtcfh.Size = new System.Drawing.Size(157, 23);
            this.txtcfh.TabIndex = 20;
            this.txtcfh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcfh_KeyPress);
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkall.ForeColor = System.Drawing.Color.Black;
            this.chkall.Location = new System.Drawing.Point(8, 54);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(50, 16);
            this.chkall.TabIndex = 20;
            this.chkall.Text = "ȫѡ";
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(367, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "סԺ��";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.myDataGrid2);
            this.tabPage4.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(895, 403);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Title = "������Ϣ";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(895, 403);
            this.myDataGrid2.TabIndex = 1;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // rdoydy
            // 
            this.rdoydy.AutoSize = true;
            this.rdoydy.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoydy.Location = new System.Drawing.Point(121, 3);
            this.rdoydy.Name = "rdoydy";
            this.rdoydy.Size = new System.Drawing.Size(59, 16);
            this.rdoydy.TabIndex = 23;
            this.rdoydy.Text = "�Ѵ�ӡ";
            this.rdoydy.UseVisualStyleBackColor = true;
            this.rdoydy.Visible = false;
            // 
            // rdowdy
            // 
            this.rdowdy.AutoSize = true;
            this.rdowdy.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdowdy.Location = new System.Drawing.Point(56, 3);
            this.rdowdy.Name = "rdowdy";
            this.rdowdy.Size = new System.Drawing.Size(59, 16);
            this.rdowdy.TabIndex = 22;
            this.rdowdy.Text = "δ��ӡ";
            this.rdowdy.UseVisualStyleBackColor = true;
            this.rdowdy.Visible = false;
            // 
            // rdoall
            // 
            this.rdoall.AutoSize = true;
            this.rdoall.Checked = true;
            this.rdoall.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoall.Location = new System.Drawing.Point(3, 3);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(47, 16);
            this.rdoall.TabIndex = 21;
            this.rdoall.TabStop = true;
            this.rdoall.Text = "ȫ��";
            this.rdoall.UseVisualStyleBackColor = true;
            this.rdoall.Visible = false;
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point(55, 5);
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size(85, 20);
            this.cmbpyr.TabIndex = 11;
            this.cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // butfy
            // 
            this.butfy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butfy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butfy.ForeColor = System.Drawing.Color.Navy;
            this.butfy.Location = new System.Drawing.Point(144, 3);
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size(79, 25);
            this.butfy.TabIndex = 13;
            this.butfy.Text = "��ҩ(&O)";
            this.butfy.UseVisualStyleBackColor = false;
            this.butfy.Click += new System.EventHandler(this.butfy_Click);
            // 
            // butjjty
            // 
            this.butjjty.Enabled = false;
            this.butjjty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butjjty.ForeColor = System.Drawing.Color.Navy;
            this.butjjty.Location = new System.Drawing.Point(499, 3);
            this.butjjty.Name = "butjjty";
            this.butjjty.Size = new System.Drawing.Size(88, 25);
            this.butjjty.TabIndex = 18;
            this.butjjty.Text = "�ܾ���ҩ(&T)";
            this.butjjty.Visible = false;
            this.butjjty.Click += new System.EventHandler(this.butjjty_Click);
            // 
            // chkprintview
            // 
            this.chkprintview.AutoSize = true;
            this.chkprintview.Location = new System.Drawing.Point(408, 7);
            this.chkprintview.Name = "chkprintview";
            this.chkprintview.Size = new System.Drawing.Size(84, 16);
            this.chkprintview.TabIndex = 17;
            this.chkprintview.Text = "��ӡʱԤ��";
            // 
            // butprinthz
            // 
            this.butprinthz.Enabled = false;
            this.butprinthz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprinthz.ForeColor = System.Drawing.Color.Navy;
            this.butprinthz.Location = new System.Drawing.Point(229, 3);
            this.butprinthz.Name = "butprinthz";
            this.butprinthz.Size = new System.Drawing.Size(80, 25);
            this.butprinthz.TabIndex = 16;
            this.butprinthz.Text = "��ӡ����(&P)";
            this.butprinthz.Click += new System.EventHandler(this.butprinthz_Click);
            // 
            // butquit
            // 
            this.butquit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(808, 2);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(84, 25);
            this.butquit.TabIndex = 15;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.ContextMenuStrip = this.contextMenuStrip1;
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(315, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 25);
            this.butprint.TabIndex = 14;
            this.butprint.Text = "��ӡ����(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��ؼ��һToolStripMenuItem,
            this.��ToolStripMenuItem,
            this.����ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // ��ؼ��һToolStripMenuItem
            // 
            this.��ؼ��һToolStripMenuItem.Name = "��ؼ��һToolStripMenuItem";
            this.��ؼ��һToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.��ؼ��һToolStripMenuItem.Text = "��ؼ��һ";
            this.��ؼ��һToolStripMenuItem.Click += new System.EventHandler(this.��ؼ��һToolStripMenuItem_Click);
            // 
            // ��ToolStripMenuItem
            // 
            this.��ToolStripMenuItem.Name = "��ToolStripMenuItem";
            this.��ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.��ToolStripMenuItem.Text = "��";
            this.��ToolStripMenuItem.Click += new System.EventHandler(this.��ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // lblbz
            // 
            this.lblbz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblbz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblbz.Location = new System.Drawing.Point(0, 0);
            this.lblbz.Name = "lblbz";
            this.lblbz.Size = new System.Drawing.Size(251, 0);
            this.lblbz.TabIndex = 8;
            this.lblbz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Controls.Add(this.panel6);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(251, 487);
            this.panel12.TabIndex = 11;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tabControl1);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 29);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(251, 458);
            this.panel13.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.BoldSelectedPage = true;
            this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(251, 458);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.tabControl1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.TextInactiveColor = System.Drawing.Color.Black;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(251, 433);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Tag = "0";
            this.tabPage1.Title = "����ҩ����";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.treeListView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(251, 411);
            this.panel5.TabIndex = 1;
            // 
            // treeListView1
            // 
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            treeListViewItemCollectionComparer4.Column = 0;
            treeListViewItemCollectionComparer4.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer4;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListView1.GridLines = true;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.Size = new System.Drawing.Size(251, 411);
            this.treeListView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView1.TabIndex = 4;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "סԺ��";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "����";
            this.columnHeader10.Width = 41;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "����";
            this.columnHeader11.Width = 64;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "�Ա�";
            this.columnHeader12.Width = 36;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "����";
            this.columnHeader13.Width = 36;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "�ѱ�";
            this.columnHeader14.Width = 45;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "����";
            this.columnHeader15.Width = 65;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaShell;
            this.panel4.Controls.Add(this.cmbbs1);
            this.panel4.Controls.Add(this.panel15);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 22);
            this.panel4.TabIndex = 0;
            // 
            // cmbbs1
            // 
            this.cmbbs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbs1.Location = new System.Drawing.Point(38, 0);
            this.cmbbs1.Name = "cmbbs1";
            this.cmbbs1.Size = new System.Drawing.Size(213, 22);
            this.cmbbs1.TabIndex = 13;
            this.cmbbs1.SelectedIndexChanged += new System.EventHandler(this.cmbbs1_SelectedIndexChanged);
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.Control;
            this.panel15.Controls.Add(this.label1);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(38, 22);
            this.panel15.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "����";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel10);
            this.tabPage2.Controls.Add(this.panel11);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(251, 433);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Tag = "1";
            this.tabPage2.Title = "�ѷ�ҩ����";
            this.tabPage2.Visible = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel9);
            this.panel10.Controls.Add(this.splitter4);
            this.panel10.Controls.Add(this.panel18);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 22);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(251, 411);
            this.panel10.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.treeListView2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(251, 229);
            this.panel9.TabIndex = 7;
            // 
            // treeListView2
            // 
            this.treeListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView2.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView2.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView2.GridLines = true;
            this.treeListView2.Location = new System.Drawing.Point(0, 0);
            this.treeListView2.Name = "treeListView2";
            this.treeListView2.Size = new System.Drawing.Size(251, 229);
            this.treeListView2.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView2.TabIndex = 3;
            this.treeListView2.UseCompatibleStateImageBehavior = false;
            this.treeListView2.DoubleClick += new System.EventHandler(this.treeListView2_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "סԺ��";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "����";
            this.columnHeader2.Width = 36;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "����";
            this.columnHeader3.Width = 71;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "�Ա�";
            this.columnHeader4.Width = 36;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "����";
            this.columnHeader5.Width = 36;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "�ѱ�";
            this.columnHeader6.Width = 45;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "����";
            this.columnHeader7.Width = 65;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 229);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(251, 5);
            this.splitter4.TabIndex = 6;
            this.splitter4.TabStop = false;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.treeListView3);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 234);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(251, 177);
            this.panel18.TabIndex = 5;
            // 
            // treeListView3
            // 
            this.treeListView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader8,
            this.columnHeader17});
            treeListViewItemCollectionComparer2.Column = 0;
            treeListViewItemCollectionComparer2.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView3.Comparer = treeListViewItemCollectionComparer2;
            this.treeListView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView3.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView3.GridLines = true;
            this.treeListView3.Location = new System.Drawing.Point(0, 0);
            this.treeListView3.Name = "treeListView3";
            this.treeListView3.Size = new System.Drawing.Size(251, 177);
            this.treeListView3.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView3.TabIndex = 4;
            this.treeListView3.UseCompatibleStateImageBehavior = false;
            this.treeListView3.DoubleClick += new System.EventHandler(this.treeListView3_DoubleClick);
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "��ҩ����";
            this.columnHeader16.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "����";
            this.columnHeader8.Width = 88;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "���";
            this.columnHeader17.Width = 79;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.SeaShell;
            this.panel11.Controls.Add(this.cmbbs2);
            this.panel11.Controls.Add(this.panel3);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(251, 22);
            this.panel11.TabIndex = 2;
            // 
            // cmbbs2
            // 
            this.cmbbs2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbs2.Location = new System.Drawing.Point(40, 0);
            this.cmbbs2.Name = "cmbbs2";
            this.cmbbs2.Size = new System.Drawing.Size(211, 22);
            this.cmbbs2.TabIndex = 21;
            this.cmbbs2.SelectedIndexChanged += new System.EventHandler(this.cmbbs2_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(40, 22);
            this.panel3.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "����";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnRefreshMessage);
            this.panel6.Controls.Add(this.rdCydy);
            this.panel6.Controls.Add(this.rdCffy);
            this.panel6.Controls.Add(this.lblbz);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(251, 29);
            this.panel6.TabIndex = 10;
            // 
            // btnRefreshMessage
            // 
            this.btnRefreshMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefreshMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshMessage.Font = new System.Drawing.Font("����", 11.5F);
            this.btnRefreshMessage.ForeColor = System.Drawing.Color.Navy;
            this.btnRefreshMessage.Location = new System.Drawing.Point(195, 0);
            this.btnRefreshMessage.Name = "btnRefreshMessage";
            this.btnRefreshMessage.Size = new System.Drawing.Size(56, 29);
            this.btnRefreshMessage.TabIndex = 11;
            this.btnRefreshMessage.Text = "ˢ��";
            this.btnRefreshMessage.UseVisualStyleBackColor = true;
            this.btnRefreshMessage.Click += new System.EventHandler(this.btnRefreshMessage_Click);
            // 
            // rdCydy
            // 
            this.rdCydy.AutoSize = true;
            this.rdCydy.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold);
            this.rdCydy.Location = new System.Drawing.Point(94, 5);
            this.rdCydy.Name = "rdCydy";
            this.rdCydy.Size = new System.Drawing.Size(85, 18);
            this.rdCydy.TabIndex = 10;
            this.rdCydy.Text = "��Ժ��ҩ";
            this.rdCydy.UseVisualStyleBackColor = true;
            // 
            // rdCffy
            // 
            this.rdCffy.AutoSize = true;
            this.rdCffy.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold);
            this.rdCffy.Location = new System.Drawing.Point(3, 5);
            this.rdCffy.Name = "rdCffy";
            this.rdCffy.Size = new System.Drawing.Size(85, 18);
            this.rdCffy.TabIndex = 9;
            this.rdCffy.Text = "������ҩ";
            this.rdCffy.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(251, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 487);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // panelbrxx
            // 
            this.panelbrxx.BackColor = System.Drawing.SystemColors.Control;
            this.panelbrxx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelbrxx.Controls.Add(this.chkbrxx);
            this.panelbrxx.Controls.Add(this.panel2);
            this.panelbrxx.Controls.Add(this.label4);
            this.panelbrxx.Controls.Add(this.lblbedno);
            this.panelbrxx.Controls.Add(this.label9);
            this.panelbrxx.Controls.Add(this.lblye);
            this.panelbrxx.Controls.Add(this.lblname);
            this.panelbrxx.Controls.Add(this.label25);
            this.panelbrxx.Controls.Add(this.label11);
            this.panelbrxx.Controls.Add(this.lbltotal);
            this.panelbrxx.Controls.Add(this.lblzyh);
            this.panelbrxx.Controls.Add(this.label23);
            this.panelbrxx.Controls.Add(this.label13);
            this.panelbrxx.Controls.Add(this.lblyjj);
            this.panelbrxx.Controls.Add(this.lblsex);
            this.panelbrxx.Controls.Add(this.label20);
            this.panelbrxx.Controls.Add(this.label15);
            this.panelbrxx.Controls.Add(this.lblks);
            this.panelbrxx.Controls.Add(this.lblage);
            this.panelbrxx.Controls.Add(this.label19);
            this.panelbrxx.Controls.Add(this.label17);
            this.panelbrxx.Controls.Add(this.lblfb);
            this.panelbrxx.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbrxx.Location = new System.Drawing.Point(254, 0);
            this.panelbrxx.Name = "panelbrxx";
            this.panelbrxx.Size = new System.Drawing.Size(895, 0);
            this.panelbrxx.TabIndex = 13;
            this.panelbrxx.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoall);
            this.panel2.Controls.Add(this.rdoydy);
            this.panel2.Controls.Add(this.rdowdy);
            this.panel2.Location = new System.Drawing.Point(672, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 24);
            this.panel2.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(179, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "����";
            // 
            // lblbedno
            // 
            this.lblbedno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblbedno.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbedno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblbedno.Location = new System.Drawing.Point(222, 6);
            this.lblbedno.Name = "lblbedno";
            this.lblbedno.Size = new System.Drawing.Size(34, 18);
            this.lblbedno.TabIndex = 1;
            this.lblbedno.Text = "01";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(262, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "����";
            // 
            // lblye
            // 
            this.lblye.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblye.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblye.Location = new System.Drawing.Point(584, 34);
            this.lblye.Name = "lblye";
            this.lblye.Size = new System.Drawing.Size(85, 18);
            this.lblye.TabIndex = 19;
            // 
            // lblname
            // 
            this.lblname.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblname.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblname.Location = new System.Drawing.Point(305, 6);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(56, 18);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "����";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(543, 35);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 15);
            this.label25.TabIndex = 18;
            this.label25.Text = "���";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(4, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "סԺ��";
            // 
            // lbltotal
            // 
            this.lbltotal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbltotal.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbltotal.Location = new System.Drawing.Point(451, 34);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(85, 18);
            this.lbltotal.TabIndex = 17;
            // 
            // lblzyh
            // 
            this.lblzyh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblzyh.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzyh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblzyh.Location = new System.Drawing.Point(62, 6);
            this.lblzyh.Name = "lblzyh";
            this.lblzyh.Size = new System.Drawing.Size(108, 18);
            this.lblzyh.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(411, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 15);
            this.label23.TabIndex = 16;
            this.label23.Text = "����";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(367, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "�Ա�";
            // 
            // lblyjj
            // 
            this.lblyjj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblyjj.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblyjj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblyjj.Location = new System.Drawing.Point(303, 34);
            this.lblyjj.Name = "lblyjj";
            this.lblyjj.Size = new System.Drawing.Size(102, 18);
            this.lblyjj.TabIndex = 15;
            // 
            // lblsex
            // 
            this.lblsex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblsex.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblsex.Location = new System.Drawing.Point(410, 6);
            this.lblsex.Name = "lblsex";
            this.lblsex.Size = new System.Drawing.Size(32, 18);
            this.lblsex.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(262, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 15);
            this.label20.TabIndex = 14;
            this.label20.Text = "Ԥ��";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(448, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "����";
            // 
            // lblks
            // 
            this.lblks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblks.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblks.Location = new System.Drawing.Point(62, 34);
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size(194, 18);
            this.lblks.TabIndex = 13;
            // 
            // lblage
            // 
            this.lblage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblage.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblage.Location = new System.Drawing.Point(491, 6);
            this.lblage.Name = "lblage";
            this.lblage.Size = new System.Drawing.Size(45, 18);
            this.lblage.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(5, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 15);
            this.label19.TabIndex = 12;
            this.label19.Text = "����";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(542, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "�ѱ�";
            // 
            // lblfb
            // 
            this.lblfb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblfb.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblfb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblfb.Location = new System.Drawing.Point(585, 6);
            this.lblfb.Name = "lblfb";
            this.lblfb.Size = new System.Drawing.Size(84, 18);
            this.lblfb.TabIndex = 11;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(254, 461);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(895, 26);
            this.statusBar1.TabIndex = 15;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 180;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 180;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 518;
            // 
            // contextMenu1
            // 
            this.contextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuall,
            this.mnutyl,
            this.mnutjs,
            this.mnuprint});
            this.contextMenu1.Name = "contextMenu1";
            this.contextMenu1.Size = new System.Drawing.Size(137, 92);
            // 
            // mnuall
            // 
            this.mnuall.Name = "mnuall";
            this.mnuall.Size = new System.Drawing.Size(136, 22);
            this.mnuall.Text = "�����Ŵ���";
            this.mnuall.Click += new System.EventHandler(this.mnuall_Click);
            // 
            // mnutyl
            // 
            this.mnutyl.Name = "mnutyl";
            this.mnutyl.Size = new System.Drawing.Size(136, 22);
            this.mnutyl.Text = "������";
            this.mnutyl.Click += new System.EventHandler(this.mnutyl_Click);
            // 
            // mnutjs
            // 
            this.mnutjs.Name = "mnutjs";
            this.mnutjs.Size = new System.Drawing.Size(136, 22);
            this.mnutjs.Text = "�˼���";
            this.mnutjs.Click += new System.EventHandler(this.mnutjs_Click);
            // 
            // mnuprint
            // 
            this.mnuprint.Name = "mnuprint";
            this.mnuprint.Size = new System.Drawing.Size(136, 22);
            this.mnuprint.Text = "��ӡ����";
            this.mnuprint.Click += new System.EventHandler(this.mnuprint_Click);
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.btnJz);
            this.panel20.Controls.Add(this.chkaddpatient);
            this.panel20.Controls.Add(this.butfy);
            this.panel20.Controls.Add(this.label5);
            this.panel20.Controls.Add(this.butjjty);
            this.panel20.Controls.Add(this.cmbpyr);
            this.panel20.Controls.Add(this.chkprintview);
            this.panel20.Controls.Add(this.butprint);
            this.panel20.Controls.Add(this.butprinthz);
            this.panel20.Controls.Add(this.butquit);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel20.Location = new System.Drawing.Point(254, 428);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(895, 33);
            this.panel20.TabIndex = 17;
            // 
            // btnJz
            // 
            this.btnJz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJz.ForeColor = System.Drawing.Color.Navy;
            this.btnJz.Location = new System.Drawing.Point(593, 3);
            this.btnJz.Name = "btnJz";
            this.btnJz.Size = new System.Drawing.Size(76, 25);
            this.btnJz.TabIndex = 20;
            this.btnJz.Text = "����(&C)";
            this.btnJz.Click += new System.EventHandler(this.btnJz_Click);
            // 
            // chkaddpatient
            // 
            this.chkaddpatient.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkaddpatient.ForeColor = System.Drawing.Color.Navy;
            this.chkaddpatient.Location = new System.Drawing.Point(678, 5);
            this.chkaddpatient.Name = "chkaddpatient";
            this.chkaddpatient.Size = new System.Drawing.Size(119, 20);
            this.chkaddpatient.TabIndex = 19;
            this.chkaddpatient.Text = "���ؿ��Ҳ���";
            this.chkaddpatient.Visible = false;
            // 
            // Frmcffy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1149, 487);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.panelbrxx);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel12);
            this.Name = "Frmcffy";
            this.Text = "Frmcffy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmcffy_Load);
            this.tabControl2.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelbrxx.ResumeLayout(false);
            this.panelbrxx.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.contextMenu1.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


        bool isloadAlter = false;
        //���ش���
        private void Frmcffy_Load(object sender, System.EventArgs e)
        {
            try
            {
                //Modify By Tany 2015-06-16 ���Ȱ�����¼�ж�ص�����������װ��
                cmbbs1.SelectedIndexChanged -= cmbbs1_SelectedIndexChanged;
                cmbbs2.SelectedIndexChanged -= cmbbs2_SelectedIndexChanged;

                DataTable tbWard = this.GetWardList(0);

                treeListView1.SmallImageList = imageList1;
                Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, cmbpyr, InstanceForm.BDatabase);
                cmbpyr.SelectedValue = Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId);

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                {
                    Yp.AddcmbWardDept(cmbbs1, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs2, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                }
                else
                {
                    Yp.AddcmbWardDept(cmbbs1, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs2, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                }

                cmbbs1.SelectedIndex = 0;
                cmbbs2.SelectedIndex = 0;
                CshMxGrid(this.myDataGrid1);
                CshHzGrid(this.myDataGrid2);
                SystemCfg sysrq = new SystemCfg(8019);
                this.dtprq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(Convert.ToInt32(sysrq.Config) * (-1));
                this.dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                this.chkrq.Checked = true;
                this.tabControl1.SelectedTab = this.tabPage1;
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                {
                    this.chkrq.Checked = false;
                    this.butfy.Visible = false;
                    this.butprinthz.Visible = false;
                    this.label5.Visible = false;
                    this.cmbpyr.Visible = false;
                    this.cmbbs2.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    this.cmbbs1.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    this.cmbbs1.Enabled = false;
                    this.cmbbs2.Enabled = false;

                }
                SystemCfg cfg8051 = new SystemCfg(8051);
                pcglfs = cfg8051.Config;

                //Modify By Tany 2015-06-16 ��������װ��
                cmbbs1.SelectedIndexChanged += cmbbs1_SelectedIndexChanged;
                cmbbs2.SelectedIndexChanged += cmbbs2_SelectedIndexChanged;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            string cxfs = ApiFunction.GetIniString("סԺ������ҩĬ�ϴ�ӡ��ʽ", "��ӡ��ʽ", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (cxfs == "Ĭ�ϴ���ϸ")
                rdomx.Checked = true;
            if (cxfs == "Ĭ�ϴ����")
                rdohz.Checked = true;
            if (cxfs == "Ĭ�ϲ���ӡ")
                rdobdy.Checked = true;
            //������ҩ��ʾ��ncq add 2014-03-24
            cfghlyytype = (new SystemCfg(8040)).Config;//8040������0����ʹ�ú�����ҩ��ʾ��1����ͨ
            if (cfghlyytype != "0" && cfghlyytype != "")
            {
                hlyyjk = Ts_Hlyy_Interface.HlyyFactory.Hlyy("��ͨ");
                hlyyjk.RegisterServer_fun(null);//���ĵ�
                //hlyyjk.Refresh();//ˢ���ĵ�
            }
            bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//�������ι���

            rdCffy.Checked = true;

            //Modify by jchl
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "ȫ��" });
                dt.Rows.Add(new object[] { "1", "�����ҷ�ҩ" });
                dt.Rows.Add(new object[] { "2", "���ϴ����" });

                Addcmb(cmbFylb, dt, "id", "name");

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_ZCY")
                {
                    cmbFylb.SelectedIndex = 2;
                    rdCydy.Visible = false;
                    rdCffy.Checked = true;
                    btnJz.Visible = false;
                }
                else if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_YFFY")
                {
                    cmbFylb.SelectedIndex = 1;
                }
                else
                {
                    cmbFylb.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private bool IsVisable(string columnName, bool defaultVisable)
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("סԺ������ҩ������", columnName, Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("סԺ������ҩ������", columnName, defaultVisable ? "1" : "0", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("סԺ������ҩ������", columnName, Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }

        private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        {
            #region �����ϸ����------------------
            List<ColumnDefine> columns = new List<ColumnDefine>();
            columns.Add(PubClass.NewColumnDefine("���", "���", 30, true, 1));
            columns.Add(PubClass.NewColumnDefine("��ҩ", "��ҩ", 30, true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҩ����", "��ҩ����", (IsVisable("��ҩ����", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҩ����", "��ҩ����", (IsVisable("��ҩ����", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", true) ? 30 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", true) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("סԺ��", "סԺ��", (IsVisable("סԺ��", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("�Ա�", "�Ա�", (IsVisable("�Ա�", true) ? 30 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", false) ? 40 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", false) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��Ʒ��", "��Ʒ��", (IsVisable("��Ʒ��", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("Ʒ��", "Ʒ��", (IsVisable("Ʒ��", true) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("���", "���", (IsVisable("���", true) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", true) ? 80 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("�����", "�����", (IsVisable("�����", false) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", true) ? 60 : 0), true, 0));
            //update code by py 7-1 18:40
            columns.Add(PubClass.NewColumnDefine("��λ", "��λ", (IsVisable("��λ", true) ? 35 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", true) ? 55 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("���", "���", (IsVisable("���", true) ? 70 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҩ", "��ҩ", (IsVisable("��ҩ", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("�÷�", "�÷�", (IsVisable("�÷�", true) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("Ƶ��", "Ƶ��", (IsVisable("Ƶ��", true) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", true) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("������λ", "������λ", (IsVisable("������λ", false) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", (IsVisable("����", false) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��������", "��������", (IsVisable("��������", true) ? 110 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("�Ƿ�����", "�Ƿ�����", (IsVisable("�Ƿ�����", true) ? 77 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("�Ƿ�Ա", "�Ƿ�Ա", (IsVisable("�Ƿ�Ա", true) ? 70 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҩ����", "��ҩ����", (IsVisable("��ҩ����", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҩԱ", "��ҩԱ", (IsVisable("��ҩԱ", true) ? 70 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҩԱ", "��ҩԱ", (IsVisable("��ҩԱ", false) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("������", "������", (IsVisable("������", true) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("zy_id", "zy_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_id", "dept_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("doc_id", "doc_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("unitrate", "unitrate", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ypsl", "ypsl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("zxdw", "zxdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("inpatient_id", "inpatient_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("������", "������", (IsVisable("������", false) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("�������", "�������", (IsVisable("�������", false) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("charge_bit", "charge_bit", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("discharge_bit", "discharge_bit", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ҽ��", "ҽ��", (IsVisable("�������", true) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_ly", "dept_ly", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("���", "���", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҽ���", "��ҽ���", (IsVisable("��ҽ���", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҽ֢��", "��ҽ֢��", (IsVisable("��ҽ֢��", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("STATITEM_CODE", "STATITEM_CODE", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("��ͥ��ַ", "��ͥ��ַ", (IsVisable("��ͥ��ַ", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("��ϵ��ʽ", "��ϵ��ʽ", (IsVisable("��ϵ��ʽ", false) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("���֤", "���֤", (IsVisable("���֤", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("cz_id", "cz_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("kcid", "kcid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("execdept_id", "execdept_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("hwh", "hwh", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("�����÷�", "tsyf", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("������λ����", "������λ����", 0, true, 0));

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";
            int index = 0;
            foreach (ColumnDefine cd in columns)
            {
                //DataGridEnableBoolColumn
                if (cd.ColBoolButton == 0)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "";
                    colText.ReadOnly = cd.ColReadOnly;
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);

                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol;
                    if (cd.MappingName.Trim() == "ypsl" || cd.MappingName == "���")
                        datacol = new DataColumn(cd.MappingName, Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(cd.MappingName);

                    dtTmp.Columns.Add(datacol);
                }
                else
                {
                    DataGridButtonColumn btnCol = new DataGridButtonColumn(index);
                    btnCol.HeaderText = cd.HeaderText;
                    btnCol.MappingName = cd.MappingName;
                    btnCol.Width = cd.ColWidth;

                    btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);

                    this.myDataGrid1.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
                    this.myDataGrid1.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);

                    DataColumn datacol;
                    datacol = new DataColumn(cd.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                index++;
            }

            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbmx";

            if (ss.����������ʾ��Ʒ�� == true)
                xcjwDataGrid.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 100;
            else
                xcjwDataGrid.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 0;

            if ((new SystemCfg(8007)).Config == "0")
                this.myDataGrid1.TableStyles[0].GridColumnStyles["ҽ��"].Width = 0;
            #endregion

        }

        private void CshHzGrid(TrasenClasses.GeneralControls.DataGridEx xcjwDataGrid)
        {
            #region ��ӻ��ܵ���
            List<ColumnDefine> columns = new List<ColumnDefine>();
            columns.Add(PubClass.NewColumnDefine("���", "���", 35, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("Ʒ��", "Ʒ��", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("��Ʒ��", "��Ʒ��", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("���", "���", 100, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 65, true, 0));
            columns.Add(PubClass.NewColumnDefine("�����", "�����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҩ��", "��ҩ��", 65, true, 0));
            columns.Add(PubClass.NewColumnDefine("ȱҩ��", "ȱҩ��", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("��λ", "��λ", 40, true, 0));
            columns.Add(PubClass.NewColumnDefine("ҩ�ⵥλ", "ҩ�ⵥλ", 75, true, 0));
            columns.Add(PubClass.NewColumnDefine("���", "���", 75, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("��ҩ����", "��ҩ����", 0, true, 0));

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbhz";
            int index = 0;
            foreach (ColumnDefine cd in columns)
            {
                DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                colText.HeaderText = cd.HeaderText;
                colText.MappingName = cd.MappingName;
                colText.Width = cd.ColWidth;
                colText.NullText = "";
                colText.ReadOnly = cd.ColReadOnly;
                colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid2_CheckCellEnabled);
                xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                DataColumn datacol;
                if (cd.MappingName.Trim() == "ypsl" || cd.MappingName == "���")
                    datacol = new DataColumn(cd.MappingName, Type.GetType("System.Decimal"));
                else
                    datacol = new DataColumn(cd.MappingName);

                dtTmp.Columns.Add(datacol);

                index++;
            }
            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbhz";
            #endregion

        }

        //����ɫ�ı��¼�
        private void myDataGrid1_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            try
            {

                e.BackColor = Color.White;
                DataTable tb;
                if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn tbxColumn = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)tbxColumn.DataGridTableStyle.DataGrid.DataSource;
                }
                if (e.Row > tb.Rows.Count - 1)
                    return;
                //				if (tb.Rows[e.Row]["cjid"].ToString().Trim()=="")
                //					e.BackColor=Color.Azure;

                if (tb.Rows[e.Row]["��ҩ"].ToString().Trim() == "��")
                    e.ForeColor = Color.Blue;
                if (tb.Rows[e.Row]["��ҩ"].ToString().Trim() == "")
                {
                    //if (tabControl1.SelectedTab == tabPage1)
                    //{
                    //    if (tb.Rows[e.Row]["����"] != null && tb.Rows[e.Row]["����"].ToString().Trim() != string.Empty)
                    //    {
                    //        tb.Rows[e.Row]["��ҩ"] = "��";
                    //        e.ForeColor = Color.Blue;//Color.Black;
                    //    }
                    //    else
                    //    {
                    //        //tb.Rows[e.Row]["��ҩ"] = string.Empty;
                    //        e.ForeColor = Color.Black;
                    //    }
                    //}
                    //else
                    //{
                    e.ForeColor = Color.Black;
                    //}
                }
                if (tb.Rows[e.Row]["��ҩ"].ToString().Trim() == "��")
                    e.ForeColor = Color.Gray;

                //Modify by jchl
                if (tb.Rows[e.Row]["����"].ToString().Trim() == "������" && tb.Rows[e.Row]["STATITEM_CODE"].ToString().Trim() == "03")
                {
                    e.BackColor = Color.LightGreen;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //			
        }

        private void myDataGrid2_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            if (e.Row > tb.Rows.Count - 1)
                return;
            if (Convert.ToDecimal(tb.Rows[e.Row]["��ҩ��"]) > Convert.ToDecimal(tb.Rows[e.Row]["�����"]))
                e.ForeColor = Color.Red;
            else
                e.ForeColor = Color.Black;
        }

        //��Ӳ���
        private void AddWardTree(int dept_ly, System.Windows.Forms.TreeListView treeListView, Crownwood.Magic.Controls.TabPage Tabpage)
        {
            treeListView.Items.Clear();
            //DataTable mytb=(DataTable)this.myDataGrid1.DataSource;
            //mytb.Rows.Clear();
            treeListView.SmallImageList = imageList1;
            string swhere = "";
            string ssql = @" select name,a.dept_id,d_code from jc_dept_property a left join jc_ward  b on a.dept_id=b.dept_id
                            where a.dept_id in(
                            select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm + "  and a.DELETED = 0";
            if (dept_ly > 0)
                ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'99999999')";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                //��Ӳ���
                TreeListViewItem itemA = new TreeListViewItem(tb.Rows[i]["name"].ToString(), 0);
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.Tag = tb.Rows[i]["dept_id"].ToString();
                itemA.ForeColor = Color.Black;
                itemA.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                treeListView.Items.Add(itemA);
            }
            treeListView.Columns[0].Width = treeListView.Width - 20;
        }

        //���Ӳ���
        private void AddWardPatientTree(string wardid, System.Windows.Forms.TreeListView treeListView, Crownwood.Magic.Controls.TabPage Tabpage)
        {
            string ssql = "";
            if (wardid.Trim() != "")
                ssql = "select inpatient_no,bed_no,name,sex_name,age,jsfs_name,cur_dept_name,inpatient_id,ward_id from VI_ZY_VINPATIENT_ALL where flag<>2 and ward_id='" + wardid.Trim() + "' order by bed_no";
            else
                ssql = "select inpatient_no,bed_no,name,sex_name,age,jsfs_name,cur_dept_name,inpatient_id,ward_id from VI_ZY_VINPATIENT_ALL where flag<>2  order by bed_no";

            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

            /*
             * update code by pengy 7-3 11:30
             * ������û��ҩƷ�Ŀ���
             */
            treeListView1.BeginUpdate();
            //Dictionary<string, string> itemView = new Dictionary<string, string>();
            for (int i = treeListView1.Items.Count - 1; i > -1; i--)
            {
                treeListView.Items[i].Items.Clear();
                DataRow[] rows = tb.Select("ward_id='" + treeListView.Items[i].Tag.ToString().Trim() + "'");
                if (rows != null && rows.Length > 0)
                {
                    for (int j = 0; j <= rows.Length - 1; j++)
                    {
                        TreeListViewItem itemA = new TreeListViewItem(tb.Rows[j]["inpatient_no"].ToString(), 1);
                        itemA.SubItems.Add(tb.Rows[j]["bed_no"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["name"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["sex_name"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["age"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["jsfs_name"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["cur_dept_name"].ToString().Trim());
                        itemA.Tag = tb.Rows[j]["inpatient_id"].ToString();

                        itemA.ForeColor = Color.Black;
                        itemA.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        treeListView.Items[i].Items.Add(itemA);
                    }
                }
                else
                {
                    treeListView1.Items.Remove(treeListView1.Items[i]);
                }
            }
            //foreach (KeyValuePair<string, string> tmp in itemView)
            //{
            //    TreeListViewItem itemA = new TreeListViewItem(tmp.Value, 0);
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.Tag = tmp.Key;
            //    itemA.ForeColor = Color.Black;
            //    itemA.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            //    treeListView1.Items.Add(itemA);
            //}
            treeListView1.EndUpdate();
        }

        //��ѯ������ť�¼�
        private void butcfcx_Click(object sender, System.EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            this.lblbz.Text = "";
            try
            {

                DataTable tb = new DataTable();
                string wardid = "";
                Guid inpatient_id = Guid.Empty;

                string rq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                string rq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";

                //Modify by Zhujh 2017-02-18
                string rq3 = chkJzRq.Checked == true ? dtpjzrq1.Value.ToShortDateString() : "";
                string rq4 = chkJzRq.Checked == true ? dtpjzrq2.Value.ToShortDateString() : "";

                int bk = this.rdodq.Checked == true ? 0 : 1;

                if (new Guid(Convertor.IsNull(this.txtzyh.Tag, Guid.Empty.ToString())) == Guid.Empty)
                {
                    if (this.tabControl1.SelectedTab == this.tabPage1)
                        wardid = this.cmbbs1.SelectedValue.ToString();
                    if (this.tabControl1.SelectedTab == this.tabPage2)
                        wardid = this.cmbbs2.SelectedValue.ToString();
                }



                inpatient_id = new Guid(Convertor.IsNull(this.txtzyh.Tag, Guid.Empty.ToString()));
                if (txtzyh.Text.Trim() != "" && inpatient_id == Guid.Empty)
                {
                    txtzyh_KeyPress(sender, new KeyPressEventArgs('\r'));
                    inpatient_id = new Guid(Convertor.IsNull(this.txtzyh.Tag, Guid.Empty.ToString()));
                }

                decimal cfh = Convert.ToDecimal(Convertor.IsNull(txtcfh.Text.Trim(), "0"));

                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;
                //δ��ҩ
                if (this.tabControl1.SelectedTab == this.tabPage1)
                {
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                    {
                        //  tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18 
                        if (chkJzRq.Checked)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "0", bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                    else
                    {
                        // tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by zhujh 2017-02-18
                        if (chkJzRq.Checked)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "0", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                }
                //�ѷ�ҩ
                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    if (((rq1.Trim() == "" && chkrq.Checked) || (rq3.Trim()==""&& chkJzRq.Checked)) && inpatient_id == Guid.Empty)
                    {
                        MessageBox.Show("��ѯ��Χ̫�󣬱���ѡ�����ڲ��ܲ�ѯ");
                        return;
                    }

                    string fybz = "1";
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                        fybz = "9";

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18
                        if (chkJzRq.Checked == true)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", fybz, bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                    else
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18
                        if (chkJzRq.Checked == true)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", fybz, bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                }

                //���鴦��
                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    string[] GroupbyField1 ={ "��ҩ����", "dept_ly" };
                    string[] ComputeField1 ={ "���" };
                    string[] CField1 ={ "sum" };
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tb;
                    DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "cjid>0");
                    if (tbcf1.Rows.Count == 0)
                    {
                        return;
                    }
                    this.treeListView3.SmallImageList = imageList1;
                    treeListView3.Items.Clear();
                    for (int i = 0; i <= tbcf1.Rows.Count - 1; i++)
                    {
                        //��Ӳ���
                        TreeListViewItem itemA = new TreeListViewItem(tbcf1.Rows[i]["��ҩ����"].ToString(), 0);
                        itemA.SubItems.Add(Yp.SeekDeptName(Convert.ToInt32(tbcf1.Rows[i]["dept_ly"].ToString()), InstanceForm.BDatabase));
                        itemA.SubItems.Add(tbcf1.Rows[i]["���"].ToString());
                        itemA.Tag = tbcf1.Rows[i]["dept_ly"].ToString();
                        itemA.ForeColor = Color.Black;
                        itemA.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        treeListView3.Items.Add(itemA);
                    }
                }
                if (rdCydy.Checked)
                {
                    /*
                     *  update code by pengy on 7-8 15:10
                     *  ֻ��ʾ�ѽ���Ĳ��˷�ҩ
                     */
                    DataTable table = tb.Clone();
                    DataRow[] resultRows = tb.Select(" DISCHARGE_BIT = 1");
                    if (tb.Rows.Count > 0 && resultRows.Length == 0)
                    {
                        MessageBox.Show("�ò���δ���㣡", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.AddPresc(tb);
                    //foreach ( DataRow row in resultRows )
                    //{
                    //    table.Rows.Add( row.ItemArray );
                    //}
                    //this.AddPresc( table );
                }
                else
                {
                    //��Ӵ���
                    this.AddPresc(tb);
                }
                butfy.Tag = "";
                chkall.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //��Ӵ�����¼
        private void AddPresc(DataTable tbcf)
        {

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();

            if (tbcf.Rows.Count == 0)
                return;

            //Modify by jchl
            if (rdCffy.Checked)
            {
                tbcf = DoFilFylb(tbcf);
            }

            if (tbcf.Rows.Count == 0)
                return;

            string _prescNo = tbcf.Rows[0]["������"].ToString().Trim();
            int _PrescRowNo = 0;
            decimal _PrescJe = 0;
            string _cfrq = "";
            string _zyh = "";
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                if (tbcf.Rows[i]["������"].ToString().Trim() != _prescNo)
                {
                    DataRow row = tb.NewRow();
                    row["���"] = "С��";
                    row["���"] = _PrescJe.ToString("0.00");
                    row["������"] = _prescNo;
                    row["סԺ��"] = _zyh;
                    _prescNo = tbcf.Rows[i]["������"].ToString().Trim();
                    _cfrq = tbcf.Rows[i]["��������"].ToString().Trim();
                    _PrescRowNo = 0;
                    _PrescJe = 0;
                    tb.Rows.Add(row);

                    DataRow row1 = tb.NewRow();
                    tb.Rows.Add(row1);
                }

                if (tbcf.Rows[i]["������"].ToString().Trim() == _prescNo)
                {
                    _PrescRowNo = _PrescRowNo + 1;
                    tbcf.Rows[i]["���"] = _PrescRowNo.ToString();
                    //					if (this.tabControl1.SelectedTab==this.tabPage2) tbcf.Rows[i]["��ҩ"]="��";
                    tb.ImportRow(tbcf.Rows[i]);

                    if (this.tabControl1.SelectedTab == this.tabPage2)
                        tb.Rows[tb.Rows.Count - 1]["��ҩ"] = "��";
                    else
                        tb.Rows[tb.Rows.Count - 1]["��ҩ"] = "��";

                    _PrescJe = _PrescJe + Convert.ToDecimal(tbcf.Rows[i]["���"]);
                }

                _prescNo = tbcf.Rows[i]["������"].ToString().Trim();
                _cfrq = tbcf.Rows[i]["��������"].ToString().Trim();
            }

            //������һ�Ŵ����ĺϼ�
            DataRow endrow = tb.NewRow();
            endrow["���"] = "С��";
            endrow["���"] = _PrescJe.ToString("0.00");
            endrow["סԺ��"] = Convert.ToDateTime(_cfrq).ToShortDateString();
            tb.Rows.Add(endrow);
            tb.TableName = "tbmx";
            this.myDataGrid1.DataSource = tb;
        }

        //����ҩƷ����
        private void computeTld(string fyrq)
        {
            bool bGrpByDeptLy = false;
            bGrpByDeptLy = _menuTag.Function_Name.Trim().Equals("Fun_ts_yf_zyfy_cf_ZCY");//�в�ҩ�ϴ���������ҩ���ҷ���
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            string[] GroupbyField ={ "����", "Ʒ��", "��Ʒ��", "���", "����", "����", "�����", "����", "cjid", "zxdw", "dwbl", "dept_ly" };

            if (bGrpByDeptLy)
            {
                GroupbyField = new string[] { "����", "Ʒ��", "��Ʒ��", "���", "����", "����", "�����", "����", "cjid", "zxdw", "dwbl" };
            }

            string[] ComputeField ={ "ypsl", "���" };
            string[] CField ={ "sum", "sum" };

            //			TrasenFrame.Classes.TsSet xcset=new TrasenFrame.Classes.TsSet();
            //			xcset.TsDataTable=tb;
            //����ÿ��ͳ�����
            //			DataTable tab=xcset.GroupTable(GroupbyField,ComputeField,CField,"��ҩ='��' and ypsl<>0");

            DataTable tab;
            DataRow[] selrow;

            if (this.tabControl1.SelectedTab == this.tabPage2)
                selrow = tb.Select("��ҩ='��' and ypsl<>0");
            else
            {
                if (fyrq != "")
                    selrow = tb.Select("��ҩ='��' and ypsl<>0 and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                else
                    selrow = tb.Select("��ҩ='��' and ypsl<>0");
            }

            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

            DataTable mytb = (DataTable)this.myDataGrid2.DataSource;
            mytb.Rows.Clear();

            DataRow[] Rows = tab.Select("", "����");
            //�������
            for (int x = 0; x <= Rows.Length - 1; x++)
            {
                DataRow row = mytb.NewRow();
                row["���"] = mytb.Rows.Count + 1;
                row["����"] = Rows[x]["����"];
                row["Ʒ��"] = Rows[x]["Ʒ��"];
                row["��Ʒ��"] = Rows[x]["��Ʒ��"];
                row["���"] = Rows[x]["���"];
                row["����"] = Rows[x]["����"];
                row["����"] = Rows[x]["����"];
                row["�����"] = Rows[x]["�����"];
                row["��ҩ��"] = Rows[x]["ypsl"];
                decimal kcl = Convert.ToDecimal(Rows[x]["�����"]);
                decimal ypsl = Convert.ToDecimal(Rows[x]["ypsl"]);
                decimal dwbl = Convert.ToDecimal(Rows[x]["dwbl"]);
                row["ȱҩ��"] = (kcl - ypsl) < 0 ? System.Math.Abs(kcl - ypsl) : 0;
                row["��λ"] = Yp.SeekYpdw(Convert.ToInt32(Rows[x]["zxdw"]), InstanceForm.BDatabase);
                Ypcj cj = new Ypcj(Convert.ToInt32(Rows[x]["cjid"]), InstanceForm.BDatabase);
                row["ҩ�ⵥλ"] = Convert.ToDouble(Math.Round(ypsl / dwbl, 3)).ToString() + cj.S_YPDW;
                row["���"] = Rows[x]["���"];
                row["����"] = Rows[x]["����"];
                row["cjid"] = Rows[x]["cjid"];
                row["dwbl"] = Rows[x]["dwbl"];
                if (!bGrpByDeptLy)
                {
                    row["��ҩ����"] = Yp.SeekDeptName(Convert.ToInt32(Rows[x]["dept_ly"]), InstanceForm.BDatabase);
                }
                mytb.Rows.Add(row);
            }
        }

        private void treeListView1_DoubleClick(object sender, System.EventArgs e)
        {
            this.lblbz.Text = "";
            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            if (TreeListView.SelectedItems.Count == 0 || TreeListView.SelectedItems[0] == null)
                return;
            TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];
            if (item.ImageIndex != 0)
            {
                //txtzyh.Text=item.Text.Trim();
                //txtzyh.Tag=item.Tag;
            }
            if (chkbrxx.Checked == true)
                this.ShowPatient(Convert.ToInt64(txtzyh.Tag), 0, 0);
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {

                DataTable tb = new DataTable();
                string wardid = "";
                Guid inpatient_id = Guid.Empty;
                string rq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                string rq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                int bk = this.rdodq.Checked == true ? 0 : 1;

                //Modify by Zhujh 2017-02-18
                string rq3 = chkJzRq.Checked == true ? dtpjzrq1.Value.ToShortDateString() : "";
                string rq4 = chkJzRq.Checked == true ? dtpjzrq2.Value.ToShortDateString() : "";

                if (item.ImageIndex != 0)
                    wardid = item.Parent.Tag.ToString();
                else
                    wardid = item.Tag.ToString();
                //wardid=item.Tag.ToString();

                decimal cfh = Convert.ToDecimal(Convertor.IsNull(txtcfh.Text.Trim(), "0"));

                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;

                int iCydy = 0;
                if (rdCydy.Checked)
                    iCydy = 1;
                else if (rdCffy.Checked)
                    iCydy = 0;

                //δ��ҩ
                if (this.tabControl1.SelectedTab == this.tabPage1)
                {
                    if (((rq1.Trim() == "" && chkrq.Checked) || (rq3.Trim() == "" && chkJzRq.Checked)) && inpatient_id == Guid.Empty)
                    {
                        MessageBox.Show("��ѯ��Χ̫�󣬱���ѡ�����ڲ��ܲ�ѯ");
                        return;
                    }

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18 
                        if (chkJzRq.Checked)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "0", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                    else
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        if (chkJzRq.Checked)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "0", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                }
                //�ѷ�ҩ
                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    if (((rq1.Trim() == "" && chkrq.Checked) || (rq3.Trim() == "" && chkJzRq.Checked)) && inpatient_id == Guid.Empty)
                    {
                        MessageBox.Show("��ѯ��Χ̫�󣬱���ѡ�����ڲ��ܲ�ѯ");
                        return;
                    }

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18
                        if (chkJzRq.Checked == true)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                    else
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18
                        if (chkJzRq.Checked == true)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                }
                if (rdCydy.Checked)
                {
                    /*
                     *  update code by pengy on 7-8 15:10
                     *  ֻ��ʾ�ѽ���Ĳ��˷�ҩ
                     */
                    DataTable table = tb.Clone();
                    DataRow[] resultRows = tb.Select(" DISCHARGE_BIT = 1");
                    foreach (DataRow row in resultRows)
                    {
                        table.Rows.Add(row.ItemArray);
                    }
                    this.AddPresc(table);
                }
                else
                {

                    //��Ӵ���
                    this.AddPresc(tb);
                }
                chkall.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void treeListView2_DoubleClick(object sender, System.EventArgs e)
        {
            this.lblbz.Text = "";
            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            if (TreeListView.SelectedItems.Count == 0 || TreeListView.SelectedItems[0] == null)
                return;
            TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];

            this.Cursor = PubStaticFun.WaitCursor();
            try
            {

                DataTable tb = new DataTable();
                string wardid = "";
                Guid inpatient_id = Guid.Empty;
                string rq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                string rq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                int bk = this.rdodq.Checked == true ? 0 : 1;

                if (item.ImageIndex != 0)
                    wardid = item.Parent.Tag.ToString();
                else
                    wardid = item.Tag.ToString();
                //wardid=item.Tag.ToString();

                decimal cfh = Convert.ToDecimal(Convertor.IsNull(txtcfh.Text.Trim(), "0"));

                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;

                int iCydy = 0;
                if (rdCydy.Checked)
                    iCydy = 1;
                else if (rdCffy.Checked)
                    iCydy = 0;

                //�ѷ�ҩ
                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    if (rq1.Trim() == "" && inpatient_id == Guid.Empty)
                    {
                        MessageBox.Show("��ѯ��Χ̫�󣬱���ѡ�����ڲ��ܲ�ѯ");
                        return;
                    }
                    //wardid = "";
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                    else
                        tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                }
                if (rdCydy.Checked)
                {
                    /*
                     *  update code by pengy on 7-8 15:10
                     *  ֻ��ʾ�ѽ���Ĳ��˷�ҩ
                     */
                    DataTable table = tb.Clone();
                    DataRow[] resultRows = tb.Select(" DISCHARGE_BIT = 1");
                    foreach (DataRow row in resultRows)
                    {
                        table.Rows.Add(row.ItemArray);
                    }
                    this.AddPresc(table);
                }
                else
                {
                    //��Ӵ���
                    this.AddPresc(tb);
                }
                chkall.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #region һ�����
        //ѡ����ʱ
        private void cmbbs2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //AddWardTree( Convert.ToInt32( Convertor.IsNull( this.cmbbs2.SelectedValue , "0" ) ) , this.treeListView2 , this.tabPage2 );
            //if ( this.chkaddpatient.Checked == true )
            //    AddWardPatientTree( cmbbs2.SelectedValue.ToString() , this.treeListView2 , this.tabPage2 );

            this.Cursor = PubStaticFun.WaitCursor();
            try
            {

                DataTable tb = new DataTable();
                string wardid = Convertor.IsNull(cmbbs2.SelectedValue, "");
                Guid inpatient_id = Guid.Empty;
                string rq1 = dtprq1.Value.ToShortDateString();
                string rq2 = dtprq2.Value.ToShortDateString();
                int bk = this.rdodq.Checked == true ? 0 : 1;


                decimal cfh = 0;
                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;

                int iCydy = 0;
                if (rdCydy.Checked)
                    iCydy = 1;
                else if (rdCffy.Checked)
                    iCydy = 0;

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                else
                    tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);

                if (rdCydy.Checked)
                {
                    DataTable table = tb.Clone();
                    DataRow[] resultRows = tb.Select(" DISCHARGE_BIT = 1");
                    foreach (DataRow row in resultRows)
                        table.Rows.Add(row.ItemArray);
                    tb = table;
                }

                string[] GroupbyField1 ={ "��ҩ����", "dept_ly" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };

                DataTable tab = FunBase.GroupbyDataTable(tb, GroupbyField1, ComputeField1, CField1, null);
                DataRow[] r0 = tab.Select("", "��ҩ���� asc");
                tb = tab.Clone();
                foreach (DataRow r in r0)
                    tb.Rows.Add(r.ItemArray);

                treeListView2.Items.Clear();
                treeListView2.SmallImageList = imageList1;

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    //��Ӳ���
                    TreeListViewItem itemA = new TreeListViewItem(tb.Rows[i]["��ҩ����"].ToString(), 0);
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.Tag = tb.Rows[i]["dept_ly"].ToString();
                    itemA.ForeColor = Color.Black;
                    itemA.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                    treeListView2.Items.Add(itemA);
                }
                treeListView2.Columns[0].Width = treeListView2.Width - 20;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        //ѡ����ʱ
        private void cmbbs1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //AddWardTree( Convert.ToInt32( Convertor.IsNull( this.cmbbs1.SelectedValue , "0" ) ) , this.treeListView1 , this.tabPage1 );
            //if ( cmbbs1.Focused )
            //    GetMessage();
            GetMessage();
        }

        private void tabControl1_Click(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            DataTable tb1 = (DataTable)this.myDataGrid2.DataSource;
            tb1.Rows.Clear();

            if (this.tabControl1.SelectedTab == this.tabPage1)
            {
                this.chkrq.Text = "��������";
                chkall.Visible = true;
                this.butfy.Enabled = true;
                this.myDataGrid1.ContextMenuStrip = null;
                butjjty.Enabled = true;
                rdoall.Visible = false;
                rdowdy.Visible = false;
                this.myDataGrid1.TableStyles[0].GridColumnStyles["��ҩ����"].Width = 0;
                this.myDataGrid1.TableStyles[0].GridColumnStyles["��ҩԱ"].Width = 0;

                TrasenFrame.Classes.SystemCfg config = new SystemCfg(8034, InstanceForm.BDatabase);
                dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                dtprq1.Value = dtprq2.Value.AddDays(Convert.ToDouble(config.Config) * -1);
            }
            else
            {
                this.chkrq.Text = "��ҩ����";
                chkall.Visible = false;
                this.butfy.Enabled = false;
                this.chkrq.Checked = true;
                this.lblbz.Text = "";
                butjjty.Enabled = false;
                rdoall.Visible = true;
                rdowdy.Visible = true;
                this.myDataGrid1.TableStyles[0].GridColumnStyles["��ҩ����"].Width = 100;
                this.myDataGrid1.TableStyles[0].GridColumnStyles["��ҩԱ"].Width = 70;
                dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                dtprq1.Value = dtprq2.Value;
            }
        }

        private void tabControl2_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                computeTld("");

                if (this.tabControl2.SelectedTab == this.tabPage4)
                    this.butprinthz.Enabled = true;
                else
                    this.butprinthz.Enabled = false;


            }
            catch (System.Exception err)
            {
                DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                tb.Rows.Clear();
                MessageBox.Show(this, "��������" + err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        //���ز�����Ϣѡ��
        private void chkaddpatient_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkaddpatient.Checked == true)
            {
                if (this.tabControl1.SelectedTab == this.tabPage1)
                    AddWardPatientTree(cmbbs1.SelectedValue.ToString(), this.treeListView1, this.tabPage1);
                if (this.tabControl1.SelectedTab == this.tabPage2)
                    AddWardPatientTree(cmbbs2.SelectedValue.ToString(), this.treeListView2, this.tabPage2);
            }
        }

        //�Ƿ���ʾ������Ϣѡ��
        private void chkbrxx_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkbrxx.Checked == true)
                this.panelbrxx.Visible = true;
            else
                this.panelbrxx.Visible = false;

            this.ClearPatient();
            if (chkbrxx.Checked == true && Convert.ToInt64(Convertor.IsNull(txtzyh.Tag, "0")) > 0)
                this.ShowPatient(Convert.ToInt64(Convertor.IsNull(txtzyh.Tag, "0")), 0, 0);
        }

        private void chkrq_CheckedChanged(object sender, System.EventArgs e)
        {
            dtprq1.Enabled = this.chkrq.Checked == true ? true : false;
            dtprq2.Enabled = this.chkrq.Checked == true ? true : false;
            if (chkrq.Checked)
            {
                this.chkJzRq.Checked = false;
            }
        }
        //�����ŵĻس��¼�
        private void txtcfh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butcfcx_Click(sender, new EventArgs());
                if (((System.Data.DataTable)this.myDataGrid1.DataSource).Rows.Count > 0)
                {
                    butfy.Focus();
                }
            }
        }
        //סԺ�ŵĻس��¼�
        private void txtzyh_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) != 13)
                return;
            txtzyh.Text = FunBase.returnZyh(txtzyh.Text);

            //string ssql="select top 1 * from jc_patient_property a,zy_inpatient b where a.patient_id=b.patient_id and inpatient_no='"+txtzyh.Text+"' order by inpatient_id desc ";
            //DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
            DataTable tb = ZY_FY.SelectPatient(txtzyh.Text, Guid.Empty, InstanceForm.BDatabase);
            if (tb.Rows.Count != 0)
            {
                txtzyh.Tag = tb.Rows[0]["inpatient_id"].ToString();
                if (chkbrxx.Checked == true)
                    this.ShowPatient(Convert.ToInt64(txtzyh.Tag), 0, 0);
                this.butcfcx_Click(sender, e);
                if (((System.Data.DataTable)this.myDataGrid1.DataSource).Rows.Count > 0)
                {
                    butfy.Focus();
                }
                else
                {
                    txtzyh.SelectAll();
                    txtzyh.Focus();
                }
            }
            else
            {
                MessageBox.Show(this, "û���ҵ����ˣ���ȷ��סԺ���Ƿ���ȷ?", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }


        private void ClearPatient()
        {
            this.lblbedno.Text = "";
            this.lblname.Text = "";
            this.lblzyh.Text = "";
            this.lblsex.Text = "";
            this.lblage.Text = "";
            this.lblfb.Text = "";
            this.lblks.Text = "";
            this.lblyjj.Text = "";
            this.lbltotal.Text = "";
            this.lblye.Text = "";
        }
        //��ʾ������Ϣ
        private void ShowPatient(long inpatient_id, long baby_id, int ismy)
        {
            DataTable tb = ZY_FY.SeekPatientInfo(inpatient_id, baby_id, ismy, InstanceForm.BDatabase);
            if (tb.Rows.Count == 0)
            {
                ClearPatient();
            }
            this.lblbedno.Text = tb.Rows[0]["bed_no"].ToString().Trim();
            this.lblname.Text = tb.Rows[0]["name"].ToString().Trim();
            this.lblzyh.Text = tb.Rows[0]["inpatient_no"].ToString().Trim();
            this.lblsex.Text = tb.Rows[0]["sex_name"].ToString().Trim();
            this.lblage.Text = tb.Rows[0]["age"].ToString().Trim();
            this.lblfb.Text = tb.Rows[0]["jsfs_name"].ToString().Trim();
            this.lblks.Text = tb.Rows[0]["cur_dept_name"].ToString().Trim();
            decimal yjj = 0;
            decimal total = 0;
            decimal ye = 0;
            yjj = Convert.ToDecimal(tb.Rows[0]["yjk"]);
            total = Convert.ToDecimal(tb.Rows[0]["wjszfy"]);
            ye = Convert.ToDecimal(tb.Rows[0]["ye"]);
            this.lblyjj.Text = yjj.ToString("0.0");
            this.lbltotal.Text = total.ToString("0.0");
            this.lblye.Text = ye.ToString("0.0");


        }

        //סԺ�ŵ��ı��ı��¼�
        private void txtzyh_TextChanged(object sender, System.EventArgs e)
        {
            txtzyh.Tag = Guid.Empty.ToString();
        }
        //��ϸ�еİ�ť�¼�
        private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            try
            {
                //���Ϊ�ѷ�ҩ
                if (this.tabControl1.SelectedTab != this.tabPage1)
                {
                    DataTable tab = (DataTable)this.myDataGrid1.DataSource;
                    int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                    if (tab.Rows[nrow]["���"].ToString() == "" || tab.Rows[nrow]["���"].ToString() == "С��" || Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["����"], "0")) < 0)
                        this.myDataGrid1.ContextMenuStrip = null;
                    else
                    {
                        if (Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["����"], "0")) == 1)
                            mnutjs.Visible = false;
                        else
                            mnutjs.Visible = true;
                        this.myDataGrid1.ContextMenuStrip = contextMenu1;

                    }
                    return;
                }
                this.myDataGrid1.ContextMenuStrip = null;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {

                    if (tb.Rows[i]["������"].ToString().Trim() == tb.Rows[e.RowIndex]["������"].ToString().Trim() && tb.Rows[i]["סԺ��"].ToString().Trim() == tb.Rows[e.RowIndex]["סԺ��"].ToString().Trim() && tb.Rows[i]["������"].ToString().Trim() != "" && tb.Rows[i]["��ҩ"].ToString().Trim() != "��" && tb.Rows[i]["��ҩ"].ToString().Trim() != "��")
                    {
                        if (tb.Rows[i]["��ҩ"].ToString().Trim() == "")
                            tb.Rows[i]["��ҩ"] = "��";
                        else
                            tb.Rows[i]["��ҩ"] = "";
                    }
                }
                ComputeCf();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //ȫѡ
        private void chkall_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.tabControl1.SelectedTab != this.tabPage1)
                    return;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (tb.Rows[i]["������"].ToString().Trim() != "" && tb.Rows[i]["��ҩ"].ToString().Trim() != "��")
                    {
                        if (chkall.Checked == true)
                            tb.Rows[i]["��ҩ"] = "��";
                        else
                            tb.Rows[i]["��ҩ"] = "";
                    }
                }
                ComputeCf();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        #endregion

        private void DoZcyJyFy()
        {

            //ʱ��
            DateTime _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            try
            {
                string hosCode = "990002";
                string hosName = "�人������ҽԺ";

                //string sFre = string.Format(@"select EXECNUM,* from JC_FREQUENCY ");
                //DataTable dtFre = InstanceForm.BDatabase.GetDataTable(sFre);

                if (rdCffy.Checked)
                {
                    //������ҩ���в�ҩ��ˮ���������
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    DataTable tbhz = (DataTable)this.myDataGrid2.DataSource;
                    int NN = 0;
                    int YY = 0;
                    //���鴦��
                    string[] GroupbyField ={ "סԺ��", "����", "inpatient_id", "������", "dept_id", "doc_id", "����" };
                    string[] ComputeField ={ "���" };
                    string[] CField ={ "sum" };
                    TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                    xcset.TsDataTable = tb;

                    //Modify by jchl �в�ҩ��ҩ�޸�
                    DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "��ҩ='��' and STATITEM_CODE='03' and ypsl<>0 and ��ҩ='����' and �÷�='ˮ���'");

                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                        return;
                    }
                    else if (tbcf.Rows.Count > 1)
                    {
                        MessageBox.Show("�в�ҩ��ҩ����ֻ�ܵ��ŷ���");
                        return;
                    }

                    //DataTable tb_h = (DataTable)this.myDataGrid1.DataSource;
                    ////���鴦��
                    //string[] GroupbyField_h ={ "סԺ��", "����", "inpatient_id", "������", "dept_id", "doc_id", "����" };
                    //string[] ComputeField_h ={ "���" };
                    //string[] CField_h ={ "sum" };
                    //TrasenFrame.Classes.TsSet xcset_h = new TrasenFrame.Classes.TsSet();
                    //xcset_h.TsDataTable = tb_h;
                    //DataTable tbcf_h = xcset_h.GroupTable(GroupbyField_h, ComputeField_h, CField_h, "��ҩ='��' and ypsl<>0 and ��ҩ='����' and �÷�='ˮ���'");

                    //������ҩ�У��в�ҩ��ˮ���������
                    if (tbcf.Rows.Count > 0)
                    {
                        for (int i = 0; i < tbcf.Rows.Count; i++)
                        {
                            bool bThisPresSuc = false;

                            string _presc_no = Convert.ToString(tbcf.Rows[i]["������"]); //������ 
                            decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���"], "0")); //���
                            int _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"], "0")); //����
                            Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["inpatient_id"], Guid.Empty.ToString()));//����ID

                            string _inpatient_no = Convert.ToString(tbcf.Rows[i]["סԺ��"]);//סԺ��
                            string _blh = "סԺ" + _inpatient_no;

                            string _jyfs = "2";//��ҩ��ʽ��д�������޸����ۡ�
                            string _allWgt = "";//����������������ʱ���ա�
                            string packvolume = "200";//��װ������д��Ĭ��200��

                            string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//����
                            string _hzxb = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["�Ա�"], ""));//�Ա�
                            string _hznl = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//����
                            string _jtdz = "";// Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["��ͥ��ַ"], ""));//��ͥ��ַ
                            string _lxfs = "";// Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["��ϵ��ʽ"], ""));//��ϵ��ʽ

                            string wardCode = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["��ҩ����"], ""));//��ҩ���ҡ����޸����ۡ�
                            string bedNo = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//����
                            string _ts = "2";////������һ�켸�Ρ�Ƶ�ʵ�ִ�д�����
                            string _fs = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//�����Ǽ���
                            string _yyfs = "";// Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["�÷�"], "")); ;//��ҩ��ʽ���÷���
                            string fre = "";//Convert.ToString(Convertor.IsNull(rows[j]["Ƶ��"], ""));

                            DateTime dtScTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//�ϴ�ʱ��

                            string buyUnit = "KG";

                            string doc = "";//Convert.ToString(Convertor.IsNull(rows[j]["ҽ��"], ""));

                            int _dept_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["dept_id"], "0"));//����
                            int _doc_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["doc_id"], "-1"));//ҽ��
                            Guid _fyid = Guid.Empty;//��ҩID

                            //�޸��ϴ� �� ����������
                            FrmZcyTsFs frmFsTs = new FrmZcyTsFs(_fs, _ts);
                            frmFsTs.ShowDialog();

                            if (frmFsTs.save)
                            {
                                _ts = frmFsTs.Ts;
                                _fs = frmFsTs.Fs;
                            }

                            DataRow[] rows = tb.Select("������='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and ����='" + _cfts.ToString() + "' and ����='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");

                            //��ѯ���͸ô�����ϸ�� ��ҩϵͳ 
                            decimal sumjhje = 0;//�ܽ������
                            NN = 0;//��ϸ����
                            string strMsg = "";
                            bool bDel = false;

                            //�ϴ�֮ǰ��ɾ��������ϸ
                            try
                            {
                                //�ϴ�֮ǰ��ɾ��������ϸ
                                //bDel = ClsZcyJy.ClsJyInterFace.DeletePres(hosCode, _presc_no, out strMsg);
                            }
                            catch (Exception ex)
                            {
                                //log
                                //��ϸ�ϴ�ʧ��   �������ϴ�ֹͣ  ���鴦����ʼ
                            //    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** ��סԺ�в�ҩ�ϴ��� begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** �в�ҩ�ϴ� end ***",
                                //DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                continue;
                            }

                            for (int j = 0; j <= rows.Length - 1; j++)
                            {
                                if (string.IsNullOrEmpty(_hzxb))
                                {
                                    _hzxb = Convert.ToString(Convertor.IsNull(rows[i]["�Ա�"], ""));//�Ա�
                                }
                                if (string.IsNullOrEmpty(_hznl))
                                {
                                    _hznl = Convert.ToString(Convertor.IsNull(rows[i]["����"], ""));//����
                                }
                                if (string.IsNullOrEmpty(_jtdz))
                                {
                                    _jtdz = Convert.ToString(Convertor.IsNull(rows[i]["��ͥ��ַ"], ""));//��ͥ��ַ
                                }
                                if (string.IsNullOrEmpty(_lxfs))
                                {
                                    _lxfs = Convert.ToString(Convertor.IsNull(rows[i]["��ϵ��ʽ"], ""));//��ϵ��ʽ
                                }
                                if (string.IsNullOrEmpty(wardCode))
                                {
                                    wardCode = Convert.ToString(Convertor.IsNull(rows[i]["��ҩ����"], ""));//��ҩ���ҡ����޸����ۡ�
                                }
                                if (string.IsNullOrEmpty(bedNo))
                                {
                                    bedNo = Convert.ToString(Convertor.IsNull(rows[i]["����"], ""));//����
                                }

                                //if (string.IsNullOrEmpty(fre))
                                //{
                                //    fre = Convert.ToString(Convertor.IsNull(rows[j]["Ƶ��"], ""));
                                //    if (!string.IsNullOrEmpty(fre))
                                //    {
                                //        _ts = ClsZcyJy.ClsJyInterFace.GetFreqExecNum(dtFre, fre);

                                //        if (_ts.Equals("-1"))
                                //        {
                                //            return;
                                //        }
                                //    }
                                //}

                                if (string.IsNullOrEmpty(_yyfs))
                                {
                                    _yyfs = Convert.ToString(Convertor.IsNull(rows[i]["�÷�"], "")); ;//��ҩ��ʽ���÷���
                                }
                                if (string.IsNullOrEmpty(doc))
                                {
                                    doc = Convertor.IsNull(rows[j]["ҽ��"], "");//����ҽ��
                                }

                                decimal ypsl = Convert.ToDecimal(rows[j]["ypsl"]);
                                ////int js = Convert.ToInt32(rows[j]["����"]);
                                ////string kcdw = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.fun_yp_ypdw(zxdw) from yf_kcmx where cjid=" + rows[j]["cjid"] + " and deptid=" + InstanceForm.BCurrentDept.DeptId + ""), "");
                                ////int dwbl_cfmx = Convert.ToInt32(rows[j]["unitrate"]);//������ϸ��λ����
                                ////decimal lsj_cfmx = Convert.ToDecimal(rows[j]["����"]);//������ϸ���ۼ�
                                ////decimal pfj_cfmx = Convert.ToDecimal(rows[j]["������"]);//������ϸ������
                                ////decimal sl = Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc / js);//������ϸ����
                                ////decimal pfje = Math.Round(Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc * pfj_cfmx), 4);    //�������=������ϸ����*������ϸ������
                                ////decimal lsje = Math.Round(Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc * lsj_cfmx), 4);//���۽��=������ϸ����*������ϸ���ۼ�
                                //decimal jhj_kc = Convert.ToDecimal(rows[j]["jhj2"]);//�ⷿ��λ����
                                ////decimal jhj_cfmx = Convert.ToDecimal(jhj_kc * dwbl_kc / dwbl_cfmx);//������ϸ�н�����
                                //decimal jhje = Math.Round(Convert.ToDecimal(jhj_kc * ypsl), 4);//�������=��浥λ����*��浥λ����

                                ////string ypph = rows[j]["ypph2"].ToString();
                                ////string ypxq = rows[j]["ypxq2"].ToString();
                                ////string yppch = rows[j]["yppch2"].ToString();
                                ////Guid kcid = new Guid(rows[j]["kcid2"].ToString());
                                ////Guid tyid = new Guid(Convertor.IsNull(rows[j]["cz_id"], Guid.Empty.ToString()));

                                string cjid = rows[j]["cjid"].ToString();
                                string spm = rows[j]["Ʒ��"].ToString();
                                string gg = rows[j]["���"].ToString();
                                string sccj = rows[j]["����"].ToString();

                                int _yl = Convert.ToInt32(rows[j]["����"]);
                                int _js = Convert.ToInt32(rows[j]["����"]);
                                string sl = ((int)(_yl * _js)).ToString();//����
                                string yl = rows[j]["����"].ToString();//����
                                string js = rows[j]["����"].ToString();//����
                                string jl = rows[j]["����"].ToString();
                                string jldw = rows[j]["������λ"].ToString();
                                string yldw = rows[j]["��λ"].ToString(); //Convert.ToInt32(rows[j]["��λ"]);
                                string jldwsl = rows[j]["������λ����"].ToString(); //Convert.ToInt32(rows[j]["��λ"]);
                                decimal _jldwsl = decimal.Parse(rows[j]["������λ����"].ToString()); //Convert.ToInt32(rows[j]["��λ"]);

                                decimal lsdj = Convert.ToDecimal(rows[j]["����"].ToString());
                                decimal lsje = Convert.ToDecimal(rows[j]["���"].ToString());
                                string tsyf = Convertor.IsNull(rows[j]["tsyf"], "");

                                //------------------add by wangzhi at 2014-08-01 ��������ͬ�Ĵ���,(д��ҩ��ϸ�ĵ�λ���浥λһ��)------------------  
                                //js = 1;  //ǿ�Ƽ���Ϊ1
                                //sl = ypsl; //����ֱ��ȡ��ֽ��
                                //decimal pfj_cfmxdj = Convert.ToDecimal(rows[j]["������"]);//������ϸ������
                                decimal pfj_cfmx = Convert.ToDecimal(rows[j]["������"]);//������ϸ������
                                int dwbl_cfmx = Convert.ToInt32(rows[j]["unitrate"]);//������ϸ��λ����
                                int dwbl_kc = Convert.ToInt32(rows[j]["dwbl"]);//��浥λ����
                                pfj_cfmx = Convert.ToDecimal(rows[j]["������"]) * dwbl_cfmx / dwbl_kc; //ʹ��������ʹ�õĵ�λ���������ʹ�õĵ�λ����һ��

                                decimal pfje = Convert.ToDecimal(rows[j]["�������"]);//������ϸ������
                                //lsj_cfmx = Convert.ToDecimal(rows[j]["����"]) * dwbl_cfmx / dwbl_kc;   //ͬ��
                                //------------------end modify by wangzhi at 2014-08-01------------------


                                string czid = rows[j]["cz_id"].ToString().Trim();
                                string zyid = rows[j]["zy_id"].ToString().Trim();

                                sumjhje += lsje;

                                bool bMedSuc = false;
                                //������ǳ�������
                                if (string.IsNullOrEmpty(czid))
                                {
                                    try
                                    {
                                        //jldwsl, yl, jldwsl,pfje����
                                        DataRow[] drCzs = tb.Select("cz_id='" + zyid + "'");
                                        if (drCzs.Length > 0)
                                        {
                                            for (int m = 0; m < drCzs.Length; m++)
                                            {
                                                int _ylcz = Convert.ToInt32(drCzs[m]["����"]);
                                                decimal _jldwslcz = Convert.ToDecimal(drCzs[m]["������λ����"].ToString());
                                                decimal lsjecz = Convert.ToDecimal(drCzs[m]["���"]);

                                                _yl += _ylcz;
                                                _jldwsl += _jldwslcz;
                                                lsje += lsjecz;
                                            }
                                        }

                                        //����������  ����ҩƷ������Ϊ0
                                        if (_jldwsl == 0)
                                            continue;

                                        //ѭ���ϴ���ϸ
                                        //bMedSuc = ClsZcyJy.ClsJyInterFace.His_DrugInfo(_presc_no, hosCode, hosName, cjid, spm, gg, sccj, jldwsl, yl, jldwsl, lsdj, lsje, jldw, tsyf, out strMsg);
                                       // bMedSuc = ClsZcyJy.ClsJyInterFace.His_DrugInfo(_presc_no, hosCode, hosName, cjid, spm, gg, sccj,
                                       //     _jldwsl.ToString("0.0"), _yl.ToString(), _jldwsl.ToString("0.0"), lsdj.ToString("0.00"), lsje.ToString("0.00"), jldw, tsyf, out strMsg);

                                    }
                                    catch (Exception ex)
                                    {
                                        //log
                                        //��ϸ�ϴ�ʧ��   �������ϴ�ֹͣ  ���鴦����ʼ
//                                        //TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** ��סԺ�в�ҩ�ϴ��� begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** �в�ҩ�ϴ� end ***",
//                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                        break;
                                    }
                                }
                                else
                                {
                                    continue;
                                }

                                if (bMedSuc)
                                {
                                    NN = NN + 1;
                                }
                                else
                                {
                                    //log
                                    //��ϸ�ϴ�ʧ��   �������ϴ�ֹͣ  ���鴦����ʼ
//                                    //TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** ��סԺ�в�ҩ�ϴ��� begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** �в�ҩ�ϴ� end ***",
                                                                                                        //DateTime.Now.ToString(),_presc_no,_inpatient_id,strMsg) }, false);

                                    break;
                                }
                            }

                            string ret = "";
                            if (NN > 0)
                            {
                                ////
                                //bThisPresSuc = ClsZcyJy.ClsJyInterFace.His_UserRecipe(hosCode, hosName, _hzxm, _hzxb, _hznl, _jtdz, _lxfs, _presc_no, "", _blh,
                                //     bedNo, _ts, _fs, _yyfs, _jyfs, _allWgt, packvolume, dtScTime, doc, dtScTime.ToString("yyyy-MM-dd HH:mm:ss"), buyUnit, wardCode, sumjhje.ToString("0.00"), dtScTime.ToString("yyyy-MM-dd HH:mm:ss"), "", "", out ret);

                                if (!bThisPresSuc)
                                {
                                    //log
                                    //������Ϣ�ϴ�����  �������ϴ�ֹͣ,    �������鴦����ʼ
                                    //TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** ��סԺ�в�ҩ�ϴ��� begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** �в�ҩ�ϴ� end ***",
//                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ret) }, false);

                                    continue;
                                }
                            }

                            //�ӿڴ���ɹ�
                            if (bThisPresSuc || NN == 0)
                            {
                                //string _presc_no = Convert.ToString(tbcf.Rows[i]["������"]); //������ 
                                //decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���"], "0")); //���
                                //int _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"], "0")); //����
                                //Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["inpatient_id"], Guid.Empty.ToString()));//����ID
                                //string _inpatient_no = Convert.ToString(tbcf.Rows[i]["סԺ��"]);//סԺ��
                                //string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//����
                                //int _dept_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["dept_id"], "0"));//����
                                //int _doc_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["doc_id"], "-1"));//ҽ��
                                //Guid _fyid = Guid.Empty;//��ҩID

                                //DateTime _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);


                                InstanceForm.BDatabase.BeginTransaction();
                                try
                                {
                                    //���£�CHARGE_BIT,FY_BIT,FY_DATE,FY_USER
                                    string strCySql = string.Format(@"update ZY_FEE_SPECI set CHARGE_BIT=1,CHARGE_DATE='{2}',CHARGE_USER='{3}',FY_BIT=1,FY_DATE='{2}',FY_USER='{3}'
                                                            where PRESC_NO='{0}' and inpatient_id='{1}' ", _presc_no, _inpatient_id, _sDate, InstanceForm.BCurrentUser.EmployeeId);

                                    InstanceForm.BDatabase.DoCommand(strCySql);

                                    //���ϴ����������ϸ
                                    if (NN > 0)
                                    {

                                        strCySql = string.Format(@"update yf_zcyfy_sc set del_bit=1 where JSSJH='{0}' ", _presc_no);

                                        InstanceForm.BDatabase.DoCommand(strCySql);

                                        strCySql = string.Format(@"insert into yf_zcyfy_sc(
                                                        id,jgbm,cflx,JSSJH,FPH,
                                                        zje,cfts,CFXH,PATID,PATIENTNO,HZXM,YSDM,KSDM,
                                                        SKRQ,SKY,FYRQ,FYR,PYR,PYCKH,FYCKH,DEPTID,JZCFBZ,TFBZ,YWLX,wkdz)  
                                                        values('{0}','{1}','{2}','{3}','{4}',
                                                        '{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',
                                                        '{13}','{14}','{15}','{16}','{17}',
                                                        '{18}','{19}','{20}','{21}','{22}','{23}','{24}')  ",
                                                            Guid.NewGuid(), InstanceForm._menuTag.Jgbm, "1", _presc_no, "01",
                                                            _sumzje, _cfts, Guid.Empty, _inpatient_id, _inpatient_no, _hzxm, _doc_id, _dept_id,
                                                            _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.EmployeeId,
                                                            "", "", InstanceForm.BCurrentDept.DeptId, "1", 0, _menuTag.FunctionTag, PubStaticFun.GetMacAddress());

                                        InstanceForm.BDatabase.DoCommand(strCySql);
                                    }

                                    InstanceForm.BDatabase.CommitTransaction();
                                }
                                catch (Exception ex)
                                {
                                    InstanceForm.BDatabase.RollbackTransaction();
                                    //log
//                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** ��סԺ�в�ҩ�ϴ��� begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** �в�ҩ�ϴ� end ***",
//                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);
                                    throw ex;
                                }
                            }
                            else
                            {
                                throw new Exception("�ϴ�ʧ��");
                            }
                        }
                    }

                    #region ������������Ϊ�ѷ�ҩ״̬
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tb;
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        if (tb.Rows[i]["��ҩ"].ToString().Trim() == "��")
                        {
                            tb.Rows[i]["��ҩ"] = "��";
                            tb.Rows[i]["��ҩ����"] = _sDate.ToString();
                            tb.Rows[i]["��ҩԱ"] = InstanceForm.BCurrentUser.Name;
                            //��ҩ����ʾ��ҩ������  lidan add 2013-07-01
                            tb.Rows[i]["��ҩԱ"] = cmbpyr.Text;
                        }
                    }
                    this.myDataGrid1.DataSource = xcset1.TsDataTable;
                    butfy.Tag = _sDate.ToString();
                    #endregion

                    #region ��ʾ�ɹ��Լ���ӡ

                    MessageBox.Show("��ҩ�ɹ���");

                    string cxfs = ApiFunction.GetIniString("סԺ������ҩĬ�ϴ�ӡ��ʽ", "��ӡ��ʽ", Constant.ApplicationDirectory + "//ClientWindow.ini");

                    if (cxfs != "Ĭ�ϲ���ӡ")
                    {
                        if (MessageBox.Show("��ҩ�ɹ�,��Ҫ��ӡ��", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            if (rdomx.Checked == true)
                                this.butprint_Click(null, null);
                            else
                            {
                                computeTld(_sDate.ToString());
                                this.butprinthz_Click(null, null);
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�ϴ�����" + ex.Message, "��ʾ");
            }
        }

        private void butfy_Click(object sender, System.EventArgs e)
        {
            string validSql = string.Format(@"select count(1) as num from V_JC_YP_ZCYSC where dept_id='{0}'", InstanceForm.BCurrentDept.DeptId);

            int iRet = int.Parse(InstanceForm.BDatabase.GetDataResult(validSql).ToString());

            //ά�������߿��Ҳ�ʹ�øò˵����ܷ�ҩ
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_ZCY" && iRet > 0)
            {
                DoZcyJyFy();
            }
            else
            {
                //His���Ŀ�淢ҩ

                if ((!bpcgl)) //���������ι���
                {
                    #region ���������ι�����
                    if (Convertor.IsNull(cmbpyr.SelectedValue, "") == "")
                    {
                        MessageBox.Show("��ѡ����ҩ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    DataTable tbhz = (DataTable)this.myDataGrid2.DataSource;

                    int NN = 0;
                    int YY = 0;

                    //���鴦��
                    //string[] GroupbyField ={ "סԺ��", "����", "inpatient_id", "������", "dept_id", "doc_id", "����" };
                    //string[] ComputeField ={ "���" };
                    //string[] CField ={ "sum" };
                    //TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                   // xcset.TsDataTable = tb;

                    //Modify by jchl �в�ҩ��ҩ�޸�
                    //DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "��ҩ='��' and ypsl<>0");
                   // DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "��ҩ='��' and ypsl<>0 ");

                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                        return;
                    }

                    //if (tbhz.Rows.Count==0) {MessageBox.Show("���ܼ���ʱ������������ѡ�񴦷��ٷ�ҩ");return;}
                    //���ر���
                    int _err_code = -1;
                    string _err_text = "";

                    //ʱ��
                    string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                    //��ҩ��
                    int _pyr = Convert.ToInt32(cmbpyr.SelectedValue);
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                        _pyr = -999;


                    //�жϳ�Ժ��ҩ����
                    string _cydy = new SystemCfg(8003).Config.Trim();

                    try
                    {
                        this.Cursor = PubStaticFun.WaitCursor();
                        InstanceForm.BDatabase.BeginTransaction();

                        #region ���뷢ҩͷ�� ���뷢ҩ��ϸ
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            //������ 
                            //string _presc_no = Convert.ToString(tbcf.Rows[i]["������"]);
                            ////���
                            //decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���"], "0"));
                            ////����
                            //int _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"], "0"));
                            ////����ID
                            //Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["inpatient_id"], Guid.Empty.ToString()));
                            ////סԺ��
                            //string _inpatient_no = Convert.ToString(tbcf.Rows[i]["סԺ��"]);
                            ////����
                            //string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));
                            ////����
                            //int _dept_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["dept_id"], "0"));
                            ////ҽ��
                            //int _doc_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["doc_id"], "-1"));
                            //��ҩID
                            Guid _fyid = Guid.Empty;
                            int mm = 1;
                            #region ������ҩ
                            try
                            {
                                //DataRow row_hlyy = tbcf.Rows[i];
                                if (cfghlyytype != "0" && cfghlyytype != "")
                                {
                                    switch (cfghlyytype)
                                    {
                                        case "1":
                                            #region ��ͨ������ҩסԺ  ncq  2014-03-24
                                            //object objbrxxid = InstanceForm.BDatabase.GetDataResult("select PATIENT_ID from ZY_inpatient where inpatient_id='" + row_hlyy["inpatient_id"].ToString() + "' ");
                                            string strbrxxid = objbrxxid != null ? objbrxxid.ToString() : "";
                                            if (strbrxxid != "")
                                            {
                                                //YY_BRXX brxx = new YY_BRXX(new Guid(strbrxxid), InstanceForm.BDatabase);
                                                string birth = brxx.Csrq;
                                                string patname = brxx.Brxm;
                                                int gh = InstanceForm.BCurrentUser.EmployeeId; //��ǰ�û�id
                                                string cfrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");//��������
                                                string employeename = InstanceForm.BCurrentUser.Name;//�û�����
                                                int ksdm = InstanceForm.BCurrentDept.DeptId;//����id
                                                string ksmc = InstanceForm.BCurrentDept.DeptName;//��������
                                                //string zyh = Convertor.IsNull(row_hlyy["סԺ��"], "").ToString();//סԺ��
                                                //string brxmhlyy = Convertor.IsNull(row_hlyy["����"], "").ToString();//��������
                                                string xb = brxx.Xb;//tbsel.Rows[0]["�Ա�"].ToString();//�Ա�
                                                if (xb == "1")
                                                {
                                                    xb = "��";
                                                }
                                                else
                                                {
                                                    if (xb == "2")
                                                        xb = "Ů";
                                                    else
                                                        xb = "����";
                                                }

                                                //string icd = Convertor.IsNull(row_hlyy["���"], "").ToString(); //tbsel.Rows[0]["���"].ToString();//���

                                                int hfresult = 0;
                                                hlyyjk.RegisterServer_fun(null);//���ĵ�
                                                hlyyjk.Refresh();
                                                //TrasenFrame.Classes.TsSet tsset1 = new TsSet();
                                                tsset1.TsDataTable = tb.Copy();
                                                DataTable tb1 = tsset1.FilterTable("������='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and ����='" + _cfts.ToString() + "' and ����='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                                                //StringBuilder sss = new StringBuilder(ts_zy_hlyy.GetXml(gh, cfrq, employeename, ksdm, ksmc, zyh, birth, brxmhlyy, xb, tb1, icd));
                                                hfresult = hlyyjk.DrugAnalysis(sss, 0);//סԺ-0 ����-1 

                                                if (hfresult >= 2)
                                                {
                                                    if (MessageBox.Show("����!�����п��ܴ��ڲ��������ҩ,��Ҫ������ҩ��?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                                        return;
                                                    hfresult = hlyyjk.SaveDrug(sss, 1);
                                                }
                                                hlyyjk.SaveXml(sss);
                                            }
                                            #endregion
                                            break;
                                        default:
                                            MessageBox.Show(cfghlyytype + "�ú�����ҩ�ӿڲ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("PASS����!ԭ��:" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //return;
                            }
                            #endregion

                            //����Ǵ�����ҩ�Ͳ�ʵ�ʷ�ҩ
                            if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_cf_jy")
                            {
                                //���뷢ҩͷ��
                                ZY_FY.SaveFy("", Convert.ToDecimal(_presc_no), 0, _sumzje, _cfts, Guid.Empty, _inpatient_id, _inpatient_no,
                                            _hzxm, _doc_id, _dept_id, _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate,
                                            InstanceForm.BCurrentUser.EmployeeId, _pyr, "", "", InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, out _fyid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                                if (_fyid == Guid.Empty || _err_code < 0)
                                    throw new Exception(_err_text);
                                DataRow[] rows = tb.Select("������='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and ����='" + _cfts.ToString() + "' and ����='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                                //���뷢ҩ��ϸ�� 
                                for (int j = 0; j <= rows.Length - 1; j++)
                                {
                                    if (Convert.ToInt16(Convertor.IsNull(rows[j]["discharge_bit"], "0")) == 0 && rdCydy.Checked == true && _cydy == "1")
                                    {
                                        throw new Exception("�Բ���,��Ժ��ҩ�Ĵ��������ڲ��˽����Ժ���ܷ�ҩ");
                                    }
                                    ZY_FY.SaveFymx(_fyid, 0, new Guid(rows[j]["zy_id"].ToString()), Convert.ToInt32(rows[j]["cjid"]), rows[j]["����"].ToString(),
                                        rows[j]["��Ʒ��"].ToString(), rows[j]["��Ʒ��"].ToString(), rows[j]["���"].ToString(), rows[j]["����"].ToString(),
                                        rows[j]["��λ"].ToString(), Convert.ToDecimal(rows[j]["unitrate"]), Convert.ToDecimal(rows[j]["����"]),
                                        Convert.ToInt32(rows[j]["����"]), Convert.ToDecimal(rows[j]["������"]), Convert.ToDecimal(rows[j]["�������"]),
                                        Convert.ToDecimal(rows[j]["����"]), Convert.ToDecimal(rows[j]["���"]), InstanceForm.BCurrentDept.DeptId,
                                        Guid.Empty, "", out _err_code, out _err_text, InstanceForm.BDatabase,
                                        0, 0, "", "", Guid.Empty, false);
                                    if (_fyid == Guid.Empty || _err_code < 0)
                                        throw new Exception(_err_text);
                                    NN = NN + 1;
                                }
                            }
                        }
                        #endregion

                        //û�мǷѵļ�¼
                        DataRow[] rows1 = tb.Select("��ҩ='��' and cjid<>'' and charge_bit='0'");
                        //�ѼǷѵļ�¼
                        DataRow[] rows2 = tb.Select("��ҩ='��' and cjid<>'' and charge_bit='1'");

                        #region ���εĴ��룬��ʱ����

                        ////////////////for (int i=0;i<=rows1.Length-1;i++)
                        ////////////////{
                        ////////////////    long _Zyid=Convert.ToInt64(rows1[i]["zy_id"]);
                        ////////////////    ZY_FY.UpdateFeeChargeFy(rdols.Checked,0,_sDate,InstanceForm.BCurrentUser.EmployeeId,_pyr,0,_sDate,InstanceForm.BCurrentUser.EmployeeId,_Zyid);
                        ////////////////    YY=YY+1;
                        ////////////////}


                        ////////////////for(int i=0;i<=rows2.Length-1;i++)
                        ////////////////{
                        ////////////////    long _Zyid=Convert.ToInt64(rows2[i]["zy_id"]);
                        ////////////////    ZY_FY.UpdateFeeChargeFy(rdols.Checked, 0,_sDate,InstanceForm.BCurrentUser.EmployeeId,_pyr,1,_sDate,InstanceForm.BCurrentUser.EmployeeId,_Zyid);
                        ////////////////    YY=YY+1;
                        ////////////////}
                        #endregion

                        #region ����û�мǷѼ�¼
                        string ssql = "";
                        //ʱ���
                        decimal _execId = 0;
                        ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                        _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));
                        //����û�мǷѵļ�¼
                        for (int i = 0; i <= rows1.Length - 1; i++)
                        {
                            ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows1[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",null,1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        if (rows1.Length > 0)
                        {
                            int iii = ZY_FY.UpdateFeeChargeFy(rdols.Checked, Guid.Empty, _sDate, InstanceForm.BCurrentUser.EmployeeId, _pyr, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                            if (rows1.Length != iii)
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!��������ˢ�����ݺ�����!");
                        }
                        #endregion

                        #region �����Ѿ��Ƿѵļ�¼
                        //ʱ���
                        ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                        _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                        //�����ѼǷѵļ�¼
                        for (int i = 0; i <= rows2.Length - 1; i++)
                        {
                            ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows2[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",null,1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        if (rows2.Length > 0)
                        {
                            int iii = ZY_FY.UpdateFeeChargeFy(rdols.Checked, Guid.Empty, _sDate, InstanceForm.BCurrentUser.EmployeeId, _pyr, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                            if (rows2.Length != iii)
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!��������ˢ�����ݺ�����!");
                        }
                        #endregion

                        //�ύ����
                        InstanceForm.BDatabase.CommitTransaction();

                        //������������Ϊ�ѷ�ҩ״̬
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = tb;
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            if (tb.Rows[i]["��ҩ"].ToString().Trim() == "��")
                            {
                                tb.Rows[i]["��ҩ"] = "��";
                                tb.Rows[i]["��ҩ����"] = _sDate;
                                tb.Rows[i]["��ҩԱ"] = InstanceForm.BCurrentUser.Name;
                                //��ҩ����ʾ��ҩ������  lidan add 2013-07-01
                                tb.Rows[i]["��ҩԱ"] = cmbpyr.Text;
                            }
                        }
                        this.myDataGrid1.DataSource = xcset1.TsDataTable;
                        butfy.Tag = _sDate;

                        //��ʾ�ɹ�

                        string cxfs = ApiFunction.GetIniString("סԺ������ҩĬ�ϴ�ӡ��ʽ", "��ӡ��ʽ", Constant.ApplicationDirectory + "//ClientWindow.ini");

                        if (cxfs != "Ĭ�ϲ���ӡ")
                        {
                            if (MessageBox.Show("��ҩ�ɹ�,��Ҫ��ӡ��", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                if (rdomx.Checked == true)
                                    this.butprint_Click(sender, e);
                                else
                                {
                                    computeTld(_sDate);
                                    this.butprinthz_Click(sender, e);
                                }
                            }
                        }

                    }
                    catch (System.Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Arrow;
                    }
                    #endregion
                }
                else//�������ι���
                {
                    if (Convertor.IsNull(cmbpyr.SelectedValue, "") == "")
                    {
                        MessageBox.Show("��ѡ����ҩ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    DataTable tbhz = (DataTable)this.myDataGrid2.DataSource;
                    int NN = 0;
                    int YY = 0;
                    //���鴦��
                    string[] GroupbyField ={ "סԺ��", "����", "inpatient_id", "������", "dept_id", "doc_id", "����" };
                    string[] ComputeField ={ "���" };
                    string[] CField ={ "sum" };
                    TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                    xcset.TsDataTable = tb;

                    //Modify by jchl �в�ҩ��ҩ�޸�
                    //DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "��ҩ='��' and ypsl<>0 ");
                    DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "��ҩ='��' and ypsl<>0 ");

                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                        return;
                    }

                    int _err_code = -1;
                    string _err_text = "";
                    string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//ʱ��
                    int _pyr = Convert.ToInt32(cmbpyr.SelectedValue); //��ҩ��
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                        _pyr = -999;
                    string _cydy = new SystemCfg(8003).Config.Trim(); //�жϳ�Ժ��ҩ����


                    #region ���η���

                    #region �����
                    if (!tb.Columns.Contains("YPPCH2"))
                    {
                        tb.Columns.Add(new DataColumn("YPPCH2", Type.GetType("System.String")));
                    }
                    if (!tb.Columns.Contains("YPPH2"))
                    {
                        tb.Columns.Add(new DataColumn("YPPH2", Type.GetType("System.String")));
                    }
                    if (!tb.Columns.Contains("YPXQ2"))
                    {
                        tb.Columns.Add(new DataColumn("YPXQ2", Type.GetType("System.String")));
                    }
                    if (!tb.Columns.Contains("KCID2"))
                    {
                        tb.Columns.Add(new DataColumn("KCID2", Type.GetType("System.String")));
                    }
                    if (!tb.Columns.Contains("JHJ2"))
                    {
                        tb.Columns.Add(new DataColumn("JHJ2", Type.GetType("System.Decimal")));
                    }
                    if (!tb.Columns.Contains("JHJE2"))
                    {
                        tb.Columns.Add(new DataColumn("JHJE2", Type.GetType("System.Decimal")));
                    }
                    if (!tb.Columns.Contains("KDSl"))
                    {
                        tb.Columns.Add(new DataColumn("KDSl", Type.GetType("System.Decimal")));//�ɵ�����
                    }
                    if (!tb.Columns.Contains("BDELETE2"))
                    {
                        tb.Columns.Add(new DataColumn("BDELETE2", Type.GetType("System.Boolean")));//ɾ����־
                    }

                    #endregion

                    DataTable tbpcmx = tb.Clone();//�ѷ�������
                    DataTable tbpcmx_zs_wfp = tb.Clone();//δ�������������
                    DataTable tbpcmx_fs = tb.Clone();//�ѷ��为��
                    DataTable tbkcph = InstanceForm.BDatabase.GetDataTable(@"select ID kcid,yppch,CJID,YPPH,YPXQ,JHJ,KCL,0 
                as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and kcl>0 and bdelete = 0 ");
                    try
                    {
                        DataTable tb_temp = tb.Copy();

                        //int it = tbcf.Rows.Count;
                        //��һ�������������������0��ҩƷ
                        DataRow[] rows_mx = tb_temp.Select("��ҩ='��' and ypsl>0 ", "ypsl desc");
                        for (int i = 0; i < rows_mx.Length; i++) //������ϸ��
                        {
                            #region
                            DataRow row = rows_mx[i];
                            DataRow[] rows_kcph;
                            if (pcglfs == "0")
                                rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["cjid"].ToString() + "", "djsj asc,yppch asc");
                            else
                                rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 cjid=" + row["cjid"].ToString() + "", "ypxq asc");

                            //��λ�����Ƚ�
                            if (rows_kcph.Length > 0)
                            {
                                int dwbl_kc = Convert.ToInt32(rows_kcph[0]["dwbl"]);
                                int dwbl_mx = Convert.ToInt32(row["dwbl"]);
                                if (dwbl_kc != dwbl_mx)
                                {
                                    throw new Exception("��λ���������仯,��ˢ�����ݺ����ԣ�");
                                }
                            }

                            decimal sysl = Convert.ToDecimal(row["ypsl"]);//ʣ������
                            for (int j = 0; j < rows_kcph.Length; j++)//���ſ����
                            {
                                DataRow row1 = rows_kcph[j];
                                decimal cksl = 0;//���γ�����
                                decimal kcl = Convert.ToDecimal(row1["kcl"]);//���ο����
                                if (kcl == 0)
                                    continue;
                                if (sysl == 0)
                                    break;
                                if (kcl > sysl)//���������ʣ������
                                {
                                    cksl = sysl;
                                    sysl = 0;
                                }
                                else//�����С��ʣ������
                                {
                                    cksl = kcl;
                                    sysl = sysl - kcl;
                                }
                                //�������������Ϣ
                                DataRow newrow = tb_temp.NewRow();
                                newrow = row;
                                newrow["yppch2"] = row1["yppch"];
                                newrow["ypph2"] = row1["ypph"];
                                newrow["ypxq2"] = row1["ypxq"];
                                newrow["kcid2"] = row1["kcid"];
                                decimal jhj = Math.Round(Convert.ToDecimal(row1["jhj"]) / Convert.ToInt32(row1["dwbl"]), 4);
                                newrow["jhj2"] = jhj;
                                newrow["jhje2"] = Math.Round(jhj * cksl, 3);
                                newrow["ypsl"] = cksl;
                                decimal pfj = Convert.ToDecimal(row["������"]);
                                newrow["������"] = pfj;
                                newrow["�������"] = Convert.ToDecimal(pfj * cksl);
                                newrow["KCID2"] = row1["kcid"];
                                newrow["KDSL"] = 0;//�ɵ�����
                                newrow["bdelete2"] = row1["bdelete"];//���ñ�־
                                tbpcmx.ImportRow(newrow);
                                row1["kcl"] = kcl - cksl;//�����ο�����
                                if (sysl == 0)//���ʣ����������0 ������ǰ���ο��ѭ��
                                {
                                    break;
                                }
                            }
                            #endregion

                            //���ʣ��������Ȼ>0 
                            #region δ���������
                            if (sysl > 0)
                            {
                                row["ypsl"] = sysl;
                                if (Convert.ToDecimal(row["ypsl"]) > 0)
                                {
                                    DataRow row_zs = tb_temp.NewRow();
                                    row_zs = row;
                                    tbpcmx_zs_wfp.ImportRow(row);
                                }
                            }
                            #endregion
                        }

                        //�ڶ���,�����������С�����ҩƷ(��ȥ�Ѿ��������ŵ�����ƥ�䣬ƥ�䲻������һ������)
                        rows_mx = tb_temp.Select("��ҩ='��' and ypsl<0", "ypsl desc");
                        for (int i = 0; i < rows_mx.Length; i++)
                        {
                            DataRow row = rows_mx[i];
                            int dwbl_mx = Convert.ToInt32(row["dwbl"]);
                            bool bFind = false;//�Ƿ��ҵ������ѷ����
                            #region ���ηֽ�
                            decimal ypsl = Convert.ToDecimal(row["ypsl"]);
                            string kcid = Convertor.IsNull(row["kcid"], new Guid().ToString());
                            string cz_id = Convertor.IsNull(row["cz_id"], new Guid().ToString());
                            DataRow[] rows_kcph = new DataRow[] { };
                            //�ڷֽ��˵���������ԭ��¼
                            DataRow[] rows_yjl = tbpcmx.Select("zy_id='" + cz_id + "'", "");
                            if (rows_yjl.Length > 0)
                            {
                                //rows_kcph = tbkcph.Select( "kcid='" + row["KCID2"].ToString() + "'" , "" );
                                rows_kcph = rows_yjl; //2015-05-07 ncq //����˵�� By Tany 2015-05-07 ������ԭ��¼���е���ģ���������ı���Ҫ���Ÿ�
                                bFind = true;
                            }
                            //�Ҳ������˵��п��ļ�¼�ϣ��������û�п�棬����һ������ļ�¼
                            if (rows_kcph.Length == 0)
                            {
                                #region
                                if (pcglfs == "0")
                                    rows_kcph = tbkcph.Select("cjid=" + row["cjid"].ToString() + "", "djsj asc");
                                else
                                    rows_kcph = tbkcph.Select("cjid=" + row["cjid"].ToString() + "", "ypxq asc");
                                if (rows_kcph.Length == 0)
                                {
                                    if (pcglfs == "0")
                                    {
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by djsj desc,yppch desc ").Select();
                                    }
                                    else
                                    {
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by ypxq desc ").Select();
                                    }
                                }
                                #endregion
                            }
                            if (rows_kcph.Length <= 0)
                            {
                                throw new Exception("�Ҳ�������¼��");
                            }
                            if (bFind)
                            {
                                //���ҵ��ѷ���������¼
                                DataRow row1 = rows_kcph[0];
                                int dwbl_zs = Convert.ToInt32(row1["dwbl"]);
                                if (dwbl_zs != dwbl_mx)
                                { throw new Exception("��λ��������������ˢ�����ݺ�����"); }
                                DataRow newrow = tb_temp.NewRow();
                                newrow = row;
                                newrow["yppch2"] = row1["yppch2"];//Modify By Tany 2015-05-07 ��Ϊ����Դ���ԭ��¼����������Ҫ��2��β��
                                newrow["ypph2"] = row1["ypph2"];//Modify By Tany 2015-05-07 ��Ϊ����Դ���ԭ��¼����������Ҫ��2��β��
                                newrow["ypxq2"] = row1["ypxq2"];//Modify By Tany 2015-05-07 ��Ϊ����Դ���ԭ��¼����������Ҫ��2��β��
                                newrow["kcid2"] = row1["kcid2"];//Modify By Tany 2015-05-07 ��Ϊ����Դ���ԭ��¼����������Ҫ��2��β��
                                //decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj"]) * dwbl_zs / dwbl_mx);
                                decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj2"]) * dwbl_zs / dwbl_mx);//2015-05-07 ncq 
                                newrow["jhj2"] = jhj;
                                newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                                newrow["ypsl"] = ypsl;
                                decimal pfj = Convert.ToDecimal(row["������"]);
                                newrow["������"] = pfj;
                                newrow["�������"] = Math.Round(pfj * ypsl, 2);
                                newrow["KDSL"] = ypsl * (-1);//�ɵ�����
                                newrow["bdelete2"] = row1["bdelete2"];//���ñ�־ //Modify By Tany 2015-05-07 ��Ϊ����Դ���ԭ��¼����������Ҫ��2��β��
                                tbpcmx_fs.ImportRow(newrow);
                            }
                            else
                            {

                                //�������������Ϣ
                                int dwbl_kc = Convert.ToInt32(rows_kcph[0]["dwbl"]);
                                if (dwbl_mx != dwbl_kc)
                                {
                                    throw new Exception("��λ���������仯����ˢ�����ݺ�����");
                                }
                                DataRow row1 = rows_kcph[0];
                                DataRow newrow = tb_temp.NewRow();
                                newrow = row;
                                newrow["yppch2"] = row1["yppch"];
                                newrow["ypph2"] = row1["ypph"];
                                newrow["ypxq2"] = row1["ypxq"];
                                newrow["kcid2"] = row1["kcid"];
                                //������ű��д����δ����Ľ���
                                decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj"]) / dwbl_mx);
                                newrow["jhj2"] = jhj;
                                newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                                newrow["ypsl"] = ypsl;
                                decimal pfj = Convert.ToDecimal(row["������"]);
                                newrow["������"] = pfj;
                                newrow["�������"] = Math.Round(pfj * ypsl, 2);
                                newrow["KDSL"] = ypsl * (-1);//�ɵ�����
                                newrow["bdelete2"] = row1["bdelete"];//���ñ�־
                                tbpcmx_fs.ImportRow(newrow);
                                //�����ο�����
                                row1["kcl"] = Convert.ToDecimal(row1["kcl"]) - ypsl;
                            }

                            #endregion
                        }

                        //������,����δ����Ĵ������ҩƷ(ȥ�ѷ���ĸ������е���)
                        foreach (DataRow row_zs in tbpcmx_zs_wfp.Rows)
                        {
                            #region ���ηֽ�
                            decimal sysl = Convert.ToDecimal(row_zs["ypsl"]);
                            DataRow[] rows_fs = tbpcmx_fs.Select(" kdsl>0 and cjid=" + row_zs["cjid"].ToString());
                            int dwbl_zs = Convert.ToInt32(row_zs["dwbl"]); //����dwbl
                            for (int i = 0; i < rows_fs.Length; i++)
                            {
                                decimal cks = 0;
                                DataRow row_fs = rows_fs[i];
                                int dwbl_fs = Convert.ToInt32(rows_fs[i]["dwbl"]);
                                if (dwbl_zs != dwbl_fs)
                                {
                                    throw new Exception("��λ���������仯����ˢ�����ݺ�����");
                                }
                                decimal kdsl = Convert.ToDecimal(row_fs["kdsl"]);
                                if (kdsl == 0)
                                    continue;

                                if (kdsl >= sysl)
                                {
                                    kdsl = kdsl - sysl;
                                    cks = sysl;
                                    sysl = 0;
                                }
                                else
                                {
                                    cks = kdsl;
                                    kdsl = 0;
                                    sysl -= cks;
                                }
                                row_fs["kdsl"] = kdsl;

                                DataRow newrow = tb_temp.NewRow();
                                newrow = row_zs;
                                newrow["yppch2"] = row_fs["yppch2"];//���κ�
                                newrow["ypph2"] = row_fs["ypph2"];//����
                                newrow["ypxq2"] = row_fs["ypxq2"];//Ч��
                                newrow["kcid2"] = row_fs["kcid2"];//kcid
                                newrow["jhj2"] = row_fs["jhj2"];
                                newrow["jhje2"] = Convert.ToDecimal(Convert.ToDecimal(row_fs["jhj2"]) * cks);
                                newrow["ypsl"] = cks;

                                newrow["bdelete2"] = row_fs["bdelete2"];//���ñ�־

                                tbpcmx.ImportRow(newrow);
                                row_zs["ypsl"] = sysl;

                                if (sysl == 0)
                                {
                                    break;
                                }
                                if (kdsl == 0)
                                {
                                    continue;
                                }
                            }
                            #endregion
                        }
                        foreach (DataRow row in tbpcmx_fs.Rows)
                        {
                            tbpcmx.ImportRow(row);
                        }

                        //���Ĳ������������δ�ܵ����Ĵ���0��ҩƷ
                        DataRow[] rows_zs_wfp = tbpcmx_zs_wfp.Select("ypsl>0");
                        if (rows_zs_wfp.Length > 0)
                        {
                            throw new Exception(string.Format("{0} {1} ���ÿ�������㣡", rows_zs_wfp[0]["Ʒ��"], rows_zs_wfp[0]["���"]));
                        }

                        //return;
                    }
                    catch (Exception eeee)
                    {
                        MessageBox.Show(eeee.ToString());
                        return;
                    }
                    #endregion


                    #region ����סԺ���ñ�kcid ���Ƿŵ�������
                    int err_code_tt = 0;
                    string err_text_tt = "���·��ñ�������Ϣʧ�ܣ�";
                    foreach (DataRow row_pcmx in tbpcmx.Rows)
                    {
                        ZY_FY.UpdateFeeKcid(new Guid(row_pcmx["zy_id"].ToString()),
                                            new Guid(row_pcmx["kcid2"].ToString()),
                                            out err_code_tt,
                                            out err_text_tt,
                                            InstanceForm.BDatabase);
                        if (err_code_tt != 0)
                        {
                            throw new Exception(err_text_tt);
                        }
                    }

                    #endregion


                    try
                    {
                        this.Cursor = PubStaticFun.WaitCursor();
                        InstanceForm.BDatabase.BeginTransaction();

                        #region ���뷢ҩͷ�� ���뷢ҩ��ϸ
                        for (int i = 0; i < tbcf.Rows.Count; i++)
                        {
                            string _presc_no = Convert.ToString(tbcf.Rows[i]["������"]); //������ 
                            decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���"], "0")); //���
                            int _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"], "0")); //����
                            Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["inpatient_id"], Guid.Empty.ToString()));//����ID
                            string _inpatient_no = Convert.ToString(tbcf.Rows[i]["סԺ��"]);//סԺ��
                            string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//����
                            int _dept_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["dept_id"], "0"));//����
                            int _doc_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["doc_id"], "-1"));//ҽ��
                            Guid _fyid = Guid.Empty;//��ҩID

                            #region ������ҩ
                            try
                            {
                                DataRow row_hlyy = tbcf.Rows[i];
                                if (cfghlyytype != "0" && cfghlyytype != "")
                                {
                                    switch (cfghlyytype)
                                    {
                                        case "1":
                                            #region ��ͨ������ҩסԺ  ncq  2014-03-24
                                            object objbrxxid = InstanceForm.BDatabase.GetDataResult("s5elect PATIENT_ID from ZY_inpatient where inpatient_id='" + row_hlyy["inpatient_id"].ToString() + "' ");
                                            string strbrxxid = objbrxxid != null ? objbrxxid.ToString() : "";
                                            if (strbrxxid != "")
                                            {
                                                YY_BRXX brxx = new YY_BRXX(new Guid(strbrxxid), InstanceForm.BDatabase);
                                                string birth = brxx.Csrq;
                                                string patname = brxx.Brxm;
                                                int gh = InstanceForm.BCurrentUser.EmployeeId; //��ǰ�û�id
                                                string cfrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");//��������
                                                string employeename = InstanceForm.BCurrentUser.Name;//�û�����
                                                int ksdm = InstanceForm.BCurrentDept.DeptId;//����id
                                                string ksmc = InstanceForm.BCurrentDept.DeptName;//��������
                                                string zyh = Convertor.IsNull(row_hlyy["סԺ��"], "").ToString();//סԺ��
                                                string brxmhlyy = Convertor.IsNull(row_hlyy["����"], "").ToString();//��������
                                                string xb = brxx.Xb;//tbsel.Rows[0]["�Ա�"].ToString();//�Ա�
                                                if (xb == "1")
                                                {
                                                    xb = "��";
                                                }
                                                else
                                                {
                                                    if (xb == "2")
                                                        xb = "Ů";
                                                    else
                                                        xb = "����";
                                                }
                                                string icd = Convertor.IsNull(row_hlyy["���"], "").ToString(); //tbsel.Rows[0]["���"].ToString();//���
                                                int hfresult = 0;
                                                hlyyjk.RegisterServer_fun(null);//���ĵ�
                                                hlyyjk.Refresh();
                                                TrasenFrame.Classes.TsSet tsset1 = new TsSet();
                                                tsset1.TsDataTable = tb.Copy();
                                                DataTable tb1 = tsset1.FilterTable("������='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and ����='" + _cfts.ToString() + "' and ����='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                                                StringBuilder sss = new StringBuilder(ts_zy_hlyy.GetXml(gh, cfrq, employeename, ksdm, ksmc, zyh, birth, brxmhlyy, xb, tb1, icd));
                                                hfresult = hlyyjk.DrugAnalysis(sss, 0);//סԺ-0 ����-1 

                                                if (hfresult >= 2)
                                                {
                                                    if (MessageBox.Show("����!�����п��ܴ��ڲ��������ҩ,��Ҫ������ҩ��?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                                        return;
                                                    hfresult = hlyyjk.SaveDrug(sss, 1);
                                                }
                                                hlyyjk.SaveXml(sss);
                                            }
                                            #endregion
                                            break;
                                        default:
                                            MessageBox.Show(cfghlyytype + "�ú�����ҩ�ӿڲ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("PASS����!ԭ��:" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //return;
                            }
                            #endregion

                            #region  �ϵ�����Ǵ�����ҩ�Ͳ�ʵ�ʷ�ҩ
                            //if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_cf_jy")
                            //{
                            //    //���뷢ҩͷ��
                            //    ZY_FY.SaveFy("", Convert.ToDecimal(_presc_no), 0, _sumzje, _cfts, Guid.Empty, _inpatient_id, _inpatient_no,
                            //              _hzxm, _doc_id, _dept_id, _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate,
                            //              InstanceForm.BCurrentUser.EmployeeId, _pyr, "", "", InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, out _fyid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                            //    if (_fyid == Guid.Empty || _err_code < 0) throw new Exception(_err_text);

                            //    DataRow[] rows = tbpcmx.Select("������='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and ����='" + _cfts.ToString() + "' and ����='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                            //    //���뷢ҩ��ϸ�� 
                            //    decimal sumjhje = 0;//�ܽ������
                            //    for (int j = 0; j <= rows.Length - 1; j++)
                            //    {
                            //        if (Convert.ToInt16(Convertor.IsNull(rows[j]["discharge_bit"], "0")) == 0 && chkcydy.Checked == true && _cydy == "1")
                            //        {
                            //            throw new Exception("�Բ���,��Ժ��ҩ�Ĵ��������ڲ��˽����Ժ���ܷ�ҩ");
                            //        }
                            //        //decimal jhj = Convert.ToDecimal(rows[j]["jhj2"]);
                            //        decimal ypsl = Convert.ToDecimal(rows[j]["ypsl"]);
                            //        int js = Convert.ToInt32(rows[j]["����"]);
                            //        int dwbl_kc = Convert.ToInt32(rows[j]["dwbl"]);//��浥λ����
                            //        int dwbl_cfmx = Convert.ToInt32(rows[j]["unitrate"]);//������ϸ��λ����
                            //        decimal lsj_cfmx = Convert.ToDecimal(rows[j]["����"]);//������ϸ���ۼ�
                            //        decimal pfj_cfmx = Convert.ToDecimal(rows[j]["������"]);//������ϸ������

                            //        decimal sl = Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc/js);//����
                            //        decimal pfje = Convert.ToDecimal(ypsl*dwbl_cfmx/dwbl_kc*pfj_cfmx*js);//�������
                            //        decimal lsje = Convert.ToDecimal(ypsl*dwbl_cfmx/dwbl_kc*lsj_cfmx*js);//���۽��

                            //        decimal jhj_kc = Convert.ToDecimal(rows[j]["jhj2"]);
                            //        decimal jhje = Convert.ToDecimal(jhj_kc*ypsl);
                            //        string ypph = rows[j]["ypph2"].ToString();
                            //        string ypxq = rows[j]["ypxq2"].ToString();
                            //        string yppch = rows[j]["yppch2"].ToString();
                            //        Guid kcid = new Guid(rows[j]["kcid2"].ToString());
                            //        Guid tyid = new Guid(Convertor.IsNull(rows[j]["cz_id"], Guid.Empty.ToString()));



                            //        ZY_FY.SaveFymx(_fyid,0, new Guid(rows[j]["zy_id"].ToString()), Convert.ToInt32(rows[j]["cjid"]), rows[j]["����"].ToString(),
                            //            rows[j]["��Ʒ��"].ToString(), rows[j]["��Ʒ��"].ToString(), rows[j]["���"].ToString(), rows[j]["����"].ToString(),
                            //            rows[j]["��λ"].ToString(), Convert.ToDecimal(rows[j]["unitrate"]), sl,
                            //            Convert.ToInt32(rows[j]["����"]), Convert.ToDecimal(rows[j]["������"]), pfje,
                            //            Convert.ToDecimal(rows[j]["����"]), lsje, InstanceForm.BCurrentDept.DeptId,
                            //            tyid, ypph, out _err_code, out _err_text, InstanceForm.BDatabase, jhj_kc,jhje,ypxq,yppch,kcid,true);
                            //        if (_fyid == Guid.Empty || _err_code < 0) throw new Exception(_err_text);
                            //        NN = NN + 1;

                            //        sumjhje += jhje;
                            //    }


                            //    #region ���·�ҩͷ���еĽ������
                            //    string ssql_jhje = string.Format(" update yf_fy set jhje={0} where id='{1}'", sumjhje, _fyid);
                            //    if (InstanceForm.BDatabase.DoCommand(ssql_jhje) <= 0)
                            //    {
                            //        throw new Exception("���½������ʧ��");
                            //    }
                            //    #endregion

                            //}
                            #endregion

                            #region ����Ǵ�����ҩ�Ͳ�ʵ�ʷ�ҩ
                            if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_cf_jy")
                            {
                                //���뷢ҩͷ��
                                ZY_FY.SaveFy("", Convert.ToDecimal(_presc_no), 0, _sumzje, _cfts, Guid.Empty, _inpatient_id, _inpatient_no,
                                          _hzxm, _doc_id, _dept_id, _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate,
                                          InstanceForm.BCurrentUser.EmployeeId, _pyr, "", "", InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, out _fyid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                                if (_fyid == Guid.Empty || _err_code < 0)
                                    throw new Exception(_err_text);

                                DataRow[] rows = tbpcmx.Select("������='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and ����='" + _cfts.ToString() + "' and ����='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                                //���뷢ҩ��ϸ�� 
                                decimal sumjhje = 0;//�ܽ������
                                for (int j = 0; j <= rows.Length - 1; j++)
                                {
                                    if (Convert.ToInt16(Convertor.IsNull(rows[j]["discharge_bit"], "0")) == 0 && rdCydy.Checked == true && _cydy == "1")
                                    {
                                        throw new Exception("�Բ���,��Ժ��ҩ�Ĵ��������ڲ��˽����Ժ���ܷ�ҩ");
                                    }
                                    decimal ypsl = Convert.ToDecimal(rows[j]["ypsl"]);
                                    int js = Convert.ToInt32(rows[j]["����"]);
                                    int dwbl_kc = Convert.ToInt32(rows[j]["dwbl"]);//��浥λ����
                                    string kcdw = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.fun_yp_ypdw(zxdw) from yf_kcmx where cjid=" + rows[j]["cjid"] + " and deptid=" + InstanceForm.BCurrentDept.DeptId + ""), "");
                                    int dwbl_cfmx = Convert.ToInt32(rows[j]["unitrate"]);//������ϸ��λ����
                                    decimal lsj_cfmx = Convert.ToDecimal(rows[j]["����"]);//������ϸ���ۼ�
                                    decimal pfj_cfmx = Convert.ToDecimal(rows[j]["������"]);//������ϸ������
                                    decimal sl = Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc / js);//������ϸ����
                                    decimal pfje = Math.Round(Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc * pfj_cfmx), 4);    //�������=������ϸ����*������ϸ������
                                    decimal lsje = Math.Round(Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc * lsj_cfmx), 4);//���۽��=������ϸ����*������ϸ���ۼ�
                                    decimal jhj_kc = Convert.ToDecimal(rows[j]["jhj2"]);//�ⷿ��λ����
                                    decimal jhj_cfmx = Convert.ToDecimal(jhj_kc * dwbl_kc / dwbl_cfmx);//������ϸ�н�����
                                    decimal jhje = Math.Round(Convert.ToDecimal(jhj_kc * ypsl), 4);//�������=��浥λ����*��浥λ����
                                    string ypph = rows[j]["ypph2"].ToString();
                                    string ypxq = rows[j]["ypxq2"].ToString();
                                    string yppch = rows[j]["yppch2"].ToString();
                                    Guid kcid = new Guid(rows[j]["kcid2"].ToString());
                                    Guid tyid = new Guid(Convertor.IsNull(rows[j]["cz_id"], Guid.Empty.ToString()));

                                    string spm = rows[j]["��Ʒ��"].ToString();
                                    //------------------modify by wangzhi at 2014-07-29 ԭ���������ͬ------------------                                                                                                             
                                    //sl = decimal.Round( ypsl * dwbl_cfmx / dwbl_kc / js , 6 );                 
                                    //decimal d1 = ( ypsl * dwbl_cfmx / dwbl_kc );                              
                                    //decimal d2 = decimal.Round( ( js * sl ) , 6 );                                                                                                                                    
                                    //if ( d1 != d2 )
                                    //{
                                    //    sl = ypsl * dwbl_cfmx / dwbl_kc;
                                    //    js = 1;
                                    //}
                                    //------------------end modify by wangzhi at 2014-07-29------------------
                                    //���ϴ�����29�ŵ��޸ģ���������©��,����

                                    //------------------add by wangzhi at 2014-08-01 ��������ͬ�Ĵ���,(д��ҩ��ϸ�ĵ�λ���浥λһ��)------------------  
                                    js = 1;  //ǿ�Ƽ���Ϊ1
                                    sl = ypsl; //����ֱ��ȡ��ֽ��
                                    pfj_cfmx = Convert.ToDecimal(rows[j]["������"]) * dwbl_cfmx / dwbl_kc; //ʹ��������ʹ�õĵ�λ���������ʹ�õĵ�λ����һ��
                                    lsj_cfmx = Convert.ToDecimal(rows[j]["����"]) * dwbl_cfmx / dwbl_kc;   //ͬ��
                                    //------------------end modify by wangzhi at 2014-08-01------------------

                                    ZY_FY.SaveFymx(_fyid, 0, new Guid(rows[j]["zy_id"].ToString()), Convert.ToInt32(rows[j]["cjid"]), rows[j]["����"].ToString(),
                                        spm, spm, rows[j]["���"].ToString(), rows[j]["����"].ToString(),
                                        kcdw,// rows[j]["��λ"].ToString()
                                        dwbl_kc,// Convert.ToDecimal( rows[j]["unitrate"] )
                                        sl,
                                        js,// Convert.ToInt32( rows[j]["����"] ) ,
                                        pfj_cfmx, //Convert.ToDecimal( rows[j]["������"] ) , //modify by wangzhi at 2014-08-01 ��Ϊ�뵥λ��Ӧ�ļ۸�
                                        pfje,
                                        lsj_cfmx, //Convert.ToDecimal( rows[j]["����"] ) ,   //modify by wangzhi at 2014-08-01 ��Ϊ�뵥λ��Ӧ�ļ۸�
                                        lsje,
                                        InstanceForm.BCurrentDept.DeptId,
                                        tyid,
                                        ypph,
                                        out _err_code,
                                        out _err_text,
                                        InstanceForm.BDatabase,
                                        jhj_kc, // jhj_cfmx , //ʹ�ÿⷿ��λ�Ľ�����         //modify by wangzhi at 2014-08-01 ��Ϊ�뵥λ��Ӧ�ļ۸�
                                        jhje,
                                        ypxq,
                                        yppch, kcid, true);
                                    if (_fyid == Guid.Empty || _err_code < 0)
                                        throw new Exception(_err_text);
                                    NN = NN + 1;
                                    sumjhje += jhje;
                                }
                                #region ���·�ҩͷ���еĽ������
                                string ssql_jhje = string.Format(" update yf_fy set jhje={0} where id='{1}'", sumjhje, _fyid);
                                if (InstanceForm.BDatabase.DoCommand(ssql_jhje) <= 0)
                                {
                                    throw new Exception("���½������ʧ��");
                                }
                                #endregion
                            }
                            #endregion

                        }
                        #endregion

                        DataRow[] rows1 = tb.Select("��ҩ='��' and cjid<>'' and charge_bit='0'");//û�мǷѵļ�¼
                        DataRow[] rows2 = tb.Select("��ҩ='��' and cjid<>'' and charge_bit='1'");//�ѼǷѵļ�¼

                        #region ����û�мǷѼ�¼
                        string ssql = "";
                        //ʱ���
                        decimal _execId = 0;
                        ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                        _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));
                        //����û�мǷѵļ�¼
                        for (int i = 0; i <= rows1.Length - 1; i++)
                        {
                            ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows1[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",null,1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        if (rows1.Length > 0)
                        {
                            int iii = ZY_FY.UpdateFeeChargeFy(rdols.Checked, Guid.Empty, _sDate, InstanceForm.BCurrentUser.EmployeeId, _pyr, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                            if (rows1.Length != iii)
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!��������ˢ�����ݺ�����!");
                        }
                        #endregion

                        #region �����Ѿ��Ƿѵļ�¼
                        //ʱ���
                        ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                        _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                        //�����ѼǷѵļ�¼
                        for (int i = 0; i <= rows2.Length - 1; i++)
                        {
                            ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows2[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",null,1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        if (rows2.Length > 0)
                        {
                            int iii = ZY_FY.UpdateFeeChargeFy(rdols.Checked, Guid.Empty, _sDate, InstanceForm.BCurrentUser.EmployeeId, _pyr, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                            if (rows2.Length != iii)
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!��������ˢ�����ݺ�����!");
                        }
                        #endregion

                        InstanceForm.BDatabase.CommitTransaction();//�ύ����

                        #region ������������Ϊ�ѷ�ҩ״̬
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = tb;
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            if (tb.Rows[i]["��ҩ"].ToString().Trim() == "��")
                            {
                                tb.Rows[i]["��ҩ"] = "��";
                                tb.Rows[i]["��ҩ����"] = _sDate;
                                tb.Rows[i]["��ҩԱ"] = InstanceForm.BCurrentUser.Name;
                                //��ҩ����ʾ��ҩ������  lidan add 2013-07-01
                                tb.Rows[i]["��ҩԱ"] = cmbpyr.Text;
                            }
                        }
                        this.myDataGrid1.DataSource = xcset1.TsDataTable;
                        butfy.Tag = _sDate;
                        #endregion

                        #region ��ʾ�ɹ��Լ���ӡ
                        string cxfs = ApiFunction.GetIniString("סԺ������ҩĬ�ϴ�ӡ��ʽ", "��ӡ��ʽ", Constant.ApplicationDirectory + "//ClientWindow.ini");

                        if (cxfs != "Ĭ�ϲ���ӡ")
                        {
                            if (MessageBox.Show("��ҩ�ɹ�,��Ҫ��ӡ��", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (rdomx.Checked == true)
                                    this.butprint_Click(sender, e);
                                else
                                {
                                    computeTld(_sDate);
                                    this.butprinthz_Click(sender, e);
                                }
                            }
                        }
                        #endregion

                    }
                    catch (System.Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Arrow;
                    }
                }
                txtzyh.Focus();
                txtzyh.SelectAll();
            }
        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            //PubClass.PrintCf("5F8369FC-F60F-4D78-9A86-A01700D84082", "1", "22", InstanceForm.BDatabase);
            this.Close();
        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            if (new SystemCfg(8021).Config == "0")
            {
                #region ��������ҩ
                try
                {



                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    if (tb.Rows.Count == 0)
                        return;

                    DataRow[] rows;

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        rows = tb.Select("( ��ҩ='��' or ��ҩ='��') and ypsl<>0");
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                            rows = tb.Select("( ��ҩ='��') and ypsl<>0  and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        else
                            rows = tb.Select("( ��ҩ='��') and ypsl<>0");
                    }
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("û��Ҫ��ӡ���ѷ�ҩ����", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    butprint.Enabled = false;

                    //Ҫ��ӡ�Ĵ����ż���
                    string _cfh = "";
                    string[] GroupbyField1 ={ "������" };
                    string[] ComputeField1 ={ };
                    string[] CField1 ={ };
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tb;
                    DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "( ��ҩ='��' or ��ҩ='��') and ypsl<>0");
                    _cfh = "(";
                    for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                        _cfh = _cfh + tb_cfh.Rows[i]["������"].ToString() + ",";
                    _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";



                    ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                    DataRow myrow;
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        myrow = Dset.��ҩ��ϸ��.NewRow();
                        myrow["rowno"] = Convert.ToString(rows[i]["���"]);
                        myrow["yppm"] = Convert.ToString(rows[i]["Ʒ��"]);
                        myrow["ypspm"] = Convert.ToString(rows[i]["��Ʒ��"]);
                        myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
                        myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                        myrow["lsj"] = Convert.ToDecimal(rows[i]["����"]);
                        myrow["ypsl"] = Convert.ToDecimal(rows[i]["����"]);
                        if (Convert.ToDecimal(rows[i]["����"]) > 1 || Convert.ToString(rows[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                            myrow["cfts"] = "����:" + rows[i]["����"].ToString() + " ��   " + rows[i]["��ҩ"].ToString();
                        myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
                        myrow["lsje"] = Convert.ToDecimal(rows[i]["���"]);
                        myrow["shh"] = Convert.ToString(rows[i]["����"]);
                        myrow["bed_no"] = Convert.ToString(rows[i]["����"]);
                        myrow["name"] = Convert.ToString(rows[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows[i]["��������"]).Trim();
                        myrow["inpatient_no"] = Convert.ToString(rows[i]["סԺ��"]);
                        myrow["lydw"] = Convert.ToString(rows[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows[i]["ҽ��"]);
                        myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows[i]["dept_id"]), InstanceForm.BDatabase);
                        myrow["presc_no"] = rows[i]["������"].ToString().Trim();
                        myrow["order_usage"] = rows[i]["�÷�"].ToString().Trim() + " " + rows[i]["Ƶ��"].ToString().Trim();
                        myrow["xb"] = Convert.ToString(rows[i]["�Ա�"]);
                        myrow["nl"] = Convert.ToString(rows[i]["����"]);
                        myrow["JTDZ"] = Convert.ToString(rows[i]["��ͥ��ַ"]);
                        myrow["LXDH"] = Convert.ToString(rows[i]["��ϵ��ʽ"]);
                        myrow["SFZH"] = Convert.ToString(rows[i]["���֤"]);
                        myrow["bz1"] = Convert.ToString(rows[i]["���"]);
                        myrow["bz2"] = Convert.ToString(rows[i]["��ҽ���"]);
                        myrow["bz3"] = Convert.ToString(rows[i]["��ҽ֢��"]);
                        myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                        //��ӡ��ҩ�ˡ���ҩ�ˡ���ҩ���ڡ�ҽ��������ҩƷ����  lidan 2013-07-01
                        myrow["fyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
                        myrow["pyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
                        myrow["fyrq"] = Convert.ToString(rows[i]["��ҩ����"]);
                        myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]);
                        myrow["ypjx"] = Convert.ToString(rows[i]["����"]);
                        myrow["jl"] = Convert.ToString(rows[i]["����"]) + Convert.ToString(rows[i]["������λ"]);

                        int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["������"].ToString().Trim() + ""));
                        bdycs = bdycs + 1;
                        myrow["bz"] = bdycs > 1 ? "(����)" : "";//��ע��ʾ������ lidan 2013-07-01
                        myrow["hwh"] = Convert.ToString(rows[i]["hwh"]);
                        myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));


                        Dset.��ҩ��ϸ��.Rows.Add(myrow);
                    }

                    ParameterEx[] parameters = new ParameterEx[2];
                    parameters[0].Text = "titletext";
                    string ss = "";
                    if (rdCydy.Checked == false)
                        ss = "סԺ�����嵥";
                    else
                        ss = "��Ժ��ҩ�嵥";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                    parameters[1].Text = "BZ";
                    parameters[1].Value = "";
                    bool bview = this.chkprintview.Checked == true ? false : true;
                    TrasenFrame.Forms.FrmReportView f;

                    string[] str ={ "" };
                    str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";


                    f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥.rpt", parameters, bview, str, InstanceForm.BDatabase);
                    //f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥.rpt", parameters, bview);
                    if (f.LoadReportSuccess)
                        f.Show();
                    else
                        f.Dispose();

                    butprint.Enabled = true;
                }
                catch (System.Exception err)
                {
                    butprint.Enabled = true;
                    MessageBox.Show(err.Message);
                }
                #endregion
            }

            else
            {
                try
                {
                    DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                    if (tb.Rows.Count == 0)
                        return;

                    DataRow[] rows;

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        rows = tb.Select("( ��ҩ='��' or ��ҩ='��') and ypsl<>0");
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                            rows = tb.Select("( ��ҩ='��') and ypsl<>0  and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        else
                            rows = tb.Select("( ��ҩ='��') and ypsl<>0");
                    }
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("û��Ҫ��ӡ���ѷ�ҩ����", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    butprint.Enabled = false;




                    DataRow[] rows_xy = null;
                    DataRow[] rows_zy = null;
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        rows_xy = tb.Select("( ��ҩ='��' or ��ҩ='��') and ypsl<>0 and STATITEM_CODE not like '%03%' ");
                        rows_zy = tb.Select("( ��ҩ='��' or ��ҩ='��') and ypsl<>0 and STATITEM_CODE like '%03%'");
                    }
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                        {
                            rows_xy = tb.Select("( ��ҩ='��') and ypsl<>0 and STATITEM_CODE not like '%03%'  and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                            rows_zy = tb.Select("( ��ҩ='��') and ypsl<>0 and STATITEM_CODE like '%03%'   and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        }
                        else
                        {
                            rows_xy = tb.Select("( ��ҩ='��') and ypsl<>0 and STATITEM_CODE not like '%03%' ");
                            rows_zy = tb.Select("( ��ҩ='��') and ypsl<>0 and STATITEM_CODE like '%03%' ");
                        }
                    }


                    ts_Yk_ReportView.Dataset2 Dset;
                    DataRow myrow;

                    if (rows_xy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_xy.Length - 1; i++)
                        {
                            myrow = Dset.��ҩ��ϸ��.NewRow();
                            myrow["rowno"] = Convert.ToString(rows_xy[i]["���"]);
                            myrow["yppm"] = Convert.ToString(rows_xy[i]["Ʒ��"]);
                            myrow["ypspm"] = Convert.ToString(rows_xy[i]["��Ʒ��"]);
                            myrow["ypgg"] = Convert.ToString(rows_xy[i]["���"]);
                            myrow["sccj"] = Convert.ToString(rows_xy[i]["����"]);
                            myrow["lsj"] = Convert.ToDecimal(rows_xy[i]["����"]);
                            myrow["ypsl"] = Convert.ToDecimal(rows_xy[i]["����"]);
                            if (Convert.ToDecimal(rows_xy[i]["����"]) > 1 || Convert.ToString(rows_xy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                myrow["cfts"] = "����:" + rows_xy[i]["����"].ToString() + " ��   " + rows_xy[i]["��ҩ"].ToString();
                            myrow["ypdw"] = Convert.ToString(rows_xy[i]["��λ"]);
                            myrow["lsje"] = Convert.ToDecimal(rows_xy[i]["���"]);
                            myrow["shh"] = Convert.ToString(rows_xy[i]["����"]);
                            myrow["bed_no"] = Convert.ToString(rows_xy[i]["����"]);
                            myrow["name"] = Convert.ToString(rows_xy[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows_xy[i]["��������"]).Trim();
                            myrow["inpatient_no"] = Convert.ToString(rows_xy[i]["סԺ��"]);
                            myrow["lydw"] = Convert.ToString(rows_xy[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows_xy[i]["ҽ��"]);
                            myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_xy[i]["dept_id"]), InstanceForm.BDatabase);
                            myrow["presc_no"] = rows_xy[i]["������"].ToString().Trim();
                            myrow["order_usage"] = rows_xy[i]["�÷�"].ToString().Trim() + " " + rows_xy[i]["Ƶ��"].ToString().Trim();
                            myrow["xb"] = Convert.ToString(rows_xy[i]["�Ա�"]);
                            myrow["nl"] = Convert.ToString(rows_xy[i]["����"]);
                            myrow["JTDZ"] = Convert.ToString(rows_xy[i]["��ͥ��ַ"]);
                            myrow["LXDH"] = Convert.ToString(rows_xy[i]["��ϵ��ʽ"]);
                            myrow["SFZH"] = Convert.ToString(rows_xy[i]["���֤"]);
                            myrow["bz1"] = Convert.ToString(rows_xy[i]["���"]);
                            myrow["bz2"] = Convert.ToString(rows_xy[i]["��ҽ���"]);
                            myrow["bz3"] = Convert.ToString(rows_xy[i]["��ҽ֢��"]);
                            myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                            //��ӡ��ҩ�ˡ���ҩ�ˡ���ҩ���ڡ�ҽ��������ҩƷ����  lidan 2013-07-01
                            myrow["fyr"] = Convert.ToString(rows_xy[i]["��ҩԱ"]);
                            myrow["pyr"] = Convert.ToString(rows_xy[i]["��ҩԱ"]);
                            myrow["fyrq"] = Convert.ToString(rows_xy[i]["��ҩ����"]);
                            myrow["ysname"] = Convert.ToString(rows_xy[i]["ҽ��"]);
                            myrow["ypjx"] = Convert.ToString(rows_xy[i]["����"]);
                            myrow["jl"] = Convert.ToString(rows[i]["����"]) + Convert.ToString(rows[i]["������λ"]);
                            int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["������"].ToString().Trim() + ""));
                            bdycs = bdycs + 1;
                            myrow["bz"] = bdycs > 1 ? "(����)" : "";//��ע��ʾ������ lidan 2013-07-01
                            myrow["hwh"] = Convert.ToString(rows_xy[i]["hwh"]);
                            myrow["image"] = GetImageByte((Convertor.IsNull(rows_xy[i]["doc_id"], "0")));


                            Dset.��ҩ��ϸ��.Rows.Add(myrow);

                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        if (rdCydy.Checked == false)
                            ss = "סԺ�����嵥";
                        else
                            ss = "��Ժ��ҩ�嵥";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = this.chkprintview.Checked == true ? false : true;
                        TrasenFrame.Forms.FrmReportView f;

                        //Ҫ��ӡ�Ĵ����ż���
                        string _cfh = "";
                        string[] GroupbyField1 ={ "presc_no" };
                        string[] ComputeField1 ={ };
                        string[] CField1 ={ };
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = Dset.��ҩ��ϸ��;
                        DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                        _cfh = "(";
                        for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                            _cfh = _cfh + tb_cfh.Rows[i]["presc_no"].ToString() + ",";
                        _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";

                        string[] str ={ "" };
                        str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";

                        f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥.rpt", parameters, bview, str, InstanceForm.BDatabase);
                        if (f.LoadReportSuccess)
                            f.Show();
                        else
                            f.Dispose();
                    }

                    if (rows_zy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_zy.Length - 1; i++)
                        {
                            myrow = Dset.��ҩ��ϸ��.NewRow();
                            myrow["rowno"] = Convert.ToString(rows_zy[i]["���"]);
                            myrow["yppm"] = Convert.ToString(rows_zy[i]["Ʒ��"]);
                            myrow["ypspm"] = Convert.ToString(rows_zy[i]["��Ʒ��"]);
                            myrow["ypgg"] = Convert.ToString(rows_zy[i]["���"]);
                            myrow["sccj"] = Convert.ToString(rows_zy[i]["����"]);
                            myrow["lsj"] = Convert.ToDecimal(rows_zy[i]["����"]);
                            myrow["ypsl"] = Convert.ToDecimal(rows_zy[i]["����"]);
                            if (Convert.ToDecimal(rows_zy[i]["����"]) > 1 || Convert.ToString(rows_zy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                myrow["cfts"] = "����:" + rows_zy[i]["����"].ToString() + " ��   " + rows_zy[i]["��ҩ"].ToString();
                            myrow["ypdw"] = Convert.ToString(rows_zy[i]["��λ"]);
                            myrow["lsje"] = Convert.ToDecimal(rows_zy[i]["���"]);
                            myrow["shh"] = Convert.ToString(rows_zy[i]["����"]);
                            myrow["bed_no"] = Convert.ToString(rows_zy[i]["����"]);
                            myrow["name"] = Convert.ToString(rows_zy[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows_zy[i]["��������"]).Trim();
                            myrow["inpatient_no"] = Convert.ToString(rows_zy[i]["סԺ��"]);
                            myrow["lydw"] = Convert.ToString(rows_zy[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows_zy[i]["ҽ��"]);
                            myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_zy[i]["dept_id"]), InstanceForm.BDatabase);
                            myrow["presc_no"] = rows_zy[i]["������"].ToString().Trim();
                            myrow["order_usage"] = rows_zy[i]["�÷�"].ToString().Trim() + " " + rows_zy[i]["Ƶ��"].ToString().Trim();
                            myrow["xb"] = Convert.ToString(rows_zy[i]["�Ա�"]);
                            myrow["nl"] = Convert.ToString(rows_zy[i]["����"]);
                            myrow["JTDZ"] = Convert.ToString(rows_zy[i]["��ͥ��ַ"]);
                            myrow["LXDH"] = Convert.ToString(rows_zy[i]["��ϵ��ʽ"]);
                            myrow["SFZH"] = Convert.ToString(rows_zy[i]["���֤"]);
                            myrow["bz1"] = Convert.ToString(rows_zy[i]["���"]);
                            myrow["bz2"] = Convert.ToString(rows_zy[i]["��ҽ���"]);
                            myrow["bz3"] = Convert.ToString(rows_zy[i]["��ҽ֢��"]);
                            myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                            //��ӡ��ҩ�ˡ���ҩ�ˡ���ҩ���ڡ�ҽ��������ҩƷ����  lidan 2013-07-01
                            myrow["fyr"] = Convert.ToString(rows_zy[i]["��ҩԱ"]);
                            myrow["pyr"] = Convert.ToString(rows_zy[i]["��ҩԱ"]);
                            myrow["fyrq"] = Convert.ToString(rows_zy[i]["��ҩ����"]);
                            myrow["ysname"] = Convert.ToString(rows_zy[i]["ҽ��"]);
                            myrow["ypjx"] = Convert.ToString(rows_zy[i]["����"]);
                            myrow["jl"] = Convert.ToString(rows[i]["����"]) + Convert.ToString(rows[i]["������λ"]);
                            int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["������"].ToString().Trim() + ""));
                            bdycs = bdycs + 1;
                            myrow["bz"] = bdycs > 1 ? "(����)" : "";//��ע��ʾ������ lidan 2013-07-01
                            myrow["hwh"] = Convert.ToString(rows_zy[i]["hwh"]);
                            myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));


                            Dset.��ҩ��ϸ��.Rows.Add(myrow);
                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        if (rdCydy.Checked == false)
                            ss = "סԺ�����嵥";
                        else
                            ss = "��Ժ��ҩ�嵥";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = this.chkprintview.Checked == true ? false : true;
                        TrasenFrame.Forms.FrmReportView f;


                        //Ҫ��ӡ�Ĵ����ż���
                        string _cfh = "";
                        string[] GroupbyField1 ={ "presc_no" };
                        string[] ComputeField1 ={ };
                        string[] CField1 ={ };
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = Dset.��ҩ��ϸ��;
                        DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                        _cfh = "(";
                        for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                            _cfh = _cfh + tb_cfh.Rows[i]["presc_no"].ToString() + ",";
                        _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";
                        string[] str ={ "" };
                        str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";

                        f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥(��ҩ).rpt", parameters, bview, str, InstanceForm.BDatabase);
                        if (f.LoadReportSuccess)
                            f.Show();
                        else
                            f.Dispose();
                    }


                    butprint.Enabled = true;
                }
                catch (System.Exception err)
                {
                    butprint.Enabled = true;
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void butprinthz_Click(object sender, System.EventArgs e)
        {
            try
            {


                DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                if (tb.Rows.Count == 0)
                    return;

                DataTable tbmx = (DataTable)this.myDataGrid1.DataSource;
                DataRow[] rows;
                rows = tbmx.Select("( ��ҩ='��') and ypsl<>0");

                if (rows.Length == 0 && new SystemCfg(8041).Config == "1")
                {
                    MessageBox.Show("û��Ҫ��ӡ���ѷ�ҩ����", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                butprinthz.Enabled = false;


                //string lydw=Yp.SeekWardName(tb.Rows[0]["wardid"].ToString().Trim());
                //string fyr=Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["fyr"]));
                //string pyr=Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["pyr"]));
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.��ҩ��ϸ��.NewRow();
                    myrow["yppm"] = Convert.ToString(tb.Rows[i]["Ʒ��"]);
                    myrow["ypspm"] = Convert.ToString(tb.Rows[i]["��Ʒ��"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["���"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["����"]);
                    myrow["lsj"] = Convert.ToDecimal(tb.Rows[i]["����"]);
                    myrow["ypsl"] = tb.Rows[i]["��ҩ��"];
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["��λ"]);
                    myrow["lsje"] = Convert.ToDecimal(tb.Rows[i]["���"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["����"]);
                    myrow["tlfl"] = "";
                    myrow["fyrq"] = "";
                    myrow["fyr"] = "";
                    myrow["pyr"] = "";
                    myrow["lydw"] = Convert.ToString(tb.Rows[i]["��ҩ����"]);
                    myrow["bz"] = Convert.ToString(tb.Rows[i]["ҩ�ⵥλ"]);
                    Dset.��ҩ��ϸ��.Rows.Add(myrow);

                }

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "title";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")סԺ�������ܵ�";
                parameters[1].Text = "lydwHeadText";
                parameters[1].Value = this.lblbz.Text.Trim();
                bool bview = this.chkprintview.Checked == true ? false : true;

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�������ܵ�.rpt", parameters, bview);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
                butprinthz.Enabled = true;

            }
            catch (System.Exception err)
            {
                butprinthz.Enabled = true;
                MessageBox.Show(err.Message);
            }
        }



        private void rdols_CheckedChanged(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
        }

        private void ComputeCf()
        {
            string[] GroupbyField ={ "������" };
            string[] ComputeField ={ };
            string[] CField ={ };

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataTable tab;
            DataRow[] selrow = tb.Select("��ҩ='��' and cjid<>''");
            //DataRow[] selrow=tb.Select("��ҩ='��' and cjid<>'' and charge_bit='1'");
            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
            this.lblbz.Text = "������:" + tab.Rows.Count.ToString() + " ��";

            string[] GroupbyField1 ={ "dept_ly" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            DataTable tbsel1 = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel1.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel1, GroupbyField1, ComputeField1, CField1, null);
            string ss = "";
            for (int i = 0; i <= tab.Rows.Count - 1; i++)
                ss = ss + " " + Yp.SeekDeptName(Convert.ToInt32(tab.Rows[i]["dept_ly"]), InstanceForm.BDatabase);
            this.lblbz.Text = lblbz.Text + " ����:" + ss.ToString();


        }

        //����
        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                string[] GroupbyField ={ "dept_ly", "����", "סԺ��", "����", "������", "����", "��ҩ" };
                string[] ComputeField ={ "���" };
                string[] CField ={ "sum" };

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataTable tab;
                DataRow[] selrow = tb.Select("��ҩ<>'��' and cjid<>''");

                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);
                tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

                Frmcffy_cx f = new Frmcffy_cx();
                DataTable tbcx = (DataTable)f.myDataGrid1.DataSource;
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    DataRow row = tbcx.NewRow();
                    int xh = i + 1;
                    row["���"] = xh.ToString();
                    row["����"] = Yp.SeekDeptName(Convert.ToInt32(tab.Rows[i]["dept_ly"]), InstanceForm.BDatabase);
                    row["סԺ��"] = tab.Rows[i]["סԺ��"];
                    row["����"] = tab.Rows[i]["����"];
                    row["���"] = tab.Rows[i]["���"];
                    row["������"] = tab.Rows[i]["������"];
                    row["����"] = tab.Rows[i]["����"];
                    row["ѡ"] = tab.Rows[i]["��ҩ"].ToString().Trim() == "��" ? (short)1 : (short)0;
                    tbcx.Rows.Add(row);
                }
                f._tb = tb.Copy();

                f.ShowDialog();

                int d = 0;
                for (int i = 0; i <= f._tb.Rows.Count - 1; i++)
                {
                    for (int x = 0; x <= tb.Rows.Count - 1; x++)
                    {
                        if (tb.Rows[x]["������"].ToString().Trim() != "" && tb.Rows[x]["��ҩ"].ToString().Trim() != "��" && tb.Rows[x]["������"].ToString().Trim() == f._tb.Rows[i]["������"].ToString().Trim())
                        {
                            if (Convert.ToInt16(f._tb.Rows[i]["ѡ"]) == 1)
                                tb.Rows[x]["��ҩ"] = "��";
                            else
                                tb.Rows[x]["��ҩ"] = "";
                        }
                    }
                    d = d + 1;
                }
                ComputeCf();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //�������иı��¼�
        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable tab = (DataTable)this.myDataGrid1.DataSource;
                if (tab.Rows.Count == 0)
                    return;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow >= tab.Rows.Count)
                    return;
                if (tab.Rows[nrow]["���"].ToString() == "" || tab.Rows[nrow]["���"].ToString() == "С��" || Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["����"], "0")) < 0)
                    this.myDataGrid1.ContextMenuStrip = null;
                else
                {
                    if (Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["����"], "0")) == 1)
                        mnutjs.Visible = false;
                    else
                        mnutjs.Visible = true;
                    if (tabControl1.SelectedTab != this.tabPage1)
                        this.myDataGrid1.ContextMenuStrip = contextMenu1;
                    else
                    {
                        this.myDataGrid1.ContextMenuStrip = null;

                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //�����Ŵ���
        private void mnuall_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow >= tb.Rows.Count)
                return;
            int err_code = -1;
            string err_text = "";

            if (MessageBox.Show("��ȷ��Ҫ�˵�ǰ���Ŵ�����", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //��ݵ��ٴ�ȷ��
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
            if (!bOk)
            {
                TrasenFrame.Forms.FrmMessageBox.Show("��û��ͨ��Ȩ��ȷ�ϣ����ܽ��д˲�����", new Font("����", 12f), Color.Red, "Sorry��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                Guid inpatient_id = new Guid(tb.Rows[nrow]["inpatient_id"].ToString());
                string presc_no = tb.Rows[nrow]["������"].ToString();

                DataTable tab = ZY_FY.Qyqr(inpatient_id, presc_no, Guid.Empty, 0, 0, 0, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tab.Rows.Count == 0)
                    throw new System.Exception("��ҩû�гɹ�," + err_text);

                ty(tab);

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("��ҩ�ɹ�");
                this.butcfcx_Click(sender, e);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "��ҩ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //������
        private void mnutyl_Click(object sender, EventArgs e)
        {
            //��ݵ��ٴ�ȷ��
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
            if (!bOk)
            {
                TrasenFrame.Forms.FrmMessageBox.Show("��û��ͨ��Ȩ��ȷ�ϣ����ܽ��д˲�����", new Font("����", 12f), Color.Red, "Sorry��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow >= tb.Rows.Count)
                return;
            int err_code = -1;
            string err_text = "";
            Guid zy_id = new Guid(tb.Rows[nrow]["zy_id"].ToString());

            decimal ypsl = Convert.ToDecimal(tb.Rows[nrow]["����"]);
            TrasenFrame.Forms.DlgInputBox f = new TrasenFrame.Forms.DlgInputBox(ypsl.ToString(), tb.Rows[nrow]["Ʒ��"].ToString() + "��ԭ����Ϊ" + ypsl.ToString() + tb.Rows[nrow]["��λ"].ToString() + "��������ҩ����", "��ҩ ");
            f.NumCtrl = true;
            f.ShowDialog();
            if (TrasenFrame.Forms.DlgInputBox.DlgResult == true)
                ypsl = Convert.ToDecimal(TrasenFrame.Forms.DlgInputBox.DlgValue);
            else
                return;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                Guid inpatient_id = new Guid(tb.Rows[nrow]["inpatient_id"].ToString());
                string presc_no = tb.Rows[nrow]["������"].ToString();

                DataTable tab = ZY_FY.Qyqr(inpatient_id, presc_no, zy_id, ypsl, 0, 1, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tab.Rows.Count == 0)
                    throw new System.Exception("��ҩû�гɹ�," + err_text);

                ty(tab);

                tab.TableName = "tab";
                DataRow row = tb.NewRow();
                row.ItemArray = tab.Rows[0].ItemArray;

                tb.Rows.InsertAt(row, nrow);

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("��ҩ�ɹ�");

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "��ҩ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ty(DataTable tab)
        {
            Guid _fyid = Guid.Empty;
            int _err_code = -1;
            string _err_text = "";

            string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            decimal zje = Convert.ToDecimal(tab.Compute("sum(���)", ""));
            int cfts = Convert.ToInt32(tab.Rows[0]["����"]);
            Guid inpatient_id = new Guid(tab.Rows[0]["inpatient_id"].ToString());
            string inpatient_no = tab.Rows[0]["סԺ��"].ToString();
            string hzxm = tab.Rows[0]["����"].ToString();
            int ysdm = Convert.ToInt32(tab.Rows[0]["doc_id"]);
            int ksdm = Convert.ToInt32(tab.Rows[0]["dept_id"]);
            int djy = InstanceForm.BCurrentUser.EmployeeId;
            int _pyr = Convert.ToInt32(cmbpyr.SelectedValue);

            ZY_FY.SaveFy("", 0, 0, zje, cfts, Guid.Empty, inpatient_id, inpatient_no, hzxm, ysdm, ksdm, _sDate, djy, _sDate, djy, _pyr, "", "", InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, out _fyid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
            if (_fyid == Guid.Empty || _err_code != 0)
                throw new Exception(_err_text);
            for (int j = 0; j <= tab.Rows.Count - 1; j++)
            {
                ZY_FY.SaveFymx(_fyid, 0, new Guid(tab.Rows[j]["zy_id"].ToString()), Convert.ToInt32(tab.Rows[j]["cjid"]), tab.Rows[j]["����"].ToString(),
                    tab.Rows[j]["��Ʒ��"].ToString(), tab.Rows[j]["��Ʒ��"].ToString(), tab.Rows[j]["���"].ToString(), tab.Rows[j]["����"].ToString(),
                    tab.Rows[j]["��λ"].ToString(), Convert.ToDecimal(tab.Rows[j]["unitrate"]), Convert.ToDecimal(tab.Rows[j]["����"]),
                    Convert.ToInt32(tab.Rows[j]["����"]), Convert.ToDecimal(tab.Rows[j]["������"]), Convert.ToDecimal(tab.Rows[j]["�������"]),
                    Convert.ToDecimal(tab.Rows[j]["����"]), Convert.ToDecimal(tab.Rows[j]["���"]), InstanceForm.BCurrentDept.DeptId,
                    Guid.Empty, "", out _err_code, out _err_text, InstanceForm.BDatabase,
                    0, 0, "", "", Guid.Empty, false);
                if (_err_code < 0)
                    throw new Exception(_err_text);
            }

        }

        //�˼���
        private void mnutjs_Click(object sender, EventArgs e)
        {
            //��ݵ��ٴ�ȷ��
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
            if (!bOk)
            {
                TrasenFrame.Forms.FrmMessageBox.Show("��û��ͨ��Ȩ��ȷ�ϣ����ܽ��д˲�����", new Font("����", 12f), Color.Red, "Sorry��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow >= tb.Rows.Count)
                return;
            int err_code = -1;
            string err_text = "";
            Guid zy_id = new Guid(tb.Rows[nrow]["zy_id"].ToString());

            int ypsl = Convert.ToInt32(tb.Rows[nrow]["����"]);
            TrasenFrame.Forms.DlgInputBox f = new TrasenFrame.Forms.DlgInputBox(ypsl.ToString(), "��ǰ�����ļ���Ϊ" + ypsl.ToString() + "��,������Ҫ�˵ļ���", "��ҩ ");
            f.NumCtrl = true;
            f.ShowDialog();
            if (TrasenFrame.Forms.DlgInputBox.DlgResult == true)
                ypsl = Convert.ToInt32(TrasenFrame.Forms.DlgInputBox.DlgValue);
            else
                return;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                Guid inpatient_id = new Guid(tb.Rows[nrow]["inpatient_id"].ToString());
                string presc_no = tb.Rows[nrow]["������"].ToString();

                DataTable tab = ZY_FY.Qyqr(inpatient_id, presc_no, Guid.Empty, 0, ypsl, 2, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tab.Rows.Count == 0)
                    throw new System.Exception("��ҩû�гɹ�," + err_text);

                ty(tab);

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("��ҩ�ɹ�");
                this.butcfcx_Click(sender, e);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "��ҩ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuprint_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataTable tab = tb.Clone();
                DataRow[] rows;
                string swhere = " ";
                decimal cfh = Convert.ToDecimal(Convertor.IsNull(tb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["������"], "0"));
                Guid inpatientId = new Guid(Convertor.IsNull(tb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["inpatient_id"], Guid.Empty.ToString()));
                swhere = swhere + " ������='" + cfh.ToString() + "' and inpatient_id='" + inpatientId.ToString() + "'";
                rows = tb.Select(swhere);
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    tab.ImportRow(rows[i]);
                }

                if (tab.Rows.Count == 0)
                    return;
                rows = tab.Select();
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

                DataRow myrow;
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.��ҩ��ϸ��.NewRow();
                    myrow["rowno"] = Convert.ToString(rows[i]["���"]);
                    myrow["yppm"] = Convert.ToString(rows[i]["Ʒ��"]);
                    myrow["ypspm"] = Convert.ToString(rows[i]["��Ʒ��"]);
                    myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                    myrow["lsj"] = Convert.ToDecimal(rows[i]["����"]);
                    myrow["ypsl"] = Convert.ToDecimal(rows[i]["����"]);
                    myrow["cfts"] = Convert.ToDecimal(rows[i]["����"]) >= 1 ? "����:" + rows[i]["����"].ToString() + " ��   " + rows[i]["��ҩ"].ToString() : "";
                    myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
                    myrow["lsje"] = Convert.ToDecimal(rows[i]["���"]);
                    myrow["shh"] = Convert.ToString(rows[i]["����"]);
                    myrow["bed_no"] = Convert.ToString(rows[i]["����"]);
                    myrow["name"] = Convert.ToString(rows[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows[i]["��������"]).Trim();
                    myrow["inpatient_no"] = Convert.ToString(rows[i]["סԺ��"]);
                    myrow["lydw"] = Convert.ToString(rows[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows[i]["ҽ��"]);
                    myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows[i]["dept_id"]), InstanceForm.BDatabase);
                    myrow["presc_no"] = rows[i]["������"].ToString().Trim();
                    myrow["order_usage"] = rows[i]["�÷�"].ToString().Trim() + " " + rows[i]["Ƶ��"].ToString().Trim();
                    myrow["xb"] = Convert.ToString(rows[i]["�Ա�"]);
                    myrow["nl"] = Convert.ToString(rows[i]["����"]);

                    myrow["JTDZ"] = "";
                    myrow["LXDH"] = "";
                    myrow["SFZH"] = "";
                    myrow["bz1"] = Convert.ToString(rows[i]["���"]);
                    myrow["bz2"] = Convert.ToString(rows[i]["��ҽ���"]);
                    myrow["bz3"] = Convert.ToString(rows[i]["��ҽ֢��"]);
                    myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                    //��ӡ��ҩ�ˡ���ҩ�ˡ���ҩ���ڡ�ҽ��������ҩƷ����
                    myrow["fyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
                    myrow["pyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
                    myrow["fyrq"] = Convert.ToString(rows[i]["��ҩ����"]);
                    myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]);
                    myrow["ypjx"] = Convert.ToString(rows[i]["����"]);
                    myrow["hwh"] = Convert.ToString(rows[i]["hwh"]);
                    myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));

                    Dset.��ҩ��ϸ��.Rows.Add(myrow);
                }

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "titletext";
                string ss = "";
                if (rdCydy.Checked == false)
                    ss = "סԺ�����嵥";
                else
                    ss = "��Ժ��ҩ�嵥";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                parameters[1].Text = "BZ";
                parameters[1].Value = "";
                bool bview = this.chkprintview.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView ff;
                if (Convert.ToString(rows[0]["STATITEM_CODE"]).Contains("03") == false || new SystemCfg(8021).Config == "0")
                    ff = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥.rpt", parameters);
                else
                    ff = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥(��ҩ).rpt", parameters);
                if (ff.LoadReportSuccess)
                    ff.Show();
                else
                    ff.Dispose();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void treeListView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeListViewItem item = (TreeListViewItem)this.treeListView3.SelectedItems[0];
                string dept_ly = item.Tag.ToString();
                string fyrq = item.SubItems[0].Text;
                int bk = this.rdodq.Checked == true ? 0 : 1;

                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;
                DataTable tb = ZY_FY.SelectCF(dept_ly, Guid.Empty, "", "", "", "", fyrq, fyrq, "1", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, 0, InstanceForm.BDatabase, bdybz);
                this.AddPresc(tb);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnujjty_Click(object sender, EventArgs e)
        {


        }

        private void butjjty_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            //int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            //if (nrow >= tb.Rows.Count) return;
            int err_code = -1;
            string err_text = "";

            //���鴦��
            string[] GroupbyField ={ "סԺ��", "����", "inpatient_id", "������", "dept_id", "doc_id", "����" };
            string[] ComputeField ={ "���" };
            string[] CField ={ "sum" };
            TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            xcset.TsDataTable = tb;
            DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "��ҩ='��' and ypsl<0");
            if (tbcf.Rows.Count == 0)
            {
                MessageBox.Show("��ѡ��Ҫ�ܾ��Ĵ���");
                return;
            }

            DataRow[] rowsx = tb.Select("��ҩ='��' and cjid<>''  and ypsl<0 ");
            if (rowsx.Length == 0)
            {
                MessageBox.Show("��ѡ��Ҫ�ܾ��Ĵ���");
                return;
            }

            if (MessageBox.Show("��ѡ����  " + rowsx.Length.ToString() + " ����¼,��ȷ��Ҫ�ܾ���", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                for (int j = 0; j <= rowsx.Length - 1; j++)
                {
                    Guid zy_id = new Guid(rowsx[j]["zy_id"].ToString());
                    DataTable tab = ZY_FY.Qyqr(Guid.Empty, "0", zy_id, 0, 0, 5, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, out err_code, out err_text, InstanceForm.BDatabase);
                }
                if (err_code != 0)
                    throw new System.Exception("" + err_text);


                InstanceForm.BDatabase.CommitTransaction();

                for (int j = 0; j <= rowsx.Length - 1; j++)
                {
                    rowsx[j]["��ҩ"] = "��";
                }

                MessageBox.Show(err_text);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "�ܾ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buthelp_Click(object sender, EventArgs e)
        {

            TszyHIS.Inpatient inpatient = new TszyHIS.Inpatient(TszyHIS.Inpatient.GetInpatientID());
            if (inpatient.InpatientNo.ToString() != "")
            {
                txtzyh.Text = inpatient.InpatientNo;
                txtzyh.Tag = inpatient.InpatientID;

                butcfcx_Click(sender, e);
            }
        }

        private void rdomx_CheckedChanged(object sender, EventArgs e)
        {
            string dy = "Ĭ�ϴ���ϸ";
            if (rdohz.Checked == true)
                dy = "Ĭ�ϴ����";
            if (rdobdy.Checked == true)
                dy = "Ĭ�ϲ���ӡ";
            ApiFunction.WriteIniString("סԺ������ҩĬ�ϴ�ӡ��ʽ", "��ӡ��ʽ", dy, Constant.ApplicationDirectory + "\\ClientWindow.ini");
        }

        private int uid_pyr = 0;
        private void cmbpyr_SelectedIndexChanged(object sender, EventArgs e)
        {
            int uid_sel = Convert.ToInt32(cmbpyr.SelectedValue);//ѡ���û�
            int uid_cur = InstanceForm.BCurrentUser.EmployeeId;//��ǰ�û�
            SystemCfg cfg8059 = new SystemCfg(8059);
            if (cfg8059.Config == "1")
            {
                if (uid_sel != uid_cur && uid_pyr != 0)
                {
                    //��ݵ��ٴ�ȷ��
                    string dlgvalue = Ts_zyys_public.DlgPW.Show();
                    string pwStr = dlgvalue; //YS.Password;

                    bool bOk = new User(uid_sel, InstanceForm.BDatabase).CheckPassword(pwStr);
                    if (!bOk)
                    {
                        TrasenFrame.Forms.FrmMessageBox.Show("��û��ͨ��Ȩ��ȷ�ϣ����ܽ��д˲�����", new Font("����", 12f), Color.Red, "Sorry��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbpyr.SelectedValue = uid_pyr;
                        return;
                    }
                }

            }
            uid_pyr = Convert.ToInt32(cmbpyr.SelectedValue);
        }

        private void tabControl2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnRefreshMessage_Click(object sender, EventArgs e)
        {
            ((DataTable)myDataGrid1.DataSource).Rows.Clear();
            if (tabControl1.SelectedTab.Name == this.tabPage1.Name)
            {

                GetMessage();
            }
            else
            {
                tabControl2_Click(this.tabPage2, e);
                cmbbs2_SelectedIndexChanged(cmbbs2, e);
            }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        //Add by jchl����������ҩ�����ݷ�ҩ�����˴�����
        private DataTable DoFilFylb(DataTable tb)
        {
            try
            {
                //Modify by jchl��������ҩ�����ݷ�ҩ�����ж�-1��ȫ��  1����ҩ����ҩ  2���÷�(ˮ���)��ҩ(����)���ˡ�
                DataTable dtCffy = tb.Clone();
                if (cmbFylb.SelectedValue.ToString().Trim().Equals("1"))
                {
                    DataRow[] drs = tb.Select("STATITEM_CODE='03' and ��ҩ='����' and �÷�='ˮ���'");
                    //DataRow[] drs = tb.Select("��ҩ<>'����' and �÷�='ˮ���' ");

                    for (int j = 0; j < drs.Length; j++)
                    {
                        tb.Rows.Remove(drs[j]);
                    }

                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        dtCffy.Rows.Add(tb.Rows[i].ItemArray);
                    }
                    //for (int i = 0; i < drs.Length; i++)
                    //{
                    //    dtCffy.Rows.Add(drs[i].ItemArray);
                    //}
                }
                else if (cmbFylb.SelectedValue.ToString().Trim().Equals("2"))
                {
                    // 
                    DataRow[] drs = tb.Select("STATITEM_CODE='03' and ��ҩ='����' and �÷�='ˮ���'");

                    for (int i = 0; i < drs.Length; i++)
                    {
                        dtCffy.Rows.Add(drs[i].ItemArray);
                    }
                }
                else if (cmbFylb.SelectedValue.ToString().Trim().Equals("-1"))
                {
                    return tb;
                }

                return dtCffy;
            }
            catch
            {
                return null;
            }
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ss);
            if (tb == null || tb.Rows.Count == 0 || tb.Rows[0]["sign"].GetType().ToString() == "System.DBNull")
                return null;
            else
                return ((byte[])tb.Rows[0]["sign"]);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJz_Click(object sender, EventArgs e)
        {
            #region Ȩ��ȷ��
            try
            {
                if ((new SystemCfg(8008)).Config == "1")
                {
                    string dlgvalue = DlgPW.Show();
                    string pwStr = dlgvalue; //YS.Password;
                    bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                    if (!bOk)
                    {
                        FrmMessageBox.Show("��û��ͨ��Ȩ��ȷ�ϣ����ܷ�ҩ��", new Font("����", 12f), Color.Red, "Sorry��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                        return;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            this.Cursor = PubStaticFun.WaitCursor();

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataTable tbsel = tb.Clone();
            try
            {
                DataRow[] selrow = tb.Select("��ҩ='��'");
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tbsel.ImportRow(selrow[i]);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            if (tbsel.Rows.Count == 0)
            {
                MessageBox.Show("û��Ҫ���˵�ҩƷ��¼��");
                this.Cursor = Cursors.Arrow;
                return;
            }

            try
            {
                //û�мǷѵļ�¼
                DataRow[] rows = tb.Select("��ҩ='��' and charge_bit='0'");
                if (rows.Length == 0)
                {
                    MessageBox.Show("û��Ҫ���˵�ҩƷ��¼��");
                    this.Cursor = Cursors.Arrow;
                    return;
                }

                string[] ssql = new string[rows.Length];

                #region ����û�мǷѵļ�¼
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    ssql[i] = "update zy_fee_speci set charge_bit=1,charge_date=getdate(),charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " where id='" + new Guid(rows[i]["zy_id"].ToString()) + "' and charge_bit=0 and delete_bit=0";
                    //Modify By Tany 2015-04-20
                    //�����pivasҩ����Ҫ��֤������ö�Ӧ��ҽ���Ƿ��Ѿ������
                    //if (isPivasYF)
                    //{
                    //    ssql[i] = "update a set a.charge_bit=1,a.charge_date=getdate(),a.charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " from zy_fee_speci a inner join zy_orderrecord b on a.order_id=b.order_id where a.id='" + new Guid(rows[i]["zy_id"].ToString()) + "' and a.charge_bit=0 and a.delete_bit=0 and b.is_pvschk=1";
                    //}
                }
                InstanceForm.BDatabase.DoCommand(null, null, null, ssql);
                #endregion

                #region ������������Ϊ�ѷ�ҩ״̬
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (tb.Rows[i]["��ҩ"].ToString().Trim() == "��")
                    {
                        //tb.Rows[i]["��ҩ"] = "��";
                        //tb.Rows[i]["��ҩ����"] = _sDate;
                        //tb.Rows[i]["��ҩԱ"] = InstanceForm.BCurrentUser.Name;
                        ////��ҩ����ʾ��ҩ������  lidan add 2013-07-01
                        //tb.Rows[i]["��ҩԱ"] = cmbpyr.Text;
                    }
                }
                this.myDataGrid1.DataSource = xcset1.TsDataTable;
                //butfy.Tag = _sDate;
                #endregion

                MessageBox.Show("���˳ɹ�", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb.Rows.Clear();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zyh = "";
            if (string.IsNullOrEmpty(txtzyh.Text.Trim()))
            {
                TrasenFrame.Forms.DlgInputBox dlgInput = new TrasenFrame.Forms.DlgInputBox("", "������סԺ�ţ�", "ͬ�����˽���״̬");
                dlgInput.NumCtrl = true;
                dlgInput.ShowDialog();
                if (DlgInputBox.DlgResult)
                {
                    zyh = DlgInputBox.DlgValue;
                }
            }

            zyh = txtzyh.Text.Trim();

          //  TrasenHIS.BLL.CheckPatientInfo.CheckPatJszt(zyh, InstanceForm.BDatabase);

        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkJzRq_CheckedChanged(object sender, EventArgs e)
        {
            dtpjzrq1.Enabled = this.chkJzRq.Checked == true ? true : false;
            dtpjzrq2.Enabled = this.chkJzRq.Checked == true ? true : false;
            if (chkJzRq.Checked)
            {
                this.chkrq.Checked = false;
            }
        }

        public DataTable SelectCFList(string fy_type, string deptid, string fy_date1, string fy_date2, string fy_date3, string fy_date4, string fybz, int bdybz, int sjbz)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "@fy_type";
                parameters[0].Value = fy_type;

                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;

                parameters[2].Text = "@fy_date1";
                parameters[2].Value = fy_date1;

                parameters[3].Text = "@fy_date2";
                parameters[3].Value = fy_date2;

                parameters[2].Text = "@fy_date3";
                parameters[2].Value = fy_date3;

                parameters[3].Text = "@fy_date4";
                parameters[3].Value = fy_date4;

                parameters[5].Text = "@fybz";
                parameters[5].Value = fybz;

                parameters[6].Text = "@bdybz";
                parameters[6].Value = bdybz;

                parameters[7].Text = "@sjbz";
                parameters[7].Value = sjbz;
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_SELECT_ZYCFFY", parameters, 30);

                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }



        private void printcf_ts(string yplx)
        {
            DataTable dt_cf = new DataTable();
            string sql_yp="";
            if (yplx == "djjsyp")
            {
                sql_yp = "select  cjid from yp_ypcjd a left join yp_ypggd b on a.ggid=b.ggid where b.djyp=1";
            }
            if (yplx == "j1mzyp")
            {
                sql_yp = "select  cjid from yp_ypcjd a left join yp_ypggd b on a.ggid=b.ggid where b.mzyp=1 or(b.jsyp=1 and jsypfl=1)";
            }
            if (yplx == "j2yp")
            {
                sql_yp = "select  cjid from yp_ypcjd a left join yp_ypggd b on a.ggid=b.ggid where b.jsyp=1 and b.jsypfl=2";
            }
            dt_cf = InstanceForm.BDatabase.GetDataTable(sql_yp);
            if (new SystemCfg(8021).Config == "0")
            {
                #region ��������ҩ
                try
                {
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    if (tb.Rows.Count == 0)
                        return;

                    DataRow[] rows;

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        rows = tb.Select("( ��ҩ='��' or ��ҩ='��') and ypsl<>0");
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                            rows = tb.Select("( ��ҩ='��') and ypsl<>0  and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        else
                            rows = tb.Select("( ��ҩ='��') and ypsl<>0");
                    }
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("û��Ҫ��ӡ���ѷ�ҩ����", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    butprint.Enabled = false;

                    //Ҫ��ӡ�Ĵ����ż���
                    string _cfh = "";
                    string[] GroupbyField1 ={ "������" };
                    string[] ComputeField1 ={ };
                    string[] CField1 ={ };
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tb;
                    DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "( ��ҩ='��' or ��ҩ='��') and ypsl<>0");
                    _cfh = "(";
                    for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                        _cfh = _cfh + tb_cfh.Rows[i]["������"].ToString() + ",";
                    _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";


                    ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                    DataRow myrow;
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        for (int m=0; m < dt_cf.Rows.Count; m++)
                        {
                            if (rows[i]["cjid"].ToString() == dt_cf.Rows[m]["cjid"].ToString())
                            {
                                myrow = Dset.��ҩ��ϸ��.NewRow();
                                myrow["rowno"] = Convert.ToString(rows[i]["���"]);
                                myrow["yppm"] = Convert.ToString(rows[i]["Ʒ��"]);
                                myrow["ypspm"] = Convert.ToString(rows[i]["��Ʒ��"]);
                                myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
                                myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                                myrow["lsj"] = Convert.ToDecimal(rows[i]["����"]);
                                myrow["ypsl"] = Convert.ToDecimal(rows[i]["����"]);
                                if (Convert.ToDecimal(rows[i]["����"]) > 1 || Convert.ToString(rows[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                    myrow["cfts"] = "����:" + rows[i]["����"].ToString() + " ��   " + rows[i]["��ҩ"].ToString();
                                myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
                                myrow["lsje"] = Convert.ToDecimal(rows[i]["���"]);
                                myrow["shh"] = Convert.ToString(rows[i]["����"]);
                                myrow["bed_no"] = Convert.ToString(rows[i]["����"]);
                                myrow["name"] = Convert.ToString(rows[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows[i]["��������"]).Trim();
                                myrow["inpatient_no"] = Convert.ToString(rows[i]["סԺ��"]);
                                myrow["lydw"] = Convert.ToString(rows[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows[i]["ҽ��"]);
                                myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows[i]["dept_id"]), InstanceForm.BDatabase);
                                myrow["presc_no"] = rows[i]["������"].ToString().Trim();
                                myrow["order_usage"] = rows[i]["�÷�"].ToString().Trim() + " " + rows[i]["Ƶ��"].ToString().Trim();
                                myrow["xb"] = Convert.ToString(rows[i]["�Ա�"]);
                                myrow["nl"] = Convert.ToString(rows[i]["����"]);
                                myrow["JTDZ"] = Convert.ToString(rows[i]["��ͥ��ַ"]);
                                myrow["LXDH"] = Convert.ToString(rows[i]["��ϵ��ʽ"]);
                                myrow["SFZH"] = Convert.ToString(rows[i]["���֤"]);
                                myrow["bz1"] = Convert.ToString(rows[i]["���"]);
                                myrow["bz2"] = Convert.ToString(rows[i]["��ҽ���"]);
                                myrow["bz3"] = Convert.ToString(rows[i]["��ҽ֢��"]);
                                myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                                //��ӡ��ҩ�ˡ���ҩ�ˡ���ҩ���ڡ�ҽ��������ҩƷ����  lidan 2013-07-01
                                myrow["fyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
                                myrow["pyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
                                myrow["fyrq"] = Convert.ToString(rows[i]["��ҩ����"]);
                                myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]);
                                myrow["ypjx"] = Convert.ToString(rows[i]["����"]);
                                myrow["jl"] = Convert.ToString(rows[i]["����"]) + Convert.ToString(rows[i]["������λ"]);

                                int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["������"].ToString().Trim() + ""));
                                bdycs = bdycs + 1;
                                myrow["bz"] = bdycs > 1 ? "(����)" : "";//��ע��ʾ������ lidan 2013-07-01
                                myrow["hwh"] = Convert.ToString(rows[i]["hwh"]);
                                myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));


                                Dset.��ҩ��ϸ��.Rows.Add(myrow);
                            }
                        }
                    }

                    ParameterEx[] parameters = new ParameterEx[2];
                    parameters[0].Text = "titletext";
                    string ss = "";
                    if (rdCydy.Checked == false)
                        ss = "סԺ�����嵥";
                    else
                        ss = "��Ժ��ҩ�嵥";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                    parameters[1].Text = "BZ";
                    parameters[1].Value = "";
                    bool bview = this.chkprintview.Checked == true ? false : true;
                    TrasenFrame.Forms.FrmReportView f;

                    string[] str ={ "" };
                    str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";
                    if (yplx == "j1mzyp")
                    {
                        if (Dset.��ҩ��ϸ��.Count > 0)
                        {
                            f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ�龫һ�����嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                            if (f.LoadReportSuccess)
                                f.Show();
                            else
                                f.Dispose();

                            butprint.Enabled = true;
                        }
                    }
                    if (yplx == "djjsyp")
                    {
                        if (Dset.��ҩ��ϸ��.Count > 0)
                        {
                            f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ���紦���嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                            if (f.LoadReportSuccess)
                                f.Show();
                            else
                                f.Dispose();

                            butprint.Enabled = true;
                        }
                    }
                    if (yplx == "j2yp")
                    {
                        if (Dset.��ҩ��ϸ��.Count > 0)
                        {
                            f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ���������嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                            if (f.LoadReportSuccess)
                                f.Show();
                            else
                                f.Dispose();

                            butprint.Enabled = true;
                        }
                    }
                    //f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥.rpt", parameters, bview);

                }
                catch (System.Exception err)
                {
                    butprint.Enabled = true;
                    MessageBox.Show(err.Message);
                }
                #endregion
            }

            else
            {
                try
                {

                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    if (tb.Rows.Count == 0)
                        return;

                    DataRow[] rows;

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        rows = tb.Select("( ��ҩ='��' or ��ҩ='��') and ypsl<>0");
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                            rows = tb.Select("( ��ҩ='��') and ypsl<>0  and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        else
                            rows = tb.Select("( ��ҩ='��') and ypsl<>0");
                    }
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("û��Ҫ��ӡ���ѷ�ҩ����", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    butprint.Enabled = false;




                    DataRow[] rows_xy = null;
                    DataRow[] rows_zy = null;
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        rows_xy = tb.Select("( ��ҩ='��' or ��ҩ='��') and ypsl<>0 and STATITEM_CODE not like '%03%' ");
                        rows_zy = tb.Select("( ��ҩ='��' or ��ҩ='��') and ypsl<>0 and STATITEM_CODE like '%03%'");
                    }
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                        {
                            rows_xy = tb.Select("( ��ҩ='��') and ypsl<>0 and STATITEM_CODE not like '%03%'  and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                            rows_zy = tb.Select("( ��ҩ='��') and ypsl<>0 and STATITEM_CODE like '%03%'   and ��ҩ����='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        }
                        else
                        {
                            rows_xy = tb.Select("( ��ҩ='��') and ypsl<>0 and STATITEM_CODE not like '%03%' ");
                            rows_zy = tb.Select("( ��ҩ='��') and ypsl<>0 and STATITEM_CODE like '%03%' ");
                        }
                    }


                    ts_Yk_ReportView.Dataset2 Dset;
                    DataRow myrow;

                    if (rows_xy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_xy.Length - 1; i++)
                        {
                            for (int m=0; m < dt_cf.Rows.Count; m++)
                            {
                                if (rows_xy[i]["cjid"].ToString() == dt_cf.Rows[m]["cjid"].ToString())
                                {
                                    myrow = Dset.��ҩ��ϸ��.NewRow();
                                    myrow["rowno"] = Convert.ToString(rows_xy[i]["���"]);
                                    myrow["yppm"] = Convert.ToString(rows_xy[i]["Ʒ��"]);
                                    myrow["ypspm"] = Convert.ToString(rows_xy[i]["��Ʒ��"]);
                                    myrow["ypgg"] = Convert.ToString(rows_xy[i]["���"]);
                                    myrow["sccj"] = Convert.ToString(rows_xy[i]["����"]);
                                    myrow["lsj"] = Convert.ToDecimal(rows_xy[i]["����"]);
                                    myrow["ypsl"] = Convert.ToDecimal(rows_xy[i]["����"]);
                                    if (Convert.ToDecimal(rows_xy[i]["����"]) > 1 || Convert.ToString(rows_xy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                        myrow["cfts"] = "����:" + rows_xy[i]["����"].ToString() + " ��   " + rows_xy[i]["��ҩ"].ToString();
                                    myrow["ypdw"] = Convert.ToString(rows_xy[i]["��λ"]);
                                    myrow["lsje"] = Convert.ToDecimal(rows_xy[i]["���"]);
                                    myrow["shh"] = Convert.ToString(rows_xy[i]["����"]);
                                    myrow["bed_no"] = Convert.ToString(rows_xy[i]["����"]);
                                    myrow["name"] = Convert.ToString(rows_xy[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows_xy[i]["��������"]).Trim();
                                    myrow["inpatient_no"] = Convert.ToString(rows_xy[i]["סԺ��"]);
                                    myrow["lydw"] = Convert.ToString(rows_xy[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows_xy[i]["ҽ��"]);
                                    myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_xy[i]["dept_id"]), InstanceForm.BDatabase);
                                    myrow["presc_no"] = rows_xy[i]["������"].ToString().Trim();
                                    myrow["order_usage"] = rows_xy[i]["�÷�"].ToString().Trim() + " " + rows_xy[i]["Ƶ��"].ToString().Trim();
                                    myrow["xb"] = Convert.ToString(rows_xy[i]["�Ա�"]);
                                    myrow["nl"] = Convert.ToString(rows_xy[i]["����"]);
                                    myrow["JTDZ"] = Convert.ToString(rows_xy[i]["��ͥ��ַ"]);
                                    myrow["LXDH"] = Convert.ToString(rows_xy[i]["��ϵ��ʽ"]);
                                    myrow["SFZH"] = Convert.ToString(rows_xy[i]["���֤"]);
                                    myrow["bz1"] = Convert.ToString(rows_xy[i]["���"]);
                                    myrow["bz2"] = Convert.ToString(rows_xy[i]["��ҽ���"]);
                                    myrow["bz3"] = Convert.ToString(rows_xy[i]["��ҽ֢��"]);
                                    myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                                    //��ӡ��ҩ�ˡ���ҩ�ˡ���ҩ���ڡ�ҽ��������ҩƷ����  lidan 2013-07-01
                                    myrow["fyr"] = Convert.ToString(rows_xy[i]["��ҩԱ"]);
                                    myrow["pyr"] = Convert.ToString(rows_xy[i]["��ҩԱ"]);
                                    myrow["fyrq"] = Convert.ToString(rows_xy[i]["��ҩ����"]);
                                    myrow["ysname"] = Convert.ToString(rows_xy[i]["ҽ��"]);
                                    myrow["ypjx"] = Convert.ToString(rows_xy[i]["����"]);
                                    myrow["jl"] = Convert.ToString(rows[i]["����"]) + Convert.ToString(rows[i]["������λ"]);
                                    int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["������"].ToString().Trim() + ""));
                                    bdycs = bdycs + 1;
                                    myrow["bz"] = bdycs > 1 ? "(����)" : "";//��ע��ʾ������ lidan 2013-07-01
                                    myrow["hwh"] = Convert.ToString(rows_xy[i]["hwh"]);
                                    myrow["image"] = GetImageByte((Convertor.IsNull(rows_xy[i]["doc_id"], "0")));


                                    Dset.��ҩ��ϸ��.Rows.Add(myrow);
                                }
                            }

                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        if (rdCydy.Checked == false)
                            ss = "סԺ�����嵥";
                        else
                            ss = "��Ժ��ҩ�嵥";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = this.chkprintview.Checked == true ? false : true;
                        TrasenFrame.Forms.FrmReportView f;

                        //Ҫ��ӡ�Ĵ����ż���
                        string _cfh = "";
                        string[] GroupbyField1 ={ "presc_no" };
                        string[] ComputeField1 ={ };
                        string[] CField1 ={ };
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = Dset.��ҩ��ϸ��;
                        DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                        _cfh = "(";
                        for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                            _cfh = _cfh + tb_cfh.Rows[i]["presc_no"].ToString() + ",";
                        _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";

                        string[] str ={ "" };
                        str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";

                        if (yplx == "j1mzyp")
                        {
                            if (Dset.��ҩ��ϸ��.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ�龫һ�����嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();

                                butprint.Enabled = true;
                            }
                        }
                        if (yplx == "djjsyp")
                        {
                            if (Dset.��ҩ��ϸ��.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ���紦���嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();

                                butprint.Enabled = true;
                            }
                        }
                        if (yplx == "j2yp")
                        {
                            if (Dset.��ҩ��ϸ��.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ���������嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();

                                butprint.Enabled = true;
                            }
                        }

                    }

                    if (rows_zy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_zy.Length - 1; i++)
                        {
                            for (int m=0; m < dt_cf.Rows.Count; m++)
                            {
                                if (rows_xy[i]["cjid"].ToString() == dt_cf.Rows[m]["cjid"].ToString())
                                {
                                    myrow = Dset.��ҩ��ϸ��.NewRow();
                                    myrow["rowno"] = Convert.ToString(rows_zy[i]["���"]);
                                    myrow["yppm"] = Convert.ToString(rows_zy[i]["Ʒ��"]);
                                    myrow["ypspm"] = Convert.ToString(rows_zy[i]["��Ʒ��"]);
                                    myrow["ypgg"] = Convert.ToString(rows_zy[i]["���"]);
                                    myrow["sccj"] = Convert.ToString(rows_zy[i]["����"]);
                                    myrow["lsj"] = Convert.ToDecimal(rows_zy[i]["����"]);
                                    myrow["ypsl"] = Convert.ToDecimal(rows_zy[i]["����"]);
                                    if (Convert.ToDecimal(rows_zy[i]["����"]) > 1 || Convert.ToString(rows_zy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                        myrow["cfts"] = "����:" + rows_zy[i]["����"].ToString() + " ��   " + rows_zy[i]["��ҩ"].ToString();
                                    myrow["ypdw"] = Convert.ToString(rows_zy[i]["��λ"]);
                                    myrow["lsje"] = Convert.ToDecimal(rows_zy[i]["���"]);
                                    myrow["shh"] = Convert.ToString(rows_zy[i]["����"]);
                                    myrow["bed_no"] = Convert.ToString(rows_zy[i]["����"]);
                                    myrow["name"] = Convert.ToString(rows_zy[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows_zy[i]["��������"]).Trim();
                                    myrow["inpatient_no"] = Convert.ToString(rows_zy[i]["סԺ��"]);
                                    myrow["lydw"] = Convert.ToString(rows_zy[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows_zy[i]["ҽ��"]);
                                    myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_zy[i]["dept_id"]), InstanceForm.BDatabase);
                                    myrow["presc_no"] = rows_zy[i]["������"].ToString().Trim();
                                    myrow["order_usage"] = rows_zy[i]["�÷�"].ToString().Trim() + " " + rows_zy[i]["Ƶ��"].ToString().Trim();
                                    myrow["xb"] = Convert.ToString(rows_zy[i]["�Ա�"]);
                                    myrow["nl"] = Convert.ToString(rows_zy[i]["����"]);
                                    myrow["JTDZ"] = Convert.ToString(rows_zy[i]["��ͥ��ַ"]);
                                    myrow["LXDH"] = Convert.ToString(rows_zy[i]["��ϵ��ʽ"]);
                                    myrow["SFZH"] = Convert.ToString(rows_zy[i]["���֤"]);
                                    myrow["bz1"] = Convert.ToString(rows_zy[i]["���"]);
                                    myrow["bz2"] = Convert.ToString(rows_zy[i]["��ҽ���"]);
                                    myrow["bz3"] = Convert.ToString(rows_zy[i]["��ҽ֢��"]);
                                    myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                                    //��ӡ��ҩ�ˡ���ҩ�ˡ���ҩ���ڡ�ҽ��������ҩƷ����  lidan 2013-07-01
                                    myrow["fyr"] = Convert.ToString(rows_zy[i]["��ҩԱ"]);
                                    myrow["pyr"] = Convert.ToString(rows_zy[i]["��ҩԱ"]);
                                    myrow["fyrq"] = Convert.ToString(rows_zy[i]["��ҩ����"]);
                                    myrow["ysname"] = Convert.ToString(rows_zy[i]["ҽ��"]);
                                    myrow["ypjx"] = Convert.ToString(rows_zy[i]["����"]);
                                    myrow["jl"] = Convert.ToString(rows[i]["����"]) + Convert.ToString(rows[i]["������λ"]);
                                    int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["������"].ToString().Trim() + ""));
                                    bdycs = bdycs + 1;
                                    myrow["bz"] = bdycs > 1 ? "(����)" : "";//��ע��ʾ������ lidan 2013-07-01
                                    myrow["hwh"] = Convert.ToString(rows_zy[i]["hwh"]);
                                    myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));


                                    Dset.��ҩ��ϸ��.Rows.Add(myrow);
                                }
                            }
                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        if (rdCydy.Checked == false)
                            ss = "סԺ�����嵥";
                        else
                            ss = "��Ժ��ҩ�嵥";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = this.chkprintview.Checked == true ? false : true;
                        TrasenFrame.Forms.FrmReportView f;


                        //Ҫ��ӡ�Ĵ����ż���
                        string _cfh = "";
                        string[] GroupbyField1 ={ "presc_no" };
                        string[] ComputeField1 ={ };
                        string[] CField1 ={ };
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = Dset.��ҩ��ϸ��;
                        DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                        _cfh = "(";
                        for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                            _cfh = _cfh + tb_cfh.Rows[i]["presc_no"].ToString() + ",";
                        _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";
                        string[] str ={ "" };
                        str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";

                        if (yplx == "j1mzyp")
                        {
                            if (Dset.��ҩ��ϸ��.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ�龫һ�����嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();
                                butprint.Enabled = true;
                            }
                        }
                        if (yplx == "djjsyp")
                        {
                            if (Dset.��ҩ��ϸ��.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ���紦���嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();
                                butprint.Enabled = true;
                            }
                        }
                        if (yplx == "j2yp")
                        {
                            if (Dset.��ҩ��ϸ��.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\ZYYF_��ҩ���������嵥.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();
                                butprint.Enabled = true;
                            }
                        }

                    }


                    butprint.Enabled = true;
                }
                catch (System.Exception err)
                {
                    butprint.Enabled = true;
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void ��ؼ��һToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printcf_ts("j1mzyp");
        }

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printcf_ts("djjsyp");
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printcf_ts("j2yp");
        }
    }
}
