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

namespace ts_zyhs_brzk
{
    /// <summary>
    /// Form2 ��ժҪ˵����
    /// </summary>
    public class frmBRZK : System.Windows.Forms.Form
    {
        private BaseFunc myFunc;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btת��;
        private System.Windows.Forms.Button btnWzx;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabZK;
        private System.Windows.Forms.TabPage tabQXZK;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnˢ��;
        private System.Windows.Forms.Button btnȡ��ת��;
        private System.Windows.Forms.Button btn�˳�;
        private DataGridEx GrdQxzk;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;
        SystemCfg cfg7205 = new SystemCfg(7205);//yaokx2014-06-27
        public frmBRZK(string _formText)
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnWzx = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btת�� = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.GrdQxzk = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabZK = new System.Windows.Forms.TabPage();
            this.tabQXZK = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnˢ�� = new System.Windows.Forms.Button();
            this.btnȡ��ת�� = new System.Windows.Forms.Button();
            this.btn�˳� = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdQxzk)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabZK.SuspendLayout();
            this.tabQXZK.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 465);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(694, 405);
            this.panel4.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 405);
            this.panel2.TabIndex = 0;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "����ת���嵥";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.HeaderFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(694, 405);
            this.myDataGrid1.TabIndex = 59;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Tag = "";
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 405);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(694, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnWzx);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btת��);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 409);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 56);
            this.panel3.TabIndex = 1;
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
            this.btnRefresh.Location = new System.Drawing.Point(270, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 24);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "ˢ��(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.Location = new System.Drawing.Point(518, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "ȡ��ת��(&Q)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnWzx
            // 
            this.btnWzx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWzx.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWzx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWzx.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWzx.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnWzx.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWzx.ImageIndex = 0;
            this.btnWzx.Location = new System.Drawing.Point(342, 16);
            this.btnWzx.Name = "btnWzx";
            this.btnWzx.Size = new System.Drawing.Size(96, 24);
            this.btnWzx.TabIndex = 6;
            this.btnWzx.Text = "δ������Ŀ(&W)";
            this.btnWzx.UseVisualStyleBackColor = false;
            this.btnWzx.Click += new System.EventHandler(this.btnWzx_Click);
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
            this.btCancel.Location = new System.Drawing.Point(614, 16);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "�˳�(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btת��
            // 
            this.btת��.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btת��.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btת��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btת��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btת��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btת��.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btת��.ImageIndex = 0;
            this.btת��.Location = new System.Drawing.Point(446, 16);
            this.btת��.Name = "btת��";
            this.btת��.Size = new System.Drawing.Size(64, 24);
            this.btת��.TabIndex = 4;
            this.btת��.Text = "ת��(&Z)";
            this.btת��.UseVisualStyleBackColor = false;
            this.btת��.Click += new System.EventHandler(this.btת��_Click);
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
            this.button3.Location = new System.Drawing.Point(262, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(424, 40);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // GrdQxzk
            // 
            this.GrdQxzk.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GrdQxzk.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.GrdQxzk.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdQxzk.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.GrdQxzk.CaptionText = "ȡ��ת���嵥";
            this.GrdQxzk.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.GrdQxzk.DataMember = "";
            this.GrdQxzk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdQxzk.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GrdQxzk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.GrdQxzk.HeaderFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GrdQxzk.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdQxzk.Location = new System.Drawing.Point(0, 0);
            this.GrdQxzk.Name = "GrdQxzk";
            this.GrdQxzk.ReadOnly = true;
            this.GrdQxzk.Size = new System.Drawing.Size(694, 409);
            this.GrdQxzk.TabIndex = 60;
            this.GrdQxzk.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.GrdQxzk.Tag = "";
            this.GrdQxzk.CurrentCellChanged += new System.EventHandler(this.GrdQxzk_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.GrdQxzk;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabZK);
            this.tabControl1.Controls.Add(this.tabQXZK);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 491);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabZK
            // 
            this.tabZK.Controls.Add(this.panel1);
            this.tabZK.Location = new System.Drawing.Point(4, 22);
            this.tabZK.Name = "tabZK";
            this.tabZK.Size = new System.Drawing.Size(694, 465);
            this.tabZK.TabIndex = 0;
            this.tabZK.Text = "ת��";
            // 
            // tabQXZK
            // 
            this.tabQXZK.Controls.Add(this.panel5);
            this.tabQXZK.Location = new System.Drawing.Point(4, 22);
            this.tabQXZK.Name = "tabQXZK";
            this.tabQXZK.Size = new System.Drawing.Size(694, 465);
            this.tabQXZK.TabIndex = 1;
            this.tabQXZK.Text = "ȡ��ת��";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.splitter2);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(694, 465);
            this.panel5.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 405);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(694, 4);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.GrdQxzk);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(694, 409);
            this.panel7.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnˢ��);
            this.panel6.Controls.Add(this.btnȡ��ת��);
            this.panel6.Controls.Add(this.btn�˳�);
            this.panel6.Controls.Add(this.button5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 409);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(694, 56);
            this.panel6.TabIndex = 0;
            // 
            // btnˢ��
            // 
            this.btnˢ��.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnˢ��.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnˢ��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnˢ��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnˢ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnˢ��.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnˢ��.ImageIndex = 0;
            this.btnˢ��.Location = new System.Drawing.Point(452, 16);
            this.btnˢ��.Name = "btnˢ��";
            this.btnˢ��.Size = new System.Drawing.Size(64, 24);
            this.btnˢ��.TabIndex = 12;
            this.btnˢ��.Text = "ˢ��(&R)";
            this.btnˢ��.UseVisualStyleBackColor = false;
            this.btnˢ��.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnȡ��ת��
            // 
            this.btnȡ��ת��.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnȡ��ת��.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnȡ��ת��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnȡ��ת��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnȡ��ת��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnȡ��ת��.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnȡ��ת��.ImageIndex = 0;
            this.btnȡ��ת��.Location = new System.Drawing.Point(522, 16);
            this.btnȡ��ת��.Name = "btnȡ��ת��";
            this.btnȡ��ת��.Size = new System.Drawing.Size(88, 24);
            this.btnȡ��ת��.TabIndex = 11;
            this.btnȡ��ת��.Text = "ȡ��ת��(&Q)";
            this.btnȡ��ת��.UseVisualStyleBackColor = false;
            this.btnȡ��ת��.Click += new System.EventHandler(this.btnȡ��ת��_Click);
            // 
            // btn�˳�
            // 
            this.btn�˳�.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn�˳�.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn�˳�.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn�˳�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn�˳�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn�˳�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn�˳�.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn�˳�.ImageIndex = 0;
            this.btn�˳�.Location = new System.Drawing.Point(616, 16);
            this.btn�˳�.Name = "btn�˳�";
            this.btn�˳�.Size = new System.Drawing.Size(64, 24);
            this.btn�˳�.TabIndex = 10;
            this.btn�˳�.Text = "�˳�(&E)";
            this.btn�˳�.UseVisualStyleBackColor = false;
            this.btn�˳�.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.ImageIndex = 0;
            this.button5.Location = new System.Drawing.Point(444, 8);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(244, 40);
            this.button5.TabIndex = 9;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // frmBRZK
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(702, 491);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmBRZK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ת��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBRZK_Load);
            this.Activated += new System.EventHandler(this.frmBRZK_Activated);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdQxzk)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabZK.ResumeLayout(false);
            this.tabQXZK.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmZK_Load(object sender, System.EventArgs e)
        {
            string sSql = "";
            DataTable myTb = new DataTable();

            Cursor.Current = PubStaticFun.WaitCursor();

            if (tabControl1.SelectedTab == tabZK)
            {
                sSql = "select dbo.fun_getdate(Transfer_date) ת������,convert(char,Transfer_date,108) ת��ʱ��,a.bed_no ����,a.inpatient_no  סԺ��,a.name ����,a.SEX_NAME �Ա�,dbo.FUN_ZY_SEEKDEPTNAME(d.s_Dept_id) Դ����,dbo.FUN_ZY_SEEKDEPTNAME(d.d_Dept_id) Ŀ�����,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) ҽ��,dbo.fun_getdate(book_date) �Ǽ�����,a.inpatient_id,a.baby_id,b.isMYTS,d.d_Dept_id,d.s_Dept_id,d.order_id,d.id ,b.bed_id,d.chk_bit,d.chk_man,d.chk_Time,d.ref_memo,a.DISCHARGETYPE " +
                    "  from ZY_TRANSFER_dept d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a " + //and d.baby_id=b.baby_id Modify by tany 2011-03-07 Ӥ����ĸ��ͬһ�Ŵ�
                    "	where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id " +
                    "         and d.s_Dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') and d.finish_bit=0 and d.cancel_bit=0 "
                    + "and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)= " + FrmMdiMain.Jgbm;
                myFunc.ShowGrid(0, sSql, this.myDataGrid1);

                string[] GrdMappingName1 ={ "ת������", "ת��ʱ��", "����", "סԺ��", "����", "�Ա�", "Դ����", "Ŀ�����", "ҽ��", "�Ǽ�����", "inpatient_id", "baby_id", "isMYTS", "d_Dept_id", "s_Dept_id", "order_id", "id", "bed_id" ,
                                        "��˱�־", "�����", "���ʱ��", "�ܾ�ԭ��","yblx" };
                int[] GrdWidth1 ={ 10, 8, 4, 9, 12, 4, 12, 12, 8, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 0 };
                int[] Alignment1 ={ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 0 };
                int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 0 };
                myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb.Rows.Count != 0)
                {
                    this.btת��.Enabled = true;
                    this.myDataGrid1.Enabled = true;
                    myFunc.SelectBin(false, this.myDataGrid1, 10, 11, 0, 0);
                }
                else
                {
                    this.btת��.Enabled = false;
                    this.myDataGrid1.Enabled = false;
                }
            }
            else
            {
                sSql = "select dbo.fun_getdate(Transfer_date) ת������,convert(char,Transfer_date,108) ת��ʱ��,b.inpatient_no  סԺ��,b.name ����,b.SEX_NAME �Ա�,dbo.FUN_ZY_SEEKDEPTNAME(a.s_Dept_id) Դ����,dbo.FUN_ZY_SEEKDEPTNAME(a.d_Dept_id) Ŀ�����,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.operator) ҽ��,dbo.fun_getdate(book_date) �Ǽ�����,b.inpatient_id,b.baby_id,a.d_Dept_id,a.s_Dept_id,a.order_id,a.id,b.bed_id " +
                    "  from zy_transfer_Dept a inner join vi_zy_vinpatient_info b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id " +
                    "  where a.finish_bit=1 and a.cancel_bit=0 and b.flag=1  " +
                    "        and a.s_Dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') "
                    + " and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)= " + FrmMdiMain.Jgbm;
                myFunc.ShowGrid(0, sSql, this.GrdQxzk);

                string[] GrdMappingName1 ={ "ת������", "ת��ʱ��", "סԺ��", "����", "�Ա�", "Դ����", "Ŀ�����", "ҽ��", "�Ǽ�����", "inpatient_id", "baby_id", "d_Dept_id", "s_Dept_id", "order_id", "id", "bed_id" };
                int[] GrdWidth1 ={ 10, 8, 9, 12, 4, 12, 12, 8, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] Alignment1 ={ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.GrdQxzk);

                myTb = (DataTable)this.GrdQxzk.DataSource;
                if (myTb.Rows.Count != 0)
                {
                    this.btnȡ��ת��.Enabled = true;
                    this.GrdQxzk.Enabled = true;
                    myFunc.SelectBin(false, this.GrdQxzk, 9, 10, 0, 0);
                }
                else
                {
                    this.btnȡ��ת��.Enabled = false;
                    this.GrdQxzk.Enabled = false;
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }

        private void btת��_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            string sBinID = myTb.Rows[nrow]["inpatient_id"].ToString().Trim();
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            long nSDeptID = Convert.ToInt64(myTb.Rows[nrow]["s_Dept_id"]);
            long nDDeptID = Convert.ToInt64(myTb.Rows[nrow]["d_Dept_id"]);
            string sOrderId = myTb.Rows[nrow]["order_id"].ToString().Trim();
            //add by zouchihua 2013-8-22 ת�Ƶ�ʱ��ͬʱ����ǰ����bed_id���½�ȥ
            string Sid = myTb.Rows[nrow]["id"].ToString().Trim(); //ת��id
            string Sbed_id = myTb.Rows[nrow]["bed_id"].ToString().Trim(); //ת��id

            int isMYTS = 0;
            if (myTb.Rows[nrow]["isMYTS"].ToString().Trim() != "")
            {
                isMYTS = Convert.ToInt32(myTb.Rows[nrow]["isMYTS"]);
            }

            //�ж��Ƿ���Ӥ����ת��
            if (isMYTS != 0 && Convert.ToInt32(sBabyID) == 0 && cfg7205.Config == "0")
            {
                MessageBox.Show(this, "�Բ������Ƚ�Ӥ��ת�ƣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isMYTS != 0 && Convert.ToInt32(sBabyID) == 0 && cfg7205.Config == "1")
            {
                MessageBox.Show(this, "�Բ������Ƚ�" + myTb.Rows[nrow]["����"].ToString() + "��ת�ƣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sMsg = "";
            string sSql = "";
            DataTable tempTb = new DataTable();
            bool isBTYZ = false;//�Ƿ�ͣҽ��

            try
            {
                //ת���Ƿ��ж���δ���˵ķ��� 0=���ǣ�1=��, Ӧ����7102 Modify By Tany 2015-04-02 ������ж϶������ˣ�һ������
                //string cfg7012 = new SystemCfg(7012).Config;
                string cfg7102 = new SystemCfg(7102).Config;

                sSql = "select 1 from zy_zkgx where s_Dept=" + nSDeptID + " and d_Dept=" + nDDeptID;
                DataTable deptTB = InstanceForm.BDatabase.GetDataTable(sSql);
                //�ж��Ƿ���Բ�ͣҽ��ת��
                if (deptTB == null || deptTB.Rows.Count == 0)
                {
                    //�ж��Ƿ���δֹͣ��ҽ�����ж��Ƿ���δ���ʵķ���
                    sSql = " select sum(id1) as id1,sum(id2) as id2 from ( " +
                        " select count(a.order_id) id1,0 id2 " +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<5 and a.delete_bit=0 " +
                        "  and a.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-13 ����֤��������Ƶ�ҽ���Ƿ����
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID + " ";

                    if (cfg7102 != "0")
                    {
                        sSql += " union all" +
                                            " select 0 id1,count(b.id) id2 " +
                                            "  from zy_fee_speci b " +
                                            "  where b.charge_bit=0 and b.delete_bit=0 " +
                                            "  and b.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-08 ����֤��������Ƶķ����Ƿ����
                                            "  and b.inpatient_id='" + sBinID + "' and b.baby_id=" + sBabyID + " "; //Modify By Tany 2004-12-22 ת�ƿ��Բ��жϷ���
                    }
                    sSql += " ) tmp";
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    {
                        sMsg = "��δֹͣ��ҽ��";
                    }
                    if (Convert.ToInt32(tempTb.Rows[0]["id2"]) > 0)
                    {
                        sMsg += sMsg == "" ? "��" : "��";
                        sMsg = "δ���ʵķ���";
                    }
                    if (sMsg != "")
                    {
                        MessageBox.Show(this, "�Բ��𣬸ò���" + sMsg + "��������ת�ƣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnWzx_Click(null, null);
                        return;
                    }
                }
                else
                {
                    isBTYZ = true;

                    sSql = "select count(a.order_id) id1" +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<2 and a.delete_bit=0 " +
                        "  and a.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-13 ����֤��������Ƶ�ҽ���Ƿ����
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    {
                        MessageBox.Show(this, "�Բ��𣬸ò�����δת����ҽ����������ת�ƣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //��ʱҽ�����뷢�ͺ����ת��
                    sSql = "select count(a.order_id) id1" +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<5 and a.delete_bit=0 and mngtype in (1,5)" +
                        "  and a.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-13 ����֤��������Ƶ�ҽ���Ƿ����
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    {
                        MessageBox.Show(this, "�Բ��𣬸ò�����δִ�е���ʱҽ����������ת�ƣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //��ת�ƹ�ϵ��ת��ʱҲ��Ҫ��֤�����Ƿ�ȷ�� Modify By Tany 2015-03-13
                    //ҽԺ�ֲ�Ҫ��֤�� Modify By Tany 2015-04-09
                    //if (cfg7102 != "0")
                    //{
                    //    sSql = " select 0 id1,count(b.id) id2 " +
                    //            "  from zy_fee_speci b " +
                    //            "  where b.charge_bit=0 and b.delete_bit=0 " +
                    //            "  and b.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-08 ����֤��������Ƶķ����Ƿ����
                    //            "  and b.inpatient_id='" + sBinID + "' and b.baby_id=" + sBabyID + " ";

                    //    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    //    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    //    {
                    //        sMsg = "��δֹͣ��ҽ��";
                    //    }
                    //    if (Convert.ToInt32(tempTb.Rows[0]["id2"]) > 0)
                    //    {
                    //        sMsg += sMsg == "" ? "��" : "��";
                    //        sMsg = "δ���ʵķ���";
                    //    }
                    //    if (sMsg != "")
                    //    {
                    //        MessageBox.Show(this, "�Բ��𣬸ò���" + sMsg + "��������ת�ƣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        btnWzx_Click(null, null);
                    //        return;
                    //    }
                    //}
                }

                //add by zouchihua 2012-12-11 ��δ��˵���������
                sSql = "select  * from SS_APPRECORD where  BDELETE=0 and JZSS=0 and SHBJ=0 and inpatient_id='" + sBinID + "'";
                DataTable tmtb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tmtb != null && tmtb.Rows.Count > 0)
                {
                    MessageBox.Show("�Բ��𣬸ò��˻���δ��˵�������������֪ͨҽ��������˺�ſ��Խ���ת�Ʋ�����");
                    return;
                }

                sSql = "Select 1 from zy_BedDiction where inpatient_id='" + sBinID + "' and isbf=1";
                tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tempTb.Rows.Count > 0)
                {
                    MessageBox.Show(this, "�Բ��𣬸ò����а�������ȡ����������ת�ƣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Modify By Tany 2015-04-01 ���Ӳ�������
                SystemCfg cfg7604 = new SystemCfg(7604);
                //Modify by jchl��ҽ��������̣�
                if (!myTb.Rows[nrow]["DISCHARGETYPE"].ToString().Trim().Equals("0") && cfg7604.Config == "1")
                {
                    string id = myTb.Rows[nrow]["id"].ToString();
                    //���ԷѲ���
                    sSql = "Select count(1) from ZY_TRANSFER_dept where id='" + id + "' and finish_bit=0 and cancel_bit=0 and ( chk_bit=1 or exists (select 1 from ZY_ZKGX where S_DEPT=s_Dept_id and D_DEPT=d_Dept_id))";
                    int iCnt = int.Parse(InstanceForm.BDatabase.GetDataResult(sSql).ToString());
                    if (iCnt <= 0)
                    {
                        MessageBox.Show(this, "�Բ��𣬸ò���δ���ͨ��������ϵҽ������ˣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //ת��
                if (MessageBox.Show(this, "ȷ�ϡ�" + myTb.Rows[nrow]["����"].ToString().Trim() + "��ת����" + myTb.Rows[nrow]["Ŀ�����"].ToString().Trim() + "����", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                #region ���ת�ƿ��Բ�ͣҽ��
                if (isBTYZ)
                {
                    //�����ǲ��ǻ����ڱ����ҵ�ҩƷ
                    sSql = "select a.group_id,a.hoitem_id cjid,a.order_context " +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<5 and a.delete_bit=0 and ntype in (1,2,3) and exec_Dept=" + InstanceForm.BCurrentDept.WardDeptId +
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    //����У����ִ�п��Ҹ��ĳɶԷ�����
                    if (tempTb.Rows.Count > 0)
                    {
                        //�õ��Է�������Ϣ
                        Department _newDept = new Department(nDDeptID, InstanceForm.BDatabase);

                        string tmpMsg = "";

                        #region �ж�ҩƷ����Ч��
                        for (int i = 0; i < tempTb.Rows.Count; i++)
                        {
                            sSql = "Select 1 from YF_KCMX a where a.bdelete=0 and a.cjid=" + tempTb.Rows[i]["cjid"].ToString().Trim() + " and a.deptid=" + _newDept.WardDeptId;
                            DataTable medTb = InstanceForm.BDatabase.GetDataTable(sSql);

                            if (medTb == null || medTb.Rows.Count == 0)
                            {
                                tmpMsg += " �� " + tempTb.Rows[i]["order_context"].ToString().Trim() + "\n";
                            }
                        }

                        if (tmpMsg.Trim() != "")
                        {
                            MessageBox.Show("����ҩƷ��Ϊ�Է�����Сҩ����û�и���ҩƷ�������ܸ���ִ�п��ң�\n��ȷ�϶Է�����Сҩ���и���ҩƷ����ҽ��ֹͣ����ҽ����\n���ܸ���ִ�п���Ϊ�Է����ҵ�ҩƷ������\n\n" + tmpMsg,
                                "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        #endregion

                        //�ж�ͨ���Ļ��������Щҽ����ִ�п���ȫ���ı�
                        sSql = "update zy_orderrecord a " +
                            "  set exec_Dept=" + _newDept.WardDeptId +
                            "  where a.status_flag<5 and a.delete_bit=0 and ntype in (1,2,3) and exec_Dept=" + InstanceForm.BCurrentDept.WardDeptId +
                            "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //���θ���ת��ҽ��
                        sSql = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                }
                #endregion

                string _outmsg = "";
                if (myFunc.isMYTSBaby(isMYTS, Convert.ToInt32(sBabyID)))
                {
                    //����ĸ�׵�ĸӤͬ������
                    _outmsg = myFunc.TransfeDept("", 2, new Guid(sBinID), Convert.ToInt64(sBabyID), nSDeptID, nDDeptID, InstanceForm.BCurrentUser.EmployeeId, Convert.ToDateTime(myTb.Rows[nrow]["�Ǽ�����"]), new Guid(myTb.Rows[nrow]["id"].ToString()));
                }
                else
                {
                    _outmsg = myFunc.TransfeDept("", 1, new Guid(sBinID), Convert.ToInt64(sBabyID), nSDeptID, nDDeptID, InstanceForm.BCurrentUser.EmployeeId, Convert.ToDateTime(myTb.Rows[nrow]["�Ǽ�����"]), new Guid(myTb.Rows[nrow]["id"].ToString()));
                }

                if (_outmsg.Trim() != "")
                {
                    MessageBox.Show(_outmsg);
                }
                //���Ĵ�λ 2013-8-22 
                string updatesql = "update ZY_TRANSFER_DEPT set Sbed_id='" + Sbed_id + "'  where id='" + Sid + "'";
                InstanceForm.BDatabase.DoCommand(updatesql);

                Department msgDept = new Department(nDDeptID, FrmMdiMain.Database);
                string msg_wardid = msgDept.WardId;
                long msg_deptid = 0;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.WardName + "��" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = "��ת�Ʋ��ˣ�\r\nסԺ�ţ�" + myTb.Rows[nrow]["סԺ��"].ToString().Trim() + "\r\n������" + myTb.Rows[nrow]["����"].ToString().Trim();
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.סԺ��ʿվ, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);

                //д��־ Add By Tany 2005-01-12
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "ת��", _outmsg + "����" + myTb.Rows[nrow]["����"].ToString().Trim() + " " + sBinID + " " + sBabyID + "��ת����" + myTb.Rows[nrow]["Ŀ�����"].ToString().Trim() + "��", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                frmZK_Load(sender, e);
            }
        }

        private void btnWzx_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            string sBinID = myTb.Rows[nrow]["inpatient_id"].ToString().Trim();
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();

            object[] _communicates = new object[2];
            _communicates[0] = sBinID;
            _communicates[1] = sBabyID;
            WorkStaticFun.InstanceFormEx("ts_zyhs_wclxmcx", "Fun_ts_zyhs_wclxmcx", "δ������Ŀ��ѯ", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase, ref _communicates);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

            if (myTb == null || myTb.Rows.Count == 0) return;

            string sSql = "";
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            Guid sBinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            string sBedNo = myTb.Rows[nrow]["����"].ToString().Trim();
            string sName = myTb.Rows[nrow]["����"].ToString().Trim();
            string sSDept = myTb.Rows[nrow]["Դ����"].ToString().Trim();
            string sDDept = myTb.Rows[nrow]["Ŀ�����"].ToString().Trim();
            long nSDeptID = Convert.ToInt64(myTb.Rows[nrow]["s_Dept_id"]);
            long nDDeptID = Convert.ToInt64(myTb.Rows[nrow]["d_Dept_id"]);
            Guid sId = new Guid(myTb.Rows[nrow]["id"].ToString().Trim());
            Guid sOrderId = new Guid(myTb.Rows[nrow]["order_id"].ToString().Trim());
            bool IsExistOrder = false;

            if (sOrderId == Guid.Empty)
            {
                if (MessageBox.Show("û���ҵ�����ת����Ϣ��ת��ҽ����ȡ����ת����Ϣ������ͬʱȡ��ת��ҽ�����Ƿ������", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }
            else
            {
                IsExistOrder = true;
            }
            string sMsg = IsExistOrder ? "\nͬʱ��ȡ��ת��ҽ����" : "";
            if (MessageBox.Show("�Ƿ�ȷ��ȡ�� " + sBedNo + " ������ " + sName + " �� " + sSDept + " �� " + sDDept + " ��ת����Ϣ��" + sMsg, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            try
            {
                string[] sqls = new string[2];
                //sqls[0] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                //    " where id='" + sId + "'";

                //Modify by tany 2011-03-07 ȡ�����иò��˰���Ӥ����ת�Ƽ�¼
                sqls[0] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                    " where finish_bit=0 and inpatient_id='" + sBinID + "' and s_dept_id=" + nSDeptID;

                if (IsExistOrder)
                {
                    sqls[1] = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
                }
                InstanceForm.BDatabase.DoCommand(null, null, null, sqls);
            }
            catch (Exception err)
            {
                //д������־ Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "ȡ��ת�ƴ���" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source + "\n\n�����Ѿ��ع������������ִ�У�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmZK_Load(sender, e);
                return;
            }

            MessageBox.Show("ȡ��ת�Ʋ����ɹ���", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //д��־ Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "ȡ��ת��", "ȡ�� " + sBedNo + " ������ " + sName + " �� " + sSDept + " �� " + sDDept + " ��ת����Ϣ", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            frmZK_Load(sender, e);
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            frmZK_Load(null, null);
        }

        private void frmBRZK_Activated(object sender, System.EventArgs e)
        {
            frmZK_Load(null, null);
        }

        private void GrdQxzk_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.GrdQxzk);
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            frmZK_Load(null, null);
        }

        private void btnȡ��ת��_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.GrdQxzk.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return;
            int nrow = this.GrdQxzk.CurrentCell.RowNumber;
            Guid sBinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            string sName = myTb.Rows[nrow]["����"].ToString().Trim();
            string sSDept = myTb.Rows[nrow]["Դ����"].ToString().Trim();
            string sDDept = myTb.Rows[nrow]["Ŀ�����"].ToString().Trim();
            long nSDeptID = Convert.ToInt64(myTb.Rows[nrow]["s_Dept_id"]);
            long nDDeptID = Convert.ToInt64(myTb.Rows[nrow]["d_Dept_id"]);
            Guid sOrderId = new Guid(myTb.Rows[nrow]["order_id"].ToString().Trim());
            Guid sId = new Guid(myTb.Rows[nrow]["id"].ToString().Trim());
            string sSql = "";
            bool IsExistOrder = false;

            if (sOrderId == Guid.Empty)
            {
                if (MessageBox.Show("û���ҵ�����ת����Ϣ��ת��ҽ����ȡ����ת����Ϣ������ͬʱȡ��ת��ҽ�����Ƿ������", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }
            else
            {
                IsExistOrder = true;
            }
            string sMsg = IsExistOrder ? "\nͬʱ��ȡ��ת��ҽ����" : "";
            if (MessageBox.Show("�Ƿ�ȷ��ȡ������ " + sName + " �� " + sSDept + " �� " + sDDept + " ��ת����Ϣ��" + sMsg, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            //�ٴ��жϲ���״̬
            sSql = "select flag from vi_zy_vinpatient_info where (flag=1 or dept_id=" + nSDeptID + ") and inpatient_id='" + sBinID + "' and baby_id=0";//Modify By tany 2011-03-07 ֻ�жϴ��˵�״̬" + sBabyID;
            DataTable patTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (patTb == null || patTb.Rows.Count == 0)
            {
                MessageBox.Show("�Բ���û���ҵ�������Ϣ�����Ѿ����䴲λ�����ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmZK_Load(sender, e);
                return;
            }

            string[] sqls = new string[5];
            sqls[0] = "update zy_inpatient set dept_id=" + nSDeptID + " where dept_id=" + nDDeptID + " and inpatient_id='" + sBinID + "'";

            //sqls[1] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
            //    " where id='" + sId + "'";

            //Modify by tany 2011-03-07 ȡ�����иò��˰���Ӥ����ת�Ƽ�¼
            sqls[1] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                " where inpatient_id='" + sBinID + "' and s_dept_id=" + nSDeptID;

            if (IsExistOrder)
            {
                sqls[2] = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
            }

            //Modify By tany 2011-03-07 ȡ��Ӥ����ת�Ƽ�¼
            sqls[3] = "update a set a.dept_id=" + nSDeptID + ",a.flag=b.flag,a.bed_id=b.bed_id from zy_inpatient_baby a inner join zy_inpatient b on a.inpatient_id=b.inpatient_id where a.dept_id=" + nDDeptID + " and a.inpatient_id='" + sBinID + "'";
            sqls[4] = "update zy_beddiction set ismyts=isnull((select count(1) from zy_inpatient_baby where inpatient_id='" + sBinID + "'),0) where inpatient_id='" + sBinID + "'";

            InstanceForm.BDatabase.DoCommand(null, null, null, sqls);

            //д��־ Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "ȡ��ת��", "����" + myTb.Rows[nrow]["����"].ToString().Trim() + " " + sBinID + " " + sBabyID + "��ȡ��ת��", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            frmZK_Load(sender, e);
        }

        private void frmBRZK_Load(object sender, System.EventArgs e)
        {

        }

    }
}

