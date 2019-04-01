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
using TrasenFrame.Forms;

namespace ts_yp_pdlr
{
	/// <summary>
	/// Frmyprk ��ժҪ˵����
	/// </summary>
	public class Frmzylr : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private myDataGrid.myDataGrid myDataGrid3;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn44;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn45;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn46;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn47;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label dtprq;
        private System.Windows.Forms.Label label3;
        public TextBox txtbz;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbldjh;
		private System.Windows.Forms.Label lbldjhH;
		private System.Windows.Forms.Button butLoadData;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblzmje;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblzmsl;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblpcje;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtypsl;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label lbllsj;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblpfj;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox cmbdw;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label lblhh;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblypmc;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblcj;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lblgg;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtypdm;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button butnext;
		private System.Windows.Forms.Button butmrzc;
		private System.Windows.Forms.Button butmodif;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.Button butadd;
		private System.Windows.Forms.TextBox txtdwcx;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button butprintkb;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butnew;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.Button butprintlpyp;
		private System.Windows.Forms.Button butclose1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn48;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn49;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn50;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn51;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn52;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn53;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn54;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn55;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn56;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn57;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn58;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn59;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn60;
		private System.Windows.Forms.DataGridTextBoxColumn ��λ;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblshdjh;
		private System.Windows.Forms.CheckBox chkdw;
		private System.Windows.Forms.CheckBox chkgl;
		private System.Windows.Forms.TextBox txtph;
		private System.Windows.Forms.CheckBox chkprintlp;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.Button butsavemb;
		private System.Windows.Forms.Label lblpm;
		private System.Windows.Forms.DataGridTextBoxColumn Ʒ��;
		private System.Windows.Forms.DataGridTextBoxColumn ��Ʒ��;
		private YpConfig ss;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label lbljhj;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn61;
        private Button butjy;
        private DataGridBoolColumn dataGridBoolColumn1;
        private ComboBox cmbck;
        private Label label2;
        private Button butmrwl;
        private bool bpcgl;
        private string pcfs;//�̴淽ʽ 0-����ϸ��� 1-�����ο��
        private DataGridTextBoxColumn colЧ��;
        private DataGridTextBoxColumn col���κ�;
        private DataGridTextBoxColumn ccЧ��;
        private DataGridTextBoxColumn cc���κ�;
        private DataGridTextBoxColumn cЧ��;
        private DataGridTextBoxColumn c���κ�;//�Ƿ�������ι���

        private bool btjhj = false;
        private DataGridTextBoxColumn dataGridTextBoxColumn62;
        private DataGridTextBoxColumn dataGridTextBoxColumn63;
        private DataGridTextBoxColumn dataGridTextBoxColumn64;//�Ƿ��������

		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmzylr(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.MdiParent=_mdiParent;

            //��ʼ���б�myDataGrid1��myDataGrid2��myDataGrid3
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
            FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tb1");
            FunBase.CsDataGrid(this.myDataGrid3, this.myDataGrid3.TableStyles[0], "Tb2");

            Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			
			
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Ʒ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��Ʒ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn61 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��λ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colЧ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col���κ� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn62 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn63 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.myDataGrid3 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn47 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ccЧ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.cc���κ� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butsavemb = new System.Windows.Forms.Button();
            this.butprintkb = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.butmrwl = new System.Windows.Forms.Button();
            this.butnext = new System.Windows.Forms.Button();
            this.butmrzc = new System.Windows.Forms.Button();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
            this.txtdwcx = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.chkdw = new System.Windows.Forms.CheckBox();
            this.chkgl = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbljhj = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblpm = new System.Windows.Forms.Label();
            this.lblzmje = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblzmsl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpcje = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtypsl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lbllsj = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblpfj = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbdw = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblhh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblypmc = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblshdjh = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtprq = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhH = new System.Windows.Forms.Label();
            this.butLoadData = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn52 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn53 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn54 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn55 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn56 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn57 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn58 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn59 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn60 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.cЧ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.c���κ� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.butjy = new System.Windows.Forms.Button();
            this.chkprintlp = new System.Windows.Forms.CheckBox();
            this.butclose1 = new System.Windows.Forms.Button();
            this.butprintlpyp = new System.Windows.Forms.Button();
            this.dataGridTextBoxColumn64 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(820, 193);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.Ʒ��,
            this.��Ʒ��,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn61,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn5,
            this.��λ,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn17,
            this.colЧ��,
            this.col���κ�,
            this.dataGridTextBoxColumn62,
            this.dataGridTextBoxColumn63,
            this.dataGridTextBoxColumn64});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // Ʒ��
            // 
            this.Ʒ��.Format = "";
            this.Ʒ��.FormatInfo = null;
            this.Ʒ��.HeaderText = "Ʒ��";
            this.Ʒ��.NullText = "";
            this.Ʒ��.ReadOnly = true;
            this.Ʒ��.Width = 130;
            // 
            // ��Ʒ��
            // 
            this.��Ʒ��.Format = "";
            this.��Ʒ��.FormatInfo = null;
            this.��Ʒ��.HeaderText = "��Ʒ��";
            this.��Ʒ��.Width = 130;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "���";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 90;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "����";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 90;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "������";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "�������";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 0;
            // 
            // dataGridTextBoxColumn61
            // 
            this.dataGridTextBoxColumn61.Format = "";
            this.dataGridTextBoxColumn61.FormatInfo = null;
            this.dataGridTextBoxColumn61.HeaderText = "����";
            this.dataGridTextBoxColumn61.NullText = "";
            this.dataGridTextBoxColumn61.ReadOnly = true;
            this.dataGridTextBoxColumn61.Width = 60;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "���ۼ�";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "����";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // ��λ
            // 
            this.��λ.Format = "";
            this.��λ.FormatInfo = null;
            this.��λ.HeaderText = "��λ";
            this.��λ.NullText = "";
            this.��λ.ReadOnly = true;
            this.��λ.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "��������";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 70;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "������";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 0;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "�̴�����";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 70;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "��λ";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 40;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "�̴���";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 0;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "ӯ������";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "ӯ�����";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 0;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "����";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "CJID";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "KCID";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.ReadOnly = true;
            this.dataGridTextBoxColumn19.Width = 0;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "DWBL";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.ReadOnly = true;
            this.dataGridTextBoxColumn20.Width = 0;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "KWID";
            this.dataGridTextBoxColumn41.NullText = "";
            this.dataGridTextBoxColumn41.Width = 0;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "ID";
            this.dataGridTextBoxColumn40.NullText = "";
            this.dataGridTextBoxColumn40.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "����";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.Width = 70;
            // 
            // colЧ��
            // 
            this.colЧ��.Format = "";
            this.colЧ��.FormatInfo = null;
            this.colЧ��.HeaderText = "Ч��";
            this.colЧ��.Width = 75;
            // 
            // col���κ�
            // 
            this.col���κ�.Format = "";
            this.col���κ�.FormatInfo = null;
            this.col���κ�.HeaderText = "���κ�";
            this.col���κ�.Width = 95;
            // 
            // dataGridTextBoxColumn62
            // 
            this.dataGridTextBoxColumn62.Format = "";
            this.dataGridTextBoxColumn62.FormatInfo = null;
            this.dataGridTextBoxColumn62.HeaderText = "ҩƷ����";
            this.dataGridTextBoxColumn62.NullText = " ";
            this.dataGridTextBoxColumn62.Width = 75;
            // 
            // dataGridTextBoxColumn63
            // 
            this.dataGridTextBoxColumn63.Format = "";
            this.dataGridTextBoxColumn63.FormatInfo = null;
            this.dataGridTextBoxColumn63.HeaderText = "����";
            this.dataGridTextBoxColumn63.NullText = "";
            this.dataGridTextBoxColumn63.Width = 75;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 592);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(834, 23);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 230;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 230;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 230;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 400;
            // 
            // myDataGrid3
            // 
            this.myDataGrid3.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid3.CaptionVisible = false;
            this.myDataGrid3.DataMember = "";
            this.myDataGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid3.Name = "myDataGrid3";
            this.myDataGrid3.Size = new System.Drawing.Size(826, 112);
            this.myDataGrid3.TabIndex = 7;
            this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid3;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn44,
            this.dataGridTextBoxColumn45,
            this.dataGridTextBoxColumn46,
            this.dataGridTextBoxColumn47,
            this.ccЧ��,
            this.cc���κ�});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "���";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.ReadOnly = true;
            this.dataGridTextBoxColumn21.Width = 40;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.ReadOnly = true;
            this.dataGridTextBoxColumn22.Width = 150;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "���";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.ReadOnly = true;
            this.dataGridTextBoxColumn23.Width = 0;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "����";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.ReadOnly = true;
            this.dataGridTextBoxColumn24.Width = 0;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "������";
            this.dataGridTextBoxColumn25.NullText = "";
            this.dataGridTextBoxColumn25.ReadOnly = true;
            this.dataGridTextBoxColumn25.Width = 0;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "�������";
            this.dataGridTextBoxColumn26.NullText = "0";
            this.dataGridTextBoxColumn26.Width = 0;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "���ۼ�";
            this.dataGridTextBoxColumn27.NullText = "0";
            this.dataGridTextBoxColumn27.ReadOnly = true;
            this.dataGridTextBoxColumn27.Width = 0;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "����";
            this.dataGridTextBoxColumn28.NullText = "";
            this.dataGridTextBoxColumn28.ReadOnly = true;
            this.dataGridTextBoxColumn28.Width = 75;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "��λ";
            this.dataGridTextBoxColumn29.NullText = "";
            this.dataGridTextBoxColumn29.ReadOnly = true;
            this.dataGridTextBoxColumn29.Width = 75;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "��������";
            this.dataGridTextBoxColumn30.NullText = "0";
            this.dataGridTextBoxColumn30.ReadOnly = true;
            this.dataGridTextBoxColumn30.Width = 0;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "������";
            this.dataGridTextBoxColumn31.NullText = "0";
            this.dataGridTextBoxColumn31.ReadOnly = true;
            this.dataGridTextBoxColumn31.Width = 0;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "�̴�����";
            this.dataGridTextBoxColumn32.NullText = "";
            this.dataGridTextBoxColumn32.ReadOnly = true;
            this.dataGridTextBoxColumn32.Width = 80;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "��λ";
            this.dataGridTextBoxColumn33.NullText = "";
            this.dataGridTextBoxColumn33.ReadOnly = true;
            this.dataGridTextBoxColumn33.Width = 30;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "�̴���";
            this.dataGridTextBoxColumn34.NullText = "0";
            this.dataGridTextBoxColumn34.ReadOnly = true;
            this.dataGridTextBoxColumn34.Width = 0;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "ӯ������";
            this.dataGridTextBoxColumn35.NullText = "0";
            this.dataGridTextBoxColumn35.ReadOnly = true;
            this.dataGridTextBoxColumn35.Width = 0;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "ӯ�����";
            this.dataGridTextBoxColumn36.NullText = "";
            this.dataGridTextBoxColumn36.ReadOnly = true;
            this.dataGridTextBoxColumn36.Width = 0;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "����";
            this.dataGridTextBoxColumn37.NullText = "";
            this.dataGridTextBoxColumn37.ReadOnly = true;
            this.dataGridTextBoxColumn37.Width = 0;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "CJID";
            this.dataGridTextBoxColumn38.NullText = "0";
            this.dataGridTextBoxColumn38.ReadOnly = true;
            this.dataGridTextBoxColumn38.Width = 0;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "KCID";
            this.dataGridTextBoxColumn39.NullText = "0";
            this.dataGridTextBoxColumn39.ReadOnly = true;
            this.dataGridTextBoxColumn39.Width = 0;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "DWBL";
            this.dataGridTextBoxColumn42.NullText = "0";
            this.dataGridTextBoxColumn42.ReadOnly = true;
            this.dataGridTextBoxColumn42.Width = 0;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "KWID";
            this.dataGridTextBoxColumn43.NullText = "0";
            this.dataGridTextBoxColumn43.ReadOnly = true;
            this.dataGridTextBoxColumn43.Width = 0;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "ID";
            this.dataGridTextBoxColumn44.NullText = "0";
            this.dataGridTextBoxColumn44.ReadOnly = true;
            this.dataGridTextBoxColumn44.Width = 0;
            // 
            // dataGridTextBoxColumn45
            // 
            this.dataGridTextBoxColumn45.Format = "";
            this.dataGridTextBoxColumn45.FormatInfo = null;
            this.dataGridTextBoxColumn45.HeaderText = "�Ǽ�Ա";
            this.dataGridTextBoxColumn45.NullText = "";
            this.dataGridTextBoxColumn45.ReadOnly = true;
            this.dataGridTextBoxColumn45.Width = 70;
            // 
            // dataGridTextBoxColumn46
            // 
            this.dataGridTextBoxColumn46.Format = "";
            this.dataGridTextBoxColumn46.FormatInfo = null;
            this.dataGridTextBoxColumn46.HeaderText = "�Ǽ�ʱ��";
            this.dataGridTextBoxColumn46.NullText = "";
            this.dataGridTextBoxColumn46.ReadOnly = true;
            this.dataGridTextBoxColumn46.Width = 130;
            // 
            // dataGridTextBoxColumn47
            // 
            this.dataGridTextBoxColumn47.Format = "";
            this.dataGridTextBoxColumn47.FormatInfo = null;
            this.dataGridTextBoxColumn47.HeaderText = "���ݺ�";
            this.dataGridTextBoxColumn47.NullText = "";
            this.dataGridTextBoxColumn47.ReadOnly = true;
            this.dataGridTextBoxColumn47.Width = 60;
            // 
            // ccЧ��
            // 
            this.ccЧ��.Format = "";
            this.ccЧ��.FormatInfo = null;
            this.ccЧ��.HeaderText = "Ч��";
            this.ccЧ��.Width = 75;
            // 
            // cc���κ�
            // 
            this.cc���κ�.Format = "";
            this.cc���κ�.FormatInfo = null;
            this.cc���κ�.HeaderText = "���κ�";
            this.cc���κ�.Width = 95;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 592);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(826, 563);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "�̵�¼�뵥";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(826, 246);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(820, 193);
            this.panel2.TabIndex = 62;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butsavemb);
            this.panel1.Controls.Add(this.butprintkb);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 33);
            this.panel1.TabIndex = 61;
            // 
            // butsavemb
            // 
            this.butsavemb.Location = new System.Drawing.Point(176, 3);
            this.butsavemb.Name = "butsavemb";
            this.butsavemb.Size = new System.Drawing.Size(96, 24);
            this.butsavemb.TabIndex = 72;
            this.butsavemb.Text = "��Ϊģ��(&M)";
            this.butsavemb.Click += new System.EventHandler(this.butsavemb_Click);
            // 
            // butprintkb
            // 
            this.butprintkb.Location = new System.Drawing.Point(272, 3);
            this.butprintkb.Name = "butprintkb";
            this.butprintkb.Size = new System.Drawing.Size(96, 24);
            this.butprintkb.TabIndex = 70;
            this.butprintkb.Text = "��ӡ�ձ�(&M)";
            this.butprintkb.Click += new System.EventHandler(this.butprintKB_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(632, 3);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 68;
            this.butclose.Text = "�ر�(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(544, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 67;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(456, 3);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 66;
            this.butsave.Text = "����(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(368, 3);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 65;
            this.butnew.Text = "�µ���(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(0, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 24);
            this.checkBox1.TabIndex = 71;
            this.checkBox1.Text = "�����̵���ϸ����";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 443);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(826, 8);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 451);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(826, 112);
            this.panel3.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.butmrwl);
            this.groupBox4.Controls.Add(this.butnext);
            this.groupBox4.Controls.Add(this.butmrzc);
            this.groupBox4.Controls.Add(this.butmodif);
            this.groupBox4.Controls.Add(this.butdel);
            this.groupBox4.Controls.Add(this.butadd);
            this.groupBox4.Controls.Add(this.txtdwcx);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.chkdw);
            this.groupBox4.Controls.Add(this.chkgl);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(826, 40);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // butmrwl
            // 
            this.butmrwl.Location = new System.Drawing.Point(10, 13);
            this.butmrwl.Name = "butmrwl";
            this.butmrwl.Size = new System.Drawing.Size(108, 23);
            this.butmrwl.TabIndex = 86;
            this.butmrwl.Text = "�̴���Ĭ��Ϊ��";
            this.butmrwl.Click += new System.EventHandler(this.butmrwl_Click);
            // 
            // butnext
            // 
            this.butnext.Font = new System.Drawing.Font("����", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butnext.Location = new System.Drawing.Point(324, 13);
            this.butnext.Name = "butnext";
            this.butnext.Size = new System.Drawing.Size(40, 20);
            this.butnext.TabIndex = 83;
            this.butnext.Text = "Next";
            this.butnext.Visible = false;
            this.butnext.Click += new System.EventHandler(this.butnext_Click);
            // 
            // butmrzc
            // 
            this.butmrzc.Location = new System.Drawing.Point(13, 49);
            this.butmrzc.Name = "butmrzc";
            this.butmrzc.Size = new System.Drawing.Size(67, 23);
            this.butmrzc.TabIndex = 82;
            this.butmrzc.Text = "�̵���Ĭ��Ϊ�ʴ���(&X)";
            this.butmrzc.Click += new System.EventHandler(this.butmrzc_Click);
            // 
            // butmodif
            // 
            this.butmodif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmodif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butmodif.Location = new System.Drawing.Point(760, 11);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(58, 23);
            this.butmodif.TabIndex = 6;
            this.butmodif.Text = "�޸�(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butdel.Location = new System.Drawing.Point(699, 11);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(59, 23);
            this.butdel.TabIndex = 78;
            this.butdel.Text = "ɾ��(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butadd.Location = new System.Drawing.Point(641, 11);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(56, 23);
            this.butadd.TabIndex = 5;
            this.butadd.Text = "���(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // txtdwcx
            // 
            this.txtdwcx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtdwcx.ForeColor = System.Drawing.Color.Navy;
            this.txtdwcx.Location = new System.Drawing.Point(200, 13);
            this.txtdwcx.Name = "txtdwcx";
            this.txtdwcx.Size = new System.Drawing.Size(120, 21);
            this.txtdwcx.TabIndex = 80;
            this.txtdwcx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(148, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 81;
            this.label25.Text = "��λ��ѯ";
            // 
            // chkdw
            // 
            this.chkdw.Location = new System.Drawing.Point(536, 12);
            this.chkdw.Name = "chkdw";
            this.chkdw.Size = new System.Drawing.Size(104, 24);
            this.chkdw.TabIndex = 84;
            this.chkdw.Text = "����ѡ��λ";
            this.chkdw.CheckedChanged += new System.EventHandler(this.chkdw_CheckedChanged);
            // 
            // chkgl
            // 
            this.chkgl.Location = new System.Drawing.Point(370, 13);
            this.chkgl.Name = "chkgl";
            this.chkgl.Size = new System.Drawing.Size(175, 23);
            this.chkgl.TabIndex = 85;
            this.chkgl.Text = "¼��ҩƷʱ�������̴�ҩƷ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbljhj);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.lblzmje);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblzmsl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblpcje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtph);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtypsl);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lbllsj);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lblpfj);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cmbdw);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblhh);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblypmc);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 88);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lbljhj
            // 
            this.lbljhj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbljhj.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljhj.ForeColor = System.Drawing.Color.Navy;
            this.lbljhj.Location = new System.Drawing.Point(216, 34);
            this.lbljhj.Name = "lbljhj";
            this.lbljhj.Size = new System.Drawing.Size(96, 20);
            this.lbljhj.TabIndex = 77;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(184, 38);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 76;
            this.label31.Text = "����";
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(218, 12);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(152, 20);
            this.lblpm.TabIndex = 75;
            // 
            // lblzmje
            // 
            this.lblzmje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzmje.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzmje.ForeColor = System.Drawing.Color.Navy;
            this.lblzmje.Location = new System.Drawing.Point(688, 61);
            this.lblzmje.Name = "lblzmje";
            this.lblzmje.Size = new System.Drawing.Size(128, 20);
            this.lblzmje.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(632, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 72;
            this.label8.Text = "������";
            // 
            // lblzmsl
            // 
            this.lblzmsl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzmsl.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzmsl.ForeColor = System.Drawing.Color.Navy;
            this.lblzmsl.Location = new System.Drawing.Point(536, 61);
            this.lblzmsl.Name = "lblzmsl";
            this.lblzmsl.Size = new System.Drawing.Size(87, 20);
            this.lblzmsl.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(480, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "��������";
            // 
            // lblpcje
            // 
            this.lblpcje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpcje.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpcje.ForeColor = System.Drawing.Color.Navy;
            this.lblpcje.Location = new System.Drawing.Point(385, 61);
            this.lblpcje.Name = "lblpcje";
            this.lblpcje.Size = new System.Drawing.Size(88, 20);
            this.lblpcje.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(328, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 68;
            this.label7.Text = "�̴���";
            // 
            // txtph
            // 
            this.txtph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtph.Location = new System.Drawing.Point(217, 61);
            this.txtph.Name = "txtph";
            this.txtph.ReadOnly = true;
            this.txtph.Size = new System.Drawing.Size(96, 21);
            this.txtph.TabIndex = 9;
            this.txtph.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(179, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "�� ��";
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.Location = new System.Drawing.Point(64, 37);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(88, 21);
            this.txtypsl.TabIndex = 3;
            this.txtypsl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtypsl_KeyUp);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtypsl_KeyPress);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 37);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "�̴�����";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(552, 37);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(88, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(504, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 28;
            this.label23.Text = "���ۼ�";
            // 
            // lblpfj
            // 
            this.lblpfj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfj.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.ForeColor = System.Drawing.Color.Navy;
            this.lblpfj.Location = new System.Drawing.Point(384, 37);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(96, 20);
            this.lblpfj.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(344, 37);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 26;
            this.label20.Text = "������";
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(64, 61);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(88, 20);
            this.cmbdw.TabIndex = 4;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbdw_KeyPress);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(28, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 15);
            this.label19.TabIndex = 24;
            this.label19.Text = "��λ";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(688, 37);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(128, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(648, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 16);
            this.label18.TabIndex = 22;
            this.label18.Text = "����";
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(370, 12);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(152, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(688, 12);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(128, 20);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(648, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 18;
            this.label14.Text = "����";
            // 
            // lblgg
            // 
            this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgg.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(560, 12);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(84, 20);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(528, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "���";
            // 
            // txtypdm
            // 
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(64, 12);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(88, 21);
            this.txtypdm.TabIndex = 2;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "ҩƷ����";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(150, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "Ʒ��/��Ʒ��";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblshdjh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtprq);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhH);
            this.groupBox1.Controls.Add(this.butLoadData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(64, 11);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(112, 20);
            this.cmbck.TabIndex = 0;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 81;
            this.label2.Text = "�ֿ�����";
            // 
            // lblshdjh
            // 
            this.lblshdjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblshdjh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblshdjh.ForeColor = System.Drawing.Color.Navy;
            this.lblshdjh.Location = new System.Drawing.Point(589, 12);
            this.lblshdjh.Name = "lblshdjh";
            this.lblshdjh.Size = new System.Drawing.Size(80, 20);
            this.lblshdjh.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(534, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "��˵���";
            // 
            // dtprq
            // 
            this.dtprq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtprq.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtprq.ForeColor = System.Drawing.Color.Navy;
            this.dtprq.Location = new System.Drawing.Point(243, 12);
            this.dtprq.Name = "dtprq";
            this.dtprq.Size = new System.Drawing.Size(152, 20);
            this.dtprq.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(190, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 76;
            this.label3.Text = "¼��ʱ��";
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(64, 36);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(605, 21);
            this.txtbz.TabIndex = 1;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "��ע";
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.ForeColor = System.Drawing.Color.Navy;
            this.lbldjh.Location = new System.Drawing.Point(452, 12);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(80, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhH
            // 
            this.lbldjhH.Location = new System.Drawing.Point(398, 16);
            this.lbldjhH.Name = "lbldjhH";
            this.lbldjhH.Size = new System.Drawing.Size(64, 16);
            this.lbldjhH.TabIndex = 14;
            this.lbldjhH.Text = "¼�뵥��";
            // 
            // butLoadData
            // 
            this.butLoadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLoadData.ForeColor = System.Drawing.Color.Blue;
            this.butLoadData.Location = new System.Drawing.Point(688, 20);
            this.butLoadData.Name = "butLoadData";
            this.butLoadData.Size = new System.Drawing.Size(112, 24);
            this.butLoadData.TabIndex = 75;
            this.butLoadData.Text = "��ȡ����(&W)";
            this.butLoadData.UseVisualStyleBackColor = false;
            this.butLoadData.Click += new System.EventHandler(this.butLoadData_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(826, 563);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "©��ҩƷ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.myDataGrid2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(826, 515);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(820, 495);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.myDataGrid2.Click += new System.EventHandler(this.myDataGrid2_Click);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn48,
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn49,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn50,
            this.dataGridTextBoxColumn51,
            this.dataGridTextBoxColumn52,
            this.dataGridTextBoxColumn53,
            this.dataGridTextBoxColumn54,
            this.dataGridTextBoxColumn55,
            this.dataGridTextBoxColumn56,
            this.dataGridTextBoxColumn57,
            this.dataGridTextBoxColumn58,
            this.dataGridTextBoxColumn59,
            this.dataGridTextBoxColumn60,
            this.cЧ��,
            this.c���κ�});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.ReadOnly = true;
            // 
            // dataGridTextBoxColumn48
            // 
            this.dataGridTextBoxColumn48.Format = "";
            this.dataGridTextBoxColumn48.FormatInfo = null;
            this.dataGridTextBoxColumn48.HeaderText = "���";
            this.dataGridTextBoxColumn48.Width = 35;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.FalseValue = ((short)(0));
            this.dataGridBoolColumn1.HeaderText = "ѡ��";
            this.dataGridBoolColumn1.NullText = "";
            this.dataGridBoolColumn1.TrueValue = ((short)(1));
            this.dataGridBoolColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn49
            // 
            this.dataGridTextBoxColumn49.Format = "";
            this.dataGridTextBoxColumn49.FormatInfo = null;
            this.dataGridTextBoxColumn49.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn49.Width = 140;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "��Ʒ��";
            this.dataGridTextBoxColumn2.Width = 140;
            // 
            // dataGridTextBoxColumn50
            // 
            this.dataGridTextBoxColumn50.Format = "";
            this.dataGridTextBoxColumn50.FormatInfo = null;
            this.dataGridTextBoxColumn50.HeaderText = "���";
            this.dataGridTextBoxColumn50.Width = 90;
            // 
            // dataGridTextBoxColumn51
            // 
            this.dataGridTextBoxColumn51.Format = "";
            this.dataGridTextBoxColumn51.FormatInfo = null;
            this.dataGridTextBoxColumn51.HeaderText = "����";
            this.dataGridTextBoxColumn51.Width = 90;
            // 
            // dataGridTextBoxColumn52
            // 
            this.dataGridTextBoxColumn52.Format = "";
            this.dataGridTextBoxColumn52.FormatInfo = null;
            this.dataGridTextBoxColumn52.HeaderText = "������";
            this.dataGridTextBoxColumn52.Width = 65;
            // 
            // dataGridTextBoxColumn53
            // 
            this.dataGridTextBoxColumn53.Format = "";
            this.dataGridTextBoxColumn53.FormatInfo = null;
            this.dataGridTextBoxColumn53.HeaderText = "���ۼ�";
            this.dataGridTextBoxColumn53.Width = 65;
            // 
            // dataGridTextBoxColumn54
            // 
            this.dataGridTextBoxColumn54.Format = "";
            this.dataGridTextBoxColumn54.FormatInfo = null;
            this.dataGridTextBoxColumn54.HeaderText = "����";
            this.dataGridTextBoxColumn54.Width = 65;
            // 
            // dataGridTextBoxColumn55
            // 
            this.dataGridTextBoxColumn55.Format = "";
            this.dataGridTextBoxColumn55.FormatInfo = null;
            this.dataGridTextBoxColumn55.HeaderText = "��λ";
            this.dataGridTextBoxColumn55.Width = 65;
            // 
            // dataGridTextBoxColumn56
            // 
            this.dataGridTextBoxColumn56.Format = "";
            this.dataGridTextBoxColumn56.FormatInfo = null;
            this.dataGridTextBoxColumn56.HeaderText = "�����";
            this.dataGridTextBoxColumn56.Width = 70;
            // 
            // dataGridTextBoxColumn57
            // 
            this.dataGridTextBoxColumn57.Format = "";
            this.dataGridTextBoxColumn57.FormatInfo = null;
            this.dataGridTextBoxColumn57.HeaderText = "��λ";
            this.dataGridTextBoxColumn57.Width = 40;
            // 
            // dataGridTextBoxColumn58
            // 
            this.dataGridTextBoxColumn58.Format = "";
            this.dataGridTextBoxColumn58.FormatInfo = null;
            this.dataGridTextBoxColumn58.HeaderText = "����";
            this.dataGridTextBoxColumn58.Width = 65;
            // 
            // dataGridTextBoxColumn59
            // 
            this.dataGridTextBoxColumn59.Format = "";
            this.dataGridTextBoxColumn59.FormatInfo = null;
            this.dataGridTextBoxColumn59.HeaderText = "cjid";
            this.dataGridTextBoxColumn59.Width = 0;
            // 
            // dataGridTextBoxColumn60
            // 
            this.dataGridTextBoxColumn60.Format = "";
            this.dataGridTextBoxColumn60.FormatInfo = null;
            this.dataGridTextBoxColumn60.HeaderText = "kcid";
            this.dataGridTextBoxColumn60.Width = 0;
            // 
            // cЧ��
            // 
            this.cЧ��.Format = "";
            this.cЧ��.FormatInfo = null;
            this.cЧ��.HeaderText = "Ч��";
            this.cЧ��.Width = 75;
            // 
            // c���κ�
            // 
            this.c���κ�.Format = "";
            this.c���κ�.FormatInfo = null;
            this.c���κ�.HeaderText = "���κ�";
            this.c���κ�.Width = 75;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.butjy);
            this.groupBox5.Controls.Add(this.chkprintlp);
            this.groupBox5.Controls.Add(this.butclose1);
            this.groupBox5.Controls.Add(this.butprintlpyp);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(0, 515);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(826, 48);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "����";
            // 
            // butjy
            // 
            this.butjy.Location = new System.Drawing.Point(31, 11);
            this.butjy.Name = "butjy";
            this.butjy.Size = new System.Drawing.Size(241, 32);
            this.butjy.TabIndex = 73;
            this.butjy.Text = "��������ѡ����ҿ��Ϊ���ҩƷ";
            this.butjy.Visible = false;
            this.butjy.Click += new System.EventHandler(this.butjy_Click);
            // 
            // chkprintlp
            // 
            this.chkprintlp.Location = new System.Drawing.Point(290, 16);
            this.chkprintlp.Name = "chkprintlp";
            this.chkprintlp.Size = new System.Drawing.Size(176, 24);
            this.chkprintlp.TabIndex = 72;
            this.chkprintlp.Text = "ֻ��ӡ�������Ϊ���ҩƷ";
            // 
            // butclose1
            // 
            this.butclose1.Location = new System.Drawing.Point(616, 11);
            this.butclose1.Name = "butclose1";
            this.butclose1.Size = new System.Drawing.Size(104, 32);
            this.butclose1.TabIndex = 1;
            this.butclose1.Text = "�˳�(&Q)";
            this.butclose1.Click += new System.EventHandler(this.butclose1_Click);
            // 
            // butprintlpyp
            // 
            this.butprintlpyp.Location = new System.Drawing.Point(496, 11);
            this.butprintlpyp.Name = "butprintlpyp";
            this.butprintlpyp.Size = new System.Drawing.Size(104, 32);
            this.butprintlpyp.TabIndex = 0;
            this.butprintlpyp.Text = "��ӡ(&P)";
            this.butprintlpyp.Click += new System.EventHandler(this.butprintlpyp_Click);
            // 
            // dataGridTextBoxColumn64
            // 
            this.dataGridTextBoxColumn64.Format = "";
            this.dataGridTextBoxColumn64.FormatInfo = null;
            this.dataGridTextBoxColumn64.HeaderText = "��������2";
            this.dataGridTextBoxColumn64.NullText = "";
            this.dataGridTextBoxColumn64.Width = 90;
            // 
            // Frmzylr
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(834, 615);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Frmzylr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "�̵�����¼��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmzylr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		
		private void Frmzylr_Load(object sender, System.EventArgs e)
		{

			//�����̵���ϸ����
			this.checkBox1.Checked=true;
			//this.��λ.Width=0;
                SystemCfg cfg8056 = new SystemCfg(8056);//��������
                if (cfg8056.Config == "1")
                {
                    btjhj = true;
                }

		}

	

		#region ��������¼�
		// �س�������һ���ı�
		private void GotoNext(object sender, KeyPressEventArgs e)
		{ 
			Control control=(Control)sender;
			if (e.KeyChar==13 )
			{
				this.SelectNextControl(control,true,false,true,true);
			}
		}

	
		//��ʼ����һ�����
		private void csgroupbox1()
		{
			for(int i=0;i<=this.groupBox1.Controls.Count-1;i++)
			{
				if (this.groupBox1.Controls[i].GetType().ToString()=="System.Windows.Forms.TextBox")
				{
					this.groupBox1.Controls[i].Text="";
					this.groupBox1.Controls[i].Tag="0";
				}
			}
			this.lbldjh.Text="";
			this.lblshdjh.Text="";
			this.groupBox1.Tag=null;
			this.dtprq.Text="";
		}

		//��ʼ���ڶ������
		private void csgroupbox2()
		{
			for(int i=0;i<=this.groupBox2.Controls.Count-1;i++)
			{
				if (this.groupBox2.Controls[i].GetType().ToString()=="System.Windows.Forms.TextBox")
				{
					this.groupBox2.Controls[i].Text="";
					this.groupBox2.Controls[i].Tag="0";
				}
			}
			this.lblypmc.Text="";
			this.lblypmc.Tag="0";
			this.lblpm.Text="";
			this.lblgg.Text="";
			this.lblcj.Text="";
			this.lblhh.Text="";
			this.lblpfj.Text="";
			this.lbllsj.Text="";
			this.lblpfj.Tag="";
			this.lbllsj.Tag ="";
			this.lblpcje.Text="";
			this.lblzmsl.Text="";
			this.lblzmje.Text="";
//			this.lblkw.Text="";
//			this.lblkw.Tag="0";
			this.cmbdw.DataSource=null;

			this.lbljhj.Text="";
			this.lbljhj.Tag="";
			//this.txtypdm.Focus();
		}

	
		private void txtypsl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (Convert.ToInt32(e.KeyChar)==13)
			{
				if (this.chkdw.Checked==true)
					cmbdw.Focus();
				else
				{
					if (butadd.Enabled==true)
						butadd.Focus();
					else
						butmodif.Focus();
				}
			}
		}

		private void cmbdw_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (butadd.Enabled==true)
				butadd.Focus();
			else
				butmodif.Focus();
		}

		//���������¼�
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{

            
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" ){control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)=="")))
			{}
			else{return;}

			string[] GrdMappingName;
			int[] GrdWidth;
			string[]sfield;
			string ssql="";
			DataRow row;
			
			try
			{
				Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
				switch(control.TabIndex)
				{
					case 2:
						if (control.Text.Trim()=="") return;
						GrdMappingName=new string[] {"kcid","ggid","cjid","�к�","Ʒ��","��Ʒ��","�����","��λ","����","����","���","����","������","���ۼ�","����","dwbl"};
						GrdWidth=new int[] {0,0,0,35,120,120,65,35,60,60,90,90,0,60,60,0};
						sfield=new string[] {"b.wbm","b.pym","szm","ywm","ypbm"};

						if (ss.�Ƿ������û�п���¼��ҩƷ�����̴�==true)
                            ssql = "select isnull(kcid,dbo.FUN_GETEMPTYGUID()) kcid,a.ggid,a.cjid,0 rowno,s_yppm,s_ypspm,kcl,coalesce(dbo.fun_yp_ypdw(zxdw),s_ypdw) s_zxdw,jhj,ypph,s_ypgg,s_sccj," +
								" pfj,lsj,shh,coalesce(dwbl,1) dwbl from yp_ypcjd a inner join yp_ypbm b on a.ggid=b.ggid  left join yf_pdtemp c  on"+
                                " a.cjid=c.cjid and  c.shbz=0 and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (c.bdelete=0 or kcl<>0)" +
                                " where (a.bdelete=0 or c.kcl<>0) and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")";
						else
                            ssql = "select isnull(kcid,dbo.FUN_GETEMPTYGUID()) kcid,a.ggid,a.cjid,0 rowno,s_yppm,s_ypspm,kcl,coalesce(dbo.fun_yp_ypdw(zxdw),s_ypdw) ,jhj,ypph,s_ypgg,s_sccj," +
								" pfj,lsj,shh,coalesce(dwbl,1) dwbl from yp_ypcjd a inner join yp_ypbm b on a.ggid=b.ggid  inner join yf_pdtemp c  on"+
                                " a.cjid=c.cjid and  c.shbz=0 and  deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (c.bdelete=0 or kcl<>0)" +
                                " where a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")";
						
						if (chkgl.Checked==true)
                            ssql = ssql + " and isnull(c.kcid,dbo.FUN_GETEMPTYGUID()) not in(select isnull(kcid,dbo.FUN_GETEMPTYGUID()) from yf_pdcs a,yf_pdcsmx b where a.deptid=b.deptid and a.djh=b.djh and bdelete=0 and a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and shbz=0 )";


						TrasenFrame.Forms.Fshowcard f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
						f2.Location=point;
						f2.Width=750;
						f2.Height=300;
						f2.ShowDialog(this);
						row=f2.dataRow;
						if (row!=null) 
						{
							this.csyp(row);
							this.SelectNextControl((Control)sender,true,false,true,true);
							
						}
						break;
					case 80:
						if (control.Text.Trim()=="") return;
                        GrdMappingName = new string[] { "kcid", "ggid", "cjid", "�к�", "Ʒ��", "��Ʒ��", "�����", "��λ", "����", "����", "���", "����", "������", "���ۼ�", "����", "dwbl" };
                        GrdWidth = new int[] { 0, 0, 0, 35, 120, 120, 65, 35, 60, 60, 90, 90, 0, 60, 60, 0 };
                        sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                        if (ss.�Ƿ������û�п���¼��ҩƷ�����̴� == true)
                            ssql = "select isnull(kcid,dbo.FUN_GETEMPTYGUID()) kcid,a.ggid,a.cjid,0 rowno,s_yppm,s_ypspm,kcl,coalesce(dbo.fun_yp_ypdw(zxdw),s_ypdw) s_zxdw,jhj,ypph,s_ypgg,s_sccj," +
                                " pfj,lsj,shh,coalesce(dwbl,1) dwbl from yp_ypcjd a inner join yp_ypbm b on a.ggid=b.ggid  left join yf_pdtemp c  on" +
                                " a.cjid=c.cjid and  c.shbz=0 and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (c.bdelete=0 or kcl<>0)" +
                                " where (a.bdelete=0 or c.kcl<>0) and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")";
                        else
                            ssql = "select isnull(kcid,dbo.FUN_GETEMPTYGUID()) kcid,a.ggid,a.cjid,0 rowno,s_yppm,s_ypspm,kcl,coalesce(dbo.fun_yp_ypdw(zxdw),s_ypdw) ,jhj,ypph,s_ypgg,s_sccj," +
                                " pfj,lsj,shh,coalesce(dwbl,1) dwbl from yp_ypcjd a inner join yp_ypbm b on a.ggid=b.ggid  inner join yf_pdtemp c  on" +
                                " a.cjid=c.cjid and  c.shbz=0 and  deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (c.bdelete=0 or kcl<>0)" +
                                " where a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")";

                        if (chkgl.Checked == true)
                            ssql = ssql + " and isnull(c.kcid,dbo.FUN_GETEMPTYGUID()) not in(select isnull(kcid,dbo.FUN_GETEMPTYGUID()) from yf_pdcs a,yf_pdcsmx b where a.deptid=b.deptid and a.djh=b.djh and bdelete=0 and a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and shbz=0 )";
                        TrasenFrame.Forms.Fshowcard f3 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
						f3.Location=point;
						f3.ShowDialog(this);
						row=f3.dataRow;
						if (row!=null) 
						{
                            control.Text = row["s_yppm"].ToString();
							control.Tag=row["cjid"].ToString();
							int cjid=Convert.ToInt32(Convertor.IsNull(row["cjid"],"0"));
							int nrow=0;
							FindRecord(cjid,nrow);
							
						}
						break;

				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}


		}


		//���������¼�
		private void txtypsl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				//if (Convertor.IsNumeric(txtypsl.Text)==false) txtypsl.Text="";
				if (txtypsl.Text.Trim()!="-" && txtypsl.Text.Trim()!=".")
				{
					//decimal sumpcje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text,"0"));
                    decimal sumpcje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0"))/Convert.ToInt32(Convertor.IsNull(cmbdw.SelectedValue,"1"));
					this.lblpcje.Text=sumpcje.ToString("0.00");
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������ȷ������");
			}

		}

		
		//����Ԫ�ı��¼�
		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				int ncol =this.myDataGrid1.CurrentCell.ColumnNumber ;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				this.csgroupbox2();
				if (nrow<tb.Rows.Count && tb.Rows.Count>0)
				{
					DataRow row=tb.Rows[nrow];
					Getrow(row);
					this.butadd.Enabled=false;
				}

				int cjid=0;
				DataTable tb1=(DataTable)this.myDataGrid1.DataSource;
				if (nrow<tb1.Rows.Count)
				{
					cjid=Convert.ToInt32(tb1.Rows[nrow]["cjid"]);
				}

				if (this.checkBox1.Checked!=true)
				   Selectpcmx(cjid);


				this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);
				return ;
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
			
		}


		//��λ�ı��¼�
		private void cmbdw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbdw.SelectedIndex<=-1) return;
				if (cmbdw.SelectedValue.GetType().ToString()!="System.Int32") return;
				int dwbl=Convert.ToInt32(cmbdw.SelectedValue);

				//�ʴ�����
				decimal zmsl=Convert.ToDecimal(Convertor.IsNull(lblzmsl.Text,"0"))*dwbl/Convert.ToInt32(lblzmsl.Tag);
				this.lblzmsl.Text=zmsl.ToString("0.000");
				this.lblzmsl.Tag=dwbl.ToString();

				//�̴�����
				decimal ypsl=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"));

				//����
				decimal jhj=Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Tag,"0"))/dwbl;
				jhj=Convert.ToDecimal(jhj.ToString("0.0000"));

				
				//������
				decimal pfj=Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag,"0"))/dwbl;
				pfj=Convert.ToDecimal(pfj.ToString("0.0000"));
		
				//���ۼ�
				decimal lsj=Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag,"0"))/dwbl;
				lsj=Convert.ToDecimal(lsj.ToString("0.0000"));

				this.lblpfj.Text=pfj.ToString("0.0000");
				this.lbllsj.Text=lsj.ToString("0.0000");
				this.lbljhj.Text=jhj.ToString("0.0000");

				//�̴���
                decimal pcje = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) * ypsl/dwbl;
				this.lblpcje.Text=pcje.ToString("0.00");
                decimal zmje = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) * zmsl/dwbl;
				this.lblzmje.Text=zmje.ToString("0.00");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}

		

		
		//�������ڲ������ҩƷ
		private void FindRecord(int cjid,int nrow)
		{
			int beginrow=nrow;
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			for(int i=beginrow;i<=tb.Rows.Count-1;i++)
			{
				if (Convert.ToInt32(tb.Rows[i]["cjid"])==cjid)
				{
					this.myDataGrid1.CurrentCell=new DataGridCell(i,0);
					for(int j=0;j<=tb.Rows.Count-1;j++)
					{
						this.myDataGrid1.UnSelect(j);
					}

					this.myDataGrid1.Select(i);
					beginrow=i+1;
					if (beginrow!=tb.Rows.Count) 
					{
						this.butnext.Visible=true;
						this.butnext.Tag=beginrow.ToString(); 
					}
					else
					{
						this.butnext.Visible=false;
						this.butnext.Tag="0";
					}
					return;

				}
				
				if (beginrow>=tb.Rows.Count-1)
				{
					this.butnext.Visible=false;
				}

			}
		}

		
		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox1.Checked==true)
			{
				this.panel3.Visible=false;
			}
			else
			{
				this.panel3.Visible=true;
			}
		}


		private void chkdw_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkdw.Checked==true)
				cmbdw.TabIndex=3;
			else 
				cmbdw.TabIndex=8;

		}


		#endregion

		#region ������ݵĹ���
		//��ʼҩƷ
		private void csyp(DataRow row)
		{
			try
			{
				this.csgroupbox2();
				this.lblypmc.Tag=row["cjid"].ToString();
				this.lblypmc.Text=row["s_ypspm"].ToString();
				this.lblpm.Text=row["s_yppm"].ToString();
				this.lblgg.Text=row["s_ypgg"].ToString();
				this.lblcj.Text=row["s_sccj"].ToString();
				this.lblhh.Text=row["shh"].ToString();

				this.lblpfj.Text=row["pfj"].ToString();
				this.lbllsj.Text=row["lsj"].ToString() ;
				this.lbljhj.Text=row["jhj"].ToString() ;

				this.lblpfj.Tag=row["pfj"].ToString();
				this.lbllsj.Tag=row["lsj"].ToString();
				this.lbljhj.Tag=row["jhj"].ToString();

				this.txtph.Text=Convert.ToString(row["ypph"]);
				this.txtph.Tag=row["kcid"].ToString();
//				this.lblkw.Text="";
//				this.lblkw.Tag="0";
				this.lblzmsl.Text=Convertor.IsNull(row["kcl"],"0");
				this.lblzmsl.Tag=row["dwbl"].ToString();
                Ypcj cj = new Ypcj(Convert.ToInt32(row["cjid"]), InstanceForm.BDatabase);
                Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cj.GGID, Convert.ToInt32(row["cjid"]), this.cmbdw, InstanceForm.BDatabase);
				this.cmbdw.SelectedIndex=0;
				if (this.checkBox1.Checked==false) 
					Selectpcmx(Convert.ToInt32(row["cjid"]));
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}


		//�����
		private void Fillrow(System.Data.DataRow row)
		{
			if (Convert.ToInt32(this.lblypmc.Tag)==0) 
			{
				MessageBox.Show("û�п���ӵ�ҩƷ");
				return;
			}

			if (new Guid(Convertor.IsNull(this.txtph.Tag,Guid.Empty.ToString()))==Guid.Empty)
			{
				if(MessageBox.Show("��ǰҩƷ�ڿ����û����ȷ��Ҫ����� ��","ѯ�ʴ�",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
				{
					return;
				}
			}

			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			if (row["���"].ToString().Trim()=="") row["���"]=tb.Rows.Count+1;
			row["Ʒ��"]=this.lblpm.Text.Trim();
			row["��Ʒ��"]=this.lblypmc.Text.Trim();
			row["���"]=this.lblgg.Text.Trim();
			row["����"]=this.lblcj.Text.Trim();
			row["������"]=this.lblpfj.Text.Trim();

			decimal sumpfje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(),"0"));
			row["�������"]=sumpfje.ToString("0.00");
			
			row["����"]=Convertor.IsNull(this.lbljhj.Text.Trim(),"0");
			row["���ۼ�"]=this.lbllsj.Text.Trim();
			row["����"]=this.txtph.Text.Trim();
			row["��λ"]="";//this.lblkw.Text.Trim();
			row["��������"]=Convertor.IsNull(this.lblzmsl.Text.Trim(),"0");

			decimal sumzmje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(),"0"));
			row["������"]=sumzmje.ToString("0.00");

			row["�̴�����"]=Convertor.IsNull(this.txtypsl.Text.Trim(),"0");
			row["��λ"]=this.cmbdw.Text.Trim();

			decimal sumpcje=Convert.ToDecimal(Convertor.IsNull(lblpcje.Text,"0"));
			row["�̴���"]=sumpcje.ToString("0.00");
			
			decimal yksl=Convert.ToDecimal(Convertor.IsNull(row["�̴�����"],"0"))-Convert.ToDecimal(Convertor.IsNull(row["��������"],"0"));
			row["ӯ������"]=yksl.ToString("0.0");
			
			decimal ykje=Convert.ToDecimal(Convertor.IsNull(row["ӯ������"],"0"))*Convert.ToDecimal(row["���ۼ�"]);
			row["ӯ�����"]=ykje.ToString("0.00");

			row["����"]=this.lblhh.Text.Trim();
			row["CJID"]=this.lblypmc.Tag.ToString();
            row["KCID"] = Convertor.IsNull(this.txtph.Tag, Guid.Empty.ToString());//new Guid(Convertor.IsNull(this.txtph.Tag,Guid.Empty.ToString())).ToString();
			row["DWBL"]=Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
			row["KWID"]="0";//Convertor.IsNull(this.lblkw.Tag,"0");

			SortRowNO();
		}

		
		//��ͽ��
		private void Sumje()
		{
			try
			{
				decimal sumpfje=0;
				decimal sumpcje=0;
				decimal sumjhje=0;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for( int i=0;i<=tb.Rows.Count-1;i++)
				{
                    sumpfje = sumpfje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["������"], "0"));
                    sumpcje = sumpcje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�̴���"], "0"));
					//sumjhje=sumjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["����"],"0"))*Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�̴�����"],"0"));
				}
				this.statusBar1.Panels[0].Text ="�ʴ����۽��: "+sumjhje.ToString("0.00");
				this.statusBar1.Panels[1].Text ="�̴����۽��: "+sumpcje.ToString("0.00");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}


		//��ȡһ��
		private void Getrow(DataRow row)
		{
			int cjid=Convert.ToInt32(Convertor.IsNull(row["cjid"],"0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
			this.lblpm.Text=row["Ʒ��"].ToString();
			this.lblypmc.Text=row["��Ʒ��"].ToString();
			this.lblypmc.Tag=row["CJID"].ToString();
			this.lblgg.Text=row["���"].ToString();
			this.lblcj.Text=row["����"].ToString();
			this.lblpfj.Text=row["������"].ToString();
			this.lblpfj.Tag=ydcj.PFJ.ToString();

			this.lbljhj.Text=row["����"].ToString();
			this.lbljhj.Tag=Convert.ToDecimal(Convertor.IsNull(row["����"],"0"))*Convert.ToDecimal(Convertor.IsNull(row["dwbl"],"0"));
			this.lbllsj.Text=row["���ۼ�"].ToString();
			this.lbllsj.Tag=ydcj.LSJ.ToString();


			this.txtph.Text=row["����"].ToString();
			this.txtph.Tag=row["kcid"].ToString();

//			this.lblkw.Text=row["��λ"].ToString();
//			this.lblkw.Tag=row["kwid"].ToString();
			this.lblzmsl.Text=row["��������"].ToString();
			this.lblzmsl.Tag=row["dwbl"].ToString();
			this.lblzmje.Text=row["������"].ToString();
			this.txtypsl.Text=row["�̴�����"].ToString();
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
			this.cmbdw.Text=row["��λ"].ToString();
			decimal pcje=Convert.ToDecimal(Convertor.IsNull(txtypsl.Text,"0"))*Convert.ToDecimal(lbllsj.Tag)/Convert.ToInt32(Convertor.IsNull(cmbdw.SelectedValue,"1"));
			this.lblpcje.Text=pcje.ToString("0.00");
			this.lblhh.Text=row["����"].ToString();
			
		}


		//���������к�
		private void SortRowNO()
		{
			DataTable tb1=(DataTable)this.myDataGrid1.DataSource;
			for(int i=0;i<=tb1.Rows.Count-1;i++)
			{
				tb1.Rows[i]["���"]=i+1;
			}
		}


		//��䵥��
		public void FillDj(Guid id,bool shbz)
		{
			try
			{
                cmbck.Enabled = false;
				string ssql="select * from yf_pdcs where id='"+id+"'";
				DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
                cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();
				this.groupBox1.Tag=tb.Rows[0]["id"].ToString();
				this.txtbz.Text=tb.Rows[0]["bz"].ToString();
				long djh=Convert.ToInt64(tb.Rows[0]["djh"]);
				long shdjh=Convert.ToInt64(tb.Rows[0]["shdjh"]);
				this.lbldjh.Text=djh.ToString("00000000");
				if (shdjh>0) this.lblshdjh.Text=shdjh.ToString("00000000");
				this.dtprq.Text=tb.Rows[0]["djrq"].ToString();

				ssql="select 0 ���,B.yppm Ʒ��,b.ypspm ��Ʒ��,b.ypgg ���,dbo.fun_yp_sccj(b.sccj) ����,a.pfj ������,0.00 �������,jhj ����,a.lsj ���ۼ�,a.ypph ����,hwmc ��λ,"+
					" zcsl ��������,round(zcsl*a.yklsj/ydwbl,2) ������,pcsl �̴�����,a.ypdw ��λ,"+
                    " round(pcsl*A.yklsj/ydwbl,2) �̴���, (case when (pcsl-zcsl)<>0 then cast((pcsl-zcsl) as float) else null end)  ӯ������,0.00 ӯ����� ,b.shh ����," +
                    " a.cjid,kcid,ydwbl dwbl,kwid,id ,''  ����,a.ypxq Ч��,a.yppch ���κ�,dbo.fun_yp_yplx(yplx) ҩƷ����,s_ypjx ����,"+
                    " '' ��������2" +
                    " from yf_pdcsmx a,vi_yp_ypcd b  " +
                    " where a.cjid=b.cjid and  djid='" + new Guid(tb.Rows[0]["id"].ToString()) + "' and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " order by a.pxxh";
				DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
				tbmx.TableName="tbmx";
				this.myDataGrid1.DataSource=tbmx;
				this.myDataGrid1.TableStyles[0].MappingName ="tbmx";
			
				this.butLoadData.Enabled=false;
				this.butmrzc.Enabled=false;

				if (Convert.ToInt32(tb.Rows[0]["shbz"])==1)
				{
					this.txtypdm.Enabled=false;
					this.txtypsl.Enabled=false;
					this.cmbdw.Enabled=false;
					this.butsave.Enabled=false;
					this.butadd.Enabled=false;
					this.butdel.Enabled=false;
					this.butmodif.Enabled=false;	
					this.myDataGrid1.ReadOnly=true;
				}

				this.butprint.Enabled=true;
				
				this.Sumje();
				SortRowNO();
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}

		}

		
		//���ģ��
		public void AddMB(int mbid)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[4];
				parameters[0].Value=Convert.ToInt32(mbid);
				parameters[0].Text="@mbid";
                parameters[1].Value = Convert.ToInt32(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
				parameters[1].Text="@deptid";

                parameters[2].Text = "bpcgl";
                parameters[2].Value = bpcgl;
                parameters[3].Text = "@pcfs";
                parameters[3].Value = "1";

				DataTable tb=InstanceForm.BDatabase.GetDataTable("sp_yf_MBIMPORT",parameters,30);
				FunBase.AddRowtNo(tb);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
				this.myDataGrid1.TableStyles[0].MappingName ="Tb";
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
			

		}

		
		//���ҵ�ǰҩƷ������̴��¼
		public void Selectpcmx(int cjid)
		{
			DataTable tbkc;
			if (YpConfig.�Ƿ�ҩ��(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),InstanceForm.BDatabase)==true)
                tbkc = Yp.Selectkc(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cjid, "yk_kcmx", InstanceForm.BDatabase);
			else
                tbkc = Yp.Selectkc(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cjid, "Yf_kcmx", InstanceForm.BDatabase);
		
			int xdwbl=1;
			int zxdw=0;
			if (tbkc.Rows.Count!=0)
			{
				xdwbl=Convert.ToInt32(tbkc.Rows[0]["dwbl"]);
				zxdw=Convert.ToInt32(tbkc.Rows[0]["zxdw"]);
			}

            DataTable tb = YF_PDCS_PDCSMX.Select_cjid_pdmx(cjid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), Convert.ToInt64(Convertor.IsNull(lblshdjh.Text, "0")), InstanceForm.BDatabase);
			if (tb.Rows.Count>0) 
			{
				decimal sumsl=0;
				for (int i=0;i<=tb.Rows.Count-1;i++)
				{
					int ydwbl=Convert.ToInt32(tb.Rows[i]["Ydwbl"]);
					decimal pcsl=Convert.ToDecimal(tb.Rows[i]["�̴�����"]);
					sumsl=sumsl+pcsl*(xdwbl/ydwbl);
				}
				DataRow row;
				row=tb.NewRow()	;		
				row["���"]="�ܼ�";
				row["�̴�����"]=Convert.ToString(sumsl.ToString("0.000"));
                row["��λ"] = Yp.SeekYpdw(zxdw, InstanceForm.BDatabase);
				if (row["��λ"].ToString().Trim()=="") row["��λ"]=tb.Rows[0]["��λ"].ToString();
				tb.Rows.Add(row);
				tb.TableName="tb";
				this.myDataGrid3.DataSource=tb;
				this.myDataGrid3.TableStyles[0].MappingName ="tb";
			}
		}
		
		//����˫���¼�
		private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber ;
				int cjid=0;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (nrow<tb.Rows.Count)
				{
					cjid=Convert.ToInt32(tb.Rows[nrow]["cjid"]);
				}
				Selectpcmx(cjid);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}

		}


		//���©��ҩƷ
		private void AddLpyp(long deptid)
		{
			string ssql="select 0 ���,cast(1 as smallint) ѡ��,B.yppm Ʒ��,b.ypspm ��Ʒ��,b.ypgg ���, s_sccj ����,"+
				" cast(round(b.pfj/a.dwbl,4) as decimal(15,4)) ������,cast(round(b.lsj/a.dwbl,4) as decimal(15,4)) ���ۼ�,a.ypph ����,'' ��λ,"+
				" kcl �����,dbo.fun_yp_ypdw(a.zxdw) ��λ,"+
				" b.shh ����,"+
				" a.cjid,kcid from yf_pdtemp a,vi_yp_ypcd b  where a.pddh="+Convert.ToInt64(Convertor.IsNull(lblshdjh.Text,"0"))+
				" and a.cjid=b.cjid and deptid="+deptid+" and (a.bdelete=0 or a.kcl<>0)  and "+
				" a.kcid not in(select kcid from yf_pdcsmx a,yf_pdcs b where A.deptid=b.deptid and a.djh=b.djh and bdelete=0 and a.deptid="+deptid+" and shdjh="+Convert.ToInt64(Convertor.IsNull(lblshdjh.Text,"0"))+") ";
			DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
			FunBase.AddRowtNo(tbmx);
			tbmx.TableName="Tb2";
			this.myDataGrid2.DataSource=tbmx;
			this.myDataGrid2.TableStyles[0].MappingName="Tb2";
		}
		#endregion
	
		#region ��ť�¼�
		//���һ��
		private void butadd_Click(object sender, System.EventArgs e)
		{
			try
			{

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				DataRow row=tb.NewRow();
				this.Fillrow(row);
				if (row["Ʒ��"].ToString().Trim()!="")
				{
                    cmbck.Enabled = false;
					tb.Rows.Add(row);
					this.Sumje();
					//this.myDataGrid1.CurrentCell=new DataGridCell(tb.Rows.Count,2);
					this.myDataGrid1.Select(tb.Rows.Count-1);
					this.myDataGrid1.CurrentCell=new DataGridCell(tb.Rows.Count-1,3);
					this.csgroupbox2();
					this.butadd.Enabled=true;
					//this.butadd.Enabled=true;
					this.txtypdm.Focus();
					return;
				}
				

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}
	
		
		//�µ���
		private void butnew_Click(object sender, System.EventArgs e)
		{
			this.Close();
			Frmxd f=new Frmxd(_menuTag,_chineseName,_mdiParent);
			f.ShowDialog();

		}

	
		//�����¼�
		private void butsave_Click(object sender, System.EventArgs e)
		{
			Guid djid=Guid.Empty;
			long djh=0;
			int err_code=0;
			string err_text="";
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			if (tb.Rows.Count==0) {MessageBox.Show("û�пɱ���ļ�¼");return;}

            //decimal sumsl = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(�̴�����)", "cjid>0"), "0"));
            //if (sumsl == 0)
            //{
            //    Font font = new Font("����", 16);
            //    if (TrasenFrame.Forms.FrmMessageBox.Show("��û�������κ��̴���,ȷ��Ҫ������?", font, Color.Red, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //}

			if(MessageBox.Show("��ȷ����������̴�������ȷ��������?","ѯ�ʴ�",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
			{
				return;
			}

			this.butsave.Enabled=false;


			try
			{
				this.Cursor=PubStaticFun.WaitCursor();;

				InstanceForm.BDatabase.BeginTransaction();
				//�������ݺ�
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToInt64(Convertor.IsNull(this.lbldjh.Text, "0"));
				
				//���浥�ݱ�ͷ
                YF_PDCS_PDCSMX.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), 
					djh,
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
					sDate,
					InstanceForm.BCurrentUser.EmployeeId,
					0,
					txtbz.Text.Trim(),out djid,
                    out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
			
				//���û�гɹ����׳��쳣
				if (err_code!=0){throw new System.Exception(err_text);}

				//���浥����ϸ
				
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["cjid"],"0"))>0)
					{
                        if (Convertor.IsNumeric(Convertor.IsNull(tb.Rows[i]["�̴�����"], "0")) == false)
                        {
                            int nerr = i + 1;
                            throw new Exception("���ڵ�"+nerr.ToString()+"�е��̴���������������");
                        }
                        YF_PDCS_PDCSMX.SaveDJMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"].ToString(), Guid.Empty.ToString())),
                            djid,
                            djh,
                            Convert.ToInt32(tb.Rows[i]["cjid"]),
                            Convert.ToString(tb.Rows[i]["����"]),
                            Convert.ToInt64(tb.Rows[i]["KWID"]),
                            Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["����"], "0")),
                            Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["������"], "0")),
                            Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���ۼ�"], "0")),
                            Convert.ToDecimal(tb.Rows[i]["��������"]),
                            Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�̴�����"], "0")),
                            Convert.ToString(tb.Rows[i]["��λ"]),
                            Convert.ToInt32(tb.Rows[i]["dwbl"]),
                            new Guid(tb.Rows[i]["KCID"].ToString()),
                            Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                            Convert.ToString(Convertor.IsNull(tb.Rows[i]["��λ"], "")),
                            Convert.ToInt32(tb.Rows[i]["���"]),
                            out err_code, out err_text, InstanceForm.BDatabase,
                            Convertor.IsNull(tb.Rows[i]["Ч��"], "1900-1-1"),
                            Convertor.IsNull(tb.Rows[i]["���κ�"], ""));
					}
				}

				//���û�гɹ����׳��쳣
				if (err_code!=0){throw new System.Exception(err_text);}

				//�ύ����
				InstanceForm.BDatabase.CommitTransaction();
				this.lbldjh.Text=djh.ToString("00000000");
				this.dtprq.Text=sDate.Trim();
				this.butadd.Enabled=false;
				this.butdel.Enabled=false;
				this.butmodif.Enabled=false;
				this.butprint.Enabled=true;
				this.butmrzc.Enabled=false;
                
				MessageBox.Show(err_text);
                FillDj(djid, false);
                this.butsave.Enabled = true;
			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				this.butsave.Enabled=true;
				MessageBox.Show(err.Message);
				
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

	
		// ɾ����
		private void butdel_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				if (nrow>=tb.Rows.Count) return;
				if(MessageBox.Show("��ȷ��Ҫɾ����"+Convert.ToString((nrow+1))+"���� ��","ѯ�ʴ�",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					DataRow datarow=tb.Rows[nrow];
                    Guid _id = new Guid(Convertor.IsNull(datarow["id"], Guid.Empty.ToString()));
                    Guid _djid = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));

					if (_id==Guid.Empty)
						tb.Rows.Remove(datarow);
					else
					{
						string ssql="select id from yf_pdcsmx where djid='"+_djid+"'";
						DataTable tab=InstanceForm.BDatabase.GetDataTable(ssql);
						
						InstanceForm.BDatabase.BeginTransaction();

						ssql="delete from YF_PDCSMX where id='"+_id+"'";
						InstanceForm.BDatabase.DoCommand(ssql);

						if (tab.Rows.Count==1)
						{
							ssql="delete from YF_PDCS where id='"+_djid+"'";
							InstanceForm.BDatabase.DoCommand(ssql);
						}

						InstanceForm.BDatabase.CommitTransaction();
						
						tb.Rows.Remove(datarow);
					}
					this.Sumje();
					this.csgroupbox2();
					SortRowNO();
				}

			
				this.butadd.Enabled=true;
			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show("��������"+err.Message);
			}
		}

	
		//�˳�
		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butclose1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	

		//�޸İ�ť�¼�
		private void butmodif_Click(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (nrow>tb.Rows.Count-1) return;
				DataRow row=tb.Rows[nrow];
				this.Fillrow(row);
				this.Sumje();
				this.butadd.Enabled=true;
				this.csgroupbox2();
				this.txtypdm.Focus();

			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}

		//Ĭ���ʴ���
		private void butmrzc_Click(object sender, System.EventArgs e)
		{
			//if (MessageBox.Show(this, "��ȷ��Ҫ���̴���Ĭ��Ϊ�ʴ�����", "ȷ��", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2 )==DialogResult.No ) return;
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			for (int i=0;i<=tb.Rows.Count-1;i++)
			{
				tb.Rows[i]["�̴�����"]=tb.Rows[i]["��������"];
                Ypcj cj = new Ypcj(Convert.ToInt32(tb.Rows[i]["cjid"]), InstanceForm.BDatabase);
                decimal sumpcje = Convert.ToDecimal(tb.Rows[i]["�̴�����"]) * Convert.ToDecimal(cj.LSJ) / Convert.ToInt32(tb.Rows[i]["dwbl"]);
				tb.Rows[i]["�̴���"]=sumpcje.ToString("0.00");
			}
		}
        //Ĭ��Ϊ��
        private void butmrwl_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                tb.Rows[i]["�̴�����"] = "0";
                tb.Rows[i]["�̴���"] = "0.00";
            }
        }
	
		//��ӡ
		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.ҩƷ�̵㵥.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["���"]);
					if (ss.��ӡ����ʱ������ʾ��Ʒ��==true)
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["��Ʒ��"]);
					else
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["Ʒ��"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["���"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["��λ"]);
                    myrow["yppch"] = Convert.ToString(tb.Rows[i]["���κ�"]);
                    myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["����"], "0"));
					myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["������"],"0"));
					myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���ۼ�"],"0"));
					myrow["zcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0"));
					myrow["zcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["������"],"0"));
					myrow["pcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�̴�����"],"0"));
					myrow["pcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�̴���"],"0"));
					myrow["yksl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ӯ������"],"0"));
					myrow["ypph"]=Convert.ToString(tb.Rows[i]["����"]);
                    myrow["ypxq"] = Convert.ToString(tb.Rows[i]["Ч��"]);
					myrow["shh"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["kwmc"]=Convert.ToString(tb.Rows[i]["��λ"]);

  

                    myrow["yplx"] = Convert.ToString(tb.Rows[i]["ҩƷ����"]);
                    myrow["ypjx"] = Convert.ToString(tb.Rows[i]["����"]);

					Dset.ҩƷ�̵㵥.Rows.Add(myrow);

				}

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from yf_pdcs where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

				ParameterEx[] parameters=new ParameterEx[6];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
                parameters[1].Value = djy + "                                 ��ӡԱ:" + InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value=dtprq.Text.Trim();
				parameters[3].Text="TITLETEXT";
				parameters[3].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")�̵�¼�뵥";
				parameters[4].Text="BZ";
				parameters[4].Value=txtbz.Text.Trim();
                parameters[5].Text = "CKMC";
                parameters[5].Value = cmbck.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.ҩƷ�̵㵥,Constant.ApplicationDirectory+"\\Report\\YF_ҩƷ�̵�¼�뵥.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
			

		}

		//��ӡ�ձ�
		private void butprintKB_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.ҩƷ�̵㵥.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["���"]);
					if (ss.��ӡ����ʱ������ʾ��Ʒ��==true)
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["��Ʒ��"]);
					else
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["Ʒ��"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["���"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["��λ"]);
                    myrow["yppch"] = Convert.ToString(tb.Rows[i]["���κ�"]);
                    myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["����"], "0"));
					myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["������"],"0"));
					myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���ۼ�"],"0"));
					myrow["zcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0"));
					myrow["zcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["������"],"0"));
					myrow["pcsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�̴�����"],"0"));
					myrow["pcje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�̴���"],"0"));
					myrow["yksl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ӯ������"],"0"));
					myrow["ypph"]=Convert.ToString(tb.Rows[i]["����"]);
                    myrow["ypxq"] = Convert.ToString(tb.Rows[i]["Ч��"]);
					myrow["shh"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["kwmc"]=Convert.ToString(tb.Rows[i]["��λ"]);
                    myrow["yppch"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["���κ�"],""));
                    myrow["yplx"] = Convert.ToString(tb.Rows[i]["ҩƷ����"]);
                    myrow["ypjx"] = Convert.ToString(tb.Rows[i]["����"]);
                    myrow["zcsl2"] = Convert.ToString(tb.Rows[i]["��������2"]);
					Dset.ҩƷ�̵㵥.Rows.Add(myrow);

				}
				ParameterEx[] parameters=new ParameterEx[6];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
				parameters[1].Value=InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value=dtprq.Text.Trim();
				parameters[3].Text="TITLETEXT";
				parameters[3].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")�̵�ձ�";
				parameters[4].Text="BZ";
				parameters[4].Value=txtbz.Text.Trim();
                parameters[5].Text = "CKMC";
                parameters[5].Value = cmbck.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.ҩƷ�̵㵥,Constant.ApplicationDirectory+"\\Report\\YF_ҩƷ�̵�ձ�.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}		
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}


		private void butnext_Click(object sender, System.EventArgs e)
		{
			try
			{
				int cjid=Convert.ToInt32(Convertor.IsNull(this.txtdwcx.Tag,"0"));
				int nrow=Convert.ToInt32(Convertor.IsNull(this.butnext.Tag,"0"));
				FindRecord(cjid,nrow);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}

		private void butLoadData_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				FrmOptionData f=new FrmOptionData(_menuTag,_chineseName,_mdiParent);
				Point point=new Point(500,75 );
				f.Location=point;
				f.ShowDialog();
				if (f.ssql=="") return;

                string tlName = f.strtlName;
                this.txtbz.Text = tlName;

                cmbck.SelectedValue = f._Deptid.ToString();
                cmbck.Enabled = false;

				DataTable tb=InstanceForm.BDatabase.GetDataTable(f.ssql);
				FunBase.AddRowtNo(tb);
				tb.TableName="tb";
				this.myDataGrid1.DataSource=tb;
				this.myDataGrid1.TableStyles[0].MappingName ="tb";

                ////if (f.chkmrz.Checked == true)
                ////    butmrwl_Click(sender, e);
                ////else
                ////    butmrzc_Click(sender, e);


                //if (!bpcgl)//���������ι���
                //{
                //    col���κ�.Width = 0;
                //    colЧ��.Width = 0;
                //    cc���κ�.Width = 0;
                //    ccЧ��.Width = 0;
                //    c���κ�.Width = 0;
                //    cЧ��.Width = 0;
                //}

			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}

		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
                if (tabControl1.SelectedTab == this.tabPage2) AddLpyp(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}
		#endregion

		private void butprintlpyp_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				DataRow[] rows;
				if (this.chkprintlp.Checked==true)
					rows=tb.Select("�����<>'0'");
				else
					rows=tb.Select("");

				for(int i=0;i<=rows.Length-1;i++)
				{
					
					myrow=Dset.ҩƷ�̵㵥.NewRow();
					myrow["xh"]=Convert.ToInt32(rows[i]["���"]);
					myrow["ypmc"]=Convert.ToString(rows[i]["Ʒ��"]);
					myrow["ypgg"]=Convert.ToString(rows[i]["���"]);
					myrow["sccj"]=Convert.ToString(rows[i]["����"]);
					myrow["ypdw"]=Convert.ToString(rows[i]["��λ"]);
					myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["������"],"0"));
					myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["���ۼ�"],"0"));
					myrow["zcsl"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["�����"],"0"));
					decimal zmje=Convert.ToDecimal(myrow["zcsl"])*Convert.ToDecimal(myrow["lsj"]);
					myrow["zcje"]=zmje.ToString("0.00");
					myrow["pcsl"]=0;
					myrow["pcje"]=0;
					myrow["yksl"]=0;
					myrow["ypph"]=Convert.ToString(rows[i]["����"]);
					myrow["shh"]=Convert.ToString(rows[i]["����"]);
					myrow["kwmc"]=Convert.ToString(rows[i]["��λ"]);
					Dset.ҩƷ�̵㵥.Rows.Add(myrow);

				}
				ParameterEx[] parameters=new ParameterEx[5];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
				parameters[1].Value=InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value=dtprq.Text.Trim();
				parameters[3].Text="TITLETEXT";
				parameters[3].Value="©��ҩƷ��";
				parameters[4].Text="BZ";
				parameters[4].Value=txtbz.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.ҩƷ�̵㵥,Constant.ApplicationDirectory+"\\Report\\YF_ҩƷ�̵�ձ�.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}		
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		private void butsavemb_Click(object sender, System.EventArgs e)
		{
			try
			{
				string mbmc="";
				int mbid=0;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;

                Frmxd2 f = new Frmxd2(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
				f.ShowDialog();
				if (f.mbid==-1) return;
				if (f.mbid==0)
				{
					TrasenFrame.Forms.DlgInputBox f1=new TrasenFrame.Forms.DlgInputBox(mbmc,"������ģ�������","��������");
					f1.ShowDialog();
					if (DlgInputBox.DlgResult==true)
					{
						mbmc=DlgInputBox.DlgValue;
						mbid=0;
					}
					else return;

				}
				else
				{
					mbid=f.mbid;
					mbmc=f.mbmc;

				}

				InstanceForm.BDatabase.BeginTransaction();
				int newmbid=0;

				//ɾ��ģ����ϸ
                YP_PDMB.DeleteMbmx(mbid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);

				//����ģ��ͷ
                YP_PDMB.SaveMb(mbid, mbmc, "", "", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(), InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(), InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), out newmbid, InstanceForm.BDatabase);
				if (newmbid==0 && mbid==0) {MessageBox.Show("ģ��IDΪ�㣬û�б���ɹ�");return;}
				if (mbid==0 && newmbid!=0){mbid=newmbid;}
	

				//����ģ����ϸ
				for (int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["cjid"],"0"))>0)
                        YP_PDMB.SaveMbmx(Convert.ToInt32(tb.Rows[i]["cjid"]), mbid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), tb.Rows[i]["����"].ToString(), InstanceForm.BDatabase);
				}
				
				InstanceForm.BDatabase.CommitTransaction();
				
				MessageBox.Show("����ɹ�");
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message,"����",MessageBoxButtons.OK,MessageBoxIcon.Error);
				InstanceForm.BDatabase.RollbackTransaction();
			}

		}

        private void myDataGrid2_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            int ncol = this.myDataGrid2.CurrentCell.ColumnNumber;
            if (this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].HeaderText == "ѡ��")
                tb.Rows[nrow][ncol] = Convert.ToBoolean(tb.Rows[nrow][ncol]) == true ? false : true;
        }

        private void butjy_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            string ssql = "";
            int cjid=0;
            long kcid = 0;
            decimal kcl = 0;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                for (int i = 0; i < tb.Rows.Count - 1; i++)
                {
                    
                    cjid = Convert.ToInt32(tb.Rows[i]["cjid"]);
                    kcid = Convert.ToInt64(tb.Rows[i]["kcid"]);
                    kcl = Convert.ToDecimal(tb.Rows[i]["�����"]);
                    if (kcl == 0)
                    {
                        //�������ű�
                        ssql = "update " + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + " set bdelete=1 where cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and id=" + kcid + "";
                        InstanceForm.BDatabase.DoCommand(ssql);

                        ssql = "update  yf_pdtemp set bdelete=1 where cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and kcid=" + kcid + "";
                        InstanceForm.BDatabase.DoCommand(ssql);

                        //���¿���
                        ssql = "select * from " + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + " where  cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and bdelete=0 ";
                        DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tab.Rows.Count == 0)
                        {
                            ssql = "update " + Yp.Seek_kcmx_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + " set bdelete=1 where cjid=" + cjid + " and deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + "";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }
                    }
                }

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("�����ɹ�");
                tabControl1_SelectedIndexChanged(sender, e);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message);
            }
        }

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbck.SelectedValue == null) return;
                if (cmbck.SelectedValue.ToString() == "System.Data.DataRowView") return;
                ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),InstanceForm.BDatabase);
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (tb != null) tb.Rows.Clear();
                //ϵͳ����
                if (ss.����������ʾ��Ʒ�� == true)
                {
                    this.��Ʒ��.Width = 130;
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 140;
                }
                else
                {
                    this.��Ʒ��.Width = 0;
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 0;
                }

                int deptid = Convert.ToInt32(cmbck.SelectedValue);
                bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
                if (!bpcgl)//���������ι���
                {
                    col���κ�.Width = 0;
                    colЧ��.Width = 0;
                    cc���κ�.Width = 0;
                    ccЧ��.Width = 0;
                    c���κ�.Width = 0;
                    cЧ��.Width = 0;
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }















    }
}
