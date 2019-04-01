using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using YpClass;
using System.IO;
namespace ts_zyhs_jyddy
{
	/// <summary>
	/// ���鵥��ӡ ��ժҪ˵����
	/// </summary>
	public class frmjydqf : System.Windows.Forms.Form
	{

        //�Զ������
		private BaseFunc myFunc;
		private int nType=0;
        private TheReportDateSet rds = new TheReportDateSet();
        private System.Windows.Forms.Panel panel4;
        private GroupBox groupBox3;
        private RadioButton rdowdy;
        private RadioButton rdoydy;
        private Button btCancel;
        private Button btnfyqr;
        private Button btnRefresh;
        private Button button3;
        private Panel panel1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TextBox txtcwh;
        private Label label4;
        private Label label3;
        private TextBox txtzyh;
        private Panel panel2;
        private myDataGrid.myDataGrid myDataGrid1;
        private DataGridTableStyle dataGridTableStyle1;
        private DataGridTextBoxColumn ���;
        private DataGridBoolColumn ѡ��;
        private DataGridTextBoxColumn סԺ��;
        private DataGridTextBoxColumn ����;
        private DataGridTextBoxColumn ����;
        private DataGridTextBoxColumn �Ա�;
        private DataGridTextBoxColumn ����;
        private DataGridTextBoxColumn ��Ŀ����;
        private DataGridTextBoxColumn ��ϼ���ʷ;
        private DataGridTextBoxColumn ����˵��;
        private DataGridTextBoxColumn �걾����;
        private DataGridTextBoxColumn ���;
        private DataGridTextBoxColumn ִ�п���;
        private DataGridTextBoxColumn ��Ŀ����;
        private DataGridTextBoxColumn ��������;
        private DataGridTextBoxColumn ��ӡ;
        private DataGridTextBoxColumn ����ҽ��;
        private DataGridTextBoxColumn ȷ������;
        private DataGridTextBoxColumn ȷ����;
        private DataGridTextBoxColumn ������;
        private DataGridTextBoxColumn order_id;
        private DataGridTextBoxColumn lx;
        private DataGridTextBoxColumn ״̬;
        private DataGridTextBoxColumn inpatient_id;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private DataGridTextBoxColumn ����;
        private Label label5;
        private TextBox txtname;
        private RadioButton rdorq1;
        private RadioButton rdorq2;
        private Label label1;
        private TextBox txttxm;
        private RadioButton rdoall;
        private DataGridTextBoxColumn ����;
        private PrintPreviewDialog printPreviewDialog1;
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")] 
        private static extern bool BitBlt(

            IntPtr hdcDest, //Ŀ���������豸�ľ�� 

            int nXDest, //Ŀ��ͼ�ε����Ͻǵ�x���� 

            int nYDest, //Ŀ��ͼ�ε����Ͻǵ�y���� 

            int nWidth, //Ŀ��ͼ�εľ��ο�� 

            int nHeight, //Ŀ��ͼ�εľ��θ߶� 

            IntPtr hdcSrc, //Դ�������豸�ľ�� 

            int nXSrc, //Դͼ�ε����Ͻǵ�x���� 

            int nYSrc, //Դͼ�ε����Ͻǵ�x���� 

            System.Int32 dwRop //��դ�������� 

            );
        public System.Drawing.Brush brush;
        public System.Drawing.Font font;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmjydqf(string _formText,int _type)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
			this.Text=_formText;
			nType=_type;
			
			myFunc=new BaseFunc();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmjydqf));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.��� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ѡ�� = new System.Windows.Forms.DataGridBoolColumn();
            this.��ӡ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.״̬ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.סԺ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.�Ա� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.������ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��Ŀ���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ִ�п��� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��Ŀ���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.�걾���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.����˵�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.�������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.����ҽ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ȷ������ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ȷ���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��ϼ���ʷ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.order_id = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lx = new System.Windows.Forms.DataGridTextBoxColumn();
            this.inpatient_id = new System.Windows.Forms.DataGridTextBoxColumn();
            this.���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txttxm = new System.Windows.Forms.TextBox();
            this.rdorq1 = new System.Windows.Forms.RadioButton();
            this.rdorq2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtcwh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.rdowdy = new System.Windows.Forms.RadioButton();
            this.rdoydy = new System.Windows.Forms.RadioButton();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnfyqr = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(909, 557);
            this.panel4.TabIndex = 74;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 451);
            this.panel2.TabIndex = 78;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(909, 451);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.���,
            this.ѡ��,
            this.��ӡ,
            this.״̬,
            this.����,
            this.סԺ��,
            this.����,
            this.����,
            this.�Ա�,
            this.����,
            this.������,
            this.��Ŀ����,
            this.���,
            this.ִ�п���,
            this.��Ŀ����,
            this.�걾����,
            this.����˵��,
            this.��������,
            this.����ҽ��,
            this.ȷ������,
            this.ȷ����,
            this.��ϼ���ʷ,
            this.order_id,
            this.lx,
            this.inpatient_id,
            this.����});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // ���
            // 
            this.���.Format = "";
            this.���.FormatInfo = null;
            this.���.HeaderText = "���";
            this.���.Width = 40;
            // 
            // ѡ��
            // 
            this.ѡ��.FalseValue = ((short)(0));
            this.ѡ��.HeaderText = "ѡ��";
            this.ѡ��.NullValue = ((short)(0));
            this.ѡ��.TrueValue = ((short)(1));
            this.ѡ��.Width = 30;
            // 
            // ��ӡ
            // 
            this.��ӡ.Format = "";
            this.��ӡ.FormatInfo = null;
            this.��ӡ.HeaderText = "��ӡ";
            this.��ӡ.Width = 35;
            // 
            // ״̬
            // 
            this.״̬.Format = "";
            this.״̬.FormatInfo = null;
            this.״̬.HeaderText = "״̬";
            this.״̬.Width = 50;
            // 
            // ����
            // 
            this.����.Format = "";
            this.����.FormatInfo = null;
            this.����.HeaderText = "����";
            this.����.Width = 75;
            // 
            // סԺ��
            // 
            this.סԺ��.Format = "";
            this.סԺ��.FormatInfo = null;
            this.סԺ��.HeaderText = "סԺ��";
            this.סԺ��.Width = 65;
            // 
            // ����
            // 
            this.����.Format = "";
            this.����.FormatInfo = null;
            this.����.HeaderText = "����";
            this.����.Width = 40;
            // 
            // ����
            // 
            this.����.Format = "";
            this.����.FormatInfo = null;
            this.����.HeaderText = "����";
            this.����.Width = 50;
            // 
            // �Ա�
            // 
            this.�Ա�.Format = "";
            this.�Ա�.FormatInfo = null;
            this.�Ա�.HeaderText = "�Ա�";
            this.�Ա�.Width = 0;
            // 
            // ����
            // 
            this.����.Format = "";
            this.����.FormatInfo = null;
            this.����.HeaderText = "����";
            this.����.Width = 0;
            // 
            // ������
            // 
            this.������.Format = "";
            this.������.FormatInfo = null;
            this.������.HeaderText = "������";
            this.������.Width = 85;
            // 
            // ��Ŀ����
            // 
            this.��Ŀ����.Format = "";
            this.��Ŀ����.FormatInfo = null;
            this.��Ŀ����.HeaderText = "��Ŀ����";
            this.��Ŀ����.Width = 150;
            // 
            // ���
            // 
            this.���.Format = "";
            this.���.FormatInfo = null;
            this.���.HeaderText = "���";
            this.���.Width = 55;
            // 
            // ִ�п���
            // 
            this.ִ�п���.Format = "";
            this.ִ�п���.FormatInfo = null;
            this.ִ�п���.HeaderText = "ִ�п���";
            this.ִ�п���.Width = 0;
            // 
            // ��Ŀ����
            // 
            this.��Ŀ����.Format = "";
            this.��Ŀ����.FormatInfo = null;
            this.��Ŀ����.HeaderText = "��Ŀ����";
            this.��Ŀ����.Width = 0;
            // 
            // �걾����
            // 
            this.�걾����.Format = "";
            this.�걾����.FormatInfo = null;
            this.�걾����.HeaderText = "�걾����";
            this.�걾����.Width = 60;
            // 
            // ����˵��
            // 
            this.����˵��.Format = "";
            this.����˵��.FormatInfo = null;
            this.����˵��.HeaderText = "����˵��";
            this.����˵��.Width = 75;
            // 
            // ��������
            // 
            this.��������.Format = "";
            this.��������.FormatInfo = null;
            this.��������.HeaderText = "��������";
            this.��������.Width = 75;
            // 
            // ����ҽ��
            // 
            this.����ҽ��.Format = "";
            this.����ҽ��.FormatInfo = null;
            this.����ҽ��.HeaderText = "����ҽ��";
            this.����ҽ��.Width = 50;
            // 
            // ȷ������
            // 
            this.ȷ������.Format = "";
            this.ȷ������.FormatInfo = null;
            this.ȷ������.HeaderText = "ȷ������";
            this.ȷ������.Width = 75;
            // 
            // ȷ����
            // 
            this.ȷ����.Format = "";
            this.ȷ����.FormatInfo = null;
            this.ȷ����.HeaderText = "ȷ����";
            this.ȷ����.Width = 50;
            // 
            // ��ϼ���ʷ
            // 
            this.��ϼ���ʷ.Format = "";
            this.��ϼ���ʷ.FormatInfo = null;
            this.��ϼ���ʷ.HeaderText = "��ϼ���ʷ";
            this.��ϼ���ʷ.Width = 120;
            // 
            // order_id
            // 
            this.order_id.Format = "";
            this.order_id.FormatInfo = null;
            this.order_id.HeaderText = "order_id";
            this.order_id.Width = 75;
            // 
            // lx
            // 
            this.lx.Format = "";
            this.lx.FormatInfo = null;
            this.lx.HeaderText = "lx";
            this.lx.Width = 75;
            // 
            // inpatient_id
            // 
            this.inpatient_id.Format = "";
            this.inpatient_id.FormatInfo = null;
            this.inpatient_id.HeaderText = "inpatient_id";
            this.inpatient_id.Width = 75;
            // 
            // ����
            // 
            this.����.Format = "";
            this.����.FormatInfo = null;
            this.����.HeaderText = "����";
            this.����.Width = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txttxm);
            this.panel1.Controls.Add(this.rdorq1);
            this.panel1.Controls.Add(this.rdorq2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.txtcwh);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtzyh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnfyqr);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 106);
            this.panel1.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 91;
            this.label1.Text = "������";
            // 
            // txttxm
            // 
            this.txttxm.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttxm.Location = new System.Drawing.Point(55, 76);
            this.txttxm.Name = "txttxm";
            this.txttxm.Size = new System.Drawing.Size(336, 23);
            this.txttxm.TabIndex = 90;
            this.txttxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttxm_KeyPress);
            // 
            // rdorq1
            // 
            this.rdorq1.AutoSize = true;
            this.rdorq1.Location = new System.Drawing.Point(12, 15);
            this.rdorq1.Name = "rdorq1";
            this.rdorq1.Size = new System.Drawing.Size(71, 16);
            this.rdorq1.TabIndex = 89;
            this.rdorq1.Text = "ȷ������";
            this.rdorq1.UseVisualStyleBackColor = true;
            this.rdorq1.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // rdorq2
            // 
            this.rdorq2.AutoSize = true;
            this.rdorq2.Checked = true;
            this.rdorq2.Location = new System.Drawing.Point(92, 15);
            this.rdorq2.Name = "rdorq2";
            this.rdorq2.Size = new System.Drawing.Size(71, 16);
            this.rdorq2.TabIndex = 88;
            this.rdorq2.TabStop = true;
            this.rdorq2.Text = "��������";
            this.rdorq2.UseVisualStyleBackColor = true;
            this.rdorq2.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 87;
            this.label5.Text = "����";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(191, 46);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(97, 21);
            this.txtname.TabIndex = 86;
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // txtcwh
            // 
            this.txtcwh.Location = new System.Drawing.Point(326, 46);
            this.txtcwh.Name = "txtcwh";
            this.txtcwh.Size = new System.Drawing.Size(65, 21);
            this.txtcwh.TabIndex = 84;
            this.txtcwh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcwh_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 83;
            this.label4.Text = "����";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 82;
            this.label3.Text = "סԺ��";
            // 
            // txtzyh
            // 
            this.txtzyh.Location = new System.Drawing.Point(55, 46);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(97, 21);
            this.txtzyh.TabIndex = 81;
            this.txtzyh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzyh_KeyPress);
            this.txtzyh.TextChanged += new System.EventHandler(this.txtzyh_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 80;
            this.label2.Text = "��";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(293, 13);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(98, 21);
            this.dateTimePicker2.TabIndex = 78;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 21);
            this.dateTimePicker1.TabIndex = 77;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdoall);
            this.groupBox3.Controls.Add(this.rdowdy);
            this.groupBox3.Controls.Add(this.rdoydy);
            this.groupBox3.Location = new System.Drawing.Point(411, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 49);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ѡ������";
            // 
            // rdoall
            // 
            this.rdoall.Location = new System.Drawing.Point(9, 18);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(59, 16);
            this.rdoall.TabIndex = 3;
            this.rdoall.Text = "ȫ��";
            this.rdoall.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoall.Visible = false;
            this.rdoall.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // rdowdy
            // 
            this.rdowdy.Checked = true;
            this.rdowdy.Location = new System.Drawing.Point(68, 18);
            this.rdowdy.Name = "rdowdy";
            this.rdowdy.Size = new System.Drawing.Size(88, 16);
            this.rdowdy.TabIndex = 2;
            this.rdowdy.TabStop = true;
            this.rdowdy.Text = "ѡ��δȷ��";
            this.rdowdy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdowdy.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // rdoydy
            // 
            this.rdoydy.Location = new System.Drawing.Point(162, 18);
            this.rdoydy.Name = "rdoydy";
            this.rdoydy.Size = new System.Drawing.Size(88, 16);
            this.rdoydy.TabIndex = 1;
            this.rdoydy.Text = "ѡ����ȷ��";
            this.rdoydy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoydy.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(829, 31);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 32);
            this.btCancel.TabIndex = 72;
            this.btCancel.Text = "�˳�(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(687, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 32);
            this.btnRefresh.TabIndex = 74;
            this.btnRefresh.Text = "ˢ��(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnfyqr
            // 
            this.btnfyqr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnfyqr.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnfyqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfyqr.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfyqr.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnfyqr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnfyqr.ImageIndex = 0;
            this.btnfyqr.Location = new System.Drawing.Point(757, 31);
            this.btnfyqr.Name = "btnfyqr";
            this.btnfyqr.Size = new System.Drawing.Size(64, 32);
            this.btnfyqr.TabIndex = 71;
            this.btnfyqr.Text = "ȷ��(&P)";
            this.btnfyqr.UseVisualStyleBackColor = false;
            this.btnfyqr.Click += new System.EventHandler(this.btnfyqr_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(679, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(224, 49);
            this.button3.TabIndex = 73;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmjydqf
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(909, 557);
            this.Controls.Add(this.panel4);
            this.Name = "frmjydqf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "���鵥����ȷ��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmjyd_Load);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void frmjyd_Load(object sender, EventArgs e)
        {
            //��ʼ��
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[12];
                parameters[0].Value = 0;
                parameters[1].Value = InstanceForm.BCurrentDept.WardId.Trim();
                parameters[2].Value = rdorq1.Checked==true?"": this.dateTimePicker1.Value.ToShortDateString() + " 00:00:01";
                parameters[3].Value = rdorq1.Checked == true ? "" : this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59";
                int bprint = 8;
                if (rdowdy.Checked == true) bprint = 3;
                if (rdoydy.Checked == true) bprint = 4;
                parameters[4].Value = bprint;
                parameters[5].Value = txtzyh.Text.Trim();
                parameters[6].Value = txtcwh.Text.Trim();
                parameters[7].Value = txtname.Text.Trim();
                parameters[8].Value = txttxm.Text.Trim();
                parameters[9].Value = rdorq1.Checked == false ? "" : this.dateTimePicker1.Value.ToShortDateString() + " 00:00:01";
                parameters[10].Value = rdorq1.Checked == false ? "" : this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59";
                parameters[11].Value = InstanceForm.BCurrentDept.DeptId;

                parameters[0].Text = "@lx";
                parameters[1].Text = "@wardid";
                parameters[2].Text = "@sqrq1";
                parameters[3].Text = "@sqrq2";
                parameters[4].Text = "@dybz";
                parameters[5].Text = "@zyh";
                parameters[6].Text = "@cwh";
                parameters[7].Text = "@name";
                parameters[8].Text = "@txm";
                parameters[9].Text = "@qrrq1";
                parameters[10].Text = "@qrrq2";
                parameters[11].Text = "@zxks";
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_zyhs_getjchy", parameters, 30);
                FunBase.AddRowtNo(tb);
                tb.TableName = "Tb";
                //if (rdorq2.Checked == true)
                //{
                //    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                //        tb.Rows[i]["ѡ��"] = (short)1;
                //}
                this.myDataGrid1.DataSource = tb;
                FunBase.myGridSelect(this.myDataGrid1, this.myDataGrid1.TableStyles[0].GridColumnStyles);
                //if (rdowdy.Checked == true && tb.Rows.Count != 0)
                //{
                //    if (MessageBox.Show("��Ҫȷ�ϸ÷�����", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //    {
                //        this.btnfyqr_Click(sender, e);
                //        txttxm.Focus();
                //        txttxm.SelectAll();
                //    }
                //}

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }



        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (tb.Rows.Count == 0) return;
            if (tb.Rows[nrow]["״̬"].ToString().Trim() == "����") return;
            if (rdorq1.Checked==true) return;
            //DataRow[] selrow = tb.Select("������='"+tb.Rows[nrow]["������"].ToString().Trim()+"'");
            string txm = tb.Rows[nrow]["������"].ToString().Trim();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (tb.Rows[i]["������"].ToString().Trim() == txm )
                {
                    if (Convert.ToBoolean(tb.Rows[i]["ѡ��"]) == false)
                       tb.Rows[i]["ѡ��"] = (short)1;
                    else
                       tb.Rows[i]["ѡ��"] = (short)0;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void txtzyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtzyh.Text=FunBase.returnZyh(txtzyh.Text.Trim());
                this.btnRefresh_Click(sender, e);
            }
        }

        private void txtcwh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.btnRefresh_Click(sender, e);
            }
        }

        private void txtzyh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.btnRefresh_Click(sender, e);
            }
        }

        //����ȷ��
        private void btnfyqr_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] selrow = tb.Select(" ѡ��=true");

            string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                for (int i = 0; i <= selrow.Length - 1; i++)
                {
                    string ssql = "update YJ_ZYSQ set BJSBZ=1,jssj='" + sDate + "',jsr=" + InstanceForm.BCurrentUser.EmployeeId + " where yzid='" + new Guid(selrow[i]["order_id"].ToString()) + "' and bjsbz=0 and bscbz=0";
                    int n = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                    if (n == 0)
                        throw new Exception("û�и��µ��������ݣ���ˢ������");

                    ssql = "update zy_fee_speci set charge_bit=1,charge_date='" + sDate + "',charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " where order_id=" + Convert.ToInt64(selrow[i]["order_id"]) + " and charge_bit=0 and delete_bit=0";
                    n = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                    if (n == 0)
                        throw new Exception("û�и��µ��������ݣ���ˢ������");

                    ssql = "update zy_prescription set charge_bit=1  where order_id=" + Convert.ToInt64(selrow[i]["order_id"]) + " and charge_bit=0 ";
                    n = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                    if (n == 0)
                        throw new Exception("û�и��µ��������ݣ���ˢ������");
                }
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tb.Rows.Remove(selrow[i]);

                InstanceForm.BDatabase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message,"����",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void rdorq1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
        }

        private void txttxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                string txm = txttxm.Text.Trim();
                if (Convertor.IsNumeric(txm) == true)
                {
                    decimal tm = Convert.ToDecimal(txm);
                    txttxm.Text = tm.ToString("000000000");
                    btnRefresh_Click(sender, e);
                    txttxm.Focus();
                    txttxm.SelectAll();
                }
            }
        }


    }
}
