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

namespace ts_zyhs_cwyl
{
    /// <summary>
    /// Form4 ��ժҪ˵����
    /// </summary>
    public class frmFM : System.Windows.Forms.Form
    {
        //�û��������		
        private BaseFunc myFunc;
        private int current_row = 0;
        private string sName = "";

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbMonther;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bt�޸�;
        private System.Windows.Forms.Button btɾ��;
        private System.Windows.Forms.Button bt����;
        private System.Windows.Forms.CheckBox cbCWF;
        /// <summary>
        /// �Ƿ����������Ƶ���
        /// </summary>
        private int _istszl = 0;
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmFM()
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //

            myFunc = new BaseFunc();
        }
        public frmFM(int istszl)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            _istszl = istszl;
            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //

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
            this.panel3 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbCWF = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bt�޸� = new System.Windows.Forms.Button();
            this.lbMonther = new System.Windows.Forms.Label();
            this.btɾ�� = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.bt���� = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 341);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 189);
            this.panel3.TabIndex = 1;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "Ӥ����Ϣ";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.RowHeadersVisible = false;
            this.myDataGrid1.Size = new System.Drawing.Size(544, 184);
            this.myDataGrid1.TabIndex = 57;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.cbCWF);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.bt�޸�);
            this.panel2.Controls.Add(this.lbMonther);
            this.panel2.Controls.Add(this.btɾ��);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.bt����);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 152);
            this.panel2.TabIndex = 0;
            // 
            // cbCWF
            // 
            this.cbCWF.Checked = true;
            this.cbCWF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCWF.Location = new System.Drawing.Point(288, 56);
            this.cbCWF.Name = "cbCWF";
            this.cbCWF.Size = new System.Drawing.Size(160, 16);
            this.cbCWF.TabIndex = 60;
            this.cbCWF.Text = "�Զ����ɴ�λ�ѳ����˵�";
            this.cbCWF.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "��",
            "Ů"});
            this.comboBox1.Location = new System.Drawing.Point(80, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 20);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyUp);
            // 
            // bt�޸�
            // 
            this.bt�޸�.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt�޸�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�޸�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�޸�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�޸�.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt�޸�.ImageIndex = 0;
            this.bt�޸�.Location = new System.Drawing.Point(464, 80);
            this.bt�޸�.Name = "bt�޸�";
            this.bt�޸�.Size = new System.Drawing.Size(64, 24);
            this.bt�޸�.TabIndex = 58;
            this.bt�޸�.Text = "�޸�(&X)";
            this.bt�޸�.UseVisualStyleBackColor = false;
            this.bt�޸�.Click += new System.EventHandler(this.bt�޸�_Click);
            // 
            // lbMonther
            // 
            this.lbMonther.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMonther.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbMonther.Location = new System.Drawing.Point(8, 8);
            this.lbMonther.Name = "lbMonther";
            this.lbMonther.Size = new System.Drawing.Size(440, 40);
            this.lbMonther.TabIndex = 57;
            this.lbMonther.Text = "ĸ����Ϣ��";
            // 
            // btɾ��
            // 
            this.btɾ��.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btɾ��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btɾ��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btɾ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btɾ��.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btɾ��.ImageIndex = 0;
            this.btɾ��.Location = new System.Drawing.Point(464, 48);
            this.btɾ��.Name = "btɾ��";
            this.btɾ��.Size = new System.Drawing.Size(64, 24);
            this.btɾ��.TabIndex = 56;
            this.btɾ��.Text = "ɾ��(&D)";
            this.btɾ��.UseVisualStyleBackColor = false;
            this.btɾ��.Click += new System.EventHandler(this.btɾ��_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(464, 112);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 54;
            this.btCancel.Text = "�˳�(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            // 
            // bt����
            // 
            this.bt����.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt����.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt����.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt����.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt����.ImageIndex = 0;
            this.bt����.Location = new System.Drawing.Point(464, 16);
            this.bt����.Name = "bt����";
            this.bt����.Size = new System.Drawing.Size(64, 24);
            this.bt����.TabIndex = 53;
            this.bt����.Text = "����(&F)";
            this.bt����.UseVisualStyleBackColor = false;
            this.bt����.Click += new System.EventHandler(this.bt����_Click);
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
            this.button3.Location = new System.Drawing.Point(456, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 136);
            this.button3.TabIndex = 55;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "�Ա�";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 120);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "������";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(80, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(184, 21);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2004, 7, 27, 0, 0, 0, 0);
            this.dateTimePicker1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "����ʱ�䣺";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmFM
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(544, 341);
            this.Controls.Add(this.panel1);
            this.Name = "frmFM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "����";
            this.Load += new System.EventHandler(this.frmFM_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        SystemCfg cfg7205 = new SystemCfg(7205);

        private void frmFM_Load(object sender, System.EventArgs e)
        {
            // yaokx  2014-06-23¦���п���ҽԺ����Щ����סԺʱ�䳤,����ԭ���������ַ��� 
            //1 ҽԺ�ṩ��ͬ�ĳԷ��ײͣ� ��������
            //2 ҽԺ�ṩ���ಡ��һЩ���⻤�� �������
            if (cfg7205.Config == "1")
            {
                label1.Visible = false;
                dateTimePicker1.Visible = false;
              
                comboBox1.Enabled = false;
                label2.Text = "��������";
                cbCWF.Checked = false;
                cbCWF.Visible = false;
                bt����.Text="����";
                btɾ��.Visible = false;
                bt�޸�.Visible = false;
                this.textBox1.Enabled = false;
            }
            else
            {
                label1.Visible = true;
                dateTimePicker1.Visible = true;
           
                comboBox1.Enabled = true;
                cbCWF.Checked = true;
                cbCWF.Visible = true;
                btɾ��.Visible = true;
                bt�޸�.Visible = true;
                this.textBox1.Enabled = true;
            }


            //����Ƿ񸾲��ƣ�����������˳�
            bool isFCK = myFunc.IsFCK();
            //add by zouchihua 2012-5-18 ��������
            if (_istszl == 1)
                isFCK = true;
            if (isFCK == false && cfg7205.Config == "0")
            {
                MessageBox.Show("�Բ��𣬵�ǰ�������Ǹ����ƣ�����¼�������Ϣ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }

            string sSql = "Select name,bed_no,inpatient_no,in_date,SEX_NAME from vi_zy_vinpatient_bed where baby_id=0 and inpatient_id='" + ClassStatic.Current_BinID + "'";
            DataTable tempTb = FrmMdiMain.Database.GetDataTable(sSql);
            this.dateTimePicker1.MinDate = Convert.ToDateTime(tempTb.Rows[0]["in_date"]);
            this.dateTimePicker1.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortDateString() + " 23:59:59");
            this.dateTimePicker1.Value = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);

            this.sName = tempTb.Rows[0]["name"].ToString().Trim();
            this.lbMonther.Text = "���ţ�" + tempTb.Rows[0]["bed_no"].ToString().Trim() + "�� ������" + this.sName + "��סԺ�ţ�" + tempTb.Rows[0]["inpatient_no"].ToString().Trim();

            this.Show_Date();

            string[] GrdMappingName ={ "��������", "����", "�Ա�", "Ӥ����", "¼�뻤ʿ", "¼��ʱ��", "BABY_ID", "BOOK_OPER" };
            int[] Alignment ={ 0, 0, 1, 1, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0 };
            this.dateTimePicker1.Focus();
            if (cfg7205.Config == "1")
            {
                int[] GrdWidth ={ 0, 14, 4, 0, 8, 19, 0, 0 };
                this.textBox1.Text = sName + "��";
                int sexindex = 1;
                if (tempTb.Rows[0]["SEX_NAME"].ToString().Trim() == "Ů")
                {
                    sexindex = 2;
                }else if(tempTb.Rows[0]["SEX_NAME"].ToString().Trim() == "δ֪")
                {
                     sexindex=9;
                }
                this.Text = "���ø���";
                this.myDataGrid1.CaptionText = "���˸�����Ϣ";
                comboBox1.SelectedIndex = sexindex;
                myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);
            }
            else
            {
                int[] GrdWidth ={ 19, 14, 4, 6, 8, 19, 0, 0 };
                this.textBox1.Text = sName + "ëë";//+this.comboBox1.SelectedItem;
                myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);
            }
          //  this.comboBox1.SelectedIndex = 0;

        }

        private void Show_Date()
        {
            string sSql = "select BIRTHDAY �������� ,BABYNAME ����,c.name �Ա�,BABY_NO Ӥ����,dbo.FUN_ZY_SEEKEMPLOYEENAME(BOOK_OPER) ¼�뻤ʿ ,BOOK_DATE ¼��ʱ��,BABY_ID,BOOK_OPER" +
                        "  from zy_inpatient_baby a LEFT JOIN JC_SEXCODE c ON convert(varchar,a.SEX)=c.CODE" +
                        " where a.inpatient_id='" + ClassStatic.Current_BinID + "'" +
                        " order by BIRTHDAY";
            myFunc.ShowGrid(0, sSql, this.myDataGrid1);
            current_row = myFunc.SelRow(this.myDataGrid1);
            if (current_row == -1)
            {
                this.btɾ��.Enabled = false;
                this.bt�޸�.Enabled = false;
            }
            else
            {
                this.btɾ��.Enabled = true;
                this.bt�޸�.Enabled = true;
            }
        }

        private void dateTimePicker1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == 13)
            {
                this.comboBox1.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "" || this.textBox1.Text.Trim() == sName + "֮��" || this.textBox1.Text.Trim() == sName + "֮Ů")
            {
                this.textBox1.Text = sName + "֮" + this.comboBox1.SelectedItem;
            }
            this.textBox1.Focus();
            this.textBox1.SelectAll();
        }

        private void comboBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == 13)
            {
                this.comboBox1_SelectedIndexChanged(sender, e);
            }
        }

        private void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == 13)
            {
                this.bt����.Focus();
            }
        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }


        private void bt����_Click(object sender, System.EventArgs e)
        {
            int current_no = 0;

            int CWF = cbCWF.Checked ? 0 : 1;
            if (cfg7205.Config == "0")
            {

                if (this.textBox1.Text.Trim() == "")
                {
                    MessageBox.Show(this, "�Բ���������Ӥ��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBox1.Focus();
                    return;
                }

                if (this.textBox1.Text.Trim() == sName)
                {
                    MessageBox.Show(this, "�Բ���Ӥ�������������ĸ�׵�������ͬ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBox1.Focus();
                    return;
                }

                if (this.current_row != -1)
                {
                    if (MessageBox.Show(this, sName + "�Ѿ��������ȷ�ϻ�������", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                    string sSql = "Select max(baby_no)  as max_no from zy_inpatient_baby where inpatient_id='" + ClassStatic.Current_BinID + "'";
                    DataTable tempTb = FrmMdiMain.Database.GetDataTable(sSql);
                    current_no = Convert.ToInt16(tempTb.Rows[0]["max_no"]);

                    sSql = "Select babyname from zy_inpatient_baby where inpatient_id='" + ClassStatic.Current_BinID + "' and rtrim(babyname)='" + this.textBox1.Text.Trim() + "'";
                    DataTable tempTb1 = FrmMdiMain.Database.GetDataTable(sSql);
                    if (tempTb1.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "�Բ���" + sName + "�Ѿ���������С�" + this.textBox1.Text.Trim() + "����Ӥ����������Ӥ��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.textBox1.Focus();
                        return;
                    }
                    //add by zouchihua 2012-10-1 ����ѡ���Ա�
                    if (comboBox1.Text.Trim() == "")
                    {
                        MessageBox.Show(this, "�Բ�������ѡ�����Ӥ�����Ա�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.comboBox1.Focus();
                        return;
                    }
                    //string xx = "��������" + textBox1.Text.Trim() + " ��";
                    // xx += "\r�Ա𣺡�" + comboBox1.Text.Trim() + " ��";
                    //if (MessageBox.Show(this, sName + "ȷ�Ϸ�����\r����Ӥ����Ϣ���£�\r" + xx, "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    //    return;
                }
                else
                {
                    //add by zouchihua 2012-10-1 ����ѡ���Ա�
                    if (comboBox1.Text.Trim() == "")
                    {
                        MessageBox.Show(this, "�Բ�������ѡ�����Ӥ�����Ա�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.comboBox1.Focus();
                        return;
                    }
                    string xx = "��������" + textBox1.Text.Trim() + " ��";
                    xx += "\r�Ա𣺡�" + comboBox1.Text.Trim() + " ��";
                    if (MessageBox.Show(this, sName + "ȷ�Ϸ�����\r����Ӥ����Ϣ���£�\r" + xx, "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
                current_no += 1;
            }
            else
            {
               string sSql = "Select babyname from zy_inpatient_baby where inpatient_id='" + ClassStatic.Current_BinID + "' and rtrim(babyname)='" + this.textBox1.Text.Trim() + "'";
                DataTable tempTb1 = FrmMdiMain.Database.GetDataTable(sSql);
                if (tempTb1.Rows.Count > 0)
                {
                    MessageBox.Show(this, "�Բ���" + sName + "�Ѿ����ڸø������ƣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
           
            //����
            string _outmsg = myFunc.ChildBearing("", 1, CWF, ClassStatic.Current_BinID, current_no, this.comboBox1.Text.Trim(), this.textBox1.Text.Trim(),FrmMdiMain.CurrentUser.EmployeeId, this.dateTimePicker1.Value, FrmMdiMain.Jgbm);

            if (_outmsg.Trim() != "")
            {
                MessageBox.Show(_outmsg);
            }

            //д��־ Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "����", sName + "�������С�" + this.textBox1.Text.Trim() + "����Ӥ��", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            this.Show_Date();
        }

        private void btɾ��_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            string sBaby_ID = myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["BABY_ID"].ToString().Trim();

            //Modify By Tany 2004-12-13
            //			if (ClassStatic.Static_EmployeeID!=myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["BOOK_OPER"].ToString().Trim())
            //			{
            //				MessageBox.Show(this,"�Բ�����û��ɾ��������¼��Ȩ����", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 				
            //				return;		
            //			}

            //�Ƿ���ҽ�����Ƿ�ת����
            string sSql = "select * from ( " +
                        " Select Order_ID,0 id1,dbo.fun_getemptyguid() id2 from zy_orderrecord a" +
                        "  where status_flag<>5 and delete_bit=0 and a.INPATIENT_ID='" + ClassStatic.Current_BinID + "' and a.Baby_ID=" + Convert.ToInt32(sBaby_ID) +
                //				        " union "+
                //						" Select 0,ID,0 from zy_fee_speci b"+
                //				        "  where b.INPATIENT_ID="+ClassStatic.Current_BinID+ " and b.Baby_ID="+ Convert.ToInt32(sBaby_ID) + 			
                        " union " +
                        " Select Order_ID,0,c.id from ZY_TRANSFER_dept c" +
                        "   where c.INPATIENT_ID='" + ClassStatic.Current_BinID + "' and c.Baby_ID=" + Convert.ToInt32(sBaby_ID) +
                        " ) tmp ";
            DataTable tempTb1 = FrmMdiMain.Database.GetDataTable(sSql);
            if (tempTb1.Rows.Count > 0)
            {
                MessageBox.Show(this, "�Բ��𣬸�Ӥ����δͣ��ҽ����ת�Ƽ�¼��������ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //�Ƿ��з��� ����ͳ�� Add By Tany 2005-03-14
            sSql = "Select sum(acvalue) from ZY_FEE_SPECI" +
                " where delete_bit=0 and charge_bit=1 and INPATIENT_ID='" + ClassStatic.Current_BinID + "' and Baby_ID=" + Convert.ToInt32(sBaby_ID);
            string fee = Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sSql), "");
            if (fee != "0" && fee != "")
            {
                MessageBox.Show(this, "�Բ��𣬸�Ӥ���ܷ��ò�Ϊ0��������ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(this, "ȷ��ɾ����" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["����"].ToString().Trim() + "���ļ�¼��", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //ɾ��Ӥ����¼������ĸ�׵�ĸӤͬ��
            string _outmsg = myFunc.ChildBearing("", 2, 1, ClassStatic.Current_BinID, Convert.ToInt16(sBaby_ID), "", "",FrmMdiMain.CurrentUser.EmployeeId, this.dateTimePicker1.Value, FrmMdiMain.Jgbm);

            if (_outmsg.Trim() != "")
            {
                MessageBox.Show(_outmsg);
            }

            //д��־ Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "ɾ��Ӥ��", "ɾ��" + sName + "��Ӥ����" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["����"].ToString().Trim() + "���ļ�¼", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            this.Show_Date();
        }

        private void bt�޸�_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            string sBaby_ID = myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["BABY_ID"].ToString().Trim();

            //Modify By Tany 2004-12-13
            //			if (ClassStatic.Static_EmployeeID!=myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["BOOK_OPER"].ToString().Trim())
            //			{
            //				MessageBox.Show(this,"�Բ�����û���޸ĸ�����¼��Ȩ����", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 				
            //				return;		
            //			}

            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show(this, "�Բ���������Ӥ��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Focus();
                return;
            }
            //add by zouchihua 2012-10-1 ����ѡ���Ա�
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show(this, "�Բ�������ѡ�����Ӥ�����Ա�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.comboBox1.Focus();
                return;
            }
            if (this.textBox1.Text.Trim() == sName)
            {
                MessageBox.Show(this, "�Բ���Ӥ�������������ĸ�׵�������ͬ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Focus();
                return;
            }

            string sMsg = "";
            string OperContens = "��" + sName + "��Ӥ����" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["����"].ToString().Trim() + "��";
            if (this.dateTimePicker1.Value.ToString() != myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["��������"].ToString().Trim())
            {
                sMsg = "���������ڡ��ɡ�" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["��������"].ToString().Trim() + "����Ϊ��" + this.dateTimePicker1.Value.ToString() + "��";
                OperContens += "���������ڡ��ɡ�" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["��������"].ToString().Trim() + "����Ϊ��" + this.dateTimePicker1.Value.ToString() + "��";
            }
            if (this.comboBox1.Text.Trim() != myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["�Ա�"].ToString().Trim())
            {
                sMsg += sMsg == "" ? "" : "��";
                sMsg += "���Ա��ɡ�" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["�Ա�"].ToString().Trim() + "����Ϊ��" + this.comboBox1.Text.Trim() + "��";
                OperContens += "���Ա��ɡ�" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["�Ա�"].ToString().Trim() + "����Ϊ��" + this.comboBox1.Text.Trim() + "��";
            }
            if (this.textBox1.Text.Trim() != myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["����"].ToString().Trim())
            {
                sMsg += sMsg == "" ? "" : "��";
                sMsg += "���������ɡ�" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["����"].ToString().Trim() + "����Ϊ��" + this.textBox1.Text.Trim() + "��";
                OperContens += "���������ɡ�" + myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["����"].ToString().Trim() + "����Ϊ��" + this.textBox1.Text.Trim() + "��";
            }
           
            if (sMsg == "") return;
            if (MessageBox.Show(this, "ȷ��" + sMsg + "��", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //�޸�
            string _outmsg = myFunc.ChildBearing("", 3, 1, ClassStatic.Current_BinID, Convert.ToInt16(myTb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["BABY_ID"]), this.comboBox1.Text.Trim(), this.textBox1.Text.Trim(),FrmMdiMain.CurrentUser.EmployeeId, this.dateTimePicker1.Value, FrmMdiMain.Jgbm);

            if (_outmsg.Trim() != "")
            {
                MessageBox.Show(_outmsg);
            }

            //д��־ Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "�޸�Ӥ����Ϣ", OperContens, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            this.Show_Date();
        }
    }
}
