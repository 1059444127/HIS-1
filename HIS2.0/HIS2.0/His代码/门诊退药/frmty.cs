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
using ts_mz_class;
using ClsWsMzTy;

namespace ts_yf_mzty
{
    /// <summary>
    /// Form1 ��ժҪ˵����
    /// </summary>
    public class Frmmzty : System.Windows.Forms.Form
    {
        private string _Fyckh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridTextBoxColumn XH;
        private System.Windows.Forms.DataGridTextBoxColumn fph;
        private System.Windows.Forms.DataGridTextBoxColumn je;
        private System.Windows.Forms.DataGridTextBoxColumn xm;
        private System.Windows.Forms.DataGridTextBoxColumn brxm;
        private System.Windows.Forms.DataGridTextBoxColumn SFRQ;
        private System.Windows.Forms.DataGridTextBoxColumn sfy;
        private System.Windows.Forms.DataGridTextBoxColumn PYR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid2;
        private System.Windows.Forms.ComboBox cmbpyr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rdoytycf;
        private System.Windows.Forms.RadioButton rdoytywtfcf;
        private System.Windows.Forms.RadioButton rdodtycf;
        private System.Windows.Forms.RadioButton rdoall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Button butfy;
        private System.Windows.Forms.ComboBox cmbph;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Button butqxfy;
        private System.Windows.Forms.Button butquit;
        //private decimal _zje=0;
        private Guid _fyid = Guid.Empty;
        private System.Windows.Forms.CheckBox chkprrintView;
        private System.Windows.Forms.Button buttjs;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.CheckBox chkxp;
        private System.Windows.Forms.Label lblzd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblnl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblxb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblxm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtfph;
        private System.Windows.Forms.Label label4;
        private YpConfig s;
        private ComboBox cmbklx;
        private TextBox txttmk;
        private Label label5;
        private TextBox txtlsh;
        private Label label6;
        private TextBox txtmzh;
        private Label label8;
        private SystemCfg cfg8025 = new SystemCfg( 8025 );
        private SystemCfg cfg8001 = new SystemCfg( 8001 );
        private bool bpcgl = true; //�Ƿ�������ι���

        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frmmzty( MenuTag menuTag , string chineseName , Form mdiParent )
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName.Trim();
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            s = new YpConfig( InstanceForm.BCurrentDept.DeptId , InstanceForm.BDatabase );
            if ( s.���﷢ҩ����ҩʱĬ�ϴ�ӡСƱ == true )
                this.chkxp.Checked = true;
            else
                this.chkxp.Checked = false;

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
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
            this.XH = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fph = new System.Windows.Forms.DataGridTextBoxColumn();
            this.je = new System.Windows.Forms.DataGridTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridTextBoxColumn();
            this.brxm = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SFRQ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sfy = new System.Windows.Forms.DataGridTextBoxColumn();
            this.PYR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtmzh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtlsh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.txttmk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblzd = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblnl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblxb = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblxm = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoytywtfcf = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoytycf = new System.Windows.Forms.RadioButton();
            this.rdodtycf = new System.Windows.Forms.RadioButton();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttjs = new System.Windows.Forms.Button();
            this.cmbph = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkxp = new System.Windows.Forms.CheckBox();
            this.chkprrintView = new System.Windows.Forms.CheckBox();
            this.butqxfy = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.butfy = new System.Windows.Forms.Button();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid1 ) ).BeginInit();
            this.panel3.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel2 ) ).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // XH
            // 
            this.XH.Format = "";
            this.XH.FormatInfo = null;
            this.XH.HeaderText = "���";
            this.XH.NullText = "";
            this.XH.ReadOnly = true;
            this.XH.Width = 50;
            // 
            // fph
            // 
            this.fph.Format = "";
            this.fph.FormatInfo = null;
            this.fph.HeaderText = "��Ʊ��";
            this.fph.NullText = "";
            this.fph.ReadOnly = true;
            this.fph.Width = 60;
            // 
            // je
            // 
            this.je.Format = "";
            this.je.FormatInfo = null;
            this.je.HeaderText = "���";
            this.je.NullText = "";
            this.je.ReadOnly = true;
            this.je.Width = 60;
            // 
            // xm
            // 
            this.xm.Format = "";
            this.xm.FormatInfo = null;
            this.xm.HeaderText = "��Ŀ";
            this.xm.NullText = "";
            this.xm.ReadOnly = true;
            this.xm.Width = 0;
            // 
            // brxm
            // 
            this.brxm.Format = "";
            this.brxm.FormatInfo = null;
            this.brxm.HeaderText = "����";
            this.brxm.NullText = "";
            this.brxm.ReadOnly = true;
            this.brxm.Width = 60;
            // 
            // SFRQ
            // 
            this.SFRQ.Format = "";
            this.SFRQ.FormatInfo = null;
            this.SFRQ.HeaderText = "�շ�����";
            this.SFRQ.NullText = "";
            this.SFRQ.ReadOnly = true;
            this.SFRQ.Width = 70;
            // 
            // sfy
            // 
            this.sfy.Format = "";
            this.sfy.FormatInfo = null;
            this.sfy.HeaderText = "�շ�Ա";
            this.sfy.NullText = "";
            this.sfy.ReadOnly = true;
            this.sfy.Width = 50;
            // 
            // PYR
            // 
            this.PYR.Format = "";
            this.PYR.FormatInfo = null;
            this.PYR.HeaderText = "��ҩ��";
            this.PYR.NullText = "";
            this.PYR.ReadOnly = true;
            this.PYR.Width = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.txtmzh );
            this.panel1.Controls.Add( this.label8 );
            this.panel1.Controls.Add( this.txtlsh );
            this.panel1.Controls.Add( this.label6 );
            this.panel1.Controls.Add( this.cmbklx );
            this.panel1.Controls.Add( this.txttmk );
            this.panel1.Controls.Add( this.label5 );
            this.panel1.Controls.Add( this.lblzd );
            this.panel1.Controls.Add( this.label16 );
            this.panel1.Controls.Add( this.lblks );
            this.panel1.Controls.Add( this.label14 );
            this.panel1.Controls.Add( this.lblnl );
            this.panel1.Controls.Add( this.label12 );
            this.panel1.Controls.Add( this.lblxb );
            this.panel1.Controls.Add( this.label10 );
            this.panel1.Controls.Add( this.lblxm );
            this.panel1.Controls.Add( this.label7 );
            this.panel1.Controls.Add( this.txtfph );
            this.panel1.Controls.Add( this.label4 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 1027 , 68 );
            this.panel1.TabIndex = 0;
            // 
            // txtmzh
            // 
            this.txtmzh.BackColor = System.Drawing.Color.White;
            this.txtmzh.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtmzh.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.txtmzh.Location = new System.Drawing.Point( 697 , 12 );
            this.txtmzh.Name = "txtmzh";
            this.txtmzh.Size = new System.Drawing.Size( 112 , 21 );
            this.txtmzh.TabIndex = 53;
            this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtfph_KeyPress );
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point( 649 , 15 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 56 , 17 );
            this.label8.TabIndex = 54;
            this.label8.Text = "�����";
            // 
            // txtlsh
            // 
            this.txtlsh.BackColor = System.Drawing.Color.White;
            this.txtlsh.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtlsh.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.txtlsh.Location = new System.Drawing.Point( 540 , 12 );
            this.txtlsh.Name = "txtlsh";
            this.txtlsh.Size = new System.Drawing.Size( 93 , 21 );
            this.txtlsh.TabIndex = 51;
            this.txtlsh.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtfph_KeyPress );
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point( 482 , 15 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 57 , 17 );
            this.label6.TabIndex = 52;
            this.label6.Text = "��ˮ��";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cmbklx.Location = new System.Drawing.Point( 248 , 11 );
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size( 72 , 22 );
            this.cmbklx.TabIndex = 50;
            // 
            // txttmk
            // 
            this.txttmk.BackColor = System.Drawing.Color.White;
            this.txttmk.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txttmk.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.txttmk.Location = new System.Drawing.Point( 322 , 12 );
            this.txttmk.Name = "txttmk";
            this.txttmk.Size = new System.Drawing.Size( 153 , 21 );
            this.txttmk.TabIndex = 48;
            this.txttmk.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtfph_KeyPress );
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point( 162 , 15 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 87 , 17 );
            this.label5.TabIndex = 49;
            this.label5.Text = "������/����";
            // 
            // lblzd
            // 
            this.lblzd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzd.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblzd.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblzd.Location = new System.Drawing.Point( 642 , 40 );
            this.lblzd.Name = "lblzd";
            this.lblzd.Size = new System.Drawing.Size( 168 , 21 );
            this.lblzd.TabIndex = 47;
            this.lblzd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblzd.Visible = false;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point( 604 , 42 );
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size( 55 , 17 );
            this.label16.TabIndex = 46;
            this.label16.Text = "���";
            this.label16.Visible = false;
            // 
            // lblks
            // 
            this.lblks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblks.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblks.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblks.Location = new System.Drawing.Point( 467 , 40 );
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size( 128 , 21 );
            this.lblks.TabIndex = 45;
            this.lblks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblks.Visible = false;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point( 428 , 42 );
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size( 57 , 17 );
            this.label14.TabIndex = 44;
            this.label14.Text = "����";
            this.label14.Visible = false;
            // 
            // lblnl
            // 
            this.lblnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblnl.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblnl.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblnl.Location = new System.Drawing.Point( 260 , 40 );
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size( 69 , 21 );
            this.lblnl.TabIndex = 43;
            this.lblnl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point( 226 , 42 );
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size( 57 , 17 );
            this.label12.TabIndex = 42;
            this.label12.Text = "����";
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxb.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblxb.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblxb.Location = new System.Drawing.Point( 185 , 40 );
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size( 37 , 21 );
            this.lblxb.TabIndex = 41;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point( 152 , 42 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 56 , 17 );
            this.label10.TabIndex = 40;
            this.label10.Text = "�Ա�";
            // 
            // lblxm
            // 
            this.lblxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxm.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblxm.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblxm.Location = new System.Drawing.Point( 59 , 40 );
            this.lblxm.Name = "lblxm";
            this.lblxm.Size = new System.Drawing.Size( 92 , 21 );
            this.lblxm.TabIndex = 39;
            this.lblxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point( 2 , 42 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 56 , 17 );
            this.label7.TabIndex = 38;
            this.label7.Text = "����";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtfph
            // 
            this.txtfph.BackColor = System.Drawing.Color.White;
            this.txtfph.Font = new System.Drawing.Font( "����" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtfph.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.txtfph.Location = new System.Drawing.Point( 59 , 12 );
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size( 93 , 21 );
            this.txtfph.TabIndex = 36;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtfph_KeyPress );
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point( 1 , 15 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 57 , 17 );
            this.label4.TabIndex = 37;
            this.label4.Text = "��Ʊ��";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.myDataGrid1 );
            this.panel2.Controls.Add( this.panel3 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point( 0 , 68 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 312 , 672 );
            this.panel2.TabIndex = 1;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font( "Tahoma" , 8.25F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.myDataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.CaptionText = "����ͷ";
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point( 0 , 64 );
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size( 312 , 608 );
            this.myDataGrid1.TabIndex = 1;
            this.myDataGrid1.TableStyles.AddRange( new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1} );
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler( this.myDataGrid1_CurrentCellChanged );
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add( this.rdoytywtfcf );
            this.panel3.Controls.Add( this.button5 );
            this.panel3.Controls.Add( this.dtp2 );
            this.panel3.Controls.Add( this.label3 );
            this.panel3.Controls.Add( this.dtp1 );
            this.panel3.Controls.Add( this.label2 );
            this.panel3.Controls.Add( this.rdoytycf );
            this.panel3.Controls.Add( this.rdodtycf );
            this.panel3.Controls.Add( this.rdoall );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0 , 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 312 , 64 );
            this.panel3.TabIndex = 0;
            this.panel3.Visible = false;
            // 
            // rdoytywtfcf
            // 
            this.rdoytywtfcf.Location = new System.Drawing.Point( 184 , 0 );
            this.rdoytywtfcf.Name = "rdoytywtfcf";
            this.rdoytywtfcf.Size = new System.Drawing.Size( 128 , 24 );
            this.rdoytywtfcf.TabIndex = 3;
            this.rdoytywtfcf.Text = "����ҩδ�˷�";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            this.button5.Location = new System.Drawing.Point( 270 , 30 );
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size( 48 , 24 );
            this.button5.TabIndex = 8;
            this.button5.Text = "ˢ��";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler( this.button5_Click );
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point( 154 , 33 );
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size( 110 , 21 );
            this.dtp2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 138 , 37 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 48 , 16 );
            this.label3.TabIndex = 6;
            this.label3.Text = "��";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point( 32 , 33 );
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size( 105 , 21 );
            this.dtp1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 2 , 36 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 48 , 16 );
            this.label2.TabIndex = 4;
            this.label2.Text = "����";
            // 
            // rdoytycf
            // 
            this.rdoytycf.Location = new System.Drawing.Point( 120 , 0 );
            this.rdoytycf.Name = "rdoytycf";
            this.rdoytycf.Size = new System.Drawing.Size( 88 , 24 );
            this.rdoytycf.TabIndex = 2;
            this.rdoytycf.Text = "����ҩ";
            // 
            // rdodtycf
            // 
            this.rdodtycf.Location = new System.Drawing.Point( 56 , 0 );
            this.rdodtycf.Name = "rdodtycf";
            this.rdodtycf.Size = new System.Drawing.Size( 88 , 24 );
            this.rdodtycf.TabIndex = 1;
            this.rdodtycf.Text = "����ҩ";
            // 
            // rdoall
            // 
            this.rdoall.Checked = true;
            this.rdoall.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.rdoall.Location = new System.Drawing.Point( 8 , 0 );
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size( 56 , 24 );
            this.rdoall.TabIndex = 0;
            this.rdoall.TabStop = true;
            this.rdoall.Text = "ȫ��";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font( "Tahoma" , 10.5F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Navy;
            this.myDataGrid2.CaptionText = "������ϸ ";
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font( "����" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point( 0 , 0 );
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ParentRowsBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 224 ) ) ) ) , ( (int)( ( (byte)( 224 ) ) ) ) , ( (int)( ( (byte)( 224 ) ) ) ) );
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size( 713 , 584 );
            this.myDataGrid2.TabIndex = 2;
            this.myDataGrid2.TableStyles.AddRange( new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2} );
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler( this.myDataGrid2_CurrentCellChanged );
            this.myDataGrid2.Click += new System.EventHandler( this.myDataGrid2_Click );
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.RowHeaderWidth = 20;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point( 312 , 68 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 2 , 672 );
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point( 314 , 716 );
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange( new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2} );
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size( 713 , 24 );
            this.statusBar1.TabIndex = 3;
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
            this.statusBarPanel2.Text = "Ҫȡ����ҩʱ����������� [ѡ] ���ϴ�";
            this.statusBarPanel2.Width = 1000;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.panel6 );
            this.panel4.Controls.Add( this.panel5 );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 314 , 68 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 713 , 648 );
            this.panel4.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add( this.buttjs );
            this.panel6.Controls.Add( this.cmbph );
            this.panel6.Controls.Add( this.myDataGrid2 );
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point( 0 , 64 );
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size( 713 , 584 );
            this.panel6.TabIndex = 1;
            // 
            // buttjs
            // 
            this.buttjs.Location = new System.Drawing.Point( 280 , 2 );
            this.buttjs.Name = "buttjs";
            this.buttjs.Size = new System.Drawing.Size( 104 , 22 );
            this.buttjs.TabIndex = 4;
            this.buttjs.Text = "��������ҩ����";
            this.buttjs.Click += new System.EventHandler( this.buttjs_Click );
            // 
            // cmbph
            // 
            this.cmbph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbph.Location = new System.Drawing.Point( 104 , 96 );
            this.cmbph.Name = "cmbph";
            this.cmbph.Size = new System.Drawing.Size( 80 , 20 );
            this.cmbph.TabIndex = 3;
            this.cmbph.Visible = false;
            this.cmbph.SelectedIndexChanged += new System.EventHandler( this.cmbph_SelectedIndexChanged );
            this.cmbph.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.cmbph_KeyPress );
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add( this.chkxp );
            this.panel5.Controls.Add( this.chkprrintView );
            this.panel5.Controls.Add( this.butqxfy );
            this.panel5.Controls.Add( this.butquit );
            this.panel5.Controls.Add( this.button2 );
            this.panel5.Controls.Add( this.butfy );
            this.panel5.Controls.Add( this.cmbpyr );
            this.panel5.Controls.Add( this.label1 );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point( 0 , 0 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 713 , 64 );
            this.panel5.TabIndex = 0;
            // 
            // chkxp
            // 
            this.chkxp.Location = new System.Drawing.Point( 174 , 34 );
            this.chkxp.Name = "chkxp";
            this.chkxp.Size = new System.Drawing.Size( 100 , 18 );
            this.chkxp.TabIndex = 37;
            this.chkxp.Text = "Ĭ�ϴ�ӡСƱ";
            // 
            // chkprrintView
            // 
            this.chkprrintView.Location = new System.Drawing.Point( 175 , 8 );
            this.chkprrintView.Name = "chkprrintView";
            this.chkprrintView.Size = new System.Drawing.Size( 79 , 24 );
            this.chkprrintView.TabIndex = 8;
            this.chkprrintView.Text = "��ӡԤ��";
            // 
            // butqxfy
            // 
            this.butqxfy.Location = new System.Drawing.Point( 368 , 16 );
            this.butqxfy.Name = "butqxfy";
            this.butqxfy.Size = new System.Drawing.Size( 88 , 32 );
            this.butqxfy.TabIndex = 7;
            this.butqxfy.Text = "ȡ����ҩ(&C)";
            this.butqxfy.Click += new System.EventHandler( this.butqxfy_Click );
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point( 544 , 16 );
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size( 88 , 32 );
            this.butquit.TabIndex = 6;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler( this.butquit_Click );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 456 , 16 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 88 , 32 );
            this.button2.TabIndex = 5;
            this.button2.Text = "��ӡ(&P)";
            this.button2.Click += new System.EventHandler( this.butprint_Click );
            // 
            // butfy
            // 
            this.butfy.Location = new System.Drawing.Point( 280 , 16 );
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size( 88 , 32 );
            this.butfy.TabIndex = 4;
            this.butfy.Text = "��ҩȷ��(&O)";
            this.butfy.Click += new System.EventHandler( this.butfy_Click );
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point( 64 , 22 );
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size( 104 , 20 );
            this.cmbpyr.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 24 , 26 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 48 , 16 );
            this.label1.TabIndex = 2;
            this.label1.Text = "��ҩ��";
            // 
            // Frmmzty
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 1027 , 740 );
            this.Controls.Add( this.panel4 );
            this.Controls.Add( this.statusBar1 );
            this.Controls.Add( this.splitter1 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.KeyPreview = true;
            this.Name = "Frmmzty";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.Frmmzfy_Load );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid1 ) ).EndInit();
            this.panel3.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel2 ) ).EndInit();
            this.panel4.ResumeLayout( false );
            this.panel6.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion


        private void Frmmzfy_Load( object sender , System.EventArgs e )
        {
            FunAddComboBox.AddKlx( false , 0 , cmbklx , InstanceForm.BDatabase );
            CshMyGrid1( this.myDataGrid1 );
            CshMyGrid2( this.myDataGrid2 );

            //��ҩ����
            ///////_Fyckh=MZYF.SeekFychk(PubStaticFun.GetMacAddress());

            //�����ҩ��
            Yp.AddcmbPyr( InstanceForm.BCurrentDept.DeptId , this.cmbpyr , InstanceForm.BDatabase );

            this.dtp1.Value = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase );
            this.dtp2.Value = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase );

            if ( _menuTag.Function_Name.Trim() != "Fun_ts_yf_mzty" && _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
            {
                this.label1.Visible = false;
                this.cmbpyr.Visible = false;
            }

            //�Զ�����Ƶ��
            string sbxh = ApiFunction.GetIniString( "ҽԺ������" , "�豸�ͺ�" , Constant.ApplicationDirectory + "//ClientWindow.ini" );
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall( sbxh );
            if ( ReadCard != null )
                ReadCard.AutoReadCard( _menuTag.Function_Name , cmbklx , txttmk );

            int deptid = InstanceForm.BCurrentDept.DeptId; //�ⷿid
            bpcgl = Yp.BPcgl( deptid , InstanceForm.BDatabase );                         //�Ƿ�������ι���
        }


        #region ��ʼ��������
        private void CshMyGrid1( TrasenClasses.GeneralControls.ButtonDataGridEx dataGrid )
        {
            #region �����ϸ����
            string[] HeaderText ={ "���" , "״̬" , "��Ʊ��" , "���" , "������" , "����" , "�Ա�" , "����" , "��Ŀ" , "���ʽ��" , "�Żݽ��" , "�Ը����" , "����" , "ҽ��" , "����" , "�շ�����" , "�շ�Ա" , "��ҩ��" , "��ҩ����" , "��ҩ����" , "��ҩ��" , "jssjh" , "xh" , "patid" , "ysdm" , "ksdm" , "sky" , "pyckh" , "cflx" , "id" };
            string[] MappingName ={ "���" , "״̬" , "��Ʊ��" , "���" , "������" , "����" , "�Ա�" , "����" , "��Ŀ" , "���ʽ��" , "�Żݽ��" , "�Ը����" , "����" , "ҽ��" , "����" , "�շ�����" , "�շ�Ա" , "��ҩ��" , "��ҩ����" , "��ҩ����" , "��ҩ��" , "jssjh" , "xh" , "patid" , "ysdm" , "ksdm" , "sky" , "pyckh" , "cflx" , "id" };
            int[] ColWidth ={ 35 , 50 , 60 , 55 , 0 , 55 , 40 , 40 , 55 , 0 , 0 , 0 , 70 , 55 , 45 , 100 , 55 , 55 , 0 , 100 , 55 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 };
            bool[] ColReadOnly ={ true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true };
            bool[] ColBool ={ false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false };
            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tb";

            for ( int j = 0 ; j <= HeaderText.Length - 1 ; j++ )
            {
                //DataGridEnableBoolColumn
                if ( ColBool[j] == false )
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn( j );
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "";
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler( colText_CheckCellEnabled );

                    dataGrid.TableStyles[0].GridColumnStyles.Add( colText );
                    DataColumn datacol;
                    if ( MappingName[j] == "���" )
                        datacol = new DataColumn( MappingName[j] , Type.GetType( "System.Decimal" ) );
                    else
                        datacol = new DataColumn( MappingName[j] );

                    dtTmp.Columns.Add( datacol );
                }
                else
                {
                    DataGridEnableBoolColumn colText = new DataGridEnableBoolColumn( j );
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "0";
                    colText.AllowNull = false;
                    colText.NullValue = ( (short)( 0 ) );
                    colText.FalseValue = ( (short)( 0 ) );
                    colText.TrueValue = ( (short)( 1 ) );
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableBoolColumn.EnableCellEventHandler( colText_CheckCellEnabled );

                    dataGrid.TableStyles[0].GridColumnStyles.Add( colText );
                    dtTmp.Columns.Add( MappingName[j] , Type.GetType( "System.Int16" ) );

                }

            }

            dataGrid.DataSource = dtTmp;
            dataGrid.TableStyles[0].MappingName = "tb";
            #endregion

        }

        private void CshMyGrid2( TrasenClasses.GeneralControls.ButtonDataGridEx dataGrid )
        {
            #region �����ϸ����
            string[] HeaderText ={ "���" , "ѡ" , "Ƥ��" , "��Ʊ��" , "ҩƷ����" , "���" , "����" , "������" , "���ۼ�" , "����" , "����" , "����" , "������" , "�˼���" , "��λ" , "�������" , "���۽��" , "cfxh" , "ypid" , "ydwbl" , "����" , "���۲��" , "cfts" , "id" , "fyid" , "tyid" , "deptid" , "cfmxid" , "�÷�" , "����" , "���κ�" , "Ч��" , "kcid" , "����" , "�������" , "byscf" };
            string[] MappingName ={ "���" , "ѡ" , "Ƥ��" , "��Ʊ��" , "ҩƷ����" , "���" , "����" , "������" , "���ۼ�" , "����" , "����" , "����" , "������" , "�˼���" , "��λ" , "�������" , "���۽��" , "cfxh" , "ypid" , "ydwbl" , "����" , "���۲��" , "cfts" , "id" , "fyid" , "tyid" , "deptid" , "cfmxid" , "�÷�" , "����" , "���κ�" , "Ч��" , "kcid" , "����" , "�������" , "byscf" };
            int[] ColWidth ={ 35 , 25 , 50 , 0 , 100 , 100 , 0 , 0 , 55 , 50 , 50 , 70 , 55 , 35 , 0 , 0 , 65 , 0 , 0 , 0 , 60 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 100 , 50 , 95 , 60 , 0 , 0 , 0 , 0 };
            bool[] ColReadOnly ={ true , false , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true };
            bool[] ColBool ={ false , true , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , true };
            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";

            for ( int j = 0 ; j <= HeaderText.Length - 1 ; j++ )
            {
                if ( ColBool[j] == false )
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn( j );
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "";
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler( myDataGrid2_CheckCellEnabled );

                    dataGrid.TableStyles[0].GridColumnStyles.Add( colText );
                    DataColumn datacol;
                    if ( MappingName[j] == "���۽��" )
                        datacol = new DataColumn( MappingName[j] , Type.GetType( "System.Decimal" ) );
                    else
                        datacol = new DataColumn( MappingName[j] );

                    dtTmp.Columns.Add( datacol );
                }
                else
                {
                    DataGridEnableBoolColumn colText = new DataGridEnableBoolColumn( j );
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "0";
                    colText.AllowNull = false;
                    colText.NullValue = ( (short)( 0 ) );
                    colText.FalseValue = ( (short)( 0 ) );
                    colText.TrueValue = ( (short)( 1 ) );
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableBoolColumn.EnableCellEventHandler( myDataGrid2_CheckCellEnabled );

                    dataGrid.TableStyles[0].GridColumnStyles.Add( colText );
                    dtTmp.Columns.Add( MappingName[j] , Type.GetType( "System.Int16" ) );

                }
            }

            dataGrid.DataSource = dtTmp;
            dataGrid.TableStyles[0].MappingName = "tbmx";
            #endregion

            if ( !bpcgl )
            {

            }
        }

        #endregion

        #region ������ɫ�ı��¼�
        //����ɫ�ı��¼�
        private void myDataGrid2_CheckCellEnabled( object sender , DataGridEnableEventArgs e )
        {
            try
            {
                e.BackColor = Color.White;
                DataTable tb;
                if ( sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn" )
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                if ( e.Row > tb.Rows.Count - 1 )
                    return;

                if ( Convertor.IsNull( tb.Rows[e.Row]["fyid"] , Guid.Empty.ToString() ) == Guid.Empty.ToString() && tb.Rows[e.Row]["���"].ToString().Trim() != "С��" )
                    e.ForeColor = Color.Blue;
                if ( Convertor.IsNull( tb.Rows[e.Row]["fyid"] , Guid.Empty.ToString() ) != Guid.Empty.ToString() )
                    e.ForeColor = Color.Black;
                if ( tb.Rows[e.Row]["byscf"].ToString().Trim() == "1" )
                    e.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 248 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
                else
                    e.BackColor = Color.White;

            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message );
            }
        }

        #endregion

        #region ���˿ؼ��س��¼�
        private void patientInfo1_IDTextBoxKeyPress( object sender , System.Windows.Forms.KeyPressEventArgs e )
        {
            //			try
            //			{
            //
            //				DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
            //				tb2.Rows.Clear();
            //
            //				if (Convert.ToInt32(e.KeyChar)!=13)return;
            //				if (this.patientInfo1.PatientID<=0) return;
            //
            //				this.Cursor=PubStaticFun.WaitCursor();
            //				//��ѯ����
            //				int cxtype=Convert.ToInt32(patientInfo1.SearchIDType);
            //				//��ѯֵ
            //				string values=patientInfo1.PatientInvoiceID;
            //				//����ID
            //				long ghxh=patientInfo1.PatientRegisterID;
            //				
            //
            //				
            //				DataTable tb=MZYF.Select_TY_Cf(InstanceForm.BCurrentDept.DeptId,ghxh,1,cxtype,values);
            //				tb.TableName="tb";
            //				this.myDataGrid1.DataSource=tb;
            //				this.myDataGrid1.TableStyles[0].MappingName="tb";
            //
            //				if (tb.Rows.Count==0) return;
            //				
            //				_fyid=Convert.ToInt64(tb.Rows[0]["id"]);
            //
            //				//���Ҵ�����ϸ
            //				SelectCf_Cfmx(Convert.ToInt64(tb.Rows[0]["xh"]),Convert.ToInt64(tb.Rows[0]["��Ʊ��"]),0,Convert.ToDecimal(tb.Rows[0]["���"]));
            //
            //				//�����еĿ�ȺͿɶ���
            //				
            //				string _cflx=tb.Rows[0]["cflx"].ToString().Trim();
            //				ControlVisble(_cflx);

            //			}
            //			catch(System.Exception err)
            //			{
            //
            //				DataTable tb1=(DataTable)this.myDataGrid2.DataSource;
            //				tb1.Rows.Clear();
            //				MessageBox.Show("��������"+err.Message);
            //			}
            //			finally
            //			{
            //				this.Cursor=Cursors.Arrow;
            //			}

        }

        #endregion

        private void ControlVisble( string _cflx )
        {
            DataTable tb = (DataTable)myDataGrid2.DataSource;
            if ( tb.Rows.Count != 0 )
            {

                string hh = tb.Rows[0]["����"].ToString().Trim().Length >= 2 ? tb.Rows[0]["����"].ToString().Trim().Substring( 0 , 2 ) : "";
                if ( hh.Trim() == "ZY" )
                    _cflx = "03";
            }
            if ( _cflx == "03" )
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].Width = 0;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly = true;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].Width = 55;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly = true;
                if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_ys" )
                    this.buttjs.Visible = true;
                else
                    this.buttjs.Visible = true;
                myDataGrid2.Refresh();
            }
            else
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].Width = 55;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly = false;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].Width = 0;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly = true;
                this.buttjs.Visible = false;
            }
        }

        #region ����
        //��ѯ������ϸ
        private void SelectCf_Cfmx( string cflx , Guid cfxh , long fph , Guid fyid , decimal _zje )
        {
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;
            tbmx.Rows.Clear();
            DataTable tb1 = MZYF.Select_TY_Cfmx( cfxh , fph , fyid , InstanceForm.BDatabase );
            decimal sumlsje = 0;

            for ( int j = 0 ; j <= tb1.Rows.Count - 1 ; j++ )
            {
                DataRow myrow = tbmx.NewRow();
                myrow["���"] = Convert.ToString( j + 1 ).ToString();
                if ( _zje >= 0 )
                    myrow["ѡ"] = (short)( 0 );
                else
                    myrow["ѡ"] = (short)( 1 );

                myrow["Ƥ��"] = tb1.Rows[j]["Ƥ��"];
                myrow["��Ʊ��"] = fph.ToString();
                myrow["ҩƷ����"] = tb1.Rows[j]["ҩƷ����"];
                myrow["���"] = tb1.Rows[j]["���"];
                myrow["����"] = tb1.Rows[j]["����"];
                myrow["������"] = tb1.Rows[j]["������"];
                myrow["���ۼ�"] = tb1.Rows[j]["���ۼ�"];
                myrow["����"] = tb1.Rows[j]["����"];
                Guid _fymxid = Guid.Empty;
                _fymxid = new Guid( tb1.Rows[j]["id"].ToString() );

                if ( !bpcgl )//���������ι���ʱ ȥyf_fymx_ph���в�ѯ������Ϣ
                {
                    myrow["����"] = MZYF.SeekFymxPh( _fymxid , InstanceForm.BCurrentDept.DeptId , InstanceForm.BDatabase );
                    if ( myrow["����"].ToString().Trim() == "" )
                        myrow["����"] = "������";
                }
                else
                {
                    myrow["����"] = tb1.Rows[j]["����"];
                    myrow["Ч��"] = tb1.Rows[j]["Ч��"];
                    myrow["���κ�"] = tb1.Rows[j]["���κ�"];
                    myrow["kcid"] = tb1.Rows[j]["kcid"];
                    myrow["����"] = tb1.Rows[j]["����"];
                    myrow["�������"] = tb1.Rows[j]["�������"];
                }

                #region ���ô���
                //if (Convert.ToDecimal(tb1.Rows[j]["cfts"])>1)
                //{
                //    myrow["�˼���"]=tb1.Rows[j]["cfts"];
                //    //myrow["������"] = tb1.Rows[j]["����"];
                //}
                //else
                //{
                //    myrow["�˼���"]="1";
                //    //myrow["������"] = tb1.Rows[j]["����"];
                //}
                #endregion

                if ( Convert.ToDecimal( tb1.Rows[j]["���۽��"] ) >= 0 )
                {
                    if ( cflx == "03" )
                    {
                        myrow["�˼���"] = tb1.Rows[j]["cfts"];
                        myrow["������"] = tb1.Rows[j]["����"];
                    }
                    else
                    {
                        myrow["�˼���"] = "1";
                        myrow["������"] = tb1.Rows[j]["tysl"];
                    }
                }

                if ( cfg8025.Config == "1" && _menuTag.Function_Name != "Fun_ts_yf_mzty_ys" )
                {

                    if ( cflx == "03" )
                    {
                        myrow["�˼���"] = "";
                        myrow["������"] = "";
                    }
                    else
                    {
                        myrow["�˼���"] = "1";
                        myrow["������"] = "";
                    }

                }

                myrow["����"] = tb1.Rows[j]["cfts"];
                myrow["��λ"] = tb1.Rows[j]["��λ"];
                myrow["�������"] = tb1.Rows[j]["�������"];
                myrow["���۽��"] = tb1.Rows[j]["���۽��"];
                myrow["���۲��"] = tb1.Rows[j]["���۲��"];
                myrow["cfxh"] = tb1.Rows[j]["cfxh"];
                myrow["ypid"] = tb1.Rows[j]["ypid"];
                myrow["ydwbl"] = tb1.Rows[j]["ydwbl"];
                myrow["����"] = tb1.Rows[j]["����"];
                myrow["id"] = tb1.Rows[j]["id"];
                myrow["FYid"] = tb1.Rows[j]["FYid"];
                myrow["tyid"] = tb1.Rows[j]["tyid"];
                myrow["deptid"] = tb1.Rows[j]["deptid"];
                myrow["cfmxid"] = tb1.Rows[j]["cfmxid"];
                //myrow["������"]=tb1.Rows[j]["tysl"];
                myrow["�÷�"] = tb1.Rows[j]["�÷�"];
                myrow["����"] = tb1.Rows[j]["����"];
                myrow["byscf"] = tb1.Rows[j]["byscf"];
                tbmx.Rows.Add( myrow );
                sumlsje = sumlsje + Convert.ToDecimal( tb1.Rows[j]["���۽��"] );
            }

            DataRow sumrow = tbmx.NewRow();
            sumrow["���"] = "С��";
            sumrow["ѡ"] = (short)( 0 );
            sumrow["���۽��"] = sumlsje.ToString( "0.000" );
            tbmx.Rows.Add( sumrow );

            #region ���ô���
            //////			if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty_eyf")
            //////			{
            //////				bool bflag=false;
            //////				for(int x=0;x<=tb1.Rows.Count-1;x++)
            //////				{
            //////					if (Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[x]["����"],"0"))<0)
            //////					{
            //////						bflag=true;
            //////					}
            //////				}
            //////				if (bflag==true)
            //////				{
            //////					for(int x=0;x<=tbmx.Rows.Count-1;x++)
            //////					{
            //////						tbmx.Rows[x]["������"]="";
            //////					}
            //////				}
            //////			}
            #endregion

        }


        //��ӡ����
        private void PrintCf( DataRow row )
        {
            DataTable tb2 = (DataTable)this.myDataGrid2.DataSource;
            string cftsname = "";
            cftsname = Convert.ToString( row["��Ŀ"] ).Trim() == "�в�ҩ" ? "��ҩ����" : "";
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow;
            for ( int i = 0 ; i <= tb2.Rows.Count - 1 ; i++ )
            {
                if ( tb2.Rows[i]["���"].ToString().Trim() != "С��" )
                {
                    myrow = Dset.���˴����嵥.NewRow();
                    myrow["xh"] = Convert.ToInt32( tb2.Rows[i]["���"] );
                    myrow["ypmc"] = Convert.ToString( tb2.Rows[i]["ҩƷ����"] );
                    myrow["ypgg"] = Convert.ToString( tb2.Rows[i]["���"] );
                    myrow["sccj"] = Convert.ToString( tb2.Rows[i]["����"] );
                    myrow["lsj"] = Convert.ToDecimal( Convertor.IsNull( tb2.Rows[i]["���ۼ�"] , "0" ) );
                    myrow["ypsl"] = Convert.ToDecimal( Convertor.IsNull( tb2.Rows[i]["����"] , "0" ) );
                    myrow["ypdw"] = Convert.ToString( tb2.Rows[i]["��λ"] );
                    myrow["cfts"] = Convert.ToString( row["��Ŀ"] ).Trim() == "�в�ҩ" ? tb2.Rows[i]["����"] + "��" : "";
                    myrow["lsje"] = Convert.ToDecimal( Convertor.IsNull( tb2.Rows[i]["���۽��"] , "0" ) );
                    //					myrow["yf"]=Convert.ToString(tb2.Rows[i]["�÷�"])+"  "+ BaseFun.SeekPc(Convert.ToInt32(Convertor.IsNull(tb2.Rows[i]["PCDM"],"0")));
                    //					myrow["pc"]= BaseFun.SeekPc(Convert.ToInt32(Convertor.IsNull(tb2.Rows[i]["PCDM"],"0")));
                    //					myrow["syjl"]="";
                    //					myrow["zt"]=Convert.ToString(tb2.Rows[i]["����"]);
                    myrow["shh"] = Convert.ToString( tb2.Rows[i]["����"] );
                    myrow["ksname"] = Convert.ToString( row["����"] );//+"  �ѱ�:"+this.patientInfo1.FeeTypeName;
                    myrow["ysname"] = Convert.ToString( row["ҽ��"] );
                    myrow["Pyck"] = row["��ҩ����"].ToString();
                    myrow["fph"] = Convert.ToString( row["��Ʊ��"] );
                    myrow["hzxm"] = Convert.ToString( row["����"] );
                    myrow["sex"] = Convert.ToString( row["�Ա�"] );
                    myrow["age"] = Convert.ToString( row["����"] );
                    myrow["blh"] = Convert.ToString( row["������"] );
                    myrow["sfrq"] = Convert.ToString( row["�շ�����"] );
                    myrow["pyr"] = this.cmbpyr.Text.Trim();
                    ;
                    myrow["fyr"] = InstanceForm.BCurrentUser.Name;
                    Dset.���˴����嵥.Rows.Add( myrow );
                }

            }

            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;

            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "cfts";
            parameters[0].Value = cftsname;
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal( Convertor.IsNull( row["���"] , "0" ) );
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + "������ҩ�嵥";
            parameters[3].Text = "text1";
            parameters[3].Value = "��ҩ��λ:" + InstanceForm.BCurrentDept.DeptName + "     ���:" + this.lblzd.Text + "       ԭ�������:" + tb1.Rows[0]["���"].ToString();
            bool bview = this.chkprrintView.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView( Dset.���˴����嵥 , Constant.ApplicationDirectory + "\\Report\\YF_������ҩ�嵥.rpt" , parameters , bview );

            if ( f.LoadReportSuccess )
                f.Show();
            else
                f.Dispose();

        }


        //��֤��ҩ��Ϣ�ĺϷ���
        private bool DataTrueFalse()
        {
            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            bool values = true;

            for ( int i = 0 ; i <= myTb.Rows.Count - 1 ; i++ )
            {
                if ( new SystemCfg( 8020 ).Config == "0" && _menuTag.Function_Name != "Fun_ts_yf_mzty_ys" )
                {
                    if ( myTb.Rows[0]["deptid"].ToString() != InstanceForm.BCurrentDept.DeptId.ToString() )
                    {
                        MessageBox.Show( "�ô����Ǳ�ҩ������,�뵽 [" + Yp.SeekDeptName( Convert.ToInt32( myTb.Rows[0]["deptid"] ) , InstanceForm.BDatabase ) + "] ������ҩ " , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        values = false;
                        break;
                    }
                }
                if ( myTb.Rows[i]["id"].ToString().Trim() != "" && ( Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["������"] , "0" ) ) > 0 && Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["�˼���"] , "0" ) ) > 0 ) )
                {
                    decimal yyl = Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["����"] , "0" ) );//ԭ����
                    decimal yjs = Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["����"] , "0" ) );//ԭ����
                    decimal ytyl = 0;//��������
                    decimal ytjs = 0;//���˼���
                    decimal dqtyl = Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["������"] , "0" ) );//��ǰ������
                    decimal dqtjs = Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["�˼���"] , "0" ) );//��ǰ�˼���

                    string _cflx = tb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["cflx"].ToString().Trim();

                    //��������ҩ��
                    DataTable tb = MZYF.SelectYtyl( new Guid( myTb.Rows[i]["id"].ToString() ) , Convert.ToInt64( myTb.Rows[i]["��Ʊ��"] ) , InstanceForm.BDatabase );
                    if ( tb.Rows.Count > 0 )
                    {
                        ytyl = Convert.ToDecimal( Convertor.IsNull( tb.Rows[0]["tyl"] , "0" ) ) * ( -1 );
                        ytjs = Convert.ToDecimal( Convertor.IsNull( tb.Rows[0]["tjs"] , "0" ) );
                    }

                    //��ǰ��ҩ�����ڿ���ҩ��
                    if ( dqtyl > ( yyl - ytyl ) && _cflx != "03" )
                    {
                        MessageBox.Show( "��ǰ��ҩ�����ڿ���ҩ�������޸���ҩ��" );
                        myTb.Rows[i]["������"] = "0";
                        values = false;
                    }

                    if ( this.myDataGrid1.CurrentCell.RowNumber > ( tb1.Rows.Count - 1 ) )
                        values = false;
                    //��ǰ�˼���������ڿ��˼���

                    if ( _cflx == "03" )
                    {
                        if ( dqtjs > ( yjs - ytjs ) )
                        {
                            MessageBox.Show( "��ǰ�˼������ڿ��˼��������޸��˼���" );
                            myTb.Rows[i]["�˼���"] = "0";
                            values = false;
                        }
                    }

                    if ( !bpcgl )//���������ι���ʱ,Ҫ��yf_fymx_ph������֤�������Ƿ����
                    {
                        //ȷ��������Ƿ���ڸ���ҩ����
                        if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                        {
                            DataTable tbkc = MZYF.Selectkcph( Convert.ToInt32( Convertor.IsNull( myTb.Rows[i]["ypid"] , "0" ) ) , InstanceForm.BCurrentDept.DeptId , _menuTag.Function_Name.Trim() , InstanceForm.BDatabase );
                            bool byes = false;
                            for ( int j = 0 ; j <= tbkc.Rows.Count - 1 ; j++ )
                            {
                                if ( tbkc.Rows[j]["ypph"].ToString().Trim() == myTb.Rows[i]["����"].ToString().Trim() )
                                {
                                    byes = true;
                                }
                            }
                            if ( byes == false )
                            {
                                MessageBox.Show( myTb.Rows[i]["ҩƷ����"].ToString().Trim() + " �ڿ����û�� [" + myTb.Rows[i]["����"].ToString().Trim() + "] ����������" );
                                values = false;
                            }
                        }
                    }

                    //�����ҩƷ����Һ������������Һ������ҩ


                }
            }
            return values;
        }

        #endregion

        #region �¼�
        /// <summary>
        /// ȡ����ҩ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butqxfy_Click( object sender , System.EventArgs e )
        {

            //��ݵ��ٴ�ȷ��
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword( pwStr );
            if ( !bOk )
            {
                TrasenFrame.Forms.FrmMessageBox.Show( "��û��ͨ��Ȩ��ȷ�ϣ����ܽ��д˲�����" , new Font( "����" , 12f ) , Color.Red , "Sorry��" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }


            int err_code = -1;
            string err_text = "";
            Guid fymxid = Guid.Empty;
            string sDate = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToString();
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;

            string _pronamefy = "";
            string _pronamefymx = "";

            _pronamefy = "sp_yf_fy";
            _pronamefymx = "sp_yf_fymx";

            //���Ϊ��ҩ����ҩ
            if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
            {
                _pronamefy = "sp_yk_fy";
                _pronamefymx = "sp_yk_fymx";
            }

            #region ȡ����ҩ���
            decimal sumtyje = 0;
            for ( int i = 0 ; i <= tbmx.Rows.Count - 1 ; i++ )
            {
                if ( tbmx.Rows[i]["���"].ToString().Trim() != "С��" && Convert.ToBoolean( tbmx.Rows[i]["ѡ"] ) == true && Convert.ToDecimal( tbmx.Rows[i]["����"] ) < 0 )
                {
                    sumtyje = sumtyje + Convert.ToDecimal( tbmx.Rows[i]["���۽��"] );
                }
            }
            if ( sumtyje >= 0 )
            {
                MessageBox.Show( "ȡ����ҩ���Ϊ�㣬��ȷ��" );
                this.butqxfy.Enabled = true;
                return;
            }
            if ( MessageBox.Show( "��ǰȡ����ҩ���Ϊ " + Convert.ToString( Math.Abs( sumtyje ) ) + " ��ȷ��Ҫȡ���� ��" , "ѯ�ʴ�" , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                return;

            #endregion

            this.butqxfy.Enabled = false;
            this.Cursor = PubStaticFun.WaitCursor();

            try
            {
                //��������
                InstanceForm.BDatabase.BeginTransaction();

                for ( int i = 0 ; i <= tbmx.Rows.Count - 1 ; i++ )
                {

                    if ( tbmx.Rows[i]["���"].ToString().Trim() != "С��" && Convert.ToBoolean( tbmx.Rows[i]["ѡ"] ) == true && Convert.ToDecimal( tbmx.Rows[i]["����"] ) < 0 )
                    {
                        Guid fyid = new Guid( Convertor.IsNull( tbmx.Rows[i]["fyid"] , Guid.Empty.ToString() ) );

                        //�жϴ˴����Ƿ����˷Ѻ��ϴ�
                        if ( fyid != Guid.Empty && _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_ys" )
                        {
                            throw new Exception( "ҩ����ȷ����ҩ��������ȡ��" );
                        }

                        if ( fyid != Guid.Empty )
                            MZYF.SelectYpzt( fyid , InstanceForm.BDatabase );

                        //ȡ������Һ��ҩ��¼
                        ////////MZYF.Delete_mzdsyckb(Convert.ToInt64(Convertor.IsNull(tbmx.Rows[i]["id"],"0")),InstanceForm.BCurrentUser.EmployeeId,sDate);

                        MZYF.DeleteTymx( new Guid( Convertor.IsNull( tbmx.Rows[i]["id"] , Guid.Empty.ToString() ) ) , 1 , out err_code , out err_text , InstanceForm.BDatabase );
                        if ( err_code != 0 )
                            throw new Exception( err_text );


                        if ( fyid != Guid.Empty )
                        {
                            MZYF.DeleteTy( fyid , Convert.ToDecimal( tbmx.Rows[i]["���۽��"] ) , out err_code , out err_text , InstanceForm.BDatabase );
                            if ( err_code != 0 )
                                throw new Exception( err_text );

                            #region ���¿��
                            MZYF.SaveFymx( fyid ,//��fyidΪ����ȡ��ʱ���ø��¿�棬ֻ�д�����ű�ʾ���˹�ҩ���ȡ��
                                Convert.ToInt64( Convertor.IsNull( tbmx.Rows[i]["��Ʊ��"] , "0" ) ) ,
                                new Guid( Convertor.IsNull( tbmx.Rows[i]["cfxh"] , Guid.Empty.ToString() ) ) ,
                                Convert.ToInt32( Convertor.IsNull( tbmx.Rows[i]["ypid"] , "0" ) ) ,
                                tbmx.Rows[i]["����"].ToString() ,
                                tbmx.Rows[i]["ҩƷ����"].ToString() ,
                                tbmx.Rows[i]["ҩƷ����"].ToString() ,
                                tbmx.Rows[i]["���"].ToString() ,
                                tbmx.Rows[i]["����"].ToString() ,
                                tbmx.Rows[i]["��λ"].ToString() ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["ydwbl"] , "0" ) ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["����"] , "0" ) ) * ( -1 ) ,
                                Convert.ToInt32( Convertor.IsNull( tbmx.Rows[i]["����"] , "0" ) ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["������"] , "0" ) ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["�������"] , "0" ) ) * ( -1 ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["���ۼ�"] , "0" ) ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["���۽��"] , "0" ) ) * ( -1 ) ,
                                0 ,
                                0 ,
                                InstanceForm.BCurrentDept.DeptId ,
                                new Guid( tbmx.Rows[i]["tyid"].ToString() ) ,
                                tbmx.Rows[i]["����"].ToString() ,
                                new Guid( tbmx.Rows[i]["id"].ToString() ) ,//�ò���������ʱ����̨��������ϸ
                                new Guid( Convertor.IsNull( tbmx.Rows[i]["cfmxid"] , Guid.Empty.ToString() ) ) ,
                                "" ,
                                "" ,
                                "" ,
                                "" ,
                                "" ,
                                "" ,
                                "" ,
                                0 ,
                                0 ,
                                0 ,
                                _pronamefymx ,
                                out fymxid ,
                                out err_code ,
                                out err_text

                                , 0 , 0 , "" , "" , Guid.Empty ,

                                InstanceForm.BDatabase ,
                                false );
                            if ( err_code != 0 )
                            {
                                throw new System.Exception( err_text );
                            }

                            #endregion
                        }
                    }

                }
                InstanceForm.BDatabase.CommitTransaction();


                //������ʾ�÷�Ʊ
                //				_zje=0;
                _fyid = Guid.Empty;
                //this.patientInfo1_IDTextBoxKeyPress(sender,new KeyPressEventArgs((char)13));
                this.txtfph.Focus();
                this.txtfph_KeyPress( txtfph , new KeyPressEventArgs( (char)13 ) );
                this.myDataGrid2.CurrentCell = new DataGridCell( 0 , 4 );

                MessageBox.Show( "ȡ����ҩ�ɹ�" );
                butqxfy.Enabled = true;

            }
            catch ( System.Exception err )
            {
                butqxfy.Enabled = true;
                InstanceForm.BDatabase.RollbackTransaction();

                MessageBox.Show( err.Message );
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// ��ҩ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butfy_Click( object sender , System.EventArgs e )
        {
            //�����ҩ������Ա
            if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" )
            {
                YpConfig s = new YpConfig( InstanceForm.BCurrentDept.DeptId , InstanceForm.BDatabase );
                if ( s.ϵͳ���� == false )
                {
                    MessageBox.Show( "ϵͳδ����" );
                    return;
                }
                if ( s.����ϵͳ == true )
                {
                    MessageBox.Show( "ϵͳ������Ա����" );
                    return;
                }
                if ( cmbpyr.Text.Trim() == "" )
                {
                    MessageBox.Show( "��ѡ����ҩ��" );
                    return;
                }
            }


            string _pronamefy = "";
            string _pronamefymx = "";

            _pronamefy = "sp_yf_fy";
            _pronamefymx = "sp_yf_fymx";

            //���Ϊ��ҩ����ҩ
            if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
            {
                _pronamefy = "sp_yk_fy";
                _pronamefymx = "sp_yk_fymx";
            }


            string sDate = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToString();
            Guid fyid = Guid.Empty;
            Guid fymxid = Guid.Empty;
            int err_code = -1;
            string err_text = "";

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;
            if ( tb.Rows.Count == 0 )
            {
                MessageBox.Show( "������Ҫ��ҩ�ķ�Ʊ�Ų����س���" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            if ( tbmx.Rows.Count == 0 )
            {
                MessageBox.Show( "û�п��˵�ҩƷ" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            Frmtyyy tyyy = new Frmtyyy();
            DialogResult dr = tyyy.ShowDialog();
            if ( string.IsNullOrEmpty( tyyy.ResultValue.Value ) )
            {
                return;
            }


            //��ݵ��ٴ�ȷ��
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword( pwStr );
            if ( !bOk )
            {
                TrasenFrame.Forms.FrmMessageBox.Show( "��û��ͨ��Ȩ��ȷ�ϣ����ܽ��д˲�����" , new Font( "����" , 12f ) , Color.Red , "Sorry��" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }


            //��ҩ��Ϣ�Ϸ�����֤
            if ( DataTrueFalse() == false )
                return;


            //��ҩ����
            int ypjs = Convert.ToInt32( Convertor.IsNull( tbmx.Rows[0]["�˼���"] , "0" ) );

            #region ������ҩ��� tyzje
            decimal tyzje = 0;
            decimal tjzje = 0;
            decimal tyhje = 0;
            decimal tzfje = 0;
            decimal tyzjhje = 0;
            for ( int i = 0 ; i <= tbmx.Rows.Count - 1 ; i++ )
            {
                if ( tbmx.Rows[i]["id"].ToString().Trim() != "" )
                {
                    //׼����ҩ���
                    if ( Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["���۽��"] , "0" ) ) > 0 )
                    {
                        decimal _tyl = 0;
                        _tyl = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["������"] , "0" ) );
                        tyzje = tyzje + Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["���ۼ�"] , "0" ) ) * _tyl * ypjs * ( -1 );

                        tyzjhje = tyzjhje + Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["����"] , "0" ) ) * _tyl * ypjs * ( -1 );
                    }
                    //��ȷ���������ҩ���
                    if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                    {
                        if ( Convertor.IsNull( tbmx.Rows[i]["fyid"] , Guid.Empty.ToString() ) == Guid.Empty.ToString() )
                        {
                            tyzje = tyzje + Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["���۽��"] , "0" ) );
                            tyzjhje = tyzjhje + Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["�������"] , "0" ) );
                        }
                    }
                }

            }
            if ( tyzje >= 0 )
            {
                //MessageBox.Show( "��ҩ���Ϊ�㣬��ȷ��" );
                //this.butfy.Enabled = true;
                //return;
                if ( MessageBox.Show( "��ҩ���Ϊ�㣬�Ƿ��������?" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                {
                    this.butfy.Enabled = true;
                    return;
                }

            }
            if ( MessageBox.Show( "��ǰ��ҩ���Ϊ " + Convert.ToString( Math.Abs( tyzje ) ) + " ��ȷ��Ҫ��ҩ�� ��" , "ѯ�ʴ�" , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                return;
            #endregion


            try
            {

                InstanceForm.BDatabase.BeginTransaction();


                #region �ж�ͷ����(cfrow)��λ��
                Guid cfxh = Guid.Empty;
                if ( tbmx.Rows.Count > 0 )
                    cfxh = new Guid( tbmx.Rows[0]["cfxh"].ToString() );
                int cfrow = -1;
                for ( int i = 0 ; i <= tb.Rows.Count - 1 ; i++ )
                {
                    if ( new Guid( Convertor.IsNull( tb.Rows[i]["xh"] , Guid.Empty.ToString() ) ) == cfxh )
                        cfrow = i;
                }
                #endregion

                #region �����ҽ�����������ȫ��  ��ʱ�ر�
                //				decimal cfje=0;
                //				if (Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["���"],"0"))!=Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["�Ը����"],"0")))
                //				{
                //					for(int i=0;i<=tbmx.Rows.Count-1;i++)
                //					{
                //						if (Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[i]["id"],"0"))>0)
                //							cfje=cfje+Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[i]["���۽��"],"0"));
                //					}
                //
                ////					decimal Cfje=Math.Abs(cfje);
                ////					decimal Tyzje=Math.Abs(tyzje);
                ////					if (Math.Round(Math.Abs(cfje),1)!=Math.Round(Math.Abs(tyzje),1))
                ////					{
                ////						throw new Exception("�ô������ʲ��֣�ҽ�����������Ż�,����ȫ����ҩ");
                ////					}
                //					
                //					tjzje=Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["���ʽ��"],"0"))*(-1);
                //					tyhje=Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["�Żݽ��"],"0"))*(-1);
                //					tzfje=Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["�Ը����"],"0"))*(-1);
                //				}
                //				else
                //				{
                //					tjzje=0;
                //					tyhje=0;
                //					tzfje=tyzje;
                //				}

                #endregion

                #region �����ҩ����ҩ�����ͷ��
                if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                {
                    //������ҩͷ��¼
                    MZYF.SaveFy( tb.Rows[cfrow]["cflx"].ToString() ,
                        Convert.ToDecimal( Convertor.IsNull( tb.Rows[cfrow]["jssjh"] , "0" ) ) ,
                        Convert.ToInt64( Convertor.IsNull( tb.Rows[cfrow]["��Ʊ��"] , "0" ) ) ,
                        tyzje ,
                        tjzje ,
                        tyhje ,
                        tzfje ,
                        ypjs ,
                        new Guid( tb.Rows[cfrow]["xh"].ToString() ) ,
                        new Guid( Convertor.IsNull( tb.Rows[cfrow]["patid"] , Guid.Empty.ToString() ) ) ,
                        tb.Rows[cfrow]["������"].ToString().Trim() ,
                        tb.Rows[cfrow]["����"].ToString() ,
                        Convert.ToInt32( Convertor.IsNull( tb.Rows[cfrow]["ysdm"] , "0" ) ) ,
                        Convert.ToInt32( Convertor.IsNull( tb.Rows[cfrow]["ksdm"] , "0" ) ) ,
                        tb.Rows[cfrow]["�շ�����"].ToString() ,
                        Convert.ToInt32( Convertor.IsNull( tb.Rows[cfrow]["sky"] , "0" ) ) ,
                        sDate ,
                        InstanceForm.BCurrentUser.EmployeeId ,
                        Convert.ToInt32( cmbpyr.SelectedValue ) ,
                        Convertor.IsNull( tb.Rows[cfrow]["pyckh"] , "0" ) ,
                        _Fyckh ,
                        InstanceForm.BCurrentDept.DeptId , 1 , _menuTag.FunctionTag , 0 , _pronamefy , out fyid , out err_code , out err_text , InstanceForm._menuTag.Jgbm , InstanceForm.BDatabase , tyyy.ResultValue.Value );

                    if ( err_code != 0 || fyid == Guid.Empty )
                    {
                        throw new System.Exception( err_text );
                    }
                }
                #endregion

                for ( int j = 0 ; j <= tbmx.Rows.Count - 1 ; j++ )
                {
                    #region ȡ�ñ���ֵ id,tyl��tjs��pfj��lsj
                    Guid id = Guid.Empty;
                    int tjs = 0;
                    decimal tyl = 0;
                    decimal pfj = 0;
                    decimal lsj = 0;
                    decimal jhj = 0;

                    //������Ѿ��������ҩ
                    if ( new Guid( Convertor.IsNull( tbmx.Rows[j]["fyid"].ToString() , Guid.Empty.ToString() ) ) == Guid.Empty )
                    {
                        id = new Guid( Convertor.IsNull( tbmx.Rows[j]["id"].ToString() , Guid.Empty.ToString() ) );
                        tyl = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["����"] , "0" ) );
                        tjs = Convert.ToInt32( Convertor.IsNull( tbmx.Rows[j]["����"] , "0" ) );
                        pfj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["������"] , "0" ) );
                        lsj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["���ۼ�"] , "0" ) );
                        jhj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["����"] , "0" ) );
                    }
                    //����������������ҩ
                    else
                    {

                        id = Guid.Empty;
                        if ( Convert.ToInt32( Convertor.IsNull( tbmx.Rows[j]["����"] , "0" ) ) == 1 )
                        {
                            tyl = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["������"] , "0" ) ) * ( -1 );
                            tjs = 1;
                        }
                        else
                        {
                            tyl = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["����"] , "0" ) ) * ( -1 );
                            tjs = Convert.ToInt32( Convertor.IsNull( tbmx.Rows[j]["�˼���"] , "0" ) );
                        }

                        pfj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["������"] , "0" ) );
                        lsj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["���ۼ�"] , "0" ) );
                        jhj = Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[j]["����"], "0"));//Add By Tany 2018-01-25
                    }
                    #endregion

                    #region ������ϸ�����¿��
                    if ( new Guid( Convertor.IsNull( tbmx.Rows[j]["id"].ToString() , Guid.Empty.ToString() ) ) != Guid.Empty)// && tyl * tjs != 0 )
                    {
                        long fyksid = 0;
                        if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                            fyksid = InstanceForm.BCurrentDept.DeptId;
                        else
                            fyksid = Convert.ToInt64( Convertor.IsNull( tbmx.Rows[j]["deptid"] , "0" ) );
                        //������ҩ��ϸ
                        MZYF.SaveFymx( fyid ,
                            Convert.ToInt64( Convertor.IsNull( tbmx.Rows[j]["��Ʊ��"] , "0" ) ) ,
                            new Guid( Convertor.IsNull( tbmx.Rows[j]["cfxh"] , Guid.Empty.ToString() ) ) ,
                            Convert.ToInt32( Convertor.IsNull( tbmx.Rows[j]["ypid"] , "0" ) ) ,
                            tbmx.Rows[j]["����"].ToString() ,
                            tbmx.Rows[j]["ҩƷ����"].ToString() ,
                            tbmx.Rows[j]["ҩƷ����"].ToString() ,
                            tbmx.Rows[j]["���"].ToString() ,
                            tbmx.Rows[j]["����"].ToString() ,
                            tbmx.Rows[j]["��λ"].ToString() ,
                            Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["ydwbl"] , "0" ) ) ,
                            tyl ,
                            tjs ,
                            pfj ,
                            Math.Round( Convert.ToDecimal( pfj * tyl * tjs ) , 3 ) ,
                            lsj ,
                            Math.Round( lsj * tyl * tjs , 3 ) ,
                            0 ,
                            0 ,
                            fyksid ,
                            new Guid( tbmx.Rows[j]["id"].ToString() ) ,
                            tbmx.Rows[j]["����"].ToString() ,
                            id ,
                            new Guid( Convertor.IsNull( tbmx.Rows[j]["cfmxid"] , Guid.Empty.ToString() ) ) ,
                            tbmx.Rows[j]["Ƥ��"].ToString() ,
                            tbmx.Rows[j]["�÷�"].ToString() ,
                            tbmx.Rows[j]["����"].ToString() ,
                               "" ,
                                "" ,
                                "" ,
                                "" ,
                                0 ,
                                0 ,
                                0 ,
                            _pronamefymx ,
                            out fymxid ,
                            out err_code ,
                            out err_text
                            , Convert.ToDecimal( tbmx.Rows[j]["����"] )
                            //, Math.Round( Convert.ToDecimal( pfj * tyl * tjs ) , 3 )
                            , Math.Round(Convert.ToDecimal(jhj * tyl * tjs), 3)//Modify By Tany 2018-01-25
                            , tbmx.Rows[j]["Ч��"].ToString()//?
                            , tbmx.Rows[j]["���κ�"].ToString()
                            , new Guid( tbmx.Rows[j]["kcid"].ToString() ) ,
                            InstanceForm.BDatabase , bpcgl );

                        if ( err_code != 0 )
                        {
                            throw new System.Exception( err_text );
                        }


                        //����FYID
                        if ( fyid != Guid.Empty && new Guid( Convertor.IsNull( tbmx.Rows[j]["fyid"] , Guid.Empty.ToString() ) ) == Guid.Empty )
                        {
                            MZYF.UpdateFymx_Fyid( id , fyid , out err_code , out err_text , InstanceForm.BDatabase );
                            if ( err_code != 0 )
                            {
                                throw new System.Exception( err_text );
                            }
                        }

                        //��Ԥ����ҩ�ļ�¼ �������Һ����� 
                        ////////						if (Convert.ToDecimal(tbmx.Rows[j]["����"])>0 && fymxid>0)
                        ////////						{
                        ////////							string ssql="insert into yf_mzdsyckb(fph,hzxm,cfxh,cfmxid,hjcfmxid,ggid,cjid,ypmc,ypgg,ypsl,cfts,ypdw,dwbl,lsj,lsje,execdeptid,ksdm,ysdm,djrq,djy,sqdjh,qytybz,bdel,fyid,fymxid)"+
                        ////////								"select top 1 fph,hzxm,cfxh,cfmxid,hjcfmxid,ggid,cjid,ypmc,ypgg,"+tyl+","+tjs+",ypdw,dwbl,lsj,"+lsj*tyl*tjs+",execdeptid,ksdm,ysdm,'"+sDate+"',"+InstanceForm.BCurrentUser.EmployeeId+",0,0,0,"+fyid+","+fymxid+" from yf_mzdsyckb"+
                        ////////								" where cfmxid="+Convert.ToInt64(Convertor.IsNull(tbmx.Rows[j]["cfmxid"],"0"))+" and ypsl>0 and bdel=0 order by id ";
                        ////////							int ncount=InstanceForm.BDatabase.DoCommand(ssql);
                        ////////
                        ////////						}
                        fymxid = Guid.Empty;

                    }
                    #endregion

                }

                string ssql = string.Format( " update yf_fy set jhje={0},TYYY = '{2}' where id='{1}'" , tyzjhje , fyid , tyyy.ResultValue.Value );
                if ( InstanceForm.BDatabase.DoCommand( ssql ) <= 0 )
                {
                    throw new Exception( "���·�ҩͷ��������ʧ�ܣ�" );
                }


                //////////				if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty_eyf")
                //////////					MZYF_DSYTL.Update_Mzdsyckb_QYTYBZ(Convert.ToInt64(Convertor.IsNull(tb.Rows[cfrow]["��Ʊ��"],"0")),_fyid,cmd);
                //////////				cmd.Parameters.Clear();


                InstanceForm.BDatabase.CommitTransaction();


                //ͬ����his��ҩ״̬
                try
                {
                    ClsMzTy.DoMzTY(cfxh.ToString());
                }
                catch (System.Exception err)
                {
                    this.butfy.Enabled = true;
                    MessageBox.Show("��������" + err.Message);
                }


                //				#region ���ҳ��
                //				DataTable tb2=(DataTable)this.myDataGrid1.DataSource;
                //				DataTable tb3=(DataTable)this.myDataGrid2.DataSource;
                //				tb2.Rows.Clear();
                //				tb3.Rows.Clear();

                this.butfy.Enabled = true;
                //				#endregion 

                //������ʾ�÷�Ʊ
                //				_zje=0;
                //				_fyid=0;
                //				this.patientInfo1_IDTextBoxKeyPress(sender,new KeyPressEventArgs((char)13));


                //this.patientInfo1_IDTextBoxKeyPress(sender,new KeyPressEventArgs((char)13));
                this.txtfph.Focus();
                this.txtfph_KeyPress( txtfph , new System.Windows.Forms.KeyPressEventArgs( (char)13 ) );
                DataTable tbt = (DataTable)this.myDataGrid1.DataSource;
                if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell( tbt.Rows.Count - 1 , 1 );
                    this.myDataGrid2.CurrentCell = new DataGridCell( 0 , 4 );
                }



            }
            catch ( System.Exception err )
            {
                this.butfy.Enabled = true;
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show( "��������" + err.Message );
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butquit_Click( object sender , System.EventArgs e )
        {
            this.Close();
        }

        private void cmbph_KeyPress( object sender , System.Windows.Forms.KeyPressEventArgs e )
        {
            if ( Convert.ToInt32( e.KeyChar ) == 13 )
            {
                int nrow = this.myDataGrid2.CurrentCell.RowNumber;
                int ncol = this.myDataGrid2.CurrentCell.ColumnNumber;
                string columnName = this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].HeaderText.Trim();
                if ( columnName.Trim() == "����" )
                {
                    DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                    tb.Rows[nrow][ncol] = cmbph.Text;
                    this.myDataGrid2.CurrentCell = new DataGridCell( nrow , ncol + 1 );
                    return;
                }
                this.cmbph.Visible = false;
            }
        }

        private void cmbph_VisibleChanged( object sender , System.EventArgs e )
        {
            cmbph.Focus();
        }

        private void butprint_Click( object sender , System.EventArgs e )
        {
            try
            {



                DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
                if ( tb2.Rows.Count == 0 )
                {
                    MessageBox.Show( "û�п��Դ�ӡ�Ĵ���" );
                    return;
                }
                DataTable tb3 = (DataTable)this.myDataGrid2.DataSource;
                if ( tb3.Rows.Count <= 1 )
                {
                    MessageBox.Show( "û�п��Դ�ӡ�Ĵ�����ϸ" );
                    return;
                }
                if ( this.myDataGrid2.CurrentCell.RowNumber > tb2.Rows.Count - 1 )
                    return;

                if ( Convert.ToDecimal( tb2.Rows[this.myDataGrid1.CurrentCell.RowNumber]["���"] ) > 0 )
                {
                    MessageBox.Show( "��ѡ����ҩ��¼���ٴ�ӡ" );
                    return;
                }

                if ( chkxp.Checked == true )
                {
                    this.PrintCfXP();
                    return;
                }

                PrintCf( tb2.Rows[this.myDataGrid1.CurrentCell.RowNumber] );

            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message );
            }
        }

        private void PrintCfXP()
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows = tb.Select( "����<>''" );
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;


            if ( rows.Length == 0 )
                return;
            string cftsname = "";
            //cftsname=Convert.ToString(tb1.Rows[nrow]["��Ŀ"]).Trim()=="�в�ҩ"?"��ҩ����":"";
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow;
            for ( int i = 0 ; i <= rows.Length - 1 ; i++ )
            {
                //string[] HeaderText	={"���","ѡ","��Ʊ��","ҩƷ����","���","����","������","���ۼ�","����","����","����","������","�˼���","��λ","�������","���۽��","cfxh","ypid","ydwbl","����","���۲��","cfts","id","fyid","tyid","deptid","cfmxid"};
                myrow = Dset.���˴����嵥.NewRow();
                //myrow["xh"]=Convert.ToInt32(rows[i]["���"]);
                myrow["ypmc"] = Convert.ToString( rows[i]["ҩƷ����"] );
                myrow["ypgg"] = Convert.ToString( rows[i]["���"] );
                myrow["sccj"] = Convert.ToString( rows[i]["����"] );
                myrow["lsj"] = Convert.ToDecimal( Convertor.IsNull( rows[i]["���ۼ�"] , "0" ) );
                myrow["zje"] = Convert.ToDecimal( Convertor.IsNull( tb1.Rows[nrow]["���"] , "0" ) );
                myrow["ypsl"] = Convertor.IsNull( rows[i]["����"] , "0" );
                myrow["ypdw"] = Convert.ToString( rows[i]["��λ"] );
                myrow["cfts"] = Convert.ToString( tb1.Rows[nrow]["��Ŀ"] ).Trim() == "�в�ҩ" ? rows[i]["����"] + "��" : "";
                myrow["lsje"] = Convert.ToDecimal( Convertor.IsNull( rows[i]["���۽��"] , "0" ) );
                //				string UserEat="";
                //				UserEat=rows[i]["Ƶ��"].ToString().Trim()==""?"":Convert.ToDouble(rows[i]["����"]).ToString()+rows[i]["������λ"].ToString().Trim()+"/ÿ��";
                //				myrow["yf"]=Convert.ToString(rows[i]["�÷�"])+"  "+rows[i]["ʹ��Ƶ��"].ToString().Trim()+" "+UserEat;
                //				myrow["pc"]= rows[i]["ʹ��Ƶ��"].ToString().Trim();
                //				myrow["syjl"]="";
                //				myrow["zt"]=Convert.ToString(rows[i]["����"]);
                //				myrow["shh"]=Convert.ToString(rows[i]["����"]);
                //				myrow["ksname"]=Convert.ToString(rows[i]["����"]);//+"  �ѱ�:"+this.patientInfo1.FeeTypeName;
                //				string ysqm="";
                //				//if (Convert.ToString(row["ҽ��ǩ��"]).Trim()!="")  ysqm="   ҽ��ǩ��:"+Convert.ToString(rows[i]["ҽ��ǩ��"]);
                //				myrow["ysname"]=Convert.ToString(rows[i]["ҽ��"])+ysqm;
                //				myrow["Pyck"]=rows[i]["Ƥ��"].ToString();
                myrow["fph"] = Convert.ToString( tb1.Rows[nrow]["��Ʊ��"] );
                myrow["hzxm"] = Convert.ToString( tb1.Rows[nrow]["����"] );
                //				myrow["sex"]=Convert.ToString(rows[i]["�Ա�"]);
                //				myrow["age"]=Convert.ToString(rows[i]["����"]);
                //				myrow["blh"]=Convert.ToString(rows[i]["�����"]);
                myrow["sfrq"] = Convert.ToString( tb1.Rows[nrow]["�շ�����"] );
                //				myrow["pyr"]=this.cmbpyr.Text.Trim();;
                //				myrow["fyr"]=InstanceForm.BCurrentUser.Name;
                Dset.���˴����嵥.Rows.Add( myrow );
            }

            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Text = "TITLETEXT";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "��ҩ��ϸ��";
            bool bview = this.chkprrintView.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView( Dset.���˴����嵥 , Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥�б�_СƱ.rpt" , parameters , bview );
            if ( f.LoadReportSuccess )
                f.Show();
            else
                f.Dispose();

        }

        private void myDataGrid2_CurrentCellChanged( object sender , System.EventArgs e )
        {
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            int ncol = this.myDataGrid2.CurrentCell.ColumnNumber;
            if ( nrow >= myTb.Rows.Count )
                return;
            if ( myTb.Rows[nrow]["���"].ToString().Trim() == "С��" )
                return;

            if ( !bpcgl ) //���������ι���
            {
                #region ��ѯ��ǰҩƷ���õ�����
                string ss = "   ";
                DataTable tab = MZYF.Selectkcph( Convert.ToInt32( Convertor.IsNull( myTb.Rows[nrow]["ypid"] , "0" ) ) , InstanceForm.BCurrentDept.DeptId , _menuTag.Function_Name.Trim() , InstanceForm.BDatabase );
                cmbph.DataSource = tab;
                cmbph.DisplayMember = "YPPH";

                string columnName = this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].HeaderText.Trim();
                this.cmbph.Visible = false;
                if ( columnName.Trim() == "����" )
                {
                    if ( nrow > myTb.Rows.Count - 1 )
                        return;
                    this.cmbph.Left = this.myDataGrid2.GetCellBounds( nrow , ncol ).Left + this.myDataGrid2.Left;
                    this.cmbph.Top = this.myDataGrid2.GetCellBounds( nrow , ncol ).Top + this.myDataGrid2.Top;
                    this.cmbph.Width = this.myDataGrid2.GetCellBounds( nrow , ncol ).Width;

                    string ypph = myTb.Rows[nrow]["����"].ToString().Trim();
                    if ( ypph != "" )
                        cmbph.Text = ypph.Trim();

                    this.cmbph.Visible = true;
                    return;
                }
                #endregion
            }

            //�����ҽ��
            if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_ys" )
            {
                if ( new Guid( Convertor.IsNull( myTb.Rows[nrow]["fyid"].ToString() , Guid.Empty.ToString() ) ) == Guid.Empty )
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["ѡ"].ReadOnly = false;
                else
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["ѡ"].ReadOnly = true;
            }
            else
            {
                if ( Convertor.IsNull( myTb.Rows[nrow]["fyid"] , Guid.Empty.ToString() ) != Guid.Empty.ToString() && Convert.ToDecimal( myTb.Rows[nrow]["����"] ) < 0 )
                {
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["ѡ"].ReadOnly = true;
                }
                else
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["ѡ"].ReadOnly = true;
            }


            ////			if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty_ys")
            ////			{
            ////				if (Convert.ToDecimal(Convertor.IsNull(myTb.Rows[nrow]["����"],"0"))>=0)
            ////				{
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly=false;
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly=false;
            ////				}
            ////				else
            ////				{
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly=true;
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly=true;
            ////				}
            ////			}
            ////			else
            ////			{
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly=true;
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly=true;
            ////			}

            if ( cfg8001.Config == "1" )
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly = false;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly = false;
            }
            else
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly = true;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly = true;
            }
            if ( Convert.ToDecimal( Convertor.IsNull( myTb.Rows[nrow]["����"] , "0" ) ) <= 0 )
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly = true;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly = true;
            }

            if ( cfg8025.Config == "1" && _menuTag.Function_Name != "Fun_ts_yf_mzty_ys" )
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["������"].ReadOnly = true;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly = true;
            }
            this.myDataGrid2.TableStyles[0].GridColumnStyles["�˼���"].ReadOnly = true;
        }

        private void myDataGrid1_CurrentCellChanged( object sender , System.EventArgs e )
        {
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;

            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if ( nrow >= tb.Rows.Count )
                return;

            //this.patientInfo1.LoadPatient(tb.Rows[nrow]["��Ʊ��"].ToString().Trim());
            Guid _xh = new Guid( Convertor.IsNull( tb.Rows[nrow]["xh"].ToString() , Guid.Empty.ToString() ) );
            Guid _fyid = new Guid( tb.Rows[nrow]["id"].ToString() );
            long _fph = Convert.ToInt64( tb.Rows[nrow]["��Ʊ��"] );
            //���Ҵ�����ϸ

            string _cflx = tb.Rows[nrow]["cflx"].ToString().Trim();
            SelectCf_Cfmx( _cflx , _xh , _fph , _fyid , Convert.ToDecimal( tb.Rows[nrow]["���"] ) );

            //�����еĿ�ȺͿɶ���

            ControlVisble( _cflx );

        }

        private void colText_CheckCellEnabled( object sender , DataGridEnableEventArgs e )
        {
            try
            {
                e.BackColor = Color.White;
                DataTable tb;
                if ( sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn" )
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                if ( e.Row > tb.Rows.Count - 1 )
                    return;

                if ( Convert.ToDecimal( Convertor.IsNull( tb.Rows[e.Row]["���"] , "0" ) ) < 0 )
                    e.ForeColor = Color.Red;
                else
                    e.ForeColor = Color.Black;
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message );
                return;
            }
        }

        private void cmbph_SelectedIndexChanged( object sender , System.EventArgs e )
        {

        }


        #endregion

        private void buttjs_Click( object sender , System.EventArgs e )
        {

            int torow = 0;
            TrasenFrame.Forms.DlgInputBox f = new TrasenFrame.Forms.DlgInputBox( "0" , "������Ҫ����ҩ�ļ��� " , "�˼���" );
            f.NumCtrl = true;
            f.ShowDialog();
            if ( TrasenFrame.Forms.DlgInputBox.DlgResult == true )
                torow = Convert.ToInt32( TrasenFrame.Forms.DlgInputBox.DlgValue );
            else
                return;

            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            if ( Convertor.IsNumeric( torow.ToString() ) == false )
            {
                MessageBox.Show( "����������" );
                return;
            }

            for ( int i = 0 ; i <= tb.Rows.Count - 1 ; i++ )
            {
                if ( Convert.ToDecimal( Convertor.IsNull( tb.Rows[i]["����"] , "0" ) ) > 0 && Convertor.IsNull( tb.Rows[i]["cfmxid"] , Guid.Empty.ToString() ) != Guid.Empty.ToString() )
                {
                    tb.Rows[i]["�˼���"] = torow.ToString();
                }
            }
        }


        private void txtfph_KeyPress( object sender , System.Windows.Forms.KeyPressEventArgs e )
        {
            try
            {
                Control control = (Control)sender;
                int nkey = Convert.ToInt32( e.KeyChar );
                if ( nkey == 13 )
                {
                    if ( control.Name == "txtlsh" && ( txtlsh.Text == "0" || ( Convertor.IsNumeric( txtlsh.Text ) == false && txtlsh.Text.Trim() != "" ) ) )
                    {
                        MessageBox.Show( "��ˮ������������" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }
                    if ( control.Name == "txtfph" && ( txtfph.Text == "0" || ( Convertor.IsNumeric( txtfph.Text ) == false && txtfph.Text.Trim() != "" ) ) )
                    {
                        MessageBox.Show( "��Ʊ������������" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }

                    DataTable mytb_mx = (DataTable)this.myDataGrid2.DataSource;
                    mytb_mx.Rows.Clear();

                    DataTable mytb = (DataTable)this.myDataGrid1.DataSource;
                    mytb.Rows.Clear();


                    ts_mz_brxx.MzGhxx ghxx = null;
                    ts_mz_brxx.MzBrxx brxx = null;
                    if ( control.Name == "txtmzh" )
                        txtmzh.Text = FunBase.returnMzh( txtmzh.Text , InstanceForm.BDatabase , InstanceForm._menuTag.Jgbm );

                    Guid _brxxid = Guid.Empty;
                    string _mzh = txtmzh.Text;
                    long _dnlsh = Convert.ToInt64( Convertor.IsNull( txtlsh.Text , "0" ) );
                    string _fph = Convertor.IsNull( txtfph.Text , "0" );
                    Guid _fyid = Guid.Empty;
                    string _cfrq1 = "";
                    string _cfrq2 = "";



                    if ( ( control.Name == "txttmk" && control.Text.Trim() != "" ) || ( _mzh == "" && _dnlsh == 0 && _fph == "0" ) )
                    {
                        //txttmk.Text = Fun.returnKh( Convert.ToInt32( Convertor.IsNull( cmbklx.SelectedValue , "0" ) ) , txttmk.Text , InstanceForm.BDatabase );
                        ReadCard card = new ReadCard( Convert.ToInt32( Convertor.IsNull( cmbklx.SelectedValue , "0" ) ) , txttmk.Text , InstanceForm.BDatabase );
                        _brxxid = card.brxxid;
                        _cfrq1 = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).AddDays( -3 ).ToShortDateString() + " 00:00:00";
                        _cfrq2 = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).AddDays( 0 ).ToShortDateString() + " 23:59:59";
                        if ( _brxxid == Guid.Empty )
                            return;
                    }


                    DataTable tb = MZYF.Select_TY_Cf( InstanceForm.BCurrentDept.DeptId , _brxxid , _cfrq1 , _cfrq2 , _mzh , _dnlsh , _fph , _fyid , InstanceForm.BDatabase );
                    DataTable tbcopy = tb.Clone();
                    if ( tb.Rows.Count == 1 )
                        tbcopy.ImportRow( tb.Rows[0] );
                    else
                    {
                        FrmSel f = new FrmSel( _brxxid , _cfrq1 , _cfrq2 , _mzh , _dnlsh , _fph );
                        f.Left = 500;
                        f.Top = 500;
                        if ( _cfrq1 != "" )
                        {
                            f.chkcfrq.Checked = true;
                            f.dtprq1.Value = Convert.ToDateTime( _cfrq1 );
                            f.dtprq2.Value = Convert.ToDateTime( _cfrq2 );
                        }
                        DataTable tbx = (DataTable)f.dataGridView1.DataSource;
                        int x = 0;
                        for ( int i = 0 ; i <= tb.Rows.Count - 1 ; i++ )
                        {
                            DataRow row = tbx.NewRow();
                            x = x + 1;
                            row["���"] = x.ToString();
                            row["ѡ��"] = ( control.Name == "txtfph" || control.Name == "txtlsh" ) == true ? true : false;
                            row["�����"] = tb.Rows[i]["������"];
                            row["��Ʊ��"] = tb.Rows[i]["��Ʊ��"];
                            row["��ˮ��"] = tb.Rows[i]["jssjh"];
                            row["����"] = tb.Rows[i]["����"];
                            row["���"] = tb.Rows[i]["���"];
                            row["��ҩ����"] = tb.Rows[i]["��ҩ����"];
                            row["��ҩ����"] = tb.Rows[i]["��ҩ����"];
                            row["id"] = tb.Rows[i]["id"];
                            tbx.Rows.Add( row );
                        }
                        f.ShowDialog();
                        if ( f.Bok == true )
                        {
                            /*
                             * update code by pengy 7-31
                             */
                            if (tb == null || tb.Rows.Count == 0)
                                tb = f.RetDataList;
                            DataRow[] rows = tbx.Select( "ѡ��=true" );
                            for ( int i = 0 ; i <= rows.Length - 1 ; i++ )
                            {                                
                                DataRow[] selrow = tb.Select( "id='" + rows[i]["id"].ToString() + "'" );
                                if ( selrow.Length > 0 )
                                    tbcopy.ImportRow( selrow[0] );
                            }
                        }
                    }
                    if ( tbcopy.Rows.Count > 0 )
                    {
                        _brxxid = new Guid( tbcopy.Rows[0]["patid"].ToString() );
                        brxx = new ts_mz_brxx.MzBrxx( _brxxid , 0 , "" , "" , 0 , InstanceForm.BDatabase );
                        this.lblxm.Text = brxx.����;
                        this.lblxb.Text = brxx.�Ա�;
                        this.lblnl.Text = brxx.����;
                        txtlsh.Text = tb.Rows[0]["jssjh"].ToString();
                    }



                    //if (control.Name=="txtfph")
                    //{
                    //    DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, "", Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")), 0, InstanceForm.BDatabase);
                    //    if (tbghxx.Rows.Count==0){MessageBox.Show("û���ҵ����ˣ�����������","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
                    //    ghxx=new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                    //    brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", 0, InstanceForm.BDatabase);
                    //}



                    //this.lblks.Text=ghxx.�Һſ�������;
                    //this.lblzd.Text=ghxx.�������;


                    this.Cursor = PubStaticFun.WaitCursor();



                    //DataTable tb = MZYF.Select_TY_Cf(InstanceForm.BCurrentDept.DeptId, Guid.Empty, 1, 0, txtfph.Text, InstanceForm.BDatabase);
                    tbcopy.TableName = "tbcopy";
                    this.myDataGrid1.DataSource = tbcopy;
                    this.myDataGrid1.TableStyles[0].MappingName = "tbcopy";

                    if ( tbcopy.Rows.Count == 0 )
                        return;

                    _fyid = new Guid( tbcopy.Rows[0]["id"].ToString() );

                    //���Ҵ�����ϸ
                    string _cflx = tbcopy.Rows[0]["cflx"].ToString().Trim();
                    SelectCf_Cfmx( _cflx , new Guid( tbcopy.Rows[0]["xh"].ToString() ) , Convert.ToInt64( tbcopy.Rows[0]["��Ʊ��"] ) , _fyid , Convert.ToDecimal( tbcopy.Rows[0]["���"] ) );

                    //�����еĿ�ȺͿɶ���


                    ControlVisble( _cflx );


                }
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message );
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }


        }

        private void button5_Click( object sender , EventArgs e )
        {

        }

        private void myDataGrid2_Click( object sender , EventArgs e )
        {
            try
            {
                DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
                int nrow = this.myDataGrid2.CurrentCell.RowNumber;
                int ncol = this.myDataGrid2.CurrentCell.ColumnNumber;
                if ( nrow >= myTb.Rows.Count )
                    return;
                if ( myTb.Rows[nrow]["���"].ToString().Trim() == "С��" )
                    return;

                if ( Convertor.IsNull( myTb.Rows[nrow]["fyid"] , Guid.Empty.ToString() ) == Guid.Empty.ToString()
                    && Convert.ToDecimal( myTb.Rows[nrow]["����"] ) < 0 && _menuTag.Function_Name == "Fun_ts_yf_mzty_ys" )
                {
                    if ( Convert.ToBoolean( myTb.Rows[nrow]["ѡ"] ) == true )
                        myTb.Rows[nrow]["ѡ"] = false;
                    else
                        myTb.Rows[nrow]["ѡ"] = true;
                }
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }

        }

    }
}
