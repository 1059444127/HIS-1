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

namespace ts_yp_pdlr
{
    /// <summary>
    /// FrmOptionData ��ժҪ˵����
    /// </summary>
    public class FrmOptionData : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button butok;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbpxfs;
        private System.Windows.Forms.ComboBox cmbypzlx;
        private System.Windows.Forms.ComboBox cmbyplx;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckBox chkyplx;
        private System.Windows.Forms.CheckBox chkypzlx;
        private System.Windows.Forms.CheckBox chkypjx;
        private System.Windows.Forms.CheckBox chkpxfs;
        private System.Windows.Forms.CheckBox chkkc;
        private System.Windows.Forms.ComboBox cmbypjx;
        public string ssql;
        public int _Deptid = 0;
        private MenuTag _menuTag;
        private string _chineseName;
        private ComboBox cmbck;
        private Label label3;
        private CheckBox chkkcdyl;
        public CheckBox chkmrz;
        private Form _mdiParent;
        private bool bpcgl = false;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn col_ͳ�����;
        private DataGridViewCheckBoxColumn col_ѡ��;
        private DataGridViewTextBoxColumn col_code;
        private TextBox txtHwh;
        private CheckBox chkHwh;
        public YpConfig ypconfig;

        public FrmOptionData(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);

            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            ypconfig = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptionData));
            this.panel1 = new System.Windows.Forms.Panel();
            this.butclose = new System.Windows.Forms.Button();
            this.butok = new System.Windows.Forms.Button();
            this.chkmrz = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_ͳ����� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ѡ�� = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkkcdyl = new System.Windows.Forms.CheckBox();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbypjx = new System.Windows.Forms.ComboBox();
            this.chkpxfs = new System.Windows.Forms.CheckBox();
            this.chkypjx = new System.Windows.Forms.CheckBox();
            this.chkypzlx = new System.Windows.Forms.CheckBox();
            this.chkyplx = new System.Windows.Forms.CheckBox();
            this.cmbpxfs = new System.Windows.Forms.ComboBox();
            this.chkkc = new System.Windows.Forms.CheckBox();
            this.cmbypzlx = new System.Windows.Forms.ComboBox();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkHwh = new System.Windows.Forms.CheckBox();
            this.txtHwh = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butok);
            this.panel1.Controls.Add(this.chkmrz);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 40);
            this.panel1.TabIndex = 0;
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(256, 8);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(80, 24);
            this.butclose.TabIndex = 1;
            this.butclose.Text = "ȡ��(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butok
            // 
            this.butok.Location = new System.Drawing.Point(168, 8);
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size(80, 24);
            this.butok.TabIndex = 0;
            this.butok.Text = "ȷ��(&O)";
            this.butok.Click += new System.EventHandler(this.butok_Click);
            // 
            // chkmrz
            // 
            this.chkmrz.ForeColor = System.Drawing.Color.Black;
            this.chkmrz.Location = new System.Drawing.Point(24, 8);
            this.chkmrz.Name = "chkmrz";
            this.chkmrz.Size = new System.Drawing.Size(176, 24);
            this.chkmrz.TabIndex = 5;
            this.chkmrz.Text = "���̴���Ĭ��Ϊ��";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(392, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(73, 32);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ѡ���λ";
            this.groupBox2.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 17);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(67, 12);
            this.treeView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 244);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHwh);
            this.groupBox1.Controls.Add(this.chkHwh);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.chkkcdyl);
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbypjx);
            this.groupBox1.Controls.Add(this.chkpxfs);
            this.groupBox1.Controls.Add(this.chkypjx);
            this.groupBox1.Controls.Add(this.chkypzlx);
            this.groupBox1.Controls.Add(this.chkyplx);
            this.groupBox1.Controls.Add(this.cmbpxfs);
            this.groupBox1.Controls.Add(this.chkkc);
            this.groupBox1.Controls.Add(this.cmbypzlx);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 244);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ѡ��";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ͳ�����,
            this.col_ѡ��,
            this.col_code});
            this.dataGridView1.Location = new System.Drawing.Point(353, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 15;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(201, 231);
            this.dataGridView1.TabIndex = 25;
            // 
            // col_ͳ�����
            // 
            this.col_ͳ�����.DataPropertyName = "ͳ�����";
            this.col_ͳ�����.HeaderText = "ͳ�����";
            this.col_ͳ�����.Name = "col_ͳ�����";
            // 
            // col_ѡ��
            // 
            this.col_ѡ��.DataPropertyName = "ѡ��";
            this.col_ѡ��.FalseValue = "0";
            this.col_ѡ��.HeaderText = "ѡ��";
            this.col_ѡ��.Name = "col_ѡ��";
            this.col_ѡ��.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_ѡ��.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_ѡ��.TrueValue = "1";
            this.col_ѡ��.Width = 45;
            // 
            // col_code
            // 
            this.col_code.DataPropertyName = "code";
            this.col_code.HeaderText = "code";
            this.col_code.Name = "col_code";
            this.col_code.Visible = false;
            // 
            // chkkcdyl
            // 
            this.chkkcdyl.ForeColor = System.Drawing.Color.Black;
            this.chkkcdyl.Location = new System.Drawing.Point(189, 172);
            this.chkkcdyl.Name = "chkkcdyl";
            this.chkkcdyl.Size = new System.Drawing.Size(176, 24);
            this.chkkcdyl.TabIndex = 24;
            this.chkkcdyl.Text = "ֻ��ȡ���������ҩƷ";
            this.chkkcdyl.CheckedChanged += new System.EventHandler(this.chkkcdyl_CheckedChanged);
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(120, 20);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(224, 20);
            this.cmbck.TabIndex = 22;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "�ֿ�����";
            // 
            // cmbypjx
            // 
            this.cmbypjx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbypjx.Enabled = false;
            this.cmbypjx.Location = new System.Drawing.Point(120, 93);
            this.cmbypjx.Name = "cmbypjx";
            this.cmbypjx.Size = new System.Drawing.Size(224, 20);
            this.cmbypjx.TabIndex = 13;
            // 
            // chkpxfs
            // 
            this.chkpxfs.ForeColor = System.Drawing.Color.Black;
            this.chkpxfs.Location = new System.Drawing.Point(24, 140);
            this.chkpxfs.Name = "chkpxfs";
            this.chkpxfs.Size = new System.Drawing.Size(80, 24);
            this.chkpxfs.TabIndex = 12;
            this.chkpxfs.Text = "����ʽ";
            this.chkpxfs.CheckedChanged += new System.EventHandler(this.chkypzlx_CheckedChanged);
            // 
            // chkypjx
            // 
            this.chkypjx.Enabled = false;
            this.chkypjx.ForeColor = System.Drawing.Color.Black;
            this.chkypjx.Location = new System.Drawing.Point(24, 91);
            this.chkypjx.Name = "chkypjx";
            this.chkypjx.Size = new System.Drawing.Size(80, 24);
            this.chkypjx.TabIndex = 11;
            this.chkypjx.Text = "ҩƷ����";
            this.chkypjx.CheckedChanged += new System.EventHandler(this.chkypzlx_CheckedChanged);
            // 
            // chkypzlx
            // 
            this.chkypzlx.Enabled = false;
            this.chkypzlx.ForeColor = System.Drawing.Color.Black;
            this.chkypzlx.Location = new System.Drawing.Point(24, 67);
            this.chkypzlx.Name = "chkypzlx";
            this.chkypzlx.Size = new System.Drawing.Size(88, 24);
            this.chkypzlx.TabIndex = 10;
            this.chkypzlx.Text = "ҩƷ������";
            this.chkypzlx.CheckedChanged += new System.EventHandler(this.chkypzlx_CheckedChanged);
            // 
            // chkyplx
            // 
            this.chkyplx.ForeColor = System.Drawing.Color.Black;
            this.chkyplx.Location = new System.Drawing.Point(24, 42);
            this.chkyplx.Name = "chkyplx";
            this.chkyplx.Size = new System.Drawing.Size(80, 24);
            this.chkyplx.TabIndex = 9;
            this.chkyplx.Text = "ҩƷ����";
            this.chkyplx.CheckedChanged += new System.EventHandler(this.chkypzlx_CheckedChanged);
            // 
            // cmbpxfs
            // 
            this.cmbpxfs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpxfs.Enabled = false;
            this.cmbpxfs.Items.AddRange(new object[] {
            "��λ��",
            "����",
            "����",
            "Ʒ��",
            "ƴ����"});
            this.cmbpxfs.Location = new System.Drawing.Point(120, 144);
            this.cmbpxfs.Name = "cmbpxfs";
            this.cmbpxfs.Size = new System.Drawing.Size(224, 20);
            this.cmbpxfs.TabIndex = 8;
            // 
            // chkkc
            // 
            this.chkkc.Checked = true;
            this.chkkc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkkc.ForeColor = System.Drawing.Color.Black;
            this.chkkc.Location = new System.Drawing.Point(24, 172);
            this.chkkc.Name = "chkkc";
            this.chkkc.Size = new System.Drawing.Size(176, 24);
            this.chkkc.TabIndex = 4;
            this.chkkc.Text = "ֻ��ȡ��治�������ҩƷ";
            this.chkkc.CheckedChanged += new System.EventHandler(this.chkkc_CheckedChanged);
            // 
            // cmbypzlx
            // 
            this.cmbypzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbypzlx.Enabled = false;
            this.cmbypzlx.Location = new System.Drawing.Point(120, 69);
            this.cmbypzlx.Name = "cmbypzlx";
            this.cmbypzlx.Size = new System.Drawing.Size(224, 20);
            this.cmbypzlx.TabIndex = 3;
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Enabled = false;
            this.cmbyplx.Location = new System.Drawing.Point(120, 45);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(224, 20);
            this.cmbyplx.TabIndex = 1;
            this.cmbyplx.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // chkHwh
            // 
            this.chkHwh.ForeColor = System.Drawing.Color.Black;
            this.chkHwh.Location = new System.Drawing.Point(24, 115);
            this.chkHwh.Name = "chkHwh";
            this.chkHwh.Size = new System.Drawing.Size(80, 24);
            this.chkHwh.TabIndex = 26;
            this.chkHwh.Text = "�� λ ��";
            this.chkHwh.CheckedChanged += new System.EventHandler(this.chkHwh_CheckedChanged);
            // 
            // txtHwh
            // 
            this.txtHwh.Enabled = false;
            this.txtHwh.Location = new System.Drawing.Point(120, 117);
            this.txtHwh.Name = "txtHwh";
            this.txtHwh.Size = new System.Drawing.Size(224, 21);
            this.txtHwh.TabIndex = 27;
            // 
            // FrmOptionData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(560, 284);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmOptionData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "��ȡ����";
            this.Load += new System.EventHandler(this.FrmOptionData_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void AddKw()
        {


        }

        private void FrmOptionData_Load(object sender, System.EventArgs e)
        {
            Yp.AddCmbYplx(false, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), this.cmbyplx, InstanceForm.BDatabase);
            cmbpxfs.SelectedIndex = 0;

            chkpxfs.Checked = true;


            string ssql = string.Format(" select name ͳ�����, 0 ѡ��,code from yp_tlfl ");
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            dataGridView1.DataSource = tb;
        }

        private void cmbyplx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cmbyplx.SelectedValue.GetType().ToString() != "System.Int32") return;
            int yplx = Convert.ToInt32(this.cmbyplx.SelectedValue);
            Yp.AddCmbYpzlx(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), yplx, this.cmbypzlx, InstanceForm.BDatabase);
            Yp.AddcmbYpjx(yplx, this.cmbypjx, InstanceForm.BDatabase);
        }

        private void chkypzlx_CheckedChanged(object sender, System.EventArgs e)
        {
            this.cmbyplx.Enabled = chkyplx.Checked == true ? true : false;
            this.cmbypzlx.Enabled = chkypzlx.Checked == true ? true : false;
            this.cmbypjx.Enabled = chkypjx.Checked == true ? true : false;
            this.chkypzlx.Enabled = chkyplx.Checked == true ? true : false;
            this.chkypjx.Enabled = chkyplx.Checked == true ? true : false;
            this.cmbpxfs.Enabled = chkpxfs.Checked == true ? true : false;
        }

        public string strtlName = ""; //ͳ�����

        private void butok_Click(object sender, System.EventArgs e)
        {
            string ssql = "";

            string strTlfl = "";
            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataRow[] rows = tb.Select(" ѡ�� = 1");
            for (int i = 0; i < rows.Length; i++)
            {
                if (i == 0)
                {
                    strTlfl += rows[i]["code"].ToString();
                    strtlName += rows[i]["ͳ�����"].ToString();
                }
                else
                {
                    strTlfl += "," + rows[i]["code"].ToString();
                    strtlName += "," + rows[i]["ͳ�����"].ToString();
                }
            }

            if (strTlfl != "")
            {
                strTlfl = " and b.tlfl in ( " + strTlfl + ") ";
            }

            if (ypconfig.�̴淽ʽ == "1")
            {
                ssql = @"select 0 ���,B.yppm Ʒ��,b.ypspm ��Ʒ��,b.ypgg ���,
                    dbo.fun_yp_sccj(b.sccj) ����,
                    cast(round(b.pfj/a.dwbl,4) as decimal(15,4)) ������
                    ,0.00 �������,0 ����,
                    cast(round(b.lsj/a.dwbl,4) as decimal(15,4)) ���ۼ�,null ����,
                    hwmc ��λ,
                   cast(kcl as float) ��������,cast(round(b.lsj*kcl/a.dwbl,2) as decimal(15,2)) ������,";
                if (InstanceForm.BCurrentDept.DeptId == 207 || InstanceForm.BCurrentDept.DeptId == 424)
                {
                    ssql = ssql + " '0' as ��ҩ�����,";
                }


                if (chkmrz.Checked == false)
                    ssql = ssql + "   cast(kcl as float) �̴�����,s_ypdw ��λ,dbo.fun_yp_ypdw(a.zxdw) ��λ,round(kcl*(lsj/dwbl),2) �̴���,";
                else
                    ssql = ssql + "   0.0 �̴�����,dbo.fun_yp_ypdw(a.zxdw) ��λ,  0.00 �̴���,";

                ssql = ssql + @" 0.00 ӯ������,0.00 ӯ����� ,b.shh ����,
                 a.cjid,dbo.FUN_GETEMPTYGUID()  kcid,a.dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id,'' ���� 
                      ,'1900-1-1' Ч�� ,'' ���κ� ,dbo.fun_yp_yplx(yplx) ҩƷ����,s_ypjx ����,
                    (case when cast(kcl/a.dwbl as int)<>0 then cast(cast(kcl/a.dwbl as bigint) AS varchar(50))+rtrim(s_ypdw) else '' end )+(case when kcl%a.dwbl<>0 then cast(cast(kcl%a.dwbl AS float) as varchar(50))+dbo.fun_yp_ypdw(a.zxdw) else '' end ) ��������2,
                    (case when cast(kcl/a.dwbl as int)<>0 then cast(cast(kcl/a.dwbl as bigint) AS varchar(50))+rtrim(s_ypdw) else '' end )+(case when kcl%a.dwbl<>0 then cast(cast(kcl%a.dwbl AS float) as varchar(50))+dbo.fun_yp_ypdw(a.zxdw) else '' end ) �̴�����2
                   from ";

                ssql = ssql + " (select  ggid,CJID,SUM(kcl) as kcl,DWBL,ZXDW from yf_pdtemp where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + "  and  shbz=0  and ( bdelete=0 or kcl<>0) group by  ggid,CJID,dwbl,zxdw ) a ";

                ssql = ssql + " inner join vi_yp_ypcd b  "
                + " on a.cjid=b.cjid  "
                + " left join yp_hwsz c on b.ggid=c.ggid and c.deptid="
                + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"))
                + " and c.bscbz=0 "
                + " where  a.cjid not in(select cjid from yf_pdcsmx_kcmx a,yf_pdcs b where"
                + " a.djid=b.id and a.deptid="
                + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"))
                + " and shbz=0 and bdelete=0 ) ";


            }
            else//�����ο��
            {
                ssql = @"select 0 ���,B.yppm Ʒ��,b.ypspm ��Ʒ��,b.ypgg ���,
                    dbo.fun_yp_sccj(b.sccj) ����,cast(round(b.pfj/a.dwbl,4) as decimal(15,4)) ������
                    ,0.00 �������,cast(round(a.jhj/a.dwbl,4) as decimal(15,4)) ����,
                    cast(round(b.lsj/a.dwbl,4) as decimal(15,4)) ���ۼ�,a.ypph ����,hwmc ��λ, 
                    cast(kcl as float) ��������,cast(round(b.lsj*kcl/a.dwbl,2) as decimal(15,2)) ������,";
                if (chkmrz.Checked == false)
                    ssql = ssql + "   cast(kcl as float) �̴�����,dbo.fun_yp_ypdw(a.zxdw) ��λ,round(kcl*(lsj/dwbl),2) �̴���,";
                else
                    ssql = ssql + "   0.0 �̴�����,dbo.fun_yp_ypdw(a.zxdw) ��λ,  0.00 �̴���,";
                ssql = ssql + @" 0.00 ӯ������,0.00 ӯ����� ,b.shh ����, 
                   a.cjid,a.kcid,a.dwbl,kwid,dbo.FUN_GETEMPTYGUID() id,'' ���� 
                    ,a.yppch ���κ�,a.ypxq Ч�� ,dbo.fun_yp_yplx(yplx) ҩƷ����,s_ypjx ����,
                    (case when cast(kcl/a.dwbl as int)<>0 then cast(cast(kcl/a.dwbl as bigint) AS varchar(50))+rtrim(s_ypdw) else '' end )+(case when kcl%a.dwbl<>0 then cast(cast(kcl%a.dwbl AS float) as varchar(50))+dbo.fun_yp_ypdw(a.zxdw) else '' end ) ��������2
                   from yf_pdtemp a inner join vi_yp_ypcd b  "
             + " on a.cjid=b.cjid and deptid="
             + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"))
             + " and a.shbz=0  and (a.bdelete=0 or a.kcl<>0)  "
             + " left join yp_hwsz c on b.ggid=c.ggid and c.deptid="
             + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"))
             + " and c.bscbz=0 "
             + " where  a.kcid not in(select kcid from yf_pdcsmx a,yf_pdcs b where"
             + " a.djid=b.id and a.deptid="
             + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"))
             + " and shbz=0 and bdelete=0 ) ";
            }


            if (strTlfl != "")
            {
                ssql += strTlfl;
            }


            if (this.chkyplx.Checked == true)
            {
                int yplx = Convert.ToInt32(this.cmbyplx.SelectedValue);
                ssql = ssql + " and b.yplx=" + yplx;
            }
            if (this.chkypzlx.Checked == true)
            {
                int ypzlx = Convert.ToInt32(this.cmbypzlx.SelectedValue);
                ssql = ssql + " and b.ypzlx=" + ypzlx;
            }
            if (this.chkypjx.Checked == true)
            {
                int ypjx = Convert.ToInt32(this.cmbypjx.SelectedValue);
                ssql = ssql + " and b.ypjx=" + ypjx;
            }
            if (chkHwh.Checked && (!string.IsNullOrEmpty(txtHwh.Text.Trim())))//ǰ����λ����ȡ�̴����� add by jchl
            {
                ssql = ssql + " and c.hwmc like '" + txtHwh.Text.Replace("'","''").Replace("%","[%]").Replace("_","[_]") + "%'";
            }
            if (this.chkkc.Checked == true)
            {
                ssql = ssql + " and kcl<>0 ";
            }
            if (this.chkkcdyl.Checked == true)
            {
                ssql = ssql + " and kcl=0 ";
            }

            if (this.chkpxfs.Checked == true)
            {
                if (this.cmbpxfs.SelectedIndex == 0)
                    this.ssql = ssql + " order by hwmc,yplx,ypjx,a.ggid,a.cjid ";
                if (this.cmbpxfs.SelectedIndex == 1)
                    this.ssql = ssql + " order by yplx,ypzlx,shh,a.cjid";
                if (this.cmbpxfs.SelectedIndex == 2)
                    this.ssql = ssql + "order by yplx,ypzlx,ypjx,shh,a.cjid";
                if (this.cmbpxfs.SelectedIndex == 3)
                    this.ssql = ssql + "order by b.s_yppm,a.ggid ";
                if (this.cmbpxfs.SelectedIndex == 4)
                    this.ssql = ssql + "order by b.pym,a.ggid";
            }
            else
            {
                this.ssql = ssql + " order by yplx,ypzlx,ypjx,shh,a.cjid ";
            }

            _Deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));

            this.Close();
        }

        private void butclose_Click(object sender, System.EventArgs e)
        {

            this.ssql = "";
            _Deptid = 0;
            this.Close();
        }

        private void chkkcdyl_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkkc.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkkc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkkcdyl.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
        }

        private void chkHwh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = sender as CheckBox;

                if (chk.Checked)
                {
                    txtHwh.Enabled = true;
                    txtHwh.Focus();
                }
                else
                {
                    txtHwh.Text = "";
                    txtHwh.Enabled = false;
                }
            }
            catch { }
        }

    }
}
