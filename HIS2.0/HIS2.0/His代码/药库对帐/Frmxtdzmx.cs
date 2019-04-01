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

namespace ts_yk_xtdz
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Frmxtdzmx : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		public myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.TabPage tabPage2;
		public myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn col_��������;
		private System.Windows.Forms.DataGridTextBoxColumn col_��������;
		private System.Windows.Forms.DataGridTextBoxColumn col_�������;
		private System.Windows.Forms.DataGridTextBoxColumn col_�������;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.Button butmodif;
        private DataGridTextBoxColumn dataGridTextBoxColumn41;
        private DataGridTextBoxColumn dataGridTextBoxColumn42;
        private DataGridTextBoxColumn dataGridTextBoxColumn43;
        private DataGridTextBoxColumn dataGridTextBoxColumn44;
        private DataGridTextBoxColumn col_���κ�;
        private DataGridTextBoxColumn col_kcid;
        private DataGridTextBoxColumn col_����;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
        private DataGridTextBoxColumn col_���ڽ������;
        private DataGridTextBoxColumn col_�����������;
        private DataGridTextBoxColumn col_���������;
        private DataGridTextBoxColumn col_��������ֵ;
        private DataGridTextBoxColumn c���ڽ������;
        private DataGridTextBoxColumn c�����������;
        private DataGridTextBoxColumn c���������;
        private DataGridTextBoxColumn c��������ֵ;
        private DataGridTextBoxColumn c���κ�;
        private DataGridTextBoxColumn ckcid;
        private DataGridTextBoxColumn c����;

        bool bpcgl = false; //�Ƿ�������ι���

		public Frmxtdzmx(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

            //int deptid = Convert.ToInt32(InstanceForm.BCurrentDept.DeptId); //�ⷿid
            //bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);                        //�Ƿ�������ι���
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
				if (components != null) 
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_�������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_���ڽ������ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_�������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_����������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_��������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_��������ֵ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_���κ� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_kcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.c���ڽ������ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.c����������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.c��������� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.c��������ֵ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.c���κ� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.c���� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ckcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butmodif = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid1 ) ).BeginInit();
            this.tabPage2.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel2 ) ).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size( 60 , 17 );
            this.tabControl1.Location = new System.Drawing.Point( 0 , 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 714 , 391 );
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.myDataGrid1 );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size( 706 , 366 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "��������";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point( 0 , 0 );
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size( 706 , 366 );
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange( new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1} );
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange( new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn4,
            this.col_��������,
            this.col_���ڽ������,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22,
            this.col_��������,
            this.col_�����������,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24,
            this.col_�������,
            this.col_���������,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
            this.col_�������,
            this.col_��������ֵ,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn42,
            this.col_���κ�,
            this.col_����,
            this.col_kcid} );
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "CJID";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "�ֿ�����";
            this.dataGridTextBoxColumn41.NullText = "";
            this.dataGridTextBoxColumn41.Width = 75;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "����";
            this.dataGridTextBoxColumn39.NullText = "";
            this.dataGridTextBoxColumn39.Width = 55;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "��Ʒ��";
            this.dataGridTextBoxColumn35.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "���";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "����";
            this.dataGridTextBoxColumn37.Width = 0;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "��λ";
            this.dataGridTextBoxColumn4.Width = 40;
            // 
            // col_��������
            // 
            this.col_��������.Format = "";
            this.col_��������.FormatInfo = null;
            this.col_��������.HeaderText = "��������";
            this.col_��������.Width = 60;
            // 
            // col_���ڽ������
            // 
            this.col_���ڽ������.Format = "";
            this.col_���ڽ������.FormatInfo = null;
            this.col_���ڽ������.HeaderText = "���ڽ������";
            this.col_���ڽ������.Width = 0;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "�����������";
            this.dataGridTextBoxColumn21.Width = 0;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "�������۽��";
            this.dataGridTextBoxColumn22.Width = 0;
            // 
            // col_��������
            // 
            this.col_��������.Format = "";
            this.col_��������.FormatInfo = null;
            this.col_��������.HeaderText = "��������";
            this.col_��������.Width = 60;
            // 
            // col_�����������
            // 
            this.col_�����������.Format = "";
            this.col_�����������.FormatInfo = null;
            this.col_�����������.HeaderText = "�����������";
            this.col_�����������.Width = 0;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "�����������";
            this.dataGridTextBoxColumn23.Width = 0;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "�������۽��";
            this.dataGridTextBoxColumn24.Width = 0;
            // 
            // col_�������
            // 
            this.col_�������.Format = "";
            this.col_�������.FormatInfo = null;
            this.col_�������.HeaderText = "�������";
            this.col_�������.Width = 60;
            // 
            // col_���������
            // 
            this.col_���������.Format = "";
            this.col_���������.FormatInfo = null;
            this.col_���������.Width = 0;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "����������";
            this.dataGridTextBoxColumn25.Width = 0;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "������۽��";
            this.dataGridTextBoxColumn26.Width = 0;
            // 
            // col_�������
            // 
            this.col_�������.Format = "";
            this.col_�������.FormatInfo = null;
            this.col_�������.HeaderText = "�������";
            this.col_�������.Width = 60;
            // 
            // col_��������ֵ
            // 
            this.col_��������ֵ.Format = "";
            this.col_��������ֵ.FormatInfo = null;
            this.col_��������ֵ.HeaderText = "��������ֵ";
            this.col_��������ֵ.Width = 0;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "��������ֵ";
            this.dataGridTextBoxColumn27.Width = 0;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "���۽���ֵ";
            this.dataGridTextBoxColumn28.Width = 0;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "dwbl";
            this.dataGridTextBoxColumn33.Width = 0;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "DEPTID";
            this.dataGridTextBoxColumn42.NullText = "";
            this.dataGridTextBoxColumn42.Width = 0;
            // 
            // col_���κ�
            // 
            this.col_���κ�.Format = "";
            this.col_���κ�.FormatInfo = null;
            this.col_���κ�.HeaderText = "���κ�";
            this.col_���κ�.Width = 75;
            // 
            // col_����
            // 
            this.col_����.Format = "";
            this.col_����.FormatInfo = null;
            this.col_����.HeaderText = "����";
            this.col_����.Width = 75;
            // 
            // col_kcid
            // 
            this.col_kcid.Format = "";
            this.col_kcid.FormatInfo = null;
            this.col_kcid.HeaderText = "kcid";
            this.col_kcid.Width = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.myDataGrid2 );
            this.tabPage2.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size( 706 , 366 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "�������";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point( 0 , 0 );
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size( 706 , 366 );
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange( new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2} );
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.GridColumnStyles.AddRange( new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn29,
            this.c���ڽ������,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn30,
            this.c�����������,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn31,
            this.c���������,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn32,
            this.c��������ֵ,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn44,
            this.c���κ�,
            this.c����,
            this.ckcid} );
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "cjid";
            this.dataGridTextBoxColumn34.Width = 0;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "�ֿ�����";
            this.dataGridTextBoxColumn43.NullText = "";
            this.dataGridTextBoxColumn43.Width = 75;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "����";
            this.dataGridTextBoxColumn40.NullText = "";
            this.dataGridTextBoxColumn40.Width = 50;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn10.MappingName = "Ʒ��";
            this.dataGridTextBoxColumn10.Width = 0;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "��Ʒ��";
            this.dataGridTextBoxColumn36.Width = 90;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "���";
            this.dataGridTextBoxColumn11.MappingName = "���";
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "����";
            this.dataGridTextBoxColumn38.Width = 0;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "��λ";
            this.dataGridTextBoxColumn12.MappingName = "��λ";
            this.dataGridTextBoxColumn12.Width = 30;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "��������";
            this.dataGridTextBoxColumn29.Width = 0;
            // 
            // c���ڽ������
            // 
            this.c���ڽ������.Format = "";
            this.c���ڽ������.FormatInfo = null;
            this.c���ڽ������.HeaderText = "���ڽ������";
            this.c���ڽ������.Width = 0;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "�����������";
            this.dataGridTextBoxColumn13.Width = 0;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "�������۽��";
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "��������";
            this.dataGridTextBoxColumn30.Width = 0;
            // 
            // c�����������
            // 
            this.c�����������.Format = "";
            this.c�����������.FormatInfo = null;
            this.c�����������.HeaderText = "�����������";
            this.c�����������.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "�����������";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "�������۽��";
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "�������";
            this.dataGridTextBoxColumn31.Width = 0;
            // 
            // c���������
            // 
            this.c���������.Format = "";
            this.c���������.FormatInfo = null;
            this.c���������.HeaderText = "���������";
            this.c���������.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "����������";
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "������۽��";
            this.dataGridTextBoxColumn18.Width = 0;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "������ֵ";
            this.dataGridTextBoxColumn32.Width = 0;
            // 
            // c��������ֵ
            // 
            this.c��������ֵ.Format = "";
            this.c��������ֵ.FormatInfo = null;
            this.c��������ֵ.HeaderText = "��������ֵ";
            this.c��������ֵ.Width = 75;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "��������ֵ";
            this.dataGridTextBoxColumn19.Width = 75;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "���۽���ֵ";
            this.dataGridTextBoxColumn20.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "dwbl";
            this.dataGridTextBoxColumn9.Width = 0;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "DEPTID";
            this.dataGridTextBoxColumn44.NullText = "";
            this.dataGridTextBoxColumn44.Width = 0;
            // 
            // c���κ�
            // 
            this.c���κ�.Format = "";
            this.c���κ�.FormatInfo = null;
            this.c���κ�.HeaderText = "���κ�";
            this.c���κ�.Width = 125;
            // 
            // c����
            // 
            this.c����.Format = "";
            this.c����.FormatInfo = null;
            this.c����.HeaderText = "����";
            this.c����.Width = 0;
            // 
            // ckcid
            // 
            this.ckcid.Format = "";
            this.ckcid.FormatInfo = null;
            this.ckcid.HeaderText = "kcid";
            this.ckcid.Width = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point( 0 , 447 );
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange( new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2} );
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size( 714 , 24 );
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
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
            // panel1
            // 
            this.panel1.Controls.Add( this.butmodif );
            this.panel1.Controls.Add( this.button2 );
            this.panel1.Controls.Add( this.button1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0 , 391 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 714 , 56 );
            this.panel1.TabIndex = 2;
            // 
            // butmodif
            // 
            this.butmodif.Location = new System.Drawing.Point( 240 , 8 );
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size( 112 , 32 );
            this.butmodif.TabIndex = 3;
            this.butmodif.Text = "��������(&M)";
            this.butmodif.Click += new System.EventHandler( this.butmodif_Click );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 480 , 8 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 112 , 32 );
            this.button2.TabIndex = 1;
            this.button2.Text = "�˳�(&Q)";
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 360 , 8 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 112 , 32 );
            this.button1.TabIndex = 0;
            this.button1.Text = "��������(&O)";
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.tabControl1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0 , 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 714 , 391 );
            this.panel2.TabIndex = 3;
            // 
            // Frmxtdzmx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 714 , 471 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.statusBar1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Frmxtdzmx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ϵͳ���ʽ��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.Frmxtdz_Load );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid1 ) ).EndInit();
            this.tabPage2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel2 ) ).EndInit();
            this.panel1.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.ResumeLayout( false );

		}
		#endregion


		private void Frmxtdz_Load(object sender, System.EventArgs e)
		{
			//��ʼ��
			DataTable Tb=new DataTable();
			Tb.TableName="Tb";
			for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
					Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
				else
					Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
				this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
				this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
			}
			this.myDataGrid1.DataSource=Tb;
			this.myDataGrid1.TableStyles[0].MappingName ="Tb";

			//��ʼ��
			DataTable Tb1=new DataTable();
			Tb1.TableName="Tb1";
			for(int i=0;i<=this.myDataGrid2.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
					Tb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
				else
					Tb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
				this.myDataGrid2.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText;
				this.myDataGrid2.TableStyles[0].GridColumnStyles[i].NullText="";
			}
			this.myDataGrid2.DataSource=Tb1;
			this.myDataGrid2.TableStyles[0].MappingName ="Tb1";

			_menuTag.FunctionTag="012";


            SystemCfg cfg = new SystemCfg(8026);
            if (cfg.Config == "1")
                butmodif.Enabled = true;
            else
                butmodif.Enabled = false;

            int deptid = Convert.ToInt32(InstanceForm.BCurrentDept.DeptId);
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
            if (!bpcgl)
            {
                col_���κ�.Width = 0;
                col_����.Width = 0;

                c���κ�.Width = 0;
                c����.Width = 0;
                c���ڽ������.Width = 0;
                c�����������.Width = 0;
                c���������.Width = 0;
                c��������ֵ.Width = 0;
            }


		}

		public void FillData(DataTable tb)
		{
				

			DataTable Tb=(DataTable)this.myDataGrid1.DataSource;
			Tb.TableName="Tb";
			DataRow[] row=tb.Select("������ֵ<> 0");
			for(int i=0;i<=row.Length-1;i++)
			{
				Tb.Rows.Add(row[i].ItemArray);
			}
			myDataGrid1.DataSource=Tb;

			DataTable Tb1=(DataTable)this.myDataGrid2.DataSource;
			Tb1.TableName="Tb1";
			DataRow[] row1=tb.Select("��������ֵ<> 0 or ���۽���ֵ<>0  or ��������ֵ<>0");
			for(int i=0;i<=row1.Length-1;i++)
			{
				Tb1.Rows.Add(row1[i].ItemArray);
			}
			myDataGrid2.DataSource=Tb1;

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			DataTable tbsl=(DataTable)this.myDataGrid1.DataSource;
			if (tbsl.Rows.Count>0){MessageBox.Show("�����������ʱ��������������������Ƚ����������͹���Ա��ϵ!");return;}
			DataTable tbje=(DataTable)this.myDataGrid2.DataSource;
			if (tbje.Rows.Count==0) {MessageBox.Show("û����Ҫ������������");return;}

			if(MessageBox.Show("��ȷ��Ҫ������������������������ ��","ѯ�ʴ�",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
			{
				return;
			}

            //if (sumlsje >= 100 || sumpfje >= 100)
            //{
            //    MessageBox.Show("�������̫���ˣ�ϵͳ���ݿ��ܴ������⣡��͹���Ա��ϵ");
            //    return;
            //}

            DataTable tb = (DataTable)this.myDataGrid2.DataSource;


			long djh=0;       //���ݺ�
            string sdjh = "";
			Guid  djid=Guid.Empty;	  //����ID
			int err_code=0;   //�����
			string err_text="";//�����ı�
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//�Ǽ�ʱ��
			this.button1.Enabled=false;

			try
			{
				InstanceForm.BDatabase.BeginTransaction();

                //����ҩ���ֿ�
                string[] GroupbyField1 ={ "deptid" };
                string[] ComputeField1 ={ };
                string[] CField1 ={  };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
                if (tbcf1.Rows.Count == 0) { MessageBox.Show("û����Ҫ�����Ľ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


                //�������ֿ�Ľ��
                for (int xxx = 0; xxx <= tbcf1.Rows.Count - 1; xxx++)
                {
                    int _deptID = Convert.ToInt32(tbcf1.Rows[xxx]["deptid"]);
                    DataRow[] rows = tb.Select("deptid='" + _deptID + "' ");

                    //�������ݺ�
                    djh = Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), _deptID, InstanceForm.BDatabase);
                    sdjh = Yp.SeekNewDjh_Str(_menuTag.FunctionTag.Trim(), _deptID, InstanceForm.BDatabase);

                    decimal sumlsje = 0;
                    decimal sumpfje = 0;
                    decimal sumjhje = 0;
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        sumjhje += Convert.ToDecimal(rows[i]["��������ֵ"]);
                        sumlsje = sumlsje + Convert.ToDecimal(rows[i]["���۽���ֵ"]);
                        sumpfje = sumpfje + Convert.ToDecimal(rows[i]["��������ֵ"]);
                    }

                    //���浥�ݱ�ͷ
                    Yk_dj_djmx.SaveDJ(Guid.Empty,
                        djh,
                        _deptID,
                        _menuTag.FunctionTag.Trim(),
                        _deptID,
                        0,
                        Convert.ToDateTime(sDate).ToShortDateString(),
                        InstanceForm.BCurrentUser.EmployeeId,
                        Convert.ToDateTime(sDate).ToShortDateString(),
                        Convert.ToDateTime(sDate).ToLongTimeString(),
                        "",
                        "",
                        "",
                        "",
                        0,
                        0,
                        sumjhje,
                        sumpfje,
                        sumlsje,
                        sdjh,
                        out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                    if (err_code != 0) { throw new System.Exception(err_text); }

                    //���浥����ϸ
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        Yk_dj_djmx.SaveDJMX(Guid.Empty,
                            djid,
                            Convert.ToInt32(rows[i]["cjid"]),
                            0,
                            Convert.ToString(rows[i]["����"]),
                            Convert.ToString(rows[i]["Ʒ��"]),
                            Convert.ToString(rows[i]["��Ʒ��"]),
                            Convert.ToString(rows[i]["���"]),
                            Convert.ToString(rows[i]["����"]),
                            "",
                            "",
                            0,
                            0,
                            0,
                            Convert.ToString(rows[i]["��λ"]),
                            Yp.SeekYpdw(Convert.ToString(rows[i]["��λ"]), InstanceForm.BDatabase),
                            Convert.ToInt32(rows[i]["dwbl"]),
                            0,
                            0,
                            0,
                             Convert.ToDecimal(rows[i]["��������ֵ"])*(-1),
                            Convert.ToDecimal(rows[i]["��������ֵ"])*(-1),
                            Convert.ToDecimal(rows[i]["���۽���ֵ"]) * (-1),
                            djh,
                            _deptID,
                            _menuTag.FunctionTag.Trim(),
                            "",
                            "",0,
                            out err_code, out err_text, InstanceForm.BDatabase,i,
                            rows[i]["���κ�"].ToString(),
                            new Guid(rows[i]["kcid"].ToString()));

                        if (err_code != 0) { throw new System.Exception(err_text); }
                    }


                    //��˵���
                    Yk_dj_djmx.Shdj(djid,
                            sDate, InstanceForm.BDatabase);
                }

				//�ύ����
				InstanceForm.BDatabase.CommitTransaction();

				MessageBox.Show(err_text);

			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				this.button1.Enabled=true;
				MessageBox.Show(err.Message+err.Source);
				
			}


		}

        //��������
		private void butmodif_Click(object sender, System.EventArgs e)
		{
            //���浥����ϸ
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb.Rows.Count == 0) { MessageBox.Show("û�п������ļ�¼"); return; };
            string ssql = "";

			try
			{
                InstanceForm.BDatabase.BeginTransaction();
                if (!bpcgl) //���������ι���
                {
                    #region
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        int _deptid = Convert.ToInt32(tb.Rows[i]["deptid"]);

                        ssql = "update yk_kcmx set kcl=kcl+(" + Convert.ToDecimal(tb.Rows[i]["�������"]) + ") where deptid=" + _deptid + " and cjid=" + Convert.ToInt32(tb.Rows[i]["cjid"]) + " ";
                        InstanceForm.BDatabase.DoCommand(ssql);

                        ssql = "select * from yk_kcph where deptid=" + _deptid + " and cjid=" + Convert.ToInt32(tb.Rows[i]["cjid"]) + " order by bdelete asc,ypxq desc";
                        DataTable tbkc = InstanceForm.BDatabase.GetDataTable(ssql);

                        ssql = "update yk_kcph set kcl=kcl+(" + Convert.ToDecimal(tb.Rows[i]["�������"]) + ") where deptid=" + _deptid + " and cjid=" + Convert.ToInt32(tb.Rows[i]["cjid"]) + " and id='" + new Guid(tbkc.Rows[0]["id"].ToString()) + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                    #endregion
                }
                else//�������ι���
                {
                    #region
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        int _deptid = Convert.ToInt32(tb.Rows[i]["deptid"]);
                        decimal sl_wc = Convert.ToDecimal(tb.Rows[i]["�������"]);
                        int cjid = Convert.ToInt32(tb.Rows[i]["cjid"]);
                        Guid kcid = new Guid(tb.Rows[i]["kcid"].ToString());

                        //���������ϸ���� kcl 
                        ssql = string.Format(" update yk_kcmx set kcl=kcl+{0} where deptid ={1} and cjid={2}",sl_wc,_deptid,cjid);
                        if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                            throw new Exception("����ʧ��kcmx");

                        //����������ű�������
                        ssql = string.Format(" select * from yk_kcph where deptid={0} and id='{1}'",_deptid,kcid);
                        DataTable tb_temp = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tb_temp.Rows.Count > 0)
                        {
                            ssql = string.Format(" update yk_kcph set kcl=kcl+{0} where deptid={1} and id='{2}'",sl_wc,_deptid,kcid);
                            if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                                throw new Exception("����ʧ��,update kcph");
                        }
                        else
                        {
                            throw new Exception("����ʧ�ܣ��Ҳ����ÿ�����Σ�����ϵϵͳ����Ա");
//                            ssql = string.Format(@" insert into yk_kcph (id,jgbm,ggid,cjid,kwid,ypph,ypxq,jhj,kcl,zxdw,
//                                    dwbl,djsj,bdelete,deptid,ykbdelete,yppch,rkdjmxid,rkdh)  
//                            values ()");
                        }
                    }
                    #endregion
                }

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("�����ɹ�");

			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				this.button1.Enabled=true;
				MessageBox.Show(err.Message+err.Source);
				
			}
		}
	}
}
