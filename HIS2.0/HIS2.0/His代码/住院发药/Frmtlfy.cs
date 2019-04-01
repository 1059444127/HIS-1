using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using Ts_zyys_public;
using TrasenFrame.Forms;
using YpClass;
using System.Collections.Generic;
using System.IO;

namespace ts_yf_zyfy
{
    /// <summary>
    /// Frmyprk ��ժҪ˵����
    /// </summary>
    public class Frmtlfy : System.Windows.Forms.Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        public long _Sqdh;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeListView treeListView1;
        private System.Windows.Forms.ColumnHeader ��Ϣʱ��;
        private System.Windows.Forms.ColumnHeader ������;
        private System.Windows.Forms.ColumnHeader ��Ϣ��ע;
        private System.Windows.Forms.ColumnHeader apply_id;
        private System.Windows.Forms.ColumnHeader nurseid;
        private System.Windows.Forms.ColumnHeader dept_ly;
        private System.Windows.Forms.ColumnHeader groupid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeListView treeListView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Crownwood.Magic.Controls.TabControl tabControl2;
        private System.Windows.Forms.ComboBox cmbpyr;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtcw;
        private System.Windows.Forms.TextBox txtypmc;
        private System.Windows.Forms.TextBox txtxm;
        private System.Windows.Forms.TextBox txtzyh;
        private System.Windows.Forms.Button butmxcx;
        private System.Windows.Forms.Button butqc;
        private System.Windows.Forms.Button butref;
        private System.Windows.Forms.DateTimePicker dtptlrq2;
        private System.Windows.Forms.DateTimePicker dtptlrq1;
        private System.Windows.Forms.Button butref1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbbs2;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.TreeListView treeListView3;
        private System.Windows.Forms.ColumnHeader ��ҩ����;
        private System.Windows.Forms.ColumnHeader ��ҩ��;
        private System.Windows.Forms.ColumnHeader ��ҩ��;
        private System.Windows.Forms.ColumnHeader ���ݺ�;
        private System.Windows.Forms.ColumnHeader ���;
        private System.Windows.Forms.ColumnHeader ��ҩ��ʿ;
        private System.Windows.Forms.ColumnHeader ��ע;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.ComboBox cmbbs3;
        private System.Windows.Forms.CheckBox chkmx;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butprintmx;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butfy;
        private System.Windows.Forms.ComboBox cmbbs1;
        private System.Windows.Forms.TextBox txtbz;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGridMx;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.CheckBox chkprintview;
        private System.Windows.Forms.Button butselect;
        private System.Windows.Forms.Button butunselect;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private Panel panel9;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader8;
        private CheckBox chkkcfs;
        private CheckBox chkkccc;
        private Panel panel_dd;
        private StatusBarPanel statusBarPanel3;
        private StatusBarPanel statusBarPanel2;
        private StatusBarPanel statusBarPanel1;
        private StatusBar statusBar1;
        private Panel panel_left;
        private Splitter splitter2;
        private System.Windows.Forms.GroupBox panel_top;
        private Panel panel_chk;
        private YpConfig ss;
        bool bpcgl = false;
        private Panel panel7;
        private Panel panel13;
        private Button button1;
        private Button button3;
        private StatusBarPanel statusBarPanel4;
        private RadioButton rdAll;
        private RadioButton rdCJ;
        private RadioButton rdTL;
        private Panel panel6;
        private ComboBox comboBox1;
        private Label label3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Button btncb;

        //private CachedYF_סԺ�����嵥��ҩ cachedYF_סԺ�����嵥��ҩ1;
        private CheckBox chkAllFee;
        private CheckBox chkCharged;
        private CheckBox chkUncharge;
        private Button btCharge; //�Ƿ�������ι���

        private CachedYF_סԺ�����嵥��ҩ cachedYF_סԺ�����嵥��ҩ1;
        private DateTimePicker dateTimePicker1;
        private CheckBox checkBox4; //�Ƿ�������ι���

        string pcglfs = "0";//���ι���ʽ 0�Ƚ��ȳ� 1��Ч���ȳ�

        private bool isPivasYF = false;
        private CheckBox chkPivasCHK;
        private RadioButton rbDy;
        private RadioButton rbXydy;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;//�Ƿ�PIVASҩ�� Add By Tany 2015-04-20
        private DataTable PivasDept = new DataTable();//��¼pivas����ҵĶ�Ӧ��ϵ

        public Frmtlfy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            _Sqdh = 0;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            ss = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //

        }

        private void OrderTypeSelectionChanged(object sender, EventArgs e)
        {
            butref1_Click(sender, e);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmtlfy));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer2 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer3 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeListView1 = new System.Windows.Forms.TreeListView();
            this.��Ϣʱ�� = new System.Windows.Forms.ColumnHeader();
            this.������ = new System.Windows.Forms.ColumnHeader();
            this.��Ϣ��ע = new System.Windows.Forms.ColumnHeader();
            this.apply_id = new System.Windows.Forms.ColumnHeader();
            this.nurseid = new System.Windows.Forms.ColumnHeader();
            this.dept_ly = new System.Windows.Forms.ColumnHeader();
            this.groupid = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.chkmx = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdTL = new System.Windows.Forms.RadioButton();
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.rdCJ = new System.Windows.Forms.RadioButton();
            this.cmbbs1 = new System.Windows.Forms.ComboBox();
            this.butref1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.treeListView2 = new System.Windows.Forms.TreeListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbbs2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeListView3 = new System.Windows.Forms.TreeListView();
            this.��ҩ���� = new System.Windows.Forms.ColumnHeader();
            this.��ҩ�� = new System.Windows.Forms.ColumnHeader();
            this.���ݺ� = new System.Windows.Forms.ColumnHeader();
            this.��ע = new System.Windows.Forms.ColumnHeader();
            this.��ҩ�� = new System.Windows.Forms.ColumnHeader();
            this.��ҩ��ʿ = new System.Windows.Forms.ColumnHeader();
            this.��� = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbs3 = new System.Windows.Forms.ComboBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.butref = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtptlrq2 = new System.Windows.Forms.DateTimePicker();
            this.dtptlrq1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butfy = new System.Windows.Forms.Button();
            this.chkkccc = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkkcfs = new System.Windows.Forms.CheckBox();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkprintview = new System.Windows.Forms.CheckBox();
            this.butprintmx = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.myDataGridMx = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btncb = new System.Windows.Forms.Button();
            this.butunselect = new System.Windows.Forms.Button();
            this.butselect = new System.Windows.Forms.Button();
            this.butqc = new System.Windows.Forms.Button();
            this.butmxcx = new System.Windows.Forms.Button();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtxm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtcw = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtypmc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel_dd = new System.Windows.Forms.Panel();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.panel_chk = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel_top = new System.Windows.Forms.GroupBox();
            this.rbDy = new System.Windows.Forms.RadioButton();
            this.rbXydy = new System.Windows.Forms.RadioButton();
            this.chkPivasCHK = new System.Windows.Forms.CheckBox();
            this.chkAllFee = new System.Windows.Forms.CheckBox();
            this.chkCharged = new System.Windows.Forms.CheckBox();
            this.chkUncharge = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btCharge = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.cachedYF_סԺ�����嵥��ҩ1 = new ts_yf_zyfy.CachedYF_סԺ�����嵥��ҩ();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridMx)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel_dd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.panel_left.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 485);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl1.BoldSelectedPage = true;
            this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(273, 458);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            this.tabControl1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.TextInactiveColor = System.Drawing.Color.Black;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(273, 433);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Tag = "0";
            this.tabPage1.Title = "��ҩ��Ϣ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.treeListView1);
            this.panel5.Controls.Add(this.chkmx);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 66);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(273, 367);
            this.panel5.TabIndex = 1;
            // 
            // treeListView1
            // 
            this.treeListView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.��Ϣʱ��,
            this.������,
            this.��Ϣ��ע,
            this.apply_id,
            this.nurseid,
            this.dept_ly,
            this.groupid,
            this.columnHeader8});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeListView1.GridLines = true;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeListView1.Size = new System.Drawing.Size(273, 367);
            this.treeListView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView1.TabIndex = 3;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            this.treeListView1.Click += new System.EventHandler(this.treeListView1_Click);
            // 
            // ��Ϣʱ��
            // 
            this.��Ϣʱ��.Text = "��Ϣʱ��";
            this.��Ϣʱ��.Width = 194;
            // 
            // ������
            // 
            this.������.Text = "������";
            this.������.Width = 67;
            // 
            // ��Ϣ��ע
            // 
            this.��Ϣ��ע.Text = "��Ϣ��ע";
            this.��Ϣ��ע.Width = 95;
            // 
            // apply_id
            // 
            this.apply_id.Text = "apply_id";
            this.apply_id.Width = 0;
            // 
            // nurseid
            // 
            this.nurseid.Text = "nurseid";
            this.nurseid.Width = 0;
            // 
            // dept_ly
            // 
            this.dept_ly.Text = "dept_ly";
            this.dept_ly.Width = 0;
            // 
            // groupid
            // 
            this.groupid.Text = "groupid";
            this.groupid.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "lyflcode";
            this.columnHeader8.Width = 0;
            // 
            // chkmx
            // 
            this.chkmx.AutoSize = true;
            this.chkmx.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkmx.ForeColor = System.Drawing.Color.Black;
            this.chkmx.Location = new System.Drawing.Point(199, 0);
            this.chkmx.Name = "chkmx";
            this.chkmx.Size = new System.Drawing.Size(48, 16);
            this.chkmx.TabIndex = 12;
            this.chkmx.Text = "��ϸ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.cmbbs1);
            this.panel4.Controls.Add(this.butref1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(273, 66);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rdTL);
            this.panel6.Controls.Add(this.rdAll);
            this.panel6.Controls.Add(this.rdCJ);
            this.panel6.Location = new System.Drawing.Point(9, 39);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(189, 24);
            this.panel6.TabIndex = 12;
            // 
            // rdTL
            // 
            this.rdTL.AutoSize = true;
            this.rdTL.Checked = true;
            this.rdTL.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTL.Location = new System.Drawing.Point(3, 3);
            this.rdTL.Name = "rdTL";
            this.rdTL.Size = new System.Drawing.Size(56, 20);
            this.rdTL.TabIndex = 9;
            this.rdTL.TabStop = true;
            this.rdTL.Text = "ͳ��";
            this.rdTL.UseVisualStyleBackColor = true;
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAll.Location = new System.Drawing.Point(127, 2);
            this.rdAll.Name = "rdAll";
            this.rdAll.Size = new System.Drawing.Size(56, 20);
            this.rdAll.TabIndex = 11;
            this.rdAll.Text = "ȫ��";
            this.rdAll.UseVisualStyleBackColor = true;
            // 
            // rdCJ
            // 
            this.rdCJ.AutoSize = true;
            this.rdCJ.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCJ.Location = new System.Drawing.Point(65, 2);
            this.rdCJ.Name = "rdCJ";
            this.rdCJ.Size = new System.Drawing.Size(56, 20);
            this.rdCJ.TabIndex = 10;
            this.rdCJ.Text = "���";
            this.rdCJ.UseVisualStyleBackColor = true;
            // 
            // cmbbs1
            // 
            this.cmbbs1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbbs1.Location = new System.Drawing.Point(50, 14);
            this.cmbbs1.Name = "cmbbs1";
            this.cmbbs1.Size = new System.Drawing.Size(217, 21);
            this.cmbbs1.TabIndex = 3;
            this.cmbbs1.SelectedIndexChanged += new System.EventHandler(this.cmbbs1_SelectedIndexChanged);
            // 
            // butref1
            // 
            this.butref1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butref1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butref1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butref1.ForeColor = System.Drawing.Color.Navy;
            this.butref1.Location = new System.Drawing.Point(199, 39);
            this.butref1.Name = "butref1";
            this.butref1.Size = new System.Drawing.Size(68, 24);
            this.butref1.TabIndex = 2;
            this.butref1.Text = "ˢ��";
            this.butref1.Click += new System.EventHandler(this.butref1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "����";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel10);
            this.tabPage2.Controls.Add(this.panel11);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(273, 433);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Tag = "1";
            this.tabPage2.Title = "��ҩ��Ϣ";
            this.tabPage2.Visible = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.treeListView2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 88);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(273, 345);
            this.panel10.TabIndex = 3;
            // 
            // treeListView2
            // 
            this.treeListView2.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.treeListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9});
            treeListViewItemCollectionComparer2.Column = 0;
            treeListViewItemCollectionComparer2.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView2.Comparer = treeListViewItemCollectionComparer2;
            this.treeListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView2.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeListView2.GridLines = true;
            this.treeListView2.Location = new System.Drawing.Point(0, 0);
            this.treeListView2.Name = "treeListView2";
            this.treeListView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeListView2.Size = new System.Drawing.Size(273, 345);
            this.treeListView2.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView2.TabIndex = 4;
            this.treeListView2.UseCompatibleStateImageBehavior = false;
            this.treeListView2.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            this.treeListView2.Click += new System.EventHandler(this.treeListView1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "��Ϣʱ��";
            this.columnHeader1.Width = 168;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "������";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "��Ϣ��ע";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "apply_id";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "nurseid";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "dept_ly";
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "groupid";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "lyflcode";
            this.columnHeader9.Width = 0;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.Control;
            this.panel11.Controls.Add(this.button1);
            this.panel11.Controls.Add(this.button3);
            this.panel11.Controls.Add(this.cmbbs2);
            this.panel11.Controls.Add(this.label11);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(273, 88);
            this.panel11.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(224, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "����";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(224, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 24);
            this.button3.TabIndex = 5;
            this.button3.Text = "ˢ��";
            // 
            // cmbbs2
            // 
            this.cmbbs2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbs2.Location = new System.Drawing.Point(50, 14);
            this.cmbbs2.Name = "cmbbs2";
            this.cmbbs2.Size = new System.Drawing.Size(165, 21);
            this.cmbbs2.TabIndex = 0;
            this.cmbbs2.SelectedIndexChanged += new System.EventHandler(this.cmbbs2_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(9, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "����";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(273, 433);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Tag = "2";
            this.tabPage3.Title = "��ʷͳ�쵥��";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeListView3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 141);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 292);
            this.panel3.TabIndex = 1;
            // 
            // treeListView3
            // 
            this.treeListView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.��ҩ����,
            this.��ҩ��,
            this.���ݺ�,
            this.��ע,
            this.��ҩ��,
            this.��ҩ��ʿ,
            this.���});
            treeListViewItemCollectionComparer3.Column = 0;
            treeListViewItemCollectionComparer3.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView3.Comparer = treeListViewItemCollectionComparer3;
            this.treeListView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView3.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListView3.GridLines = true;
            this.treeListView3.Location = new System.Drawing.Point(0, 0);
            this.treeListView3.Name = "treeListView3";
            this.treeListView3.Size = new System.Drawing.Size(273, 292);
            this.treeListView3.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView3.TabIndex = 1;
            this.treeListView3.UseCompatibleStateImageBehavior = false;
            this.treeListView3.Click += new System.EventHandler(this.treeListView3_Click);
            // 
            // ��ҩ����
            // 
            this.��ҩ����.Text = "��ҩ����";
            this.��ҩ����.Width = 188;
            // 
            // ��ҩ��
            // 
            this.��ҩ��.Text = "��ҩ��";
            // 
            // ���ݺ�
            // 
            this.���ݺ�.Text = "���ݺ�";
            this.���ݺ�.Width = 55;
            // 
            // ��ע
            // 
            this.��ע.Text = "��ע";
            this.��ע.Width = 100;
            // 
            // ��ҩ��
            // 
            this.��ҩ��.Text = "��ҩ��";
            // 
            // ��ҩ��ʿ
            // 
            this.��ҩ��ʿ.Text = "��ҩ��ʿ";
            // 
            // ���
            // 
            this.���.Text = "���";
            this.���.Width = 65;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmbbs3);
            this.panel2.Controls.Add(this.cmbtype);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.butref);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtptlrq2);
            this.panel2.Controls.Add(this.dtptlrq1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 141);
            this.panel2.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "ȫ��",
            "����ҽ��",
            "��ʱҽ��"});
            this.comboBox1.Location = new System.Drawing.Point(72, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(122, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "ҽ������";
            // 
            // cmbbs3
            // 
            this.cmbbs3.Location = new System.Drawing.Point(72, 59);
            this.cmbbs3.Name = "cmbbs3";
            this.cmbbs3.Size = new System.Drawing.Size(122, 21);
            this.cmbbs3.TabIndex = 11;
            this.cmbbs3.SelectedIndexChanged += new System.EventHandler(this.cmbbs3_SelectedIndexChanged);
            // 
            // cmbtype
            // 
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.Items.AddRange(new object[] {
            "ȫ��",
            "ͳ��",
            "��ҩ"});
            this.cmbtype.Location = new System.Drawing.Point(72, 86);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(122, 21);
            this.cmbtype.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 10;
            this.label12.Text = "ͳ������";
            // 
            // butref
            // 
            this.butref.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butref.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butref.ForeColor = System.Drawing.Color.Navy;
            this.butref.Location = new System.Drawing.Point(200, 85);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(67, 49);
            this.butref.TabIndex = 8;
            this.butref.Text = "ˢ��(&F)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "����";
            // 
            // dtptlrq2
            // 
            this.dtptlrq2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtptlrq2.Location = new System.Drawing.Point(72, 32);
            this.dtptlrq2.Name = "dtptlrq2";
            this.dtptlrq2.Size = new System.Drawing.Size(195, 21);
            this.dtptlrq2.TabIndex = 5;
            // 
            // dtptlrq1
            // 
            this.dtptlrq1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtptlrq1.Location = new System.Drawing.Point(72, 5);
            this.dtptlrq1.Name = "dtptlrq1";
            this.dtptlrq1.Size = new System.Drawing.Size(195, 21);
            this.dtptlrq1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "����";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(273, 458);
            this.panel1.TabIndex = 4;
            // 
            // txtbz
            // 
            this.txtbz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbz.Location = new System.Drawing.Point(188, 5);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(151, 21);
            this.txtbz.TabIndex = 8;
            // 
            // butquit
            // 
            this.butquit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butquit.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(737, 3);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(66, 28);
            this.butquit.TabIndex = 7;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butprint.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(479, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(66, 28);
            this.butprint.TabIndex = 5;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butfy
            // 
            this.butfy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butfy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butfy.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butfy.ForeColor = System.Drawing.Color.Navy;
            this.butfy.Location = new System.Drawing.Point(412, 3);
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size(66, 28);
            this.butfy.TabIndex = 4;
            this.butfy.Text = "��ҩ(&O)";
            this.butfy.Click += new System.EventHandler(this.butfy_Click);
            // 
            // chkkccc
            // 
            this.chkkccc.AutoSize = true;
            this.chkkccc.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkkccc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkkccc.Location = new System.Drawing.Point(278, 17);
            this.chkkccc.Name = "chkkccc";
            this.chkkccc.Size = new System.Drawing.Size(234, 16);
            this.chkkccc.TabIndex = 9;
            this.chkkccc.Text = "����ҩ�����ڿ��ʱ,����������ϸ��ѡ";
            this.chkkccc.UseVisualStyleBackColor = true;
            this.chkkccc.CheckedChanged += new System.EventHandler(this.chkkccc_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(147, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "��ע";
            // 
            // chkkcfs
            // 
            this.chkkcfs.AutoSize = true;
            this.chkkcfs.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkkcfs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkkcfs.Location = new System.Drawing.Point(9, 17);
            this.chkkcfs.Name = "chkkcfs";
            this.chkkcfs.Size = new System.Drawing.Size(258, 16);
            this.chkkcfs.TabIndex = 8;
            this.chkkcfs.Text = "����ҩ���ܱ���ҩ�ֿ�ʱ,����������ϸ��ѡ";
            this.chkkcfs.UseVisualStyleBackColor = true;
            this.chkkcfs.CheckedChanged += new System.EventHandler(this.chkkcfs_CheckedChanged);
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point(61, 5);
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size(80, 20);
            this.cmbpyr.TabIndex = 1;
            this.cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "��ҩ��";
            // 
            // chkprintview
            // 
            this.chkprintview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkprintview.AutoSize = true;
            this.chkprintview.Checked = true;
            this.chkprintview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkprintview.Location = new System.Drawing.Point(650, 8);
            this.chkprintview.Name = "chkprintview";
            this.chkprintview.Size = new System.Drawing.Size(84, 16);
            this.chkprintview.TabIndex = 18;
            this.chkprintview.Text = "��ӡʱԤ��";
            // 
            // butprintmx
            // 
            this.butprintmx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butprintmx.ContextMenuStrip = this.contextMenuStrip1;
            this.butprintmx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butprintmx.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprintmx.ForeColor = System.Drawing.Color.Navy;
            this.butprintmx.Location = new System.Drawing.Point(546, 3);
            this.butprintmx.Name = "butprintmx";
            this.butprintmx.Size = new System.Drawing.Size(98, 28);
            this.butprintmx.TabIndex = 6;
            this.butprintmx.Text = "��ӡ��ϸ(&M)";
            this.butprintmx.Visible = false;
            this.butprintmx.Click += new System.EventHandler(this.butprintmx_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "�����ϸ";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SelectedTab = this.tabPage4;
            this.tabControl2.Size = new System.Drawing.Size(805, 335);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4});
            this.tabControl2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.TextInactiveColor = System.Drawing.Color.Black;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage4.Controls.Add(this.panel9);
            this.tabPage4.Controls.Add(this.panel8);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(805, 310);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Title = "��Ϣ��ϸ";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.myDataGridMx);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 40);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(805, 270);
            this.panel9.TabIndex = 2;
            // 
            // myDataGridMx
            // 
            this.myDataGridMx.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myDataGridMx.CaptionVisible = false;
            this.myDataGridMx.DataMember = "";
            this.myDataGridMx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridMx.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGridMx.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGridMx.Location = new System.Drawing.Point(0, 0);
            this.myDataGridMx.Name = "myDataGridMx";
            this.myDataGridMx.ReadOnly = true;
            this.myDataGridMx.SelectionForeColor = System.Drawing.Color.Aquamarine;
            this.myDataGridMx.Size = new System.Drawing.Size(805, 270);
            this.myDataGridMx.TabIndex = 0;
            this.myDataGridMx.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGridMx.DoubleClick += new System.EventHandler(this.myDataGridMx_DoubleClick_1);
            this.myDataGridMx.Click += new System.EventHandler(this.myDataGridMx_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGridMx;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 10;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.btncb);
            this.panel8.Controls.Add(this.butunselect);
            this.panel8.Controls.Add(this.butselect);
            this.panel8.Controls.Add(this.butqc);
            this.panel8.Controls.Add(this.butmxcx);
            this.panel8.Controls.Add(this.txtzyh);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.txtxm);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.txtcw);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.txtypmc);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(805, 40);
            this.panel8.TabIndex = 1;
            // 
            // btncb
            // 
            this.btncb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncb.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncb.ForeColor = System.Drawing.Color.Navy;
            this.btncb.Location = new System.Drawing.Point(699, 6);
            this.btncb.Name = "btncb";
            this.btncb.Size = new System.Drawing.Size(45, 27);
            this.btncb.TabIndex = 12;
            this.btncb.Text = "�ذ�";
            this.btncb.Click += new System.EventHandler(this.btncb_Click);
            // 
            // butunselect
            // 
            this.butunselect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butunselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butunselect.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butunselect.ForeColor = System.Drawing.Color.Yellow;
            this.butunselect.Location = new System.Drawing.Point(40, 7);
            this.butunselect.Name = "butunselect";
            this.butunselect.Size = new System.Drawing.Size(40, 27);
            this.butunselect.TabIndex = 11;
            this.butunselect.Text = "��ѡ";
            this.butunselect.UseVisualStyleBackColor = false;
            this.butunselect.Click += new System.EventHandler(this.butunselect_Click);
            // 
            // butselect
            // 
            this.butselect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butselect.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butselect.ForeColor = System.Drawing.Color.Yellow;
            this.butselect.Location = new System.Drawing.Point(0, 7);
            this.butselect.Name = "butselect";
            this.butselect.Size = new System.Drawing.Size(40, 27);
            this.butselect.TabIndex = 10;
            this.butselect.Text = "ȫѡ";
            this.butselect.UseVisualStyleBackColor = false;
            this.butselect.Click += new System.EventHandler(this.butselect_Click);
            // 
            // butqc
            // 
            this.butqc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butqc.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butqc.ForeColor = System.Drawing.Color.Navy;
            this.butqc.Location = new System.Drawing.Point(653, 6);
            this.butqc.Name = "butqc";
            this.butqc.Size = new System.Drawing.Size(45, 27);
            this.butqc.TabIndex = 9;
            this.butqc.Text = "���";
            this.butqc.Click += new System.EventHandler(this.butqc_Click);
            // 
            // butmxcx
            // 
            this.butmxcx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butmxcx.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butmxcx.ForeColor = System.Drawing.Color.Navy;
            this.butmxcx.Location = new System.Drawing.Point(606, 6);
            this.butmxcx.Name = "butmxcx";
            this.butmxcx.Size = new System.Drawing.Size(45, 27);
            this.butmxcx.TabIndex = 4;
            this.butmxcx.Text = "��ѯ";
            this.butmxcx.Click += new System.EventHandler(this.butmxcx_Click);
            // 
            // txtzyh
            // 
            this.txtzyh.Location = new System.Drawing.Point(491, 8);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(113, 23);
            this.txtzyh.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(443, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "סԺ��";
            // 
            // txtxm
            // 
            this.txtxm.Location = new System.Drawing.Point(379, 8);
            this.txtxm.Name = "txtxm";
            this.txtxm.Size = new System.Drawing.Size(64, 23);
            this.txtxm.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(347, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "����";
            // 
            // txtcw
            // 
            this.txtcw.Location = new System.Drawing.Point(307, 8);
            this.txtcw.Name = "txtcw";
            this.txtcw.Size = new System.Drawing.Size(40, 23);
            this.txtcw.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(275, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "����";
            // 
            // txtypmc
            // 
            this.txtypmc.Location = new System.Drawing.Point(147, 8);
            this.txtypmc.Name = "txtypmc";
            this.txtypmc.Size = new System.Drawing.Size(128, 23);
            this.txtypmc.TabIndex = 0;
            this.txtypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(83, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "ҩƷ����";
            // 
            // panel_dd
            // 
            this.panel_dd.Controls.Add(this.statusBar1);
            this.panel_dd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_dd.Location = new System.Drawing.Point(3, 458);
            this.panel_dd.Name = "panel_dd";
            this.panel_dd.Size = new System.Drawing.Size(1082, 27);
            this.panel_dd.TabIndex = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar1.Location = new System.Drawing.Point(0, 0);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1082, 27);
            this.statusBar1.TabIndex = 0;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 200;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 200;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 465;
            // 
            // panel_chk
            // 
            this.panel_chk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_chk.Location = new System.Drawing.Point(3, 62);
            this.panel_chk.Name = "panel_chk";
            this.panel_chk.Size = new System.Drawing.Size(799, 24);
            this.panel_chk.TabIndex = 1;
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel1);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(3, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(273, 458);
            this.panel_left.TabIndex = 8;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(276, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(4, 458);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.rbDy);
            this.panel_top.Controls.Add(this.rbXydy);
            this.panel_top.Controls.Add(this.chkPivasCHK);
            this.panel_top.Controls.Add(this.chkAllFee);
            this.panel_top.Controls.Add(this.chkCharged);
            this.panel_top.Controls.Add(this.chkUncharge);
            this.panel_top.Controls.Add(this.checkBox4);
            this.panel_top.Controls.Add(this.dateTimePicker1);
            this.panel_top.Controls.Add(this.checkBox3);
            this.panel_top.Controls.Add(this.checkBox2);
            this.panel_top.Controls.Add(this.checkBox1);
            this.panel_top.Controls.Add(this.chkkcfs);
            this.panel_top.Controls.Add(this.chkkccc);
            this.panel_top.Controls.Add(this.panel_chk);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(280, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(805, 89);
            this.panel_top.TabIndex = 10;
            this.panel_top.TabStop = false;
            this.panel_top.Text = "����ѡ��";
            // 
            // rbDy
            // 
            this.rbDy.AutoSize = true;
            this.rbDy.Location = new System.Drawing.Point(313, 38);
            this.rbDy.Name = "rbDy";
            this.rbDy.Size = new System.Drawing.Size(29, 16);
            this.rbDy.TabIndex = 19;
            this.rbDy.Text = "=";
            this.rbDy.UseVisualStyleBackColor = true;
            // 
            // rbXydy
            // 
            this.rbXydy.AutoSize = true;
            this.rbXydy.Checked = true;
            this.rbXydy.Location = new System.Drawing.Point(275, 38);
            this.rbXydy.Name = "rbXydy";
            this.rbXydy.Size = new System.Drawing.Size(35, 16);
            this.rbXydy.TabIndex = 18;
            this.rbXydy.TabStop = true;
            this.rbXydy.Text = "<=";
            this.rbXydy.UseVisualStyleBackColor = true;
            // 
            // chkPivasCHK
            // 
            this.chkPivasCHK.AutoSize = true;
            this.chkPivasCHK.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPivasCHK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkPivasCHK.Location = new System.Drawing.Point(518, 15);
            this.chkPivasCHK.Name = "chkPivasCHK";
            this.chkPivasCHK.Size = new System.Drawing.Size(174, 16);
            this.chkPivasCHK.TabIndex = 17;
            this.chkPivasCHK.Text = "��ҩʱ����֤PIVAS���״̬";
            this.chkPivasCHK.UseVisualStyleBackColor = true;
            // 
            // chkAllFee
            // 
            this.chkAllFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAllFee.AutoSize = true;
            this.chkAllFee.Location = new System.Drawing.Point(595, 38);
            this.chkAllFee.Name = "chkAllFee";
            this.chkAllFee.Size = new System.Drawing.Size(72, 16);
            this.chkAllFee.TabIndex = 15;
            this.chkAllFee.Text = "ȫ������";
            this.chkAllFee.UseVisualStyleBackColor = true;
            this.chkAllFee.CheckedChanged += new System.EventHandler(this.chkAllFee_CheckedChanged);
            // 
            // chkCharged
            // 
            this.chkCharged.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCharged.AutoSize = true;
            this.chkCharged.Location = new System.Drawing.Point(733, 38);
            this.chkCharged.Name = "chkCharged";
            this.chkCharged.Size = new System.Drawing.Size(60, 16);
            this.chkCharged.TabIndex = 14;
            this.chkCharged.Text = "�Ѽ���";
            this.chkCharged.UseVisualStyleBackColor = true;
            this.chkCharged.CheckedChanged += new System.EventHandler(this.chkCharged_CheckedChanged);
            // 
            // chkUncharge
            // 
            this.chkUncharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUncharge.AutoSize = true;
            this.chkUncharge.Location = new System.Drawing.Point(670, 38);
            this.chkUncharge.Name = "chkUncharge";
            this.chkUncharge.Size = new System.Drawing.Size(60, 16);
            this.chkUncharge.TabIndex = 13;
            this.chkUncharge.Text = "δ����";
            this.chkUncharge.UseVisualStyleBackColor = true;
            this.chkUncharge.CheckedChanged += new System.EventHandler(this.chkUncharge_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(197, 38);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(78, 16);
            this.checkBox4.TabIndex = 16;
            this.checkBox4.Text = "��������:";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(344, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(9, 38);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "ȫ��ҽ��";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.VisibleChanged += new System.EventHandler(this.checkBox3_VisibleChanged);
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(133, 38);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "����";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(83, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "����";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btCharge);
            this.panel7.Controls.Add(this.txtbz);
            this.panel7.Controls.Add(this.butfy);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.butquit);
            this.panel7.Controls.Add(this.butprintmx);
            this.panel7.Controls.Add(this.cmbpyr);
            this.panel7.Controls.Add(this.butprint);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.chkprintview);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(280, 424);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(805, 34);
            this.panel7.TabIndex = 12;
            // 
            // btCharge
            // 
            this.btCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCharge.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCharge.ForeColor = System.Drawing.Color.Navy;
            this.btCharge.Location = new System.Drawing.Point(345, 3);
            this.btCharge.Name = "btCharge";
            this.btCharge.Size = new System.Drawing.Size(66, 28);
            this.btCharge.TabIndex = 19;
            this.btCharge.Text = "����(&C)";
            this.btCharge.Click += new System.EventHandler(this.btCharge_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tabControl2);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(280, 89);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(805, 335);
            this.panel13.TabIndex = 13;
            // 
            // Frmtlfy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1085, 485);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_dd);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Frmtlfy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ҩƷͳ��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmtlfy_Load);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridMx)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel_dd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.panel_left.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        Point cbxfirstPoint;
        Point dtpfirstPoint;
        private void Frmtlfy_Load(object sender, System.EventArgs e)
        {
            try
            {
                //��ʼ����ҩ��ϸ
                CshMxGrid(this.myDataGridMx);
                if (ss.����������ʾ��Ʒ�� == true)
                    this.myDataGridMx.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 120;
                else
                    this.myDataGridMx.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 0;
                //��Ӳ����б�
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_bq")
                {
                    Yp.AddcmbWardDept(cmbbs1, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs2, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs3, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                }
                else
                {
                    Yp.AddcmbWardDept(cmbbs1, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs2, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs3, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                }

                //Add By Tany 2015-05-04 ����ǽ����ˣ���ҩ��ť���ɼ�
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_jz"
                    || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz")
                {
                    butfy.Visible = false;
                }

                this.cmbbs1.SelectedIndex = 0;
                this.cmbbs2.SelectedIndex = 0;
                this.cmbbs3.SelectedIndex = 0;
                this.cmbtype.SelectedIndex = 0;


                //�����ҩ��
                Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, cmbpyr, InstanceForm.BDatabase);
                cmbpyr.SelectedValue = Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId);


                this.dtptlrq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                this.dtptlrq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                string fs = ApiFunction.GetIniString("סԺͳ�췢ҩͳ��ѡ��", "��ҩ�ֿ۲���ʱ�������ֵ���ϸ�Զ���ѡ", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (fs == "��")
                    chkkcfs.Checked = true;
                string cc = ApiFunction.GetIniString("סԺͳ�췢ҩͳ��ѡ��", "��ҩ�����ڿ����ʱ�������ֵ���ϸ�Զ���ѡ", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (cc == "��")
                    chkkccc.Checked = true;

                bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//�������ι���
                SystemCfg cfg8051 = new SystemCfg(8051);
                if (cfg8051.Config == "1")
                {
                    pcglfs = "1";
                }
                tabControl1.SelectedTab = this.tabPage1;
                btncb.Enabled = false;
                checkBox4.Checked = false;
                dateTimePicker1.Value = DateTime.Now;
                cbxfirstPoint = checkBox4.Location;
                dtpfirstPoint = dateTimePicker1.Location;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

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

            cmbbs3.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbbs3.Text == "")
                    {
                        cmbbs3.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm,b.ward_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
                    ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Ward_Id", "Name", "pym", "wbm" },
                                                                                       new string[] { "����", "����", "ƴ����", "�����", "���" },
                                                                                       new string[] { "Ward_Id", "Name", "PYM", "WBM", "Dept_id" }, new int[] { 80, 150, 80, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs3;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs3.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs3.Text = "";
                        cmbbs3.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };

            rdTL.CheckedChanged += new EventHandler(butref1_Click);
            rdCJ.CheckedChanged += new EventHandler(butref1_Click);
            rdAll.CheckedChanged += new EventHandler(butref1_Click);

            //Modify By Tany 2015-04-20
            CheckIsPivasYF();

            //Modify By jchl 2016-08-23
            if (isPivasYF)
            {
                //Pivas ���μ��˰�ť   ����������bug��ת�����תסԺҩ����ҩ�ӿɼ��ˡ�
                btCharge.Visible = false;
            }
        }

        //Add By Tany 2015-04-20 ����Ƿ�pivasҩ��
        private void CheckIsPivasYF()
        {
            string sql = "";
            try
            {
                sql = "select * from JC_DEPT_DRUGSTORE where is_PvsRel=1 and DELETE_BIT=0 and DRUGSTORE_ID=" + InstanceForm.BCurrentDept.DeptId;
                PivasDept = InstanceForm.BDatabase.GetDataTable(sql); //Modify By Tany 2015-04-21 �����һ����datatable
                if (PivasDept != null && PivasDept.Rows.Count > 0)
                {
                    isPivasYF = true;
                }
                else
                {
                    isPivasYF = false;
                }
            }
            catch (Exception ex)
            {
                isPivasYF = false;
                MessageBox.Show("��ȡPIVAS������Ϣʱ�������飡\r\n\r\n" + sql);
            }
        }


        //��ʼ����ҩ��ϸ
        private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        {
            #region ���ͳ����ϸ����

            xcjwDataGrid.TableStyles[0].GridColumnStyles.Clear();

            #region
            List<ColumnDefine> columns = new List<ColumnDefine>();
            columns.Add(PubClass.NewColumnDefine("���", "���", 45, true, 0));
            columns.Add(PubClass.NewColumnDefine("ѡ��", "ѡ��", 35, false, 1));
            columns.Add(PubClass.NewColumnDefine("����", "����", 35, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("סԺ��", "סԺ��", 80, true, 0));
            columns.Add(PubClass.NewColumnDefine("�Ա�", "�Ա�", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ҽ������", "ҽ������", 45, true, 0));
            columns.Add(PubClass.NewColumnDefine("Ʒ��", "Ʒ��", 120, true, 0));
            columns.Add(PubClass.NewColumnDefine("��Ʒ��", "��Ʒ��", 120, true, 0));
            columns.Add(PubClass.NewColumnDefine("���", "���", 90, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 55, true, 0));
            //columns.Add(PubClass.NewColumnDefine("�����", "�����", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 50, true, 0));
            columns.Add(PubClass.NewColumnDefine("��λ", "��λ", 40, true, 0));
            columns.Add(PubClass.NewColumnDefine("ȱҩ", "ȱҩ", 0, true, 2));
            columns.Add(PubClass.NewColumnDefine("ת��", "ת��", 0, true, 2));
            columns.Add(PubClass.NewColumnDefine("�����", "�����", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("���", "���", 50, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_id", "dept_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("apply_id", "apply_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("apply_date", "apply_date", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("charge_bit", "charge_bit", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_ly", "dept_ly", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("zy_id", "zy_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("unitrate", "unitrate", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ypsl", "ypsl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("zxdw", "zxdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("������", "������", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("�������", "�������", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("�÷�", "�÷�", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("Ƶ��", "Ƶ��", 50, true, 0));
            columns.Add(PubClass.NewColumnDefine("ryrq", "ryrq", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("��λ��", "��λ��", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("lyflcode", "lyflcode", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("lsj", "lsj", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("��������", "��������", 80, true, 0));
            columns.Add(PubClass.NewColumnDefine("kcid", "kcid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("Ӣ����", "Ӣ����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cz_id", "cz_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("�շ�����", "�շ�����", 80, true, 0));//Modify By Tany 2015-03-17 �ų��շ�����
            columns.Add(PubClass.NewColumnDefine("�շ�Աid", "�շ�Աid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("�ܴ�ҽ��id", "�ܴ�ҽ��id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ҽ�����", "ҽ�����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����id", "����id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ҽ������", "ҽ������", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ִ�п���id", "ִ�п���id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("���˿���id", "���˿���id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("��������id", "��������id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����ҽ��id", "����ҽ��id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("jlzxdw", "jlzxdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ypdw", "ypdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("סԺid", "סԺid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("Ӥ��id", "Ӥ��id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("���־", "���־", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("������λ", "������λ", 0, true, 0));
            //update code pengy 2015-1-2
            columns.Add(PubClass.NewColumnDefine("��ҩ��ʽ", "��ҩ��ʽ", 80, true, 0));
            columns.Add(PubClass.NewColumnDefine("groupid", "groupid", 0, true, 0));
            #endregion

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";
            this.butprintmx.Visible = true;
            int index = 0;
            foreach (ColumnDefine cd in columns)
            {
                #region �ı���
                if (cd.ColBoolButton == 0)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "";
                    colText.ReadOnly = cd.ColReadOnly;
                    colText.TextBox.Visible = false;
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGridMx_colText_CheckCellEnabled);

                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol;
                    if (cd.MappingName.Trim() == "ypsl" || cd.MappingName == "���" || cd.MappingName == "�������")
                        datacol = new DataColumn(cd.MappingName, Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(cd.MappingName);

                    dtTmp.Columns.Add(datacol);
                }
                #endregion

                #region ������
                if (cd.ColBoolButton == 1)
                {
                    DataGridEnableBoolColumn colText = new DataGridEnableBoolColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "0";
                    colText.AllowNull = false;
                    colText.NullValue = ((short)(0));
                    colText.FalseValue = ((short)(0));
                    colText.TrueValue = ((short)(1));
                    colText.ReadOnly = cd.ColReadOnly;
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableBoolColumn.EnableCellEventHandler(myDataGridMx_colText_CheckCellEnabled);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    dtTmp.Columns.Add(cd.MappingName, Type.GetType("System.Int16"));
                }
                #endregion

                #region ��ť��
                if (cd.ColBoolButton == 2)
                {
                    DataGridButtonColumn btnCol = new DataGridButtonColumn(index);
                    btnCol.Dispose();
                    btnCol.HeaderText = cd.HeaderText;
                    btnCol.MappingName = cd.MappingName;
                    btnCol.Width = cd.ColWidth;
                    btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);
                    xcjwDataGrid.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
                    xcjwDataGrid.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);

                    DataColumn datacol;
                    datacol = new DataColumn(cd.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                #endregion

                index++;
            }

            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbmx";

            #endregion



        }

        //�����Ϣ��
        private void AddMssageTree(int dept_ly, System.Windows.Forms.TreeListView treeListView, Crownwood.Magic.Controls.TabPage Tabpage)
        {
            treeListView.Items.Clear();
            DataTable mytb = (DataTable)this.myDataGridMx.DataSource;
            mytb.Rows.Clear();
            //��ȡ�����б�
            string ssql = @" select name,a.dept_id,a.d_code from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;
            if (dept_ly > 0)
                ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'999999999')";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

            SystemCfg cfg = new SystemCfg(8004); //סԺͳ�췢ҩ��Ϣ���Ƿ��Զ�չ��  0 ��չ����1չ��
            //��ȡ��ҩ��Ϣ
            DataTable tab = ZY_FY.SelectMassage(dept_ly, InstanceForm.BCurrentDept.DeptId, 0, "", Convert.ToInt32(Tabpage.Tag), _menuTag.Function_Name, InstanceForm.BDatabase);

            if (rdTL.Checked || rdCJ.Checked)
            {
                int msgType = 0;
                if (rdTL.Checked == false && rdCJ.Checked == true)
                    msgType = 1;
                DataRow[] datalist = tab.Select(string.Format(" msg_type = {0}", msgType));
                DataTable newTable = tab.Clone();
                foreach (DataRow dr in datalist)
                {
                    newTable.Rows.Add(dr.ItemArray);
                }
                tab = newTable;
            }

            #region �������Ϣ�Ĳ�������Ϣ
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                DataRow[] rows = tab.Select(string.Format("dept_ly={0}", tb.Rows[i]["dept_id"]));

                treeListView.SmallImageList = imageList1;
                //��Ӳ���
                TreeListViewItem itemA = new TreeListViewItem("��" + rows.Length + "����" + tb.Rows[i]["name"].ToString(), 0);
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.Tag = tb.Rows[i]["dept_id"].ToString();

                itemA.ForeColor = Color.Black;
                itemA.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        TreeListViewItem itemB = new TreeListViewItem(row["apply_date"].ToString(), 1);
                        itemB.SubItems.Add(row["������"].ToString().Trim());
                        itemB.SubItems.Add(row["memo"].ToString());
                        itemB.SubItems.Add(row["apply_id"].ToString());
                        itemB.SubItems.Add(row["apply_nurse"].ToString());
                        itemB.SubItems.Add(row["dept_ly"].ToString());
                        itemB.SubItems.Add(row["group_id"].ToString());
                        itemB.SubItems.Add(row["lyflcode"].ToString());
                        itemB.Tag = row["apply_id"].ToString();
                        itemB.BackColor = Color.White;
                        if (Convert.ToInt32(row["msg_type"]) == 1)
                        {
                            for (int d = 0; d <= itemB.SubItems.Count - 1; d++)
                                itemB.SubItems[d].ForeColor = Color.Red;
                        }
                        itemB.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        itemA.Items.Add(itemB);

                    }
                    treeListView.Items.Add(itemA);
                    if (cfg.Config == "1")
                        treeListView.Items[i].Expand();
                }
            }
            #endregion

            if (Tabpage.Name == "tabPage1")
                Tabpage.Title = "��ҩ��Ϣ" + "(" + tab.Rows.Count + ")";
            if (Tabpage.Name == "tabPage2")
                Tabpage.Title = "��ҩ��Ϣ" + "(" + tab.Rows.Count + ")";
        }

        //���ͳ�쵥��
        private void AddTldTree(int dept_ly, System.Windows.Forms.TreeListView treeListView, Crownwood.Magic.Controls.TabPage Tabpage, string sType)
        {
            treeListView.Items.Clear();
            DataTable mytb = (DataTable)this.myDataGridMx.DataSource;

            mytb.Rows.Clear();

            long tldCount = 0;
            decimal tldJe = 0;

            int lylx = 0;
            if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by"
                || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                lylx = 1;
            SystemCfg cfg = new SystemCfg(8004);


            string ssql = @" select name,a.dept_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id
                            where a.dept_id in(
                            select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm + " ";
            if (dept_ly > 0)
                ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'999999999')";

            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            DataTable tab = ZY_FY.SelectTld(dept_ly, InstanceForm.BCurrentDept.DeptId, this.dtptlrq1.Value.ToShortDateString(), this.dtptlrq2.Value.ToShortDateString(), "", sType, lylx, InstanceForm.BDatabase);

            treeListView.SmallImageList = imageList1;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow[] rows = tab.Select(string.Format("dept_ly={0}", tb.Rows[i]["dept_id"]));
                if (rows.Length > 0)
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
                    //����ӽڵ�
                    foreach (DataRow row in rows)
                    {
                        TreeListViewItem itemB = new TreeListViewItem(row["fyrq"].ToString(), 1);
                        itemB.SubItems.Add(row["��ҩ��"].ToString().Trim());
                        itemB.SubItems.Add(row["djh"].ToString());
                        string bz = "";
                        if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by"
                            || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                            bz = "�Ѵ�ӡ " + row["mxdycs"].ToString() + " ��";
                        else
                            bz = "�Ѵ�ӡ " + row["hzdycs"].ToString() + " ��";
                        itemB.SubItems.Add(bz);

                        itemB.SubItems.Add(row["��ҩ��"].ToString().Trim());
                        itemB.SubItems.Add(row["��ʿ"].ToString().Trim());
                        itemB.SubItems.Add(row["sumlsje"].ToString());
                        itemB.Tag = row["groupid"].ToString();
                        tldCount = tldCount + 1;
                        tldJe = tldJe + Convert.ToDecimal(row["sumlsje"]);
                        itemB.BackColor = Color.White;
                        itemB.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

                        itemA.Items.Add(itemB);
                    }
                    treeListView.Items.Add(itemA);
                    if (cfg.Config == "1")
                        itemA.Expand();
                }

            }

            this.statusBar1.Panels[0].Text = "ͳ�쵥����: " + tldCount.ToString() + " ��";
            this.statusBar1.Panels[1].Text = "ͳ�쵥���: " + tldJe.ToString("0.00") + " ";
            this.statusBar1.Panels[2].Text = "";


        }

        //�ݹ��Ƴ�tabpage
        private void RemoveTabpage(Crownwood.Magic.Controls.TabControl tabcontrol)
        {
            for (int i = 0; i <= tabcontrol.TabPages.Count - 1; i++)
            {
                if (tabcontrol.TabPages[i] != this.tabPage4)
                {
                    tabcontrol.TabPages.Remove(tabcontrol.TabPages[i]);
                    RemoveTabpage(tabcontrol);
                }
            }
        }

        //���ͳ�췽ʽҳ��
        private void AddtlflPage(DataTable tb)
        {

            RemoveTabpage(this.tabControl2);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage();
                tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                tabPage1.Location = new System.Drawing.Point(0, 25);
                tabPage1.Name = tb.Rows[i]["����"].ToString().Trim() == "" ? "����" : tb.Rows[i]["����"].ToString().Trim();
                tabPage1.Title = tb.Rows[i]["����"].ToString();
                tabPage1.Size = new System.Drawing.Size(639, 452);
                tabPage1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																								   tabPage1});

                TrasenClasses.GeneralControls.DataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
                System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();
                myDataGrid1.TableStyles.Add(dataGridTableStyle1);
                ;
                List<ColumnDefine> columns = new List<ColumnDefine>();
                columns.Add(PubClass.NewColumnDefine("���", "���", 30, true, 0));
                columns.Add(PubClass.NewColumnDefine("Ʒ��", "Ʒ��", 250, true, 0));
                columns.Add(PubClass.NewColumnDefine("��Ʒ��", "��Ʒ��", 250, true, 0));
                columns.Add(PubClass.NewColumnDefine("���", "���", 150, true, 0));
                columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("����", "����", 50, true, 0));
                columns.Add(PubClass.NewColumnDefine("�����", "�����", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("��ҩ��", "��ҩ��", 55, true, 0));
                columns.Add(PubClass.NewColumnDefine("ȱҩ��", "ȱҩ��", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("��λ", "��λ", 40, false, 0));
                columns.Add(PubClass.NewColumnDefine("���", "���", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("����", "����", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("��λ��", "��λ��", 0, true, 0));

                DataTable dtTmp = new DataTable();
                dtTmp.TableName = "tb";
                int index = 0;
                foreach (ColumnDefine cd in columns)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "";
                    colText.ReadOnly = cd.ColReadOnly;
                    //colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);
                    myDataGrid1.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol = new DataColumn(cd.MappingName);
                    dtTmp.Columns.Add(datacol);
                    index++;
                }

                myDataGrid1.DataSource = dtTmp;
                myDataGrid1.TableStyles[0].MappingName = "tb";
                myDataGrid1.CaptionVisible = false;
                myDataGrid1.BackgroundColor = System.Drawing.Color.White;
                myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
                myDataGrid1.ReadOnly = true;
                myDataGrid1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                tabPage1.Controls.Add(myDataGrid1);
                myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                if (ss.����������ʾ��Ʒ�� == true)
                    myDataGrid1.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 120;
                else
                    myDataGrid1.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 0;
            }
        }

        //�����Ϣʱ
        private void treeListView1_Click(object sender, System.EventArgs e)
        {

            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];

                //��ѯ���Ƴ���ϸ
                this.SelectOrRemoveItem(TreeListView, item);

                //����ͳ�쵥
                computeTld();

                PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                this.AddMssageTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs1.SelectedValue, "0")), TreeListView, this.tabPage1);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        //�����ϸ���Ƴ���ϸ�ķ���
        private void SelectOrRemoveItem(System.Windows.Forms.TreeListView TreeListView, TreeListViewItem item)
        {
            #region �ı�ѡ��������ɫ
            if (item.ImageIndex == 0)
                return;
            if (item.BackColor != Color.GreenYellow)
            {
                #region �ж�ѡ�����ĸ�����
                bool Byes = false;
                for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
                {
                    //�����ǰ�ڵ��ǿ��Ҳ�����ѡ��
                    if (TreeListView.Items[i].ImageIndex == 0 && TreeListView.Items[i].BackColor == Color.GreenYellow)
                    {
                        //�����Ҫѡ��Ľڵ�ĸ��ڵ�����ѡ��Ŀ��Ҳ�ͬ
                        if (item.Parent.Tag.ToString().Trim() != TreeListView.Items[i].Tag.ToString().Trim())
                        {
                            if (MessageBox.Show(this, "��Ϊ���ܿ����ѡ����Ϣ,��ǰ������ȡ��ԭ�е�ѡ��,��ȷ�ϼ�����?", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                            Byes = true;
                        }
                    }
                }

                //���ȷ�Ͽ����
                if (Byes == true)
                {
                    DataTable tbb = (DataTable)this.myDataGridMx.DataSource;
                    tbb.Rows.Clear();
                    for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
                        this.ChangeTreeItemColorToWhite(TreeListView.Items[i]);
                }
                #endregion

                item.BackColor = Color.GreenYellow;
                item.SubItems[0].BackColor = Color.GreenYellow;
                item.SubItems[1].BackColor = Color.GreenYellow;
                item.SubItems[2].BackColor = Color.GreenYellow;
                item.SubItems[3].BackColor = Color.GreenYellow;
                item.Selected = false;
            }
            else
            {
                item.BackColor = Color.White;
                item.SubItems[0].BackColor = Color.White;
                item.SubItems[1].BackColor = Color.White;
                item.SubItems[2].BackColor = Color.White;
                item.SubItems[3].BackColor = Color.White;
                item.Selected = false;
            }
            #endregion

            #region �ı丸�������ɫ
            bool bflag = false;
            for (int i = 0; i <= item.Parent.Items.Count - 1; i++)
            {
                if (item.Parent.Items[i].BackColor == Color.GreenYellow)
                {
                    bflag = true;
                }
            }

            if (bflag == true)
            {
                item.Parent.SubItems[0].BackColor = Color.GreenYellow;
                item.Parent.SubItems[1].BackColor = Color.GreenYellow;
                item.Parent.SubItems[2].BackColor = Color.GreenYellow;
                item.Parent.SubItems[3].BackColor = Color.GreenYellow;
                item.Parent.Selected = false;
            }
            else
            {
                item.Parent.SubItems[0].BackColor = Color.White;
                item.Parent.SubItems[1].BackColor = Color.White;
                item.Parent.SubItems[2].BackColor = Color.White;
                item.Parent.SubItems[3].BackColor = Color.White;
                item.Parent.Selected = false;
            }
            #endregion

            #region ��ѯ��ȥ����ϸ
            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            if (new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString())) != Guid.Empty)
                tb.Rows.Clear();
            DataTable tbmx = new DataTable();
            //��ѯ��ȥ����ϸ
            if (item.BackColor != Color.White)
            {
                DataTable tab = tb.Copy();/////////////////////////////
                tbmx = ZY_FY.SelectMassageMx(item.SubItems[7].Text, item.Tag.ToString(), item.SubItems[0].Text, item.Parent.Tag.ToString(), 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                if (tbmx.Rows.Count == 0)
                {
                    ZY_FY.UpdateMsg_Delete(new Guid(item.Tag.ToString()), InstanceForm.BDatabase);
                }

                tab.TableName = "tbmx";
                FunBase.AddRowtNo(tab);
                FunBase.AddRowtNo(tbmx);
                /*
                 * update code by pengy  7-7 14:55 
                 * ���������� ����������Ϣ��ϸ
                 */
                DataTable datalist = GetDatatableForGrid(tbmx, false);
                this.myDataGridMx.DataSource = ReOrderDataTable(datalist);
            }
            else
            {
                DataTable tbmxCopy = tb.Clone();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (new Guid(tb.Rows[i]["apply_id"].ToString().Trim()) != new Guid(item.Tag.ToString().Trim()))
                        tbmxCopy.ImportRow(tb.Rows[i]);
                }
                tb.Rows.Clear();
                FunBase.AddRowtNo(tbmxCopy);
                /*
                 * update code by pengy  7-7 14:55 
                 * ���������� ����������Ϣ��ϸ
                 */
                DataTable datalist = tbmxCopy;
                this.myDataGridMx.DataSource = ReOrderDataTable(datalist);
            }

            //���ܵ�ǰ�ķ���
            DataTable tbMx = (DataTable)myDataGridMx.DataSource;
            string[] GroupbyField1 ={ "����" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tbMx;
            DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "ѡ��=true");///////////////////
            DataTable tbfl2 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            panel_chk.Controls.Clear();
            for (int i = 0; i <= tbfl2.Rows.Count - 1; i++)
            {

                CheckBox checkBox1;
                checkBox1 = new System.Windows.Forms.CheckBox();
                panel_chk.Controls.Add(checkBox1);
                checkBox1.AutoSize = true;
                checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
                checkBox1.Location = new System.Drawing.Point(0, 0);
                checkBox1.Name = "checkBox" + i.ToString();
                checkBox1.Size = new System.Drawing.Size(77, 40);
                checkBox1.TabIndex = 4;
                checkBox1.Text = tbfl2.Rows[i]["����"].ToString();
                checkBox1.UseVisualStyleBackColor = true;
                checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            }
            //			DataTable tt=(DataTable)this.myDataGridMx.DataSource;
            //			decimal sumje=0;
            //			for(int i=0;i<=tt.Rows.Count-1;i++)
            //				sumje=sumje+Convert.ToDecimal(tt.Rows[i]["���"]);
            //			this.Text=sumje.ToString();
            #endregion
        }

        //˫�����ҽڵ�ʱ
        private void treeListView1_DoubleClick(object sender, System.EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            try
            {

                //�������һ���ڵ���˳�
                if (TreeListView.SelectedItems.Count == 0)
                    return;
                int Ncount = 0;
                TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];
                if (item.ImageIndex != 0)
                    return;
                DataTable tbmx = (DataTable)this.myDataGridMx.DataSource;
                Ncount = tbmx.Rows.Count;

                //myDataGridMx.TableStyles[0].GridColumnStyles["ȱҩ"].Width = 55;
                //�����������
                tbmx.Rows.Clear();
                //�����нڵ��ɰ�ɫ
                for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
                    this.ChangeTreeItemColorToWhite(TreeListView.Items[i]);

                for (int i = 0; i <= item.Items.Count - 1; i++)
                {
                    //�����ǰ������û����ϸ�������ϸ�������ǰ����ϸ�Ͱѽڵ���Ϊû��ѡ��
                    if (Ncount == 0)
                        this.SelectOrRemoveItem(TreeListView, item.Items[i]);
                }

                item.Selected = false;
                checkBox3.Checked = true;
                chkAllFee.Checked = true;//Modify By Tany 2015-03-17

                //Modify By Tany 2015-03-23 ���Ӵ������ڹ���
                //Modify by jchl 2015-03-27 �������ڹ������ڶ��ˣ����˵��������ڵĶ�Ӧ�ĳ������¼
                if (checkBox4.Checked)
                    moveCfrq();

                //ͳ��ʱ,������ҩʱ���û����������,��Ĭ�ϲ�ѡ��
                if (chkkcfs.Checked == true)
                    moveTyxx();
                if (chkkccc.Checked == true)
                    moveKccc();

                //����ͳ�쵥
                computeTld();
                PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);


            }
            catch (System.Exception err)
            {

                MessageBox.Show(err.Message);
                this.AddMssageTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs1.SelectedValue, "0")), TreeListView, this.tabPage1);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //ͳ��ʱ,������ҩʱ���û����������,��Ĭ�ϲ�ѡ��
        private void moveTyxx()
        {
            //���¼���ͳ�쵥
            DataTable tb = (DataTable)myDataGridMx.DataSource;
            string[] GroupbyField3 ={ "����", "����", "Ʒ��", "��Ʒ��", "���", "����", "�����", "cjid", "������", "lsj", "dwbl", "zxdw", "��λ��" };
            string[] ComputeField3 ={ "ypsl", "���", "�������" };
            string[] CField3 ={ "sum", "sum", "sum" };
            TrasenFrame.Classes.TsSet xcset4 = new TrasenFrame.Classes.TsSet();
            xcset4.TsDataTable = tb;

            DataTable tbhz;
            try
            {
                DataRow[] selrow = tb.Select("ѡ��=true");
                DataTable tbsel = tb.Clone();
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tbsel.ImportRow(selrow[i]);
                tbhz = FunBase.GroupbyDataTable(tbsel, GroupbyField3, ComputeField3, CField3, null);

                //��ҩ�ֿ�
                for (int i = 0; i <= tbhz.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) >= 0)
                        continue;
                    decimal ypsl = Convert.ToDecimal(tbhz.Rows[i]["ypsl"]);
                    int cjid = Convert.ToInt32(tbhz.Rows[i]["cjid"]);
                    decimal kc_ypsl = 0;
                    DataRow[] selrow_mx = tb.Select("ypsl<0 and cjid=" + cjid + "", "ypsl");
                    for (int x = 0; x <= selrow_mx.Length - 1; x++)
                    {
                        if (kc_ypsl > ypsl)
                        {
                            selrow_mx[x]["ѡ��"] = (int)0;
                            kc_ypsl = kc_ypsl + Convert.ToDecimal(selrow_mx[x]["ypsl"]);
                        }
                    }
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
        }

        //ͳ��ʱ,������ҩ�������ʱ
        private void moveKccc()
        {
            //���¼���ͳ�쵥
            DataTable tb = (DataTable)myDataGridMx.DataSource;
            string[] GroupbyField3 ={ "����", "����", "Ʒ��", "��Ʒ��", "���", "����", "�����", "cjid", "������", "lsj", "dwbl", "zxdw", "��λ��" };
            string[] ComputeField3 ={ "ypsl", "���", "�������" };
            string[] CField3 ={ "sum", "sum", "sum" };
            TrasenFrame.Classes.TsSet xcset4 = new TrasenFrame.Classes.TsSet();
            xcset4.TsDataTable = tb;

            DataTable tbhz;
            try
            {
                DataRow[] selrow = tb.Select("ѡ��=true");
                DataTable tbsel = tb.Clone();
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tbsel.ImportRow(selrow[i]);
                tbhz = FunBase.GroupbyDataTable(tbsel, GroupbyField3, ComputeField3, CField3, null);

                //��ҩ�ֿ�
                //tb.Reset();
                for (int i = 0; i <= tbhz.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) < Convert.ToDecimal(tbhz.Rows[i]["�����"]))
                        continue;
                    decimal ypsl = Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) - Convert.ToDecimal(tbhz.Rows[i]["�����"]);
                    int cjid = Convert.ToInt32(tbhz.Rows[i]["cjid"]);
                    decimal kc_ypsl = 0;
                    DataRow[] selrow_mx = tb.Select("ypsl>0 and cjid=" + cjid + "", "ypsl");
                    for (int x = 0; x <= selrow_mx.Length - 1; x++)
                    {
                        if (kc_ypsl < ypsl)
                        {
                            selrow_mx[x]["ѡ��"] = (int)0;
                            kc_ypsl = kc_ypsl + Convert.ToDecimal(selrow_mx[x]["ypsl"]);
                        }
                    }
                }
                //tb.AcceptChanges();
                myDataGridMx.Refresh();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
        }

        //ͳ��ʱ���������������ڵĲ���ѡ Add By Tany 2015-03-23
        private void moveCfrq()
        {
            if (!checkBox4.Checked)
            {
                return;
            }

            DataTable tb = (DataTable)myDataGridMx.DataSource;
            try
            {
                DateTime currentTime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 23, 59, 59);
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    //Modify By Tany 2015-05-21 ����С�ڵ��ں͵��ڵ��ж�
                    if ((rbXydy.Checked && currentTime >= Convert.ToDateTime(tb.Rows[i]["��������"].ToString()))
                        || (rbDy.Checked && currentTime.ToShortDateString() == Convert.ToDateTime(tb.Rows[i]["��������"].ToString()).ToShortDateString()))
                    {
                        continue;
                    }
                    else
                    {
                        tb.Rows[i]["ѡ��"] = (int)0;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
        }

        //���ͳ�쵥ʱ
        private void treeListView3_Click(object sender, System.EventArgs e)
        {
            try
            {

                decimal sumlsje = 0;
                this.statusBar1.Panels[2].Text = "";
                this.Cursor = PubStaticFun.WaitCursor();

                TreeListViewItem item = treeListView3.SelectedItems[0];
                if (item.ImageIndex == 0)
                    return;

                //��ѯͳ����ܵ�
                DataTable tb = ZY_FY.SelectTldHz(item.Tag.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                this.myDataGridMx.Tag = item.Tag.ToString();

                //���ܵ�ǰ��ͳ�����
                string[] GroupbyField1 ={ "����" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");

                //��ӷ���ҳ��
                this.AddtlflPage(tbfl);


                //���ÿ��ͳ������ҩƷ
                for (int i = 1; i <= this.tabControl2.TabPages.Count - 1; i++)
                {
                    for (int j = 0; j <= this.tabControl2.TabPages[i].Controls.Count - 1; j++)
                    {
                        //���������
                        if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                        {
                            TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
                            DataTable mytb = (DataTable)mydatagrid.DataSource;

                            DataRow[] rows = tb.Select("����='" + this.tabControl2.TabPages[i].Title.Trim() + "'", "hwh,yppm");
                            for (int x = 0; x <= rows.Length - 1; x++)
                            {
                                DataRow row = mytb.NewRow();
                                row["���"] = mytb.Rows.Count + 1;
                                row["Ʒ��"] = rows[x]["yppm"];
                                row["��Ʒ��"] = rows[x]["ypspm"];
                                row["���"] = rows[x]["ypgg"];
                                row["����"] = rows[x]["sccj"];
                                row["����"] = rows[x]["lsj"];
                                row["�����"] = rows[x]["kcl"];
                                row["��ҩ��"] = rows[x]["ypsl"];
                                row["ȱҩ��"] = rows[x]["qysl"];
                                row["��λ"] = rows[x]["ypdw"];
                                row["���"] = rows[x]["lsje"];
                                row["����"] = rows[x]["shh"];
                                row["cjid"] = rows[x]["cjid"];
                                row["dwbl"] = rows[x]["ydwbl"];
                                row["��λ��"] = rows[x]["hwh"];
                                sumlsje = sumlsje + Convert.ToDecimal(rows[x]["lsje"]);
                                mytb.Rows.Add(row);
                            }
                        }
                    }
                }

                this.statusBar1.Panels[2].Text = "��ǰ���ݽ��:" + sumlsje.ToString("0.00");

                //��ѯ��ϸ��
                if (this.chkmx.Checked == true)
                {
                    myDataGridMx.TableStyles[0].GridColumnStyles["ȱҩ"].Width = 0;

                    string sql = string.Format("select bylx from yf_tld where groupid = '{0}'", item.Tag.ToString());
                    DataTable tmpTable = InstanceForm.BDatabase.GetDataTable(sql);

                    DataTable tbmx = ZY_FY.SelectTldMx(item.Tag.ToString(), InstanceForm.BDatabase);
                    tbmx.TableName = "tbmx";



                    //this.myDataGridMx.DataSource=tbmx;
                    FunBase.AddRowtNo(tbmx);
                    DataTable datalist = GetDatatableForGrid(tbmx, true);
                    //DataView dv = datalist.DefaultView;
                    //dv.Sort = "�������� DESC,���� DESC";

                    string bylx = tmpTable != null && tmpTable.Rows.Count > 0 ? tmpTable.Rows[0]["bylx"].ToString() : "";
                    if (bylx == "1")
                        bylx = "�Զ�";
                    else if (bylx == "2")
                        bylx = "�ֹ�";
                    else
                        bylx = "δ֪";
                    DataTable dt = ReOrderDataTable(datalist);
                    DataColumn bylxColumn = new DataColumn();
                    bylxColumn.Caption = "��ҩ��ʽ";
                    bylxColumn.ColumnName = "��ҩ��ʽ";
                    bylxColumn.DataType = typeof(string);

                    DataColumn groupidColumn = new DataColumn();
                    groupidColumn.Caption = "groupid";
                    groupidColumn.ColumnName = "groupid";
                    groupidColumn.DataType = typeof(string);
                    dt.Columns.AddRange(new DataColumn[] { bylxColumn, groupidColumn });

                    foreach (DataRow tmpRow in dt.Rows)
                    {
                        tmpRow["��ҩ��ʽ"] = bylx;
                        tmpRow["groupid"] = item.Tag.ToString();
                    }
                    this.myDataGridMx.DataSource = dt;
                    PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);
                }

                #region �ı�ѡ��������ɫ
                if (item.ImageIndex == 0)
                    return;

                for (int i = 0; i <= this.treeListView3.Items.Count - 1; i++)
                    this.ChangeTreeItemColorToWhite(this.treeListView3.Items[i]);

                if (item.BackColor != Color.GreenYellow)
                {
                    item.BackColor = Color.GreenYellow;
                    item.SubItems[0].BackColor = Color.GreenYellow;
                    item.SubItems[1].BackColor = Color.GreenYellow;
                    item.SubItems[2].BackColor = Color.GreenYellow;
                    item.SubItems[3].BackColor = Color.GreenYellow;
                    item.Selected = false;
                }

                #endregion

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                //��ԭ���ָ�� Modify By Tany 2015-05-25
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// jianqg 20133-5-7����
        /// </summary>
        /// <param name="tbSource"></param>
        /// <param name="ClearOldData"></param>
        private DataTable GetDatatableForGrid(DataTable tbSource, bool ClearOldData)
        {
            //"�������� DESC,���� DESC";
            try
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                DataTable tab = tbSource.Clone();
                if (ClearOldData == false)
                    tab = tb.Copy();
                for (int i = 0; i <= tbSource.Rows.Count - 1; i++)
                {
                    tab.ImportRow(tbSource.Rows[i]);
                }
                return tab;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// �����������������
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        private DataTable ReOrderDataTable(DataTable dtSource)
        {
            DataTable dtOrder = dtSource.Clone();

            DataRow[] rows = dtSource.Select("", "���� ASC,�������� ASC");

            for (int i = 0; i < rows.Length; i++)
            {
                dtOrder.Rows.Add(rows[i].ItemArray);
                dtOrder.Rows[dtOrder.Rows.Count - 1]["���"] = i + 1;
            }

            return dtOrder;
        }

        //����ͳ�쵥
        private void computeTld()
        {
            this.myDataGridMx.Tag = null;
            this.statusBar1.Panels[2].Text = "";
            decimal sumlsje = 0;

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;

            //���ܵ�ǰ�ķ���
            string[] GroupbyField1 ={ "����" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tb;
            DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "ѡ��=true");///////////////////


            //��ӷ���ҳ��
            AddtlflPage(tbfl);//
            string[] GroupbyField ={ "����", "Ʒ��", "��Ʒ��", "���", "����", "�����", "cjid", "������", "lsj", "dwbl", "zxdw", "��λ��" };/////,"ifby"
            string[] ComputeField ={ "ypsl", "���" };
            string[] CField ={ "sum", "sum" };

            TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            xcset.TsDataTable = tb;
            for (int i = 1; i <= this.tabControl2.TabPages.Count - 1; i++)
            {
                for (int j = 0; j <= this.tabControl2.TabPages[i].Controls.Count - 1; j++)
                {
                    //���������
                    if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                    {
                        //����ÿ��ͳ�����
                        //DataTable tab=xcset.GroupTable(GroupbyField,ComputeField,CField," ����='"+this.tabControl2.TabPages[i].Title.Trim()+"' and ѡ��=true");

                        DataTable tab;
                        DataRow[] selrow = tb.Select(" ����='" + this.tabControl2.TabPages[i].Title.Trim() + "' and ѡ��=true");
                        DataTable tbsel = tb.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbsel.ImportRow(selrow[w]);
                        tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

                        TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
                        DataTable mytb = (DataTable)mydatagrid.DataSource;
                        mytb.Rows.Clear();
                        DataRow[] rows = tab.Select("", "��λ��,Ʒ�� asc");

                        //�������
                        #region �������
                        for (int x = 0; x <= rows.Length - 1; x++)
                        {
                            DataRow row = mytb.NewRow();
                            row["���"] = x + 1;
                            row["Ʒ��"] = rows[x]["Ʒ��"];
                            row["��Ʒ��"] = rows[x]["��Ʒ��"];
                            row["���"] = rows[x]["���"];
                            row["����"] = rows[x]["����"];
                            row["����"] = rows[x]["lsj"];

                            decimal ypsl = Convert.ToDecimal(Convertor.IsNull(rows[x]["ypsl"], "0"));
                            decimal kcl = Convert.ToDecimal(Convertor.IsNull(rows[x]["�����"], "0"));
                            float _ypsl = (float)ypsl;
                            float _kcl = (float)kcl;
                            row["�����"] = kcl.ToString();// rows[x]["�����"];
                            row["��ҩ��"] = ypsl.ToString();// rows[x]["ypsl"];
                            row["ȱҩ��"] = (kcl - ypsl) < 0 ? System.Math.Abs(kcl - ypsl) : 0;
                            row["��λ"] = Yp.SeekYpdw(Convert.ToInt32(rows[x]["zxdw"]), InstanceForm.BDatabase);
                            row["���"] = rows[x]["���"];
                            row["����"] = rows[x]["����"];
                            row["cjid"] = rows[x]["cjid"];
                            row["dwbl"] = rows[x]["dwbl"];
                            row["��λ��"] = rows[x]["��λ��"];
                            //sumlsje=sumlsje+Convert.ToDecimal(Convertor.IsNull(rows[x]["���"],"0"));
                            sumlsje = sumlsje + (Convert.IsDBNull(rows[x]["���"]) ? 0 : Convert.ToDecimal(rows[x]["���"]));
                            mytb.Rows.Add(row);
                        }

                        #endregion
                    }
                }
            }

            this.statusBar1.Panels[2].Text = "��ǰ���ݽ��:" + sumlsje.ToString("0.00");

            PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);

        }

        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chk = (CheckBox)sender;
            DataTable tb = (DataTable)this.myDataGridMx.DataSource;

            DataRow[] rows = tb.Select("����='" + chk.Text + "'");
            for (int i = 0; i <= rows.Length - 1; i++)
                rows[i]["ѡ��"] = chk.Checked == true ? (short)1 : (short)0;
            computeTld();
        }

        //˫����Ϣ��ϸʱ
        private void myDataGridMx_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (this.tabControl1.SelectedTab == this.tabPage3)
                    return;
                TrasenClasses.GeneralControls.ButtonDataGridEx myGridDate = (TrasenClasses.GeneralControls.ButtonDataGridEx)sender;
                int nrow = myGridDate.CurrentCell.RowNumber;
                DataTable tb = (DataTable)myGridDate.DataSource;
                if (myGridDate.TableStyles[0].GridColumnStyles[myGridDate.CurrentCell.ColumnNumber].HeaderText != "ѡ��")
                    return;
                if (nrow > tb.Rows.Count - 1)
                    return;
                tb.Rows[nrow]["ѡ��"] = Convert.ToBoolean(tb.Rows[nrow]["ѡ��"]) == true ? false : true;
                if (myGridDate.Name == "myDataGridMx")
                    this.computeTld();
                PubStaticFun.ModifyDataGridStyle(myGridDate, 0);

                //if (myGridDate.Name == "myhy")
                //{
                //    if (tb.Rows.Count == 0) return;
                //    int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
                //    decimal zsl = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(ypsl)", "ѡ��=true and cjid=" + cjid + ""), "0"));
                //    f.statusStrip1.Items[0].Text = "���滻����:" + zsl.ToString() + Yp.SeekYpdw(Convert.ToInt32(tb.Rows[0]["zxdw"]));

                //}
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //��ϸ�еİ�ť�¼�
        private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            if (this.tabControl2.SelectedTab == this.tabPage3)
                return;

            try
            {

                DataGridButtonColumn butCol = (DataGridButtonColumn)sender;
                TrasenClasses.GeneralControls.ButtonDataGridEx myGridDate = (TrasenClasses.GeneralControls.ButtonDataGridEx)butCol.DataGridTableStyle.DataGrid;
                ;
                int nrow = myGridDate.CurrentCell.RowNumber;
                DataTable tb = (DataTable)myGridDate.DataSource;
                if (nrow > tb.Rows.Count - 1)
                    return;

                Guid zy_id = new Guid(tb.Rows[nrow]["zy_id"].ToString());
                int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);

                if (butCol.HeaderText == "ȱҩ")
                {
                    if (Convert.ToDecimal(tb.Rows[nrow]["����"]) < 0)
                    {
                        MessageBox.Show("��ҩ��Ϣ���ܴ�ȱ");
                        return;
                    }

                    if (MessageBox.Show(this, "��ȷ��Ҫ������ҩƷ��¼��Ϊȱҩ��?", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    ZY_FY.UpdateFeeChargeTlfs(1, "ȱҩcjid=" + cjid.ToString(), zy_id, InstanceForm.BDatabase);

                    DataTable tbkc = Yp.Selectkc(InstanceForm.BCurrentDept.DeptId, cjid, Yp.Seek_kcmx_table(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase), InstanceForm.BDatabase);
                    decimal kcl = 0;
                    int bdelete = 0;
                    int zxdw = 0;
                    if (tbkc.Rows.Count > 0)
                    {
                        kcl = Convert.ToDecimal(tbkc.Rows[0]["kcl"]);
                        zxdw = Convert.ToInt32(tbkc.Rows[0]["zxdw"]);
                        bdelete = Convert.ToInt32(tbkc.Rows[0]["bdelete"]);
                    }

                    SystemCfg cfg8036 = new SystemCfg(8036);
                    if (bdelete == 0 && cfg8036.Config == "1")
                    {
                        if (MessageBox.Show(this, "��ҩ��ǰ�����" + kcl.ToString() + Yp.SeekYpdw(zxdw, InstanceForm.BDatabase) + ",��Ҫ���ø�ҩƷ�����?", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                InstanceForm.BDatabase.BeginTransaction();
                                string ssql = "update yf_kcmx set bdelete=1 where cjid=" + cjid + " and deptid=" + InstanceForm.BCurrentDept.DeptId + "";
                                InstanceForm.BDatabase.DoCommand(ssql);
                                ssql = "update yf_kcph set bdelete=1 where cjid=" + cjid + " and deptid=" + InstanceForm.BCurrentDept.DeptId + "";
                                InstanceForm.BDatabase.DoCommand(ssql);
                                InstanceForm.BDatabase.CommitTransaction();

                                string bz = " ��ʱ�����ſ��Ϊ " + kcl.ToString() + Yp.SeekYpdw(zxdw, InstanceForm.BDatabase);
                                Yp.InsertLog("����ҩƷ", InstanceForm.BCurrentDept.DeptId, cjid, InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(), bz, InstanceForm.BDatabase);
                            }
                            catch (System.Exception err)
                            {
                                InstanceForm.BDatabase.RollbackTransaction();
                                MessageBox.Show("", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    tb.Rows.Remove(tb.Rows[nrow]);
                    myGridDate.DataSource = tb;
                    this.computeTld();
                }
                if (butCol.HeaderText == "ת��")
                {
                    Frmks f = new Frmks();
                    f.cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
                    f.deptid = InstanceForm.BCurrentDept.DeptId;
                    f.ShowDialog();

                    if (f.mdks > 0)
                    {
                        ZY_FY.UpdateFeeChargeExecDeptID(f.mdks, "ת��", zy_id, InstanceForm.BDatabase);
                        tb.Rows.Remove(tb.Rows[nrow]);
                        myGridDate.DataSource = tb;
                        this.computeTld();
                    }
                }

                if (butCol.HeaderText == "��ҩ")
                {

                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

        }

        //��Ϣ��ͳ�쵥��ϸ��ѯ
        private void butmxcx_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                DataTable tab = tb.Clone();
                DataRow[] rows;
                string swhere = "";
                //Ʒ��
                if (Convert.ToInt32(txtypmc.Tag) > 0 && txtypmc.Text.Trim() != "")
                    swhere = " cjid='" + txtypmc.Tag.ToString().Trim() + "'";
                //��λ
                if (txtcw.Text.Trim() != "")
                    swhere = swhere == "" ? swhere = "����='" + txtcw.Text.Trim() + "'" : swhere = swhere + " and ����='" + txtcw.Text.Trim() + "'";
                //����
                if (txtxm.Text.Trim() != "")
                    swhere = swhere == "" ? swhere = "����='" + txtxm.Text.Trim() + "'" : swhere = swhere + " and ����='" + txtxm.Text.Trim() + "'";
                //סԺ��
                if (txtzyh.Text.Trim() != "")
                    swhere = swhere == "" ? swhere = "סԺ��='" + txtzyh.Text.Trim() + "'" : swhere = swhere + " and סԺ��='" + txtzyh.Text.Trim() + "'";


                rows = tb.Select(swhere);
                if (checkBox4.Checked)
                {
                    for (int x = 0; x < rows.Length; x++)
                    {
                        DateTime currentTime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 23, 59, 59);
                        if (currentTime >= Convert.ToDateTime(rows[x]["��������"].ToString()))
                            tab.ImportRow(rows[x]);
                    }
                }
                else
                {
                    for (int i = 0; i <= rows.Length - 1; i++)
                        tab.ImportRow(rows[i]);
                }
                TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
                System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();
                dataGridTableStyle1.AllowSorting = false;
                myDataGrid1.TableStyles.Add(dataGridTableStyle1);
                myDataGrid1.CaptionVisible = false;
                myDataGrid1.ReadOnly = true;
                myDataGrid1.BackgroundColor = System.Drawing.Color.White;
                myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
                myDataGrid1.AllowSorting = false;
                myDataGrid1.Click += new EventHandler(myDataGridMx_DoubleClick);

                //��ʼ������
                CshMxGrid(myDataGrid1);

                //��ʾ��ѯ���
                myDataGrid1.DataSource = tab;

                Frmmxcx f = new Frmmxcx();
                f.panel2.Controls.Add(myDataGrid1);
                myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);
                myDataGrid1.TableStyles[0].GridColumnStyles["ȱҩ"].Width = 0;

                if (this.tabControl1.SelectedTab == this.tabPage3)
                {
                    f.butok.Visible = false;
                    f.butall.Visible = false;
                    f.butuall.Visible = false;
                }
                f.ShowDialog();

                //������ϸ��ѡ����
                if (f.Bselect == true)
                {
                    DataTable tbmx = (DataTable)myDataGrid1.DataSource;
                    TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                    xcset.TsDataTable = tb;//Modify By Tany 2015-03-20 ����Ҫ�ý������ȫ��������ᵼ�²���ҩû��������û��������ͳ�쵥

                    for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                    {
                        ItemEx[] item = new ItemEx[1];
                        item[0].Text = "ѡ��";
                        item[0].Value = (short)(Convert.ToInt16(tbmx.Rows[i]["ѡ��"]));
                        xcset.UpdateField(item, "zy_id='" + tbmx.Rows[i]["zy_id"].ToString().Trim() + "'");
                    }
                    ////////////////
                    FunBase.AddRowtNo(xcset.TsDataTable);

                    DataTable datalist = xcset.TsDataTable;

                    this.myDataGridMx.DataSource = ReOrderDataTable(datalist);
                    this.computeTld();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //�رմ���
        private void butquit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        //��ҩ��ť�¼�
        private void butfy_Click(object sender, System.EventArgs e)
        {
            bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//�������ι���

            if (!bpcgl)
            {
                #region ���������ι���
                if (new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString())) != Guid.Empty)
                {
                    MessageBox.Show("��ǰҩƷ�ѷ�ҩ�����ٴη�ҩ");
                    return;
                }

                if (Convertor.IsNull(cmbpyr.SelectedValue, "") == "")
                {
                    MessageBox.Show("��ѡ����ҩ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

                SystemCfg cfg8203 = new SystemCfg(8203);
                string alertDept = cfg8203.Config.Trim();
                if (!string.IsNullOrEmpty(alertDept))
                {
                    if (alertDept.Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                    {
                        if (MessageBox.Show("�Ƿ���Ҫ��ҩ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            return;
                    }
                }

                this.Cursor = PubStaticFun.WaitCursor();

                DataTable tb = (DataTable)this.myDataGridMx.DataSource;

                //��֤PIVAS��˱�־ Modify By Tany 2015-04-20
                //Modify By Tany 2015-05-04 ����ѡ���ȷ���Ƿ���֤���״̬
                if (!chkPivasCHK.Checked)
                {
                    CheckPvsSH(tb);
                }

                //���ܵ�ǰҪ��ҩ��Ϣ������
                string[] GroupbyField1 ={ "dept_ly", "apply_id", "apply_date", "lyflcode" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tb_msg = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "ѡ��=true");
                if (tb_msg.Rows.Count == 0)
                {
                    MessageBox.Show("û��Ҫ��ҩ����Ϣ");
                    this.Cursor = Cursors.Arrow;
                    return;
                }

                //���ܵ�ǰ��ѡ��ҩ����Ϣ����
                TrasenFrame.Classes.TsSet xcset2 = new TrasenFrame.Classes.TsSet();
                xcset2.TsDataTable = tb;
                DataTable tb_Umsg = xcset2.GroupTable(GroupbyField1, ComputeField1, CField1, "ѡ��=false");

                //���ܵ�ǰ���
                string[] GroupbyField2 ={ };
                string[] ComputeField2 ={ "���", "�������" };
                string[] CField2 ={ "sum", "sum" };
                TrasenFrame.Classes.TsSet xcset3 = new TrasenFrame.Classes.TsSet();
                xcset3.TsDataTable = tb;
                DataTable tbje = xcset3.GroupTable(GroupbyField2, ComputeField2, CField2, "ѡ��=true");

                //���¼���ͳ�쵥
                string[] GroupbyField3 ={ "����", "����", "Ʒ��", "��Ʒ��", "���", "����", "�����", "cjid", "������", "lsj", "dwbl", "zxdw", "��λ��" };
                string[] ComputeField3 ={ "ypsl", "���", "�������", "ypcjs" };
                string[] CField3 ={ "sum", "sum", "sum", "sum" };
                TrasenFrame.Classes.TsSet xcset4 = new TrasenFrame.Classes.TsSet();
                xcset4.TsDataTable = tb;
                //DataTable tbhz=xcset4.GroupTable(GroupbyField3,ComputeField3,CField3,"ѡ��=true");


                #region Modify by dyw 2014/7/1���ӳ����
                if (!tb.Columns.Contains("ypcjs"))
                {
                    tb.Columns.Add(new DataColumn("ypcjs", Type.GetType("System.Decimal")));
                }
                foreach (DataRow row in tb.Select("ѡ��=true"))
                {
                    if (Convert.ToDecimal(row["ypsl"]) < 0)
                    {
                        row["ypcjs"] = row["ypsl"];
                    }
                    else
                    {
                        row["ypcjs"] = 0;
                    }
                }
                #endregion

                DataTable tbhz;
                try
                {
                    DataRow[] selrow = tb.Select("ѡ��=true");
                    DataTable tbsel = tb.Clone();
                    for (int i = 0; i <= selrow.Length - 1; i++)
                        tbsel.ImportRow(selrow[i]);
                    tbhz = FunBase.GroupbyDataTable(tbsel, GroupbyField3, ComputeField3, CField3, null);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }

                if (tbhz.Rows.Count == 0)
                {
                    MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                    this.Cursor = Cursors.Arrow;
                    return;
                }

                //���ر���
                int _err_code = -1;
                string _err_text = "";

                //ʱ��
                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                //��ҩ����
                string _dept_ly = tb_msg.Rows[0]["dept_ly"].ToString().Trim();
                //��ҩ��
                int _py_user = Convert.ToInt32(cmbpyr.SelectedValue);
                //��ע
                string _bz = this.txtbz.Text.Trim();
                //�����ۡ��������
                decimal _sumpfje = Convert.ToDecimal(tbje.Rows[0]["�������"]);
                decimal _sumlsje = Convert.ToDecimal(tbje.Rows[0]["���"]);
                //ͳ�����
                string _stype = this.tabControl1.SelectedTab == this.tabPage1 ? "ͳ��" : "��ҩ";
                //string _stype=_sumlsje>0?"ͳ��":"��ҩ";
                //��Ϣ����
                int _msg_type = this.tabControl1.SelectedTab == this.tabPage1 ? 0 : 1;
                //ǿ�ƿ��ƿ��
                YpConfig s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                //��ҩ��ʽ
                int lylx = 0;
                if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by"
                    || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                    lylx = 1;
                //�ܽ������ں���������_sumlsje�Ƚϡ����Է����㲻��ȷ
                decimal _zje = 0;
                long djh = Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                InstanceForm.BDatabase.BeginTransaction();

                try
                {

                    #region ���ͳ�쵥ͷ��
                    _err_text = "���ͳ�쵥ͷ��";
                    Guid _groupid = Guid.Empty;


                    //��Ҫ���Ͻ������ncq
                    ZY_FY.SaveTld(djh, InstanceForm.BCurrentDept.DeptId, _sDate, InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(_dept_ly), 0, _py_user, _bz, _sumpfje, _sumlsje, _stype, _menuTag.FunctionTag, out _groupid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, lylx, InstanceForm.BDatabase, 0);
                    if (_groupid == Guid.Empty || _err_code != 0)
                        throw new Exception(_err_text);
                    #endregion

                    this.myDataGridMx.Tag = _groupid.ToString();
                    this.butfy.Tag = _sDate.Trim();

                    #region ���ͳ�쵥��ϸ��
                    _err_text = "���ͳ�쵥��ϸ��";
                    for (int i = 0; i <= tbhz.Rows.Count - 1; i++)
                    {
                        Guid _fyid = Guid.Empty;
                        decimal _qysl = Convert.ToDecimal(tbhz.Rows[i]["�����"]) - Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) < 0 ? Convert.ToDecimal(tbhz.Rows[i]["�����"]) - Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) : 0;
                        _zje = _zje + Convert.ToDecimal(tbhz.Rows[i]["���"]);
                        decimal _ypcjs = Convert.ToDecimal(tbhz.Rows[i]["ypcjs"]);
                        #region ����ͳ�쵥��ϸ
                        ZY_FY.SaveTldMx(_groupid,
                                        Convert.ToInt32(tbhz.Rows[i]["cjid"]),
                                        tbhz.Rows[i]["����"].ToString(),
                                        tbhz.Rows[i]["Ʒ��"].ToString(),
                                        tbhz.Rows[i]["��Ʒ��"].ToString(),
                                        tbhz.Rows[i]["���"].ToString(),
                                        Yp.SeekYpdw(Convert.ToInt32(tbhz.Rows[i]["zxdw"]), InstanceForm.BDatabase),
                                        tbhz.Rows[i]["����"].ToString(),
                                        Convert.ToDecimal(tbhz.Rows[i]["�����"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["ypsl"]),
                                        _qysl,
                                        Convert.ToDecimal(tbhz.Rows[i]["������"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["lsj"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["�������"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["���"]),//���۽��
                                        Convert.ToString(tbhz.Rows[i]["����"]),
                                        Convert.ToInt32(tbhz.Rows[i]["dwbl"]),
                                        s.ǿ�ƿ��ƿ��,
                                        InstanceForm.BCurrentDept.DeptId,
                                        "",
                                        tbhz.Rows[i]["��λ��"].ToString(),
                                        out _fyid,
                                        out _err_code,
                                        out _err_text,
                                        InstanceForm.BDatabase,
                                        0, //����
                                        0, //�������
                                        "",//Ч��
                                        "",//���κ�
                                        Guid.Empty,
                                        false, _ypcjs
                                        );
                        if (_fyid == Guid.Empty || _err_code != 0)
                            throw new Exception(_err_text);
                        #endregion
                    }
                    #endregion

                    #region ��֤���
                    _err_text = "������";
                    _zje = Math.Round(_zje, 0);
                    _sumlsje = Math.Round(_sumlsje, 0);
                    if (Math.Abs(_zje - (_sumlsje)) > 1)
                    {
                        throw new Exception("��������ܽ��" + _zje.ToString() + " ��������ϸ�ܽ��" + _sumlsje.ToString() + " ����͹���Ա��ϵ");
                    }
                    #endregion

                    //û�мǷѵļ�¼
                    DataRow[] rows = tb.Select("ѡ��=true and charge_bit='0'");
                    //�ѼǷѵļ�¼
                    DataRow[] rows2 = tb.Select("ѡ��=true  and charge_bit='1'");

                    #region ���δ��룬��ʱ����
                    //////////////////////////////�Ǽ޽ӵķ�ʽֱ�Ӹ��·��ñ�
                    ////////////////////////////if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy")
                    ////////////////////////////{
                    ////////////////////////////    for (int i = 0; i <= rows.Length - 1; i++)
                    ////////////////////////////    {
                    ////////////////////////////        long _Zyid = Convert.ToInt64(rows[i]["zy_id"]);
                    ////////////////////////////        ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _Zyid);
                    ////////////////////////////    }

                    ////////////////////////////    for (int i = 0; i <= rows2.Length - 1; i++)
                    ////////////////////////////    {
                    ////////////////////////////        long _Zyid = Convert.ToInt64(rows2[i]["zy_id"]);
                    ////////////////////////////        ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _Zyid);
                    ////////////////////////////    }
                    ////////////////////////////}

                    //�޽ӵķ�ʽ�������ʱ����ٸ��·��ñ�
                    //////////////////////////////if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy")
                    //////////////////////////////{
                    #endregion

                    string ssql = "";
                    decimal _execId = 0;

                    #region ����û�мǷѵļ�¼
                    _err_text = "����û�мǷѵļ�¼";
                    //����û�мǷѵļ�¼
                    //ʱ���
                    ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                    _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ", '" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + _groupid + "',1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                    if (rows.Length > 0)
                    {
                        int iii = ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                        if (rows.Length != iii)
                        {
                            if (isPivasYF)
                            {
                                butref1_Click(null,null);
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!\r\r  ���ܲ���������ת���������  \r\r��������ˢ�����ݺ�����!");

                            }
                            else
                            {
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!��������ˢ�����ݺ�����!");
                            }
                        }
                    }
                    #endregion

                    #region �����ѼǷѵļ�¼
                    _err_text = "�����ѼǷѵļ�¼";
                    //�����ѼǷѵļ�¼
                    //ʱ���
                    ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                    _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                    for (int i = 0; i <= rows2.Length - 1; i++)
                    {
                        ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows2[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + _groupid + "',1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }

                    if (rows2.Length > 0)
                    {
                        int iii = ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                        if (rows2.Length != iii)
                        {
                            if (isPivasYF)
                            {
                                butref1_Click(null, null);
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!\r\r  ���ܲ���������ת���������  \r\r��������ˢ�����ݺ�����!");
                            }
                            else
                            {
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!��������ˢ�����ݺ�����!");
                            }
                        }
                    }
                    #endregion

                    #region �޽Ӳ����·�ҩ��Ϣ
                    _err_text = "�޽Ӳ����·�ҩ��Ϣ";
                    //�޽Ӳ����·�ҩ��Ϣ
                    if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_ly")
                    {
                        _err_text = "����zy_apply_drug";
                        //����zy_apply_drug
                        for (int i = 0; i <= tb_msg.Rows.Count - 1; i++)
                            ZY_FY.UpdateMsg(new Guid(tb_msg.Rows[i]["apply_id"].ToString()), _groupid, InstanceForm.BDatabase);

                        _err_text = "��û�з�ҩ�������µ���Ϣ";
                        //��û�з�ҩ�������µ���Ϣ
                        for (int i = 0; i <= tb_Umsg.Rows.Count - 1; i++)
                        {
                            //�ж��Ƿ񲿷ַ�ҩ
                            bool byes = false;
                            for (int j = 0; j <= tb_msg.Rows.Count - 1; j++)
                            {
                                if (new Guid(tb_Umsg.Rows[i]["apply_id"].ToString().Trim()) == new Guid(tb_msg.Rows[j]["apply_id"].ToString().Trim()))
                                    byes = true;
                            }

                            Guid _apply_id = Guid.Empty;
                            if (byes == true)
                            {
                                //������Ϣ��
                                ZY_FY.SaveApplyDrug(tb_Umsg.Rows[i]["apply_date"].ToString().Trim(), InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(_dept_ly), InstanceForm.BCurrentDept.DeptId, _msg_type, tb_Umsg.Rows[i]["lyflcode"].ToString().Trim(), out _apply_id, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                                if (_apply_id == Guid.Empty)
                                    throw new Exception("����,������Ϣʱ,��ϢIDΪ��");
                                DataRow[] RowUmsg = tb.Select("ѡ��=false and apply_id='" + tb_Umsg.Rows[i]["apply_id"].ToString().Trim() + "'");

                                //���´���Ϣ����ϸ
                                for (int x = 0; x <= RowUmsg.Length - 1; x++)
                                    ZY_FY.UpdateFeeChargeApplyID(_apply_id, new Guid(RowUmsg[x]["zy_id"].ToString()), InstanceForm.BDatabase);
                            }
                        }
                    }
                    #endregion

                    #region  ʹ�÷ְ��� ---��ҩ LQQ 2013-4-27
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by"
                        || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                    {
                        DataTable dt_byjCS = InstanceForm.BDatabase.GetDataTable("select ZT from yk_config where BH=153 and deptid='" + InstanceForm.BCurrentDept.DeptId + "'");
                        if (dt_byjCS != null)
                        {
                            if (dt_byjCS.Rows.Count > 0)
                            {
                                if (Convert.ToString(dt_byjCS.Rows[0][0]) == "1")
                                {
                                    ParameterEx[] parameters = new ParameterEx[2];
                                    parameters[0].Value = "00000000-0000-0000-0000-000000000000";
                                    parameters[1].Value = _groupid;

                                    parameters[0].Text = "@fyid";
                                    parameters[1].Text = "@V_groupid";

                                    DataSet dset = new DataSet();
                                    InstanceForm.BDatabase.AdapterFillDataSet("sp_yf_zyfy_byj", parameters, dset, "kss", 240);
                                }
                            }
                        }
                    }

                    #endregion

                    //�ύ����
                    InstanceForm.BDatabase.CommitTransaction();

                    //if (MessageBox.Show("��ҩ�ɹ�,��Ҫ��ӡ��", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    //{
                    //    if (_menuTag.Function_Name != "Fun_ts_yf_zyfy_tld_by")
                    //        this.butprint_Click(sender, e);
                    //    else
                    //        this.butprintmx_Click(sender, e);
                    //}
                    MessageBox.Show("��ҩ�ɹ�", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //�޽Ӳ����Ƴ���ҩ��Ϣ
                    if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_ly")
                    {
                        //�Ƴ���Ϣ
                        System.Windows.Forms.TreeListView TreeListView;
                        if (this.tabControl1.SelectedTab == this.tabPage1)
                            TreeListView = this.treeListView1;
                        else
                            TreeListView = this.treeListView2;

                        for (int i = 0; i <= tb_msg.Rows.Count - 1; i++)
                            RemoveItem(TreeListView, _dept_ly, tb_msg.Rows[i]);
                        for (int i = 0; i <= tb_Umsg.Rows.Count - 1; i++)
                            RemoveItem(TreeListView, _dept_ly, tb_Umsg.Rows[i]);
                        tb.Rows.Clear();
                    }
                    else
                    {
                        tb.Rows.Clear();
                    }


                }
                catch (System.Exception err)
                {
                    this.myDataGridMx.Tag = null;
                    this.butfy.Tag = "";
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
                #endregion
            }
            else
            {
                #region �������ι���
                if (new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString())) != Guid.Empty)
                {
                    MessageBox.Show("��ǰҩƷ�ѷ�ҩ�����ٴη�ҩ");
                    return;
                }

                if (Convertor.IsNull(cmbpyr.SelectedValue, "") == "")
                {
                    MessageBox.Show("��ѡ����ҩ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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


                SystemCfg cfg8203 = new SystemCfg(8203);
                string alertDept = cfg8203.Config.Trim();
                if (!string.IsNullOrEmpty(alertDept))
                {
                    if (alertDept.Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                    {
                        if (MessageBox.Show("�Ƿ���Ҫ��ҩ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            return;
                    }
                }


                this.Cursor = PubStaticFun.WaitCursor();

                DataTable tb = (DataTable)this.myDataGridMx.DataSource;

                //��֤PIVAS��˱�־ Modify By Tany 2015-04-20
                //Modify By Tany 2015-05-04 ����ѡ���ȷ���Ƿ���֤���״̬
                if (!chkPivasCHK.Checked)
                {
                    CheckPvsSH(tb);
                }

                #region ���ܵ�ǰҪ��ҩ��Ϣ������
                string[] GroupbyField1 ={ "dept_ly", "apply_id", "apply_date", "lyflcode" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb.Copy();
                DataTable tb_msg = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "ѡ��=true");
                if (tb_msg.Rows.Count == 0)
                {
                    MessageBox.Show("û��Ҫ��ҩ����Ϣ");
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                #endregion

                #region ���ܵ�ǰ��ѡ��ҩ����Ϣ����
                TrasenFrame.Classes.TsSet xcset2 = new TrasenFrame.Classes.TsSet();
                xcset2.TsDataTable = tb.Copy();
                DataTable tb_Umsg = xcset2.GroupTable(GroupbyField1, ComputeField1, CField1, "ѡ��=false");
                #endregion

                #region ���ܵ�ǰ��� ������� ���۽��
                string[] GroupbyField2 ={ };
                string[] ComputeField2 ={ "���", "�������" };
                string[] CField2 ={ "sum", "sum" };
                TrasenFrame.Classes.TsSet xcset3 = new TrasenFrame.Classes.TsSet();
                xcset3.TsDataTable = tb.Copy();
                DataTable tbje = xcset3.GroupTable(GroupbyField2, ComputeField2, CField2, "ѡ��=true");
                #endregion

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
                if (!tb.Columns.Contains("ypcjs"))
                {
                    tb.Columns.Add(new DataColumn("ypcjs", Type.GetType("System.Decimal")));

                }
                #endregion

                DataTable tbpcmx = tb.Clone();//�ѷ�������
                DataTable tbpcmx_zs_wfp = tb.Clone();//δ�������������
                DataTable tbpcmx_fs = tb.Clone();//�ѷ��为��

                DataTable tbkcph = InstanceForm.BDatabase.GetDataTable(@"select ID kcid,yppch,CJID,YPPH,YPXQ,JHJ,KCL,0 
                as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where  deptid=" + InstanceForm.BCurrentDept.DeptId + " and kcl>0 and bdelete = 0");

                try
                {
                    #region ���μ���
                    DataTable tb_temp = tb.Copy();
                    //��һ�������������������0��ҩƷ
                    DataRow[] rows_mx = tb_temp.Select("ѡ��=true and ypsl>0 ", "ypsl desc");
                    for (int i = 0; i < rows_mx.Length; i++) //������ϸ��
                    {
                        #region
                        DataRow row = rows_mx[i];
                        DataRow[] rows_kcph;
                        if (pcglfs == "0")
                            rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["cjid"].ToString() + "", "djsj asc,yppch asc");
                        else
                            rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["cjid"].ToString() + "", "ypxq asc");

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
                    rows_mx = tb_temp.Select("ѡ��=true and ypsl<=0", "ypsl desc");
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
                            //rows_kcph = tbkcph.Select("kcid='" + row["KCID2"].ToString() + "'", "");
                            rows_kcph = rows_yjl;//2015-05-07 ncq //����˵�� By Tany 2015-05-07 ������ԭ��¼���е���ģ���������ı���Ҫ���Ÿ�
                            bFind = true;
                        }
                        #region �Ҳ������˵��п��ļ�¼�ϣ��������û�п�棬����һ������ļ�¼
                        if (rows_kcph.Length == 0)
                        {
                            if (pcglfs == "0")
                                rows_kcph = tbkcph.Select("cjid=" + row["cjid"].ToString() + "", "djsj asc");
                            else
                                rows_kcph = tbkcph.Select("cjid=" + row["cjid"].ToString() + "", "ypxq asc");
                            if (rows_kcph.Length == 0)
                            {
                                if (pcglfs == "0")
                                {
                                    rows_kcph = InstanceForm.BDatabase.GetDataTable(@"select top 1 ID kcid, yppch,
                                            CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by djsj desc,yppch desc ").Select();
                                }
                                else
                                {
                                    rows_kcph = InstanceForm.BDatabase.GetDataTable(@"select top 1 ID kcid, yppch,
                                            CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by ypxq desc ").Select();
                                }
                            }
                        }
                        #endregion
                        if (rows_kcph.Length <= 0)
                        {
                            throw new Exception("�Ҳ�������¼��");
                        }
                        if (bFind)
                        {
                            //���ҵ��ѷ���������¼
                            DataRow row1 = rows_kcph[0];
                            DataRow newrow = tb_temp.NewRow();
                            newrow = row;
                            int dwbl_zs = Convert.ToInt32(row1["dwbl"]);
                            if (dwbl_zs != dwbl_mx)
                            {
                                throw new Exception("��λ��������������ˢ�����ݺ�����");
                            }
                            #region
                            //newrow["yppch2"] = row1["yppch2"];
                            //newrow["ypph2"] = row1["ypph2"];
                            //newrow["ypxq2"] = row1["ypxq2"];
                            //newrow["kcid2"] = row1["kcid2"];
                            //decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj2"]) * dwbl_zs / dwbl_mx);
                            //newrow["jhj2"] = jhj;
                            //newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                            //newrow["ypsl"] = ypsl;
                            //decimal pfj = Convert.ToDecimal(row["������"]);
                            //newrow["������"] = pfj;
                            //newrow["�������"] = Math.Round(pfj * ypsl, 2);
                            //newrow["KDSL"] = ypsl * (-1);//�ɵ�����
                            //newrow["bdelete2"] = row1["bdelete2"];//���ñ�־
                            #endregion
                            /*
                             * 2014-12-11 ���´���
                             */
                            newrow["yppch2"] = row1["yppch2"]; //Modify By Tany 2015-05-07 ��Ϊ����Դ���ԭ��¼����������Ҫ��2��β��
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
                            //δ�ҵ��ѷ���������¼
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
                            int dwbl_fs = Convert.ToInt32(rows_fs[i]["dwbl"]);
                            if (dwbl_zs != dwbl_fs)
                            {
                                throw new Exception("��λ���������仯����ˢ�����ݺ�����");
                            }
                            decimal cks = 0;
                            DataRow row_fs = rows_fs[i];
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

                    #region ���ô���
                    //for (int i = 0; i < rows_zs_wfp.Length; i++)
                    //{
                    //    DataRow newrow = tb_temp.NewRow();
                    //    newrow = rows_zs_wfp[i];

                    //    DataRow[] rows_kcph = new DataRow[] { };

                    //    //�ȷ���ԭ�п��ļ�¼�ϣ��������û�п�棬����һ������ļ�¼
                    //    if (rows_kcph.Length == 0)
                    //    {
                    //        if (pcglfs == "1")
                    //            rows_kcph = tbkcph.Select("cjid=" + newrow["cjid"].ToString() + "", "djsj asc");
                    //        else
                    //            rows_kcph = tbkcph.Select("cjid=" + newrow["cjid"].ToString() + "", "ypxq asc");
                    //        if (rows_kcph.Length == 0)
                    //            rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + newrow["cjid"].ToString() + " order by djsj desc ").Select();
                    //    }

                    //    //����������Ϣ
                    //    DataRow row1 = rows_kcph[0];
                    //    newrow["yppch2"] = row1["yppch"];
                    //    newrow["ypph2"] = row1["ypph"];
                    //    newrow["ypxq2"] = row1["ypxq"];
                    //    newrow["kcid2"] = row1["kcid"];
                    //    decimal jhj = Convert.ToDecimal(row1["jhj"]);
                    //    decimal ypsl = Convert.ToDecimal(newrow["ypsl"]);
                    //    decimal pfj = Convert.ToDecimal(newrow["������"]);
                    //    newrow["�������"] = Convert.ToDecimal(pfj*ypsl);
                    //    newrow["KDSL"] = 0;
                    //    tbpcmx.ImportRow(newrow);
                    //}
                    #endregion

                    #endregion
                }
                catch (Exception eeee)
                {
                    MessageBox.Show(eeee.ToString());
                    this.Cursor = Cursors.Arrow;
                    return;
                }


                string str = "";
                //foreach (DataRow rowtest in tbpcmx.Rows)
                //{
                //    str += rowtest["Ʒ��"].ToString() + " " + rowtest["yppch2"].ToString() + " " + rowtest["ypsl"].ToString() + rowtest["jhj2"].ToString() + "\n";
                //}

                //MessageBox.Show(str);
                //return;
                #region ��ֵ�����
                foreach (DataRow row in tbpcmx.Rows)
                {
                    if (Convert.ToDecimal(row["ypsl"]) < 0)
                    {
                        row["ypcjs"] = row["ypsl"];
                    }
                    else
                    {
                        row["ypcjs"] = 0;
                    }
                }
                #endregion

                #region ���¼���ͳ�쵥 ���ܷ������ε���ϸ
                //���¼���ͳ�쵥 
                string[] GroupbyField3 ={ "����", "����", "Ʒ��", "��Ʒ��", "���", 
                                    "����", "�����", "cjid", "������", "lsj", 
                                "dwbl", "zxdw", "��λ��",
                                "kcid2","jhj2","yppch2","ypph2","ypxq2","ypdw","bdelete2" }; //����kcid2 jhj2  yppch2 ypph2 ypxq2 ypdw
                string[] ComputeField3 ={ "ypsl", "���", "�������", "jhje2", "ypcjs" };
                string[] CField3 ={ "sum", "sum", "sum", "sum", "sum" };
                TrasenFrame.Classes.TsSet xcset4 = new TrasenFrame.Classes.TsSet();
                xcset4.TsDataTable = tbpcmx.Copy();
                DataTable tbhz;
                try
                {
                    DataRow[] selrow = tbpcmx.Select();
                    DataTable tbsel1 = tb.Clone();
                    for (int i = 0; i <= selrow.Length - 1; i++)
                        tbsel1.ImportRow(selrow[i]);
                    tbhz = FunBase.GroupbyDataTable(tbsel1, GroupbyField3, ComputeField3, CField3, null);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }
                if (tbhz.Rows.Count == 0)
                {
                    MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                //string strHz = "���λ���:\n";
                //foreach (DataRow row_hz in tbhz.Rows)
                //{
                //    strHz += (row_hz["Ʒ��"].ToString() + " " + row_hz["yppch2"].ToString() + " " + row_hz["ypsl"].ToString()+" "+ row_hz["jhj2"].ToString() + "\n");
                //}
                //str += strHz;
                //MessageBox.Show(str);
                //return;
                #endregion

                #region ���������
                DataRow[] rows_jy = tbhz.Select(" bdelete2 = '1' and ypsl> 0 ");
                if (rows_jy.Length > 0)
                {
                    DataRow row_jy = rows_jy[0];
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show(row_jy["Ʒ��"].ToString() + " " + row_jy["���"].ToString() + " ���ÿ����������");
                    return;
                }
                #endregion

                //����������
                string[] GroupbyField_jhje ={ };
                string[] ComputeField_jhje ={ "jhje2" };
                string[] CField_jhje ={ "sum" };
                TrasenFrame.Classes.TsSet xcset_jhje = new TrasenFrame.Classes.TsSet();
                xcset_jhje.TsDataTable = tbpcmx.Copy();
                DataTable tbjhje = xcset_jhje.GroupTable(GroupbyField_jhje, ComputeField_jhje, CField_jhje, "");
                decimal _sumjhje = 0;
                if (tbjhje.Rows.Count <= 0)
                {
                    MessageBox.Show("�������ο��ʧ��");
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                _sumjhje = Convert.ToDecimal(Convertor.IsNull(tbjhje.Rows[0]["jhje2"], "0"));

                int _err_code = -1; //���ر���
                string _err_text = "";
                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(); //ʱ��
                string _dept_ly = tb_msg.Rows[0]["dept_ly"].ToString().Trim(); //��ҩ����
                int _py_user = Convert.ToInt32(cmbpyr.SelectedValue); //��ҩ��
                string _bz = this.txtbz.Text.Trim();//��ע
                decimal _sumpfje = Convert.ToDecimal(tbje.Rows[0]["�������"]); //�������
                decimal _sumlsje = Convert.ToDecimal(tbje.Rows[0]["���"]);     //���۽��
                string _stype = this.tabControl1.SelectedTab == this.tabPage1 ? "ͳ��" : "��ҩ";//ͳ�����
                int _msg_type = this.tabControl1.SelectedTab == this.tabPage1 ? 0 : 1; //��Ϣ����
                int lylx = 0; //��ҩ��ʽ
                if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by"
                    || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                    lylx = 1;
                decimal _zje = 0; //�ܽ������ں���������_sumlsje�Ƚϡ����Է����㲻��ȷ

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
                long djh = Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                InstanceForm.BDatabase.BeginTransaction();
                try
                {


                    #region ���ͳ�쵥ͷ��
                    _err_text = "���ͳ�쵥ͷ��";
                    Guid _groupid = Guid.Empty;


                    //��Ҫ���Ͻ������ncq 
                    ZY_FY.SaveTld(djh, InstanceForm.BCurrentDept.DeptId, _sDate, InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(_dept_ly), 0, _py_user, _bz, _sumpfje, _sumlsje, _stype, _menuTag.FunctionTag, out _groupid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, lylx, InstanceForm.BDatabase, _sumjhje);
                    if (_groupid == Guid.Empty || _err_code != 0)
                        throw new Exception(_err_text);
                    #endregion

                    this.myDataGridMx.Tag = _groupid.ToString();
                    this.butfy.Tag = _sDate.Trim();

                    #region ���ͳ�쵥��ϸ��
                    _err_text = "���ͳ�쵥��ϸ��";
                    InstanceForm.DebugView(tbhz);

                    for (int i = 0; i <= tbhz.Rows.Count - 1; i++)
                    {
                        Guid _fyid = Guid.Empty;
                        decimal _qysl = Convert.ToDecimal(tbhz.Rows[i]["�����"]) - Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) < 0 ? Convert.ToDecimal(tbhz.Rows[i]["�����"]) - Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) : 0;
                        decimal _ypcjs = Convert.ToDecimal(tbhz.Rows[i]["ypcjs"]);
                        decimal lsje = Convert.ToDecimal(Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) * Convert.ToDecimal(tbhz.Rows[i]["lsj"]));
                        decimal pfje = Convert.ToDecimal(Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) * Convert.ToDecimal(tbhz.Rows[i]["������"]));
                        _zje = _zje + lsje;
                        //string ssss = tbhz.Rows[i]["kcid2"].ToString();
                        #region ����ͳ�쵥��ϸ
                        ZY_FY.SaveTldMx(_groupid,
                                        Convert.ToInt32(tbhz.Rows[i]["cjid"]),
                                        tbhz.Rows[i]["����"].ToString(),
                                        tbhz.Rows[i]["Ʒ��"].ToString(),
                                        tbhz.Rows[i]["��Ʒ��"].ToString(),
                                        tbhz.Rows[i]["���"].ToString(),
                                        Yp.SeekYpdw(Convert.ToInt32(tbhz.Rows[i]["zxdw"]), InstanceForm.BDatabase),
                                        tbhz.Rows[i]["����"].ToString(),
                                        Convert.ToDecimal(tbhz.Rows[i]["�����"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["ypsl"]),
                                        _qysl,
                                        Convert.ToDecimal(tbhz.Rows[i]["������"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["lsj"]),
                                        pfje,
                                        lsje,
                                        Convert.ToString(tbhz.Rows[i]["����"]),
                                        Convert.ToInt32(tbhz.Rows[i]["dwbl"]),
                                        true,
                                        InstanceForm.BCurrentDept.DeptId,
                                        tbhz.Rows[i]["ypph2"].ToString(),//����
                                        tbhz.Rows[i]["��λ��"].ToString(),
                                        out _fyid,
                                        out _err_code,
                                        out _err_text, InstanceForm.BDatabase,
                                        Convert.ToDecimal(Convertor.IsNull(tbhz.Rows[i]["jhj2"], "0")),//������
                                        Convert.ToDecimal(tbhz.Rows[i]["jhje2"]),//�������
                                        tbhz.Rows[i]["ypxq2"].ToString(),
                                        Convertor.IsNull(tbhz.Rows[i]["yppch2"].ToString(), ""),
                                        new Guid(tbhz.Rows[i]["kcid2"].ToString()),
                                        true, _ypcjs);
                        if (_fyid == Guid.Empty || _err_code != 0)
                            throw new Exception(_err_text);
                        #endregion
                    }

                    #endregion

                    DateTime tnow = Convert.ToDateTime(InstanceForm.BDatabase.GetDataResult(InstanceForm.BDatabase.GetServerTimeString()).ToString());
                    string err_text_t = "";
                    int err_code_t = -1;
                    InstanceForm.DebugView(tbpcmx);
                    #region ���ͳ�쵥��ϸ���ű�yf_tldmx_fee ������������λ����
                    int pxxh_fee = 0;
                    foreach (DataRow row_fee in tbpcmx.Rows)
                    {
                        if (Convert.ToDecimal(row_fee["ypsl"]) == 0)
                            throw new Exception(string.Format("{0}ҩƷ��ҩ����Ϊ0,��������ֹ,����ϵ����Ա!", row_fee["Ʒ��"].ToString()));
                        pxxh_fee += 1;
                        ZY_FY.SaveTldMxFee(Guid.Empty, _groupid,
                            Convert.ToInt32(row_fee["cjid"]),
                            row_fee["����"].ToString(),
                            row_fee["Ʒ��"].ToString(),
                            row_fee["Ӣ����"].ToString(),
                            row_fee["��Ʒ��"].ToString(),
                            row_fee["���"].ToString(),
                            row_fee["����"].ToString(),
                            row_fee["ypdw"].ToString(),
                            Convert.ToInt32(row_fee["dwbl"]),
                            Convert.ToDecimal(row_fee["ypsl"]),
                            Convert.ToInt32(row_fee["����"]),
                            new Guid(row_fee["kcid2"].ToString()),
                            Convertor.IsNull(row_fee["yppch2"], ""),
                            Convertor.IsNull(row_fee["ypph2"], ""),
                            row_fee["ypxq2"].ToString(),
                            Convert.ToDecimal(row_fee["jhj2"]),
                            Convert.ToDecimal(row_fee["������"]),
                            Convert.ToDecimal(row_fee["lsj"]),
                            Convert.ToDecimal(row_fee["jhje2"]),
                            Convert.ToDecimal(row_fee["�������"]),
                            Convert.ToDecimal(row_fee["���"]),
                            new Guid(row_fee["zy_id"].ToString()),
                            new Guid(Convertor.IsNull(row_fee["cz_id"], Guid.Empty.ToString())),
                            new Guid(row_fee["סԺid"].ToString()),
                            row_fee["����"].ToString(), row_fee["סԺ��"].ToString(), Convert.ToInt32(row_fee["Ӥ��id"]),
                            Convertor.IsNull(row_fee["ҽ������"], ""),
                            Convert.ToDateTime(row_fee["��������"].ToString()),
                            Convert.ToInt32(Convertor.IsNull(row_fee["���˿���id"], "0")),
                            Convert.ToInt32(Convertor.IsNull(row_fee["��������id"], "0")),
                            Convert.ToInt32(Convertor.IsNull(row_fee["����ҽ��id"], "0")),
                            Convert.ToInt32(Convertor.IsNull(row_fee["�ܴ�ҽ��id"], "0")),
                            Convert.ToInt32(Convertor.IsNull(row_fee["ִ�п���id"], "0")),
                            Convert.ToDateTime(row_fee["�շ�����"] == DBNull.Value ? DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss") : row_fee["�շ�����"].ToString()),
                            Convert.ToInt32(Convertor.IsNull(row_fee["�շ�Աid"], "0")),
                            Convertor.IsNull(row_fee["�÷�"].ToString(), ""),
                            Convertor.IsNull(row_fee["����"].ToString(), ""),
                            Convertor.IsNull(row_fee["Ƶ��"].ToString(), ""),
                            Convertor.IsNull(row_fee["����"].ToString(), "0"),
                            row_fee["������λ"].ToString(),
                            0, pxxh_fee, InstanceForm.BCurrentUser.EmployeeId, tnow, InstanceForm.BCurrentUser.EmployeeId, tnow, InstanceForm._menuTag.Jgbm,
                            out err_code_t, out err_text_t, InstanceForm.BDatabase);
                        if (err_code_t != 0)
                        {
                            throw new Exception(err_text_t);
                        }


                    }
                    #endregion

                    #region ��֤���
                    _err_text = "������";
                    _zje = Math.Round(_zje, 0);
                    _sumlsje = Math.Round(_sumlsje, 0);
                    if (Math.Abs(_zje - (_sumlsje)) > 1)
                    {
                        //MessageBox.Show("��������ܽ��" + _zje.ToString() + " ��������ϸ�ܽ��" + _sumlsje.ToString() + " ����͹���Ա��ϵ");
                    }
                    #endregion

                    //û�мǷѵļ�¼
                    DataRow[] rows = tb.Select("ѡ��=true and charge_bit='0'");
                    //�ѼǷѵļ�¼
                    DataRow[] rows2 = tb.Select("ѡ��=true  and charge_bit='1'");

                    string ssql = "";
                    decimal _execId = 0;

                    #region ����û�мǷѵļ�¼
                    _err_text = "����û�мǷѵļ�¼";
                    //����û�мǷѵļ�¼ //ʱ���
                    ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                    _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ", '" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + _groupid + "',1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                    if (rows.Length > 0)
                    {
                        int iii = ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                        if (rows.Length != iii)
                        {
                            if (isPivasYF)
                            {
                                butref1_Click(null, null);
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!\r\r  ���ܲ���������ת���������  \r\r��������ˢ�����ݺ�����!");
                            }
                            else
                            {
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!��������ˢ�����ݺ�����!");
                            }
                        }
                    }
                    #endregion

                    #region �����ѼǷѵļ�¼
                    _err_text = "�����ѼǷѵļ�¼";
                    //�����ѼǷѵļ�¼ //ʱ���
                    ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                    _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                    for (int i = 0; i <= rows2.Length - 1; i++)
                    {
                        ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows2[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + _groupid + "',1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }

                    if (rows2.Length > 0)
                    {
                        int iii = ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                        if (rows2.Length != iii)
                        {
                            if (isPivasYF)
                            {
                                butref1_Click(null, null);
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!\r\r  ���ܲ���������ת���������  \r\r��������ˢ�����ݺ�����!");
                            }
                            else
                            {
                                throw new System.Exception("�����������ø���ʱ�������µļ�¼���뷢ҩ��¼�������,�����ع�!��������ˢ�����ݺ�����!");
                            }
                        }
                    }
                    #endregion

                    #region �޽Ӳ����·�ҩ��Ϣ
                    _err_text = "�޽Ӳ����·�ҩ��Ϣ";
                    if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_ly")
                    {
                        _err_text = "����zy_apply_drug";
                        //����zy_apply_drug
                        for (int i = 0; i <= tb_msg.Rows.Count - 1; i++)
                            ZY_FY.UpdateMsg(new Guid(tb_msg.Rows[i]["apply_id"].ToString()), _groupid, InstanceForm.BDatabase);

                        _err_text = "��û�з�ҩ�������µ���Ϣ";
                        //��û�з�ҩ�������µ���Ϣ
                        for (int i = 0; i <= tb_Umsg.Rows.Count - 1; i++)
                        {
                            //�ж��Ƿ񲿷ַ�ҩ
                            bool byes = false;
                            for (int j = 0; j <= tb_msg.Rows.Count - 1; j++)
                            {
                                if (new Guid(tb_Umsg.Rows[i]["apply_id"].ToString().Trim()) == new Guid(tb_msg.Rows[j]["apply_id"].ToString().Trim()))
                                    byes = true;
                            }

                            Guid _apply_id = Guid.Empty;
                            if (byes == true)
                            {
                                //������Ϣ��
                                ZY_FY.SaveApplyDrug(tb_Umsg.Rows[i]["apply_date"].ToString().Trim(), InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(_dept_ly), InstanceForm.BCurrentDept.DeptId, _msg_type, tb_Umsg.Rows[i]["lyflcode"].ToString().Trim(), out _apply_id, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                                if (_apply_id == Guid.Empty)
                                    throw new Exception("����,������Ϣʱ,��ϢIDΪ��");
                                DataRow[] RowUmsg = tb.Select("ѡ��=false and apply_id='" + tb_Umsg.Rows[i]["apply_id"].ToString().Trim() + "'");

                                //���´���Ϣ����ϸ
                                for (int x = 0; x <= RowUmsg.Length - 1; x++)
                                    ZY_FY.UpdateFeeChargeApplyID(_apply_id, new Guid(RowUmsg[x]["zy_id"].ToString()), InstanceForm.BDatabase);
                            }
                        }
                    }
                    #endregion

                    #region  ʹ�÷ְ��� ---��ҩ LQQ 2013-4-27
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by"
                        || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                    {
                        DataTable dt_byjCS = InstanceForm.BDatabase.GetDataTable("select ZT from yk_config where BH=153 and deptid='" + InstanceForm.BCurrentDept.DeptId + "'");
                        if (dt_byjCS != null)
                        {
                            if (dt_byjCS.Rows.Count > 0)
                            {
                                if (Convert.ToString(dt_byjCS.Rows[0][0]) == "1")
                                {
                                    ParameterEx[] parameters = new ParameterEx[2];
                                    parameters[0].Value = "00000000-0000-0000-0000-000000000000";
                                    parameters[1].Value = _groupid;

                                    string gid = _groupid.ToString();

                                    parameters[0].Text = "@fyid";
                                    parameters[1].Text = "@V_groupid";

                                    DataSet dset = new DataSet();
                                    InstanceForm.BDatabase.AdapterFillDataSet("sp_yf_zyfy_byj", parameters, dset, "kss", 240);
                                }
                            }
                        }
                    }

                    #endregion
                    InstanceForm.BDatabase.CommitTransaction();

                    //Modify by jchl 2015-06-27 �ύ�����,�������׳��쳣����ع�����
                    try
                    {
                        #region ѡ���ҩ��ʽ
                        int execResult = 0;
                        DialogResult retDialog = DialogResult.None;
                        string[] retInfo = null;
                        bool isDisPlay = false;
                        string exceptionInfo = string.Empty;
                        if (_chineseName.Contains("�ڷ���ҩ��") && InstanceForm.BCurrentDept.DeptId == 359)
                        {
                            FrmSeleByType bylxFrm = null;
                            try
                            {
                                isDisPlay = true;
                                bylxFrm = new FrmSeleByType(_groupid.ToString());
                                bylxFrm.UpdateFylx += new FrmSeleByType.SelectBylx(bylxFrm_UpdateFylx);
                                bylxFrm.StartPosition = FormStartPosition.CenterScreen;
                                bylxFrm.Activate();
                                retDialog = bylxFrm.ShowDialog();
                                retInfo = bylxFrm.ExecResultInfo;
                            }
                            catch (Exception err)
                            {
                                exceptionInfo = err.Message;
                                isDisPlay = false;
                            }
                        }

                        if (InstanceForm.BCurrentDept.DeptId == 359)
                        {
                            object[] param = new object[] 
                        {         
                            InstanceForm.BCurrentDept.DeptId,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            _chineseName, 
                            retInfo !=null && retInfo.Length >1 ? retInfo[0]:"" , 
                            retInfo !=null && retInfo.Length >1 ? retInfo[1]:"",
                            retDialog.ToString(),
                            string.IsNullOrEmpty( exceptionInfo)? "��": exceptionInfo,
                            _dept_ly
                        };
                            //{סԺҩ��} {18��00} ��{�ڷ���ҩ��}ѡ���ҩ��ʽ,ִ��{sql}����Ӱ������{1},ѡ�񴰿ڷ�������{}
                            string logInfo = string.Format("{0}ҩ����{1}ʱ{2}ѡ���ҩ��ʽ,Ϊ{7}���ҷ�ҩ,ִ��{3}����Ӱ������{4},ѡ�񴰿ڷ�������{5},�쳣��ϢΪ{6}", param);
                            ThrowTechError(logInfo);
                        }
                        #endregion

                        #region �ύ���񲢴�ӡ
                        if (_menuTag.Function_Name != "Fun_ts_yf_zyfy_tld_by"
                            || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                        {
                            if (MessageBox.Show("��ҩ�ɹ�,��Ҫ��ӡ��", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                this.butprint_Click(sender, e);

                                #region Modify by dyw 2014/6/30����
                                //if (_menuTag.Function_Name != "Fun_ts_yf_zyfy_tld_by")
                                //    this.butprint_Click(sender, e);
                                //else
                                //    this.butprintmx_Click(sender, e);
                                #endregion
                            }
                        }
                        MessageBox.Show("��ҩ�ɹ�", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion

                        #region �޽Ӳ����Ƴ���ҩ��Ϣ
                        if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_ly")
                        {
                            //�Ƴ���Ϣ
                            System.Windows.Forms.TreeListView TreeListView;
                            if (this.tabControl1.SelectedTab == this.tabPage1)
                                TreeListView = this.treeListView1;
                            else
                                TreeListView = this.treeListView2;

                            for (int i = 0; i <= tb_msg.Rows.Count - 1; i++)
                                RemoveItem(TreeListView, _dept_ly, tb_msg.Rows[i]);
                            for (int i = 0; i <= tb_Umsg.Rows.Count - 1; i++)
                                RemoveItem(TreeListView, _dept_ly, tb_Umsg.Rows[i]);
                            tb.Rows.Clear();
                        }
                        else
                        {
                            tb = (DataTable)this.myDataGridMx.DataSource;
                            tb.Rows.Clear();
                        }
                        #endregion
                    }
                    catch { }
                }
                catch (System.Exception err)
                {
                    this.myDataGridMx.Tag = null;
                    this.butfy.Tag = "";
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message + "\t" + err.StackTrace + "\t" + err.Source);
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
                #endregion
            }
        }

        /// <summary>
        /// ���PIVAS�����״̬
        /// </summary>
        /// <param name="tb"></param>
        private void CheckPvsSH(DataTable tb)
        {
            string sql = "";
            string msg = "";
            if (isPivasYF && tb != null && tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tb.Rows[i]["ѡ��"]))
                    {
                        //������õĿ�����pivas��Ӧ��ϵ�����棬����֤ Modify By Tany 2015-04-21
                        if (PivasDept.Select("dept_id=" + tb.Rows[i]["���˿���id"].ToString()).Length > 0)
                        {
                            sql = "select is_pvschk from zy_orderrecord a inner join zy_fee_speci b on a.order_id=b.order_id where b.id='" + tb.Rows[i]["zy_id"].ToString() + "'";
                            int isPvschk = Convert.ToInt16(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sql), "0"));
                            if (isPvschk != 1)
                            {
                                tb.Rows[i]["ѡ��"] = false;
                                msg += "�ڡ�" + tb.Rows[i]["���"].ToString().Trim() + "���У�" + tb.Rows[i]["Ʒ��"].ToString().Trim() + " " + tb.Rows[i]["���"].ToString().Trim() + "\r\n";
                            }
                        }
                    }
                }
            }
            if (msg != "")
            {
                MessageBox.Show("����ҩƷδ����PIVAS��˻����δͨ������ʱ���ܷ�ҩ���Ѿ�ȡ�����乴ѡ��\r\n\r\n" + msg);
            }
        }

        private string[] bylxFrm_UpdateFylx(object[] sender)
        {
            if (sender == null || sender.Length == 0)
                return null;

            int bylx = Convert.ToInt32(sender[0]);
            string tldid = sender[1].ToString();
            string outXml = string.Empty;
            if (bylx == 1)
            {
                string postString = string.Empty;
                ParameterEx[] parameters_tsbyj = new ParameterEx[1];
                parameters_tsbyj[0].Value = tldid;
                parameters_tsbyj[0].Text = "@group_id";
                DataTable tbbyjmx = InstanceForm.BDatabase.GetDataTable("SP_WHZXYY_BYJ_TS", parameters_tsbyj, 60);
                tbbyjmx.TableName = "root";
                if (tbbyjmx != null && tbbyjmx.Rows.Count > 0)
                {
                    DateTime currTime = DateTime.Now;
                    Dictionary<string, DateTime> dict = new Dictionary<string, DateTime>();
                    int i = 0;
                    foreach (DataRow tmpRow in tbbyjmx.Rows)
                    {
                        if (!dict.ContainsKey(tmpRow["wardCd"].ToString().Trim()))
                        {
                            if (i > 0)
                            {
                                currTime = currTime.AddSeconds(1);
                            }
                            dict.Add(tmpRow["wardCd"].ToString().Trim(), currTime);
                            i++;
                        }
                    }
                    for (int x = 0; x < tbbyjmx.Rows.Count; x++)
                    {
                        tbbyjmx.Rows[x].BeginEdit();
                        tbbyjmx.Rows[x]["makerecTime"] = dict[tbbyjmx.Rows[x]["wardCd"].ToString().Trim()];
                        tbbyjmx.Rows[x].EndEdit();
                    }
                    postString = DataTableToXmlEx(tbbyjmx, "tsDoctorAdvice");
                }
                else
                {
                    //MessageBox.Show("δ��ѯ����ҩ����!");
                    return null;
                }
                postString = "<" + tbbyjmx.TableName + ">" + postString + "</" + tbbyjmx.TableName + ">";
                TsByj.getTsDoctorAdvice ts = new TsByj.getTsDoctorAdvice();
                outXml = ts.CallgetTsDoctorAdvice(postString);
            }
            if (outXml == "1" || bylx == 2) //������Ͱ�ҩ���ݳɹ� ���ֹ���ҩ��ʽ  ��¼���β���
            {
                if (bylx > 0 && !string.IsNullOrEmpty(tldid))
                {
                    string sql = string.Format("update yf_tld set bylx = {0} where groupid = '{1}'", bylx, tldid);
                    int execResult = InstanceForm.BDatabase.DoCommand(sql);
                    return new string[] { sql, execResult.ToString() };
                }
            }
            return null;
        }

        private static string DataTableToXmlEx(DataTable dt, string rowname)
        {
            if (dt != null)
            {
                if (rowname == "")
                {
                    rowname = "ROW";
                }
                string returnValue = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    returnValue += "<" + rowname + ">";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string colName = dt.Columns[j].ColumnName.ToString().Trim();
                        returnValue += "<" + colName + ">" + Convertor.IsNull(dt.Rows[i][j], "") + "</" + colName + ">";
                    }
                    returnValue += "</" + rowname + ">";
                }

                return returnValue;
            }
            else
            {
                return "";
            }
        }

        private void ThrowTechError(string logInfo)
        {
            try
            {
                string ErrPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, "��ҩ����־");
                if (!Directory.Exists(ErrPath))
                {
                    Directory.CreateDirectory(ErrPath);
                }
                StreamWriter txtWriter = new StreamWriter(string.Format(@"{0}\{1}-ByjLog.txt", ErrPath, DateTime.Now.ToString("yyyy-MM-dd")), true);
                txtWriter.WriteLine("---------------------------------------------------------");
                txtWriter.WriteLine(logInfo);
                txtWriter.WriteLine("---------------------------------------------------------");
                txtWriter.WriteLine();
                txtWriter.Close();
            }
            catch
            {
                MessageBox.Show("������־��¼ʧ��!", "��ʾ");
            }
        }

        //�Ƴ���Ϣ
        private void RemoveItem(System.Windows.Forms.TreeListView TreeListView, string dept_ly, DataRow row)
        {
            for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
            {
                if (TreeListView.Items[i].Tag.ToString().Trim() == dept_ly.Trim())
                {
                    for (int j = 0; j <= TreeListView.Items[i].Items.Count - 1; j++)
                    {
                        if (row["apply_id"].ToString().Trim() == TreeListView.Items[i].Items[j].Tag.ToString().Trim())
                        {
                            TreeListView.Items[i].Items[j].Remove();
                        }
                    }
                }
            }

            for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
            {
                if (TreeListView.Items[i].Items.Count == 0)
                    TreeListView.Items[i].BackColor = Color.White;
                TreeListView.Items[i].SubItems[0].BackColor = Color.White;
                TreeListView.Items[i].SubItems[1].BackColor = Color.White;
                TreeListView.Items[i].SubItems[2].BackColor = Color.White;
                TreeListView.Items[i].SubItems[3].BackColor = Color.White;
            }
        }

        #region �������
        //���ҳ��
        private void ClearData()
        {

            DataTable tbmx = (DataTable)this.myDataGridMx.DataSource;
            tbmx.Rows.Clear();

            for (int i = 1; i <= this.tabControl2.TabPages.Count - 1; i++)
            {
                for (int j = 0; j <= this.tabControl2.TabPages[i].Controls.Count - 1; j++)
                {
                    //���������
                    if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                    {
                        TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
                        DataTable mytb = (DataTable)mydatagrid.DataSource;
                        mytb.Rows.Clear();
                    }
                }
            }
        }

        //������Ŀ
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            {
            }
            else
            {
                return;
            }

            try
            {
                string[] GrdMappingName;
                int[] GrdWidth;
                string[] sfield;
                string ssql = "";
                DataRow row;

                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 0:
                        if (control.Text.Trim() == "")
                            return;
                        GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "�����", "��λ", "����", "DWBL", "������", "���ۼ�", "����", "ƴ����", "�����" };
                        GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 65, 40, 40, 0, 60, 60, 70, 60, 60 };
                        sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                        ssql = "select distinct a.ggid,cjid,0  rowno,yppm,ypgg,s_sccj sccj,cast(kcl as float) kcl,dbo.fun_yp_ypdw(ypdw) ypdw,(case when bdelete_kc=1 then '��' else '' end) jy,1 dwbl,pfj,lsj,shh,pym,wbm from vi_yf_kcmx a,yp_ypbm b " +
                                "where a.ggid=b.ggid and deptid=" + InstanceForm.BCurrentDept.DeptId + "  and a.ypzlx in(select ypzlx from yp_gllx where deptid=" + InstanceForm.BCurrentDept.DeptId + ")  ";

                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                        f2.Location = point;
                        f2.Width = 700;
                        f2.Height = 300;
                        f2.ShowDialog(this);
                        row = f2.dataRow;
                        if (row != null)
                        {
                            control.Text = row["yppm"].ToString();
                            control.Tag = row["cjid"].ToString();
                            this.SelectNextControl((Control)sender, true, false, true, true);

                            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                            DataRow[] rowX = tb.Select("cjid=" + row["cjid"].ToString() + "");
                            if (rowX.Length > 0)
                            {
                                int nrow = Convert.ToInt32(rowX[0]["���"]);
                                this.myDataGridMx.CurrentCell = new DataGridCell(nrow - 1, 1);

                            }
                        }
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��������" + err.Message);
            }
        }

        //ˢ����Ϣ
        private void butref1_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                if (this.tabControl1.SelectedTab == this.tabPage1)
                    AddMssageTree(Convert.ToInt32(Convertor.IsNull(cmbbs1.SelectedValue, "0")), this.treeListView1, this.tabPage1);
                if (this.tabControl1.SelectedTab == this.tabPage2)
                    AddMssageTree(Convert.ToInt32(Convertor.IsNull(cmbbs2.SelectedValue, "0")), this.treeListView2, this.tabPage2);
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

        //ˢ��ͳ����Ϣ
        private void butref_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                AddTldTree(Convert.ToInt32(Convertor.IsNull(cmbbs3.SelectedValue, "0")), this.treeListView3, this.tabPage3, this.cmbtype.Text.Trim());
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

        //ѡ������ͳ�죿��ҩ��ͳ�쵥?
        private void tabControl1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.tabControl1.SelectedTab == this.tabPage1)
                {
                    //CshMxGrid(this.myDataGridMx);
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[1].Width = 35;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[2].Width = 30;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[3].Width = 55;//0
                    DataTable tbb = (DataTable)this.myDataGridMx.DataSource;
                    tbb.Rows.Clear();
                    for (int i = 0; i <= this.treeListView1.Items.Count - 1; i++)
                        this.ChangeTreeItemColorToWhite(treeListView1.Items[i]);
                    //����ͳ�ƻ��ܵ�
                    computeTld();
                    butfy.Enabled = true;
                    btCharge.Enabled = true;//Modify By Tany 2015-03-17
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    chkAllFee.Visible = true;//Modify By Tany 2015-03-17
                    chkUncharge.Visible = true;//Modify By Tany 2015-03-17
                    chkCharged.Visible = true;//Modify By Tany 2015-03-17
                    btncb.Enabled = false;

                    //checkBox4.Location = checkBox3.Location;
                    //dateTimePicker1.Location = checkBox1.Location;

                    checkBox4.Location = cbxfirstPoint;
                    dateTimePicker1.Location = dtpfirstPoint;
                }

                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    //CshMxGrid(this.myDataGridMx);
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[1].Width = 35;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[2].Width = 35;//0
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[3].Width = 55;//0
                    DataTable tbb = (DataTable)this.myDataGridMx.DataSource;
                    tbb.Rows.Clear();
                    for (int i = 0; i <= this.treeListView2.Items.Count - 1; i++)
                        this.ChangeTreeItemColorToWhite(treeListView2.Items[i]);
                    //����ͳ�ƻ��ܵ�
                    computeTld();
                    butfy.Enabled = true;
                    btCharge.Enabled = true;//Modify By Tany 2015-03-17
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    chkAllFee.Visible = true;//Modify By Tany 2015-03-17
                    chkUncharge.Visible = true;//Modify By Tany 2015-03-17
                    chkCharged.Visible = true;//Modify By Tany 2015-03-17
                    btncb.Enabled = false;

                    //checkBox4.Location = checkBox3.Location;
                    //dateTimePicker1.Location = checkBox1.Location;

                    checkBox4.Location = cbxfirstPoint;
                    dateTimePicker1.Location = dtpfirstPoint;
                }

                if (this.tabControl1.SelectedTab == this.tabPage3)
                {
                    //CshMxGrid(this.myDataGridMx);
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[1].Width = 0;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[2].Width = 35;//0
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[3].Width = 55;//0
                    DataTable tbb = (DataTable)this.myDataGridMx.DataSource;
                    tbb.Rows.Clear();

                    //Modify by dyw 2014/6/29
                    chkmx.Checked = true;
                    butref_Click(butref, new EventArgs());

                    //����ͳ�ƻ��ܵ�
                    computeTld();

                    butfy.Enabled = false;
                    btCharge.Enabled = false;//Modify By Tany 2015-03-17
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    checkBox3.Visible = false;
                    chkAllFee.Visible = false;//Modify By Tany 2015-03-17
                    chkUncharge.Visible = false;//Modify By Tany 2015-03-17
                    chkCharged.Visible = false;//Modify By Tany 2015-03-17
                    if (InstanceForm.BCurrentDept.DeptId == 359)
                        btncb.Enabled = true;

                    checkBox4.Location = checkBox3.Location;
                    dateTimePicker1.Location = new Point(checkBox1.Location.X + 20, checkBox1.Location.Y);
                }
                panel_top.Refresh();
                dateTimePicker1.Refresh();
                this.statusBar1.Panels[0].Text = "";
                this.statusBar1.Panels[1].Text = "";
                this.statusBar1.Panels[2].Text = "";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        //���
        private void butqc_Click(object sender, System.EventArgs e)
        {
            this.txtypmc.Text = "";
            this.txtxm.Text = "";
            this.txtzyh.Text = "";
            this.txtcw.Text = "";
        }


        //ѡ��ͳ�첡��
        private void cmbbs1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AddMssageTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs1.SelectedValue, "0")), this.treeListView1, this.tabPage1);
        }

        //ѡ����ҩ����
        private void cmbbs2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AddMssageTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs2.SelectedValue, "0")), this.treeListView2, this.tabPage2);
        }


        private void cmbbs3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AddTldTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs3.SelectedValue, "0")), this.treeListView3, this.tabPage3, this.cmbtype.Text.Trim());
        }

        //����Ϣ�ı侰��ɰ�ɫ
        private void ChangeTreeItemColorToWhite(System.Windows.Forms.TreeListViewItem item)
        {
            item.BackColor = Color.White;
            item.SubItems[0].BackColor = Color.White;
            item.SubItems[1].BackColor = Color.White;
            item.SubItems[2].BackColor = Color.White;
            item.SubItems[3].BackColor = Color.White;
            item.Selected = false;

            for (int i = 0; i <= item.Items.Count - 1; i++)
            {
                item.Items[i].BackColor = Color.White;
                item.Items[i].SubItems[0].BackColor = Color.White;
                item.Items[i].SubItems[1].BackColor = Color.White;
                item.Items[i].SubItems[2].BackColor = Color.White;
                item.Items[i].SubItems[3].BackColor = Color.White;
                item.Items[i].Selected = false;
                ChangeTreeItemColorToWhite(item.Items[i]);
            }
        }

        //����ɫ�ı��¼�
        private void colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
            DataTable tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
            if (e.Row > tb.Rows.Count - 1)
                return;
            if (Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["��ҩ��"], "0")) > Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["�����"], "0")))
                e.ForeColor = Color.Red;
            else
                e.ForeColor = Color.Black;


        }

        //����ɫ�ı��¼�
        private void myDataGridMx_colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
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
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }



                if (e.Row > tb.Rows.Count - 1)
                    return;
                if (Convert.ToBoolean(tb.Rows[e.Row]["ѡ��"]) == false)
                    e.ForeColor = Color.Gray;
                else
                {
                    decimal sl_kc = 0;
                    if (Convert.ToString(tb.Rows[e.Row]["�����"]) != "")
                        sl_kc = Convert.ToDecimal(tb.Rows[e.Row]["�����"]);
                    if (Convert.ToDecimal(tb.Rows[e.Row]["����"]) > sl_kc)
                        e.ForeColor = Color.Red;
                    else
                        e.ForeColor = Color.Blue;
                }

                if (e.Row == this.myDataGridMx.CurrentCell.RowNumber)
                    e.BackColor = Color.Yellow;
                else
                {
                    e.BackColor = Color.White;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //			
        }



        #endregion

        #region ��ӡ��ť
        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                Guid _groupid = new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString()));
                //_groupid = new Guid(Convertor.IsNull("691aa94e-90ff-403a-aaa4-a0d60006ebc0", Guid.Empty.ToString()));
                if (_groupid == Guid.Empty)
                {
                    MessageBox.Show("���뷢ҩ����ܴ�ӡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //���´�ӡ����
                //string ssql = "update yf_tld set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
                //int n = InstanceForm.BDatabase.DoCommand(ssql);
                //if (n == 0)
                //{

                //    ssql = "update yf_tld_h set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
                //    n = InstanceForm.BDatabase.DoCommand(ssql);
                //}


                DataTable tb = ZY_FY.SelectTldHz(_groupid.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                #region Modify by dyw 2014/7/1�������κ�ϲ����δ�ӡ
                bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//�������ι���
                if (bpcgl)
                {

                    string[] GroupbyField3 ={ "cjid", "ypgg", "ypdw", "dept_ly", "fyr", 
                        "pyr", "bprint", "fyrq", "����", "djh","ypspm","sccj","lsj","shh",
                        "hwh","ypjx" ,"stype","hzdycs","ypzddw","DWBL","yppm"}; //����kcid2 jhj2  yppch2 ypph2 ypxq2 ypdw
                    string[] ComputeField3 ={ "ypsl", "lsje", "ypcjs" };
                    string[] CField3 ={ "sum", "sum", "sum" };

                    //Modify by jchl
                    //TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    //xcset1.TsDataTable = tb.Copy();
                    //DataTable tbTemp = xcset1.GroupTable(GroupbyField3, ComputeField3, CField3, "");

                    DataTable tbTemp = GroupByDataTable(tb, GroupbyField3, ComputeField3, CField3);
                    tb.Clear();
                    tb = tbTemp.Copy();

                }
                #endregion

                // InstanceForm.BDatabase.GetDataTable(@" select ypjx,a.groupid,djh,deptid,fyrq,fyr,dept_ly,nurseid,pyr,bz,sumpfje,sumlsje,
                //yppm ,ypspm ,ypgg ,sccj ,lsj ,kcl ,ypsl ,qysl ,ypdw ,lsje ,shh ,cjid,ydwbl,tlfl ����,
                //stype,b.id,isnull(bprint,1) bprint,hwh,hzdycs  from yf_tld_h a inner join yf_tldmx_h b 
                //on a.groupid=b.groupid left join yp_tlfl c on b.tlfl=c.name where  
                //a.groupid='" + _groupid + "' order by hwh,yppm");//ZY_FY.SelectTldHz(_groupid.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);// new DataTable();

                if (this.tabControl1.SelectedTab == this.tabPage3 || tb.Rows.Count == 0)
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
                }
                this.Cursor = PubStaticFun.WaitCursor();

                PrintInfo(tb, _groupid);


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
        #endregion

        #region ��ӡ����
        private void PrintInfo(DataTable tb, Guid _groupid)
        {
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

            if (tb.Rows.Count == 0)
                return;
            string lydw = Yp.SeekDeptName(Convert.ToInt32(tb.Rows[0]["dept_ly"]), InstanceForm.BDatabase);
            string fyr = Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["fyr"]), InstanceForm.BDatabase);
            string pyr = Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["pyr"]), InstanceForm.BDatabase);
            DataRow myrow;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (Convertor.IsNull(tb.Rows[i]["bprint"], "0") == "1")
                {
                    myrow = Dset.��ҩ��ϸ��.NewRow();
                    myrow["yppm"] = Convert.ToString(tb.Rows[i]["yppm"]);
                    myrow["ypspm"] = Convert.ToString(tb.Rows[i]["ypspm"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["ypgg"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["sccj"]);
                    myrow["lsj"] = Convert.ToDecimal(tb.Rows[i]["lsj"]);
                    myrow["ypsl"] = Convert.ToDecimal(tb.Rows[i]["ypsl"]);
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["ypdw"]);
                    myrow["lsje"] = Convert.ToDecimal(tb.Rows[i]["lsje"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["shh"]);
                    myrow["hwh"] = Convert.ToString(tb.Rows[i]["hwh"]);
                    myrow["tlfl"] = Convert.ToString(tb.Rows[i]["����"]) + " ( No." + tb.Rows[0]["djh"].ToString() + " )";
                    myrow["fyrq"] = Convert.ToString(tb.Rows[i]["fyrq"]);
                    myrow["fyr"] = fyr;
                    myrow["pyr"] = pyr;
                    myrow["lydw"] = lydw;
                    myrow["bz"] = Convert.ToDecimal(tb.Rows[i]["ypsl"]) >= 0 ? "" : "��ҩ";
                    myrow["groupid"] = "( No." + tb.Rows[0]["djh"].ToString() + " )";
                    myrow["ypjx"] = Convert.ToString(tb.Rows[i]["ypjx"]);
                    myrow["bz1"] = Convert.ToDecimal(tb.Rows[i]["ypcjs"]);
                    myrow["bz2"] = Convertor.IsNull(tb.Rows[i]["ypzddw"], "");
                    myrow["bz3"] = tb.Rows[i]["DWBL"];
                    Dset.��ҩ��ϸ��.Rows.Add(myrow);
                }

            }


            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Text = "title";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "" + InstanceForm.BCurrentDept.DeptName + tb.Rows[0]["stype"].ToString().Trim() + "" + "��";
            parameters[1].Text = "lydwHeadText";
            parameters[1].Value = tb.Rows[0]["stype"].ToString().Trim() == "ͳ��" ? "��ҩ����:" : "��ҩ����:";
            parameters[2].Text = "dycs";
            int dycs = 0;
            if (tb.Rows[0]["hzdycs"].ToString() == "0")
                dycs = 1;
            else
                dycs = Convert.ToInt32(tb.Rows[0]["hzdycs"].ToString()) + 1;

            parameters[2].Value = dycs.ToString();

            string[] str ={ "" };
            str[0] = "update yf_tld set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
            bool bview = this.chkprintview.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_ҩƷͳ�쵥.rpt", parameters, bview, str);
            f._sqlStr = str;
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();
        }
        #endregion

        private void butselect_Click(object sender, System.EventArgs e)
        {

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                tb.Rows[i]["ѡ��"] = (short)1;
            this.computeTld();
        }

        private void butunselect_Click(object sender, System.EventArgs e)
        {

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                int selected = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["ѡ��"], "0"));
                tb.Rows[i]["ѡ��"] = selected == 1 ? (short)0 : (short)1;
            }
            this.computeTld();
        }

        private void myDataGridMx_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == this.tabPage3)
                return;

            if ((new SystemCfg(8012)).Config != "1")
                return;

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            if (tb.Rows.Count == 0)
                return;
            int nrow = this.myDataGridMx.CurrentCell.RowNumber;
            int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
            Ypcj cj = new Ypcj(cjid, InstanceForm.BDatabase);

            DataTable tab = tb.Clone();
            DataRow[] rows;
            string swhere = " cjid=" + cjid + " and ����>0 ";
            rows = tb.Select(swhere);
            for (int i = 0; i <= rows.Length - 1; i++)
                tab.ImportRow(rows[i]);

            TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();
            myDataGrid1.TableStyles.Add(dataGridTableStyle1);
            myDataGrid1.CaptionVisible = false;
            myDataGrid1.ReadOnly = true;
            myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
            myDataGrid1.Click += new EventHandler(myDataGridMx_DoubleClick);
            myDataGrid1.Name = "myhy";
            //��ʼ������
            CshMxGrid(myDataGrid1);

            //��ʾ��ѯ���
            myDataGrid1.DataSource = tab;

            Frmhy f = new Frmhy(cj.GGID, cj.CJID, InstanceForm.BCurrentDept.DeptId);
            f.panel2.Controls.Add(myDataGrid1);
            myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);
            myDataGrid1.TableStyles[0].GridColumnStyles["ȱҩ"].Width = 0;
            myDataGrid1.TableStyles[0].GridColumnStyles["����"].Width = 80;
            myDataGrid1.TableStyles[0].GridColumnStyles["����"].Width = 80;

            decimal zsl = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(ypsl)", "ѡ��=true and cjid=" + cj.CJID + " and ����>0 "), "0"));
            f.statusStrip1.Items[0].Text = "ҩƷ������:" + zsl.ToString() + Yp.SeekYpdw(Convert.ToInt32(tb.Rows[0]["zxdw"]), InstanceForm.BDatabase);

            f.ShowDialog();

            if (f.Bok == false)
                return;

            DataTable tbmx = (DataTable)this.myDataGridMx.DataSource;
            DataTable tbcj = (DataTable)f.dataGridView1.DataSource;
            if (tbcj.Rows.Count == 0)
            {
                MessageBox.Show("û�пɹ�ѡ��ĳ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ypcj newcj = new Ypcj(Convert.ToInt32(tbcj.Rows[f.dataGridView1.CurrentCell.RowIndex]["cjid"]), InstanceForm.BDatabase);
            decimal kcl = Convert.ToDecimal(tbcj.Rows[f.dataGridView1.CurrentCell.RowIndex]["�����"]);

            try
            {

                //�޸ĺ�̨������
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tab.Rows[i]["ѡ��"]) == true)
                    {
                        DataRow[] rows1 = tbmx.Select("zy_id='" + tab.Rows[i]["zy_id"] + "'");
                        DataRow row = rows1[0];

                        decimal dj = Math.Round(newcj.LSJ / Convert.ToInt32(row["unitrate"]), 4);
                        decimal sl = Convert.ToDecimal(row["����"]);
                        decimal je = Math.Round(dj * sl, 2);
                        Guid zy_id = new Guid(row["zy_id"].ToString());

                        try
                        {
                            InstanceForm.BDatabase.BeginTransaction();

                            string kcl_y = tab.Rows[i]["�����"].ToString();
                            string kcdw = tab.Rows[i]["��λ"].ToString();

                            ParameterEx[] parameters = new ParameterEx[9];
                            parameters[0].Text = "@zy_id";
                            parameters[0].Value = zy_id;
                            parameters[1].Text = "@new_cjid";
                            parameters[1].Value = newcj.CJID;
                            parameters[2].Text = "@new_price";
                            parameters[2].Value = dj;
                            parameters[3].Text = "@new_je";
                            parameters[3].Value = je;
                            parameters[4].Text = "@err_code";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].DataType = System.Data.DbType.Int32;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@err_text";
                            parameters[5].ParaDirection = ParameterDirection.Output;
                            parameters[5].ParaSize = 100;
                            parameters[6].Text = "@sccj";
                            parameters[6].Value = newcj.S_SCCJ;
                            parameters[7].Text = "@djy";
                            parameters[7].Value = InstanceForm.BCurrentUser.Name;
                            parameters[8].Text = "@kcl";
                            parameters[8].Value = kcl_y + kcdw + " ��ҩ���:" + kcl.ToString("0.0") + kcdw;
                            InstanceForm.BDatabase.DoCommand("sp_yf_hy", parameters, 120);
                            int err_code = Convert.ToInt32(parameters[4].Value);
                            string err_text = Convert.ToString(parameters[5].Value);
                            if (err_code != 0)
                                throw new Exception(@err_text);
                            InstanceForm.BDatabase.CommitTransaction();
                            //�޸������е�������ʾ
                            row["cjid"] = newcj.CJID;
                            row["����"] = dj.ToString();
                            row["���"] = je.ToString();
                            row["�����"] = kcl.ToString();
                            row["����"] = newcj.SHH;
                            row["����"] = newcj.S_SCCJ;
                        }
                        catch (System.Exception err)
                        {
                            InstanceForm.BDatabase.RollbackTransaction();
                            MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


                //���¼���
                computeTld();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataTable tbb = (DataTable)myDataGridMx.DataSource;
                tb.Rows.Clear();
            }

        }

        #region ��ӡ��ϸ��ť
        private void butprintmx_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _groupid = new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString()));
                //_groupid = new Guid(Convertor.IsNull("47BD001F-AB4A-4AB5-AF27-A0D700D59CE7", Guid.Empty.ToString()));
                if (_groupid == Guid.Empty)
                {
                    MessageBox.Show("���뷢ҩ����ܴ�ӡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //��ӡ����
                //string  ssql = "update yf_tld set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
                //int n = InstanceForm.BDatabase.DoCommand(ssql);
                //if (n == 0)
                //{

                //    ssql = "update yf_tld_h set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
                //    n = InstanceForm.BDatabase.DoCommand(ssql);
                //}

                string ssql = "select * from vi_yf_tld where groupid='" + _groupid.ToString() + "'";
                DataTable tbtld = InstanceForm.BDatabase.GetDataTable(ssql);


                DataTable tb = ZY_FY.SelectTldMx(_groupid.ToString(), InstanceForm.BDatabase);

                DataView dv = tb.DefaultView;
                dv.RowFilter = "����>0";
                tb = dv.ToTable();

                this.Cursor = PubStaticFun.WaitCursor();

                if (this.tabControl1.SelectedTab == this.tabPage3 || tb.Rows.Count == 0)
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
                }
                Print_FYMXInfo(tb, _groupid, tbtld);

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
        #endregion

        #region ��ӡ��ϸ����
        private void Print_FYMXInfo(DataTable tb, Guid _groupid, DataTable tbtld)
        {
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

            if (tb.Rows.Count == 0)
                return;
            string lydw = Yp.SeekDeptName(Convert.ToInt32(tbtld.Rows[0]["dept_ly"]), InstanceForm.BDatabase);
            string fyr = Yp.SeekEmpName(Convert.ToInt32(tbtld.Rows[0]["fyr"]), InstanceForm.BDatabase);
            string pyr = Yp.SeekEmpName(Convert.ToInt32(tbtld.Rows[0]["pyr"]), InstanceForm.BDatabase);
            string fyrq = tbtld.Rows[0]["fyrq"].ToString();
            string djh = Convertor.IsNull(tbtld.Rows[0]["djh"], "");
            DataRow myrow;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                myrow = Dset.סԺҩƷ��ҩ��ϸ.NewRow();
                myrow["yppm"] = Convert.ToString(tb.Rows[i]["Ʒ��"]);
                myrow["ypspm"] = Convert.ToString(tb.Rows[i]["��Ʒ��"]);
                myrow["ypgg"] = Convert.ToString(tb.Rows[i]["���"]);
                myrow["sccj"] = Convert.ToString(tb.Rows[i]["����"]);
                myrow["lsj"] = Convert.ToDecimal(tb.Rows[i]["����"]);////////////////lsj ����
                myrow["ypsl"] = Convert.ToDecimal(tb.Rows[i]["����"]);
                myrow["ypdw"] = Convert.ToString(tb.Rows[i]["��λ"]);
                myrow["lsje"] = Convert.ToDecimal(tb.Rows[i]["���"]);
                myrow["shh"] = Convert.ToString(tb.Rows[i]["����"]);
                //myrow["tlfl"] = Convert.ToString(tb.Rows[i]["����"]) + " ( No." + tb.Rows[0]["djh"].ToString() + " )";
                myrow["fyrq"] = fyrq;
                myrow["fyr"] = fyr;
                myrow["pyr"] = pyr;
                myrow["lydw"] = lydw;
                myrow["mcyl"] = Convert.ToString(tb.Rows[i]["mcyl"]);
                myrow["mcdw"] = Convert.ToString(tb.Rows[i]["mcdw"]);
                myrow["yf"] = Convert.ToString(tb.Rows[i]["�÷�"]);
                myrow["pc"] = Convert.ToString(tb.Rows[i]["Ƶ��"]);
                //myrow["ryrq"] = Convert.ToString(tb.Rows[i]["ryrq"]);
                myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["dept_id"], "0")), InstanceForm.BDatabase);
                myrow["rowno"] = i;
                myrow["lydw"] = lydw;
                myrow["bed_no"] = Convert.ToString(tb.Rows[i]["����"]);
                myrow["inpatient_no"] = Convert.ToString(tb.Rows[i]["סԺ��"]);
                myrow["name"] = Convert.ToString(tb.Rows[i]["����"]);
                myrow["cfrq"] = Convert.ToString(tb.Rows[i]["presc_date"]);
                myrow["MNGTYPE"] = Convert.ToString(tb.Rows[i]["MNGTYPE"]);////////////��printBZ
                myrow["gysj"] = Convert.ToString(tb.Rows[i]["gysj"]);
                myrow["ypjx"] = Convert.ToString(tb.Rows[i]["����"]);
                Dset.סԺҩƷ��ҩ��ϸ.Rows.Add(myrow);


            }



            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "titletext";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "" + InstanceForm.BCurrentDept.DeptName + "��ҩ��";
            parameters[1].Text = "yfmc";
            parameters[1].Value = InstanceForm.BCurrentDept.DeptName;
            parameters[2].Text = "djh";
            parameters[2].Value = djh;
            parameters[3].Text = "dycs";

            int dycs = 0;
            if (tbtld.Rows[0]["mxdycs"].ToString() == "0")
                dycs = 1;
            else
                dycs = Convert.ToInt32(tbtld.Rows[0]["mxdycs"].ToString()) + 1;

            parameters[3].Value = dycs.ToString();

            string[] str ={ "" };
            str[0] = "update yf_tld set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
            bool bview = this.chkprintview.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.סԺҩƷ��ҩ��ϸ, Constant.ApplicationDirectory + "\\Report\\YF_סԺ��ҩ��.rpt", parameters, bview, str);
            f._sqlStr = str;
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();
        }

        #endregion

        private void chkkccc_CheckedChanged(object sender, EventArgs e)
        {
            #region Modify by dyw 2014/6/28 ����д��INI
            //string dy = "��";
            //if ( chkkccc.Checked == true )
            //    dy = "��";
            //ApiFunction.WriteIniString( "סԺͳ�췢ҩͳ��ѡ��" , "��ҩ�����ڿ����ʱ�������ֵ���ϸ�Զ���ѡ" , dy , Constant.ApplicationDirectory + "\\ClientWindow.ini" );
            #endregion

        }

        private void chkkcfs_CheckedChanged(object sender, EventArgs e)
        {
            #region Modify by dyw 2014/6/28 ����д��INI
            //string dy = "��";
            //if ( chkkcfs.Checked == true )
            //    dy = "��";
            //ApiFunction.WriteIniString( "סԺͳ�췢ҩͳ��ѡ��" , "��ҩ�ֿ۲���ʱ�������ֵ���ϸ�Զ���ѡ" , dy , Constant.ApplicationDirectory + "\\ClientWindow.ini" );
            #endregion
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

        bool cqAllSelParam = true;
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        object objYzlx = tmpRow["ҽ������"];
                        decimal objKcl = tmpRow["�����"] == null || tmpRow["�����"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["�����"].ToString().Trim());
                        if (objYzlx != null && objYzlx.ToString().Trim() == "����ҽ��" && objKcl > 0)
                            tmpRow["ѡ��"] = checkBox1.Checked;
                        else
                            tmpRow["ѡ��"] = false;
                    }
                    cqAllSelParam = !cqAllSelParam;
                }

            }
            checkBox3.CheckedChanged -= checkBox3_CheckedChanged;
            checkBox2.CheckedChanged -= checkBox2_CheckedChanged;
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
        }

        bool lsAllSelParam = true;
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        object objYzlx = tmpRow["ҽ������"];
                        decimal objKcl = tmpRow["�����"] == null || tmpRow["�����"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["�����"].ToString().Trim());
                        if (objYzlx != null && objYzlx.ToString().Trim() == "��ʱҽ��" && objKcl > 0)
                            tmpRow["ѡ��"] = checkBox2.Checked; // lsAllSelParam;
                        else
                            tmpRow["ѡ��"] = false;
                    }
                    lsAllSelParam = !lsAllSelParam;
                }

            }
            checkBox3.CheckedChanged -= checkBox3_CheckedChanged;
            checkBox1.CheckedChanged -= checkBox1_CheckedChanged_1;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        //object objYzlx = tmpRow["ҽ������"];
                        decimal objKcl = tmpRow["�����"] == null || tmpRow["�����"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["�����"].ToString().Trim());
                        if (objKcl > 0)
                            tmpRow["ѡ��"] = checkBox3.Checked;// lsAllSelParam;
                        else
                            tmpRow["ѡ��"] = false;
                    }
                    lsAllSelParam = !lsAllSelParam;
                }
                if (checkBox3.Focused)
                {
                    //ͳ��ʱ,������ҩʱ���û����������,��Ĭ�ϲ�ѡ��
                    if (chkkcfs.Checked == true)
                        moveTyxx();
                    if (chkkccc.Checked == true)
                        moveKccc();
                    //Modify By Tany 2015-03-23 ���Ӵ������ڹ���
                    if (checkBox4.Checked)
                        moveCfrq();

                    //����ͳ�쵥
                    computeTld();
                }
            }
            checkBox2.CheckedChanged -= checkBox2_CheckedChanged;
            checkBox1.CheckedChanged -= checkBox1_CheckedChanged_1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
        }

        private void btncb_Click(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource is DataTable)
            {
                List<string> groupIdList = new List<string>();
                DataTable datalist = myDataGridMx.DataSource as DataTable;
                string groupRange = string.Empty;
                foreach (DataRow tmpRow in datalist.Rows)
                {
                    if (tmpRow["groupid"].ToString().Trim() != string.Empty && !groupIdList.Contains(tmpRow["groupid"].ToString()))
                    {
                        groupIdList.Add(tmpRow["groupid"].ToString());
                        groupRange += string.Format("'{0}',", tmpRow["groupid"].ToString());
                    }
                }
                Dictionary<string, string> dict = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(groupRange))
                {
                    groupRange = groupRange.Remove(groupRange.Length - 1, 1);
                    string sql = string.Format("select bylx,GROUPID from YF_TLD where GROUPID in ({0})", groupRange);
                    DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        bool isShowMsg = false;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string bylx = dt.Rows[i]["bylx"].ToString().Trim();
                            if (!string.IsNullOrEmpty(bylx))
                            {
                                if (!isShowMsg)
                                {
                                    isShowMsg = true;
                                    //��Ϊ�մ����Ѿ�������ҩ����,�������ʾ
                                    DialogResult dr = MessageBox.Show("��������ҩ����,��ȷ���Ƿ����°�ҩ��", "ϵͳ��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dr != DialogResult.Yes)
                                        return;
                                }
                            }
                            dict.Add(dt.Rows[i]["GROUPID"].ToString(), dt.Rows[i]["bylx"].ToString());
                        }

                    }
                }
                else
                    return;

                bool param = false;
                foreach (KeyValuePair<string, string> s in dict)
                {
                    string outXml = string.Empty;
                    if (s.Value == "2" || string.IsNullOrEmpty(s.Value))
                    {

                        string postString = string.Empty;
                        ParameterEx[] parameters_tsbyj = new ParameterEx[1];
                        parameters_tsbyj[0].Value = s.Key;
                        parameters_tsbyj[0].Text = "@group_id";
                        DataTable tbbyjmx = InstanceForm.BDatabase.GetDataTable("SP_WHZXYY_BYJ_TS", parameters_tsbyj, 60);
                        tbbyjmx.TableName = "root";
                        if (tbbyjmx != null && tbbyjmx.Rows.Count > 0)
                        {
                            DateTime currTime = DateTime.Now;
                            Dictionary<string, DateTime> dictInfo = new Dictionary<string, DateTime>();
                            int i = 0;
                            foreach (DataRow tmpRow in tbbyjmx.Rows)
                            {
                                if (!dictInfo.ContainsKey(tmpRow["wardCd"].ToString().Trim()))
                                {
                                    if (i > 0)
                                    {
                                        currTime = currTime.AddSeconds(1);
                                    }
                                    dictInfo.Add(tmpRow["wardCd"].ToString().Trim(), currTime);
                                    i++;
                                }
                            }
                            for (int x = 0; x < tbbyjmx.Rows.Count; x++)
                            {
                                tbbyjmx.Rows[x].BeginEdit();
                                tbbyjmx.Rows[x]["makerecTime"] = dictInfo[tbbyjmx.Rows[x]["wardCd"].ToString().Trim()];
                                tbbyjmx.Rows[x].EndEdit();
                            }
                            postString = DataTableToXmlEx(tbbyjmx, "tsDoctorAdvice");
                        }
                        else
                        {
                            //MessageBox.Show("δ��ѯ����ҩ����!");
                            continue;
                        }
                        postString = "<" + tbbyjmx.TableName + ">" + postString + "</" + tbbyjmx.TableName + ">";

                        TsByj.getTsDoctorAdvice ts = new TsByj.getTsDoctorAdvice();
                        outXml = ts.CallgetTsDoctorAdvice(postString);
                        if (outXml == "1" || s.Value == "2") //������Ͱ�ҩ���ݳɹ� ���ֹ���ҩ��ʽ  ��¼���β���
                        {
                            if (!string.IsNullOrEmpty(s.Key))
                            {
                                string sql = string.Format("update yf_tld set bylx = {0} where groupid = '{1}'", string.IsNullOrEmpty(s.Value) ? "1" : s.Value, s.Key);
                                int execResult = InstanceForm.BDatabase.DoCommand(sql);
                                param = true;
                            }
                        }
                        else if (outXml == "0")
                        {
                            MessageBox.Show("���ð�ҩ���ӿ�ʧ��!");
                            return;
                        }
                    }
                }
                if (param)
                    MessageBox.Show("�����ɹ���");
            }
        }

        //Modify By Tany 2015-03-17 ��ѡ����δ���˵ķ���
        /***********************Begin Modify By Tany****************************************************/
        private void chkUncharge_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        object objChargeBit = tmpRow["charge_bit"];
                        decimal objKcl = tmpRow["�����"] == null || tmpRow["�����"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["�����"].ToString().Trim());
                        if (objChargeBit != null && objChargeBit.ToString().Trim() != "1" && objKcl > 0)
                            tmpRow["ѡ��"] = chkUncharge.Checked;
                        else
                            tmpRow["ѡ��"] = false;
                    }
                }

            }
            chkAllFee.CheckedChanged -= chkAllFee_CheckedChanged;
            chkCharged.CheckedChanged -= chkCharged_CheckedChanged;
            chkAllFee.Checked = false;
            chkCharged.Checked = false;
            chkAllFee.CheckedChanged += chkAllFee_CheckedChanged;
            chkCharged.CheckedChanged += chkCharged_CheckedChanged;
        }

        private void checkBox3_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void chkCharged_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        object objChargeBit = tmpRow["charge_bit"];
                        decimal objKcl = tmpRow["�����"] == null || tmpRow["�����"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["�����"].ToString().Trim());
                        if (objChargeBit != null && objChargeBit.ToString().Trim() == "1" && objKcl > 0)
                            tmpRow["ѡ��"] = chkCharged.Checked;
                        else
                            tmpRow["ѡ��"] = false;
                    }
                }
            }
            chkAllFee.CheckedChanged -= chkAllFee_CheckedChanged;
            chkUncharge.CheckedChanged -= chkUncharge_CheckedChanged;
            chkUncharge.Checked = false;
            chkAllFee.Checked = false;
            chkAllFee.CheckedChanged += chkAllFee_CheckedChanged;
            chkUncharge.CheckedChanged += chkUncharge_CheckedChanged;
        }

        private void chkAllFee_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        decimal objKcl = tmpRow["�����"] == null || tmpRow["�����"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["�����"].ToString().Trim());
                        if (objKcl > 0)
                            tmpRow["ѡ��"] = chkAllFee.Checked;// lsAllSelParam;
                        else
                            tmpRow["ѡ��"] = false;
                    }
                }
                if (chkAllFee.Focused)
                {
                    //ͳ��ʱ,������ҩʱ���û����������,��Ĭ�ϲ�ѡ��
                    if (chkkcfs.Checked == true)
                        moveTyxx();
                    if (chkkccc.Checked == true)
                        moveKccc();
                    //Modify By Tany 2015-03-23 ���Ӵ������ڹ���
                    if (checkBox4.Checked)
                        moveCfrq();

                    //����ͳ�쵥
                    computeTld();
                }
            }
            chkCharged.CheckedChanged -= chkCharged_CheckedChanged;
            chkUncharge.CheckedChanged -= chkUncharge_CheckedChanged;
            chkUncharge.Checked = false;
            chkCharged.Checked = false;
            chkCharged.CheckedChanged += chkCharged_CheckedChanged;
            chkUncharge.CheckedChanged += chkUncharge_CheckedChanged;
        }

        private void btCharge_Click(object sender, EventArgs e)
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

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            DataTable tbsel = tb.Clone();
            try
            {
                DataRow[] selrow = tb.Select("ѡ��=true");
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
                DataRow[] rows = tb.Select("ѡ��=true and charge_bit='0'");
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
                    if (isPivasYF)
                    {
                        ssql[i] = "update a set a.charge_bit=1,a.charge_date=getdate(),a.charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " from zy_fee_speci a inner join zy_orderrecord b on a.order_id=b.order_id where a.id='" + new Guid(rows[i]["zy_id"].ToString()) + "' and a.charge_bit=0 and a.delete_bit=0 and b.is_pvschk=1";
                    }
                }
                InstanceForm.BDatabase.DoCommand(null, null, null, ssql);
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
        /***********************End Modify By Tany****************************************************/

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _groupid = new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString()));
                //_groupid = new Guid(Convertor.IsNull("47BD001F-AB4A-4AB5-AF27-A0D700D59CE7", Guid.Empty.ToString()));
                if (_groupid == Guid.Empty)
                {
                    MessageBox.Show("���뷢ҩ����ܴ�ӡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //��ӡ����
                //string  ssql = "update yf_tld set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
                //int n = InstanceForm.BDatabase.DoCommand(ssql);
                //if (n == 0)
                //{

                //    ssql = "update yf_tld_h set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
                //    n = InstanceForm.BDatabase.DoCommand(ssql);
                //}

                string ssql = "select * from vi_yf_tld where groupid='" + _groupid.ToString() + "'";
                DataTable tbtld = InstanceForm.BDatabase.GetDataTable(ssql);


                DataTable tb = ZY_FY.SelectTldMx(_groupid.ToString(), true, InstanceForm.BDatabase);
                this.Cursor = PubStaticFun.WaitCursor();

                if (this.tabControl1.SelectedTab == this.tabPage3 || tb.Rows.Count == 0)
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
                }
                Print_FYMXInfo(tb, _groupid, tbtld);

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

        public static DataTable GroupByDataTable(DataTable tbtb, string[] GroupByField, string[] ComputeField, string[] Cfield, string filter)
        {
            DataTable tb = tbtb.Clone();
            if (filter != "")
            {
                tb = tb.Clone();
                DataRow[] rows = tbtb.Select(filter);
                for (int i = 0; i < rows.Length; i++)
                {
                    tb.ImportRow(rows[i]);
                }
            }
            else
            {
                tb = tbtb;
            }
            return GroupByDataTable(tb, GroupByField, ComputeField, Cfield);
        }

        public static DataTable GroupByDataTable(DataTable tbtb, string[] GroupByField, string[] ComputeField, string[] Cfield)
        {
            DataTable tbCompute = new DataTable();
            if (tbtb.Rows.Count <= 0)
                return tbCompute;
            List<string> lstCol = new List<string>();
            List<string> lstHj = new List<string>();

            #region ������֤

            //�����ֶβ��ܳ����ظ�����
            List<string> lstGroupByFiled = new List<string>();
            for (int i = 0; i < GroupByField.Length; i++)
            {
                if (!lstGroupByFiled.Contains(GroupByField[i]))
                {
                    lstGroupByFiled.Add(GroupByField[i]);
                }
                else
                {
                    throw new Exception(string.Format("���鷢������:GroupByField�����ظ��ֶ�:{0}", GroupByField[i]));
                }
            }

            for (int i = 0; i < tbtb.Columns.Count; i++)
            {
                lstCol.Add(tbtb.Columns[i].ColumnName.ToLower().Trim());
            }

            for (int i = 0; i < GroupByField.Length; i++)
            {
                if (!lstCol.Contains(GroupByField[i].ToLower().Trim()))
                {
                    throw new Exception(string.Format("���鷢������:�Ҳ���GroupByField:{0}", GroupByField[i].Trim().ToLower()));
                }
            }

            for (int i = 0; i < ComputeField.Length; i++)
            {
                if (!lstCol.Contains(ComputeField[i].ToLower().Trim()))
                {
                    throw new Exception(string.Format("���鷢������:�Ҳ���ComputeField:{0}", ComputeField[i].Trim().ToLower()));
                }
            }
            lstHj.Add("sum");
            lstHj.Add("max");
            lstHj.Add("min");
            lstHj.Add("count");
            for (int i = 0; i < Cfield.Length; i++)
            {
                if (!lstHj.Contains(Cfield[i].Trim().ToLower().Trim()))
                {
                    throw new Exception(string.Format("���鷢������:��֧��Cfield:{0}", Cfield[i]));
                }
            }

            if (ComputeField.Length != Cfield.Length)
            {
                throw new Exception("���鷢������:ComputeField��Cfield���鳤�Ȳ�һ��");
            }
            #endregion

            #region �����
            for (int i = 0; i <= GroupByField.Length - 1; i++)
                tbCompute.Columns.Add(GroupByField[i]);
            for (int i = 0; i <= ComputeField.Length - 1; i++)
                tbCompute.Columns.Add(ComputeField[i]);
            if (tbtb.Rows.Count <= 0) return tbCompute;
            #endregion

            #region ����
            DataTable tb = tbtb.Copy();
            string strFilter = " 1=1 ";
            try
            {

                for (int i = 0; 0 < tb.Rows.Count; i++)
                {
                    DataRow insertRow = tbCompute.NewRow();
                    strFilter = " 1=1 ";
                    for (int j = 0; j < GroupByField.Length; j++)
                    {

                        if (tb.Rows[0][GroupByField[j]] is DBNull)
                        {
                            strFilter += string.Format(" and {0} is null ", GroupByField[j].ToString()
                            );
                        }
                        else
                        {
                            strFilter += string.Format(" and {0}='{1}'", GroupByField[j].ToString(),
                              tb.Rows[0][GroupByField[j]].ToString());
                        }

                        //�����и�ֵ
                        insertRow[GroupByField[j]] = tb.Rows[0][GroupByField[j]];
                    }

                    tb.DefaultView.RowFilter = strFilter;
                    DataTable tbTemp = tb.DefaultView.ToTable();

                    //�����
                    for (int mm = 0; mm < ComputeField.Length; mm++)
                    {
                        string strCompute = string.Format("{0}({1})", Cfield[mm], ComputeField[mm].Trim());
                        insertRow[ComputeField[mm]] = tbTemp.Compute(strCompute, "").ToString();
                    }

                    tbCompute.Rows.Add(insertRow);
                    DataRow[] rows = tb.Select(strFilter);
                    if (rows.Length <= 0)
                    {
                        throw new Exception("���鷢������,δ�ɳɹ��Ƴ���:" + strFilter);
                    }
                    for (int w = 0; w < rows.Length; w++)
                    {
                        tb.Rows.Remove(rows[w]);
                    }

                }
            }
            catch (Exception err)
            {
                throw new Exception("���鷢������" + strFilter + " " + err.Message);
            }
            #endregion

            return tbCompute;
        }
    }
}
