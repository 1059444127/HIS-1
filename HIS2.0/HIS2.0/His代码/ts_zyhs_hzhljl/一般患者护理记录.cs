using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_hzhljl
{
    /// <summary>
    /// Form1 ��ժҪ˵����
    /// </summary>
    public class frmYBHZHLJL : System.Windows.Forms.Form
    {
        //�Զ������
        private BaseFunc myFunc;
        private bool isNew = true;
        private Guid pat_id = Guid.Empty;
        private long baby_id = 0;
        private string strSql = "";

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker DtpbeginDate;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btSaveModel;
        private System.Windows.Forms.Button btOpenModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt�½�;
        private System.Windows.Forms.Button bt����;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.RichTextBox rtbBook;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblBed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblZyh;
        private RichTextBoxEx rtbShow;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel6;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtInpatNo;
        private System.Windows.Forms.Button btnSeek;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Splitter splitter2;
        private System.ComponentModel.IContainer components;

        public frmYBHZHLJL(string _formText)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtbShow = new TrasenClasses.GeneralControls.RichTextBoxEx(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.lblBed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblZyh = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbBook = new System.Windows.Forms.RichTextBox();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.bt�½� = new System.Windows.Forms.Button();
            this.btSaveModel = new System.Windows.Forms.Button();
            this.btOpenModel = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.bt���� = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtInpatNo = new System.Windows.Forms.TextBox();
            this.btnSeek = new System.Windows.Forms.Button();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(168, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 669);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.rtbShow);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(760, 329);
            this.panel4.TabIndex = 64;
            // 
            // rtbShow
            // 
            this.rtbShow.AccessibleDescription = "";
            this.rtbShow.AccessibleName = "";
            this.rtbShow.BackColor = System.Drawing.SystemColors.Window;
            this.rtbShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbShow.DetectUrls = false;
            this.rtbShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbShow.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbShow.LinkStyle = true;
            this.rtbShow.Location = new System.Drawing.Point(0, 0);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.ReadOnly = true;
            this.rtbShow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbShow.Size = new System.Drawing.Size(760, 329);
            this.rtbShow.TabIndex = 59;
            this.rtbShow.Text = "";
            this.toolTip1.SetToolTip(this.rtbShow, "�����  ������������޸ļ�¼");
            this.rtbShow.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbShow_LinkClicked);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.lblDept);
            this.panel5.Controls.Add(this.lblWard);
            this.panel5.Controls.Add(this.lblBed);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.lblName);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.lblZyh);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(760, 40);
            this.panel5.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(127, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "����";
            // 
            // lblDept
            // 
            this.lblDept.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDept.Location = new System.Drawing.Point(175, 16);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(88, 23);
            this.lblDept.TabIndex = 3;
            // 
            // lblWard
            // 
            this.lblWard.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.Location = new System.Drawing.Point(319, 16);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(80, 23);
            this.lblWard.TabIndex = 5;
            // 
            // lblBed
            // 
            this.lblBed.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBed.Location = new System.Drawing.Point(455, 16);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(64, 23);
            this.lblBed.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(407, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 23);
            this.label9.TabIndex = 6;
            this.label9.Text = "����";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(55, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 23);
            this.lblName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "����";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(271, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "����";
            // 
            // lblZyh
            // 
            this.lblZyh.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZyh.Location = new System.Drawing.Point(583, 16);
            this.lblZyh.Name = "lblZyh";
            this.lblZyh.Size = new System.Drawing.Size(72, 23);
            this.lblZyh.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(527, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 8;
            this.label11.Text = "סԺ��";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.GrayText;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 369);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(760, 4);
            this.splitter1.TabIndex = 61;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblId);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.rtbBook);
            this.panel3.Controls.Add(this.DtpbeginDate);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 373);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 232);
            this.panel3.TabIndex = 2;
            // 
            // lblId
            // 
            this.lblId.ForeColor = System.Drawing.Color.Blue;
            this.lblId.Location = new System.Drawing.Point(69, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(268, 16);
            this.lblId.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "��ţ�";
            // 
            // rtbBook
            // 
            this.rtbBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbBook.DetectUrls = false;
            this.rtbBook.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbBook.Location = new System.Drawing.Point(0, 40);
            this.rtbBook.MaxLength = 7800;
            this.rtbBook.Name = "rtbBook";
            this.rtbBook.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbBook.Size = new System.Drawing.Size(760, 192);
            this.rtbBook.TabIndex = 58;
            this.rtbBook.Text = "";
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DtpbeginDate.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(410, 9);
            this.DtpbeginDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(167, 23);
            this.DtpbeginDate.TabIndex = 67;
            this.DtpbeginDate.Value = new System.DateTime(2004, 8, 13, 12, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(370, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "���ڣ�";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnCheck);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.bt�½�);
            this.panel2.Controls.Add(this.btSaveModel);
            this.panel2.Controls.Add(this.btOpenModel);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.bt����);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 605);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 64);
            this.panel2.TabIndex = 60;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDel.ImageIndex = 0;
            this.btnDel.Location = new System.Drawing.Point(615, 24);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(64, 24);
            this.btnDel.TabIndex = 68;
            this.btnDel.Text = "ɾ��(&D)";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheck.ImageIndex = 0;
            this.btnCheck.Location = new System.Drawing.Point(420, 24);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(64, 24);
            this.btnCheck.TabIndex = 67;
            this.btnCheck.Text = "���(&K)";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(485, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 24);
            this.btnRefresh.TabIndex = 66;
            this.btnRefresh.Text = "ˢ��(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // bt�½�
            // 
            this.bt�½�.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt�½�.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt�½�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�½�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�½�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�½�.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt�½�.ImageIndex = 0;
            this.bt�½�.Location = new System.Drawing.Point(112, 24);
            this.bt�½�.Name = "bt�½�";
            this.bt�½�.Size = new System.Drawing.Size(64, 24);
            this.bt�½�.TabIndex = 65;
            this.bt�½�.Text = "�½�(&N)";
            this.bt�½�.UseVisualStyleBackColor = false;
            this.bt�½�.Click += new System.EventHandler(this.bt�½�_Click);
            // 
            // btSaveModel
            // 
            this.btSaveModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveModel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btSaveModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveModel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSaveModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btSaveModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveModel.ImageIndex = 9;
            this.btSaveModel.Location = new System.Drawing.Point(266, 24);
            this.btSaveModel.Name = "btSaveModel";
            this.btSaveModel.Size = new System.Drawing.Size(88, 24);
            this.btSaveModel.TabIndex = 64;
            this.btSaveModel.Text = "����ģ��(&M)";
            this.btSaveModel.UseVisualStyleBackColor = false;
            this.btSaveModel.Click += new System.EventHandler(this.btSaveModel_Click);
            // 
            // btOpenModel
            // 
            this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenModel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenModel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenModel.ImageIndex = 1;
            this.btOpenModel.Location = new System.Drawing.Point(177, 24);
            this.btOpenModel.Name = "btOpenModel";
            this.btOpenModel.Size = new System.Drawing.Size(88, 24);
            this.btOpenModel.TabIndex = 63;
            this.btOpenModel.Text = "��ģ��(&O)";
            this.btOpenModel.UseVisualStyleBackColor = false;
            this.btOpenModel.Click += new System.EventHandler(this.btOpenModel_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(680, 24);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 61;
            this.btCancel.Text = "�˳�(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.Location = new System.Drawing.Point(550, 24);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(64, 24);
            this.btnPrint.TabIndex = 60;
            this.btnPrint.Text = "��ӡ(&P)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // bt����
            // 
            this.bt����.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt����.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt����.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt����.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt����.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt����.ImageIndex = 0;
            this.bt����.Location = new System.Drawing.Point(355, 24);
            this.bt����.Name = "bt����";
            this.bt����.Size = new System.Drawing.Size(64, 24);
            this.bt����.TabIndex = 59;
            this.bt����.Text = "����(&S)";
            this.bt����.UseVisualStyleBackColor = false;
            this.bt����.Click += new System.EventHandler(this.bt����_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(104, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(648, 40);
            this.button3.TabIndex = 62;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox2);
            this.panel6.Controls.Add(this.myDataGrid2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(168, 669);
            this.panel6.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.txtInpatNo);
            this.groupBox2.Controls.Add(this.btnSeek);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 608);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 61);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "סԺ�Ų�ѯ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox1.Location = new System.Drawing.Point(4, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 20);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtInpatNo
            // 
            this.txtInpatNo.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInpatNo.Location = new System.Drawing.Point(4, 13);
            this.txtInpatNo.Name = "txtInpatNo";
            this.txtInpatNo.Size = new System.Drawing.Size(96, 21);
            this.txtInpatNo.TabIndex = 0;
            this.txtInpatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInpatNo_KeyPress);
            // 
            // btnSeek
            // 
            this.btnSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeek.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeek.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeek.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSeek.Location = new System.Drawing.Point(112, 23);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(48, 24);
            this.btnSeek.TabIndex = 56;
            this.btnSeek.Text = "��ѯ";
            this.btnSeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Black;
            this.myDataGrid2.CaptionText = "������Ϣ";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myDataGrid2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(168, 608);
            this.myDataGrid2.TabIndex = 24;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(168, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 669);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // frmYBHZHLJL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 669);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Name = "frmYBHZHLJL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "һ�㻼�߻����¼";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYBHZ_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmYBHZ_Load(object sender, System.EventArgs e)
        {

            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            this.btnCheck.Enabled = false;

            //��������ҵĲ�����Ϣ
            string sSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY dbo.Fun_GetBedToOrder( (case when left( bed_no,1)='+' then '999'+ bed_no else  bed_no end) ),Baby_ID";
            string[] GrdMappingName1 ={ "����", "����", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
            int[] GrdWidth1 ={ 6, 12, 0, 0, 0, 0 };
            int[] Alignment1 ={ 1, 0, 0, 0, 0, 0 };
            myFunc.InitGridSQL(sSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);
            myFunc.SelectBin(true, this.myDataGrid2, 2, 3, 4, 5);

            myDataGrid2_CurrentCellChanged(null, null);
        }

        public void Show_Date(Guid v_pat_id, long v_baby_id)
        {
            try
            {
                string book_user_name = "";
                string check_user_name = "";
                string sSql = "select '    '+ltrim(rtrim(book_text)) as book_text,id,book_date,book_user,check_user from zy_ybhzhljl where inpatient_id='" + v_pat_id + "' and baby_id=" + v_baby_id + " order by book_date,id";
                DataTable myTb = new DataTable();
                DataTable binTb = new DataTable();

                rtbShow.Text = "";
                pat_id = v_pat_id;
                baby_id = v_baby_id;

                binTb = GetPatInfo(pat_id, baby_id);
                if (binTb == null || binTb.Rows.Count == 0)
                {
                    MessageBox.Show(this, "û�в�����Ϣ����ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblName.Text = binTb.Rows[0]["name"].ToString();
                lblDept.Text = binTb.Rows[0]["cur_dept_name"].ToString();
                lblWard.Text = binTb.Rows[0]["ward_name"].ToString();
                lblBed.Text = binTb.Rows[0]["bed_no"].ToString();
                lblZyh.Text = binTb.Rows[0]["inpatient_no"].ToString();
                myTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (myTb == null || myTb.Rows.Count == 0) return;

                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    book_user_name = GetUserName(myTb.Rows[i]["book_user"].ToString() == null ? 0 : Convert.ToInt32(myTb.Rows[i]["book_user"].ToString()));
                    check_user_name = GetUserName(myTb.Rows[i]["check_user"].ToString() == null || myTb.Rows[i]["check_user"].ToString().Trim() == "" ? 0 : Convert.ToInt32(myTb.Rows[i]["check_user"].ToString()));
                    rtbShow.Text += "�� " + myTb.Rows[i]["id"].ToString() + " ��";
                    rtbShow.Text += myTb.Rows[i]["book_date"].ToString() + "\n";
                    rtbShow.Text += myTb.Rows[i]["book_text"].ToString() + "\n";
                    rtbShow.Text += "                                                            " +
                        book_user_name + "   " + check_user_name + "\n";
                }

                rtbShow.Focus();
                rtbShow.Select(rtbShow.TextLength, 0);
                rtbShow.ScrollToCaret();
            }
            catch (Exception err)
            {
                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt�½�_Click(object sender, System.EventArgs e)
        {
            this.isNew = true;
            this.btnCheck.Enabled = false;
            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.rtbBook.ForeColor = Color.Black;
            this.rtbBook.Text = "";
            this.lblId.Text = "";
            this.rtbBook.Focus();
        }

        private void bt����_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable myTb = new DataTable();

                if (pat_id == null || pat_id == Guid.Empty)
                {
                    MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.rtbBook.Text.Trim() == "") return;

                if (this.isNew)
                {
                    strSql = @"insert into zy_ybhzhljl(id,inpatient_id,baby_id,dept_id,book_date,book_text,book_user,jgbm)" +
                        @" values('" + PubStaticFun.NewGuid() + "','" + pat_id + "'," + baby_id + "," + ClassStatic.Current_DeptID + ",'" + DtpbeginDate.Value + "','" + rtbBook.Text.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";

                    InstanceForm.BDatabase.DoCommand(strSql);
                }
                else
                {
                    if (lblId.Text.Trim() == "") return;

                    strSql = @"select * from zy_ybhzhljl where id='" + lblId.Text + "' and (check_user=" + InstanceForm.BCurrentUser.EmployeeId +
                        @" or book_user=" + InstanceForm.BCurrentUser.EmployeeId + ") and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                    myTb = InstanceForm.BDatabase.GetDataTable(strSql);

                    //Add By Tany 2005-07-04
                    //��ʿ�����鳤��ʿ���Բ���
                    if (myFunc.IsHSZ(Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId)) == false
                        && myFunc.IsZZHS(Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId)) == false)
                    {
                        if (myTb == null || myTb.Rows.Count == 0)
                        {
                            MessageBox.Show(this, "�Բ��𣬲�����¼�루��ˣ��ļ�¼�����޸ģ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    strSql = @"update zy_ybhzhljl set book_text='" + rtbBook.Text.Trim() + "',modify_user=" + InstanceForm.BCurrentUser.EmployeeId +
                        @" where id='" + lblId.Text + "' and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                    InstanceForm.BDatabase.DoCommand(strSql);
                }

                MessageBox.Show(this, "����ɹ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show_Date(pat_id, baby_id);
                bt�½�_Click(sender, e);

            }
            catch (Exception err)
            {
                //д������־ Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "����һ�㻼�߻����¼����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetUserName(int UserId)
        {
            DataTable myTb = new DataTable();
            string UserName = "";
            string sSql;

            sSql = @"select name from jc_employee_property where employee_id = " + UserId;
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb != null && myTb.Rows.Count > 0) UserName = myTb.Rows[0]["name"].ToString();

            return UserName;

        }

        private void btOpenModel_Click(object sender, System.EventArgs e)
        {
            DataRow myDr;
            string msgStr = "";
            frmSelBox fs = new frmSelBox();

            strSql = @"select id,name ����,model_text ����,py ƴ����,wb �����,case model_type when 0 then 'ȫԺ����' when 1 then '����ʹ��' when 2 then '����ʹ��' " +
                    @"when 3 then '����ʹ��' end ���� from ZY_HLJLMODEL where mng_type in (0,1) and " +
                @"((model_type=0) or (model_type=1 and ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                @" or (model_type=2 and dept_id=" + ClassStatic.Current_DeptID + ")" +
                @" or (model_type=3 and user_id=" + InstanceForm.BCurrentUser.EmployeeId + "))";
            fs.InitGrid(strSql);
            fs.ShowDialog();
            if (fs.DialogResult == DialogResult.OK)
            {
                myDr = fs.myDr;
                if (rtbBook.Text.Trim() != "")
                {
                    msgStr = MessageBox.Show(this, "�Ƿ񸲸����е����ݣ�\n\n���ǣ�������������    ��׷�ӵ���������", "��ʾ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString();
                    switch (msgStr.ToUpper())
                    {
                        case "YES":
                            rtbBook.Text = "";
                            break;
                        case "CANCEL":
                            return;
                    }
                }
                rtbBook.Text += myDr["����"].ToString();
            }
            fs.Dispose();
        }

        private void btSaveModel_Click(object sender, System.EventArgs e)
        {

            try
            {
                string ModelName = "";
                int mng_type = 0;
                int model_type = 0;
                string ward_id = "";
                long dept_id = -1;
                long user_id = -1;
                string msgStr = "";
                DataTable myTb = new DataTable();
                frmHLModelSave fh = new frmHLModelSave();

                if (rtbBook.Text.Trim() == "") return;

                fh.ShowDialog();
                if (fh.DialogResult == DialogResult.OK)
                {
                    ModelName = fh.ModelName;
                    mng_type = fh.mng_type;
                    model_type = fh.model_type;
                    fh.Dispose();
                }
                else
                {
                    fh.Dispose();
                    return;
                }

                strSql = @"select id,name from ZY_HLJLMODEL where name='" + ModelName + "' and mng_type in (0,1) and " +
                    @"((model_type=0) or (model_type=1 and ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                    @" or (model_type=2 and dept_id=" + ClassStatic.Current_DeptID + ")" +
                    @" or (model_type=3 and user_id=" + InstanceForm.BCurrentUser.EmployeeId + "))";
                myTb = InstanceForm.BDatabase.GetDataTable(strSql);

                if (myTb != null && myTb.Rows.Count != 0)
                {
                    msgStr = MessageBox.Show(this, "ģ�����Ѿ����ڣ��Ƿ��滻���е�ģ�棿", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (msgStr.ToUpper() == "YES")
                    {
                        strSql = "delete from ZY_HLJLMODEL where id=" + Convert.ToInt32(myTb.Rows[0]["id"].ToString());
                        InstanceForm.BDatabase.DoCommand(strSql);
                    }
                    else
                    {
                        return;
                    }
                }

                switch (model_type)
                {
                    case 1:
                        ward_id = InstanceForm.BCurrentDept.WardId;
                        break;
                    case 2:
                        dept_id = Convert.ToInt64(ClassStatic.Current_DeptID);
                        break;
                    case 3:
                        user_id = InstanceForm.BCurrentUser.EmployeeId;
                        break;
                }

                strSql = @"insert into ZY_HLJLMODEL(name,py,wb,model_text,model_type,mng_type,ward_id,dept_id,user_id,memo) " +
                    @"values('" + ModelName + "','" + PubStaticFun.GetPYWBM(ModelName, 0) + "','" + PubStaticFun.GetPYWBM(ModelName, 1) + "','" + rtbBook.Text + "'," +
                    model_type + @"," + mng_type + ",'" + ward_id + "'," + dept_id + "," + user_id + ",' ')";
                InstanceForm.BDatabase.DoCommand(strSql);

                MessageBox.Show(this, "����ɹ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            Show_Date(pat_id, baby_id);
        }

        private void btnCheck_Click(object sender, System.EventArgs e)
        {

            try
            {
                DataTable myTb = new DataTable();

                if (isNew)
                {
                    return;
                }
                else
                {
                    if (lblId.Text.Trim() == "") return;

                    strSql = @"select * from zy_ybhzhljl where id='" + lblId.Text + "' and  book_user=" + InstanceForm.BCurrentUser.EmployeeId + " and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                    myTb = InstanceForm.BDatabase.GetDataTable(strSql);

                    if (myTb != null && myTb.Rows.Count != 0)
                    {
                        MessageBox.Show(this, "�Բ��𣬲�������Լ�¼��ļ�¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    strSql = @"update zy_ybhzhljl set check_user=" + InstanceForm.BCurrentUser.EmployeeId +
                        @" where id='" + lblId.Text + "' and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                    InstanceForm.BDatabase.DoCommand(strSql);
                }
                MessageBox.Show(this, "��˳ɹ���", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show_Date(pat_id, baby_id);
                btnCheck.Enabled = false;
            }
            catch (Exception err)
            {
                //д������־ Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "���һ�㻼�߻����¼����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetPatInfo(Guid inpatient_id, long baby_id)
        {
            //��ȡ���˵Ļ�����Ϣ
            string sqlStr = "";
            DataTable dbTb = new DataTable();
            sqlStr = @"select a.name,a.cur_dept_name,a.bed_no,a.inpatient_no,b.ward_name from vi_zy_vINPATIENT_ALL a,jc_WARD b where a.ward_id=b.ward_id and a.inpatient_id='" + inpatient_id + "' and a.baby_id=" + baby_id;
            dbTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
            return dbTb;
        }

        private void rtbShow_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            try
            {
                Guid id;

                id = new Guid(e.LinkText);
                string sSql = @"select '    '+ltrim(rtrim(book_text)) as book_text,id,book_date,book_user,check_user from zy_ybhzhljl where id='" + id + "' order by id";
                DataTable myTb = new DataTable();

                myTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (myTb == null || myTb.Rows.Count == 0) return;

                lblId.Text = myTb.Rows[0]["id"].ToString();
                DtpbeginDate.Value = Convert.ToDateTime(myTb.Rows[0]["book_date"].ToString());
                rtbBook.Text = myTb.Rows[0]["book_text"].ToString();
                if (myTb.Rows[0]["check_user"].ToString().Trim() == "") btnCheck.Enabled = true;
                else btnCheck.Enabled = false;
                isNew = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                //				����.TheReportDateSet rds = new ��ʿ����վ.����.TheReportDateSet();
                //ʹ�ÿո����ʹ��ȫ�ǿո񣬷�����Ϊ���з�
                string sSql = "select a.id,a.inpatient_id,a.baby_id,a.dept_id,a.book_date,'����'+ltrim(rtrim(a.book_text)) as book_text," +
                    "dbo.FUN_ZY_SEEKEMPLOYEENAME(a.book_user) book_user, dbo.FUN_ZY_SEEKEMPLOYEENAME(a.check_user) check_user,dbo.FUN_ZY_SEEKdeptname(a.dept_id) deptname,c.ward_name wardname " +
                    "from zy_ybhzhljl a inner join jc_wardrdept b on a.dept_id=b.dept_id " +
                    "inner join jc_ward c on b.ward_id=c.ward_id " +
                    "where a.inpatient_id='" + pat_id + "' and a.baby_id=" + baby_id + " order by a.book_date,a.id";
                DataSet ds = new DataSet();
                DataTable prTb = new DataTable();

                prTb = InstanceForm.BDatabase.GetDataTable(sSql);
                prTb.TableName = "tabYbhljl";
                ds.Tables.Add(prTb);

                if (prTb == null || prTb.Rows.Count == 0) return;

                //�ѿո���ȫ��
                for (int i = 0; i < prTb.Rows.Count; i++)
                {
                    prTb.Rows[i]["book_text"] = prTb.Rows[i]["book_text"].ToString().Replace(" ", "��");
                }

                FrmReportView frmRptView = null;
                ParameterEx[] _parameters = new ParameterEx[7];

                _parameters[0].Text = "ҽԺ����";
                _parameters[0].Value = (new SystemCfg(0002)).Config;
                _parameters[1].Text = "��������";
                _parameters[1].Value = lblName.Text;
                _parameters[2].Text = "����";
                _parameters[2].Value = lblDept.Text;
                _parameters[3].Text = "����";
                _parameters[3].Value = lblWard.Text;
                _parameters[4].Text = "����";
                _parameters[4].Value = lblBed.Text;
                _parameters[5].Text = "סԺ��";
                _parameters[5].Value = lblZyh.Text;
                _parameters[6].Text = "��ӡ��";
                _parameters[6].Value = InstanceForm.BCurrentUser.Name;

                frmRptView = new FrmReportView(ds, Constant.ApplicationDirectory + "\\report\\ZYHS_һ�㻼�߻����¼.rpt", _parameters);
                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            if (tb.Rows.Count == 0)
            {
                return;
            }
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);
            ClassStatic.Current_BinID = new Guid(this.myDataGrid2[nrow, 2].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(this.myDataGrid2[nrow, 3]);
            ClassStatic.Current_DeptID = Convert.ToInt64(this.myDataGrid2[nrow, 4]);
            ClassStatic.Current_isMY = Convert.ToInt16(this.myDataGrid2[nrow, 5]);

            Show_Date(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
            bt�½�_Click(sender, e);
        }

        private void btnSeek_Click(object sender, System.EventArgs e)
        {
            if (txtInpatNo.Text.Trim() == "")
                txtInpatNo.Text = "0";

            string sSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_All " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + txtInpatNo.Text.Trim() + "'" +
                "  order by baby_id";
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                MessageBox.Show("û���ҵ��ò�����Ϣ����˶�סԺ�ţ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            comboBox1.Items.Clear();

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                ClassStatic.MYTS_Name[i] = myTb.Rows[i]["����"].ToString().Trim();
                ClassStatic.MYTS_BabyID[i] = myTb.Rows[i]["BABY_ID"].ToString().Trim();
                ClassStatic.MYTS_BinID[i] = new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString().Trim());
                comboBox1.Items.Add(ClassStatic.MYTS_Name[i]);
                if (Convert.ToInt64(ClassStatic.MYTS_BabyID[i]) == ClassStatic.Current_BabyID)
                {
                    comboBox1.Text = ClassStatic.MYTS_Name[i];
                }
            }

            comboBox1.SelectedIndex = 0;

            ClassStatic.Current_BinID = new Guid(myTb.Rows[0]["INPATIENT_ID"].ToString().Trim());
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);
            ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[0]["DEPT_ID"].ToString().Trim());
            ClassStatic.Current_isMY = Convert.ToInt32(myTb.Rows[0]["isMY"].ToString().Trim());

            myDataGrid2.UnSelect(myDataGrid2.CurrentCell.RowNumber);

            Show_Date(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ClassStatic.Current_BinID = new Guid(ClassStatic.MYTS_BinID[comboBox1.SelectedIndex].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);

            Show_Date(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
        }

        private void txtInpatNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSeek.Focus();

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {

            try
            {
                DataTable myTb = new DataTable();

                if (pat_id == null || pat_id == Guid.Empty)
                {
                    MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lblId.Text.Trim() == "") return;

                strSql = @"select * from zy_ybhzhljl where id='" + lblId.Text + "' and (check_user=" + InstanceForm.BCurrentUser.EmployeeId +
                    @" or book_user=" + InstanceForm.BCurrentUser.EmployeeId + ") and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                myTb = InstanceForm.BDatabase.GetDataTable(strSql);

                //Add By Tany 2005-07-04
                //��ʿ�����鳤��ʿ���Բ���
                if (myFunc.IsHSZ(Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId)) == false
                    && myFunc.IsZZHS(Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId)) == false)
                {
                    if (myTb == null || myTb.Rows.Count == 0)
                    {
                        MessageBox.Show(this, "�Բ��𣬲�����¼�루��ˣ��ļ�¼����ɾ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (MessageBox.Show(this, "��¼ɾ�������ָܻ���ȷ��ɾ��������¼��", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                strSql = @"delete from zy_ybhzhljl where id='" + lblId.Text + "' and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                InstanceForm.BDatabase.DoCommand(strSql);

                //д��־ Add By Tany 2005-06-21
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "ɾ��һ�㻤���¼", "�� " + pat_id + " ���˵� " + lblId.Text + " �Ż����¼ɾ��", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                MessageBox.Show(this, "ɾ���ɹ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show_Date(pat_id, baby_id);
                bt�½�_Click(sender, e);
            }
            catch (Exception err)
            {
                //д������־ Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "ɾ��һ�㻼�߻����¼����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
