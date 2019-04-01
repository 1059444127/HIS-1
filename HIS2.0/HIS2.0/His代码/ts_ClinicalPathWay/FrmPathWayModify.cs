using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using PathWay;
using Trasen.Base;
using Trasen.Base.Cmb;
using TrasenClasses.GeneralClasses;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using TrasenFrame.Forms;



namespace ts_ClinicalPathWay
{
    /// <summary>
    /// �ٴ�·������
    /// </summary>
    public partial class FrmPathWayModify : FrmBase2
    {
        #region ȫ�ֱ���

        #region int���ͱ���

        /// <summary>
        /// ·��״̬(�����ʼ��)
        /// </summary>
        int _iPathWayStatus;
        /// <summary>
        /// ·���������(�����ʼ��)
        /// </summary>
        int _iPathWayMaxDay;

        #endregion

        #region string���ͱ���

        /// <summary>
        /// ��������(�ٴ�·���򵥲���)
        /// </summary>
        string _sFormType;
        /// <summary>
        /// ·��ID(�����ʼ��)
        /// </summary>
        string _sPathWayId;
        /// <summary>
        /// ·������(�����ʼ��)
        /// </summary>
        string _sPathWayName;
        /// <summary>
        /// ·���汾(�����ʼ��)
        /// </summary>
        string _sPathWayVersion;
        /// <summary>
        /// ·������(�����ʼ��)
        /// </summary>
        string _sPathWayAmount;
        /// <summary>
        /// ��ǰ�׶�ID
        /// </summary>
        string _sCurrentStepId;
        /// <summary>
        /// ��ǰ����
        /// </summary>
        string _sNowGroup;
        /// <summary>
        /// �׶β�ѯ���
        /// </summary>
        string _sSqlStep;
        /// <summary>
        /// �׶ι�ϵ��ѯ���
        /// </summary>
        string _sSqlStepRelation;
        /// <summary>
        /// �̶��ṹ��ѯ���
        /// </summary>
        string _sSqlFixedStructure;
        /// <summary>
        /// �׶���Ŀ��ѯ���
        /// </summary>
        string _sSqlStepItem;
        /// <summary>
        /// �׶���Ŀ��ѯ���(���ڱ���)
        /// </summary>
        string _sSqlStepItemSave;
        /// <summary>
        /// �׶���Ŀ�����ѯ���
        /// </summary>
        string _sSqlStepItemKind;
        /// <summary>
        /// �׶���Ŀ�����ѯ���(���ڱ���)
        /// </summary>
        string _sSqlStepItemKindSave;
        /// <summary>
        /// ��Ŀ���ݲ�ѯ���
        /// </summary>
        string _sSqlCONTENT;
        /// <summary>
        /// ������λ��ѯ���
        /// </summary>
        string _sSqlJLDW;
        /// <summary>
        /// �÷���ѯ���
        /// </summary>
        string _sSqlYF;
        /// <summary>
        /// Ƶ�β�ѯ���
        /// </summary>
        string _sSqlPC;

        #endregion

        #region bool���ͱ���

        /// <summary>
        /// ·���Ƿ�ֻ��(�����ʼ��)
        /// </summary>
        bool _bPathWayReadOnly;

        #endregion

        #region DataTable�ڴ��

        /// <summary>
        /// �׶α�
        /// </summary>
        DataTable dtStep;
        /// <summary>
        /// �׶ι�����
        /// </summary>
        DataTable dtStepRelation;
        /// <summary>
        /// �̶��ṹ��
        /// </summary>
        DataTable dtFixedStructure;
        /// <summary>
        /// ���ؼ�����ʾ��
        /// </summary>
        DataTable dtBindShow;
        /// <summary>
        /// �׶���Ŀ��
        /// </summary>
        DataTable dtStepItem;
        /// <summary>
        /// �׶���Ŀ�����
        /// </summary>
        DataTable dtStepItemKind;
        /// <summary>
        /// ��Ŀ���ݱ�
        /// </summary>
        DataTable dtCONTENT;
        /// <summary>
        /// ��Ŀ���ݱ� ȫ�� 
        /// </summary>
        DataTable dtCONTENT_all;//add by zouchihu1 2013-6-22
        /// <summary>
        /// ִ������
        /// </summary>
        DataTable dtEXEC_TYPE;
        /// <summary>
        /// ѡ������
        /// </summary>
        DataTable dtSELECT_TYPE;
        /// <summary>
        /// ��λ��
        /// </summary>
        DataTable dtJLDW;
        /// <summary>
        /// �÷���
        /// </summary>
        DataTable dtYF;
        /// <summary>
        /// Ƶ�α�
        /// </summary>
        DataTable dtPC;
        /// <summary>
        /// ������ʾ�ĳ���ҽ����
        /// </summary>
        DataTable dtContinuedStepItem;
        /// <summary>
        /// ������ʾ�ĳ���ҽ�������
        /// </summary>
        DataTable dtContinuedStepItemKind;

        #endregion

        #region �༭��

        /// <summary>
        /// ��Ŀ���ݱ༭��
        /// </summary>
        LookEditItemCmb editCONTENT;
        /// <summary>
        /// ��Ŀ���ݱ༭�������ؼ�
        /// </summary>
        ShowPopup spCONTENT;
        /// <summary>
        /// �÷��༭��
        /// </summary>
        LookEditItemCmb editYF;
        /// <summary>
        /// �÷��༭�������ؼ�
        /// </summary>
        ShowPopup spYF;
        /// <summary>
        /// Ƶ�α༭��
        /// </summary>
        LookEditItemCmb editPC;
        /// <summary>
        /// Ƶ�α༭�������ؼ�
        /// </summary>
        ShowPopup spPC;
        /// <summary>
        /// ��λ�༭��
        /// </summary>
        LookEditItemCmb editJLDW;
        /// <summary>
        /// ��λ�༭�������ؼ�
        /// </summary>
        ShowPopup spJLDW;
        /// <summary>
        /// ѡ�����༭��
        /// </summary>
        RepositoryItemLookUpEdit editSELECT_TYPE;
        /// <summary>
        /// ִ�����༭��
        /// </summary>
        RepositoryItemLookUpEdit editEXEC_TYPE;
        /// <summary>
        /// �����׶α༭��
        /// </summary>
        RepositoryItemLookUpEdit editPATH_STEP_ID;
        /// <summary>
        /// �����༭��
        /// </summary>
        RepositoryItemCalcEdit editJS;
        /// <summary>
        /// �����༭��
        /// </summary>
        RepositoryItemCalcEdit editJL;
        /// <summary>
        /// ͣ���ձ༭��
        /// </summary>
        RepositoryItemCalcEdit editTS;
        /// <summary>
        /// ���۱༭��
        /// </summary>
        RepositoryItemCalcEdit editPRICE;

        #endregion

        #region ����

        /// <summary>
        /// ���ݼ����߳�
        /// </summary>
        BackgroundWorker bwLoadData;

        /// <summary>
        /// �׶���Ŀ����Դ
        /// </summary>
        BindingSource bsItemData;


        #endregion

        #endregion

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="infoDlg">�����б�</param>
        public FrmPathWayModify(DbOpt.InFoDlg infoDlg)
        {
            //������������
            InitializeComponent();
            //���մӵ��ô��崫�����Ĳ����б�
            this.info_DLG = infoDlg;
            //��ʼ��ȫ�ֱ���
            InitGlobalFields();
            //��ʼ���ؼ�
            InitControls();
            //��ʼ���¼�
            InitEvents();
            //��ʼ������
            InitData();
        }

        #region ��ʼ��

        /// <summary>
        /// ��ʼ��ȫ�ֱ���(���췽������)
        /// </summary>
        void InitGlobalFields()
        {
            try
            {
                //�жϲ����б��Ƿ���ֵ,��ֵ���ʼ��ȫ�ֱ���
                if (InfoDialogCheck())
                {
                    //״̬����ʾ���ڳ�ʼ��
                    this.UseHelp("��״̬��ʾ�����ڳ�ʼ��������Ϣ...", true);

                    //��ʼ��·��ID
                    this._sPathWayId = this.info_DLG.pKey1;
                    //��ʼ��·��״̬
                    this._iPathWayStatus = Convertor.IsInteger(this.info_DLG.dlgCs1) ? int.Parse(this.info_DLG.dlgCs1) : 0;
                    //��ʼ��·���������
                    this._iPathWayMaxDay = Convertor.IsInteger(this.info_DLG.dlgCs2) ? int.Parse(this.info_DLG.dlgCs2) : 0;
                    //��ʼ��·������
                    this._sPathWayName = this.info_DLG.dlgCs3;
                    //��ʼ��·���汾
                    this._sPathWayVersion = this.info_DLG.dlgCs4;
                    //��ʼ��·������
                    this._sPathWayAmount = this.info_DLG.dlgCs5;
                    //��ʼ��·��ֻ��״̬
                    this._bPathWayReadOnly = false;//modify by zouchihua 2013-10-16 ������Ҳ�����޸� this._iPathWayStatus != 1;//false; //
                    //��ʼ����������
                    this._sFormType = this.info_DLG.pKey2;

                    //״̬����ʾ���ڳ�ʼ�����
                    this.UseHelp("��״̬��ʾ��������Ϣ��ʼ����ϣ�", true);
                }
                else
                {
                    //��������б�Ϊ��,���ô���Tag,�ڴ������ʱ�ж�,���ΪClose,����ֱ�ӹر�
                    this.Tag = "Close";
                }
            }
            catch (Exception ex)
            {
                //״̬����ʾ��ʼ��ʧ��
                this.UseHelp("��״̬��ʾ����ʼ��������Ϣʧ�ܣ�" + ex.Message, true);
            }
        }

        /// <summary>
        /// ��ʼ���ؼ�(���췽������)
        /// </summary>
        void InitControls()
        {
            try
            {
                //״̬����ʾ���ڳ�ʼ���ؼ�
                this.UseHelp("��״̬��ʾ�����ڳ�ʼ���ؼ�", true);


                //��ʼ���׶���ʱ���ֿؼ���ʽ��
                this.tbTimeUp.Properties.EditMask = "d2";
                this.tbTimeDown.Properties.EditMask = "d2";

                #region TreeList��ؿؼ�

                #region ��Ŀ���ݱ༭��

                //ʵ������Ŀ���ݱ༭��
                this.editCONTENT = new LookEditItemCmb();
                //ʵ������Ŀ���ݵ����ؼ�
                this.spCONTENT = new ShowPopup();
                //������Ŀ���ݱ༭����ʾ��Ա
                this.editCONTENT.DisplayMember = "��Ŀ����";
                //������Ŀ���ݱ༭��ֵ��Ա
                this.editCONTENT.ValueMember = "��Ŀ����";
                //������Ŀ���ݱ༭����ʹ�ü���չ�������ؼ�
                this.editCONTENT.ShowPopupCanPressKeyDown = true;
                //������Ŀ���ݱ༭������ʱ������ֵΪ��
                this.editCONTENT.ShowPopupInputTextValueIsNull = true;
                //������Ŀ���ݱ༭��Ĭ��ֵ
                this.editCONTENT.DefualtText = null;
                //������Ŀ���ݱ༭�������ؼ�
                this.editCONTENT.PopupControl = this.spCONTENT;
                //������Ŀ���ݱ༭������Դ
                this.editCONTENT.DataSource = dtCONTENT;

                //������Ŀ���ݵ����ؼ���С
                this.spCONTENT.Size = new System.Drawing.Size(800, 200);
                //������Ŀ���ݵ����ؼ�ɸѡ��
                this.spCONTENT.Filter = "(ƴ���� like '{0}%' or ƴ���� like '%{0}%' or ��Ŀ���� like '%{0}%')";
                //������Ŀ���ݵ����ؼ������ֶ�
                this.spCONTENT.KeyMember = "KEYCODE";
                //������Ŀ���ݵ����ؼ����뷴��������
                this.spCONTENT.MustReturnDatarow = true;
                //��ʼ����Ŀ���ݵ����ؼ�������
                string[] strColNamesCONTENT = new string[]{"��Ŀ����","����","˵��","���","����",
                                                    "��λ","��װ����","��װ��λ","�����",
                                                    "��浥λ","ƴ����","�����","CODE","��Ŀ��Դ",
                                                    "KEYCODE","ҩƷ����", "ִ�п�������","ִ�п���"};
                //��ʼ����Ŀ���ݵ����ؼ���ʾ����
                string[] strHeadNamesCONTENT = new string[]{"ҽ������(��Ŀ����)","����","˵��","���","��λ����",
                                                    "������λ","��װ����","��װ��λ","�����",
                                                    "��浥λ","ƴ����","�����","����","��Ŀ��Դ",
                                                    "Ψһ����","ҩƷ����","ִ�п�������","ִ�п���"};
                //������Ŀ���ݵ����ؼ������ʾ
                this.spCONTENT.GridViewColumnInfo(strColNamesCONTENT, new int[] { 200, 50, 150, 100, 60, 60, 60, 60, 60, 60, 50, 0, 0, 0, 0, 0,100, 80 }, strHeadNamesCONTENT);

                #endregion

                //ʵ����ѡ�����༭��
                this.editSELECT_TYPE = CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE", true);
                //����ѡ�����༭������Դ
                this.editSELECT_TYPE.DataSource = dtSELECT_TYPE;

                //ʵ����ִ�����༭��
                this.editEXEC_TYPE = CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE", true);
                //����ִ�����༭������Դ
                this.editEXEC_TYPE.DataSource = dtEXEC_TYPE;

                //ʵ���������༭��
                this.editJS = CtlFun.CreateRepositoryItemCalcEdit(0);
                //���ü����༭���༭��ʽ��
                this.editJS.EditMask = "d";

                //ʵ���������༭��
                this.editJL = CtlFun.CreateRepositoryItemCalcEdit(2);
                //���ü����༭���༭��ʽ��
                this.editJL.EditMask = "f";

                #region ��λ�༭��

                //ʵ������λ�༭��
                this.editJLDW = new LookEditItemCmb();
                //ʵ������λ�����ؼ�
                this.spJLDW = new ShowPopup();
                //���õ�λ�༭����ʾ��Ա
                this.editJLDW.DisplayMember = "s_ypdw";
                //���õ�λ�༭��ֵ��Ա
                this.editJLDW.ValueMember = "s_ypdw";
                //���õ�λ�༭����ʹ�ü���չ�������ؼ�
                this.editJLDW.ShowPopupCanPressKeyDown = true;
                //���õ�λ�༭������ʱ������ֵΪ��
                this.editJLDW.ShowPopupInputTextValueIsNull = true;
                //���õ�λ�༭��Ĭ��ֵ
                this.editJLDW.DefualtText = null;
                //���õ�λ�༭�������ؼ�
                this.editJLDW.PopupControl = this.spJLDW;
                //���õ�λ�༭������Դ
                this.editJLDW.DataSource = dtJLDW;

                //���õ�λ�����ؼ�ɸѡ��
                this.spJLDW.Filter = "(s_ypdw like '%{0}%')";
                //���õ�λ�����ؼ������ֶ�
                this.spJLDW.KeyMember = "dwlx";
                //���õ�λ�����ؼ����뷴��������
                this.spJLDW.MustReturnDatarow = true;
                //��ʼ����λ�����ؼ�������
                string[] strColNamesJLDW = new string[] { "s_ypdw", "dwlx" };
                //��ʼ����λ�����ؼ���ʾ����
                string[] strHeadNamesJLDW = new string[] { "��λ", "��λ����" };
                //���õ�λ�����ؼ������ʾ
                this.spJLDW.GridViewColumnInfo(strColNamesJLDW, new int[] { 50, 0 }, strHeadNamesJLDW);

                #endregion

                #region �÷��༭��

                //ʵ�����÷��༭��
                this.editYF = new LookEditItemCmb();
                //ʵ�����÷������ؼ�
                this.spYF = new ShowPopup();
                //�����÷��༭����ʾ��Ա
                this.editYF.DisplayMember = "�÷�";
                //�����÷��༭��ֵ��Ա
                this.editYF.ValueMember = "���";
                //�����÷��༭����ʹ�ü���չ�������ؼ�
                this.editYF.ShowPopupCanPressKeyDown = true;
                //�����÷��༭������ʱ������ֵΪ��
                this.editYF.ShowPopupInputTextValueIsNull = true;
                //�����÷��༭��Ĭ��ֵ
                this.editYF.DefualtText = null;
                //�����÷��༭�������ؼ�
                this.editYF.PopupControl = this.spYF;
                //�����÷��༭������Դ
                this.editYF.DataSource = dtYF;

                //�����÷������ؼ�ɸѡ��
                this.spYF.Filter = "( �÷� like '%{0}%' or ƴ���� like '%{0}%')";
                //�����÷������ؼ������ֶ�
                this.spYF.KeyMember = "���";
                //�����÷������ؼ����뷴��������
                this.spYF.MustReturnDatarow = true;
                //��ʼ���÷������ؼ�������
                string[] strColNamesYF = new string[] { "�÷�", "���" };
                //��ʼ���÷������ؼ���ʾ����
                string[] strHeadNamesYF = new string[] { "�÷�", "���" };
                //�����÷������ؼ������ʾ
                this.spYF.GridViewColumnInfo(strColNamesYF, new int[] { 80, 0 }, strHeadNamesYF);

                #endregion

                #region Ƶ�α༭��

                //ʵ����Ƶ�α༭��
                this.editPC = new LookEditItemCmb();
                //ʵ����Ƶ�ε����ؼ�
                this.spPC = new ShowPopup();
                //����Ƶ�α༭����ʾ��Ա
                this.editPC.DisplayMember = "Ƶ��";
                //����Ƶ�α༭��ֵ��Ա
                this.editPC.ValueMember = "���";
                //����Ƶ�α༭����ʹ�ü���չ�������ؼ�
                this.editPC.ShowPopupCanPressKeyDown = true;
                //����Ƶ�α༭������ʱ������ֵΪ��
                this.editPC.ShowPopupInputTextValueIsNull = true;
                //����Ƶ�α༭��Ĭ��ֵ
                this.editPC.DefualtText = null;
                //����Ƶ�α༭�������ؼ�
                this.editPC.PopupControl = this.spPC;
                //����Ƶ�α༭������Դ
                this.editPC.DataSource = dtPC;

                //����Ƶ�ε����ؼ�ɸѡ��
                this.spPC.Filter = "( Ƶ�� like '%{0}%' or ƴ���� like '%{0}%')";
                //����Ƶ�ε����ؼ������ֶ�
                this.spPC.KeyMember = "���";
                //����Ƶ�ε����ؼ����뷴��������
                this.spPC.MustReturnDatarow = true;
                //��ʼ��Ƶ�ε����ؼ�������
                string[] strColNamesPC = new string[] { "Ƶ��", "���" };
                //��ʼ��Ƶ�ε����ؼ���ʾ����
                string[] strHeadNamesPC = new string[] { "Ƶ��", "���" };
                //����Ƶ�ε����ؼ������ʾ
                this.spPC.GridViewColumnInfo(strColNamesPC, new int[] { 50, 0 }, strHeadNamesPC);

                #endregion

                //ʵ����ͣ���ձ༭��
                this.editTS = CtlFun.CreateRepositoryItemCalcEdit(0);
                //����ͣ���ձ༭���༭��ʽ��
                this.editTS.EditMask = "d2";

                //ʵ���������׶α༭��
                this.editPATH_STEP_ID = CtlFun.CreateRepositoryItemLookUpEdit("PATH_STEP_NAME", "PATH_STEP_ID", true);
                //���ô����׶α༭������Դ
                this.editPATH_STEP_ID.DataSource = dtStep;
                //���ô����׶α༭��������ť��ʾ״̬
                this.editPATH_STEP_ID.Buttons[0].Visible = false;

                //�жϴ��������Ƿ�Ϊ������
                if (this._sFormType == "1")
                {
                    //ʵ�������۱༭��
                    this.editPRICE = CtlFun.CreateRepositoryItemCalcEdit(2);
                    //���õ��۱༭���༭��ʽ��
                    this.editJL.EditMask = "f";
                }

                //��ʼ��TreeList������
                InitTreeListColumns();

                #endregion

                //ʵ�������ݼ����߳�
                this.bwLoadData = new BackgroundWorker();
                //�������ݼ��ؽ��̱����첽����
                this.bwLoadData.WorkerReportsProgress = true;

                //״̬����ʾ�ؼ���ʼ�����
                this.UseHelp("��״̬��ʾ���ؼ���ʼ����ϣ�", true);
            }
            catch (Exception ex)
            {
                //״̬����ʾ��ʼ���ؼ�ʧ��
                this.UseHelp("��״̬��ʾ����ʼ���ؼ�ʧ�ܣ�" + ex.Message, true);
            }
        }

        /// <summary>
        /// ��ʼ��TreeList��
        /// </summary>
        void InitTreeListColumns()
        {
            try
            {
                //״̬����ʾ���ڳ�ʼ��������
                this.UseHelp("��״̬��ʾ�����ڳ�ʼ��������...", true);

                #region ���ص�������

                //��ӽ׶���ĿID��
                TreeListColumnAdd("PATH_STEP_ITEM_ID", "PATH_STEP_ITEM_ID");
                //��ӽ׶���Ŀ����ID��
                TreeListColumnAdd("STEP_ITEM_KIND_ID", "STEP_ITEM_KIND_ID");
                //��ӽ׶���Ŀ����·��ID��
                TreeListColumnAdd("PATHAWAY_ID", "PATHAWAY_ID");
                //�����Ŀ������
                TreeListColumnAdd("ITEMKIND", "ITEMKIND");
                //��ӳ�����������
                TreeListColumnAdd("MNGTYPE", "MNGTYPE");
                //��Ӽ�¼������
                TreeListColumnAdd("OPER_DATE", "OPER_DATE");
                //��Ӽ�¼����
                TreeListColumnAdd("EMPID_OPER", "EMPID_OPER");
                //���ƴ������
                TreeListColumnAdd("PY_CODE", "PY_CODE");
                //����������
                TreeListColumnAdd("WB_CODE", "WB_CODE");
                //���ɾ�������
                TreeListColumnAdd("DELETE_BIT", "DELETE_BIT");
                //���ִ�п�����
                TreeListColumnAdd("ZXKS", "ZXKS");
                //�����ĿID��
                TreeListColumnAdd("XMID", "XMID");
                //�����Ŀ��Դ��
                TreeListColumnAdd("XMLY", "XMLY");
                //��Ӽ�����λID��
                TreeListColumnAdd("JLDWID", "JLDWID");
                //��ӵ�λ������
                TreeListColumnAdd("DWLX", "DWLX");
                //��ӷ��������
                TreeListColumnAdd("FZXH", "FZXH");
                //����Ա�ҩ��
                TreeListColumnAdd("BZBY", "BZBY");
                //��ӳ���ID��
                TreeListColumnAdd("CJID", "CJID");
                //��������
                TreeListColumnAdd("lb", "lb");
                //��ӳ���ҽ��ͣ��������
                TreeListColumnAdd("CQYZTZTS", "CQYZTZTS");
                //������������
                TreeListColumnAdd("SORT", "SORT", false, true, false, false, -1, 0, false, null, Color.Black);

                #endregion

                #region ��ʾ��������

                switch (this._sFormType)
                {
                    case "0":
                        //�����Ŀ������
                        TreeListColumnAdd("��Ŀ����", "CONTENT", true, 1, 230, true, editCONTENT, Color.DarkBlue);
                        //��ӷ�������
                        TreeListColumnAdd("", "Grouping", false, 2, 20, true, null, Color.DarkGreen);
                        //���ѡ�������
                        TreeListColumnAdd("ѡ�����", "SELECT_TYPE", true, 3, 60, false, editSELECT_TYPE, Color.Black);
                        //���ִ�������
                        TreeListColumnAdd("ִ�����", "EXEC_TYPE", true, 4, 60, false, editEXEC_TYPE, Color.Black);
                        //��ӹ����
                        TreeListColumnAdd("���", "NOTES", false, 5, 80, false, null, Color.Black);
                        //��Ӽ�����
                        TreeListColumnAdd("����", "JS", false, 6, 50, false, editJS, Color.Black);
                        //��Ӽ�����
                        TreeListColumnAdd("����", "JL", true, 7, 50, false, editJL, Color.Black);
                        //��ӵ�λ��
                        TreeListColumnAdd("��λ", "JLDW", true, 8, 50, false, editJLDW, Color.Black);
                        //����÷���
                        TreeListColumnAdd("�÷�", "YF", true, 9, 80, false, editYF, Color.Black);
                        //���Ƶ����
                        TreeListColumnAdd("Ƶ��", "PC", true, 10, 50, false, editPC, Color.Black);
                        //���ͣ����
                        TreeListColumnAdd("ͣ����", "TS", true, 11, 50, false, editTS, Color.Red);
                        //���������
                        TreeListColumnAdd("����", "ZT", true, 12, 100, false, null, Color.Black);
                        //��Ӵ����׶�
                        TreeListColumnAdd("�����׶�", "PATH_STEP_ID", false, 13, 80, false, editPATH_STEP_ID, Color.Black);
                        break;
                    case "1":
                        //�����Ŀ������
                        TreeListColumnAdd("��Ŀ����", "CONTENT", true, 1, 230, true, editCONTENT, Color.DarkBlue);
                        //��ӷ�������
                        TreeListColumnAdd("", "Grouping", false, 2, 20, true, null, Color.DarkGreen);
                        //���ѡ�������
                        TreeListColumnAdd("ѡ�����", "SELECT_TYPE", true, 3, 60, false, editSELECT_TYPE, Color.Black);
                        //���ִ�������
                        TreeListColumnAdd("ִ�����", "EXEC_TYPE", true, 4, 60, false, editEXEC_TYPE, Color.Black);
                        //��ӹ����
                        TreeListColumnAdd("���", "NOTES", false, 5, 80, false, null, Color.Black);
                        //��Ӽ�����
                        TreeListColumnAdd("����", "JS", false, 6, 50, false, editJS, Color.Black);
                        //��Ӽ�����
                        TreeListColumnAdd("����", "JL", true, 7, 50, false, editJL, Color.Black);
                        //��ӵ���
                        TreeListColumnAdd("����", "PRICE", true, 8, 80, false, null, Color.Black);
                        //��ӵ�λ��
                        TreeListColumnAdd("��λ", "JLDW", true, 9, 50, false, editJLDW, Color.Black);
                        //����÷���
                        TreeListColumnAdd("�÷�", "YF", true, 10, 80, false, editYF, Color.Black);
                        //���Ƶ����
                        TreeListColumnAdd("Ƶ��", "PC", true, 11, 50, false, editPC, Color.Black);
                        //���ͣ����
                        TreeListColumnAdd("ͣ����", "TS", true, 12, 50, false, editTS, Color.Red);
                        //���������
                        TreeListColumnAdd("����", "ZT", true, 13, 100, false, null, Color.Black);
                        //��Ӵ����׶�
                        TreeListColumnAdd("�����׶�", "PATH_STEP_ID", false, 14, 80, false, editPATH_STEP_ID, Color.Black);
                        break;
                }

                #endregion

                //״̬����ʾ�����г�ʼ�����
                this.UseHelp("��״̬��ʾ�������г�ʼ����ϣ�", true);
            }
            catch (Exception ex)
            {
                //״̬����ʾ�г�ʼ��ʧ��
                this.UseHelp("��״̬��ʾ�������г�ʼ��ʧ�ܣ�" + ex.Message, true);
            }
        }

        /// <summary>
        /// ��ʼ���¼�(���췽������)
        /// </summary>
        void InitEvents()
        {
            //��������¼�
            this.Load += new EventHandler(FrmPathWayModify_Load);
            //����·����ť�����¼�
            this.btnSavePathWay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnSavePathWay_ItemClick);
            //·��������ť�����¼�
            this.btnPathWayAssessment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnPathWayAssessment_ItemClick);
            //�����ֵ䰴ť�����¼�
            this.btnRuleDictionary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnRuleDictionary_ItemClick);
            //·��ͼ�οؼ�Ԫ��ɾ���¼�
            this.pathWay.Item_DeleteAfter += new PathWay.PathWay.Item_DeleteHandler(pathWay_Item_DeleteAfter);
            //·��ͼ�οؼ�Ԫ��ѡ���¼�
            this.pathWay.Item_Add_Sel_Modiy_After += new PathWay.PathWay.Item_Add_Sel_Modiyf_Handler(pathWay_Item_Add_Sel_Modiy_After);
            //�׶���Ŀ��Ӱ�ť�����¼�
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            //�׶���Ŀ������Ӱ�ť�����¼�
            this.btnAddKind.Click += new EventHandler(btnAddKind_Click);
            //�׶���Ŀ˵��ҽ����Ӱ�ť�����¼�
            this.btnExplain.Click += new EventHandler(btnExplain_Click);
            //�׶���Ŀ��������ҽ����Ӱ�ť�����¼�
            this.btnOperation.Click += new EventHandler(btnOperation_Click);
            //�׶���Ŀɾ����ť�����¼�
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            //�׶����ı������ݸı��¼�
            this.tbStepName.TextChanged += new EventHandler(tbStepName_TextChanged);
            //�׶���ʼʱ���ı������ݸı��¼�
            this.tbTimeUp.TextChanged += new EventHandler(tbTimeUp_TextChanged);
            //�׶ν����¼��ı������ݸı��¼�
            this.tbTimeDown.TextChanged += new EventHandler(tbTimeDown_TextChanged);
            //��ʼ�׶μ�����״̬�ı��¼�
            this.chkIsFirst.CheckedChanged += new EventHandler(chkIsFirst_CheckedChanged);
            //�Ҽ��˵�չ���¼�
            this.cmsTreeList.Opening += new CancelEventHandler(cmsTreeList_Opening);
            //ҩƷ���鰴ť�����¼�
            this.btnGrouping.Click += new EventHandler(btnGrouping_Click);
            //ȡ�����鰴ť�����¼�
            this.btnCancelGrouping.Click += new EventHandler(btnCancelGrouping_Click);
            //��Ŀ���ݱ༭������ѡ���¼�
            this.editCONTENT.AfterSelData += new Trasen.Base.Cmb.PubFun.OnAfterSelDataHandle(editCONTENT_AfterSelData);
            //��λ�༭������ѡ���¼�
            this.editJLDW.AfterSelData += new Trasen.Base.Cmb.PubFun.OnAfterSelDataHandle(editJLDW_AfterSelData);
            //���ݼ����̹߳����¼�
            this.bwLoadData.DoWork += new DoWorkEventHandler(bwLoadData_DoWork);
            //���ݼ����߳̽��ȸ����¼�
            this.bwLoadData.ProgressChanged += new ProgressChangedEventHandler(bwLoadData_ProgressChanged);
            //���ݼ����߳�ִ������¼�
            this.bwLoadData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwLoadData_RunWorkerCompleted);
            //�������رն����¼�
            this.tmrLoadingClose.Tick += new EventHandler(tmrLoadingClose_Tick);
            //���ؼ��ڵ㵥Ԫ���û������¼�
            this.tlItem.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(tlItem_CustomDrawNodeCell);
            //���ؼ���Ԫ��ֵ�ı��¼�
            this.tlItem.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(tlItem_CellValueChanged);
            //���ؼ����̰����¼�
            this.tlItem.KeyDown += new KeyEventHandler(tlItem_KeyDown);
            //���ؼ��༭�����̰����¼�
            this.tlItem.EditorKeyDown += new KeyEventHandler(tlItem_EditorKeyDown);
            
            
            //���ؼ��۽��ڵ�ı��¼�
            this.tlItem.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(tlItem_FocusedNodeChanged);
            //���ؼ��۽��иı��¼�
            this.tlItem.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(tlItem_FocusedColumnChanged);
            //ִ�����������ر��¼�
            this.editEXEC_TYPE.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(editEXEC_TYPE_CloseUp);


            this.editCONTENT.QueryPopUp += new CancelEventHandler(editCONTENT_QueryPopUp);
            this.editPC.QueryPopUp += new CancelEventHandler(editCONTENT_QueryPopUp);
            this.editYF.QueryPopUp += new CancelEventHandler(editCONTENT_QueryPopUp);
            this.editJLDW.QueryPopUp += new CancelEventHandler(editCONTENT_QueryPopUp);
        }

        void editCONTENT_QueryPopUp(object sender, CancelEventArgs e)
        {
            SendKeys.Send(" ");
            
            SendKeys.Send("{BACKSPACE}");  
             
        }

         



         
        

        /// <summary>
        /// ��ʼ������(���췽������)
        /// </summary>
        void InitData()
        {
            try
            {
                //״̬����ʾ���ڳ�ʼ������
                this.UseHelp("��״̬��ʾ�����ڼ�������...", true);

                //ͣ�ý׶�ͼ�οؼ�
                this.pathWay.Enabled = false;
                //ͣ�ý׶���Ϣ���
                this.plStepInfo.Enabled = false;
                //ͣ�����ؼ�
                this.tlItem.Enabled = false;
                //��ʾ�������
                this.plLoading.Show();
                //�������ݼ����߳�
                this.bwLoadData.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                //״̬����ʾ��ʼ������ʧ��
                this.UseHelp("��״̬��ʾ����������ʧ�ܣ�" + ex.Message);
            }
        }

        /// <summary>
        /// ��ʼ��SQL���(���̵߳���)
        /// </summary>
        void InitSQLString()
        {
            try
            {
                //��¼��־
                Logger("��״̬��ʾ�����ڳ�ʼ��SQL���...");

                
                //��ʼ���׶β�ѯ���
                this._sSqlStep = string.Format("SELECT * FROM [PATH_STEP] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", this._sPathWayId);
                
                //��ʼ���׶ι�����ѯ���
                this._sSqlStepRelation = string.Format("SELECT * FROM [PATH_STEP_RALATE] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", this._sPathWayId);
                
                //��ʼ���̶��ṹ��ѯ���
                this._sSqlFixedStructure = @"SELECT 'ITEMKIND_' + CAST([CODE] AS VARCHAR(10)) AS ID,
                                                                                         NULL AS ParentID,
                                                                                       [NAME] AS CONTENT,
                                                                                          -10 AS lb,
                                                                                         NULL AS MNGTYPE,
                                                                      CAST([CODE] AS TINYINT) AS ITEMKIND 
                                            FROM [PATH_DM] WHERE [KIND] IN (100) AND VALID IN (1) 
                                        UNION SELECT 'MNGTYPE_' + CAST([CODE] AS VARCHAR(10)) AS ID,
                                       (CASE WHEN [KIND]=101 THEN 'ITEMKIND_2' ELSE NULL END) AS ParentID,
                                                                                       [NAME] AS CONTENT,
                                                                                           -1 AS lb,
                                                                      CAST([CODE] AS TINYINT) AS MNGTYPE,
                                                                           CAST(2 AS TINYINT) AS ITEMKIND 
                                            FROM [PATH_DM] WHERE [KIND] IN (101) AND VALID IN (1)";

                #region ҽ����Ŀ��ѯ���
                
                //��ʼ��ҽ����Ŀ��ѯ���
                this._sSqlCONTENT = @"SELECT * FROM (SELECT a.[ORDER_NAME] AS ��Ŀ����,
																	  '' AS ����,
																	[BZ] AS ˵��,
																	  '' AS ���,
																	   1 AS ����,
															[ORDER_UNIT] AS ��λ,
													      dbo.FUN_ZY_SEEKHOITEMPRICE(ORDER_ID," + FrmMdiMain.Jgbm + @") AS ��װ����,
															[ORDER_UNIT] AS ��װ��λ,
    															    NULL AS �����,
																	NULL AS ��浥λ,
															 a.[PY_CODE] AS ƴ����,
                                                             a.[WB_CODE] AS �����,
															  [ORDER_ID] AS CODE,
															         '2' AS ��Ŀ��Դ,
								   CAST([ORDER_ID] AS VARCHAR(30)) +'_2' AS KEYCODE ,
								    							    '00' AS ҩƷ����,
																	   0 AS ִ�п���,
                                                                     '' as ִ�п�������,
                                                                       0 AS ���ID,
                                                            [ORDER_TYPE] AS ҽ������,
                                                                               0 as pxxh
					                                FROM [JC_HOITEMDICTION] a left join [JC_HOI_HDI] b on a.ORDER_ID=b.HOITEM_ID
                                    left join [JC_HSITEM] c on b.HDITEM_ID=c.ITEM_ID WHERE a.[DELETE_BIT] = 0 UNION
														 SELECT [S_YPPM] AS ��Ŀ����,
														    	[S_YPJX] AS ����,
																[s_sccj] AS ˵��,
																  [YPGG] AS ���,
																  [HLXS] AS ����,
												 DBO.FUN_YP_YPDW([HLDW]) AS ��λ,
																   [LSJ] AS ��װ����,
												 DBO.FUN_YP_YPDW([BZDW]) AS ��װ��λ,
																   [KCL] AS �����,
												 DBO.FUN_YP_YPDW([ZXDW]) AS ��浥λ,
																 B.[PYM] AS ƴ����,
                                                                 B.[WBM] AS �����,
																  [CJID] AS CODE,
																     '1' AS ��Ŀ��Դ,
           CAST(isnull([CJID],0) AS VARCHAR(30)) + CAST(isnull(B.[ID],0) AS VARCHAR(20)) + '_' + CAST(isnull([DEPTID],0) AS VARCHAR(30)) + '_1' AS KEYCODE,
														 [STATITEM_CODE] AS ҩƷ����,
																[DEPTID] AS ִ�п���,
                                                                dbo.fun_getDeptname([DEPTID])   as ִ�п�������,
                                                                A.[GGID] AS ���ID,
                                                                       0 AS ҽ������,
                                                                        0 as pxxh
									   FROM [VI_YF_KCMX] A LEFT JOIN [YP_YPBM] B ON A.[GGID]=B.[GGID])T ORDER BY LEN(ƴ����)";

                #endregion

                //��ʼ����λ��ѯ���
                this._sSqlJLDW = "EXEC SP_YF_SELECT_DW {0},{1}";

                //��ʼ���÷���ѯ���
                this._sSqlYF = "SELECT [NAME] AS �÷�,[PY_CODE] AS ƴ����,[ID] AS ��� FROM [JC_USAGEDICTION]";

                //��ʼ��Ƶ�β�ѯ���
                this._sSqlPC = "SELECT [NAME] AS Ƶ��,[PY_CODE] AS ƴ����,[ID] AS ��� FROM [JC_FREQUENCY]";

                #region ��ʼ���׶���Ŀ��ѯ���
                //��ʼ���׶���Ŀ����ѯ���
                string sSqlStepItemMain = "SELECT {0} * FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{1}' AND [DELETE_BIT] = 0 ORDER BY SORT";
                //��ʼ���׶���Ŀ�Զ����ѯ�ֶ�
                string sSqlStepItemFields = @"
                    CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                    (CASE 
                        WHEN [STEP_ITEM_KIND_ID] IS NOT NULL THEN CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50))
                        WHEN [STEP_ITEM_KIND_ID] IS NULL AND [ITEMKIND] =2 THEN 'MNGTYPE_' + CAST([MNGTYPE] AS VARCHAR(10))
                        WHEN [STEP_ITEM_KIND_ID] Is NULL AND [ITEMKIND]<>2 THEN 'ITEMKIND_' + CAST([ITEMKIND] AS VARCHAR(10))
                    END) AS ParentID,
                       3 AS lb,
                      '' AS Grouping,";
                //��ʼ���׶���Ŀ��ѯ���
                this._sSqlStepItem = string.Format(sSqlStepItemMain, sSqlStepItemFields, this._sPathWayId);
                //��ʼ���׶���Ŀ��ѯ���(���ڱ���)
                this._sSqlStepItemSave = string.Format(sSqlStepItemMain, "", this._sPathWayId);
                #endregion


                #region ��ʼ���׶���Ŀ�����ѯ���
                //��ʼ���׶���Ŀ��������ѯ���
                string sSqlStepItemKindMain = "SELECT {0} * FROM [PATH_STEP_ITEM_KIND] WHERE [PATHAWAY_ID] = '{1}' AND [DELETE_BIT] = 0 ORDER BY SORT";
                //��ʼ���׶���Ŀ�����Զ����ѯ�ֶ�
                string sSqlStepItemKindFields = @"
                    CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ID,
                    (CASE 
                        WHEN ITEMKIND =2 THEN 'MNGTYPE_' + CAST([MNGTYPE] AS VARCHAR(10)) 
                        ELSE 'ITEMKIND_' + CAST([ITEMKIND] AS  VARCHAR(10)) 
                    END) AS ParentID,
                       2 AS lb,
                      '' AS Grouping,";
                //��ʼ���׶���Ŀ�����ѯ���
                this._sSqlStepItemKind = string.Format(sSqlStepItemKindMain, sSqlStepItemKindFields, this._sPathWayId);
                //��ʼ���׶���Ŀ�����ѯ���(���ڱ���)
                this._sSqlStepItemKindSave = string.Format(sSqlStepItemKindMain, "", this._sPathWayId);
                #endregion


                //��¼��־
                Logger("��״̬��ʾ��SQL����ʼ����ϣ�");
            }
            catch (Exception ex)
            {
                //��¼��־
                Logger("��״̬��ʾ��SQL����ʼ��ʧ�ܣ�" + ex.Message);
                //�����쳣������һ��
                throw ex;
            }
        }

        #endregion

        #region �¼�����

        /// <summary>
        /// ��������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FrmPathWayModify_Load(object sender, EventArgs e)
        {
            //�жϹ��캯���г�ʼ����Tag,���ΪClose,��ֱ�ӹرմ���
            if (this.Tag != null && this.Tag.ToString().Equals("Close"))
            {
                //���TagΪClose,����ʾ��Ϣ
                MessageBox.Show("δ��ȡ�����õĲ����б����ڼ����رա�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //�رմ���
                this.Close();
            }

            //���ݴ����������ÿؼ�����
            switch (this._sFormType)
            {
                case "0":
                    //���ô������
                    this.Text = string.Format("·�����á���ǰ·����{0}|�汾��{1}|���ã�{2}��", this._sPathWayName, this._sPathWayVersion, this._sPathWayAmount);
                    this.btnSavePathWay.Caption = "����·��(&S)";
                    this.btnPathWayAssessment.Caption = "·������(&A)";
                    break;
                case "1":
                    //���ô������
                    this.Text = string.Format("���������á���ǰ���֣�{0}|�汾��{1}|���ã�{2}��", this._sPathWayName, this._sPathWayVersion, this._sPathWayAmount);
                    this.btnSavePathWay.Caption = "���浥����(&S)";
                    this.btnPathWayAssessment.Caption = "����������(&A)";
                    break;
            }


        }

        #region ���ݼ���

        /// <summary>
        /// ���ݼ����̹߳����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //�����첽����
                this.bwLoadData.ReportProgress(0,"���ڳ�ʼ����ѯ...");
                //��ʼ��SQL���
                InitSQLString();
                //�����첽����
                this.bwLoadData.ReportProgress(1, "���ڼ��ؽ׶���Ϣ...");
                //��ʼ���׶�����
                dtStep = DbOpt.GetDataTable(this._sSqlStep);
                //�����첽����
                this.bwLoadData.ReportProgress(2, "���ڼ��ع�����Ϣ...");
                //��ʼ���׶ι�������
                dtStepRelation = DbOpt.GetDataTable(this._sSqlStepRelation);
                //����ģ��
                LoadModel();
                //�����첽����
                this.bwLoadData.ReportProgress(3, "���ڼ��ع̶��ṹ...");
                //��ʼ���̶��ṹ����
                dtFixedStructure = DbOpt.GetDataTable(this._sSqlFixedStructure);
                //�����첽����
                this.bwLoadData.ReportProgress(4, "���ڼ����÷���Ϣ...");
                //��ʼ���÷�����
                dtYF = DbOpt.GetDataTable(this._sSqlYF);
                //�����첽����
                this.bwLoadData.ReportProgress(5, "���ڼ���Ƶ����Ϣ...");
                //��ʼ��Ƶ������
                dtPC = DbOpt.GetDataTable(this._sSqlPC);
                //�����첽����
                this.bwLoadData.ReportProgress(6, "���ڼ��ؽ׶���Ŀ...");
                //��ʼ���׶���Ŀ����
                dtStepItem = DbOpt.GetDataTable(this._sSqlStepItem);
                //�����첽����
                this.bwLoadData.ReportProgress(7, "���ڼ�����Ŀ����...");
                //��ʼ���׶���Ŀ��������
                dtStepItemKind = DbOpt.GetDataTable(this._sSqlStepItemKind);
                //�����첽����
                this.bwLoadData.ReportProgress(8, "���ڼ���ҽ����Ŀ...");
                //��ʼ��ҽ����Ŀ����
                dtCONTENT = DbOpt.GetDataTable(this._sSqlCONTENT);
                dtCONTENT_all = dtCONTENT.Copy();
                //�����첽����
                this.bwLoadData.ReportProgress(9, "���ڼ���ѡ������...");
                #region ��ʼ��ѡ���������

                //ʵ����ѡ�����ͱ�
                dtSELECT_TYPE = new DataTable();
                //�����첽����
                this.bwLoadData.ReportProgress(10, "���ڼ���ѡ������...");
                //�����ʾ��
                dtSELECT_TYPE.Columns.Add("NAME", typeof(System.String));
                dtSELECT_TYPE.Columns.Add("CODE", typeof(System.Byte));
                //�����첽����
                this.bwLoadData.ReportProgress(11, "���ڼ���ѡ������...");
                //��ѡ�����ͱ���һ������
                DataRow drNewSelect = dtSELECT_TYPE.NewRow();
                //��ʼ����������,����ӵ�ѡ�����ͱ�
                drNewSelect = dtSELECT_TYPE.NewRow(); drNewSelect.ItemArray = new object[] { "��ѡ", 0 }; dtSELECT_TYPE.Rows.Add(drNewSelect);
                drNewSelect = dtSELECT_TYPE.NewRow(); drNewSelect.ItemArray = new object[] { "��ѡ", 1 }; dtSELECT_TYPE.Rows.Add(drNewSelect);
                //�����첽����
                this.bwLoadData.ReportProgress(12, "���ڼ���ѡ������...");
                #endregion
                #region ��ʼ��ִ�����
                //ʵ����ִ������
                dtEXEC_TYPE = new DataTable();
                //�����첽����
                this.bwLoadData.ReportProgress(13, "���ڼ���ִ�����...");
                //�����ʾ��
                dtEXEC_TYPE.Columns.Add("NAME", typeof(System.String));
                dtEXEC_TYPE.Columns.Add("CODE", typeof(System.Byte));
                //��ִ��������һ������
                DataRow drNewExec = dtEXEC_TYPE.NewRow();
                //��ʼ����������,����ӵ�ִ������
                drNewExec = dtEXEC_TYPE.NewRow(); drNewExec.ItemArray = new object[] { "��ѡ", 0 }; dtEXEC_TYPE.Rows.Add(drNewExec);
                drNewExec = dtEXEC_TYPE.NewRow(); drNewExec.ItemArray = new object[] { "��ѡ", 1 }; dtEXEC_TYPE.Rows.Add(drNewExec);

                //�����첽����
                this.bwLoadData.ReportProgress(14, "���ݼ������...");
                #endregion
            }
            catch (Exception ex)
            {
                //״̬����ʾ���ݼ����߳��쳣
                this.UseHelp("��״̬��ʾ�����ݼ����߳��쳣��" + ex.Message, true);
            }
            
        }

        /// <summary>
        /// ���ݼ����߳̽��ȸ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bwLoadData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //���ü���ͼƬ����ʾͼƬ
            this.pbLoading.Image = this.ilLoading.Images[e.ProgressPercentage];
            //���ü����ı�
            this.lbLoading.Text = e.UserState.ToString();

            #region ���ݰ�

            switch (e.ProgressPercentage)
            {
                //�󶨽׶�ͼ��
                case 3:
                    //��������
                    dtStep.PrimaryKey = new DataColumn[] { dtStep.Columns["PATH_STEP_ID"] };
                    dtStepRelation.PrimaryKey = new DataColumn[] { dtStepRelation.Columns["PATH_STEP_RALATE_ID"] };
                    //��DataTable����ͼ��
                    pathWay.LoadItem_FromDataTable(dtStep, dtStepRelation);
                    break;
                //�󶨹̶��ṹ
                case 4:
                    //ʵ�������ؼ�����ʾ��
                    dtBindShow = new DataTable();
                    //�ϲ��̶������
                    dtBindShow.Merge(dtFixedStructure);
                    break;
                //���÷�
                case 5:
                    //�����÷��༭������Դ
                    editYF.DataSource = dtYF;
                    break;
                //��Ƶ��
                case 6:
                    //����Ƶ�α༭������Դ
                    editPC.DataSource = dtPC;
                    break;
                //�󶨽׶���Ŀ
                case 7:
                    //�ϲ��׶���Ŀ��
                    dtBindShow.Merge(dtStepItem);
                    break;
                //�󶨽׶���Ŀ����
                case 8:
                    //�ϲ��׶���Ŀ�����
                    dtBindShow.Merge(dtStepItemKind);
                    //��������
                    dtBindShow.PrimaryKey = new DataColumn[] { dtBindShow.Columns["ID"] };
                    Grouping();
                    //ʵ�����׶���Ŀ����Դ
                    bsItemData = new BindingSource();
                    //��������Դ���ݱ�
                    bsItemData.DataSource = dtBindShow;
                    //��������Դ����ʽ
                    bsItemData.Sort = "lb,PATH_STEP_ID desc,SORT";//modify by zouchihua 2013-11-5
                    //��������Դ������
                    bsItemData.Filter = "lb = -1 or lb = -10";
                    //�����ؼ�����Դ
                    tlItem.DataSource = bsItemData;
                    //չ�����ؼ�
                    tlItem.ExpandAll();
                    break;
                //����ҽ����Ŀ
                case 9:
                    //����ҽ�����ݱ༭������Դ
                    editCONTENT.DataSource = dtCONTENT;
                    break;
                //����ѡ�����
                case 12:
                    //����ѡ�����༭������Դ
                    editSELECT_TYPE.DataSource = dtSELECT_TYPE;
                    break;
                //����ִ�����
                case 14:
                    //����ִ�����༭������Դ
                    editEXEC_TYPE.DataSource = dtEXEC_TYPE;
                    //״̬����ʾ���ݳ�ʼ�����
                    this.UseHelp("��״̬��ʾ�����ݼ�����ϣ�", true);
                    break;
            }

            #endregion
        }

        /// <summary>
        /// ���ݼ����߳�ִ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //������嶯���ر�
            tmrLoadingClose.Start();
        }

        /// <summary>
        /// �������رն����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tmrLoadingClose_Tick(object sender, EventArgs e)
        {
            if (this.plLoading.Width != 0)
            {
                if (plLoading.Width > 150)
                {
                    //������������Լ�5
                    this.plLoading.Width-= 5;
                }
                else if (plLoading.Width <= 150)
                {
                    //������������Լ�10
                    this.plLoading.Width -= 10;
                }
                else if (plLoading.Width <= 100)
                {
                    //������������Լ�20
                    this.plLoading.Width -= 20;
                }
            }
            else
            {
                //���ý׶�ͼ�οؼ�
                this.pathWay.Enabled = true;
                //���ý׶���Ϣ���
                this.plStepInfo.Enabled = true;
                //�������ؼ�
                this.tlItem.Enabled = true;
                //���ؼ������
                this.plLoading.Hide();
                //ֹͣ����
                this.tmrLoadingClose.Stop();
            }
        }

        #endregion

        #region ���˵��ؼ�

        /// <summary>
        /// ����·����ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSavePathWay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode focusnode = tlItem.FocusedNode;
            //����׶�ͼ��
            SavePathStep(false);
            //����׶���Ŀ
            SaveStepItem();
            tlItem.FocusedNode = focusnode;
        }

        /// <summary>
        /// ·��������ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnPathWayAssessment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmPathWayAssessment(this._sPathWayId, this._sFormType == "0").ShowDialog();
        }

        /// <summary>
        /// �����ֵ䰴ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnRuleDictionary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmRuleDictionary(this._sFormType == "0").ShowDialog();
        }

        #endregion

        #region ·��ͼ�οؼ�

        /// <summary>
        /// ·��ͼ�οؼ�Ԫ��ɾ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pathWay_Item_DeleteAfter(object sender, EventArgs e)
        {
            try
            {
                //��ȡɾ����Ԫ��
                GItemObj delObj = (GItemObj)sender;
                //����obj.Name��ȡGUID
                string strGUID = delObj.Name.Substring(delObj.Type.Length + 1);
                //�ж�Ԫ������
                if (delObj.Type == "Item")
                {
                    if (dtStep.Rows.Find(strGUID) != null)
                        dtStep.Rows.Find(strGUID).Delete();
                }
                else
                {
                    if (dtStepRelation.Rows.Find(strGUID) != null)
                        dtStepRelation.Rows.Find(strGUID).Delete();
                }
            }
            catch (Exception ex)
            {
                //״̬����ʾɾ��ʧ��
                this.UseHelp("��״̬��ʾ��ɾ��ʧ�ܣ�" + ex.Message, true);
            }
        }

        /// <summary>
        /// ·��ͼ�οؼ�Ԫ��ѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="fl">��������</param>
        /// <param name="e"></param>
        void pathWay_Item_Add_Sel_Modiy_After(object sender, PathWay.PathWay.FenLei fl, EventArgs e)
        {
            //�жϲ����Ƿ�Ϊѡ��
            if (fl == PathWay.PathWay.FenLei.Sel)
            {
                //���浱ǰͼ��
                this.pathWay.SaveItem_ToDataTable(dtStep, dtStepRelation, this._sPathWayId);
                //�������ؼ��༭״̬
                this.tlItem.EndCurrentEdit();
                //�жϵ�ǰ�Ƿ���δ����Ĳ���
                if (dtBindShow != null && dtBindShow.GetChanges() != null)
                {
                    //�����Ϊ����Ĳ���,����ʾ�Ƿ񱣴�
                    if (MessageBox.Show("��ǰ�׶���Ŀδ����,�Ƿ񱣴���Ŀ?", "��ʾ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //ȷ���򱣴�����
                        SaveStepItem();
                    }
                    else
                    {
                        //ȡ�������ð󶨱�
                        dtBindShow.RejectChanges();
                    }
                }

                //������ѡ��Ľڵ����
                GItemObj selectObj = (GItemObj)sender;
                //��ȡ�ڵ�ID,����ֵ����ǰ�׶�ID
                this._sCurrentStepId = selectObj.Name.Remove(0, 5);
                //���ð�����Դ�Ĺ�����
                bsItemData.Filter = string.Format("(lb = -1 or lb = -10) or (PATH_STEP_ID = '{0}') and DELETE_BIT = 0", this._sCurrentStepId);

                //�жϽڵ��Ƿ�Ϊ�׶�
                if (selectObj.Type == GItemObj.KindInfo.Item.ToString())
                {
                    //���ý׶���Ϣ���
                    plStepInfo.Enabled = true;

                    #region ���ý׶���Ϣ

                    //����TAGֵΪSET,��ʾ����״̬
                    tbStepName.Tag = "set";
                    //��ȡ�׶���
                    this.tbStepName.Text = selectObj.Text;
                    //��ȡ�׶ν���ʱ��
                    this.tbTimeUp.Value = selectObj.TIME_UP / 1440;
                    //��ȡ�׶ο�ʼʱ��
                    this.tbTimeDown.Value = selectObj.TIME_DOWN / 1440 + 1;
                    //��ȡ�׶���ʼ״̬
                    this.chkIsFirst.Checked = selectObj.IsFirst;
                    //����TAGֵΪNULL,��ʾ����״̬
                    tbStepName.Tag = null;

                    #endregion

                    #region ������ʾ�ĳ���ҽ��

                    //��ʼ�����ڵ�����
                    string sContinuted = "";
                    //�ݹ��ѯ�׶θ��ڵ�
                    bool bFlag = SelectContinuedStepItem(this._sCurrentStepId, ref sContinuted);

                    //�жϸ��ڵ��Ƿ�Ϊ��
                    if (sContinuted != "")
                    {
                        //�����ڵ�ָ�������
                        string[] sSteps = sContinuted.Split(',');
                        //��ʼ����ʱ�õĸ��ڵ��б�
                        string tempContinuted = "";
                        //ѭ����������
                        foreach (string sStep in sSteps)
                        {
                            //�����ڵ�����ת��������ӵ��б�
                            tempContinuted += string.Format("CONVERT({0},'System.Guid'),", sStep);
                        }
                        //���ó�����ʾ�ĳ���ҽ����ѯ����
                        sContinuted = string.Format(" and PATH_STEP_ID in ({0})", tempContinuted.TrimEnd(','));
                    }
                    else
                    {
                        //���ó�����ʾ�ĳ���ҽ����ѯ����
                        sContinuted = " and 1<>1";
                    }

                    //��������Դ������
                    bsItemData.Filter += string.Format(" or (DELETE_BIT = 0 and MNGTYPE = 0 and (CQYZTZTS = 0 or CQYZTZTS is null or CQYZTZTS > {0}) and PATH_STEP_ID <> '{1}' {2})",
                        selectObj.TIME_DOWN, this._sCurrentStepId, sContinuted);
                    
                    #endregion

                    #region ���³�ʼ�����󶨴����׶α༭��

                    //ʵ���������׶α༭��
                    this.editPATH_STEP_ID = CtlFun.CreateRepositoryItemLookUpEdit("PATH_STEP_NAME", "PATH_STEP_ID", true);
                    //���ô����׶α༭������Դ
                    this.editPATH_STEP_ID.DataSource = dtStep;
                    //���ô����׶α༭��������ť��ʾ״̬
                    this.editPATH_STEP_ID.Buttons[0].Visible = false;
                    this.tlItem.Columns["PATH_STEP_ID"].ColumnEdit = editPATH_STEP_ID;

                    #endregion

                }
                else
                {
                    //���ý׶���Ϣ���
                    plStepInfo.Enabled = false;

                }
                //ˢ�½׶�ͼ��
                this.pathWay.Refresh();
                //չ�����ڵ�
                this.tlItem.ExpandAll();
            }
        }

        #endregion

        #region �׶���Ŀ�ؼ�

        /// <summary>
        /// �׶���Ŀ��Ӱ�ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddItem_Click(object sender, EventArgs e)
        {
            NewItem(true, NewItemKind.Normal,false);
        }

        /// <summary>
        /// �׶���Ŀ������Ӱ�ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddKind_Click(object sender, EventArgs e)
        {
            NewKind();
        }

        /// <summary>
        /// �׶���Ŀ˵��ҽ����Ӱ�ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnExplain_Click(object sender, EventArgs e)
        {
            NewItem(true, NewItemKind.Explain,false);
        }

        /// <summary>
        /// �׶���Ŀ��������ҽ����Ӱ�ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnOperation_Click(object sender, EventArgs e)
        {
            NewItem(true, NewItemKind.Operation,false);
        }

        /// <summary>
        /// �׶���Ŀɾ����ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        /// <summary>
        /// ��Ŀ���ݱ༭������ѡ���¼�
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SelectValue"></param>
        void editCONTENT_AfterSelData(object Sender, Trasen.Base.Cmb.PubFun.ValueInfo SelectValue)
        {
            //�ж�ѡ��ֵ�Ƿ�ƥ��,ƥ����ܽ��в���
            if (!SelectValue.CloseUpIsNotMatch)
            {
                //��ʼ��һ������,���ڱ��浯������ѡ���������
                DataRow selectRow = SelectValue.datarow;
                //CONTENT�ڿؼ�ѡ��ʱ���Զ���ֵ,�������ﲻ������
                tlItem.FocusedNode.SetValue("CONTENT", selectRow["��Ŀ����"].ToString());   //��ʼ����Ŀ����
                tlItem.FocusedNode.SetValue("NOTES", selectRow["���"].ToString());         //��ʼ�����
                tlItem.FocusedNode.SetValue("PY_CODE", selectRow["ƴ����"].ToString());     //��ʼ��ƴ����
                tlItem.FocusedNode.SetValue("WB_CODE", selectRow["�����"].ToString());     //��ʼ�������
                tlItem.FocusedNode.SetValue("JS", 1);                                       //��ʼ������(Ĭ��Ϊ1)
                tlItem.FocusedNode.SetValue("JL", selectRow["����"].ToString());            //��ʼ������
                tlItem.FocusedNode.SetValue("ZXKS", selectRow["ִ�п���"].ToString());      //��ʼ��ִ�п���
                tlItem.FocusedNode.SetValue("XMLY", selectRow["��Ŀ��Դ"].ToString());      //��ʼ����Ŀ��Դ
                tlItem.FocusedNode.SetValue("JLDW", selectRow["��λ"].ToString());          //��ʼ��������λ
                tlItem.FocusedNode.SetValue("TS", 0);                                       //��ʼ��ͣ����
                if (this._sFormType == "1")
                {
                    tlItem.FocusedNode.SetValue("PRICE", selectRow["��װ����"].ToString());  
                }
                //�ж���Ŀ��Դ�Ƿ�Ϊ1(1ΪҩƷ,2Ϊ��Ŀ),����CODE��ֵ��CJID,����ֵ��XMID  
                if (selectRow["��Ŀ��Դ"].ToString() == "1")
                {
                    tlItem.FocusedNode.SetValue("CJID", selectRow["CODE"].ToString());      //��ʼ������ID
                    tlItem.FocusedNode.SetValue("XMID", selectRow["���ID"].ToString());    //��ʼ�����ID

                    //�����ҩƷ,�����õ�λ����
                    //(1Ϊ������λ,2Ϊ��װ��λ,3Ϊҩ�ⵥλ,4Ϊҩ����λ)
                    tlItem.FocusedNode.SetValue("DWLX", 1);//Ĭ��Ϊ������λ                 //��ʼ����λ����
                }
                else
                {
                    tlItem.FocusedNode.SetValue("XMID", selectRow["CODE"].ToString());      //��ʼ����ĿID

                    dtBindShow.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["FZXH"] = DBNull.Value;
                    dtBindShow.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["Grouping"] = "";
                }

                //  JLDWID ������λID  δ����
                //  TS     ����        δ����
                //  YF     �÷�        ���û�����
                //  PC     Ƶ��        ���û�����
                //  ZT     ����        ���û�����
                //  BZBY   �Ա�ҩ      ���û�����

                tlItem.EndCurrentEdit();
                //������۽���ִ�����
                tlItem.FocusedColumn = tlItem.Columns["EXEC_TYPE"];
                //tlItem.ShowEditor();
            }
            else
            {
                tlItem.FocusedNode.SetValue("CONTENT", SelectValue.InputText);
                tlItem.EndCurrentEdit();
                //������۽���ִ�����
                tlItem.FocusedColumn = tlItem.Columns["EXEC_TYPE"];
            }
        }

        /// <summary>
        /// ��λ�༭������ѡ���¼�
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SelectValue"></param>
        void editJLDW_AfterSelData(object Sender, Trasen.Base.Cmb.PubFun.ValueInfo SelectValue)
        {
            if (!SelectValue.CloseUpIsNotMatch)
            {
                tlItem.FocusedNode.SetValue("JLDW", SelectValue.datarow["s_ypdw"].ToString());
                tlItem.FocusedNode.SetValue("DWLX", SelectValue.datarow["dwlx"].ToString());
                tlItem.EndCurrentEdit();
                //Modify by zouchihua ��λ����Ϊ�÷�  tlItem.FocusedColumn = tlItem.Columns["TS"].OptionsColumn.AllowEdit ? tlItem.Columns["TS"] : tlItem.Columns["YF"];
                tlItem.FocusedColumn =tlItem.Columns["YF"];
            }
        }

        /// <summary>
        /// ���ؼ��ڵ㵥Ԫ���û������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if ((e.Node == tlItem.FocusedNode && e.Column != tlItem.FocusedColumn) || e.Node == null || e.Column == null) return;
            if (e.Node["lb"].ToString() != "-1" && e.Node["lb"].ToString() != "-10" && e.Node["PATH_STEP_ID"].ToString() != this._sCurrentStepId)
            {
                e.Appearance.ForeColor = SystemColors.ControlDark;
                e.Appearance.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// ���ؼ���Ԫ��ֵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "TS")
            {
                e.Node["CQYZTZTS"] = Convert.ToInt32(e.Value) * 1440;
            }
        }

        /// <summary>
        /// ���ؼ����̰����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;
                case Keys.F2:
                    if (this.btnAddKind.Enabled)
                    {
                        //��������
                        NewKind();
                    }
                    break;
                case Keys.F3:
                    if (this.btnAddItem.Enabled)
                    {
                        //��������ҽ��
                        NewItem(true, NewItemKind.Normal,false);
                    }
                    break;
                case Keys.F7:
                    if (this.btnAddItem.Enabled)
                    {
                        //����˵��ҽ��
                        NewItem(true, NewItemKind.Explain,false);
                    }
                    break;
                case Keys.F8:
                    if (this.btnAddItem.Enabled)
                    {
                        //������������ҽ��
                        NewItem(true, NewItemKind.Operation,false);
                    }
                    break;
                case Keys.F9:
                    if (this.btnDelete.Enabled)
                    {
                        //ɾ����Ŀ
                        DeleteItem();
                    }
                    break;
            }
            //�жϰ����Ƿ�ΪEnter�ҵ�ǰ�۽����в�Ϊִ�����
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn != tlItem.Columns["EXEC_TYPE"] && tlItem.FocusedColumn != tlItem.Columns["SELECT_TYPE"])
            {
                ColIndexMove(e);
            }
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn == tlItem.Columns["SELECT_TYPE"])
            {
                tlItem.FocusedColumn = tlItem.Columns["EXEC_TYPE"];
                //this.tlItem.CloseEditor();
            }
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn == tlItem.Columns["EXEC_TYPE"])
            {

                this.tlItem.CloseEditor();
                ColIndexMove(e);
                //tlItem.FocusedColumn.ColumnEdit.LookAndFeel.OwnerControl
                //SendKeys.Send("{Right}");
                //tlItem.FocusedColumn = tlItem.Columns["NOTES"] ;
                
            }
        }

        /// <summary>
        /// ���ؼ��༭�����̰����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_EditorKeyDown(object sender, KeyEventArgs e)
        {

             
            //�жϰ����Ƿ�ΪEnter�ҵ�ǰ�۽����в�Ϊִ�����
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn != tlItem.Columns["EXEC_TYPE"] && tlItem.FocusedColumn != tlItem.Columns["SELECT_TYPE"])
            {
                ColIndexMove(e);
            }
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn == tlItem.Columns["SELECT_TYPE"])
            {
                SendKeys.Send("{Right}");
                
            }
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn == tlItem.Columns["EXEC_TYPE"])
            {
                
              // ColIndexMove(e);
                //this.tlItem.CloseEditor();
                //SendKeys.Send("{Right}");
                 //tlItem.FocusedColumn = tlItem.Columns["JS"].OptionsColumn.AllowEdit ? tlItem.Columns["JS"] : tlItem.Columns["JL"];
                 
            }
        }

        /// <summary>
        /// ���ؼ��۽��ڵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                //չ����ǰ�ڵ�
                e.Node.Expanded = true;

                //��ȡ�ڵ�����
                string sLb = e.Node.GetValue("lb").ToString();
                //��ʼ�����ڵ����
                string sParentLb = "";
                if (e.Node.ParentNode != null)
                {
                    sParentLb = e.Node.ParentNode.GetValue("lb").ToString();
                }

                if (!this._bPathWayReadOnly)
                {

                    if (sLb == "-1" || sLb == "-10")
                    {

                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                    }
                    else if (sLb == "2")
                    {
                        //�����ؼ�����Ϊ�༭״̬
                        tlItem.ShowEditor();

                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlItem.Columns["CONTENT"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["SELECT_TYPE"].OptionsColumn.AllowEdit = true;


                        tlItem.Columns["CONTENT"].ColumnEdit = null;
                    }
                    else if (sLb == "3")
                    {
                        //�����ؼ�����Ϊ�༭״̬
                        tlItem.ShowEditor();
                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlItem.Columns["CONTENT"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["EXEC_TYPE"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["JL"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["YF"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["PC"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["ZT"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["BZBY"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["TS"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["JLDW"].OptionsColumn.AllowEdit = true;

                        if (e.Node.GetValue("XMLY").ToString() == "2" && this._sFormType == "1")
                        {
                            tlItem.Columns["PRICE"].OptionsColumn.AllowEdit = true;
                        }

                        tlItem.Columns["CONTENT"].ColumnEdit = this.editCONTENT;
                    }
                    else if (sLb == "0")
                    {
                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlItem.Columns["TS"].OptionsColumn.AllowEdit = true;
                    }


                    if (sLb == "-1" || sParentLb == "-1")
                    {
                        this.btnExplain.Enabled = true;
                        this.btnOperation.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.btnAddItem.Enabled = true;
                        this.btnAddKind.Enabled = true;
                    }
                    else if (sLb == "2" || sLb == "-1" || sLb == "3")
                    {
                        this.btnExplain.Enabled = true;
                        this.btnOperation.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.btnAddItem.Enabled = true;
                        this.btnAddKind.Enabled = false;
                    }
                    else
                    {
                        this.btnAddItem.Enabled = false;
                        this.btnAddKind.Enabled = false;
                        this.btnExplain.Enabled = false;
                        this.btnOperation.Enabled = false;
                        //this.btnDelete.Enabled = false;
                    }
                }
                else
                {
                    foreach (TreeListColumn tlc in tlItem.Columns)
                    {
                        tlc.OptionsColumn.AllowEdit = false;
                    }
                }



                if (e.Node["CJID"].ToString().Length > 0)
                {
                    int cjid = (int)e.Node["CJID"];
                    if (cjid == -1)
                    {
                        tlItem.Columns["CONTENT"].ColumnEdit = null;
                    }
                    else if (cjid == -999)
                    {
                        tlItem.Columns["CONTENT"].ColumnEdit = editCONTENT;
                    }
                    else
                    {
                        tlItem.Columns["CONTENT"].ColumnEdit = editCONTENT;
                        tlItem.Columns["JS"].OptionsColumn.AllowEdit = dtCONTENT_all.Select("ҩƷ���� = '03' and CODE = " + e.Node["CJID"] + " and ��Ŀ��Դ = " + (e.Node["XMLY"].ToString() == "" ? "1" : e.Node["XMLY"].ToString())).Length > 0;
                        tlItem.Columns["JL"].OptionsColumn.AllowEdit = dtCONTENT_all.Select("��Ŀ��Դ = '1' and CODE = " + e.Node["CJID"] + "").Length > 0;

                        //������Ŀ�ĳ���ID��ִ�п��Ҳ�ѯ��Ŀ�ĵ�λ�͵�λ����
                        dtJLDW = InstanceForm.BDatabase.GetDataTable("exec SP_YF_SELECT_DW " + e.Node["CJID"] + "," + e.Node["ZXKS"] + "");

                        ////��ʼ��ִ�����������
                        //cmbDW = CtlFun.CreateRepositoryComboBox(true, dtDW.DefaultView, "s_ypdw");
                        //cmbDW.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        //����Ŀ��������������Դ
                        this.editJLDW.DataSource = dtJLDW;
                    }
                }
            }
        }

        /// <summary>
        /// ���ؼ��۽��иı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            tlItem.ShowEditor();
        }


        /// <summary>
        /// ִ�����������ر��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void editEXEC_TYPE_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

            dtBindShow.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["EXEC_TYPE"] = e.Value;

            tlItem.FocusedColumn = tlItem.Columns["JS"].OptionsColumn.AllowEdit ? tlItem.Columns["JS"] : tlItem.Columns["JL"];
             
        }

        #endregion   

        #region �׶���Ϣ�޸Ŀؼ�

        /// <summary>
        /// �׶����ı������ݸı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbStepName_TextChanged(object sender, EventArgs e)
        {
            //ִ�н׶���Ϣ�޸ķ���,�޸Ľ׶���
            ModifyItem(Enum.KindModifyItem.text);
        }

        /// <summary>
        /// �׶���ʼʱ���ı������ݸı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbTimeUp_TextChanged(object sender, EventArgs e)
        {
            //ִ�н׶���Ϣ�޸ķ���,�޸Ŀ�ʼ����
            ModifyItem(Enum.KindModifyItem.time_up);
        }

        /// <summary>
        /// �׶ν����¼��ı������ݸı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbTimeDown_TextChanged(object sender, EventArgs e)
        {
            //ִ�н׶���Ϣ�޸ķ���,�޸Ľ�������
            ModifyItem(Enum.KindModifyItem.time_down);
        }

        /// <summary>
        /// ��ʼ�׶μ�����״̬�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chkIsFirst_CheckedChanged(object sender, EventArgs e)
        {
            //ִ�н׶���Ϣ�޸ķ���,�޸���ʼ״̬
            ModifyItem(Enum.KindModifyItem.isFirst);
        }

        #endregion

        #region �Ҽ��˵��ؼ�

        /// <summary>
        /// �Ҽ��˵�չ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmsTreeList_Opening(object sender, CancelEventArgs e)
        {
            //�ж���Ŀ��ѡ�����Ƿ����1
            if (tlItem.Selection.Count > 1)
            {
                bool bFlag = true;//��ʼ�����ñ�־,Ĭ��true
                //ѭ��������ѡ�ڵ�,�жϷ������(FZXH)�Ƿ����
                foreach (TreeListNode node in tlItem.Selection)
                {
                    //�жϸýڵ��Ƿ��з������
                    if (node["FZXH"].ToString().Length > 0 || node["XMLY"].ToString() == "2")
                        //����з������,�����ñ�־ΪFalse
                        bFlag = false;
                }
                //�����ñ�־��ֵ�����鰴ť.
                btnGrouping.Enabled = bFlag;
            }
            else
            {
                //���ѡ�������1,����鰴ť������
                btnGrouping.Enabled = false;
            }

            //�жϵ�ǰѡ�����ڵ��Ƿ�Ϊ��,���з������(FZXH),��������ʾ�ѷ���,����������ʾδ����,ͬʱ����ȡ�����鰴ť����״̬
            btnCancelGrouping.Enabled = tlItem.FocusedNode != null && tlItem.FocusedNode["FZXH"].ToString().Length > 0;
            //������ҩƷ�ſ��Բ���һ��
            ����һ��ToolStripMenuItem.Enabled = tlItem.FocusedNode != null && (tlItem.FocusedNode["XMLY"].ToString() == "1" || tlItem.FocusedNode["XMLY"].ToString() == "2");
        }

        /// <summary>
        /// ҩƷ���鰴ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnGrouping_Click(object sender, EventArgs e)
        {
            //�ж���Ŀ��ѡ�����Ƿ����1
            if (tlItem.Selection.Count > 1)
            {
                bool bLevel = true;//�Ƿ�ͬ��,Ĭ��Ϊtrue
                List<int> lstNodeID = new List<int>();//�ڵ�ID�б�
                //��ȡ��ǰѡ��ڵ�ȼ�
                int iLevel = tlItem.Selection[0].Level;
                //ѭ��������ѡ�ڵ�,���ж�ÿ���ڵ�ĵȼ��Ƿ�һ��
                foreach (TreeListNode node in tlItem.Selection)
                {
                    //�ж�ÿ���ڵ�ĵȼ��Ƿ�һ��
                    bLevel = node.Level == iLevel;
                    //ѭ�����ÿ���ڵ��ID���б�
                    lstNodeID.Add((int)node["SORT"]);//��Ϊid ��ǰ SORT
                }
                //�ж���ѡ�ڵ�ȼ��Ƿ�һ��
                if (bLevel)
                {
                    //��List�����򷽷����ڵ�ID��������
                    lstNodeID.Sort();
                    bool bIsLink = true;//�ڵ��Ƿ�����,Ĭ��Ϊtrue
                    //ѭ�������ڵ�ID�б�
                    for (int i = 0; i < lstNodeID.Count; i++)
                    {
                        //�ж�ÿ�����ڵ�ID֮��Ĳ��Ƿ�Ϊ1
                        if (i > 0 && lstNodeID[i] - lstNodeID[i - 1] != 1)
                            //�粻Ϊ1,��ڵ������
                            bIsLink = false;
                    }

                    //�жϽڵ��Ƿ�����
                    if (bIsLink)
                    {
                        //��ʼ���µ�GUID
                        string sGroupId = Guid.NewGuid().ToString();
                        //ѭ��������ѡ�ڵ�,��ӷ����־
                        foreach (TreeListNode node in tlItem.Selection)
                        {
                            //�ж��Ƿ�Ϊ��һ���ڵ�,����ө���־
                            if (node["SORT"].ToString() == lstNodeID[0].ToString())
                                node["Grouping"] = "��";
                            //�ж��Ƿ�Ϊ���һ���ڵ�,����ө���־
                            else if (node["SORT"].ToString() == lstNodeID[tlItem.Selection.Count - 1].ToString())
                                node["Grouping"] = "��";
                            //�����ڵ���ө���־
                            else
                                node["Grouping"] = "��";

                            //��ÿ���ڵ������ͬ�ķ������
                            node["FZXH"] = sGroupId;
                        }
                    }
                    else
                    {
                        //�ڵ����������ʾ
                        MsgBox.MsgShow("�������Ŀ������������.", "��ʾ", MessageBoxButtons.OK, 350, 120);
                    }
                }
                else
                {
                    //�ڵ�ȼ���һ������ʾ
                    MsgBox.MsgShow("�������Ŀ������һ��������.", "��ʾ", MessageBoxButtons.OK, 350, 120);
                }
            }
        }

        /// <summary>
        /// ȡ�����鰴ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnCancelGrouping_Click(object sender, EventArgs e)
        {
            //�ж���ѡ�ڵ㲻Ϊ��
            if (tlItem.FocusedNode != null)
            {
                //��ȡ��ѡ�ڵ�ķ������
                string sGroupId = tlItem.FocusedNode["FZXH"].ToString();
                //���ݷ�����Ų�ѯ����Դ�е�ͬ������
                DataRow[] drGroup = dtBindShow.Select("FZXH = '" + sGroupId + "'");
                //ѭ��������������
                foreach (DataRow dr in drGroup)
                {
                    //��������־
                    dr["Grouping"] = "";
                    //����������
                    dr["FZXH"] = DBNull.Value;
                }
            }
        }

        #endregion

        #endregion

        #region �߼�����

        void Grouping()
        {
            try
            {
                
                //��������������� add by zouchihua 2013-11-6
                //dtBindShow.DefaultView.Sort = " lb,PATH_STEP_ID desc,SORT";
                DataTable tempbindtable = dtBindShow.Copy();
                tempbindtable.DefaultView.Sort = " lb,PATH_STEP_ID desc,FZXH,SORT";
                //tempbindtable.DefaultView.Sort = " lb,PATH_STEP_ID desc,SORT";
                dtBindShow.Rows.Clear();
                for (int i = 0; i < tempbindtable.Rows.Count; i++)
                {
                    dtBindShow.Rows.Add(tempbindtable.DefaultView[i].Row.ItemArray);
                }

                    foreach (DataRow dr in dtBindShow.Rows)
                    {
                        if (dr["FZXH"].ToString() != "")
                        {
                            int rowIndex = dtBindShow.Rows.IndexOf(dr);

                            bool upRowExists = rowIndex - 1 > 0;
                            bool upRowInGroup = upRowExists && dtBindShow.Rows[rowIndex - 1]["FZXH"].ToString() == dr["FZXH"].ToString();
                            bool downRowExists = rowIndex + 1 <= dtBindShow.Rows.Count - 1;

                            bool downRowInGroup = downRowExists && dtBindShow.Rows[rowIndex + 1]["FZXH"].ToString() == dr["FZXH"].ToString();

                            if (!upRowExists && !downRowExists)
                            {
                                continue;
                            }
                            else if (upRowExists && downRowExists)
                            {
                                if (!upRowInGroup && !downRowInGroup)
                                {
                                    continue;
                                }
                                else if (upRowInGroup && !downRowInGroup)
                                {
                                    dr["Grouping"] = "��";
                                }
                                else if (!upRowInGroup && downRowInGroup)
                                {
                                    dr["Grouping"] = "��";
                                }
                                else if (upRowInGroup && downRowInGroup)
                                {
                                    dr["Grouping"] = "��";
                                }
                            }
                            else if (upRowExists && !downRowExists)
                            {
                                if (upRowInGroup)
                                {
                                    dr["Grouping"] = "��";
                                }
                            }
                            else if (!upRowExists && downRowExists)
                            {
                                if (downRowInGroup)
                                {
                                    dr["Grouping"] = "��";
                                }
                            }

                        }
                    }

                dtBindShow.AcceptChanges();
                //չ�����ؼ�
                tlItem.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        /// <summary>
        /// �����б������Լ��(InitGlobalField����)
        /// </summary>
        /// <returns>���ز����б��Ƿ�����</returns>
        bool InfoDialogCheck()
        {
            //��ʼ�����ؽ��,Ĭ��Ϊtrue
            bool result = true;

            //���pKey1(·��ID)Ϊ�ջ��߳���Ϊ0,����Ϊfalse
            if (this.info_DLG.pKey1 == null || this.info_DLG.pKey1.Length == 0)
                result = false;
            //���dlgCs1(·��״̬)Ϊ�ջ��߳���Ϊ0,����Ϊfalse
            if (this.info_DLG.dlgCs1 == null || this.info_DLG.dlgCs1.Length == 0)
                result = false;
            //���dlgCs2(·���������)Ϊ�ջ��߳���Ϊ0,����Ϊfalse
            if (this.info_DLG.dlgCs2 == null || this.info_DLG.dlgCs2.Length == 0)
                result = false;
            //���dlgCs3(·������)Ϊ�ջ��߳���Ϊ0,����Ϊfalse
            if (this.info_DLG.dlgCs3 == null || this.info_DLG.dlgCs3.Length == 0)
                result = false;
            //���dlgCs4(·���汾)Ϊ�ջ��߳���Ϊ0,����Ϊfalse
            if (this.info_DLG.dlgCs4 == null || this.info_DLG.dlgCs4.Length == 0)
                result = false;
            //���dlgCs5(·������)Ϊ�ջ��߳���Ϊ0,����Ϊfalse
            if (this.info_DLG.dlgCs5 == null || this.info_DLG.dlgCs5.Length == 0)
                result = false;
            //���pKey2(��������)Ϊ�ջ��߳���Ϊ0,����Ϊfalse
            if (this.info_DLG.pKey2 == null || this.info_DLG.pKey2.Length == 0)
                result = false;

            //���ؽ��
            return result;
        }

        /// <summary>
        /// �׶���Ϣ�޸�
        /// </summary>
        /// <param name="kindModifyItem">�޸���Ϣ������</param>
        void ModifyItem(Enum.KindModifyItem kindModifyItem)
        {
            //�жϵ�ǰѡ��׶�Ϊ��,�����ɸ�ֵ�����ĸ��¼�,�򷵻�..
            if (this.pathWay.LastGObj == null || this.tbStepName.Tag != null) return;

            //��ȡ��ǰѡ��׶ε���Ϣ
            string strText = this.pathWay.LastGObj.Text;
            int time_up = this.pathWay.LastGObj.TIME_UP;
            int time_down = this.pathWay.LastGObj.TIME_DOWN;
            bool isFirst = this.pathWay.LastGObj.IsFirst;
            //�����޸���Ϣ���������ж���Щ��Ϣ��Ҫ�޸�
            if (kindModifyItem == Enum.KindModifyItem.text) strText = tbStepName.Text;
            if (kindModifyItem == Enum.KindModifyItem.time_up) time_up = ((int)this.tbTimeUp.Value) * 1440;
            if (kindModifyItem == Enum.KindModifyItem.time_down) time_down = (int)this.tbTimeDown.Value > 0 ? (((int)this.tbTimeDown.Value) - 1) * 1440 : 0;
            if (kindModifyItem == Enum.KindModifyItem.isFirst) isFirst = chkIsFirst.Checked;
            //ִ�н׶���Ϣ�޸�
            pathWay.ModifyItem(pathWay.LastGObj, strText, isFirst, time_up, time_down);
        }

        #region TreeListColumn��ӷ���

        /// <summary>
        /// TreeList����з���
        /// </summary>
        /// <param name="caption">�б���</param>
        /// <param name="fieldName">���ֶ�</param>
        void TreeListColumnAdd(string caption, string fieldName)
        {
            TreeListColumnAdd(caption, fieldName, false, false, false, false, -1, 0, false, null, Color.Black);
        }

        /// <summary>
        /// TreeList����з���
        /// </summary>
        /// <param name="caption">�б���</param>
        /// <param name="fieldName">���ֶ�</param>
        /// <param name="allowEdit">�Ƿ�ɱ༭</param>
        /// <param name="visibleIndex">��ʾ���</param>
        /// <param name="width">���</param>
        /// <param name="fixedWidth">�Ƿ�̶����</param>
        /// <param name="columnEdit">�б༭��</param>
        void TreeListColumnAdd(string caption, string fieldName,
            bool allowEdit, int visibleIndex, int width, bool fixedWidth, RepositoryItem columnEdit, Color foreColor)
        {
            TreeListColumnAdd(caption, fieldName, allowEdit, false, false, false, visibleIndex, width, fixedWidth, columnEdit, foreColor);
        }

        /// <summary>
        /// TreeList����з���
        /// </summary>
        /// <param name="caption">�б���</param>
        /// <param name="fieldName">���ֶ�</param>
        /// <param name="allowEdit">�Ƿ�ɱ༭</param>
        /// <param name="allowSort">�Ƿ�����</param>
        /// <param name="allowSize">�Ƿ�ɵ�����С</param>
        /// <param name="allowMove">�Ƿ���ƶ�</param>
        /// <param name="visibleIndex">��ʾ���</param>
        /// <param name="width">���</param>
        /// <param name="fixedWidth">�Ƿ�̶����</param>
        /// <param name="columnEdit">�б༭��</param>
        void TreeListColumnAdd(string caption, string fieldName,
            bool allowEdit, bool allowSort, bool allowSize, bool allowMove,
            int visibleIndex, int width, bool fixedWidth, RepositoryItem columnEdit, Color foreColor)
        {
            //ʵ����һ���µ���
            TreeListColumn tlcNew = new TreeListColumn();
            try
            {
                #region ��ʼ������Ϣ
                
                //��ʼ���б���
                if (caption != null)
                    tlcNew.Caption = caption;
                //��ʼ�����ֶ�
                if (fieldName != null)
                    tlcNew.FieldName = fieldName;
                //��ʼ���ɱ༭״̬
                tlcNew.OptionsColumn.AllowEdit = allowEdit;
                //��ʼ��������״̬
                tlcNew.OptionsColumn.AllowSort = allowSort;
                //��ʼ���ɵ�����С״̬
                tlcNew.OptionsColumn.AllowSize = allowSize;
                //��ʼ�����ƶ�״̬
                tlcNew.OptionsColumn.AllowMove = allowMove;
                //��ʼ����ʾ���
                if (visibleIndex > -1)
                    tlcNew.VisibleIndex = visibleIndex;
                //��ʼ�����
                if (width > 0)
                    tlcNew.Width = width;
                //��ʼ���̶����״̬
                tlcNew.OptionsColumn.FixedWidth = fixedWidth;
                //��ʼ���б༭��
                if (columnEdit != null)
                    tlcNew.ColumnEdit = columnEdit;
                //��ʼ��������ɫ
                if (foreColor != Color.Black)
                {
                    tlcNew.AppearanceCell.ForeColor = foreColor;
                    tlcNew.AppearanceCell.Options.UseForeColor = true;
                }

                #endregion

                //���еĶ���ŵ�����������ӵ�TreeList
                tlItem.Columns.AddRange(new TreeListColumn[] { tlcNew });
            }
            catch (Exception ex)
            {
                //�����쳣������һ��
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// �ݹ��ѯ������ʾ�ĳ���ҽ��
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public bool SelectContinuedStepItem(string stepId, ref string returnValue)
        {
            bool bflag = false;
            DataRow[] dr = dtStepRelation.Select(string.Format("PATH_STEP_ID2 = {0}", "'" + stepId + "'"));
            if (dr != null && dr.Length > 0)
            {

                for (int i = 0; i < dr.Length; i++)
                {
                    string stepId_f1 = dr[i]["PATH_STEP_ID1"].ToString();
                    if (stepId_f1 != "")
                    {
                        if (returnValue.Contains("'" + stepId_f1 + "'"))
                        {
                            //bflag = true;
                            continue;
                        }
                        if (returnValue != "") returnValue += ",";
                        returnValue += "'" + stepId_f1 + "'";
                        SelectContinuedStepItem(stepId_f1, ref returnValue);

                    }
                    else
                        continue;
                }

            }
            return bflag;
        }

        /// <summary>
        /// ��ӽ׶���Ŀ����
        /// </summary>
        void NewKind()
        {         
            //�жϵ�ǰ�ڵ��Ƿ�Ϊ��,�ҽ׶�ͼ�οؼ�ѡ��׶β�Ϊ��
            if (tlItem.FocusedNode != null && pathWay.LastGObj != null && pathWay.LastGObj.Type == PathWay.GItemObj.KindInfo.Item.ToString())
            {

                //��ʼ���ڵ����,�����ж��Ƿ�������ӷ���
                string sLb = tlItem.FocusedNode["lb"].ToString();
                //��ʼ�����ڵ����,�����ж��Ƿ�������ӷ���
                string sParentLb = "";//��ʼΪ���ַ���
                //�жϵ�ǰ�ڵ�ĸ��ڵ��Ƿ�Ϊ��
                if (tlItem.FocusedNode.ParentNode != null)
                {
                    //�粻Ϊ��,���ȡ���ڵ�����
                    sParentLb = tlItem.FocusedNode.ParentNode["lb"].ToString();
                }


                //�ж��ӽڵ�򸸽ڵ������Ƿ�Ϊ-1,����һ��Ϊ-1���ܽ��в���
                if (sLb == "-1" || sParentLb == "-1")
                {
                    //����һ���ڵ�,���ڱ����½ڵ�ĸ��ڵ�
                    TreeListNode tlnNow;
                    //�жϸ��ڵ������Ƿ�Ϊ-1,�����½ڵ�ĸ��ڵ�Ϊ��ǰ�ڵ�ĸ��ڵ�,�����½ڵ�ĸ��ڵ�Ϊ��ǰ�ڵ�
                    if (sParentLb == "-1") tlnNow = tlItem.FocusedNode.ParentNode;
                    else tlnNow = tlItem.FocusedNode;

                    //չ���½ڵ�ĸ��ڵ�
                    ExpandNode(tlnNow);

                    //�Ӱ󶨵�����Դ����һ��������
                    DataRow drNew = dtBindShow.NewRow();
                    //��ʼ��һ���µ�GUID,��Ϊ�½ڵ�ID
                    string sID = Guid.NewGuid().ToString();

                    //��ʼ�����е�����
                    drNew["ID"] = sID;//��ȡ�½ڵ�ID                                                                        //����[�ڵ�ID]
                    drNew["ParentID"] = tlnNow["ID"].ToString();//��ȡ�½ڵ�ĸ��ڵ�ID                                      //����[���ڵ�ID]
                    drNew["lb"] = 2;//�ڵ����(3Ϊ��Ŀ,2Ϊ����),�����Ƿ���,����Ϊ2                                          //����[�ڵ����]
                    drNew["STEP_ITEM_KIND_ID"] = sID;//��ȡ�½ڵ�ID                                                         //����[����ID]
                    drNew["PATH_STEP_ID"] = this._sCurrentStepId;//��ȡ��ǰѡ����ID                                        //���÷������ڵ�[����ID]
                    drNew["PATHAWAY_ID"] = this._sPathWayId;//��ȡ��ǰ·��ID                                                 //���÷������ڵ�[·��ID]
                    drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//��ȡ���ڵ���Ŀ����(1Ϊ���ƹ���,2Ϊҽ��,3Ϊ������) //���÷����[��Ŀ����]
                    drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//��ȡ���ڵ㳤�ٱ���(0Ϊ����ҽ��,1Ϊ��ʱҽ��)           //���÷����[�����ڱ���]
                    drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//��ȡ��ǰ����Ա                                //���÷����[��¼��]
                    drNew["OPER_DATE"] = DateTime.Now;//��ȡϵͳ��ǰʱ��                                                    //���÷����[��¼����]
                    drNew["DELETE_BIT"] = 0;//ָ��ɾ��״̬(0Ϊδɾ��,1Ϊ��ɾ��),������������,����Ϊ0                        //���÷����[ɾ�����]
                    drNew["SELECT_TYPE"] = 1;//ָ��ѡ������(0Ϊ��ѡ,1Ϊ��ѡ),Ĭ��Ϊ��ѡ                                     //���÷����[ѡ������]
                    //Ѱ��lbΪ2������
                    int maxSort = 0;
                    try
                    {
                        maxSort = int.Parse(dtBindShow.Compute("max(SORT)", "lb=2").ToString());
                    }
                    catch { }
                    drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//��ȡ�������                //���÷����[�������]
                    if ((int)tlnNow.LastNode["SORT"] < maxSort)
                        drNew["SORT"] = tlnNow.HasChildren ? maxSort + 1 : 0;//��ȡ�������                //���÷����[�������]
                    //��������ӵ��󶨵�����Դ
                    dtBindShow.Rows.Add(drNew);

                    //����һ���ڵ�,���ڻ�ȡ�����Ľڵ�
                    TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
                    //�ж��½ڵ��Ƿ�Ϊ��,���򽫵�ǰ�۽��ڵ�����Ϊ�½ڵ�
                    if (newNode != null) tlItem.FocusedNode = newNode;
                    //����ǰ�۽�������Ϊ������
                    tlItem.FocusedColumn = tlItem.Columns["CONTENT"];
                    //��ȡ���ؼ�����
                    tlItem.Focus();
                }
            }
        }
        
        /// <summary>
        /// չ���ڵ㼰�临�ڵ�(ֱ�����ڵ�)
        /// </summary>
        /// <param name="node"></param>
        void ExpandNode(TreeListNode node)
        {
            if (node != null) node.ExpandAll();
            if (node.PrevNode != null) node.PrevNode.ExpandAll();
        }

        /// <summary>
        /// ��ӽ׶���Ŀ
        /// </summary>
        /// <param name="isNew"></param>
        void NewItem(bool isNew, NewItemKind itemKind,bool INsertline)
        {
            int pxxh = 0;
            int InsertSort = 0;
            if (!dtBindShow.Columns.Contains("pxxh"))
            {
                dtBindShow.Columns.Add("pxxh", typeof(System.Int32));
            }

            //�жϵ�ǰ�ڵ��Ƿ�Ϊ��,��Ϊ�ղ���ִ�в���
            if (tlItem.FocusedNode != null && pathWay.LastGObj!=null && pathWay.LastGObj.Type == PathWay.GItemObj.KindInfo.Item.ToString())
            {
                //����һ���ڵ�,���ڱ����½ڵ�ĸ��ڵ�
                TreeListNode tlnNow;
                //���ڲ���ʱ��ķ����־
                string insertgroup = "";
                //�жϵ�ǰ�ڵ������Ƿ�Ϊ3,�����½ڵ�ĸ��ڵ�Ϊ��ǰ�ڵ�ĸ��ڵ�,�����½ڵ�ĸ��ڵ�Ϊ��ǰ�ڵ�
                if (tlItem.FocusedNode["lb"].ToString() == "3" || tlItem.FocusedNode["lb"].ToString() == "0") tlnNow = tlItem.FocusedNode.ParentNode;
                else tlnNow = tlItem.FocusedNode;

                //�ж��Ƿ�Ϊ�¿�
                if (isNew)
                {
                    this._sNowGroup = Guid.NewGuid().ToString();//�����µ�GUID,��Ϊ��ǰ����ID
                    dtCONTENT.DefaultView.RowFilter = "";
                     
                    dtCONTENT_all.DefaultView.RowFilter = "";
                    dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                     

                }
                else
                {
                    this._sNowGroup = tlnNow.LastNode["FZXH"].ToString();

                    if (INsertline)//���������һ��
                    {
                        this._sNowGroup = tlItem.FocusedNode["FZXH"].ToString();
                        if(this._sNowGroup=="")
                        {
                            _sNowGroup = Guid.NewGuid().ToString();
                          
                               tlItem.FocusedNode["FZXH"] = _sNowGroup;
                           
                        }
                    }
                    string strCjid = TrasenClasses.GeneralClasses.Convertor.IsInteger(tlnNow.LastNode["CJID"].ToString()) ? tlnNow.LastNode["CJID"].ToString() : "-1";
                    if (dtCONTENT_all.Select("ҩƷ���� = '03' and CODE = " + strCjid + " and ��Ŀ��Դ = '" + tlnNow.LastNode["XMLY"] + "'").Length > 0)
                    {
                        dtCONTENT_all.DefaultView.RowFilter = "ҩƷ���� = '03'";
                        dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                    }
                    else
                    {
                        
                            dtCONTENT_all.DefaultView.RowFilter = string.Format("��Ŀ��Դ = '{0}' and ҩƷ���� <> 3", tlnNow.LastNode["XMLY"].ToString());
                            dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                        
                    }
                    //����ǲ�����ж�
                    if (INsertline)
                    {
                        strCjid = TrasenClasses.GeneralClasses.Convertor.IsInteger(tlItem.FocusedNode["CJID"].ToString()) ? tlItem.FocusedNode["CJID"].ToString() : "-1";
                        if (dtCONTENT_all.Select("ҩƷ���� = '03' and CODE = " + strCjid + " and ��Ŀ��Դ = '" + tlItem.FocusedNode["XMLY"] + "'").Length > 0)
                        {
                            dtCONTENT_all.DefaultView.RowFilter = "ҩƷ���� = '03'";
                            dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                        }
                        else
                        {

                            dtCONTENT_all.DefaultView.RowFilter = string.Format("��Ŀ��Դ = '{0}' and ҩƷ���� <> 3", tlItem.FocusedNode["XMLY"].ToString());
                            dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                        }
                    }
                     

                    //add by zouchihu1 2013-6-22 ���������ֻ��ʾ����ҽ��
                    //if (itemKind == NewItemKind.Operation)
                    //{
                    //    //[ORDER_TYPE] AS ҽ������
                    //    dtCONTENT_all.DefaultView.RowFilter = string.Format("ҽ������ = {0} ", 6);
                    //    dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                    //}
                    //�ж���Ŀ��Դ�Ƿ�ΪҩƷ
                    if (INsertline ==false&& tlnNow.LastNode["XMLY"].ToString() == "1")
                    {
                        string sFZXH = tlnNow.LastNode["FZXH"].ToString();
                        int iFZGS = dtBindShow.Select(string.Format("FZXH = '{0}'", sFZXH)).Length;

                        if (sFZXH != "" && iFZGS >= 1)
                        {
                            tlnNow.LastNode["Grouping"] = iFZGS > 1 ? "��" : "��";
                        }
                        else
                        {
                            tlnNow.LastNode["Grouping"] = "";
                            dtBindShow.Select("ID = '" + tlnNow.LastNode["ID"] + "'")[0]["FZXH"] = DBNull.Value;
                        }
                    }
                    
                    if (INsertline)
                    {
                        string sFZXH = tlItem.FocusedNode["FZXH"].ToString();
                        this.BindingContext[dtBindShow].EndCurrentEdit();
                        int iFZGS = dtBindShow.Select(string.Format("FZXH = '{0}'", sFZXH)).Length;

                        if (sFZXH != "" && iFZGS >= 1 && tlItem.FocusedNode["XMLY"].ToString() == "1")//����Ҫ��ҩƷ
                        {
                            if ( dtBindShow.Select(string.Format("FZXH = '{0}'", sFZXH))[0]["ID"] == tlItem.FocusedNode["ID"].ToString())
                            {
                                tlItem.FocusedNode["Grouping"] = "��";
                                if(iFZGS==1)
                                    insertgroup = "��";
                                else
                                    insertgroup = "��";
                            }
                            else
                            {
                                //����ǲ���������һ��
                                if (dtBindShow.Select(string.Format("FZXH = '{0}'", sFZXH))[iFZGS - 1]["ID"] == tlItem.FocusedNode["ID"].ToString())
                                    insertgroup = "��";
                                else
                                    insertgroup = "��";
                                  tlItem.FocusedNode["Grouping"] = "��";
                            }
                            //tlItem.FocusedNode["Grouping"] = iFZGS > 1 ? "��" : "��";insertgroup
                        }
                        else
                        {
                            if (tlItem.FocusedNode["XMLY"].ToString() == "1")
                            {
                                tlItem.FocusedNode["Grouping"] = "��";
                                insertgroup = "��";
                            }
                            else
                            {
                                tlItem.FocusedNode["Grouping"] = "";
                            }
                           // dtBindShow.Select("ID = '" + tlnNow.LastNode["ID"] + "'")[0]["FZXH"] = DBNull.Value;
                        }
                        #region //����ǲ������±���������� add by zouchihua 2013-11-6
                        DataRow[] _row = dtBindShow.Select(string.Format("PATH_STEP_ID = '{0}'", tlItem.FocusedNode["PATH_STEP_ID"]),"sort");
                        int flag = 0;
                        int j = 0;
                        int tempsort = 0;
                        for (int i = 0; i < tlItem.FocusedNode.ParentNode.Nodes.Count; i++)
                        {
                            if (tlItem.FocusedNode.ParentNode.Nodes[i]["ID"].ToString() == tlItem.FocusedNode["ID"].ToString())
                            {
                                flag = 1;
                                InsertSort = int.Parse(tlItem.FocusedNode.ParentNode.Nodes[i]["SORT"].ToString()) + 1;
                                tempsort = InsertSort;
                            }
                            else
                                if (flag == 1)
                                {
                                    j++;
                                    tlItem.FocusedNode.ParentNode.Nodes[i]["SORT"] = tempsort + j;
                                }
                        }
                        #endregion
                    }
                }
                //add by zouchihua 2013-6-22
                editCONTENT.DataSource = dtCONTENT;
                //չ���½ڵ�ĸ��ڵ�
                ExpandNode(tlnNow);
                //�Ӱ󶨵�����Դ����һ��������
                DataRow drNew = dtBindShow.NewRow();
                //��ʼ��һ���µ�GUID,��Ϊ�½ڵ�ID
                string sID = Guid.NewGuid().ToString();
                //��ʼ���½ڵ�ĸ��ڵ�ID
                string sParentID = tlnNow["ID"].ToString();

                drNew["pxxh"] = 0;
                //��ʼ�����е�����
                drNew["ID"] = sID;//��ȡ�½ڵ�ID                                                                        //����[�ڵ�ID]
                drNew["ParentID"] = sParentID;//��ȡ�½ڵ�ĸ��ڵ�ID                                                    //����[���ڵ�ID]
                drNew["lb"] = 3;//�ڵ����(3Ϊ��Ŀ,2Ϊ����),�����Ƿ���,����Ϊ3                                          //����[�ڵ����]
                drNew["PATH_STEP_ITEM_ID"] = sID;//��ȡ�½ڵ�ID                                                         //����[��ĿID]
                //�ж��½ڵ�ĸ��ڵ�����Ƿ�Ϊ-1,�����½ڵ�ķ���IDΪNULL,�����½ڵ�ķ���IDΪ���ڵ�ID                  //������Ŀ[����ID]
                if (tlnNow["lb"].ToString() == "-1") drNew["STEP_ITEM_KIND_ID"] = DBNull.Value;
                else drNew["STEP_ITEM_KIND_ID"] = sParentID;
                drNew["PATH_STEP_ID"] = this._sCurrentStepId;//��ȡ��ǰѡ����ID                                        //������Ŀ���ڵ�[����ID]
                drNew["PATHAWAY_ID"] = this._sPathWayId;//��ȡ��ǰ·��ID                                                 //������Ŀ���ڵ�[·��ID]
                drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//��ȡ���ڵ���Ŀ����(1Ϊ���ƹ���,2Ϊҽ��,3Ϊ������) //������Ŀ��[��Ŀ����]
                drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//��ȡ���ڵ㳤�ٱ���(0Ϊ����ҽ��,1Ϊ��ʱҽ��)           //������Ŀ��[�����ڱ���]
                drNew["EXEC_TYPE"] = 0;//ָ��ִ�����(0Ϊ��ѡ,1Ϊ��ѡ),Ĭ��Ϊ��ѡ                                       //������Ŀ��[ִ�����]
                drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//��ȡ��ǰ����Ա                                //������Ŀ��[��¼��]
                drNew["OPER_DATE"] = DateTime.Now;//��ȡϵͳ��ǰʱ��                                                    //������Ŀ��[��¼����]
                drNew["DELETE_BIT"] = 0;//ָ��ɾ��״̬(0Ϊδɾ��,1Ϊ��ɾ��),������������,����Ϊ0                        //������Ŀ��[ɾ�����]
                drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//��ȡ�������                //������Ŀ��[�������]
                  if(INsertline)//���������һ��
                      drNew["SORT"] = InsertSort;
                switch (itemKind)
                {
                    case NewItemKind.Explain:
                        drNew["CJID"] = -1;
                        drNew["XMID"] = -1;
                        drNew["XMLY"] = 2;
                        break;
                    case NewItemKind.Operation:
                        drNew["CJID"] = -999;
                        drNew["XMLY"] = 2;
                        break;
                }

                if (this._sNowGroup != "" && this.tlItem.FocusedNode["XMLY"].ToString()=="1") drNew["FZXH"] = this._sNowGroup;                                               //������Ŀ��[�������]       

                string sGrouping="";//��ʼ��������  
                if (isNew) sGrouping = "��";//����¿�
                else if (tlnNow.LastNode["XMLY"].ToString() == "1")
                {
                    if(INsertline==false)
                       sGrouping = "��";//�����һ����ĿΪҩƷ
                }
                else sGrouping = "";//������϶�����,�����Ŀ����Ҫ������
                //if (INsertline && tlItem.FocusedNode["XMLY"].ToString() == "1")
                //    sGrouping = "��";
                //add by zouchihua 2013-11-6 �������ſ���
                if (INsertline == true)
                {
                    drNew["Grouping"] = insertgroup;
                    //drNew["pxxh"] = pxxh;
                }//������Ŀ��[������]
                else
                    drNew["Grouping"] = sGrouping;
                //��������ӵ��󶨵�����Դ
                dtBindShow.Rows.Add(drNew);
                 dtBindShow.DefaultView.Sort = "lb,PATH_STEP_ID desc,SORT";//add by zouchihua 2013-11-5
                //����һ���ڵ�,���ڻ�ȡ�����Ľڵ�
                TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
                //�ж��½ڵ��Ƿ�Ϊ��,���򽫵�ǰ�۽��ڵ�����Ϊ�½ڵ�
                if (newNode != null) tlItem.FocusedNode = newNode;
                //����ǰ�۽�������Ϊ������
                tlItem.FocusedColumn = tlItem.Columns["CONTENT"];
                //��ȡ���ؼ�����
                tlItem.Focus();
                tlItem.ShowEditor();
                
            }
        }

        /// <summary>
        /// ����ģ��
        /// </summary>
        void LoadModel()
        {
            try
            {
                //����·��û���κν׶�,�����ģ��
                if (dtStep.Rows.Count + dtStepRelation.Rows.Count == 0)
                {
                    //��¼��־
                    Logger("��״̬��ʾ�����ڼ���ģ��...");

                    #region ��ʼ��������SQL���

                    //��ʼ������������
                    ArrayList tabAl = new ArrayList();
                    tabAl.Add("PATH_STEP_MODEL");
                    tabAl.Add("PATH_STEP_RALATE_MODEL");

                    //��ʼ��SQL��������
                    ArrayList sqlAl = new ArrayList();
                    sqlAl.Add(string.Format("SELECT TOP {0} * FROM PATH_STEP_MODEL order by note", this._iPathWayMaxDay));
                    sqlAl.Add(string.Format("SELECT TOP {0} * FROM PATH_STEP_RALATE_MODEL order by note", this._iPathWayMaxDay - 1));

                    #endregion

                    #region ��ȡģ�����ݲ����д���

                    //��ȡģ������
                    DataSet dsTmp = DbOpt.GetDataSet(sqlAl, tabAl);
                    //��������
                    dsTmp.Tables["PATH_STEP_MODEL"].PrimaryKey = new DataColumn[] { dsTmp.Tables["PATH_STEP_MODEL"].Columns["PATH_STEP_ID"] };
                    dsTmp.Tables["PATH_STEP_RALATE_MODEL"].PrimaryKey = new DataColumn[] { dsTmp.Tables["PATH_STEP_RALATE_MODEL"].Columns["PATH_STEP_RALATE_ID"] };
                    //ѭ�������׶�ģ��
                    foreach (DataRow drStep in dsTmp.Tables["PATH_STEP_MODEL"].Rows)
                    {
                        //��ȡ�׶ε�ID
                        object tmpID = drStep["PATH_STEP_ID"];
                        //��ʼ����ID
                        string newID = Guid.NewGuid().ToString();
                        //�����µĽ׶�ID
                        drStep["PATH_STEP_ID"] = newID;
                        //�����µ�·��ID
                        drStep["PATHWAY_ID"] = this._sPathWayId;
                        //���NOTE
                        drStep["NOTE"] = DBNull.Value;


                        //��ȡ���õ��ý׶ε����й���
                        DataRow[] drs = dsTmp.Tables["PATH_STEP_RALATE_MODEL"].Select(string.Format("PATH_STEP_ID1 = '{0}' or PATH_STEP_ID2 = '{0}'", tmpID));
                        //ѭ����������
                        foreach (DataRow dr in drs)
                        {
                            //�滻�����еĽ׶�ID
                            if (dr["PATH_STEP_ID1"].ToString() == tmpID.ToString()) dr["PATH_STEP_ID1"] = newID;
                            if (dr["PATH_STEP_ID2"].ToString() == tmpID.ToString()) dr["PATH_STEP_ID2"] = newID;
                        }
                    }
                    //ѭ����������ģ��
                    foreach (DataRow drRelate in dsTmp.Tables["PATH_STEP_RALATE_MODEL"].Rows)
                    {
                        //��ʼ����ID�滻��ģ���е�ID
                        drRelate["PATH_STEP_RALATE_ID"] = Guid.NewGuid().ToString();
                        //�滻·��ID
                        drRelate["PATHWAY_ID"] = this._sPathWayId;
                        //���NOTE
                        drRelate["NOTE"] = DBNull.Value;
                    }

                    #endregion

                    #region �ϲ����ݲ�����

                    //��������ģ��ϲ�����ǰ·���Ľ׶κ͹�����
                    dtStep.Merge(dsTmp.Tables["PATH_STEP_MODEL"]);
                    dtStepRelation.Merge(dsTmp.Tables["PATH_STEP_RALATE_MODEL"]);
                    //ѭ�����ý׶α�����Ϊ����
                    foreach (DataRow dr in dtStep.Rows)
                    {
                        dr.AcceptChanges();
                        dr.SetAdded();
                    }
                    //ѭ�����ù���������Ϊ����
                    foreach (DataRow dr in dtStepRelation.Rows)
                    {
                        dr.AcceptChanges();
                        dr.SetAdded();
                    }
                    //����׶κ͹���
                    SavePathStep(true);

                    #endregion

                    //��¼��־
                    Logger("��״̬��ʾ��ģ�������ϣ�");
                }
            }
            catch (Exception ex)
            {
                //��¼��־
                Logger("��״̬��ʾ��ģ�����ʧ�ܣ�" + ex.Message);
            }
            
        }

        /// <summary>
        /// ɾ����Ŀ
        /// </summary>
        void DeleteItem()
        {
            try
            {
                //�ж����ؼ���ǰ�۽��ڵ��Ƿ�Ϊ��
                if (tlItem.FocusedNode != null)
                {
                    //��ȡ��ǰ�۽��ڵ�
                    TreeListNode tlnDel = tlItem.FocusedNode;
                    string fzxh = tlnDel["FZXH"].ToString();
                    if (1==1||tlnDel["FZXH"].ToString().Length == 0)
                    {
                        //��ȡ�ڵ�����
                        string nodeLb = tlnDel["lb"].ToString();
                        //�жϽڵ��Ƿ�Ϊ�׶���Ŀ
                        if (nodeLb == "3")
                        {
                            //��Ϣ��ʾ�Ƿ�ɾ��
                            if (MessageBox.Show("ȷ��ɾ������Ŀ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //ɾ����Ŀ
                                dtBindShow.Select("ID = '" + tlnDel["ID"] + "'")[0]["DELETE_BIT"] = 1;
                                
                            }
                        }
                        else if (nodeLb == "2")//�жϽڵ��Ƿ�Ϊ�׶���Ŀ����
                        {
                            //�жϷ�������Ƿ�����Ŀ
                            if (tlnDel.HasChildren)
                            {
                                MessageBox.Show("�÷����������Ŀ������ɾ������Ŀ����ɾ�����࣡", "��ʾ");
                            }
                            else
                            {
                                //��Ϣ��ʾ�Ƿ�ɾ��
                                if (MessageBox.Show("ȷ��ɾ���÷��ࣿ", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //ɾ������
                                    dtBindShow.Select("ID = '" + tlnDel["ID"] + "'")[0]["DELETE_BIT"] = 1;
                                }
                            }
                        }
                        else
                        {
                            //״̬����ʾֻ��ɾ���׶���Ŀ�����
                            this.UseHelp("��״̬��ʾ��ֻ��ɾ���׶���Ŀ����࣡");
                        }
                        //�����������
                        //�ж���ѡ�ڵ㲻Ϊ��
                        if (tlItem.FocusedNode != null)
                        {
                            //��ȡ��ѡ�ڵ�ķ������
                            string sGroupId = fzxh;
                            //���ݷ�����Ų�ѯ����Դ�е�ͬ������
                            DataRow[] drGroup = dtBindShow.Select("FZXH = '" + sGroupId + "' and DELETE_BIT=0");
                            if (drGroup.Length <= 1)
                            {
                                //ѭ��������������
                                foreach (DataRow dr in drGroup)
                                {
                                    //��������־
                                    dr["Grouping"] = "";
                                    //����������
                                    dr["FZXH"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                int xx = 0;
                                string FZXH=Guid.NewGuid().ToString();
                                //ѭ��������������
                                foreach (DataRow dr in drGroup)
                                {
                                    dr["FZXH"] = FZXH;
                                    if(xx==0)
                                        dr["Grouping"] = "��";
                                    else
                                        if(drGroup.Length-1!=xx)
                                            dr["Grouping"] = "��";//"��" : "��";
                                        else
                                            dr["Grouping"] = "��";
                                    xx++;

                                }
                            }
                        }

                    }
                    else
                    {
                        
                        //��Ϣ��ʾ��ǰ��Ŀ�ڷ�����,����ȡ�������ٽ���ɾ��
                        MessageBox.Show("��ǰ��Ŀ�ڷ�����,����ȡ�������ٽ���ɾ��������", "��ʾ");
                    }
                }
                else
                {
                    //״̬����ʾδѡ��ڵ�
                    this.UseHelp("��״̬��ʾ����ѡ��Ҫɾ���Ľڵ㣡");
                }
            }
            catch (Exception ex)
            {
                //״̬����ʾɾ��ʧ��
                this.UseHelp("��״̬��ʾ��ɾ��ʧ�ܣ�" + ex.Message, true);
            }
            
        }

        /// <summary>
        /// ���±��ƶ��¼�
        /// </summary>
        /// <param name="e"></param>
        private void ColIndexMove(KeyEventArgs e)
        {
            string sColName = tlItem.FocusedColumn.Caption;
            
            switch (sColName)
            {
                case "��Ŀ����":
                    tlItem.FocusedColumn = tlItem.Columns["SELECT_TYPE"];
                   
                    break;
                case "ѡ�����":
                    tlItem.FocusedColumn = tlItem.Columns["EXEC_TYPE"];
                    if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();
                    break;
                case "ִ�����":
                    tlItem.FocusedColumn = tlItem.Columns["JS"].OptionsColumn.AllowEdit ? tlItem.Columns["JS"] : tlItem.Columns["JL"];
                    if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();
                    break;
                case "����":
                    tlItem.FocusedColumn = tlItem.Columns["JL"];
                     if (e.KeyCode == Keys.Enter)  tlItem.CloseEditor();//����
                    break;
                case "����":
                    tlItem.FocusedColumn = tlItem.Columns["JLDW"];
                    if (e.KeyCode == Keys.Enter) tlItem.CloseEditor();//����
                    break;
                case "��λ":
                    tlItem.FocusedColumn = tlItem.Columns["YF"];
                     if (e.KeyCode == Keys.Enter) tlItem.CloseEditor();//����
                    break;
                case "�÷�":
                    tlItem.FocusedColumn = tlItem.Columns["PC"];
                    if (e.KeyCode == Keys.Enter) tlItem.CloseEditor();//����
                    break;
                case "Ƶ��":
                    tlItem.FocusedColumn = tlItem.Columns["TS"].OptionsColumn.AllowEdit ? tlItem.Columns["TS"] : tlItem.Columns["YF"];
                    //if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();//����
                    break;
                case "ͣ����":
                    tlItem.FocusedColumn = tlItem.Columns["ZT"];
                   // if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();//����
                    break;
                case "����":
                    bool isItem = tlItem.FocusedNode["lb"].ToString() == "3";
                    if (tlItem.FocusedNode.NextNode == null && tlItem.FocusedNode["CONTENT"].ToString().Length > 0 && isItem)
                    {
                        NewItem(false, NewItemKind.Normal,false);
                    }
                    break;
                default:
                     
                    SendKeys.Send("{Right}");//Ĭ���������ƶ� 
                    break;
            }
            try
            {
               // if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();//����
               // tlItem.FocusedColumn.ColumnEdit.IsActivateKey(Keys.Back);
                //tlItem.FocusedColumn.ColumnEdit.IsActivateKey(Keys.Back);
            }
            catch { };
           // SendKeys.Send("{1}");
        }

        /// <summary>
        /// ����׶���Ϣ
        /// </summary>
        /// <param name="isSaveModel">�Ƿ�Ϊ����ģ��</param>
        void SavePathStep(bool isSaveModel)
        {
            try
            {
                if (!isSaveModel)
                {
                    //����ͼ��DataTable
                    pathWay.SaveItem_ToDataTable(dtStep, dtStepRelation, this._sPathWayId);
                }
                //����DataTable
                this.BindingContext[dtStep].EndCurrentEdit();
                this.BindingContext[dtStepRelation].EndCurrentEdit();
                int rows = DbOpt.Update(new DataTable[] { dtStep, dtStepRelation }, new string[] { this._sSqlStep, this._sSqlStepRelation }, null, null);
                if (rows >= 0)
                {
                    dtStep.AcceptChanges();
                    dtStepRelation.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                //״̬����ʾ����ʧ��
                this.UseHelp("��״̬��ʾ������׶�ʧ�ܣ�" + ex.Message, true);
            }
        }

        /// <summary>
        /// ����׶���Ŀ
        /// </summary>
        void SaveStepItem()
        {
            try
            {
                try
                {
                    TreeListColumn col=this.tlItem.FocusedColumn;
                    this.tlItem.FocusedColumn = this.tlItem.Columns[0];
                    this.tlItem.FocusedColumn = this.tlItem.Columns[1];
                    this.tlItem.FocusedColumn = col;
                }
                catch { }
                //�жϰ������Ƿ����
                if (dtBindShow != null && dtBindShow.GetChanges() != null && dtBindShow.GetChanges().Rows.Count > 0)
                {
                    //�������ؼ��ı༭״̬
                    this.tlItem.EndCurrentEdit();
                    //����������Դ�ı༭״̬
                    bsItemData.EndEdit();
                    this.BindingContext[bsItemData].EndCurrentEdit();
                    this.BindingContext[dtBindShow].EndCurrentEdit();
                    

                    //��ʼ��һ���ڴ��,���ڱ�����Ŀ����   //��ʼ��һ��������,���ڱ���Ҫ����ķ�������
                    DataTable dtSaveItem = dtBindShow.Copy(); DataRow[] drRemoveItem = dtSaveItem.Select("lb in (-1,-10,2) or CONTENT is null or CONTENT = ''");

                    //ѭ������Ҫ����ķ�������,������Ŀ���н���ɾ��
                    foreach (DataRow dr in drRemoveItem)
                    {
                        //ɾ����Ŀ���еķ�������
                        dtSaveItem.Rows.Remove(dr);
                    }

                    //dtSaveItem.PrimaryKey = new DataColumn[] { dtSaveItem.Columns["PATH_STEP_ITEM_ID"] };
                    //dtSaveItem.Columns.Remove("ID");
                    //dtSaveItem.Columns.Remove("ParentID");
                    //dtSaveItem.Columns.Remove("lb");
                    //dtSaveItem.Columns.Remove("Grouping");


                    ////��ȡSQL������Զ����ֶε����һ���ֶε�����
                    //int col = dtSaveItem.Columns.IndexOf("Grouping");
                    ////ѭ�������Զ����ֶ�,��������Ŀ����ɾ��
                    //for (int i = dtSaveItem.Columns.Count - 1; i >= 0; i--)
                    //{
                    //    if (i <= col) dtSaveItem.Columns.RemoveAt(i);
                    //}

                    //��ʼ��һ���ڴ��,���ڱ����������   //��ʼ��һ��������,���ڱ���Ҫ�������Ŀ����
                    DataTable dtSaveKind = dtBindShow.Copy(); DataRow[] drRemoveKind = dtSaveKind.Select("lb in (-1,-10,3) or CONTENT is null or CONTENT = ''");

                    //ѭ������Ҫ�������Ŀ����,���ڷ�����н���ɾ��
                    foreach (DataRow dr in drRemoveKind)
                    {
                        //ɾ��������е���Ŀ����
                        dtSaveKind.Rows.Remove(dr);
                    }
                    //dtSaveKind.PrimaryKey = new DataColumn[] { dtSaveKind.Columns["STEP_ITEM_KIND_ID"] };
                    //dtSaveKind.Columns.Remove("ID");
                    //dtSaveKind.Columns.Remove("ParentID");
                    //dtSaveKind.Columns.Remove("lb");
                    //dtSaveKind.Columns.Remove("Grouping");

                    ////��ȡSQL������Զ����ֶε����һ���ֶε�����
                    //col = dtSaveItem.Columns.IndexOf("Grouping");
                    ////ѭ�������Զ����ֶ�,�����ڷ������ɾ��
                    //for (int i = dtSaveKind.Columns.Count - 1; i >= 0; i--)
                    //{
                    //    if (i <= col) dtSaveKind.Columns.RemoveAt(i);
                    //}

                    //����������Ŀ��ı༭״̬
                    this.BindingContext[dtSaveItem].EndCurrentEdit();
                    //������������ı༭״̬
                    this.BindingContext[dtSaveKind].EndCurrentEdit();

                    //dtSaveItem.PrimaryKey = new DataColumn[] { dtSaveItem.Columns["PATH_STEP_ITEM_ID"] };

                    //����Ŀ��ͷ��������ݱ��浽���ݿ�,�������޸�����
                    //int rows = DbOpt.Update(new DataTable[] { dtSaveItem, dtSaveKind }, new string[] { this._sSqlStepItemSave, this._sSqlStepItemKindSave }, null, null);
                    int rows = DbOpt.Update(dtSaveItem, this._sSqlStepItemSave);
                    rows += DbOpt.Update(dtSaveKind, this._sSqlStepItemKindSave);
                    //�ж��޸������Ƿ���ڻ����0,����ˢ���ڴ��
                    if (rows >= 0)
                    {
                        if (dtSaveItem.GetChanges() != null)
                            dtSaveItem.AcceptChanges();
                        if (dtSaveKind.GetChanges() != null)
                            dtSaveKind.AcceptChanges();
                        if (dtBindShow.GetChanges() != null)
                        {
                            dtBindShow.AcceptChanges();
                            dtStepItem = DbOpt.GetDataTable(this._sSqlStepItem);
                            dtStepItemKind = DbOpt.GetDataTable(this._sSqlStepItemKind);
                            dtBindShow.Merge(dtStepItem);
                            dtBindShow.Merge(dtStepItemKind);
                            Grouping();
                        }
                        

                        //dtFixedStructure.AcceptChanges();
                        //dtContinuedStepItem.AcceptChanges();
                        //dtContinuedStepItemKind.AcceptChanges();
                        //if (dtStep.GetChanges() != null)
                        //    dtStep.AcceptChanges();
                        //if (dtStepItem.GetChanges() != null)
                        //    dtStepItem.AcceptChanges();
                        //if (dtStepItemKind.GetChanges() != null)
                        //    dtStepItemKind.AcceptChanges();
                        //InitData();

                        this.UseHelp("��״̬��ʾ���׶���Ŀ����ɹ���", true);
                    }
                }
                else
                {
                    this.UseHelp("��״̬��ʾ��û��������Ҫ���棡");
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("��״̬��ʾ��������Ŀʧ�ܣ�" + ex.Message, true);
            }
        }

        /// <summary>
        /// �û�������Ϣ��ʾ
        /// </summary>
        /// <param name="strHelp">��ʾ��Ϣ</param>
        /// <param name="isLog">�Ƿ��¼��־</param>
        void UseHelp(string strHelp, bool isLog)
        {

            //״̬����ʾ
            this.UseHelp(strHelp);
            //�ж��Ƿ��¼��־
            if (isLog)
                //�����,����Ϣ��¼����־�ļ�
                this.Logger(strHelp);
        }

        /// <summary>
        /// ��¼��־
        /// </summary>
        /// <param name="strLog">��־��Ϣ</param>
        void Logger(string strLog)
        {
            try
            {
                //��ʼ����־Ŀ¼·��
                string logPath = Application.StartupPath + "\\log\\pathwaylog";
                //��ʼ����־�ļ���
                string logFileName = "\\" + DateTime.Now.Date.ToShortDateString() + ".txt";
                //�ж�·���Ƿ����
                if (!Directory.Exists(logPath))
                    //���������,�򴴽���־Ŀ¼
                    Directory.CreateDirectory(logPath);
                //������д����
                StreamWriter srLog = null;
                //�ж���־�ļ��Ƿ����
                if (File.Exists(logPath + logFileName ))
                {
                    //�������,���ڵ�ǰ��־�ļ������Ӽ�¼
                    srLog = File.AppendText(logPath + logFileName);
                }
                else
                {
                    //���������,�򴴽���ǰ��־�ļ������Ӽ�¼
                    srLog = File.CreateText(logPath + logFileName);
                }
                //д����־
                srLog.WriteLine(DateTime.Now.ToLocalTime().ToString() + ":" + DateTime.Now.Millisecond.ToString() + "\t" + strLog);
                //�ر�д����
                srLog.Close();
                //�ͷ�д����
                srLog.Dispose();
            }
            catch (Exception ex)
            {
                //״̬����ʾ��¼��־ʧ��
                this.UseHelp("��¼��־ʧ�ܣ�" + ex.Message);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPathTableSet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmPathTableSelect(this.info_DLG).ShowDialog();
        }

        private void btnConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sSqlTable_Way = string.Format("SELECT * FROM [PATHTABLE_WAY_RELATION] WHERE [PATHWAYID] = '{0}'", this._sPathWayId);
            DataTable dtPathTable_Way = DbOpt.GetDataTable(sSqlTable_Way);
            if (dtPathTable_Way.Rows.Count > 0)
            {
                new FrmPathTableConfig(dtPathTable_Way.Rows[0]["PATHWAYID"].ToString(), (int)dtPathTable_Way.Rows[0]["PATHTABLEID"],this).ShowDialog();
            }
            else
            {
                MessageBox.Show("����ѡ������ٽ������á�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddItem_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddKind_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSavePathWay_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void ����һ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewItem(false, NewItemKind.Normal, true);
        }

        private void btnGrouping_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelGrouping_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

    }
}