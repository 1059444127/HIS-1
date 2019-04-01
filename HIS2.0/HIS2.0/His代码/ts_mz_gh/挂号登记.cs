using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using ts_yb_interface;
using TrasenFrame.Forms;
using System.Text;
using TrasenClasses.DatabaseAccess;
using Ts_Visit_Class;
using ts_mzys_class;
using System.Net;

namespace ts_mz_gh
{
    public partial class Frmghdj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbks;//�Һſ�������
        private DataTable Tbys;//�Һ�ҽ������
        private int Fplx;//��Ʊ���� 0 �Һ�Ʊ 1 �շ�Ʊ
        private DataTable tbk;//���˿���Ϣ
        //���ڿ��ƴ��ڿؼ������Ա���
        private string ghlb_ini = "";
        private string klx_ini = "";
        private string kh_ini = "";
        private string xm_ini = "";
        private string xb_ini = "";
        private string nl_ini = "";
        private string lxfs_ini = "";
        private string jtdz_ini = "";
        private string brlx_ini = "";
        private string ghks_ini = "";
        private string ghjb_ini = "";
        private string ghys_ini = "";
        private string yblx_ini = "";
        private string readcard_ini = "";
        private string blb_ini = "";
        private string sfplx_ini = "";
        private string Bview = "";//��ƱԤ��
        /// <summary>
        /// ϵͳ���� - �Һ�ʱ�����¿�
        /// </summary>
        private string New_Card = ""; //�Һ�ʱ�����¿�
        /// <summary>
        /// ϵͳ���� - ˢ��ʱ������Ĳ�����Ϣ
        /// </summary>
        private string Modif_ini = "";//ˢ��ʱ������Ĳ�����Ϣ
        /// <summary>
        /// ϵͳ���� - �Һ�ʱ����ʹ�ÿ�
        /// </summary>
        private string syk_ini = "";//�Һ�ʱ����ʹ�ÿ�
        private long Jgbm = 0;//��������
        /// <summary>
        /// ҽ��������Ϣ����
        /// </summary>
        private ts_yb_mzgl.BRXX brxx = new ts_yb_mzgl.BRXX();
        private ts_yb_mzgl.CFMX[] cfmx;
        private ts_yb_mzgl.JSXX jsxx;

        private DataTable Ybcard;//ҽ������Ϣ
        private DataTable Ybbrxx;//ҽ��������Ϣ
        private IntPtr Pint;

        private string yb_dylx = "";
        private string yb_dylxmc = "";
        private string yb_bzxx = "";
        private SystemCfg cfgsfy = new SystemCfg(3016);
        /// <summary>
        /// ϵͳ����Ĳ���������,add by wangzhi 2010-10-26
        /// </summary>
        private SystemCfg cfgBlb = new SystemCfg(1018);
        /// <summary>
        /// ���β����Ƿ񴴽���һ���¿�
        /// </summary>
        //Add By Tany 2010-09-18 ���������շ��Ƿ��տ���
        private bool _isCreateNewCard = false;
        private SystemCfg cfgnl = new SystemCfg(1050);
        private SystemCfg cfgpb = new SystemCfg(1051);
        private SystemCfg cfgpbys = new SystemCfg(1052);
        private SystemCfg cfg1046 = new SystemCfg(1046);
        //����Һ�����ҽ��ʱֻ������Ӧ���ҵ�ҽ��
        private SystemCfg cfg1058 = new SystemCfg(1058);
        private SystemCfg cfg1060 = new SystemCfg(1060);//Add By Zj 2012-05-10 �Ƿ���֤����Ӣ����ĸ
        private SystemCfg cfg3035 = new SystemCfg(3035);//Add By Zj 2012-06-07 ��ӡ��Ʊʹ��������ƻ��ǿ�������
        private SystemCfg cfg1065 = new SystemCfg(1065);//���ﱾ���շ��������ؼ������ʱ�� Add By Zj 2012-10-08
        private SystemCfg cfg1078 = new SystemCfg(1078);//*add by zch 2013-03-26 ����СƱ��ӡ�Ƿ����һ���ϣ�ֻ��ֽһ�Σ�0=�� ��1=�� */
        private SystemCfg cfg1079 = new SystemCfg(1079);//*add by zch 2013-03-28 ����СƱ��ӡ�Ƿ����һ���ϣ�ֻ��ֽһ�Σ�0=�� ��1=�� */
        private SystemCfg cfg_1093 = new SystemCfg(1093);//Add By zp 2013-09-22 �Һ��Ƿ�ֻ����ˢ������ 0�� 1�� Ĭ��0
        /// <summary>
        /// �Ƿ������·���к�ϵͳ add by zp 2013-07-11
        /// </summary>
        private SystemCfg cfg3070 = new SystemCfg(3070);
        /// <summary>
        /// ����Һſ��Ҷ�Ӧ������ ��ʽ:����id|���� ͨ������","���ֿ���
        /// </summary>
        private SystemCfg cfg1088 = new SystemCfg(1088);
        public SystemCfg cfg1099 = new SystemCfg(1099); //Add by zp 2013-11-08 �Ƿ����÷�ʱ�ιҺ�0������1���� Ĭ��0
        private SystemCfg cfg1114 = new SystemCfg(1114);//add by jiangzf 2014-4-22 ��ͬ��λ�����Ƿ��ӡ��Ʊ 1����ӡ 0��ӡ Ĭ��0
        /// <summary>
        /// 0:��/��/��,1:��/��,2:��/��,3:��/��
        /// </summary>
        private SystemCfg cfg1155 = new SystemCfg(1155);
        /// <summary>
        /// �Ƿ�������ϵͳ�Զ����������뿨��0:�� 1:��)
        /// </summary>
        private SystemCfg cfg1161 = new SystemCfg(1161);
        /// <summary>
        /// �����Ƿ񲻴�ӡ��Ʊ 0-�� 1-��
        /// </summary>
        private SystemCfg cfg1163 = new SystemCfg(1163);
        /// <summary>
        /// �°쿨ʱ���ص�δ����Ĳ�����Ϣ������Ϣ add by wangzhi 2010-10-27
        /// </summary>
        private MZ_BRXX_KXX _new_brxx_kxx;
        private DataTable dt_AgeToDocLevel = null;//�洢�����Զ�ѡ��Һż���ļ�¼ �������䡢�Һż��� Ϊ�չҺ�����֤ Add By zp 2013-09-03 
        private DataTable dt_ghksxz = null; //�Һſ��������ڴ�� �Һ��������ܰ����Ŀ��� add by zp 2013-12-14
        private bool Isyy = false; //�Ƿ���ԤԼ Add By zp 2014-03-26 
        /// <summary>
        /// ���ڱ�ʾ�Ƿ���ȡ���ѣ�һ���������½�������ֵ�������ʹ��
        /// </summary>
        private bool _needChargeCardFee = false;
        public YY_BRXX_BC_MOL yy_brxx_bc = new YY_BRXX_BC_MOL();//add by cc

        public Frmghdj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            ControlEnable();

            //add by zouchihua 2013-4-17 ��ʼ���ر����ӡ
            this.backgroundWorker1.RunWorkerAsync();


        }

        private void Frmghdj_Load(object sender, EventArgs e)
        {
            try
            {
                panel_yanzheng.Height = 0;
                //��Ӻ�ͬ��λ����
                FunAddComboBox.AddHtdwLx(false, cmbdwlx, InstanceForm.BDatabase);
                cmbdwlx.SelectedIndex = -1;
                //��Ӳ�������
                FunAddComboBox.AddBrlx(false, 0, cmbbrlx, InstanceForm.BDatabase);
                //��ӹҺ�����
                FunAddComboBox.AddGhlx(false, 0, cmbghlx, InstanceForm.BDatabase);
                //��ӿ�����
                FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
                //��ӹҺż���
                FunAddComboBox.AddGhjb(false, 0, cmbghjb, InstanceForm.BDatabase);
                //���ҽ������
                FunAddComboBox.AddYblx(false, 0, cmbyblx, InstanceForm.BDatabase);
                //����Ա�
                FunAddComboBox.Addxb(false, cmbxb, InstanceForm.BDatabase);
                //���䵥λ
                #region ����
                DataTable tbnl = new DataTable();
                tbnl.Columns.Add("ID", Type.GetType("System.Int32"));
                tbnl.Columns.Add("NAME", Type.GetType("System.String"));
                DataRow row = tbnl.NewRow();
                row["ID"] = 0;
                row["NAME"] = "��";
                tbnl.Rows.Add(row);
                row = tbnl.NewRow();
                row["ID"] = 1;
                row["NAME"] = "��";
                tbnl.Rows.Add(row);
                row = tbnl.NewRow();
                row["ID"] = 2;
                row["NAME"] = "��";
                tbnl.Rows.Add(row);
                row = tbnl.NewRow();
                row["ID"] = 3;
                row["NAME"] = "Сʱ";
                tbnl.Rows.Add(row);
                cmbDW.DisplayMember = "NAME";
                cmbDW.ValueMember = "ID";
                cmbDW.DataSource = tbnl;
                cmbDW.SelectedIndex = 0;
                #endregion
                //����Żݷ���
                AddYhlx();
                this.dt_AgeToDocLevel = ts_mz_class.Fun.FillDocLevelByPatAge();
                IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
                string ip = addressList[0].ToString().Trim();
                this.dt_ghksxz = Fun.GetGhKsXz(ip, InstanceForm.BDatabase); //�õ��Һſ������������εĿ�����Ϣ
            }
            catch (System.Exception err)
            {
                //Add by Zj 2012-2-11 ��Ӵ�����ʾ
                MessageBox.Show("��ʼ������!�������:1,ԭ��:" + err.Message);
            }
            this.WindowState = FormWindowState.Maximized;
            Jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            //ADD BY CC Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            SystemCfg cfg1116 = new SystemCfg(1116);
            if (cfg1116.Config.ToString() == "0")
            {
                Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            }
            else
            {
                Tbks = GetGhks_lyfy(false, InstanceForm.BDatabase, cfg1116.Config.Trim());
            }
            RefGhKsInfo(); //Add by zp 2013-12-14
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
            //ReadGhxx();
            //������ ��ӭ
            #region ����������
            try
            {
                string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true")
                {
                    string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    call.SetPicture(InstanceForm.BCurrentUser.EmployeeId.ToString());  //(txtxm.Text.Trim());
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("�����������쳣!ԭ��:" + ea.Message, "��ʾ");
            }
            #endregion
            //���ڿ��� ���û�н���  ����ȫ���ؼ�
            try
            {
                mz_sf.CKJZKZ(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
            }
            catch (System.Exception err)
            {
                for (int i = 0; i <= panel1.Controls.Count - 1; i++)
                    panel1.Controls[i].Enabled = false;
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //����Ű��������
            if (cfgpb.Config == "0")
                tabControl1.TabPages.Remove(tabPage2);
            else
                AddDeptTree();
            //��ʼ���²���
            butnew_Click(sender, e);

            //Add By Zj 2012-10-15 �����շ���������
            if (cfg1065.Config != "0")
            {
                string applicationName = "";
                string link = "";
                string LinkDBName = "";
                //RelationalDatabase Database = null;
                ParameterEx[] parameters = new ParameterEx[1];
                try
                {
                    applicationName = ApiFunction.GetIniString("SERVER_NAME", "NAME", Constant.ApplicationDirectory + "\\LocalClientConfig.ini");
                    link = TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "Link", Constant.ApplicationDirectory + "\\LocalClientConfig.ini"));//Add By Zj 2012-10-07
                    LinkDBName = TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "LinkDBName", Constant.ApplicationDirectory + "\\LocalClientConfig.ini"));//Add By Zj 2012-10-07
                    parameters[0].Text = "@servername";
                    parameters[0].Value = "[" + link + "].[" + LinkDBName + "]";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("���ӱ�������ʧ��!��򿪱������ݿ���߳�����ϵ����Ա!" + Ex.Message, "��ʾ");
                }
                if (link != "")
                {
                    MessageBox.Show("����ϸ�˶����ĵ��Է�Ʊ���Ƿ��ʵ�ʷ�Ʊ��һ��!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (new SystemCfg(1137).Config == "1")
                panel10.Visible = true;

            #region//�Զ�����Ƶ��,ȫ����ʼ�����������������豸
            string sbxh = ApiFunction.GetIniString("ҽԺ������", "�豸�ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (sbxh != "")
            {
                ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);

                if (ReadCard != null)
                    ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
            }
            #endregion

        }




        public static DataTable GetGhks_lyfy(bool jzks, RelationalDatabase _DataBase, string strNoteTemp)
        {
            string strNote = strNoteTemp;
            string strDept = InstanceForm.BCurrentDept.DeptId.ToString();
            string[] strDeptList = strNote.Split('|');
            int iCount = 0;
            for (int i = 0; i < strDeptList.Length; i++)
            {
                if (strDeptList[i].ToString().IndexOf(InstanceForm.BCurrentDept.DeptId.ToString()) >= 0)
                {
                    iCount = i;
                    break;
                }
            }
            string strDeptAll = strDeptList[iCount].ToString().Split('-')[1];

            //ԭ����

            string ssql = "";
            SystemCfg cfg = new SystemCfg(1057, _DataBase);
            if (jzks == false)
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where layer=3 and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in(" + cfg.Config + "))";
            else
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where layer=3 and  jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in('003'))";
            return _DataBase.GetDataTable(ssql + " and dept_id  in" + strDeptAll);
        }
        //ˢѡ����ǰ�������ԹҺŵĿ��Ҽ�¼ Add by zp 2013-12-14
        private void RefGhKsInfo()
        {
            try
            {
                if (dt_ghksxz == null || dt_ghksxz.Rows.Count == 0) return;
                for (int i = 0; i < dt_ghksxz.Rows.Count; i++)
                {
                    DataRow[] drs = Tbks.Select("DEPT_ID=" + dt_ghksxz.Rows[i]["GHKSID"] + "");
                    if (drs.Length == 0) continue;
                    DataRow dr = drs[0];
                    Tbks.Rows.Remove(dr);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("RefGhKsInfo�����쳣!ԭ��:" + ea.Message, "��ʾ");
            }
        }

        private void ControlEnable()
        {
            #region ����������Ŀ���
            ghlb_ini = ApiFunction.GetIniString("�Һ�������", "���", Constant.ApplicationDirectory + "//ClientWindow.ini");
            klx_ini = ApiFunction.GetIniString("�Һ�������", "������", Constant.ApplicationDirectory + "//ClientWindow.ini");
            kh_ini = ApiFunction.GetIniString("�Һ�������", "����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            xm_ini = ApiFunction.GetIniString("�Һ�������", "����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            xb_ini = ApiFunction.GetIniString("�Һ�������", "�Ա�", Constant.ApplicationDirectory + "//ClientWindow.ini");
            nl_ini = ApiFunction.GetIniString("�Һ�������", "����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            lxfs_ini = ApiFunction.GetIniString("�Һ�������", "��ϵ��ʽ", Constant.ApplicationDirectory + "//ClientWindow.ini");
            jtdz_ini = ApiFunction.GetIniString("�Һ�������", "��ͥ��ַ", Constant.ApplicationDirectory + "//ClientWindow.ini");
            brlx_ini = ApiFunction.GetIniString("�Һ�������", "��������", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ghks_ini = ApiFunction.GetIniString("�Һ�������", "�Һſ���", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ghjb_ini = ApiFunction.GetIniString("�Һ�������", "�Һż���", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ghys_ini = ApiFunction.GetIniString("�Һ�������", "�Һ�ҽ��", Constant.ApplicationDirectory + "//ClientWindow.ini");
            yblx_ini = ApiFunction.GetIniString("�Һ�������", "ҽ������", Constant.ApplicationDirectory + "//ClientWindow.ini");
            readcard_ini = ApiFunction.GetIniString("�Һ�������", "����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            blb_ini = ApiFunction.GetIniString("�Һ�������", "������", Constant.ApplicationDirectory + "//ClientWindow.ini");

            sfplx_ini = new SystemCfg(1005).Config == "0" ? "true" : "false";//
            syk_ini = new SystemCfg(1009).Config == "1" ? "true" : "false";
            Bview = ApiFunction.GetIniString("�����շ�", "�Һŷ�ƱԤ��", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (Bview == null || Bview == "")
                Bview = ApiFunction.GetIniString("�����շ�", "��ƱԤ��", Constant.ApplicationDirectory + "//ClientWindow.ini");

            New_Card = new SystemCfg(1010).Config == "1" ? "true" : "false";
            Modif_ini = new SystemCfg(1011).Config == "1" ? "true" : "false";


            Fplx = sfplx_ini == "true" ? 1 : 0;
            cmbghlx.Enabled = ghlb_ini == "true" ? false : true;
            cmbklx.Enabled = klx_ini == "true" ? false : true;
            txtkh.Enabled = kh_ini == "true" ? false : true;
            txtxm.Enabled = xm_ini == "true" ? false : true;
            cmbxb.Enabled = xb_ini == "true" ? false : true;
            txtnl.Enabled = nl_ini == "true" ? false : true;
            cmbDW.Enabled = nl_ini == "true" ? false : true;
            txtgrlxfs.Enabled = lxfs_ini == "true" ? false : true;
            txtjtdz.Enabled = jtdz_ini == "true" ? false : true;
            cmbbrlx.Enabled = brlx_ini == "true" ? false : true;
            txtks.Enabled = ghks_ini == "true" ? false : true;
            cmbghjb.Enabled = ghjb_ini == "true" ? false : true;
            txtys.Enabled = ghys_ini == "true" ? false : true;
            cmbyblx.Enabled = yblx_ini == "true" ? false : true;
            butreadcard.Enabled = readcard_ini == "true" ? false : true;
            chkblb.Enabled = blb_ini == "true" ? false : true;
            #endregion
        }
        /// <summary>
        /// �ºŰ�ť����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnew_Click(object sender, EventArgs e)
        {
            string sbxh = ApiFunction.GetIniString("ҽԺ������", "�豸�ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");

            //Add By tany2010-09-18
            _isCreateNewCard = false;

            this.Tag = Guid.Empty.ToString(); //�洢�˲�����Ϣ�ɣ�
            lbljyh.Text = "";
            cmbyblx.SelectedIndex = -1;
            lblfph.Text = "";
            //Add By Zj ��Ϊ�豸������ԭ������տ��� ����ȥ���˿ؼ��е�Ĭ��ֵ
            //if (sbxh == "") 
            txtkh.Text = ""; //Modify By zp 2013-09-23 �����Ƿ����ö����豸 ����տ���
            txtxm.Text = "";
            txtnl.Text = "";
            cmbDW.SelectedIndex = 0;
            txtgrlxfs.Text = "";
            txtjtdz.Text = "";
            lblkye.Text = "";
            lblmzh.Text = "";
            txtks.Text = "";
            txtks.Tag = "0";
            txtys.Text = "";
            txtys.Tag = "0";
            tbk = null;
            Ybbrxx = null;
            Ybcard = null;
            lblgzdw.Text = "";
            lblybrylx.Text = "";
            lblYbye.Text = "";
            lbljyh.Text = "";
            lblybxm.Text = "";

            lblghzs.Text = "0";
            //lblghzs.Visible = false;
            //label11.Visible = false;

            cmbdwlx.SelectedIndex = -1;
            txthtdw.Text = "";
            txthtdw.Tag = "0";
            lblxh.Text = "";

            label22.Text = "";

            yb_bzxx = "";
            yb_dylx = "";
            yb_dylxmc = "";

            jsxx.GRZF = 0;
            jsxx.ZHZF = 0;
            jsxx.TCZF = 0;
            jsxx.JSDH = "";
            jsxx.HisJsdid = 0;
            jsxx.HisJsid_Old = 0;
            jsxx.YBZF = 0;
            jsxx.ZJE = 0;

            brxx.BRXXID = Guid.Empty;
            brxx.GHXXID = Guid.Empty;
            brxx.GRBH = "";
            brxx.GSYWSQH = "";
            brxx.GZDW = "";
            brxx.ICD = "";
            brxx.ICDMC = "";
            brxx.JSSJH = "";
            brxx.KH = "";
            brxx.KLX = 0;
            brxx.KYE = "";
            brxx.LXDH = "";
            brxx.RYLB = "";
            brxx.RYLBMC = "";
            brxx.SFZH = "";
            brxx.XB = "";
            brxx.YLBZKKH = "";
            brxx.YLZH = "";
            brxx.YWLX = "";
            brxx.YWLXMC = "";
            brxx.YWSQH = "";
            brxx.YWZLX = "";
            brxx.YWZLXMC = "";

            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);


            lblmzh.Text = Fun.GetNewMzh(InstanceForm.BDatabase);

            butnew.Enabled = false;

            //��ÿ��÷�Ʊ��
            if (cfg1046.Config == "1")
            {
                int err_code; string err_text;
                DataTable tb = Fun.GetFph(InstanceForm.BCurrentUser.EmployeeId, 1, Fplx, out err_code, out err_text, InstanceForm.BDatabase);
                if (tb.Rows.Count == 0 || err_code != 0)
                {
                    MessageBox.Show(err_text, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblfph.Text = Convertor.IsNull(tb.Rows[0]["QZ"], "") + tb.Rows[0]["fph"].ToString().Trim();
            }

            if (cmbbrlx.Items.Count > 0) cmbbrlx.SelectedIndex = 0;

            if (cmbbrlx.Items.Count > 0) cmbbrlx.SelectedIndex = 0;
            //����Żݷ���
            AddYhlx();

            //������ ����
            //string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //if (bqybjq == "true")
            //{
            //    string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
            //    call.Call(ts_call.DmType.���, "");
            //}

            //if (cmbghlx.Enabled == true) { cmbghlx.Focus(); return; }
            //if (cmbbrlx.Enabled == true) { cmbbrlx.Focus(); return; }
            //if (cmbklx.Enabled == true) { cmbklx.Focus(); return; }

            _new_brxx_kxx = null;  // add by wangzhi 2010-10-27 
            // �ºŻ������ʱ���²�����Ϣ�Ϳ��Ǽ���Ϣ��Null
            rdonl.Checked = true;
            if (txtkh.Enabled == true) { txtkh.Focus(); return; }
            if (txtxm.Enabled == true) { txtxm.Focus(); return; }
            if (txtks.Enabled == true) { txtks.Focus(); return; }
            if (txtys.Enabled == true) { txtys.Focus(); return; }
            if (Isyy)
            {
                Isyy = false;
                butqh.Tag = "";
                butqh.BackColor = Color.WhiteSmoke;
                txtks.Enabled = true;
                cmbghjb.Enabled = true;
                txtys.Enabled = true;
                treeView1.Enabled = true;
            }
        }


        /// <summary>
        /// �س�������һ���ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                if (control.Name == "txtnl" && cfgnl.Config == "1" && control.Text.Trim() == "")
                {
                    return;
                }
                if (control.Name == "cmbDW")
                {
                    if (txtgrlxfs.Enabled == true) { txtgrlxfs.Focus(); return; }
                    if (txtjtdz.Enabled == true) { txtjtdz.Focus(); return; }
                    if (txtks.Enabled == true)
                    {
                        if (cfgpb.Config == "1" && cfgpbys.Config == "1" && txtys.Enabled == true)
                            txtys.Focus();
                        else
                            txtks.Focus();
                        return;
                    }
                }
                if (control.Name == "txtjtdz")
                {
                    if (txtks.Enabled == true) txtks.Focus(); return;
                }
                if (control.Name == "txtxm" && control.Text.Trim() == "")
                    return;

                SendKeys.Send("{TAB}");
                return;


            }
        }

        /// <summary>
        /// ���뷨����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLanguage_Click(object sender, EventArgs e)
        {
            FrmSelectLanguage f = new FrmSelectLanguage();
            if (f.ShowDialog() == DialogResult.OK)
            {
                ApiFunction.WriteIniString("INPUTLANGUAGE", "N" + InstanceForm.BCurrentUser.LoginCode, f.SelectedInputLanguageName, Constant.ApplicationDirectory + "//CustomInputLanguage.ini");

            }
        }

        private void Language_Off(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.Close;
            Fun.SetInputLanguageOff();
        }

        private void Language_On(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.On;
            Fun.SetInputLanguageOn();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            SystemCfg cfg1121 = new SystemCfg(1121);
            if (cfg1121.Config == "1")
            {
                int out_code = 0;
                string out_text = "";
                Fun.Isjz(InstanceForm.BCurrentUser.EmployeeId, out out_code, out out_text, InstanceForm.BDatabase);
                if (out_code == -1)
                {
                    MessageBox.Show(out_text);
                    return;
                }
            }
            if (cmbdwlx.SelectedIndex != -1 && (txthtdw.Text.Trim().Length == 0 || txthtdw.Tag == null))
            {
                MessageBox.Show("ָ���˵�λ���ͣ���û��ѡ���ͬ��λ,��ѡ���ͬ��λ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                #region ������ֵ
                string Msg = "";
                //long kdjid = 0;
                Guid brxxid = new Guid(Convertor.IsNull(this.Tag, Guid.Empty.ToString()));
                int ghlx = Convert.ToInt32(Convertor.IsNull(cmbghlx.SelectedValue, "0"));
                string _ghlx = Convertor.IsNull(cmbghlx.Text, "");
                int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                int _pdxh = 0;//�Ŷ����
                string kh = txtkh.Text.Trim();
                string xm = txtxm.Text.Trim();

                decimal zje = 0;
                decimal yhje = 0;
                decimal srje = 0;
                decimal zfje = 0;
                decimal ybzf = 0;
                int fpzs = 0;//��Ʊ���� Add By Zj 2012-12-13
                //Add By Tany 2010-06-30
                decimal ybzhzf = 0;//ҽ���ʻ�֧��
                decimal ybjjzf = 0;//ҽ������֧��
                decimal ybbzzf = 0;//ҽ������֧��

                decimal ybkye = Convert.ToDecimal(Convertor.IsNull(lblYbye.Text, "0"));

                if (Convertor.IsNumeric(txtnl.Text) == false && txtnl.Text.Trim() != "")
                {
                    MessageBox.Show("��������������");
                    return;
                }

                Guid NewFpid = Guid.Empty;

                string csrq = "1900-01-01 00:00:00";
                if (rdocsrq.Checked == true) csrq = dtpcsrq.Value.ToShortDateString();
                if (rdonl.Checked == true && txtnl.Text.Trim() != "") csrq = dtpcsrq.Value.ToShortDateString();
                if (cfgnl.Config == "1" && txtnl.Text.Trim() == "" && rdonl.Checked == true)
                {
                    MessageBox.Show("�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtnl.Focus();
                    return;
                }

                #region �²�����Ϣ�ṹ��
                if (brxxid == Guid.Empty)
                {
                    if (_new_brxx_kxx == null)
                        _new_brxx_kxx = new MZ_BRXX_KXX();
                    _new_brxx_kxx.Brxx.Brxm = txtxm.Text.Trim();
                    _new_brxx_kxx.Brxx.Xb = Convertor.IsNull(cmbxb.SelectedValue, "1");
                    _new_brxx_kxx.Brxx.Csrq = csrq;
                    _new_brxx_kxx.Brxx.Brlxfs = txtgrlxfs.Text.Trim();
                    _new_brxx_kxx.Brxx.Jtdz = txtjtdz.Text.Trim();
                    _new_brxx_kxx.Brxx.Brlx = Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0"));
                    if (Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")) > 0)
                        _new_brxx_kxx.Brxx.Yblx = Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));
                    if (Convertor.IsNull(cmbyblx.Tag, "") != "")
                        _new_brxx_kxx.Brxx.Cbkh = Convertor.IsNull(cmbyblx.Tag, "");
                }
                #endregion

                int brlx = Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0"));
                string mzh = lblmzh.Text.Trim();
                string fph = "0";
                decimal ye = Convert.ToDecimal(Convertor.IsNull(lblkye.Text, "0"));
                int ghks = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                int ghjb = Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                int ghys = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                int yblx = Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));
                string jydjh = lbljyh.Text.Trim();
                string cbkh = Convertor.IsNull(cmbyblx.Tag, "");

                string _message = "";

                #region add by wangzhi 2014-11-04 ���ӳֿ��˺͵�ǰ�����Ƿ�һ�µ��жϣ���ֹ�ȼ�������Ϣ�����޸Ŀ��ź󲻻س�ֱ�ӵ�ҺŶ�������������
                if (!mz_ghxx.ValidingPatInfoAndCardInfo(klx, kh, brxxid, InstanceForm.BDatabase, out  _message))
                {
                    MessageBox.Show(_message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                #endregion

                #region add by wangzhi 2014-09-10 �����Ա����� ������Һ���Щ���� �������жϣ�����������,ԭ�����и�����1088��������

                DateTime? _boryDay = null;
                if (!string.IsNullOrEmpty(csrq))
                    _boryDay = Convert.ToDateTime(csrq);
                int? xb = null;
                xb = Convert.ToInt32(Convertor.IsNull(cmbxb.SelectedValue, "1"));
                if (!mz_ghxx.ValidingRestrictiveConditions(xb, _boryDay, ghks, InstanceForm.BDatabase, out _message))
                {
                    MessageBox.Show(_message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //2014-09-10
                //wangzhi:ԭ���Ĳ���1088Ҳ�����ڿ���ĳ�����䲻�ܹ��ض����ң�������ӵĲ���1143������һ���������Ѿ���ҽԺ���ã��ʱ���MatchAge����           
                /*���ƹҺ��������� ����� ָ��16�����ڲ�����Һ� add by zp 2013-07-17*/
                if (!MatchAge())
                    return;
                #endregion

                #region סԺǷ�Ѽ��
                // add by wangzhi 2010-10-28
                if (CheckZyFee(brxxid, xm) == false)
                {
                    return;
                }
                // end add
                #endregion

                //��ȡ�������õĲ��������ͣ�������ʽ 1000,1001
                string blb = cfgBlb.Config.Trim();
                if (!String.IsNullOrEmpty(blb))
                {
                    FrmNoteBookSelect fNote = new FrmNoteBookSelect(blb);
                    if (fNote.ShowDialog() == DialogResult.OK)
                    {
                        blb = fNote.SelectedBLB;
                    }
                    else
                    {
                        blb = "";
                    }
                }
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                //������
                mz_card card = new mz_card(klx, InstanceForm.BDatabase);
                //��ȡ���˿����
                ReadCard readcard = new ReadCard(klx, kh, InstanceForm.BDatabase);
                ye = readcard.kye;

                if (readcard.sdbz == 1)
                {
                    MessageBox.Show("���˿��Ѷ��ᣬ�ݲ������ѡ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (readcard.sdbz == 2)
                {
                    MessageBox.Show("���˿��ѹ�ʧ���ݲ������ѡ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (kh.Trim() != "" && readcard.kdjid == Guid.Empty && New_Card != "true")
                {
                    MessageBox.Show("û���ҵ�����Ϣ����ȷ�Ͽ��Ƿ�������ȷ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //150213  chencan/   ��֤������Ч��
                if (txtkh.Text.Length != card.kcd && card.klx > 0 && txtkh.Text.Trim() != "")
                {
                    MessageBox.Show("��λ���������ϵͳ�趨��(" + card.kcd.ToString() + ")λ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cfg1060.Config == "0" && !Convertor.IsNumeric(txtkh.Text.Trim()))
                {
                    MessageBox.Show("����¼�����󣬲��ܳ����ַ�!", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InstanceForm.BDatabase.RollbackTransaction();
                    return;
                }

                //ҽ������
                Yblx yb = new Yblx(yblx, InstanceForm.BDatabase);

                if (lblmzh.Text.Trim() == "")
                {
                    MessageBox.Show("�����Ϊ�գ�����");
                    return;
                }

                if (syk_ini == "true" && readcard.kdjid == Guid.Empty && kh == "")
                {
                    MessageBox.Show("�������뿨��");
                    txtkh.Focus();
                    return;
                }

                if (xm_ini != "true" && xm == "")
                {
                    MessageBox.Show("����������");
                    txtxm.Focus();
                    return;
                }
                if (ghks_ini != "true" && ghks == 0)
                {
                    MessageBox.Show("������Һſ���");
                    txtks.Focus();
                    return;
                }
                //if (ghys_ini != "true" && ghys == 0)
                //{
                //    MessageBox.Show("������Һ�ҽ��");
                //    txtys.Focus();
                //    return;
                //}

                if (yb.ybjklx > 0)
                {
                    SystemCfg s = new SystemCfg(1031);
                    if (s.Config == "1" && lblybxm.Text.Trim() != "" && lblybxm.Text.Trim() != txtxm.Text.Trim() && lblybxm.Text.Trim() != "")
                    {
                        MessageBox.Show("�����շѣ�ϵͳҪ��ҽ������������HISϵͳ��ʹ�õ�������ͬ!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //ԤԼ�����Ϣ
                int yylx = 0;
                string yysd = "";
                string yyqtxx = "";
                string ghsj = djsj;
                if (Convertor.IsNull(butqh.Tag, "0") != "0")
                {
                    string ssql = "select * from mz_yyghlb where yyid='" + Convertor.IsNull(butqh.Tag, "") + "'";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count > 0)
                    {
                        yylx = Convert.ToInt32(tb.Rows[0]["yylx"]);
                        yysd = Convertor.IsNull(tb.Rows[0]["yysd"], "");
                        yyqtxx = "";
                        //chencan ԤԼȡ�ŵĹҺ�ʱ�䴦��
                        //���ԤԼ��¼��ʱ�Σ���Һ�ʱ����ԤԼ����+ʱ�Σ����ȡ�����ڲ���ԤԼ���ڣ���Һ�����=ԤԼ���ڣ����ȡ��������ԤԼ���ڣ���Һ�����=��ǰʱ�䡣
                        if (tb.Rows[0]["yyrq"] != null)
                        {
                            DateTime dt = Convert.ToDateTime(tb.Rows[0]["yyrq"]);
                            //Fun.DebugView(dt);
                            //ԤԼ����+ʱ��
                            if (!string.IsNullOrEmpty(yysd))
                            {
                                ghsj = dt.ToString("yyyy-MM-dd")+" " + yysd.Split('-')[0];
                            }
                            //�Һ�����=ԤԼ����
                            else if (DateTime.Parse(ghsj).ToString("yyyy-mm-dd") != dt.ToString("yyyy-mm-dd"))
                            {
                                ghsj = Convert.ToDateTime(tb.Rows[0]["yyrq"]).ToString();
                            }
                        }
                        _pdxh = Convert.ToInt32(tb.Rows[0]["pdxh"]);
                    }
                }
                #endregion
                int err_code = -1;
                string err_text = "";
                //Guid NewCfmxid = Guid.NewGuid(); //Add by zp 2013-12-13 ����ҽ����Ҫ���䴦����ϸid���� �����ɴ�����ϸid
                #region ҽ��Ԥ��
                string HDGS_MZH = "";
                try
                {

                    if (yb.isgh == true)
                    {
                        DataSet mxds = mz_ghxx.mzgh_get_sfmx(ghlx, brlx, yblx, ghks, ghjb, ghys, blb, ybzf, klx, new Guid(Convertor.IsNull(cmbyhlx.SelectedValue, Guid.Empty.ToString())), Jgbm, out err_code, out err_text, Convertor.IsNull(butqh.Tag, Guid.Empty.ToString()), InstanceForm.BDatabase);//�ĳ�yyid

                        DataRow[] Tab_yb = mxds.Tables[4].Select("groupid='�Һŷ�'");//Modify By Zj 2012-12-19 ҽ������ ֻ����Һŷ�

                        cfmx = new ts_yb_mzgl.CFMX[Tab_yb.Length];
                        for (int i = 0; i <= cfmx.Length - 1; i++)
                        {
                            cfmx[i].HJID = PubStaticFun.NewGuid().ToString();//Modify By tany 2010-08-06 �Һ�û��HJID Tab_yb.Rows[i]["hjid"].ToString();//Add By Tany 2010-08-06
                            cfmx[i].TJDXM = Tab_yb[i]["statitem_code"].ToString().Trim();
                            if (Tab_yb[i]["��Ŀ��Դ"].ToString() == "1")
                                cfmx[i].BM = Convertor.IsNull(yb.ypbm, "") + Tab_yb[i]["HISCODE"].ToString().Trim();
                            else
                                cfmx[i].BM = Convertor.IsNull(yb.xmbm, "") + Tab_yb[i]["HISCODE"].ToString().Trim();
                            cfmx[i].MC = Tab_yb[i]["item_name"].ToString().Trim().Trim();
                            cfmx[i].GG = "";
                            cfmx[i].JX = "";
                            cfmx[i].DJ = Tab_yb[i]["cost_price"].ToString();
                            decimal sl = Convert.ToDecimal(Tab_yb[i]["num"]);
                            cfmx[i].SL = sl.ToString();
                            cfmx[i].JE = Tab_yb[i]["je"].ToString();
                            cfmx[i].DW = Tab_yb[i]["item_unit"].ToString().Trim();
                            cfmx[i].SCCJ = "";
                            cfmx[i].YSDM = Convertor.IsNull(txtys.Tag, "");
                            cfmx[i].YSXM = Fun.SeekEmpName(Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0")), InstanceForm.BDatabase);
                            cfmx[i].KSDM = Convertor.IsNull(txtks.Tag, "");
                            cfmx[i].KSMC = Fun.SeekDeptName(Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0")), InstanceForm.BDatabase);
                            cfmx[i].FSSJ = djsj;
                            //cfmx[i].HJMXID = NewCfmxid.ToString(); //��ǰ������ע�͵� ������Ҫ������ϸid���� �������� Add by zp 2013-12-13

                        }


                        if (cfmx.Length > 0)
                        {
                            ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                            bool bok = ybjk.Compute(false, yb.yblx.ToString(), yb.insureCentral, yb.hospid, InstanceForm.BCurrentUser.EmployeeId.ToString(), cfmx, brxx, ref jsxx);
                            if (bok == false) throw new Exception("ҽ������û�гɹ�");
                            ybzf = jsxx.YBZF;
                            zfje = jsxx.GRZF;

                            //Add By Tany 2010-06-30
                            ybzhzf = jsxx.ZHZF;
                            ybjjzf = jsxx.TCZF;
                            ybbzzf = jsxx.QTZF;
                            //Add by zp 2013-12-30 ������������
                            HDGS_MZH = jsxx.HDGS_MZH;
                        }
                        else
                            yb.isgh = false;  //����Һŷ�Ϊ0 �����Ϊ�Է� Modify By zp 2013-10-14  
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("ҽ��Ԥ������쳣! ԭ��:" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                #endregion

                //bool b_ok = false;

                #region �޺��ж�
                //��֤�Ƿ񳬹����޺�
                try
                {
                    GetXh(false);
                }
                catch (System.Exception err)
                {
                    if (err.Message != "") MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                #endregion

                #region  ͨ���Һ���Ϣ��ñ��ε��շ�������ϸ��Ŀ

                //���ѵ���ȡ ������˿����;��տ���
                int _klx = 0;

                //if (New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "")
                //Modify By Tany 2010-09-18 Ӧ���ǿ��Ǽ�ID��Ϊ�ղ����տ��Ѳ���Ϊ���δ������¿�
                //if (_isCreateNewCard && New_Card == "true" && readcard.kdjid != Guid.Empty && txtkh.Text.Trim() != "")
                //Modify By zp 2013-09-30 �¿������Ŀ��Ǽ�id��Զ�ǿյ�  �����ж���Ҫ�ı� ��ǰ�Ǳ�����ȫ�����˲�����Ϣ�Ϳ���Ϣ
                if (_isCreateNewCard && New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "")
                {
                    _klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                }
                if (_isCreateNewCard && _needChargeCardFee)
                    _klx = 1;

                // add by wangzhi 2010-10-27 
                //���²�����Ϣ����Ϣ��ΪNullʱ��˵�����°쿨,����_klx�����Ա��̨�ܹ�������ȡ����
                if (_klx > 0)
                {

                    if (_new_brxx_kxx != null)
                    {
                        _klx = _new_brxx_kxx.Kdjxx.Klx;
                        //add by zouchihua 2013-4-17 ������¿������ж�һ�ο��Ƿ��йҺż�¼
                        string ssstr = "select * from YY_KDJB where KH='" + txtkh.Text.Trim() + "'and ZFBZ=0  and KLX=" + _klx;
                        DataTable tbtempxx = InstanceForm.BDatabase.GetDataTable(ssstr);
                        if (tbtempxx.Rows.Count > 0)
                        {
                            MessageBox.Show("ϵͳ��鵽�ÿ����Ѿ�������Ч�Ŀ���Ϣ��\r\n ������ˢ���ٽ��йҺŲ�������");
                            return;
                        }
                    }
                }
                //end add
                Guid yhlx = new Guid(Convertor.IsNull(cmbyhlx.SelectedValue, Guid.Empty.ToString()));
                DataSet dset = mz_ghxx.mzgh_get_sfmx(ghlx, brlx, yblx, ghks, ghjb, ghys, blb, ybzf, _klx, yhlx, Jgbm, out err_code, out err_text, Convertor.IsNull(butqh.Tag, Guid.Empty.ToString()), InstanceForm.BDatabase);

                if (err_code != 0)
                {
                    MessageBox.Show(err_text, "����", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }

                //��д��ˮ��,һ�ŷ�Ʊ��Ӧһ����ˮ��
                for (int iFp = 0; iFp < dset.Tables[0].Rows.Count; iFp++)
                    dset.Tables[0].Rows[iFp]["dnlsh"] = Fun.GetNewDnlsh(InstanceForm.BDatabase);


                zje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));//��������1����ܽ��
                yhje = Convert.ToDecimal(dset.Tables[0].Compute("sum(yhje)", ""));//��������1����Żݽ��
                srje = Convert.ToDecimal(dset.Tables[0].Compute("sum(srje)", ""));//��������1���������
                zfje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zfje)", ""));//��������1����Ը����
                fpzs = dset.Tables[0].Rows.Count;//Add By Zj 2012-12-13 ����Ʊ������ֵ

                //if (new SystemCfg(1068).Config == "0")//Add By Zj 2012-12-20 ���ƿ����ò���ӡ  ��ƱΪ1��
                //    fpzs = 1;
                //�����Ʊ ע����Щ
                //zje = Convert.ToDecimal(dset.Tables[0].Rows[0]["zje"]);
                //yhje = Convert.ToDecimal(dset.Tables[0].Rows[0]["yhje"]);
                //srje = Convert.ToDecimal(dset.Tables[0].Rows[0]["srje"]);
                //zfje = Convert.ToDecimal(dset.Tables[0].Rows[0]["zfje"]);



                #endregion

                #region ���������

                Frmsf f = new Frmsf(_menuTag, _chineseName, _mdiParent, InstanceForm.BDatabase);
                f.lblks.Text = txtks.Text.Trim();
                f.lblxm.Text = txtxm.Text.Trim();
                f.lblfph.Text = lblfph.Text.Trim();
                f.lblzje.Text = zje.ToString();
                f.lblklx.Text = cmbklx.Text.Trim();
                f.lblkye.Text = lblkye.Text.Trim();
                f.lblbrlx.Text = cmbbrlx.Text.Trim();
                f.lblyhje.Text = yhje == 0 ? "" : yhje.ToString();
                f.lblsrje.Text = srje == 0 ? "" : srje.ToString();
                f.txtybzf.Text = ybzf == 0 ? "" : ybzf.ToString();
                f.lblfps.Text = fpzs + " ��";
                f.txtybzf.Enabled = ybzf > 0 && Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")) > 0 ? false : true;
                f.klx = readcard.klx;
                f.kdjid = readcard.kdjid;
                f.fpzs = fpzs;
                f.dataGridView1.DataSource = dset.Tables[1];
                f.lblhtdwlx.Text = cmbdwlx.Text;
                f.lblhtdw.Text = txthtdw.Text;


                //��ѡ����ҽ�����ͣ���û�����ýӿڵ������ ҽ����������
                f.txtybzf.Enabled = false;
                if (yblx > 0 && jydjh.Trim() == "" && yb.isgh == false)
                    f.txtybzf.Enabled = true;

                if (yb.issf == true)
                    f.lblbz.Text = "�ʻ�֧��:" + ybzhzf.ToString() + " ͳ��֧��:" + ybjjzf.ToString() + " ����֧��:" + ybbzzf.ToString();

                //�жϵ�ǰ���Ƿ�֧��Ƿ�ѹ��� ���������Ƿ�ѹ�����������

                //f.txtqfgz.Enabled = card.bqfgz;
                //f.txtcwjz.Enabled = card.bjebz == true && ye > 0 ? true : false;

                //�жϵ�ǰ���Ƿ�֧��Ƿ�ѹ��� ���������Ƿ�ѹ�����������
                string ssqfgz = new SystemCfg(1025).Config == "0" ? "true" : "false";
                if (ssqfgz == "true") f.txtqfgz.Enabled = true; else f.txtqfgz.Enabled = false;
                if (card.klx > 0 && card.bqfgz == true)
                    f.txtqfgz.Enabled = card.bqfgz;
                if (new SystemCfg(1037).Config == "1") f.txtzpzf.Enabled = false;
                if (new SystemCfg(1038).Config == "1" && cmbdwlx.Text.Trim() == "") f.txtqfgz.Enabled = false;

                //���������
                if (ye > 0)
                {
                    if (ye >= zfje)
                    {
                        f.txtcwjz.Text = zfje.ToString();
                        f.lblysxj.Text = "0";
                    }
                    else
                    {
                        f.txtcwjz.Text = ye.ToString();
                        f.lblysxj.Text = Convert.ToDecimal(zfje - ye).ToString();
                    }
                }
                else
                {
                    f.txtcwjz.Enabled = false;
                    f.txtcwjz.Text = "";
                    f.lblysxj.Text = zfje.ToString();
                }


                //��ͬ��λ��������ʱ,������뵽����һ��
                if (new SystemCfg(1036).Config == "1" && cmbdwlx.Text.Trim() != "")
                {
                    f.txtqfgz.Text = zfje.ToString();
                    f.lblysxj.Text = "0";
                }

                //������ Ӧ�� Modify by tck 2013-11-21
                string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true")
                {
                    string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);

                    /* ��Ϊ��˾�������Ѿ�����������ҽ,�޷����� ���Դ˴���ע�� �������ϵ�ģʽ
                    ts_call.CallFactory.cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));
                    ts_call.CallFactory.ysje = Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0"));
                    ts_call.CallFactory.zje = Convert.ToDecimal(Convertor.IsNull(f.lblzje.Text, "0"));
                    string par = txtxm.Text.Trim() + ",(" + txtks.Text.Trim() + ")" + "," + ye + "Ԫ" + "," + ts_call.CallFactory.ysje.ToString("0.00") + "Ԫ";
                    ts_call.CallFactory.Bjq_YsCall(bjqxh, call, par);*/
                    decimal _cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));//�������
                    decimal ysje = Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0"));//Ӧ���ֽ�
                    decimal _zje = Convert.ToDecimal(Convertor.IsNull(f.lblzje.Text, "0"));
                    decimal ysze = Convert.ToDecimal(Convertor.IsNull(f.lblzje.Text, "0"));

                    decimal _ybzf = Convert.ToDecimal(Convertor.IsNull(f.txtybzf.Text, "0"));//ҽ��֧��



                    if (ye > ysje && bjqxh == "�Ϻ�ͨ�������������ͺŢ�")
                    {
                        string par = txtxm.Text.Trim() + ",(" + txtks.Text.Trim() + ")" + "," + ye + "Ԫ" + "," + ysje.ToString("0.00") + "Ԫ";
                        call.Call(ts_call.DmType.Ӧ��, par);
                    }
                    else if (ye > _zje && bjqxh == "�Ϻ�ͨ������������������һ����ҽԺ")
                    {
                        call.Call(ts_call.DmType.����, txtxm.Text.Trim() + "(" + txtks.Text.Trim() + ")");
                        call.Call(ts_call.DmType.�ܷ���, _zje.ToString("0.00") + "Ԫ");//_zje
                    }
                    else
                    {
                        call.Call(ts_call.DmType.����, txtxm.Text.Trim() + "(" + txtks.Text.Trim() + ")");
                        call.Call(ts_call.DmType.Ӧ��, Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0")).ToString("0.00"));

                        //call.Call(ts_call.DmType.ʵ��,)
                    }
                }
                f.txtssxj.Focus();
                f.ShowDialog();

                if (f.Bok == false)
                {
                    //Add By Tany 2010-0630
                    try
                    {
                        if (yb.ybjklx > 0 && yb.issf)
                        {
                            ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                            bool bok = ybjk.DeleteYbInfo(yb.insureCentral, yb.hospid, brxx, ref jsxx);//Modify By zp 2013-08-30 ����jsxx
                            if (bok)
                            {
                                MessageBox.Show("ȡ��ҽ���ɹ��������¶���ȷ��ҽ��������Ϣ��");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return;
                }


                #endregion

                #region ҽ����ʽ����

                try
                {
                    if (yb.isgh == true)
                    {
                        ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                        jsxx.HDGS_MZH = HDGS_MZH;//Add by zp 2013-12-30
                        bool bok = ybjk.Compute(true, yb.yblx.ToString(), yb.insureCentral, yb.hospid, InstanceForm.BCurrentUser.EmployeeId.ToString(), cfmx, brxx, ref jsxx);
                        if (bok == false) throw new Exception("ҽ����ʽ��û�гɹ�");
                    }

                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
                #endregion

                #region �޺��ж�
                //��֤�Ƿ񳬹����޺�
                try
                {
                    GetXh(false);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #endregion

                #region  //������ ���� Modify By tck 2013-11-21
                bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true")
                {
                    string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    decimal ssje = Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));//ʵ���ֽ�
                    //decimal je = Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));
                    decimal _cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));
                    decimal _zlje = Convert.ToDecimal(Convertor.IsNull(f.lblzl.Text, "0"));

                    if (bjqxh.Trim() == "�Ϻ�ͨ�������������ͺŢ�" && _cwjz > 0)
                    {
                        string par = ",,,," + ssje.ToString("0.00") + "Ԫ";
                        call.Call(ts_call.DmType.ʵ��, par);//ssje.ToString("0.00")
                    }
                    else if (bjqxh.Trim() == "�Ϻ�ͨ������������������һ����ҽԺ" && _cwjz > 0 && ssje == 0)
                    {
                        //Add by tck 2013-11
                        string par = _cwjz.ToString("0.00") + "Ԫ" + "," + (ye - _cwjz) + "Ԫ";
                        call.Call(ts_call.DmType.ʵ��, par);
                    }
                    else
                        call.Call(ssje.ToString("0.00"), _zlje.ToString("0.00"));
                    /*�����������⴦��ȫ����ts_call��CallFactory����ȥ���� ���¸��汾���� �����ϵ�ģʽ Modify By zp 2013-12-04
                    ts_call.CallFactory.cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));
                    ts_call.CallFactory.ssje = Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));//ʵ���ֽ�
                    ts_call.CallFactory.zlje = Convert.ToDecimal(Convertor.IsNull(f.lblzl.Text, "0"));
                    ts_call.CallFactory.zlkye = ye;
                    ts_call.CallFactory.Bjq_ZlCall(bjqxh, call, "");
                    */
                }
                #endregion

                #region //�Զ�����Ƶ��
                string kxym = "";
                //try
                //{
                //    if ( New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "" )
                //    {
                //        string sbxh = ApiFunction.GetIniString( "ҽԺ������" , "�豸�ͺ�" , Constant.ApplicationDirectory + "//ClientWindow.ini" );
                //        if ( sbxh != "" )
                //        {
                //            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall( sbxh );
                //            if ( ReadCard != null )
                //            {
                //                kxym = ReadCard.CreateKxym();
                //                bool bok = ReadCard.WriterCard( txtkh.Text , kxym , "" , kxym );
                //                if ( bok == false )
                //                    throw new Exception( "д��û�гɹ�" );
                //            }
                //        }
                //    }
                //}
                //catch ( System.Exception err )
                //{
                //    MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                //    return;
                //}
                #endregion

                decimal ylkzf = 0;//������֧��
                decimal cwjz = 0;//�������
                decimal qfgz = 0;//Ƿ�ѹ���
                decimal ssxj = 0;//ʵ�ս��
                decimal zlje = 0;//������
                decimal xjzf = 0;//�ֽ�֧��
                decimal zpzf = 0;//֧Ʊ֧��
                string _ghck = "";//�ҺŴ���
                FsdClass _fsd = null;
                Guid NewJsid = Guid.Empty;

                ylkzf = Convert.ToDecimal(Convertor.IsNull(f.txtpos.Text, "0"));//����
                cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));//�������
                qfgz = Convert.ToDecimal(Convertor.IsNull(f.txtqfgz.Text, "0"));//Ƿ�ѹ���
                ssxj = Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));//ʵ���ֽ�
                zlje = Convert.ToDecimal(Convertor.IsNull(f.lblzl.Text, "0"));//������
                xjzf = Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0"));//�ֽ��Ը�
                zpzf = Convert.ToDecimal(Convertor.IsNull(f.txtzpzf.Text, "0"));//֧Ʊ֧��
                ybzf = Convert.ToDecimal(Convertor.IsNull(f.txtybzf.Text, "0"));//ҽ��֧��
                _ghck = "";
                if (cwjz > 0)
                {
                    #region ���뿨��

                    if (cfg_1093.Config.Trim() == "1") //Add By zp ��������ƿ��ۿ�����Ҫ������֤ 2013-09-22
                    {
                        string strMsg = "����ʧ�ܣ�ҽԺ���ƿ�֧����Ҫ���ж���ȷ��!�뽫�����ö�������!\r\n�������ò���ȷ�����ܶ����豸������...";


                        string sbxh = ApiFunction.GetIniString("ҽԺ������", "�豸�ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                        if (sbxh != "")
                        {
                            //load �¼� �� ��panel_yanzheng �ĸ߶� ��Ϊ0
                            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                            if (ReadCard != null)
                            {
                                ts_Read_hospitalCard.CardFactory.ReadCard_for_yanzheng(ReadCard, _menuTag.Function_Name, cmbklx, txt_kh_yanzheng);
                                if (string.IsNullOrEmpty(txt_kh_yanzheng.Text) || txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                {
                                    string strRetry = "ҽԺ���ƿ�֧����Ҫ���ж���ȷ�ϣ�\r\n��<����>���ٶ�һ�ο�����<����>ǰ��źÿ�\r\n�����˳������ιҺ���Ч��";
                                    string strRetryMsg = "";
                                    if (string.IsNullOrEmpty(txt_kh_yanzheng.Text)) strRetryMsg = "��ȡ��ʧ�ܣ�" + strRetry;
                                    else
                                    {
                                        // (txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                        strRetryMsg = "��������ȡ����Ϣ��ҺŴ�����д�Ŀ���Ϣ�������Һ�ʧ�ܣ�\r\n" + strRetry;
                                    }
                                    DialogResult dlg = MessageBox.Show(strRetryMsg, "��ʾ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                    ts_Read_hospitalCard.CardFactory.ReadCard_for_yanzheng(ReadCard, _menuTag.Function_Name, cmbklx, txt_kh_yanzheng);
                                    if (string.IsNullOrEmpty(txt_kh_yanzheng.Text))
                                    {
                                        if (dlg == DialogResult.Retry) MessageBox.Show(string.Format("��<����>����Ȼ����ʧ�ܣ��Һ���Ч��"), "��ʾ");
                                        return;
                                    }
                                    else if (txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                    {
                                        string str = txt_kh_yanzheng.Text;
                                        if (dlg == DialogResult.Retry) MessageBox.Show(string.Format("��<����>����Ȼ��������Ϣ��ҺŴ�����д�Ŀ���Ϣ�������Һ���Ч��", "��ʾ"));
                                        return;
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show(strMsg, "��ʾ");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(strMsg, "��ʾ");
                            return;
                        }
                    }
                    #endregion
                }

                #region  ��ÿ��÷�Ʊ�ż���
                DataTable tbfp = null;
                tbfp = Fun.GetFph(InstanceForm.BCurrentUser.EmployeeId, new SystemCfg(1067).Config != "2" ? 1 : fpzs, Fplx, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tbfp.Rows.Count == 0 || tbfp.Rows.Count != (new SystemCfg(1067).Config != "2" ? 1 : fpzs))
                {
                    if (cfg1046.Config == "1")//ֻ�д�Ʊʱ���ж� Modify by zouchihua 2013-4-23)
                    {
                        //if (Convertor.IsNull(txthtdw.Tag, "0") != "0" && txthtdw.Tag.ToString() != "" && cfg1114.Config == "0") { }//add by jiangzf ����Ǻ�ͬ��λ���ˣ����Ҳ���1114=1������Ҫ��ȡ��Ʊ��
                        if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1") { }//add by jiangzf
                        else
                        {
                            MessageBox.Show(err_text, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                #endregion

                #region//��ʱ�ιҺŴ��� Add by zp 2013-10-30 �洢���ݵ���̨ǰ�Ȼ�ȡ��ǰ��ʱ����Ϣ
                string _msg = ""; //cfg1099


                if (cfg1099.Config.Trim() == "1")
                {
                    try
                    {
                        _fsd = FsdClass.GetNowFsd(ghks, ghys, ghjb, ghsj, yysd, ref _msg, InstanceForm.BDatabase);
                        if (_fsd == null)//Ϊ�ձ�ʾ��ǰʱ��δ�ҵ���ʱ����Դ,����ҽ������������Դ�޺�
                        {
                            MessageBox.Show(_msg, "��ʾ");
                            return;
                        }
                        //û��ʱ�ε���Դ����̶���ʱ���ǳ� Modify by zp 2013-11-05
                        if (_fsd.FsdId <= 0)
                        {
                            DateTime _date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                            if (_date.Hour < 12 && _date.Hour > 6)
                            {
                                _fsd.Btime = "08:00";
                                _fsd.Etime = "12:00";
                                _fsd.Sdbm = "08:00-12:00";
                            }
                            else
                            {
                                _fsd.Btime = "14:00";
                                _fsd.Etime = "17:00";
                                _fsd.Sdbm = "14:00-17:00";
                            }
                        }
                    }
                    catch (Exception ea)
                    {

                        MessageBox.Show("��ȡ��ʱ���쳣!ԭ��:" + ea.Message);
                    }

                }

                #endregion
                Cursor = PubStaticFun.WaitCursor();
                InstanceForm.BDatabase.BeginTransaction();
                try
                {
                    #region//������Ϣ����
                    if (brxxid == Guid.Empty)
                    {
                        //add by zouchihua 2013-4-9���û��ѡ��Ĭ��Ϊ��
                        if (_new_brxx_kxx.Brxx.Xb.Trim() == "0")
                            _new_brxx_kxx.Brxx.Xb = "1";
                        //YY_BRXX.BrxxDj(Guid.Empty, xm, xb, csrq, "", "", "", "", "", jtdz, "", "", "", lxdh, "", "", "", "", "", "", "", brlx, yblx, cbkh, InstanceForm.BCurrentUser.EmployeeId, 0, out brxxid, out err_code, out err_text, InstanceForm.BDatabase);
                        string str_brxm = txtxm.Text.Trim();
                        string str_brxb = cmbxb.SelectedValue.ToString();
                        string str_csrq = dtpcsrq.Value.ToShortDateString();
                        string str_jtdz = txtjtdz.Text.Trim();
                        string str_brlxfs = txtgrlxfs.Text.Trim();
                        YY_BRXX.BrxxDj(Guid.Empty, str_brxm, str_brxb, str_csrq, _new_brxx_kxx.Brxx.Hyzk,
                            _new_brxx_kxx.Brxx.Gj, _new_brxx_kxx.Brxx.Mz, _new_brxx_kxx.Brxx.Zy, _new_brxx_kxx.Brxx.Csdz, str_jtdz,
                            _new_brxx_kxx.Brxx.Jtyb, _new_brxx_kxx.Brxx.Jtdh, _new_brxx_kxx.Brxx.Jtlxr, str_brlxfs, _new_brxx_kxx.Brxx.Dzyj,
                            _new_brxx_kxx.Brxx.Gzdw, _new_brxx_kxx.Brxx.Gzdwdz, _new_brxx_kxx.Brxx.Gzdwyb, _new_brxx_kxx.Brxx.Gzdwdh, _new_brxx_kxx.Brxx.Gzdwlxr,
                            _new_brxx_kxx.Brxx.Sfzh, _new_brxx_kxx.Brxx.Brlx, _new_brxx_kxx.Brxx.Yblx, _new_brxx_kxx.Brxx.Cbkh, InstanceForm.BCurrentUser.EmployeeId, 0, out brxxid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (brxxid == Guid.Empty || err_code != 0)
                        {
                            brxxid = Guid.Empty;
                            throw new Exception(err_text);
                        }
                        //add by cc 
                        YY_BRXX.BrxxBcDj(brxxid, yy_brxx_bc.QTZJLX, yy_brxx_bc.QTZJHM, yy_brxx_bc.JKDAH, yy_brxx_bc.WHCDDM, yy_brxx_bc.LXRXM,
                        yy_brxx_bc.LXRGX, yy_brxx_bc.LXRDH, out err_code, out err_text, InstanceForm.BDatabase);
                        if (err_code != 0)
                            throw new Exception(err_text);
                        //end add 
                    }
                    #endregion

                    Guid NewGhxxid = Guid.Empty;
                    Guid _Kdjid = Guid.Empty;
                    #region //���濨��Ϣ

                    if (New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "")
                    {
                        mz_kdj.Kdj(Guid.Empty,
                            brxxid,
                            Convert.ToInt32(cmbklx.SelectedValue),
                            txtkh.Text.Trim(),
                            txtxm.Text.Trim() == "" ? "δд��" : txtxm.Text.Trim(),
                            0,
                            0,
                            0,
                            0,
                            djsj,
                            InstanceForm.BCurrentUser.EmployeeId,
                            card.mrmm, kxym, "",
                            out _Kdjid, out err_code, out err_text, Fun.GetNewGrzhbh(InstanceForm.BDatabase), _menuTag.Function_Name, InstanceForm.BDatabase);
                        if (_Kdjid == Guid.Empty || err_code != 0)
                            throw new Exception(err_text);
                        readcard.kdjid = _Kdjid;
                        //Add By Zj 2012-12-24
                        mz_kdj.UpdateBKJE(_Kdjid, brxxid, klx, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);

                    }
                    #endregion

                    #region //����Һ���Ϣ��������Ϣ
                    string sCfid = "";
                    for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                    {
                        int ksdm = ghks;//���Ҵ���
                        string ksmc = txtks.Text.Trim();//��������
                        int ysdm = ghys;//ҽ������
                        string ysmc = txtys.Text.Trim();//ҽ������
                        int zxks = ghks;//ִ�п��Ҵ���
                        string zxksmc = txtks.Text.Trim();//ִ�п�������
                        int bghpbz = 0;//�Һ�Ʊ��־
                        decimal cfzje = Convert.ToDecimal(dset.Tables[0].Rows[i]["zje"]);//������Һ��ܽ�� �� ���ѷֿ�
                        if (dset.Tables[0].Rows[i]["groupid"].ToString() == "�Һŷ�" || dset.Tables[0].Rows[i]["groupid"].ToString() == "")
                        {
                            bghpbz = 1;//�Һ�Ʊ
                            if (cfg1046.Config == "1")//�����Ҫ��Ʊ���ͻ�ȡ��Ʊ��
                            {
                                //add by jiangzf ����Ǻ�ͬ��λ���ˣ����Ҳ���1114=0������Ҫ��ȡ��Ʊ��
                                //add by wangzhi �����0���ɲ���1163����0����Ƿ��ӡ��Ʊ
                                if ((cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1") || (cfg1163.Config == "1" && zje == 0))
                                {
                                }
                                else
                                    fph = Convertor.IsNull(tbfp.Rows[i]["QZ"], "") + tbfp.Rows[i]["fph"].ToString().Trim();
                            }
                            long _dnlsh = Convert.ToInt64(dset.Tables[0].Rows[i]["dnlsh"]);
                            //�Һ���Ϣ����
                            mz_ghxx.GhxxDj(Guid.Empty, brxxid, ghlx, readcard.kdjid, mzh, ghks, ghys, ghjb, cfzje, InstanceForm.BCurrentUser.EmployeeId, 1, _ghck, ref _pdxh, _dnlsh, fph, Jgbm, out NewGhxxid, out err_code, out err_text, Convert.ToInt32(Convertor.IsNull(cmbdwlx.SelectedValue, "0")), Convert.ToInt32(Convertor.IsNull(txthtdw.Tag, "0")), Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")), yb_dylx, yb_dylxmc, yb_bzxx, yylx, yysd, yyqtxx, ghsj, InstanceForm.BDatabase);
                            if (NewGhxxid == Guid.Empty || err_code != 0)
                                throw new Exception(err_text);
                        }
                        else
                        {

                            ksdm = 0;
                            ksmc = "";
                            ysdm = 0;
                            ysmc = "";
                            zxks = 0;
                            zxksmc = "";//���Ѳ������κ�ҽ���Ϳ��� ֻ��¼����Ա
                            //add by zouchihua 2013-3-28 ���ÿ��ŷѵ�ִ�п��ң�0����֮ǰ��ʽ ����0��ʾ����ִ�п��ң� 
                            if (cfg1079.Config.Trim() != "0")
                            {
                                zxks = Convert.ToInt32(cfg1079.Config);
                                ksdm = Convert.ToInt32(cfg1079.Config);
                            }
                        }

                        if (!(cfg1163.Config == "1" && zje == 0))
                        {
                            string groupid = dset.Tables[0].Rows[i]["groupid"].ToString();//���ڷֽ�������
                            #region ���洦��
                            Guid NewCfid = Guid.Empty;
                            if (cfg1163.Config == "1" && zje == 0)
                            {
                                //�ܽ��Ϊ0�����ֲ���Ʊ������Ҫ���ɴ���
                            }
                            else
                            {
                                mz_cf.SaveCf(Guid.Empty, brxxid, NewGhxxid, lblmzh.Text.Trim(), _ghck, cfzje, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, _ghck, Guid.Empty, ksdm,
                                            ksmc, ysdm, ysmc, 0, zxks, zxksmc, bghpbz, 0, 2, 0, 1, Jgbm, out NewCfid, out err_code, out err_text, InstanceForm.BDatabase);
                                if (NewCfid == Guid.Empty || err_code != 0)
                                    throw new Exception(err_text);

                                sCfid += NewCfid.ToString() + ",";//�����Ҫ���µ�CFID

                                DataRow[] rows = dset.Tables[4].Select("groupid='" + groupid + "'");//�ҵ���Ӧ�ķ��鴦��

                                for (int j = 0; j <= rows.Length - 1; j++)
                                {
                                    //���洦����ϸ
                                    Guid NewCfmxid = Guid.Empty;
                                    mz_cf.SaveCfmx(Guid.Empty, NewCfid, rows[j]["PY_CODE"].ToString().Trim(), "", rows[j]["item_name"].ToString().Trim(),
                                        rows[j]["item_name"].ToString().Trim(), "", "", Convert.ToDecimal(rows[j]["cost_price"]), Convert.ToDecimal(rows[j]["num"]),
                                        rows[j]["item_unit"].ToString().Trim(), 1, 1, Convert.ToDecimal(rows[j]["je"]), rows[j]["statitem_code"].ToString().Trim(),
                                        Convert.ToInt64(rows[j]["item_id"]), Guid.Empty, rows[j]["STD_CODE"].ToString().Trim(), 0, 0, Guid.Empty, 0, "", "", 0, 0, "",
                                        0, 0, Guid.Empty, 0, 0, 0, out NewCfmxid, out err_code, out err_text, InstanceForm.BDatabase);
                                    if (NewCfmxid == Guid.Empty || err_code != 0)
                                        throw new Exception(err_text);
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion
                    int UpdateCfs = 0;//���´���ͷ����
                    #region //����������Ϣ
                    if (!(cfg1163.Config == "1" && zje == 0))
                    {
                        mz_sf.SaveJs(Guid.Empty, brxxid, NewGhxxid, djsj, InstanceForm.BCurrentUser.EmployeeId, zje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, ssxj, zlje, fpzs, 0, Jgbm, out NewJsid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (NewJsid == Guid.Empty || err_code != 0)
                            throw new Exception(err_text);


                        sCfid = sCfid.Substring(0, sCfid.Length - 1);//����β��,ȥ��
                        string[] ssCfid = sCfid.Split(',');//�м��ŷ�Ʊ���м���CFID �ָ� ���� ��Ϊ�����շѱ�־������

                        for (int X = 0; X < dset.Tables[0].Rows.Count; X++)
                        {
                            Guid yhlxid = new Guid(dset.Tables[0].Rows[X]["yhlxid"].ToString());//�Ż�
                            string yhlxmc = Fun.SeekYhlxMc(yhlxid, InstanceForm.BDatabase);
                            decimal cfzje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);//������Һ��ܽ�� �� ���ѷֿ�
                            string groupid = dset.Tables[0].Rows[X]["groupid"].ToString();//����ID
                            int bghpbz = 0;//�Һ�Ʊ��־
                            long _dnlsh = Convert.ToInt64(dset.Tables[0].Rows[X]["dnlsh"]);//��ȡÿ�ŷ�Ʊ�ĵ�����ˮ��


                            if (new SystemCfg(1067).Config == "1" && dset.Tables[0].Rows[X]["groupid"].ToString() != "�Һŷ�" && dset.Tables[0].Rows[X]["groupid"].ToString() != "")//Add By Zj 2012-12-20 ���ƿ����ò���ӡ  ��ƱΪ1��
                                fph = "0";
                            // add by jiangzf 2014-07-26 ���ƿ�������Һŷѷֿ�,�����ƿ���ֻ��СƱ
                            if (new SystemCfg(1067).Config == "3" && dset.Tables[0].Rows[X]["groupid"].ToString() != "�Һŷ�" && dset.Tables[0].Rows[X]["groupid"].ToString() != "")
                                fph = "0";
                            if (cfg1046.Config == "1" && fph != "0")//�����Ҫ��Ʊ���ͻ�ȡ��Ʊ��
                                fph = Convertor.IsNull(tbfp.Rows[X]["QZ"], "") + tbfp.Rows[X]["fph"].ToString().Trim();
                            if (dset.Tables[0].Rows[X]["groupid"].ToString() == "�Һŷ�" || dset.Tables[0].Rows[X]["groupid"].ToString() == "") //Modify By Zj 2012-12-28 ��ѹҺ�
                            {
                                bghpbz = 1;
                                //ֻ�йҺŷ� �Ÿ�ҽ����ҽ�ǼǺŸ�ֵ
                                jydjh = string.IsNullOrEmpty(jsxx.JSDH) ? "" : jsxx.JSDH;//add by wangzhi 2010-12-28
                            }
                            else//Add By Zj 2013-03-11 ghpbz=2 �����ƿ� ��Ʊ������ͳ�����ƿ���Ʊ.
                                bghpbz = 2;
                            if (dset.Tables[0].Rows.Count == 1)//Modify By Zj 2012-12-20 �ܼ�¼��Ϊ1ʱ �ű���һ�ŷ�Ʊ.���ƿ���Ȼ����Ʊ ������ȻҪ�м�¼
                            {
                                //add by zouchihua 2013-3-28 ���ÿ��ŷѵ�ִ�п��ң�0����֮ǰ��ʽ ����0��ʾ����ִ�п��ң� 
                                if (bghpbz == 2)
                                {
                                    //���淢Ʊ��Ϣ  //add by zouchihua 2013-5-9���ƿ��������κο��Һ�ҽ��
                                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, InstanceForm.BCurrentUser.EmployeeId, _ghck, _dnlsh, fph, cfzje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, Guid.Empty, "", NewJsid, bghpbz, Convert.ToInt32(cfg1079.Config), 0, 0, Convert.ToInt32(cfg1079.Config), yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlx, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                                }
                                else
                                    //���淢Ʊ��Ϣ
                                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, InstanceForm.BCurrentUser.EmployeeId, _ghck, _dnlsh, fph, cfzje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, Guid.Empty, "", NewJsid, bghpbz, ghks, ghys, 0, ghks, yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlx, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                            }
                            else
                            {
                                decimal fp_zfje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zfje"]);
                                //����ÿ�ŷ�Ʊ��֧�����
                                if (Convert.ToDecimal(dset.Tables[0].Rows[X]["ybzf"]) == 0)
                                    fp_zfje = fp_zfje - (dset.Tables[0].Rows[X]["groupid"].ToString() == "�Һŷ�" ? ybzf : 0);//Modify By Zj 2012-12-26 �ֹ������ҽ��֧�� �ڴ洢�������޷����� ����������Ը����Ҫ��ȥҽ��֧��

                                decimal fp_zje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                                decimal fp_yhje = Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]);
                                decimal fp_srje = Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]);
                                //decimal fp_ybzhzf = ybzhzf > 0 && ybjjzf == 0 && ybbzzf == 0 ? fp_zfje : 0;
                                //decimal fp_ybjjzf = ybjjzf > 0 && ybzhzf == 0 && ybbzzf == 0 ? fp_zfje : 0;
                                //decimal fp_ybbzzf = ybbzzf > 0 && ybzhzf == 0 && ybjjzf == 0 ? fp_zfje : 0;
                                decimal fp_ylkzf = ylkzf > 0 ? fp_zfje : 0;
                                decimal fp_cwjz = cwjz > 0 ? fp_zfje : 0;
                                decimal fp_qfgz = qfgz > 0 ? fp_zfje : 0;
                                decimal fp_ybzf = dset.Tables[0].Rows[X]["groupid"].ToString() == "�Һŷ�" ? ybzf : 0;
                                decimal fp_xjzf = xjzf > 0 ? fp_zfje : 0;
                                decimal fp_zpzf = zpzf > 0 ? fp_zfje : 0;
                                //add by zouchihua 2013-3-28 ���ÿ��ŷѵ�ִ�п��ң�0����֮ǰ��ʽ ����0��ʾ����ִ�п��ң� 
                                if (bghpbz == 2)
                                {
                                    //add by zouchihua 2013-5-9���ƿ��������κο��Һ�ҽ��
                                    //���淢Ʊ��Ϣ
                                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, InstanceForm.BCurrentUser.EmployeeId, _ghck, _dnlsh, fph, fp_zje, fp_ybzf, 0, 0, fp_ylkzf, fp_yhje, fp_cwjz, fp_qfgz, fp_xjzf, fp_zpzf, fp_srje, Guid.Empty, "", NewJsid, bghpbz, Convert.ToInt32(cfg1079.Config), 0, 0, Convert.ToInt32(cfg1079.Config), yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlxid, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                                }
                                else
                                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, InstanceForm.BCurrentUser.EmployeeId, _ghck, _dnlsh, fph, fp_zje, fp_ybzf, 0, 0, fp_ylkzf, fp_yhje, fp_cwjz, fp_qfgz, fp_xjzf, fp_zpzf, fp_srje, Guid.Empty, "", NewJsid, bghpbz, ghks, ghys, 0, ghks, yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlxid, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                                if (err_code != 0)
                                    throw new Exception(err_text);

                            }

                            //��Ʊ��ϸ
                            decimal fpje = 0;
                            DataRow[] rows = dset.Tables[1].Select("groupid = '" + groupid + "'");
                            //���淢Ʊ��ϸ��Ŀ Begin
                            for (int i = 0; i <= rows.Length - 1; i++)
                            {
                                mz_sf.SaveFpmx(NewFpid, Convertor.IsNull(rows[i]["code"], "0"), Convertor.IsNull(rows[i]["item_name"], "0"), Convert.ToDecimal(rows[i]["je"]), 0, out err_code, out err_text, InstanceForm.BDatabase);
                                if (err_code != 0)
                                    throw new Exception(err_text);
                                fpje = fpje + Convert.ToDecimal(rows[i]["je"]);
                            }
                            if (fpje != Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - (Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"])))
                                throw new Exception("���뷢Ʊ��ϸʱ����,�����ڷ�Ʊ�ܶ�");
                            //���淢Ʊ��ϸ��Ŀ End

                            //���淢Ʊͳ�ƴ���Ŀ Begin
                            decimal tjxmje = 0;
                            DataRow[] tjdxmrows = dset.Tables[3].Select("groupid = '" + groupid + "' ");
                            for (int i = 0; i <= tjdxmrows.Length - 1; i++)
                            {
                                mz_sf.SaveFpdxmmx(NewFpid, Convertor.IsNull(tjdxmrows[i]["code"], "0"), Convertor.IsNull(tjdxmrows[i]["item_name"], "0"), Convert.ToDecimal(tjdxmrows[i]["je"]), 0, out err_code, out err_text, InstanceForm.BDatabase);
                                if (err_code != 0)
                                    throw new Exception(err_text);
                                tjxmje = tjxmje + Convert.ToDecimal(tjdxmrows[i]["je"]);
                            }
                            if (tjxmje != Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - (Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"])))
                                throw new Exception("���뷢Ʊ��ϸʱ����,�����ڷ�Ʊ�ܶ�");
                            //���淢Ʊͳ�ƴ���Ŀ End

                            //����ҽ���������շ���Ϣ
                            if (yb.isgh == true && groupid == "�Һŷ�")
                            {
                                ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                                bool bok = ybjk.UpdateJsmx(brxxid, NewGhxxid, 0, jsxx.HisJsdid, NewFpid, fph, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                                if (bok == false)
                                    throw new Exception("���±���ҽ��������ϸ��ʱû�гɹ�");
                            }
                            dset.Tables[0].Rows[X]["fph"] = fph.ToString();
                            dset.Tables[0].Rows[X]["fpid"] = NewFpid;

                            //���´���״̬
                            int Nrows = 0;
                            mz_cf.UpdateCfsfzt("('" + ssCfid[X] + "')", InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, djsj, _ghck, _dnlsh, fph, NewFpid, out Nrows, out err_code, out err_text, InstanceForm.BDatabase);
                            if (Nrows != 1)
                                throw new Exception(err_text);
                            UpdateCfs = UpdateCfs + Nrows;
                        }
                    }
                    #endregion

                    #region pos֧������mz_pos_czjl
                    if (ylkzf > 0)
                    {
                        Guid opid = Guid.NewGuid();
                        InstanceForm.BDatabase.DoCommand(string.Format("insert into mz_pos_czjl(czid,fpid,fph,je,jsid,tsbz,czy,czsj) select '{0}',fpid,fph,ylkzf,jsid,0,{2},'{3}' from mz_fpb where jsid='{1}'", opid, NewJsid, InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss")));
                    }
                    #endregion

                    //�жϴ�������������ʵ�ʷ��������Ƿ�һ��
                    if (!(cfg1163.Config == "1" && zje == 0))
                    {
                        if (UpdateCfs != dset.Tables[0].Rows.Count)
                            throw new Exception("���´���������" + UpdateCfs + "��,���鴦������" + dset.Tables[0].Rows.Count + "��.���鴦��״̬��ˢ�´�������");

                        //���·�Ʊ���ñ�ĵ�ǰ��Ʊ����
                        if (cfg1046.Config == "1")
                        {
                            //if (Convertor.IsNull(txthtdw.Tag, "0") != "0" && txthtdw.Tag.ToString() != "" && cfg1114.Config == "0") { }//add by jiangzf ����Ǻ�ͬ��λ���ˣ����Ҳ���1114=0������Ҫ��ȡ��Ʊ��
                            if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1")
                            {
                            }
                            else
                                mz_sf.UpdateDqfph(new Guid(tbfp.Rows[0]["fpid"].ToString()), tbfp.Rows[0]["fph"].ToString().Trim(), tbfp.Rows[tbfp.Rows.Count - 1]["fph"].ToString().Trim(), out Msg, InstanceForm.BDatabase);
                        }

                        //���¿������ۼ���Ϣ���
                        if (cwjz > 0)
                            readcard.UpdateKye(cwjz, InstanceForm.BDatabase);
                    }

                    string dd = Convertor.IsNull(butqh.Tag, "");
                    //����ԤԼȡ��״̬
                    if (new Guid(Convertor.IsNull(butqh.Tag, Guid.Empty.ToString())) != Guid.Empty)
                        mz_ghxx.UpateYyghxx(new Guid(Convertor.IsNull(butqh.Tag, Guid.Empty.ToString())), NewGhxxid, djsj, InstanceForm.BDatabase);


                    #region  //modify by zp 2013-06  �Ƿ��Զ�����  �������·���ϵͳ�����������ҵ�ǰ����Ϊ�Զ�����
                    //if (cfg3070.Config.Trim() == "0") //Modify by zp �����Ƿ����÷��ﶼ�����¼����ʿ����� 2013-10-31
                    //{
                    Fz_Zq _fzzq = new Fz_Zq(InstanceForm.BDatabase, ghks, ghjb);
                    Guid NewFzid = Guid.Empty;
                    string fsd_btime = "";
                    string fsd_etime = "";
                    string fsd_sdbm = "";
                    if (_fsd != null)
                    {
                        fsd_btime = Convertor.IsNull(_fsd.Btime, "");
                        fsd_etime = Convertor.IsNull(_fsd.Etime, "");
                        fsd_sdbm = Convertor.IsNull(_fsd.Sdbm, "");
                    }
                    if (_fzzq.Zqid > 0)//ZqidĬ��Ϊ0 ����0��ʾ��������¼
                    {
                        if (_fzzq.Zqbdfs <= 0) //�ֶ����� _fsd
                        {
                            ts_mzys_class.MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, NewGhxxid, ghks, ts_mzys_class.MZHS_FZJL.FzStatus.δ����, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, _fzzq.Zqid, InstanceForm.BDatabase);
                            if (err_code != 0)
                                MessageBox.Show("�����ֶ����������쳣!ԭ��:" + err_text);
                        }
                        else
                        {
                            ts_mzys_class.MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, NewGhxxid, ghks, ts_mzys_class.MZHS_FZJL.FzStatus.�ѷ���, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, _fzzq.Zqid, InstanceForm.BDatabase);
                            if (err_code != 0)
                                MessageBox.Show("�����Զ����������쳣!ԭ��:" + err_text);
                            if (new SystemCfg(3103).Config == "1")
                            {
                                int isjz = 0;
                                if (ghlx == 2)
                                    isjz = 1; 
                                int pxxh = Fun.MZQH_GET_HZH(ghks, ghys, ghjb, Convert.ToInt16(Isyy), isjz, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss"), InstanceForm.BDatabase);
                                InstanceForm.BDatabase.DoCommand("UPDATE MZHS_FZJL SET PXXH = " + pxxh.ToString() + "WHERE FZID = '" + NewFzid + "'");
                                int zsid=Convert.ToInt16(   InstanceForm.BDatabase.GetDataResult("SELECT ISNULL(ZJID,0) FROM JC_ZJSZ WHERE ZZYS='" + ghys + "' ORDER BY DLSJ DESC") ); 
                                InstanceForm.BDatabase.DoCommand("UPDATE MZHS_FZJL SET zsid = " + zsid.ToString() + "WHERE FZID = '" + NewFzid + "'");
                            }
                        }
                    }
                    else //δ����������Ҳ�����¼�������
                    {
                        ts_mzys_class.MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, NewGhxxid, ghks, ts_mzys_class.MZHS_FZJL.FzStatus.�ѷ���, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, 0, InstanceForm.BDatabase);
                        if (err_code != 0)
                            MessageBox.Show("�����Զ����������쳣!ԭ��:" + err_text);
                    }
                    if (_fsd != null && _fsd.FsdId > 0 && (string.IsNullOrEmpty(yysd)))
                        _fsd.UpdateFsdGhrc(ref _fsd, InstanceForm.BDatabase); //���¹Һ�����

                    #endregion
                    InstanceForm.BDatabase.CommitTransaction();

                    _new_brxx_kxx = null;//�Һųɹ��󽫲�����Ϣ���¿���Ϣ��ΪNull
                    this.Tag = Guid.Empty;
                    Isyy = false;
                    butqh.Tag = "";
                    butqh.BackColor = Color.WhiteSmoke;
                    txtks.Enabled = true;
                    cmbghjb.Enabled = true;
                    txtys.Enabled = true;
                    treeView1.Enabled = true;
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;

                }


                /*��СƱ��Ʊ��ӡ����ʱ�� Modify by zp 2013-11-21*/
                string Print_Sdnc = yysd;
                if (string.IsNullOrEmpty(Print_Sdnc) && _fsd != null && _fsd.FsdId > 0)
                    Print_Sdnc = _fsd.Sdbm;

                if (cfg1163.Config == "1" && zje == 0)
                {
                    //1163���������ܽ��δ������ӡ�κζ���
                }
                else
                {

                    if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1")
                    {
                        if (cfg1114.Config == "0")
                            PrintGuideBill();//��ӡ������
                    }
                    //Modify By zp 2013-09-30 �ع� ��ӡƱ��
                    else
                        PrintReport(_ghlx, _pdxh, card, djsj, fpzs, dset, fph, jydjh, kh, klx, zje, ssxj, zlje, ybkye, ybzf, ybzhzf, ye, Print_Sdnc, cwjz);
                }

                #region ������ǰ���÷�Ʊ�� ˢ������
                try
                {
                    //�ؼ��Ŀ�����
                    ControlEnable();
                    this.butnew_Click(sender, e);
                    //��ʾ��Ʊ���Ѿ�����
                    if (Msg.Trim() != "")
                        MessageBox.Show(Msg, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //ˢ������
                    if (chksx.Checked == true)
                        ReadGhxx();
                    if (cfgpb.Config.ToString() == "1")//Add By Zj 2013-02-16 ��������Ű�Һţ��Һųɹ���ˢ���ŰࡣΪ��ˢ��ҽ���Һ��˴�
                        treeView1_AfterSelect(sender, null);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("�շ��ѳɹ�,���������д���" + err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
                #region ������
                string bqypjq = ApiFunction.GetIniString("������", "����������", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string pjqxh = ApiFunction.GetIniString("������", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                try
                {
                    if (bqypjq == "true")
                    {
                        ts_pjq.ipjq ipjq = ts_pjq.PjqFactory.Newpjq(pjqxh);
                        string perr_text = "";
                        int perr_code = 0;
                        ipjq.Pj(InstanceForm.BCurrentUser.LoginCode.ToString(), InstanceForm.BCurrentUser.Name, InstanceForm.BCurrentDept.DeptId.ToString(), InstanceForm.BCurrentDept.DeptName, out perr_code, out perr_text);
                        if (perr_code != 0) throw new Exception("���������ó���!" + perr_text);
                    }
                }
                catch (Exception ea)
                {
                    MessageBox.Show(ea.Message);
                }
                #endregion
            }
            catch (Exception ea)
            {
                MessageBox.Show("�ҺŵǼǳ����쳣!" + ea.Message);
            }
        }
        private void PrintGuideBill()
        {
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            int ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));//�Һſ���
            string ssql = "select NAME,DEPTADDR from  JC_DEPT_PROPERTY where dept_id=" + ksdm;
            DataRow deptdr = InstanceForm.BDatabase.GetDataRow(ssql);//��������λ��

            ParameterEx[] paramters = new ParameterEx[7];
            paramters[0].Text = "ҽԺ����";
            paramters[0].Value = Constant.HospitalName;

            paramters[1].Text = "����";
            paramters[1].Value = txtxm.Text.Trim();

            paramters[2].Text = "����";
            paramters[2].Value = txtkh.Text.Trim();

            paramters[3].Text = "�����";
            paramters[3].Value = lblmzh.Text.Trim();

            paramters[4].Text = "����";
            paramters[4].Value = txtks.Text.Trim();

            paramters[5].Text = "��������";
            paramters[5].Value = sDate;

            paramters[6].Text = "������Ϣ";
            paramters[6].Value = deptdr["NAME"] + " λ��:" + Convertor.IsNull(deptdr["DEPTADDR"], "") + "\r\n";


            TrasenFrame.Forms.FrmReportView ff;
            ff = new TrasenFrame.Forms.FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\MZ_������.rpt", paramters, true);
        }
        //��ӡ�Һ�Ʊ Add By zp 2013-09-30
        private void PrintReport(string _ghlx, int _pdxh, mz_card card, string djsj, int fpzs, DataSet dset,
            string fph, string jydjh, string kh, int klx, decimal zje, decimal ssxj, decimal zlje, decimal ybkye,
            decimal ybzf, decimal ybzhzf, decimal ye, string yysd, decimal cwjz)
        {
            #region ��ӡ��Ʊ
            try
            {
                //��ÿ���
                string sql = " select isnull(b.RETAIL_PRICE,0) RETAIL_PRICE,d.CODE,d.ITEM_NAME from JC_KLX a left join JC_HSITEM b on a.SFXMID=b.ITEM_ID  "
                           + "  left join JC_STAT_ITEM c on c.CODE=b.STATITEM_CODE  "
                           + " left join JC_MZFP_XM d on c.mzfp_code=d.code  where a.klx=" + klx + " ";
                DataTable kftb = FrmMdiMain.Database.GetDataTable(sql);
                decimal kf = 0;
                if (kftb.Rows.Count > 0)
                    kf = decimal.Parse(kftb.Rows[0]["RETAIL_PRICE"].ToString());

                SystemCfg cfg1067 = new SystemCfg(1067);//���ƿ���ӡ��ʽ 0 ���ƿ�������ҺŷѴ�ӡ��ͬһ��Ʊ 1 ���ƿ�������Һŷѷֿ�(����ӡ�Һŷ�һ��Ʊ) 2 ���ƿ�������Һŷѷֿ�(��ӡ�Һŷ������ƿ����ڲ�ͬ��Ʊ�� Ĭ��0
                int num = 1;
                if (cfg1067.Config != "2")
                    num = 1;
                else
                    num = fpzs;

                for (int X = 0; X <= num - 1; X++)//Modify By Zj 2012-12-20 ��¼���޸�Ϊ��Ʊ��
                {

                    int ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                    int ysdm = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                    int zxks = 0;

                    string ssql = "select *,deptaddr from mz_fpb a (nolock) left join jc_dept_property b on a.ksdm=b.dept_id where fpid='" + new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()) + "'";
                    DataTable tbFp = InstanceForm.BDatabase.GetDataTable(ssql);

                    lbl_xm.Text = tbFp.Rows[0]["brxm"].ToString();
                    lbl_mzh.Text = tbFp.Rows[0]["blh"].ToString();
                    lbl_zje.Text = zje.ToString();
                    lbl_ssxj.Text = ssxj.ToString();
                    lbl_zlje.Text = zlje.ToString();
                    if (cfg1046.Config == "1") //��ӡ��Ʊ
                    {
                        //����1006���Һ�Ʊ�Ƿ�ʹ��ˮ������0=����1=��
                        if ((new TrasenFrame.Classes.SystemCfg(1006)).Config == "1")
                        {
                            try
                            {
                                #region ˮ����
                                ParameterEx[] parameters = new ParameterEx[25];
                                parameters[0].Text = "ҽԺ����";
                                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                                parameters[1].Text = "��Ʊ��";
                                parameters[1].Value = fph.Trim();

                                DateTime time = Convert.ToDateTime(djsj);

                                parameters[2].Text = "��";
                                parameters[2].Value = time.Year;

                                parameters[3].Text = "��";
                                parameters[3].Value = time.Month;

                                parameters[4].Text = "��";
                                parameters[4].Value = time.Day;

                                parameters[5].Text = "�Һ�����";
                                parameters[5].Value = _ghlx;

                                parameters[6].Text = "����";
                                parameters[6].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                                parameters[7].Text = "ҽ��";
                                parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                                parameters[8].Text = "ҽ������";
                                parameters[8].Value = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                                parameters[9].Text = "�Һ����";
                                parameters[9].Value = _pdxh;

                                PrintClass.InvoiceItem[] item = null;
                                //150316 chencan ��Ʊ��ϸ
                                //DataRow[] rows = dset.Tables[1].Select();
                                DataRow[] rows = dset.Tables[1].Select("groupid = '" + dset.Tables[0].Rows[X]["groupid"].ToString() + "'");
                                string _ghf = "";
                                string _zcf = "";
                                string _jcf = "";
                                string _clf = "";
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {

                                    item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//��Ʊ��Ŀ���

                                    //�Һ�ר����Ŀ Modify By Tany 2008-12-22
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                                    {
                                        _ghf = item[m].ItemMoney.ToString("0.00");
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                                    {
                                        _zcf = item[m].ItemMoney.ToString("0.00");
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                                    {
                                        _jcf = item[m].ItemMoney.ToString("0.00");
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                                    {
                                        _clf = item[m].ItemMoney.ToString("0.00");
                                    }
                                }

                                parameters[10].Text = "�Һŷ�";
                                parameters[10].Value = _ghf;

                                parameters[11].Text = "����";
                                parameters[11].Value = _zcf;

                                parameters[12].Text = "����";
                                parameters[12].Value = _jcf;

                                parameters[13].Text = "���Ϸ�";
                                parameters[13].Value = _clf;

                                parameters[14].Text = "Сд���";
                                parameters[14].Value = Convert.ToDecimal(Convertor.IsNull(dset.Tables[0].Rows[X]["zje"], "0")).ToString("0.00");

                                parameters[15].Text = "��д���";
                                parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                                parameters[16].Text = "�տ�Ա";
                                if (cfgsfy.Config == "1")
                                    parameters[16].Value = InstanceForm.BCurrentUser.Name;
                                else
                                    parameters[16].Value = InstanceForm.BCurrentUser.LoginCode;

                                parameters[17].Text = "��������";
                                parameters[17].Value = txtxm.Text.Trim();

                                parameters[18].Text = "�����";
                                parameters[18].Value = lblmzh.Text.Trim();

                                parameters[19].Text = "����";
                                parameters[19].Value = "";

                                parameters[20].Text = "ҽ������";
                                parameters[20].Value = lbljyh.Text.Trim();

                                parameters[21].Text = "ҽ��֧��";
                                parameters[21].Value = Convert.ToString(jsxx.TCZF);

                                parameters[22].Text = "ҽ����֧��";
                                parameters[22].Value = Convert.ToString(jsxx.ZHZF);

                                parameters[23].Text = "�ֽ�֧��";
                                parameters[23].Value = tbFp.Rows[0]["xjzf"].ToString();

                                parameters[24].Text = "ҽ�����";
                                parameters[24].Value = Convert.ToString(ybkye - jsxx.ZHZF);

                                //parameters[25].Text = "λ��";
                                //parameters[25].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                //parameters[25].Text = "���￨��";
                                //parameters[25].Value = txtkh.Text;

                                //parameters[26].Text = "λ��";
                                //parameters[26].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                //parameters[27].Text = "ҽԺ�����";
                                //parameters[27].Value = ye - (Convert.ToDecimal(tbFp.Rows[0]["cwjz"]));

                                //parameters[28].Text = "��֧�����";//�������
                                //parameters[28].Value = cwjz;


                                TrasenFrame.Forms.FrmReportView fv;

                                if (Bview == "true")
                                {
                                    fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һŷ�Ʊ.rpt", parameters);
                                    if (!fv.LoadReportSuccess)
                                    {
                                        fv.Dispose();
                                    }
                                    else
                                    {
                                        fv.Show();
                                    }
                                }
                                else
                                {
                                    //TrasenFrame.Forms.FrmReportView.DirectPrint(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һŷ�Ʊ.rpt", parameters, false, "", false);
                                    fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һŷ�Ʊ.rpt", parameters, true);
                                }

                                #endregion
                            }
                            catch
                            {
                                //modify by zouchihua 2013-7-1 �����˿���
                                #region ˮ����
                                ParameterEx[] parameters = new ParameterEx[29];
                                parameters[0].Text = "ҽԺ����";
                                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                                parameters[1].Text = "��Ʊ��";
                                parameters[1].Value = fph.Trim();

                                DateTime time = Convert.ToDateTime(djsj);

                                parameters[2].Text = "��";
                                parameters[2].Value = time.Year;

                                parameters[3].Text = "��";
                                parameters[3].Value = time.Month;

                                parameters[4].Text = "��";
                                parameters[4].Value = time.Day;

                                parameters[5].Text = "�Һ�����";
                                parameters[5].Value = _ghlx;

                                parameters[6].Text = "����";
                                parameters[6].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                                parameters[7].Text = "ҽ��";
                                parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                                parameters[8].Text = "ҽ������";
                                parameters[8].Value = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                                parameters[9].Text = "�Һ����";
                                parameters[9].Value = _pdxh;

                                PrintClass.InvoiceItem[] item = null;
                                DataRow[] rows = dset.Tables[1].Select();
                                string _ghf = "";
                                string _zcf = "";
                                string _jcf = "";
                                string _clf = "";
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {
                                    item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//��Ʊ��Ŀ���

                                    //�Һ�ר����Ŀ Modify By Tany 2008-12-22
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                                    {
                                        _ghf = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                                    {
                                        _zcf = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                                    {
                                        _jcf = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                                    {
                                        _clf = item[m].ItemMoney.ToString();
                                    }
                                }

                                parameters[10].Text = "�Һŷ�";
                                parameters[10].Value = _ghf;

                                parameters[11].Text = "����";
                                parameters[11].Value = _zcf;

                                parameters[12].Text = "����";
                                parameters[12].Value = _jcf;

                                parameters[13].Text = "���Ϸ�";
                                parameters[13].Value = _clf;

                                parameters[14].Text = "Сд���";
                                parameters[14].Value = dset.Tables[0].Rows[X]["zje"].ToString();

                                parameters[15].Text = "��д���";
                                parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                                parameters[16].Text = "�տ�Ա";
                                if (cfgsfy.Config == "1")
                                    parameters[16].Value = InstanceForm.BCurrentUser.Name;
                                else
                                    parameters[16].Value = InstanceForm.BCurrentUser.LoginCode;

                                parameters[17].Text = "��������";
                                parameters[17].Value = txtxm.Text.Trim();

                                parameters[18].Text = "�����";
                                parameters[18].Value = lblmzh.Text.Trim();

                                parameters[19].Text = "����";
                                parameters[19].Value = "";

                                parameters[20].Text = "ҽ������";
                                parameters[20].Value = lbljyh.Text.Trim();

                                parameters[21].Text = "ҽ��֧��";
                                parameters[21].Value = Convert.ToString(jsxx.TCZF);

                                parameters[22].Text = "ҽ����֧��";
                                parameters[22].Value = Convert.ToString(jsxx.ZHZF);

                                parameters[23].Text = "�ֽ�֧��";
                                parameters[23].Value = Convert.ToDecimal(Convertor.IsNull(tbFp.Rows[0]["xjzf"], "0")).ToString("0.00");

                                parameters[24].Text = "ҽ�����";
                                parameters[24].Value = Convert.ToString(ybkye - jsxx.ZHZF);
                                //add by zouchihua 2013-7-1

                                parameters[25].Text = "���￨��";
                                parameters[25].Value = txtkh.Text;

                                parameters[26].Text = "λ��";
                                parameters[26].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                parameters[27].Text = "ҽԺ�����";
                                parameters[27].Value = ye - (Convert.ToDecimal(tbFp.Rows[0]["cwjz"]));

                                parameters[28].Text = "��֧�����";//�������
                                parameters[28].Value = cwjz;

                                TrasenFrame.Forms.FrmReportView fv;

                                if (Bview == "true")
                                {
                                    fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һŷ�Ʊ.rpt", parameters);
                                    if (!fv.LoadReportSuccess)
                                    {
                                        fv.Dispose();
                                    }
                                    else
                                    {
                                        fv.Show();
                                    }
                                }
                                else
                                {
                                    //TrasenFrame.Forms.FrmReportView.DirectPrint(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һŷ�Ʊ.rpt", parameters, false, "", false);
                                    fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һŷ�Ʊ.rpt", parameters, true);
                                }

                                #endregion
                            }
                        }
                        else
                        {
                            //����1005���Һ�ʱ��Ʊ��ʹ���ĸ�Ʊ�����͵����ö�:0-�����շ�Ʊ��,1-�Һ�ר��Ʊ��
                            SystemCfg cfg1005 = new SystemCfg(1005);
                            if (cfg1005.Config == "0")
                            {
                                //����1123�����﷢Ʊ�Ƿ������·�Ʊ��ʽ 0������ 1���� Ĭ��0
                                SystemCfg cfg1123 = new SystemCfg(1123);
                                PrintClass.OPDInvoice invoice = PrintClass.PrintClass.GetOPDInvoiceInstance(cfg1123.Config);
                                #region �շѷ�Ʊ���ݸ�ֵ
                                invoice.yysd = yysd;
                                invoice.OtherInfo = "";
                                invoice.HisName = Constant.HospitalName;
                                invoice.PatientName = txtxm.Text.Trim();
                                invoice.OutPatientNo = lblmzh.Text.Trim();
                                //Add By Zj 2012-06-07 �������3035�����Ժ�  �Һ�Ʊ����������� ��ʾ������� �ص�Ϊ������ҽԺ�޸�
                                //����3035��ҽ���Űఴ����(���)��,������(���)���ÿ��Զ�����ҹ���  0=��1=�� Ĭ��Ϊ0,��Ҫ�����Ϊ1��0��Ϊ1ʱ��Ҫ�ֹ��������� 
                                if (cfg3035.Config == "1")
                                {
                                    //Modify By Zj 2012-09-10 �����ZJID �����һ�����Ҷ�������ʾ����ȷ������
                                    string zjsql = "select PBKS,pbksid,ZJID_QC from jc_mz_yspb where ysid=" + ysdm + " and BSCBZ=0 and PBSJ='" + Convert.ToDateTime(djsj).ToString("yyyy-MM-dd") + " 00:00:00'";

                                    if (Convert.ToDateTime(Convert.ToDateTime(djsj).ToShortTimeString()) <= Convert.ToDateTime("12:00"))//Add By Zj 2013-02-26 Ϊ�˷�ֹ��ʾ����ȷ����ҽ�������ڸ��������ڲ��Ƶ������Ű� �����������ж� ��ֹ����
                                        zjsql += " and pblx=1";
                                    else
                                        zjsql += " and pblx=2";

                                    DataTable zjtb = InstanceForm.BDatabase.GetDataTable(zjsql);
                                    if (zjtb.Rows.Count > 0)
                                    {
                                        if (zjtb.Rows[0]["ZJID_QC"].ToString() != "0")
                                        {
                                            //Add By Zj 2012-08-22 �ٴ���֤������ȷ��
                                            string zjmcsql = "select ZJMC from JC_ZJSZ a,JC_ZJSZ_QC b where a.ZJID_QC=b.ZJID_QC and b.deleted=0 and b.ZJID_QC=" + zjtb.Rows[0]["ZJID_QC"].ToString() + " and a.ksdm=" + zjtb.Rows[0]["pbksid"].ToString();
                                            invoice.DepartmentName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(zjmcsql), "");
                                        }
                                        else
                                            invoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                    }
                                    else
                                        invoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                }
                                else
                                    invoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                invoice.DoctorName = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);
                                invoice.InvoiceNo = "����Ʊ�ţ�" + Convert.ToString(dset.Tables[0].Rows[X]["fph"]);//Modify By Zj 2012-12-19 ���ŷ�Ʊʹ��ѭ���ķ�Ʊ��

                                invoice.TotalMoneyCN = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());
                                invoice.TotalMoneyNum = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                                if (cfgsfy.Config == "1")
                                    invoice.Payee = InstanceForm.BCurrentUser.Name;
                                else
                                    invoice.Payee = InstanceForm.BCurrentUser.LoginCode;

                                DateTime time = Convert.ToDateTime(djsj);
                                invoice.Year = time.Year;
                                invoice.Month = time.Month;
                                invoice.Day = time.Day;

                                bool bqedy = mz_sf.Bqedy(new Guid(Convertor.IsNull(tbFp.Rows[0]["yhlxid"], Guid.Empty.ToString())), InstanceForm.BDatabase);
                                if (bqedy == true && Convert.ToDecimal(tbFp.Rows[0]["yhje"]) != 0)
                                {
                                    invoice.Yhje = 0;
                                    invoice.Qfgz = 0;
                                    invoice.Ybzhzf = 0;
                                    invoice.Ybjjzf = 0;
                                    invoice.Ybbzzf = 0;
                                    invoice.Cwjz = 0;
                                    invoice.Ylkje = 0;
                                    invoice.Srje = 0;
                                    invoice.Xjzf = 0;
                                    invoice.Zpzf = 0;
                                }
                                else
                                {
                                    invoice.Yhje = Convert.ToDecimal(tbFp.Rows[0]["yhje"]);
                                    invoice.Qfgz = Convert.ToDecimal(tbFp.Rows[0]["qfgz"]);
                                    invoice.Ybzhzf = dset.Tables[0].Rows[X]["groupid"].ToString() == "�Һŷ�" ? ybzf : 0; //�ҺŷѲ���ʾҽ��֧�� 
                                    invoice.Cwjz = Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                                    invoice.Ylkje = Convert.ToDecimal(tbFp.Rows[0]["ylkzf"]);
                                    invoice.Srje = Convert.ToDecimal(tbFp.Rows[0]["srje"]);
                                    invoice.Xjzf = Convert.ToDecimal(tbFp.Rows[0]["xjzf"]);
                                    invoice.Zpzf = Convert.ToDecimal(tbFp.Rows[0]["zpzf"]);
                                }


                                invoice.Zxks = Fun.SeekDeptName(zxks, InstanceForm.BDatabase);
                                invoice.Kye = ye - invoice.Cwjz;
                                invoice.Ybkye = 0;

                                invoice.Ybkye = ybkye - ybzhzf;
                                if (invoice.Ybkye < 0)
                                    invoice.Ybkye = 0;

                                invoice.Yblx = cmbyblx.Text.Trim();
                                invoice.Ybjydjh = jydjh.Trim();
                                invoice.Klx = txtkh.Text.Trim() == "" ? "" : cmbklx.Text.Trim();
                                invoice.Klx_Bje = card.bjebz;

                                invoice.sfck = "";
                                invoice.fyck = "";
                                invoice.htdwlx = cmbdwlx.Text.Trim();
                                invoice.htdwmc = txthtdw.Text.Trim();
                                invoice.kswz = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                invoice.Klx = kh.Trim() == "" ? "" : cmbklx.Text.Trim();
                                invoice.kh = kh;
                                invoice.sfsj = Convert.ToDateTime(djsj).ToShortTimeString();
                                invoice.yysj = yysd;
                                invoice.ghjb = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-", 0) + 1);//�Һż������� Add By Zj ��ȡ�Һż��� 2012-03-06
                                if (Convert.ToDateTime(djsj).DayOfWeek == DayOfWeek.Saturday || Convert.ToDateTime(djsj).DayOfWeek == DayOfWeek.Sunday)//Add By Zj 2012-03-19 ���˫���ձ��
                                    invoice.sxrbz = "˫����";
                                else
                                    invoice.sxrbz = "";
                                if (_pdxh > 0)
                                    invoice.hzh = _pdxh.ToString();
                                invoice.sex = cmbxb.Text.Trim();

                                PrintClass.InvoiceItem[] item = null;

                                string groupid = dset.Tables[0].Rows[X]["groupid"].ToString();//Add By Zj 2012-12-19 ���ڷ���

                                DataRow[] rows = dset.Tables[1].Select("groupid = '" + groupid + "' ");//Modify By Zj 2012-12-19 ���ڷ���
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//��Ʊ��Ŀ���
                                }
                                if (rows.Length == 0 && invoice.TotalMoneyNum == 0M)
                                {
                                    item = new PrintClass.InvoiceItem[1];
                                    item[0].ItemName = "�Һŷ�";
                                    item[0].ItemMoney = 0;//��Ʊ��Ŀ���
                                }
                                invoice.Items = item;

                                PrintClass.InvoiceItemDetail[] itemdetail = null; //Modify By Tany 2008-12-20 ���ӷ�Ʊ��ϸ��Ŀ

                                //Modify By Tany 2008-12-20 ���ӷ�Ʊ��ϸ��Ŀ
                                DataRow[] rowsdetail = dset.Tables[4].Select("groupid = '" + groupid + "' ");//Modify By Zj 2012-12-19 ���ڷ���
                                itemdetail = new PrintClass.InvoiceItemDetail[rowsdetail.Length];
                                for (int m = 0; m <= rowsdetail.Length - 1; m++)
                                {
                                    itemdetail[m].ItemDetailName = rowsdetail[m]["item_name"].ToString().Trim();
                                    itemdetail[m].ItemDW = rowsdetail[m]["item_unit"].ToString().Trim();
                                    itemdetail[m].ItemGG = "";
                                    itemdetail[m].ItemJS = 1;
                                    itemdetail[m].ItemNum = Convert.ToDecimal(rowsdetail[m]["num"]);
                                    itemdetail[m].ItemPrice = Convert.ToDecimal(rowsdetail[m]["cost_price"]);
                                    itemdetail[m].ItemJE = Convert.ToDecimal(rowsdetail[m]["JE"]);
                                }
                                if (rowsdetail.Length == 0 && invoice.TotalMoneyNum == 0)
                                {
                                    itemdetail = new PrintClass.InvoiceItemDetail[1];
                                    itemdetail[0].ItemDetailName = "�Һŷ�";
                                    itemdetail[0].ItemDW = "";
                                    itemdetail[0].ItemGG = "";
                                    itemdetail[0].ItemJS = 0;
                                    itemdetail[0].ItemNum = 0;
                                    itemdetail[0].ItemPrice = 0;
                                    itemdetail[0].ItemJE = 0;
                                }
                                invoice.ItemDetail = itemdetail;


                                if (Bview != "true")
                                    invoice.Print();
                                else
                                    invoice.Preview();
                                #endregion

                            }
                            else
                            {
                                #region �Һŷ�Ʊ
                                PrintClass.RegisterInvoice Rinvoice = PrintClass.PrintClass.GetRegisterInvoice(cfg1005.Config);

                                Rinvoice.OtherInfo = "";
                                Rinvoice.yysd = yysd;
                                Rinvoice.kh = kh;
                                Rinvoice.HisName = Constant.HospitalName;
                                Rinvoice.PatientName = txtxm.Text.Trim();
                                Rinvoice.OutPatientNo = lblmzh.Text.Trim();
                                Rinvoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                Rinvoice.Pdxh = _pdxh;//�Ŷ���� Modify by Tany 2008-12-26
                                Rinvoice.DoctorName = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);
                                Rinvoice.InvoiceNo = "����Ʊ�ţ�" + fph.Trim();

                                Rinvoice.TotalMoneyCN = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());
                                Rinvoice.TotalMoneyNum = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                                if (cfgsfy.Config == "1")
                                    Rinvoice.Payee = InstanceForm.BCurrentUser.Name;
                                else
                                    Rinvoice.Payee = InstanceForm.BCurrentUser.LoginCode;

                                DateTime time = Convert.ToDateTime(djsj);
                                Rinvoice.Year = time.Year;
                                Rinvoice.Month = time.Month;
                                Rinvoice.Day = time.Day;
                                Rinvoice.yysj = yysd; //Add by zp 2013-10-31
                                Rinvoice.Yhje = Convert.ToDecimal(tbFp.Rows[0]["yhje"]);
                                Rinvoice.Qfgz = Convert.ToDecimal(tbFp.Rows[0]["qfgz"]);
                                Rinvoice.Ybzhzf = ybzf;
                                Rinvoice.Cwjz = Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                                Rinvoice.Ylkje = Convert.ToDecimal(tbFp.Rows[0]["ylkzf"]);
                                Rinvoice.Srje = Convert.ToDecimal(tbFp.Rows[0]["srje"]);
                                Rinvoice.Xjzf = Convert.ToDecimal(tbFp.Rows[0]["xjzf"]);
                                Rinvoice.Zxks = Fun.SeekDeptName(zxks, InstanceForm.BDatabase);
                                Rinvoice.Kye = ye - zje;

                                //add by jiangzf ����λ��
                                Rinvoice.kswz = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                //Rinvoice.Ybkye = 0;
                                Rinvoice.Ybkye = ybkye - ybzhzf;
                                if (Rinvoice.Ybkye < 0)
                                    Rinvoice.Ybkye = 0;

                                Rinvoice.Yblx = cmbyblx.Text.Trim();
                                Rinvoice.Ybjydjh = jydjh.ToString().Trim();
                                Rinvoice.Klx = txtkh.Text.Trim() == "" ? "" : cmbklx.Text.Trim();
                                Rinvoice.Klx_Bje = card.bjebz;

                                //Modify By Tany 2008-12-26
                                Rinvoice.RegisterType = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                                PrintClass.InvoiceItem[] item = null;

                                DataRow[] rows = dset.Tables[1].Select();
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {
                                    item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//��Ʊ��Ŀ���

                                    //�Һ�ר����Ŀ Modify By Tany 2008-12-22
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                                    {
                                        Rinvoice.RegisterFee = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                                    {
                                        Rinvoice.ExamineFee = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                                    {
                                        Rinvoice.JerqueFee = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                                    {
                                        Rinvoice.MaterialFee = item[m].ItemMoney.ToString();
                                    }
                                }
                                Rinvoice.Items = item;
                                //Modify by Tany 2008-12-26 ���ӹҺ�����
                                Rinvoice.Ghlx = _ghlx;

                                if (Bview != "true")
                                    Rinvoice.Print();
                                else
                                    Rinvoice.Preview();
                                #endregion
                            }
                        }
                    }
                    else if (cfg1046.Config == "2")
                    {
                        #region СƱ
                        ParameterEx[] parameters = new ParameterEx[30];
                        parameters[0].Text = "ҽԺ����";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                        parameters[1].Text = "��Ʊ��";
                        parameters[1].Value = fph.Trim();

                        DateTime time = Convert.ToDateTime(djsj);

                        parameters[2].Text = "��";
                        parameters[2].Value = time.Year;

                        parameters[3].Text = "��";
                        parameters[3].Value = time.Month;

                        parameters[4].Text = "��";
                        parameters[4].Value = time.Day;

                        parameters[5].Text = "�Һ�����";
                        parameters[5].Value = _ghlx;

                        parameters[6].Text = "����";
                        parameters[6].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                        parameters[7].Text = "ҽ��";
                        parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                        parameters[8].Text = "ҽ������";
                        parameters[8].Value = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                        parameters[9].Text = "�Һ����";
                        parameters[9].Value = _pdxh;

                        PrintClass.InvoiceItem[] item = null;
                        DataRow[] rows = dset.Tables[1].Select();
                        string _ghf = "0";
                        string _zcf = "0";
                        string _jcf = "0";
                        string _clf = "0";
                        item = new PrintClass.InvoiceItem[rows.Length];
                        for (int m = 0; m <= rows.Length - 1; m++)
                        {
                            item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                            item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                            item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//��Ʊ��Ŀ���

                            //add  by zouchihua 2013-3-31 ��ÿ��ѵķ�Ʊ��Ŀ,�����Ʊ����2�����Ҵ򿨷���СƱ

                            if (fpzs == 2 && X == 0 && item[m].ItemCode.Trim() == kftb.Rows[0]["code"].ToString().Trim())
                            {
                                if (rows[m]["groupid"].ToString().Trim() == "���ƿ���")
                                    continue;
                            }
                            if (fpzs == 2 && X == 1) //X=1˵���ڶ���ѭ��,ֻ�п���
                            {
                                if (item[m].ItemCode.Trim() == kftb.Rows[0]["code"].ToString().Trim())
                                {
                                    item[m].ItemMoney = kf;
                                    //item[m].ItemName=kf.ToString()+"(����)";
                                }
                                else
                                    item[m].ItemMoney = 0;
                            }
                            //�Һ�ר����Ŀ Modify By Tany 2008-12-22
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                            {
                                _ghf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                            {
                                _zcf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                            {
                                _jcf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                            {
                                _clf = item[m].ItemMoney.ToString();
                            }

                        }
                        try
                        {
                            //���ӹҺŷѱ�ע
                            if (fpzs == 2 && X == 1)
                            {
                                if (Convert.ToDecimal(_ghf == "" ? "0" : _ghf) > 0)
                                    _ghf += "(����)";
                                if (Convert.ToDecimal(_zcf == "" ? "0" : _zcf) > 0)
                                    _zcf += "(����)";
                                if (Convert.ToDecimal(_jcf == "" ? "0" : _jcf) > 0)
                                    _jcf += "(����)";
                                if (Convert.ToDecimal(_clf == "" ? "0" : _clf) > 0)
                                    _clf += "(����)";
                            }
                        }
                        catch
                        {

                        }

                        parameters[10].Text = "�Һŷ�";
                        parameters[10].Value = _ghf;

                        parameters[11].Text = "����";
                        parameters[11].Value = _zcf;

                        parameters[12].Text = "����";
                        parameters[12].Value = _jcf;

                        parameters[13].Text = "���Ϸ�";
                        parameters[13].Value = _clf;

                        parameters[14].Text = "Сд���";
                        parameters[14].Value = dset.Tables[0].Rows[X]["zje"].ToString();

                        parameters[15].Text = "��д���";
                        parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                        parameters[16].Text = "�տ�Ա";
                        if (cfgsfy.Config == "1")
                            parameters[16].Value = InstanceForm.BCurrentUser.Name;
                        else
                            parameters[16].Value = InstanceForm.BCurrentUser.LoginCode;

                        parameters[17].Text = "��������";
                        parameters[17].Value = txtxm.Text.Trim();

                        parameters[18].Text = "�����";
                        parameters[18].Value = lblmzh.Text.Trim();

                        parameters[19].Text = "����";
                        parameters[19].Value = "";

                        parameters[20].Text = "ҽ������";
                        parameters[20].Value = lbljyh.Text.Trim();

                        parameters[21].Text = "ҽ��֧��";
                        parameters[21].Value = Convert.ToString(jsxx.TCZF);

                        parameters[22].Text = "ҽ����֧��";
                        parameters[22].Value = Convert.ToString(jsxx.ZHZF);

                        parameters[23].Text = "�ֽ�֧��";
                        parameters[23].Value = Convert.ToDecimal(Convertor.IsNull(tbFp.Rows[0]["xjzf"], "0")).ToString("0.00");

                        parameters[24].Text = "ҽ�����";
                        parameters[24].Value = Convert.ToString(ybkye - jsxx.ZHZF);


                        parameters[25].Text = "����";
                        parameters[25].Value = txtkh.Text;

                        parameters[26].Text = "����ʱ��";
                        parameters[26].Value = yysd;

                        parameters[27].Text = "ҽԺ�����"; //add by zp 2013-12-20
                        parameters[27].Value = ye - (Convert.ToDecimal(tbFp.Rows[0]["cwjz"]));

                        parameters[28].Text = "��֧�����";//�������
                        parameters[28].Value = cwjz;

                        parameters[29].Text = "λ��";
                        parameters[29].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                        TrasenFrame.Forms.FrmReportView fv;

                        if (Bview == "true")
                        {
                            fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һ�СƱ.rpt", parameters);
                            if (!fv.LoadReportSuccess)
                            {
                                fv.Dispose();
                            }
                            else
                            {
                                fv.Show();
                            }
                        }
                        else
                        {
                            //TrasenFrame.Forms.FrmReportView.DirectPrint(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һŷ�Ʊ.rpt", parameters, false, "", false);
                            fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һ�СƱ.rpt", parameters, true);
                        }
                        /*add by zch 2013-03-26 ����СƱ��ӡ�Ƿ����һ���ϣ�ֻ��ֽһ�Σ�0=�� ��1=�� */
                        // if (cfg1078.Config.Trim() == "1")//������
                        // fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һ�СƱ.rpt", parameters, true);
                        #endregion
                    }
                }
                //��СƱ add by zouchihua 2013-3-29
                for (int X = 0; X <= (new SystemCfg(1067).Config != "2" ? 1 : fpzs) - 1; X++)//Modify By Zj 2012-12-20 ��¼���޸�Ϊ��Ʊ��
                {
                    int ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                    int ysdm = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                    string ssql = "select *,deptaddr from mz_fpb a (nolock) left join jc_dept_property b on a.ksdm=b.dept_id where fpid='" + new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()) + "'";
                    DataTable tbFp = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (cfg1046.Config == "2")
                    {
                        #region СƱ
                        ParameterEx[] parameters = new ParameterEx[30];
                        parameters[0].Text = "ҽԺ����";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                        parameters[1].Text = "��Ʊ��";
                        parameters[1].Value = fph.Trim();

                        DateTime time = Convert.ToDateTime(djsj);

                        parameters[2].Text = "��";
                        parameters[2].Value = time.Year;

                        parameters[3].Text = "��";
                        parameters[3].Value = time.Month;

                        parameters[4].Text = "��";
                        parameters[4].Value = time.Day;

                        parameters[5].Text = "�Һ�����";
                        parameters[5].Value = _ghlx;

                        parameters[6].Text = "����";
                        parameters[6].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                        parameters[7].Text = "ҽ��";
                        parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                        parameters[8].Text = "ҽ������";
                        parameters[8].Value = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                        parameters[9].Text = "�Һ����";
                        parameters[9].Value = _pdxh;

                        PrintClass.InvoiceItem[] item = null;
                        DataRow[] rows = dset.Tables[1].Select();
                        string _ghf = "";
                        string _zcf = "";
                        string _jcf = "";
                        string _clf = "";
                        item = new PrintClass.InvoiceItem[rows.Length];
                        for (int m = 0; m <= rows.Length - 1; m++)//Modify By zp 2013-09-30
                        {
                            item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                            item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                            item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//��Ʊ��Ŀ���
                            //add  by zouchihua 2013-3-31 ��ÿ��ѵķ�Ʊ��Ŀ,�����Ʊ����2�����Ҵ򿨷���СƱ

                            if (fpzs == 2 && X == 0 && item[m].ItemCode.Trim() == kftb.Rows[0]["code"].ToString().Trim())
                            {
                                if (rows[m]["groupid"].ToString().Trim() == "���ƿ���")
                                    continue;

                            }
                            else
                                if (fpzs == 2 && X == 1) //X=1˵���ڶ���ѭ��,ֻ�п���
                                {
                                    if (item[m].ItemCode.Trim() == kftb.Rows[0]["code"].ToString().Trim())
                                        item[m].ItemMoney = kf;
                                    else
                                        item[m].ItemMoney = 0;
                                }
                            //�Һ�ר����Ŀ Modify By Tany 2008-12-22
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                            {
                                _ghf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                            {
                                _zcf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                            {
                                _jcf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                            {
                                _clf = item[m].ItemMoney.ToString();
                            }


                        }
                        try
                        {
                            //���ӹҺŷѱ�ע
                            if (fpzs == 2 && X == 1)
                            {
                                if (Convert.ToDecimal(_ghf == "" ? "0" : _ghf) > 0)
                                    _ghf += "(����)";
                                if (Convert.ToDecimal(_zcf == "" ? "0" : _zcf) > 0)
                                    _zcf += "(����)";
                                if (Convert.ToDecimal(_jcf == "" ? "0" : _jcf) > 0)
                                    _jcf += "(����)";
                                if (Convert.ToDecimal(_clf == "" ? "0" : _clf) > 0)
                                    _clf += "(����)";
                            }
                        }
                        catch
                        {

                        }
                        parameters[10].Text = "�Һŷ�";
                        parameters[10].Value = _ghf;

                        parameters[11].Text = "����";
                        parameters[11].Value = _zcf;

                        parameters[12].Text = "����";
                        parameters[12].Value = _jcf;

                        parameters[13].Text = "���Ϸ�";
                        parameters[13].Value = _clf;

                        parameters[14].Text = "Сд���";
                        parameters[14].Value = dset.Tables[0].Rows[X]["zje"].ToString();

                        parameters[15].Text = "��д���";
                        parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                        parameters[16].Text = "�տ�Ա";
                        if (cfgsfy.Config == "1")
                            parameters[16].Value = InstanceForm.BCurrentUser.Name;
                        else
                            parameters[16].Value = InstanceForm.BCurrentUser.LoginCode;

                        parameters[17].Text = "��������";
                        parameters[17].Value = txtxm.Text.Trim();

                        parameters[18].Text = "�����";
                        parameters[18].Value = lblmzh.Text.Trim();

                        parameters[19].Text = "����";
                        parameters[19].Value = "";

                        parameters[20].Text = "ҽ������";
                        parameters[20].Value = lbljyh.Text.Trim();

                        parameters[21].Text = "ҽ��֧��";
                        parameters[21].Value = Convert.ToString(jsxx.TCZF);

                        parameters[22].Text = "ҽ����֧��";
                        parameters[22].Value = Convert.ToString(jsxx.ZHZF);

                        parameters[23].Text = "�ֽ�֧��";
                        parameters[23].Value = Convert.ToDecimal(Convertor.IsNull(tbFp.Rows[0]["xjzf"], "0")).ToString("0.00");

                        parameters[24].Text = "ҽ�����";
                        parameters[24].Value = Convert.ToString(ybkye - jsxx.ZHZF);

                        parameters[25].Text = "����";
                        parameters[25].Value = txtkh.Text;
                        TrasenFrame.Forms.FrmReportView fv;

                        parameters[26].Text = "����ʱ��";
                        parameters[26].Value = yysd;

                        parameters[27].Text = "ҽԺ�����"; //add by zp 2013-12-20
                        parameters[27].Value = ye - (Convert.ToDecimal(tbFp.Rows[0]["cwjz"]));

                        parameters[28].Text = "��֧�����";//add by jiangzf�������
                        parameters[28].Value = cwjz;

                        parameters[29].Text = "λ��";//add by jiangzf 
                        parameters[29].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");


                        /*add by zch 2013-03-26 ����СƱ��ӡ�Ƿ����һ���ϣ�ֻ��ֽһ�Σ�0=�� ��1=�� */
                        if (cfg1078.Config.Trim() == "1")//������
                            fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һ�СƱ.rpt", parameters, true);
                        #endregion
                    }
                }

                if (fpzs == 2 && new SystemCfg(1067).Config == "3")
                {

                    #region СƱ
                    ParameterEx[] parameters = new ParameterEx[10];
                    parameters[0].Text = "ҽԺ����";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                    DateTime time = Convert.ToDateTime(djsj);

                    parameters[1].Text = "��";
                    parameters[1].Value = time.Year;

                    parameters[2].Text = "��";
                    parameters[2].Value = time.Month;

                    parameters[3].Text = "��";
                    parameters[3].Value = time.Day;


                    parameters[4].Text = "Сд���";
                    parameters[4].Value = kf.ToString();

                    parameters[5].Text = "��д���";
                    parameters[5].Value = Money.NumToChn(kf.ToString());

                    parameters[6].Text = "�տ�Ա";
                    if (cfgsfy.Config == "1")
                        parameters[6].Value = InstanceForm.BCurrentUser.Name;
                    else
                        parameters[6].Value = InstanceForm.BCurrentUser.LoginCode;

                    parameters[7].Text = "��������";
                    parameters[7].Value = txtxm.Text.Trim();


                    parameters[8].Text = "�ֽ�֧��";
                    parameters[8].Value = kf.ToString("0.00");


                    parameters[9].Text = "����";
                    parameters[9].Value = txtkh.Text;

                    TrasenFrame.Forms.FrmReportView fv;

                    if (Bview == "true")
                    {
                        fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\���ƿ���.rpt", parameters);
                        if (!fv.LoadReportSuccess)
                        {
                            fv.Dispose();
                        }
                        else
                        {
                            fv.Show();
                        }
                    }
                    else
                    {
                        fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\���ƿ���.rpt", parameters, true);
                    }
                    #endregion
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        private bool MatchAge()
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtks.Text.Trim()))
                    return false;
                int dept_id = Convert.ToInt32(this.txtks.Tag);
                DateTime birth = this.dtpcsrq.Value;

                if (string.IsNullOrEmpty(cfg1088.Config))
                    return true;

                string[] par_match = cfg1088.Config.Split(',');
                foreach (string par in par_match)
                {
                    string[] par_m = par.Split(':');
                    if (par_m.Length < 1) return true;

                    if (int.Parse(par_m[0]) == dept_id) /*�뵱ǰ����ƥ�� ���жϻ��������Ƿ�С�ڲ������õ�����*/
                    {
                        // DateTime now_time = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                        // string age = TrasenClasses.GeneralClasses.Age.GetAgeString(birth, now_time, 1);
                        string age = this.txtnl.Text;
                        switch (this.cmbDW.Text.Trim())
                        {
                            case "��":
                                if (int.Parse(age) > int.Parse(par_m[1]))
                                {
                                    MessageBox.Show("��ǰ���������˻��ߵĹҺ�����!������" + par_m[1] + "�����ڲ�����ҵ�ǰ���Һ�");
                                    return false;
                                }
                                break;
                            default:
                                return true;
                        }
                        break;
                    }

                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("MatchAge���������쳣!ԭ��:" + ea.Message, "����");
            }
            return true;
        }


        /// <summary>
        /// ���ɴ���������
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="klx"></param>
        /// <returns></returns>
        private DataTable GetGroupCf(DataSet dset, int klx)
        {
            if (klx > 0)
            {
                string ssql = "select sfxmid from jc_klx where klx=" + klx.ToString();//�ҵ����շ�ID
                int ksfxmid = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(ssql));
                DataTable grouptb = dset.Tables[4].Clone();//��¡�շ���ϸ��
                grouptb.Columns.Add("����ID", Type.GetType("System.String"));//��ӷ���ID��
                grouptb.Columns.Add("��Ʊ����CODE", Type.GetType("System.String"));//��ӷ�Ʊ���������
                grouptb.Columns.Add("��Ʊ����NAME", Type.GetType("System.String"));//��ӷ�Ʊ����������
                grouptb.Columns.Add("ͳ�ƴ���Ŀ����", Type.GetType("System.String"));//���ͳ�ƴ���Ŀ������
                for (int i = 0; i < dset.Tables[4].Rows.Count; i++)//ѭ���������¡��
                {
                    DataRow dr = grouptb.NewRow();
                    dr["ITEM_ID"] = dset.Tables[4].Rows[i]["ITEM_ID"];
                    dr["ITEM_NAME"] = dset.Tables[4].Rows[i]["ITEM_NAME"];
                    dr["ITEM_UNIT"] = dset.Tables[4].Rows[i]["ITEM_UNIT"];
                    dr["cost_price"] = dset.Tables[4].Rows[i]["cost_price"];
                    dr["num"] = dset.Tables[4].Rows[i]["num"];
                    dr["je"] = dset.Tables[4].Rows[i]["je"];
                    dr["yhje"] = dset.Tables[4].Rows[i]["yhje"];
                    dr["py_code"] = dset.Tables[4].Rows[i]["py_code"];
                    dr["wb_code"] = dset.Tables[4].Rows[i]["wb_code"];
                    dr["std_code"] = dset.Tables[4].Rows[i]["std_code"];
                    string fpsql = "SELECT A.CODE,A.ITEM_NAME,B.ITEM_NAME AS STATNAME FROM JC_MZFP_XM A INNER JOIN  JC_STAT_ITEM B ON B.MZFP_CODE=A.CODE WHERE B.CODE='" + dset.Tables[4].Rows[i]["statitem_code"].ToString() + "' ";
                    DataTable fptb = InstanceForm.BDatabase.GetDataTable(fpsql);
                    if (fptb.Rows.Count != 1)
                    {
                        MessageBox.Show("ͳ�ƴ���Ŀ�����ķ�Ʊ��Ŀ�������һ�����߲����ڶ�Ӧ��ϵ�����ܽ����շѲ���������ϵ����Ա������ݣ�", "��ʾ");
                        return null;
                    }
                    dr["��Ʊ����CODE"] = fptb.Rows[0]["CODE"].ToString();
                    dr["��Ʊ����NAME"] = fptb.Rows[0]["ITEM_NAME"].ToString();
                    dr["statitem_code"] = dset.Tables[4].Rows[i]["statitem_code"];
                    dr["ͳ�ƴ���Ŀ����"] = fptb.Rows[0]["STATNAME"].ToString();
                    dr["hiscode"] = dset.Tables[4].Rows[i]["hiscode"];
                    dr["��Ŀ��Դ"] = dset.Tables[4].Rows[i]["��Ŀ��Դ"];
                    if (ksfxmid == Convert.ToInt32(dset.Tables[4].Rows[i]["ITEM_ID"]))//������ڿ���ID ����ID����Ϊ���� ���������Ϊ�Һŷ�
                        dr["����ID"] = "����";
                    else
                        dr["����ID"] = "�Һŷ�";
                    grouptb.Rows.Add(dr);
                }
                return grouptb;
            }
            else
                return null;
        }
        /// <summary>
        /// סԺǷ�Ѽ��
        /// </summary>
        /// <param name="brxxid"></param>
        /// <param name="xm"></param>
        private bool CheckZyFee(Guid brxxid, string xm)
        {
            //add by wangzhi 2010-10-05
            //�����жϲ����Ƿ�����סԺ����Ƿ�ѳ�Ժ������У�������ʾ
            string ssq = "";
            SystemCfg cfg = new SystemCfg(1044);
            if (cfg.Config.Trim() == "1")
            {
                SystemCfg cfg1045 = new SystemCfg(1045);
                if (cfg1045.Config.Trim() == "1")
                {

                    ssq = @"select top 1 b.patient_id,lack_fee,discharge_bdate,discharge_edate
                    from zy_discharge a ,zy_inpatient b 
                    where a.inpatient_id=b.inpatient_id
                        and a.ntype=2 and a.cancel_bit=0 and lack_fee>0
                        and patient_id = '" + brxxid.ToString() + "' order by a.discharge_date desc";
                }
                else if (cfg1045.Config.Trim() == "2")
                {
                    ssq = @"select top 1 b.patient_id,lack_fee,discharge_bdate,discharge_edate
                    from zy_discharge a ,zy_inpatient b ,yy_brxx c
                    where a.inpatient_id=b.inpatient_id and b.patient_id=c.brxxid
                        and a.ntype=2 and a.cancel_bit=0 and lack_fee>0
                        and c.brxm = '" + xm + "' order by a.discharge_date desc";
                }
                DataRow drZyqf = InstanceForm.BDatabase.GetDataRow(ssq);
                if (drZyqf != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("�ò�������");
                    sb.Append(Convert.ToDateTime(drZyqf["discharge_bdate"]).ToString("yyyy-MM-dd HH:mm;ss"));
                    sb.Append("��");
                    sb.Append(Convert.ToDateTime(drZyqf["discharge_edate"]).ToString("yyyy-MM-dd HH:mm;ss"));
                    sb.Append("�ڱ�ԺסԺ");
                    sb.Append(",������Ƿ�ѳ�Ժ��ʽ��Ժ��Ƿ�ѣ�" + Convert.ToDecimal(drZyqf["lack_fee"]).ToString() + "Ԫ��");
                    sb.Append("\r\n");
                    sb.Append("�Ƿ�����Һţ�");

                    if (MessageBox.Show(sb.ToString(), "Ƿ�Ѳ���", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return false;
                    else
                        return true;
                }
            }
            return true;
            //end add
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 22)
            {
                txtkh.Text = "";
                e.Handled = true;
                return;

            }

            if ((int)e.KeyChar != 13)
            {
                _isCreateNewCard = false; //Add By tany2010-09-18
                return;
            }

            if (txtkh.Text.Trim() == "")
            {
                //Add By tany2010-09-18
                _isCreateNewCard = false;
                if (sender != null)
                {
                    SendKeys.Send("{TAB}");
                }
                return;
            }
            if (cfg1060.Config == "0")//������1060 ����0  �������а���Ӣ����ĸ��ʱ����֤���������� Add By Zj 2012-05-10
            {
                if (!Convertor.IsNumeric(txtkh.Text.Trim()))
                {
                    MessageBox.Show("��������ȷ�Ŀ���!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtkh.SelectAll();
                    return;
                }
            }


            int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
            txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase);
            if (!Isyy) //add by zp 2014-03-26 ����Ƿ�ԤԼ�ľ���ղ�����Ϣ���� show������������Ϣ��
            {
                txtkh.Text = ToDBC(txtkh.Text);
                txtxm.Text = "";
                cmbxb.Text = "";
                txtnl.Text = "";
                cmbDW.SelectedIndex = 0;
                txtgrlxfs.Text = "";
                txtjtdz.Text = "";
            }
            this.Tag = Guid.Empty.ToString();
            //ʹ�������ӡ���Ϊ��Щ���Ǽ��˵�û�в�����Ϣ��ֻ�гֿ�����Ϣ
            string ssq = @"select *,dbo.FUN_ZY_SEEKSEXNAME(xb) �Ա�,brlx from YY_KDJB a inner join YY_BRXX b 
                            on a.brxxid=b.brxxid where a.klx=" + klx + " and a.kh='" + txtkh.Text + "'  and a.ZFBZ=0 ";
            tbk = InstanceForm.BDatabase.GetDataTable(ssq);
            if (tbk.Rows.Count == 0) //û���ҵ�������Ϣ�Ϳ���Ϣ
            {
                if (New_Card != "true")
                {
                    this.Tag = Guid.Empty.ToString();
                    MessageBox.Show("û���ҵ�����Ϣ����ȷ�Ͽ����Ƿ���ȷ��û������");
                    return;
                }
                else
                {
                    if (cfg1161.Config == "1")
                    {
                        MessageBox.Show("����1161����ʱ, �������ڴ˴������¿�ҵ��", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    this.Tag = Guid.Empty.ToString();
                    if (!Isyy) //Add by zp  2014-03-26 ������޿�ԤԼ�� ����Ҫ����дһ�β�����Ϣ��
                    {
                        ts_mz_kgl.Frmbrkdj f = new ts_mz_kgl.Frmbrkdj(_menuTag, "������Ϣ�Ǽ�", _mdiParent, Guid.Empty, Guid.Empty, InstanceForm.BDatabase);
                        f.txtkh.Text = txtkh.Text;
                        f.txtbrxm.Text = "δд��";
                        f.cmbklx.SelectedValue = cmbklx.SelectedValue;
                        //if (f.txtbrxm.Enabled == true) f.txtbrxm.Focus();

                        //add by wangzhi 2010-10-27
                        //���ò��˵ǼǶԻ���Ϊ��ʱ���没����Ϣ���ڵ���Һź�һ������
                        f.DelaySave = true;
                        if (f.ShowDialog() == DialogResult.Cancel)
                        {
                            ControlEnable();
                            butnew_Click(sender, e);
                            return;
                        }
                        _new_brxx_kxx = f.Brdjxx;
                        //add by cc 2014-04-24
                        yy_brxx_bc = f.yy_brxx_bc;
                        //end add
                        ShowBrxx();
                    }
                    //end add

                    //comment by wangzhi 2010-10-27
                    //if (f.brxxid != Guid.Empty)
                    //    txtkh_KeyPress(sender, e);
                    //end comment

                    this.RechargeWithNewCard(klx, ref _new_brxx_kxx);

                    //Add By tany2010-09-18
                    _isCreateNewCard = true;
                    txtks.Focus();
                    return;
                }
            }
            else
            {
                //���ڴ���ԤԼ���˹Һţ���ˢ�����˲���ԤԼ����,ȡ��ԤԼ״̬,���������Һ�״̬
                if (Isyy && tbk.Rows[0]["brxm"].ToString() != txtxm.Text.Trim())
                {
                    Isyy = false;
                    butqh.Tag = "";
                    butqh.BackColor = Color.WhiteSmoke;
                    txtks.Text = "";
                    txtys.Text = "";
                    txtks.Enabled = true;
                    cmbghjb.Enabled = true;
                    txtys.Enabled = true;
                    treeView1.Enabled = true;
                }
                _new_brxx_kxx = null;  // add by wangzhi 2010-10-27
                // ���ͨ�����ҵ�������Ϣ�����²��˵İ쿨��Ϣ���������˻�����Ϣ������Ϣ��֮ΪNull

                if (new SystemCfg(1137).Config == "1")
                {
                    DataTable dt = mz_ghxx.GetLastestGhxx(txtkh.Text.Trim(), klx, InstanceForm.BDatabase);
                    if (dt.Rows.Count == 0)
                    {
                        label22.Text = "";
                        //return;
                    }
                    else
                    {
                        label22.Text = "�ϴιҺſ��ң�" + dt.Rows[0]["ghks"].ToString() + ",����ҽ����" + dt.Rows[0]["jzys"].ToString();
                    }
                }
            }
            //else
            //{
            //    throw new Exception("����,û���ҵ�������Ϣ");
            //}

            if (Modif_ini == "true")
            {
                txtxm.Enabled = false;
                cmbxb.Enabled = false;
                txtnl.Enabled = false;
                cmbDW.Enabled = false;
                txtgrlxfs.Enabled = false;
                txtjtdz.Enabled = false;
            }
            else
            {
                txtxm.Enabled = true;
                cmbxb.Enabled = true;
                txtnl.Enabled = true;
                cmbDW.Enabled = true;
                txtgrlxfs.Enabled = true;
                txtjtdz.Enabled = true;
            }

            if (tbk.Rows.Count > 1)
            {
                MessageBox.Show("�ҵ�����ͬʱ��Ч�Ŀ�,���ϵͳ����Ա��ϵ");
                return;
            }
            if (Convert.ToInt16(tbk.Rows[0]["sdbz"]) == 1)
            {
                MessageBox.Show("���ſ��ѱ�����,��������.���ȼ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Getghzs(new Guid(tbk.Rows[0]["kdjid"].ToString()));

            if (xm_ini == "true") txtxm.Enabled = false;
            if (xb_ini == "true") cmbxb.Enabled = false;
            if (nl_ini == "true") { txtnl.Enabled = false; cmbDW.Enabled = false; }
            if (lxfs_ini == "true") txtgrlxfs.Enabled = false;
            if (jtdz_ini == "true") txtjtdz.Enabled = false;

            lblkye.Text = tbk.Rows[0]["kye"].ToString();
            txtxm.Text = Convertor.IsNull(tbk.Rows[0]["brxm"], "");
            if (txtxm.Text.Trim() == "")
                txtxm.Text = Convertor.IsNull(tbk.Rows[0]["CKRXM"], "");
            txtgrlxfs.Text = Convertor.IsNull(tbk.Rows[0]["BRLXFS"], "");
            txtjtdz.Text = Convertor.IsNull(tbk.Rows[0]["JTDZ"], "");
            cmbxb.Text = Convertor.IsNull(tbk.Rows[0]["�Ա�"], "");
            lblgzdw.Text = Convertor.IsNull(tbk.Rows[0]["gzdw"], "");
            cmbbrlx.SelectedValue = Convertor.IsNull(tbk.Rows[0]["brlx"], "");


            //����Żݷ���
            AddYhlx();

            if (Convertor.IsNull(tbk.Rows[0]["csrq"], "") != "")
            {
                txtnl.Text = DateManager.DateToAge(Convert.ToDateTime(tbk.Rows[0]["csrq"]), InstanceForm.BDatabase).AgeNum.ToString();
                dtpcsrq.Value = Convert.ToDateTime(tbk.Rows[0]["csrq"]);
                AutoSelectGhjb();
            }
            this.Tag = Convertor.IsNull(tbk.Rows[0]["brxxid"], Guid.Empty.ToString());

            if (Convert.ToInt16(tbk.Rows[0]["zbbz"]) == 1)
            {
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbk.Rows[0]["zbks"]), InstanceForm.BDatabase);
                txtks.Tag = tbk.Rows[0]["zbks"].ToString();
                cmbghjb.SelectedValue = tbk.Rows[0]["ZBJB"].ToString() == "0" ? "1" : tbk.Rows[0]["ZBJB"].ToString();
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbk.Rows[0]["ZBYS"]), InstanceForm.BDatabase);
                txtys.Tag = tbk.Rows[0]["ZBYS"].ToString();
            }

            //������ ����
            string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.���, "");//add by zouchihua 2013-6-24 ����֮ǰ�����
                call.Call(ts_call.DmType.����, txtxm.Text.Trim());
            }

            txtks.Focus();

            //if (sender != null)
            //{
            //    SendKeys.Send("{TAB}");

            //}
        }
        /// <summary>
        /// ͨ�����������Զ�ѡ��Һż��� Add By zp 2013-09-04
        /// </summary>
        private void AutoSelectGhjb()
        {
            try
            {
                string age = this.txtnl.Text;
                int i_age = 0;
                int _ghjb = -1;
                if (this.cmbDW.Text.Trim() == "��" && (!string.IsNullOrEmpty(age)))
                    i_age = int.Parse(age);
                _ghjb = ts_mz_class.Fun.SelectDocLevelByPatAge(i_age, this.dt_AgeToDocLevel);
                if (_ghjb > -1)
                    this.cmbghjb.SelectedValue = _ghjb;
            }
            catch (Exception ea)
            {
                MessageBox.Show("����AutoSelectGhjb�����쳣!ԭ��:" + ea.Message);
            }
        }

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {

            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "��������", "������", "ƴ����", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtks;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtks.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtks.Text = f.SelectDataRow["name"].ToString().Trim();
                    GetXh(true);
                    if (cfg1058.Config == "0")
                    {
                        Tbys = Fun.GetGhys(Convert.ToInt32(txtks.Tag), 0, InstanceForm.BDatabase);
                    }
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtks.Text.Trim() == "")
                {
                    txtks.Focus();
                    return;
                }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtys_KeyPress(object sender, KeyPressEventArgs e)
        {

            Control control = (Control)sender;

            if ((int)e.KeyChar == 8)
            {
                txtys.Tag = "0";
                txtys.Text = "";
                return;
            }

            if ((int)e.KeyChar == 13 && Convertor.IsNumeric(txtys.Text.Trim()) == true)
            {
                DataRow[] rows = Tbys.Select("code='" + txtys.Text.Trim() + "'", "");
                if (rows.Length == 1)
                {
                    txtys.Tag = rows[0]["employee_id"].ToString();
                    txtys.Text = rows[0]["name"].ToString().Trim();
                    GetDoctorPbxx(rows[0]["employee_id"].ToString());
                    //Add By Zj 2012-02-16 ����ҽ��������ʾԤԼ������Ϣ
                    GetXh(true);
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                    return;
                }
                else
                {
                    txtys.Tag = "0";
                    txtys.Text = "";
                    return;
                }
            }

            if ((int)e.KeyChar != 13 && Convertor.IsNumeric(e.KeyChar.ToString()) == false)
            {
                string[] headtext = new string[] { "ҽ������", "����", "����", "ƴ����", "�����", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtys;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtys.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtys.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtys.Text = f.SelectDataRow["name"].ToString().Trim();
                    GetDoctorPbxx(txtys.Tag.ToString());
                    #region  ���δ���
                    ////////int yghs = 0; int xhs = 0; int swxhs = 0; int xwxhs = 0; int lsjh = 0;
                    ////////mz_ghxx.GetXhs(Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0")), out yghs, out xhs, out swxhs, out xwxhs, out lsjh, InstanceForm.BDatabase);
                    ////////if (xhs > 0) lblxh.Text = yghs.ToString().ToString() + "/" + Convert.ToString(xhs+lsjh); else lblxh.Text = "";
                    ////////if (swxhs > 0) lblxh.Text = lblxh.Text + " ����:" + swxhs.ToString();//����
                    ////////if (xwxhs > 0) lblxh.Text = lblxh.Text + " ����:" + xwxhs.ToString();//����
                    ////////if (lsjh > 0) lblxh.Text = lblxh.Text + " �Ӻ�:" + lsjh.ToString();
                    #endregion
                    GetXh(true);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }

            }
            if ((int)e.KeyChar == 13)
            {
                //Add By Zj 2012-04-09 ����ҽ��������ʾԤԼ������Ϣ
                GetDoctorPbxx(txtys.Tag.ToString());
                //Add By Zj 2012-02-16 ����ҽ��������ʾԤԼ������Ϣ
                GetXh(true);
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }

        }

        private void ReadGhxx()
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[14];

                parameters[0].Text = "@djy";
                parameters[0].Value = InstanceForm.BCurrentUser.EmployeeId;

                parameters[1].Text = "@rq1";
                parameters[1].Value = DateTime.Now.ToShortDateString() + " 00:00:00";

                parameters[2].Text = "@rq2";
                parameters[2].Value = DateTime.Now.ToShortDateString() + " 23:59:59";

                parameters[3].Text = "@GHLB";
                parameters[3].Value = 0;

                parameters[4].Text = "@BRLX";
                parameters[4].Value = 0;

                parameters[5].Text = "@GHKS";
                parameters[5].Value = 0;

                parameters[6].Text = "@GHJB";
                parameters[6].Value = 0;

                parameters[7].Text = "@GHYS";
                parameters[7].Value = 0;

                parameters[8].Text = "@KLX";
                parameters[8].Value = 0;

                parameters[9].Text = "@kh";
                parameters[9].Value = "";

                parameters[10].Text = "@brxm";
                parameters[10].Value = "";

                parameters[11].Text = "@blh";
                parameters[11].Value = "";

                parameters[12].Text = "@px";
                parameters[12].Value = " DESC ";

                parameters[13].Text = "@fph";
                parameters[13].Value = "";
                //modify by cc �����ѯ����Ҫʹ����ͼSP_MZSF_CX_GHXXFORGHJM
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_GHXXFORGHJM", parameters, 30);
                Fun.AddRowtNo(tb);
                this.dataGridView1.DataSource = tb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtnl.Visible = rdonl.Checked == true ? true : false;
            dtpcsrq.Visible = rdocsrq.Checked == true ? true : false;
        }

        private void butclear_Click(object sender, EventArgs e)
        {
            ControlEnable();
            butnew_Click(sender, e);


        }

        private void txtnl_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtnl.Text.Trim() != "" && Convertor.IsNumeric(txtnl.Text.Trim()) == false)
                {
                    MessageBox.Show("��������������");
                    return;
                }
                if (txtnl.Text.Trim() != "")
                {
                    //DateTime date = DateManager.AgeToDate(new Age(Convert.ToInt32(txtnl.Text), AgeUnit.��), InstanceForm.BDatabase);
                    //dtpcsrq.Value = date;
                    dtpcsrq.Value = DateManager.AgeToDate(new Age(Convert.ToInt16(txtnl.Text), (AgeUnit)cmbDW.SelectedIndex), InstanceForm.BDatabase);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmghdj_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && butsave.Enabled == true)
                butsave_Click(sender, e);

            if (e.KeyData == Keys.F1 && buthelp.Enabled == true)
                buthelp_Click(sender, e);

            if (e.KeyData == Keys.F3)
                butnew_Click(sender, e);

            if (e.KeyData == Keys.F7)
                butreadcard_Click(sender, e);

            if (e.KeyData == Keys.F10)
            {
                cmbdwlx.DroppedDown = true;
                cmbdwlx.Focus();
            }
            if (e.KeyData == Keys.F6)
            {
                cmbyblx.DroppedDown = true;
                cmbyblx.Focus();
            }
            if (e.KeyData == Keys.F9)
            {
                butclear_Click(sender, e);
            }

            if (e.KeyCode == Keys.F12)
            {
                for (int i = 0; i <= _mdiParent.MdiChildren.Length - 1; i++)
                {
                    if (_mdiParent.MdiChildren[i].Name == "Frmhjsf")
                    {
                        _mdiParent.MdiChildren[i].Activate();
                        _mdiParent.MdiChildren[i].Show();
                    }
                }
            }
        }

        private void txtxm_Leave(object sender, EventArgs e)
        {
            #region  ���ʹ�ÿ� �ҳֿ��˲�����Ϣ�����ڵ�ǰ����ʱ��������������Ϣ��������Ӧ�Ĳ�����Ϣ
            if (tbk != null)
            {
                if (tbk.Rows.Count != 0)
                {
                    if (Convertor.IsNull(tbk.Rows[0]["brxm"], "").Trim() != txtxm.Text.Trim())
                    {
                        //DialogResult dr = MessageBox.Show("");
                        string ss = "select * from YY_BRXX where brxxid in(select b.brxxid from YY_KDJB  a inner join vi_mz_ghxx b on a.kdjid=b.kdjid and a.brxxid='" + tbk.Rows[0]["brxxid"].ToString() + "')";
                        DataTable tbghxx = InstanceForm.BDatabase.GetDataTable(ss);
                        this.Tag = Guid.Empty.ToString();
                        for (int i = 0; i <= tbghxx.Rows.Count - 1; i++)
                        {
                            if (tbghxx.Rows[i]["brxm"].ToString().Trim() == txtxm.Text.Trim())
                            {
                                this.Tag = tbghxx.Rows[i]["brxxid"].ToString();
                                lblkye.Text = tbk.Rows[0]["kye"].ToString();
                                txtgrlxfs.Text = Convertor.IsNull(tbk.Rows[0]["BRLXFS"], "");
                                txtjtdz.Text = Convertor.IsNull(tbk.Rows[0]["JTDZ"], "");
                                cmbxb.Text = Convertor.IsNull(tbk.Rows[0]["xb"], "");
                            }
                        }
                    }
                }
            }
            #endregion

            //������ ����
            string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.���, "");
                call.Call(ts_call.DmType.����, txtxm.Text.Trim());
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //��ҽ����
        private void butreadcard_Click(object sender, EventArgs e)
        {


            //�����Ļ�Ĭ�ϵ�һ��ҽ������ 
            if (Convert.ToInt32(cmbyblx.SelectedValue) <= 0)
            {
                if (cmbyblx.Items.Count > 0) cmbyblx.SelectedIndex = 0;
            }

            if (cmbyblx.SelectedIndex == -1)
            {
                MessageBox.Show("û��ѡ��ҽ�����ͣ�");
                return;
            }

            try
            {
                Cursor = PubStaticFun.WaitCursor();
                int _yblx = Convert.ToInt32(cmbyblx.SelectedValue);
                Yblx yblx = new Yblx(_yblx, InstanceForm.BDatabase);

                brxx = new ts_yb_mzgl.BRXX();
                jsxx = new ts_yb_mzgl.JSXX();

                brxx.BRXM = txtxm.Text;

                // if (yblx.isgh == false) return;

                ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                ComboBox cmbtb = new ComboBox();
                bool bok = ybjk.GetPatientInfo("", yblx.yblx.ToString(), yblx.insureCentral, yblx.hospid, InstanceForm.BCurrentUser.EmployeeId.ToString(), "", "", ref brxx, cmbtb);

                if (brxx.KLX != 0 && brxx.KH != null && brxx.KH != "")
                {
                    cmbklx.SelectedValue = brxx.KLX;
                    txtkh.Text = brxx.KH;
                    txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                    if (cmbxb.Text.Trim() != "" && brxx.XB.Trim() != cmbxb.Text.Trim())
                        MessageBox.Show("ҽ���еĲ����Ա��HIS�ǼǵĲ����Ա�һ��,�뼰ʱ�޸�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                brxx.BLH = lblmzh.Text.Trim();
                brxx.SFZH = "";

                lblybxm.Text = brxx.BRXM;
                txtxm.Text = brxx.BRXM;
                lblYbye.Text = brxx.KYE;//��ȡҽ�������
                lblybrylx.Text = brxx.RYLB;
                lbljyh.Text = brxx.JSSJH;
                lblgzdw.Text = brxx.GZDW;


                yb_dylx = brxx.YWLX;
                yb_dylxmc = brxx.YWLXMC;
                yb_bzxx = "��������:" + brxx.ICDMC;
                yb_bzxx = "    ��Ա���:" + brxx.RYLBMC;

                txtkh.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                butreadcard.Enabled = false;
                Cursor = Cursors.Default;
            }
            finally
            {
                butreadcard.Enabled = true;
                Cursor = Cursors.Default;
            }

        }

        private void butxtk_Click(object sender, EventArgs e)
        {
            try
            {
                //Ĭ�ϵ�һ��ҽ������
                if (Convert.ToInt32(cmbyblx.SelectedValue) <= 0)
                {
                    DataTable yblxTb = (DataTable)cmbyblx.DataSource;
                    DataRow[] yblxDr = yblxTb.Select("ID>0");

                    if (yblxDr.Length > 0)
                    {
                        cmbyblx.SelectedValue = Convert.ToInt32(Convertor.IsNull(yblxDr[0]["id"], "-1"));
                    }
                }

                Cursor = PubStaticFun.WaitCursor();
                int _yblx = Convert.ToInt32(cmbyblx.SelectedValue);
                Yblx yblx = new Yblx(_yblx, InstanceForm.BDatabase);

                ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                bool bok = ybjk.Xtk(yblx.yblx.ToString(), yblx.insureCentral, yblx.hospid);

                butreadcard.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void Frmghdj_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Modify by Tany 2009-01-04 �رյ�ʱ���ͷ�ҽ����Դ
            DataTable yblxTb = (DataTable)cmbyblx.DataSource;
            DataRow[] yblxDr = yblxTb.Select("ID>0");

            for (int i = 0; i < yblxDr.Length; i++)
            {
                Yblx yblx = new Yblx(Convert.ToInt64(Convertor.IsNull(yblxDr[i]["id"], "-1")), InstanceForm.BDatabase);

                switch (yblx.ybjklx)
                {
                    case 1://����
                        break;
                    case 2://ɣ��
                        string msg = "";
                        ushort iAuth = ts_yb_interface.SED_Interface.Sed_UnAuthHis(ref msg);
                        if (iAuth == 0)
                            MessageBox.Show("ȡ����֤ʧ�ܣ�" + msg);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Frmghdj_Activated(object sender, EventArgs e)
        {
            try
            {
                //ReadGhxx();
                //dataGridView1_DataBindingComplete( null , null );

                //��ÿ��÷�Ʊ��
                if (cfg1046.Config == "1")
                {
                    int err_code; string err_text;
                    DataTable tb = Fun.GetFph(InstanceForm.BCurrentUser.EmployeeId, 1, Fplx, out err_code, out err_text, InstanceForm.BDatabase);
                    if (tb.Rows.Count == 0 || err_code != 0)
                    {
                        MessageBox.Show(err_text, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lblfph.Text = Convertor.IsNull(tb.Rows[0]["QZ"], "") + tb.Rows[0]["fph"].ToString().Trim();
                }

                if (txtkh.Enabled == true) { txtkh.Focus(); return; }
                if (txtxm.Enabled == true) { txtxm.Focus(); return; }
                if (txtks.Enabled == true) { txtks.Focus(); return; }
                if (txtys.Enabled == true) { txtys.Focus(); return; }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["ȡ������"].Value, "") != "")
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void Getghzs(Guid kdjid)
        {
            string bdate = DateTime.Now.ToShortDateString() + " 00:00:00";
            string edate = DateTime.Now.ToShortDateString() + " 23:59:59";
            DataTable tb = FrmMdiMain.Database.GetDataTable("select count(1) num from mz_ghxx where ghsj between '" + bdate + "' and '" + edate + "' and bqxghbz=0 and kdjid='" + kdjid + "'");

            if (tb.Rows.Count > 0)
            {
                lblghzs.Text = Convert.ToString(tb.Rows[0][0]);
            }
            else
            {
                lblghzs.Text = "0";
            }

            lblghzs.Visible = true;
            label11.Visible = true;
        }

        //����Żݷ���
        private void AddYhlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AddYhlx();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //����Żݷ���
        private void AddYhlx()
        {
            ReadCard readcard = new ReadCard(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
            //����Żݷ��� ���ӿ��Ҳ�����ȡ�Żݷ��������б�add by jiangzf
            FunAddComboBox.AddYhfa(readcard.klx, readcard.kdjid, Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0")), Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")), Convert.ToInt32(Convertor.IsNull(cmbdwlx.SelectedValue, "0")), _menuTag.Function_Name, cmbyhlx, InstanceForm.BDatabase);
        }

        private void txthtdw_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "��λ����", "������", "ƴ����", "�����" };
                string[] mappingname = new string[] { "dwmc", "szm", "pym", "wbm" };
                string[] searchfields = new string[] { "dwmc", "szm", "pym", "wbm" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = InstanceForm.BDatabase.GetDataTable(@"select * from jc_htdw WHERE ISNULL(BQYBZ,1)=1  ");
                f.WorkForm = this;
                f.srcControl = txthtdw;
                f.Font = txthtdw.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txthtdw.Focus();
                }
                else
                {
                    txthtdw.Tag = Convert.ToInt32(f.SelectDataRow["id"]);
                    txthtdw.Text = f.SelectDataRow["dwmc"].ToString().Trim();
                    //this.SelectNextControl(control, true, false, true, true);
                    butsave.Focus();
                }
            }
            else
            {
                if (txthtdw.Text.Trim() == "") { txthtdw.Focus(); return; }
                butsave.Focus();
            }
            e.Handled = true;
        }

        private void txtjtdz_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblYbye_Click(object sender, EventArgs e)
        {

        }

        private void butreadcard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtkh.Enabled == true)
            {
                txtkh.Focus();
                return;
            }
            if (txtxm.Enabled == true)
            {
                txtxm.Focus();
                return;
            }

        }

        private void Frmghdj_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {

                MenuTag tag = new MenuTag();
                tag = _menuTag;
                ts_mz_kgl.Frmbrxxcx f = new ts_mz_kgl.Frmbrxxcx(tag, "���˲�ѯ", null);
                f.txtbrxm.Text = txtxm.Text;
                if (txtxm.Text.Trim() == "")
                    f.chkdjsj.Checked = true;
                f.txtbrxm.Focus();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();

                ReadCard card = new ReadCard(f.return_kdjid, InstanceForm.BDatabase);
                if (card.kdjid != Guid.Empty)
                {
                    cmbklx.SelectedValue = card.klx;
                    txtkh.Text = card.kh;
                    txtkh.Focus();
                    txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    if (f.bok == true)
                    {
                        MessageBox.Show("ֻ�ܼ����п��Ĳ���", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buthygl_Click(object sender, EventArgs e)
        {
            //������ ����
            string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.SetPicture(InstanceForm.BCurrentUser.EmployeeId.ToString());
            }
        }
        private void butzbsy_Click(object sender, EventArgs e)
        {
            //������ ����
            string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.��ӭ, "��Ǹ,��ͣ����");
            }
        }
        /// <summary>
        /// ��ʾ�°�δ�ǼǵĿ���Ϣ
        /// </summary>
        /// <remarks>add by wangzhi 2010-10-27</remarks>
        private void ShowBrxx()
        {
            if (Modif_ini == "true")
            {
                txtxm.Enabled = false;
                cmbxb.Enabled = false;
                txtnl.Enabled = false;
                txtgrlxfs.Enabled = false;
                txtjtdz.Enabled = false;
            }
            else
            {
                txtxm.Enabled = true;
                cmbxb.Enabled = true;
                txtnl.Enabled = true;
                txtgrlxfs.Enabled = true;
                txtjtdz.Enabled = true;
            }


            Getghzs(_new_brxx_kxx.Kdjxx.Kdjid);




            if (xm_ini == "true")
                txtxm.Enabled = false;
            if (xb_ini == "true")
                cmbxb.Enabled = false;
            if (nl_ini == "true")
                txtnl.Enabled = false;
            if (lxfs_ini == "true")
                txtgrlxfs.Enabled = false;
            if (jtdz_ini == "true")
                txtjtdz.Enabled = false;

            lblkye.Text = "0.00";                                    // tbk.Rows[0]["kye"].ToString();
            txtkh.Text = _new_brxx_kxx.Kdjxx.Kh;
            txtxm.Text = _new_brxx_kxx.Brxx.Brxm;               //Convertor.IsNull( tbk.Rows[0]["brxm"] , "" );
            if (txtxm.Text.Trim() == "")
                txtxm.Text = _new_brxx_kxx.Kdjxx.Brxm;          //Convertor.IsNull( tbk.Rows[0]["CKRXM"] , "" );
            txtgrlxfs.Text = _new_brxx_kxx.Brxx.Brlxfs;         //Convertor.IsNull( tbk.Rows[0]["BRLXFS"] , "" );
            txtjtdz.Text = _new_brxx_kxx.Brxx.Jtdz;             //Convertor.IsNull( tbk.Rows[0]["JTDZ"] , "" );
            cmbxb.SelectedValue = _new_brxx_kxx.Brxx.Xb;                 //Convertor.IsNull( tbk.Rows[0]["�Ա�"] , "" );
            lblgzdw.Text = _new_brxx_kxx.Brxx.Gzdw;             //Convertor.IsNull( tbk.Rows[0]["gzdw"] , "" );
            cmbbrlx.SelectedValue = _new_brxx_kxx.Brxx.Brlx;

            //����Żݷ���
            AddYhlx();

            if (_new_brxx_kxx.Brxx.Csrq != "")
            {
                txtnl.Text = DateManager.DateToAge(Convert.ToDateTime(_new_brxx_kxx.Brxx.Csrq), InstanceForm.BDatabase).AgeNum.ToString();
                dtpcsrq.Value = Convert.ToDateTime(_new_brxx_kxx.Brxx.Csrq);
                AutoSelectGhjb();
            }

            this.Tag = _new_brxx_kxx.Brxx.Brxxid.ToString();


            if (Convert.ToInt16(_new_brxx_kxx.Kdjxx.Zbbz) == 1)
            {
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(_new_brxx_kxx.Kdjxx.Zbks), InstanceForm.BDatabase);
                txtks.Tag = _new_brxx_kxx.Kdjxx.Zbks;
                cmbghjb.SelectedValue = _new_brxx_kxx.Kdjxx.Zbjb.ToString() == "0" ? "1" : _new_brxx_kxx.Kdjxx.Zbjb.ToString();
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(_new_brxx_kxx.Kdjxx.Zbys), InstanceForm.BDatabase);
                txtys.Tag = _new_brxx_kxx.Kdjxx.Zbys.ToString();

            }



            //������ ����
            string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.����, txtxm.Text.Trim());
            }
        }

        //ԤԼȡ��
        private void butqh_Click(object sender, EventArgs e)
        {
            //�����ԤԼƽ̨ 
            if (new SystemCfg(3061).Config.Trim() == "1")
            {
                try
                {
                    DataRow row = null;
                    Frmyyjl f = new Frmyyjl("ȡԤԼ��", "", txtkh.Text.Trim(), txtxm.Text.Trim());//ȫ�������
                    f.ShowDialog();
                    if (f.Bok == false) { return; }
                    //Isyy = true; //��¼��ԤԼ Add by zp 2014-03-26
                    row = f.ReturnRow;
                    if (row == null) return;
                    string ssql = "select * from MZ_YYGHLB where yyid='" + Convertor.IsNull(row["yyid"], Guid.Empty.ToString()) + "'";
                    DataTable tbyy2 = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbyy2.Rows.Count == 0) return;
                    ReadCard card = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), f.ReturnNewKH, InstanceForm.BDatabase);

                    if (card.kdjid == Guid.Empty)
                    {
                        #region ���첡����Ϣ
                        _new_brxx_kxx = new MZ_BRXX_KXX();
                        YY_BRXX brxx = new YY_BRXX();
                        brxx.Brxxid = Guid.Empty;
                        brxx.Brxm = Convertor.IsNull(tbyy2.Rows[0]["brxm"], "");
                        brxx.Xb = Convertor.IsNull(tbyy2.Rows[0]["xb"], "");
                        brxx.Csrq = Convertor.IsNull(tbyy2.Rows[0]["csrq"], "");
                        brxx.Hyzk = "";
                        brxx.Gj = "";
                        brxx.Mz = "";
                        brxx.Zy = "";
                        brxx.Csdz = Convertor.IsNull(tbyy2.Rows[0]["jtdz"], ""); ;
                        brxx.Jtdz = Convertor.IsNull(tbyy2.Rows[0]["jtdz"], "");
                        brxx.Jtyb = "";
                        brxx.Jtdh = Convertor.IsNull(tbyy2.Rows[0]["lxdh"], ""); ;
                        brxx.Jtlxr = "";
                        brxx.Brlxfs = Convertor.IsNull(tbyy2.Rows[0]["lxdh"], ""); ;
                        brxx.Dzyj = "";
                        brxx.Gzdw = "";
                        brxx.Gzdwdz = "";
                        brxx.Gzdwyb = "";
                        brxx.Gzdwdh = "";
                        brxx.Gzdwlxr = "";
                        brxx.Sfzh = Convertor.IsNull(tbyy2.Rows[0]["sfzh"], "");
                        brxx.Brlx = 0;
                        brxx.Yblx = 0;
                        brxx.Cbkh = "";
                        brxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                        brxx.Djly = 0;
                        //���쿨�Ǽ���Ϣ
                        MZ_KDJXX kdjxx = new MZ_KDJXX();
                        kdjxx.Kdjid = Guid.Empty;
                        kdjxx.Brxxid = Guid.Empty;
                        kdjxx.Klx = Convert.ToInt32(cmbklx.SelectedValue);
                        kdjxx.Kh = f.ReturnNewKH;
                        kdjxx.Brxm = Convertor.IsNull(tbyy2.Rows[0]["brxm"], "");
                        kdjxx.Zbbz = 0;
                        kdjxx.Zbks = 0;
                        kdjxx.Zbjb = 0;
                        kdjxx.Zbys = 0;
                        kdjxx.Djsj = "";
                        kdjxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                        kdjxx.Kmm = "";

                        _new_brxx_kxx.Brxx = brxx;
                        _new_brxx_kxx.Kdjxx = kdjxx;
                        if (card.brxxid == Guid.Empty)
                            _isCreateNewCard = true;

                        ShowBrxx();
                        #endregion
                    }
                    if (f.ReturnNewKH != "")//modify by jiangzf ���޺�ԤԼ��ȡԤԼ��Ϣ�еĿ���
                        txtkh.Text = f.ReturnNewKH;
                    KeyPressEventArgs key = new KeyPressEventArgs('\r');
                    txtkh_KeyPress(null, key);
                    txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbyy2.Rows[0]["ghks"]), InstanceForm.BDatabase);
                    txtks.Tag = Convertor.IsNull(row["ghks"], "");
                    txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbyy2.Rows[0]["ghys"]), InstanceForm.BDatabase);
                    txtys.Tag = Convertor.IsNull(row["ghys"], "");
                    cmbghjb.Text = Fun.SeekGhjbName(Convert.ToInt32(tbyy2.Rows[0]["ghjb"]), InstanceForm.BDatabase);
                    cmbghjb.SelectedValue = Convertor.IsNull(tbyy2.Rows[0]["ghjb"], "");
                    Isyy = true;
                    butqh.Tag = Convertor.IsNull(row["yyid"], "");
                    butqh.BackColor = Color.Red;
                    if (Convertor.IsNull(tbyy2.Rows[0]["brxm"], "") == "") txtxm.Focus(); else butsave.Focus();
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                //Add by Zj 2012-2-11 ��������п�,���ԤԼȡ�ŵ�ʱ�� ֱ�Ӱ󶨲�����Ϣ Begin
                int err_code = -1;
                string err_text = "";
                DataTable tbyy = mz_ghxx.YYQH("", txtkh.Text, "", "", "", out err_code, out err_text, TrasenFrame.Forms.FrmMdiMain.Database);
                if (tbyy.Rows.Count == 1) //ӵ�����ƿ� ͬʱֻ��һ����¼ ֱ�Ӹ�ֵ
                {
                    Isyy = true; //��¼��ԤԼ
                    txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbyy.Rows[0]["ghks"]), InstanceForm.BDatabase);
                    txtks.Tag = Convertor.IsNull(tbyy.Rows[0]["ghks"], "");
                    txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbyy.Rows[0]["ghys"]), InstanceForm.BDatabase);
                    txtys.Tag = Convertor.IsNull(tbyy.Rows[0]["ghys"], "");
                    cmbghjb.Text = Fun.SeekGhjbName(Convert.ToInt32(tbyy.Rows[0]["ghjb"]), InstanceForm.BDatabase);
                    cmbghjb.SelectedValue = Convertor.IsNull(tbyy.Rows[0]["ghjb"], "");
                    butqh.Tag = Convertor.IsNull(tbyy.Rows[0]["yyid"], Guid.Empty.ToString());//Add By Zj 2012-05-15 ���ȡ��Tagֵ ��ֹδ���µ�MZ_YYGHLB
                    butqh.BackColor = Color.Red;
                }
                else
                {
                    try
                    {
                        DataRow row = null;
                        Frmyyjl f = new Frmyyjl("ȡԤԼ��", Convertor.IsNull(cmbklx.SelectedValue, ""), txtkh.Text, txtxm.Text);
                        f.ShowDialog();
                        if (f.Bok == false) { return; }
                        row = f.ReturnRow;
                        if (row == null) return;
                        Isyy = true; //��¼��ԤԼ Add by zp 2014-03-26
                        string ssql = "select * from mz_yyghlb where yyid='" + Convertor.IsNull(row["yyid"], Guid.Empty.ToString()) + "'";
                        DataTable tbyy2 = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tbyy2.Rows.Count == 0) return;

                        ReadCard card = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), f.ReturnNewKH, InstanceForm.BDatabase);


                        if (card.kdjid == Guid.Empty)
                        {
                            #region ���첡����Ϣ
                            _new_brxx_kxx = new MZ_BRXX_KXX();
                            YY_BRXX brxx = new YY_BRXX();
                            brxx.Brxxid = Guid.Empty;
                            brxx.Brxm = Convertor.IsNull(tbyy2.Rows[0]["brxm"], "");
                            brxx.Xb = Convertor.IsNull(tbyy2.Rows[0]["xb"], "");
                            brxx.Csrq = Convertor.IsNull(tbyy2.Rows[0]["csrq"], "");
                            brxx.Hyzk = "";
                            brxx.Gj = "";
                            brxx.Mz = "";
                            brxx.Zy = "";
                            brxx.Csdz = Convertor.IsNull(tbyy2.Rows[0]["jtdz"], ""); ;
                            brxx.Jtdz = Convertor.IsNull(tbyy2.Rows[0]["jtdz"], "");
                            brxx.Jtyb = "";
                            brxx.Jtdh = Convertor.IsNull(tbyy2.Rows[0]["lxdh"], ""); ;
                            brxx.Jtlxr = "";
                            brxx.Brlxfs = Convertor.IsNull(tbyy2.Rows[0]["lxdh"], ""); ;
                            brxx.Dzyj = "";
                            brxx.Gzdw = "";
                            brxx.Gzdwdz = "";
                            brxx.Gzdwyb = "";
                            brxx.Gzdwdh = "";
                            brxx.Gzdwlxr = "";
                            brxx.Sfzh = Convertor.IsNull(tbyy2.Rows[0]["sfzh"], "");
                            brxx.Brlx = 0;
                            brxx.Yblx = 0;
                            brxx.Cbkh = "";
                            brxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                            brxx.Djly = 0;
                            //���쿨�Ǽ���Ϣ
                            MZ_KDJXX kdjxx = new MZ_KDJXX();
                            kdjxx.Kdjid = Guid.Empty;
                            kdjxx.Brxxid = Guid.Empty;
                            kdjxx.Klx = Convert.ToInt32(cmbklx.SelectedValue);
                            kdjxx.Kh = f.ReturnNewKH;
                            kdjxx.Brxm = Convertor.IsNull(tbyy2.Rows[0]["brxm"], "");
                            kdjxx.Zbbz = 0;
                            kdjxx.Zbks = 0;
                            kdjxx.Zbjb = 0;
                            kdjxx.Zbys = 0;
                            kdjxx.Djsj = "";
                            kdjxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                            kdjxx.Kmm = "";

                            _new_brxx_kxx.Brxx = brxx;
                            _new_brxx_kxx.Kdjxx = kdjxx;
                            if (card.brxxid == Guid.Empty)
                                _isCreateNewCard = true;
                            txtkh.Text = f.ReturnNewKH;
                            ShowBrxx();
                            #endregion
                        }
                        txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbyy2.Rows[0]["ghks"]), InstanceForm.BDatabase);
                        txtks.Tag = Convertor.IsNull(row["ghks"], "");
                        txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbyy2.Rows[0]["ghys"]), InstanceForm.BDatabase);
                        txtys.Tag = Convertor.IsNull(row["ghys"], "");
                        cmbghjb.Text = Fun.SeekGhjbName(Convert.ToInt32(tbyy2.Rows[0]["ghjb"]), InstanceForm.BDatabase);
                        cmbghjb.SelectedValue = Convertor.IsNull(tbyy2.Rows[0]["ghjb"], "");

                        butqh.Tag = Convertor.IsNull(row["yyid"], "");
                        butqh.BackColor = Color.Red;

                        if (Convertor.IsNull(tbyy2.Rows[0]["brxm"], "") == "") txtxm.Focus(); else butsave.Focus();

                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            //150310 chencan ԤԼȡ�Ų������޸ĹҺſ��Ҽ�ҽ����Ϣ.
            txtks.Enabled = false;
            cmbghjb.Enabled = false;
            txtys.Enabled = false;
            treeView1.Enabled = false;
            panel8.Controls.Clear();
            //end 
        }

        //��ȡ�޺���� Modify by zp 2013-12-04
        private void GetXh(bool bxs)
        {
            try
            {
                Guid _Yyid = new Guid(Convertor.IsNull(butqh.Tag, Guid.Empty.ToString()));
                int ghks = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                int ghjb = Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                int ghys = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                if (ghks == 0) return;
                if (ghjb == 0) return;
                //������÷�ʱ�� ͬʱ��ҽ���з�ʱ����Ϣ ����ʾ��Դʱ���޺���Ϣ Modify By zp 2013-12-04
                if (cfg1099.Config.Trim() == "1")
                {
                    DateTime date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    string ghrq = date.ToString("yyyy-MM-dd");
                    int sxwid = 1;

                    if (_Yyid != Guid.Empty)
                    {
                        int _err_code = 0;
                        string _err_text = "";
                        //DataTable dt = Mz_YYgh.GetYYghInfo( _Yyid.ToString() , "" , "" , "" , Mz_YYgh.YYgh_Status.δ����δȡ�ż�¼ , "" , "" , 0 , out _err_code , out _err_text , InstanceForm.BDatabase );
                        DataTable dt = Mz_YYgh.GetYYghInfo(_Yyid.ToString(), "", "", "", Mz_YYgh.YYgh_Status.δ����δȡ�ż�¼, "", "", 0, 0, 0, Mz_YYgh.YYgh_Sort.����ԤԼ��ʽ, out _err_code, out _err_text, InstanceForm.BDatabase);

                        ghrq = Convert.ToDateTime(dt.Rows[0]["ԤԼ����"]).ToString("yyyy-MM-dd");
                        sxwid = Convert.ToInt32(dt.Rows[0]["ԤԼ�����id"]);
                    }
                    else
                    {
                        if (date.Hour >= 12)
                            sxwid = 2;
                    }
                    VisitResource _vistRes = new VisitResource(ghks, ghjb, ghys, ghrq, InstanceForm.BDatabase);
                    if (_vistRes.Resid > 0)
                    {
                        string strTime = "";
                        if (sxwid == 1)
                            strTime = string.Format("(ghsj>='{0} 00:00:00' and ghsj<='{0} 12:00:00')", ghrq);
                        else
                            strTime = string.Format("(ghsj>='{0} 12:00:01' and ghsj<='{0} 23:59:59')", ghrq);
                        object objRS = InstanceForm.BDatabase.GetDataResult(string.Format("select count(1) from mz_ghxx where bqxghbz=0 and ghks={0} and ghys={1} and {2}",
                            ghks, ghys, strTime));
                        objRS = Convertor.IsNull(objRS, "0");

                        FsdClass _fsd = new FsdClass();
                        DataTable dt_fsd = _fsd.GetSdXhInfo(ghrq, _vistRes.Resid, 0, date.ToString("HH:mm"), sxwid, InstanceForm.BDatabase);
                        //lblxh.Text = "[��:" + objRS.ToString() + "][��:" + dt_fsd.Rows[0]["����Դ��"].ToString() + "][��:" + dt_fsd.Rows[0]["ʣ����"].ToString() + "]";
                        if (dt_fsd.Rows.Count > 0)
                        {
                            switch (cfg1155.Config)
                            {
                                case "1":
                                    lblxh.Text = string.Format("[��:{0}][��:{1}]", objRS, dt_fsd.Rows[0]["����Դ��"]);
                                    break;
                                case "2":
                                    lblxh.Text = string.Format("[��:{0}][��:{1}]", dt_fsd.Rows[0]["����Դ��"], dt_fsd.Rows[0]["ʣ����"]);
                                    break;
                                case "3":
                                    lblxh.Text = string.Format("[��:{0}][��:{1}]", objRS, dt_fsd.Rows[0]["ʣ����"]);
                                    break;
                                case "0":
                                default:
                                    //lblxh.Text = string.Format( "[��:{2}][��:{0}][��:{1}]" , objRS , dt_fsd.Rows[0]["����Դ��"] , dt_fsd.Rows[0]["ʣ����"] );
                                    lblxh.Text = string.Format("[��:{0}][��:{1}][��:{2}]", objRS, dt_fsd.Rows[0]["����Դ��"], dt_fsd.Rows[0]["ʣ����"]);
                                    break;
                            }
                        }
                        return;
                    }
                }


                ParameterEx[] parameters = new ParameterEx[9];

                parameters[0].Text = "@YYID";
                parameters[0].Value = _Yyid;

                parameters[1].Text = "@GHKS";
                parameters[1].Value = ghks;

                parameters[2].Text = "@ghjb";
                parameters[2].Value = ghjb;

                parameters[3].Text = "@ghys";
                parameters[3].Value = ghys;

                parameters[4].Text = "@bxs";
                parameters[4].Value = bxs == true ? 1 : 0;

                parameters[5].Text = "@outbok";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int16;


                parameters[6].Text = "@OUTBZ";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].DataType = System.Data.DbType.String;
                parameters[6].ParaSize = 100;

                parameters[7].Text = "@err_code";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].DataType = System.Data.DbType.Int32;
                parameters[7].ParaSize = 100;

                parameters[8].Text = "@err_text";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].ParaSize = 100;


                InstanceForm.BDatabase.DoCommand("SP_MZSF_MZXH", parameters, 30);

                int outbok = Convert.ToInt16(parameters[5].Value);
                string outbz = Convert.ToString(parameters[6].Value);
                int err_code = Convert.ToInt32(parameters[7].Value);
                string err_text = Convert.ToString(parameters[8].Value);

                if (outbok == 1 && MessageBox.Show(outbz, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) throw new Exception("");
                if (bxs == true)
                {
                    lblxh.Text = outbz;
                    return;
                }
                if (err_code != 0 && outbok != 1) throw new Exception(outbz);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }



        private void cmbghjb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetXh(true);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cmbklx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                mz_card card = new mz_card(klx, InstanceForm.BDatabase);
                //txtmzh.Enabled = true;
                buthelp.Enabled = true;
                if (card.binput == false)
                {

                    //txtmzh.Enabled = false;
                    buthelp.Enabled = false;

                }
                if (txtkh.Enabled == true) txtkh.Focus();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        //����Ű��������
        private void AddDeptTree()
        {
            //            string ssql = @"select id as id,0 as flid ,mc,bzk from jc_mz_yspb_ksfl
            //                        union all 
            //                        select ksid as id,flid,rtrim(name) as mc,0 bzk from jc_mz_yspb_ksflmx a,jc_dept_property b where a.ksid=b.dept_id and deleted=0";
            //            string sssql = @"select id,flid,mc,bzk from 
            //(select id as id,0 as flid ,mc,bzk from jc_mz_yspb_ksfl
            //union all 
            //select a.zjid_qc as id,flid,rtrim(ZJMC_QC) as mc,0 bzk 
            //from jc_mz_yspb_ksflmx  a, JC_ZJSZ_QC b 
            //where a.zjid_qc=b.zjid_qc and a.zjid_qc<>0 and b.deleted =0 ) a
            //order by  id,flid ";
            string ssql = @"select id as id,0 as flid ,mc,bzk,PXXH
from jc_mz_yspb_ksfl
union all 
select ksid as id,flid,rtrim(name) as mc,0 bzk,PXXH
from jc_mz_yspb_ksflmx a,jc_dept_property b 
where a.ksid=b.dept_id and deleted=0";
            string sssql = @"select id,flid,mc,bzk,PXXH from 
(select id as id,0 as flid ,mc,bzk,PXXH from jc_mz_yspb_ksfl
union all 
select a.zjid_qc as id,flid,rtrim(ZJMC_QC) as mc,0 bzk ,PXXH
from jc_mz_yspb_ksflmx  a, JC_ZJSZ_QC b 
where a.zjid_qc=b.zjid_qc and a.zjid_qc<>0 and b.deleted =0 ) a
order by  flid,PXXH ";

            DataTable tb = null;
            if (cfg3035.Config == "0")
                tb = InstanceForm.BDatabase.GetDataTable(ssql);
            else
                tb = InstanceForm.BDatabase.GetDataTable(sssql);

            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList2;

            DataRow[] rows_x = tb.Select(" flid=0", "PXXH asc");
            for (int x = 0; x <= rows_x.Length - 1; x++)
            {
                TreeNode node = treeView1.Nodes.Add(rows_x[x]["mc"].ToString().Trim());
                node.Tag = rows_x[x]["id"].ToString().Trim();
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                DataRow[] rows = tb.Select(" flid=" + rows_x[x]["id"].ToString().Trim() + "", "PXXH asc");
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    TreeNode Cnode = node.Nodes.Add(rows[i]["mc"].ToString());
                    Cnode.Tag = rows[i]["id"].ToString().Trim();
                    Cnode.ImageIndex = 2;
                    Cnode.SelectedImageIndex = 2;
                }
                if (rows_x[x]["bzk"].ToString() == "1")
                    node.Expand();
            }

        }
        //��ȡ�Ű���Ϣ
        private void GetPbxx(string ksid, string ysid)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@ksid";
                parameters[0].Value = ksid;

                parameters[1].Text = "@ysid";
                parameters[1].Value = ysid;

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZGH_GETPBXX", parameters, dset, "sfmx", 30);

                CreateTabPage(dset);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }
        //����tabpage
        private void CreateTabPage(DataSet dset)
        {
            string ghsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");//Add By Zj 2013-03-19
            //this.tableLayoutPanel2.Controls.Add(this.label22, 0, 0);
            //tabControl2.TabPages.Clear();
            //for (int i = 0; i <= dset.Tables[1].Rows.Count - 1; i++)
            //{
            //    System.Windows.Forms.TabPage tabPage = new System.Windows.Forms.TabPage();
            //    System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();

            //    tabPage.Controls.Add(listView);
            //    tabPage.Location = new System.Drawing.Point(4, 21);
            //    tabPage.Name = "tabPage3";
            //    tabPage.Padding = new System.Windows.Forms.Padding(3);
            //    tabPage.Size = new System.Drawing.Size(813, 276);
            //    tabPage.TabIndex = 0;
            //    tabPage.Text = dset.Tables[1].Rows[i]["ghjbmc"].ToString();
            //    tabPage.UseVisualStyleBackColor = true;

            //    listView.Dock = System.Windows.Forms.DockStyle.Fill;
            //    listView.Location = new System.Drawing.Point(3, 3);
            //    listView.Name = "listView1";
            //    listView.Size = new System.Drawing.Size(807, 270);
            //    listView.TabIndex = 0;
            //    listView.UseCompatibleStateImageBehavior = false;
            //    this.tabControl2.Controls.Add(tabPage);
            //    listView.DoubleClick += new EventHandler(listView_DoubleClick);
            //}

            panel8.Controls.Clear();
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();

            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.506699F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.4933F));
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 0;
            //tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new System.Drawing.Size(821, 150);
            tableLayoutPanel2.TabIndex = 2;
            tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.AutoSize = false;

            //tableLayoutPanel2.RowCount = dset.Tables[1].Rows.Count;
            for (int i = 0; i <= dset.Tables[1].Rows.Count - 1; i++)
            {
                DataRow[] rowsJB = dset.Tables[0].Select("ghjb='" + dset.Tables[1].Rows[i]["ghjb"].ToString() + "'");
                if (rowsJB.Length <= 7)
                    tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));//70
                else
                    tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));

                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.AutoEllipsis = true;
                label.BorderStyle = System.Windows.Forms.BorderStyle.None;
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label.Location = new System.Drawing.Point(3, 0);
                label.Name = "label22";
                label.Size = new System.Drawing.Size(30, 150);
                label.TabIndex = 0;

                label.Text = dset.Tables[1].Rows[i]["ghjbmc"].ToString();
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tableLayoutPanel2.Controls.Add(label, 0, i);

                System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();
                listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
                listView.Dock = System.Windows.Forms.DockStyle.Fill;
                listView.Location = new System.Drawing.Point(3, 3);
                listView.Name = "listView1";
                listView.Size = new System.Drawing.Size(807, 30);
                listView.TabIndex = 0;
                listView.UseCompatibleStateImageBehavior = false;
                tableLayoutPanel2.Controls.Add(listView, 1, i);
                listView.DoubleClick += new EventHandler(listView_DoubleClick);
                listView.Click += new EventHandler(listView_Click);
                listView.LargeImageList = this.imgBED;
                listView.View = System.Windows.Forms.View.LargeIcon;
                listView.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                //tableLayoutPanel2.RowStyles[0].Height = 300;

                DataRow[] rows = dset.Tables[0].Select("ghjb=" + dset.Tables[1].Rows[i]["ghjb"].ToString() + "", "px");
                for (int j = 0; j <= rows.Length - 1; j++)
                {
                    //Add by zp 2013-12-04 ������Դ�޺����
                    string xhqk = "";
                    if (cfg1099.Config.Trim() == "1")
                    {
                        try
                        {
                            FsdClass _Fsd = new FsdClass();
                            int ksdm = Convert.ToInt32(rows[j]["ksdm"]);
                            int ysdm = Convert.ToInt32(rows[j]["ysdm"]);
                            int ghjb = Convert.ToInt32(rows[j]["ghjb"]);
                            DateTime date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                            int sxwid = 1;
                            string ghrq = date.ToString("yyyy-MM-dd");
                            if (date.Hour >= 12)
                                sxwid = 2;
                            string time = date.ToString("HH:mm");
                            VisitResource _visres = new VisitResource(ksdm, ghjb, ysdm, ghrq, InstanceForm.BDatabase);
                            DataTable dtb = _Fsd.GetSdXhInfo(ghrq, _visres.Resid, 0, time, sxwid, InstanceForm.BDatabase);
                            //ȡ���չҺ�����
                            string strTime = "";
                            if (sxwid == 1)
                                strTime = string.Format("(ghsj>='{0} 00:00:00' and ghsj<='{0} 12:00:00')", ghrq);
                            else
                                strTime = string.Format("(ghsj>='{0} 12:00:01' and ghsj<='{0} 23:59:59')", ghrq);
                            object objRS = InstanceForm.BDatabase.GetDataResult(string.Format("select count(1) from mz_ghxx where bqxghbz=0 and ghks={0} and ghys={1} and {2}",
                                ksdm, ysdm, strTime));
                            objRS = Convertor.IsNull(objRS, "0");

                            if (dtb != null && dtb.Rows.Count > 0)
                            {
                                switch (cfg1155.Config)
                                {
                                    case "1":
                                        xhqk = string.Format("\r\n[��:{0}][��:{1}]", objRS, dtb.Rows[0]["����Դ��"]);
                                        break;
                                    case "2":
                                        xhqk = string.Format("\r\n[��:{0}][��:{1}]", dtb.Rows[0]["����Դ��"], dtb.Rows[0]["ʣ����"]);
                                        break;
                                    case "3":
                                        xhqk = string.Format("\r\n[��:{0}][��:{1}]", objRS, dtb.Rows[0]["ʣ����"]);
                                        break;
                                    case "0":
                                    default:
                                        xhqk = string.Format("\r\n[��:{0}][��:{1}][��:{2}]", objRS, dtb.Rows[0]["����Դ��"], dtb.Rows[0]["ʣ����"]);
                                        break;
                                }
                            }
                        }
                        catch
                        { }
                    }
                    string mc = rows[j]["ysmc"].ToString() + xhqk;
                    ListViewItem item = new ListViewItem(mc);//+ "\r" + rows[j]["ghjbmc"].ToString().Trim());
                    item.Tag = rows[j]["xh"].ToString();
                    if (rows[j]["sex"].ToString() == "��")
                        item.ImageIndex = 8;
                    if (rows[j]["sex"].ToString() == "Ů")
                        item.ImageIndex = 3;
                    if (rows[j]["sex"].ToString() == "")
                        item.ImageIndex = 71;

                    ////Add By Zj 2013-02-16    Modify by zj 2013-03-19 �ٶȺ��� �����Ҫͳ��ҽ���ĹҺ��˴� ����ڴ洢������һ��ͳ�Ƴ�����
                    //string ssql = "select COUNT(*) from MZ_GHXX where GHKS=" + dset.Tables[0].Rows[i]["ksdm"].ToString() + " and GHJB=" + dset.Tables[1].Rows[i]["ghjb"].ToString() + " and CONVERT(varchar(120),ghsj,23)='" + ghsj + "' ";
                    //if (rows[j]["ysdm"].ToString() != "0")
                    //    ssql += " and GHYS=" + rows[j]["ysdm"].ToString();
                    //if (rows[j]["ysdm"].ToString() == "0")
                    //    ssql += " and GHYS=0";
                    //item.Text = item.Text + "(" + InstanceForm.BDatabase.GetDataResult(ssql).ToString() + ")";
                    listView.Items.Add(item);
                }

            }
            panel8.Controls.Add(tableLayoutPanel2);
        }
        //ҽ������¼�
        void listView_Click(object sender, EventArgs e)
        {
            try
            {
                ListView tree = (ListView)sender;
                if (tree.SelectedItems[0] == null) return;
                string tag = tree.SelectedItems[0].Tag.ToString();
                string[] s = tag.Split(new char[1] { '|' });
                if (s.Length <= 1) return;
                string ksdm = s[0];
                string ysdm = s[1];
                string ghjb = s[2];
                string pplx = s[3];
                txtks.Tag = ksdm;
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(ksdm), InstanceForm.BDatabase);
                txtys.Tag = ysdm;
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(ysdm), InstanceForm.BDatabase);
                cmbghjb.SelectedValue = ghjb;

                GetXh(true);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ҽ��˫���¼�
        void listView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListView tree = (ListView)sender;
                if (tree.SelectedItems[0] == null) return;
                string tag = tree.SelectedItems[0].Tag.ToString();
                string[] s = tag.Split(new char[1] { '|' });
                if (s.Length <= 1) return;
                string ksdm = s[0];
                string ysdm = s[1];
                string ghjb = s[2];
                string pplx = s[3];
                txtks.Tag = ksdm;
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(ksdm), InstanceForm.BDatabase);
                txtys.Tag = ysdm;
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(ysdm), InstanceForm.BDatabase);
                cmbghjb.SelectedValue = ghjb;
                butsave_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //����ѡ���¼�
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                if (this.treeView1.SelectedNode == null)
                    return;
                if (this.treeView1.SelectedNode.ImageIndex == 2)
                    GetPbxx(this.treeView1.SelectedNode.Tag.ToString(), "0");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        //ͨ��ҽ�������Ű�ȷ�����Һͼ���
        private void GetDoctorPbxx(string ysid)
        {
            try
            {
                if (cfgpb.Config == "0") return;
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@ksid";
                parameters[0].Value = "0";

                parameters[1].Text = "@ysid";
                parameters[1].Value = ysid;

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZGH_GETPBXX", parameters, dset, "sfmx", 30);

                if (dset.Tables[0].Rows.Count > 0)
                {
                    string tag = Convertor.IsNull(dset.Tables[0].Rows[0]["xh"], "");
                    string[] s = tag.Split(new char[1] { '|' });
                    if (s.Length <= 1) return;
                    string ksdm = s[0];
                    string ysdm = s[1];
                    string ghjb = s[2];
                    string pplx = s[3];
                    if (txtks.Text.Trim() == "")//Add By Zj 2012-05-06 ����Ѿ������˿��� �����ı���� �޸�ԭ������Ϊ������ҽԺ �������������ҽ���ƿյĻ� ����տ���
                    {
                        txtks.Tag = ksdm;
                        txtks.Text = Fun.SeekDeptName(Convert.ToInt32(ksdm), InstanceForm.BDatabase);
                        cmbghjb.SelectedValue = ghjb;
                    }
                    txtys.Tag = ysdm;
                    txtys.Text = Fun.SeekEmpName(Convert.ToInt32(ysdm), InstanceForm.BDatabase);
                }
                else
                {
                    string ssql = @"select a.employee_id,d.type_id,a.dept_id,dbo.fun_getdeptname(a.dept_id) dept_name from JC_EMP_DEPT_ROLE a inner join jc_role_doctor b
                                        on a.employee_id=b.employee_id  inner join 
                                        JC_DEPT_TYPE_RELATION c on a.dept_id=c.dept_id and c.type_code='001'
                                        inner join jc_doctor_type d on  b.ys_typeid=d.zcjb where a.employee_id=" + ysid + "";

                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count > 0)
                    {
                        if (txtks.Text.Trim() == "")
                        {
                            txtks.Text = tb.Rows[0]["dept_name"].ToString();
                            txtks.Tag = tb.Rows[0]["dept_id"].ToString();
                            cmbghjb.SelectedValue = tb.Rows[0]["type_id"].ToString();
                        }
                        else //������Ҳ�Ϊ�� ֻ�ı�ҽ��Ĭ�ϵļ��� 2012-04-09
                        {
                            cmbghjb.SelectedValue = tb.Rows[0]["type_id"].ToString();
                        }
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void dtpcsrq_ValueChanged(object sender, EventArgs e)
        {
            DateTime Nowtime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            TimeSpan timespan = Nowtime.Subtract(dtpcsrq.Value);
            Age age = DateManager.DateToAge(dtpcsrq.Value, InstanceForm.BDatabase);

            txtnl.Text = age.AgeNum.ToString();
            switch (age.Unit.ToString())
            {
                case "��":
                    cmbDW.SelectedValue = 0;
                    break;
                case "��":
                    cmbDW.SelectedValue = 1;
                    break;
                case "��":
                    cmbDW.SelectedValue = 2;
                    break;
                case "Сʱ":
                    cmbDW.SelectedValue = 3;
                    break;
                default:
                    cmbDW.SelectedValue = 4;
                    break;
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            #region ��һ��ʹ�ñ�����
            try
            {
                #region СƱ
                ParameterEx[] parameters = new ParameterEx[26];
                parameters[0].Text = "ҽԺ����";
                parameters[0].Value = "";

                parameters[1].Text = "��Ʊ��";
                parameters[1].Value = "";

                DateTime time = System.DateTime.Now;

                parameters[2].Text = "��";
                parameters[2].Value = time.Year;

                parameters[3].Text = "��";
                parameters[3].Value = time.Month;

                parameters[4].Text = "��";
                parameters[4].Value = time.Day;

                parameters[5].Text = "�Һ�����";
                parameters[5].Value = "";

                parameters[6].Text = "����";
                parameters[6].Value = "";

                parameters[7].Text = "ҽ��";
                parameters[7].Value = "";

                parameters[8].Text = "ҽ������";
                parameters[8].Value = "";

                parameters[9].Text = "�Һ����";
                parameters[9].Value = "";

                PrintClass.InvoiceItem[] item = null;


                parameters[10].Text = "�Һŷ�";
                parameters[10].Value = "";

                parameters[11].Text = "����";
                parameters[11].Value = "";

                parameters[12].Text = "����";
                parameters[12].Value = "";

                parameters[13].Text = "���Ϸ�";
                parameters[13].Value = "";

                parameters[14].Text = "Сд���";
                parameters[14].Value = "";

                parameters[15].Text = "��д���";
                parameters[15].Value = "";
                parameters[16].Text = "�տ�Ա";
                if (cfgsfy.Config == "1")
                    parameters[16].Value = "";
                else
                    parameters[16].Value = "";

                parameters[17].Text = "��������";
                parameters[17].Value = txtxm.Text.Trim();

                parameters[18].Text = "�����";
                parameters[18].Value = lblmzh.Text.Trim();

                parameters[19].Text = "����";
                parameters[19].Value = "";

                parameters[20].Text = "ҽ������";
                parameters[20].Value = "";

                parameters[21].Text = "ҽ��֧��";
                parameters[21].Value = "";

                parameters[22].Text = "ҽ����֧��";
                parameters[22].Value = "";

                parameters[23].Text = "�ֽ�֧��";
                parameters[23].Value = "";

                parameters[24].Text = "ҽ�����";
                parameters[24].Value = "";
                parameters[25].Text = "����";
                parameters[25].Value = txtkh.Text;
                // TrasenFrame.Forms.FrmReportView fv;


                //fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_�Һ�СƱ.rpt", parameters, false);
                #endregion
                //fv.Show();
                // fv.Close();

                CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rd.Load(Constant.CustomDirectory + "\\Report\\GH_�Һ�СƱ.rpt");
                // rd.Load(Constant.ApplicationDirectory + "\\Report\\MZSF_СƱ(ֻ��һ��).rpt");
                // rd.SetDataSource(_dset);
                for (int i = 0; i < parameters.Length; i++)
                {
                    rd.SetParameterValue(parameters[i].Text, parameters[i].Value);
                }
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Show();
                //Form f = new Form();
                //f.Controls.Add(crystalReportViewer1);
                //f.ShowDialog();
                crystalReportViewer1.Dispose();
            }
            catch (Exception ex) { }
            #endregion
        }
        //add by jiangzf �Żݷ��������ҹ���
        private void txtks_Leave(object sender, EventArgs e)
        {
            AddYhlx();
        }

        private void btnReadIDCard_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "                                                                                                      ";
                string bqy = ApiFunction.GetIniString("���֤ɨ����", "�������֤ɨ����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqy == "true")
                {
                    string bsbxh = ApiFunction.GetIniString("���֤ɨ����", "�豸�ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    string bshow = ApiFunction.GetIniString("���֤ɨ����", "��ʾ������Ϣ", Constant.ApplicationDirectory + "//ClientWindow.ini");

                    ts_ReadCard.Icard card = ts_ReadCard.CardFactory.NewCard(bsbxh);
                    ts_ReadCard.IDCardData _IDCardData = new ts_ReadCard.IDCardData();

                    bool bok = card.ReadCard(ref _IDCardData, ref msg);
                    if (bok == false)
                        return;

                    txtxm.Text = _IDCardData.Name;
                    cmbxb.Text = _IDCardData.Sex;

                    dtpcsrq.Value = Convert.ToDateTime(_IDCardData.Born);
                    rdonl.Checked = true;

                    Age age = DateManager.DateToAge(dtpcsrq.Value, InstanceForm.BDatabase);
                    txtnl.Text = age.AgeNum.ToString();
                    cmbDW.SelectedIndex = (int)age.Unit;

                    txtjtdz.Text = _IDCardData.Address;

                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ˢ�¹Һż�¼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadGhxx();
            dataGridView1_DataBindingComplete(null, null);
        }
        /// <summary>
        /// �¿���ֵ
        /// </summary>
        private void RechargeWithNewCard(int _klx, ref MZ_BRXX_KXX new_brxx_kxx)
        {
            SystemCfg cfg1154 = new SystemCfg(1154, InstanceForm.BDatabase);
            if (cfg1154.Config == "1")
            {
                ts_mz_class.Klx cardType = new Klx(_klx, InstanceForm.BDatabase);
                if (cardType.BJEBZ == (short)1)
                {
                    //�½���ʱ�������������
                    if (MessageBox.Show("�Ƿ�����Ԥ���", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strDjsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
                        int err_code = -1;
                        string err_text = "";
                        try
                        {
                            InstanceForm.BDatabase.BeginTransaction();
                            Guid _outNewBrxxId = Guid.Empty;
                            //���ȱ��没����Ϣ
                            ts_mz_class.YY_BRXX.BrxxDj(Guid.Empty, new_brxx_kxx.Brxx.Brxm, new_brxx_kxx.Brxx.Xb, new_brxx_kxx.Brxx.Csrq, new_brxx_kxx.Brxx.Hyzk,
                                new_brxx_kxx.Brxx.Gj, new_brxx_kxx.Brxx.Mz, new_brxx_kxx.Brxx.Zy, new_brxx_kxx.Brxx.Csdz, new_brxx_kxx.Brxx.Jtdh, new_brxx_kxx.Brxx.Jtyb,
                                new_brxx_kxx.Brxx.Jtdh, new_brxx_kxx.Brxx.Jtlxr, new_brxx_kxx.Brxx.Brlxfs, new_brxx_kxx.Brxx.Dzyj, new_brxx_kxx.Brxx.Gzdw, new_brxx_kxx.Brxx.Gzdwdz,
                                new_brxx_kxx.Brxx.Gzdwyb, new_brxx_kxx.Brxx.Gzdwdh, new_brxx_kxx.Brxx.Gzdwlxr, new_brxx_kxx.Brxx.Sfzh, new_brxx_kxx.Brxx.Brlx, new_brxx_kxx.Brxx.Yblx,
                                new_brxx_kxx.Brxx.Cbkh, new_brxx_kxx.Brxx.Djy, new_brxx_kxx.Brxx.Djly, out _outNewBrxxId, out err_code, out err_text, InstanceForm.BDatabase);
                            if (_outNewBrxxId == Guid.Empty || err_code != 0)
                                throw new Exception(err_text);

                            //���濨��Ϣ
                            Guid _outNewKdjid = Guid.Empty;
                            ts_mz_class.mz_kdj.Kdj(Guid.Empty, _outNewBrxxId, _klx, txtkh.Text, new_brxx_kxx.Brxx.Brxm, 0, 0, 0, 0, strDjsj, new_brxx_kxx.Brxx.Djy, "", "",
                                "", out _outNewKdjid, out err_code, out err_text, "", "", InstanceForm.BDatabase);
                            if (_outNewKdjid == Guid.Empty || err_code != 0)
                                throw new Exception(err_text);
                            InstanceForm.BDatabase.CommitTransaction();
                            new_brxx_kxx.Brxx.Brxxid = _outNewBrxxId;
                        }
                        catch (Exception error)
                        {
                            InstanceForm.BDatabase.RollbackTransaction();
                            throw error;
                        }
                        //����Ԥ�������
                        ts_mz_kgl.Frmbrkcz frmkcz = new ts_mz_kgl.Frmbrkcz(InstanceForm.BDatabase, InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, _klx, txtkh.Text);
                        frmkcz.AfterRechargeSuccess += delegate()
                        {
                            frmkcz.Close();
                        };
                        //����ֵ����Ŀ�������Ϊֻ��
                        ((System.Windows.Forms.TextBox)frmkcz.GetType().GetField("txtkh", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(frmkcz)).ReadOnly = true;
                        frmkcz.Size = new Size(852, 385);
                        frmkcz.StartPosition = FormStartPosition.CenterScreen;
                        frmkcz.ShowDialog();
                        txtkh.Focus();
                        txtkh_KeyPress(txtkh, new KeyPressEventArgs('\r'));
                        _isCreateNewCard = true;
                        _needChargeCardFee = true;
                    }
                }
            }
        }
    }
}
