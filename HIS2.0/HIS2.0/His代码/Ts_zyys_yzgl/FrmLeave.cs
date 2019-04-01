using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using TrasenClasses.DatabaseAccess;
using Ts_zyys_main;
using TrasenHIS.BLL;

namespace Ts_zyys_yzgl
{
    /// <summary>
    /// ��Ժ���� ��ժҪ˵����
    /// </summary>
    public class FrmLeave : System.Windows.Forms.Form
    {
        private DbQuery myQuery = new DbQuery();
        public User YS = null;
        public long YS_ID = 0;
        public long DeptID = 0;
        public string WardID = "";
        public Guid BinID = Guid.Empty;
        SystemCfg cfg30000 = new SystemCfg(30000);
        private DateTime timesever;
        public long BabyID = 0;
        public bool outType = false; //�Ƿ�����˳�Ժҽ��
        private DataTable dt;
        private DataTable diseaseTb = null;
        private TextBox TBox = new TextBox();
        private SystemCfg cfg6057;
        private int ybjklx = 0;
        private int yblx = 0;//Add By Tany 2015-04-28

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDiag;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label lblZyh;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTreat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtXY;
        private System.Windows.Forms.TextBox txtZY;
        private System.Windows.Forms.DataGrid GrdSel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numUD;
        private System.Windows.Forms.DateTimePicker dTimePicker1;
        private System.Windows.Forms.TextBox txtBZ;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radBt2;
        private System.Windows.Forms.RadioButton radBt1;
        private System.Windows.Forms.CheckBox chk_hsz;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private GroupBox groupBox3;
        private ComboBox comblyfs;
        private TextBox txtyljgmc;
        private Button btGetEmrDiagnosois;
        private Button btManyZD;
        private Label lblYbjbbm;
        private DataGridTextBoxColumn YBJBBM;
        private DataGridTextBoxColumn YBJBMC;
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmLeave()
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btManyZD = new System.Windows.Forms.Button();
            this.btGetEmrDiagnosois = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtyljgmc = new System.Windows.Forms.TextBox();
            this.comblyfs = new System.Windows.Forms.ComboBox();
            this.GrdSel = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.YBJBMC = new System.Windows.Forms.DataGridTextBoxColumn();
            this.YBJBBM = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.chk_hsz = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblYbjbbm = new System.Windows.Forms.Label();
            this.txtBZ = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtXY = new System.Windows.Forms.TextBox();
            this.txtZY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDiag = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.lblZyh = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numUD = new System.Windows.Forms.NumericUpDown();
            this.radBt2 = new System.Windows.Forms.RadioButton();
            this.radBt1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.dTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTreat = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btManyZD);
            this.panel1.Controls.Add(this.btGetEmrDiagnosois);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.GrdSel);
            this.panel1.Controls.Add(this.chk_hsz);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.numUD);
            this.panel1.Controls.Add(this.radBt2);
            this.panel1.Controls.Add(this.radBt1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dTimePicker1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbTreat);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 318);
            this.panel1.TabIndex = 0;
            // 
            // btManyZD
            // 
            this.btManyZD.Font = new System.Drawing.Font("����", 10.5F);
            this.btManyZD.Location = new System.Drawing.Point(482, 128);
            this.btManyZD.Name = "btManyZD";
            this.btManyZD.Size = new System.Drawing.Size(102, 27);
            this.btManyZD.TabIndex = 38;
            this.btManyZD.Text = "�����¼��";
            this.btManyZD.UseVisualStyleBackColor = true;
            this.btManyZD.Click += new System.EventHandler(this.btManyZD_Click);
            // 
            // btGetEmrDiagnosois
            // 
            this.btGetEmrDiagnosois.Font = new System.Drawing.Font("����", 10.5F);
            this.btGetEmrDiagnosois.Location = new System.Drawing.Point(483, 190);
            this.btGetEmrDiagnosois.Name = "btGetEmrDiagnosois";
            this.btGetEmrDiagnosois.Size = new System.Drawing.Size(101, 28);
            this.btGetEmrDiagnosois.TabIndex = 37;
            this.btGetEmrDiagnosois.Text = "��ȡEMR���";
            this.btGetEmrDiagnosois.UseVisualStyleBackColor = true;
            this.btGetEmrDiagnosois.Visible = false;
            this.btGetEmrDiagnosois.Click += new System.EventHandler(this.btGetEmrDiagnosois_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtyljgmc);
            this.groupBox3.Controls.Add(this.comblyfs);
            this.groupBox3.Location = new System.Drawing.Point(479, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 118);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "��Ժ��ʽ";
            // 
            // txtyljgmc
            // 
            this.txtyljgmc.Location = new System.Drawing.Point(6, 56);
            this.txtyljgmc.Name = "txtyljgmc";
            this.txtyljgmc.ReadOnly = true;
            this.txtyljgmc.Size = new System.Drawing.Size(175, 21);
            this.txtyljgmc.TabIndex = 1;
            // 
            // comblyfs
            // 
            this.comblyfs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comblyfs.FormattingEnabled = true;
            this.comblyfs.Items.AddRange(new object[] {
            "ҽ����Ժ",
            "ҽ��תԺ",
            "ҽ��ת���������������\\��������Ժ",
            "��ҽ����Ժ",
            "����",
            "����"});
            this.comblyfs.Location = new System.Drawing.Point(6, 16);
            this.comblyfs.Name = "comblyfs";
            this.comblyfs.Size = new System.Drawing.Size(175, 20);
            this.comblyfs.TabIndex = 0;
            this.comblyfs.SelectedIndexChanged += new System.EventHandler(this.comblyfs_SelectedIndexChanged);
            // 
            // GrdSel
            // 
            this.GrdSel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GrdSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrdSel.CaptionBackColor = System.Drawing.SystemColors.Window;
            this.GrdSel.CaptionVisible = false;
            this.GrdSel.DataMember = "";
            this.GrdSel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdSel.Location = new System.Drawing.Point(16, 296);
            this.GrdSel.Name = "GrdSel";
            this.GrdSel.RowHeaderWidth = 20;
            this.GrdSel.Size = new System.Drawing.Size(432, 136);
            this.GrdSel.TabIndex = 31;
            this.GrdSel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.GrdSel.Visible = false;
            this.GrdSel.DoubleClick += new System.EventHandler(this.GrdSel_DoubleClick);
            this.GrdSel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GrdSel_KeyUp);
            this.GrdSel.Click += new System.EventHandler(this.GrdSel_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.GrdSel;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn3,
            this.YBJBMC,
            this.YBJBBM,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "����";
            this.dataGridTextBoxColumn1.MappingName = "NAME";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "ICD";
            this.dataGridTextBoxColumn3.MappingName = "ICD";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 50;
            // 
            // YBJBMC
            // 
            this.YBJBMC.Format = "";
            this.YBJBMC.FormatInfo = null;
            this.YBJBMC.HeaderText = "ҽ�����";
            this.YBJBMC.MappingName = "YBJBMC";
            this.YBJBMC.NullText = "";
            this.YBJBMC.Width = 220;
            // 
            // YBJBBM
            // 
            this.YBJBBM.Format = "";
            this.YBJBBM.FormatInfo = null;
            this.YBJBBM.HeaderText = "ҽ������";
            this.YBJBBM.MappingName = "YBJBBM";
            this.YBJBBM.NullText = "";
            this.YBJBBM.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "ƴ����";
            this.dataGridTextBoxColumn2.MappingName = "ƴ����";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "�����";
            this.dataGridTextBoxColumn4.MappingName = "�����";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 60;
            // 
            // chk_hsz
            // 
            this.chk_hsz.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_hsz.Location = new System.Drawing.Point(24, 216);
            this.chk_hsz.Name = "chk_hsz";
            this.chk_hsz.Size = new System.Drawing.Size(144, 24);
            this.chk_hsz.TabIndex = 35;
            this.chk_hsz.Text = "֪ͨ��ʿ����վ";
            this.chk_hsz.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblYbjbbm);
            this.groupBox2.Controls.Add(this.txtBZ);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtXY);
            this.groupBox2.Controls.Add(this.txtZY);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(16, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 122);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "��Ժ�����";
            // 
            // lblYbjbbm
            // 
            this.lblYbjbbm.AutoSize = true;
            this.lblYbjbbm.Location = new System.Drawing.Point(11, 80);
            this.lblYbjbbm.Name = "lblYbjbbm";
            this.lblYbjbbm.Size = new System.Drawing.Size(0, 12);
            this.lblYbjbbm.TabIndex = 50;
            this.lblYbjbbm.Visible = false;
            // 
            // txtBZ
            // 
            this.txtBZ.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBZ.Location = new System.Drawing.Point(80, 81);
            this.txtBZ.Name = "txtBZ";
            this.txtBZ.Size = new System.Drawing.Size(112, 23);
            this.txtBZ.TabIndex = 2;
            this.txtBZ.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.txtBZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(40, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 35;
            this.label12.Text = "֤��";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtXY
            // 
            this.txtXY.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXY.Location = new System.Drawing.Point(40, 20);
            this.txtXY.Name = "txtXY";
            this.txtXY.Size = new System.Drawing.Size(152, 23);
            this.txtXY.TabIndex = 0;
            this.txtXY.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.txtXY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // txtZY
            // 
            this.txtZY.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZY.Location = new System.Drawing.Point(40, 53);
            this.txtZY.Name = "txtZY";
            this.txtZY.Size = new System.Drawing.Size(152, 23);
            this.txtZY.TabIndex = 1;
            this.txtZY.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.txtZY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(5, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 31;
            this.label11.Text = "��ҽ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(5, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 30;
            this.label7.Text = "��ҽ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(291, 262);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "ȡ��(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(123, 262);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "ȷ��(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDiag);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblWard);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblBedNo);
            this.groupBox1.Controls.Add(this.lblZyh);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblDiag
            // 
            this.lblDiag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiag.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDiag.Location = new System.Drawing.Point(238, 48);
            this.lblDiag.Name = "lblDiag";
            this.lblDiag.Size = new System.Drawing.Size(208, 23);
            this.lblDiag.TabIndex = 20;
            this.lblDiag.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(184, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "��  �ϣ�";
            // 
            // lblWard
            // 
            this.lblWard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWard.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.Location = new System.Drawing.Point(54, 48);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(122, 23);
            this.lblWard.TabIndex = 18;
            this.lblWard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(10, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "���ң�";
            // 
            // lblBedNo
            // 
            this.lblBedNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBedNo.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedNo.Location = new System.Drawing.Point(390, 16);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(56, 23);
            this.lblBedNo.TabIndex = 16;
            this.lblBedNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblZyh
            // 
            this.lblZyh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZyh.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZyh.Location = new System.Drawing.Point(240, 16);
            this.lblZyh.Name = "lblZyh";
            this.lblZyh.Size = new System.Drawing.Size(104, 23);
            this.lblZyh.TabIndex = 15;
            this.lblZyh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(54, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(122, 23);
            this.lblName.TabIndex = 14;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(184, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "סԺ�ţ�";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(354, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "���ţ�";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "������";
            // 
            // numUD
            // 
            this.numUD.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numUD.Location = new System.Drawing.Point(420, 190);
            this.numUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD.Name = "numUD";
            this.numUD.Size = new System.Drawing.Size(40, 24);
            this.numUD.TabIndex = 1;
            // 
            // radBt2
            // 
            this.radBt2.Checked = true;
            this.radBt2.Location = new System.Drawing.Point(364, 190);
            this.radBt2.Name = "radBt2";
            this.radBt2.Size = new System.Drawing.Size(64, 24);
            this.radBt2.TabIndex = 34;
            this.radBt2.TabStop = true;
            this.radBt2.Text = "�޸�ֵ";
            // 
            // radBt1
            // 
            this.radBt1.Location = new System.Drawing.Point(364, 163);
            this.radBt1.Name = "radBt1";
            this.radBt1.Size = new System.Drawing.Size(64, 24);
            this.radBt1.TabIndex = 33;
            this.radBt1.Text = "Ĭ��ֵ";
            this.radBt1.CheckedChanged += new System.EventHandler(this.radBt1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(232, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "����ĩ��ִ�д���:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dTimePicker1
            // 
            this.dTimePicker1.CustomFormat = "yyyy��MM��dd�� HH:mm";
            this.dTimePicker1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTimePicker1.Location = new System.Drawing.Point(304, 131);
            this.dTimePicker1.Name = "dTimePicker1";
            this.dTimePicker1.Size = new System.Drawing.Size(168, 23);
            this.dTimePicker1.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(232, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "��Ժʱ�䣺";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTreat
            // 
            this.cmbTreat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTreat.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTreat.Items.AddRange(new object[] {
            "����",
            "��ת",
            "δ��",
            "����",
            "����"});
            this.cmbTreat.Location = new System.Drawing.Point(304, 99);
            this.cmbTreat.Name = "cmbTreat";
            this.cmbTreat.Size = new System.Drawing.Size(168, 22);
            this.cmbTreat.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(232, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "��Ժ�����";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // FrmLeave
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(678, 318);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLeave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��Ժ����";
            this.Load += new System.EventHandler(this.FrmLeave_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            //�������ĳ�Ժҽ��,����Ժ��ԤԼ����
            bool bShowMzYy = true;

            string er = "";
            DateTime serverDateTime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            //if(this.dTimePicker1.Value<serverDateTime) this.dTimePicker1.Value=serverDateTime;
            if (this.BabyID == 0 && (txtXY.Text.Trim() == "" || Convertor.IsNull(txtXY.Tag, "") == ""))
            {
                MessageBox.Show("��Ժ��ϲ�������");
                return;
            }
            else if (cmbTreat.SelectedItem == null)
            {
                MessageBox.Show("��ѡ�񡮳�Ժ�������");
                return;
            }
            #region//Add by Zouchihua 2011-11-18 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������ò������ڿ��һ�������
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(BinID);


            //Modify by zouchihfua 2011-11-16  �������ڿ��һ�������
            //string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(BinID);
            int BrJgbm = Convert.ToInt32(rtnSql[1]);
            #endregion
            #region Ȩ��ȷ��
            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (new SystemCfg(6023).Config == "0")
            {
                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm._currentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("��û��ͨ��Ȩ��ȷ�ϣ����ܷ���ҽ����", new Font("����", 12f), Color.Red, "Sorry��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion

            //дͣҽ����¼
            //
            long Order_Num = myQuery.GetYzNum(this.BinID, this.DeptID);
            long OrderNumCount = Order_Num + 1;
            int num = 0;//ĩ�մ���

            if (this.radBt1.Checked == true) num = -1;
            else num = Convert.ToInt16(this.numUD.Value);

            string str = "";
            if (this.dTimePicker1.Value.Date <= serverDateTime.Date)
            {
                str = "����";
            }
            else if (this.dTimePicker1.Value.Date == serverDateTime.Date.AddDays(1))
            {
                str = "����";
            }
            else if (this.dTimePicker1.Value.DayOfWeek == DayOfWeek.Monday)
            {
                str = "����һ";
            }
            else
            {
                str = this.dTimePicker1.Value.Month.ToString() + "��" + this.dTimePicker1.Value.Day.ToString() + "��";
            }
            str += "����" + (num != 0 ? "��Һ��" : "") + "��Ժ";// +dTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");

            if (cmbTreat.Text.Trim() == "����")
            {
                str = "��������";
                bShowMzYy = false;
            }

            //��Ժҽ������  modify by jchl   2015-09-30
            OutHosp.isZg(lblZyh.Text.Trim(), FrmMdiMain.Database);

            //if (string.IsNullOrEmpty(Convertor.IsNull(txtXY.Tag, "")))
            //{
            //    MessageBox.Show("δ�ҵ���ҽ��ϵĹ��ұ���,������ѡ����ҽ��ϣ�");
            //    return;
            //}

            if (this.BabyID == 0 && ybjklx == 40 && yblx >= 0)
            {
                //ҽ�����˱�����ҽ�����
                if (string.IsNullOrEmpty(Convertor.IsNull(lblYbjbbm.Tag, "")))
                {
                    MessageBox.Show("ҽ�����ˣ�δ�ҵ���ҽ��ϵ�ҽ������,������ѡ����ҽ��ϣ�");
                    return;
                }
            }

            FrmMdiMain.Database.BeginTransaction();
            try
            {
                string sSql0 = "";
                string sSql1 = "";
                if (this.BabyID == 0)
                {
                    sSql0 = "select * from zy_inpatient(nolock) where flag=3 and inpatient_id='" + this.BinID.ToString() + "' ";
                    sSql1 = "update zy_inpatient set out_mode=" + Convert.ToString(cmbTreat.SelectedIndex + 1) + ",out_date='" + this.dTimePicker1.Value.ToString() + "',out_diagnosis='" + Convertor.IsNull(txtXY.Tag, "") + "'," +
                        "out_diagnosis_h='" + txtZY.Text.Trim() + "  " + txtBZ.Text.Trim() + "' , zx='" + (txtBZ.Tag == null ? "" : txtBZ.Tag.ToString()) + "' ,flag=4 where inpatient_id='" + this.BinID.ToString() + "'";
                }
                else
                {
                    sSql0 = "select * from zy_inpatient_baby(nolock) where flag=3 and baby_id=" + this.BabyID.ToString() + "";
                    sSql1 = "update zy_inpatient_baby set out_mode=" + Convert.ToString(cmbTreat.SelectedIndex + 1) + ",out_date='" + this.dTimePicker1.Value.ToString() + "',out_diagnosis='" + Convertor.IsNull(txtXY.Tag, "") + "'," +
                        "flag=4 where baby_id=" + this.BabyID.ToString() + "";
                }
                DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql0);
                if (myTb.Rows.Count > 0)
                {
                    string inDate = myTb.Rows[0]["IN_DATE"].ToString();
                    //�ſ�������ƣ���������ǽ����ӿڶԵ����뵱����Ĳ�����ϵͳzy_zybrxx���cwh��bf����գ���סԺ�����ǲ��˵Ĵ�λ�� Modify By Tany 2015-03-12
                    //if (DateTime.Parse(inDate).Date == this.dTimePicker1.Value.Date)
                    //{
                    //    FrmMdiMain.Database.RollbackTransaction();
                    //    MessageBox.Show("������Ժ�Ĳ��˵����Ժ��ֻ�������ճ�Ժ����û����������֪ͨ��ʿȡ�����䴲λ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    FrmMdiMain.Database.DoCommand(sSql1);

                    //ֻ������˵ĳ�Ժҽ��
                    if (this.BabyID == 0)
                    {
                        //Modify by jchl ����ɾ���ò��˵ķϵĵ�1���
                        string sqlDelZd = string.Format(@"delete from ZY_DISEASE_MANY where INPATIENT_ID='{0}' and DISEASE_MARK='��1���'", this.BinID.ToString());
                        FrmMdiMain.Database.DoCommand(sqlDelZd);

                        //Modify by jchl ������һ���
                        string sqlZd = String.Format(@" INSERT INTO ZY_DISEASE_MANY (INPATIENT_ID ,INPATIENT_NO ,BABY_ID ,DISEASE_MARK ,DISEASE_CODE ,DISEASE_NAME ,JGBM,YBJBBM,YBJBMC) 
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}')",
                        this.BinID.ToString(), lblZyh.Text.Trim(), "0", "��1���", Convertor.IsNull(txtXY.Tag, ""), txtXY.Text, BrJgbm, Convertor.IsNull(lblYbjbbm.Tag, ""), lblYbjbbm.Text.Trim());
                        FrmMdiMain.Database.DoCommand(sqlZd);
                    }

                    //����SQL���,��ִ��,ҽ��¼����Ϊҽ�����ˣ�Ĭ�ϲ��˿���Ϊҽ������,�в�ҩ����Ĭ��Ϊ1,����ԱΪҽ������
                    //�人����ҽԺת�ơ���Ժ������ҽ���洢����ʱҽ�� Moidify by jchl
                    string sSql = "INSERT INTO ZY_ORDERRECORD(" +
                        "order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc," + // ntype=0 ��ʿվִֻ��һ��
                        "HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date," +
                        "Order_bDate,First_times,Order_Usage,frequency," +
                        "Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,serial_no,jgbm)" +
                        " VALUES('" + PubStaticFun.NewGuid() + "'," + OrderNumCount.ToString() + ",'" + BinID.ToString() + "'," + this.DeptID.ToString() + ",'" + this.WardID + "',1,0," + this.YS_ID.ToString() + "," +
                        "-1,2,'" + str + "',0,1,'',GetDate(),'" + (dTimePicker1.Value.Date <= serverDateTime.Date ? dTimePicker1.Value : serverDateTime) + "',1,'','1'," +
                        "" + this.YS_ID.ToString() + ",0,1," + this.BabyID.ToString() + "," + this.DeptID.ToString() + "," + this.DeptID.ToString() + ",0," + BrJgbm + ") ";

                    FrmMdiMain.Database.DoCommand(sSql);

                    //ͣҽ��
                    myQuery.StopOrders(FrmMdiMain.Database, this.dTimePicker1.Value.ToString(), this.YS_ID, this.BinID, this.BabyID, num);
                    //ͣ�˵�
                    myQuery.StopOrders_ZD(FrmMdiMain.Database, this.dTimePicker1.Value.ToString(), this.YS_ID, this.BinID, this.BabyID, num, 0);
                    //add by zouchihua 2013-1-31
                    string cz = "select * from zy_cyfs(nolock) where inpatient_id='" + BinID.ToString() + "' and baby_id='" + this.BabyID.ToString() + "'";
                    DataTable ttbbtemp = FrmMdiMain.Database.GetDataTable(cz);
                    if (ttbbtemp.Rows.Count == 0)
                    {
                        string insertlyqc = "insert into zy_cyfs(inpatient_id,baby_id,lyfs,jsyljgmc,book_date)"
                        + "  values('" + BinID.ToString() + "'," + this.BabyID.ToString() + ",'" + this.comblyfs.Text + "','" + this.txtyljgmc.Text + "',getdate()) ";
                        FrmMdiMain.Database.DoCommand(insertlyqc);
                    }
                    else
                    {
                        cz = " update  zy_cyfs set  lyfs='" + this.comblyfs.Text + "' , jsyljgmc='" + this.txtyljgmc.Text + "'  where inpatient_id='" + BinID.ToString() + "' and baby_id='" + this.BabyID.ToString() + "'";
                        FrmMdiMain.Database.DoCommand(cz);
                    }
                }

                FrmMdiMain.Database.CommitTransaction();
                if (myTb.Rows.Count > 0)
                {
                    MessageBox.Show("��Ժ����ɹ���");
                }
                else
                {
                    er = "�Ѿ��ǳ�Ժ״̬���������ٿ���Ժҽ����";
                    MessageBox.Show(er.Trim(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                outType = true;

                string msg_wardid = InstanceForm._currentDept.WardId;
                long msg_deptid = 0;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.DeptName + "��" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = lblBedNo.Text + " �� " + lblName.Text + " �г�Ժҽ�����봦��";
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.סԺ��ʿվ, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);

                try
                {
                    if (bShowMzYy)
                    {
                        string ssql = string.Format(@"select oldid from datamap where newtable='JC_EMPLOYEE_PROPERTY' and newid='{0}'", this.YS_ID.ToString());
                        string oldid=InstanceForm._database.GetDataResult(ssql).ToString();

                        string path = @"D:\bsoft\portal\360\360chrome.exe";
                        //string url = @"http://192.168.0.59:7005/Main.aspx?menu=cyfzyy";
                        string url = string.Format(@"http://192.168.0.59:7005/Main.aspx?menu=cyfzyy&zyno={0}&account={1}&accountold={2}", BinID.ToString(), this.YS_ID.ToString(),oldid);
                    
                        //System.Diagnostics.Process.Start("360chrome.exe", url);string path = @"E:\360ChromePortable\360ChromePortable\360chrome.exe";
                        //string url = @"http://192.168.0.59:7055/Main.aspx?menu=cyfzyy";

                        System.Diagnostics.Process[] myProcesses;
                        myProcesses = System.Diagnostics.Process.GetProcessesByName("360chrome");
                        foreach (System.Diagnostics.Process instance in myProcesses)
                        {
                            //instance.CloseMainWindow();
                            instance.Kill();
                        }

                        System.Diagnostics.Process.Start(path, url);
                    }
                }
                catch { }
            }
            catch (System.Exception err)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show("��Ժ����ʧ�ܣ������ԣ�\n" + err.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                er = err.ToString();
                this.Close();
            }
            finally
            {
                //				InstanceForm._database.Close();
                if (er.Trim() == "") myQuery.SaveLog(this.DeptID, this.YS_ID, "����Ժҽ��", this.BinID.ToString() + "��" + this.BabyID.ToString() + "�� " + txtXY.Text.Trim() + "����Ժʱ��" + this.dTimePicker1.Value.ToString() + "����Ժ״̬" + Convert.ToString(cmbTreat.SelectedIndex + 1) + "��ĩ�մ�����" + num.ToString(), 0, 41);
                else myQuery.SaveLog(this.DeptID, this.YS_ID, "��Ժҽ��ʧ��", this.BinID.ToString() + "��" + this.BabyID.ToString() + "��" + er.Trim() + " ��" + txtXY.Text.Trim() + "����Ժʱ��" + this.dTimePicker1.Value.ToString() + "����Ժ״̬" + Convert.ToString(cmbTreat.SelectedIndex + 1) + "��ĩ�մ�����" + num.ToString(), 1, 41);
            }

            //����Ϣ֪ͨ��ʿվ
            if (this.chk_hsz.Checked)
            {
                long warddept = new Department().DeptId;
                myQuery.InformHS(warddept, " ��Ϊ " + this.lblBedNo.Text.Trim() + "�� " + this.lblName.Text.Trim() + " �����Ժ");
            }
            //if(this.txtDZ.Text.Trim()!="" && this.txtDZ.Text.Trim()!="<IP �� �û���>")System.Diagnostics.Process.Start("net.exe", "send "+this.txtDZ.Text.Trim()+" ��Ϊ "+this.lblBedNo.Text.Trim()+"�� "+this.lblName.Text.Trim()+" �����Ժ����");

            if (this.BabyID == 0)
            {
                //FrmYZGL.outType=true;
                Ts_zyys_main.frmMain.outflag = true;
            }
            this.Close();
        }

        private void FrmLeave_Load(object sender, System.EventArgs e)
        {
            //loadData();
            DataTable dt_timesever = InstanceForm._database.GetDataTable("select getdate() as  time");
            timesever = Convert.ToDateTime(dt_timesever.Rows[0]["time"].ToString());
            DateTime dt = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            string cfgStr = (new SystemCfg(6011)).Config;
            int cfg = 0;
            if (cfgStr != "")
            {
                try
                {
                    cfg = Convert.ToInt16(cfgStr);
                }
                catch (System.InvalidCastException err)
                {
                    err.ToString();
                    cfg = 0;
                }
            }
            this.dTimePicker1.Value = dt;
            this.dTimePicker1.MaxDate = dt.Date.AddDays(3);
            this.dTimePicker1.MinDate = dt.Date.AddDays(-cfg);
            if (this.BabyID != 0)
            {
                this.groupBox2.Enabled = false;
            }

            //Modify By Tany 2010-09-29 ��loadData�����棬���滹Ҫ��֤������Ժ���ڣ���֤��Ժ���ڲ���С����Ժ����
            loadData();

            txtXY.Focus();
            cfg6057 = new SystemCfg(6057);

            //�人����ҽԺ��Ժ��Ҫ�Ĵ��� Modify By Tany 2014-12-03
            bool isOk = false;
            try
            {
                string sql_dbz = string.Format(@"select inpatient_id,bzbm,bzmc  from  zy_inpatient_dbz  where inpatient_id='{0}'",this.BinID);
                DataTable dt_dbz = InstanceForm._database.GetDataTable(sql_dbz);
                if (dt_dbz.Rows.Count > 0)
                {
                    if (MessageBox.Show("�ò���Ϊ��" + dt_dbz.Rows[0]["bzmc"].ToString() + "�������ֽ��㣬�Ƿ�ȷ��?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        FrmDBZ FrmDBZ = new FrmDBZ(InstanceForm._database, BinID);
                        FrmDBZ.binid = BinID;
                        FrmDBZ.zyh = lblZyh.Text;
                        FrmDBZ.ShowDialog();
                        //isOk = true;
                    }
                    else
                    {
                        isOk = true;
                    }
                }
                else
                {
                    isOk = TrasenHIS.BLL.OutHosp.Cycl(lblZyh.Text, FrmMdiMain.Database);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isOk = false;
            }
            finally
            {
                if (!isOk)
                {
                    Close();
                }
            }
        }

        private void loadData()
        {
            string sSql = "select a.name,a.inpatient_no,a.bed_no,c.name in_diagnosis,a.ward_id,b.ward_name,a.yblx,isnull(a.ybjklx,'0') ybjklx,in_date  from dbo.VI_ZY_VINPATIENT_ALL a left join jc_ward b on a.ward_id=b.ward_id left join jc_disease c on a.in_diagnosis=c.coding and isnull(a.ybjklx,0)=c.ybjklx and c.bscbz=0  where    inpatient_id='" + this.BinID + "' and baby_id=" + this.BabyID;
            DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
            if (myTb.Rows.Count == 0) return;
            lblName.Text = myTb.Rows[0]["name"].ToString().Trim();
            lblZyh.Text = myTb.Rows[0]["inpatient_no"].ToString().Trim();
            lblBedNo.Text = myTb.Rows[0]["bed_no"].ToString();
            lblDiag.Text = myTb.Rows[0]["in_diagnosis"].ToString().Trim();
            lblWard.Tag = myTb.Rows[0]["ward_id"];
            lblWard.Text = myTb.Rows[0]["ward_name"].ToString();
            ybjklx = Convert.ToInt32(myTb.Rows[0]["ybjklx"]);
            yblx = Convert.ToInt32(myTb.Rows[0]["yblx"]);//Add By Tany 2015-04-28
            //			Inpatient Inpt=new Inpatient(this.BinID);
            //			Patient pt=new Patient (Inpt.PatientID );
            //			lblName.Text=pt.Name.Trim();
            //			lblZyh.Text =pt.Inpatient_No .Trim ();
            //			lblBedNo.Text =myQuery.GetBedNO(Inpt.Bed_ID);
            //			lblDiag.Text =Inpt.In_Diagnosis;
            //			lblWard.Tag  =WardID;
            //			lblWard.Text  =WardID;

            //Modify by Tany 2010-09-29 ��֤������Ժ���ڣ���֤��Ժ���ڲ���С����Ժ����
            if (this.dTimePicker1.MinDate < Convert.ToDateTime(myTb.Rows[0]["in_date"].ToString()))
            {
                this.dTimePicker1.MinDate = Convert.ToDateTime(myTb.Rows[0]["in_date"].ToString());
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void chkStopOrder_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, System.EventArgs e)
        {
            string Sort = "";
            TBox = (TextBox)sender;
            this.GrdSel.Visible = true;
            if (TBox == this.txtZY)
            {
                //this.GrdSel.Top = 138;
                Sort = "B";
            }
            else if (TBox == this.txtBZ)
            {
                //this.GrdSel.Top = 165;
                Sort = "Z";
            }
            else if (TBox == this.txtXY)
            {
                //this.GrdSel.Top = 192;
                Sort = "D";
            }
            this.GrdSel.Top = TBox.Parent.Top + TBox.Top + TBox.Height;
            this.GrdSel.Left = TBox.Parent.Left + TBox.Left;
            //Point pp =this.groupBox2.PointToScreen( this.TBox.Location); 
            //Point p = new Point(pp.X-this.Left,pp.Y + TBox.Height-this.Top);
            //this.GrdSel.Location = p;
            string str = TBox.Text.Trim().Replace("'", ".").ToUpper().Replace('��', '.');
            //add yaokx 2014-02-26  ��������ϴ���������ʱ����
            string tbox_re = TBox.Text.Trim().Replace("'", ".").ToUpper().Replace('��', '.');
            str = str == "" ? "" : " and (ƴ���� like '" + str + "%' )";
            //			string sSql="select name NAME,coding ICD,py_code ƴ���� from base_disease where sort='"+Sort+"' and py_code like '"+str+"%'";
            //			if (diseaseTb==null)
            //			{
            string tj = "";
            if (cfg6057.Config.Trim() == "1")
                tj = " and ybjklx<=0 ";
            //string sSql = "select top 20 name NAME,coding ICD,py_code ƴ����,wb_code �����,sort from jc_disease where 1=1 " + (ybjklx <= 0 ? " " + tj + " " : " and ybjklx =" + ybjklx) + " and (py_code like '" + tbox_re + "%'  or wb_code like '%" + tbox_re + "%' ) order by len(py_code)";


            //Modify By Tany 2015-05-26 ҽ���ӿ�����=0��ʱ��ҲҪ����
            //Modify by jchl 2015-08-22 ����ybjbbm
            string sSql = "";
            if (Convert.ToDateTime(cfg30000.Config.ToString())> timesever)
            {
                sSql = "select top 20 name NAME,coding ICD,'' as YBJBBM,'' as YBJBMC,py_code ƴ����,wb_code �����,sort from jc_disease where 1=1 " + (ybjklx < 0 ? " " + tj + " " : " and ybjklx =" + ybjklx) + " and (py_code like '" + tbox_re + "%'  or wb_code like '%" + tbox_re + "%' ) order by len(py_code)";
                if (ybjklx == 40 && yblx >= 0)
                {
                    //ҽ����ϴ���ҽ������
                    sSql = @"select top 20 a.name NAME,a.coding ICD,b.YBJBBM,b.YBJBMC,a.py_code ƴ����,a.wb_code �����,a.sort 
                            from jc_disease a
                            inner join JC_DISEASE_YYYBDZ b on a.CODING=b.YYJBBM 
                            where 1=1 and a.ybjklx =" + ybjklx + " and (py_code like '" + tbox_re + "%'  or wb_code like '%" + tbox_re + "%' ) order by len(py_code)";
                }
            }
            else
            {

                sSql = @"SELECT JBMC AS NAME, JBBM AS ICD,JBBM as YBJBBM,JBMC as YBJBMC ,PYM as ƴ����,
                                    WBM as �����  FROM JC_Diagnosis_Dict where PYM like '" + tbox_re + "%' order by len(PYM) ";
            }

            diseaseTb = FrmMdiMain.Database.GetDataTable(sSql);
            dt = null;
            dt = diseaseTb.Clone();
            //			}
            DataRow[] diseaseDR = diseaseTb.Select();//("sort='"+Sort+"'","ƴ����");    //��ʱ����
            GrdSel.DataSource = null;
            dt.Clear();
            foreach (DataRow dr in diseaseDR)
            {
                dt.Rows.Add(dr.ItemArray);
            }
            //			dt=DatabaseAccess.GetDataTable(DatabaseType.IbmDb2ZY,sSql);

            GrdSel.DataSource = dt;
            PubStaticFun.ModifyDataGridStyle(GrdSel, 0);
        }

        private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            TBox = (TextBox)sender;
            int keyInt = Convert.ToInt32(e.KeyCode);
            //			if(keyInt>=65 && keyInt<=90)
            //			{
            //				char Keychar=Convert.ToChar(keyInt);
            //				TBox.Text="";
            //				str+=Keychar.ToString();
            //				TBox.Text=str;
            //			}
            //			else if(keyInt==127)
            //			{
            //				str=TBox.Text.Trim();
            //			}
            if (dt == null)
            {
                this.GrdSel.Visible = false;
                return;
            }
            if (dt.Rows.Count == 0)
            {
                GrdSel.Visible = false;
                return;
            }
            else if (keyInt == 27 && GrdSel.Visible == true)
            {
                lblYbjbbm.Text = "";//Modify by jchl
                lblYbjbbm.Tag = "";//Modify by jchl
                TBox.Text = "";
                GrdSel.Visible = false;
            }
            else if (keyInt == 40 && this.GrdSel.CurrentRowIndex < dt.Rows.Count - 1)
            {
                GrdSel.UnSelect(GrdSel.CurrentCell.RowNumber);
                GrdSel.CurrentRowIndex += 1;
                GrdSel.Select(GrdSel.CurrentCell.RowNumber);
            }
            else if (keyInt == 38 && this.GrdSel.CurrentRowIndex > 0)
            {
                GrdSel.UnSelect(GrdSel.CurrentCell.RowNumber);
                GrdSel.CurrentRowIndex -= 1;
                GrdSel.Select(GrdSel.CurrentCell.RowNumber);
            }
            else if (keyInt == 13)
            {
                lblYbjbbm.Text = dt.Rows[GrdSel.CurrentCell.RowNumber]["YBJBMC"].ToString().Trim();
                lblYbjbbm.Tag = dt.Rows[GrdSel.CurrentCell.RowNumber]["YBJBBM"].ToString().Trim(); ;//Modify by jchl
                TBox.Tag = dt.Rows[GrdSel.CurrentCell.RowNumber]["ICD"].ToString();
                TBox.Text = dt.Rows[GrdSel.CurrentCell.RowNumber]["NAME"].ToString();

                GrdSel.Visible = false;
                if (TBox.Name == "txtZY")
                {
                    txtBZ.Focus();
                }
                else if (TBox.Name == "txtBZ")
                {
                    cmbTreat.Focus();
                }
                else if (TBox.Name == "txtXY")
                    txtZY.Focus();
            }
        }

        private void GrdSel_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int keyInt = Convert.ToInt32(e.KeyCode);
            if (keyInt == 13)
            {
                lblYbjbbm.Text = dt.Rows[GrdSel.CurrentCell.RowNumber]["YBJBMC"].ToString().Trim();
                lblYbjbbm.Tag = dt.Rows[GrdSel.CurrentCell.RowNumber]["YBJBBM"].ToString().Trim(); ;//Modify by jchl
                TBox.Tag = dt.Rows[GrdSel.CurrentCell.RowNumber]["ICD"].ToString();
                TBox.Text = dt.Rows[GrdSel.CurrentCell.RowNumber]["NAME"].ToString();

                if (TBox.Name == "txtZY")
                {
                    txtBZ.Focus();
                }
                else if (TBox.Name == "txtBZ")
                {
                    txtXY.Focus();
                }

                GrdSel.Visible = false;
            }
        }

        private void radBt1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radBt1.Checked == true) this.numUD.Enabled = false;
            else this.numUD.Enabled = true;
        }

        private void GrdSel_Click(object sender, System.EventArgs e)
        {
            GrdSel.Select(GrdSel.CurrentCell.RowNumber);
        }

        private void GrdSel_DoubleClick(object sender, System.EventArgs e)
        {
            GrdSel_KeyUp(GrdSel, new KeyEventArgs(Keys.Enter));
        }

        private void comblyfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex == 1 || cb.SelectedIndex == 2)
            {
                this.txtyljgmc.Text = "";
                this.txtyljgmc.ReadOnly = false;
            }
            else
            {
                this.txtyljgmc.Text = "";
                this.txtyljgmc.ReadOnly = true;
            }
        }

        //Add By Tany 2014-12-02
        private void btGetEmrDiagnosois_Click(object sender, EventArgs e)
        {
            try
            {
                string sSql = "select * from VI_ZY_VINPATIENT_ALL where inpatient_id='" + this.BinID + "' and baby_id=" + this.BabyID;
                DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
                if (myTb.Rows.Count == 0) return;
                string[] rtn = TrasenHIS.BLL.HisFunctions.GetEmrDiagnosois(myTb.Rows[0]["inpatient_no"].ToString(), myTb.Rows[0]["inpatient_bano"].ToString());

                txtXY.Text = rtn[1];
                txtXY.Tag = rtn[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add By Tany 2015-04-28 ���Ӷ����¼��
        private void btManyZD_Click(object sender, EventArgs e)
        {
            Cursor = PubStaticFun.WaitCursor();
            try
            {
                ArrayList arrList = new ArrayList();
                arrList.Add(BinID);
                arrList.Add(lblZyh.Text.ToString());
                arrList.Add(BabyID);
                arrList.Add(ybjklx);
                arrList.Add(yblx);
                arrList.Add("");

                FrmMultipleDiagnostic frmMD = new FrmMultipleDiagnostic(arrList);
                frmMD.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }


    }
}
