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

namespace ts_zyhs_rypg
{
    /// <summary>
    /// Form1 ��ժҪ˵����
    /// </summary>
    public class frmRYPG : System.Windows.Forms.Form
    {
        //�Զ������
        private BaseFunc myFunc;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lbסԺ������;
        private System.Windows.Forms.Label lb����;
        private System.Windows.Forms.Label lb����;
        private System.Windows.Forms.Label lb����;
        private System.Windows.Forms.Label lb����;
        private System.Windows.Forms.Label lb�Ա�;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lbҽ�Ʒ���;
        private System.Windows.Forms.TextBox tb��ϵ�绰;
        private System.Windows.Forms.TextBox tb�뻼�߹�ϵ;
        private System.Windows.Forms.TextBox tb��ϵ��;
        private System.Windows.Forms.TextBox tb��ͥ��ַ;
        private System.Windows.Forms.DateTimePicker dtp��Ժʱ��;
        private System.Windows.Forms.Label lb�½�;
        private CheckBox chkbox = new CheckBox();
        private System.Windows.Forms.CheckedListBox clbWHCD;
        private System.Windows.Forms.TextBox tb��������;
        private System.Windows.Forms.TextBox tb��ҽ;
        private System.Windows.Forms.CheckedListBox ckbHYZT;
        private System.Windows.Forms.CheckedListBox ckbRYFS;
        private System.Windows.Forms.TextBox tb��Ժ��ʽ����;
        private System.Windows.Forms.CheckedListBox ckbPS;
        private System.Windows.Forms.TextBox tb��������;
        private System.Windows.Forms.CheckedListBox ckbJWBS;
        private System.Windows.Forms.TextBox tb������ʷ;
        private System.Windows.Forms.CheckedListBox ckbGMS;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckedListBox ckbYS;
        private System.Windows.Forms.TextBox tb��ʳ�쳣;
        private System.Windows.Forms.TextBox tb��ʳ�Ⱥ�;
        private System.Windows.Forms.CheckedListBox ckbSM;
        private System.Windows.Forms.TextBox tb˯������;
        private System.Windows.Forms.CheckedListBox ckbDB;
        private System.Windows.Forms.TextBox tb�������;
        private System.Windows.Forms.CheckedListBox ckbXB;
        private System.Windows.Forms.DateTimePicker dtp֪ͨҽʦʱ��;
        private System.Windows.Forms.TextBox tb��������;
        private System.Windows.Forms.DataGrid dg1;
        private System.Windows.Forms.TextBox zy;
        private System.Windows.Forms.TextBox jg;
        private System.Windows.Forms.TextBox mz;
        private DataTable tb, tb1, tb2;
        int inputflag = 1;
        private System.Windows.Forms.TextBox tb����;
        private System.Windows.Forms.CheckedListBox ckbmx;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox tb��̦����;
        private System.Windows.Forms.CheckedListBox ckbST;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.CheckedListBox ckbJSZT;
        private System.Windows.Forms.CheckedListBox ckbZYZT;
        private System.Windows.Forms.TextBox tb��������;
        private System.Windows.Forms.CheckedListBox ckbQX;
        private System.Windows.Forms.CheckedListBox ckbYE;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.CheckedListBox ckbZE;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.CheckedListBox ckbYY;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.CheckedListBox ckbZY;
        private System.Windows.Forms.TextBox tbƤ������������;
        private System.Windows.Forms.CheckedListBox ckbPFWZX;
        private System.Windows.Forms.TextBox tb��������;
        private System.Windows.Forms.CheckedListBox ckbSZ;
        private System.Windows.Forms.CheckedListBox ckbYSZT;
        private System.Windows.Forms.CheckedListBox ckbDGQK;
        private System.Windows.Forms.CheckedListBox ckbZTHD_TH;
        private System.Windows.Forms.TextBox tb֫���ϰ�;
        private System.Windows.Forms.CheckedListBox ckbZTHD;
        private System.Windows.Forms.CheckedListBox ckbZLNL;
        private System.Windows.Forms.DateTimePicker dtp����ʱ��;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox lb������ʿ;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox tb��ע;
        private System.Windows.Forms.TextBox tbѪѹ;
        private System.Windows.Forms.TextBox tb����;
        private System.Windows.Forms.TextBox tb����;
        private System.Windows.Forms.TextBox tb����;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb�޸�ʱ��;
        private System.Windows.Forms.Label lb����ʱ��;
        private System.Windows.Forms.Label lb�޸���;
        private System.Windows.Forms.Label lb������;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt�˳�;
        private System.Windows.Forms.Button btUse;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox tb����ҩ��;
        private System.Windows.Forms.ComboBox tb����ʳ��;
        private System.Windows.Forms.ComboBox tb�����������;
        private System.Windows.Forms.ComboBox tbƤ��������ѹ;
        private System.Windows.Forms.ComboBox tb��������;
        private System.Windows.Forms.ComboBox tb��������;
        private System.Windows.Forms.ComboBox tb�������;
        private System.Windows.Forms.ComboBox tb�Ҷ�����;
        private System.Windows.Forms.TextBox lb��Ժ���;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtInpatNo;
        private System.Windows.Forms.Button btnSeek;
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmRYPG(string _formText)
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
        /// 
        //װ�����ݿ������ݲ���ʾ�ڽ�����
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb�������� = new System.Windows.Forms.TextBox();
            this.tb�Ҷ����� = new System.Windows.Forms.ComboBox();
            this.tb������� = new System.Windows.Forms.ComboBox();
            this.tb�������� = new System.Windows.Forms.ComboBox();
            this.tbƤ��������ѹ = new System.Windows.Forms.ComboBox();
            this.tb����������� = new System.Windows.Forms.ComboBox();
            this.tb���� = new System.Windows.Forms.TextBox();
            this.ckbmx = new System.Windows.Forms.CheckedListBox();
            this.label58 = new System.Windows.Forms.Label();
            this.tb��̦���� = new System.Windows.Forms.TextBox();
            this.ckbST = new System.Windows.Forms.CheckedListBox();
            this.label56 = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.ckbJSZT = new System.Windows.Forms.CheckedListBox();
            this.ckbZYZT = new System.Windows.Forms.CheckedListBox();
            this.tb�������� = new System.Windows.Forms.TextBox();
            this.ckbQX = new System.Windows.Forms.CheckedListBox();
            this.ckbYE = new System.Windows.Forms.CheckedListBox();
            this.label55 = new System.Windows.Forms.Label();
            this.ckbZE = new System.Windows.Forms.CheckedListBox();
            this.label64 = new System.Windows.Forms.Label();
            this.ckbYY = new System.Windows.Forms.CheckedListBox();
            this.label63 = new System.Windows.Forms.Label();
            this.tbƤ������������ = new System.Windows.Forms.TextBox();
            this.ckbPFWZX = new System.Windows.Forms.CheckedListBox();
            this.ckbSZ = new System.Windows.Forms.CheckedListBox();
            this.ckbYSZT = new System.Windows.Forms.CheckedListBox();
            this.ckbDGQK = new System.Windows.Forms.CheckedListBox();
            this.ckbZTHD_TH = new System.Windows.Forms.CheckedListBox();
            this.tb֫���ϰ� = new System.Windows.Forms.TextBox();
            this.ckbZTHD = new System.Windows.Forms.CheckedListBox();
            this.ckbZLNL = new System.Windows.Forms.CheckedListBox();
            this.dtp����ʱ�� = new System.Windows.Forms.DateTimePicker();
            this.label71 = new System.Windows.Forms.Label();
            this.lb������ʿ = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.tb��ע = new System.Windows.Forms.TextBox();
            this.tbѪѹ = new System.Windows.Forms.TextBox();
            this.tb���� = new System.Windows.Forms.TextBox();
            this.tb���� = new System.Windows.Forms.TextBox();
            this.tb���� = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.tb�������� = new System.Windows.Forms.ComboBox();
            this.ckbZY = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb�޸�ʱ�� = new System.Windows.Forms.Label();
            this.lb����ʱ�� = new System.Windows.Forms.Label();
            this.lb�޸��� = new System.Windows.Forms.Label();
            this.lb������ = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.bt�˳� = new System.Windows.Forms.Button();
            this.btUse = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dg1 = new System.Windows.Forms.DataGrid();
            this.tb�������� = new System.Windows.Forms.TextBox();
            this.ckbHYZT = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtInpatNo = new System.Windows.Forms.TextBox();
            this.btnSeek = new System.Windows.Forms.Button();
            this.lb��Ժ��� = new System.Windows.Forms.TextBox();
            this.tb����ʳ�� = new System.Windows.Forms.ComboBox();
            this.tb����ҩ�� = new System.Windows.Forms.ComboBox();
            this.mz = new System.Windows.Forms.TextBox();
            this.jg = new System.Windows.Forms.TextBox();
            this.zy = new System.Windows.Forms.TextBox();
            this.ckbXB = new System.Windows.Forms.CheckedListBox();
            this.tb������� = new System.Windows.Forms.TextBox();
            this.ckbDB = new System.Windows.Forms.CheckedListBox();
            this.tb˯������ = new System.Windows.Forms.TextBox();
            this.ckbSM = new System.Windows.Forms.CheckedListBox();
            this.tb��ʳ�Ⱥ� = new System.Windows.Forms.TextBox();
            this.tb��ʳ�쳣 = new System.Windows.Forms.TextBox();
            this.ckbYS = new System.Windows.Forms.CheckedListBox();
            this.tb�������� = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.ckbGMS = new System.Windows.Forms.CheckedListBox();
            this.tb������ʷ = new System.Windows.Forms.TextBox();
            this.ckbJWBS = new System.Windows.Forms.CheckedListBox();
            this.tb�������� = new System.Windows.Forms.TextBox();
            this.ckbPS = new System.Windows.Forms.CheckedListBox();
            this.tb��Ժ��ʽ���� = new System.Windows.Forms.TextBox();
            this.ckbRYFS = new System.Windows.Forms.CheckedListBox();
            this.clbWHCD = new System.Windows.Forms.CheckedListBox();
            this.lb�½� = new System.Windows.Forms.Label();
            this.lbҽ�Ʒ��� = new System.Windows.Forms.Label();
            this.lb�Ա� = new System.Windows.Forms.Label();
            this.lb���� = new System.Windows.Forms.Label();
            this.tb��ҽ = new System.Windows.Forms.TextBox();
            this.tb��ϵ�绰 = new System.Windows.Forms.TextBox();
            this.tb�뻼�߹�ϵ = new System.Windows.Forms.TextBox();
            this.tb��ϵ�� = new System.Windows.Forms.TextBox();
            this.tb��ͥ��ַ = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtp֪ͨҽʦʱ�� = new System.Windows.Forms.DateTimePicker();
            this.dtp��Ժʱ�� = new System.Windows.Forms.DateTimePicker();
            this.lbסԺ������ = new System.Windows.Forms.Label();
            this.lb���� = new System.Windows.Forms.Label();
            this.lb���� = new System.Windows.Forms.Label();
            this.lb���� = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 680);
            this.panel1.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tb��������);
            this.panel3.Controls.Add(this.tb�Ҷ�����);
            this.panel3.Controls.Add(this.tb�������);
            this.panel3.Controls.Add(this.tb��������);
            this.panel3.Controls.Add(this.tbƤ��������ѹ);
            this.panel3.Controls.Add(this.tb�����������);
            this.panel3.Controls.Add(this.tb����);
            this.panel3.Controls.Add(this.ckbmx);
            this.panel3.Controls.Add(this.label58);
            this.panel3.Controls.Add(this.tb��̦����);
            this.panel3.Controls.Add(this.ckbST);
            this.panel3.Controls.Add(this.label56);
            this.panel3.Controls.Add(this.statusBar1);
            this.panel3.Controls.Add(this.ckbJSZT);
            this.panel3.Controls.Add(this.ckbZYZT);
            this.panel3.Controls.Add(this.tb��������);
            this.panel3.Controls.Add(this.ckbQX);
            this.panel3.Controls.Add(this.ckbYE);
            this.panel3.Controls.Add(this.label55);
            this.panel3.Controls.Add(this.ckbZE);
            this.panel3.Controls.Add(this.label64);
            this.panel3.Controls.Add(this.ckbYY);
            this.panel3.Controls.Add(this.label63);
            this.panel3.Controls.Add(this.tbƤ������������);
            this.panel3.Controls.Add(this.ckbPFWZX);
            this.panel3.Controls.Add(this.ckbSZ);
            this.panel3.Controls.Add(this.ckbYSZT);
            this.panel3.Controls.Add(this.ckbDGQK);
            this.panel3.Controls.Add(this.ckbZTHD_TH);
            this.panel3.Controls.Add(this.tb֫���ϰ�);
            this.panel3.Controls.Add(this.ckbZTHD);
            this.panel3.Controls.Add(this.ckbZLNL);
            this.panel3.Controls.Add(this.dtp����ʱ��);
            this.panel3.Controls.Add(this.label71);
            this.panel3.Controls.Add(this.lb������ʿ);
            this.panel3.Controls.Add(this.label70);
            this.panel3.Controls.Add(this.tb��ע);
            this.panel3.Controls.Add(this.tbѪѹ);
            this.panel3.Controls.Add(this.tb����);
            this.panel3.Controls.Add(this.tb����);
            this.panel3.Controls.Add(this.tb����);
            this.panel3.Controls.Add(this.label62);
            this.panel3.Controls.Add(this.label61);
            this.panel3.Controls.Add(this.label60);
            this.panel3.Controls.Add(this.label59);
            this.panel3.Controls.Add(this.label52);
            this.panel3.Controls.Add(this.label51);
            this.panel3.Controls.Add(this.label50);
            this.panel3.Controls.Add(this.label49);
            this.panel3.Controls.Add(this.label48);
            this.panel3.Controls.Add(this.label46);
            this.panel3.Controls.Add(this.label47);
            this.panel3.Controls.Add(this.label45);
            this.panel3.Controls.Add(this.label44);
            this.panel3.Controls.Add(this.label43);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.label40);
            this.panel3.Controls.Add(this.label38);
            this.panel3.Controls.Add(this.label39);
            this.panel3.Controls.Add(this.label54);
            this.panel3.Controls.Add(this.label53);
            this.panel3.Controls.Add(this.label57);
            this.panel3.Controls.Add(this.tb��������);
            this.panel3.Controls.Add(this.ckbZY);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(508, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(508, 600);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tb��������
            // 
            this.tb��������.Enabled = false;
            this.tb��������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��������.Location = new System.Drawing.Point(328, 272);
            this.tb��������.Name = "tb��������";
            this.tb��������.Size = new System.Drawing.Size(152, 21);
            this.tb��������.TabIndex = 51;
            // 
            // tb�Ҷ�����
            // 
            this.tb�Ҷ�����.ForeColor = System.Drawing.Color.Blue;
            this.tb�Ҷ�����.Items.AddRange(new object[] {
            "�����½�",
            "����",
            "����"});
            this.tb�Ҷ�����.Location = new System.Drawing.Point(432, 416);
            this.tb�Ҷ�����.Name = "tb�Ҷ�����";
            this.tb�Ҷ�����.Size = new System.Drawing.Size(48, 20);
            this.tb�Ҷ�����.TabIndex = 1154;
            // 
            // tb�������
            // 
            this.tb�������.ForeColor = System.Drawing.Color.Blue;
            this.tb�������.Items.AddRange(new object[] {
            "�����½�",
            "����",
            "����"});
            this.tb�������.Location = new System.Drawing.Point(224, 416);
            this.tb�������.Name = "tb�������";
            this.tb�������.Size = new System.Drawing.Size(48, 20);
            this.tb�������.TabIndex = 1153;
            // 
            // tb��������
            // 
            this.tb��������.ForeColor = System.Drawing.Color.Blue;
            this.tb��������.Items.AddRange(new object[] {
            "����",
            "Զ��",
            "������",
            "�����"});
            this.tb��������.Location = new System.Drawing.Point(432, 392);
            this.tb��������.Name = "tb��������";
            this.tb��������.Size = new System.Drawing.Size(48, 20);
            this.tb��������.TabIndex = 1152;
            // 
            // tbƤ��������ѹ
            // 
            this.tbƤ��������ѹ.Enabled = false;
            this.tbƤ��������ѹ.ForeColor = System.Drawing.Color.Blue;
            this.tbƤ��������ѹ.Items.AddRange(new object[] {
            "��β��",
            "����",
            "����",
            "���",
            "�Ų�",
            "��",
            "���β�"});
            this.tbƤ��������ѹ.Location = new System.Drawing.Point(392, 368);
            this.tbƤ��������ѹ.Name = "tbƤ��������ѹ";
            this.tbƤ��������ѹ.Size = new System.Drawing.Size(88, 20);
            this.tbƤ��������ѹ.TabIndex = 1151;
            // 
            // tb�����������
            // 
            this.tb�����������.ForeColor = System.Drawing.Color.Blue;
            this.tb�����������.Items.AddRange(new object[] {
            "\"T\"�͹�",
            "����������",
            "θ��"});
            this.tb�����������.Location = new System.Drawing.Point(184, 80);
            this.tb�����������.Name = "tb�����������";
            this.tb�����������.Size = new System.Drawing.Size(295, 20);
            this.tb�����������.TabIndex = 161;
            // 
            // tb����
            // 
            this.tb����.Enabled = false;
            this.tb����.Location = new System.Drawing.Point(328, 336);
            this.tb����.Name = "tb����";
            this.tb����.Size = new System.Drawing.Size(152, 21);
            this.tb����.TabIndex = 53;
            // 
            // ckbmx
            // 
            this.ckbmx.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbmx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbmx.CheckOnClick = true;
            this.ckbmx.ColumnWidth = 100;
            this.ckbmx.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbmx.Items.AddRange(new object[] {
            "ƽ��",
            "����",
            "����",
            "����",
            "����",
            "����",
            "����",
            "ɬ��",
            "����",
            "ϸ��",
            "���",
            "������"});
            this.ckbmx.Location = new System.Drawing.Point(72, 288);
            this.ckbmx.MultiColumn = true;
            this.ckbmx.Name = "ckbmx";
            this.ckbmx.Size = new System.Drawing.Size(408, 64);
            this.ckbmx.TabIndex = 52;
            this.ckbmx.Tag = "9";
            this.ckbmx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbmx_MouseUp);
            this.ckbmx.SelectedIndexChanged += new System.EventHandler(this.ckbmx_SelectedIndexChanged);
            this.ckbmx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbmx_KeyUp);
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(8, 288);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(72, 16);
            this.label58.TabIndex = 151;
            this.label58.Text = "��  ��";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb��̦����
            // 
            this.tb��̦����.Enabled = false;
            this.tb��̦����.Location = new System.Drawing.Point(328, 224);
            this.tb��̦����.Name = "tb��̦����";
            this.tb��̦����.Size = new System.Drawing.Size(152, 21);
            this.tb��̦����.TabIndex = 48;
            this.tb��̦����.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb��̦����_KeyUp);
            // 
            // ckbST
            // 
            this.ckbST.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbST.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbST.CheckOnClick = true;
            this.ckbST.ColumnWidth = 100;
            this.ckbST.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbST.Items.AddRange(new object[] {
            "����",
            "����",
            "����",
            "����",
            "��̦",
            "����",
            "����",
            "��̦",
            "������"});
            this.ckbST.Location = new System.Drawing.Point(72, 192);
            this.ckbST.MultiColumn = true;
            this.ckbST.Name = "ckbST";
            this.ckbST.Size = new System.Drawing.Size(408, 48);
            this.ckbST.TabIndex = 46;
            this.ckbST.Tag = "9";
            this.ckbST.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbST_MouseUp_1);
            this.ckbST.SelectedIndexChanged += new System.EventHandler(this.ckbST_SelectedIndexChanged_1);
            this.ckbST.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbST_KeyUp_1);
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(8, 240);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(56, 16);
            this.label56.TabIndex = 148;
            this.label56.Text = "��  �ʣ�";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar1.Location = new System.Drawing.Point(8, 568);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(472, 24);
            this.statusBar1.TabIndex = 147;
            this.statusBar1.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar1_PanelClick);
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 250;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 250;
            // 
            // ckbJSZT
            // 
            this.ckbJSZT.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbJSZT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbJSZT.CheckOnClick = true;
            this.ckbJSZT.ColumnWidth = 90;
            this.ckbJSZT.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbJSZT.Items.AddRange(new object[] {
            "����",
            "���ڹ���",
            "Ƿ����",
            "�����չ�"});
            this.ckbJSZT.Location = new System.Drawing.Point(72, 504);
            this.ckbJSZT.MultiColumn = true;
            this.ckbJSZT.Name = "ckbJSZT";
            this.ckbJSZT.Size = new System.Drawing.Size(376, 16);
            this.ckbJSZT.TabIndex = 71;
            this.ckbJSZT.Tag = "4";
            this.ckbJSZT.SelectedIndexChanged += new System.EventHandler(this.ckbJSZT_SelectedIndexChanged);
            this.ckbJSZT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbJSZT_KeyUp);
            // 
            // ckbZYZT
            // 
            this.ckbZYZT.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZYZT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZYZT.CheckOnClick = true;
            this.ckbZYZT.ColumnWidth = 100;
            this.ckbZYZT.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZYZT.Items.AddRange(new object[] {
            "�ڸ�",
            "�¸�",
            "��ũ",
            "��ҵ",
            "���徭Ӫ",
            "ɥʧ�Ͷ�����",
            "������"});
            this.ckbZYZT.Location = new System.Drawing.Point(72, 472);
            this.ckbZYZT.MultiColumn = true;
            this.ckbZYZT.Name = "ckbZYZT";
            this.ckbZYZT.Size = new System.Drawing.Size(408, 32);
            this.ckbZYZT.TabIndex = 70;
            this.ckbZYZT.Tag = "6";
            this.ckbZYZT.SelectedIndexChanged += new System.EventHandler(this.ckbZYZT_SelectedIndexChanged);
            this.ckbZYZT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZYZT_KeyUp);
            // 
            // tb��������
            // 
            this.tb��������.Enabled = false;
            this.tb��������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��������.Location = new System.Drawing.Point(328, 440);
            this.tb��������.Name = "tb��������";
            this.tb��������.Size = new System.Drawing.Size(152, 21);
            this.tb��������.TabIndex = 69;
            // 
            // ckbQX
            // 
            this.ckbQX.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbQX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbQX.CheckOnClick = true;
            this.ckbQX.ColumnWidth = 65;
            this.ckbQX.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbQX.Items.AddRange(new object[] {
            "����",
            "����",
            "��ŭ",
            "�־�",
            "����",
            "����",
            "������"});
            this.ckbQX.Location = new System.Drawing.Point(72, 440);
            this.ckbQX.MultiColumn = true;
            this.ckbQX.Name = "ckbQX";
            this.ckbQX.Size = new System.Drawing.Size(408, 32);
            this.ckbQX.TabIndex = 68;
            this.ckbQX.Tag = "7";
            this.ckbQX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbQX_MouseUp);
            this.ckbQX.SelectedIndexChanged += new System.EventHandler(this.ckbQX_SelectedIndexChanged);
            this.ckbQX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbQX_KeyUp);
            // 
            // ckbYE
            // 
            this.ckbYE.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbYE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbYE.CheckOnClick = true;
            this.ckbYE.ColumnWidth = 65;
            this.ckbYE.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbYE.Items.AddRange(new object[] {
            "����",
            "�ϰ���"});
            this.ckbYE.Location = new System.Drawing.Point(312, 416);
            this.ckbYE.MultiColumn = true;
            this.ckbYE.Name = "ckbYE";
            this.ckbYE.Size = new System.Drawing.Size(144, 16);
            this.ckbYE.TabIndex = 66;
            this.ckbYE.Tag = "2";
            this.ckbYE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbYE_MouseUp);
            this.ckbYE.SelectedIndexChanged += new System.EventHandler(this.ckbYE_SelectedIndexChanged);
            this.ckbYE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbYE_KeyUp);
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(280, 416);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(32, 16);
            this.label55.TabIndex = 142;
            this.label55.Text = "�Ҷ�";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbZE
            // 
            this.ckbZE.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZE.CheckOnClick = true;
            this.ckbZE.ColumnWidth = 65;
            this.ckbZE.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZE.Items.AddRange(new object[] {
            "����",
            "�ϰ���"});
            this.ckbZE.Location = new System.Drawing.Point(104, 416);
            this.ckbZE.MultiColumn = true;
            this.ckbZE.Name = "ckbZE";
            this.ckbZE.Size = new System.Drawing.Size(144, 16);
            this.ckbZE.TabIndex = 64;
            this.ckbZE.Tag = "2";
            this.ckbZE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbZE_MouseUp);
            this.ckbZE.SelectedIndexChanged += new System.EventHandler(this.ckbZE_SelectedIndexChanged);
            this.ckbZE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZE_KeyUp);
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(72, 416);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(32, 16);
            this.label64.TabIndex = 140;
            this.label64.Text = "���";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbYY
            // 
            this.ckbYY.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbYY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbYY.CheckOnClick = true;
            this.ckbYY.ColumnWidth = 65;
            this.ckbYY.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbYY.Items.AddRange(new object[] {
            "����",
            "�ϰ���"});
            this.ckbYY.Location = new System.Drawing.Point(312, 392);
            this.ckbYY.MultiColumn = true;
            this.ckbYY.Name = "ckbYY";
            this.ckbYY.Size = new System.Drawing.Size(144, 16);
            this.ckbYY.TabIndex = 62;
            this.ckbYY.Tag = "2";
            this.ckbYY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbYY_MouseUp);
            this.ckbYY.SelectedIndexChanged += new System.EventHandler(this.ckbYY_SelectedIndexChanged);
            this.ckbYY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbYY_KeyUp);
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(280, 392);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(32, 16);
            this.label63.TabIndex = 137;
            this.label63.Text = "����";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbƤ������������
            // 
            this.tbƤ������������.Enabled = false;
            this.tbƤ������������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbƤ������������.Location = new System.Drawing.Point(200, 368);
            this.tbƤ������������.Name = "tbƤ������������";
            this.tbƤ������������.Size = new System.Drawing.Size(134, 21);
            this.tbƤ������������.TabIndex = 58;
            // 
            // ckbPFWZX
            // 
            this.ckbPFWZX.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbPFWZX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbPFWZX.CheckOnClick = true;
            this.ckbPFWZX.ColumnWidth = 65;
            this.ckbPFWZX.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbPFWZX.Items.AddRange(new object[] {
            "����",
            "����",
            "",
            "",
            "ѹ����"});
            this.ckbPFWZX.Location = new System.Drawing.Point(80, 368);
            this.ckbPFWZX.MultiColumn = true;
            this.ckbPFWZX.Name = "ckbPFWZX";
            this.ckbPFWZX.Size = new System.Drawing.Size(408, 16);
            this.ckbPFWZX.TabIndex = 57;
            this.ckbPFWZX.Tag = "5";
            this.ckbPFWZX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbPFWZX_MouseUp);
            this.ckbPFWZX.SelectedIndexChanged += new System.EventHandler(this.ckbPFWZX_SelectedIndexChanged);
            this.ckbPFWZX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbPFWZX_KeyUp);
            // 
            // ckbSZ
            // 
            this.ckbSZ.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbSZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbSZ.CheckOnClick = true;
            this.ckbSZ.ColumnWidth = 100;
            this.ckbSZ.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbSZ.Items.AddRange(new object[] {
            "����",
            "��",
            "���",
            "����",
            "��ߡ�����",
            "����",
            "�ִ�",
            "��С",
            "������"});
            this.ckbSZ.Location = new System.Drawing.Point(72, 240);
            this.ckbSZ.MultiColumn = true;
            this.ckbSZ.Name = "ckbSZ";
            this.ckbSZ.Size = new System.Drawing.Size(408, 48);
            this.ckbSZ.TabIndex = 49;
            this.ckbSZ.Tag = "9";
            this.ckbSZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbST_MouseUp);
            this.ckbSZ.SelectedIndexChanged += new System.EventHandler(this.ckbST_SelectedIndexChanged);
            this.ckbSZ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbST_KeyUp);
            // 
            // ckbYSZT
            // 
            this.ckbYSZT.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbYSZT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbYSZT.CheckOnClick = true;
            this.ckbYSZT.ColumnWidth = 100;
            this.ckbYSZT.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbYSZT.Items.AddRange(new object[] {
            "����",
            "��˯",
            "��ʶģ��",
            "��˯",
            "ǳ����",
            "�����"});
            this.ckbYSZT.Location = new System.Drawing.Point(72, 158);
            this.ckbYSZT.MultiColumn = true;
            this.ckbYSZT.Name = "ckbYSZT";
            this.ckbYSZT.Size = new System.Drawing.Size(408, 32);
            this.ckbYSZT.TabIndex = 40;
            this.ckbYSZT.Tag = "6";
            this.ckbYSZT.SelectedIndexChanged += new System.EventHandler(this.ckbYSZT_SelectedIndexChanged);
            this.ckbYSZT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbYSZT_KeyUp);
            // 
            // ckbDGQK
            // 
            this.ckbDGQK.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbDGQK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbDGQK.CheckOnClick = true;
            this.ckbDGQK.ColumnWidth = 70;
            this.ckbDGQK.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbDGQK.Items.AddRange(new object[] {
            "��",
            "�У�"});
            this.ckbDGQK.Location = new System.Drawing.Point(72, 80);
            this.ckbDGQK.MultiColumn = true;
            this.ckbDGQK.Name = "ckbDGQK";
            this.ckbDGQK.Size = new System.Drawing.Size(256, 16);
            this.ckbDGQK.TabIndex = 34;
            this.ckbDGQK.Tag = "2";
            this.ckbDGQK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbDGQK_MouseUp);
            this.ckbDGQK.SelectedIndexChanged += new System.EventHandler(this.ckbDGQK_SelectedIndexChanged);
            this.ckbDGQK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbDGQK_KeyUp);
            // 
            // ckbZTHD_TH
            // 
            this.ckbZTHD_TH.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZTHD_TH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZTHD_TH.CheckOnClick = true;
            this.ckbZTHD_TH.ColumnWidth = 70;
            this.ckbZTHD_TH.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZTHD_TH.Items.AddRange(new object[] {
            "ƫ̱",
            "��̱",
            "��̱",
            "����̱"});
            this.ckbZTHD_TH.Location = new System.Drawing.Point(344, 40);
            this.ckbZTHD_TH.MultiColumn = true;
            this.ckbZTHD_TH.Name = "ckbZTHD_TH";
            this.ckbZTHD_TH.Size = new System.Drawing.Size(144, 32);
            this.ckbZTHD_TH.TabIndex = 33;
            this.ckbZTHD_TH.Tag = "5";
            this.ckbZTHD_TH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbZTHD_TH_MouseUp);
            this.ckbZTHD_TH.SelectedIndexChanged += new System.EventHandler(this.ckbZTHD_TH_SelectedIndexChanged);
            this.ckbZTHD_TH.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZTHD_TH_KeyUp);
            // 
            // tb֫���ϰ�
            // 
            this.tb֫���ϰ�.Enabled = false;
            this.tb֫���ϰ�.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb֫���ϰ�.Location = new System.Drawing.Point(200, 40);
            this.tb֫���ϰ�.Name = "tb֫���ϰ�";
            this.tb֫���ϰ�.Size = new System.Drawing.Size(80, 21);
            this.tb֫���ϰ�.TabIndex = 32;
            // 
            // ckbZTHD
            // 
            this.ckbZTHD.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZTHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZTHD.CheckOnClick = true;
            this.ckbZTHD.ColumnWidth = 70;
            this.ckbZTHD.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZTHD.Items.AddRange(new object[] {
            "����",
            "�ϰ���",
            "",
            "̱����"});
            this.ckbZTHD.Location = new System.Drawing.Point(72, 40);
            this.ckbZTHD.MultiColumn = true;
            this.ckbZTHD.Name = "ckbZTHD";
            this.ckbZTHD.Size = new System.Drawing.Size(408, 16);
            this.ckbZTHD.TabIndex = 31;
            this.ckbZTHD.Tag = "5";
            this.ckbZTHD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbZTHD_MouseUp);
            this.ckbZTHD.SelectedIndexChanged += new System.EventHandler(this.ckbZTHD_SelectedIndexChanged);
            this.ckbZTHD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZTHD_KeyUp);
            // 
            // ckbZLNL
            // 
            this.ckbZLNL.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZLNL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZLNL.CheckOnClick = true;
            this.ckbZLNL.ColumnWidth = 100;
            this.ckbZLNL.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZLNL.Items.AddRange(new object[] {
            "����",
            "��������",
            "��ȫ����"});
            this.ckbZLNL.Location = new System.Drawing.Point(72, 8);
            this.ckbZLNL.MultiColumn = true;
            this.ckbZLNL.Name = "ckbZLNL";
            this.ckbZLNL.Size = new System.Drawing.Size(408, 16);
            this.ckbZLNL.TabIndex = 30;
            this.ckbZLNL.Tag = "3";
            this.ckbZLNL.SelectedIndexChanged += new System.EventHandler(this.ckbZLNL_SelectedIndexChanged);
            this.ckbZLNL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZLNL_KeyUp);
            // 
            // dtp����ʱ��
            // 
            this.dtp����ʱ��.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp����ʱ��.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp����ʱ��.Location = new System.Drawing.Point(320, 544);
            this.dtp����ʱ��.Name = "dtp����ʱ��";
            this.dtp����ʱ��.ShowUpDown = true;
            this.dtp����ʱ��.Size = new System.Drawing.Size(160, 21);
            this.dtp����ʱ��.TabIndex = 72;
            this.dtp����ʱ��.Value = new System.DateTime(2004, 8, 22, 16, 39, 50, 93);
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(256, 552);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(72, 16);
            this.label71.TabIndex = 123;
            this.label71.Tag = "";
            this.label71.Text = "����ʱ�䣺";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb������ʿ
            // 
            this.lb������ʿ.BackColor = System.Drawing.SystemColors.Control;
            this.lb������ʿ.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb������ʿ.Location = new System.Drawing.Point(72, 544);
            this.lb������ʿ.Name = "lb������ʿ";
            this.lb������ʿ.Size = new System.Drawing.Size(128, 21);
            this.lb������ʿ.TabIndex = 1150;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(8, 552);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(72, 16);
            this.label70.TabIndex = 121;
            this.label70.Tag = "";
            this.label70.Text = "������ʿ��";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb��ע
            // 
            this.tb��ע.BackColor = System.Drawing.SystemColors.Window;
            this.tb��ע.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��ע.Location = new System.Drawing.Point(72, 520);
            this.tb��ע.Name = "tb��ע";
            this.tb��ע.Size = new System.Drawing.Size(408, 21);
            this.tb��ע.TabIndex = 72;
            // 
            // tbѪѹ
            // 
            this.tbѪѹ.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbѪѹ.Location = new System.Drawing.Point(104, 132);
            this.tbѪѹ.Name = "tbѪѹ";
            this.tbѪѹ.Size = new System.Drawing.Size(48, 21);
            this.tbѪѹ.TabIndex = 39;
            this.tbѪѹ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbѪѹ_KeyPress);
            // 
            // tb����
            // 
            this.tb����.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb����.Location = new System.Drawing.Point(384, 104);
            this.tb����.Name = "tb����";
            this.tb����.Size = new System.Drawing.Size(48, 21);
            this.tb����.TabIndex = 38;
            this.tb����.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb����_KeyUp);
            this.tb����.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb����_KeyPress);
            // 
            // tb����
            // 
            this.tb����.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb����.Location = new System.Drawing.Point(232, 104);
            this.tb����.Name = "tb����";
            this.tb����.Size = new System.Drawing.Size(48, 21);
            this.tb����.TabIndex = 37;
            this.tb����.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb����_KeyUp);
            this.tb����.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb����_KeyPress);
            // 
            // tb����
            // 
            this.tb����.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb����.Location = new System.Drawing.Point(104, 104);
            this.tb����.Name = "tb����";
            this.tb����.Size = new System.Drawing.Size(48, 21);
            this.tb����.TabIndex = 36;
            this.tb����.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb����_KeyUp);
            this.tb����.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb����_KeyPress);
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(8, 528);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(72, 16);
            this.label62.TabIndex = 112;
            this.label62.Tag = "";
            this.label62.Text = "��    ע��";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(8, 504);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(72, 16);
            this.label61.TabIndex = 110;
            this.label61.Tag = "";
            this.label61.Text = "����״̬��";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(8, 472);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(72, 16);
            this.label60.TabIndex = 108;
            this.label60.Tag = "";
            this.label60.Text = "ְҵ״̬��";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(8, 440);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(72, 16);
            this.label59.TabIndex = 106;
            this.label59.Tag = "";
            this.label59.Text = "��    ����";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(8, 368);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(80, 16);
            this.label52.TabIndex = 98;
            this.label52.Text = "Ƥ�������ԣ�";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(8, 192);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(72, 16);
            this.label51.TabIndex = 96;
            this.label51.Text = "��  ̦��";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(8, 158);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(72, 16);
            this.label50.TabIndex = 94;
            this.label50.Text = "��ʶ״̬��";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(152, 140);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(32, 16);
            this.label49.TabIndex = 93;
            this.label49.Text = "mmHg";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(72, 136);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(32, 16);
            this.label48.TabIndex = 92;
            this.label48.Text = "Ѫѹ";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(440, 108);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(48, 16);
            this.label46.TabIndex = 91;
            this.label46.Text = "��/min";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(352, 108);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(32, 16);
            this.label47.TabIndex = 90;
            this.label47.Text = "����";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(286, 108);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(48, 16);
            this.label45.TabIndex = 89;
            this.label45.Text = "��/min";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(198, 108);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(32, 16);
            this.label44.TabIndex = 88;
            this.label44.Text = "����";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(152, 108);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(16, 16);
            this.label43.TabIndex = 87;
            this.label43.Text = "��";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(72, 108);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(32, 16);
            this.label42.TabIndex = 86;
            this.label42.Text = "����";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(8, 108);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(72, 16);
            this.label41.TabIndex = 85;
            this.label41.Text = "����������";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(8, 80);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 16);
            this.label40.TabIndex = 83;
            this.label40.Text = "���������";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(8, 8);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(72, 16);
            this.label38.TabIndex = 79;
            this.label38.Text = "����������";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(8, 40);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(72, 16);
            this.label39.TabIndex = 82;
            this.label39.Text = "֫����";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(72, 392);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(32, 16);
            this.label54.TabIndex = 101;
            this.label54.Text = "����";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(8, 392);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(72, 16);
            this.label53.TabIndex = 100;
            this.label53.Text = "��    ����";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(8, 416);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(72, 16);
            this.label57.TabIndex = 146;
            this.label57.Text = "��    ����";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb��������
            // 
            this.tb��������.ForeColor = System.Drawing.Color.Blue;
            this.tb��������.Items.AddRange(new object[] {
            "����",
            "Զ��",
            "������",
            "�����"});
            this.tb��������.Location = new System.Drawing.Point(224, 392);
            this.tb��������.Name = "tb��������";
            this.tb��������.Size = new System.Drawing.Size(48, 20);
            this.tb��������.TabIndex = 161;
            // 
            // ckbZY
            // 
            this.ckbZY.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZY.CheckOnClick = true;
            this.ckbZY.ColumnWidth = 65;
            this.ckbZY.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZY.Items.AddRange(new object[] {
            "����",
            "�ϰ���"});
            this.ckbZY.Location = new System.Drawing.Point(104, 392);
            this.ckbZY.MultiColumn = true;
            this.ckbZY.Name = "ckbZY";
            this.ckbZY.Size = new System.Drawing.Size(144, 16);
            this.ckbZY.TabIndex = 60;
            this.ckbZY.Tag = "2";
            this.ckbZY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbZY_MouseUp);
            this.ckbZY.SelectedIndexChanged += new System.EventHandler(this.ckbZY_SelectedIndexChanged);
            this.ckbZY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZY_KeyUp);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lb�޸�ʱ��);
            this.panel4.Controls.Add(this.lb����ʱ��);
            this.panel4.Controls.Add(this.lb�޸���);
            this.panel4.Controls.Add(this.lb������);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.bt�˳�);
            this.panel4.Controls.Add(this.btUse);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(508, 600);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(508, 80);
            this.panel4.TabIndex = 3;
            // 
            // lb�޸�ʱ��
            // 
            this.lb�޸�ʱ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb�޸�ʱ��.Location = new System.Drawing.Point(100, 20);
            this.lb�޸�ʱ��.Name = "lb�޸�ʱ��";
            this.lb�޸�ʱ��.Size = new System.Drawing.Size(176, 12);
            this.lb�޸�ʱ��.TabIndex = 64;
            this.lb�޸�ʱ��.Text = "�޸�ʱ�䣺";
            // 
            // lb����ʱ��
            // 
            this.lb����ʱ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb����ʱ��.Location = new System.Drawing.Point(100, 8);
            this.lb����ʱ��.Name = "lb����ʱ��";
            this.lb����ʱ��.Size = new System.Drawing.Size(176, 12);
            this.lb����ʱ��.TabIndex = 63;
            this.lb����ʱ��.Text = "����ʱ�䣺";
            // 
            // lb�޸���
            // 
            this.lb�޸���.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb�޸���.Location = new System.Drawing.Point(4, 20);
            this.lb�޸���.Name = "lb�޸���";
            this.lb�޸���.Size = new System.Drawing.Size(92, 12);
            this.lb�޸���.TabIndex = 61;
            this.lb�޸���.Text = "�޸��ˣ�";
            // 
            // lb������
            // 
            this.lb������.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb������.Location = new System.Drawing.Point(4, 8);
            this.lb������.Name = "lb������";
            this.lb������.Size = new System.Drawing.Size(92, 12);
            this.lb������.TabIndex = 60;
            this.lb������.Text = "�����ˣ�";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ContextMenu = this.contextMenu1;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.ImageIndex = 0;
            this.button1.Location = new System.Drawing.Point(356, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 24);
            this.button1.TabIndex = 75;
            this.button1.Text = "��ӡ(&P)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "��ǰҳ";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "�հ�ҳ";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // bt�˳�
            // 
            this.bt�˳�.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt�˳�.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt�˳�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�˳�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�˳�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�˳�.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt�˳�.ImageIndex = 0;
            this.bt�˳�.Location = new System.Drawing.Point(420, 8);
            this.bt�˳�.Name = "bt�˳�";
            this.bt�˳�.Size = new System.Drawing.Size(60, 24);
            this.bt�˳�.TabIndex = 77;
            this.bt�˳�.Text = "�˳�(&E)";
            this.bt�˳�.UseVisualStyleBackColor = false;
            this.bt�˳�.Click += new System.EventHandler(this.bt�˳�_Click);
            // 
            // btUse
            // 
            this.btUse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUse.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUse.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btUse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btUse.ImageIndex = 0;
            this.btUse.Location = new System.Drawing.Point(292, 8);
            this.btUse.Name = "btUse";
            this.btUse.Size = new System.Drawing.Size(60, 24);
            this.btUse.TabIndex = 73;
            this.btUse.Text = "����(&S)";
            this.btUse.UseVisualStyleBackColor = false;
            this.btUse.Click += new System.EventHandler(this.btUse_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(288, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 33);
            this.button3.TabIndex = 56;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.ImageIndex = 0;
            this.button2.Location = new System.Drawing.Point(0, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(284, 32);
            this.button2.TabIndex = 62;
            this.button2.Text = "z";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(504, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 680);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dg1);
            this.panel2.Controls.Add(this.tb��������);
            this.panel2.Controls.Add(this.ckbHYZT);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.lb��Ժ���);
            this.panel2.Controls.Add(this.tb����ʳ��);
            this.panel2.Controls.Add(this.tb����ҩ��);
            this.panel2.Controls.Add(this.mz);
            this.panel2.Controls.Add(this.jg);
            this.panel2.Controls.Add(this.zy);
            this.panel2.Controls.Add(this.ckbXB);
            this.panel2.Controls.Add(this.tb�������);
            this.panel2.Controls.Add(this.ckbDB);
            this.panel2.Controls.Add(this.tb˯������);
            this.panel2.Controls.Add(this.ckbSM);
            this.panel2.Controls.Add(this.tb��ʳ�Ⱥ�);
            this.panel2.Controls.Add(this.tb��ʳ�쳣);
            this.panel2.Controls.Add(this.ckbYS);
            this.panel2.Controls.Add(this.tb��������);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.ckbGMS);
            this.panel2.Controls.Add(this.tb������ʷ);
            this.panel2.Controls.Add(this.ckbJWBS);
            this.panel2.Controls.Add(this.tb��������);
            this.panel2.Controls.Add(this.ckbPS);
            this.panel2.Controls.Add(this.tb��Ժ��ʽ����);
            this.panel2.Controls.Add(this.ckbRYFS);
            this.panel2.Controls.Add(this.clbWHCD);
            this.panel2.Controls.Add(this.lb�½�);
            this.panel2.Controls.Add(this.lbҽ�Ʒ���);
            this.panel2.Controls.Add(this.lb�Ա�);
            this.panel2.Controls.Add(this.lb����);
            this.panel2.Controls.Add(this.tb��ҽ);
            this.panel2.Controls.Add(this.tb��ϵ�绰);
            this.panel2.Controls.Add(this.tb�뻼�߹�ϵ);
            this.panel2.Controls.Add(this.tb��ϵ��);
            this.panel2.Controls.Add(this.tb��ͥ��ַ);
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.dtp֪ͨҽʦʱ��);
            this.panel2.Controls.Add(this.dtp��Ժʱ��);
            this.panel2.Controls.Add(this.lbסԺ������);
            this.panel2.Controls.Add(this.lb����);
            this.panel2.Controls.Add(this.lb����);
            this.panel2.Controls.Add(this.lb����);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.lb1);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 680);
            this.panel2.TabIndex = 0;
            this.panel2.Tag = "2";
            // 
            // dg1
            // 
            this.dg1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dg1.CaptionBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dg1.CaptionVisible = false;
            this.dg1.DataMember = "";
            this.dg1.GridLineColor = System.Drawing.SystemColors.HotTrack;
            this.dg1.HeaderBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dg1.Location = new System.Drawing.Point(200, 128);
            this.dg1.Name = "dg1";
            this.dg1.Size = new System.Drawing.Size(304, 136);
            this.dg1.TabIndex = 158;
            // 
            // tb��������
            // 
            this.tb��������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��������.Location = new System.Drawing.Point(368, 352);
            this.tb��������.Name = "tb��������";
            this.tb��������.Size = new System.Drawing.Size(120, 21);
            this.tb��������.TabIndex = 15;
            // 
            // ckbHYZT
            // 
            this.ckbHYZT.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbHYZT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbHYZT.CheckOnClick = true;
            this.ckbHYZT.ColumnWidth = 50;
            this.ckbHYZT.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbHYZT.Items.AddRange(new object[] {
            "δ��",
            "�ѻ�",
            "���",
            "�ٻ�",
            "ɥż"});
            this.ckbHYZT.Location = new System.Drawing.Point(72, 152);
            this.ckbHYZT.MultiColumn = true;
            this.ckbHYZT.Name = "ckbHYZT";
            this.ckbHYZT.Size = new System.Drawing.Size(408, 16);
            this.ckbHYZT.TabIndex = 4;
            this.ckbHYZT.Tag = "5";
            this.ckbHYZT.SelectedIndexChanged += new System.EventHandler(this.ckbHYZT_SelectedIndexChanged);
            this.ckbHYZT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbHYZT_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.txtInpatNo);
            this.groupBox2.Controls.Add(this.btnSeek);
            this.groupBox2.Location = new System.Drawing.Point(384, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(112, 88);
            this.groupBox2.TabIndex = 162;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "סԺ�Ų�ѯ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox1.Location = new System.Drawing.Point(8, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 20);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // txtInpatNo
            // 
            this.txtInpatNo.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInpatNo.Location = new System.Drawing.Point(8, 13);
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
            this.btnSeek.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeek.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSeek.Location = new System.Drawing.Point(8, 58);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(96, 24);
            this.btnSeek.TabIndex = 56;
            this.btnSeek.Text = "��ѯ";
            this.btnSeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // lb��Ժ���
            // 
            this.lb��Ժ���.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb��Ժ���.Location = new System.Drawing.Point(72, 376);
            this.lb��Ժ���.Name = "lb��Ժ���";
            this.lb��Ժ���.Size = new System.Drawing.Size(416, 21);
            this.lb��Ժ���.TabIndex = 161;
            // 
            // tb����ʳ��
            // 
            this.tb����ʳ��.Enabled = false;
            this.tb����ʳ��.ForeColor = System.Drawing.Color.Blue;
            this.tb����ʳ��.Items.AddRange(new object[] {
            "Ϻ��",
            "����"});
            this.tb����ʳ��.Location = new System.Drawing.Point(352, 448);
            this.tb����ʳ��.Name = "tb����ʳ��";
            this.tb����ʳ��.Size = new System.Drawing.Size(48, 20);
            this.tb����ʳ��.TabIndex = 160;
            this.tb����ʳ��.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb����ʳ��_KeyUp);
            // 
            // tb����ҩ��
            // 
            this.tb����ҩ��.Enabled = false;
            this.tb����ҩ��.ForeColor = System.Drawing.Color.Blue;
            this.tb����ҩ��.Items.AddRange(new object[] {
            "��ù��",
            "�ǰ�ҩ"});
            this.tb����ҩ��.Location = new System.Drawing.Point(232, 448);
            this.tb����ҩ��.Name = "tb����ҩ��";
            this.tb����ҩ��.Size = new System.Drawing.Size(64, 20);
            this.tb����ҩ��.TabIndex = 159;
            this.tb����ҩ��.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb����ҩ��_KeyUp);
            // 
            // mz
            // 
            this.mz.Location = new System.Drawing.Point(315, 104);
            this.mz.Name = "mz";
            this.mz.Size = new System.Drawing.Size(61, 21);
            this.mz.TabIndex = 1;
            this.mz.Text = "����";
            this.mz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mz_KeyUp);
            this.mz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mz_KeyPress);
            // 
            // jg
            // 
            this.jg.BackColor = System.Drawing.SystemColors.HighlightText;
            this.jg.Location = new System.Drawing.Point(413, 104);
            this.jg.Name = "jg";
            this.jg.Size = new System.Drawing.Size(83, 21);
            this.jg.TabIndex = 2;
            this.jg.Text = "����ʡ��ɳ��";
            this.jg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.jg_KeyUp);
            this.jg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.jg_KeyPress);
            // 
            // zy
            // 
            this.zy.Location = new System.Drawing.Point(208, 104);
            this.zy.Name = "zy";
            this.zy.Size = new System.Drawing.Size(72, 21);
            this.zy.TabIndex = 0;
            this.zy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.zy_KeyUp);
            this.zy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zy_KeyPress);
            // 
            // ckbXB
            // 
            this.ckbXB.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbXB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbXB.CheckOnClick = true;
            this.ckbXB.ColumnWidth = 100;
            this.ckbXB.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbXB.Items.AddRange(new object[] {
            "����",
            "�峤",
            "�̳�",
            "����",
            "��Ѫ",
            "ʧ��",
            "����",
            "���",
            "���õ����",
            "����"});
            this.ckbXB.Location = new System.Drawing.Point(72, 584);
            this.ckbXB.MultiColumn = true;
            this.ckbXB.Name = "ckbXB";
            this.ckbXB.Size = new System.Drawing.Size(416, 48);
            this.ckbXB.TabIndex = 29;
            this.ckbXB.Tag = "9";
            this.ckbXB.SelectedIndexChanged += new System.EventHandler(this.ckbXB_SelectedIndexChanged);
            this.ckbXB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbXB_KeyUp);
            // 
            // tb�������
            // 
            this.tb�������.Enabled = false;
            this.tb�������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb�������.Location = new System.Drawing.Point(192, 560);
            this.tb�������.Name = "tb�������";
            this.tb�������.Size = new System.Drawing.Size(296, 21);
            this.tb�������.TabIndex = 28;
            // 
            // ckbDB
            // 
            this.ckbDB.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbDB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbDB.CheckOnClick = true;
            this.ckbDB.ColumnWidth = 65;
            this.ckbDB.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbDB.Items.AddRange(new object[] {
            "����",
            "�籡",
            "�ؽ�",
            "���ͱ�",
            "ʧ��",
            "��ڣ�",
            "����"});
            this.ckbDB.Location = new System.Drawing.Point(72, 536);
            this.ckbDB.MultiColumn = true;
            this.ckbDB.Name = "ckbDB";
            this.ckbDB.Size = new System.Drawing.Size(264, 48);
            this.ckbDB.TabIndex = 27;
            this.ckbDB.Tag = "6";
            this.ckbDB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbDB_MouseUp);
            this.ckbDB.SelectedIndexChanged += new System.EventHandler(this.ckbDB_SelectedIndexChanged);
            this.ckbDB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbDB_KeyUp);
            // 
            // tb˯������
            // 
            this.tb˯������.Enabled = false;
            this.tb˯������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb˯������.Location = new System.Drawing.Point(296, 496);
            this.tb˯������.Name = "tb˯������";
            this.tb˯������.Size = new System.Drawing.Size(192, 21);
            this.tb˯������.TabIndex = 26;
            // 
            // ckbSM
            // 
            this.ckbSM.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbSM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbSM.CheckOnClick = true;
            this.ckbSM.ColumnWidth = 85;
            this.ckbSM.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbSM.Items.AddRange(new object[] {
            "ҹ�°�",
            "ҹ������",
            "ҹ�η��",
            "����",
            "ҩ�"});
            this.ckbSM.Location = new System.Drawing.Point(72, 496);
            this.ckbSM.MultiColumn = true;
            this.ckbSM.Name = "ckbSM";
            this.ckbSM.Size = new System.Drawing.Size(408, 32);
            this.ckbSM.TabIndex = 25;
            this.ckbSM.Tag = "5";
            this.ckbSM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbSM_MouseUp);
            this.ckbSM.SelectedIndexChanged += new System.EventHandler(this.ckbSM_SelectedIndexChanged);
            this.ckbSM.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbSM_KeyUp);
            // 
            // tb��ʳ�Ⱥ�
            // 
            this.tb��ʳ�Ⱥ�.Enabled = false;
            this.tb��ʳ�Ⱥ�.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��ʳ�Ⱥ�.Location = new System.Drawing.Point(368, 472);
            this.tb��ʳ�Ⱥ�.Name = "tb��ʳ�Ⱥ�";
            this.tb��ʳ�Ⱥ�.Size = new System.Drawing.Size(120, 21);
            this.tb��ʳ�Ⱥ�.TabIndex = 24;
            // 
            // tb��ʳ�쳣
            // 
            this.tb��ʳ�쳣.Enabled = false;
            this.tb��ʳ�쳣.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��ʳ�쳣.Location = new System.Drawing.Point(184, 472);
            this.tb��ʳ�쳣.Name = "tb��ʳ�쳣";
            this.tb��ʳ�쳣.Size = new System.Drawing.Size(128, 21);
            this.tb��ʳ�쳣.TabIndex = 23;
            this.tb��ʳ�쳣.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb��ʳ�쳣_KeyUp);
            // 
            // ckbYS
            // 
            this.ckbYS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbYS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbYS.CheckOnClick = true;
            this.ckbYS.ColumnWidth = 60;
            this.ckbYS.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbYS.Items.AddRange(new object[] {
            "����",
            "�쳣��",
            "",
            "",
            "�Ⱥã�"});
            this.ckbYS.Location = new System.Drawing.Point(72, 472);
            this.ckbYS.MultiColumn = true;
            this.ckbYS.Name = "ckbYS";
            this.ckbYS.Size = new System.Drawing.Size(408, 16);
            this.ckbYS.TabIndex = 22;
            this.ckbYS.Tag = "5";
            this.ckbYS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbYS_MouseUp);
            this.ckbYS.SelectedIndexChanged += new System.EventHandler(this.ckbYS_SelectedIndexChanged);
            this.ckbYS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbYS_KeyUp);
            // 
            // tb��������
            // 
            this.tb��������.Enabled = false;
            this.tb��������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��������.Location = new System.Drawing.Point(432, 448);
            this.tb��������.Name = "tb��������";
            this.tb��������.Size = new System.Drawing.Size(56, 21);
            this.tb��������.TabIndex = 21;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(400, 448);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 16);
            this.label33.TabIndex = 154;
            this.label33.Text = "������";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(296, 448);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 16);
            this.label32.TabIndex = 153;
            this.label32.Text = "����ʳ�";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(176, 448);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 16);
            this.label31.TabIndex = 152;
            this.label31.Text = "����ҩ�";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbGMS
            // 
            this.ckbGMS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbGMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbGMS.CheckOnClick = true;
            this.ckbGMS.ColumnWidth = 60;
            this.ckbGMS.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbGMS.Items.AddRange(new object[] {
            "��",
            "��"});
            this.ckbGMS.Location = new System.Drawing.Point(72, 448);
            this.ckbGMS.MultiColumn = true;
            this.ckbGMS.Name = "ckbGMS";
            this.ckbGMS.Size = new System.Drawing.Size(432, 16);
            this.ckbGMS.TabIndex = 18;
            this.ckbGMS.Tag = "2";
            this.ckbGMS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbGMS_MouseUp);
            this.ckbGMS.SelectedIndexChanged += new System.EventHandler(this.ckbGMS_SelectedIndexChanged);
            this.ckbGMS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbGMS_KeyUp);
            // 
            // tb������ʷ
            // 
            this.tb������ʷ.Enabled = false;
            this.tb������ʷ.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb������ʷ.Location = new System.Drawing.Point(176, 424);
            this.tb������ʷ.Name = "tb������ʷ";
            this.tb������ʷ.Size = new System.Drawing.Size(312, 21);
            this.tb������ʷ.TabIndex = 17;
            // 
            // ckbJWBS
            // 
            this.ckbJWBS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbJWBS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbJWBS.CheckOnClick = true;
            this.ckbJWBS.ColumnWidth = 60;
            this.ckbJWBS.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbJWBS.Items.AddRange(new object[] {
            "��",
            "�У�"});
            this.ckbJWBS.Location = new System.Drawing.Point(72, 424);
            this.ckbJWBS.MultiColumn = true;
            this.ckbJWBS.Name = "ckbJWBS";
            this.ckbJWBS.Size = new System.Drawing.Size(416, 16);
            this.ckbJWBS.TabIndex = 16;
            this.ckbJWBS.Tag = "2";
            this.ckbJWBS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbJWBS_MouseUp);
            this.ckbJWBS.SelectedIndexChanged += new System.EventHandler(this.ckbJWBS_SelectedIndexChanged);
            this.ckbJWBS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbJWBS_KeyUp);
            // 
            // tb��������
            // 
            this.tb��������.Enabled = false;
            this.tb��������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��������.Location = new System.Drawing.Point(256, 328);
            this.tb��������.Name = "tb��������";
            this.tb��������.Size = new System.Drawing.Size(232, 21);
            this.tb��������.TabIndex = 13;
            // 
            // ckbPS
            // 
            this.ckbPS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbPS.CheckOnClick = true;
            this.ckbPS.ColumnWidth = 60;
            this.ckbPS.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbPS.Items.AddRange(new object[] {
            "����",
            "����",
            "������"});
            this.ckbPS.Location = new System.Drawing.Point(72, 328);
            this.ckbPS.MultiColumn = true;
            this.ckbPS.Name = "ckbPS";
            this.ckbPS.Size = new System.Drawing.Size(424, 16);
            this.ckbPS.TabIndex = 12;
            this.ckbPS.Tag = "3";
            this.ckbPS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbPS_MouseUp);
            this.ckbPS.SelectedIndexChanged += new System.EventHandler(this.ckbPS_SelectedIndexChanged);
            this.ckbPS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbPS_KeyUp);
            // 
            // tb��Ժ��ʽ����
            // 
            this.tb��Ժ��ʽ����.Enabled = false;
            this.tb��Ժ��ʽ����.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��Ժ��ʽ����.Location = new System.Drawing.Point(368, 296);
            this.tb��Ժ��ʽ����.Name = "tb��Ժ��ʽ����";
            this.tb��Ժ��ʽ����.Size = new System.Drawing.Size(120, 21);
            this.tb��Ժ��ʽ����.TabIndex = 11;
            // 
            // ckbRYFS
            // 
            this.ckbRYFS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbRYFS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbRYFS.CheckOnClick = true;
            this.ckbRYFS.ColumnWidth = 60;
            this.ckbRYFS.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbRYFS.Items.AddRange(new object[] {
            "����",
            "����",
            "����",
            "ƽ��",
            "������"});
            this.ckbRYFS.Location = new System.Drawing.Point(72, 304);
            this.ckbRYFS.MultiColumn = true;
            this.ckbRYFS.Name = "ckbRYFS";
            this.ckbRYFS.Size = new System.Drawing.Size(416, 16);
            this.ckbRYFS.TabIndex = 10;
            this.ckbRYFS.Tag = "5";
            this.ckbRYFS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbRYFS_MouseUp);
            this.ckbRYFS.SelectedIndexChanged += new System.EventHandler(this.ckbRYFS_SelectedIndexChanged);
            this.ckbRYFS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbRYFS_KeyUp);
            // 
            // clbWHCD
            // 
            this.clbWHCD.BackColor = System.Drawing.SystemColors.Menu;
            this.clbWHCD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbWHCD.CheckOnClick = true;
            this.clbWHCD.ColumnWidth = 50;
            this.clbWHCD.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clbWHCD.Items.AddRange(new object[] {
            "��ä",
            "Сѧ",
            "����",
            "����",
            "��ר",
            "��ר",
            "��ѧ����",
            "ѧǰ��ͯ"});
            this.clbWHCD.Location = new System.Drawing.Point(72, 128);
            this.clbWHCD.MultiColumn = true;
            this.clbWHCD.Name = "clbWHCD";
            this.clbWHCD.Size = new System.Drawing.Size(480, 16);
            this.clbWHCD.TabIndex = 3;
            this.clbWHCD.Tag = "6";
            this.clbWHCD.SelectedIndexChanged += new System.EventHandler(this.clbWHCD_SelectedIndexChanged);
            this.clbWHCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.clbWHCD_KeyUp);
            // 
            // lb�½�
            // 
            this.lb�½�.Font = new System.Drawing.Font("����_GB2312", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb�½�.ForeColor = System.Drawing.Color.Red;
            this.lb�½�.Location = new System.Drawing.Point(8, 8);
            this.lb�½�.Name = "lb�½�";
            this.lb�½�.Size = new System.Drawing.Size(48, 24);
            this.lb�½�.TabIndex = 135;
            this.lb�½�.Text = "�½�";
            this.lb�½�.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbҽ�Ʒ���
            // 
            this.lbҽ�Ʒ���.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbҽ�Ʒ���.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbҽ�Ʒ���.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbҽ�Ʒ���.Location = new System.Drawing.Point(72, 176);
            this.lbҽ�Ʒ���.Name = "lbҽ�Ʒ���";
            this.lbҽ�Ʒ���.Size = new System.Drawing.Size(416, 21);
            this.lbҽ�Ʒ���.TabIndex = 133;
            this.lbҽ�Ʒ���.Text = "����";
            this.lbҽ�Ʒ���.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lb�Ա�
            // 
            this.lb�Ա�.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb�Ա�.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb�Ա�.Location = new System.Drawing.Point(72, 104);
            this.lb�Ա�.Name = "lb�Ա�";
            this.lb�Ա�.Size = new System.Drawing.Size(16, 21);
            this.lb�Ա�.TabIndex = 132;
            this.lb�Ա�.Text = "����";
            this.lb�Ա�.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lb����
            // 
            this.lb����.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb����.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb����.Location = new System.Drawing.Point(120, 104);
            this.lb����.Name = "lb����";
            this.lb����.Size = new System.Drawing.Size(56, 21);
            this.lb����.TabIndex = 131;
            this.lb����.Text = "����";
            this.lb����.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tb��ҽ
            // 
            this.tb��ҽ.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��ҽ.Location = new System.Drawing.Point(184, 352);
            this.tb��ҽ.Name = "tb��ҽ";
            this.tb��ҽ.Size = new System.Drawing.Size(120, 21);
            this.tb��ҽ.TabIndex = 14;
            // 
            // tb��ϵ�绰
            // 
            this.tb��ϵ�绰.BackColor = System.Drawing.SystemColors.Window;
            this.tb��ϵ�绰.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��ϵ�绰.Location = new System.Drawing.Point(352, 240);
            this.tb��ϵ�绰.Name = "tb��ϵ�绰";
            this.tb��ϵ�绰.Size = new System.Drawing.Size(136, 21);
            this.tb��ϵ�绰.TabIndex = 8;
            // 
            // tb�뻼�߹�ϵ
            // 
            this.tb�뻼�߹�ϵ.BackColor = System.Drawing.SystemColors.Window;
            this.tb�뻼�߹�ϵ.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb�뻼�߹�ϵ.Location = new System.Drawing.Point(216, 240);
            this.tb�뻼�߹�ϵ.Name = "tb�뻼�߹�ϵ";
            this.tb�뻼�߹�ϵ.Size = new System.Drawing.Size(64, 21);
            this.tb�뻼�߹�ϵ.TabIndex = 7;
            // 
            // tb��ϵ��
            // 
            this.tb��ϵ��.BackColor = System.Drawing.SystemColors.Window;
            this.tb��ϵ��.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��ϵ��.Location = new System.Drawing.Point(72, 240);
            this.tb��ϵ��.Name = "tb��ϵ��";
            this.tb��ϵ��.Size = new System.Drawing.Size(64, 21);
            this.tb��ϵ��.TabIndex = 6;
            // 
            // tb��ͥ��ַ
            // 
            this.tb��ͥ��ַ.BackColor = System.Drawing.SystemColors.Window;
            this.tb��ͥ��ַ.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb��ͥ��ַ.Location = new System.Drawing.Point(72, 208);
            this.tb��ͥ��ַ.Name = "tb��ͥ��ַ";
            this.tb��ͥ��ַ.Size = new System.Drawing.Size(416, 21);
            this.tb��ͥ��ַ.TabIndex = 5;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(8, 584);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(72, 16);
            this.label37.TabIndex = 91;
            this.label37.Text = "С    �㣺";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(8, 544);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 16);
            this.label36.TabIndex = 89;
            this.label36.Text = "��    �㣺";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(72, 352);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(120, 16);
            this.label25.TabIndex = 63;
            this.label25.Text = "��ҽ��������֤�ͣ�";
            // 
            // dtp֪ͨҽʦʱ��
            // 
            this.dtp֪ͨҽʦʱ��.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp֪ͨҽʦʱ��.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp֪ͨҽʦʱ��.Location = new System.Drawing.Point(344, 272);
            this.dtp֪ͨҽʦʱ��.Name = "dtp֪ͨҽʦʱ��";
            this.dtp֪ͨҽʦʱ��.ShowUpDown = true;
            this.dtp֪ͨҽʦʱ��.Size = new System.Drawing.Size(144, 21);
            this.dtp֪ͨҽʦʱ��.TabIndex = 9;
            // 
            // dtp��Ժʱ��
            // 
            this.dtp��Ժʱ��.CalendarForeColor = System.Drawing.SystemColors.HotTrack;
            this.dtp��Ժʱ��.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.dtp��Ժʱ��.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp��Ժʱ��.Enabled = false;
            this.dtp��Ժʱ��.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp��Ժʱ��.Location = new System.Drawing.Point(72, 272);
            this.dtp��Ժʱ��.Name = "dtp��Ժʱ��";
            this.dtp��Ժʱ��.Size = new System.Drawing.Size(160, 21);
            this.dtp��Ժʱ��.TabIndex = 86;
            // 
            // lbסԺ������
            // 
            this.lbסԺ������.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbסԺ������.Location = new System.Drawing.Point(87, 32);
            this.lbסԺ������.Name = "lbסԺ������";
            this.lbסԺ������.Size = new System.Drawing.Size(64, 16);
            this.lbסԺ������.TabIndex = 78;
            this.lbסԺ������.Text = "����";
            // 
            // lb����
            // 
            this.lb����.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb����.Location = new System.Drawing.Point(296, 56);
            this.lb����.Name = "lb����";
            this.lb����.Size = new System.Drawing.Size(48, 16);
            this.lb����.TabIndex = 77;
            this.lb����.Text = "����";
            // 
            // lb����
            // 
            this.lb����.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb����.Location = new System.Drawing.Point(152, 56);
            this.lb����.Name = "lb����";
            this.lb����.Size = new System.Drawing.Size(104, 16);
            this.lb����.TabIndex = 76;
            this.lb����.Text = "����";
            // 
            // lb����
            // 
            this.lb����.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb����.Location = new System.Drawing.Point(40, 56);
            this.lb����.Name = "lb����";
            this.lb����.Size = new System.Drawing.Size(72, 16);
            this.lb����.TabIndex = 75;
            this.lb����.Text = "����";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(8, 496);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 16);
            this.label35.TabIndex = 73;
            this.label35.Text = "˯    �ߣ�";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(8, 472);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 16);
            this.label34.TabIndex = 71;
            this.label34.Text = "��    ʳ��";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(8, 448);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 16);
            this.label30.TabIndex = 69;
            this.label30.Text = "�� �� ʷ��";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(8, 424);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 16);
            this.label29.TabIndex = 67;
            this.label29.Text = "������ʷ��";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(16, 400);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 16);
            this.label28.TabIndex = 66;
            this.label28.Text = "������������";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(8, 376);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 16);
            this.label27.TabIndex = 65;
            this.label27.Text = "��ҽ��ϣ�";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(288, 248);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 16);
            this.label19.TabIndex = 55;
            this.label19.Text = "��ϵ�绰��";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(88, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "���䣺";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "סԺ������";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(264, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "����";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(120, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "����";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 52;
            this.label16.Text = "��ͥ��ַ��";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 352);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 16);
            this.label24.TabIndex = 62;
            this.label24.Text = "��Ժ��ϣ�";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 280);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 16);
            this.label20.TabIndex = 56;
            this.label20.Text = "��Ժʱ�䣺";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 304);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 16);
            this.label22.TabIndex = 58;
            this.label22.Text = "��Ժ��ʽ��";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(376, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 45;
            this.label12.Text = "���᣺";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(32, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 39;
            this.label7.Text = "һ��һ������";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(232, 280);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 16);
            this.label21.TabIndex = 57;
            this.label21.Text = "֪ͨҽʦʱ��ʱ�䣺";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(144, 248);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 54;
            this.label18.Text = "�뻼�߹�ϵ��";
            // 
            // lb1
            // 
            this.lb1.Location = new System.Drawing.Point(8, 184);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(72, 16);
            this.lb1.TabIndex = 50;
            this.lb1.Text = "ҽ�Ʒ��ã�";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 328);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 16);
            this.label23.TabIndex = 60;
            this.label23.Text = "��    �ͣ�";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 248);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 16);
            this.label17.TabIndex = 53;
            this.label17.Text = "�� ϵ �ˣ�";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(312, 352);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 64;
            this.label26.Text = "��������";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 48;
            this.label14.Text = "����״̬��";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 46;
            this.label13.Text = "�Ļ��̶ȣ�";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(282, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 44;
            this.label11.Text = "���壺";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(176, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 43;
            this.label10.Text = "ְҵ��";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "��    ��";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "����";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(152, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "��Ժ���߻�������";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 24);
            this.label1.TabIndex = 33;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRYPG
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1016, 637);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmRYPG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "��Ժ���߻���������";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHLPG_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmHLPG_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmHLPG_Load(object sender, System.EventArgs e)
        {
            label1.Text = (new SystemCfg(0002)).Config;

            if (Convert.ToInt32(ClassStatic.Current_BabyID) != 0)
            {
                MessageBox.Show(this, "�Բ��𣬳���Ӥ��û����Ժ���߻���������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            string sSql = "SELECT A.NAME,A.IN_DEPT_NAME,A.BED_NO,A.INPATIENT_NO,A.SEX_NAME," +
                //"case when A.AGE>0 then ltrim(rtrim(convert(varchar,A.AGE)))+'��' else ltrim(rtrim(char((days(CURRENT DATE) - days(A.BIRTHDAY))/30)))||'����' end as AGE,"+
                //ʹ���µ�������㺯��
                " dbo.FUN_ZY_AGE(A.BIRTHDAY,0,getdate()) AGE, " +
                " A.JSFS_NAME,A.IN_DATE,A.IN_DIAGNOSIS,A.ryzd,C.HOME_STREET,C.RELATION_NAME,C.RELATION,C.RELATION_TEL,B.* " +
                "  from vi_zy_vInpatient_All A LEFT JOIN ZY_ZYRYPG B ON A.INPATIENT_ID=B.INPATIENT_ID AND A.Baby_ID=B.Baby_ID," +
                "       vi_zy_vInpatient C" +
                " where A.INPATIENT_ID='" + ClassStatic.Current_BinID + "' and A.Baby_ID=0" +
                "       AND C.INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
            DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
            if (tempTab == null || tempTab.Rows.Count == 0)
            {
                MessageBox.Show("δ�ҵ�������Ϣ��������ѡ���ˣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btUse.Enabled = false;
                return;
            }

            btUse.Enabled = true;

            this.lb����.Text = tempTab.Rows[0]["NAME"].ToString().Trim();
            this.lb����.Text = tempTab.Rows[0]["IN_DEPT_NAME"].ToString().Trim();
            this.lb����.Text = tempTab.Rows[0]["BED_NO"].ToString().Trim();
            this.lbסԺ������.Text = tempTab.Rows[0]["INPATIENT_NO"].ToString().Trim();
            this.lb�Ա�.Text = tempTab.Rows[0]["SEX_NAME"].ToString().Trim();
            this.lb����.Text = tempTab.Rows[0]["AGE"].ToString().Trim();
            this.lbҽ�Ʒ���.Text = tempTab.Rows[0]["JSFS_NAME"].ToString().Trim();
            this.lb��Ժ���.Text = tempTab.Rows[0]["ryzd"].ToString().Trim();//Modify By tany 2011-04-20

            this.dtp��Ժʱ��.Text = tempTab.Rows[0]["IN_DATE"].ToString().Trim();
            this.tb��ͥ��ַ.Text = tempTab.Rows[0]["HOME_STREET"].ToString().Trim();
            this.tb��ϵ��.Text = tempTab.Rows[0]["RELATION_NAME"].ToString().Trim();
            this.tb�뻼�߹�ϵ.Text = tempTab.Rows[0]["RELATION"].ToString().Trim();

            this.tb��ϵ�绰.Text = tempTab.Rows[0]["RELATION_TEL"].ToString().Trim();

            if (tempTab.Rows[0]["BOOK"].ToString() == "")
            {
                this.lb�½�.Visible = true;
                this.lb������ʿ.Text = InstanceForm.BCurrentUser.Name;
                this.dtp����ʱ��.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                this.dg1.Visible = false;
                //��ʼ��ѡ��
                this.clbWHCD.SetItemChecked(0, true);
                this.ckbHYZT.SetItemChecked(0, true);
                this.ckbRYFS.SetItemChecked(0, true);
                this.ckbPS.SetItemChecked(0, true);
                this.ckbJWBS.SetItemChecked(0, true);
                this.ckbGMS.SetItemChecked(0, true);
                this.ckbYS.SetItemChecked(0, true);
                this.ckbSM.SetItemChecked(0, true);
                this.ckbDB.SetItemChecked(0, true);
                this.ckbXB.SetItemChecked(0, true);
                this.ckbZLNL.SetItemChecked(0, true);
                this.ckbZTHD.SetItemChecked(0, true);
                this.ckbDGQK.SetItemChecked(0, true);
                this.ckbYSZT.SetItemChecked(0, true);
                this.ckbST.SetItemChecked(0, true);
                this.ckbSZ.SetItemChecked(0, true);
                this.ckbmx.SetItemChecked(0, true);
                this.ckbPFWZX.SetItemChecked(0, true);
                this.ckbZY.SetItemChecked(0, true);
                this.ckbYY.SetItemChecked(0, true);
                this.ckbZE.SetItemChecked(0, true);
                this.ckbYE.SetItemChecked(0, true);
                this.ckbQX.SetItemChecked(0, true);
                this.ckbZYZT.SetItemChecked(0, true);
                this.ckbJSZT.SetItemChecked(0, true);
            }
            else
            {
                #region ����Ժ������
                this.lb�½�.Visible = false;
                this.zy.Text = tempTab.Rows[0]["occupati"].ToString().Trim();
                this.mz.Text = tempTab.Rows[0]["nationco"].ToString().Trim();
                this.jg.Text = tempTab.Rows[0]["disrict"].ToString().Trim();
                SelectCKB(this.clbWHCD, tempTab);
                SelectCKB(this.ckbHYZT, tempTab);
                SelectCKB(this.ckbRYFS, tempTab);
                this.dtp֪ͨҽʦʱ��.Text = tempTab.Rows[0]["tzyssj"].ToString().Trim();
                this.tb��Ժ��ʽ����.Text = tempTab.Rows[0]["ryfs_qt"].ToString().Trim();
                SelectCKB(this.ckbPS, tempTab);
                this.tb��������.Text = tempTab.Rows[0]["ps_qt"].ToString().Trim();
                this.tb��ҽ.Text = tempTab.Rows[0]["ZYRYZD"].ToString().Trim();
                this.tb��������.Text = tempTab.Rows[0]["FBJQ"].ToString().Trim();
                SelectCKB(this.ckbJWBS, tempTab);
                this.tb������ʷ.Text = tempTab.Rows[0]["JWBS_QT"].ToString().Trim();
                SelectCKB(this.ckbGMS, tempTab);
                this.tb����ҩ��.Text = tempTab.Rows[0]["gms_yw"].ToString().Trim();
                this.tb����ʳ��.Text = tempTab.Rows[0]["gms_sw"].ToString().Trim();
                this.tb��������.Text = tempTab.Rows[0]["gms_qt"].ToString().Trim();

                SelectCKB(this.ckbYS, tempTab);
                if (CheckValue(this.ckbYS) == 1)
                { this.tb��ʳ�쳣.Text = tempTab.Rows[0]["YS_QT"].ToString().Trim(); }
                else if (CheckValue(this.ckbYS) == 4)
                { this.tb��ʳ�Ⱥ�.Text = tempTab.Rows[0]["YS_QT"].ToString().Trim(); }
                SelectCKB(this.ckbSM, tempTab);
                this.tb˯������.Text = tempTab.Rows[0]["SM_YW"].ToString().Trim();
                SelectCKB(this.ckbDB, tempTab);
                this.tb�������.Text = tempTab.Rows[0]["DB_ZK"].ToString().Trim();
                SelectCKB(this.ckbXB, tempTab);
                SelectCKB(this.ckbZLNL, tempTab);
                SelectCKB(this.ckbZTHD, tempTab);
                this.tb֫���ϰ�.Text = tempTab.Rows[0]["zthd_za"].ToString().Trim();

                sSql = "select zthd_th from zy_zyrypg where inpatient_id='" + ClassStatic.Current_BinID + "'";
                DataTable tempTab1 = InstanceForm.BDatabase.GetDataTable(sSql);
                int i = Convert.ToInt32(tempTab1.Rows[0]["zthd_th"]);
                if (i > -1)
                { SelectCKB(this.ckbZTHD_TH, tempTab); }
                SelectCKB(this.ckbDGQK, tempTab);
                this.tb�����������.Text = tempTab.Rows[0]["dgqk_qt"].ToString().Trim();
                this.tb����.Text = tempTab.Rows[0]["smtz_tw"].ToString().Trim();
                this.tb����.Text = tempTab.Rows[0]["smtz_mb"].ToString().Trim();
                this.tb����.Text = tempTab.Rows[0]["smtz_hx"].ToString().Trim();
                this.tbѪѹ.Text = tempTab.Rows[0]["smtz_xy"].ToString().Trim();
                SelectCKB(this.ckbYSZT, tempTab);
                SelectCKB(this.ckbST, tempTab);
                this.tb��̦����.Text = tempTab.Rows[0]["st_qt"].ToString().Trim();
                SelectCKB(this.ckbSZ, tempTab);
                this.tb��������.Text = tempTab.Rows[0]["sz_qt"].ToString().Trim();
                SelectCKB(this.ckbmx, tempTab);
                this.tb����.Text = tempTab.Rows[0]["mx_qt"].ToString().Trim();
                SelectCKB(this.ckbPFWZX, tempTab);
                if (CheckValue(this.ckbPFWZX) == 1)
                { this.tbƤ������������.Text = tempTab.Rows[0]["pfwzx_qt"].ToString().Trim(); }
                else if (CheckValue(this.ckbPFWZX) == 4)
                { this.tbƤ��������ѹ.Text = tempTab.Rows[0]["pfwzx_qt"].ToString().Trim(); }
                SelectCKB(this.ckbZY, tempTab);
                this.tb��������.Text = tempTab.Rows[0]["zy_qt"].ToString().Trim();
                SelectCKB(this.ckbYY, tempTab);
                this.tb��������.Text = tempTab.Rows[0]["yy_qt"].ToString().Trim();
                SelectCKB(this.ckbZE, tempTab);
                this.tb�������.Text = tempTab.Rows[0]["ze_qt"].ToString().Trim();
                SelectCKB(this.ckbYE, tempTab);
                this.tb�Ҷ�����.Text = tempTab.Rows[0]["ye_qt"].ToString().Trim();
                SelectCKB(this.ckbQX, tempTab);
                this.tb��������.Text = tempTab.Rows[0]["qx_qt"].ToString().Trim();
                SelectCKB(this.ckbZYZT, tempTab);
                SelectCKB(this.ckbJSZT, tempTab);
                this.tb��ע.Text = tempTab.Rows[0]["bz"].ToString().Trim();

                this.lb������ʿ.Text = tempTab.Rows[0]["PGHS"].ToString().Trim();
                this.dtp����ʱ��.Value = Convert.ToDateTime(tempTab.Rows[0]["PGSJ"]);
                this.lb������.Text = "�����ˣ�" + tempTab.Rows[0]["BOOK"].ToString().Trim();
                this.lb����ʱ��.Text = "����ʱ�䣺" + tempTab.Rows[0]["BOOK_DATE"].ToString().Trim();
                this.lb�޸���.Text = "�޸��ˣ�" + tempTab.Rows[0]["UPDATE"].ToString().Trim();
                this.lb�޸�ʱ��.Text = "�޸�ʱ�䣺" + tempTab.Rows[0]["UPDATE_DATE"].ToString().Trim();
                this.dg1.Visible = false;
                #endregion
            }
            //�Դ����˺��޸��˺�����ص�ʱ�����ʾ
            if (this.lb�½�.Visible == true)
            {
                this.lb������.Text = "�����ˣ�" + lb������ʿ.Text.Trim();
                this.lb����ʱ��.Text = "����ʱ�䣺" + this.dtp����ʱ��.Value.ToString();
                //			}
                //			else
                //			{
                //				this.lb�޸���.Text="�޸��ˣ�"+lb������ʿ.Text.Trim();
                //				this.lb�޸�ʱ��.Text="�޸�ʱ�䣺"+this.dtp����ʱ��.Value.ToString();
            }
            if (CheckValue(this.ckbRYFS) == 4)
            {
                this.tb��Ժ��ʽ����.Enabled = true;
            }
            if (CheckValue(this.ckbPS) == 2)
            {
                this.tb��������.Enabled = true;
            }
            if (CheckValue(this.ckbJWBS) == 1)
            {
                this.tb������ʷ.Enabled = true;
            }
            if (CheckValue(this.ckbGMS) == 1)
            {
                this.tb����ҩ��.Enabled = true;
                this.tb����ʳ��.Enabled = true;
                this.tb��������.Enabled = true;
            }
            if (CheckValue(this.ckbYS) == 1)
            {
                this.tb��ʳ�쳣.Enabled = true;
            }
            else if (CheckValue(this.ckbYS) == 4)
            {
                this.tb��ʳ�Ⱥ�.Enabled = true;
            }
            if (CheckValue(this.ckbSM) == 4)
            {
                this.tb˯������.Enabled = true;
            }
            if (CheckValue(this.ckbDB) == 5)
            {
                this.tb�������.Enabled = true;
            }
            if (CheckValue(this.ckbZTHD) == 1)
            {
                this.tb֫���ϰ�.Enabled = true;
            }
            if (CheckValue(this.ckbDGQK) == 1)
            {
                this.tb�����������.Enabled = true;
            }
            if (CheckValue(this.ckbST) == 8)
            {
                this.tb��̦����.Enabled = true;
            }
            if (CheckValue(this.ckbSZ) == 8)
            {
                this.tb��������.Enabled = true;
            }
            if (CheckValue(this.ckbmx) == 11)
            {
                this.tb����.Enabled = true;
            }
            if (CheckValue(this.ckbPFWZX) == 1)
            {
                this.tbƤ������������.Enabled = true;
            }
            else if (CheckValue(this.ckbPFWZX) == 4)
            {
                this.tbƤ��������ѹ.Enabled = true;
            }
            if (CheckValue(this.ckbZY) == 1)
            {
                this.tb��������.Enabled = true;
            }
            if (CheckValue(this.ckbYY) == 1)
            {
                this.tb��������.Enabled = true;
            }
            if (CheckValue(this.ckbZE) == 1)
            {
                this.tb�������.Enabled = true;
            }
            if (CheckValue(this.ckbYE) == 1)
            {
                this.tb�Ҷ�����.Enabled = true; this.tb�Ҷ�����.Focus();
            }
            if (CheckValue(this.ckbQX) == 6)
            {
                this.tb��������.Enabled = true;
            }

            ShowInput();
            this.dg1.Visible = false;
            this.zy.Focus();
        }

        //		private void SelectRB(string rbName,DataTable myTb)
        //		{
        //			int i=Convert.ToInt16(myTb.Rows[0][rbName]);
        //			string rbname="";
        //			rbname="rb"+rbName+i.ToString ().Trim ();
        //			chkbox.Name =rbname;
        //			chkbox.Checked=true; 
        ////"rb"+rbName+i.ToString()
        //
        //			//RadioButton rb
        //
        //		}
        //������������ݿ�����
        private void SelectCKB(CheckedListBox chklBox, DataTable myTb)
        {
            string sName = chklBox.Name.Trim().Substring(3, chklBox.Name.Trim().Length - 3);
            if (myTb.Rows[0][sName].ToString() == "") return;
            int i = Convert.ToInt16(myTb.Rows[0][sName]);
            if (i == -1) return;
            try
            {
                chklBox.SetItemCheckState(i, CheckState.Checked);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return;
        }

        //��ѡ�Ŀ���
        private void ChkLChange(CheckedListBox chklBox, int Num)
        {

            if (chklBox.SelectedIndex == -1) return;
            for (int i = 0; i < Num; i++)
            {
                if (i != chklBox.SelectedIndex)
                {
                    if (chklBox.GetItemCheckState(chklBox.SelectedIndex) == CheckState.Checked)
                        chklBox.SetItemChecked(i, false);
                }
            }

            return;
        }
        #region //��CHECKEDLISTBOX�д�С���ж�

        private void ckbJSZT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbJSZT, 4);
        }

        private void ckbZYZT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZYZT, 7);
        }

        private void ckbQX_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbQX, 7);
        }

        private void ckbYE_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbYE, 2);
        }

        private void ckbZE_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZE, 2);
        }

        private void ckbYY_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbYY, 2);
        }

        private void ckbZY_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZY, 2);
        }

        private void ckbPFWZX_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbPFWZX, 5);
        }

        private void ckbST_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbSZ, 9);
        }

        private void ckbYSZT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbYSZT, 6);
        }

        private void ckbDGQK_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbDGQK, 2);
        }



        private void ckbZLNL_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZLNL, 3);
        }

        private void ckbXB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbXB, 10);
        }

        private void ckbDB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbDB, 7);
        }

        private void ckbSM_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbSM, 5);
        }

        private void ckbYS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbYS, 5);
        }

        private void ckbGMS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbGMS, 2);
        }

        private void ckbJWBS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbJWBS, 2);
        }

        private void ckbPS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbPS, 3);
        }

        private void ckbRYFS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbRYFS, 5);
        }

        private void ckbHYZT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbHYZT, 5);
        }

        private void clbWHCD_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.clbWHCD, 8);
        }
        #endregion

        private void sf_F1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //ChkLChange(this.ckbWHCD ,6);
        }

        private void sf_F1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //			int i=this.sf_F1 .SelectedIndex;
            //			this.sf_F1.ClearSelected();
            //			this.sf_F1.SetItemChecked(i,true);
        }

        public static DataTable GetListTable(string strSelect, DataGrid dtGridName)
        {
            if (strSelect == "")
            {
                throw new Exception("��ѯ��䲻��Ϊ�գ�");
            }
            else if (strSelect.Trim().Substring(0, 6).ToLower() != "select")
            {
                throw new Exception("ֻ��Ϊ��ѯ��䣡");
            }
            DataTable tb = InstanceForm.BDatabase.GetDataTable(strSelect);
            dtGridName.DataSource = tb;
            if (tb != null && tb.Rows.Count > 0)
            {
                dtGridName.Visible = true;
            }
            return tb;
        }
        #region//��ְҵ�����������Ĳ�ѯ
        private void zy_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dg1.DataSource = null;
                tb.Clear();
                dg1.Visible = false;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tb.Rows.Count > 0)
                    {
                        zy.Text = tb.Rows[dg1.CurrentRowIndex][1].ToString().Trim();
                        dg1.Visible = false;
                    }
                    else
                    {
                        dg1.Visible = false;
                        return;
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("�������ѯ��������\n\n" + err.Message);
                }

                if (e.KeyCode == Keys.Enter)
                {
                    mz.Focus();
                    dg1.Visible = false;
                }
                mz.Focus();
                dg1.Visible = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex > 0)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex - 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.Down)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex < tb.Rows.Count)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex + 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.F4)
            {
                showchange();
            }
            else
            {//���ݿ���û�������
                string strSelect = "select py_code  ƴ��,name as ְҵ,code ������,wb_code �����  from jc_occupati where ";
                if (inputflag == 1)
                    strSelect = strSelect + "lower(py_code) like lower('" + zy.Text + "%')";
                else if (inputflag == 2)
                    strSelect = strSelect + "wb_code like '" + zy.Text + "%'";
                else if (inputflag == 3)
                    strSelect = strSelect + "code like '" + zy.Text + "%'";
                tb = GetListTable(strSelect, dg1);
            }

        }

        private void mz_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dg1.DataSource = null;
                tb1.Clear();
                dg1.Visible = false;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (this.mz.Text == "����")
                {
                    jg.Focus();
                }
                else
                {
                    if (tb1.Rows.Count > 0)
                    { mz.Text = tb1.Rows[dg1.CurrentRowIndex][1].ToString().Trim(); jg.Focus(); }
                    else
                    {
                        dg1.Visible = false;
                        return;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    this.jg.Focus();
                }
                this.dg1.Visible = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex > 0)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex - 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.Down)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex < tb1.Rows.Count)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex + 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.F4)
            {
                showchange();
            }
            else
            {
                string strSelect1 = "select py_code ƴ����,name as ����,code �����,code2 ������ from jc_nationco where ";
                if (inputflag == 1)
                    strSelect1 = strSelect1 + "lower(py_code) like lower('" + mz.Text + "%')";
                else if (inputflag == 2)
                    strSelect1 = strSelect1 + "lower(code) like lower('" + mz.Text + "%')";
                else if (inputflag == 3)
                    strSelect1 = strSelect1 + "code2 like '" + mz.Text + "%'";
                tb1 = GetListTable(strSelect1, dg1);
            }

        }

        private void jg_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dg1.DataSource = null;
                tb2.Clear();
                dg1.Visible = false;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (jg.Text == "����ʡ��ɳ��")
                {
                    this.clbWHCD.Focus();
                }
                else
                {
                    if (tb2.Rows.Count > 0)
                    {
                        try { jg.Text = tb2.Rows[dg1.CurrentRowIndex][1].ToString().Trim(); }
                        catch (System.Exception err) { MessageBox.Show(err.Message); }
                        this.clbWHCD.Focus();
                        dg1.Visible = false;

                    }
                    else { dg1.Visible = false; return; }
                }

            }
            else if (e.KeyCode == Keys.Up)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex > 0)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex - 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.Down)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex < tb2.Rows.Count)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex + 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.F4)
            {
                showchange();
            }
            else
            {
                string strSelect2 = "select py_code ƴ����,name as ����,code ������,wb_code ����� from jc_district where ";
                if (inputflag == 1)//ƴ����
                { strSelect2 = strSelect2 + "lower(py_code) like lower('" + jg.Text + "%')"; }
                else if (inputflag == 2)
                { strSelect2 = strSelect2 + "lower(wb_code) like lower('" + jg.Text + "%')"; }
                else if (inputflag == 3)
                    strSelect2 = strSelect2 + "code like '" + jg.Text + "%'";
                tb2 = GetListTable(strSelect2, dg1);
            }
        }

        #endregion
        //��ѡCHECKEDLISTBOX�е��ж�
        private int CheckValue(CheckedListBox chklBox)
        {
            int i = -1;
            try
            {
                i = chklBox.CheckedIndices[0];
                return i;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                return -1;
            }
            finally
            {
            }
            return 0;
        }

        #region//������޸����ݿ����
        private void btUse_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int fwh = 0;
            int fhy = 0;
            int fry = 0;
            int fps = 0;
            int fjw = 0;
            int fgm = 0;
            int fys = 0;
            int fsm = 0;
            int fdb = 0;
            int fxb = 0;
            int fzl = 0;
            int fzt = 0;
            int fzthd_th = 0;
            int fdg = 0;
            int fysz = 0;
            int fst = 0;
            int fsz = 0;
            int fmx = 0;
            int fpf = 0;
            int fzy = 0;
            int fyy = 0;
            int fze = 0;
            int fye = 0;
            int fqx = 0;
            int fzyzt = 0;
            int fjs = 0;
            fwh = CheckValue(this.clbWHCD);
            fhy = CheckValue(this.ckbHYZT);
            fry = CheckValue(this.ckbRYFS);
            fps = CheckValue(this.ckbPS);
            fjw = CheckValue(this.ckbJWBS);
            fgm = CheckValue(this.ckbGMS);
            fys = CheckValue(this.ckbYS);
            fsm = CheckValue(this.ckbSM);
            fdb = CheckValue(this.ckbDB);
            fxb = CheckValue(this.ckbXB);
            fzl = CheckValue(this.ckbZLNL);
            fzt = CheckValue(this.ckbZTHD);
            fzthd_th = CheckValue(this.ckbZTHD_TH);
            fdg = CheckValue(this.ckbDGQK);
            fysz = CheckValue(this.ckbYSZT);
            fst = CheckValue(this.ckbST);
            fsz = CheckValue(this.ckbSZ);
            fmx = CheckValue(this.ckbmx);
            fpf = CheckValue(this.ckbPFWZX);
            fzy = CheckValue(this.ckbZY);
            fyy = CheckValue(this.ckbYY);
            fze = CheckValue(this.ckbZE);
            fye = CheckValue(this.ckbYE);
            fqx = CheckValue(this.ckbQX);
            fzyzt = CheckValue(this.ckbZYZT);
            fjs = CheckValue(this.ckbJSZT);

            //��ȡ���˵�INPATIENT_ID��BABY_ID
            string sSql;
            DataTable myTb = new DataTable();
            Guid intTb = ClassStatic.Current_BinID;//Convert.ToInt32(myTb.Rows[0]["inpatient_id"]);
            long intTb1 = Convert.ToInt32(ClassStatic.Current_BabyID);//Convert.ToInt32(myTb.Rows[0]["baby_id"]);

            if (this.tb����.Text.Trim() != "")
            {
                if (Convert.ToDouble(this.tb����.Text.Trim()) > 45 || Convert.ToDouble(this.tb����.Text.Trim()) < 30)
                {
                    MessageBox.Show("����������´���45�����С��30�棬���������룬¼����ȷ���ٱ��棡");
                    return;
                }
            }
            sSql = "select * from zy_zyrypg where inpatient_id='" + intTb + "'";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);
            if (myTb.Rows.Count > 0)
            {
                //�Ա�ZY _ZYRYPG�����޸�
                this.lb�½�.Visible = false;
                sSql = "update zy_zyrypg set baby_id=" + intTb1 + ",occupati='" + zy.Text.Trim() + "',nationco='" + mz.Text.Trim() + "'," +
                    "disrict='" + jg.Text.Trim() + "',whcd=" + fwh + ",hyzt=" + fhy + ",tzyssj='" + Convert.ToDateTime(this.dtp֪ͨҽʦʱ��.Value) + "'," +
                    "ryfs=" + fry + ",ryfs_qt='" + tb��Ժ��ʽ����.Text.Trim() + "',ps=" + fps + ",ps_qt='" + tb��������.Text.Trim() + "',zyryzd='" + tb��ҽ.Text.Trim() + "',fbjq='" + tb��������.Text.Trim() + "'," +
                    "jwbs=" + fjw + ",jwbs_qt='" + tb������ʷ.Text.Trim() + "',gms=" + fgm + ",gms_yw='" + tb����ҩ��.Text.Trim() + "',gms_sw='" + tb����ʳ��.Text.Trim() + "'," +
                    "gms_qt='" + tb��������.Text.Trim() + "',ys=" + fys + ",sm=" + fsm + ",sm_yw='" + this.tb˯������.Text.Trim() + "',db=" + fdb + ",xb=" + fxb + ",zlnl=" + fzl + "," +
                    "db_zk='" + this.tb�������.Text.Trim() + "',zthd=" + fzt + ",zthd_za='" + this.tb֫���ϰ�.Text.Trim() + "',zthd_th=" + fzthd_th + ",dgqk=" + fdg + "," +
                    "dgqk_qt='" + this.tb�����������.Text.Trim() + "',smtz_tw='" + this.tb����.Text.Trim() + "',smtz_mb='" + this.tb����.Text.Trim() + "'," +
                    "smtz_hx='" + this.tb����.Text.Trim() + "',smtz_xy='" + this.tbѪѹ.Text.Trim() + "',yszt=" + fysz + ",st=" + fst + ",st_qt='" + this.tb��̦����.Text.Trim() + "'," +
                    "sz=" + fsz + ",sz_qt='" + this.tb��������.Text.Trim() + "',mx=" + fmx + ",mx_qt='" + this.tb����.Text.Trim() + "'," +
                    "pfwzx=" + fpf + ",zy=" + fzy + ",zy_qt='" + this.tb��������.Text.Trim() + "',yy=" + fyy + ",yy_qt='" + this.tb��������.Text.Trim() + "'," +
                    "ze=" + fze + ",ze_qt='" + this.tb�������.Text.Trim() + "',ye=" + fye + ",ye_qt='" + this.tb�Ҷ�����.Text.Trim() + "',qx=" + fqx + ",qx_qt='" + this.tb��������.Text.Trim() + "'," +
                    "zyzt=" + fzyzt + ",jszt=" + fjs + ",bz='" + this.tb��ע.Text.Trim() + "',pgsj='" + Convert.ToDateTime(this.dtp����ʱ��.Value) + "'," +
                    "[update]='" + InstanceForm.BCurrentUser.Name + "',update_date=getdate() where inpatient_id='" + intTb + "' ";

                try
                {
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
                catch (System.Exception err)
                {
                    //д������־ Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "������Ժ��������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show(err.Message);
                    return;
                }

                if (lb��Ժ���.Text.Trim() != "")
                {
                    sSql = "update zy_inpatient set IN_DIAGNOSIS = '" + lb��Ժ���.Text.Trim() + "' where inpatient_id='" + intTb + "'";

                    try
                    {
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                    catch (System.Exception err)
                    {
                        //д������־ Add By Tany 2005-01-12
                        SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "���²�����ϴ���" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                        _systemErrLog.Save();
                        _systemErrLog = null;

                        MessageBox.Show(err.Message);
                        return;
                    }
                }

                MessageBox.Show(" �����޸ĳɹ�");

            }
            else
            {
                //�Ա�ZY _ZYRYPG��������
                sSql = "insert into zy_zyrypg(id,inpatient_id,baby_id,occupati,nationco,disrict,whcd,hyzt,tzyssj,ryfs,ryfs_qt,ps,ps_qt,zyryzd,fbjq,jwbs,jwbs_qt," +
                    "gms,gms_yw,gms_sw,gms_qt,ys,sm,sm_yw,db,db_zk,xb,zlnl,zthd,zthd_za,zthd_th,dgqk,dgqk_qt,smtz_tw," +
                    "smtz_mb,smtz_hx,smtz_xy,yszt,st,st_qt,sz,sz_qt,mx,mx_qt,pfwzx,zy,zy_qt,yy,yy_qt,ze,ze_qt,ye,ye_qt,qx,qx_qt,zyzt," +
                    "jszt,bz,pghs,pgsj,book,book_date,jgbm) " +
                    "values('" + PubStaticFun.NewGuid() + "','" + intTb + "'," + intTb1 + ",'" + this.zy.Text.Trim() + "','" + this.mz.Text.Trim() + "','" + this.jg.Text.Trim() + "'," + fwh + "," +
                    "" + fhy + ",'" + Convert.ToDateTime(this.dtp֪ͨҽʦʱ��.Value) + "'," + fry + "," +
                    "'" + this.tb��Ժ��ʽ����.Text.Trim() + "'," + fps + ",'" + this.tb��������.Text.Trim() + "','" + this.tb��ҽ.Text.Trim() + "','" + this.tb��������.Text.Trim() + "'," +
                    "" + fjw + ",'" + this.tb������ʷ.Text.Trim() + "'," + fgm + ",'" + this.tb����ҩ��.Text.Trim() + "'," +
                    "'" + this.tb����ʳ��.Text.Trim() + "','" + this.tb��������.Text.Trim() + "'," + fys + "," + fsm + ",'" + this.tb˯������.Text.Trim() + "'," +
                    "" + fdb + ",'" + this.tb�������.Text.Trim() + "'," + fxb + "," + fzl + "," + fzt + "," +
                    "'" + this.tb֫���ϰ�.Text.Trim() + "'," + fzthd_th + "," +
                    "" + fdg + ",'" + this.tb�����������.Text.Trim() + "','" + this.tb����.Text.Trim() + "','" + this.tb����.Text.Trim() + "'," +
                    "'" + this.tb����.Text.Trim() + "','" + this.tbѪѹ.Text.Trim() + "'," + fysz + "," + fst + ",'" + this.tb��̦����.Text.Trim() + "'," +
                    "" + fsz + ",'" + this.tb��������.Text.Trim() + "'," + fmx + ",'" + this.tb����.Text.Trim() + "'," +
                    "" + fpf + "," + fzy + ",'" + this.tb��������.Text.Trim() + "'," + fyy + ",'" + this.tb��������.Text.Trim() + "'," +
                    "" + fze + ",'" + this.tb�������.Text.Trim() + "'," + fye + ",'" + this.tb�Ҷ�����.Text.Trim() + "'," + fqx + "," +
                    "'" + this.tb��������.Text.Trim() + "'," + fzyzt + "," + fjs + ",'" + this.tb��ע.Text.Trim() + "','" + this.lb������ʿ.Text.Trim() + "'," +
                    "'" + Convert.ToDateTime(this.dtp����ʱ��.Value) + "','" + this.lb������ʿ.Text.Trim() + "'," +
                    "'" + Convert.ToDateTime(this.dtp����ʱ��.Value) + "'," + FrmMdiMain.Jgbm + ")";

                try
                {
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
                catch (System.Exception err)
                {
                    //д������־ Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "������Ժ��������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show(err.Message);

                    return;
                }

                if (lb��Ժ���.Text.Trim() != "")
                {
                    sSql = "update zy_inpatient set IN_DIAGNOSIS = '" + lb��Ժ���.Text.Trim() + "' where inpatient_id='" + intTb + "'";

                    try
                    {
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                    catch (System.Exception err)
                    {
                        //д������־ Add By Tany 2005-01-12
                        SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "���²�����ϴ���" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                        _systemErrLog.Save();
                        _systemErrLog = null;

                        MessageBox.Show(err.Message);
                        return;
                    }
                }

            }
            //�Ա�yy_brxx�����޸�
            //sSql = "update yy_brxx set jtdz='" + this.tb��ͥ��ַ.Text.Trim() + "',lxr='" + this.tb��ϵ��.Text.Trim() + "'," +
            //    "lxrdh='" + this.tb��ϵ�绰.Text.Trim() + "'" +
            //    "where inpatient_no='" + this.lbסԺ������.Text.Trim() + "'";
            //try
            //{
            //    InstanceForm.BDatabase.DoCommand(sSql);
            //}
            //catch (System.Exception err)
            //{
            //    //д������־ Add By Tany 2005-01-12
            //    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "���²�����Ϣ����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
            //    _systemErrLog.Save();
            //    _systemErrLog = null;

            //    MessageBox.Show(err.Message);
            //    return;
            //}
            //����ʳ����
            string sSql1;
            sSql1 = "select id from zy_zyrypg where inpatient_id='" + intTb + "'";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql1);
            Guid intTb2 = new Guid(myTb.Rows[0]["id"].ToString());

            sSql1 = "";
            if (CheckValue(this.ckbYS) == 1)
            {
                sSql1 = "update zy_zyrypg set  ys_qt='" + this.tb��ʳ�쳣.Text.Trim() + "' where id='" + intTb2 + "' ";
            }
            else if (CheckValue(this.ckbYS) == 4)
            {
                sSql1 = "update zy_zyrypg set  ys_qt='" + this.tb��ʳ�Ⱥ�.Text.Trim() + "' where id='" + intTb2 + "' ";
            }
            if (sSql1 != "")
            {
                try
                {
                    InstanceForm.BDatabase.DoCommand(sSql1);
                }
                catch (System.Exception err)
                {
                    //д������־ Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "������Ժ��������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show(err.Message);

                    return;
                }
            }

            sSql1 = "";
            //Ƥ�������Դ���
            if (CheckValue(this.ckbPFWZX) == 1)
            {
                sSql1 = "update zy_zyrypg set  pfwzx_qt='" + this.tbƤ������������.Text.Trim() + "' where id='" + intTb2 + "'";
            }
            else if (CheckValue(this.ckbPFWZX) == 4)
            {
                sSql1 = "update zy_zyrypg set  pfwzx_qt='" + this.tbƤ��������ѹ.Text.Trim() + "' where id='" + intTb2 + "'";
            }
            if (sSql1 != "")
            {
                try
                {
                    InstanceForm.BDatabase.DoCommand(sSql1);
                }
                catch (System.Exception err)
                {
                    //д������־ Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "������Ժ��������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show(err.Message);

                    return;
                }
            }
            MessageBox.Show(" ���ݱ���ɹ�");

            frmHLPG_Load(null, null);

        }
        #endregion

        private void ckbZTHD_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZTHD, 4);
        }

        private void ckbZTHD_TH_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZTHD_TH, 4);
        }
        //�������Ŀ�����ʾ
        private void ShowInput()
        {
            switch (inputflag)
            {
                case 1:
                    this.statusBar1.Panels[0].Text = "��ǰ���뷨��ƴ����   ��F4�л����뷨";
                    this.statusBar1.Panels[1].Text = "��ӭ��ʹ�ô���ҽԺ������Ϣϵͳ";
                    break;
                case 2:
                    this.statusBar1.Panels[0].Text = "��ǰ���뷨�������   ��F4�л����뷨";
                    this.statusBar1.Panels[1].Text = "��ӭ��ʹ�ô���ҽԺ������Ϣϵͳ";
                    break;
                case 3:
                    this.statusBar1.Panels[0].Text = "��ǰ���뷨��������   ��F4�л����뷨";
                    this.statusBar1.Panels[1].Text = "��ӭ��ʹ�ô���ҽԺ������Ϣϵͳ";
                    break;
            }
            return;
        }
        private void showchange()
        {
            switch (inputflag)
            {
                case 1:
                    inputflag = 2;
                    this.statusBar1.Panels[0].Text = "��ǰ���뷨�������   ��F4�л����뷨";
                    break;
                case 2:
                    inputflag = 3;
                    this.statusBar1.Panels[0].Text = "��ǰ���뷨��������   ��F4�л����뷨";
                    break;
                case 3:
                    inputflag = 1;
                    this.statusBar1.Panels[0].Text = "��ǰ���뷨��ƴ����   ��F4�л����뷨";
                    break;
            }
            return;
        }


        //��F4ת������

        #region //��CHECKEDLISTBOX���ı����������
        private void ckbRYFS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbRYFS) == 4)
            {
                this.tb��Ժ��ʽ����.Enabled = true;
                this.tb��Ժ��ʽ����.Focus();
            }
            if (CheckValue(this.ckbRYFS) != 4)
            {
                this.tb��Ժ��ʽ����.Text = "";
                this.tb��Ժ��ʽ����.Enabled = false;
            }

        }

        private void ckbPS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbPS) == 2)
            {
                this.tb��������.Enabled = true;
                this.tb��������.Focus();
            }
            if (CheckValue(this.ckbPS) != 2)
            {
                this.tb��������.Text = "";
                this.tb��������.Enabled = false;
            }

        }

        private void ckbJWBS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbJWBS) == 1)
            {
                this.tb������ʷ.Enabled = true;
                this.tb������ʷ.Focus();
            }
            if (CheckValue(this.ckbJWBS) != 1)
            {
                this.tb������ʷ.Text = "";
                this.tb������ʷ.Enabled = false;
            }

        }

        private void ckbGMS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbGMS) == 1)
            {
                this.tb����ҩ��.Enabled = true;
                this.tb����ҩ��.Focus();
                this.tb����ʳ��.Enabled = true;
                this.tb��������.Enabled = true;
            }
            if (CheckValue(this.ckbGMS) != 1)
            {
                this.tb����ҩ��.Text = "";
                this.tb����ʳ��.Text = "";
                this.tb��������.Text = "";
                this.tb����ҩ��.Enabled = false;
                this.tb����ʳ��.Enabled = false;
                this.tb��������.Enabled = false;
            }

        }

        private void ckbYS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbYS) == 1)
            {
                this.tb��ʳ�쳣.Enabled = true;
                this.tb��ʳ�쳣.Focus();
                this.tb��ʳ�Ⱥ�.Text = "";
            }
            else this.tb��ʳ�쳣.Enabled = false;
            if (CheckValue(this.ckbYS) == 4) { this.tb��ʳ�Ⱥ�.Enabled = true; this.tb��ʳ�Ⱥ�.Focus(); this.tb��ʳ�쳣.Text = ""; }
            else this.tb��ʳ�Ⱥ�.Enabled = false;
            if (CheckValue(this.ckbYS) == 0)
            {
                this.tb��ʳ�Ⱥ�.Text = "";
                this.tb��ʳ�쳣.Text = "";
                this.tb��ʳ�쳣.Enabled = false;
                this.tb��ʳ�Ⱥ�.Enabled = false;
            }
        }

        private void ckbSM_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbSM) == 4)
            {
                this.tb˯������.Enabled = true;
                this.tb˯������.Focus();
            }
            else
            {
                this.tb˯������.Text = "";
            }
        }

        private void ckbDB_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbDB) == 5)
            {
                this.tb�������.Enabled = true;
                this.tb�������.Focus();
            }
            else
            {
                this.tb�������.Text = "";
                this.tb�������.Enabled = false;
            }

        }

        private void ckbZTHD_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbZTHD) == 1)
            {
                this.tb֫���ϰ�.Enabled = true;
                this.tb֫���ϰ�.Focus();
            }
            else
            {
                this.tb֫���ϰ�.Enabled = false;
            }
            if (CheckValue(this.ckbZTHD) == 3)
            {

                this.ckbZTHD_TH.SetItemChecked(0, true);
            }

            if (CheckValue(this.ckbZTHD) == 1 || CheckValue(this.ckbZTHD) == 0)
            {
                this.ckbZTHD_TH.SetItemChecked(0, false);
                this.ckbZTHD_TH.SetItemChecked(1, false);
                this.ckbZTHD_TH.SetItemChecked(2, false);
                this.ckbZTHD_TH.SetItemChecked(3, false);
            }
        }

        private void ckbDGQK_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbDGQK) == 1)
            {
                this.tb�����������.Enabled = true;
                this.tb�����������.Focus();
            }
            if (CheckValue(this.ckbDGQK) == 0)
            {
                this.tb�����������.Text = "";
                this.tb�����������.Enabled = false;
            }
        }

        private void ckbST_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbSZ) == 8)
            {
                this.tb��������.Enabled = true;
                this.tb��������.Focus();
            }
            else
            {
                this.tb��������.Enabled = false;
                this.tb��������.Text = "";
            }
        }

        private void ckbPFWZX_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbPFWZX) == 1) { this.tbƤ������������.Enabled = true; this.tbƤ������������.Focus(); this.tbƤ��������ѹ.Text = ""; }
            else { this.tbƤ������������.Enabled = false; this.tbƤ������������.Text = ""; }
            if (CheckValue(this.ckbPFWZX) == 4) { this.tbƤ��������ѹ.Enabled = true; this.tbƤ��������ѹ.Focus(); this.tbƤ������������.Text = ""; }
            else { this.tbƤ��������ѹ.Enabled = false; this.tbƤ��������ѹ.Text = ""; }
        }

        private void ckbZY_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbZY) == 1) { this.tb��������.Enabled = true; this.tb��������.Focus(); }
            else
            {
                this.tb��������.Text = "";
                this.tb��������.Enabled = false;
            }
        }

        private void ckbYY_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbYY) == 1) { this.tb��������.Enabled = true; this.tb��������.Focus(); }
            else { this.tb��������.Enabled = false; this.tb��������.Text = ""; }

        }

        private void ckbZE_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbZE) == 1) { this.tb�������.Enabled = true; this.tb�������.Focus(); }
            else { this.tb�������.Enabled = false; this.tb�������.Text = ""; }
        }

        private void ckbYE_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbYE) == 1) { this.tb�Ҷ�����.Enabled = true; this.tb�Ҷ�����.Focus(); }
            else { this.tb�Ҷ�����.Enabled = false; this.tb�Ҷ�����.Text = ""; }

        }

        private void ckbQX_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbQX) == 6) { this.tb��������.Enabled = true; this.tb��������.Focus(); }
            else { this.tb��������.Enabled = false; this.tb��������.Text = ""; }
        }

        private void tb����_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbѪѹ.Focus();
            }
        }

        private void tb����_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb����.Focus();
            }
        }

        private void ckbZTHD_TH_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbZTHD_TH) == 0 || CheckValue(this.ckbZTHD_TH) == 1 || CheckValue(this.ckbZTHD_TH) == 2 || CheckValue(this.ckbZTHD_TH) == 3)
                this.ckbZTHD.SetItemChecked(3, true);
            this.ckbZTHD.SetItemChecked(0, false);
            this.ckbZTHD.SetItemChecked(1, false);
            this.tb֫���ϰ�.Text = "";
            this.tb֫���ϰ�.Enabled = false;
        }

        private void tb����_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb����.Focus();
            }
        }

        private void tb����ҩ��_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb����ʳ��.Focus();
            }
        }

        private void tb����ʳ��_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb��������.Focus();
            }
        }
        #endregion
        #region//ͨ�����̿��ƽ���ʱ����CHECKLISTBOX��ѡ�Ŀ���
        private void clbWHCD_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.clbWHCD, 7);
            this.dg1.Visible = false;
            if (e.KeyCode == Keys.Enter)
            {
                this.dg1.Visible = false;
            }
        }

        private void ckbHYZT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbHYZT, 5);
        }

        private void ckbRYFS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbRYFS, 5);
            if (CheckValue(this.ckbRYFS) == 4)
            {
                this.tb��Ժ��ʽ����.Enabled = true;
                this.tb��Ժ��ʽ����.Focus();
            }
            if (CheckValue(this.ckbRYFS) != 4)
            {
                this.tb��Ժ��ʽ����.Text = "";
                this.tb��Ժ��ʽ����.Enabled = false;
            }
        }

        private void ckbPS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbPS, 3);
            if (CheckValue(this.ckbPS) == 2)
            {
                this.tb��������.Enabled = true;
                this.tb��������.Focus();
            }
            if (CheckValue(this.ckbPS) != 2)
            {
                this.tb��������.Text = "";
                this.tb��������.Enabled = false;
            }
        }

        private void ckbJWBS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbJWBS, 2);
            if (CheckValue(this.ckbJWBS) == 1)
            {
                this.tb������ʷ.Enabled = true;
                this.tb������ʷ.Focus();
            }
            if (CheckValue(this.ckbJWBS) != 1)
            {
                this.tb������ʷ.Text = "";
                this.tb������ʷ.Enabled = false;
            }
        }

        private void ckbGMS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbGMS, 2);
            if (CheckValue(this.ckbGMS) == 1)
            {
                this.tb����ҩ��.Enabled = true;
                this.tb����ҩ��.Focus();
                this.tb����ʳ��.Enabled = true;
                this.tb��������.Enabled = true;
            }
            if (CheckValue(this.ckbGMS) != 1)
            {
                this.tb����ҩ��.Text = "";
                this.tb����ʳ��.Text = "";
                this.tb��������.Text = "";
                this.tb����ҩ��.Enabled = false;
                this.tb����ʳ��.Enabled = false;
                this.tb��������.Enabled = false;
            }
        }

        private void ckbYS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbYS, 5);
            if (CheckValue(this.ckbYS) == 1)
            {
                this.tb��ʳ�쳣.Enabled = true;
                this.tb��ʳ�쳣.Focus();
                this.tb��ʳ�Ⱥ�.Text = "";
            }
            else this.tb��ʳ�쳣.Enabled = false;
            if (CheckValue(this.ckbYS) == 4) { this.tb��ʳ�Ⱥ�.Enabled = true; this.tb��ʳ�Ⱥ�.Focus(); this.tb��ʳ�쳣.Text = ""; }
            else this.tb��ʳ�Ⱥ�.Enabled = false;
            if (CheckValue(this.ckbYS) == 0)
            {
                this.tb��ʳ�Ⱥ�.Text = "";
                this.tb��ʳ�쳣.Text = "";
                this.tb��ʳ�쳣.Enabled = false;
                this.tb��ʳ�Ⱥ�.Enabled = false;
            }
        }

        private void ckbSM_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbSM, 5);
            if (CheckValue(this.ckbSM) == 4)
            {
                this.tb˯������.Enabled = true;
                this.tb˯������.Focus();
            }
            else
            {
                this.tb˯������.Text = "";
            }
        }

        private void ckbDB_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbDB, 6);
            if (CheckValue(this.ckbDB) == 5)
            {
                this.tb�������.Enabled = true;
                this.tb�������.Focus();
            }
            else
            {
                this.tb�������.Text = "";
                this.tb�������.Enabled = false;
            }
        }

        private void ckbXB_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbXB, 9);
            if (e.KeyCode == Keys.Enter)
            {
                this.ckbZLNL.Focus();
            }
        }

        private void ckbZLNL_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZLNL, 3);
        }

        private void ckbZTHD_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZTHD, 4);
            if (CheckValue(this.ckbZTHD) == 1)
            {
                this.tb֫���ϰ�.Enabled = true;
                this.tb֫���ϰ�.Focus();
            }
            else
            {
                this.tb֫���ϰ�.Enabled = false;
            }
            if (CheckValue(this.ckbZTHD) == 3)
            {

                this.ckbZTHD_TH.SetItemChecked(0, true);
            }

            if (CheckValue(this.ckbZTHD) == 1 || CheckValue(this.ckbZTHD) == 0)
            {
                this.ckbZTHD_TH.SetItemChecked(0, false);
                this.ckbZTHD_TH.SetItemChecked(1, false);
                this.ckbZTHD_TH.SetItemChecked(2, false);
                this.ckbZTHD_TH.SetItemChecked(3, false);
            }
        }

        private void ckbDGQK_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbDGQK, 2);
            if (CheckValue(this.ckbDGQK) == 1)
            {
                this.tb�����������.Enabled = true;
                this.tb�����������.Focus();
            }
            if (CheckValue(this.ckbDGQK) == 0)
            {
                this.tb�����������.Text = "";
                this.tb�����������.Enabled = false;
            }
        }

        private void ckbYSZT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbYSZT, 6);
        }



        private void ckbPFWZX_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbPFWZX, 5);
            if (CheckValue(this.ckbPFWZX) == 1) { this.tbƤ������������.Enabled = true; this.tbƤ������������.Focus(); this.tbƤ��������ѹ.Text = ""; }
            else { this.tbƤ������������.Enabled = false; this.tbƤ������������.Text = ""; }
            if (CheckValue(this.ckbPFWZX) == 4) { this.tbƤ��������ѹ.Enabled = true; this.tbƤ��������ѹ.Focus(); this.tbƤ������������.Text = ""; }
            else { this.tbƤ��������ѹ.Enabled = false; this.tbƤ��������ѹ.Text = ""; }
        }

        private void ckbZY_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZY, 2);
            if (CheckValue(this.ckbZY) == 1) { this.tb��������.Enabled = true; this.tb��������.Focus(); }
            else
            {
                this.tb��������.Text = "";
                this.tb��������.Enabled = false;
            }
        }

        private void ckbYY_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbYY, 2);

            if (CheckValue(this.ckbYY) == 1) { this.tb��������.Enabled = true; this.tb��������.Focus(); }
            else { this.tb��������.Enabled = false; this.tb��������.Text = ""; }
        }

        private void ckbZE_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZE, 2);
            if (CheckValue(this.ckbZE) == 1) { this.tb�������.Enabled = true; this.tb�������.Focus(); }
            else { this.tb�������.Enabled = false; this.tb�������.Text = ""; }
        }

        private void ckbYE_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbYE, 2);
            if (CheckValue(this.ckbYE) == 1) { this.tb�Ҷ�����.Enabled = true; this.tb�Ҷ�����.Focus(); }
            else { this.tb�Ҷ�����.Enabled = false; this.tb�Ҷ�����.Text = ""; }
        }

        private void ckbQX_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbQX, 7);
            if (CheckValue(this.ckbQX) == 6) { this.tb��������.Enabled = true; this.tb��������.Focus(); }
            else { this.tb��������.Enabled = false; this.tb��������.Text = ""; }
        }

        private void ckbZYZT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZYZT, 6);
        }

        private void ckbJSZT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbJSZT, 4);
        }

        private void ckbZTHD_TH_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZTHD_TH, 4);
            if (CheckValue(this.ckbZTHD_TH) == 0 || CheckValue(this.ckbZTHD_TH) == 1 || CheckValue(this.ckbZTHD_TH) == 2 || CheckValue(this.ckbZTHD_TH) == 3)
                this.ckbZTHD.SetItemChecked(3, true);
            this.ckbZTHD.SetItemChecked(0, false);
            this.ckbZTHD.SetItemChecked(1, false);
            this.tb֫���ϰ�.Text = "";
            this.tb֫���ϰ�.Enabled = false;
        }
        #endregion

        private void ckbST_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbST, 9);
        }

        private void ckbST_KeyUp_1(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbST, 9);
            if (CheckValue(this.ckbST) == 8) { this.tb��̦����.Enabled = true; this.tb��̦����.Focus(); }
            else { this.tb��̦����.Text = ""; this.tb��̦����.Enabled = false; }

        }

        private void ckbST_MouseUp_1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbST) == 8) { this.tb��̦����.Enabled = true; this.tb��̦����.Focus(); }
            else { this.tb��̦����.Text = ""; this.tb��̦����.Enabled = false; }
        }

        private void ckbST_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbSZ, 9);
            if (CheckValue(this.ckbSZ) == 8)
            {
                this.tb��������.Enabled = true;
                this.tb��������.Focus();
            }
            else
            {
                this.tb��������.Enabled = false;
                this.tb��������.Text = "";
            }
        }

        private void ckbmx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbmx, 12);
        }

        private void ckbmx_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbmx, 12);
            if (CheckValue(this.ckbmx) == 11)
            {
                this.tb����.Enabled = true;
                this.tb����.Focus();
            }
            else
            {
                this.tb����.Enabled = false;
                this.tb����.Text = "";
            }
        }

        private void ckbmx_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbmx) == 11)
            {
                this.tb����.Enabled = true;
                this.tb����.Focus();
            }
            else
            {
                this.tb����.Enabled = false;
                this.tb����.Text = "";
            }
        }

        private void tb��ʳ�쳣_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ckbSM.Focus();
            }
        }

        private void tb��̦����_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ckbSZ.Focus();
            }
        }

        private void frmHLPG_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                showchange();
            }

        }
        //����
        private void button1_Click(object sender, System.EventArgs e)
        {
            Point pp = new Point(button1.Parent.Location.X + button1.Location.X, button1.Parent.Location.Y + button1.Location.Y + button1.Height);

            contextMenu1.Show(this, pp);
        }

        #region//ֻ���������ݺ͵�

        private void tb����_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != Convert.ToInt32('.'))
            {
                e.Handled = true;
            }
        }

        private void tb����_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void tb����_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void tbѪѹ_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 65 && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != Convert.ToInt32('/'))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void zy_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar == 27))
            {
                this.dg1.Visible = false;
            }

        }

        private void statusBar1_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
        {
            showchange();
        }

        private void mz_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar == 27))
            {
                this.dg1.Visible = false;
            }
        }

        private void jg_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar == 27))
            {
                this.dg1.Visible = false;
            }
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string sSql;

                sSql = "SELECT A.NAME,A.IN_DEPT_NAME,A.BED_NO,A.INPATIENT_NO,A.SEX_NAME," +
                    //"case when A.AGE>0 then ltrim(rtrim(convert(varchar,A.AGE)))+'��' else ltrim(rtrim(char((days(CURRENT DATE) - days(A.BIRTHDAY))/30)))||'����' end as AGE,"+
                    //ʹ���µ�������㺯��
                    " dbo.FUN_ZY_AGE(A.BIRTHDAY,0,getdate()) AGE, " +
                    " A.JSFS_NAME,A.IN_DATE,A.IN_DIAGNOSIS, " +
                    " C.HOME_STREET,C.RELATION_NAME,C.RELATION,C.RELATION_TEL,B.* " +
                    "  from vi_zy_vInpatient_all A LEFT JOIN ZY_ZYRYPG B ON A.INPATIENT_ID=B.INPATIENT_ID AND A.Baby_ID=B.Baby_ID," +
                    "       vi_zy_vInpatient C" +
                    " where A.INPATIENT_ID='" + ClassStatic.Current_BinID + "' and A.Baby_ID=0" +
                    "       AND C.INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                dt = InstanceForm.BDatabase.GetDataTable(sSql);
                if (dt == null || dt.Rows.Count == 0) return;
                dt.TableName = "tabRypg";
                ds.Tables.Add(dt);

                FrmReportView frmRptView = null;
                ParameterEx[] _parameters = new ParameterEx[1];

                _parameters[0].Text = "ҽԺ����";
                _parameters[0].Value = (new SystemCfg(0002)).Config;
                frmRptView = new FrmReportView(ds, Constant.ApplicationDirectory + "\\report\\ZYHS_��Ժ���߻�������.rpt", _parameters);
                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            try
            {
                FrmReportView frmRptView = null;
                ParameterEx[] _parameters = new ParameterEx[1];

                _parameters[0].Text = "ҽԺ����";
                _parameters[0].Value = (new SystemCfg(0002)).Config;
                frmRptView = new FrmReportView(null, Constant.ApplicationDirectory + "\\report\\ZYHS_�հ���Ժ���߻�������.rpt", _parameters);
                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeek_Click(object sender, System.EventArgs e)
        {
            if (txtInpatNo.Text.Trim() == "")
                txtInpatNo.Text = "0";

            string sSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY" +
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

            frmHLPG_Load(null, null);
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

        private void comboBox1_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ClassStatic.Current_BinID = new Guid(ClassStatic.MYTS_BinID[comboBox1.SelectedIndex].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);

            frmHLPG_Load(null, null);
        }

        private void panel3_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void contextMenu1_Popup(object sender, System.EventArgs e)
        {
            menuItem1.Enabled = !lb�½�.Visible;
        }

        private void bt�˳�_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}