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

namespace ts_yk_bsby
{
	/// <summary>
	/// Frmyprk ��ժҪ˵����
	/// </summary>
	public class Frmypbsby : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtbz;
		private System.Windows.Forms.Label lbldjh;
		private System.Windows.Forms.Label lbldjhd;
		private System.Windows.Forms.TextBox txtypdm;
		private System.Windows.Forms.TextBox txtph;
		private System.Windows.Forms.TextBox txtkw;
		private System.Windows.Forms.TextBox txtypsl;
		private System.Windows.Forms.ComboBox cmbdw;
		private System.Windows.Forms.Label lblhh;
		private System.Windows.Forms.Label lblypmc;
		private System.Windows.Forms.Label lblcj;
		private System.Windows.Forms.Label lblgg;
		private System.Windows.Forms.Label lbllsje;
		private System.Windows.Forms.Label lblpfje;
		private System.Windows.Forms.Label lblkc;
		private System.Windows.Forms.Label lbllsj;
		private System.Windows.Forms.Label lblpfj;
		private System.Windows.Forms.Button butmodif;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.Button butadd;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butnew;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.TextBox txtyy;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.Label lblyy;
		private System.Windows.Forms.Label lbldjrq;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DateTimePicker dtprq;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn ����;
		private System.Windows.Forms.DataGridTextBoxColumn ��λ;
		private System.Windows.Forms.Button butph;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblxq;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.Label lblpm;
		private System.Windows.Forms.DataGridTextBoxColumn ��Ʒ��;
		private YpConfig ss;
		private System.Windows.Forms.Label lbljhje;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lbljhj;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private Label lblsdjh;
        private ComboBox cmbck;
        private Label label6;
        private TextBox txtpch;
        private Label label1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
        private DataGridTextBoxColumn col_���κ�;
        private DataGridTextBoxColumn col_kcid;


        bool bpcgl = false; //�Ƿ�������ι���

        private bool btjhj = false;//�Ƿ��������
            
		public Frmypbsby(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);

            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblsdjh = new System.Windows.Forms.Label();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtyy = new System.Windows.Forms.TextBox();
            this.lblyy = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhd = new System.Windows.Forms.Label();
            this.dtprq = new System.Windows.Forms.DateTimePicker();
            this.lbldjrq = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtpch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbljhje = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbljhj = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblxq = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbllsje = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpfje = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butph = new System.Windows.Forms.Button();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtkw = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
            this.lblkc = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
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
            this.lblpm = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��Ʒ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_���κ� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_kcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��λ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblsdjh);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtyy);
            this.groupBox1.Controls.Add(this.lblyy);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhd);
            this.groupBox1.Controls.Add(this.dtprq);
            this.groupBox1.Controls.Add(this.lbldjrq);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(899, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(64, 12);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(106, 20);
            this.cmbck.TabIndex = 0;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            this.cmbck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "�ֿ�����";
            // 
            // lblsdjh
            // 
            this.lblsdjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsdjh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsdjh.Location = new System.Drawing.Point(683, 12);
            this.lblsdjh.Name = "lblsdjh";
            this.lblsdjh.Size = new System.Drawing.Size(88, 20);
            this.lblsdjh.TabIndex = 19;
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(64, 36);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(709, 21);
            this.txtbz.TabIndex = 3;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(35, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "��ע";
            // 
            // txtyy
            // 
            this.txtyy.ForeColor = System.Drawing.Color.Navy;
            this.txtyy.Location = new System.Drawing.Point(394, 12);
            this.txtyy.Name = "txtyy";
            this.txtyy.Size = new System.Drawing.Size(138, 21);
            this.txtyy.TabIndex = 2;
            this.txtyy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtyy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblyy
            // 
            this.lblyy.Location = new System.Drawing.Point(339, 16);
            this.lblyy.Name = "lblyy";
            this.lblyy.Size = new System.Drawing.Size(64, 16);
            this.lblyy.TabIndex = 16;
            this.lblyy.Text = "����ԭ��";
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.Location = new System.Drawing.Point(591, 12);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(88, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhd
            // 
            this.lbldjhd.Location = new System.Drawing.Point(536, 16);
            this.lbldjhd.Name = "lbldjhd";
            this.lbldjhd.Size = new System.Drawing.Size(64, 16);
            this.lbldjhd.TabIndex = 14;
            this.lbldjhd.Text = "���𵥺�";
            // 
            // dtprq
            // 
            this.dtprq.Location = new System.Drawing.Point(228, 12);
            this.dtprq.Name = "dtprq";
            this.dtprq.Size = new System.Drawing.Size(106, 21);
            this.dtprq.TabIndex = 1;
            this.dtprq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lbldjrq
            // 
            this.lbldjrq.Location = new System.Drawing.Point(172, 16);
            this.lbldjrq.Name = "lbldjrq";
            this.lbldjrq.Size = new System.Drawing.Size(64, 16);
            this.lbldjrq.TabIndex = 4;
            this.lbldjrq.Text = "��������";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtpch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbljhje);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbljhj);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblxq);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbllsje);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblpfje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.butph);
            this.groupBox2.Controls.Add(this.txtph);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtkw);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.butmodif);
            this.groupBox2.Controls.Add(this.butdel);
            this.groupBox2.Controls.Add(this.butadd);
            this.groupBox2.Controls.Add(this.lblkc);
            this.groupBox2.Controls.Add(this.label36);
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
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(899, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtpch
            // 
            this.txtpch.Enabled = false;
            this.txtpch.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpch.ForeColor = System.Drawing.Color.Navy;
            this.txtpch.Location = new System.Drawing.Point(64, 88);
            this.txtpch.Name = "txtpch";
            this.txtpch.Size = new System.Drawing.Size(129, 21);
            this.txtpch.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 103;
            this.label1.Text = "����";
            // 
            // lbljhje
            // 
            this.lbljhje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbljhje.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljhje.ForeColor = System.Drawing.Color.Navy;
            this.lbljhje.Location = new System.Drawing.Point(664, 64);
            this.lbljhje.Name = "lbljhje";
            this.lbljhje.Size = new System.Drawing.Size(104, 20);
            this.lbljhje.TabIndex = 84;
            this.lbljhje.Click += new System.EventHandler(this.lbljhje_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(608, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 83;
            this.label11.Text = "�������";
            // 
            // lbljhj
            // 
            this.lbljhj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbljhj.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljhj.ForeColor = System.Drawing.Color.Navy;
            this.lbljhj.Location = new System.Drawing.Point(530, 64);
            this.lbljhj.Name = "lbljhj";
            this.lbljhj.Size = new System.Drawing.Size(72, 20);
            this.lbljhj.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(500, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 81;
            this.label8.Text = "����";
            // 
            // lblxq
            // 
            this.lblxq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxq.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxq.ForeColor = System.Drawing.Color.Navy;
            this.lblxq.Location = new System.Drawing.Point(559, 89);
            this.lblxq.Name = "lblxq";
            this.lblxq.Size = new System.Drawing.Size(112, 20);
            this.lblxq.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(527, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 72;
            this.label3.Text = "Ч��";
            // 
            // lbllsje
            // 
            this.lbllsje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsje.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsje.ForeColor = System.Drawing.Color.Navy;
            this.lbllsje.Location = new System.Drawing.Point(392, 65);
            this.lbllsje.Name = "lbllsje";
            this.lbllsje.Size = new System.Drawing.Size(96, 20);
            this.lbllsje.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(336, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "���۽��";
            // 
            // lblpfje
            // 
            this.lblpfje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfje.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfje.ForeColor = System.Drawing.Color.Navy;
            this.lblpfje.Location = new System.Drawing.Point(232, 65);
            this.lblpfje.Name = "lblpfje";
            this.lblpfje.Size = new System.Drawing.Size(104, 20);
            this.lblpfje.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(176, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 68;
            this.label7.Text = "�������";
            // 
            // butph
            // 
            this.butph.Font = new System.Drawing.Font("����", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butph.Location = new System.Drawing.Point(312, 89);
            this.butph.Name = "butph";
            this.butph.Size = new System.Drawing.Size(25, 20);
            this.butph.TabIndex = 67;
            this.butph.Text = "...";
            this.butph.Click += new System.EventHandler(this.butph_Click);
            // 
            // txtph
            // 
            this.txtph.ForeColor = System.Drawing.Color.Navy;
            this.txtph.Location = new System.Drawing.Point(231, 89);
            this.txtph.Name = "txtph";
            this.txtph.ReadOnly = true;
            this.txtph.Size = new System.Drawing.Size(80, 21);
            this.txtph.TabIndex = 7;
            this.txtph.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(199, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "����";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("����", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(487, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 20);
            this.button2.TabIndex = 64;
            this.button2.Text = "...";
            // 
            // txtkw
            // 
            this.txtkw.ForeColor = System.Drawing.Color.Navy;
            this.txtkw.Location = new System.Drawing.Point(399, 91);
            this.txtkw.Name = "txtkw";
            this.txtkw.ReadOnly = true;
            this.txtkw.Size = new System.Drawing.Size(90, 21);
            this.txtkw.TabIndex = 8;
            this.txtkw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(367, 95);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 62;
            this.label31.Text = "��λ";
            // 
            // butmodif
            // 
            this.butmodif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmodif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butmodif.Location = new System.Drawing.Point(828, 90);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(64, 24);
            this.butmodif.TabIndex = 10;
            this.butmodif.Text = "�޸�(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butdel.Location = new System.Drawing.Point(757, 90);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(65, 24);
            this.butdel.TabIndex = 11;
            this.butdel.Text = "ɾ��(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butadd.Location = new System.Drawing.Point(685, 90);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(65, 24);
            this.butadd.TabIndex = 9;
            this.butadd.Text = "���(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(530, 40);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(72, 20);
            this.lblkc.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(490, 43);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 16);
            this.label36.TabIndex = 50;
            this.label36.Text = "�����";
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.Location = new System.Drawing.Point(64, 39);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(96, 21);
            this.txtypsl.TabIndex = 5;
            this.txtypsl.Leave += new System.EventHandler(this.txtypsl_Leave);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(32, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(33, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "����";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(392, 40);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(96, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(336, 40);
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
            this.lblpfj.Location = new System.Drawing.Point(232, 40);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(104, 20);
            this.lblpfj.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(188, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 16);
            this.label20.TabIndex = 26;
            this.label20.Text = "������";
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(64, 64);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(96, 20);
            this.cmbdw.TabIndex = 66;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(32, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 16);
            this.label19.TabIndex = 24;
            this.label19.Text = "��λ";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(664, 40);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(104, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(632, 42);
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
            this.lblypmc.Location = new System.Drawing.Point(392, 14);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(136, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(688, 15);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(87, 19);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(656, 16);
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
            this.lblgg.Location = new System.Drawing.Point(560, 15);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(84, 19);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(528, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "���";
            // 
            // txtypdm
            // 
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(64, 15);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(96, 21);
            this.txtypdm.TabIndex = 4;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "ҩƷ����";
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(232, 14);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(160, 20);
            this.lblpm.TabIndex = 74;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(164, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "Ʒ��/��Ʒ��";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(899, 366);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(893, 298);
            this.panel2.TabIndex = 62;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.ForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(893, 298);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.DataSourceChanged += new System.EventHandler(this.myDataGrid1_DataSourceChanged);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.��Ʒ��,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.col_���κ�,
            this.col_kcid,
            this.����,
            this.dataGridTextBoxColumn6,
            this.��λ,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn16});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // ��Ʒ��
            // 
            this.��Ʒ��.Format = "";
            this.��Ʒ��.FormatInfo = null;
            this.��Ʒ��.HeaderText = "��Ʒ��";
            this.��Ʒ��.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "���";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "����";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 80;
            // 
            // col_���κ�
            // 
            this.col_���κ�.Format = "";
            this.col_���κ�.FormatInfo = null;
            this.col_���κ�.HeaderText = "���κ�";
            this.col_���κ�.Width = 75;
            // 
            // col_kcid
            // 
            this.col_kcid.Format = "";
            this.col_kcid.FormatInfo = null;
            this.col_kcid.HeaderText = "kcid";
            this.col_kcid.Width = 0;
            // 
            // ����
            // 
            this.����.Format = "";
            this.����.FormatInfo = null;
            this.����.HeaderText = "����";
            this.����.NullText = "";
            this.����.Width = 70;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Ч��";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 70;
            // 
            // ��λ
            // 
            this.��λ.Format = "";
            this.��λ.FormatInfo = null;
            this.��λ.HeaderText = "��λ";
            this.��λ.NullText = "";
            this.��λ.Width = 70;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "������";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 65;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "���ۼ�";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 65;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "����";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 50;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "��λ";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 40;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "�������";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 75;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "���۽��";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "����";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "�������";
            this.dataGridTextBoxColumn18.Width = 70;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "����";
            this.dataGridTextBoxColumn14.NullText = "70";
            this.dataGridTextBoxColumn14.Width = 75;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "dwbl";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "CJID";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "kwid";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "id";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 48);
            this.panel1.TabIndex = 61;
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(608, 0);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 14;
            this.butclose.Text = "�ر�(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(520, 0);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 13;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(432, 0);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 12;
            this.butsave.Text = "����(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(344, 0);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 11;
            this.butnew.Text = "�µ���(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 524);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(899, 25);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 150;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 400;
            // 
            // Frmypbsby
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(899, 549);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frmypbsby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ҩƷ����";
            this.Load += new System.EventHandler(this.Frmypck_Load);
            this.Activated += new System.EventHandler(this.Frmypbsby_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmypbsby_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		private void Frmypck_Load(object sender, System.EventArgs e)
		{
			try
			{

				this.dtprq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				

				if (_menuTag.Function_Name.Trim()=="Fun_ts_yk_ypbs")
				{
					lbldjrq.Text="��������";
					lblyy.Text="����ԭ��";
				}
				else
				{
					lbldjrq.Text="��������";
					lblyy.Text="����ԭ��";
				}


                if (_menuTag.Function_Name == "Fun_ts_yk_ypby_cx" || _menuTag.Function_Name == "Fun_ts_yk_ypbs_cx")
                {
                    butnew.Visible = false;
                }

              
                SystemCfg cfg8056 = new SystemCfg(8056);//��������
                if (cfg8056.Config == "1")
                {
                    btjhj = true;
                }
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message );
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

	
		private void csgroupbox1()
		{
            cmbck.Enabled = true;
			for(int i=0;i<=this.groupBox1.Controls.Count-1;i++)
			{
				if (this.groupBox1.Controls[i].GetType().ToString()=="System.Windows.Forms.TextBox")
				{
					this.groupBox1.Controls[i].Text="";
                    this.groupBox1.Controls[i].Tag = "0";
					this.groupBox1.Controls[i].Enabled=true;
				}
			}
			this.lbldjh.Text="";
            this.lblsdjh.Text = "";
            this.groupBox1.Tag = null;
			this.dtprq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.dtprq.Enabled=true;

		}

        //���ҩƷ��Ϣ
		private void csgroupbox2()
		{
			for(int i=0;i<=this.groupBox2.Controls.Count-1;i++)
			{
				if (this.groupBox2.Controls[i].GetType().ToString()=="System.Windows.Forms.TextBox")
				{
					this.groupBox2.Controls[i].Text="";
                    if (this.groupBox2.Controls[i].Name == "txtph")
                        this.groupBox2.Controls[i].Tag = "";
                    else
                        this.groupBox2.Controls[i].Tag = "0";
					this.groupBox2.Controls[i].Enabled=true;
				}
			}
            this.txtpch.Enabled = false; //���κŲ�������
			this.lblxq.Text="";
			this.lblpm.Text="";
			this.lblypmc.Text="";
			this.lblypmc.Tag="0";
			this.lblgg.Text="";
			this.lblcj.Text="";
			this.lblhh.Text="";
			this.lblpfj.Text="";
			this.lbllsj.Text="";
			this.lblpfj.Tag="";
			this.lbllsj.Tag ="";
			this.lblpfje.Text="";
			this.lbllsje.Text="";
			this.lblkc.Text="";

			this.lbljhj.Text="";
			this.lbljhje.Text="";
			this.lbljhj.Tag="";

			this.cmbdw.DataSource=null;
			this.cmbdw.Enabled=true;
			this.txtypdm.Focus();
		}

	
		//���������¼�
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;
			if (control.Text.Trim()=="" ){control.Text="";control.Tag="0";}
			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)==""))){}else{return;}
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
						GrdMappingName=new string[] {"id","�к�","ԭ��","ƴ����","�����"};
						GrdWidth=new int[] {0,50,200,100,100};
						if (Convertor.IsNull(control.Tag,"0")!="0")
							sfield=new string[] {"wbm","pym","","",""};
						else
							sfield=new string[] {"","","","",""};
						if (_menuTag.FunctionTag.Trim()=="006") 
							ssql="select id, 0 rowno,mc,wbm,pym from yp_bsyy where id<>0  ";
						else
							ssql="select id, 0 rowno,mc,wbm,pym from yp_yyyy where id<>0 ";
						TrasenFrame.Forms.Fshowcard f1=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,FilterType.ƴ��,control.Text.Trim(),ssql);
						f1.Location=point;
						f1.ShowDialog(this);
						row=f1.dataRow;
						if (row!=null) 
						{
							control.Text=row["mc"].ToString();
							control.Tag=row["id"].ToString();
							this.SelectNextControl((Control)sender,true,false,true,true);
						}
						break;
					case 4:
						if (control.Text.Trim()=="") return;
						GrdMappingName=new string[] {"ggid","cjid","�к�","Ʒ��","���","����","��λ","DWBL","������","���ۼ�","����"};
						GrdWidth=new int[] {0,0,30,140,90,90,30,0,60,60,70};
						sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
                        ssql = "select distinct a.ggid,cjid,0 rowno,ypspm,ypgg,s_sccj sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid  and a.bdelete_kc=0 and a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " ";
						TrasenFrame.Forms.Fshowcard f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
						f2.Location=point;
						f2.Width=700;
						f2.Height=300;
						f2.ShowDialog(this);
						row=f2.dataRow;
						if (row!=null) 
						{
							this.csyp(Convert.ToInt32(row["ggid"]),Convert.ToInt32(row["cjid"]));
                            FindRecord(Convert.ToInt32(row["cjid"]), 0);
							this.SelectNextControl((Control)sender,true,false,true,true);
							
						}
						break;
					case 7:
						this.txtph.Text="";
						this.butph_Click(sender,e);
						break;

				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}

		}

        public void FindRecord(int cjid, int nrow)
        {
            int beginrow = nrow;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = beginrow; i <= tb.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(tb.Rows[i]["cjid"]) == cjid)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    for (int j = 0; j <= tb.Rows.Count - 1; j++)
                    {
                        this.myDataGrid1.UnSelect(j);
                    }

                    this.myDataGrid1.Select(i);
                    beginrow = i + 1;
                    txtypdm.Focus();
                    return;

                }


            }
        }

		//���������¼�
		private void txtypsl_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (Convertor.IsNumeric(txtypsl.Text)==false) txtypsl.Text="";
				if(txtypsl.Text.Trim()!="-" && txtypsl.Text.Trim()!=".")
				{
					decimal sumpfje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text,"0"));
					this.lblpfje.Text=sumpfje.ToString("0.00");
					decimal sumlsje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text,"0"));
					this.lbllsje.Text=sumlsje.ToString("0.00");
					decimal sumjhje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text,"0"));
					this.lbljhje.Text=sumjhje.ToString("0.00");
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}

		}

		
		//����Ԫ�ı��¼�
		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (nrow>=tb.Rows.Count)
				{
					DataRow nullrow=tb.NewRow();
					this.Getrow(nullrow);
				}
				else
				{
					DataRow row=tb.Rows[nrow];
					Getrow(row);
					this.butadd.Enabled=false;
				}
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
                this.lblkc.Text = Yp.SeekKcZh(dwbl, Convert.ToInt32(this.lblypmc.Tag), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
		
				//�����������ۡ����������ۼۡ����۽��
				decimal ypsl=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"));
				decimal pfj=Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag,"0"))/dwbl;
				pfj=Convert.ToDecimal(pfj.ToString("0.0000"));
				this.lblpfj.Text=pfj.ToString("0.0000");
				decimal lsj=Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag,"0"))/dwbl;
				lsj=Convert.ToDecimal(lsj.ToString("0.0000"));
				this.lbllsj.Text=lsj.ToString("0.0000");
				decimal pfje=pfj*ypsl;
				this.lblpfje.Text=pfje.ToString("0.00");
				decimal lsje=lsj*ypsl;
				this.lbllsje.Text=lsje.ToString("0.00");

				//���ۡ��������
				decimal jhj=Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Tag,"0"))/dwbl;
				jhj=Convert.ToDecimal(jhj.ToString("0.0000"));
				this.lbljhj.Text=jhj.ToString("0.0000");

				decimal jhje=jhj*ypsl;
				this.lbljhje.Text=jhje.ToString("0.00");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}

		
		//��������¼�
		private void Frmypbsby_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Convert.ToInt32(e.KeyCode)==112)
			{
				this.butph_Click(sender,e);
			}
		}

		
		#endregion

		#region ������ݵĹ���
		//��ʼҩƷ
		private void csyp(int ggid,int cjid)
		{
			try
			{
				this.csgroupbox2();
				//Ydgg ydgg=new  Ydgg(ggid);
                Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
				this.lblypmc.Tag=ydcj.CJID.ToString();
				this.lblypmc.Text=ydcj.S_YPSPM;
				this.lblpm.Text=ydcj.S_YPPM;
				this.lblgg.Text=ydcj.S_YPGG;
				this.lblcj.Text=ydcj.S_SCCJ;
				this.lblhh.Text=ydcj.SHH;
				this.lblpfj.Text=ydcj.PFJ.ToString();
				this.lbllsj.Text=ydcj.LSJ.ToString() ;
				this.lblpfj.Tag=ydcj.PFJ.ToString();
				this.lbllsj.Tag=ydcj.LSJ.ToString() ;
				this.lbljhj.Text="";
				this.lbljhj.Tag="";
				this.lbljhje.Text="";

                if (btjhj)
                {
                    lbljhj.Text = ydcj.MRJJ.ToString();
                    lbljhj.Tag = ydcj.MRJJ;
                }

                Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
				this.cmbdw.SelectedIndex=0;
                this.lblkc.Text = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}


		//�����
		private void Fillrow(System.Data.DataRow row)
		{
			YpConfig s=new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),InstanceForm.BDatabase);

            Guid t_kcid = Guid.Empty;

            if (Convertor.IsNull(txtph.Tag, "0") != "0")
            {
                t_kcid = new Guid(txtph.Tag.ToString());
            }

            #region  ��֤����
            if (Convert.ToInt32(this.lblypmc.Tag)==0) 
			{
				MessageBox.Show("û�п���ӵ�ҩƷ");
				return;
			}

//			if (Convertor.IsNull(this.txtypsl.Text,"0")=="0")
//			{
//				MessageBox.Show("������ҩƷ����");
//				return;
//			}

			if (txtph.Text.Trim()=="" && s.��������==true )
			{
				MessageBox.Show("������ҩƷ����");
				return;
			}

            if (bpcgl)
            {
                if (t_kcid == Guid.Empty || t_kcid == null)
                {
                    MessageBox.Show("����ѡ�����Σ�");
                }
                if (Convertor.IsNumeric(txtypsl.Text.Trim()))
                {
                    if(Convert.ToDecimal(Convertor.IsNull(txtypsl.Text.Trim(),"0"))<=0)
                    {
                        MessageBox.Show("ϵͳ�趨�������븺����");
                        return;
                    }
                }
                else
                { 
                    MessageBox.Show("ϵͳ�趨�������븺����");
                    return;
                }
            }

            if (Convertor.IsNumeric(txtypsl.Text) == true)
            {
                if (new SystemCfg(8023).Config.Contains(_menuTag.FunctionTag.ToString()) == true && Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) < 0)
                {
                    MessageBox.Show("ϵͳ�趨�������븺��");
                    return;
                }
            }

            
            #endregion

            #region �жϿ��
            if (Yp.BYkOutKc(_menuTag.FunctionTag.Trim(),
			    Convert.ToInt32(this.lblypmc.Tag),
			    Convertor.IsNull(this.txtph.Text.Trim(),"������"),
			    Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text.Trim(),"0")),
			    Convert.ToInt32(cmbdw.SelectedValue),
                Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), Convert.ToDecimal(Convertor.IsNull(lbljhj.Tag, "0")), InstanceForm.BDatabase
                ,new Guid(Convertor.IsNull(txtph.Tag,Guid.Empty.ToString())) ) == true)
		    {
			    if (s.ǿ�ƿ��ƿ��==true)
			    {
				    MessageBox.Show("��治��,������ȷ������");
				    return;
			    }
			    else
			    {
				    if(MessageBox.Show(this, "��治������ȷ�ϼ�����?", "ȷ��", MessageBoxButtons.YesNo)==DialogResult.No ) return;
			    }

                if(bpcgl)
                {
                    MessageBox.Show("���ο���������㣡");
                    return;
                }
		    }
  
            #endregion


			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			row["���"]=tb.Rows.Count+1;
			row["Ʒ��"]=this.lblpm.Text.Trim();
			row["��Ʒ��"]=this.lblypmc.Text.Trim();
			row["���"]=this.lblgg.Text.Trim();
			row["����"]=this.lblcj.Text.Trim();

            row["���κ�"] = this.txtpch.Text.Trim();
            row["kcid"] = t_kcid.ToString();

			row["����"]=this.txtph.Text.Trim();
			row["Ч��"]=this.lblxq.Text.Trim();
			row["��λ"]=this.txtkw.Text.ToString();
			row["������"]=this.lblpfj.Text.Trim();
			row["���ۼ�"]=this.lbllsj.Text.Trim();
			row["����"]=this.txtypsl.Text.Trim();
			row["��λ"]=this.cmbdw.Text.Trim();
			decimal sumpfje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(),"0"));
			row["�������"]=sumpfje.ToString("0.00");
			decimal sumlsje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(),"0"));
			row["���۽��"]=sumlsje.ToString("0.00");
           
			//���ۡ��������
			decimal sumjhje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text.Trim(),"0"));
			row["����"]=Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text,"0"));
			row["�������"]=sumjhje.ToString("0.00");

            row["���κ�"] = "";

			row["����"]=this.lblhh.Text.Trim();
			row["CJID"]=this.lblypmc.Tag.ToString();
			row["DWBL"]=Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
			row["kwid"]=Convertor.IsNull(this.txtkw.Tag,"0");
			this.SortRowNO();
		}

		
		//��ͽ��
		private void Sumje()
		{
			try
			{
				decimal sumjhje=0;
				decimal sumpfje=0;
				decimal sumlsje=0;
				decimal sumplce=0;
				decimal sumjlce=0;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for( int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumjhje=sumjhje+Convert.ToDecimal(tb.Rows[i]["�������"]);
					sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["�������"]);
					sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["���۽��"]);
				}
				sumplce=sumlsje-sumpfje;
				sumjlce=sumlsje-sumjhje;
				//				this.statusBar1.Panels[0].Text ="�������: "+sumpfje.ToString("0.00");
				//				this.statusBar1.Panels[1].Text ="���۽��: "+sumlsje.ToString("0.00");
				//				this.statusBar1.Panels[2].Text ="������: "+sumplce.ToString("0.00");
				
				this.statusBar1.Panels[0].Text ="�������: "+sumjhje.ToString("0.00");
				this.statusBar1.Panels[1].Text ="���۽��: "+sumlsje.ToString("0.00");
				this.statusBar1.Panels[2].Text ="������: "+sumjlce.ToString("0.00");
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
			this.lblypmc.Text=row["��Ʒ��"].ToString();
			this.lblpm.Text=row["Ʒ��"].ToString();
			this.lblypmc.Tag=row["CJID"].ToString();
			this.lblgg.Text=row["���"].ToString();
			this.lblcj.Text=row["����"].ToString();

            this.txtpch.Text = row["���κ�"].ToString(); //���κ�
            this.txtph.Tag = row["kcid"]; 

			this.txtph.Text=row["����"].ToString();
            //this.txtph.Tag = "10000";
            this.lblxq.Text = row["Ч��"].ToString();
			this.txtkw.Text=row["��λ"].ToString();
			this.txtkw.Tag=row["kwid"].ToString();
			this.lblpfj.Text=row["������"].ToString();
			this.lblpfj.Tag=ydcj.PFJ.ToString();
			this.lbllsj.Text=row["���ۼ�"].ToString();
			this.lbllsj.Tag=ydcj.LSJ.ToString();
            this.lblkc.Text = Yp.SeekKcZh(1, ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
			this.txtypsl.Text=row["����"].ToString();
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
			this.cmbdw.Text=row["��λ"].ToString();
			this.lblpfje.Text=row["�������"].ToString();
			this.lbllsje.Text=row["���۽��"].ToString();
			this.lblhh.Text=row["����"].ToString();

			this.lbljhj.Text=row["����"].ToString();
			this.lbljhj.Tag=Convert.ToDecimal(Convertor.IsNull(row["����"],"0"))*Convert.ToDecimal(Convertor.IsNull(row["dwbl"],"0"));
			this.lbljhje.Text=row["�������"].ToString();
			
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
		public void FillDj(Guid  id,bool shbz)
		{
			try
			{
                cmbck.Enabled = false;
				string ssql="select * from vi_yk_dj where id='"+id+"'";
				DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);

                cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();
				this.groupBox1.Tag=tb.Rows[0]["id"].ToString();
				this.txtyy.Tag=tb.Rows[0]["yydm"].ToString();

				if (_menuTag.FunctionTag.Trim()=="006")
				{
                    this.txtyy.Text = Yp.SeekBsyy(Convert.ToInt32(tb.Rows[0]["yydm"].ToString()), InstanceForm.BDatabase);
				}
				else
				{
                    this.txtyy.Text = Yp.Seekyyyy(Convert.ToInt32(tb.Rows[0]["yydm"].ToString()), InstanceForm.BDatabase);
				}

				this.txtbz.Text=tb.Rows[0]["bz"].ToString();
			
				this.dtprq.Value=Convert.ToDateTime(tb.Rows[0]["rq"]);
				long djh=Convert.ToInt64(tb.Rows[0]["djh"]);
				this.lbldjh.Text=djh.ToString("00000000");
                this.lblsdjh.Text = tb.Rows[0]["sdjh"].ToString();

				ssql="select 0 ���,b.yppm Ʒ��,B.ypspm ��Ʒ��,b.ypgg ���,s_sccj ����,a.yppch ���κ�,a.kcid, a.ypph ����,ypxq Ч��,dbo.FUN_YP_KWMC(b.ggid,A.DEPTID) ��λ,"+
					" a.pfj ������,a.lsj ���ۼ�,ypsl ����,a.ypdw ��λ,"+
					" pfje �������,lsje ���۽��,jhj ����,jhje �������,b.shh ����,"+
					" a.cjid,ydwbl dwbl,kwid,a.id from yk_djmx a,vi_yp_ypcd b  where a.cjid=b.cjid and  djid='"+id+"' order by a.PXXH ";
				DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
				if (tbmx.Rows.Count==0)
				{
					ssql="select 0 ���,b.yppm Ʒ��,B.ypspm ��Ʒ��,b.ypgg ���,s_sccj ����,a.yppch ���κ�,a.kcid,a.ypph ����,ypxq Ч��,dbo.FUN_YP_KWMC(b.ggid,A.DEPTID) ��λ,"+
						" a.pfj ������,a.lsj ���ۼ�,ypsl ����,a.ypdw ��λ,"+
						" pfje �������,lsje ���۽��,jhj ����,jhje �������,b.shh ����,"+
						" a.cjid,ydwbl dwbl,kwid,a.id from yk_djmx_H a,vi_yp_ypcd b  where a.cjid=b.cjid and  djid='"+id+"' order by a.PXXH ";
					 tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
				}
				FunBase.AddRowtNo(tbmx);
				tbmx.TableName="tbmx";
				this.myDataGrid1.DataSource=tbmx;
				this.myDataGrid1.TableStyles[0].MappingName ="tbmx";
			
				this.butsave.Enabled=false;
				this.butadd.Enabled=false;
				this.butdel.Enabled=false;
				this.butmodif.Enabled=false;
				this.dtprq.Enabled=false;
				this.txtyy.Enabled=false;
				this.txtbz.Enabled=false;
				this.txtypdm.Enabled=false;
				this.txtypsl.Enabled=false;
				this.cmbdw.Enabled=false;
				this.butprint.Enabled=true;
				this.Sumje();


			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}

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
				Fillrow(row);

				if (row["Ʒ��"].ToString().Trim()!="")
				{
                    if (YpClass.FunBase.IsExistsInGrid(new object[] { row["cjid"],Convertor.IsNull(row["���κ�"], "") }, tb, new string[] { "cjid", "���κ�" }))
                    {
                        MessageBox.Show( "��ӵ�ҩƷ�Ѵ��ڣ������ظ����" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }
					tb.Rows.Add(row);
					this.Sumje();
					this.myDataGrid1.Select(tb.Rows.Count-1);
					this.myDataGrid1.CurrentCell=new DataGridCell(tb.Rows.Count-1,3);
					this.csgroupbox2();
					this.butadd.Enabled=true;
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
			this.csgroupbox1();
			this.csgroupbox2();
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
			this.statusBar1.Panels[0].Text="";
			this.statusBar1.Panels[1].Text="";
			this.statusBar1.Panels[2].Text="";
			this.butadd.Enabled=true;
			this.butdel.Enabled=true;
			this.butmodif.Enabled=true;
			this.butsave.Enabled=true;
			this.butprint.Enabled=false;
			this.dtprq.Focus();
		}

	
		//�����¼�
		private void butsave_Click(object sender, System.EventArgs e)
		{
            if (Yp.�Ƿ�ҩ��(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),InstanceForm.BDatabase) == false)
            {
                MessageBox.Show("���ʵ����ǰ��½�Ŀ����Ƿ���ȷ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

			long djh=0;
            string sdjh = "";
			Guid djid=Guid.Empty;//����ID
			int err_code=0;
			string err_text="";
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			if (tb.Rows.Count==0){MessageBox.Show("û�пɱ���ļ�¼");return;}

			this.butsave.Enabled=false;


			try
			{
				InstanceForm.BDatabase.BeginTransaction();

				//�������ݺ�
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToInt64(this.lbldjh.Text);
                sdjh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh_Str(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToString(this.lblsdjh.Text);
				
				#region �ϼƽ��
				decimal sumjhje=0;
				decimal sumpfje=0;
				decimal sumlsje=0;
				for( int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumjhje=sumjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�������"],"0"));
					sumpfje=sumpfje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�������"],"0"));
					sumlsje=sumlsje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���۽��"],"0"));
				}
				#endregion

				//���浥�ݱ�ͷ
                Yk_dj_djmx.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), 
					djh,
					Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
					_menuTag.FunctionTag.Trim(),
					Convert.ToInt32(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"))),+
					0,
					this.dtprq.Value.ToShortDateString(),
					InstanceForm.BCurrentUser.EmployeeId,
					Convert.ToDateTime(sDate).ToShortDateString(),
					Convert.ToDateTime(sDate).ToLongTimeString(),
					"",
					"",
					this.txtbz.Text.Trim(),
					"",
					Convert.ToInt32(Convertor.IsNull(this.txtyy.Tag,"0")),
					0,
					sumjhje,
					sumpfje,
					sumlsje,
                    sdjh,
                    out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

				if (err_code!=0){throw new System.Exception(err_text);}

				//���浥����ϸ
				
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
                    Yk_dj_djmx.SaveDJMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"], Guid.Empty.ToString())),
						djid,
						Convert.ToInt32(tb.Rows[i]["cjid"]),
						Convert.ToInt32(tb.Rows[i]["kwid"]),
						Convert.ToString(tb.Rows[i]["����"]),
						Convert.ToString(tb.Rows[i]["Ʒ��"]),
						Convert.ToString(tb.Rows[i]["��Ʒ��"]),
						Convert.ToString(tb.Rows[i]["���"]),
						Convert.ToString(tb.Rows[i]["����"]),
						Convert.ToString(tb.Rows[i]["����"]),
						Convert.ToString(tb.Rows[i]["Ч��"]),
						0,//kl
						0,
						Convert.ToDecimal(tb.Rows[i]["����"]),
						Convert.ToString(tb.Rows[i]["��λ"]),
                        Yp.SeekYpdw(Convert.ToString(tb.Rows[i]["��λ"]), InstanceForm.BDatabase),
						Convert.ToInt32(tb.Rows[i]["dwbl"]),
						Convert.ToDecimal(tb.Rows[i]["����"]),
						Convert.ToDecimal(tb.Rows[i]["������"]),
						Convert.ToDecimal(tb.Rows[i]["���ۼ�"]),
						Convert.ToDecimal(tb.Rows[i]["�������"]),
						Convert.ToDecimal(tb.Rows[i]["�������"]),
						Convert.ToDecimal(tb.Rows[i]["���۽��"]),
						djh,
						Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
						_menuTag.FunctionTag.Trim(),
						"",
						"",0,
                        out err_code, out err_text, InstanceForm.BDatabase,i,
                        tb.Rows[i]["���κ�"].ToString(),
                        new Guid(tb.Rows[i]["kcid"].ToString()));
					if (err_code!=0){throw new System.Exception(err_text);}
				}

				
				//���±�ͷ����˱�־
				Yk_dj_djmx.Shdj(djid,
                    sDate, InstanceForm.BDatabase);

				//���¿��
				Yk_dj_djmx.AddUpdateKcmx(
					djid,
                    out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
				if (err_code!=0){throw new System.Exception(err_text);}


				//�ύ����
				InstanceForm.BDatabase.CommitTransaction();
                this.groupBox1.Tag = djid.ToString();
				this.lbldjh.Text=djh.ToString("00000000");
                this.lblsdjh.Text = sdjh;
				this.butadd.Enabled=false;
				this.butdel.Enabled=false;
				this.butmodif.Enabled=false;
				this.dtprq.Enabled=false;
				this.txtyy.Enabled=false;
				this.txtbz.Enabled=false;
				this.butprint.Enabled=true;
                cmbck.Enabled = false;
				MessageBox.Show(err_text);

			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				this.butsave.Enabled=true;
				MessageBox.Show(err.Message+err.Source);
				
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
					string ssql="delete from yk_djmx where id='"+Convertor.IsNull(datarow["id"],Guid.Empty.ToString())+"'";
					InstanceForm.BDatabase.DoCommand(ssql);
					tb.Rows.Remove(datarow);
					this.Sumje();
					this.csgroupbox2();
				}
			
				this.butadd.Enabled=true;
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}

	
		//�˳�
		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	
		//���Ű�ť�¼�
		private void butph_Click(object sender, System.EventArgs e)
		{
			try
			{
				int cjid=Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag,"0"));
				string[] GrdMappingName={"�к�","�����","��λ","����",  "���κ�","kcid",   "����","Ч��","��λ","kwid","id"};
				int[] GrdWidth={50,80,40,60,95,0,75,100,100,0,0};
				string[] sfield={"","","","",""};
				string ssql="select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),jhj,yppch,id kcid, ypph,ypxq,dbo.fun_yp_kwmc(ggid,deptid) kwmc,kwid,id kcid  from yk_kcph  where deptid="+Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"))+" and cjid="+cjid+" and bdelete=0  ";

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_ypbs")
                {
                    ssql += " and KCL>0";
                }
                //modify by jchl
                SystemCfg cfg = new SystemCfg(8051);//���������Զ��������ſ�����0-�Ƚ��ȳ� 1-��Ч���ȳ� 
                ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";

				TrasenFrame.Forms.Fshowcard f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,FilterType.ƴ��,"".Trim(),ssql);
				Point point=new Point(this.Location.X+this.txtph.Location.X,this.Location.Y+this.txtph.Location.Y+this.txtph.Height*3 );
				f2.Location=point;
				f2.ShowDialog(this);
				DataRow row=f2.dataRow;
				if (row!=null) 
				{
					this.txtph.Text=Convert.ToString(row["ypph"]);

                    this.txtph.Tag = Convert.ToString(row["kcid"]);
                    this.txtpch.Text = row["yppch"].ToString();

					this.lblxq.Text=Convert.ToString(row["ypxq"]);
					this.txtkw.Text=row["kwmc"].ToString();
					this.txtkw.Tag=Convert.ToInt32(row["kwid"]);

                    ////���ۡ��������
                    //if (!btjhj)
                    //{
                        int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                        decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                        decimal jhj = Convert.ToDecimal(Convertor.IsNull(row["jhj"], "0")) / dwbl;
                        jhj = Convert.ToDecimal(jhj.ToString("0.0000"));
                        this.lbljhj.Text = jhj.ToString("0.0000");

                        this.lbljhj.Tag = Convertor.IsNull(row["jhj"], "0").ToString();

                        decimal jhje = jhj * ypsl;
                        this.lbljhje.Text = jhje.ToString("0.00");
                    //}

					if(butadd.Enabled==true) butadd.Focus(); else butmodif.Focus();
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}


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
				if (row["����"].ToString().Trim()!="")
				{
					this.Sumje();
					DataRow nullrow=tb.NewRow();
					this.Getrow(nullrow);
					this.butadd.Enabled=true;
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}

	
		//����¼�
		private void butsh_Click(object sender, System.EventArgs e)
		{

		}

		#endregion

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.�����絥.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["���"]);
					if (ss.��ӡ����ʱ������ʾ��Ʒ��==true)
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["��Ʒ��"]);
					else
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["Ʒ��"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["���"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["ypsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["����"],"0"));
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["��λ"]);
					myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["������"],"0"));
					myrow["pfje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�������"],"0"));
					myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���ۼ�"],"0"));
					myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���۽��"],"0"));
					decimal plce=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���۽��"],"0"))-Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�������"],"0"));
					myrow["plce"]=plce.ToString("0.00");

					myrow["jhj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["����"],"0"));
					myrow["jhje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�������"],"0"));
					decimal jlce=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���۽��"],"0"))-Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�������"],"0"));
					myrow["jlce"]=jlce.ToString("0.00");

					myrow["ypph"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["ypxq"]=Convert.ToString(tb.Rows[i]["Ч��"]);
					myrow["shh"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["kwmc"]=Convert.ToString(tb.Rows[i]["��λ"]);
					Dset.�����絥.Rows.Add(myrow);

				}

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from vi_yk_dj where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

                string title = "";

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_ypbs" || _menuTag.Function_Name == "Fun_ts_yk_ypbs_cx")
                    title = "ҩƷ����";
                else
                    title = "ҩƷ���絥";
				ParameterEx[] parameters=new ParameterEx[9];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
                parameters[1].Value = djy + "                                 ��ӡԱ:" + InstanceForm.BCurrentUser.Name;
				parameters[2].Text="BSBYYY";
				parameters[2].Value=txtyy.Text.Trim();
				parameters[3].Text="RQ";
				parameters[3].Value=dtprq.Value.ToShortDateString();
				parameters[4].Text="TITLETEXT";
				parameters[4].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+title.Trim();
				parameters[5].Text="BZ";
				parameters[5].Value=txtbz.Text.Trim();
				parameters[6].Text="ybps";
				parameters[6].Value=lblsdjh.Text;
				parameters[7].Text="swhere";
				parameters[7].Value="��������:"+dtprq.Value.ToShortDateString()+"    ԭ��:"+txtyy.Text.Trim()+
					"     No."+lbldjh.Text+"      ��ע:"+txtbz.Text.Trim();
                parameters[8].Text = "ckmc";
                parameters[8].Value = cmbck.Text;

                string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string[] str ={ "" };
                str[0] = " update yk_dj set bprint=1,DYCZY="+InstanceForm.BCurrentUser.EmployeeId+" ,DYSJ='"+sDate+"' where id='" + new Guid(Convertor.IsNull(this.groupBox1.Tag, "")) + "'";
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.�����絥,Constant.ApplicationDirectory+"\\Report\\YK_ҩƷ�����絥.rpt",parameters,false,str,InstanceForm.BDatabase);
                if (f.LoadReportSuccess)
                {
                    f._sqlStr = str;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }



			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			

		}

		private void lbljhje_Click(object sender, System.EventArgs e)
		{
		
		}

        private void myDataGrid1_DataSourceChanged(object sender, EventArgs e)
        {

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

                if (ss.�������� == false)
                {
                    txtph.Enabled = false;
                    this.����.Width = 0;
                    this.butph.Enabled = false;
                }
                if (ss.��λ���� == false)
                {
                    txtkw.Enabled = false;
                    this.��λ.Width = 0;
                }
                if (ss.����������ʾ��Ʒ�� == true)
                    this.��Ʒ��.Width = 120;
                else
                    this.��Ʒ��.Width = 0;


                int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")); //�ⷿid
                bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);                        //�Ƿ�������ι���
                if (bpcgl)//�Ƿ���ʾ������
                    col_���κ�.Width = 75;
                else
                    col_���κ�.Width = 0;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmypbsby_Activated(object sender, EventArgs e)
        {

        }





	}
}
