using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TszyHIS;
using HospitalManage.Services;
using TrasenHIS.BLL;

namespace ts_zyhs_yzgl
{
    /// <summary>
    /// ҽ������ ��ժҪ˵����
    /// </summary>
    public class frmYZGL : System.Windows.Forms.Form
    {

        /// <summary>
        /// ����������������
        /// </summary>
        /// 


        //�Զ������==============================================		
        private BaseFunc myFunc;

        string binSql = "";
        bool isSSMZ = false;
        bool isTSZL = false;//Modify By tany 2010-03-10
        bool isCX = false;//�Ƿ��ѯ
        int ssmzType = 0;//0=���� 1=����
        string sPaint = "", sPaintPS = "", sPaintWZX = "", sName = "";
        int max_len0 = 0, max_len1 = 0, max_len2 = 0;//���ҽ������,���ҽ������(��������λ��),���������λ����		
        decimal orderfee = 0;
        /// <summary>
        /// ��ʿվҽ�������Ƿ�������ǰҽ����ӡ 0=����,1=��
        /// </summary>
        SystemCfg cfg7111;
        SystemCfg cfg7129;
        SystemCfg cfg7160 = new SystemCfg(7160);//�������ڿ��ҿ��߳�Ժҽ���󣬲������ڽ��е��������ƿ����Ƿ���Խ��г���������0����1����
        SystemCfg cfg7159 = new SystemCfg(7159);
        /// <summary>
        /// ҽ�����˵�Ƿ�ѿ����Ƿ���ҽ��ʵʱ����������Ƿ�ѿ���  0=�� 1=��
        /// </summary>
        SystemCfg cfg7186 = new SystemCfg(7186);

        //Add By Tany 2015-05-04
        string functionName = "";

        //Add By Tany 2015-11-17
        DateTime sysDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd"));

        private TheReportDateSet rds = new TheReportDateSet();
        private DataRow dr;
        private Panel ReasenPanel;
        private System.Windows.Forms.Panel panel��;
        private System.Windows.Forms.Panel panel��;
        private System.Windows.Forms.Panel panel����;
        private System.Windows.Forms.Panel panel����;
        private System.Windows.Forms.Button bt��ϸ��Ϣ;
        private System.Windows.Forms.Button btҽ����ӡ;
        private System.Windows.Forms.Button bt����ִ��;
        private System.Windows.Forms.Button bt�˳�;
        private �۸���Ϣ.PriceInfo priceInfo1;
        private ������Ϣ.PatientInfo patientInfo1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private DataGridEx myDataGrid3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.Button btδִ��;
        private System.Windows.Forms.Button bt����;
        private System.Windows.Forms.Button bt����;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btȡ��ͣҽ���˶�;
        private System.Windows.Forms.Button btȡ��ͣҽ��ת��;
        private System.Windows.Forms.Button btȡ����ҽ���˶�;
        private System.Windows.Forms.Button btȡ����ҽ��ת��;
        private System.Windows.Forms.Button bt��ʾ�л�;
        private System.Windows.Forms.Button btȫѡ;
        private System.Windows.Forms.Button bt��ѡ;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ContextMenu contextMenu2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbIn;
        private System.Windows.Forms.RadioButton rbOut;
        private System.Windows.Forms.ComboBox cmbWard;
        private System.Windows.Forms.RadioButton rbTempOut;
        private System.Windows.Forms.RadioButton rb��ʾ�����б�;
        private System.Windows.Forms.RadioButton rb���ز����б�;
        private System.Windows.Forms.Button btִ��ʱ��;
        private ContextMenu contextMenu3;
        private MenuItem menuItem7;
        private MenuItem menuItem8;
        private MenuItem menuItem9;
        private Button btԤ��;
        private Button butorderprint;
        private RadioButton rbTszl;
        private RadioButton rbTrans;
        private SplitContainer splitContainer1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ContextMenuStrip contextMenuSerch;
        private ToolStripMenuItem ��ѯToolStripMenuItem;
        private Button btnSqyzdy;
        private ContextMenuStrip contextMenuSqm;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem ȡ��˫ǩ��ToolStripMenuItem;
        private ImageList imageList1;
        private Button BtnTszlZcQm;
        private ToolStripMenuItem ɾ��ִ��ʱ��ToolStripMenuItem;
        private IContainer components;
        private Button btnCheck;
        private ToolStripMenuItem ����ǩ��ToolStripMenuItem;
        private ContextMenuStrip contextMenuSP;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private TabControl tabControl2;
        private TabPage tabPage5;
        private TabPage tabPage10;
        private UCWzxm ucWzxm1;
        private RadioButton rbTkxs;

        private Panel panel5;
        private Trasen.Controls.ShowCardComponent showCardComponent1;
        private Trasen.Controls.LabelTextBox txt_yz;
        private CheckBox che_yz;
        private CheckBox che_date;
        private ComboBox cmb_date;
        private TabControl tabControl1;
        private UcShowCard ucShowCard1;
        private Label label4;
        private CheckBox chkWardOrder;
        private CheckBox chkShowAllSMYz;

        //add by jchl(pivas �Ƿ��󷽲��ܷ����ж�)
        string cfg7605 = new SystemCfg(7605).Config;
        string cfg7602 = new SystemCfg(7602).Config;
        private Button btSsmzwc;
        private Label lblSsMzFee;
        private Label label5;
        private Label label6;
        private CheckBox chkSsyz;
        private Panel panel6;
        private CheckBox chkGwyp;

        /// <summary>
        /// ������������ҩ
        /// </summary>
        private bool zczyz_notfy = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_formText">����</param>
        /// <param name="_isTszl">�Ƿ���������0=����1=��</param>
        public frmYZGL(string _formText, int _isTszl)
        {
            isSSMZ = false;

            isTSZL = _isTszl == 0 ? false : true;
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
            if (!isTSZL)
            {
                //binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                //    "   FROM vi_zy_vInpatient_Bed " +
                //    "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY dbo.Fun_GetBedToOrder( (case when left( bed_no,1)='+' then '999'+ bed_no else  bed_no end) ),Baby_ID";
                binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                  "   FROM vi_zy_vInpatient_Bed " +
                  "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            else
            {
                binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS סԺ�� " +
                    "   FROM vi_zy_vInpatient_Bed " +
                    "  WHERE inpatient_id in (select inpatient_id from ZY_TS_APPLY where status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002) and (ts_dept = " + InstanceForm.BCurrentDept.DeptId + " or ts_dept in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))) " +
                    "  ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            LoadWard();

            if (!isSSMZ && !isCX && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);

            if (isTSZL)
            {
                rbTszl.Checked = true;

                rbIn.Enabled = false;
                rbOut.Enabled = false;
                rbTempOut.Enabled = false;
                rbTrans.Enabled = false;
                //add by zouchihua 2012-4-27 �������Ʋ���ת��ǩ��
                if (rbTszl.Checked)
                    this.BtnTszlZcQm.Visible = true;
                else
                    this.BtnTszlZcQm.Visible = false;
            }
            //�˶�ǩ��
            if (isTSZL || isSSMZ)
            {
                btnCheck.Visible = true;
            }
            else
                btnCheck.Visible = false;
        }


        /// <summary>
        /// �������ˣ�ֻ�ܳ���ҩƷ�����Ҳ��������� add by zouchihua 2013-9-11
        /// </summary>
        /// <param name="_formText">����</param>
        /// <param name="_isTszl">�Ƿ���������0=����1=��</param>
        public frmYZGL(string _formText, int _isTszl, bool _zczyz)
        {
            isSSMZ = false;
            zczyz_notfy = _zczyz;
            isTSZL = _isTszl == 0 ? false : true;
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;
            DataTable myTb = new DataTable();
            string sSql = "";

            cmbWard.Items.Clear();
            cmbWard.DataSource = null;

            cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);
            sSql = "select WARD_ID,WARD_NAME from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " order by ward_id";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            cmbWard.DataSource = myTb;
            cmbWard.DisplayMember = "WARD_NAME";
            cmbWard.ValueMember = "WARD_ID";
            cmbWard.SelectedIndexChanged += new EventHandler(cmbWard_SelectedIndexChanged);

            myFunc = new BaseFunc();
            binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";



            if (!isSSMZ && !isCX && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);

            //if (isTSZL)
            {
                rbTempOut.Checked = true;
                rbTszl.Checked = false;

                rbIn.Enabled = false;
                rbOut.Enabled = false;
                rbTszl.Enabled = false;
                rbTrans.Enabled = false;
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="_formText">����</param>
        /// <param name="_isTszl">�Ƿ���������0=����1=��</param>
        /// <param name="_inpatientId">����ID</param>
        public frmYZGL(string _formText, int _isTszl, Guid _inpatientId)
        {
            isSSMZ = false;

            isTSZL = _isTszl == 0 ? false : true;
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_all " +
                "  WHERE inpatient_id= '" + _inpatientId + "' and flag<>10 ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";

            LoadWard();

            if (!isSSMZ && !isCX && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);

            if (isTSZL)
            {
                rbTszl.Checked = true;

                rbIn.Enabled = false;
                rbOut.Enabled = false;
                rbTempOut.Enabled = false;
                rbTrans.Enabled = false;
                //add by zouchihua 2012-4-27 �������Ʋ���ת��ǩ��
                if (rbTszl.Checked)
                    this.BtnTszlZcQm.Visible = true;
                else
                    this.BtnTszlZcQm.Visible = false;
            }
            //�˶�ǩ��
            if (isTSZL || isSSMZ)
            {
                btnCheck.Visible = true;
            }
            else
                btnCheck.Visible = false;
        }


        /// <summary>
        /// �����˲�ѯ
        /// </summary>
        /// <param name="_formText">����</param>
        /// <param name="_isTszl">�Ƿ���������0=����1=��</param>
        /// <param name="_inpatientId">����ID</param>
        public frmYZGL(string _formText, int _isTszl, Guid _inpatientId, bool _iscx)
        {
            isSSMZ = false;
            isCX = _iscx;
            isTSZL = _isTszl == 0 ? false : true;
            isTSZL = false;
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
            binSql = @" SELECT INPATIENT_NO AS סԺ��,BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end ҽ������,BRLX_NAME ��������,XZLX_NAME ��������,DYLX_NAME ��������,flag,WARD_ID " +
                "   FROM vi_zy_vInpatient_all " +
                "  WHERE inpatient_id= '" + _inpatientId + "' and flag<>10 ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";

            LoadWard();

            //add by yaokx Ĭ��ѡ��
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(binSql);
            if (myTb.Rows.Count > 0)
            {
                if (myTb.Rows[0]["flag"].ToString() == "4")//����
                {
                    this.rbTempOut.Checked = true;
                }
                else if (myTb.Rows[0]["flag"].ToString() == "2" || myTb.Rows[0]["flag"].ToString() == "6")//��Ժ
                {
                    this.rbOut.Checked = true;
                }
                this.groupBox1.Enabled = false;
                cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);
                this.cmbWard.SelectedValue = myTb.Rows[0]["WARD_ID"].ToString();
            }
            if (!isSSMZ && !isCX && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);

            if (isTSZL)
            {
                rbTszl.Checked = true;
                rbIn.Enabled = false;
                rbOut.Enabled = false;
                rbTempOut.Enabled = false;
                rbTrans.Enabled = false;
                //add by zouchihua 2012-4-27 �������Ʋ���ת��ǩ��
                if (rbTszl.Checked)
                    this.BtnTszlZcQm.Visible = true;
                else
                    this.BtnTszlZcQm.Visible = false;
            }
            //�˶�ǩ��
            if (isTSZL || isSSMZ)
            {
                btnCheck.Visible = true;
            }
            else
                btnCheck.Visible = false;
        }

        /// <summary>
        /// ��������ʹ��
        /// </summary>
        /// <param name="_formText"></param>
        /// <param name="_curDeptId"></param>
        /// <param name="_curUserId"></param>
        public frmYZGL(string _formText, string sSql, int nType, string _functionName)
        {
            isSSMZ = true;
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������            //
            this.Text = _formText;
            functionName = _functionName; //Add By Tany 2015-05-04
            myFunc = new BaseFunc();
            binSql = sSql;
            ssmzType = nType;
            LoadWard();

            if (!isSSMZ && !isCX)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ)
            {
                //this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            //pengyang 2015-7-28
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);
            btȡ����ҽ���˶�.EnabledChanged += new EventHandler(btȡ����ҽ���˶�_EnabledChanged);
        }

        /// <summary>
        /// ҽ����ѯ
        /// </summary>
        /// <param name="_formText"></param>
        /// <param name="_curDeptId"></param>
        /// <param name="_curUserId"></param>
        public frmYZGL(string _formText, bool _isCX)
        {
            isCX = _isCX;
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            LoadWard();

            cmbWard.SelectedIndex = 0;

            binSql = @" SELECT INPATIENT_NO AS סԺ��,BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end ҽ������,BRLX_NAME ��������,XZLX_NAME ��������,DYLX_NAME �������� " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' ORDER BY INPATIENT_NO,Baby_ID";

            if (!isSSMZ && !isCX)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);
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
            Trasen.Controls.ShowCardProperty showCardProperty1 = new Trasen.Controls.ShowCardProperty();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYZGL));
            this.panel�� = new System.Windows.Forms.Panel();
            this.panel�� = new System.Windows.Forms.Panel();
            this.panel���� = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.contextMenuSerch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.��ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ucShowCard1 = new ts_zyhs_classes.UcShowCard();
            this.rbTkxs = new System.Windows.Forms.RadioButton();
            this.rbTszl = new System.Windows.Forms.RadioButton();
            this.rbTrans = new System.Windows.Forms.RadioButton();
            this.cmbWard = new System.Windows.Forms.ComboBox();
            this.rbOut = new System.Windows.Forms.RadioButton();
            this.rbTempOut = new System.Windows.Forms.RadioButton();
            this.rbIn = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btSsmzwc = new System.Windows.Forms.Button();
            this.bt��ѡ = new System.Windows.Forms.Button();
            this.btnSqyzdy = new System.Windows.Forms.Button();
            this.btȫѡ = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rb���ز����б� = new System.Windows.Forms.RadioButton();
            this.rb��ʾ�����б� = new System.Windows.Forms.RadioButton();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel���� = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.bt����ִ�� = new System.Windows.Forms.Button();
            this.btԤ�� = new System.Windows.Forms.Button();
            this.btִ��ʱ�� = new System.Windows.Forms.Button();
            this.contextMenuSqm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ȡ��˫ǩ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ɾ��ִ��ʱ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ǩ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btδִ�� = new System.Windows.Forms.Button();
            this.btȡ����ҽ��ת�� = new System.Windows.Forms.Button();
            this.bt�˳� = new System.Windows.Forms.Button();
            this.btȡ��ͣҽ��ת�� = new System.Windows.Forms.Button();
            this.butorderprint = new System.Windows.Forms.Button();
            this.bt��ϸ��Ϣ = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bt���� = new System.Windows.Forms.Button();
            this.contextMenuSP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnTszlZcQm = new System.Windows.Forms.Button();
            this.bt���� = new System.Windows.Forms.Button();
            this.btҽ����ӡ = new System.Windows.Forms.Button();
            this.contextMenu3 = new System.Windows.Forms.ContextMenu();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.btȡ����ҽ���˶� = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.btȡ��ͣҽ���˶� = new System.Windows.Forms.Button();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.myDataGrid3 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.ucWzxm1 = new ts_zyhs_yzgl.UCWzxm();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.patientInfo1 = new ������Ϣ.PatientInfo();
            this.priceInfo1 = new �۸���Ϣ.PriceInfo();
            this.bt��ʾ�л� = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkGwyp = new System.Windows.Forms.CheckBox();
            this.chkSsyz = new System.Windows.Forms.CheckBox();
            this.lblSsMzFee = new System.Windows.Forms.Label();
            this.chkWardOrder = new System.Windows.Forms.CheckBox();
            this.txt_yz = new Trasen.Controls.LabelTextBox();
            this.showCardComponent1 = new Trasen.Controls.ShowCardComponent();
            this.che_yz = new System.Windows.Forms.CheckBox();
            this.che_date = new System.Windows.Forms.CheckBox();
            this.cmb_date = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ReasenPanel = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.chkShowAllSMYz = new System.Windows.Forms.CheckBox();
            this.panel��.SuspendLayout();
            this.panel��.SuspendLayout();
            this.panel����.SuspendLayout();
            this.panel4.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.contextMenuSerch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel����.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuSqm.SuspendLayout();
            this.contextMenuSP.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
            this.tabPage10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel��
            // 
            this.panel��.Controls.Add(this.panel��);
            this.panel��.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel��.Location = new System.Drawing.Point(0, 0);
            this.panel��.Name = "panel��";
            this.panel��.Size = new System.Drawing.Size(1160, 483);
            this.panel��.TabIndex = 0;
            // 
            // panel��
            // 
            this.panel��.Controls.Add(this.panel����);
            this.panel��.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel��.Location = new System.Drawing.Point(0, 0);
            this.panel��.Name = "panel��";
            this.panel��.Size = new System.Drawing.Size(1160, 483);
            this.panel��.TabIndex = 2;
            // 
            // panel����
            // 
            this.panel����.Controls.Add(this.panel4);
            this.panel����.Controls.Add(this.panel1);
            this.panel����.Controls.Add(this.bt��ʾ�л�);
            this.panel����.Controls.Add(this.panel5);
            this.panel����.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel����.Location = new System.Drawing.Point(0, 0);
            this.panel����.Name = "panel����";
            this.panel����.Size = new System.Drawing.Size(1160, 483);
            this.panel����.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1160, 272);
            this.panel4.TabIndex = 81;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 272);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 272);
            this.panel3.TabIndex = 26;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.MediumSeaGreen;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.ContextMenuStrip = this.contextMenuSerch;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 99);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(202, 173);
            this.myDataGrid2.TabIndex = 23;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid2.Tag = "";
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // contextMenuSerch
            // 
            this.contextMenuSerch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��ѯToolStripMenuItem});
            this.contextMenuSerch.Name = "contextMenuSerch";
            this.contextMenuSerch.Size = new System.Drawing.Size(95, 26);
            // 
            // ��ѯToolStripMenuItem
            // 
            this.��ѯToolStripMenuItem.Name = "��ѯToolStripMenuItem";
            this.��ѯToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.��ѯToolStripMenuItem.Text = "��ѯ";
            this.��ѯToolStripMenuItem.Click += new System.EventHandler(this.��ѯToolStripMenuItem_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ucShowCard1);
            this.groupBox1.Controls.Add(this.rbTkxs);
            this.groupBox1.Controls.Add(this.rbTszl);
            this.groupBox1.Controls.Add(this.rbTrans);
            this.groupBox1.Controls.Add(this.cmbWard);
            this.groupBox1.Controls.Add(this.rbOut);
            this.groupBox1.Controls.Add(this.rbTempOut);
            this.groupBox1.Controls.Add(this.rbIn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "����";
            // 
            // ucShowCard1
            // 
            this.ucShowCard1.IType = 0;
            this.ucShowCard1.Key = "";
            this.ucShowCard1.Location = new System.Drawing.Point(36, 76);
            this.ucShowCard1.Name = "ucShowCard1";
            this.ucShowCard1.Row = null;
            this.ucShowCard1.Size = new System.Drawing.Size(135, 21);
            this.ucShowCard1.TabIndex = 7;
            this.ucShowCard1.Value = "";
            this.ucShowCard1.MyDelEvent += new ts_zyhs_classes.UcShowCard.MyDel(this.ucShowCard1_MyDelEvent);
            // 
            // rbTkxs
            // 
            this.rbTkxs.Location = new System.Drawing.Point(118, 28);
            this.rbTkxs.Name = "rbTkxs";
            this.rbTkxs.Size = new System.Drawing.Size(53, 24);
            this.rbTkxs.TabIndex = 6;
            this.rbTkxs.Text = "����";
            this.rbTkxs.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbTszl
            // 
            this.rbTszl.Location = new System.Drawing.Point(48, 28);
            this.rbTszl.Name = "rbTszl";
            this.rbTszl.Size = new System.Drawing.Size(74, 24);
            this.rbTszl.TabIndex = 5;
            this.rbTszl.Text = "��������";
            this.rbTszl.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbTrans
            // 
            this.rbTrans.Location = new System.Drawing.Point(5, 28);
            this.rbTrans.Name = "rbTrans";
            this.rbTrans.Size = new System.Drawing.Size(57, 24);
            this.rbTrans.TabIndex = 4;
            this.rbTrans.Text = "ת��";
            this.rbTrans.Click += new System.EventHandler(this.rb_Click);
            // 
            // cmbWard
            // 
            this.cmbWard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWard.Location = new System.Drawing.Point(5, 52);
            this.cmbWard.Name = "cmbWard";
            this.cmbWard.Size = new System.Drawing.Size(192, 20);
            this.cmbWard.TabIndex = 0;
            this.cmbWard.SelectedIndexChanged += new System.EventHandler(this.cmbWard_SelectedIndexChanged);
            // 
            // rbOut
            // 
            this.rbOut.Location = new System.Drawing.Point(90, 9);
            this.rbOut.Name = "rbOut";
            this.rbOut.Size = new System.Drawing.Size(48, 24);
            this.rbOut.TabIndex = 3;
            this.rbOut.Text = "��Ժ";
            this.rbOut.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbTempOut
            // 
            this.rbTempOut.Location = new System.Drawing.Point(48, 9);
            this.rbTempOut.Name = "rbTempOut";
            this.rbTempOut.Size = new System.Drawing.Size(48, 24);
            this.rbTempOut.TabIndex = 2;
            this.rbTempOut.Text = "����";
            this.rbTempOut.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbIn
            // 
            this.rbIn.Checked = true;
            this.rbIn.Location = new System.Drawing.Point(5, 9);
            this.rbIn.Name = "rbIn";
            this.rbIn.Size = new System.Drawing.Size(57, 24);
            this.rbIn.TabIndex = 1;
            this.rbIn.TabStop = true;
            this.rbIn.Text = "��Ժ";
            this.rbIn.Click += new System.EventHandler(this.rb_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btSsmzwc);
            this.panel2.Controls.Add(this.bt��ѡ);
            this.panel2.Controls.Add(this.btnSqyzdy);
            this.panel2.Controls.Add(this.btȫѡ);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rb���ز����б�);
            this.panel2.Controls.Add(this.rb��ʾ�����б�);
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 272);
            this.panel2.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label6.ForeColor = System.Drawing.Color.Fuchsia;
            this.label6.Location = new System.Drawing.Point(244, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 98;
            this.label6.Text = "�Ϻ�ɫ��Ƥ��ҽ��";
            // 
            // btSsmzwc
            // 
            this.btSsmzwc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSsmzwc.BackColor = System.Drawing.Color.PaleGreen;
            this.btSsmzwc.Location = new System.Drawing.Point(649, 2);
            this.btSsmzwc.Name = "btSsmzwc";
            this.btSsmzwc.Size = new System.Drawing.Size(94, 20);
            this.btSsmzwc.TabIndex = 96;
            this.btSsmzwc.Text = "�����������";
            this.btSsmzwc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSsmzwc.UseVisualStyleBackColor = false;
            this.btSsmzwc.Visible = false;
            this.btSsmzwc.Click += new System.EventHandler(this.btSsmzwc_Click);
            // 
            // bt��ѡ
            // 
            this.bt��ѡ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt��ѡ.BackColor = System.Drawing.Color.PaleGreen;
            this.bt��ѡ.Location = new System.Drawing.Point(900, 2);
            this.bt��ѡ.Name = "bt��ѡ";
            this.bt��ѡ.Size = new System.Drawing.Size(56, 20);
            this.bt��ѡ.TabIndex = 79;
            this.bt��ѡ.Text = "��ѡ(&F)";
            this.bt��ѡ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt��ѡ.UseVisualStyleBackColor = false;
            this.bt��ѡ.Click += new System.EventHandler(this.bt��ѡ_Click);
            // 
            // btnSqyzdy
            // 
            this.btnSqyzdy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSqyzdy.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSqyzdy.Location = new System.Drawing.Point(743, 2);
            this.btnSqyzdy.Name = "btnSqyzdy";
            this.btnSqyzdy.Size = new System.Drawing.Size(97, 20);
            this.btnSqyzdy.TabIndex = 82;
            this.btnSqyzdy.Text = "��ǰִ�е���ӡ(&P)";
            this.btnSqyzdy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSqyzdy.UseVisualStyleBackColor = false;
            this.btnSqyzdy.Visible = false;
            this.btnSqyzdy.Click += new System.EventHandler(this.btnSqyzdy_Click);
            // 
            // btȫѡ
            // 
            this.btȫѡ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btȫѡ.BackColor = System.Drawing.Color.PaleGreen;
            this.btȫѡ.Location = new System.Drawing.Point(843, 2);
            this.btȫѡ.Name = "btȫѡ";
            this.btȫѡ.Size = new System.Drawing.Size(56, 20);
            this.btȫѡ.TabIndex = 78;
            this.btȫѡ.Text = "ȫѡ(&A)";
            this.btȫѡ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btȫѡ.UseVisualStyleBackColor = false;
            this.btȫѡ.Click += new System.EventHandler(this.btȫѡ_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(533, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 12);
            this.label5.TabIndex = 97;
            this.label5.Text = "��ɫ��˵��ҽ��";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(145, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 95;
            this.label3.Text = "��ɫ����ǰδִ��";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(364, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 12);
            this.label2.TabIndex = 94;
            this.label2.Text = "��ɫ������ֹͣ ����ִ�����";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(247, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "��ɫ�������Ѿ�ִ��";
            // 
            // rb���ز����б�
            // 
            this.rb���ز����б�.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb���ز����б�.Location = new System.Drawing.Point(32, 3);
            this.rb���ز����б�.Name = "rb���ز����б�";
            this.rb���ز����б�.Size = new System.Drawing.Size(127, 18);
            this.rb���ز����б�.TabIndex = 92;
            this.rb���ز����б�.Text = "���ز����б�(F3)";
            this.rb���ز����б�.UseVisualStyleBackColor = false;
            this.rb���ز����б�.Visible = false;
            this.rb���ز����б�.Click += new System.EventHandler(this.rb��ʾ�����б�_Click);
            // 
            // rb��ʾ�����б�
            // 
            this.rb��ʾ�����б�.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb��ʾ�����б�.Checked = true;
            this.rb��ʾ�����б�.Location = new System.Drawing.Point(11, 3);
            this.rb��ʾ�����б�.Name = "rb��ʾ�����б�";
            this.rb��ʾ�����б�.Size = new System.Drawing.Size(127, 18);
            this.rb��ʾ�����б�.TabIndex = 91;
            this.rb��ʾ�����б�.TabStop = true;
            this.rb��ʾ�����б�.Text = "��ʾ�����б�(F2)";
            this.rb��ʾ�����б�.UseVisualStyleBackColor = false;
            this.rb��ʾ�����б�.Visible = false;
            this.rb��ʾ�����б�.Click += new System.EventHandler(this.rb��ʾ�����б�_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(956, 272);
            this.myDataGrid1.TabIndex = 24;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myDataGrid1_MouseUp);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.myDataGrid1_myKeyDown);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel����);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 183);
            this.panel1.TabIndex = 80;
            // 
            // panel����
            // 
            this.panel����.Controls.Add(this.panel6);
            this.panel����.Controls.Add(this.tabControl2);
            this.panel����.Controls.Add(this.progressBar1);
            this.panel����.Controls.Add(this.patientInfo1);
            this.panel����.Controls.Add(this.priceInfo1);
            this.panel����.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel����.Location = new System.Drawing.Point(0, 0);
            this.panel����.Name = "panel����";
            this.panel����.Size = new System.Drawing.Size(1160, 183);
            this.panel����.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.bt����ִ��);
            this.panel6.Controls.Add(this.btԤ��);
            this.panel6.Controls.Add(this.btִ��ʱ��);
            this.panel6.Controls.Add(this.btnCheck);
            this.panel6.Controls.Add(this.btδִ��);
            this.panel6.Controls.Add(this.btȡ����ҽ��ת��);
            this.panel6.Controls.Add(this.bt�˳�);
            this.panel6.Controls.Add(this.btȡ��ͣҽ��ת��);
            this.panel6.Controls.Add(this.butorderprint);
            this.panel6.Controls.Add(this.bt��ϸ��Ϣ);
            this.panel6.Controls.Add(this.btnDelete);
            this.panel6.Controls.Add(this.bt����);
            this.panel6.Controls.Add(this.BtnTszlZcQm);
            this.panel6.Controls.Add(this.bt����);
            this.panel6.Controls.Add(this.btҽ����ӡ);
            this.panel6.Controls.Add(this.btȡ����ҽ���˶�);
            this.panel6.Controls.Add(this.btȡ��ͣҽ���˶�);
            this.panel6.Location = new System.Drawing.Point(-2, -3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1276, 27);
            this.panel6.TabIndex = 76;
            // 
            // bt����ִ��
            // 
            this.bt����ִ��.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt����ִ��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt����ִ��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt����ִ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt����ִ��.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt����ִ��.ImageIndex = 9;
            this.bt����ִ��.Location = new System.Drawing.Point(2, 2);
            this.bt����ִ��.Name = "bt����ִ��";
            this.bt����ִ��.Size = new System.Drawing.Size(61, 24);
            this.bt����ִ��.TabIndex = 47;
            this.bt����ִ��.Text = "����(&S)";
            this.bt����ִ��.Click += new System.EventHandler(this.bt����ִ��_Click);
            // 
            // btԤ��
            // 
            this.btԤ��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btԤ��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btԤ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btԤ��.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btԤ��.ImageIndex = 9;
            this.btԤ��.Location = new System.Drawing.Point(64, 2);
            this.btԤ��.Name = "btԤ��";
            this.btԤ��.Size = new System.Drawing.Size(61, 24);
            this.btԤ��.TabIndex = 71;
            this.btԤ��.Text = "Ԥ��(&Y)";
            this.btԤ��.Click += new System.EventHandler(this.btԤ��_Click);
            // 
            // btִ��ʱ��
            // 
            this.btִ��ʱ��.ContextMenuStrip = this.contextMenuSqm;
            this.btִ��ʱ��.Enabled = false;
            this.btִ��ʱ��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btִ��ʱ��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btִ��ʱ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btִ��ʱ��.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btִ��ʱ��.ImageIndex = 9;
            this.btִ��ʱ��.Location = new System.Drawing.Point(796, 2);
            this.btִ��ʱ��.Name = "btִ��ʱ��";
            this.btִ��ʱ��.Size = new System.Drawing.Size(84, 24);
            this.btִ��ʱ��.TabIndex = 70;
            this.btִ��ʱ��.Text = "ִ��ʱ��(&T)";
            this.btִ��ʱ��.Click += new System.EventHandler(this.btִ��ʱ��_Click);
            this.btִ��ʱ��.EnabledChanged += new System.EventHandler(this.btִ��ʱ��_EnabledChanged);
            // 
            // contextMenuSqm
            // 
            this.contextMenuSqm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ȡ��˫ǩ��ToolStripMenuItem,
            this.ɾ��ִ��ʱ��ToolStripMenuItem,
            this.����ǩ��ToolStripMenuItem});
            this.contextMenuSqm.Name = "contextMenuSerch";
            this.contextMenuSqm.Size = new System.Drawing.Size(143, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem1.Text = "˫ǩ��";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ȡ��˫ǩ��ToolStripMenuItem
            // 
            this.ȡ��˫ǩ��ToolStripMenuItem.Name = "ȡ��˫ǩ��ToolStripMenuItem";
            this.ȡ��˫ǩ��ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ȡ��˫ǩ��ToolStripMenuItem.Text = "ȡ��˫ǩ��";
            this.ȡ��˫ǩ��ToolStripMenuItem.Click += new System.EventHandler(this.ȡ��˫ǩ��ToolStripMenuItem_Click);
            // 
            // ɾ��ִ��ʱ��ToolStripMenuItem
            // 
            this.ɾ��ִ��ʱ��ToolStripMenuItem.Name = "ɾ��ִ��ʱ��ToolStripMenuItem";
            this.ɾ��ִ��ʱ��ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ɾ��ִ��ʱ��ToolStripMenuItem.Text = "ɾ��ִ��ʱ��";
            this.ɾ��ִ��ʱ��ToolStripMenuItem.Click += new System.EventHandler(this.ɾ��ִ��ʱ��ToolStripMenuItem_Click);
            // 
            // ����ǩ��ToolStripMenuItem
            // 
            this.����ǩ��ToolStripMenuItem.Name = "����ǩ��ToolStripMenuItem";
            this.����ǩ��ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.����ǩ��ToolStripMenuItem.Text = "����ǩ��";
            this.����ǩ��ToolStripMenuItem.Click += new System.EventHandler(this.����ǩ��ToolStripMenuItem_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCheck.Location = new System.Drawing.Point(440, 2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(67, 24);
            this.btnCheck.TabIndex = 74;
            this.btnCheck.Text = "�˶�ǩ��";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.BtnTszlZcQm_Click);
            // 
            // btδִ��
            // 
            this.btδִ��.Enabled = false;
            this.btδִ��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btδִ��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btδִ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btδִ��.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btδִ��.ImageIndex = 9;
            this.btδִ��.Location = new System.Drawing.Point(720, 2);
            this.btδִ��.Name = "btδִ��";
            this.btδִ��.Size = new System.Drawing.Size(76, 24);
            this.btδִ��.TabIndex = 65;
            this.btδִ��.Text = "δִ��(&X)";
            this.btδִ��.Click += new System.EventHandler(this.btδִ��_Click);
            this.btδִ��.EnabledChanged += new System.EventHandler(this.btδִ��_EnabledChanged);
            // 
            // btȡ����ҽ��ת��
            // 
            this.btȡ����ҽ��ת��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btȡ����ҽ��ת��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btȡ����ҽ��ת��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btȡ����ҽ��ת��.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btȡ����ҽ��ת��.ImageIndex = 6;
            this.btȡ����ҽ��ת��.Location = new System.Drawing.Point(250, 2);
            this.btȡ����ҽ��ת��.Name = "btȡ����ҽ��ת��";
            this.btȡ����ҽ��ת��.Size = new System.Drawing.Size(120, 24);
            this.btȡ����ҽ��ת��.TabIndex = 49;
            this.btȡ����ҽ��ת��.Text = "ȡ����ҽ��ת��()";
            this.btȡ����ҽ��ת��.Visible = false;
            this.btȡ����ҽ��ת��.Click += new System.EventHandler(this.btȡ����ҽ��ת��_Click);
            this.btȡ����ҽ��ת��.EnabledChanged += new System.EventHandler(this.btȡ����ҽ��ת��_EnabledChanged);
            // 
            // bt�˳�
            // 
            this.bt�˳�.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt�˳�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�˳�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�˳�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�˳�.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt�˳�.ImageIndex = 4;
            this.bt�˳�.Location = new System.Drawing.Point(880, 2);
            this.bt�˳�.Name = "bt�˳�";
            this.bt�˳�.Size = new System.Drawing.Size(64, 24);
            this.bt�˳�.TabIndex = 48;
            this.bt�˳�.Text = "�˳�(&E)";
            this.bt�˳�.Click += new System.EventHandler(this.bt�˳�_Click);
            // 
            // btȡ��ͣҽ��ת��
            // 
            this.btȡ��ͣҽ��ת��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btȡ��ͣҽ��ת��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btȡ��ͣҽ��ת��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btȡ��ͣҽ��ת��.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btȡ��ͣҽ��ת��.ImageIndex = 6;
            this.btȡ��ͣҽ��ת��.Location = new System.Drawing.Point(372, 2);
            this.btȡ��ͣҽ��ת��.Name = "btȡ��ͣҽ��ת��";
            this.btȡ��ͣҽ��ת��.Size = new System.Drawing.Size(120, 24);
            this.btȡ��ͣҽ��ת��.TabIndex = 66;
            this.btȡ��ͣҽ��ת��.Text = "ȡ��ͣҽ��ת��()";
            this.btȡ��ͣҽ��ת��.Visible = false;
            this.btȡ��ͣҽ��ת��.Click += new System.EventHandler(this.btȡ����ҽ��ת��_Click);
            this.btȡ��ͣҽ��ת��.EnabledChanged += new System.EventHandler(this.btȡ��ͣҽ��ת��_EnabledChanged);
            // 
            // butorderprint
            // 
            this.butorderprint.Enabled = false;
            this.butorderprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butorderprint.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butorderprint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butorderprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butorderprint.ImageIndex = 9;
            this.butorderprint.Location = new System.Drawing.Point(651, 2);
            this.butorderprint.Name = "butorderprint";
            this.butorderprint.Size = new System.Drawing.Size(125, 24);
            this.butorderprint.TabIndex = 72;
            this.butorderprint.Text = "��ҽ����ӡ������";
            this.butorderprint.Visible = false;
            this.butorderprint.Click += new System.EventHandler(this.butorderprint_Click);
            // 
            // bt��ϸ��Ϣ
            // 
            this.bt��ϸ��Ϣ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt��ϸ��Ϣ.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt��ϸ��Ϣ.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt��ϸ��Ϣ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt��ϸ��Ϣ.ImageIndex = 8;
            this.bt��ϸ��Ϣ.Location = new System.Drawing.Point(126, 2);
            this.bt��ϸ��Ϣ.Name = "bt��ϸ��Ϣ";
            this.bt��ϸ��Ϣ.Size = new System.Drawing.Size(61, 24);
            this.bt��ϸ��Ϣ.TabIndex = 51;
            this.bt��ϸ��Ϣ.Text = "����(F8)";
            this.bt��ϸ��Ϣ.Click += new System.EventHandler(this.bt��ϸ��Ϣ_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 9;
            this.btnDelete.Location = new System.Drawing.Point(499, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 24);
            this.btnDelete.TabIndex = 69;
            this.btnDelete.Text = "ɾ���˵�(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.EnabledChanged += new System.EventHandler(this.btnDelete_EnabledChanged);
            // 
            // bt����
            // 
            this.bt����.ContextMenuStrip = this.contextMenuSP;
            this.bt����.Enabled = false;
            this.bt����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt����.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt����.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt����.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt����.ImageIndex = 9;
            this.bt����.Location = new System.Drawing.Point(651, 2);
            this.bt����.Name = "bt����";
            this.bt����.Size = new System.Drawing.Size(64, 24);
            this.bt����.TabIndex = 64;
            this.bt����.Text = "����(&+)";
            this.bt����.Click += new System.EventHandler(this.bt����_Click);
            // 
            // contextMenuSP
            // 
            this.contextMenuSP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuSP.Name = "contextMenuSerch";
            this.contextMenuSP.Size = new System.Drawing.Size(137, 70);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem2.Text = "����(+)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem3.Text = "������(++)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem4.Text = "ǿ����(+++)";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // BtnTszlZcQm
            // 
            this.BtnTszlZcQm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTszlZcQm.ForeColor = System.Drawing.SystemColors.Desktop;
            this.BtnTszlZcQm.Location = new System.Drawing.Point(372, 2);
            this.BtnTszlZcQm.Name = "BtnTszlZcQm";
            this.BtnTszlZcQm.Size = new System.Drawing.Size(67, 24);
            this.BtnTszlZcQm.TabIndex = 73;
            this.BtnTszlZcQm.Text = "ת��ǩ��";
            this.BtnTszlZcQm.UseVisualStyleBackColor = true;
            this.BtnTszlZcQm.Visible = false;
            this.BtnTszlZcQm.Click += new System.EventHandler(this.BtnTszlZcQm_Click);
            this.BtnTszlZcQm.EnabledChanged += new System.EventHandler(this.BtnTszlZcQm_EnabledChanged);
            // 
            // bt����
            // 
            this.bt����.Enabled = false;
            this.bt����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt����.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt����.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt����.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt����.ImageIndex = 9;
            this.bt����.Location = new System.Drawing.Point(586, 2);
            this.bt����.Name = "bt����";
            this.bt����.Size = new System.Drawing.Size(64, 24);
            this.bt����.TabIndex = 63;
            this.bt����.Text = "����(&-)";
            this.bt����.Click += new System.EventHandler(this.bt����_Click);
            // 
            // btҽ����ӡ
            // 
            this.btҽ����ӡ.ContextMenu = this.contextMenu3;
            this.btҽ����ӡ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btҽ����ӡ.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btҽ����ӡ.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btҽ����ӡ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btҽ����ӡ.ImageIndex = 7;
            this.btҽ����ӡ.Location = new System.Drawing.Point(188, 2);
            this.btҽ����ӡ.Name = "btҽ����ӡ";
            this.btҽ����ӡ.Size = new System.Drawing.Size(61, 24);
            this.btҽ����ӡ.TabIndex = 50;
            this.btҽ����ӡ.Text = "��ӡ(&P)";
            this.btҽ����ӡ.Click += new System.EventHandler(this.btҽ����ӡ_Click);
            // 
            // contextMenu3
            // 
            this.contextMenu3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem8,
            this.menuItem9});
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "��ӡҽ����";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "��ӡִ�е�";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "��ӡ����ƾ֤";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // btȡ����ҽ���˶�
            // 
            this.btȡ����ҽ���˶�.ContextMenu = this.contextMenu1;
            this.btȡ����ҽ���˶�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btȡ����ҽ���˶�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btȡ����ҽ���˶�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btȡ����ҽ���˶�.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btȡ����ҽ���˶�.ImageIndex = 6;
            this.btȡ����ҽ���˶�.Location = new System.Drawing.Point(250, 2);
            this.btȡ����ҽ���˶�.Name = "btȡ����ҽ���˶�";
            this.btȡ����ҽ���˶�.Size = new System.Drawing.Size(120, 24);
            this.btȡ����ҽ���˶�.TabIndex = 62;
            this.btȡ����ҽ���˶�.Text = "ȡ����ҽ��ת��(&Z)";
            this.btȡ����ҽ���˶�.Click += new System.EventHandler(this.btȡ����ҽ���˶�_Click);
            this.btȡ����ҽ���˶�.EnabledChanged += new System.EventHandler(this.btȡ����ҽ���˶�_EnabledChanged);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem3,
            this.menuItem1});
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "ȡ����ҽ��ת��";
            this.menuItem5.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "ȡ����ҽ���˶�";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "ȡ����ҽ�����";
            this.menuItem1.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // btȡ��ͣҽ���˶�
            // 
            this.btȡ��ͣҽ���˶�.ContextMenu = this.contextMenu2;
            this.btȡ��ͣҽ���˶�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btȡ��ͣҽ���˶�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btȡ��ͣҽ���˶�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btȡ��ͣҽ���˶�.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btȡ��ͣҽ���˶�.ImageIndex = 6;
            this.btȡ��ͣҽ���˶�.Location = new System.Drawing.Point(370, 2);
            this.btȡ��ͣҽ���˶�.Name = "btȡ��ͣҽ���˶�";
            this.btȡ��ͣҽ���˶�.Size = new System.Drawing.Size(120, 24);
            this.btȡ��ͣҽ���˶�.TabIndex = 68;
            this.btȡ��ͣҽ���˶�.Text = "ȡ��ͣҽ��ת��(&C)";
            this.btȡ��ͣҽ���˶�.Click += new System.EventHandler(this.btȡ����ҽ���˶�_Click);
            this.btȡ��ͣҽ���˶�.EnabledChanged += new System.EventHandler(this.btȡ��ͣҽ���˶�_EnabledChanged);
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem4,
            this.menuItem2});
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "ȡ��ͣҽ��ת��";
            this.menuItem6.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "ȡ��ͣҽ���˶�";
            this.menuItem4.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "ȡ��ͣҽ�����";
            this.menuItem2.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Location = new System.Drawing.Point(766, 37);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(390, 120);
            this.tabControl2.TabIndex = 75;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.myDataGrid3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(382, 94);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "��Ŀ��ϸ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // myDataGrid3
            // 
            this.myDataGrid3.AllowSorting = false;
            this.myDataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGrid3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid3.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid3.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid3.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.CaptionText = "��Ŀ��ϸ";
            this.myDataGrid3.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid3.DataMember = "";
            this.myDataGrid3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.Location = new System.Drawing.Point(1, 5);
            this.myDataGrid3.Name = "myDataGrid3";
            this.myDataGrid3.ReadOnly = true;
            this.myDataGrid3.RowHeaderWidth = 20;
            this.myDataGrid3.Size = new System.Drawing.Size(378, 86);
            this.myDataGrid3.TabIndex = 61;
            this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.myDataGrid3.CurrentCellChanged += new System.EventHandler(this.myDataGrid3_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.myDataGrid3;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.ucWzxm1);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(382, 94);
            this.tabPage10.TabIndex = 1;
            this.tabPage10.Text = "ѡ��������Ŀ";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // ucWzxm1
            // 
            this.ucWzxm1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWzxm1.BabyID = ((long)(0));
            this.ucWzxm1.BinID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucWzxm1.Dept_id = 0;
            this.ucWzxm1.First_times = null;
            this.ucWzxm1.Fjfy_yzid = 0;
            this.ucWzxm1.IsSSMZ = false;
            this.ucWzxm1.Itemidsf = null;
            this.ucWzxm1.Location = new System.Drawing.Point(2, 1);
            this.ucWzxm1.MyTb = null;
            this.ucWzxm1.Name = "ucWzxm1";
            this.ucWzxm1.Nrow = 0;
            this.ucWzxm1.Order_id = null;
            this.ucWzxm1.RbIn = false;
            this.ucWzxm1.RbTszl = false;
            this.ucWzxm1.Size = new System.Drawing.Size(380, 97);
            this.ucWzxm1.TabIndex = 0;
            this.ucWzxm1.Yztype = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(465, 163);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(692, 14);
            this.progressBar1.TabIndex = 57;
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(3, 37);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(459, 144);
            this.patientInfo1.TabIndex = 56;
            // 
            // priceInfo1
            // 
            this.priceInfo1.Dv = null;
            this.priceInfo1.Location = new System.Drawing.Point(461, 37);
            this.priceInfo1.Name = "priceInfo1";
            this.priceInfo1.Order_context = null;
            this.priceInfo1.Size = new System.Drawing.Size(307, 120);
            this.priceInfo1.TabIndex = 54;
            // 
            // bt��ʾ�л�
            // 
            this.bt��ʾ�л�.BackColor = System.Drawing.Color.PaleTurquoise;
            this.bt��ʾ�л�.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt��ʾ�л�.Location = new System.Drawing.Point(10, 54);
            this.bt��ʾ�л�.Name = "bt��ʾ�л�";
            this.bt��ʾ�л�.Size = new System.Drawing.Size(16, 20);
            this.bt��ʾ�л�.TabIndex = 68;
            this.bt��ʾ�л�.UseVisualStyleBackColor = false;
            this.bt��ʾ�л�.Click += new System.EventHandler(this.bt��ʾ�л�_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkGwyp);
            this.panel5.Controls.Add(this.chkSsyz);
            this.panel5.Controls.Add(this.lblSsMzFee);
            this.panel5.Controls.Add(this.chkWardOrder);
            this.panel5.Controls.Add(this.txt_yz);
            this.panel5.Controls.Add(this.che_yz);
            this.panel5.Controls.Add(this.che_date);
            this.panel5.Controls.Add(this.cmb_date);
            this.panel5.Controls.Add(this.tabControl1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1160, 28);
            this.panel5.TabIndex = 96;
            // 
            // chkGwyp
            // 
            this.chkGwyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGwyp.AutoSize = true;
            this.chkGwyp.Location = new System.Drawing.Point(510, 6);
            this.chkGwyp.Name = "chkGwyp";
            this.chkGwyp.Size = new System.Drawing.Size(144, 16);
            this.chkGwyp.TabIndex = 38;
            this.chkGwyp.Text = "��ʾ�������и�ΣҩƷ";
            this.chkGwyp.UseVisualStyleBackColor = true;
            this.chkGwyp.Visible = false;
            this.chkGwyp.CheckedChanged += new System.EventHandler(this.chkGwyp_CheckedChanged);
            // 
            // chkSsyz
            // 
            this.chkSsyz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSsyz.AutoSize = true;
            this.chkSsyz.Location = new System.Drawing.Point(785, 6);
            this.chkSsyz.Name = "chkSsyz";
            this.chkSsyz.Size = new System.Drawing.Size(96, 16);
            this.chkSsyz.TabIndex = 98;
            this.chkSsyz.Text = "��ʾ����ҽ��";
            this.chkSsyz.UseVisualStyleBackColor = true;
            // 
            // lblSsMzFee
            // 
            this.lblSsMzFee.AutoSize = true;
            this.lblSsMzFee.Location = new System.Drawing.Point(330, 8);
            this.lblSsMzFee.Name = "lblSsMzFee";
            this.lblSsMzFee.Size = new System.Drawing.Size(89, 12);
            this.lblSsMzFee.TabIndex = 97;
            this.lblSsMzFee.Text = "������úϼƣ�";
            this.lblSsMzFee.Visible = false;
            // 
            // chkWardOrder
            // 
            this.chkWardOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWardOrder.AutoSize = true;
            this.chkWardOrder.Location = new System.Drawing.Point(785, 6);
            this.chkWardOrder.Name = "chkWardOrder";
            this.chkWardOrder.Size = new System.Drawing.Size(96, 16);
            this.chkWardOrder.TabIndex = 36;
            this.chkWardOrder.Text = "��ʾ����ҽ��";
            this.chkWardOrder.UseVisualStyleBackColor = true;
            this.chkWardOrder.Visible = false;
            this.chkWardOrder.CheckedChanged += new System.EventHandler(this.chkWardOrder_CheckedChanged);
            // 
            // txt_yz
            // 
            this.txt_yz.ActiveColor = System.Drawing.Color.Empty;
            this.txt_yz.AllowDefaultValue = false;
            this.txt_yz.AllowGotoNextControlWithoutNoneSelected = false;
            this.txt_yz.AllowPressEnterKeyCheckValue = false;
            this.txt_yz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_yz.AutoTabSend = false;
            this.txt_yz.ButtonVisible = false;
            this.txt_yz.DisplayMember = "BLH";
            this.txt_yz.DisplayShowCardWhenActived = false;
            this.txt_yz.DoSelectedWhenTextEmpty = true;
            this.txt_yz.Enable = true;
            this.txt_yz.Enabled = false;
            this.txt_yz.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_yz.InputValueStyle = Trasen.Controls.InputValueStyle.String;
            this.txt_yz.LabelText = "";
            this.txt_yz.Location = new System.Drawing.Point(1063, 4);
            this.txt_yz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_yz.MaxLength = 32767;
            this.txt_yz.Multiline = false;
            this.txt_yz.Name = "txt_yz";
            this.txt_yz.ReadOnly = false;
            this.txt_yz.SelectAllTextAfterClick = false;
            this.txt_yz.SelectedValue = null;
            this.txt_yz.SelectionLength = 0;
            this.txt_yz.SelectionStart = 0;
            this.txt_yz.SetValueEqualTextWhenNoneSelected = true;
            this.txt_yz.ShowCardComponent = this.showCardComponent1;
            this.txt_yz.ShowCardEnable = false;
            showCardProperty1.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty1.BindColumnName = null;
            showCardProperty1.ColumnHeaderVisible = false;
            showCardProperty1.DbConnection = null;
            showCardProperty1.RealTimeQuery = false;
            showCardProperty1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            showCardProperty1.RowHeaderVisible = false;
            showCardProperty1.ShowCardColumns = new Trasen.Controls.ShowCardColumn[0];
            showCardProperty1.ShowCardDataSource = null;
            showCardProperty1.ShowCardDataSourceSqlString = null;
            showCardProperty1.ShowCardSize = new System.Drawing.Size(135, 108);
            this.txt_yz.ShowCardProperty = new Trasen.Controls.ShowCardProperty[] {
        showCardProperty1};
            this.txt_yz.Size = new System.Drawing.Size(93, 24);
            this.txt_yz.TabIndex = 34;
            this.txt_yz.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_yz.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.txt_yz.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_yz.TextBoxStyle = Trasen.Controls.LabelTextBox.TextBoxStyleEnum.Standard;
            this.txt_yz.ValueMember = "BLH";
            this.txt_yz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_yz_KeyDown);
            // 
            // showCardComponent1
            // 
            this.showCardComponent1.MatchType = Trasen.Controls.MatchType.ģ����ѯ;
            this.showCardComponent1.ShowCardSelectedMode = Trasen.Controls.ShowCardSelectedMode.Click;
            // 
            // che_yz
            // 
            this.che_yz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.che_yz.AutoSize = true;
            this.che_yz.Location = new System.Drawing.Point(1019, 8);
            this.che_yz.Name = "che_yz";
            this.che_yz.Size = new System.Drawing.Size(48, 16);
            this.che_yz.TabIndex = 31;
            this.che_yz.Text = "ҽ��";
            this.che_yz.UseVisualStyleBackColor = true;
            this.che_yz.CheckedChanged += new System.EventHandler(this.che_yz_CheckedChanged);
            // 
            // che_date
            // 
            this.che_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.che_date.AutoSize = true;
            this.che_date.Location = new System.Drawing.Point(885, 6);
            this.che_date.Name = "che_date";
            this.che_date.Size = new System.Drawing.Size(60, 16);
            this.che_date.TabIndex = 28;
            this.che_date.Text = "������";
            this.che_date.UseVisualStyleBackColor = true;
            this.che_date.CheckedChanged += new System.EventHandler(this.che_date_CheckedChanged);
            // 
            // cmb_date
            // 
            this.cmb_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_date.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_date.Enabled = false;
            this.cmb_date.FormattingEnabled = true;
            this.cmb_date.Items.AddRange(new object[] {
            "����",
            "����",
            "һ��",
            "һ��",
            "����",
            "һ��",
            "ȫ��"});
            this.cmb_date.Location = new System.Drawing.Point(947, 3);
            this.cmb_date.Name = "cmb_date";
            this.cmb_date.Size = new System.Drawing.Size(66, 20);
            this.cmb_date.TabIndex = 27;
            this.cmb_date.SelectedIndexChanged += new System.EventHandler(this.cmb_date_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 22);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 28);
            this.tabControl1.TabIndex = 35;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // ReasenPanel
            // 
            this.ReasenPanel.BackColor = System.Drawing.Color.LightGreen;
            this.ReasenPanel.Location = new System.Drawing.Point(0, 0);
            this.ReasenPanel.Name = "ReasenPanel";
            this.ReasenPanel.Size = new System.Drawing.Size(280, 40);
            this.ReasenPanel.TabIndex = 2;
            this.ReasenPanel.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "23.ICO");
            this.imageList1.Images.SetKeyName(1, "gomme.ico");
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1008, 0);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "��Ч����";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1008, 0);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "��Ч����";
            this.tabPage2.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1008, 0);
            this.tabPage3.TabIndex = 7;
            this.tabPage3.Text = "��Ч�����˵�";
            this.tabPage3.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1008, 0);
            this.tabPage4.TabIndex = 8;
            this.tabPage4.Text = "��Ч��ʱ�˵�";
            this.tabPage4.Visible = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1008, 0);
            this.tabPage6.TabIndex = 10;
            this.tabPage6.Text = "���г���";
            this.tabPage6.Visible = false;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 26);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1008, 0);
            this.tabPage7.TabIndex = 11;
            this.tabPage7.Text = "��������";
            this.tabPage7.Visible = false;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 26);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1008, 0);
            this.tabPage8.TabIndex = 12;
            this.tabPage8.Text = "���г����˵�";
            this.tabPage8.Visible = false;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 26);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1008, 0);
            this.tabPage9.TabIndex = 13;
            this.tabPage9.Text = "������ʱ�˵�";
            this.tabPage9.Visible = false;
            // 
            // chkShowAllSMYz
            // 
            this.chkShowAllSMYz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAllSMYz.AutoSize = true;
            this.chkShowAllSMYz.Location = new System.Drawing.Point(661, 6);
            this.chkShowAllSMYz.Name = "chkShowAllSMYz";
            this.chkShowAllSMYz.Size = new System.Drawing.Size(120, 16);
            this.chkShowAllSMYz.TabIndex = 37;
            this.chkShowAllSMYz.Text = "��ʾ��������ҽ��";
            this.chkShowAllSMYz.UseVisualStyleBackColor = true;
            this.chkShowAllSMYz.Visible = false;
            this.chkShowAllSMYz.CheckedChanged += new System.EventHandler(this.chkShowAllSMYz_CheckedChanged);
            // 
            // frmYZGL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1160, 483);
            this.Controls.Add(this.chkShowAllSMYz);
            this.Controls.Add(this.panel��);
            this.Controls.Add(this.ReasenPanel);
            this.KeyPreview = true;
            this.Name = "frmYZGL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ҽ����ѯ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZGL_Load);
            this.Activated += new System.EventHandler(this.frmYZGL_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmYZGL_KeyUp);
            this.panel��.ResumeLayout(false);
            this.panel��.ResumeLayout(false);
            this.panel����.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.contextMenuSerch.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel����.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.contextMenuSqm.ResumeLayout(false);
            this.contextMenuSP.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmYZGL_Load(object sender, System.EventArgs e)
        {
            chkGwyp.Visible = false;
            //add by zouchihua 2012-5-16 ���ͼƬ
            this.ȡ��˫ǩ��ToolStripMenuItem.Image = ts_zyhs_yzgl.Properties.Resources.gomme;
            this.toolStripMenuItem1.Image = ts_zyhs_yzgl.Properties.Resources._23;
            this.ɾ��ִ��ʱ��ToolStripMenuItem.Image = ts_zyhs_yzgl.Properties.Resources.gomme;
            if (isSSMZ)
            {
                string[] GrdMappingName11 ={ "סԺ��", "����", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
                int[] GrdWidth11 ={ 9, 8, 0, 0, 0, 0 };
                int[] Alignment11 ={ 1, 0, 0, 0, 0, 0 };
                myFunc.InitGridSQL(binSql, GrdMappingName11, GrdWidth11, Alignment11, this.myDataGrid2);

                //Modify by jchl
                DataTable dtSrc = myDataGrid2.DataSource as DataTable;
                DoInitCtr(GrdMappingName11, GrdMappingName11, new string[] { "סԺ��", "����" }, new int[] { 100, 60, 0, 0, 0, 0 }, dtSrc);

                //				tabControl1.Controls.Remove(tabPage1);
                //				tabControl1.Controls.Remove(tabPage2);
                //				tabControl1.Controls.Remove(tabPage3);
                //				tabControl1.Controls.Remove(tabPage4);
                //				tabControl1.Controls.Remove(tabPage6);
                //				tabControl1.Controls.Remove(tabPage8);

                //0=���� 1=����
                //�����Ҳ��ܿ�������ҽ��
                //Modify By Tany 2005-11-03 �����ҿ��Կ�ҽ��
                //				if(ssmzType==0)
                //				{
                //					tabControl1.Controls.Remove(tabPage7);
                //				}

                //				tabControl1.SelectedIndex=0;

                //Modify By Tany 2010-08-31 ���Դ�ӡ����ƾ֤
                //btҽ����ӡ.Visible = false;

                //Modify by jchl
                if (ssmzType == 1)
                {
                    //
                    chkGwyp.Visible = true;
                }

                menuItem7.Visible = false;
                menuItem8.Visible = false;

                btȡ��ͣҽ���˶�.Visible = false;
                btȡ��ͣҽ��ת��.Visible = false;
                //btȡ����ҽ���˶�.Visible=false;
                //btȡ����ҽ��ת��.Visible=false;
                btδִ��.Visible = false;
                bt����.Visible = false;
                bt����.Visible = false;
                butorderprint.Visible = true;
                butorderprint.Enabled = true;
                btִ��ʱ��.Visible = true;//Modify by zouchhua 2012-6-12 ������Ҳ���Կ���
                BtnTszlZcQm.Visible = true;//Modify by zouchhua 2012-6-12 ������Ҳ���Կ���
                btnCheck.Visible = true;//Modify by zouchhua 2013-11-28 ������Ҳ���Կ���

                chkWardOrder.Visible = true;//Modify By Tany 2015-03-25 ֻ�����鿴�ü�
                chkShowAllSMYz.Visible = true;//Modify By Tany 2015-03-31 ֻ�����鿴�ü�
            }
            else if (isCX || zczyz_notfy)
            {
                if (zczyz_notfy)
                {
                    binSql = @" SELECT INPATIENT_NO AS סԺ��,BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end ҽ������,BRLX_NAME ��������,XZLX_NAME ��������,DYLX_NAME ��������" +
                      "   FROM vi_zy_vInpatient_All " +
                      "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' and flag = 5 ORDER BY INPATIENT_NO,Baby_ID";
                }
                string[] GrdMappingName11 ={ "סԺ��", "����", "����", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY", "ҽ������", "��������", "��������", "��������" };
                int[] GrdWidth11 ={ 9, 5, 8, 0, 0, 0, 0, 9, 9, 9, 9 };
                int[] Alignment11 ={ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGridSQL(binSql, GrdMappingName11, GrdWidth11, Alignment11, this.myDataGrid2);

                //Modify by jchl
                DataTable dtSrc = myDataGrid2.DataSource as DataTable;
                DoInitCtr(GrdMappingName11, GrdMappingName11, new string[] { "סԺ��", "����", "����" }, new int[] { 100, 50, 60, 0, 0, 0, 0, 0, 0, 0, 0 }, dtSrc);

                //				tabControl1.Controls.Remove(tabPage1);
                //				tabControl1.Controls.Remove(tabPage2);
                //				tabControl1.Controls.Remove(tabPage3);
                //				tabControl1.Controls.Remove(tabPage4);

                tabControl1.SelectedIndex = 0;

                bt��ϸ��Ϣ.Text = "��ϸ��Ϣ";

                bt����ִ��.Visible = false;
                btҽ����ӡ.Visible = false;
                btȡ��ͣҽ���˶�.Visible = false;
                btȡ��ͣҽ��ת��.Visible = false;
                btȡ����ҽ���˶�.Visible = false;
                btȡ����ҽ��ת��.Visible = false;
                btnDelete.Visible = false;
                btδִ��.Visible = false;
                bt����.Visible = false;
                bt����.Visible = false;
                btִ��ʱ��.Visible = false;
            }
            else
            {
                string[] GrdMappingName1 ={ "����", "����", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
                int[] GrdWidth1 ={ 5, 10, 0, 0, 0, 0 };
                int[] Alignment1 ={ 1, 0, 0, 0, 0, 0 };
                myFunc.InitGridSQL(binSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);

                //Modify by jchl
                DataTable dtSrc = myDataGrid2.DataSource as DataTable;
                DoInitCtr(GrdMappingName1, GrdMappingName1, new string[] { "����", "����" }, new int[] { 50, 60, 0, 0, 0, 0 }, dtSrc);

            }

            DataTable myTb = (DataTable)myDataGrid2.DataSource;

            int nRow = myDataGrid2.CurrentCell.RowNumber;

            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            /*
            status_flag,Order_ID,Group_ID,Num,Unit,dwlx,Order_Usage,frequency,Dropsper,Dosage,
            ntype,exec_dept,day1,second1,day2,second2,
            AUDITING_USER,AUDITING_USER1,order_euser,order_euser1,item_code,cjid,
            ������,��ʱ��,
            ҽ������,����ҽ��,����ת��,�����˶�,
            ͣ����,ͣʱ��,
            ͣ��ҽ��,ͣ��ת��,ͣ���˶�,
            ִ��ʱ��,���ͻ�ʿ,ִ�п���,serial_no,ps_flag,ps_orderid,ps_user,wzx_flag
            */
            string[] GrdMappingName ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
										"ntype","exec_dept","day1","second1","day2","second2", "AUDITING_USER","AUDITING_USER1",
										"order_euser","order_euser1","item_code","xmly",     
										"ѡ",
										"������","��ʱ��","ҽ������","����","����ҽ��","����ת��","�����˶�",
										"ͣ����","ͣʱ��","ͣ��ҽ��","ͣ��ת��","ͣ���˶�",
										"ִ��ʱ��","ִ����","ִ�п���","����ʱ��","���ͻ�ʿ",//"ִ��ʱ��","ִ����",
										"ps_flag","ps_orderid","ps_user","wzx_flag","P","hoitem_id","isprintypgg","������","����"
                //,"zfbl"
            };//isggdy add by zouchihua 2011-11-30 //������,���� add by Tany 2015-06-23
            //add by zouchihua 2011-11-30
            int isggwide = 0;
            try
            {
                //��ʿվҽ�������Ƿ���ʾ��ӡ����С�
                if (new SystemCfg(7802).Config.ToString().Trim() == "1")
                    isggwide = 10;
            }
            catch (Exception ex)
            {
                isggwide = 0;
                MessageBox.Show(ex.Message);
            }
            int[] GrdWidth ={0,0,0,0,0,0,0,0,0,0,
									 0,0,0,0,0,0,0,0,
									 0,0,0,0,
									 2,
									 6,6,50,0,8,8,0,//�����˶Բ���ʾ
									 6,6,8,8,0,//ͣ���˶Բ���ʾ
									 15,8,8,15,8,
									 0,0,0,0,4,0,0,8,8};//isggwide
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                //if (rbTszl.Checked == false)
                //{
                //    rbTszl.Checked = true;
                //    rb_Click(null, null);
                //    return;
                //}
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.patientInfo1.ClearInpatientInfo();
                ClassStatic.Current_BinID = Guid.Empty;
                ClassStatic.Current_BabyID = 0;
                ClassStatic.Current_DeptID = 0;
                ClassStatic.Current_isMYTS = 0;
                ClassStatic.Current_isMY = 0;
                //myDataGrid1.DataSource = null;
                return;
            }

            if ((new Guid(myTb.Rows[nRow]["inpatient_id"].ToString()) == ClassStatic.Current_BinID) && (Convert.ToInt64(myTb.Rows[nRow]["baby_id"]) == ClassStatic.Current_BabyID))
            {
                myDataGrid2_CurrentCellChanged(sender, e);
            }
            else
            {
                myFunc.SelectBin(true, this.myDataGrid2, "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY");
                this.ShowData();
            }

            //			PubStaticFun.ModifyDataGridStyle(myDataGrid1,0);
            PubStaticFun.ModifyDataGridStyle(myDataGrid2, 0);
            //add by zouchihu a2012-3-27
            cfg7111 = new SystemCfg(7111);
            cfg7129 = new SystemCfg(7129);
            if (zczyz_notfy)
            {
                //cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);
                //cmbWard_SelectedIndexChanged(null, null);
                //cmbWard.SelectedIndexChanged += new EventHandler(cmbWard_SelectedIndexChanged);
            }

            MenuItem menu = new MenuItem();
            menu.Index = 3;
            menu.Text = "��ӡҽ���˵�����";
            menu.Click += new EventHandler(menu_Click);

            //Modify by jchl
            menu.Name = "yzzd";
            if (!contextMenu3.MenuItems.ContainsKey(menu.Name))
            {
                contextMenu3.MenuItems.Add(menu);
            }

            //Add By Tany 2015-02-02 ���Ӵ�ӡ��ҩ����
            MenuItem menu_printzycf = new MenuItem();
            menu_printzycf.Index = 4;
            menu_printzycf.Text = "��ӡ��ҩ����";
            menu_printzycf.Click += new EventHandler(menu_printzycf_Click);

            //Modify by jchl
            menu_printzycf.Name = "zycf";
            if (!contextMenu3.MenuItems.ContainsKey(menu_printzycf.Name))
            {
                contextMenu3.MenuItems.Add(menu_printzycf);
            }

            //Add By jchl 
            if (isSSMZ)
            {
                MenuItem menuSm_JMY = new MenuItem();
                menuSm_JMY.Index = 5;
                menuSm_JMY.Text = "��ӡ�龫һ����";
                menuSm_JMY.Click += new EventHandler(menuSmCf_Print);

                //Modify by jchl ��ӡ�龫һ����
                menuSm_JMY.Name = "mjycf";
                if (!contextMenu3.MenuItems.ContainsKey(menuSm_JMY.Name))
                {
                    contextMenu3.MenuItems.Add(menuSm_JMY);
                }

                MenuItem menuSm_JE = new MenuItem();
                menuSm_JE.Index = 6;
                menuSm_JE.Text = "��ӡ��������";
                menuSm_JE.Click += new EventHandler(menuSmCf_Print);

                menuSm_JE.Name = "jecf";
                if (!contextMenu3.MenuItems.ContainsKey(menuSm_JE.Name))
                {
                    contextMenu3.MenuItems.Add(menuSm_JE);
                }

                MenuItem menuSm_ptcf = new MenuItem();
                menuSm_ptcf.Index = 7;
                menuSm_ptcf.Text = "��ӡѡ�񴦷�";
                menuSm_ptcf.Click += new EventHandler(menuSmCf_Print);

                menuSm_ptcf.Name = "xzcf";
                if (!contextMenu3.MenuItems.ContainsKey(menuSm_ptcf.Name))
                {
                    contextMenu3.MenuItems.Add(menuSm_ptcf);
                }
            }

            //if(InstanceForm)
            //Modify By Tany 2015-05-11 �����������
            btSsmzwc.Visible = isSSMZ;
            btSsmzwc.Text = ssmzType == 0 ? "�������" : "�������";

            //add pengyang 2015-8-6
            if (isSSMZ)
                tabControl1.SelectedTab = tabPage7;
            //add pengyang 2015-8-6 ����Ƥ��ҽ������ʾ����ɫ
            label6.Location = new Point(label5.Location.X + 100, label5.Location.Y);
            //add pengyang 2015-8-6 ��������ҽ��
            //chkSsyz.Location = new Point(che_date.Location.X - 30, che_date.Location.Y);
            if (isSSMZ == true)
            {
                chkSsyz.Visible = false;
            }
            else
            {
                chkSsyz.CheckedChanged += new EventHandler(chkSsyz_CheckedChanged);
            }

            //Add By Tany 2015-11-17
            sysDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd"));
        }

        private void chkSsyz_CheckedChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-6 ��������ҽ��
            if (chkSsyz.Checked)
            {
                chkShowAllSMYz.CheckedChanged -= chkShowAllSMYz_CheckedChanged;
                chkShowAllSMYz.Checked = false;
                chkShowAllSMYz.CheckedChanged += chkShowAllSMYz_CheckedChanged;

                chkWardOrder.CheckedChanged -= chkWardOrder_CheckedChanged;
                chkWardOrder.Checked = false;
                chkWardOrder.CheckedChanged += chkWardOrder_CheckedChanged;
            }
            ShowData();
        }

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
                        if (GrdMappingName[i].ToString().Trim() == "P")
                        {
                            myBoolCol.HeaderText = "����";
                        }
                    }
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
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
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //��ɫ������ҽ����״̬ 
            int ColorCol = 0;		 //״̬��
            e.BackColor = Color.White;
            if (Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) > 1 && Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) < 5)   //�����
            {
                e.ForeColor = Color.Blue;
                //ѡ����
                if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;

                //Modify By Tany 2015-06-18 �����˵��ҽ������ʾ������ɫ
                if (this.myDataGrid1[e.Row, 10].ToString() == "7")
                {
                    e.ForeColor = Color.Orange;
                }
            }
            if (this.myDataGrid1[e.Row, ColorCol].ToString() == "5")   //��ֹͣ
            {
                e.ForeColor = Color.Gray;
                if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
            }
            //�Ѿ�ִ�е�ҽ����ʾ��ɫ Modify By Tany 2007-10-27
            //ԭ����if���ĳ�else if���Ѿ�ֹͣ�ľ���ʾ��ɫ�������ǲ��ǽ���ִ�� Modify By Tany 2014-12-22
            else if (this.myDataGrid1[e.Row, 38].ToString() != "")
            {
                if (Convert.ToDateTime(this.myDataGrid1[e.Row, 38]) >= sysDate)
                {
                    e.ForeColor = Color.Red;
                    if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
                }
                object obj = myDataGrid1[e.Row, 38];
                //Modify By Tany 2015-06-18 �����˵��ҽ������ʾ������ɫ
                if (this.myDataGrid1[e.Row, 10].ToString() == "7")
                {
                    e.ForeColor = Color.Orange;
                }
            }
            //add pengyang 2015-8-6  ����Ƥ��ҽ����ʾ
            if (tabControl1.SelectedTab == tabPage7 && myDataGrid1.DataSource != null)
            {
                DataTable dt = myDataGrid1.DataSource as DataTable;
                if (dt.Rows.Count > 0 && dt.Rows.Count > e.Row)
                {
                    object ps_flag = dt.Rows[e.Row][38];
                    string[] arr = { "0", "1", "2" };
                    System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>(arr);
                    if (ps_flag != DBNull.Value && ps_flag != null && list.Contains(ps_flag.ToString().Trim()))
                    {
                        e.ForeColor = Color.Fuchsia;
                    }
                }
            }
        }

        //Tany 2014-12-2
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        /// <param name="GrdMappingName"></param>
        /// <param name="GrdWidth"></param>
        /// <param name="Alignment"></param>
        /// <param name="ReadOnly"></param>
        /// <param name="myDataGrid"></param>
        private void InitGridPat(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
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
                        if (GrdMappingName[i].ToString().Trim() == "P")
                        {
                            myBoolCol.HeaderText = "����";
                        }
                    }
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValuesPat);
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
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValuesPat);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        //Tany 2014-12-22
        private void SetEnableValuesPat(object sender, DataGridEnableEventArgs e)
        {
            //��ɫ������ҽ����״̬ 
            int ColorCol = 0;		 //״̬��
            e.BackColor = Color.White;
            e.ForeColor = Color.Red;
        }

        /// <summary>
        /// ����ʱ�䷶Χ��ҽ�����ݹ���
        /// 2014--8-26 ����
        /// </summary>
        /// <param name="myTb"></param>
        /// <returns></returns>
        private DataTable ShowDate_Filter()
        {

            DateTime curdate = TrasenClasses.GeneralClasses.DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date;

            DataTable dt = che_date.Tag as DataTable;
            DataTable dt1 = new DataTable();
            string strYznr = "";//ҽ����������
            string kind = "";//ʱ����������
            string strFilter_date = ""; ;//ʱ���������
            if (che_date.Checked && cmb_date.Text != "") kind = cmb_date.Text.Trim();
            if (che_yz.Checked && txt_yz.Text.Trim() != "") strYznr = txt_yz.Text.Trim();
            #region  ����ʱ���������
            if (dt.Columns.Contains("ORDER_BDATE"))
            {



                switch (kind)
                {
                    case "����":
                        strFilter_date = "ORDER_BDATE>='" + curdate + "' and ORDER_BDATE<'" + curdate.AddDays(1) + "'";
                        break;
                    case "����":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddDays(-1) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "һ��":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddDays(-7) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "һ��":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddMonths(-1) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "����":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddMonths(-6) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "һ��":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddYears(-1) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "����":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddYears(-2) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                }


            }
            #endregion

            #region  ����ҽ��������������������й�������

            //Modify by jchl[������ʾ��ΣҩƷ]
            string strFil_Gwyp = "";
            if (chkGwyp.Checked)
            {
                if (dt.Columns.Contains("gwypjb"))
                {
                    strFil_Gwyp = " gwypjb=1";
                }
            }


            string strFilter_yznr = "";//ҽ����������
            string strFilter_group = "";
            if (strYznr.Trim() != "") strFilter_yznr = " ҽ������ like '%" + strYznr + "%'";
            String strFilter = ""; //��������
            if (strFilter_date.Trim() != "" && strFilter_yznr.Trim() != "")
            {
                strFilter = strFilter_date + " and " + strFilter_yznr;
            }
            else if (strFilter_date.Trim() != "" && strFilter_yznr.Trim() == "")
                strFilter = strFilter_date;
            else if (strFilter_date.Trim() == "" && strFilter_yznr.Trim() != "")
                strFilter = strFilter_yznr;

            //if (strFilter != "" && strFil_Gwyp != "")
            //{
            //    strFilter += "and" + strFil_Gwyp;
            //}
            //else if (strFilter == "" && strFil_Gwyp != "")
            //{
            //    strFilter += strFil_Gwyp;
            //}

            #endregion
            if (strFilter != "")
            {
                DataView dv = new DataView(dt.Copy(), strFilter, "", DataViewRowState.CurrentRows);
                dt1 = dv.ToTable();
            }
            #region �������
            if (dt1.Rows.Count != 0)
            {
                if (dt1.Rows.Count == 1)
                {
                    strFilter_group = " group_ID =" + dt1.Rows[0]["GROUP_ID"].ToString().Trim();
                }
                else if (dt1.Rows.Count > 1)
                {
                    strFilter_group = "group_ID in (";
                    String param = "";
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (i == dt1.Rows.Count - 1)
                        {
                            param += dt1.Rows[dt1.Rows.Count - 1]["GROUP_ID"].ToString().Trim();
                        }
                        else
                        {
                            param += dt1.Rows[i]["GROUP_ID"].ToString().Trim() + ",";
                        }
                    }
                    strFilter_group += param + ")";
                }
            }

            if (strFilter_date.Trim() != "" && strFilter_group.Trim() != "")
            {
                strFilter = strFilter_date + " and 1=1  and " + strFilter_group;
            }
            else if (strFilter_date.Trim() != "" && strFilter_group.Trim() == "")
                strFilter = strFilter_date;
            else if (strFilter_date.Trim() == "" && strFilter_group.Trim() != "")
                strFilter = strFilter_group;
            #endregion
            if (strFilter != "")
            {
                DataView dv = new DataView(dt.Copy(), strFilter, "", DataViewRowState.CurrentRows);
                dt = dv.ToTable();
            }

            if (strFilter != "" && strFil_Gwyp != "")
            {
                strFilter += "and" + strFil_Gwyp;
            }
            else if (strFilter == "" && strFil_Gwyp != "")
            {
                strFilter += strFil_Gwyp;
            }

            if (strFilter != "")
            {
                DataView dv = new DataView(dt.Copy(), strFilter, "", DataViewRowState.CurrentRows);
                dt = dv.ToTable();
            }
            //if (setGridDataSource)
            //{
            //    int nType = this.GetMNGType();
            //    CheckGrdData(dt, nType);
            //    this.myDataGrid1.DataSource = dt;
            //}
            return dt;
        }
        private void ShowData()
        {
            //5=����������
            //0-����  1,5-����  2-�����˵�  3-��ʱ�˵�  ��MNGTYPE��
            int nType = this.GetMNGType();
            int nKind = this.tabControl1.SelectedTab.Text.Trim().IndexOf("��Ч", 0, this.tabControl1.SelectedTab.Text.Trim().Length) >= 0 ? 0 : 1;

            DataTable myTb = new DataTable();
            if (chkSsyz.Checked)
            {
                myTb = myFunc.GetBinOrdrsSSYZ("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), "-1");
            }
            else
            {
                if (isSSMZ && !chkWardOrder.Checked)    //Modify By Tany 2015-03-25 �����ѡ,����ʾ����ҽ��
                {
                    myTb = myFunc.GetBinOrdrsSSMZ("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), (chkShowAllSMYz.Checked ? "-1" : InstanceForm.BCurrentDept.WardId));
                }
                else
                {
                    myTb = myFunc.GetBinOrdrs("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentDept.WardId, (rbTszl.Checked ? InstanceForm.BCurrentDept.DeptId : 0));
                }
            }
            che_date.Tag = myTb.Copy();//add  by zouchihua 2014-8-27 ���Ӽ�������
            myTb = ShowDate_Filter();//add  by zouchihua 2014-8-27 ���Ӽ�������             
            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "ѡ";
            col.DefaultValue = false;
            if (!myTb.Columns.Contains("ѡ")) //�����ж�����
                myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            CheckGrdData(myTb, nType);
            this.myDataGrid1.DataSource = myTb;

            //this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();			
            //add by zouchihua 2012-5-17 �Ƿ���ʾ�˶���
            SystemCfg cfg7123 = new SystemCfg(7123);
            int Checkwide = 0;
            if (cfg7123.Config.Trim() == "1")
                Checkwide = 8;
            //�����˶ԡ�ͣ���˶Բ���ʾ
            string[] GrdMappingName ={ "����", "����ҽ��", "����ת��", "�����˶�", "ͣ����", "ͣʱ��", "ͣ��ҽ��", "ͣ��ת��", "ͣ���˶�", "ִ��ʱ��", "ִ����" };
            int[] GrdWidth ={   0,       8,         8,         Checkwide,       6,       6,         8,         8,         Checkwide,    0,         0,  
										6,       8,         8,         Checkwide,       0,       0,         0,         0,         0,    15,        12,
										0,       0,         8,         0,       6,       6,         0,         8,         0,    0,         0,
										6,       0,         8,         0,       0,       0,         0,         0,         0,    0,         0 };
            int i = 0, j = GrdMappingName.Length;
            for (i = 0; i <= j - 1; i++)
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles[GrdMappingName[i]].Width = GrdWidth[j * nType + i] == 0 ? 0 : (GrdWidth[j * nType + i] * 7 + 2);

                //���η�����  Modify by jchl ҩƷ���ü�������
                if (GrdMappingName[i].Equals("����"))
                {
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[GrdMappingName[i]].Width = 0;
                }
            }

            if (chkSsyz.Checked) //add pengyang 2015-8-7
            {
                //System.Collections.Generic.Dictionary<Button, bool> dict = new System.Collections.Generic.Dictionary<Button, bool>();
                //dict.Add(bt����ִ��, false);
                //dict.Add(btԤ��, false);
                //dict.Add(bt��ϸ��Ϣ, false);
                //dict.Add(btҽ����ӡ, false);
                //dict.Add(btȡ����ҽ���˶�, false);
                //dict.Add(BtnTszlZcQm, false);
                //dict.Add(btnCheck, false);
                //dict.Add(btnDelete, false);
                //dict.Add(butorderprint, false);
                //dict.Add(btִ��ʱ��, false);
                //dict.Add(bt�˳�, true);

                //dict.Add(btȡ��ͣҽ��ת��, false);
                //dict.Add(btδִ��, false);
                //dict.Add(bt����, false);
                //dict.Add(bt����, false);
                //foreach (System.Collections.Generic.KeyValuePair<Button, bool> pair in dict)
                //    pair.Key.Enabled = pair.Value;
                panel6.Enabled = false;
            }
            else
            {
                panel6.Enabled = true;
                //btȡ����ҽ��ת��,btȡ��ͣҽ��ת��,btȡ����ҽ���˶�,btȡ��ͣҽ���˶�,btδִ��,bt����,bt����,btnDelete
                //n����ť�Ŀ���
                int[] btEnabled ={1,1,1,1,1,0,0,0,//���ĸ��ĳ�1����0��ʼ �ѳ���ҽ����δִ�зų���
							 1,0,1,0,1,1,1,0,
							 0,0,0,0,1,0,0,1,
							 0,0,0,0,0,0,0,1};
                this.btȡ����ҽ��ת��.Enabled = btEnabled[0 + nType * 8] == 1 ? true : false;
                this.btȡ��ͣҽ��ת��.Enabled = btEnabled[1 + nType * 8] == 1 ? true : false;
                this.btȡ����ҽ���˶�.Enabled = btEnabled[2 + nType * 8] == 1 ? true : false;
                this.btȡ��ͣҽ���˶�.Enabled = btEnabled[3 + nType * 8] == 1 ? true : false;
                this.btδִ��.Enabled = btEnabled[4 + nType * 8] == 1 ? true : false;
                this.bt����.Enabled = btEnabled[5 + nType * 8] == 1 ? true : false;
                this.bt����.Enabled = btEnabled[6 + nType * 8] == 1 ? true : false;
                this.btnDelete.Enabled = btEnabled[7 + nType * 8] == 1 ? true : false;
                //ִ��ʱ���ų�����
                this.btִ��ʱ��.Enabled = this.tabControl1.SelectedTab.Text.Trim() == "��������" ? true : false;
                //add yaokx  2014-06-03
                if (nType == 1 || nType == 5)
                {
                    if (myTb.Rows.Count > 0)
                    {
                        if (myTb.Rows[0]["ҽ������"].ToString().IndexOf("ȡ��") >= 0)
                        {
                            this.btִ��ʱ��.Enabled = false;
                        }
                        else
                        {
                            this.btִ��ʱ��.Enabled = true;
                        }
                    }
                }
            }

            if (nType > 1)
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles["����ת��"].HeaderText = "¼�뻤ʿ";
                this.myDataGrid1.TableStyles[0].GridColumnStyles["ͣ��ת��"].HeaderText = "ֹͣ��ʿ";
                this.btδִ��.Text = "ͣ�˵�(&X)";
            }
            else
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles["����ת��"].HeaderText = "����ת��";
                this.myDataGrid1.TableStyles[0].GridColumnStyles["ͣ��ת��"].HeaderText = "ͣ��ת��";
                this.btδִ��.Text = "δִ��(&X)";
            }

            this.myDataGrid1.CaptionText = tabControl1.SelectedTab.Text.Trim();
            this.myDataGrid1.Refresh();
            this.myDataGrid3_Clear();
            this.priceInfo1.ClearYpInfo();

            //add By jchl 2015-06-11 ��ʾ������ҽ�������úϼ�
            decimal sdVal = 0M;
            if (isSSMZ && !chkWardOrder.Checked)
            {
                lblSsMzFee.Visible = true;
                try
                {
                    DoCntSsMzFee(myTb, out sdVal);
                }
                catch
                { }
                lblSsMzFee.Text = "������úϼƣ�" + sdVal.ToString("0.00");
            }

            //			PubStaticFun.ModifyDataGridStyle(myDataGrid1,0);
            PubStaticFun.ModifyDataGridStyle(myDataGrid2, 0);
            //			DataGridTextboxAddDoubleClick(myDataGrid1,0);˫����Ҫ����4�Σ�����Tany 2007-03-15
        }

        private int GetMNGType()
        {
            switch (this.tabControl1.SelectedTab.Text.Trim())
            {
                case "��Ч����":
                    return 0;
                case "��Ч����":
                    return 1;
                case "��Ч�����˵�":
                    return 2;
                case "��Ч��ʱ�˵�":
                    return 3;
                case "���г���":
                    return 0;
                case "��������":
                    return 1;
                case "���г����˵�":
                    return 2;
                case "������ʱ�˵�":
                    return 3;
                default:
                    return 0;
            }
        }


        private void CheckGrdData(DataTable myTb, int nType)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0;                //��¼��һ����ʾ���ں�ʱ����к�
            int l = 0, group_rows = 1;    //ͬ���е�ҽ������
            int ii = 0;
            this.sPaint = "";
            this.sPaintPS = "";
            this.sPaintWZX = "";

            #region �������
            max_len0 = 0;
            max_len1 = 0;
            max_len2 = 0;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sNum = this.GetNumUnit(myTb, i);
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["ҽ������"].ToString().Trim());
                //�ҽ��
                max_len0 = max_len0 > l ? max_len0 : l;
                if (sNum.Trim() != "")
                {
                    //�ҽ��
                    max_len1 = max_len1 > l ? max_len1 : l;
                    l = System.Text.Encoding.Default.GetByteCount(sNum);
                    //���λ
                    max_len2 = max_len2 > l ? max_len2 : l;
                }
            }
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                #region ��ʾ����ʱ��
                if (myTb.Rows[i]["������"].ToString() == "" && i == 0)
                {
                    myTb.Rows[i]["������"] = DateTime.Parse(myTb.Rows[i]["ORDER_BDATE"].ToString()).ToString("M-dd");
                }
                else if (myTb.Rows[i]["������"].ToString() != "")
                {
                    //  myTb.Rows[i]["������"] = myFunc.getDate(myTb.Rows[i]["������"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                    myTb.Rows[i]["������"] = DateTime.Parse(myTb.Rows[i]["ORDER_BDATE"].ToString()).ToString("M-dd");
                }

                if (myTb.Rows[i]["��ʱ��"].ToString() != "")
                {
                    myTb.Rows[i]["��ʱ��"] = DateTime.Parse(myTb.Rows[i]["ORDER_BDATE"].ToString()).ToString("H:mm");
                }
                else if (myTb.Rows[i]["��ʱ��"].ToString() == "" && i == 0)
                {
                    myTb.Rows[i]["��ʱ��"] = DateTime.Parse(myTb.Rows[i]["ORDER_BDATE"].ToString()).ToString("H:mm");
                }

                //�޸�����
                //myTb.Rows[i]["������"] = myFunc.getDate(myTb.Rows[i]["������"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                //myTb.Rows[i]["��ʱ��"] = myFunc.getTime(myTb.Rows[i]["��ʱ��"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                myTb.Rows[i]["ͣ����"] = myFunc.getDate(myTb.Rows[i]["ͣ����"].ToString().Trim(), myTb.Rows[i]["day2"].ToString().Trim());
                myTb.Rows[i]["ͣʱ��"] = myFunc.getTime(myTb.Rows[i]["ͣʱ��"].ToString().Trim(), myTb.Rows[i]["second2"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["������"].ToString().Trim() == myTb.Rows[iDay]["������"].ToString().Trim())
                    {
                        myTb.Rows[i]["������"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }
                    // ʱ����ͬ�����ڲ�ͬҪ��ʾʱ�� Modify by zouchihua 2012-11-14
                    if (myTb.Rows[i]["��ʱ��"].ToString().Trim() == myTb.Rows[iTime]["��ʱ��"].ToString().Trim() && (myTb.Rows[i]["������"].ToString().Trim() == myTb.Rows[iTime]["������"].ToString().Trim() || myTb.Rows[i]["������"].ToString().Trim() == ""))
                    {
                        myTb.Rows[i]["��ʱ��"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }
                #endregion
                #region ��ʾҽ������

                //��ҽ�����ݡ�+= ��ҽ�����ݡ�+���ո�+��������λ��
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["ҽ������"].ToString().Trim());
                sNum = this.GetNumUnit(myTb, i);
                if (sNum.Trim() != "")
                    myTb.Rows[i]["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;//��һ���ո� Modify by zouchiua 2012-6-29
                else
                    myTb.Rows[i]["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString().Trim() + myFunc.Repeat_Space(max_len0 - l) + sNum;

                if ((i == myTb.Rows.Count - 1) || (i != myTb.Rows.Count - 1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i + 1]["Group_id"].ToString().Trim()))
                {
                    //��������һ�л��к���һ�е�ҽ���Ų�һ��

                    //ͬ���е�һ��ҽ���ġ�ҽ�����ݡ�+=���÷���+�����١�+ ��Ƶ�ʡ�
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["ҽ������"].ToString().Trim());
                    if (sNum.Trim() != "")
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);//Modify By Tany 2005-01-25			
                    else
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(max_len2 + 4);//Modify By Tany 2005-01-25
                    #region ����
                    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "")
                    {
                        if (!myTb.Rows[i - group_rows + 1]["ҽ������"].ToString().Trim().Contains(myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim()))
                        {
                            myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                        }
                    }
                    if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "")
                    {
                        if (!myTb.Rows[i - group_rows + 1]["ҽ������"].ToString().Trim().Contains(myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim()))
                        {
                            myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim();// +"��/min"; Modify by zouchihua 2012-4-27��ȥ��
                        }
                    }
                    #endregion
                    //��ʱ���Σ�����д��󣬰���������Σ�����ſ�
                    //if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                    //if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim();// +"��/min"; Modify by zouchihua 2012-4-27��ȥ��
                    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != ""
                        && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "1"
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                        if (!myTb.Rows[i - group_rows + 1]["ҽ������"].ToString().Trim().Contains(myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim()))
                        {
                            myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                        }
                    // myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                    int cd = 0;
                    //add by zouchihua 2012-6-23 ��������
                    if ((nType == 1 || nType == 5) && myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() != ""
                        && int.Parse(myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim()) > 1
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                    {
                        cd = System.Text.Encoding.Default.GetByteCount(" " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "��");
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "��" + myFunc.Repeat_Space(6 - cd);
                    }
                    else
                    {
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(6 - cd);
                    }
                    int len = 0;
                    for (int x = 0; x < group_rows; x++)
                    {

                        #region//������ʾ
                        if ((nType == 1 || nType == 5) && Convert.ToInt32(myTb.Rows[i - group_rows + 1 + x]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i - group_rows + 1 + x]["zsl"].ToString().Trim() != "")//�����ҩƷ
                        {
                            string ssNum = "";

                            if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == Convert.ToInt64(myTb.Rows[i - group_rows + 1 + x]["zsl"]))
                            {
                                ssNum = String.Format("{0:F0}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                                if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == 0)
                                    ssNum = "";
                            }
                            else
                            {
                                ssNum = String.Format("{0:F3}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                            }
                            if (x == 0)
                            {
                                len = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["ҽ������"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["ҽ������"] += " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                            else
                            {
                                int blen = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["ҽ������"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["ҽ������"] += myFunc.Repeat_Space(len - blen) + " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                        }
                        #endregion
                    }

                    //���һ���е�ҽ����������1
                    if (group_rows != 1)
                    {
                        //[3i2]0 �����������һ��ҽ�������һ��������ҽ��������ҽ����status_flag=0
                        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                    }

                    ii = i - group_rows + 1;

                    group_rows = 1;
                }
                else
                {
                    try
                    {

                        //������ǵ�һ�У��ұ��к���һ�е�ҽ����һ��
                        myTb.Rows[i]["����ҽ��"] = System.DBNull.Value;
                        myTb.Rows[i]["����ת��"] = System.DBNull.Value;
                        myTb.Rows[i]["�����˶�"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣ����"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣʱ��"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣ��ҽ��"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣ��ת��"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣ���˶�"] = System.DBNull.Value;
                        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;

                        ii = i;
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
                #region//������ʾ
                //if ((nType == 1 || nType == 5) && Convert.ToInt32(myTb.Rows[i]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i]["zsl"].ToString().Trim() != "")//�����ҩƷ
                //{
                //    string ssNum = "";

                //    if (Convert.ToDecimal(myTb.Rows[i]["zsl"]) == Convert.ToInt64(myTb.Rows[i]["zsl"]))
                //    {
                //        ssNum = String.Format("{0:F0}", myTb.Rows[i]["zsl"]).Trim();
                //        if (Convert.ToDecimal(myTb.Rows[i]["zsl"]) == 0)
                //            ssNum = "";
                //    }
                //    else
                //    {
                //        ssNum = String.Format("{0:F3}", myTb.Rows[i]["zsl"]).Trim();
                //    }
                //    myTb.Rows[i]["ҽ������"] += " " + ssNum + myTb.Rows[i]["zsldw"].ToString().Trim();
                //}
                #endregion
                #endregion

                #region ��ʾδִ��
                if (Convert.ToInt16(myTb.Rows[i]["wzx_flag"]) > 0)
                {
                    this.sPaintWZX += "i" + i.ToString() + "X";
                }
                #endregion

                #region ��ʾƤ��
                //����
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 2 &&
                    (myTb.Rows[ii]["ҽ������"].ToString().Trim().IndexOf("Ƥ��", 0) > 0
                    || myTb.Rows[ii]["ҽ������"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "+" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["ҽ������"].ToString().Trim()) + "]";
                }
                #region ��ʾǿ����Ƥ�� yaokx 2014-05-06
                //������
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 21 &&
                    (myTb.Rows[ii]["ҽ������"].ToString().Trim().IndexOf("Ƥ��", 0) > 0
                    || myTb.Rows[ii]["ҽ������"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "++" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["ҽ������"].ToString().Trim()) + "]";
                }
                //ǿ����
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 22 &&
                    (myTb.Rows[ii]["ҽ������"].ToString().Trim().IndexOf("Ƥ��", 0) > 0
                    || myTb.Rows[ii]["ҽ������"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "+++" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["ҽ������"].ToString().Trim()) + "]";
                }
                #endregion
                //����
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 1 &&
                    (myTb.Rows[ii]["ҽ������"].ToString().Trim().IndexOf("Ƥ��", 0) > 0
                    || myTb.Rows[ii]["ҽ������"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "-" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["ҽ������"].ToString().Trim()) + "]" + myTb.Rows[ii]["status_flag"].ToString().Trim();
                }
                #endregion
            }
            this.myDataGrid1.DataSource = myTb;
        }

        //���ء�����+��λ��������Ƿ���ʾС��
        private string GetNumUnit(DataTable myTb, int i)
        {
            string sNum = "";
            if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt64(myTb.Rows[i]["Num"]))
            {
                sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
            }
            else
            {
                sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
            }
            //Modify By Tany 2004-10-27
            if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "2"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "3"
                && GetMNGType() != 2
                && GetMNGType() != 3)
                || sNum == "0" || sNum == "")
                return "";
            else
                return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();//Modify by zouchihua 2012-6-29 ��һ���ո�
        }


        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ShowData();
            int mntype = this.GetMNGType();
            if (mntype == 0 || mntype == 1)
            {
                if (cfg7111.Config.Trim() == "1")
                    //add by zouchihua 2012-3-27 ֻ��ҽ������ʾ��ǰҽ����ӡ
                    this.btnSqyzdy.Visible = true;

            }
            else
            {
                if (cfg7111.Config.Trim() == "1")
                    //add by zouchihua 2012-3-27 ֻ��ҽ������ʾ��ǰҽ����ӡ
                    this.btnSqyzdy.Visible = false;
            }
            //add by zouchihua 2011-11-30 ֻ����ʱҽ����ʾ�����
            if (mntype != 1 && mntype != 0)
            {
                for (int i = 0; i < myDataGrid1.TableStyles[0].GridColumnStyles.Count; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName == "isprintypgg")
                    {
                        myDataGrid1.TableStyles[0].GridColumnStyles[i].Width = 0;
                    }
                }
            }
            else
            {

                //add by zouchihua 2011-11-30
                int isggwide = 0;
                try
                {
                    //��ʿվҽ�������Ƿ���ʾ��ӡ����С�
                    if (new SystemCfg(7802).Config.ToString().Trim() == "1")
                    {
                        for (int i = 0; i < myDataGrid1.TableStyles[0].GridColumnStyles.Count; i++)
                        {
                            if (myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName == "isprintypgg")
                            {
                                myDataGrid1.TableStyles[0].GridColumnStyles[i].Width = 60;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            if (rbTrans.Checked && cfg7159.Config.Trim() == "1")
            {
                btδִ��.Visible = false;
                if (btδִ��.Text.Contains("ͣ"))
                    btδִ��.Visible = true;
            }
            //�õ����˻�����Ϣ
            this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
            if (new SystemCfg(7202).Config == "1")
            {
                this.tabPage10.Hide();
                this.tabControl2.SelectedIndex = 0;
                this.ucWzxm1.Itemidsf = "";
                this.ucWzxm1.BingData();
            }

            if (isSSMZ) //add pengyang 2015-7-29
            {
                System.Collections.Generic.Dictionary<Button, bool> dict = new System.Collections.Generic.Dictionary<Button, bool>();
                if (tabControl1.SelectedTab == tabPage6)
                {
                    dict.Add(bt����ִ��, false);
                    dict.Add(btԤ��, false);
                    dict.Add(bt��ϸ��Ϣ, false);
                    dict.Add(btҽ����ӡ, false);
                    dict.Add(btȡ����ҽ���˶�, false);
                    dict.Add(BtnTszlZcQm, false);
                    dict.Add(btnCheck, false);
                    dict.Add(btnDelete, false);
                    dict.Add(butorderprint, false);
                    dict.Add(btִ��ʱ��, false);
                    dict.Add(bt�˳�, true);
                }
                else if (tabControl1.SelectedTab == tabPage7)
                {
                    dict.Add(bt����ִ��, true);
                    dict.Add(btԤ��, true);
                    dict.Add(bt��ϸ��Ϣ, true);
                    dict.Add(btҽ����ӡ, true);
                    dict.Add(btȡ����ҽ���˶�, true);
                    dict.Add(BtnTszlZcQm, true);
                    dict.Add(btnCheck, true);
                    dict.Add(btnDelete, false);
                    dict.Add(butorderprint, true);
                    dict.Add(btִ��ʱ��, true);
                    dict.Add(bt�˳�, true);
                }
                else
                {
                    dict.Add(bt����ִ��, true);
                    dict.Add(btԤ��, true);
                    dict.Add(bt��ϸ��Ϣ, true);
                    dict.Add(btҽ����ӡ, true);
                    dict.Add(btȡ����ҽ���˶�, false);
                    dict.Add(BtnTszlZcQm, true);
                    dict.Add(btnCheck, true);
                    dict.Add(btnDelete, false);
                    dict.Add(butorderprint, true);
                    dict.Add(btִ��ʱ��, false);
                    dict.Add(bt�˳�, true);
                }
                if (dict.Count < 1)
                    return;
                foreach (System.Collections.Generic.KeyValuePair<Button, bool> pair in dict)
                    pair.Key.Enabled = pair.Value;
            }
        }

        private void btȡ����ҽ���˶�_EnabledChanged(object sender, EventArgs e)
        {
            if ((isSSMZ && tabControl1.SelectedTab == tabPage6))    //add pengyang 2015-7-30
            {
                btȡ����ҽ���˶�.EnabledChanged -= btȡ����ҽ���˶�_EnabledChanged;
                btȡ����ҽ���˶�.Enabled = false;
                btȡ����ҽ���˶�.EnabledChanged += btȡ����ҽ���˶�_EnabledChanged;
            }
        }

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataTable myTb1 = (DataTable)myDataGrid2.DataSource;
            if (myTb1 == null || myTb1.Rows.Count == 0)
            {
                return;
            }

            if ((myDataGrid2.DataSource as DataTable).DefaultView.Count <= 0)
                return;

            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);

            DataRow dr;

            if (!ucShowCard1.Key.Trim().Equals(""))
            {
                DataRow[] drs = myTb1.Select("inpatient_id='" + ucShowCard1.Key + "'");
                if (drs.Length <= 0)
                    return;

                dr = drs[0];
            }
            else
            {
                dr = myTb1.Rows[nrow];
            }

            //Modify By Tany 2010-01-29 �д�����ʾ���ţ�û�д�����ʾסԺ��
            string bz = "";
            if (myTb1.Columns.Contains("����"))
            {
                //bz = "(" + Convert.ToString(myTb1.Rows[nrow]["����"]).Trim() + "��)";
                bz = "(" + Convert.ToString(dr["����"]).Trim() + "��)";
            }
            else if (myTb1.Columns.Contains("סԺ��"))
            {
                //bz = "(" + Convert.ToString(myTb1.Rows[nrow]["סԺ��"]).Trim() + ")";
                bz = "(" + Convert.ToString(dr["סԺ��"]).Trim() + ")";
            }
            //this.sName = Convert.ToString(myTb1.Rows[nrow]["����"]).Trim() + bz;
            //ClassStatic.Current_BinID = new Guid(myTb1.Rows[nrow]["inpatient_id"].ToString());
            //ClassStatic.Current_BabyID = Convert.ToInt64(myTb1.Rows[nrow]["baby_id"]);
            //ClassStatic.Current_DeptID = Convert.ToInt64(myTb1.Rows[nrow]["dept_id"]);
            //ClassStatic.Current_isMY = Convert.ToInt16(myTb1.Rows[nrow]["ismy"]);
            this.sName = Convert.ToString(dr["����"]).Trim() + bz;
            ClassStatic.Current_BinID = new Guid(dr["inpatient_id"].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(dr["baby_id"]);
            ClassStatic.Current_DeptID = Convert.ToInt64(dr["dept_id"]);
            ClassStatic.Current_isMY = Convert.ToInt16(dr["ismy"]);

            //�õ����˻�����Ϣ
            this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb != null) myTb.Rows.Clear();
            this.myDataGrid1.DataSource = myTb;

            this.ShowData();
        }


        private void myDataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //�ύ��������
            if (ncol > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0)
            {
                this.priceInfo1.ClearYpInfo();
                return;
            }

            //�����ҽ��������
            if (ncol == 25)
            {
                //��ʾҩƷ��Ϣ
                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb.Rows.Count > 0)
                {
                    double myNUM = 0;
                    int myCJID = Convert.ToInt32(myTb.Rows[nrow]["hoitem_id"]);
                    //add by zouchihua 2012-6-22 �����ʱҽ��������
                    if (this.tabControl1.SelectedTab.Text.IndexOf("����") >= 0)
                    {
                        if (myTb.Rows[nrow]["zsl"].ToString() != "")
                            myNUM = Convert.ToDouble(myTb.Rows[nrow]["zsl"]);
                        else
                            myNUM = Convert.ToDouble(myTb.Rows[nrow]["Num"]);
                    }
                    else
                        myNUM = Convert.ToDouble(myTb.Rows[nrow]["Num"]);
                    int myDWLX = Convert.ToInt32(myTb.Rows[nrow]["dwlx"]);
                    long myEXECDEPT = Convert.ToInt64(myTb.Rows[nrow]["exec_dept"]);
                    int myTYPE = Convert.ToInt32(myTb.Rows[nrow]["nType"]);
                    this.priceInfo1.Order_context = myTb.Rows[nrow]["ҽ������"].ToString();
                    //��Ч���ж�
                    if (myTYPE < 3 && myTYPE != 0)
                    {
                        //Modify By tany 2011-04-12 ��ȡ����ҽ������
                        int yblx = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select yblx from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"));
                        this.priceInfo1.SetYpInfo(myCJID, myNUM, myDWLX, myEXECDEPT, yblx);
                    }
                    else
                    {
                        this.priceInfo1.ClearYpInfo();
                        if (myTYPE == 3)
                        {
                            string sSql = "";
                            if (this.tabControl1.SelectedTab.Text.IndexOf("����") < 0)
                                sSql = " select Order_context ���� ,Num ���� ,Unit ��λ" +
                                   "   from zy_orderrecord " +
                                   "  where group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() +
                                   "        and mngtype not in (1,5) and delete_bit=0" +
                                   "        and Inpatient_ID ='" + ClassStatic.Current_BinID + "'" +
                                   "        and baby_id=" + ClassStatic.Current_BabyID;
                            else
                                sSql = " select Order_context ���� ,zsl ���� ,zsldw ��λ" +
                                "   from zy_orderrecord " +
                                "  where group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() +
                                "        and mngtype  in (1,5) and delete_bit=0" +
                                "        and Inpatient_ID ='" + ClassStatic.Current_BinID + "'" +
                                "        and baby_id=" + ClassStatic.Current_BabyID;
                            string[] GrdMappingName3 ={ "����", "����", "��λ" };
                            int[] GrdWidth3 ={ 13, 8, 4 };
                            int[] Alignment3 ={ 0, 1, 1 };
                            myFunc.InitGridSQL(sSql, GrdMappingName3, GrdWidth3, Alignment3, this.myDataGrid3);
                            this.myDataGrid3.CaptionText = "�в�ҩ������" + myTb.Rows[nrow]["Dosage"].ToString().Trim() + "��";
                            this.myDataGrid3.Refresh();
                        }
                        else
                        {
                            long HOitem_ID = Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["hoitem_id"].ToString(), "0"));
                            double num = 0;//Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            //add by zouchihua 2012-6-22 �����ʱҽ��������
                            if (this.tabControl1.SelectedTab.Text.IndexOf("����") >= 0)
                            {
                                if (myTb.Rows[nrow]["zsl"].ToString() != "")
                                    num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["zsl"].ToString(), "0"));
                                else
                                    num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            }
                            else
                                num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            string User_Name = myTb.Rows[nrow]["order_usage"].ToString();

                            //							this.myDataGrid3.TableStyles.Clear();
                            //add by zouchihua ���ҽ���з��ã���ô����ʾҽ���ķ���
                            string order_id = Convert.ToString(Convertor.IsNull(myTb.Rows[nrow]["order_id"].ToString(), Guid.Empty.ToString()));
                            DataTable orderfee = FrmMdiMain.Database.GetDataTable("select  PRICE from ZY_ORDERRECORD where order_id='" + order_id + "'");
                            decimal xmfee = -1;
                            if (orderfee.Rows.Count > 0)
                            {
                                xmfee = decimal.Parse(orderfee.Rows[0]["PRICE"].ToString());
                            }
                            DataTable myTbTemp = myFunc.SetItemInfo("", HOitem_ID, num, User_Name, (new Department(myEXECDEPT, InstanceForm.BDatabase)).Jgbm); //*js);
                            if (xmfee > 0)
                            {
                                myTbTemp.Rows[0]["����"] = xmfee;
                                myTbTemp.Rows[0]["���"] = xmfee * Convert.ToDecimal(myTbTemp.Rows[0]["����"].ToString());
                            }
                            this.myDataGrid3.DataSource = myTbTemp;

                            string[] GrdMappingName4 ={ "id", "����", "����", "��λ", "����", "���" };
                            int[] GrdWidth4 ={ 0, 12, 4, 4, 4, 6 };
                            int[] Alignment4 ={ 0, 0, 0, 0, 0, 0 };
                            int[] Readonly4 ={ 0, 0, 0, 0, 0, 0 };
                            myFunc.InitGrid(GrdMappingName4, GrdWidth4, Alignment4, Readonly4, this.myDataGrid3);

                            this.myDataGrid3.CaptionText = "��Ŀ��ϸ";
                            this.myDataGrid3.Refresh();
                        }
                    }

                    if (myTb.Rows.Count > 0)
                    {
                        try
                        {
                            //this.tabPage10.Show();
                            //this.tabControl2.SelectedIndex = 1;
                            string sql = @"select a.HOITEM_ID ,isnull(c.HOITEM_ID,0) glfyyzid from ZY_ORDERRECORD a left join JC_USEAGE_FEE b on  a.ORDER_USAGE=b.USE_NAME
                            left join  JC_HOI_HDI  c on c.HDITEM_ID=b.HSITEM_ID and TC_FLAG<=0 where order_id='" + myTb.Rows[nrow]["order_id"] + "'";
                            DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
                            int type = 0;
                            if (this.GetMNGType() == 0 || this.GetMNGType() == 2)
                            {
                                type = 2;
                            }
                            else
                            {
                                type = 3;
                            }
                            this.ucWzxm1.Itemidsf = myTb.Rows[nrow]["HOITEM_ID"].ToString();
                            this.ucWzxm1.Order_id = myTb.Rows[nrow]["order_id"].ToString();//add by zouchihua 2014-8-25 ����ԭ����ҽ��id
                            this.ucWzxm1.Fjfy_yzid = int.Parse(myTb.Rows[nrow]["glfyyzid"].ToString());//add by zouchihua 2014-8-25 ���ӹ������õ�ҽ��id
                            this.ucWzxm1.BinID = ClassStatic.Current_BinID;
                            this.ucWzxm1.BabyID = ClassStatic.Current_BabyID;
                            this.ucWzxm1.RbIn = rbIn.Checked ? true : false;
                            this.ucWzxm1.Yztype = type;
                            this.ucWzxm1.IsSSMZ = isSSMZ;
                            this.ucWzxm1.RbTszl = rbTszl.Checked ? true : false;
                            this.ucWzxm1.MyTb = myTb;
                            this.ucWzxm1.Nrow = nrow;
                            this.ucWzxm1.First_times = dr["first_times"].ToString();
                            this.ucWzxm1.Dept_id = Convert.ToInt32(dr["DEPT_ID"].ToString());
                            this.ucWzxm1.BingData();
                        }
                        catch { }

                    }
                    else
                    {
                        this.tabPage10.Hide();
                        this.tabControl2.SelectedIndex = 0;
                    }

                    //add by zouchihua 2012-6-15 δִ�е�����
                    if (Convert.ToInt16(myTb.Rows[nrow]["wzx_flag"]) > 0)
                    {
                        RichTextBox txtb = new RichTextBox();
                        txtb.ReadOnly = true;
                        txtb.Dock = DockStyle.Fill;
                        txtb.Multiline = true;
                        txtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        txtb.BackColor = ReasenPanel.BackColor;
                        txtb.Width = ReasenPanel.Width;
                        txtb.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        DataTable tb11 = null;
                        if (myTb.Rows[nrow]["order_id"].ToString() != Guid.Empty.ToString())
                            tb11 = FrmMdiMain.Database.GetDataTable("select memo2 from zy_orderrecord where order_id='" + myTb.Rows[nrow]["order_id"].ToString() + "'");
                        else
                            tb11 = FrmMdiMain.Database.GetDataTable("select memo2 from zy_orderrecord where group_id='" + myTb.Rows[nrow]["group_id"].ToString() + "' and inpatient_id='" + ClassStatic.Current_BinID + "'");
                        txtb.Text = "δִ��ԭ��:�� " + tb11.Rows[0]["memo2"].ToString() + " ��";
                        ReasenPanel.Controls.Clear();
                        ReasenPanel.Controls.Add(txtb);
                        Rectangle rt = this.myDataGrid1.GetCurrentCellBounds();
                        Point pt = new Point(this.myDataGrid1.Left + this.myDataGrid1.Parent.Left + this.myDataGrid1.Parent.Parent.Left + rt.Location.X, this.myDataGrid1.Top + this.myDataGrid1.Parent.Top + this.myDataGrid1.Parent.Parent.Top + rt.Location.Y + rt.Height + 30);
                        ReasenPanel.Location = pt;
                        ReasenPanel.BringToFront();
                        ReasenPanel.Visible = true;
                        ReasenPanel.Show();
                    }
                    else
                    {
                        ReasenPanel.Hide();
                        ReasenPanel.Visible = false;
                    }
                }

            }
            else
            {
                ReasenPanel.Hide();
                ReasenPanel.Visible = false;
            }


        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.myDataGrid3_Clear();
            myFunc.SelRow(this.myDataGrid3);
            //add yaokx  2014-06-03
            int nrow = 0;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int nType = this.GetMNGType();

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            if (nType == 1 || nType == 5)
            {
                if (myTb.Rows[nrow]["ҽ������"].ToString().IndexOf("ȡ��") >= 0)
                {
                    this.btִ��ʱ��.Enabled = false;
                }
                else
                {
                    this.btִ��ʱ��.Enabled = true;
                }
            }
        }

        private void myDataGrid1_Click(object sender, System.EventArgs e)
        {
            //����BOOL��
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //�ύ��������
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            //add yaokx  2014-06-03
            int nType = this.GetMNGType();
            if (nType == 1 || nType == 5)
            {
                if (myTb.Rows[nrow]["ҽ������"].ToString().IndexOf("ȡ��") >= 0)
                {
                    this.btִ��ʱ��.Enabled = false;
                }
                else
                {
                    this.btִ��ʱ��.Enabled = true;
                }
            }
            //-�Ƿ�����ʿվ���Ե��ȡ����ӡ 0=��1=��
            string cfg7106 = new SystemCfg(7106).Config.Trim();//add by zouchihua 2012-3-9
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.ToUpper().Trim() == "P")
            {
                //add by zouchihua 2012-3-9
                if (cfg7106 == "0")
                    return;
                bool del_print = Convert.ToBoolean(myTb.Rows[nrow]["P"]);
                Guid order_id = new Guid(myTb.Rows[nrow]["order_id"].ToString());
                string ssql = " ";
                int zcy = 0;
                //add by zouchihua 2012-5-22 �в�ҩ����
                if (myTb.Rows[nrow]["ҽ������"].ToString().IndexOf("�в�ҩ����") >= 0)
                {
                    zcy = 1;
                    ssql = "select order_id from zy_tmporderprt(nolock) where order_id in( select order_id from zy_orderrecord where ntype=3 and  inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString() + " )"
                       + " union all select order_id from zy_logorderprt(nolock) where order_id in( select order_id from zy_orderrecord where ntype=3 and  inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString() + " )";
                }
                else
                    ssql = "select order_id from zy_tmporderprt(nolock) where order_id='" + order_id + "' union all select order_id from zy_logorderprt(nolock) where order_id='" + order_id + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count != 0)
                {
                    MessageBox.Show("����ҽ���ѱ����ɵ�ҽ����ӡ����,����ȡ����ӡ\n ֻҪ��ҽ����ӡ��Ԥ����,�����ɴ�ӡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (del_print == true)
                {
                    if (MessageBox.Show(this, "��Ҫ��ҽ�� [Ҫ] ��ӡ��?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }
                else
                {
                    if (MessageBox.Show(this, "ȷ����ҽ�� [��Ҫ] ��ӡ��?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }

                if (del_print == true)
                {
                    if (zcy == 0)
                        ssql = "update zy_orderrecord set del_print=0 where order_id='" + order_id + "'";
                    else
                        ssql = "update zy_orderrecord set del_print=0 where order_id in( select order_id from zy_orderrecord where ntype=3 and  inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString() + " )";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    myTb.Rows[nrow]["P"] = false;
                }
                else
                {
                    if (zcy == 0)
                        ssql = "update zy_orderrecord set del_print=1 where order_id='" + order_id + "'";
                    else
                        ssql = "update zy_orderrecord set del_print=1 where order_id in( select order_id from zy_orderrecord where ntype=3 and  inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString() + " )";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    myTb.Rows[nrow]["P"] = true;
                }

            }
            else
                if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() == "isprintypgg")//add by zouchihua 2011-11-30
                {
                    //add by zouchihua 2012-3-9
                    if (cfg7106 == "0")
                        return;
                    bool del_print = Convert.ToBoolean(myTb.Rows[nrow]["isprintypgg"]);

                    Guid order_id = new Guid(myTb.Rows[nrow]["order_id"].ToString());
                    string ssql = " ";
                    ssql = "select order_id from zy_tmporderprt(nolock) where order_id='" + order_id + "' union all select order_id from zy_logorderprt(nolock) where order_id='" + order_id + "'";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count != 0)
                    {
                        MessageBox.Show("����ҽ���ѱ����ɵ�ҽ����ӡ����,���ܲ�������\n ֻҪ��ҽ����ӡ��Ԥ����,�����ɴ�ӡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    if (del_print == true)
                    {
                        if (MessageBox.Show(this, "ȷ����ҽ�����[��Ҫ] ��ӡ��?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }
                    else
                    {
                        if (MessageBox.Show(this, "��Ҫ��ҽ����� [Ҫ] ��ӡ��?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }

                    if (del_print == true)
                    {
                        ssql = "update zy_orderrecord set isprintypgg=0 where order_id='" + order_id + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                        myTb.Rows[nrow]["isprintypgg"] = false;
                    }
                    else
                    {
                        ssql = "update zy_orderrecord set isprintypgg=1 where order_id='" + order_id + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                        myTb.Rows[nrow]["isprintypgg"] = true;
                    }

                }
            //��"ѡ"�ֶ�
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "ѡ") return;
            if (nrow > myTb.Rows.Count - 1) return;

            if (myTb.Rows[nrow]["ѡ"].ToString().Trim() == "1")
            {
                myTb.Rows[nrow]["ѡ"] = false;
                return;
            }

            bool isResult = myTb.Rows[nrow]["ѡ"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["ѡ"] = isResult;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["Group_id"].ToString().Trim() == myTb.Rows[nrow]["Group_id"].ToString().Trim()
                    && myTb.Rows[i]["ѡ"].ToString() != isResult.ToString())
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["ѡ"] = isResult;
                    //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                }
            }


            this.myDataGrid1.DataSource = myTb;
            //this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);			
        }

        /// <summary>
        /// �����ַ������Ӵ����ֵĴ���
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="substring">�Ӵ�</param>
        /// <returns>���ֵĴ���</returns>
        private int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }

            return -1;
        }
        private void myDataGrid1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count == 0) return;

                int i = 0;
                int yDelta = this.myDataGrid1.GetCellBounds(i, 0).Height + 1;
                int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

                int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
                int start_row = 0, start_point = 0;

                CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid1.DataSource, this.myDataGrid1.DataMember];

                while (y < this.myDataGrid1.Height - yDelta && i < cm.Count)
                {
                    y += yDelta;

                    try
                    {
                        //δִ��
                        index_start = this.sPaintWZX.IndexOf("i" + i.ToString() + "X", 0, this.sPaintWZX.Trim().Length);
                        if (index_start >= 0)
                        {
                            e.Graphics.DrawString("δִ��", this.myDataGrid1.Font, new SolidBrush(Color.Red), 650, y - yDelta);
                        }
                    }
                    catch { }

                    try
                    {
                        //Ƥ��+
                        int count = SubstringCount(this.sPaintPS.ToString(), "+");
                        index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "+", 0, this.sPaintPS.Trim().Length);
                        if (index_start >= 0)
                        {
                            //313/224
                            index_p = this.sPaintPS.IndexOf("+", index_start, this.sPaintPS.Trim().Length - index_start);
                            index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                            string strCtn = sPaintPS.Substring(index_start + 1, index_end - index_start - 1);
                            count = SubstringCount(strCtn.ToString(), "+");
                            if (index_start >= 0 && count == 1)//&& count==1���Ҫȥ��
                            {
                                start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                                e.Graphics.DrawString("(+)", this.myDataGrid1.Font, new SolidBrush(Color.Red), start_point - 100, y - yDelta);

                            }
                        }
                    }
                    catch { }

                    try
                    {
                        int count = SubstringCount(this.sPaintPS.ToString(), "+");
                        //Ƥ��++
                        index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "++", 0, this.sPaintPS.Trim().Length);
                        if (index_start >= 0)
                        {
                            index_p = this.sPaintPS.IndexOf("++", index_start, this.sPaintPS.Trim().Length - index_start);
                            index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                            string strCtn = sPaintPS.Substring(index_start + 1, index_end - index_start - 1);
                            count = SubstringCount(strCtn.ToString(), "+");
                            if (index_start >= 0 && count == 2)
                            {
                                //313/224
                                index_p = this.sPaintPS.IndexOf("++", index_start, this.sPaintPS.Trim().Length - index_start);
                                index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                                start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 2, index_end - index_p - 2)) * 6;
                                e.Graphics.DrawString("(++)", this.myDataGrid1.Font, new SolidBrush(Color.Red), start_point - 100, y - yDelta);

                            }
                        }
                    }
                    catch { }

                    try
                    {
                        //Ƥ��+
                        int count = SubstringCount(this.sPaintPS.ToString(), "+");
                        //Ƥ��+++
                        index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "+++", 0, this.sPaintPS.Trim().Length);
                        if (index_start >= 0)
                        {
                            index_p = this.sPaintPS.IndexOf("+++", index_start, this.sPaintPS.Trim().Length - index_start);
                            index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                            string strCtn = sPaintPS.Substring(index_start + 1, index_end - index_start - 1);
                            count = SubstringCount(strCtn.ToString(), "+");
                            if (index_start >= 0 && count == 3)
                            {
                                index_p = this.sPaintPS.IndexOf("+++", index_start, this.sPaintPS.Trim().Length - index_start);
                                index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                                start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 3, index_end - index_p - 3)) * 6;
                                e.Graphics.DrawString("(+++)", this.myDataGrid1.Font, new SolidBrush(Color.Red), start_point - 100, y - yDelta);

                            }
                        }
                    }
                    catch { }

                    try
                    {
                        //Ƥ��-
                        index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "-", 0, this.sPaintPS.Trim().Length);
                        if (index_start >= 0)
                        {
                            index_p = this.sPaintPS.IndexOf("-", index_start, this.sPaintPS.Trim().Length - index_start);
                            index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                            start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                            switch (this.sPaintPS.Substring(index_end + 1, 1))
                            {
                                case "1":  //δ���
                                    e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Black), start_point - 100, y - yDelta);
                                    break;
                                case "5":  //��ֹͣ
                                    e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Gray), start_point - 100, y - yDelta);
                                    break;
                                default: //�����
                                    e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Blue), start_point - 100, y - yDelta);
                                    break;
                            }

                        }
                    }
                    catch { }

                    try
                    {
                        //����
                        index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                        if (index_start >= 0)
                        {
                            index_i = index_start + i.ToString().Trim().Length + 1;
                            index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                            start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                            if (this.max_len1 == 0) start_point = 119 + (this.max_len0 + 4) * 6;
                            else start_point = 119 + (this.max_len1 + this.max_len2 + 4) * 6;
                            switch (this.sPaint.Substring(index_end + 1, 1))
                            {
                                case "1":  //δ���
                                    e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                                    break;
                                case "5":  //��ֹͣ
                                    e.Graphics.DrawLine(System.Drawing.Pens.Gray, start_point, y - start_row * yDelta, start_point, y - 5);
                                    break;
                                default: //�����
                                    e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                                    break;
                            }
                        }
                    }
                    catch { }

                    i++;
                }
            }
            catch { }
        }


        private void btȫѡ_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["status_flag"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                if (tabControl1.SelectedTab == tabPage7)
                {
                    if (myTb.Rows[i]["ִ��ʱ��"].ToString().Trim().Equals(""))
                    {
                        myTb.Rows[i]["ѡ"] = true;
                    }
                    else
                    {
                        myTb.Rows[i]["ѡ"] = false;
                    }
                }
                else
                {
                    myTb.Rows[i]["ѡ"] = true;
                }
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt��ѡ_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["status_flag"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["ѡ"] = myTb.Rows[i]["ѡ"].ToString() == "True" ? false : true;
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt��ʾ�л�_Click(object sender, System.EventArgs e)
        {
            if (this.panel����.Height == 176)
            {
                this.panel����.Height = 48;
                this.myDataGrid1.Height = 640;
            }
            else
            {
                this.myDataGrid1.Height = 512;
                this.panel����.Height = 176;
            }

        }

        private void bt����ִ��_Click(object sender, System.EventArgs e)
        {

            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //�����������ϵͳ�Ѿ���Ժ��ˣ��������ټǷ�
            if (TrasenHIS.BLL.CheckPatientInfo.isCysh(patientInfo1.lbID.Text.ToString().Trim()))
            {
                MessageBox.Show("�ò�����סԺ���Ѿ���Ժ��ˣ����ܷ���ҽ��������ϵסԺ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            #region//Add by Zouchihua 2011-10-12 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
            int BrJgbm = Convert.ToInt32(rtnSql[1]);
            #endregion
            string sSql = "";
            string sGroupId = "-1";
            string sMsg = "";
            string sEnableGroup = "";
            int iSelectRows = 0;
            DataTable myTb = (DataTable)myDataGrid1.DataSource;

            //Modify By Tany 2015-05-11 ������Ƿ�ֻ�����ο��Է���ҽ��
            if (isSSMZ && ssmzType == 1)
            {
                //����Ʒ���ҽ��ʱ���Ƿ�ֻ������ҽʦ������ܷ��� 0=�� 1=��
                if (new SystemCfg(9101).Config == "1")
                {
                    try
                    {
                        Doctor doc = new Doctor(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                        if (doc.TypeID != 1)
                        {
                            throw new Exception("���û�ҽ������������ҽʦ��");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("����ҽ��ֻ�����β��ܷ��ͣ�������ȷ����ݣ�\r\n" + ex.Message);
                        return;
                    }
                }
            }

            #region ��Ч���ж�
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }
            #endregion

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ��ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmBRFS f2 = new frmBRFS();
            if (isSSMZ)
            {
                f2.grpCQYZ.Enabled = false;
                f2.grpCQZD.Enabled = false;
                f2.rbȫ������.Enabled = false;
                f2.rb00.Enabled = false;
                f2.rb01.Enabled = false;
                f2.rb02.Enabled = false;
                f2.rb10.Enabled = false;
                f2.rb20.Enabled = false;
                f2.rb21.Enabled = false;
                f2.rb22.Enabled = false;
                f2.rb30.Enabled = false;
            }
            f2.nType = this.GetMNGType();
            f2.ShowDialog();

            if (f2.DialogResult == DialogResult.Cancel)
                return;

            int iSelect = f2.iSelect;
            if (iSelect == 2) return;
            int iSelect0 = f2.iSelect0;
            int iSelect1 = f2.iSelect1;
            int iSelect2 = f2.iSelect2;
            int iSelect3 = f2.iSelect3;
            bool IsChangeExecDept = f2.IsChangeExecDept;
            int newExecDept = f2.newExecDept;
            DateTime ExecDate = f2.execDateTime;
            ((Button)sender).Tag = f2.execDateTime;



            //Modify by jchl 2016-12-28-----------------------------------------
            DateTime serDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//PubStaticFun.GetDateFromGuid(PubStaticFun.NewGuid());
            int ExecYear = ExecDate.Year;
            int ServerYear = serDate.Year;
            if (ServerYear == 2016 && ExecYear == 2017)
            {
                if (MessageBox.Show("��Ϊ��״���ۣ�����ҽԺ��ͳһ�����ţ�ֻ�ܽ�ҽ��������2016.12.31�գ��Ƿ������\n" + sMsg,
                    "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }

            DateTime dtMinFee = DateTime.Parse("2016-12-31 23:55:00");
            DateTime dtMaxFee = DateTime.Parse("2017-01-01 00:20:00");
            if (serDate >= dtMinFee && serDate <= dtMaxFee)
            {
                MessageBox.Show("��Ϊ��״���ۣ�����ҽԺ��ͳһ�����ţ�12��31�� 23:55�Ժ� �� ����1��1�� 00:20 Ϊ�����ڼ䣬���в��˲�������ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dtMin = DateTime.Parse("2016-12-31 18:00:00");
            DateTime dtMax = DateTime.Parse("2017-01-01 00:10:00");
            if (patientInfo1.lbJSLX.Text.IndexOf("ҽ��") >= 0)
            {
                if (serDate >= dtMin && serDate <= dtMax)
                {
                    MessageBox.Show("��Ϊ��״���ۣ�����ҽԺ��ͳһ�����ţ�12��31�� 18�� �� ����0:10�� ҽ�����˲�������ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //------------------------------------------------------------------

            //�ж�ҩƷ����Ч�ԣ��õ���Ҫ����ִ�п��ҵ�ҽ�������
            #region �Ƿ����ִ�п���
            if (IsChangeExecDept)
            {
                //ѡ�е�ҽ��
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                    {
                        if ((myTb.Rows[i]["ntype"].ToString().Trim() == "1"
                            || myTb.Rows[i]["ntype"].ToString().Trim() == "2"
                            || myTb.Rows[i]["ntype"].ToString().Trim() == "3")
                            && myTb.Rows[i]["status_flag"].ToString().Trim() == "2")
                        {
                            sSql = "select 1 from mzyf_ypcl where s_hh='" + myTb.Rows[i]["item_code"].ToString().Trim() + "' and deptid=" + newExecDept;
                            DataTable medTb = InstanceForm.BDatabase.GetDataTable(sSql);

                            if (medTb == null || medTb.Rows.Count == 0)
                            {
                                sMsg += " �� " + myTb.Rows[i]["ҽ������"].ToString().Trim() + "\n";
                                sEnableGroup = myTb.Rows[i]["group_id"].ToString().Trim();
                                sGroupId = sGroupId.Replace(myTb.Rows[i]["group_id"].ToString().Trim(), "-1");
                            }
                            else
                            {
                                if (myTb.Rows[i]["group_id"].ToString().Trim() != sEnableGroup)
                                    sGroupId += "," + myTb.Rows[i]["group_id"].ToString().Trim();
                            }
                        }
                    }
                }
            }
            #endregion

            if (sMsg.Trim() != "")
            {
                if (MessageBox.Show("����ҽ����Ϊ�����ĵ�ִ�п�����û�и���ҩƷ�������ܱ����ͣ��Ƿ������\n���ܸ���ִ�п��ҵ�ҽ��������\n" + sMsg,
                    "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }

            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
            }
            bool isHSZ = myFunc.IsHSZ(InstanceForm.BCurrentUser.EmployeeId);

            //����
            Cursor.Current = PubStaticFun.WaitCursor();

            //			//�������ݷ��ʶ���
            //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
            //			database.Initialize("");
            //			database.Open();           
            //add by zouchihua 2013-3-15 ����Ϊ0���Ƿ���ʾ
            try
            {
                if ((new SystemCfg(7146)).Config.Trim() == "1" && Convert.ToDecimal(this.patientInfo1.lbYE.Text) <= 0)
                {
                    if (MessageBox.Show("�ò��˷������Ϊ��" + this.patientInfo1.lbYE.Text + "�����Ƿ����ִ��ҽ����\n",
                       "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                }
            }
            catch
            {
                myDataGrid2_CurrentCellChanged(null, null);
                if ((new SystemCfg(7146)).Config.Trim() == "1" && Convert.ToDecimal(this.patientInfo1.lbYE.Text) <= 0)
                {
                    if (MessageBox.Show("�ò��˷������Ϊ��" + this.patientInfo1.lbYE.Text + "�����Ƿ����ִ��ҽ����\n",
                       "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
            }
            try
            {
                bool _qfExeCurDeptOrder = false;//Ƿ���Ƿ��ܹ����ͱ�����ҽ��

                int _flag = 0;
                //��������Ժ����Ƿ��ִ��ҽ�������жϲ��˵�ǰ��״̬��Ҫ����Ĭ��Ϊ0
                if ((new SystemCfg(7042)).Config == "��")
                {
                    _flag = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select flag from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"), "0"));
                }
                //����������������Ժ�����������ж� Modifuy By Tany 2007-12-05
                if ((new SystemCfg(7001)).Config == "��" && !isSSMZ && _flag != 4)
                {
                    try
                    {
                        if (Convert.ToInt32(ClassStatic.Current_BabyID) == 0
                            || (Convert.ToInt32(ClassStatic.Current_BabyID) != 0 && (new SystemCfg(7002)).Config == "��"))
                        {
                            decimal _ye = 0;

                            SystemCfg sysCfg = new SystemCfg(7040);
                            //ҽ�����Ϳ���Ƿ���Ƿ�ǿ�ư���Ԥ�����
                            if (sysCfg.Config == "��")
                            {
                                btԤ��_Click(sender, e);
                                _ye = Convert.ToDecimal(patientInfo1.lbYE.Text.Trim() == "" ? "0" : patientInfo1.lbYE.Text.Trim()) - orderfee;
                            }
                            else
                            {
                                _ye = Convert.ToDecimal(patientInfo1.lbYE.Text.Trim() == "" ? "0" : patientInfo1.lbYE.Text.Trim());
                            }
                            //Modify By Tany 2010-06-18 �����ҽ�����ˣ����=Ԥ����-�ܷ���*���ñ���
                            if (patientInfo1.lbJSLX.Text.IndexOf("ҽ��") >= 0)
                            {
                                decimal fee = 0;
                                decimal yjj = 0;
                                //Modify by zouchihua 20121-5-10 
                                if (patientInfo1.lbWJSFY.Text.Trim().IndexOf("(") > 0)
                                    fee = Convert.ToDecimal(patientInfo1.lbWJSFY.Text.Trim() == "" ? "0" : patientInfo1.lbWJSFY.Text.Trim().Substring(0, patientInfo1.lbWJSFY.Text.Trim().IndexOf("(")).Trim());
                                else
                                    fee = Convert.ToDecimal(patientInfo1.lbWJSFY.Text.Trim() == "" ? "0" : patientInfo1.lbWJSFY.Text.Trim());
                                yjj = Convert.ToDecimal(patientInfo1.lbYJK.Text.Trim() == "" ? "0" : patientInfo1.myRow["YJK"].ToString().Trim());

                                if (cfg7186.Config.Trim() == "0")
                                {
                                    //�����жϷ��ñ����ǲ���С��1���������1������Ҫ����
                                    decimal bl = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select b.yjj_bl from zy_inpatient a left join jc_yblx b on a.yblx=b.id where a.dischargetype=1 and a.inpatient_id='" + ClassStatic.Current_BinID + "'"), "1"));
                                    //Modify By Tany 2010-08-07 ����=0��ʱ���൱�ڲ�����Ƿ��
                                    if (bl >= 0 && bl < 1)
                                    {
                                        if (sysCfg.Config == "��")
                                        {
                                            _ye = yjj - (fee * bl) - (orderfee * bl);
                                        }
                                        else
                                        {
                                            _ye = yjj - (fee * bl);
                                        }
                                    }
                                }
                                else
                                {

                                    #region  add by zouchihua 2014-3-10����ҽ��������п���
                                    string ybfy = @"select isnull(SUM(XJZF),0) fee from 
                                (
                                select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id='" + ClassStatic.Current_BinID + @"'  order by YBJS_DATE desc
                                 union all
                                select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and DISCHARGE_BIT=0 and inpatient_id='" + ClassStatic.Current_BinID + @"'
                                ) aa
                                ";
                                    DataTable tbybfy = InstanceForm.BDatabase.GetDataTable(ybfy);
                                    if (tbybfy.Rows.Count > 0)
                                    {
                                        fee = decimal.Parse(tbybfy.Rows[0]["fee"].ToString());
                                    }
                                    if (sysCfg.Config == "��")
                                    {
                                        _ye = yjj - (fee) - (orderfee);
                                    }
                                    else
                                    {
                                        _ye = yjj - (fee);
                                    }
                                    #endregion
                                }
                            }
                            //�жϲ��˵����
                            decimal zdje = myFunc.GetPatMinExecYE(ClassStatic.Current_BinID);
                            bool zgflag = true;
                            #region ��ְ����λ��������
                            if (new SystemCfg(7204).Config == "1")
                            {
                                string zgje = "0";
                                string iszgsql = @"select * from ZY_INPATIENT_SUPPLY where PATIENTTYPE=1 and CHARGETYPE=1 and INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                                DataTable mydtzg = FrmMdiMain.Database.GetDataTable(iszgsql);
                                if (mydtzg != null && mydtzg.Rows.Count > 0)
                                {
                                    int _hour = Convert.ToInt32(new SystemCfg(7072).Config);
                                    DateTime _rysj = Convert.ToDateTime(FrmMdiMain.Database.GetDataResult("select in_date from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"));
                                    if (_rysj.AddHours(_hour) <= ExecDate && _ye < zdje)
                                    {
                                        SystemCfg cfg7204 = new SystemCfg(7204);
                                        zgje = cfg7204.Config;
                                        if (isHSZ == false || (new SystemCfg(7034)).Config == "��")//��ʿ���Ƿ��ܹ�Ƿ�ѷ��� Modify By Tany 2007-07-19
                                        {
                                            if ((new SystemCfg(7021)).Config == "��")
                                            {
                                                _qfExeCurDeptOrder = true;
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " ��ְ���������� " + patientInfo1.lbName.Text.Trim() + " �����Ϊ " +
                                                    _ye.ToString().Trim() + " Ԫ��" + ("��󵣱����Ϊ " + zgje.ToString() + " Ԫ�����������Ƿ�ѡ�") + zdje + "����֪ͨ�����Ա�������,Ŀǰֻ�ܷ��͸ò��˱���ִ�е�ҽ����", "��ʾ",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " ��ְ���������� " + patientInfo1.lbName.Text.Trim() + " �����Ϊ " +
                                                    _ye.ToString().Trim() + " Ԫ��" + ("��󵣱����Ϊ " + zgje.ToString() + " Ԫ�����������Ƿ�ѡ�") + zdje + "����֪ͨ�����Ա������ˣ�", "��ʾ",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                    }
                                    zgflag = false;
                                }

                            }
                            #endregion
                            //  MessageBox.Show("���" + _ye.ToString() + " ���Ƿ��" + zdje.ToString());
                            if (_ye < zdje && zgflag)
                            {
                                //ִ�е�����ҽ��

                                //Add By Tany 2010-11-27 ���ӶԲ�����Ժʱ����ж�
                                //7072������Ժ��Сʱ�����Ƿ�ѣ�0=�������ƣ�
                                int _hour = Convert.ToInt32(new SystemCfg(7072).Config);
                                DateTime _rysj = Convert.ToDateTime(FrmMdiMain.Database.GetDataResult("select in_date from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"));
                                if (_rysj.AddHours(_hour) <= ExecDate)
                                {
                                    SystemCfg cfg7204 = new SystemCfg(7204);
                                    if (isHSZ == false || (new SystemCfg(7034)).Config == "��")//��ʿ���Ƿ��ܹ�Ƿ�ѷ��� Modify By Tany 2007-07-19
                                    {
                                        if (cfg7204.Config == "1")
                                        {
                                            string str = "";
                                            decimal je = 0;
                                            string s = @"select * from ZY_INPATIENT_SUPPLY where CHARGETYPE in(0,2) and INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                                            DataTable mydt = FrmMdiMain.Database.GetDataTable(s);
                                            if (mydt != null && mydt.Rows.Count > 0)
                                            {
                                                if (mydt.Rows[0]["PATIENTTYPE"].ToString() == "1")
                                                {
                                                    switch (mydt.Rows[0]["CHARGETYPE"].ToString())
                                                    {
                                                        //��ͬ��λ
                                                        case "0":
                                                            str = "��ͬ��λ";
                                                            string sqlht = @"select * from JC_HTDW where ID=" + mydt.Rows[0]["HTDW"].ToString() + "";
                                                            DataTable mydt_ht = FrmMdiMain.Database.GetDataTable(sqlht);
                                                            if (mydt_ht != null && mydt_ht.Rows.Count > 0)
                                                            {
                                                                je = Convert.ToDecimal(Convertor.IsNull(mydt_ht.Rows[0]["maxmoney"], "0"));
                                                            }

                                                            break;
                                                        ////ְ������
                                                        //case "1":
                                                        //    str = "ְ������";

                                                        //    je = Convert.ToDecimal(Convertor.IsNull(new SystemCfg(5130).Config, "0"));
                                                        //    break;
                                                        //���ⵣ��
                                                        case "2":
                                                            str = "���ⵣ��";
                                                            je = Convert.ToDecimal(Convertor.IsNull(mydt.Rows[0]["NEWRANG_MONEY"], "0"));
                                                            break;
                                                        default:
                                                            str = "";
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    str = "";
                                                    je = Convert.ToDecimal(Convertor.IsNull(mydt.Rows[0]["NEWRANG_MONEY"], "0"));
                                               }
                                            }
                                            //7021����Ƿ���Ƿ���Է��ͱ����ҵ���Ŀ
                                            if ((new SystemCfg(7021)).Config == "��")
                                            {
                                                _qfExeCurDeptOrder = true;
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " ��" + str + "���� " + patientInfo1.lbName.Text.Trim() + " �����Ϊ " +
                                                    patientInfo1.lbYE.Text.Trim() + " Ԫ��" + ("��󵣱����Ϊ " + zdje.ToString() + " Ԫ��") + "��֪ͨ�����Ա������ˣ�", "��ʾ",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " ��" + str + "���� " + patientInfo1.lbName.Text.Trim() + " �����Ϊ " +
                                                    patientInfo1.lbYE.Text.Trim() + " Ԫ��" + ("��󵣱����Ϊ " + zdje.ToString() + " Ԫ��") + "��֪ͨ�����Ա������ˣ�", "��ʾ",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            //7021����Ƿ���Ƿ���Է��ͱ����ҵ���Ŀ
                                            if ((new SystemCfg(7021)).Config == "��")
                                            {
                                                _qfExeCurDeptOrder = true;
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " ������ " + patientInfo1.lbName.Text.Trim() + " �����Ϊ " +
                                                    patientInfo1.lbYE.Text.Trim() + " Ԫ��" + (orderfee == 0 ? "" : ("����Ԥ�����Ϊ " + orderfee + " Ԫ��")) + "��ֻ�ܷ��͸ò��˱���ִ�е�ҽ����", "��ʾ",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " ������ " + patientInfo1.lbName.Text.Trim() + " �����Ϊ " +
                                                    patientInfo1.lbYE.Text.Trim() + " Ԫ��" + (orderfee == 0 ? "" : ("����Ԥ�����Ϊ " + orderfee + " Ԫ��")) + "�����ܷ��͸ò���ҽ����", "��ʾ",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + "\n ҽ��ִ�г�����");
                    }
                }

                //��ʼһ������
                //				database.BeginTransaction();

                #region �ı�ҩƷִ�п���
                if (IsChangeExecDept)
                {
                    //ѡ�е�ҽ��
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                        {
                            //ҩƷҽ��
                            if ((myTb.Rows[i]["ntype"].ToString().Trim() == "1"
                                || myTb.Rows[i]["ntype"].ToString().Trim() == "2"
                                || myTb.Rows[i]["ntype"].ToString().Trim() == "3")
                                && myTb.Rows[i]["status_flag"].ToString().Trim() == "2")
                            {
                                sSql = "update zy_orderrecord set exec_dept=" + newExecDept + " where mngtype in(1,5) and group_id in (" + sGroupId + ")" +
                                    " and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                        }
                    }
                }
                #endregion

                #region"pivasδ���Ƿ�����ִ��ҩƷҽ��"

                //7605 pivasδ���Ƿ�����ִ��ҩƷҽ�� 0�� 1��
                //7602 pivas�������ݣ�Ĭ��Ϊ0��0:���� 1:���� 2:������
                if (cfg7605.Trim().Equals("0"))
                {
                    string strCfgMng = cfg7602.Trim();
                    string strMng = this.GetMNGType().ToString().Trim();

                    //ѡ�е�ҽ��
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                        {
                            if (strCfgMng.Equals(strMng) || (strCfgMng.Equals("2") && (strMng.Equals("1") || strMng.Equals("2"))))
                            {
                                bool bPvsChk = isPvsChkExe(ClassStatic.Current_BinID.ToString(), ClassStatic.Current_BabyID.ToString(), myTb.Rows[i]["Group_ID"].ToString().Trim());

                                if (!bPvsChk)
                                {
                                    MessageBox.Show("�ò�����pivasҽ��δ��ˣ�����ϵpivas����\n", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                }

                #endregion

                if (iSelect == 0)
                {
                    //ȫ������
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 9, 0, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                }
                else
                {
                    //���ͳ���ҽ��
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 0, iSelect0, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);

                    //������ʱҽ��
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 1, iSelect1, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);

                    //���ͳ����˵�
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 2, iSelect2, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);

                    //������ʱ�˵�
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 3, iSelect3, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                }


                //				database.CommitTransaction();
            }
            catch (Exception err)
            {
                //				database.RollbackTransaction();
                //				database.Close();

                //д������־ Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "ҽ��ִ�д���" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source + "\n\n�����Ѿ��ع������������ִ�У�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
                this.tabControl1_SelectedIndexChanged(sender, e);
                return;
            }

            //			database.Close();

            //ҽ�����ͣ����ˣ��Ƿ��Զ�����ҩƷͳ����Ϣ
            //Modify By Tany 2005-11-05
            if ((new SystemCfg(7022)).Config == "��")
            {
                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
                DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //��ͳ��ҩƷ����ҩ����Ϣ Modify By Tany 2005-09-13
                    myFunc.SendYPFY(0, 0, InstanceForm.BCurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                    //��ͳ��ҩƷ����ҩ�� Add by zouchihua 2012-4-22
                    myFunc.SendYPFY(2, 0, InstanceForm.BCurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                }
            }

            //Modify By Tany 2009-08-03
            //���˺ͷ��ͷֿ�
            if ((new SystemCfg(7047)).Config == "��")
            {
                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
                DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //��ͳ��ҩƷ����ҩ����Ϣ Modify By Tany 2005-09-13
                    myFunc.SendYPFY(0, 1, InstanceForm.BCurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                    //��ͳ��ҩƷ����ҩ�� Add by zouchihua 2012-4-22
                    myFunc.SendYPFY(2, 1, InstanceForm.BCurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                }
            }
            //add by yaokx 2014-03-12  ����Ժҽ����ת��ҽ��ʱ�Զ������һ��Ĵ�λ����
            #region ����Ժҽ��ʱ�Զ������һ��Ĵ�λ����
            string cfg7187 = new SystemCfg(7187).Config;
            if ((cfg7187 != "") && (GetMNGType() == 2 || GetMNGType() == 0))
            {
                string str = "";

                //if(cfg7187 != "")
                //{
                //    string[] ss = cfg7187.Split(',');
                //    for (int ii = 0; ii < ss.Length; ii++)
                //    {
                //        value += "'" + ss[ii] + "',";
                //    }
                //    str = value.Substring(0, value.Length - 1);
                //}
                DateTime dTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//ȡ���ݿ�ʱ��

                myFunc.GetCZcy(ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), cfg7187, dTime);

            }
            #endregion

            Cursor.Current = Cursors.Default;

            MessageBox.Show("������ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //ˢ�½���
            this.tabControl1_SelectedIndexChanged(sender, e);
        }

        private void bt��ϸ��Ϣ_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        nrow = i;
                        SelCount++;
                    }
                }
            }
            if (SelCount == 0)
            {
                MessageBox.Show("û��ѡ��ҽ����������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SelCount > 1)
            {
                MessageBox.Show("ֻ��ѡ��һ��ҽ����������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //���ҽ��IDΪ��
            if (myTb.Rows[nrow]["Group_ID"].ToString() == "") return;

            if (myTb.Rows.Count > 0)
            {
                frmYZXX f1 = new frmYZXX();
                f1.sTitle = "���ˡ�" + this.sName + "��ҽ����ϸ��Ϣ";
                f1.MNGType = this.GetMNGType();
                f1.MNGType2 = f1.MNGType == 1 ? 5 : f1.MNGType;
                f1.Group_ID = Convert.ToInt32(myTb.Rows[nrow]["Group_ID"]);
                f1.OrderID = new Guid(myTb.Rows[nrow]["Order_ID"].ToString());
                f1.nType = Convert.ToInt32(myTb.Rows[nrow]["ntype"]);
                f1.isSSMZ = isSSMZ;
                f1.isTSZL = rbTszl.Checked ? true : false;
                f1.isCX = isCX;
                if (rbIn.Checked || rbTrans.Checked || rbTszl.Checked)
                {
                    f1.isUNCZ = false;
                    //add by zouchihua 2013-8-24 ��������������˳�Ժҽ�������������
                    if (rbTszl.Checked && cfg7160.Config.Trim() == "0")
                    {
                        DataTable tbbr = InstanceForm.BDatabase.GetDataTable("select flag from VI_ZY_VINPATIENT_BED where INPATIENT_ID='" + ClassStatic.Current_BinID + "' and baby_id='" + ClassStatic.Current_BabyID + "' and flag=4");
                        if (tbbr.Rows.Count > 0)
                        {
                            f1.isUNCZ = true;
                        }
                    }
                }
                else
                {
                    f1.isUNCZ = true;
                }
                //�ж����ҽ�����㲻�ܳ��� add by zouchihua 2013-01-07
                //string sql = "select IS_YBJS from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'";
                //DataTable temptb = FrmMdiMain.Database.GetDataTable(sql);
                //if (temptb.Rows.Count > 0)
                //{
                //    if(temptb.Rows[0]["IS_YBJS"].ToString().Trim()=="1")
                //        f1.isUNCZ = true;
                //}
                #region//Add by Zouchihua 2011-10-11 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                if (rtnSql[0] != "0")//������ܳ���
                {
                    f1.isUNCZ = true;
                }
                // if (rtnSql[2] != "0")
                //{
                //   f1.isUNCZ = true;
                //}
                #endregion
                if (zczyz_notfy)
                {
                    //�����Ĳ��˳�����ֻ�ܳ���ҩƷ�����Ҳ�������ҩ��Ϣ
                    f1.isUNCZ = false;
                    f1.zczyz_notfy = zczyz_notfy;
                }

                f1.ShowDialog();
            }

        }

        private void btҽ����ӡ_Click(object sender, System.EventArgs e)
        {
            Point pp = new Point(btҽ����ӡ.Location.X, btҽ����ӡ.Location.Y + btҽ����ӡ.Height);

            contextMenu3.Show(btҽ����ӡ.Parent, pp);
        }

        //ע�⣺�����¼ȡ����ʱ��Ҫ����صĻ�����Ϣ���������û���޸ģ��޸ĺ�ɾ��Tany��
        private void btȡ����ҽ��ת��_Click(object sender, System.EventArgs e)
        {
            string tmpSql = "";

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            DataTable decoctTb = new DataTable();
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            string sSql = "";
            bool isSelect = false;
            this.myDataGrid1.CurrentCell = new DataGridCell(0, 0);
            int mngType1 = GetMNGType();
            int mngType2 = -1;

            if (mngType1 == 1)
                mngType2 = 5;
            else
                mngType2 = mngType1;

            Button bt = (Button)sender;
            string btName = bt.Name.Trim().Substring(2, bt.Name.Trim().Length - 2);

            if (MessageBox.Show(this, "ȷ�Ͽ�ʼ��" + btName + "����", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
            }
            string sSql1;
            string tmpSql1 = "";
            DataTable hltb = FrmMdiMain.Database.GetDataTable("select b.ORDER_NAME,TENDLEVEL,a.HOITEM_ID from JC_HOI_HL a left join JC_HOITEMDICTION  b on a.HOITEM_ID=b.ORDER_ID");
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sSql1 = "";
                tmpSql1 = "";
                if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    switch (btName)
                    {
                        case "ȡ����ҽ��ת��":
                            #region �жϸ�ҽ���Ƿ�û��ת�����Ƿ�ִ�й�
                            if (Convert.ToInt16(myTb.Rows[i]["Status_flag"]) == 1)
                            {
                                MessageBox.Show(this, "�Բ���ҽ����" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����û��ת����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            //��ʱȡ��  Modify By Tany 2004-11-11
                            //							if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId)
                            //							{
                            //								MessageBox.Show(this,"�Բ���ҽ����"+myTb.Rows[i]["ҽ������"].ToString().Trim()+"��������ת���ģ�����Ȩȡ����", "����", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}
                            int nPs = Convert.ToInt16(myTb.Rows[i]["ps_flag"]);
                            if (nPs == 1 || nPs == 2)
                            {
                                MessageBox.Show(this, "�Բ��𣬸���ҽ���Ѿ�������Ƥ�Խ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            sSql = "select * from zy_orderrecord " +
                                "where order_id in (select order_id from zy_orderexec)" +
                                "      and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "      and (mngtype=" + mngType1 + " or mngtype=" + mngType2 + ")" +
                                "      and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                "      and not (ntype=0)";//Modify By Tany 2005-11-05 ��Ժҽ���ȿ�������ȡ��
                            DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                            if (myTempTb.Rows.Count != 0)
                            {
                                MessageBox.Show(this, "�Բ���ҽ����" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "���Ѿ�ִ�У�������ȡ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            #endregion
                            #region //Add by zouchihua ȡ��ת��ʱ����������Ϣ 2012-7-18
                            DataRow[] row = hltb.Select("HOITEM_ID=" + myTb.Rows[i]["HOITEM_ID"].ToString());
                            if (row != null && row.Length > 0)// && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_hl"].ToString().Trim())
                            {
                                sSql1 = "ORDER_HL=null,ORDER_HL_SPEC='',ORDER_TENDLEVEL=0";
                                //Add By Tany 2005-01-12
                                //�����ͣ������Ҫ�������ڻ����¼������ļ����ǲ���һ��
                                //��Ҫ�Ƿ�ֹ�ȿ��»�����ͣ�ϻ����ʱ�����»����¼���
                                tmpSql1 = " order_tendlevel=" + row[0]["TENDLEVEL"] + " and ";
                            }
                            if (myTb.Rows[i]["ҽ������"].ToString().IndexOf("����") >= 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BZ=null"; ;
                            }
                            if (myTb.Rows[i]["ҽ������"].ToString().IndexOf("��Σ") >= 0)//&& myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_bw"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BW=null";
                            }
                            if (myTb.Rows[i]["ҽ������"].ToString().IndexOf("��ʳ") >= 0 || myTb.Rows[i]["ҽ������"].ToString().IndexOf("��ʳ") >= 0 || myTb.Rows[i]["ҽ������"].ToString().IndexOf("��ʳ") >= 0)// && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_ys"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_YS=null,ORDER_YS_SPEC=''";
                            }
                            #endregion
                            break;
                        case "ȡ��ͣҽ��ת��":
                            #region �жϸ�ҽ���Ƿ��Ѿ�ֹͣ���Ƿ�ֹͣת��
                            if (Convert.ToInt16(myTb.Rows[i]["Status_flag"]) == 5)
                            {
                                MessageBox.Show(this, "�Բ���ҽ����" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "���Ѿ�ֹͣ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["Status_flag"]) != 4)
                            {
                                MessageBox.Show(this, "�Բ���ҽ����" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����û��ֹͣת����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            //��ʱȡ��  Modify By Tany 2004-11-11
                            //							if (myTb.Rows[i]["order_euser"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId)
                            //							{
                            //								MessageBox.Show(this,"�Բ���ҽ����"+myTb.Rows[i]["ҽ������"].ToString().Trim()+"��������ֹͣת���ģ�����Ȩȡ����", "����", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}

                            #endregion
                            #region //Add by zouchihua ȡ��ͣת��ʱ����������Ϣ 2012-7-18
                            row = hltb.Select("HOITEM_ID=" + myTb.Rows[i]["HOITEM_ID"].ToString());
                            if (row != null && row.Length > 0)
                            {
                                sSql1 = "ORDER_HL='" + myTb.Rows[i]["Order_ID"].ToString() + "',ORDER_HL_SPEC='" + row[0]["ORDER_NAME"].ToString() + "',ORDER_TENDLEVEL=" + row[0]["TENDLEVEL"].ToString();
                            }
                            if (myTb.Rows[i]["ҽ������"].ToString().IndexOf("����") >= 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BZ='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            }
                            if (myTb.Rows[i]["ҽ������"].ToString().IndexOf("��Σ") >= 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BW='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            }
                            if (myTb.Rows[i]["ҽ������"].ToString().IndexOf("��ʳ") >= 0 || myTb.Rows[i]["ҽ������"].ToString().IndexOf("��ʳ") >= 0 || myTb.Rows[i]["ҽ������"].ToString().IndexOf("��ʳ") >= 0)// && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_ys"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_YS='" + myTb.Rows[i]["Order_ID"].ToString() + "',ORDER_YS_SPEC='" + myTb.Rows[i]["ҽ������"].ToString() + "'";
                            }

                            #endregion
                            break;
                        case "ȡ����ҽ���˶�":
                            #region �жϸ�ҽ���Ƿ��Ѿ��˶�
                            //���Բ�����Ч���жϣ���Ӱ������ Modify By Tany 2004-11-18
                            //							if (myTb.Rows[i]["�����˶�"].ToString().Trim()=="")
                            //							{
                            //								MessageBox.Show(this,"�Բ���ҽ����"+myTb.Rows[i]["ҽ������"].ToString().Trim()+"����û�п�ʼ�˶ԣ�", "����", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}
                            //��ʱȡ��  Modify By Tany 2004-11-11
                            //							if (myTb.Rows[i]["AUDITING_USER1"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId)
                            //							{
                            //								MessageBox.Show(this,"�Բ���ҽ����"+myTb.Rows[i]["ҽ������"].ToString().Trim()+"���������˶Եģ�����Ȩȡ����", "����", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}
                            break;
                            #endregion
                        case "ȡ��ͣҽ���˶�":
                            #region �жϸ�ҽ���Ƿ��Ѿ�ֹͣ���
                            //���Բ�����Ч���жϣ���Ӱ������ Modify By Tany 2004-11-18
                            //							if (myTb.Rows[i]["ͣ���˶�"].ToString().Trim()=="")
                            //							{
                            //								MessageBox.Show(this,"�Բ���ҽ����"+myTb.Rows[i]["ҽ������"].ToString().Trim()+"����û��ֹͣ��ԣ�", "����", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}
                            //��ʱȡ��  Modify By Tany 2004-11-11
                            //							if (myTb.Rows[i]["order_euser1"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId)
                            //							{
                            //								MessageBox.Show(this,"�Բ���ҽ����"+myTb.Rows[i]["ҽ������"].ToString().Trim()+"��������ֹͣ��Եģ�", "����", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}					
                            break;
                            #endregion
                    }
                    isSelect = true;
                    if (sSql1 != "")
                    {
                        sSql = "update zy_inpatient_hl set " + sSql1 + " where " + tmpSql1 +
                            " inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;

                        try
                        {
                            InstanceForm.BDatabase.DoCommand(sSql);
                        }
                        catch (Exception err)
                        {
                            //д������־ Add By Tany 2005-01-12
                            SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "���»����¼����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                            _systemErrLog.Save();
                            _systemErrLog = null;

                            MessageBox.Show("���󣺸��»����¼ʱ����\nϵͳ��" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }

            if (isSelect == false)
            {
                MessageBox.Show(this, "�Բ���û��ѡ��ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region ȡ������
            string sGroupId = "";
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (i != 0 && myTb.Rows[i]["Group_ID"].ToString().Trim() == myTb.Rows[i - 1]["Group_ID"].ToString().Trim())
                    continue;

                if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    //�ж��ǲ����м�ҩ�ѣ��������Ѽ�ҩ�ѵ���ʱ�˵�ȡ��
                    //Add By Tany 2004-10-22
                    //-------------------------------------------------------------------------------------------------------------
                    Guid n_id = Guid.Empty;
                    Guid n_order_id = Guid.Empty;
                    string strSql = "select id,order_id from zy_decoct where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                        " and group_id=" + Convert.ToDecimal(myTb.Rows[i]["group_id"].ToString().Trim()) + " and order_id is not null";
                    decoctTb = InstanceForm.BDatabase.GetDataTable(strSql);

                    if (decoctTb.Rows.Count > 0)
                    {
                        n_id = new Guid(decoctTb.Rows[0]["id"].ToString().Trim());
                        n_order_id = new Guid(decoctTb.Rows[0]["order_id"].ToString().Trim());
                        if (MessageBox.Show("����ҽ���м�ҩ�ѣ��Ƿ��Զ�ɾ����ҩ�ѣ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //ȡ��ҩ����Ϣ
                            sSql = @"select * from zy_orderrecord where delete_bit=0 and order_id='" + n_order_id + "'";
                            DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                            //�����ҩ���Ѿ����ͣ����ֹ�����
                            if (myTempTb.Rows.Count == 0 || myTempTb == null || myTempTb.Rows[0]["status_flag"].ToString().Trim() == "5")
                            {
                                MessageBox.Show("δ�ҵ���ҩ�ѻ��߼�ҩ���Ѿ����ͣ����ֹ�������ҩ�ѣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else
                            {
                                //								//�������ݷ��ʶ���
                                //								RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                                //								database.Initialize("");
                                //								database.Open();
                                //								//��ʼһ������
                                //								database.BeginTransaction();

                                InstanceForm.BDatabase.BeginTransaction();

                                try
                                {
                                    //ɾ����ҩ��
                                    strSql = "update zy_orderrecord set delete_bit=1,order_euser=" + InstanceForm.BCurrentUser.EmployeeId +
                                        ",order_eudate=getdate() where order_id='" + n_order_id + "'";
                                    InstanceForm.BDatabase.DoCommand(strSql);

                                    //�����ҩ���˵���Ϣ
                                    //Modify by jchl �������ҩ��Ϣ
                                    //strSql = "update zy_decoct set order_id=DBO.FUN_GETEMPTYGUID() where id='" + n_id + "'";
                                    //InstanceForm.BDatabase.DoCommand(strSql);

                                    InstanceForm.BDatabase.CommitTransaction();
                                }
                                catch (Exception err)
                                {
                                    InstanceForm.BDatabase.RollbackTransaction();

                                    //д������־ Add By Tany 2005-01-12
                                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "ȡ��ת������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                                    _systemErrLog.Save();
                                    _systemErrLog = null;

                                    MessageBox.Show("���󣺽���ҩ�Ѵ���ʱ�˵���ɾ��ʱ���ִ������ֹ�ɾ����ҩ�ѣ�\nϵͳ��" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                //								finally
                                //								{
                                //									database.Close();
                                //								}
                            }
                        }
                    }

                    //-------------------------------------------------------------------------------------------------------------
                    //InstanceForm.BDatabase.BeginTransaction();
                    sSql = @"update zy_OrderRecord ";
                    try
                    {
                        //add by zouchihua ������Ϣ��סԺ 2013-8-14
                        string msg_wardid = "";
                        long msg_deptid = 0;// long.Parse(myTb.Rows[i]["EXEC_DEPT"].ToString().Trim());
                        long msg_empid = 0;
                        string msg_sender = FrmMdiMain.CurrentDept.DeptName + "��" + FrmMdiMain.CurrentUser.Name;
                        string msg_msg = "";
                        switch (btName)
                        {
                            case "ȡ����ҽ��ת��":

                                //add by zouchihua 2012-2-21
                                #region �Ƿ�ʹ�������棬ת��ʱ����ʱҽ���������棬����ҽ���������������
                                try
                                {
                                    string cfg6035 = new SystemCfg(6035).Config.Trim();
                                    if (cfg6035 == "1")
                                    {
                                        myFunc.OprateXnkc(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, Guid.Empty, int.Parse(myTb.Rows[i]["Group_ID"].ToString().Trim()), 1);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                #endregion
                                //Modify by Tany 2010-04-19 ���������������������ƣ�ȡ��ת��ֱ��ȡ����Ϊ0��״̬
                                int _flag = 1;
                                if (isSSMZ || isTSZL)
                                {
                                    _flag = 0;
                                }
                                sSql += " set status_flag=" + _flag + ", Auditing_User=null, Auditing_Date=null ";
                                //ȡ��ת����ʱ���ҽ����ӡ��¼Ҳɾ�� Add By Tany 2004-12-30 
                                if (GetMNGType() == 0)
                                {
                                    tmpSql = "delete from zy_logorderprt where group_id>=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                        "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                }
                                else if (GetMNGType() == 1)
                                {
                                    tmpSql = "delete from zy_tmporderprt where group_id>=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                        "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                }
                                //add by zouchihua ������Ϣ��סԺ 2013-8-14
                                msg_msg = "[" + patientInfo1.lbDQKS.Text.Trim() + "] ���� " + patientInfo1.lbBed.Text + "��[" + patientInfo1.lbName.Text.Trim() + "] ��";
                                msg_msg += "��" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "���Ѿ�ȡ��ת��\r\n";
                                try
                                {
                                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, SystemModule.סԺ��ʿվ, InstanceForm.BCurrentDept.WardId, msg_deptid, msg_empid, msg_sender, msg_msg);
                                }
                                catch (Exception)
                                { }
                                break;
                            case "ȡ��ͣҽ��ת��":
                                sSql += "  set status_flag=3,ORDER_EUSER=null, ORDER_EUDATE=null ";
                                //add by zouchihua ������Ϣ��סԺ 2013-8-14
                                //string msg_wardid = "";
                                //long msg_deptid = 0;// long.Parse(myTb.Rows[i]["EXEC_DEPT"].ToString().Trim());
                                //long msg_empid = 0;
                                //string msg_sender = FrmMdiMain.CurrentDept.DeptName + "��" + FrmMdiMain.CurrentUser.Name;
                                msg_msg = "[" + patientInfo1.lbDQKS.Text.Trim() + "] ���� " + patientInfo1.lbBed.Text + "��[" + patientInfo1.lbName.Text.Trim() + "] ��";
                                msg_msg += "��" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "���Ѿ�ȡ��ͣҽ��ת��\r\n";
                                try
                                {
                                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, SystemModule.סԺ��ʿվ, InstanceForm.BCurrentDept.WardId, msg_deptid, msg_empid, msg_sender, msg_msg);
                                }
                                catch (Exception)
                                { }
                                break;
                            case "ȡ����ҽ���˶�":
                                sSql += " set Auditing_User1=null, Auditing_Date1=null ";
                                break;
                            case "ȡ��ͣҽ���˶�":
                                sSql += "  set ORDER_EUSER1=null, ORDER_EUDATE1=null ";
                                break;
                            case "ȡ����ҽ�����":
                                sSql += " set Auditing_User2=null, Auditing_Date2=null ";
                                break;
                            case "ȡ��ͣҽ�����":
                                sSql += "  set ORDER_EUSER2=null, ORDER_EUDATE2=null ";
                                break;
                        }
                        sSql += " where group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                              "       and (mngtype=" + mngType1 + " or mngtype=" + mngType2 + ")" +
                              "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //ɾ��ҽ����ӡ��Ϣ Modify By Tany 2005-01-18
                        if (tmpSql.Trim() != "")
                        {
                            InstanceForm.BDatabase.DoCommand(tmpSql);
                        }
                        //InstanceForm.BDatabase.CommitTransaction();
                        sGroupId += myTb.Rows[i]["Group_ID"].ToString().Trim() + ",";
                    }
                    catch (Exception ex)
                    {
                        //InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            #endregion

            //д��־ Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, btName, "��inpatient_id=" + ClassStatic.Current_BinID + " and baby_id=" + ClassStatic.Current_BabyID + "�Ĳ���group_id=" + sGroupId + btName, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            this.ShowData();
        }


        private void bt����_Click(object sender, EventArgs e)
        {
            Point pp = new Point(bt����.Location.X, bt����.Location.Y + bt����.Height);

            contextMenuSP.Show(bt����.Parent, pp);
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string sMsg1 = "����(+)";
            string sMsg2 = "�޸�Ϊ����(+)";
            string sPSJG1 = "2";
            string sPSJG2 = "0";
            string value = " (+)";
            PSCL(sMsg1, sMsg2, sPSJG1, sPSJG2, value);
        }
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string sMsg1 = "������(++)";
            string sMsg2 = "�޸�Ϊ������(++)";
            string sPSJG1 = "21";
            string sPSJG2 = "0";
            string value = " (++)";
            PSCL(sMsg1, sMsg2, sPSJG1, sPSJG2, value);
        }
        /// <summary>
        /// ǿ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string sMsg1 = "ǿ����(+++)";
            string sMsg2 = "�޸�Ϊǿ����(+++)";
            string sPSJG1 = "22";
            string sPSJG2 = "0";
            string value = " (+++)";
            PSCL(sMsg1, sMsg2, sPSJG1, sPSJG2, value);
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt����_Click(object sender, System.EventArgs e)
        {
            string sMsg1 = "����(-)";
            string sMsg2 = "�޸�Ϊ����(-)";
            string sPSJG1 = "1";
            string sPSJG2 = "-1";
            string value = " (-)";
            PSCL(sMsg1, sMsg2, sPSJG1, sPSJG2, value);
        }
        /// <summary>
        /// Ƥ�Դ����÷���
        /// </summary>
        /// <param name="sMsg1"></param>
        /// <param name="sMsg2"></param>
        /// <param name="sPSJG1"></param>
        /// <param name="sPSJG2"></param>
        private void PSCL(string sMsg1, string sMsg2, string sPSJG1, string sPSJG2, string value)
        {
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            int nPs = Convert.ToInt16(myTb.Rows[nrow]["ps_flag"]);

            if (nPs == -1 || nPs == 3)
            {
                //����Ǹ���Ŀ��������vi_psyzxm�����м�¼����Ҳ����Ƥ�� Modify By Tany 2015-04-13
                if (Convert.ToInt16(myTb.Rows[nrow]["xmly"]) == 2
                    && Convert.ToInt16(InstanceForm.BDatabase.GetDataResult("select COUNT(1) from vi_psyzxm where order_id=" + myTb.Rows[nrow]["hoitem_id"].ToString())) > 0)
                {
                }
                else
                {
                    MessageBox.Show(this, "�Բ��𣬸���ҽ������ҪƤ�ԣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if ((myTb.Rows[nrow]["Order_Usage"].ToString().Trim() != "Ƥ��"
                && myTb.Rows[nrow]["Order_Usage"].ToString().Trim().ToUpper() != "AST"))
            {
                MessageBox.Show(this, "�Բ��𣬸���ҽ�����÷�����Ƥ�ԣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt16(myTb.Rows[nrow]["Status_flag"]) < 2)
            {
                MessageBox.Show(this, "�Բ��𣬸���ҽ����û����ˣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Button bt = (Button)sender;
            //string sMsg1 = bt.Text.Trim().Substring(0, 2) == "����" ? "����(-)" : "����(+)";
            //string sMsg2 = bt.Text.Trim().Substring(0, 2) == "����" ? "�����޸�Ϊ����(-)" : "�����޸�Ϊ����(+))";
            //string sPSJG1 = bt.Text.Trim().Substring(0, 2) == "����" ? "1" : "2";
            //string sPSJG2 = bt.Text.Trim().Substring(0, 2) == "����" ? "-1" : "0";
            if (nPs == 1)
                sMsg2 = "����" + sMsg2;
            else if (nPs == 2)
                sMsg2 = "����" + sMsg2;
            else if (nPs == 21)
                sMsg2 = "������" + sMsg2;
            else if (nPs == 22)
                sMsg2 = "ǿ����" + sMsg2;
            string sSql = "";
            Guid sOrderID = Guid.Empty;
            DataTable myTempTb = new DataTable();
            //1���� 2���� 21 ������ 22ǿ����
            if ((nPs == 2 && sMsg1 == "����(+)") || (nPs == 1 && sMsg1 == "����(-)") || (nPs == 21 && sMsg1 == "������(++)") || (nPs == 22 && sMsg1 == "ǿ����(+++)"))
            {
                MessageBox.Show(this, "�Բ��𣬸���ҽ���Ѿ�������" + sMsg1 + "Ƥ�Խ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nPs == 2 || nPs == 1 || nPs == 21 || nPs == 22)
            {
                //�޸�Ƥ�Խ��

                if (InstanceForm.BCurrentUser.EmployeeId != Convert.ToInt64(myTb.Rows[nrow]["ps_user"]))
                {
                    MessageBox.Show(this, "�Բ��𣬸���ҽ���Ѿ�����������Ա������Ƥ�Խ��������Ȩ�޸ģ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool bModIvOrder = false;

                //�Ƿ��ж�Ӧ��ҽ��
                if (new Guid(myTb.Rows[nrow]["ps_orderid"].ToString()) != Guid.Empty)
                {
                    sOrderID = new Guid(myTb.Rows[nrow]["ps_orderid"].ToString().Trim());
                    sSql = "select status_flag,order_id from zy_orderrecord where order_id='" + sOrderID + "'";
                    myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (myTempTb != null && myTempTb.Rows.Count > 0)
                    {
                        if (Convert.ToInt16(myTempTb.Rows[0]["status_flag"]) > 1
                            && new SystemCfg(7041).Config == "��")//Add By tany 2011-01-21 ����ò���Ϊ�ǣ�������������Ƥ�Խ�� 7041�Ƿ�����û��Ƥ�Խ����ҽ��ת��
                        {
                            MessageBox.Show(this, "�Բ��𣬸���ҽ�����Ӧ��ҽ���Ѿ�ת�����������޸�Ƥ�Խ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (MessageBox.Show(this, "ȷ�ϡ�" + myTb.Rows[nrow]["ҽ������"].ToString().Trim() + "������ " + sMsg2 + "��", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;

                    bModIvOrder = true;

                    //�޸�ע��ҽ��
                    sSql = "update zy_orderrecord set ps_flag=" + sPSJG2 + " where order_id='" + sOrderID + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
                else
                {
                    if (MessageBox.Show(this, "ȷ�ϡ�" + myTb.Rows[nrow]["ҽ������"].ToString().Trim() + "������ " + sMsg2 + "��", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();

                    if (bModIvOrder)
                    {
                        //�޸�ע��ҽ��
                        sSql = "update zy_orderrecord set ps_flag=" + sPSJG2 + " where order_id='" + sOrderID + "'";
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }

                    //�޸�Ƥ��ҽ��
                    sSql = "update zy_orderrecord set ps_flag=" + sPSJG1 + " where order_id='" + myTb.Rows[nrow]["Order_ID"].ToString().Trim() + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                    //add by zouchihua 2013-1-5 ͬʱ�޸�ҽ����ӡ���е�����
                    string[] updatesql = new string[] { " update ZY_TMPORDERPRT set ORDER_USAGE=rtrim(REPLACE(REPLACE(REPLACE( REPLACE(ORDER_USAGE,'(-)',''),'(+)',''),'(++)',''),'(+++)',''))+'" + value+ "' where order_id='"+ myTb.Rows[nrow]["Order_ID"].ToString().Trim()+"'" 
                ," update ZY_LOGORDERPRT set ORDER_USAGE=rtrim(REPLACE(REPLACE(REPLACE( REPLACE(ORDER_USAGE,'(-)',''),'(+)',''),'(++)',''),'(+++)',''))+'" + value+ "' where order_id='"+ myTb.Rows[nrow]["Order_ID"].ToString().Trim()+"'" };
                    InstanceForm.BDatabase.DoCommand(updatesql[0]);
                    InstanceForm.BDatabase.DoCommand(updatesql[1]);

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception ex)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("Ƥ�Գ���" + ex.Message, "����");
                    return;
                }
            }
            else
            {
                //��һ������Ƥ�Խ��
                if (MessageBox.Show(this, "ȷ�ϡ�" + myTb.Rows[nrow]["ҽ������"].ToString().Trim() + "����" + sMsg1 + "��", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                //��ȡע��ҽ��order_id
                sSql = "select a.order_id from zy_orderrecord a,zy_orderrecord b " +
                    " where a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id" +
                    "       and a.ps_flag=b.ps_flag and a.ps_flag=0 and a.ps_orderid=b.ps_orderid" +
                    "       and a.order_id<>b.order_id and b.order_id='" + myTb.Rows[nrow]["Order_ID"].ToString().Trim() + "'";
                myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (myTempTb.Rows.Count > 0)
                {
                    sOrderID = new Guid(myTempTb.Rows[0]["order_id"].ToString().Trim());
                }


                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    //�޸�Ƥ��ҽ��
                    sSql = "update zy_orderrecord set ps_flag=" + sPSJG1 + ",ps_orderid='" + sOrderID + "',ps_user=" + InstanceForm.BCurrentUser.EmployeeId + " where order_id='" + myTb.Rows[nrow]["Order_ID"].ToString().Trim() + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                    //add by zouchihua 2013-1-5 ͬʱ�޸�ҽ����ӡ���е�����
                    string[] updatesql = new string[] { " update ZY_TMPORDERPRT set ORDER_USAGE=ORDER_USAGE+'" +value+ "' where order_id='"+ myTb.Rows[nrow]["Order_ID"].ToString().Trim()+"'" 
                ," update ZY_LOGORDERPRT set ORDER_USAGE=ORDER_USAGE+'" + value+ "' where order_id='"+ myTb.Rows[nrow]["Order_ID"].ToString().Trim()+"'" };
                    InstanceForm.BDatabase.DoCommand(updatesql[0]);
                    InstanceForm.BDatabase.DoCommand(updatesql[1]);
                    if (myTempTb.Rows.Count > 0)
                    {
                        //�޸�ע��ҽ��
                        sSql = "update zy_orderrecord set ps_flag=" + sPSJG2 + ",ps_orderid='" + myTb.Rows[nrow]["Order_ID"].ToString() + "',ps_user=" + InstanceForm.BCurrentUser.EmployeeId + " where order_id='" + sOrderID + "'";
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception ex)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("Ƥ�Գ���" + ex.Message, "����");
                    return;
                }
            }

            string msg_wardid = "";
            long msg_deptid = ClassStatic.Current_DeptID;
            long msg_empid = 0;
            string msg_sender = FrmMdiMain.CurrentDept.WardName + "��" + FrmMdiMain.CurrentUser.Name;
            string msg_msg = patientInfo1.lbBed.Text + " �� " + patientInfo1.lbName.Text + " ����\r\nҽ����" + myTb.Rows[nrow]["ҽ������"].ToString().Trim() + " Ƥ�Խ��Ϊ " + sMsg1 + "\r\n" + (sPSJG1 == "2" ? "����д���" : "");
            TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.סԺҽ��վ, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);

            this.ShowData();

            #region Ƥ�ԵĴ������� c1�ֶ�
            //			ҽ����ҽ����   
            //			           Aҽ�� 		P0 10:00:01     (P��־��0�ǳ���/1��������ʱ��)
            //   		           BƤ��ҽ��    P0 10:00:01     (P��־��0�ǳ���/1��������ʱ�䣬���÷���Ƥ�Ի�AST)
            //          Ƥ�Ժ�  
            //                     BƤ��ҽ��    P0 A.order_id-2  (P��־��0�ǳ���/1��������a.order_idAҽ����ID��-����/+���ԣ���ʿ����)
            //   		                                          (���û�ж�Ӧ��Aҽ�������ǡ�P0 -2��)
            //          		   Aҽ�� 		P0 B.order_idI   (P��־��0�ǳ���/1��������a.order_idAҽ����ID��I����/A���ԣ�ֻ��c1�ֶΰ���I���ҽ���ſ������)
            //			�޸�Ƥ�Խ����
            //					   �ж������������Ǳ��ˣ���Aҽ��û��ת��		            
            //                     �ٷֱ��޸� BƤ��ҽ����Aҽ����c1�ֶ�
            #endregion
        }

        private void btδִ��_Click(object sender, System.EventArgs e)
        {
            int mntype = this.GetMNGType();
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            string sSql = "";
            bool isYJ = false;  //�Ƿ���ҽ����Ŀ

            #region һ������ʾ������Ϣ���ύ�ɹ�����Ϣ   yaokx2013-11-20
            ArrayList errorlist = new ArrayList();
            Hashtable sumbitht = new Hashtable();
            string reaseon = "";
            #endregion
            int count = 0;
            if (this.btδִ��.Text.Substring(0, 1) == "δ")
            {
                for (int x = 0; x < myTb.Rows.Count; x++)
                {
                    if (myTb.Rows[x]["ѡ"].ToString() == "True")
                    {
                        count++;
                        Hashtable errorht = new Hashtable();
                        nrow = x;

                        string content = myTb.Rows[x]["ҽ������"].ToString();

                        #region δִ��
                        if (Convert.ToInt16(myTb.Rows[nrow]["Status_flag"]) < 2)
                        {
                            string s = "'" + content + "'����ҽ����û��ת����";
                            errorht.Add(Guid.NewGuid(), s);
                            // MessageBox.Show(this, "�Բ��𣬸���ҽ����û��ת����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // return;
                        }
                        //��ʱҽ���ȷ��ͺ���ܱ�δִ��
                        if (Convert.ToInt16(myTb.Rows[nrow]["Status_flag"]) < 3 && mntype==1)
                        {
                            string s = "'" + content + "'����ҽ����δ����,���ȷ��ͺ��ٱ�δִ�У�";
                            errorht.Add(Guid.NewGuid(), s);
                            // MessageBox.Show(this, "�Բ��𣬸���ҽ����û��ת����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // return;
                        }

                        string groupid = myTb.Rows[nrow]["group_id"].ToString().Trim();
                        int nWzx = Convert.ToInt16(myTb.Rows[nrow]["wzx_flag"]);

                        //����ҽ���������Ƥ��������ͨ��
                        for (int i = 0; i < myTb.Rows.Count; i++)
                        {
                            if (myTb.Rows[i]["group_id"].ToString().Trim() == groupid)
                            {
                                if (Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 1 || Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 2)
                                {
                                    string s = "'" + content + "'����ҽ���Ѿ�������Ƥ�Խ����";
                                    errorht.Add(Guid.NewGuid(), s);
                                    //  MessageBox.Show(this, "�Բ��𣬸���ҽ���Ѿ�������Ƥ�Խ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //return;
                                }
                            }
                        }

                        if (nWzx > 0)
                        {
                            string s = "'" + content + "'����ҽ���Ѿ����á�δִ�С���";
                            errorht.Add(Guid.NewGuid(), s);

                            //MessageBox.Show(this, "�Բ��𣬸���ҽ���Ѿ����á�δִ�С���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        if (myTb.Rows[nrow]["ִ��ʱ��"].ToString() != "")
                        {
                            string s = "'" + content + "'����ҽ���Ѿ����á�ִ��ʱ�䡱��";
                            errorht.Add(Guid.NewGuid(), s);
                        }

                        //ת��ҽ����Ժҽ��������δִ��
                        //Modify by jchl 2015-08-25
                        if (content.Contains("ת��") || content.Contains("��Ժ"))
                        {
                            string s = "��Ժ����ת��ҽ��������δִ�У�";
                            errorht.Add(Guid.NewGuid(), s);
                        }


                        //�ж��Ƿ�ִ�й�
                        sSql = "select 1 from zy_orderrecord a inner join zy_orderexec b on a.order_id=b.order_id " +
                            " where a.group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                            "      and a.mngtype in(0,1,5) " +//Modify by zouchihua 2013-7-10 ����5���ͽ����˵��ж�
                            "      and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID;
                        DataTable myTb1 = InstanceForm.BDatabase.GetDataTable(sSql);
                        if (myTb1.Rows.Count > 0)
                        {
                            //����Ƿ����Ѿ�ԤԼ���ţ�ֻҪ��ҽ����Ŀ��
                            sSql = "select BJSBZ from YJ_ZYSQ " +
                                "  where yzid in (select order_id from zy_orderrecord  " +
                                "				       where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                "                            and mngtype in(0,1) " +
                                "                            and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                "                     )";
                            DataTable myTb2 = InstanceForm.BDatabase.GetDataTable(sSql);
                            if (myTb2.Rows.Count > 0)
                            {
                                if (Convert.ToInt16(myTb2.Rows[0]["BJSBZ"]) == 0)
                                {
                                    //��û�а��ţ�
                                    isYJ = true;
                                }
                                else
                                {
                                    #region  //Modiby by zouchihua 2011-11-27
                                    //string yjfee = "select sum(acvalue) fy from zy_fee_speci" +
                                    //" where charge_bit=1 and delete_bit=0 and order_id in (select order_id from zy_orderrecord " +
                                    //"                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    //"                           and mngtype in (1,5) " +
                                    //"                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    //"                    )";
                                    string yjfee = "select sum(acvalue) fy  from (select *  from  zy_fee_speci  where charge_bit=1 and delete_bit=0 and  order_id in "
                                            + " (select order_id from zy_orderrecord where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim()
                                            + "  and mngtype in (0,1,5)  and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + "   ) "
                                             + " ) aa ";
                                    decimal _fy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(yjfee), "0"));
                                    if (_fy != 0)//���ò�Ϊ��ʱ ��δִ��
                                    {
                                        //�Ѿ�����
                                        string s = "'" + content + "'����ҽ���������ţ���Ҫ��ִ�п��ҽ���ȡ�����Ż����������";
                                        errorht.Add(Guid.NewGuid(), s);
                                        //MessageBox.Show(this, "�Բ��𣬸���ҽ���������ţ���Ҫ��ִ�п��ҽ���ȡ�����Ż����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //return;
                                    }
                                    else
                                    {
                                        //дֹͣ��־��δִ�б�־ ,��ɾ�����ñ����Ϣ��ҽ������Ϣ 
                                        //sSql = "update zy_orderrecord set order_context='��ȡ����'+order_context,wzx_flag=" + InstanceForm.BCurrentUser.EmployeeId + ",status_flag=5 ,order_edate=getdate()" +//Modify By Tany 2005-01-31 ,order_edate=getdate()
                                        //    " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                        //    "       and mngtype in (1,5) " +
                                        //    "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                        ////Modify by Tany 2005-02-21	
                                        //if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                                        //   MessageBox.Show(this, "δ�ҵ���Ҫ���µ�ҽ����¼��������ȷ�ϣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //this.ShowDate();
                                        //Modify by zouchihua ���Խ���δִ��
                                        isYJ = true;
                                    }
                                    #endregion
                                }

                                //����Ƿ��Ѿ��Ƿ�
                                sSql = "select sum(acvalue) fy from zy_fee_speci" +
                                    " where charge_bit=1 and delete_bit=0 and order_id in (select order_id from zy_orderrecord " +
                                    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "                           and mngtype in (0,1,5) " +
                                    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    "                    )";
                                decimal _fy1 = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql), "0"));
                                if (_fy1 != 0)
                                {
                                    string s = "'" + content + "'����ҽ���Ѿ��Ƿѣ���Ҫ��ִ�п��ҽ��г���������";
                                    errorht.Add(Guid.NewGuid(), s);

                                    //MessageBox.Show(this, "�Բ��𣬸���ҽ���Ѿ��Ƿѣ���Ҫ��ִ�п��ҽ��г���������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                            }
                            else
                            {
                                //Modify By tany 2011-05-31 �������ҽ����Ŀ�����ж��Ƿ��з��ã����û�з���������δִ��
                                sSql = "select isnull(sum(acvalue),0) fy from zy_fee_speci" +
                                    " where charge_bit=1 and delete_bit=0 and order_id in (select order_id from zy_orderrecord " +
                                    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "                           and mngtype in (0,1,5) " +
                                    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    "                    )";
                                decimal _fy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql), "0"));
                                if (_fy != 0)
                                {

                                    string s = "'" + content + "'����ҽ���Ѿ������˷��ã���������δִ�У����Խ����ó������ٱ��δִ��";
                                    errorht.Add(Guid.NewGuid(), s);
                                    //MessageBox.Show(this, "�Բ��𣬸���ҽ���Ѿ������˷��ã���������δִ�У�\r\n\r\n���Խ����ó������ٱ��δִ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                            }
                        }
                        //ͬһ��ֻ��Ҫһ��
                        if (x != 0 && myTb.Rows[x]["Group_ID"].ToString().Trim() == myTb.Rows[x - 1]["Group_ID"].ToString().Trim())
                        {
                            errorlist.Add(errorht);
                            continue;
                        }
                        //add by zouchihua 2012-6-15 δִ���Ƿ���Ҫ����ԭ��

                        if (errorht.Count == 0)
                        {
                            if (sumbitht.Count == 0)
                            {
                                if (cfg7129.Config.Trim() == "1")
                                {
                                    FrmReason fr = new FrmReason();
                                    fr.ShowDialog();
                                    if (fr.DialogResult == DialogResult.No || fr.ss.Trim() == "")
                                    {
                                        MessageBox.Show(this, "�Բ�������дδִ�е����ɣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else
                                    {
                                        reaseon = fr.ss;
                                    }
                                }
                                if (MessageBox.Show(this, "ȷ��ѡ�е�ҽ����δִ�С��𣿣�ע�⣺ȷ�Ϻ��������޸ģ���", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                                //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
                                if (new SystemCfg(7066).Config == "0")
                                {
                                    frmInPassword f1 = new frmInPassword();
                                    f1.ShowDialog();
                                    bool isHSZ = f1.isHSZ;
                                    if (f1.isLogin == false) return;
                                }
                            }


                            //				//�������ݷ��ʶ���
                            //				RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                            //				database.Initialize("");
                            //				database.Open();
                            //				//��ʼһ������
                            //				database.BeginTransaction();

                            InstanceForm.BDatabase.BeginTransaction();

                            try
                            {
                                //дֹͣ��־��δִ�б�־ 
                                sSql = "update zy_orderrecord set order_context='��ȡ����'+order_context,wzx_flag=" + InstanceForm.BCurrentUser.EmployeeId + ",status_flag=5 ,order_edate=getdate() , memo2='" + reaseon + "' " +//Modify By Tany 2005-01-31 ,order_edate=getdate() //add by zouchihua 2012-6-15����δִ�е�ԭ��
                                    " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "    and  wzx_flag<=0   and mngtype in (0,1,5) " +
                                    "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                //Modify by Tany 2005-02-21	
                                if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                                    throw new Exception("δ�ҵ���Ҫ���µ�ҽ����¼��������ȷ�ϣ�");

                                #region//add by zouchihua ͬʱ����ҽ����ӡ��¼�� 2013-4-23
                                sSql = "  update ZY_LOGORDERPRT set order_context='��ȡ����'+order_context  " +
                                   " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;//û�д�ӡ�������
                                InstanceForm.BDatabase.DoCommand(sSql);
                                sSql = "  update ZY_TMPORDERPRT set order_context='��ȡ����'+order_context  " +
                                  " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                   "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;//û�д�ӡ�������
                                InstanceForm.BDatabase.DoCommand(sSql);

                                sSql = "  update ZY_LOGORDERPRT set PRT_STATUS=4,memo='ȡ��'  " +
                                  " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                   "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and PRT_STATUS not in(0,-1)";//��ӡ�������
                                InstanceForm.BDatabase.DoCommand(sSql);
                                sSql = "  update ZY_TMPORDERPRT set    PRT_STATUS=4 ,memo='ȡ��' " +
                                  " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                   "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and PRT_STATUS not in(0,-1)";//��ӡ������� ��������Ϊ4
                                InstanceForm.BDatabase.DoCommand(sSql);
                                #endregion
                                //add by zouchihua 2012-5-18 ���û��ִ�й�����ִ�б��������
                                if (myTb1.Rows.Count == 0)
                                {
                                    string order_id = myTb.Rows[nrow]["order_id"].ToString().Trim();
                                    string inpatient_id = ClassStatic.Current_BinID.ToString();
                                    string baby_id = ClassStatic.Current_BabyID.ToString();
                                    string id = Guid.NewGuid().ToString();
                                    DateTime dt = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                                    string insert = " insert into zy_orderexec(id, ORDER_ID,BOOK_DATE,inpatient_id,baby_id,REALEXEUSER,jgbm,EXECDATE) select  DBO.FUN_GETGUID(NEWID(),GETDATE()),order_id,getdate(),'" + inpatient_id + "'," + baby_id + "," + FrmMdiMain.CurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ",'" + dt + "' from ZY_ORDERRECORD  " +
                                    "   where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                    " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() + "";
                                    InstanceForm.BDatabase.DoCommand(insert);
                                    string update = " update ZY_ORDERRECORD set LASTEXECDATE='" + dt + "' where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                    " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() + "";
                                    InstanceForm.BDatabase.DoCommand(update);
                                }
                                else
                                {
                                    string sql = " update zy_orderexec  set REALEXEUSER='" + FrmMdiMain.CurrentUser.EmployeeId + "' where  order_id in ( select order_id from ZY_ORDERRECORD where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                    " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() + " )";
                                    InstanceForm.BDatabase.DoCommand(sql);
                                }
                                string _lisGroup = "-1";
                                if (isYJ)
                                {
                                    //��ҽ����Ŀ
                                    //�����Ƿ���lis���
                                    //sSql = "select lis_group from yj_applyrecord " +
                                    //    " where orderid in (select order_id from zy_orderrecord " +
                                    //    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    //    "                           and mngtype=1 " +
                                    //    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    //    "                    )";
                                    //_lisGroup = InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim();
                                    //if (_lisGroup != "-1" && _lisGroup != "")
                                    //{
                                    //    sSql = "update yj_applyrecord set lis_group=-1 where lis_group=" + _lisGroup;
                                    //    InstanceForm.BDatabase.DoCommand(sSql);
                                    //}
                                    //ȡ�������
                                    sSql = "update YJ_ZYSQ set bscbz=1,scsj=getdate() ,scr=" + InstanceForm.BCurrentUser.EmployeeId +
                                        " where YZID in (select order_id from zy_orderrecord " +
                                        "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                        "                           and mngtype in (0,1,5) " +
                                        "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                        "                    )";
                                    //Modify by Tany 2005-02-21
                                    if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                                        throw new Exception("δ�ҵ���Ҫ���µ�ҽ�������¼��������ȷ�ϣ�");
                                }
                                //Add by zouchihua  �����ķ����������÷��Ͳ���ͬһ��ʱ��ɾ��

                                //Modify By Tany 2011-05-31 �Ƴ����������������ҽ��δִ��
                                //���ñ���ɾ����־
                                sSql = "update zy_fee_speci set delete_bit=1" +
                                    " where discharge_bit=0 and charge_bit=0 and order_id in (select order_id from zy_orderrecord " +
                                    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "                           and mngtype in (0,1,5) " +
                                    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    "                    )";
                                //Modify by Tany 2005-02-21
                                InstanceForm.BDatabase.DoCommand(sSql);
                                //if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                                //    throw new Exception("δ�ҵ���Ҫ���µķ��ü�¼��������ȷ�ϣ�");

                                //ȡ������ӡ Add By Tany 2004-12-02
                                sSql = "update zy_jy_print set delete_bit=1" +
                                    " where order_id in (select order_id from zy_orderrecord " +
                                    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "                           and mngtype in (0,1,5) " +
                                    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    "                    )";
                                InstanceForm.BDatabase.DoCommand(sSql);

                                InstanceForm.BDatabase.CommitTransaction();

                                //����lis�������
                                //					if(_lisGroup!="-1" && _lisGroup!="")
                                //					{
                                //						sSql="update ls_as_txm set delete_bit=1 where id="+_lisGroup;
                                //						InstanceForm.BDatabase.DoCommand(sSql);
                                //					}

                                //д��־ Add By Tany 2005-01-12
                                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "δִ��", "��inpatient_id=" + ClassStatic.Current_BinID + " and baby_id=" + ClassStatic.Current_BabyID + "���˵�group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() + "��ҽ��δִ��", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                                _systemLog.Save();

                                string s = "'" + content + "'����ҽ����δִ�С��ύ�ɹ�";
                                sumbitht.Add(x, s);

                                _systemLog = null;
                            }
                            catch (Exception err)
                            {
                                InstanceForm.BDatabase.RollbackTransaction();
                                //					database.Close();

                                //д������־ Add By Tany 2005-01-12
                                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "δִ�д���" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                                _systemErrLog.Save();
                                _systemErrLog = null;

                                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source + "\n�����Ѿ��ع������������ִ�У�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            errorlist.Add(errorht);
                        }

                        //if (x == myTb.Rows.Count-1)
                        //{
                        //    update(sumbitht, errorlist, sSql);
                        //}

                        //				database.Close();
                        #endregion
                    }
                }
            }
            else
            {
                #region ͣ�˵�
                bool isSelect = false;
                int i = 0;
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        isSelect = true;
                        break;
                    }
                }

                if (isSelect == false)
                {
                    MessageBox.Show(this, "�Բ�����ѡ����Ҫֹͣ�ĳ����˵���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
                if (new SystemCfg(7066).Config == "0")
                {
                    frmInPassword fi = new frmInPassword();
                    fi.ShowDialog();
                    bool isHSZ = fi.isHSZ;
                    if (fi.isLogin == false) return;
                }

                frmInputDate f1 = new frmInputDate();
                f1.ShowDialog();
                if (f1.result == false) return;

                string StopDate = f1.DtpbeginDate.Value.ToString();
                string sTERMINAL_TIMES = f1.textBox1.Text.ToString();
                string ss = "����ҽ���������Ҳ����ڱ����ң�������ͣҽ����";
                #region//add yaokx 2012-02-24 ��ȡ��ʿ���벡�����������id,�ÿ���������Ϊ�ж�
                DataRow dr = InstanceForm.BDatabase.GetDataRow("select dept_id from JC_WARDRDEPT where WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and dept_id <>" + InstanceForm.BCurrentDept.DeptId + "");
                if (dr == null) return;
                string ORDER_ID = "";
                if (rbTrans.Checked)
                {
                    for (i = 0; i <= myTb.Rows.Count - 1; i++)
                    {
                        if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                        {
                            ORDER_ID += "'" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "',";
                        }
                    }
                    ORDER_ID = ORDER_ID.Substring(0, ORDER_ID.Length - 1);

                    DataTable kd_deptdt = InstanceForm.BDatabase.GetDataTable("select * from ZY_ORDERRECORD where ORDER_ID in (" + ORDER_ID + ")");

                    if (kd_deptdt == null) return;

                    for (int j = 0; j < kd_deptdt.Rows.Count; j++)
                    {
                        string kd_dept = kd_deptdt.Rows[j]["dept_id"].ToString();
                        string ordid = kd_deptdt.Rows[j]["ORDER_ID"].ToString();
                        if (kd_dept != dr["dept_id"].ToString() && kd_dept != InstanceForm.BCurrentDept.DeptId.ToString())
                        {
                            for (i = 0; i <= myTb.Rows.Count - 1; i++)
                            {
                                if (myTb.Rows[i]["ORDER_ID"].ToString() == ordid)
                                {
                                    myTb.Rows[i]["ѡ"] = "False";
                                    ss += "\r\n" + myTb.Rows[i]["ҽ������"].ToString().Trim();
                                    break;
                                }
                            }
                        }

                    }
                }
                #endregion
                if (ss != "����ҽ���������Ҳ����ڱ����ң�������ͣҽ����")
                {
                    MessageBox.Show(ss);
                    return;
                }
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (i != 0 && myTb.Rows[i]["Group_ID"].ToString().Trim() == myTb.Rows[i - 1]["Group_ID"].ToString().Trim())
                        continue;

                    if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        string sssql_ppcl = "";//ƥ����ϵ�ҲҪֹͣ
                        if (f1.isDefalut == true)
                        {
                            //ĩ��ִ�д���Ϊȱʡֵ	�Ѿ�ͣ����ԭ����Ա�����޸�
                            sSql = "update zy_OrderRecord set status_flag=4, " +
                                " TERMINAL_TIMES=case when b.execnum is null then 1 else b.execnum end, " +
                                " ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ", " +
                                " ORDER_EDATE='" + StopDate + "', " +
                                " ORDER_EUDATE='" + StopDate + "' " +
                                "   from zy_OrderRecord a,jc_frequency b " +
                                "  where rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))" +
                                "  and a.group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and a.mngtype=2 " +
                                "       and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                                "		and (a.status_flag=2 or (a.status_flag=4 and (ORDER_EUSER is null or ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ")) )";
                            sssql_ppcl = "update zy_OrderRecord set status_flag=4, " +
                                " TERMINAL_TIMES=case when b.execnum is null then 1 else b.execnum end, " +
                                " ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ", " +
                                " ORDER_EDATE='" + StopDate + "', " +
                                " ORDER_EUDATE='" + StopDate + "' " +
                                "   from   zy_OrderRecord a,jc_frequency b   where  rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))  and   ppcl_yzid in (select  a.order_id   from zy_OrderRecord a  " +
                                "  where  " +
                                "    a.group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and a.mngtype=2 " +
                                "       and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                                "		and (a.status_flag=2 or (a.status_flag=4 and (ORDER_EUSER is null or ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ")) )  )";
                        }
                        else
                        {
                            //ĩ��ִ�д���Ϊȱʡֵ���趨ֵ����Сֵ  �Ѿ�ͣ����ԭ����Ա�����޸�
                            sSql = "update zy_OrderRecord set status_flag=4, " +
                                " TERMINAL_TIMES=case when b.execnum is not null and b.execnum<" + sTERMINAL_TIMES + " then b.execnum else " + sTERMINAL_TIMES + " end," +
                                " ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + "," +
                                " ORDER_EDATE='" + StopDate + "'," +
                                " ORDER_EUDATE='" + StopDate + "' " +
                                "       from zy_OrderRecord a,jc_frequency b " +
                                "  where rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))" +
                                " and a.group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and a.mngtype=2 " +//and a.status_flag=2 "+
                                "       and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                                "		and (a.status_flag=2 or (a.status_flag=4 and (ORDER_EUSER is null or ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ")) ) ";
                            sssql_ppcl = "update zy_OrderRecord set status_flag=4, " +
                                " TERMINAL_TIMES=case when b.execnum is not null and b.execnum<" + sTERMINAL_TIMES + " then b.execnum else " + sTERMINAL_TIMES + " end," +
                                " ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + "," +
                                " ORDER_EDATE='" + StopDate + "'," +
                                " ORDER_EUDATE='" + StopDate + "' " +
                                "  from   zy_OrderRecord a,jc_frequency b   where  rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))  and  ppcl_yzid in  (select order_id     from zy_OrderRecord a,jc_frequency b " +
                                "  where rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))" +
                                " and a.group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and a.mngtype=2 " +//and a.status_flag=2 "+
                                "       and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                                "		and (a.status_flag=2 or (a.status_flag=4 and (ORDER_EUSER is null or ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ")) ) )";
                        }
                        InstanceForm.BDatabase.DoCommand(sSql);
                        InstanceForm.BDatabase.DoCommand(sssql_ppcl);
                    }
                }
                #endregion
            }
            if (this.btδִ��.Text.Substring(0, 1) == "δ")
            {
                #region һ������ʾ������Ϣ���ύ�ɹ�����Ϣ   yaokx2013-11-20
                int SuccessCount = sumbitht.Count;
                int FailureCount = errorlist.Count;
                string str = "��ѡ��" + count + "��ҽ����\r\n��δִ�С��ɹ�" + SuccessCount + "��(\r\n";
                foreach (DictionaryEntry de in sumbitht)
                {
                    str += "   " + de.Value.ToString().Replace(" ", "") + "\r\n";
                }
                if (FailureCount > 0)
                    str += ");\r\n��δִ�С�ʧ��" + FailureCount + "��(\r\n";
                else
                    str += "";
                for (int i = 0; i < FailureCount; i++)
                {
                    Hashtable ht = (Hashtable)errorlist[i];
                    foreach (DictionaryEntry de in ht)
                    {
                        str += "  " + de.Value.ToString().Replace(" ", "") + "\r\n";
                    }
                }
                str += ");";

                MessageBox.Show(str);
                #endregion
            }
            this.ShowData();
        }


        private void myDataGrid3_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid3);
        }

        private void myDataGrid3_Clear()
        {
            DataTable myTb = (DataTable)this.myDataGrid3.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;
            this.myDataGrid3.CaptionText = "��Ŀ��ϸ";
            myTb.Rows.Clear();
        }

        private void btȡ����ҽ���˶�_Click(object sender, System.EventArgs e)
        {

            Button btnNew = (Button)sender;

            Point pp = new Point(btnNew.Location.X, btnNew.Location.Y + btnNew.Height);

            string btName = btnNew.Name.Trim().Substring(2, btnNew.Name.Trim().Length - 2);

            switch (btName)
            {
                case "ȡ����ҽ���˶�":
                    #region
                    contextMenu1.Show(btnNew.Parent, pp);
                    break;
                    #endregion
                case "ȡ��ͣҽ���˶�":
                    #region
                    contextMenu2.Show(btnNew.Parent, pp);
                    break;
                    #endregion
            }
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            Button bt = new Button();
            bt.Name = "bt" + mi.Text;

            btȡ����ҽ��ת��_Click(bt, e);
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            string sSql = "";
            string sMsg = "";
            string sGroup_id = "";
            string sOrder_id = "";
            string tmpSql = "";
            DataTable tmpTb = new DataTable();
            int j = 1;

            try
            {

                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

                if (myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["����ʱ��"].ToString().Trim() != "")
                {
                    MessageBox.Show(this, "�˵��Ѿ�ִ�У�����ɾ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sGroup_id = myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["group_id"].ToString().Trim();
                sOrder_id = myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["order_id"].ToString().Trim();

                //Modify By Tany 2010-10-11 �����������һ�����ݿ⣬ȷ���Ƿ��ͣ��������û��ˢ��
                tmpSql = "select * from zy_orderrecord where order_id='" + sOrder_id + "'";
                tmpTb = InstanceForm.BDatabase.GetDataTable(tmpSql);
                if (tmpTb != null && tmpTb.Rows.Count > 0)
                {
                    if (Convertor.IsNull(tmpTb.Rows[0]["LASTEXECDATE"], "") != "")
                    {
                        MessageBox.Show(this, "�˵��Ѿ�ִ�У�����ɾ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["group_id"].ToString().Trim() == sGroup_id)
                    {
                        sMsg += "(" + j.ToString() + ") " + myTb.Rows[i]["ҽ������"].ToString().Trim() + "\n";
                        j = j + 1;
                    }
                }
                //���ֻ��1����¼��j==2
                if (j > 2)
                {
                    if (MessageBox.Show(this, "�Ƿ�ɾ�������˵����ݣ�\n�����˵�������\n" + sMsg, "ɾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        sSql = "update zy_orderrecord set delete_bit=1,order_euser=" + Convert.ToDecimal(InstanceForm.BCurrentUser.EmployeeId) +
                            ",order_eudate='" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "' where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + Convert.ToDecimal(ClassStatic.Current_BabyID) + " and group_id=" + Convert.ToInt32(sGroup_id) +
                            " and mngtype=" + GetMNGType();
                    }
                }
                if (sSql == "")
                {
                    if (MessageBox.Show(this, "�Ƿ�ɾ���˵� " + myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["ҽ������"].ToString().Trim() + " ��", "ɾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        //�ж��Ƿ��Ǽ�ҩ��
                        tmpSql = "select 1 from zy_decoct where inpatient_id='" + ClassStatic.Current_BinID + "' and order_id='" + sOrder_id + "'";
                        tmpTb = InstanceForm.BDatabase.GetDataTable(tmpSql);
                        if (tmpTb.Rows.Count > 0)
                        {
                            if (MessageBox.Show("���˵��ǲ�ҩ��ҩ�ѣ����ɾ����ҩ������������ҩ���Ƿ����Ҫɾ���˵���", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                //���һ��Ҫɾ�������������
                                //Modify by jchl �������ҩ��Ϣ
                                //tmpSql = "update zy_decoct set order_id=DBO.FUN_GETEMPTYGUID() where inpatient_id='" + ClassStatic.Current_BinID + "' and order_id='" + sOrder_id + "'";
                                //InstanceForm.BDatabase.DoCommand(tmpSql);
                            }
                        }

                        sSql = "update zy_orderrecord set delete_bit=1,order_euser=" + Convert.ToDecimal(InstanceForm.BCurrentUser.EmployeeId) +
                            ",order_eudate='" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "' where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and order_id='" + sOrder_id + "'";
                    }
                }

                //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
                if (new SystemCfg(7066).Config == "0")
                {
                    frmInPassword f1 = new frmInPassword();
                    f1.ShowDialog();
                    if (f1.isLogin == false) return;
                }

                InstanceForm.BDatabase.DoCommand(sSql);
                MessageBox.Show(this, "ִ�гɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //д��־ Add By Tany 2005-01-12
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "ɾ���˵�", "ɾ��" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + "���˵�Group_id=" + sGroup_id + " Order_id=" + sOrder_id, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                ShowData();

            }
            catch (Exception err)
            {
                //д������־ Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "ɾ���˵�����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt�˳�_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmYZGL_Activated(object sender, System.EventArgs e)
        {
            frmYZGL_Load(null, null);
        }

        private void frmYZGL_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                bt��ϸ��Ϣ_Click(null, null);
            }
            if (e.KeyCode == Keys.F2)
            {
                rb��ʾ�����б�.Checked = true;
                rb��ʾ�����б�_Click(null, null);
            }
            if (e.KeyCode == Keys.F3)
            {
                rb���ز����б�.Checked = true;
                rb��ʾ�����б�_Click(null, null);
            }
            if (e.KeyCode == Keys.Home)
            {
                myDataGrid1.ScollRow(0);
            }
            if (e.KeyCode == Keys.End)
            {
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    myDataGrid1.ScollRow(tb.Rows.Count - 1);
                }
            }
        }

        private void LoadWard()
        {
            DataTable myTb = new DataTable();
            string sSql = "";

            cmbWard.Items.Clear();
            cmbWard.DataSource = null;

            cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);
            if (isCX)
            {
                sSql = "select WARD_ID,WARD_NAME from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " order by ward_id";
                myTb = InstanceForm.BDatabase.GetDataTable(sSql);

                cmbWard.DataSource = myTb;
                cmbWard.DisplayMember = "WARD_NAME";
                cmbWard.ValueMember = "WARD_ID";
            }
            else
            {
                cmbWard.Items.Add(InstanceForm.BCurrentDept.WardName);
            }
            cmbWard.SelectedIndexChanged += new EventHandler(cmbWard_SelectedIndexChanged);
        }

        private void cmbWard_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (isSSMZ && !rbTkxs.Checked)
                return;

            if (rbIn.Checked)
            {
                if (isCX)
                {
                    binSql = @" SELECT INPATIENT_NO AS סԺ��,BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end ҽ������,BRLX_NAME ��������,XZLX_NAME ��������,DYLX_NAME �������� " +
                        "   FROM vi_zy_vInpatient_Bed " +
                        "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' ORDER BY INPATIENT_NO,Baby_ID";
                }
                else
                {
                    binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                        "   FROM vi_zy_vInpatient_Bed " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
                }
            }
            else if (rbTempOut.Checked)
            {
                if (isCX)
                {
                    binSql = @" SELECT INPATIENT_NO AS סԺ��,BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end ҽ������,BRLX_NAME ��������,XZLX_NAME ��������,DYLX_NAME �������� " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' and flag = 5 ORDER BY INPATIENT_NO,Baby_ID";
                }
                else
                {
                    binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and flag = 5 ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
                }
                if (zczyz_notfy)
                {
                    binSql = @" SELECT INPATIENT_NO AS סԺ��,BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end ҽ������,BRLX_NAME ��������,XZLX_NAME ��������,DYLX_NAME �������� " +
                          "   FROM vi_zy_vInpatient_All " +
                          "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' and flag = 5 ORDER BY INPATIENT_NO,Baby_ID";
                }
            }
            else if (rbOut.Checked)
            {
                int _outMonth = Convert.ToInt32((new SystemCfg(7023)).Config) * -1;
                DateTime _outDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddMonths(_outMonth);

                if (isCX)
                {
                    binSql = @" SELECT INPATIENT_NO AS סԺ��,BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end ҽ������,BRLX_NAME ��������,XZLX_NAME ��������,DYLX_NAME �������� " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' and flag in (2,6) " +
                        "  and out_Date>= '" + _outDate.Date + "' ORDER BY INPATIENT_NO,Baby_ID";
                }
                else
                {
                    binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and flag in (2,6) " +
                        "  and out_Date>= '" + _outDate.Date + "' ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
                }
            }
            else if (rbTrans.Checked)
            {
                binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS סԺ�� " +
                    "   FROM vi_zy_vInpatient_All " +
                    "  WHERE  flag in(1,3,4,5) and inpatient_id in (select inpatient_id from zy_transfer_dept where cancel_bit=0 and finish_bit=1 and s_dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')) " +
                    "  ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";//2012-4-22 Modify by zouchihua ֻ��ʾ��Ժ����
            }
            else if (rbTszl.Checked)
            {
                binSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS סԺ�� " +
                    "   FROM vi_zy_vInpatient_Bed " +
                    "  WHERE inpatient_id in (select inpatient_id from ZY_TS_APPLY where status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002) and (ts_dept = " + InstanceForm.BCurrentDept.DeptId + " or ts_dept in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))) " +
                    "   ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            if (rbTkxs.Checked)
            {
                //add by zouchihua 2014-8-16 ����ҽ��
                binSql = @"select  BED_NO AS ����,NAME AS ����,a.INPATIENT_ID,a.Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS סԺ�� from 
	    vi_zy_vInpatient_Bed a join  
	    (  select inpatient_id,baby_id from ZY_ORDERRECORD where  ISNULL(tkxs,0) in (select dept_id from JC_WARDRDEPT where WARD_ID   in (select WARD_ID from JC_WARDRDEPT where DEPT_ID='" + FrmMdiMain.CurrentDept.DeptId + @"' ))
	      group by  inpatient_id,baby_id
	    ) b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id";
            }

            frmYZGL_Load(null, null);
            myDataGrid2_CurrentCellChanged(null, null);
        }

        private void rb_Click(object sender, System.EventArgs e)
        {
            if (isSSMZ && !rbTkxs.Checked)
            {
                return;
            }

            if (rbIn.Checked)
            {
                if (isCX == false)
                {
                    bt����ִ��.Visible = true;
                    btҽ����ӡ.Visible = true;
                    btȡ��ͣҽ���˶�.Visible = true;
                    btȡ��ͣҽ��ת��.Visible = true;
                    btȡ����ҽ���˶�.Visible = true;
                    btȡ����ҽ��ת��.Visible = true;
                    btnDelete.Visible = true;
                    btδִ��.Visible = true;
                    bt����.Visible = true;
                    bt����.Visible = true;
                }
            }
            else if (rbTrans.Checked || rbTszl.Checked)
            {
                bt����ִ��.Visible = true;
                btȡ��ͣҽ���˶�.Visible = false;
                btȡ��ͣҽ��ת��.Visible = false;
                btȡ����ҽ���˶�.Visible = false;
                btȡ����ҽ��ת��.Visible = false;
                btnDelete.Visible = false;
                btδִ��.Visible = false;
                if (cfg7159.Config.Trim() == "1")
                {
                    if (btδִ��.Text.Contains("ͣ"))
                        btδִ��.Visible = true;
                }
                bt����.Visible = false;
                bt����.Visible = false;

            }
            else
            {
                bt����ִ��.Visible = false;
                btȡ��ͣҽ���˶�.Visible = false;
                btȡ��ͣҽ��ת��.Visible = false;
                btȡ����ҽ���˶�.Visible = false;
                btȡ����ҽ��ת��.Visible = false;
                btnDelete.Visible = false;
                btδִ��.Visible = false;
                bt����.Visible = false;
                bt����.Visible = false;
            }
            //add by zouchihua 2012-4-27 �������Ʋ���ת��ǩ��
            if (rbTszl.Checked)
            {
                this.BtnTszlZcQm.Visible = true;
                this.btnCheck.Visible = true;
            }

            else
            {
                this.BtnTszlZcQm.Visible = false;
                this.btnCheck.Visible = false;
            }
            //������ʾ
            if (rbTkxs.Checked)
            {
                bt����ִ��.Visible = true;
                btҽ����ӡ.Visible = true;
                btȡ��ͣҽ���˶�.Visible = true;
                btȡ��ͣҽ��ת��.Visible = true;
                btȡ����ҽ���˶�.Visible = true;
                btȡ����ҽ��ת��.Visible = true;
                btnDelete.Visible = true;
                btδִ��.Visible = true;
                bt����.Visible = true;
                bt����.Visible = true;
            }
            cmbWard_SelectedIndexChanged(null, null);
        }

        private void rb��ʾ�����б�_Click(object sender, System.EventArgs e)
        {
            if (rb��ʾ�����б�.Checked)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void btִ��ʱ��_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        if (Convert.ToInt32(myTb.Rows[i]["status_flag"]) != 5)
                        {
                            MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ��û�з��ͣ����ȷ��͸������飩ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int j = 0; j < myTb.Rows.Count; j++)
                            {
                                if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                {
                                    myTb.Rows[j]["ѡ"] = false;
                                }
                            }
                            return;
                        }
                        nrow = i;
                        SelCount++;
                    }
                    if (myTb.Rows[i]["ҽ������"].ToString().IndexOf("ȡ��") >= 0)
                    {
                        MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] �Ѿ���'δִ��'������ʹ��'ִ��ʱ��'��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (SelCount == 0)
            {
                MessageBox.Show("û��ѡ��ҽ����������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("�Ƿ�ȷ������ҽ����ʵ��ִ��ʱ�䣿", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            DateTime _execTime = new DateTime();
            long _employeeId = 0;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                _execTime = frmET._execTime;
                _employeeId = frmET._employeeId;
            }
            else
            {
                return;
            }

            //��ʼ��������
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        //����ҽ��ִ�б�
                        sSql = "update zy_orderexec set realexecdate='" + _execTime + "',realexeuser=" + _employeeId +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);
                        //����ҽ����ӡ�� --Modify by zouchihua 2012-6-6 ���κ����֧������ִ��ʱ��
                        //sSql = "update zy_tmporderprt set execdate='" + _execTime + "',exeuser=" + _employeeId + " "+
                        //    " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                        //    " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        //InstanceForm.BDatabase.DoCommand(sSql);

                        //д��־ Add By Tany 2005-01-12
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "����ִ��ʱ��", "������" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " ��ҽ��ִ��ʱ�����Ϊ " + _execTime.ToString() + " " + _employeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
            }

            //ˢ�½���
            this.tabControl1_SelectedIndexChanged(sender, e);

            Cursor.Current = Cursors.Default;

            MessageBox.Show("����ִ��ʱ��ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //������������textbox��˫���¼�
        public void DataGridTextboxAddDoubleClick(DataGridEx grid, int tableStyleIndex)
        {
            DataGridTextBoxColumn dgtxt = null;
            for (int i = 0; i < grid.TableStyles[tableStyleIndex].GridColumnStyles.Count; i++)
            {
                if (grid.TableStyles[tableStyleIndex].GridColumnStyles[i].GetType().ToString() == "System.Windows.Forms.DataGridTextBoxColumn")
                {
                    dgtxt = (DataGridTextBoxColumn)grid.TableStyles[tableStyleIndex].GridColumnStyles[i];
                    dgtxt.TextBox.DoubleClick += new EventHandler(myDataGrid1_DoubleClick);
                }
                else if (grid.TableStyles[tableStyleIndex].GridColumnStyles[i].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn")
                {
                    dgtxt = (DataGridEnableTextBoxColumn)grid.TableStyles[tableStyleIndex].GridColumnStyles[i];
                    dgtxt.TextBox.DoubleClick += new EventHandler(myDataGrid1_DoubleClick);
                }
            }
        }

        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null)
                return;
            if (myTb.Rows.Count == 0)
                return;
            int nrow = 0;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            //add yaokx  2014-06-03
            int nType = this.GetMNGType();
            if (nType == 1 || nType == 5)
            {
                if (myTb.Rows[nrow]["ҽ������"].ToString().IndexOf("ȡ��") >= 0)
                {
                    this.btִ��ʱ��.Enabled = false;
                }
                else
                {
                    this.btִ��ʱ��.Enabled = true;
                }
            }
            //���ҽ��IDΪ��
            if (myTb.Rows[nrow]["Group_ID"].ToString() == "") return;

            //if (myTb.Rows.Count > 0 && myTb.Rows[nrow]["xmly"].ToString() == "2" && new SystemCfg(7202).Config =="1")
            //{
            //    string sql_1 = @"select * from jc_sf_wz where item_id_sf=" + myTb.Rows[nrow]["item_code"].ToString() + "";
            //    DataTable dt_1 = InstanceForm.BDatabase.GetDataTable(sql_1);
            //    if (dt_1.Rows.Count > 0)
            //    {
            //        string sql = @"select * from ZY_ORDERRECORD where order_id='" + myTb.Rows[nrow]["order_id"] + "'";
            //        DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
            //        int type = 0;
            //        if (this.GetMNGType() == 0 || this.GetMNGType() == 2)
            //        {
            //            type = 2;
            //        }
            //        else
            //        {
            //            type = 3;
            //        }

            //        FrmWzxm frm = new FrmWzxm();
            //        frm.Itemidsf = myTb.Rows[nrow]["item_code"].ToString();
            //        frm.BinID = ClassStatic.Current_BinID;
            //        frm.BabyID = ClassStatic.Current_BabyID;
            //        frm.RbIn = rbIn.Checked ? true : false;
            //        frm.Yztype = type;
            //        frm.IsSSMZ = isSSMZ;
            //        frm.RbTszl = rbTszl.Checked ? true : false;
            //        frm.MyTb = myTb;
            //        frm.Nrow = nrow;
            //        frm.First_times = dr["first_times"].ToString();
            //        frm.Dept_id = Convert.ToInt32(dr["DEPT_ID"].ToString());
            //    }
            //}
            if (myTb.Rows.Count > 0 && !chkSsyz.Checked) //update pengyang 2015-8-7 ����ҽ������ʾ
            {
                frmYZXX f1 = new frmYZXX();
                f1.sTitle = "���ˡ�" + this.sName + "��ҽ����ϸ��Ϣ";
                f1.MNGType = this.GetMNGType();
                f1.MNGType2 = f1.MNGType == 1 ? 5 : f1.MNGType;
                f1.Group_ID = Convert.ToInt32(myTb.Rows[nrow]["Group_ID"]);
                f1.OrderID = new Guid(myTb.Rows[nrow]["Order_ID"].ToString());
                f1.nType = Convert.ToInt32(myTb.Rows[nrow]["ntype"]);
                f1.isSSMZ = isSSMZ;
                f1.isTSZL = rbTszl.Checked ? true : false;
                f1.isCX = isCX;


                if (rbIn.Checked || rbTrans.Checked || rbTszl.Checked)
                {
                    f1.isUNCZ = false;
                    //add by zouchihua 2013-8-24 ��������������˳�Ժҽ�������������
                    if (rbTszl.Checked && cfg7160.Config.Trim() == "0")
                    {
                        DataTable tbbr = InstanceForm.BDatabase.GetDataTable("select flag from VI_ZY_VINPATIENT_BED where INPATIENT_ID='" + ClassStatic.Current_BinID + "' and baby_id='" + ClassStatic.Current_BabyID + "' and flag=4");
                        if (tbbr.Rows.Count > 0)
                        {
                            f1.isUNCZ = true;
                        }
                    }

                }
                else
                {
                    f1.isUNCZ = true;
                }
                //�ж����ҽ�����㲻�ܳ��� add by zouchihua 2013-01-07
                //string sql = "select IS_YBJS from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'";
                //DataTable temptb = FrmMdiMain.Database.GetDataTable(sql);
                //if (temptb.Rows.Count > 0)
                //{
                //    if (temptb.Rows[0]["IS_YBJS"].ToString().Trim() == "1")
                //        f1.isUNCZ = true;
                //}
                #region//Add by Zouchihua 2011-10-11 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                if (rtnSql[0] != "0")
                {
                    f1.isUNCZ = true;
                }
                //if (rtnSql[1]!="0")//��������δ���
                //{
                //   f1.isUNCZ = true;
                //}
                #endregion
                if (zczyz_notfy)
                {
                    //�����Ĳ��˳�����ֻ�ܳ���ҩƷ�����Ҳ�������ҩ��Ϣ
                    f1.isUNCZ = false;
                    f1.zczyz_notfy = zczyz_notfy;
                }
                f1.ShowDialog();
            }
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_yzdy", "Fun_ts_zyhs_yzdy", "ҽ����ӡ", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_zxd", "Fun_ts_zyhs_zxd", "ִ�е�", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }
        private void menuItem9_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (GetMNGType() != 1 && GetMNGType() != 3)
            {
                MessageBox.Show("ֻ�ܴ�ӡ��ʱҽ�����˵�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            try
            {
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                    {
                        if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                        {
                            if (Convert.ToInt32(myTb.Rows[i]["status_flag"]) != 5)
                            {
                                MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ��û�з��ͣ����ȷ��͸������飩ҽ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int j = 0; j < myTb.Rows.Count; j++)
                                {
                                    if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                    {
                                        myTb.Rows[j]["ѡ"] = false;
                                    }
                                }
                                return;
                            }
                            //ֻ�ܴ�ӡ4,5,6,8,9����
                            if (Convert.ToInt32(myTb.Rows[i]["ntype"]) != 4
                                && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 5
                                && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 6
                                && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 8
                                && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 9)
                            {
                                MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ���ܴ�ӡ��������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int j = 0; j < myTb.Rows.Count; j++)
                                {
                                    if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                    {
                                        myTb.Rows[j]["ѡ"] = false;
                                    }
                                }
                                return;
                            }
                            nrow = i;
                            SelCount++;
                        }
                    }
                }

                if (SelCount == 0)
                {
                    MessageBox.Show("û��ѡ��ҽ����������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                rds.Tables["tabZYJZPZ"].Clear();
                string _msg = "";

                //Add By Tany 2010-09-26 ��ӡ�����ñ���
                string sSql = "";
                string[] sql = new string[myTb.Rows.Count];



                //Add By Tany 2010-08-30 ���Ӻϲ����ӡ
                if (new SystemCfg(2).Config.Trim().Contains("��ɳ�е���ҽԺ") || MessageBox.Show("�Ƿ�ϲ���ӡѡ�е�ҽ����", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No || SelCount == 1)
                {
                    //���ϲ�
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                        {
                            decimal _je = 0;
                            _je = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_GETORDERFEE_EX('" + myTb.Rows[i]["Order_ID"].ToString() + "')"), "0"));

                            #region add by ���ɳ� 2014-08-05
                            string sqlstring = "select cast(ISNULL(cast(c.FLID as varchar(36)),NEWID()) as varchar(36)) flid from ZY_ORDERRECORD  a" +
                                            " left join JC_ASSAY b on a.HOITEM_ID=b.YZID" +
                                            " left join JC_JYBBFLMX c on b.YZID=c.YZXMID" +
                                            " where a.XMLY=2" +
                                          " and a.ORDER_ID='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            DataTable dt = new DataTable();
                            dt = InstanceForm.BDatabase.GetDataTable(sqlstring);
                            #endregion
                            //���Ϊ0����ʾ
                            if (_je != 0)
                            {
                                dr = rds.Tables["tabZYJZPZ"].NewRow();

                                dr["��������"] = InstanceForm.BCurrentDept.WardDeptName;
                                dr["����"] = patientInfo1.lbBed.Text;
                                dr["סԺ��"] = patientInfo1.lbID.Text;
                                dr["����"] = patientInfo1.lbName.Text;
                                dr["����"] = patientInfo1.lbAge.Text;//add by ���ɳ� 2014-08-05
                                dr["����ID"] = dt.Rows[0]["flid"].ToString();//add by ���ɳ� 2014-08-05 
                                dr["����"] = patientInfo1.lbDQKS.Text;
                                dr["�Ա�"] = patientInfo1.lbSex.Text;
                                dr["ҽ��ID"] = myTb.Rows[i]["Order_ID"].ToString();
                                dr["ҽ������"] = Convert.ToDateTime(myTb.Rows[i]["����ʱ��"]).ToShortDateString();
                                dr["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString();
                                dr["ҽ�����"] = _je.ToString();

                                //Add By Tany 2010-08-30
                                dr["����ҽ��"] = myTb.Rows[i]["����ҽ��"].ToString();
                                dr["ִ�л�ʿ"] = myTb.Rows[i]["���ͻ�ʿ"].ToString();
                                dr["ִ��ʱ��"] = myTb.Rows[i]["����ʱ��"].ToString();
                                dr["ִ�п���"] = myTb.Rows[i]["ִ�п���"].ToString();

                                //Add By Tany 2010-09-26
                                //��ѯ�Ƿ��ӡ��
                                sSql = "select id from zy_printzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "' and kind=0";//Modify By Tany 2010-09-26 ���ﶨ��kind=0Ϊ����ƾ֤
                                DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                                //Modify By Tany 2010-09-26 �γ�sql����
                                if (tempTab.Rows.Count > 0)
                                {
                                    dr["�ش�״̬"] = "�ش�";
                                    dr["�ش����"] = tempTab.Rows.Count.ToString();
                                }
                                else
                                {
                                    dr["�ش�״̬"] = "";
                                    dr["�ش����"] = "";
                                }
                                //������û���ش򣬶������¼�¼����¼��ӡ����
                                sql[i] = "insert into zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
                                        "0,'" +
                                        myTb.Rows[i]["order_id"].ToString() + "'," +
                                        "'" + Convert.ToDateTime(myTb.Rows[i]["����ʱ��"]) + "'," +
                                        "getdate()," +
                                        InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";

                                rds.Tables["tabZYJZPZ"].Rows.Add(dr);
                            }
                            else
                            {
                                _msg += " �� �� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] \n";
                            }
                        }
                    }
                }
                else
                {
                    TsSet tsset = new TsSet();
                    string[] GroupbyField ={ "ִ�п���", "����ҽ��", "�ش����" };
                    string[] ComputeField ={ "ҽ������" };
                    string[] CField ={ "count" };

                    //Add By Tany 2010-09-26
                    if (!myTb.Columns.Contains("�ش����"))
                    {
                        myTb.Columns.Add("�ش����");
                    }

                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                        {
                            //��ѯ�Ƿ��ӡ��
                            sSql = "select id from zy_printzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "' and kind=0";//Modify By Tany 2010-09-26 ���ﶨ��kind=0Ϊ����ƾ֤
                            DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);

                            myTb.Rows[i]["�ش����"] = tempTab.Rows.Count;
                        }
                    }

                    tsset.TsDataTable = myTb;

                    DataTable tb = tsset.GroupTable(GroupbyField, ComputeField, CField, " ѡ=True");

                    for (int j = 0; j < tb.Rows.Count; j++)
                    {
                        //�ϲ�
                        decimal _zje = 0;
                        string yznr = "";
                        string yzid = "";
                        int ii = 0;

                        for (int i = 0; i < myTb.Rows.Count; i++)
                        {
                            if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True"
                                && myTb.Rows[i]["ִ�п���"].ToString().Trim() == tb.Rows[j]["ִ�п���"].ToString().Trim()
                                && myTb.Rows[i]["����ҽ��"].ToString().Trim() == tb.Rows[j]["����ҽ��"].ToString().Trim()
                                && myTb.Rows[i]["�ش����"].ToString().Trim() == tb.Rows[j]["�ش����"].ToString().Trim())//Add By tany 2010-09-26 �ش����Ҫһ��
                            {
                                decimal _je = 0;
                                _je = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_GETORDERFEE_EX('" + myTb.Rows[i]["Order_ID"].ToString() + "')"), "0"));
                                //���Ϊ0����ʾ
                                if (_je != 0)
                                {
                                    _zje += _je;
                                    yznr += myTb.Rows[i]["ҽ������"].ToString().Trim() + ",";
                                    yzid += myTb.Rows[i]["Order_ID"].ToString().Trim() + ",";

                                    ii++;

                                    //������û���ش򣬶������¼�¼����¼��ӡ����
                                    sql[i] = "insert into zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
                                            "0,'" +
                                            myTb.Rows[i]["order_id"].ToString() + "'," +
                                            "'" + Convert.ToDateTime(myTb.Rows[i]["����ʱ��"]) + "'," +
                                            "getdate()," +
                                            InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
                                }
                                else
                                {
                                    _msg += " �� �� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] \n";
                                }
                            }
                        }
                        if (_zje != 0)
                        {
                            dr = rds.Tables["tabZYJZPZ"].NewRow();

                            dr["����"] = patientInfo1.lbBed.Text;
                            dr["סԺ��"] = patientInfo1.lbID.Text;
                            dr["����"] = patientInfo1.lbName.Text;
                            dr["����"] = patientInfo1.lbDQKS.Text;
                            dr["�Ա�"] = patientInfo1.lbSex.Text;
                            dr["ҽ��ID"] = yzid;
                            dr["ҽ������"] = "";
                            dr["ҽ������"] = ii.ToString() + "��ϲ�(" + yznr + ")";
                            dr["ҽ�����"] = _zje;

                            //Add By Tany 2010-08-30
                            dr["����ҽ��"] = tb.Rows[j]["����ҽ��"].ToString().Trim();
                            dr["ִ�л�ʿ"] = "";
                            dr["ִ��ʱ��"] = "";
                            dr["ִ�п���"] = tb.Rows[j]["ִ�п���"].ToString().Trim();

                            if (Convert.ToInt32(tb.Rows[j]["�ش����"]) > 0)
                            {
                                dr["�ش�״̬"] = "�ش�";
                                dr["�ش����"] = tb.Rows[j]["�ش����"].ToString();
                            }
                            else
                            {
                                dr["�ش�״̬"] = "";
                                dr["�ش����"] = "";
                            }

                            rds.Tables["tabZYJZPZ"].Rows.Add(dr);
                        }
                    }
                }

                if (_msg.Trim() != "")
                {
                    MessageBox.Show("����ҽ������Ϊ0�����ܴ�ӡ��\n\n" + _msg, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (rds.Tables["tabZYJZPZ"].Rows.Count == 0)
                {
                    return;
                }

                FrmReportView frmRptView = null;
                string _reportName = "";
                ParameterEx[] _parameters = new ParameterEx[2];


                _reportName = "ZYHS_סԺ����ƾ֤.rpt";

                _parameters[0].Text = "��ӡ��";
                _parameters[0].Value = InstanceForm.BCurrentUser.Name;
                _parameters[1].Text = "ҽԺ����";
                _parameters[1].Value = new SystemCfg(0002).Config;

                frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                //Add By Tany 2010-09-26
                frmRptView._sqlStr = sql;

                frmRptView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void menu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
                {
                    MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //������˿ؼ���Ϣû�У��򼤻�һ��
                if (patientInfo1.lbID.Text.Trim() == "")
                {
                    this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
                }

                int iSel = GetMNGType();

                //Modify By Tany 2014-12-11 �˵���ҽ������
                //if (iSel != 2 && iSel != 3)
                //{
                //    MessageBox.Show("ֻ�ܴ�ӡ�˵������Ϣ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count == 0) return;

                int nrow = 0;
                int SelCount = 0;

                try
                {
                    rds.Tables["dtBillInfo"].Clear();
                    string _msg = "";

                    //Add By Tany 2010-09-26 ��ӡ�����ñ���
                    string sSql = "";
                    string[] sql = new string[myTb.Rows.Count];

                    FrmReportView frmRptView = null;
                    string _reportName = "";
                    ParameterEx[] _parameters = new ParameterEx[6];

                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        //��ӡ�����˵�
                        if (iSel == 2 || iSel == 0)
                        {

                            dr = rds.Tables["dtBillInfo"].NewRow();
                            //string[] GrdMappingName ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
                            //                "ntype","exec_dept","day1","second1","day2","second2", "AUDITING_USER","AUDITING_USER1",
                            //                "order_euser","order_euser1","item_code","xmly",     
                            //                "ѡ",
                            //                "������","��ʱ��","ҽ������","����","����ҽ��","����ת��","�����˶�",
                            //                "ͣ����","ͣʱ��","ͣ��ҽ��","ͣ��ת��","ͣ���˶�",
                            //                "ִ��ʱ��","ִ����","ִ�п���","����ʱ��","���ͻ�ʿ",//"ִ��ʱ��","ִ����",
                            //                "ps_flag","ps_orderid","ps_user","wzx_flag","P","hoitem_id","isprintypgg"};//isggdy add by zouchihua 2011-11-30


                            dr["order_id"] = myTb.Rows[i]["Order_ID"].ToString();
                            dr["inpatient_id"] = patientInfo1.lbID.Text.ToString();

                            dr["��ʼ����"] = myTb.Rows[i]["������"].ToString();
                            dr["��ʼʱ��"] = myTb.Rows[i]["��ʱ��"].ToString();
                            dr["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString();
                            dr["¼����"] = iSel == 0 ? myTb.Rows[i]["����ҽ��"].ToString() : myTb.Rows[i]["����ת��"].ToString();

                            dr["ֹͣ����"] = myTb.Rows[i]["ͣ����"].ToString();
                            dr["ֹͣʱ��"] = myTb.Rows[i]["ͣʱ��"].ToString();
                            dr["ֹͣ��"] = iSel == 0 ? myTb.Rows[i]["ͣ��ҽ��"].ToString() : myTb.Rows[i]["ִ����"].ToString();

                            dr["ִ�п���"] = myTb.Rows[i]["ִ�п���"].ToString();
                            dr["����ʱ��"] = myTb.Rows[i]["����ʱ��"].ToString();
                            dr["������"] = myTb.Rows[i]["���ͻ�ʿ"].ToString();

                            rds.Tables["dtBillInfo"].Rows.Add(dr);
                            _reportName = "ZD_�����˵�.rpt";

                            _parameters[0].Text = "TitleText";
                            _parameters[0].Value = iSel == 0 ? "����ҽ��" : "�����˵�";
                        }
                        else
                        {
                            //��ӡ��ʱ�˵�
                            dr = rds.Tables["dtBillInfo"].NewRow();

                            dr["order_id"] = myTb.Rows[i]["Order_ID"].ToString();
                            dr["inpatient_id"] = patientInfo1.lbID;

                            dr["��ʼ����"] = myTb.Rows[i]["������"].ToString();
                            dr["��ʼʱ��"] = myTb.Rows[i]["��ʱ��"].ToString();
                            dr["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString();
                            dr["¼����"] = iSel == 1 ? myTb.Rows[i]["����ҽ��"].ToString() : myTb.Rows[i]["����ת��"].ToString();

                            dr["ִ�п���"] = myTb.Rows[i]["ִ�п���"].ToString();
                            dr["����ʱ��"] = myTb.Rows[i]["����ʱ��"].ToString();
                            dr["������"] = myTb.Rows[i]["���ͻ�ʿ"].ToString();

                            rds.Tables["dtBillInfo"].Rows.Add(dr);
                            _reportName = "ZD_��ʱ�˵�.rpt";

                            _parameters[0].Text = "TitleText";
                            _parameters[0].Value = iSel == 1 ? "��ʱҽ��" : "��ʱ�˵�";
                        }
                        int ntype = Convert.ToInt16(myTb.Rows[i]["ntype"]);
                        string stype = "";
                        switch (ntype)
                        {
                            case 0:
                                stype = "��Ժת��";
                                break;
                            case 1:
                                stype = "��ҩ";
                                break;
                            case 2:
                                stype = "�г�ҩ";
                                break;
                            case 3:
                                stype = "�в�ҩ";
                                break;
                            case 4:
                                stype = "����";
                                break;
                            case 5:
                                stype = "ҽ��";
                                break;
                            case 6:
                                stype = "����";
                                break;
                            case 7:
                                stype = "˵��";
                                break;
                            case 8:
                                stype = "����";
                                break;
                            case 9:
                                stype = "����";
                                break;
                        }
                        dr["ҽ�����"] = stype;
                    }

                    if (rds.Tables["dtBillInfo"].Rows.Count == 0)
                    {
                        return;
                    }

                    _parameters[1].Text = "����";
                    _parameters[1].Value = patientInfo1.lbBed.Text;
                    _parameters[2].Text = "����";
                    _parameters[2].Value = patientInfo1.lbName.Text;
                    _parameters[3].Text = "����";
                    _parameters[3].Value = FrmMdiMain.CurrentDept.WardName;
                    _parameters[4].Text = "����";
                    _parameters[4].Value = patientInfo1.lbDQKS.Text;
                    _parameters[5].Text = "סԺ��";
                    _parameters[5].Value = patientInfo1.lbID.Text;

                    frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                    frmRptView.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch { }
        }
        //private void menuItem9_Click(object sender, EventArgs e)
        //{
        //    if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
        //    {
        //        MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    if (GetMNGType() != 1 && GetMNGType() != 3)
        //    {
        //        MessageBox.Show("ֻ�ܴ�ӡ��ʱҽ�����˵�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
        //    if (myTb == null) return;
        //    if (myTb.Rows.Count == 0) return;

        //    int nrow = 0;
        //    int SelCount = 0;

        //    try
        //    {
        //        for (int i = 0; i < myTb.Rows.Count; i++)
        //        {
        //            if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
        //            {
        //                if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
        //                {
        //                    if (Convert.ToInt32(myTb.Rows[i]["status_flag"]) != 5)
        //                    {
        //                        MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ��û�з��ͣ����ȷ��͸������飩ҽ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        for (int j = 0; j < myTb.Rows.Count; j++)
        //                        {
        //                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
        //                            {
        //                                myTb.Rows[j]["ѡ"] = false;
        //                            }
        //                        }
        //                        return;
        //                    }
        //                    //ֻ�ܴ�ӡ4,5,6,8,9����
        //                    if (Convert.ToInt32(myTb.Rows[i]["ntype"]) != 4
        //                        && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 5
        //                        && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 6
        //                        && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 8
        //                        && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 9)
        //                    {
        //                        MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ���ܴ�ӡ��������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        for (int j = 0; j < myTb.Rows.Count; j++)
        //                        {
        //                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
        //                            {
        //                                myTb.Rows[j]["ѡ"] = false;
        //                            }
        //                        }
        //                        return;
        //                    }
        //                    nrow = i;
        //                    SelCount++;
        //                }
        //            }
        //        }

        //        if (SelCount == 0)
        //        {
        //            MessageBox.Show("û��ѡ��ҽ����������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        rds.Tables["tabZYJZPZ"].Clear();
        //        string _msg = "";

        //        //Add By Tany 2010-09-26 ��ӡ�����ñ���
        //        string sSql = "";
        //        string[] sql = new string[myTb.Rows.Count];

        //        //Add By Tany 2010-08-30 ���Ӻϲ����ӡ
        //        if (MessageBox.Show("�Ƿ�ϲ���ӡѡ�е�ҽ����", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No || SelCount == 1)
        //        {
        //            //���ϲ�
        //            for (int i = 0; i < myTb.Rows.Count; i++)
        //            {
        //                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
        //                {
        //                    decimal _je = 0;
        //                    _je = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_GETORDERFEE_EX('" + myTb.Rows[i]["Order_ID"].ToString() + "')"), "0"));
        //                    //���Ϊ0����ʾ
        //                    if (_je != 0)
        //                    {
        //                        dr = rds.Tables["tabZYJZPZ"].NewRow();

        //                        dr["����"] = patientInfo1.lbBed.Text;
        //                        dr["סԺ��"] = patientInfo1.lbID.Text;
        //                        dr["����"] = patientInfo1.lbName.Text;
        //                        dr["����"] = patientInfo1.lbDQKS.Text;
        //                        dr["�Ա�"] = patientInfo1.lbSex.Text;
        //                        dr["ҽ��ID"] = myTb.Rows[i]["Order_ID"].ToString();
        //                        dr["ҽ������"] = Convert.ToDateTime(myTb.Rows[i]["����ʱ��"]).ToShortDateString();
        //                        dr["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString();
        //                        dr["ҽ�����"] = _je.ToString();

        //                        //Add By Tany 2010-08-30
        //                        dr["����ҽ��"] = myTb.Rows[i]["����ҽ��"].ToString();
        //                        dr["ִ�л�ʿ"] = myTb.Rows[i]["���ͻ�ʿ"].ToString();
        //                        dr["ִ��ʱ��"] = myTb.Rows[i]["����ʱ��"].ToString();
        //                        dr["ִ�п���"] = myTb.Rows[i]["ִ�п���"].ToString();

        //                        //Add By Tany 2010-09-26
        //                        //��ѯ�Ƿ��ӡ��
        //                        sSql = "select id from zy_printzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "' and kind=0";//Modify By Tany 2010-09-26 ���ﶨ��kind=0Ϊ����ƾ֤
        //                        DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
        //                        //Modify By Tany 2010-09-26 �γ�sql����
        //                        if (tempTab.Rows.Count > 0)
        //                        {
        //                            dr["�ش�״̬"] = "�ش�";
        //                            dr["�ش����"] = tempTab.Rows.Count.ToString();
        //                        }
        //                        else
        //                        {
        //                            dr["�ش�״̬"] = "";
        //                            dr["�ش����"] = "";
        //                        }
        //                        //������û���ش򣬶������¼�¼����¼��ӡ����
        //                        sql[i] = "insert into zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
        //                                "0,'" +
        //                                myTb.Rows[i]["order_id"].ToString() + "'," +
        //                                "'" + Convert.ToDateTime(myTb.Rows[i]["����ʱ��"]) + "'," +
        //                                "getdate()," +
        //                                InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";

        //                        rds.Tables["tabZYJZPZ"].Rows.Add(dr);
        //                    }
        //                    else
        //                    {
        //                        _msg += " �� �� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] \n";
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            TsSet tsset = new TsSet();
        //            string[] GroupbyField ={ "ִ�п���", "����ҽ��", "�ش����" };
        //            string[] ComputeField ={ "ҽ������" };
        //            string[] CField ={ "count" };

        //            //Add By Tany 2010-09-26
        //            if (!myTb.Columns.Contains("�ش����"))
        //            {
        //                myTb.Columns.Add("�ش����");
        //            }

        //            for (int i = 0; i < myTb.Rows.Count; i++)
        //            {
        //                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
        //                {
        //                    //��ѯ�Ƿ��ӡ��
        //                    sSql = "select id from zy_printzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "' and kind=0";//Modify By Tany 2010-09-26 ���ﶨ��kind=0Ϊ����ƾ֤
        //                    DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);

        //                    myTb.Rows[i]["�ش����"] = tempTab.Rows.Count;
        //                }
        //            }

        //            tsset.TsDataTable = myTb;

        //            DataTable tb = tsset.GroupTable(GroupbyField, ComputeField, CField, " ѡ=True");

        //            for (int j = 0; j < tb.Rows.Count; j++)
        //            {
        //                //�ϲ�
        //                decimal _zje = 0;
        //                string yznr = "";
        //                string yzid = "";
        //                int ii = 0;

        //                for (int i = 0; i < myTb.Rows.Count; i++)
        //                {
        //                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True"
        //                        && myTb.Rows[i]["ִ�п���"].ToString().Trim() == tb.Rows[j]["ִ�п���"].ToString().Trim()
        //                        && myTb.Rows[i]["����ҽ��"].ToString().Trim() == tb.Rows[j]["����ҽ��"].ToString().Trim()
        //                        && myTb.Rows[i]["�ش����"].ToString().Trim() == tb.Rows[j]["�ش����"].ToString().Trim())//Add By tany 2010-09-26 �ش����Ҫһ��
        //                    {
        //                        decimal _je = 0;
        //                        _je = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_GETORDERFEE_EX('" + myTb.Rows[i]["Order_ID"].ToString() + "')"), "0"));
        //                        //���Ϊ0����ʾ
        //                        if (_je != 0)
        //                        {
        //                            _zje += _je;
        //                            yznr += myTb.Rows[i]["ҽ������"].ToString().Trim() + ",";
        //                            yzid += myTb.Rows[i]["Order_ID"].ToString().Trim() + ",";

        //                            ii++;

        //                            //������û���ش򣬶������¼�¼����¼��ӡ����
        //                            sql[i] = "insert into zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
        //                                    "0,'" +
        //                                    myTb.Rows[i]["order_id"].ToString() + "'," +
        //                                    "'" + Convert.ToDateTime(myTb.Rows[i]["����ʱ��"]) + "'," +
        //                                    "getdate()," +
        //                                    InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
        //                        }
        //                        else
        //                        {
        //                            _msg += " �� �� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] \n";
        //                        }
        //                    }
        //                }
        //                if (_zje != 0)
        //                {
        //                    dr = rds.Tables["tabZYJZPZ"].NewRow();

        //                    dr["����"] = patientInfo1.lbBed.Text;
        //                    dr["סԺ��"] = patientInfo1.lbID.Text;
        //                    dr["����"] = patientInfo1.lbName.Text;
        //                    dr["����"] = patientInfo1.lbDQKS.Text;
        //                    dr["�Ա�"] = patientInfo1.lbSex.Text;
        //                    dr["ҽ��ID"] = yzid;
        //                    dr["ҽ������"] = "";
        //                    dr["ҽ������"] = ii.ToString() + "��ϲ�(" + yznr + ")";
        //                    dr["ҽ�����"] = _zje;

        //                    //Add By Tany 2010-08-30
        //                    dr["����ҽ��"] = tb.Rows[j]["����ҽ��"].ToString().Trim();
        //                    dr["ִ�л�ʿ"] = "";
        //                    dr["ִ��ʱ��"] = "";
        //                    dr["ִ�п���"] = tb.Rows[j]["ִ�п���"].ToString().Trim();

        //                    if (Convert.ToInt32(tb.Rows[j]["�ش����"]) > 0)
        //                    {
        //                        dr["�ش�״̬"] = "�ش�";
        //                        dr["�ش����"] = tb.Rows[j]["�ش����"].ToString();
        //                    }
        //                    else
        //                    {
        //                        dr["�ش�״̬"] = "";
        //                        dr["�ش����"] = "";
        //                    }

        //                    rds.Tables["tabZYJZPZ"].Rows.Add(dr);
        //                }
        //            }
        //        }

        //        if (_msg.Trim() != "")
        //        {
        //            MessageBox.Show("����ҽ������Ϊ0�����ܴ�ӡ��\n\n" + _msg, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        if (rds.Tables["tabZYJZPZ"].Rows.Count == 0)
        //        {
        //            return;
        //        }

        //        FrmReportView frmRptView = null;
        //        string _reportName = "";
        //        ParameterEx[] _parameters = new ParameterEx[2];


        //        _reportName = "ZYHS_סԺ����ƾ֤.rpt";

        //        _parameters[0].Text = "��ӡ��";
        //        _parameters[0].Value = InstanceForm.BCurrentUser.Name;
        //        _parameters[1].Text = "ҽԺ����";
        //        _parameters[1].Value = new SystemCfg(0002).Config;

        //        frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

        //        //Add By Tany 2010-09-26
        //        frmRptView._sqlStr = sql;

        //        frmRptView.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btԤ��_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal _orderfee = 0;
            int GroupID = -999;
            int iMNGType = 0;
            int iSelectRows = 0;
            DataTable myTb = (DataTable)myDataGrid1.DataSource;
            DateTime ExecDate = Convert.ToDateTime(Convertor.IsNull(((Button)sender).Tag, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString()));

            #region ��Ч���ж�
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ��ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            iMNGType = GetMNGType();

            progressBar1.Maximum = myTb.Rows.Count;
            progressBar1.Value = 0;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //�����ѡ����
                if (myTb.Rows[i]["ѡ"].ToString() == "False")
                {
                    continue;
                }

                //����������һ��ҽ����ͬ����ִ��
                if (GroupID == Convert.ToInt32(myTb.Rows[i]["Group_ID"]))
                {
                    continue;
                }

                GroupID = Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
                int iMNGType2 = iMNGType == 1 ? 5 : iMNGType;

                _orderfee += myFunc.GetOrderFee(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, iMNGType, GroupID, ExecDate, ExecDate);

                progressBar1.Value += 1;
            }

            progressBar1.Value = 0;

            Button bt = (Button)sender;

            if (bt.Name == "btԤ��")
            {
                MessageBox.Show("����ҽ������Ԥ��Ϊ��" + _orderfee.ToString() + " Ԫ");
            }
            else
            {
                orderfee = _orderfee;
            }
        }

        private void butorderprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "ȷ��Ҫ��ҽ����ӡ����������ѡ��ҽ���룿\r\n\r\nע�⣺δ��ѡ��ҽ����ȡ����ҽ����ӡ�пɼ�������", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (Convert.ToInt16(myTb.Rows[i]["ѡ"]) == 1)
                {
                    string ssql = "update zy_orderrecord set ssmz_print=" + Convert.ToInt16(myTb.Rows[i]["ѡ"]) + " where order_id='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "'";
                    InstanceForm.BDatabase.DoCommand(ssql);
                }
                else
                {
                    string ssql = "select * from zy_tmporderprt(nolock) where order_id='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "'";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count == 0)
                    {
                        ssql = "update zy_orderrecord set ssmz_print=" + Convert.ToInt16(myTb.Rows[i]["ѡ"]) + " where order_id='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(myTb.Rows[i]["ҽ������"]) + "����ȡ����ӡ����Ϊ���ѱ�ҽ����ӡ������¼");
                    }
                }
            }

            MessageBox.Show("�����ɹ�");
        }

        private bool myDataGrid1_myKeyDown(ref Message msg, Keys keyData)
        {
            long keyInt = Convert.ToInt32(keyData);
            if (keyInt == 36)
            {
                myDataGrid1.ScollRow(0);
            }
            else if (keyInt == 35)
            {
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    myDataGrid1.ScollRow(tb.Rows.Count - 1);
                }
            }
            return true;
        }

        private void ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Frmserch fserch = new Frmserch();
            // Point wz = Cursor.Position;
            //Point ScreenP = this.myDataGrid2.PointToScreen(wz);
            // fserch.Location = ScreenP;
            // fserch.ShowDialog();
            string iptid = Inpatient.GetInpatientID().ToString();// GetInpatientNO();
            if (iptid == "" || iptid == Guid.Empty.ToString())
            {
                return;
            }
            int flag = 0;
            DataTable tb = (DataTable)myDataGrid2.DataSource;
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["inpatient_id"].ToString().Trim() == iptid)
                    {
                        myDataGrid2.UnSelect(myDataGrid2.CurrentCell.RowNumber);
                        DataGridCell cell = new DataGridCell(i, 0);
                        myDataGrid2.CurrentCell = cell;
                        flag = 1;
                        return;
                    }
                }
            }

            if (flag == 0)
            {
                //ȫ����ѯģ��
                if (isCX == true)
                {
                    string sql1 = "";
                    int _outMonth = Convert.ToInt32((new SystemCfg(7023)).Config) * -1;
                    DateTime _outDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddMonths(_outMonth);
                    sql1 = "select WARD_ID,ward_name,flag,inpatient_id" +
                            "   FROM vi_zy_vInpatient_All " +
                            "  WHERE  ( out_date is null or " +
                            "   out_Date>= '" + _outDate.Date + "')  and inpatient_id='" + iptid + "'";

                    //sql1 = "  select WARD_ID,ward_name,flag,inpatient_id from  VI_ZY_VINPATIENT_ALL  where inpatient_id='" + iptid + "'";
                    DataTable tbtb = FrmMdiMain.Database.GetDataTable(sql1);
                    if (tbtb.Rows.Count > 0)
                    {
                        if (tbtb.Rows[0]["flag"].ToString() == "3" || tbtb.Rows[0]["flag"].ToString() == "4")
                        {
                            rbIn.Checked = true;
                            rb_Click(null, null);
                        }
                        if (tbtb.Rows[0]["flag"].ToString() == "5")
                        {
                            rbTempOut.Checked = true;
                            rb_Click(null, null);
                        }
                        if (tbtb.Rows[0]["flag"].ToString() == "6" || tbtb.Rows[0]["flag"].ToString() == "2")
                        {
                            rbOut.Checked = true;
                            rb_Click(null, null);
                        }
                        cmbWard.SelectedValue = tbtb.Rows[0]["WARD_ID"].ToString();
                        DataTable tb1 = (DataTable)myDataGrid2.DataSource;
                        for (int i = 0; i < tb1.Rows.Count; i++)
                        {
                            if (tb1.Rows[i]["inpatient_id"].ToString().Trim() == iptid)
                            {
                                myDataGrid2.UnSelect(myDataGrid2.CurrentCell.RowNumber);
                                DataGridCell cell = new DataGridCell(i, 0);
                                myDataGrid2.CurrentCell = cell;
                                flag = 1;
                                return;
                            }
                        }
                        MessageBox.Show("û���ҵ���Ӧ�Ľ������", "��ʾ��Ϣ"); return;
                    }
                    else
                    {
                        MessageBox.Show("û���ҵ���Ӧ�Ľ������", "��ʾ��Ϣ"); return;
                    }

                }
            }
            else
                MessageBox.Show("û���ҵ���Ӧ�Ľ������", "��ʾ��Ϣ");
        }

        private void btnSqyzdy_Click(object sender, EventArgs e)
        {
            //add by zouchihua 2012-3-27 ��ǰִ�е���ӡ
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb == null || tb.Rows.Count == 0)
                return;
            DataTable temptb = new DataTable();
            temptb.Columns.Add("ҽ������", typeof(System.String));
            temptb.Columns.Add("���", typeof(System.String));
            temptb.Columns.Add("����", typeof(System.String));
            temptb.Columns.Add("ִ��ʱ��", typeof(System.String));
            temptb.Columns.Add("ת����ʿ", typeof(System.String));
            temptb.Columns.Add("group_id", typeof(System.String));
            temptb.Columns.Add("ִ����", typeof(System.String));
            int zflag = 0;
            int zjs = 0;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    DataRow row = temptb.NewRow();
                    //row["ҽ������"] = tb.Rows[i]["ҽ������"].ToString().Substring(0, tb.Rows[i]["ҽ������"].ToString().LastIndexOf(GetNumUnit(tb, i)) + GetNumUnit(tb, i).Length);
                    DataTable ordertb = FrmMdiMain.Database.GetDataTable("select * from ZY_ORDERRECORD where ORDER_ID='" + tb.Rows[i]["order_id"] + "'");
                    if (ordertb != null && ordertb.Rows.Count > 0)
                    {
                        row["ҽ������"] = ordertb.Rows[0]["ORDER_CONTEXT"].ToString().Trim();
                        for (int x = System.Text.Encoding.Default.GetByteCount(ordertb.Rows[0]["ORDER_CONTEXT"].ToString().Trim()); x < 40; x++)
                        {
                            row["ҽ������"] += " ";
                        }
                        row["ҽ������"] += GetNumUnit(tb, i);
                    }
                    row["���"] = tb.Rows[i]["ORDER_SPEC"];
                    if (i < tb.Rows.Count - 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i + 1]["group_id"].ToString())
                    {
                        if (zflag == 0)
                        {
                            row["����"] = "��";
                            zflag = 1;
                        }
                        else
                            if (zflag == 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i - 1]["group_id"].ToString())
                            {
                                row["����"] = "��";
                            }
                    }
                    else
                        if (zflag == 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i - 1]["group_id"].ToString())
                        {
                            row["����"] = "��";
                            zflag = 0;
                            zjs = 0;
                        }
                        else
                        {
                            zflag = 0;
                            zjs = 0;
                        }
                    row["group_id"] = tb.Rows[i]["group_id"];
                    row["ִ��ʱ��"] = tb.Rows[i]["ִ��ʱ��"];
                    row["ת����ʿ"] = tb.Rows[i]["����ת��"];
                    row["ִ����"] = tb.Rows[i]["ִ����"];
                    temptb.Rows.Add(row);
                }
            }
            string _reportName = "HS_��ǰִ�е�.rpt";
            ParameterEx[] _parameters = new ParameterEx[5];
            _parameters[0].Text = "ҽԺ����";
            _parameters[0].Value = new SystemCfg(0002).Config;
            _parameters[1].Text = "����";
            _parameters[1].Value = InstanceForm.BCurrentDept.WardName;
            _parameters[2].Text = "��ӡ��";
            _parameters[2].Value = InstanceForm.BCurrentUser.Name;
            _parameters[3].Text = "����";
            _parameters[3].Value = this.patientInfo1.lbName.Text;
            _parameters[4].Text = "����";
            _parameters[4].Value = this.patientInfo1.lbBed.Text;
            FrmReportView frmRptView = new FrmReportView(temptb, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);
            //frmRptView._sqlStr = sql;
            frmRptView.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        if (Convert.ToInt32(myTb.Rows[i]["status_flag"]) != 5)
                        {
                            MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ��û�з��ͣ����ȷ��͸������飩ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int j = 0; j < myTb.Rows.Count; j++)
                            {
                                if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                {
                                    myTb.Rows[j]["ѡ"] = false;
                                }
                            }
                            return;
                        }
                        //��û���ִ��ʱ��
                        if (myTb.Rows[i]["ִ����"].ToString().Trim() == "")
                        {
                            MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ��û��ִ���ˣ����ȵ����ִ��ʱ�䡿��ť��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int j = 0; j < myTb.Rows.Count; j++)
                            {
                                if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                {
                                    myTb.Rows[j]["ѡ"] = false;
                                }
                            }
                            return;
                        }

                        nrow = i;
                        SelCount++;
                    }
                }
            }
            if (SelCount == 0)
            {
                MessageBox.Show("û��ѡ��ҽ����������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("�Ƿ�ȷ������˫ǩ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            DateTime _execTime = new DateTime();
            long _employeeId = 0;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                _execTime = frmET._execTime;
                _employeeId = frmET._employeeId;
            }
            else
            {
                return;
            }

            //��ʼ��������
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        if (myTb.Rows[i]["REALEXEUSER"].ToString().Trim() == _employeeId.ToString().Trim())
                        {
                            MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ������ǩ��������ͬ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int j = 0; j < myTb.Rows.Count; j++)
                            {
                                if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                {
                                    myTb.Rows[j]["ѡ"] = false;
                                }
                            }
                            continue;
                        }
                        //����ҽ��ִ�б�
                        sSql = "update zy_orderexec set  realexeuserdb=" + _employeeId +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);
                        //����ҽ����ӡ��
                        sSql = "update zy_tmporderprt set  exec_Duser=" + _employeeId +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //д��־ Add By Tany 2005-01-12
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "����ִ��ʱ��", "������" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " ��ҽ��ִ��ʱ�����Ϊ " + " " + _employeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
            }

            //ˢ�½���
            this.tabControl1_SelectedIndexChanged(sender, e);

            Cursor.Current = Cursors.Default;

            MessageBox.Show("˫ǩ���ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ȡ��˫ǩ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int nrow = 0;
            int SelCount = 0;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True" && myTb.Rows[i]["REALEXEUSERDb"].ToString().Trim() != frmET._employeeId.ToString().Trim())
                    {
                        MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ˫ǩ��������ǩ�ģ�����Ȩȡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int j = 0; j < myTb.Rows.Count; j++)
                        {
                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            {
                                myTb.Rows[j]["ѡ"] = false;
                            }
                        }
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            //��ʼ��������
            Cursor.Current = PubStaticFun.WaitCursor();
            if (MessageBox.Show("�Ƿ�ȷ��ȡ��˫ǩ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {

                        //����ҽ��ִ�б�
                        sSql = "update zy_orderexec set  realexeuserdb=-1" +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);
                        //����ҽ����ӡ��
                        sSql = "update zy_tmporderprt set  exec_Duser=-1" +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //д��־ Add By Tany 2005-01-12
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "����ִ��ʱ��", "������" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " ��ҽ��˫ǩ������Ϊ " + " -1", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
            }

            //ˢ�½���
            this.tabControl1_SelectedIndexChanged(sender, e);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("ȡ��˫ǩ���ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTszlZcQm_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        SelCount++;
                    }
                }
            }
            if (SelCount == 0)
            {
                MessageBox.Show("û��ѡ��ҽ����������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((sender as Button).Text.Contains("ת��ǩ��"))
            {
                if (MessageBox.Show("�Ƿ�ȷ������ת��ǩ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("�Ƿ�ȷ�����к˶�ǩ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            DateTime _execTime = new DateTime();
            long _employeeId = 0;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                _execTime = frmET._execTime;
                _employeeId = frmET._employeeId;
            }
            else
            {
                return;
            }

            //��ʼ��������
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        if ((sender as Button).Text.Contains("ת��ǩ��"))
                        {
                            //if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() != "" && myTb.Rows[i]["AUDITING_USER"].ToString().Trim() != "-1")
                            //{
                            //    MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ת��ǩ���Ѿ����ڣ���������ǩ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    for (int j = 0; j < myTb.Rows.Count; j++)
                            //    {
                            //        if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            //        {
                            //            myTb.Rows[j]["ѡ"] = false;
                            //        }
                            //    }
                            //    return;
                            //}
                            //���ں˶���
                            if (myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() != "" && myTb.Rows[i]["AUDITING_USER"].ToString().Trim() != "-1")
                            {
                                if (myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() == _employeeId.ToString().Trim())
                                {
                                    MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ת���ͺ˶Բ���Ϊͬһ���ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            //����ҽ��ִ�б�
                            sSql = "update ZY_ORDERRECORD set  AUDITING_USER=" + _employeeId + ", AUDITING_DATE='" + _execTime + "' " +
                                " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                            InstanceForm.BDatabase.DoCommand(sSql);
                            //����ҽ����ӡ��
                            sSql = "update zy_tmporderprt set  AUDITING_USER=" + _employeeId + " " +
                                " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                            InstanceForm.BDatabase.DoCommand(sSql);

                            //д��־ Add By Tany 2005-01-12
                            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "ת��ǩ��", "������" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " ��ת���˸���Ϊ " + " " + _employeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                            _systemLog.Save();
                            _systemLog = null;
                        }
                        else
                        {
                            #region  �˶�ǩ��
                            //if(
                            //    (myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() != "" && myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() != "-1")         
                            //)
                            //{
                            //    MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] �˶�ǩ���Ѿ����ڣ���������ǩ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    for (int j = 0; j < myTb.Rows.Count; j++)
                            //    {
                            //        if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            //        {
                            //            myTb.Rows[j]["ѡ"] = false;
                            //        }
                            //    }
                            //    return;
                            //}
                            if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == "" || myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == "-1")
                            {
                                MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] û��ת��ǩ����������ת����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //by add yaokx 2014-06-10 ƽ̨��5014ת���ͺ˶�ǩ��������ͬһ��ִ�У��������жϣ�������ͬһ��ǩ����������Ҳ��ܴ�ӡҽ�������ᱨ��
                            if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() || myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == _employeeId.ToString())
                            {
                                MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ת���ͺ˶Բ���Ϊͬһ���ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //����ҽ��ִ�б�
                            sSql = "update ZY_ORDERRECORD set  AUDITING_USER1=" + _employeeId + ", AUDITING_DATE1='" + _execTime + "' " +
                                " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                            InstanceForm.BDatabase.DoCommand(sSql);
                            //����ҽ����ӡ��
                            sSql = "update zy_tmporderprt set  AUDITING_USER1=" + _employeeId + " " +
                                " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                            InstanceForm.BDatabase.DoCommand(sSql);

                            //д��־ Add By Tany 2005-01-12
                            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�˶�ǩ��", "������" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " ��ת���˸���Ϊ " + " " + _employeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                            _systemLog.Save();
                            _systemLog = null;
                            #endregion
                        }
                    }
                }
            }

            //ˢ�½���
            this.tabControl1_SelectedIndexChanged(sender, e);

            Cursor.Current = Cursors.Default;

            MessageBox.Show((sender as Button).Text.Contains("ת��ǩ��") ? "ת��ǩ���ɹ���" : "�˶�ǩ���ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ɾ��ִ��ʱ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int nrow = 0;
            int SelCount = 0;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True" && myTb.Rows[i]["REALEXEUSERDb"].ToString().Trim() != "" && myTb.Rows[i]["REALEXEUSERDb"].ToString().Trim() != "-1")
                    {
                        MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] �Ѿ�˫ǩ��������Ȩȡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int j = 0; j < myTb.Rows.Count; j++)
                        {
                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            {
                                myTb.Rows[j]["ѡ"] = false;
                            }
                        }
                        return;
                    }
                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True" && myTb.Rows[i]["REALEXEUSER"].ToString().Trim() != frmET._employeeId.ToString().Trim())
                    {
                        MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ִ��ʱ�䲻����ǩ�ģ�����Ȩȡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int j = 0; j < myTb.Rows.Count; j++)
                        {
                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            {
                                myTb.Rows[j]["ѡ"] = false;
                            }
                        }
                        return;
                    }

                }
            }
            else
            {
                return;
            }

            //��ʼ��������
            Cursor.Current = PubStaticFun.WaitCursor();
            if (MessageBox.Show("�Ƿ�ȷ��ȡ��ִ��ʱ�䣿", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {

                        //����ҽ��ִ�б�
                        sSql = "update zy_orderexec set  realexecdate=null,REALEXEUSER=-1" +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);
                        //����ҽ����ӡ��
                        sSql = "update zy_tmporderprt set  execdate=null,EXEUSER=null" +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //д��־ Add By Tany 2005-01-12
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "����ִ��ʱ��", "������" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " ��ҽ��ǩ������Ϊ " + " null", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
            }

            //ˢ�½���
            this.tabControl1_SelectedIndexChanged(sender, e);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("ȡ��ִ��ʱ��ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ����ǩ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            string str_orderid = "(";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    str_orderid += "'" + myTb.Rows[i]["order_id"].ToString().Trim() + "',";
                }
            }
            if (str_orderid != "(")
                str_orderid = str_orderid.Substring(0, str_orderid.Length - 1) + ")";
            else
                return;
            FrmDgqm fqm = new FrmDgqm();
            fqm.str_orderid = str_orderid;
            fqm.ShowDialog();
            if (fqm.DialogResult == DialogResult.OK)
            {
                //ˢ�½���
                this.tabControl1_SelectedIndexChanged(sender, e);

            }
        }
        private void che_yz_CheckedChanged(object sender, EventArgs e)
        {
            txt_yz.Enabled = txt_yz.Enable = che_yz.Checked;
            this.ShowData();
        }

        private void che_date_CheckedChanged(object sender, EventArgs e)
        {
            cmb_date.Enabled = che_date.Checked;
            this.ShowData();
        }

        private void cmb_date_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowData();
        }

        private void txt_yz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ShowData();
            }
        }

        //Add By Tany 2015-02-02 ��ӡ��ҩ����
        private void menu_printzycf_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (GetMNGType() != 0 && GetMNGType() != 1)
            {
                MessageBox.Show("ֻ�ܴ�ӡ�в�ҩҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            try
            {
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                    {
                        if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                        {
                            //ֻ�ܴ�ӡ4,5,6,8,9����
                            if (Convert.ToInt32(myTb.Rows[i]["ntype"]) != 3)
                            {
                                MessageBox.Show("�� " + (i + 1) + " ��ҽ�� [" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "] ���ܴ�ӡ��������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int j = 0; j < myTb.Rows.Count; j++)
                                {
                                    if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                    {
                                        myTb.Rows[j]["ѡ"] = false;
                                    }
                                }
                                return;
                            }
                            nrow = i;
                            SelCount++;
                        }
                    }
                }

                if (SelCount == 0)
                {
                    MessageBox.Show("û��ѡ��ҽ����������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //////////////
                string groupid = "";
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                    {
                        if (groupid == myTb.Rows[i]["group_id"].ToString().Trim())
                        {
                            continue;
                        }
                        else
                        {
                            groupid = myTb.Rows[i]["group_id"].ToString().Trim();
                        }
                        string mngtype = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select mngtype from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "' and group_id=" + groupid), GetMNGType().ToString());
                        ts_yf_zyfy.PubClass.PrintCf(ClassStatic.Current_BinID.ToString(), mngtype, groupid, InstanceForm.BDatabase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ��Ϣ");
            }
        }

        private void DoInitCtr(string[] headtext, string[] mappingname, string[] serchFileds, int[] cols, DataTable dtSrc)
        {
            ucShowCard1.Init(headtext, mappingname, serchFileds, cols, dtSrc);
        }

        private void ucShowCard1_MyDelEvent()
        {
            ucShowCard1.Value = ucShowCard1.Row["����"].ToString();
            ucShowCard1.Key = ucShowCard1.Row["INPATIENT_ID"].ToString();

            DataTable dt = myDataGrid2.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return;

            dt.DefaultView.RowFilter = "INPATIENT_ID='" + ucShowCard1.Key + "'";

            myDataGrid2_CurrentCellChanged(null, null);
        }

        private void chkWardOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAllSMYz.Checked)
            {
                chkShowAllSMYz.CheckedChanged -= chkShowAllSMYz_CheckedChanged;
                chkShowAllSMYz.Checked = !chkWardOrder.Checked;
                chkShowAllSMYz.CheckedChanged += chkShowAllSMYz_CheckedChanged;
            }
            chkShowAllSMYz.Enabled = !chkWardOrder.Checked;
            ShowData();
        }

        private void chkShowAllSMYz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAllSMYz.Checked)
            {
                chkWardOrder.CheckedChanged -= chkWardOrder_CheckedChanged;
                chkWardOrder.Checked = false;
                chkWardOrder.CheckedChanged += chkWardOrder_CheckedChanged;
            }
            chkWardOrder.Enabled = !chkShowAllSMYz.Checked;
            ShowData();
        }

        /// <summary>
        /// pivas �Ƿ���
        /// </summary>
        private bool isPvsChkExe(string inpatid, string babyid, string groupid)
        {
            try
            {
                string sSql = string.Format(@"select count(1) as Num from ZY_ORDERRECORD t 
                                        where t.INPATIENT_ID='{0}' and BABY_ID='{1}' and t.GROUP_ID='{2}'  and t.DELETE_BIT=0 and t.STATUS_FLAG=2 and t.is_PvsChk=0
	                                        and exists(select 1 from VI_pivas_Orderusage f where t.ORDER_USAGE=f.name)  ",
                                                                                                                         inpatid, babyid, groupid);


                string str = InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim();
                int iNum = int.Parse(str);

                //û�� ��Ҫȴδ�� ��ҽ��
                if (iNum == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void btSsmzwc_Click(object sender, EventArgs e)
        {
            string ssmz = ssmzType == 0 ? "����" : "����";

            if (MessageBox.Show(this, "�����ɺ���򽫲������" + ssmz + "�����Ϣ��������" + ssmz + "���Ϊ���״̬������\r\n\r\n��ȷ����?", "" + ssmz + "���", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    string ssql = "";
                    string ssfj = "";
                    string sNo = "";
                    //Modify By Tany 2015-05-11 ���Ҳ����м�������
                    ssql = "select SNO,APDJRQ �Ǽ�ʱ��,YSSS ����,b.NAME ����,SSTC from SS_ARRRECORD a left join SS_ANESTHESIACODE b on a.YSMZ=b.ID where BDELETE=0 and INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                    if (ssmzType == 0)
                    {
                        ssql += " and wcbj=0";
                    }
                    else
                    {
                        ssql += " and mzwcbj=0";
                    }
                    //Modify By tany 2015-05-14 �ټ��ϰ�����Ϣ
                    ssql += " union all ";
                    ssql += "select SNO,YSSSRQ ��ʩʱ��,YSSS ����,b.NAME ����,null SSTC from SS_APPRECORD a left join SS_ANESTHESIACODE b on a.YSMZ=b.ID where BDELETE=0 and (shbj = 1 or jzss=1) and apbj = 1 and INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                    DataTable ssmzTb = FrmMdiMain.Database.GetDataTable(ssql);
                    if (ssmzTb == null || ssmzTb.Rows.Count == 0)
                    {
                        MessageBox.Show("û���ҵ�δ��ɵ�" + ssmz + "���������ɣ�", "��ʾ");
                        return;
                    }
                    //else if (ssmzTb.Rows.Count == 1)
                    //{
                    //    ssfj = ssmzTb.Rows[0]["sstc"].ToString().Trim();
                    //    sNo = ssmzTb.Rows[0]["sno"].ToString().Trim();
                    //}
                    else
                    {
                        Ts_zygl_ybgl.FrmDataGridView frmDv = new Ts_zygl_ybgl.FrmDataGridView();
                        frmDv.dgv.DataSource = ssmzTb;
                        frmDv.dgv.MultiSelect = false;
                        frmDv.ShowDialog();
                        if (frmDv.DialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (frmDv.dgv.SelectedRows.Count == 0)
                            {
                                MessageBox.Show("δѡ�����ݣ�");
                                return;
                            }
                            else
                            {
                                ssfj = Convertor.IsNull(ssmzTb.Rows[frmDv.dgv.SelectedRows[0].Index]["sstc"], "");
                                sNo = Convertor.IsNull(ssmzTb.Rows[frmDv.dgv.SelectedRows[0].Index]["sno"], "");
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    //Modify By Tany 2015-04-08 ������������ɵ����ݲ�һ��
                    FrmMdiMain.Database.BeginTransaction();
                    if (ssmzType == 0)
                    {
                        //���·���ռ�ñ�־
                        if (IsGuid(ssfj))
                        {
                            ssql = "update ss_roomtc set flag=0 where id='" + ssfj + "'";
                            FrmMdiMain.Database.DoCommand(ssql);
                        }
                        //���Ӹ��°��ű�־ Modify By Tany 2015-04-20
                        ssql = "update ss_apprecord set apbj=1 where sno='" + sNo + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                        //���°��ű�
                        ssql = "update ss_arrrecord set " +
                            " wcbj = 1,wcsj = getdate()" +
                            " where sno='" + sNo + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                        //������־
                        ssql = "insert into ss_log(id,sno,inpatient_name,sbz,djrq,czy)values('" + TrasenClasses.GeneralClasses.PubStaticFun.NewGuid() + "','" + sNo + "','','�������',getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ")";
                        FrmMdiMain.Database.DoCommand(ssql);
                    }
                    else if (ssmzType == 1)
                    {
                        //���°��ű�
                        ssql = "update ss_arrrecord set " +
                            " mzwcbj = 1,mzwcsj = getdate()," +
                            " mzwcczy=" + FrmMdiMain.CurrentUser.EmployeeId +
                            " where sno='" + sNo + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                    }
                    FrmMdiMain.Database.CommitTransaction();
                    MessageBox.Show(ssmz + "��ɣ�");
                }
                catch (System.Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(err.Message + err.Source);
                }
            }
        }

        //Add By Tany 2015-04-20
        /// <summary>
        /// �Ƿ�GUID��
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsGuid(string str)
        {
            bool isGuid = false;
            try
            {
                Guid gstr = new Guid(str);
                return true;
            }
            catch
            {
                isGuid = false;
            }
            return isGuid;
        }

        /// <summary>
        /// ���ã�ҽ�����͡���ʿִ��
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="inpNo"></param>
        /// <returns></returns> 
        private bool DoVaildYbOrder(string inpatient_id, string inpNo)
        {
            //try
            //{
            //    decimal sum = 0M;

            //    //��ϸInfo
            //    DataTable dtDetail = GetDetailBill(dtOrder, out sum);

            //    //����info
            //    DataTable dtMain = ClsAuditCheck.RetAfSetMainInfo(inpatient_id, inpNo, sum, FrmMdiMain.Database);

            //    BmiAuditClass clsAudit = new BmiAuditClass();
            //    string strRet = clsAudit.ClaimAudit4Hospital_Y(dtMain, dtDetail);

            //    if (!strRet.Equals("1"))
            //    {
            //        //throw new Exception(clsAudit.l_error_message);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("�������ҽ����ϸ \r\t " + ex.Message);
            //    return false;
            //}
            return true;
        }

        //add by jchl
        private void DoCntSsMzFee(DataTable dtDetials, out decimal sdVal)
        {
            //������ϸ���
            sdVal = 0M;

            DataRow[] drGrps = dtDetials.Select("HOITEM_ID<>-1");
            if (drGrps.Length <= 0)
                return;

            for (int i = 0; i < drGrps.Length; i++)
            {
                DataRow drDet = drGrps[i];

                string xmly = drDet["xmly"].ToString().Trim();
                string xmid = drDet["HOITEM_ID"].ToString().Trim();

                DataTable dtItem = GetItemDetails(xmid, xmly);
                for (int j = 0; j < dtItem.Rows.Count; j++)
                {
                    DataRow row = dtItem.Rows[j];

                    if (row["XMLY"].ToString().Trim().Equals("1"))
                    {
                        //if (drDet["MNGTYPE"].ToString().Trim().Equals("1"))
                        //{
                        //    //������Ҫ�ϴ� �ܵ�λ������
                        //    DataTable dtPrc = HisFunctions.SP_FUN_DW_NUM(drDet["dwlx"].ToString(), decimal.Parse(drDet["����"].ToString()), row["xmid"].ToString(), drDet["ִ�п���"].ToString(), FrmMdiMain.Database);
                        //    sdVal = decimal.Parse(dtPrc.Rows[0]["sdvalue"].ToString().Trim());//���������ķ���
                        //}
                        //else
                        //{
                        //    //��������λ���ͺͼ���
                        //    DataTable dtPrc = HisFunctions.SP_FUN_DW_NUM(drDet["dwlx"].ToString(), decimal.Parse(drDet["����"].ToString()), row["xmid"].ToString(), drDet["ִ�п���"].ToString(), FrmMdiMain.Database);
                        //    sdVal = decimal.Parse(dtPrc.Rows[0]["sdvalue"].ToString().Trim());//���������ķ���
                        //}

                        //����ֻ����ʱҽ��������ʱ�˵�
                        //������Ҫ�ϴ� �ܵ�λ������
                        DataTable dtPrc = HisFunctions.SP_FUN_DW_NUM(drDet["dwlx"].ToString(), decimal.Parse(drDet["zsl"].ToString()), row["xmid"].ToString(), drDet["EXEC_DEPT"].ToString(), FrmMdiMain.Database);
                        sdVal += decimal.Parse(dtPrc.Rows[0]["sdvalue"].ToString().Trim());//���������ķ���
                    }
                    else
                    {
                        //��Ŀ���
                        string sql = string.Format(@"select * from JC_HSITEM where ITEM_ID='{0}' ", row["xmid"].ToString());
                        DataTable dtPrc = FrmMdiMain.Database.GetDataTable(sql);
                        decimal iNum = Convert.ToDecimal(drDet["num"].ToString());

                        sdVal += decimal.Parse(dtPrc.Rows[0]["RETAIL_PRICE"].ToString()) * iNum;//���������ķ���
                    }
                }
            }
        }

        private DataTable GetItemDetails(string xmid, string xmly)
        {
            string sql = string.Format(@"select xmid, xmly
                                        from
                                        (
                                        select 2 as xmly,SUBITEM_ID as xmid from JC_HOI_HDI t 
                                        inner join JC_TC a on t.TCID=a.ITEM_ID and TC_FLAG=1 and a.DELETE_BIT=0 
                                        inner join JC_TC_MX b on a.ITEM_ID=b.MAINITEM_ID 
                                        where t.HOITEM_ID='{0}' and '{1}'='2'
                                        union all
                                        select 2 as xmly,ITEM_ID as xmid from JC_HOI_HDI t 
                                        inner join JC_HSITEM a on t.HDITEM_ID=a.ITEM_ID and TC_FLAG=0 and a.DELETE_BIT=0
                                        where t.HOITEM_ID='{0}' and '{1}'='2' 
                                        )a
                                        union all
                                        select '{0}' as xmid,'1' as xmly where '{1}'='1'", xmid, xmly);

            DataTable itemDetails = InstanceForm.BDatabase.GetDataTable(sql);
            return itemDetails;
        }


        private void btִ��ʱ��_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    btִ��ʱ��.EnabledChanged -= btִ��ʱ��_EnabledChanged;
            //    btִ��ʱ��.Enabled = false;
            //    btִ��ʱ��.EnabledChanged += btִ��ʱ��_EnabledChanged;
            //}
        }

        private void btȡ��ͣҽ��ת��_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    btȡ��ͣҽ��ת��.EnabledChanged -= btȡ��ͣҽ��ת��_EnabledChanged;
            //    btȡ��ͣҽ��ת��.Enabled = false;
            //    btȡ��ͣҽ��ת��.EnabledChanged += btȡ��ͣҽ��ת��_EnabledChanged;
            //}
        }

        private void btȡ����ҽ��ת��_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    btȡ����ҽ��ת��.EnabledChanged -= btȡ����ҽ��ת��_EnabledChanged;
            //    btȡ����ҽ��ת��.Enabled = false;
            //    btȡ����ҽ��ת��.EnabledChanged += btȡ����ҽ��ת��_EnabledChanged;
            //}
        }

        private void btȡ��ͣҽ���˶�_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    btȡ��ͣҽ���˶�.EnabledChanged -= btȡ��ͣҽ���˶�_EnabledChanged;
            //    btȡ��ͣҽ���˶�.Enabled = false;
            //    btȡ��ͣҽ���˶�.EnabledChanged += btȡ��ͣҽ���˶�_EnabledChanged;
            //}
        }

        private void BtnTszlZcQm_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    BtnTszlZcQm.EnabledChanged -= BtnTszlZcQm_EnabledChanged;
            //    BtnTszlZcQm.Enabled = false;
            //    BtnTszlZcQm.EnabledChanged += BtnTszlZcQm_EnabledChanged;
            //}
        }

        private void btnDelete_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    btnDelete.EnabledChanged -= btnDelete_EnabledChanged;
            //    btnDelete.Enabled = false;
            //    btnDelete.EnabledChanged += btnDelete_EnabledChanged;
            //}
        }

        private void btδִ��_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    btδִ��.EnabledChanged -= btδִ��_EnabledChanged;
            //    btδִ��.Enabled = false;
            //    btδִ��.EnabledChanged += btδִ��_EnabledChanged;
            //}
        }

        private void chkGwyp_CheckedChanged(object sender, EventArgs e)
        {
            chkShowAllSMYz.Visible = chkSsyz.Visible = !chkGwyp.Checked;

            if (chkGwyp.Checked)
            {
                chkWardOrder.Checked = chkShowAllSMYz.Checked = chkSsyz.Checked = !chkGwyp.Checked;
            }

            if (ssmzType == 1)
            {
                chkWardOrder.Visible = false;
            }

            ShowData();
        }

        void menuSmCf_Print(object sender, EventArgs e)
        {

            try
            {
                if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
                {
                    MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //������˿ؼ���Ϣû�У��򼤻�һ��
                if (patientInfo1.lbID.Text.Trim() == "")
                {
                    this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
                }

                int iSel = GetMNGType();

                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count == 0) return;

                int nrow = 0;
                int SelCount = 0;

                try
                {
                    rds.Tables["dtSsMzCf"].Clear();
                    string _msg = "";

                    //Add By Tany 2010-09-26 ��ӡ�����ñ���
                    string sSql = "";
                    string[] sql = new string[myTb.Rows.Count];

                    FrmReportView frmRptView = null;
                    string _reportName = "";
                    ParameterEx[] _parameters = new ParameterEx[9];

                    string cfType = (sender as MenuItem).Name;
                    int iCfType = 0;
                    if (cfType.Equals("mjycf"))
                    {
                        _reportName = "MZ_�龫һ�����嵥(������ʽ).rpt";
                        iCfType = 1;
                    }
                    else if (cfType.Equals("jecf"))
                    {
                        _reportName = "MZ_���������嵥(������ʽ).rpt";
                        iCfType = 2;
                    }
                    else if (cfType.Equals("xzcf"))
                    {
                        _reportName = "MZ_������ͨ����.rpt";
                        iCfType = 3;
                    }

                    if (iCfType == 1 || iCfType == 2)
                    {
                        for (int i = 0; i < myTb.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(myTb.Rows[i]["ѡ"].ToString()) && myTb.Rows[i]["xmly"].ToString().Trim().Equals("1"))
                            {
                                string cjid = myTb.Rows[i]["item_code"].ToString().Trim();
                                string ypgg = "";

                                if (!IsPrtSsMzPresc(iCfType, cjid, out ypgg))
                                    continue;

                                rds.Tables["dtSsMzCf"].Clear();

                                dr = rds.Tables["dtSsMzCf"].NewRow();

                                string order = myTb.Rows[i]["Order_ID"].ToString();
                                string strSql = string.Format(@"select ORDER_BDATE,ORDER_DOC,ORDER_USAGE,FREQUENCY,ORDER_CONTEXT,zsl NUM,zsldw UNIT from ZY_ORDERRECORD where ORDER_ID='{0}'", order);

                                DataTable dtOrd = InstanceForm.BDatabase.GetDataTable(strSql);

                                if (dtOrd == null || dtOrd.Rows.Count <= 0)
                                    continue;


                                dr["��ʼ����"] = dtOrd.Rows[0]["ORDER_BDATE"].ToString();
                                dr["ҽ������"] = dtOrd.Rows[0]["ORDER_CONTEXT"].ToString();
                                dr["¼����"] = dtOrd.Rows[0]["ORDER_DOC"].ToString();//iSel == 1 ? dtOrd.Rows[i]["����ҽ��"].ToString() : myTb.Rows[i]["����ת��"].ToString();
                                dr["�÷�"] = dtOrd.Rows[0]["Order_Usage"].ToString();
                                dr["Ƶ��"] = dtOrd.Rows[0]["FREQUENCY"].ToString();
                                dr["����"] = dtOrd.Rows[0]["NUM"].ToString();
                                dr["��λ"] = dtOrd.Rows[0]["UNIT"].ToString();
                                dr["���"] = ypgg;
                                dr["ҽ��ǩ��"] = GetImageByte((Convertor.IsNull(dtOrd.Rows[0]["ORDER_DOC"], "0")));

                                rds.Tables["dtSsMzCf"].Rows.Add(dr);

                                if (rds.Tables["dtSsMzCf"].Rows.Count == 0)
                                {
                                    return;
                                }

                                _parameters[0].Text = "hzsfzh";
                                _parameters[0].Value = "";
                                _parameters[1].Text = "xm";
                                _parameters[1].Value = patientInfo1.lbName.Text;
                                _parameters[2].Text = "xb";
                                _parameters[2].Value = patientInfo1.lbSex.Text;

                                _parameters[3].Text = "bq";
                                _parameters[3].Value = "";//FrmMdiMain.CurrentDept.WardName;
                                _parameters[4].Text = "ks";
                                _parameters[4].Value = patientInfo1.lbDQKS.Text;
                                _parameters[5].Text = "zyh";
                                _parameters[5].Value = patientInfo1.lbID.Text;

                                _parameters[6].Text = "ch";
                                _parameters[6].Value = patientInfo1.lbBed.Text;
                                _parameters[7].Text = "zd";
                                _parameters[7].Value = patientInfo1.lbRYZD.Text;
                                _parameters[8].Text = "nl";
                                _parameters[8].Value = patientInfo1.lbAge.Text;

                                frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                                frmRptView.Show();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < myTb.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(myTb.Rows[i]["ѡ"].ToString()))
                            {
                                dr = rds.Tables["dtSsMzCf"].NewRow();

                                string order = myTb.Rows[i]["Order_ID"].ToString();
                                string strSql = string.Format(@"select ORDER_BDATE,ORDER_DOC,ORDER_USAGE,FREQUENCY,ORDER_CONTEXT,zsl NUM,zsldw UNIT from ZY_ORDERRECORD where ORDER_ID='{0}'", order);

                                DataTable dtOrd = InstanceForm.BDatabase.GetDataTable(strSql);

                                if (dtOrd == null || dtOrd.Rows.Count <= 0)
                                    continue;

                                //dr["��ʼ����"] = myTb.Rows[i]["������"].ToString();
                                //dr["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString();
                                //dr["¼����"] = iSel == 1 ? myTb.Rows[i]["����ҽ��"].ToString() : myTb.Rows[i]["����ת��"].ToString();


                                dr["��ʼ����"] = dtOrd.Rows[0]["ORDER_BDATE"].ToString();
                                dr["ҽ������"] = dtOrd.Rows[0]["ORDER_CONTEXT"].ToString();
                                dr["¼����"] = dtOrd.Rows[0]["ORDER_DOC"].ToString();//iSel == 1 ? dtOrd.Rows[i]["����ҽ��"].ToString() : myTb.Rows[i]["����ת��"].ToString();
                                dr["�÷�"] = dtOrd.Rows[0]["Order_Usage"].ToString();
                                dr["Ƶ��"] = dtOrd.Rows[0]["FREQUENCY"].ToString();
                                dr["����"] = dtOrd.Rows[0]["NUM"].ToString();
                                dr["��λ"] = dtOrd.Rows[0]["UNIT"].ToString();
                                dr["ҽ��ǩ��"] = GetImageByte((Convertor.IsNull(dtOrd.Rows[0]["ORDER_DOC"], "0")));

                                rds.Tables["dtSsMzCf"].Rows.Add(dr);
                            }
                        }

                        if (rds.Tables["dtSsMzCf"].Rows.Count == 0)
                        {
                            return;
                        }

                        _parameters[0].Text = "hzsfzh";
                        _parameters[0].Value = "";
                        _parameters[1].Text = "xm";
                        _parameters[1].Value = patientInfo1.lbName.Text;
                        _parameters[2].Text = "xb";
                        _parameters[2].Value = patientInfo1.lbSex.Text;

                        _parameters[3].Text = "bq";
                        _parameters[3].Value = "";//FrmMdiMain.CurrentDept.WardName;
                        _parameters[4].Text = "ks";
                        _parameters[4].Value = patientInfo1.lbDQKS.Text;
                        _parameters[5].Text = "zyh";
                        _parameters[5].Value = patientInfo1.lbID.Text;

                        _parameters[6].Text = "ch";
                        _parameters[6].Value = patientInfo1.lbBed.Text;
                        _parameters[7].Text = "zd";
                        _parameters[7].Value = patientInfo1.lbRYZD.Text;
                        _parameters[8].Text = "nl";
                        _parameters[8].Value = patientInfo1.lbAge.Text;

                        frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                        frmRptView.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch { }
        }

        /// <summary>
        /// ��ҩƷ�Ƿ��ӡ
        /// </summary>
        /// <param name="iType">1���顢��һ  2������ </param>
        /// <param name="cjid"></param>
        /// <returns></returns>
        private bool IsPrtSsMzPresc(int iType, string cjid, out string ypgg)
        {
            ypgg = "";
            try
            {
                string strSql = string.Format(@"select cast(MZYP as int) MZYP,cast(jsyp as int) jsyp,jsypfl,s_ypgg from VI_YP_YPCD where cjid='{0}'", cjid);

                DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);

                if (dt == null || dt.Rows.Count <= 0)
                    return false;

                int iMz = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["MZYP"], "-1"));
                int iJs = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["jsyp"], "-1"));
                int iJsdj = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["jsypfl"], "-1"));
                ypgg = Convertor.IsNull(dt.Rows[0]["s_ypgg"], "");

                if (iType == 1)
                {
                    if (iMz > 0)
                    {
                        //����
                        return true;
                    }
                    if (iJs > 0 && iJsdj == 1)
                    {
                        //��һ
                        return true;
                    }
                }
                else if (iType == 2)
                {
                    if (iJs > 0 && iJsdj == 2)
                    {
                        //����
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ss);
            if (tb == null || tb.Rows.Count == 0 || tb.Rows[0]["sign"].GetType().ToString() == "System.DBNull")
                return null;
            else
                return ((byte[])tb.Rows[0]["sign"]);
        }
    }
}