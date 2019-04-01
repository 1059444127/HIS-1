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
using System.Net;
using System.Collections.Generic;

namespace ts_zyhs_fpcw
{
    /// <summary>
    /// ���䴲λ ��ժҪ˵����
    /// </summary>
    public class frmFPCW : System.Windows.Forms.Form
    {
        //�Զ������==============================================
        private BaseFunc myFunc;
        private long bed_DeptID = 0;  //��λ����ID
        private string Room_NO = "";  //�����
        private int isPLUS = 0;
        private bool isCK = false;
        SystemCfg cfg7600 = new SystemCfg(7600);//Modify by jchl  ��ʿվ���䴲λ�Ƿ�����������λ�ѣ�0��1��  

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblBed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DtpbeginDate;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btUse;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbBF;
        private System.Windows.Forms.CheckBox cbMYTS;
        private System.Windows.Forms.CheckBox cbCWF;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.CheckBox cbCYZH;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ���䴲λ;
        private System.Windows.Forms.TabPage ȡ������;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
        private DataGridEx myDataGrid4;
        private DataGridEx myDataGrid3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem �޸Ĵ�λ��ToolStripMenuItem;
        private GroupBox groupBox4;
        private Label label4;
        private Label label3;
        private Button button2;
        private TextBox txtname;
        private InpatientNoTextBox txtInpatNo;
        private GroupBox groupBox5;
        private Button buttryks;
        private IContainer components;

        public frmFPCW(string _formText)
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblBed = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.btOK = new System.Windows.Forms.Button();
            this.btUse = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCYZH = new System.Windows.Forms.CheckBox();
            this.cbCWF = new System.Windows.Forms.CheckBox();
            this.cbMYTS = new System.Windows.Forms.CheckBox();
            this.cbBF = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.�޸Ĵ�λ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.���䴲λ = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttryks = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtInpatNo = new TrasenClasses.GeneralControls.InpatientNoTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.ȡ������ = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.myDataGrid4 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.myDataGrid3 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.���䴲λ.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.ȡ������.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(16, 24);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(107, 12);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "��ʾ����ѡ���� ��";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(192, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "���� ,���䵽";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "�Ŵ�";
            // 
            // lblPatient
            // 
            this.lblPatient.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatient.ForeColor = System.Drawing.Color.Blue;
            this.lblPatient.Location = new System.Drawing.Point(128, 24);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(56, 16);
            this.lblPatient.TabIndex = 7;
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBed
            // 
            this.lblBed.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBed.ForeColor = System.Drawing.Color.Blue;
            this.lblBed.Location = new System.Drawing.Point(272, 24);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(32, 16);
            this.lblBed.TabIndex = 8;
            this.lblBed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.lblPatient);
            this.groupBox1.Controls.Add(this.lblBed);
            this.groupBox1.Location = new System.Drawing.Point(489, 645);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 48);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.DtpbeginDate);
            this.groupBox3.Location = new System.Drawing.Point(489, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 48);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "��סʱ�䣺";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 24);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "�޸�ʱ��";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpbeginDate.Enabled = false;
            this.DtpbeginDate.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(88, 16);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(184, 23);
            this.DtpbeginDate.TabIndex = 13;
            this.DtpbeginDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOK.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOK.ImageIndex = 0;
            this.btOK.Location = new System.Drawing.Point(873, 660);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(64, 24);
            this.btOK.TabIndex = 49;
            this.btOK.Text = "ȷ��(&O)";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btUse
            // 
            this.btUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUse.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUse.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btUse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btUse.ImageIndex = 0;
            this.btUse.Location = new System.Drawing.Point(953, 660);
            this.btUse.Name = "btUse";
            this.btUse.Size = new System.Drawing.Size(64, 24);
            this.btUse.TabIndex = 50;
            this.btUse.Text = "Ӧ��(&Y)";
            this.btUse.UseVisualStyleBackColor = false;
            this.btUse.Click += new System.EventHandler(this.btOK_Click);
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
            this.btCancel.Location = new System.Drawing.Point(1033, 660);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 51;
            this.btCancel.Text = "�˳�(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
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
            this.button3.Location = new System.Drawing.Point(865, 652);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(240, 40);
            this.button3.TabIndex = 52;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbCYZH);
            this.groupBox2.Controls.Add(this.cbCWF);
            this.groupBox2.Controls.Add(this.cbMYTS);
            this.groupBox2.Controls.Add(this.cbBF);
            this.groupBox2.Location = new System.Drawing.Point(777, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 48);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "��λѡ�";
            // 
            // cbCYZH
            // 
            this.cbCYZH.Location = new System.Drawing.Point(240, 24);
            this.cbCYZH.Name = "cbCYZH";
            this.cbCYZH.Size = new System.Drawing.Size(80, 16);
            this.cbCYZH.TabIndex = 17;
            this.cbCYZH.Text = "��Ժ�ٻ�";
            this.cbCYZH.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbCYZH.Click += new System.EventHandler(this.cbCYZH_Click);
            // 
            // cbCWF
            // 
            this.cbCWF.Checked = true;
            this.cbCWF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCWF.Location = new System.Drawing.Point(8, 24);
            this.cbCWF.Name = "cbCWF";
            this.cbCWF.Size = new System.Drawing.Size(160, 16);
            this.cbCWF.TabIndex = 16;
            this.cbCWF.Text = "�Զ����ɴ�λ�ѳ����˵�";
            this.cbCWF.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbCWF.Visible = false;
            // 
            // cbMYTS
            // 
            this.cbMYTS.Enabled = false;
            this.cbMYTS.Location = new System.Drawing.Point(168, 24);
            this.cbMYTS.Name = "cbMYTS";
            this.cbMYTS.Size = new System.Drawing.Size(80, 16);
            this.cbMYTS.TabIndex = 14;
            this.cbMYTS.Text = "ĸӤͬ��";
            this.cbMYTS.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbMYTS.Click += new System.EventHandler(this.cbMYTS_Click);
            // 
            // cbBF
            // 
            this.cbBF.Location = new System.Drawing.Point(88, 24);
            this.cbBF.Name = "cbBF";
            this.cbBF.Size = new System.Drawing.Size(48, 16);
            this.cbBF.TabIndex = 15;
            this.cbBF.Text = "����";
            this.cbBF.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbBF.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�޸Ĵ�λ��ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // �޸Ĵ�λ��ToolStripMenuItem
            // 
            this.�޸Ĵ�λ��ToolStripMenuItem.Name = "�޸Ĵ�λ��ToolStripMenuItem";
            this.�޸Ĵ�λ��ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.�޸Ĵ�λ��ToolStripMenuItem.Text = "�޸Ĵ�λ��";
            this.�޸Ĵ�λ��ToolStripMenuItem.Click += new System.EventHandler(this.�޸Ĵ�λ��ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.���䴲λ);
            this.tabControl1.Controls.Add(this.ȡ������);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 723);
            this.tabControl1.TabIndex = 59;
            // 
            // ���䴲λ
            // 
            this.���䴲λ.Controls.Add(this.groupBox5);
            this.���䴲λ.Controls.Add(this.groupBox4);
            this.���䴲λ.Controls.Add(this.groupBox3);
            this.���䴲λ.Controls.Add(this.groupBox1);
            this.���䴲λ.Controls.Add(this.btOK);
            this.���䴲λ.Controls.Add(this.btUse);
            this.���䴲λ.Controls.Add(this.btCancel);
            this.���䴲λ.Controls.Add(this.groupBox2);
            this.���䴲λ.Controls.Add(this.myDataGrid2);
            this.���䴲λ.Controls.Add(this.button3);
            this.���䴲λ.Controls.Add(this.myDataGrid1);
            this.���䴲λ.Location = new System.Drawing.Point(4, 22);
            this.���䴲λ.Name = "���䴲λ";
            this.���䴲λ.Size = new System.Drawing.Size(1113, 697);
            this.���䴲λ.TabIndex = 0;
            this.���䴲λ.Text = "���䴲λ";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.buttryks);
            this.groupBox5.Location = new System.Drawing.Point(338, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(145, 50);
            this.groupBox5.TabIndex = 59;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "�޸���Ժ����";
            // 
            // buttryks
            // 
            this.buttryks.Location = new System.Drawing.Point(15, 19);
            this.buttryks.Name = "buttryks";
            this.buttryks.Size = new System.Drawing.Size(113, 23);
            this.buttryks.TabIndex = 0;
            this.buttryks.Text = "�޸���Ժ����";
            this.buttryks.UseVisualStyleBackColor = true;
            this.buttryks.Click += new System.EventHandler(this.buttryks_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.txtname);
            this.groupBox4.Controls.Add(this.txtInpatNo);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 50);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "��ѯ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "��ѯ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(184, 15);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(76, 21);
            this.txtname.TabIndex = 3;
            // 
            // txtInpatNo
            // 
            this.txtInpatNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInpatNo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtInpatNo.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.txtInpatNo.EnabledRightKey = true;
            this.txtInpatNo.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.txtInpatNo.EnterBackColor = System.Drawing.SystemColors.Window;
            this.txtInpatNo.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInpatNo.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInpatNo.InpatientNoLength = 9;
            this.txtInpatNo.Location = new System.Drawing.Point(56, 15);
            this.txtInpatNo.Name = "txtInpatNo";
            this.txtInpatNo.NextControl = null;
            this.txtInpatNo.PreviousControl = null;
            this.txtInpatNo.Size = new System.Drawing.Size(83, 21);
            this.txtInpatNo.TabIndex = 2;
            this.txtInpatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInpatNo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "������";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "סԺ�ţ�";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid2.CaptionText = "�մ�";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.ContextMenuStrip = this.contextMenuStrip1;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(8, 272);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeadersVisible = false;
            this.myDataGrid2.Size = new System.Drawing.Size(1097, 365);
            this.myDataGrid2.TabIndex = 57;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "δ���䴲λ�Ĳ���";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(8, 64);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.RowHeadersVisible = false;
            this.myDataGrid1.Size = new System.Drawing.Size(1097, 200);
            this.myDataGrid1.TabIndex = 56;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Tag = "";
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // ȡ������
            // 
            this.ȡ������.Controls.Add(this.btnExit);
            this.ȡ������.Controls.Add(this.btnCancel);
            this.ȡ������.Controls.Add(this.button1);
            this.ȡ������.Controls.Add(this.myDataGrid4);
            this.ȡ������.Controls.Add(this.myDataGrid3);
            this.ȡ������.Location = new System.Drawing.Point(4, 22);
            this.ȡ������.Name = "ȡ������";
            this.ȡ������.Size = new System.Drawing.Size(1113, 697);
            this.ȡ������.TabIndex = 1;
            this.ȡ������.Text = "ȡ������";
            this.ȡ������.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnExit.Location = new System.Drawing.Point(1033, 661);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 24);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "�˳�(&E)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCancel.Location = new System.Drawing.Point(961, 661);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ȡ��(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(953, 653);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 40);
            this.button1.TabIndex = 2;
            // 
            // myDataGrid4
            // 
            this.myDataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGrid4.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid4.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid4.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid4.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid4.CaptionText = "�մ�";
            this.myDataGrid4.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid4.DataMember = "";
            this.myDataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid4.Location = new System.Drawing.Point(8, 264);
            this.myDataGrid4.Name = "myDataGrid4";
            this.myDataGrid4.ReadOnly = true;
            this.myDataGrid4.Size = new System.Drawing.Size(1097, 381);
            this.myDataGrid4.TabIndex = 1;
            this.myDataGrid4.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            this.myDataGrid4.CurrentCellChanged += new System.EventHandler(this.myDataGrid4_CurrentCellChanged);
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.AllowSorting = false;
            this.dataGridTableStyle4.DataGrid = this.myDataGrid4;
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle4.ReadOnly = true;
            // 
            // myDataGrid3
            // 
            this.myDataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGrid3.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid3.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid3.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid3.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid3.CaptionText = "�ѷ��䴲λ�Ĳ���";
            this.myDataGrid3.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid3.DataMember = "";
            this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.Location = new System.Drawing.Point(8, 8);
            this.myDataGrid3.Name = "myDataGrid3";
            this.myDataGrid3.ReadOnly = true;
            this.myDataGrid3.Size = new System.Drawing.Size(1097, 248);
            this.myDataGrid3.TabIndex = 0;
            this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.myDataGrid3.CurrentCellChanged += new System.EventHandler(this.myDataGrid3_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AllowSorting = false;
            this.dataGridTableStyle3.DataGrid = this.myDataGrid3;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.ReadOnly = true;
            // 
            // frmFPCW
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1121, 723);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmFPCW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "���䴲λ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFPCW_Load_1);
            this.Activated += new System.EventHandler(this.frmFPCW_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.���䴲λ.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ȡ������.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].AllowSorting = false; //����������

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "ѡ" || GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    if (GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
                    {
                        myBoolCol.AllowNull = false;
                        myBoolCol.TrueValue = (short)1;
                        myBoolCol.FalseValue = (short)0;
                        myBoolCol.NullValue = (short)0;
                    }

                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                    //add by zouchihua 2011-11-30
                    if (GrdMappingName[i].ToString().Trim() == "isprintypgg")
                    {
                        myBoolCol.AllowNull = false;
                        myBoolCol.TrueValue = 1;
                        myBoolCol.FalseValue = 0;
                        myBoolCol.NullValue = 0;
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = "��ӡ���";
                    }
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);

                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }
        private void frmFPCW_Load(object sender, System.EventArgs e)
        {
            //�����Ŀؼ����ɼ����˹�������
            this.cbBF.Visible = false;
            //this.DtpbeginDate.MinDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase); //�޸���סʱ�䲻��С�ڵ�ǰ����

            this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");					//ϵͳ����    -���
            this.DtpbeginDate.MaxDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddMinutes(2);
            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);                      //��������ǰϵͳ����
            System.TimeSpan diff = new System.TimeSpan(300, 0, 0, 0);
            this.DtpbeginDate.MinDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Subtract(diff);	    //ϵͳ����-30�� -��С


            //add by zouchihua 2013-8-22


            //Modify By Tany 2010-11-26 ���Ĳ����жϣ�ʹ����ⷽ��
            //SystemCfg cfg = new SystemCfg(7010);
            //if (InstanceForm.BCurrentDept.WardId == cfg.Config)
            if (myFunc.IsFCK())
            {
                isCK = true;
                //this.cbMYTS.Enabled = isCK;         //�ǲ���
            }
            else
            {
                isCK = false;
                //this.cbMYTS.Enabled = isCK;
            }
            //Modify By tany 2011-03-07 ���п��Ƕ��ܹ�ĸӤͬ��
            this.cbMYTS.Enabled = true;

            this.ShowData(sender, e);

            string[] GrdMappingName1 ={ "��Ժ����", "��Ժ����", "סԺ��", "����", "Ӥ����", "�Ա�", "��������", "������Դ", "ID", "pat_in_dept", "inpatient_id", "baby_id" };
            int[] GrdWidth1 ={ 19, 19, 9, 8, 6, 4, 20, 8, 0, 0, 0, 0 };
            int[] Alignment1 ={ 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //this.InitGridYZ(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);
            PubStaticFun.ModifyDataGridStyle(this.myDataGrid1, 0);

            string[] GrdMappingName2 ={ "����", "����", "��������", "����ҽ��", "����ҽ��", "����ʿ", "�����˵�", "id", "bed_dept_id", "isPLUS", "zz_doc", "zy_doc", "CHARGENURSE", "hoitem_id", "inpatient_id" };
            int[] GrdWidth2 ={ 4, 5, 20, 8, 8, 8, 30, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Alignment2 ={ 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly2 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName2, GrdWidth2, Alignment2, ReadOnly2, this.myDataGrid2);
            myFunc.InitGrid(GrdMappingName2, GrdWidth2, Alignment2, ReadOnly2, this.myDataGrid4);
            PubStaticFun.ModifyDataGridStyle(this.myDataGrid2, 0);
            PubStaticFun.ModifyDataGridStyle(this.myDataGrid4, 0);

            string[] GrdMappingName3 ={ "��������", "�����", "����", "����", "סԺ��", "�Ա�", "����", "inpatient_id", "assign_id" };
            int[] GrdWidth3 ={ 10, 6, 6, 16, 10, 4, 12, 0, 0 };
            int[] Alignment3 ={ 0, 1, 1, 1, 1, 1, 0, 0, 0 };
            int[] ReadOnly3 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName3, GrdWidth3, Alignment3, ReadOnly3, this.myDataGrid3);
            PubStaticFun.ModifyDataGridStyle(this.myDataGrid3, 0);
        }

        private void ShowData(object sender, System.EventArgs e)
        {
            string sSql;
            string sFlag = this.cbCYZH.Checked ? "5" : "1";  //1 ���䴲λ 5 �����Ժ
            string sLY = this.cbCYZH.Checked ? "��Ժ�ٻ�" : "����Ժ";
            string sZH = this.cbCYZH.Checked ? "1" : "2";
            if (this.cbMYTS.Checked)
            {
                //ֻ��Ӥ��
                sSql = @"select  convert (varchar , in_date,20  ) as ��Ժ����,out_date as ��Ժ����,inpatient_no as סԺ��,x.babyname as ����,x.baby_no as Ӥ����, " +
                    "         case when sex=1 then '��' else 'Ů' end as �Ա�, " +
                    "         dbo.FUN_ZY_SEEKDEPTNAME(x.dept_id) as ��������," +
                    "         case when y.zkcs is null or 1=" + sZH + " then '" + sLY + "' else 'ת��'end as ������Դ," +
                    "         x.inpatient_id as ID,dept_id as pat_in_dept,x.inpatient_id,x.baby_id " +
                    "    from (select inpatient_no,babyname,baby_id,baby_no,sex,in_date,out_date,inpatient_id,dept_id " +
                    "          from zy_inpatient_baby " +
                    "          where flag=" + sFlag +
                    "          and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' )) x " +
                    //ֻҪת�ɹ���,�����Ƿ�ȡ��,�����ת��,���ı䲡����Ժ���� Modify By tany 2009-10-28
                    //"  left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where cancel_bit=0 and finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    "  left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    "   order by in_date ";
            }
            else
            {
                sSql = @"select convert (varchar , in_date,20  ) as ��Ժ����,out_date as ��Ժ����,inpatient_no as סԺ��,x.name as ����,x.baby_no as Ӥ����, " +
                    "         case when sexcode=1 then '��' else 'Ů' end as �Ա�, " +
                    "         dbo.FUN_ZY_SEEKDEPTNAME(x.dept_id) as ��������," +
                    "         case when y.zkcs is null or 1=" + sZH + " then '" + sLY + "' else 'ת��'end as ������Դ," +
                    "         x.inpatient_id as ID,dept_id as pat_in_dept,x.inpatient_id,x.baby_id " +
                    "    from (select inpatient_no,name,0 baby_id,0 baby_no,sexcode,in_date,out_date,inpatient_id,dept_id " +
                    "          from vi_zy_vinpatient a " +
                    "          where flag=" + sFlag +
                    "                and a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' ) " +
                    "          union all " +
                    "          select inpatient_no,babyname,baby_id,baby_no,sex,in_date,out_date,inpatient_id,dept_id " +
                    "          from zy_inpatient_baby " +
                    "          where flag=" + sFlag +
                    "                and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' )) x " +
                    //ֻҪת�ɹ���,�����Ƿ�ȡ��,�����ת��,���ı䲡����Ժ���� Modify By tany 2009-10-28
                    //"    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where cancel_bit=0 and finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    "    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    "   order by in_date ";
            }
            //this.myDataGrid1.DataSource = FrmMdiMain.Database.GetDataTable(sSql);
            myFunc.ShowGrid(0, sSql, this.myDataGrid1, 0);

            if (this.cbMYTS.Checked)
            {
                //sSql = "select a.Room_no as ����,a.Bed_No as ����,dbo.FUN_ZY_SEEKDEPTNAME(a.dept_id) as ��������, dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zz_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zy_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.CHARGENURSE) as ����ʿ,h.order_name as �����˵�, a.bed_id as id,a.dept_id as bed_dept_id,a.isPLUS,a.zz_doc,a.zy_doc, a.CHARGENURSE,a.hoitem_id,a.inpatient_id" +
                //    "  from zy_BedDiction a left join jc_hoitemdiction     h on h.order_id=a.hoitem_id,zy_inpatient_baby i" +
                //    " where a.inpatient_id=i.inpatient_id and a.baby_id=0 and (a.dept_id=i.dept_id or  a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' )  )" +//Ӥ��  ͬ�����Ŀ����� Modify by zouchihua ���� 2012-10-23
                //    "       and i.flag=" + sFlag + " and i.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' ) " +
                //    " order by a.Room_no, dbo.Fun_GetBedToOrder(a.Bed_No) ";

                //Modify by pengy 2014-11-21
                sSql = "select a.Room_no as ����,a.Bed_No as ����,dbo.FUN_ZY_SEEKDEPTNAME(a.dept_id) as ��������, dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zz_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zy_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.CHARGENURSE) as ����ʿ,h.order_name as �����˵�, a.bed_id as id,a.dept_id as bed_dept_id,a.isPLUS,a.zz_doc,a.zy_doc, a.CHARGENURSE,a.hoitem_id,a.inpatient_id" +
                  "  from zy_BedDiction a left join jc_hoitemdiction     h on h.order_id=a.hoitem_id,zy_inpatient_baby i" +
                  " where a.inpatient_id=i.inpatient_id and a.baby_id=0 and (a.dept_id=i.dept_id or  a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' )  )" +//Ӥ��  ͬ�����Ŀ����� Modify by zouchihua ���� 2012-10-23
                  "       and i.flag=" + sFlag + " and i.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' ) " +
                  " order by case when isnumeric(a.Room_no)=1 then convert(bigint,a.room_no) else 99999 end,a.room_no,case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end,a.bed_no";//Modify By Tany 2015-02-09 �����ٰ�����
            }
            else
            {
                //Modify by Tany 2005-02-24
                //����ͣ�ñ�־
                //sSql = "select a.Room_no as ����,a.Bed_No as ����,dbo.FUN_ZY_SEEKDEPTNAME(a.dept_id) as ��������, dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zz_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zy_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.CHARGENURSE) as ����ʿ,h.order_name as �����˵�, a.bed_id as id,a.dept_id as bed_dept_id,a.isPLUS,a.zz_doc,a.zy_doc, a.CHARGENURSE,a.hoitem_id,a.inpatient_id" +
                //    "  from zy_BedDiction a left join jc_hoitemdiction     h on h.order_id=a.hoitem_id" +
                //    " where a.isinuse=0 and a.inpatient_id is null and a.isbf=0" +
                //    "       and a.ward_id ='" + InstanceForm.BCurrentDept.WardId + "'" +
                //    " order by a.Room_no,dbo.Fun_GetBedToOrder(a.Bed_No) ";


                //Modify by pengy 2014-11-21
                sSql = "select a.Room_no as ����,a.Bed_No as ����,dbo.FUN_ZY_SEEKDEPTNAME(a.dept_id) as ��������, dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zz_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zy_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.CHARGENURSE) as ����ʿ,h.order_name as �����˵�, a.bed_id as id,a.dept_id as bed_dept_id,a.isPLUS,a.zz_doc,a.zy_doc, a.CHARGENURSE,a.hoitem_id,a.inpatient_id" +
                        "  from zy_BedDiction a left join jc_hoitemdiction     h on h.order_id=a.hoitem_id" +
                        " where a.isinuse=0 and a.inpatient_id is null and a.isbf=0" +
                        "       and a.ward_id ='" + InstanceForm.BCurrentDept.WardId + "'" +
                        " order by case when isnumeric(a.Room_no)=1 then convert(bigint,a.room_no) else 99999 end,a.room_no,case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end,a.bed_no";//Modify By Tany 2015-02-09 �����ٰ�����
            }
            myFunc.ShowGrid(0, sSql, this.myDataGrid2, 0);
            myFunc.ShowGrid(0, sSql, this.myDataGrid4, 0);

            //�ѷ��䴲λ��Ϣ
            sSql = "select dbo.fun_getdate(b.assign_date) ��������,a.room_no �����,a.bed_no ����,a.cur_dept_name ����,a.inpatient_no סԺ��," +
                "a.sex_name �Ա�,a.name ����,a.inpatient_id,assign_id from vi_zy_vinpatient_bed a,zy_bed_assign b " +
                "where a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id and a.baby_id=0 and b.stop_date is null and b.stop_user is null " +
                "and a.ward_id='" + InstanceForm.BCurrentDept.WardId + "'order by case when isnumeric(a.Room_no)=1 then convert(bigint,a.room_no) else 99999 end,a.room_no,case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end,a.bed_no";
            //myFunc.ShowGrid(0, sSql, this.myDataGrid3, 0);
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);
            if (myTb != null && myTb.Rows.Count > 0)
            {
                Dictionary<int, DataRow> dict = new Dictionary<int, DataRow>();
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (!dict.ContainsKey(i))
                    {
                        string rq = myTb.Rows[i]["��������"].ToString().Trim();
                        string fjh = myTb.Rows[i]["�����"].ToString().Trim();
                        string ch = myTb.Rows[i]["����"].ToString().Trim();
                        string xm = myTb.Rows[i]["����"].ToString().Trim();
                        string zyh = myTb.Rows[i]["סԺ��"].ToString().Trim();
                        string inpatient_id = myTb.Rows[i]["inpatient_id"].ToString().Trim();
                        for (int x = 0; x < myTb.Rows.Count; x++)
                        {
                            if (i != x && !dict.ContainsKey(x))
                            {
                                string rq1 = myTb.Rows[x]["��������"].ToString().Trim();
                                string fjh1 = myTb.Rows[x]["�����"].ToString().Trim();
                                string ch1 = myTb.Rows[x]["����"].ToString().Trim();
                                string xm1 = myTb.Rows[x]["����"].ToString().Trim();
                                string zyh1 = myTb.Rows[x]["סԺ��"].ToString().Trim();
                                string inpatient_id1 = myTb.Rows[x]["inpatient_id"].ToString().Trim();

                                if (rq == rq1 && fjh == fjh1 && ch == ch1 && xm == xm1 && zyh == zyh1 && inpatient_id == inpatient_id1)
                                {
                                    dict.Add(x, myTb.Rows[x]);
                                    break;
                                }
                            }
                        }
                    }
                }
                if (dict.Count > 0)
                {
                    foreach (KeyValuePair<int, DataRow> tmp in dict)
                        myTb.Rows.Remove(tmp.Value);
                }
            }
            myDataGrid3.BeginInit();
            myDataGrid3.DataSource = myTb;
            myDataGrid3.EndInit();
            myDataGrid3.TableStyles[0].RowHeaderWidth = 5;
            PubStaticFun.ModifyDataGridStyle(myDataGrid3, 0);


            DataTable myTb1 = (DataTable)this.myDataGrid1.DataSource;
            if (myTb1.Rows.Count == 0)
            {
                this.btOK.Enabled = false;
                this.btUse.Enabled = false;
                return;
            }
            else this.myDataGrid1_CurrentCellChanged(sender, e);


            DataTable myTb2 = (DataTable)this.myDataGrid2.DataSource;
            if (myTb2.Rows.Count == 0)
            {
                this.btOK.Enabled = false;
                this.btUse.Enabled = false;
                return;
            }
            else this.myDataGrid2_CurrentCellChanged(sender, e);

            this.btOK.Enabled = true;
            this.btUse.Enabled = true;

        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            //û�д�λ�Ĳ���
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb.Rows.Count == 0) return;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            this.myDataGrid1.Select(nrow);
            this.lblPatient.Tag = myTb.Rows[nrow]["�Ա�"].ToString();
            this.lblPatient.Text = myTb.Rows[nrow]["����"].ToString();
            ClassStatic.Current_BinID = new Guid(myTb.Rows[nrow]["ID"].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(myTb.Rows[nrow]["baby_id"].ToString());
            ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[nrow]["pat_in_dept"].ToString());
            //			this.DtpbeginDate.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase); 
            //Modify by Zouchihua 
        }

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            if (myTb.Rows.Count == 0) return;
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);
            this.lblBed.Tag = myTb.Rows[nrow]["ID"].ToString();
            this.Room_NO = myTb.Rows[nrow]["����"].ToString();
            this.lblBed.Text = myTb.Rows[nrow]["����"].ToString();
            this.bed_DeptID = Convert.ToInt64(myTb.Rows[nrow]["bed_dept_id"]);
            this.isPLUS = Convert.ToInt16(myTb.Rows[nrow]["isPLUS"]);
            //			this.DtpbeginDate.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);     		
        }


        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            this.DtpbeginDate.Enabled = this.checkBox1.Checked;
        }

        private void cbMYTS_Click(object sender, System.EventArgs e)
        {
            if (this.cbMYTS.Checked)
            {
                this.cbCWF.Checked = false;
                this.cbCWF.Enabled = false;
                this.cbBF.Checked = false;
                this.cbBF.Enabled = false;
                this.myDataGrid2.CaptionText = "Ӥ��ĸ�״�λ";
            }
            else
            {
                this.cbBF.Checked = false;
                this.cbBF.Enabled = true;
                this.cbCWF.Checked = true;
                this.cbCWF.Enabled = true;
                this.myDataGrid2.CaptionText = "�մ�";
            }
            this.ShowData(sender, e);
        }

        private void cbCYZH_Click(object sender, System.EventArgs e)
        {
            if (this.cbCYZH.Checked)
            {
                this.myDataGrid1.CaptionText = "�����Ժ�Ĳ���";
            }
            else
            {
                this.myDataGrid1.CaptionText = "δ���䴲λ�Ĳ���";
            }
            cbCWF.Checked = !cbCYZH.Checked;
            this.ShowData(sender, e);
        }

        /// <summary>
        /// ���漲�������䣬�Ա�
        /// </summary>
        /// <param name="inpatientid"></param>
        /// <param name="oldjslx"></param>
        /// <param name="oldyblx"></param>
        /// <param name="newjslx"></param>
        /// <param name="newyblx"></param>
        /// <param name="type">0 ���� 1 ���� 2 �Ա�</param>
        private void SaveAllInpatientLog(Guid inpatientid, string oldstr, string newstr, int type)
        {
            try
            {
                string sql = "insert into ZY_ALLINPATIENT_LOG(INPATIENT_ID, OLD_STR, NEW_STR, TYPE, BOOK_DATE, BOOK_USER, IP, PCNAME)";
                sql += "values ('" + inpatientid + "','" + oldstr + "','" + newstr + "'," + type + ",getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",'" + Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString() + "','" + System.Environment.MachineName + "')";
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch (Exception err)
            {
                MessageBox.Show("���没�˵ǼǱ����Ϣʱ����" + err.Message);
            }
        }
        private void btOK_Click(object sender, System.EventArgs e)
        {

            Cursor.Current = PubStaticFun.WaitCursor();

            string sFlag = "";
            string sSql = "";
            string _outmsg = "";
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty) return;
            if (this.lblBed.Tag.ToString().Trim() == "" || this.lblBed.Tag == null) return;
            int isInput_ZD = this.cbCWF.Checked == true ? 0 : 1;

            DataTable myTb = new DataTable();
            //����
            DataTable myTb1 = (DataTable)this.myDataGrid1.DataSource;
            //��λ
            DataTable myTb2 = (DataTable)this.myDataGrid2.DataSource;

            #region �������䴲λʱ��������Ժ�Ǽ����ڲ�Ϊͬһ�죬�򵯳���Ϣ��ʾ��ǿ�ƻ�ʿ�޸���ס����
            //add by yaokx 2014-04-23�������䴲λʱ��������Ժ�Ǽ����ڲ�Ϊͬһ�죬�򵯳���Ϣ��ʾ��ǿ�ƻ�ʿ�޸���ס����
            if (myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["������Դ"].ToString().Trim() == "����Ժ")
            {
                if (Convert.ToDateTime(myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["��Ժ����"].ToString().Trim()).ToString("yyyy-MM-dd") != DtpbeginDate.Value.ToString("yyyy-MM-dd"))
                {
                    if (new SystemCfg(7193).Config == "1")
                    {
                        if (MessageBox.Show(this, "�Բ��𣬸ò�����ס��������Ժ���ڲ���ͬһ�죬�Ƿ�������䴲λ��", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                    else if (new SystemCfg(7193).Config == "2" && !this.checkBox1.Checked)
                    {
                        MessageBox.Show("��ס��������Ժ���ڲ���ͬһ�죬���޸���ס����", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            #endregion

            //Modify By Tany 2011-03-30 ���������Ժ����ѡ���޸���Ժʱ��Ÿ�
            int isUpdate = 1;
            if (myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["������Դ"].ToString().Trim() == "����Ժ" && checkBox1.Checked)
            {
                isUpdate = 0;
                //add by zouchihua 2012-5-4 ����Ժ���ڵ�
                if (Convert.ToDateTime(Convert.ToDateTime(myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["��Ժ����"].ToString().Trim()).ToShortDateString()) > DtpbeginDate.Value)
                {
                    MessageBox.Show("�޸���ס���ڲ���С����Ժ���ڣ����޸����ں����²�������", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //������Ժʱ����޸ĵ���־��¼add by zouchihua 2013-3-13
                SaveAllInpatientLog(new Guid(myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["inpatient_id"].ToString()), myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["��Ժ����"].ToString(),
                    DtpbeginDate.Value.ToString(), 5);
            }
            int isTmpIn = 1;//0=��ʱ��ס ״̬4��1=��ס ״̬3

            #region ��Ժ�ٻ���Ч���жϣ��ж��Ƿ����Ѿ������ҽ������ Add By Tany 2005-01-05
            if (cbCYZH.Checked)
            {
                #region �Ƿ񳬹��ٻص����ڲ��������ж��ˣ����ں���
                /*
				//�ж��Ƿ񳬹��ٻص�����
				string sDays=myFunc.GetConfig("cname","��Ժ�ٻ��������");
				sDays=sDays.Trim()==""?"0":sDays;
				
				string rDays=Convert.ToInt64("select current date - date(out_date) from zy_inpatient where inpatient_id="+ClassStatic.Current_BinID);
				rDays=rDays.Trim()==""?"0":rDays;

				if(Convert.ToInt32(sDays)<Convert.ToInt32(rDays))
				{
					MessageBox.Show("�ò����Ѿ���Ժ "+rDays+" �죬���ܳ�Ժ�ٻأ�","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}
				*/
                #endregion

                #region add by zouchihua 2014-7-27 ����תδ���ж�
                string sql_zwj = "select * from ZY_INPATIENT_SUPPLY where  inpatient_id='" + ClassStatic.Current_BinID + "' and  ISNULL(UnsettledState,0)>0";
                DataTable tbzwj = FrmMdiMain.Database.GetDataTable(sql_zwj);
                if (tbzwj.Rows.Count > 0)
                {
                    MessageBox.Show("ϵͳ�Ѿ�����תδ���㲡�˲����ٻ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                //�ж��Ƿ����Ѿ������ҽ������
                //Ӥ�����ж�
                if (ClassStatic.Current_BabyID == 0)
                {
                    //Modify By Tany 2010-03-02 7064ҽ��������˳�Ժ���Ƿ������Ժ�ٻ� 0=���� 1=��
                    if (new SystemCfg(7064).Config == "0")
                    {
                        DataRow ybrow = FrmMdiMain.Database.GetDataRow("select cysh from zy_yb_shxx where inpatient_id='" + ClassStatic.Current_BinID + "' and delete_bit=0 ");
                        if (ybrow != null && Convert.ToInt16(ybrow["cysh"]) == 1)
                        {
                            MessageBox.Show("�ò����Ѿ���ҽ������˳�Ժ�����ܳ�Ժ�ٻأ�����ϵҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    sSql = "select dischargetype,inpatient_no,is_ybjs from vi_zy_vinpatient where inpatient_id='" + ClassStatic.Current_BinID + "'";
                    myTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    //ҽ������
                    if (/*myTb.Rows[0]["dischargetype"].ToString().Trim()=="1" && */myTb.Rows[0]["is_ybjs"].ToString().Trim() == "1")
                    {
                        #region ���� Modify By Tany 2005-01-07
                        /*
						try
						{
							System.Data.SqlClient.SqlCommand SqlCmd = new System.Data.SqlClient.SqlCommand();
							System.Data.SqlClient.SqlDataAdapter SqlApt = new System.Data.SqlClient.SqlDataAdapter();

							sSql="select count(*) from sic_ylqkb where zybz=1 and cysj is not null and "+
								"serial_no=(select max(serial_no) from sic_ylqkb where zyh='"+myTb.Rows[0]["inpatient_no"].ToString().Substring(2)+"')";

							DataTable tmpTb = new DataTable();
							SqlCmd.CommandText=sSql;
							SqlCmd.CommandType=CommandType.Text;
							SqlCmd.Connection=BaseFun.YbConnect; //����ҽ��������
							SqlApt.SelectCommand=SqlCmd;
							SqlApt.Fill(tmpTb);

							if(tmpTb.Rows[0][0].ToString().Trim()!="0")
							{
								MessageBox.Show("�ò�����ҽ�������Ѿ����㣬���ܳ�Ժ�ٻأ�����ϵסԺ��","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Stop);
								BaseFun.CloseYbConnect();
								return;
							}

							BaseFun.CloseYbConnect();
						}
						catch(Exception err)
						{
							MessageBox.Show("����"+err.Message+"\n"+"Source��"+err.Source+"\n\n����ϵ��Ϣ�ƣ�","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
							BaseFun.CloseYbConnect();
							return;
						}
						*/
                        #endregion

                        MessageBox.Show("�ò�����ҽ�������Ѿ����㣬���ܳ�Ժ�ٻأ�����ϵҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //Add By Tany 2015-04-28 �����ж���ϵͳ�����״̬
                    if (TrasenHIS.BLL.CheckPatientInfo.isCysh(myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["סԺ��"].ToString()))
                    {
                        MessageBox.Show("�ò�����סԺ���Ѿ���ˣ����ܳ�Ժ�ٻأ�����ϵסԺ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            #endregion

            //��λ��Ч���ж�
            //Add By Tany 2005-02-24
            string isInuse = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select isinuse from zy_beddiction where bed_id='" + lblBed.Tag + "'"), "");
            if (isInuse == "1")
            {
                MessageBox.Show("���Ŵ�λ�Ѿ���ͣ�ã�������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData(sender, e);
                return;
            }

            //ĸӤͬ��
            if (this.cbMYTS.Checked)
            {
                if (myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["inpatient_id"].ToString().Trim() != myTb2.Rows[this.myDataGrid2.CurrentCell.RowNumber]["inpatient_id"].ToString().Trim())
                {
                    MessageBox.Show(this, "�Բ���Ŀ�괲ס�Ĳ��Ǹ�Ӥ����ĸ�ף�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if ((Convert.ToInt16(ClassStatic.Current_BabyID) > 0))//isCK && Modify By Tany 2011-03-07 ���е�Ӥ�������ܵ����ִ�
            {
                //if(MessageBox.Show(this, "ȷ��Ϊ��Ӥ���������䴲λ��", "ȷ��", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) 
                MessageBox.Show(this, "Ӥ�����ܵ������䴲λ����ѡ��ĸӤͬ�ң�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(this, "�Ƿ�ȷ�Ͻ� " + lblPatient.Text + " ���˷��䵽 " + lblBed.Text + " �Ŵ���", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //Modify by jchl
            if (cbCWF.Checked)
            //if (cfg7600.Config.Trim().Equals("1"))
            {
                //�޸Ĵ�λ���жϷ�ʽ Modify By Tany 2010-04-26

                //��λ��HOITEM_ID
                //SystemCfg cfg = new SystemCfg(7024);
                //string _hoitemID = cfg.Config;
                //if (_hoitemID.Trim() == "") _hoitemID = "0";

                //���Ƿ���δֹͣ�Ĵ�λ�˵�
                sSql = @"select 1 from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID.ToString() + "'" +
                    " and baby_id=" + ClassStatic.Current_BabyID.ToString() + " and mngtype=2 and status_flag=2 " +
                    " and delete_bit=0 and hoitem_id in (select order_id from jc_hsitemdiction a  " +
                    " inner join jc_hoi_hdi b on a.item_id=b.hditem_id " +
                    " inner join jc_hoitemdiction c on b.hoitem_id=c.order_id " +
                    " where a.statitem_code in (" + new SystemCfg(7029).Config + "))";
                DataTable tmpbedTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (tmpbedTb.Rows.Count > 0)
                {
                    if (MessageBox.Show(this, "������δֹͣ�Ĵ�λ�ѳ����˵����Ƿ�Ҫ�Զ����ɴ�λ�ѳ����˵���", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        isInput_ZD = 1;
                    }
                }
            }

            //����һ�����ж�,�Ӵ�����
            if ((Convert.ToInt64(ClassStatic.Current_DeptID) != this.bed_DeptID) && (this.isPLUS == 0))
            {
                if (MessageBox.Show(this, "���˿����봲λ���Ҳ�һ�£��Ƿ�ȷ�Ϸ��䣿", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            if (cbCYZH.Checked)
            {
                DialogResult dr = MessageBox.Show(this, "�Ƿ���ʱ�ٻز��ˣ�\n���ǣ����ֲ��˵ĳ�Ժ״̬ | �񣺽�ɾ����Ժҽ����", "��ʾ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dr == DialogResult.Yes)
                {
                    isTmpIn = 0;
                    SystemCfg cfg7208 = new SystemCfg(7208);//yaokx 2014-07-08��ʱ�ٻ�ҲҪ�в��������ٻ�����
                    if (cfg7208.Config == "1")
                    {
                        SystemCfg cfg = new SystemCfg(7003);
                        string sDays = cfg.Config;
                        sDays = sDays.Trim() == "" ? "0" : sDays;

                        string rDays = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select datediff(dd,out_date,getdate()) from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"), "0");
                        rDays = rDays.Trim() == "" ? "0" : rDays;

                        if (Convert.ToInt32(sDays) < Convert.ToInt32(rDays))
                        {
                            MessageBox.Show("�ò����Ѿ���Ժ " + rDays + " �죬��Ժ�ٻ����������:" + sDays + "��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                else if (dr == DialogResult.No)
                {
                    isTmpIn = 1;

                    //ֻ�������ٻز��ж��Ƿ񳬹��ٻص�����
                    SystemCfg cfg = new SystemCfg(7003);
                    string sDays = cfg.Config;
                    sDays = sDays.Trim() == "" ? "0" : sDays;

                    string rDays = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select datediff(dd,out_date,getdate()) from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"), "0");
                    rDays = rDays.Trim() == "" ? "0" : rDays;

                    if (Convert.ToInt32(sDays) < Convert.ToInt32(rDays))
                    {
                        MessageBox.Show("�ò����Ѿ���Ժ " + rDays + " �죬ֻ����ʱ�ٻأ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            if (this.cbBF.Checked)
            {
                //�ǰ������жϷ����Ƿ��ǼӴ�
                if (this.isPLUS == 1)
                {
                    MessageBox.Show(this, "�Բ��𣬼Ӵ������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //�жϷ����Ƿ���ס��
                sSql = @"select * from zy_BedDiction " +
                    " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                    "   and room_no='" + this.Room_NO + "'" +
                    "   and inpatient_id is not null";
                DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tempTab.Rows.Count > 0)
                {
                    MessageBox.Show(this, "�Բ���" + this.Room_NO + "�ŷ�����ס�ˣ������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //�ٴ��жϲ���״̬�Ƿ��������� Add By Tany 2005-04-26
                sSql = "select flag from vi_zy_vinpatient_info where inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')";
                DataTable patTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (patTb == null || patTb.Rows.Count == 0)
                {
                    MessageBox.Show("�Բ���û���ҵ�������Ϣ�����ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData(null, null);
                    return;
                }
                else
                {
                    sFlag = patTb.Rows[0][0].ToString().Trim();//Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select flag from vi_zy_vinpatient_all where inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID).ToString(),"");
                    if (sFlag == "2" || sFlag == "6" || sFlag == "10")
                    {
                        MessageBox.Show("�Բ��𣬲����Ѿ����������Ϣ��ɾ�������ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowData(null, null);
                        return;
                    }
                }

                //ģʽ2Ϊ�������䴲λ			
                _outmsg = myFunc.AssignBed("", 2, new Guid(this.lblBed.Tag.ToString()), Convert.ToInt64(ClassStatic.Current_DeptID), ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), Convert.ToString(this.lblPatient.Tag), this.Room_NO, 1, 0, this.DtpbeginDate.Value, InstanceForm.BCurrentUser.EmployeeId, isInput_ZD, isUpdate, isTmpIn, FrmMdiMain.Jgbm);
            }
            else
            {
                //�ǲ�����
                if (this.cbMYTS.Checked)
                {
                    //�ٴ��жϲ���״̬�Ƿ��������� Add By Tany 2005-04-26
                    sSql = "select flag from vi_zy_vinpatient_info where inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')";
                    DataTable patTb = InstanceForm.BDatabase.GetDataTable(sSql);

                    if (patTb == null || patTb.Rows.Count == 0)
                    {
                        MessageBox.Show("�Բ���û���ҵ�������Ϣ�����ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowData(null, null);
                        return;
                    }
                    else
                    {
                        sFlag = patTb.Rows[0][0].ToString().Trim();//Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select flag from vi_zy_vinpatient_all where inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID).ToString(),"");
                        if (sFlag == "2" || sFlag == "6" || sFlag == "10")
                        {
                            MessageBox.Show("�Բ��𣬲����Ѿ����������Ϣ��ɾ�������ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowData(null, null);
                            return;
                        }
                    }

                    //ģʽ3ΪĸӤͬ�ҷ��䴲λ
                    _outmsg = myFunc.AssignBed("", 3, new Guid(this.lblBed.Tag.ToString()), Convert.ToInt64(ClassStatic.Current_DeptID), ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), Convert.ToString(this.lblPatient.Tag), this.Room_NO, 0, 0, this.DtpbeginDate.Value, InstanceForm.BCurrentUser.EmployeeId, isInput_ZD, isUpdate, isTmpIn, FrmMdiMain.Jgbm);
                }
                else
                {
                    //ͬһ�����Ա��ж�
                    string s = this.lblPatient.Tag.ToString().Trim();
                    if (s != "") s = (s == "��" ? "Ů" : "��");
                    sSql = @"select * from zy_BedDiction " +
                        " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                        "   and room_no='" + this.Room_NO + "'" +
                        "   and bedsex='" + s + "'";
                    DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (tempTab.Rows.Count > 0)
                    {
                        if (MessageBox.Show(this, "�÷���ס��" + s + "�Բ��ˣ��Ƿ�ȷ�Ϸ��䣿", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }

                    //�ٴ��жϲ���״̬�Ƿ��������� Add By Tany 2005-04-26
                    sSql = "select flag from vi_zy_vinpatient_info where inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')";
                    DataTable patTb = InstanceForm.BDatabase.GetDataTable(sSql);

                    if (patTb == null || patTb.Rows.Count == 0)
                    {
                        MessageBox.Show("�Բ���û���ҵ�������Ϣ�����ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowData(null, null);
                        return;
                    }
                    else
                    {
                        sFlag = patTb.Rows[0][0].ToString().Trim();//Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select flag from vi_zy_vinpatient_all where inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID).ToString(),"");
                        if (sFlag == "2" || sFlag == "6" || sFlag == "10")
                        {
                            MessageBox.Show("�Բ��𣬲����Ѿ����������Ϣ��ɾ�������ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowData(null, null);
                            return;
                        }
                    }

                    //ģʽ1Ϊ���������䴲λ
                    _outmsg = myFunc.AssignBed("", 1, new Guid(this.lblBed.Tag.ToString()), Convert.ToInt64(ClassStatic.Current_DeptID), ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), Convert.ToString(this.lblPatient.Tag), this.Room_NO, 0, 0, this.DtpbeginDate.Value, InstanceForm.BCurrentUser.EmployeeId, isInput_ZD, isUpdate, isTmpIn, FrmMdiMain.Jgbm);
                }
            }

            //�Ѿ��ĵ���̨ Modify By Tany 2006-12-07
            //			//���������ʱ�ٻأ��ѳ�Ժҽ��ɾ�� Add By Tany 2004-11-15
            //			if(cbCYZH.Checked && isTmpIn==1)
            //			{
            //				sSql="update zy_orderrecord set delete_bit=1,memo='��Ժ�ٻ�ɾ��'||ltrim(rtrim(char(getdate())))||' By '||'"+InstanceForm.BCurrentUser.EmployeeId+"' where ntype=0 and (order_context like '%��Ժ%' or order_context like '%����%') and inpatient_id="+Convert.ToInt64(ClassStatic.Current_BinID);
            //				InstanceForm.BDatabase.DoCommand(sSql);
            //			}
            //
            //			//Add By Tany 2004-11-26
            //			//ɾ����Ժ���
            //			sSql="DELETE FROM zy_lvhsrecord WHERE INPATIENT_ID="+ClassStatic.Current_BinID;
            //			InstanceForm.BDatabase.DoCommand(sSql);

            string OperType = "";

            if (cbMYTS.Checked)
                OperType = "���䴲λĸӤͬ��";
            else if (cbCYZH.Checked)
                OperType = "��Ժ�ٻ�" + (isTmpIn == 0 ? "(��ʱ)" : "(��ʽ)");
            else
                OperType = "���䴲λ";

            if (isTmpIn != 0)
            {
                //���ӳ�Ժʱ����޸ĵ���־��¼add by zouchihua 2013-3-13
                SaveAllInpatientLog(new Guid(myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["inpatient_id"].ToString()), myTb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["��Ժ����"].ToString(),
                    DtpbeginDate.Value.ToString(), 10);
            }
            //д��־ Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, Convert.ToInt64(ClassStatic.Current_DeptID), InstanceForm.BCurrentUser.EmployeeId, OperType, _outmsg + "�� " + lblPatient.Text + " ���˷��䵽 " + lblBed.Text + " �Ŵ�", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            if (_outmsg.Trim() != "")
            {
                MessageBox.Show(_outmsg);
            }

            Button bt = (Button)sender;
            if (bt.Text.Trim().Substring(0, 2) == "ȷ��")
            {
                this.Close();
            }
            else
            {
                this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
                this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);                      //��������ǰϵͳ����
                this.checkBox1.Checked = false;
                this.ShowData(sender, e);
            }

            Cursor.Current = Cursors.Default;
        }

        private void myDataGrid3_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.myDataGrid3.Select(myDataGrid3.CurrentCell.RowNumber);
        }

        private void myDataGrid4_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.myDataGrid4.Select(myDataGrid4.CurrentCell.RowNumber);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            string _outmsg = "";
            DataTable myTb = new DataTable();
            myTb = (DataTable)myDataGrid3.DataSource;

            if (MessageBox.Show(this, "�Ƿ����Ҫȡ�� " + myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["����"].ToString().Trim() + " ������ " + myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["����"].ToString().Trim() + " �Ĵ�λ������Ϣ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            _outmsg = myFunc.CancelAssignBed("", new Guid(myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["inpatient_id"].ToString()), new Guid(myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["assign_id"].ToString()), InstanceForm.BCurrentUser.EmployeeId);
            //_outmsg = myFunc.CancelAssignBed("", new Guid(myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["inpatient_id"].ToString()), Guid.Empty, InstanceForm.BCurrentUser.EmployeeId);
            MessageBox.Show(_outmsg);

            //д��־ Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, Convert.ToInt64(ClassStatic.Current_DeptID), InstanceForm.BCurrentUser.EmployeeId, "ȡ�����䴲λ", _outmsg + "ȡ�� " + myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["����"].ToString().Trim() + " ������ " + myTb.Rows[myDataGrid3.CurrentCell.RowNumber]["����"].ToString().Trim() + " �Ĵ�λ������Ϣ", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            ShowData(sender, e);
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmFPCW_Activated(object sender, System.EventArgs e)
        {
            //add by zouchihua 2012-5-31���䴲λʱ���޸���Ժʱ���Ƿ�ֻ������Ȩ�޵��˲����޸�
            SystemCfg cfg7127 = new SystemCfg(7127);
            if (cfg7127.Config.Trim() == "1")
            {
                string sql = "select b.Name from Pub_Group_User a left join Pub_Group b  on a.Group_Id=b.Id left join Pub_User c on a.User_Id=c.Id "
                          + "  left join JC_EMPLOYEE_PROPERTY  d on c.Employee_Id=d.EMPLOYEE_ID  "
                          + " where d.EMPLOYEE_ID=" + FrmMdiMain.CurrentUser.EmployeeId + "";
                DataTable qxtb = FrmMdiMain.Database.GetDataTable(sql);
                int i = 0;
                for (i = 0; i < qxtb.Rows.Count; i++)
                {
                    if (qxtb.Rows[i]["Name"].ToString().Trim() == "�޸���Ժʱ����" || qxtb.Rows[i]["Name"].ToString().Trim() == "����Ա��")//����д����
                    {
                        this.checkBox1.Enabled = true;
                        break;
                    }
                }
                if (i == qxtb.Rows.Count)
                    this.checkBox1.Enabled = false;

            }
            else
                this.checkBox1.Enabled = true;
            frmFPCW_Load(null, null);
        }

        private void frmFPCW_Load_1(object sender, EventArgs e)
        {
            SystemCfg cfg5026 = new SystemCfg(5026);
            this.txtInpatNo.InpatientNoLength = Convert.ToInt32(cfg5026.Config.Trim());
            //add by zouchihua 2013-3-1
            SystemCfg cfg7141 = new SystemCfg(7141);
            if (cfg7141.Config.Trim() == "1")
                this.checkBox1.Checked = true;
            else
                this.checkBox1.Checked = false;

            SystemCfg cfg7205 = new SystemCfg(7205);//yaokx2014-0701
            if (cfg7205.Config == "1")
                cbMYTS.Text = "����ͬ��";

            //Modify By Tany 2015-01-13 ������Ա�ɼ��޸Ŀ���
            //groupBox5.Visible = FrmMdiMain.CurrentUser.IsAdministrator; Modify By Tany 2015-03-10 �ſ�
        }

        private void �޸Ĵ�λ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)myDataGrid2.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                int cfg = Convert.ToInt32(new SystemCfg(7058).Config);
                if (cfg != 1)
                {
                    MessageBox.Show("ϵͳ�����������޸Ĵ�λ�ѣ�");
                    return;
                }

                int nrow = myDataGrid2.CurrentRowIndex;

                string[] headText = new string[] { "����", "����", "����", "ƴ����", "�����", "������" };
                string[] mappName = new string[] { "id", "name", "price", "py_code", "wb_code", "code" };
                int[] colWidth = new int[] { 50, 200, 75, 50, 50, 50 };
                string[] searchFields = new string[] { "py_code", "wb_code" };

                string sql = "select order_id as ID,b.d_code as Code,order_name as name,b.py_code ,b.wb_code,c.price";
                sql += " from jc_hoi_hdi a inner join jc_hoitemdiction b on a.hoitem_id=b.order_id";
                sql += " inner join vi_jc_items c on a.hditem_id=c.itemid and a.tcid=c.tcid";
                sql += " where b.delete_bit=0 and c.bigitemcode in (" + (new SystemCfg(7029)).Config.Trim() + ") and c.jgbm=" + FrmMdiMain.Jgbm + " order by order_id";

                DataTable tableXm = InstanceForm.BDatabase.GetDataTable(sql);

                TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard(searchFields, headText, mappName, colWidth);
                selectCard.sourceDataTable = tableXm;
                selectCard.Width = 550;
                selectCard.Height = 200;
                selectCard.srcControl = myDataGrid2;
                selectCard.WorkForm = this;
                selectCard.ShowDialog();

                if (selectCard.DialogResult == DialogResult.OK)
                {
                    int _neworderid = Convert.ToInt32(selectCard.SelectDataRow["id"]);
                    string _newordername = selectCard.SelectDataRow["name"].ToString().Trim();

                    if (MessageBox.Show("�Ƿ� " + tb.Rows[nrow]["����"].ToString().Trim() + " ����λ�� [ " + tb.Rows[nrow]["�����˵�"].ToString().Trim() + " ] ���� [ " + _newordername + " ] ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }

                    sql = "update zy_beddiction set hoitem_id=" + _neworderid + " where bed_id='" + tb.Rows[nrow]["id"].ToString().Trim() + "'";
                    InstanceForm.BDatabase.DoCommand(sql);

                    frmFPCW_Load(null, null);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myDataGrid1.VisibleRowCount; i++)
            {
                this.myDataGrid1.UnSelect(i);
            }

            //Modify By Tany 2015-05-11 ���Ƿ��ҵ�������Ϣ
            bool isFind = false;
            if ((!(this.txtInpatNo.Text.Trim() == "" || Convert.ToInt64(this.txtInpatNo.Text.Trim()) == 0))
                || this.txtname.Text.Trim() != "")
            {
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    this.myDataGrid1.UnSelect(this.myDataGrid1.CurrentCell.RowNumber);
                    if (this.myDataGrid1[i, 2].ToString().Trim() == this.txtInpatNo.Text.Trim() || (this.txtname.Text.Trim().Trim() != "" && this.myDataGrid1[i, 3].ToString().Trim().IndexOf(this.txtname.Text.Trim()) >= 0))
                    {
                        //  this.myDataGrid1.CurrentRowIndex = i;

                        this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                        this.myDataGrid1.Select(i);
                        isFind = true;
                        break;
                    }

                }
            }

            //Modify BY Tany 2015-05-11 ���û�ҵ�������Ϣ������ʾһ�������������������
            if (!isFind)
            {
                string zyh = txtInpatNo.Text.Trim();
                string sql = "select * from vi_zy_vinpatient_all where inpatient_no='" + zyh + "' and baby_id=0";
                DataTable patTb = FrmMdiMain.Database.GetDataTable(sql);
                if (patTb == null || patTb.Rows.Count == 0)
                {
                    MessageBox.Show("δ�ҵ�סԺ��Ϊ��" + zyh + "���Ĳ�����Ϣ�����֤��");
                }
                else
                {
                    string msg = "�ҵ��ò�����Ϣ���£�\r\n\r\n";
                    msg += "סԺ�ţ�" + patTb.Rows[0]["inpatient_no"].ToString().Trim() + "\r\n";
                    msg += "������" + patTb.Rows[0]["name"].ToString().Trim() + "\r\n";
                    msg += "��Ժ���ڣ�" + patTb.Rows[0]["in_date"].ToString().Trim() + "\r\n";
                    msg += "��ǰ���ң�" + patTb.Rows[0]["cur_dept_name"].ToString().Trim() + "\r\n";
                    msg += "���ţ�" + patTb.Rows[0]["bed_no"].ToString().Trim() + "\r\n";
                    string zt = "";
                    switch (patTb.Rows[0]["flag"].ToString().Trim())
                    {
                        case "1":
                            zt = "���ִ�";
                            break;
                        case "2":
                        case "6":
                            zt = "�ѽ���";
                            break;
                        case "3":
                        case "4":
                            zt = "�ڴ�";
                            break;
                        case "5":
                            zt = "����";
                            break;
                        case "10":
                            zt = "ȡ����Ժ";
                            break;
                    }
                    msg += "״̬��" + zt + "\r\n";
                    MessageBox.Show(msg);
                }
            }
        }

        private void buttryks_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
                {
                    MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string s = "select isnull(SUM(ACVALUE),0)as ACVALUE  from ZY_FEE_SPECI where INPATIENT_ID='" + ClassStatic.Current_BinID + "'and DELETE_BIT=0 and CHARGE_BIT=1";

                DataRow drr = InstanceForm.BDatabase.GetDataRow(s);
                if (float.Parse(drr["ACVALUE"].ToString()) > 0)
                {
                    MessageBox.Show("�ò��˷������ã������޸�ת�����");
                    return;
                }
                Guid inpatient_id = ClassStatic.Current_BinID;
                FrmZk myfzk = new FrmZk(inpatient_id, lblPatient.Text);
                //fzk.ShowDialog();
                DialogResult dr = myfzk.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string str = RYZK(inpatient_id, myfzk.deptid.ToString().Trim());
                    if (str.Trim() != "")
                    {
                        MessageBox.Show(str);
                    }
                    else
                    {
                        MessageBox.Show("���á���Ժ���ҡ�ʧ��");
                    }
                    this.ShowData(sender, e);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public string RYZK(Guid inpatient_id, string dept_id)
        {
            try
            {
                string str = "";
                string sql = "UPDATE ZY_INPATIENT SET IN_DEPT=" + dept_id + ",DEPT_ID=" + dept_id + " WHERE INPATIENT_ID='" + inpatient_id + "'";

                int i = InstanceForm.BDatabase.DoCommand(sql);

                if (i > 0)
                    str = "���á���Ժ���ҡ��ɹ�";
                return str;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return "";
            }
        }

        private void txtInpatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button2_Click(null,null);
            }
        }
    }
}