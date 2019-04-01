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

namespace ts_zyhs_czbr
{
    /// <summary>
    /// Form4 ��ժҪ˵����
    /// </summary>
    public class frmCZBR : System.Windows.Forms.Form
    {
        //�û��������		
        private BaseFunc myFunc;
        private string dept_lcke = "";//add by ���ɳ� 2014-08-14
        private bool flag = false;//add by ���ɳ� 2014-08-14
        int dept_id = 0;//add by ���ɳ� 2014-08-14

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bt�˳�;
        private System.Windows.Forms.DateTimePicker dtpBeginDate1;
        private System.Windows.Forms.DateTimePicker dtpEndDate1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpBeginDate2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndDate2;
        private System.Windows.Forms.CheckBox cb����;
        private System.Windows.Forms.CheckBox cbסԺ��;
        private System.Windows.Forms.TextBox tbסԺ��;
        private System.Windows.Forms.TextBox tb����;
        private System.Windows.Forms.Button bt����;
        private System.Windows.Forms.CheckBox cb��Ժʱ��;
        private System.Windows.Forms.CheckBox cb��Ժʱ��;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkZK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpZKBdate;
        private System.Windows.Forms.DateTimePicker dtpZKEdate;
        private Button bt����;
        private DataGridView myDataGrid1;
        private Label label7;
        private Trasen.Controls.LabelTextBox labelTextBox1;
        private Trasen.Controls.ShowCardComponent showCardComponent1;
        private Trasen.Controls.ShowCardColumn showCardColumn1;
        private Trasen.Controls.ShowCardColumn showCardColumn2;
        private Trasen.Controls.ShowCardColumn showCardColumn3;
        private Trasen.Controls.ShowCardColumn showCardColumn4;
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmCZBR(string _formText)
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
            Trasen.Controls.ShowCardProperty showCardProperty1 = new Trasen.Controls.ShowCardProperty();
            this.showCardColumn1 = new Trasen.Controls.ShowCardColumn();
            this.showCardColumn2 = new Trasen.Controls.ShowCardColumn();
            this.showCardColumn3 = new Trasen.Controls.ShowCardColumn();
            this.showCardColumn4 = new Trasen.Controls.ShowCardColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt���� = new System.Windows.Forms.Button();
            this.bt�˳� = new System.Windows.Forms.Button();
            this.bt���� = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelTextBox1 = new Trasen.Controls.LabelTextBox();
            this.showCardComponent1 = new Trasen.Controls.ShowCardComponent();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkZK = new System.Windows.Forms.CheckBox();
            this.dtpZKBdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpZKEdate = new System.Windows.Forms.DateTimePicker();
            this.tb���� = new System.Windows.Forms.TextBox();
            this.tbסԺ�� = new System.Windows.Forms.TextBox();
            this.cb���� = new System.Windows.Forms.CheckBox();
            this.cbסԺ�� = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpBeginDate2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndDate2 = new System.Windows.Forms.DateTimePicker();
            this.cb��Ժʱ�� = new System.Windows.Forms.CheckBox();
            this.cb��Ժʱ�� = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginDate1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // showCardColumn1
            // 
            this.showCardColumn1.DataPropertyName = "NAME";
            this.showCardColumn1.IsFilterColumn = true;
            this.showCardColumn1.IsNumeric = false;
            this.showCardColumn1.Name = "showCardColumn1";
            // 
            // showCardColumn2
            // 
            this.showCardColumn2.DataPropertyName = "DEPT_ID";
            this.showCardColumn2.IsFilterColumn = false;
            this.showCardColumn2.IsNumeric = false;
            this.showCardColumn2.Name = "showCardColumn2";
            // 
            // showCardColumn3
            // 
            this.showCardColumn3.DataPropertyName = "pym";
            this.showCardColumn3.IsFilterColumn = true;
            this.showCardColumn3.IsNumeric = false;
            this.showCardColumn3.Name = "showCardColumn3";
            // 
            // showCardColumn4
            // 
            this.showCardColumn4.DataPropertyName = "wbm";
            this.showCardColumn4.IsFilterColumn = true;
            this.showCardColumn4.IsNumeric = false;
            this.showCardColumn4.Name = "showCardColumn4";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 557);
            this.panel1.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1110, 450);
            this.panel3.TabIndex = 2;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowUserToAddRows = false;
            this.myDataGrid1.AllowUserToDeleteRows = false;
            this.myDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.RowTemplate.Height = 23;
            this.myDataGrid1.Size = new System.Drawing.Size(1110, 450);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.myDataGrid1_RowPostPaint);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 103);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1110, 4);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt����);
            this.panel2.Controls.Add(this.bt�˳�);
            this.panel2.Controls.Add(this.bt����);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1110, 103);
            this.panel2.TabIndex = 0;
            // 
            // bt����
            // 
            this.bt����.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bt����.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt����.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt����.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt����.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt����.ImageIndex = 4;
            this.bt����.Location = new System.Drawing.Point(999, 40);
            this.bt����.Name = "bt����";
            this.bt����.Size = new System.Drawing.Size(103, 24);
            this.bt����.TabIndex = 46;
            this.bt����.Text = "����(&D)";
            this.bt����.Click += new System.EventHandler(this.bt����_Click);
            // 
            // bt�˳�
            // 
            this.bt�˳�.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bt�˳�.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt�˳�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�˳�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�˳�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�˳�.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt�˳�.ImageIndex = 4;
            this.bt�˳�.Location = new System.Drawing.Point(999, 65);
            this.bt�˳�.Name = "bt�˳�";
            this.bt�˳�.Size = new System.Drawing.Size(103, 24);
            this.bt�˳�.TabIndex = 45;
            this.bt�˳�.Text = "�˳�(&E)";
            this.bt�˳�.Click += new System.EventHandler(this.bt�˳�_Click);
            // 
            // bt����
            // 
            this.bt����.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bt����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt����.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt����.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt����.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt����.ImageIndex = 4;
            this.bt����.Location = new System.Drawing.Point(999, 15);
            this.bt����.Name = "bt����";
            this.bt����.Size = new System.Drawing.Size(103, 24);
            this.bt����.TabIndex = 44;
            this.bt����.Text = "����(&F)";
            this.bt����.Click += new System.EventHandler(this.bt����_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 4;
            this.button4.Location = new System.Drawing.Point(991, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 89);
            this.button4.TabIndex = 42;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTextBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkZK);
            this.groupBox2.Controls.Add(this.dtpZKBdate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpZKEdate);
            this.groupBox2.Controls.Add(this.tb����);
            this.groupBox2.Controls.Add(this.tbסԺ��);
            this.groupBox2.Controls.Add(this.cb����);
            this.groupBox2.Controls.Add(this.cbסԺ��);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpBeginDate2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpEndDate2);
            this.groupBox2.Controls.Add(this.cb��Ժʱ��);
            this.groupBox2.Controls.Add(this.cb��Ժʱ��);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpBeginDate1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpEndDate1);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(977, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ѡ��ʱ��";
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.ActiveColor = System.Drawing.Color.Empty;
            this.labelTextBox1.AllowDefaultValue = false;
            this.labelTextBox1.AllowGotoNextControlWithoutNoneSelected = false;
            this.labelTextBox1.AllowPressEnterKeyCheckValue = false;
            this.labelTextBox1.AutoTabSend = false;
            this.labelTextBox1.ButtonVisible = false;
            this.labelTextBox1.DisplayMember = null;
            this.labelTextBox1.DisplayShowCardWhenActived = false;
            this.labelTextBox1.DoSelectedWhenTextEmpty = true;
            this.labelTextBox1.Enable = true;
            this.labelTextBox1.InputValueStyle = Trasen.Controls.InputValueStyle.String;
            this.labelTextBox1.LabelText = "";
            this.labelTextBox1.Location = new System.Drawing.Point(871, 38);
            this.labelTextBox1.MaxLength = 32767;
            this.labelTextBox1.Multiline = false;
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.ReadOnly = false;
            this.labelTextBox1.SelectAllTextAfterClick = false;
            this.labelTextBox1.SelectedValue = null;
            this.labelTextBox1.SelectionLength = 0;
            this.labelTextBox1.SelectionStart = 0;
            this.labelTextBox1.SetValueEqualTextWhenNoneSelected = false;
            this.labelTextBox1.ShowCardComponent = this.showCardComponent1;
            this.labelTextBox1.ShowCardEnable = true;
            showCardProperty1.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty1.BindColumnName = null;
            showCardProperty1.ColumnHeaderVisible = false;
            showCardProperty1.DbConnection = null;
            showCardProperty1.RealTimeQuery = false;
            showCardProperty1.RowHeaderVisible = false;
            showCardProperty1.ShowCardColumns = new Trasen.Controls.ShowCardColumn[] {
        this.showCardColumn1,
        this.showCardColumn2,
        this.showCardColumn3,
        this.showCardColumn4};
            showCardProperty1.ShowCardDataSource = null;
            showCardProperty1.ShowCardDataSourceSqlString = null;
            showCardProperty1.ShowCardSize = new System.Drawing.Size(0, 0);
            this.labelTextBox1.ShowCardProperty = new Trasen.Controls.ShowCardProperty[] {
        showCardProperty1};
            this.labelTextBox1.Size = new System.Drawing.Size(97, 24);
            this.labelTextBox1.TabIndex = 28;
            this.labelTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.labelTextBox1.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.labelTextBox1.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.labelTextBox1.TextBoxStyle = Trasen.Controls.LabelTextBox.TextBoxStyleEnum.Standard;
            this.labelTextBox1.ValueMember = null;
            // 
            // showCardComponent1
            // 
            this.showCardComponent1.MatchType = Trasen.Controls.MatchType.ģ����ѯ;
            this.showCardComponent1.ShowCardSelectedMode = Trasen.Controls.ShowCardSelectedMode.Click;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(869, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "ѡ����ң�";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(440, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "��";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkZK
            // 
            this.chkZK.Location = new System.Drawing.Point(440, 16);
            this.chkZK.Name = "chkZK";
            this.chkZK.Size = new System.Drawing.Size(88, 24);
            this.chkZK.TabIndex = 24;
            this.chkZK.Text = "ת��ʱ�䣺";
            this.chkZK.CheckedChanged += new System.EventHandler(this.chkZK_CheckedChanged);
            // 
            // dtpZKBdate
            // 
            this.dtpZKBdate.CustomFormat = "";
            this.dtpZKBdate.Enabled = false;
            this.dtpZKBdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpZKBdate.Location = new System.Drawing.Point(456, 40);
            this.dtpZKBdate.Name = "dtpZKBdate";
            this.dtpZKBdate.Size = new System.Drawing.Size(88, 21);
            this.dtpZKBdate.TabIndex = 23;
            this.dtpZKBdate.Value = new System.DateTime(2003, 9, 27, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(544, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "��";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpZKEdate
            // 
            this.dtpZKEdate.Enabled = false;
            this.dtpZKEdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpZKEdate.Location = new System.Drawing.Point(560, 40);
            this.dtpZKEdate.Name = "dtpZKEdate";
            this.dtpZKEdate.Size = new System.Drawing.Size(88, 21);
            this.dtpZKEdate.TabIndex = 21;
            this.dtpZKEdate.Value = new System.DateTime(2003, 9, 27, 23, 59, 0, 0);
            // 
            // tb����
            // 
            this.tb����.Enabled = false;
            this.tb����.Location = new System.Drawing.Point(768, 40);
            this.tb����.Name = "tb����";
            this.tb����.Size = new System.Drawing.Size(100, 21);
            this.tb����.TabIndex = 20;
            // 
            // tbסԺ��
            // 
            this.tbסԺ��.Enabled = false;
            this.tbסԺ��.Location = new System.Drawing.Point(656, 40);
            this.tbסԺ��.Name = "tbסԺ��";
            this.tbסԺ��.Size = new System.Drawing.Size(100, 21);
            this.tbסԺ��.TabIndex = 19;
            // 
            // cb����
            // 
            this.cb����.Location = new System.Drawing.Point(768, 16);
            this.cb����.Name = "cb����";
            this.cb����.Size = new System.Drawing.Size(80, 24);
            this.cb����.TabIndex = 18;
            this.cb����.Text = "������";
            this.cb����.CheckedChanged += new System.EventHandler(this.cb����_CheckedChanged);
            // 
            // cbסԺ��
            // 
            this.cbסԺ��.Location = new System.Drawing.Point(656, 16);
            this.cbסԺ��.Name = "cbסԺ��";
            this.cbסԺ��.Size = new System.Drawing.Size(80, 24);
            this.cbסԺ��.TabIndex = 17;
            this.cbסԺ��.Text = "סԺ�ţ�";
            this.cbסԺ��.CheckedChanged += new System.EventHandler(this.cbסԺ��_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(224, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "��";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBeginDate2
            // 
            this.dtpBeginDate2.CustomFormat = "";
            this.dtpBeginDate2.Enabled = false;
            this.dtpBeginDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeginDate2.Location = new System.Drawing.Point(240, 40);
            this.dtpBeginDate2.Name = "dtpBeginDate2";
            this.dtpBeginDate2.Size = new System.Drawing.Size(88, 21);
            this.dtpBeginDate2.TabIndex = 16;
            this.dtpBeginDate2.Value = new System.DateTime(2003, 9, 27, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(328, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "��";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndDate2
            // 
            this.dtpEndDate2.Enabled = false;
            this.dtpEndDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate2.Location = new System.Drawing.Point(344, 40);
            this.dtpEndDate2.Name = "dtpEndDate2";
            this.dtpEndDate2.Size = new System.Drawing.Size(88, 21);
            this.dtpEndDate2.TabIndex = 13;
            this.dtpEndDate2.Value = new System.DateTime(2003, 9, 27, 23, 59, 0, 0);
            // 
            // cb��Ժʱ��
            // 
            this.cb��Ժʱ��.Location = new System.Drawing.Point(224, 16);
            this.cb��Ժʱ��.Name = "cb��Ժʱ��";
            this.cb��Ժʱ��.Size = new System.Drawing.Size(88, 24);
            this.cb��Ժʱ��.TabIndex = 12;
            this.cb��Ժʱ��.Text = "��Ժʱ�䣺";
            this.cb��Ժʱ��.CheckedChanged += new System.EventHandler(this.cb��Ժ_CheckedChanged);
            // 
            // cb��Ժʱ��
            // 
            this.cb��Ժʱ��.Checked = true;
            this.cb��Ժʱ��.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb��Ժʱ��.Location = new System.Drawing.Point(8, 16);
            this.cb��Ժʱ��.Name = "cb��Ժʱ��";
            this.cb��Ժʱ��.Size = new System.Drawing.Size(88, 24);
            this.cb��Ժʱ��.TabIndex = 11;
            this.cb��Ժʱ��.Text = "��Ժʱ�䣺";
            this.cb��Ժʱ��.CheckedChanged += new System.EventHandler(this.cb��Ժ_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "��";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBeginDate1
            // 
            this.dtpBeginDate1.CustomFormat = "";
            this.dtpBeginDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeginDate1.Location = new System.Drawing.Point(24, 40);
            this.dtpBeginDate1.Name = "dtpBeginDate1";
            this.dtpBeginDate1.Size = new System.Drawing.Size(88, 21);
            this.dtpBeginDate1.TabIndex = 10;
            this.dtpBeginDate1.Value = new System.DateTime(2003, 9, 27, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(112, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "��";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndDate1
            // 
            this.dtpEndDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate1.Location = new System.Drawing.Point(128, 40);
            this.dtpEndDate1.Name = "dtpEndDate1";
            this.dtpEndDate1.Size = new System.Drawing.Size(88, 21);
            this.dtpEndDate1.TabIndex = 7;
            this.dtpEndDate1.Value = new System.DateTime(2003, 9, 27, 23, 59, 0, 0);
            // 
            // frmCZBR
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1110, 557);
            this.Controls.Add(this.panel1);
            this.Name = "frmCZBR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "���Ҳ���";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCZBR_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmCZBR_Load(object sender, System.EventArgs e)
        {

            this.dtpBeginDate1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            this.dtpEndDate1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            this.dtpBeginDate2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            this.dtpEndDate2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            this.dtpZKBdate.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            this.dtpZKEdate.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            Setcmbdeptdatasourse();



            //by add���ɳ� 2014-07-21
            //string[] GrdMappingName ={ "���","��Ժʱ��", "��Ժ���", "סԺ��", "����", "����", "�Ա�", "����", "��Ժ����", "��ǰ����", "��λ", "��ͥ��ַ", "��������", "��ϵ�绰", "��������", "����ҽ��", "����ҽ��", "����ʿ", "��Ժʱ��", "��������", "סԺ����", "ת��", "��Ժ���", "����", "inpatient_id" };
            // int[] GrdWidth ={ 6,10, 30, 9, 6, 10, 4, 4, 15, 15, 30, 30, 12, 16, 8, 8, 8, 8, 10, 10, 8, 4, 30, 4, 0 };
            // int[] Alignment ={ 0,0, 0, 0, 1, 0, 1, 2, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 };
            //int[] ReadOnly ={ 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //myFunc.InitGrid(GrdMappingName,GrdWidth,Alignment,ReadOnly,this.myDataGrid1);
            //PubStaticFun.ModifyDataGridStyle(myDataGrid1,0);
        }
        /// <summary>
        /// ���������������Դ
        /// </summary>



        private void Setcmbdeptdatasourse()
        {
            ts_zyhs_czbr.InstanceForm instanceForm = new InstanceForm();
            instanceForm.CurrentDept = TrasenFrame.Forms.FrmMdiMain.CurrentDept;
            //dept_id = instanceForm.CurrentDept.DeptId;//��ǰ��¼����ID
            dept_id = instanceForm.CurrentDept.WardDeptId;
            //��ѯ������ٴ�����
            string sqllc = "select WARD_NAME AS NAME ,dbo.GETPYWB(NAME,0) pym,dbo.GETPYWB(NAME,1) wbm,t.DEPT_ID from  JC_DEPT_PROPERTY t inner join JC_WARDRDEPT t1 on t.DEPT_ID=t1.DEPT_ID inner join  JC_WARD t2 on t1.WARD_ID=t2.WARD_ID  where t.ZY_FLAG=1 and t2.DEPT_ID ='" + dept_id + "'";
            DataTable dtlc = new DataTable();
            dtlc = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sqllc);
            if (dtlc.Rows.Count == 1)
            {
                //cmbdept.DataSource = dtlc;
                //cmbdept.DisplayMember = "NAME";
                //cmbdept.ValueMember = "DEPT_ID";
                #region add by ���ɳ� 2014-08-12
                labelTextBox1.ShowCardProperty[0].ShowCardDataSource = dtlc;
                labelTextBox1.DisplayMember = "NAME";
                labelTextBox1.ValueMember = "DEPT_ID";
                labelTextBox1.Text = dtlc.Rows[0]["NAME"].ToString();
                dept_lcke = dtlc.Rows[0]["DEPT_ID"].ToString();
                flag = false;
                #endregion
            }
            else
            {
                string sqlflc = "select DEPT_ID, NAME,dbo.GETPYWB(NAME,0) pym,dbo.GETPYWB(NAME,1) wbm from JC_DEPT_PROPERTY where LAYER=3";
                DataTable dtflc = new DataTable();
                dtflc = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sqlflc);
                //cmbdept.DataSource = dtflc;
                //cmbdept.DisplayMember = "NAME";
                //cmbdept.ValueMember = "DEPT_ID";
                #region add by ���ɳ� 2014-08-12
                labelTextBox1.ShowCardProperty[0].ShowCardDataSource = dtflc;
                labelTextBox1.DisplayMember = "NAME";
                labelTextBox1.ValueMember = "DEPT_ID";
                flag = true;
                #endregion
            }
        }
        private void Show_Data()
        {

            string sSql = "select a.in_date ��Ժʱ�� ,e.name ��Ժ���," +
                        "       a.inpatient_no סԺ��,d.bed_no ����,a.name ����,s.name �Ա�,datediff(dd,a.BIRTHDAY,getdate())/365 ���� ,dbo.FUN_ZY_SEEKdeptname(a.in_dept) ��Ժ����,dbo.FUN_ZY_SEEKdeptname(a.dept_id) ��ǰ����,a.gzdw ��λ,a.home_street ��ͥ��ַ,a.home_zip ��������,a.RELATION_TEL ��ϵ�绰," +
                        "       dbo.FUN_ZY_SEEKJSFSNAME(a.dischargetype) ��������,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zy_doc) ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.clinic_doc) ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.CHARGENURSE) ����ʿ ," +
                        "       a.out_date ��Ժʱ��,g.discharge_date ��������,datediff(dd,a.in_date,a.out_date) סԺ����," +
                        "       case a.out_mode when 1 then '����' when 2 then '��ת' when 3 then 'δ��' when 4 then '����' when 9 then '����' else '' end ת��, f.name ��Ժ��� ," +
                        "       case when c.order_bz is not null and c.order_bz<>dbo.fun_getemptyguid() then '����' when c.order_bw is not null and c.order_bw<>dbo.fun_getemptyguid() then '��Σ'  else ''end ���� ,a.inpatient_id סԺ���˱���" +
                        "  from vi_zy_vinpatient_all a left join zy_beddiction d on a.bed_id=d.bed_id left join zy_inpatient_hl c on a.inpatient_id=c.inpatient_id and c.baby_id=0 " +
                        "  left join jc_disease e on a.in_diagnosis=e.coding and isnull(a.ybjklx,0)=e.ybjklx and e. BSCBZ=0 " +
                        "  left join jc_disease f on a.out_diagnosis=f.coding and isnull(a.ybjklx,0)=f.ybjklx and f. BSCBZ=0  " +
                        "  left join zy_discharge g on a.inpatient_id=g.inpatient_id and g.cancel_bit=0 and g.cz_flag=0 " +
                        "  LEFT JOIN JC_SEXCODE s ON a.SEXCODE=convert(int,s.CODE) where 1=1 ";
            //  "  and a.dept_id='" + cmbdept.SelectedValue + "'"; by add ���ɳ�20147-07-21
            if (chkZK.Checked)
            {
                #region add by ���ɳ� 2014-08-12
                string dept_idtxt = "";
                if (flag)
                {
                    dept_idtxt = labelTextBox1.SelectedValue.ToString();
                }
                else
                {
                    dept_idtxt = dept_lcke;
                }
                string sql = "select t.DEPT_ID as DEPT_ID  from  JC_DEPT_PROPERTY t inner join JC_WARDRDEPT t1 on t.DEPT_ID=t1.DEPT_ID inner join  JC_WARD t2 on t1.WARD_ID=t2.WARD_ID  where t.ZY_FLAG=1 and t2.DEPT_ID ='" + dept_idtxt + "'";
                DataTable dt = new DataTable();
                dt = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sql);
                string dept_id_zk = "";
                if (dt.Rows.Count > 0)//Ϊ�ٴ�����
                {
                    dept_id_zk = dt.Rows[0][0].ToString();  //in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"')";by add ���ɳ� 2014-07-21
                }
                else
                {
                    if (string.IsNullOrEmpty(labelTextBox1.Text.Trim()))
                    {
                        dept_id_zk = "-1";//�鿴ȫԺ����Ϣ
                    }
                    else
                    {
                        dept_id_zk = dept_idtxt;
                    }
                }

                sSql += " and a.inpatient_id in (select inpatient_id from zy_transfer_dept a where a.finish_bit=1 " +
                  " and a.cancel_bit=0 and a.transfer_date between '" + dtpZKBdate.Value.ToString() + "' and '" + dtpZKEdate.Value.ToString() + "' "
                  + " and a.s_dept_id =' " + dept_id_zk + "'" + "or a.D_DEPT_ID='" + dept_id_zk+"'" + "or -1 = " + dept_id_zk + ")";//����ֻҪ����ѡ���Ҵ�����������ʾ����   add  by  chenli
                #endregion
                //in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"') "+// by add ���ɳ� 2014-07-21
                //" and a.d_dept_id not in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"'))";by add ���ɳ� 2014-07-21
            }
            else
            {
                #region add by ���ɳ� 2014-08-12
                string dept_idtxt = "";
                if (flag)
                {
                    if (string.IsNullOrEmpty(labelTextBox1.Text.Trim()))
                    {
                        dept_idtxt = "-1";
                    }
                    else
                    {
                        dept_idtxt = labelTextBox1.SelectedValue.ToString();
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(labelTextBox1.Text.Trim()))
                    {
                        dept_idtxt = "-1";//�鿴ȫԺ����Ϣ
                    }
                    else
                    {
                        dept_idtxt = dept_lcke;
                    }
                }
                string sql = "select t.DEPT_ID as DEPT_ID  from  JC_DEPT_PROPERTY t inner join JC_WARDRDEPT t1 on t.DEPT_ID=t1.DEPT_ID inner join  JC_WARD t2 on t1.WARD_ID=t2.WARD_ID  where t.ZY_FLAG=1 and t2.DEPT_ID ='" + dept_idtxt + "'";
                DataTable dt = new DataTable();
                dt = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count > 0)//Ϊ�ٴ�����
                {
                    sSql += " and (a.dept_id  ='" + dt.Rows[0][0].ToString() + "' or -1 = " + dept_idtxt + ")"; //in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"')";by add ���ɳ� 2014-07-21
                }
                else
                {
                    sSql += " and (a.dept_id  ='" + dept_idtxt + "' or -1 = " + dept_idtxt + ")";
                }
                #endregion
            }
            //Modify By Tany 2015-03-11 ͳһ���ӹ������Ų���
            if (this.cb��Ժʱ��.Checked)
            {
                sSql += " and a.flag<>10 and a.in_date between '" + this.dtpBeginDate1.Value.ToString() + "' and '" + this.dtpEndDate1.Value.ToString() + "'";
            }
            if (this.cb��Ժʱ��.Checked)
            {
                sSql += " and flag in (2,4,5,6) and a.out_date between '" + this.dtpBeginDate2.Value.ToString() + "' and '" + this.dtpEndDate2.Value.ToString() + "'";
            }
            if (this.cbסԺ��.Checked && this.tbסԺ��.Text.Trim() != "")
            {
                sSql += " and a.flag<>10 and a.inpatient_no like '" + this.tbסԺ��.Text.Trim() + "%' ";
            }
            if (this.cb����.Checked && this.tb����.Text.Trim() != "")
            {
                sSql += " and a.flag<>10 and a.name like '" + this.tb����.Text.Trim() + "%' ";
            }
            sSql += " order by a.in_date,a.inpatient_no";
            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
            myDataGrid1.DataSource = tb;
        }

        private void cb��Ժ_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dtpBeginDate1.Enabled = this.cb��Ժʱ��.Checked ? true : false;
            this.dtpEndDate1.Enabled = this.dtpBeginDate1.Enabled;
        }

        private void cb��Ժ_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dtpBeginDate2.Enabled = this.cb��Ժʱ��.Checked ? true : false;
            this.dtpEndDate2.Enabled = this.dtpBeginDate2.Enabled;
        }

        private void cbסԺ��_CheckedChanged(object sender, System.EventArgs e)
        {
            this.tbסԺ��.Enabled = this.cbסԺ��.Checked ? true : false;
            if (this.tbסԺ��.Enabled == false) this.tbסԺ��.Text = "";
        }

        private void cb����_CheckedChanged(object sender, System.EventArgs e)
        {
            this.tb����.Enabled = this.cb����.Checked ? true : false;
            if (this.tb����.Enabled == false) this.tb����.Text = "";
        }

        private void bt����_Click(object sender, System.EventArgs e)
        {
            if (this.cb��Ժʱ��.Checked && this.dtpEndDate1.Value < this.dtpBeginDate1.Value)
            {
                MessageBox.Show(this, "�Բ�����Ժʱ��Ľ���ʱ�䲻��С�ڿ�ʼʱ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtpEndDate1.Focus();
                return;
            }

            if (this.cb��Ժʱ��.Checked && this.dtpEndDate2.Value < this.dtpBeginDate2.Value)
            {
                MessageBox.Show(this, "�Բ��𣬳�Ժʱ��Ľ���ʱ�䲻��С�ڿ�ʼʱ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtpEndDate2.Focus();
                return;
            }

            if (this.chkZK.Checked && this.dtpZKEdate.Value < this.dtpZKBdate.Value)
            {
                MessageBox.Show(this, "�Բ���ת��ʱ��Ľ���ʱ�䲻��С�ڿ�ʼʱ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtpZKEdate.Focus();
                return;
            }

            if (this.cbסԺ��.Checked == true && this.tbסԺ��.Text.Trim() == "")
            {
                MessageBox.Show(this, "�Բ���������סԺ�ţ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tbסԺ��.Focus();
                return;
            }

            if (this.cb����.Checked == true && this.tb����.Text.Trim() == "")
            {
                MessageBox.Show(this, "�Բ���������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tb����.Focus();
                return;
            }

            if (this.cb��Ժʱ��.Checked == false && this.cb��Ժʱ��.Checked == false && chkZK.Checked == false && this.cbסԺ��.Checked == false && this.cb����.Checked == false)
            {
                MessageBox.Show(this, "�Բ�����ѡ���ѯ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Show_Data();
        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            //myFunc.SelRow(this.myDataGrid1);by add ���ɳ� 2014-07-21
        }

        private void chkZK_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dtpZKBdate.Enabled = this.chkZK.Checked ? true : false;
            this.dtpZKEdate.Enabled = this.dtpZKBdate.Enabled;
        }

        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
        }

        private void bt�˳�_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void bt����_Click(object sender, EventArgs e)//by add ���ɳ� 2014-07-21
        {
            ts_jc_log.ExcelOper.ExportData_ForDataTable(myDataGrid1, "������Ϣ��");
        }

        private void myDataGrid1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //by add ���ɳ� 2014-07-21
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, myDataGrid1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            myDataGrid1.RowHeadersDefaultCellStyle.Font, rectangle, myDataGrid1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
