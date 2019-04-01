using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using PathWay;
using Trasen.Base.Cmb;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace ts_ClinicalPathWay
{
    public partial class FrmPathWayModify1 : FrmBase2
    {
        #region ȫ�ֱ���

        string sPathWayId = "";//��ǰ·��ID
        int iPathWayMaxDay = 0;//·���������
        int iPathStatus;//��ǰ·��״̬
        bool isReadOnly;//��ǰ·���Ƿ�����༭
        string sCurrentStepID = null;//��ǰ�׶�ID

        string sSqlStepItem; //�׶���Ŀ��ѯ���
        string sSqlStepItemKind; //�׶���Ŀ�����ѯ���
        DataTable dtFl;//�̶������
        DataTable dtStepItem; //�׶���Ŀ��
        DataTable dtStepItemKind; //�׶���Ŀ�����
        DataTable dtBind; //���ؼ��󶨱�
        DataTable dtContent; //ҽ����Ŀ���ݰ󶨱�
        DataTable dtYF; //�÷���
        DataTable dtPC; //Ƶ�α�
        DataTable dtDW;//��λ��
        string sNowGroup;//��ǰ����

        #endregion


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="infoDlg">�����б�</param>
        public FrmPathWayModify1(DbOpt.InFoDlg infoDlg)
        {
            //��ʼ�����
            InitializeComponent();
            //��ȡ���ϸ����崫������·��״̬
            this.iPathStatus = int.Parse(infoDlg.dlgCs1);
            //����·��״̬�ж�·���Ƿ�ֻ��
            this.isReadOnly = iPathStatus != 1;
            //��ȡ���ϸ����崫�����Ĺ̶������
            this.dtFl = (DataTable)infoDlg.dlgObj;
            //��ȡ���ϸ����崫������·��ID
            this.sPathWayId = infoDlg.pKey1;
            //��ȡ���ϸ����崫������·���������
            this.iPathWayMaxDay = TrasenClasses.GeneralClasses.Convertor.IsInteger(infoDlg.dlgCs2) ? int.Parse(infoDlg.dlgCs2) : 0;
            //��ɾ���¼�
            this.pathWay.Item_DeleteAfter += new PathWay.PathWay.Item_DeleteHandler(pathWay_ItemDelete);
            //�󶨽׶�ѡ���¼�
            this.pathWay.Item_Add_Sel_Modiy_After += new PathWay.PathWay.Item_Add_Sel_Modiyf_Handler(pathWay1_Item_Add_Sel_Modiy_After);
            //this.tlItem.ProcessCmd_Key += new TreeListEdit.OnProcessCmd_Key(tlItem_ProcessCmd_Key);
            this.tlItem.CustomDrawNodeCell +=new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(tlItem_CustomDrawNodeCell);
        }

        /// <summary>
        /// �׶�ѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="fl"></param>
        /// <param name="e"></param>
        void pathWay1_Item_Add_Sel_Modiy_After(object sender, PathWay.PathWay.FenLei fl, EventArgs e)
        {
            //�жϲ����Ƿ�Ϊѡ��
            if (fl.ToString() == "Sel")
            {
                if (dtBind != null && dtBind.GetChanges() != null)
                    if (MsgBox.MsgShow("��ǰ�׶���Ŀδ����,�Ƿ񱣴���Ŀ?", "��ʾ", MessageBoxButtons.YesNo, 300, 150) == DialogResult.Yes) SaveStepItem();

                pathWay.SaveItem_ToDataTable(dt, dtItem, this.sPathWayId);
                //������ѡ��Ľڵ����
                GItemObj selectObj = (GItemObj)sender;
                //�ж�ѡ��Ľڵ��Ƿ�Ϊ�׶νڵ�
                if (selectObj.Type == GItemObj.KindInfo.Item.ToString())
                {
                    //��ȡ�ڵ�ID,����ֵ����ǰ�׶�ID
                    sCurrentStepID = selectObj.Name.Remove(0, 5);
                    //��ȡ�׶���Ϣ,��ʾ���ؼ�
                    tbStepName.Tag = "set";
                    this.tbStepName.Text = selectObj.Text;
                    this.tbTimeUp.Value = selectObj.TIME_UP / 1440 + 1;
                    this.tbTimeDown.Value = selectObj.TIME_DOWN / 1440;
                    this.cbIsFirst.Checked = selectObj.IsFirst;
                    tbStepName.Tag = null;

                    //�׶���Ŀ��ѯ���
                    string tmpItem = @"
                                                          CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                                                          ( case when STEP_ITEM_KIND_ID IS not null then  CAST(STEP_ITEM_KIND_ID AS VARCHAR(50))
                                                            when STEP_ITEM_KIND_ID Is null and ITEMKIND =2 then 'MNGTYPE_' + cast(MNGTYPE as varchar(10))
                                                            when STEP_ITEM_KIND_ID Is null and ITEMKIND <>2 then 'ITEMKIND_' + cast(ITEMKIND as varchar(10)) end)  ParentID,
                                                                                 3 AS lb,
                                                                                '' AS Grouping,
                                                                   ";
                    sSqlStepItem = " SELECT {2} * FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{0}' AND [PATH_STEP_ID] = '{1}' ORDER BY SORT";
                    string sSqlStepItem1 = string.Format(sSqlStepItem,
                                   this.sPathWayId, sCurrentStepID, tmpItem);

                    //�׶θ��ڵ�ݹ��ѯ
                    string sFjd = "";
                    bool bFlag = SelectCQYZ(this.sCurrentStepID, ref sFjd);
                    sFjd = sFjd != "" ? "AND [PATH_STEP_ID] in (" + sFjd + ")" : " and 1<>1 ";

                    #region �Ǳ��׶γ���ҽ����ѯ

                    //����ҽ����ѯ���
                    //����ҽ����ѯ ����--��Ŀ����
                    string sCQYZ_tmp = @"
                                    select {2} FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{0}' 
                                    AND MNGTYPE = 0 " + sFjd + @" 
                                    AND (CQYZTZTS = 0 or CQYZTZTS is null or CQYZTZTS > (select TIME_UP FROM PATH_STEP where [PATH_STEP_ID] = '{1}') )
                                    AND [PATH_STEP_ID] <> '{1}'  ";
                    //�ֶ�
                    string sCQYZ_zd = @"
                                    CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                                    ( case when STEP_ITEM_KIND_ID IS not null then  CAST(STEP_ITEM_KIND_ID AS VARCHAR(50))
                                   when STEP_ITEM_KIND_ID Is null and ITEMKIND =2 then 'MNGTYPE_' + cast(MNGTYPE as varchar(10))
                                   when STEP_ITEM_KIND_ID Is null and ITEMKIND <>2 then 'ITEMKIND_' + cast(ITEMKIND as varchar(10)) end)  ParentID,
										           0 AS lb,
                                  '' AS Grouping, * ";
                    string sCQYZ = string.Format(sCQYZ_tmp + "  ORDER BY SORT", this.sPathWayId, sCurrentStepID, sCQYZ_zd);

                    #region ��ʱ����
                    //                        string.Format(@"
                    //                                    SELECT CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                    //                                    ( case when STEP_ITEM_KIND_ID IS not null then  CAST(STEP_ITEM_KIND_ID AS VARCHAR(50))
                    //                                   when STEP_ITEM_KIND_ID Is null and ITEMKIND =2 then 'MNGTYPE_' + cast(MNGTYPE as varchar(10))
                    //                                   when STEP_ITEM_KIND_ID Is null and ITEMKIND <>2 then 'ITEMKIND_' + cast(ITEMKIND as varchar(10)) end)  ParentID,
                    //										           0 AS lb,
                    //                                  '' AS Grouping, * FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{0}' 
                    //                                   AND MNGTYPE = 0 " + sFjd + @" 
                    //                                  AND (CQYZTZTS = 0 or CQYZTZTS is null or CQYZTZTS > (select TIME_UP FROM PATH_STEP where [PATH_STEP_ID] = '{1}') )
                    //                                    AND [PATH_STEP_ID] <> '{1}'  ORDER BY SORT"
                    //                                    , this.sPathWayId, sCurrentStepID);

                    #endregion

                   
                    string sCQYZ_kind_tmp = string.Format(sCQYZ_tmp, this.sPathWayId, sCurrentStepID, " STEP_ITEM_KIND_ID ");
                    string sCQYZ_kind = string.Format(@"
                                   SELECT CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ID,
                                                          ( case when ITEMKIND =2 then  'MNGTYPE_' + CAST(MNGTYPE as varchar(10)) 
                                                                 else 'ITEMKIND_' + CAST(ITEMKIND as  varchar(10)) end ) ParentID,
                                                                                0 AS lb,
                                                                               '' AS Grouping,
                                                                                * FROM [PATH_STEP_ITEM_KIND] WHERE [PATHAWAY_ID] = '{0}'  and step_item_kind_id in  
                                   ({1}) ORDER BY SORT"
                    , this.sPathWayId, sCQYZ_kind_tmp);


                    #endregion
                    



                    //�׶����Ͳ�ѯ���
                    string tmpKind = @"
                                                          CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ID,
                                                          ( case when ITEMKIND =2 then  'MNGTYPE_' + CAST(MNGTYPE as varchar(10)) 
                                                                 else 'ITEMKIND_' + CAST(ITEMKIND as  varchar(10)) end ) ParentID,
                                                                                2 AS lb,
                                                                               '' AS Grouping,
                                                                                ";
                    sSqlStepItemKind = " SELECT {2} * FROM [PATH_STEP_ITEM_KIND] WHERE [PATHAWAY_ID] = '{0}' AND [PATH_STEP_ID] = '{1}'";
                    string sSqlStepItemKind1 = string.Format(sSqlStepItemKind,
                                   this.sPathWayId, sCurrentStepID, tmpKind);


                    #region ��ʱ����

                    //                    string sSqlStepItem1 = string.Format(@"SELECT CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                    //                                                          CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ParentID,
                    //                                                                                 3 AS lb,
                    //                                                                              '00' AS KEYCODE,
                    //                                                                                '' AS Grouping,
                    //                                                                   CAST(JL AS INT) AS JL,
                    //                                                   * FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{0}' AND [PATH_STEP_ID] = '{1}' ORDER BY [SORT] DESC",
                    //                                   this.sPathWayId, sCurrentStepID);

                    //                    sSqlStepItemKind1 = string.Format(@"SELECT CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ID,
                    //                                                                        CAST([ITEMKIND] AS VARCHAR(3)) AS ParentID,
                    //                                                                                                     2 AS lb,
                    //                                                                                                  '00' AS KEYCODE,
                    //                                                                                                    '' AS Grouping,
                    //                                                       * FROM [PATH_STEP_ITEM_KIND] WHERE [PATHAWAY_ID] = '{0}' AND [PATH_STEP_ID] = '{1}'",
                    //                                       this.sPathWayId, sCurrentStepID);

                    #endregion

                    sSqlStepItem = string.Format(sSqlStepItem, this.sPathWayId, sCurrentStepID, ""); //��ղ���{2} �Ա㱣����
                    sSqlStepItemKind = string.Format(sSqlStepItemKind, this.sPathWayId, sCurrentStepID, ""); //��ղ���{2} �Ա㱣����


                    //����
                    string strSqlFl = @"
                        select  'ITEMKIND_' + cast(code as varchar(10)) as ID,null ParentID ,name  CONTENT,-10 lb,null MNGTYPE,cast(CODE as tinyint) ITEMKIND  from PATH_DM where KIND in (100) and valid in (1)
                        union 
                        select  'MNGTYPE_' + cast(code as varchar(10)) as ID,(case when KIND=101 then 'ITEMKIND_2' else null end) as ParentID,name  CONTENT,-1 lb,cast(CODE as tinyint) as MNGTYPE,cast(2 as tinyint) ITEMKIND from  PATH_DM where KIND=101 and valid in (1)
                        ";
                    dtFl = DbOpt.GetDataTable(strSqlFl);
                    


                    RepositoryItemLookUpEdit cmbStep = CtlFun.CreateRepositoryItemLookUpEdit("PATH_STEP_NAME", "PATH_STEP_ID", true);
                    //����ִ���������Դ
                    cmbStep.DataSource = dt;
                    //��ִ�����������
                    tlcPATH_STEP_ID.ColumnEdit = cmbStep;
                    tlcPATH_STEP_ID.OptionsColumn.AllowEdit = false;
                    cmbStep.Buttons[0].Visible = false;

                    //��ѯ�׶���Ŀ
                    dtStepItem = DbOpt.GetDataTable(sSqlStepItem1);
                    //��ѯ�׶���Ŀ����
                    dtStepItemKind = DbOpt.GetDataTable(sSqlStepItemKind1);

                    //�Ǳ��׶γ���ҽ����
                    DataTable dtCQYZ = DbOpt.GetDataTable(sCQYZ);
                    //�Ǳ��׶γ���ҽ�����ͱ�
                    DataTable dtCQYZ_kind = DbOpt.GetDataTable(sCQYZ_kind);

                    //��ʼ�������ݱ�,�ϲ��׶���Ŀ������
                    dtBind = new DataTable();
                    //�ϲ��׶���Ŀ
                    dtBind.Merge(dtStepItem);
                    //�ϲ��׶���Ŀ����
                    dtBind.Merge(dtStepItemKind);
                    dtBind.Merge(dtFl);
                    dtBind.Merge(dtCQYZ);
                    dtBind.Merge(dtCQYZ_kind);


                    BindingSource tItemData = new BindingSource();
                    tItemData.DataSource = dtBind;
                    tItemData.Sort = "lb,PATH_STEP_ID,sort";

                    //dtBind = new DataView(dtBind.Copy(), "", "lb,sort", DataViewRowState.CurrentRows).ToTable();

                    //�����ؼ�����Դ
                    tlItem.DataSource = tItemData;
                    tlItem.ExpandAll();
                }
            }
            this.pathWay.Refresh();
        }


        //string returnStr = "";
        private bool SelectCQYZ(string stepId, ref string returnValue)
        {
            bool bflag = false;
            DataRow[] dr = dtItem.Select(string.Format("PATH_STEP_ID2 = {0}", "'" + stepId + "'"));
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
                        SelectCQYZ(stepId_f1, ref returnValue);

                    }
                    else
                        continue;     
                }

            }
            return bflag;
        }


        /// <summary>
        /// ��ʼ��ͼ��
        /// </summary>
        public void Init()
        {
            try
            {
                #region ��ʼ���׶�ͼ��
                //��ѯSQL���
                this.sSql = string.Format("SELECT * FROM [PATH_STEP] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", sPathWayId);
                this.sSqlItem = string.Format("SELECT * FROM [PATH_STEP_RALATE] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", sPathWayId);
                //��ȡ����ѡ·����صĲ��������
                dt = DbOpt.GetDataTable(this.sSql);
                dtItem = DbOpt.GetDataTable(this.sSqlItem);
                //��������
                dt.PrimaryKey = new DataColumn[] { dt.Columns["PATH_STEP_ID"] };
                dtItem.PrimaryKey = new DataColumn[] { dtItem.Columns["PATH_STEP_RALATE_ID"] };
                //����ģ��
                LoadModel();
                //��DataTable����ͼ��
                pathWay.LoadItem_FromDataTable(dt, dtItem);

                #endregion         

                #region ��Ŀ���ư�

                #region ҽ����Ŀ��ѯ���

                //ҽ����Ŀ��ѯ���
                string sSqlContent = @"SELECT * FROM (SELECT a.[ORDER_NAME] AS ��Ŀ����,
																	  '' AS ����,
																	[BZ] AS ˵��,
																	  '' AS ���,
																	   1 AS ����,
															[ORDER_UNIT] AS ��λ,
													       (case when [RETAIL_PRICE] is null then d.PRICE else [RETAIL_PRICE]  end) AS ��װ����,
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
                                                                       0 AS ���ID,
                                                            [ORDER_TYPE] AS ҽ������
					                                FROM [JC_HOITEMDICTION] a left join [JC_HOI_HDI] b on a.ORDER_ID=b.HOITEM_ID
                                  left join [JC_HSITEM] c on b.HDITEM_ID=c.ITEM_ID and TC_FLAG=0
                                    left join JC_TC d on b.HDITEM_ID=d.ITEM_ID and TC_FLAG=1
WHERE a.[DELETE_BIT] = 0 UNION
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
                                                                A.[GGID] AS ���ID,
                                                                       0 AS ҽ������
									   FROM [VI_YF_KCMX] A LEFT JOIN [YP_YPBM] B ON A.[GGID]=B.[GGID])T ORDER BY LEN(ƴ����)";
                #endregion


                //��ѯҽ����Ŀ
                dtContent = DbOpt.GetDataTable(sSqlContent);

                //��ʼ����Ŀ����������
                this.cmbContent.ShowPopupShadow = true;
                this.cmbContent.PopupControl = this.spContent;
                this.cmbContent.DisplayMember = "��Ŀ����";
                this.cmbContent.ValueMember = "��Ŀ����";
                //����Ŀ��������������Դ
                this.cmbContent.DataSource = dtContent;
                //����ɸѡ��
                this.spContent.Filter = "(ƴ���� like '{0}%' or ƴ���� like '%{0}%' or ��Ŀ���� like '%{0}%')";
                //���������ֶ�
                this.spContent.KeyMember = "KEYCODE";
                //������
                string[] strColNames = new string[]{"��Ŀ����","����","˵��","���","����",
                                                    "��λ","��װ����","��װ��λ","�����",
                                                    "��浥λ","ƴ����","�����","CODE","��Ŀ��Դ",
                                                    "KEYCODE","ҩƷ����","ִ�п���"};

                //��ʾ����
                string[] strHeadNames = new string[]{"ҽ������(��Ŀ����)","����","˵��","���","��λ����",
                                                    "������λ","��װ����","��װ��λ","�����",
                                                    "��浥λ","ƴ����","�����","����","��Ŀ��Դ",
                                                    "Ψһ����","ҩƷ����","ִ�п���"};
                //���õ���DataGridView
                this.spContent.GridViewColumnInfo(strColNames, new int[] { 200, 50, 150, 100, 60, 60, 60, 60, 60, 60, 50, 0, 0, 0, 0, 0, 80 }, strHeadNames);

                cmbContent.ShowPopupCanPressKeyDown = true;
                cmbContent.ShowPopupInputTextValueIsNull = true;
                spContent.InputTextNotMatchCanReturnValue = true;
                cmbContent.InputTextNotMatchCanReturnValue = true;
                cmbContent.DefualtText = null;
                //���ñ��뷵��������
                this.spContent.MustReturnDatarow = true;
                //����Ŀ���Ƶ�����
                tlcContent.ColumnEdit = this.cmbContent;
                //�󶨵�����ѡ���¼�
                cmbContent.AfterSelData += new Trasen.Base.Cmb.PubFun.OnAfterSelDataHandle(cmbContent_AfterSelData);

                #endregion

                #region ִ������

                //��ʼ��ִ�����������
                RepositoryItemLookUpEdit cmbEXEC_TYPE = CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE", true);
                //����ִ������ڴ��
                DataTable dtEXEC_TYPE = new DataTable();
                dtEXEC_TYPE.Columns.Add("NAME", typeof(System.String));
                dtEXEC_TYPE.Columns.Add("CODE", typeof(System.Byte));
                DataRow drNew = dtEXEC_TYPE.NewRow();
                drNew = dtEXEC_TYPE.NewRow(); drNew.ItemArray = new object[] { "��ѡ", 0 }; dtEXEC_TYPE.Rows.Add(drNew);
                drNew = dtEXEC_TYPE.NewRow(); drNew.ItemArray = new object[] { "��ѡ", 1 }; dtEXEC_TYPE.Rows.Add(drNew);

                //����ִ���������Դ
                cmbEXEC_TYPE.DataSource = dtEXEC_TYPE;
                //��ִ�����������
                tlcEXEC_TYPE.ColumnEdit = cmbEXEC_TYPE;

                cmbEXEC_TYPE.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(cmbEXEC_TYPE_CloseUp);

                #endregion

                #region ѡ�����Ͱ�


                RepositoryItemLookUpEdit cmbSELECT_TYPE = CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE", true);

                DataTable dtSELECT_TYPE = new DataTable();
                dtSELECT_TYPE.Columns.Add("NAME", typeof(System.String));
                dtSELECT_TYPE.Columns.Add("CODE", typeof(System.Byte));
                DataRow drNewSelect = dtSELECT_TYPE.NewRow();

                drNewSelect = dtSELECT_TYPE.NewRow(); drNewSelect.ItemArray = new object[] { "��ѡ", 0 }; dtSELECT_TYPE.Rows.Add(drNewSelect);
                drNewSelect = dtSELECT_TYPE.NewRow(); drNewSelect.ItemArray = new object[] { "��ѡ", 1 }; dtSELECT_TYPE.Rows.Add(drNewSelect);

                cmbSELECT_TYPE.DataSource = dtSELECT_TYPE;

                tlcSELECT_TYPE.ColumnEdit = cmbSELECT_TYPE;

                #endregion

                #region �÷���

                //�÷���ѯ���
                string sSqlYF = "SELECT [NAME] AS �÷�,[PY_CODE] AS ƴ����,[ID] AS ��� FROM [JC_USAGEDICTION]";
                //��ѯ�÷�
                dtYF = DbOpt.GetDataTable(sSqlYF);
                //��ʼ���÷�����������
                this.cmbYF.PopupControl = this.spYF;
                this.cmbYF.DisplayMember = "�÷�";
                this.cmbYF.ValueMember = "���";
                this.cmbYF.ShowPopupCanPressKeyDown = true;
                //���÷���������������Դ
                this.cmbYF.DataSource = dtYF;
                //����ɸѡ��
                this.spYF.Filter = "( �÷� like '%{0}%' or ƴ���� like '%{0}%')";
                //���������ֶ�
                this.spYF.KeyMember = "���";
                //���ñ��뷵��������
                this.spYF.MustReturnDatarow = true;
                //���÷�������
                tlcYF.ColumnEdit = this.cmbYF;

                #endregion

                #region Ƶ�ΰ�

                //�÷���ѯ���
                string sSqlPC = "SELECT [NAME] AS Ƶ��,[PY_CODE] AS ƴ����,[ID] AS ��� FROM [JC_FREQUENCY]";
                //��ѯ�÷�
                dtPC = DbOpt.GetDataTable(sSqlPC);
                //��ʼ���÷�����������
                this.cmbPC.PopupControl = this.spPC;
                this.cmbPC.DisplayMember = "Ƶ��";
                this.cmbPC.ValueMember = "���";
                this.cmbPC.ShowPopupCanPressKeyDown = true;
                //���÷���������������Դ
                this.cmbPC.DataSource = dtPC;
                //����ɸѡ��
                this.spPC.Filter = "( Ƶ�� like '%{0}%' or ƴ���� like '%{0}%')";
                //���������ֶ�
                this.spPC.KeyMember = "���";
                //���ñ��뷵��������
                this.spPC.MustReturnDatarow = true;
                //���÷�������
                tlcPC.ColumnEdit = this.cmbPC;

                #endregion

                #region ������ʽ��

                //��ʼ��һ���ı���,���ڸ�ʽ��������Ԫ���е�����
                RepositoryItemCalcEdit jlEdit = CtlFun.CreateRepositoryItemCalcEdit(2);
                //���ü����еı༭�ؼ�
                this.tlcJL.ColumnEdit = jlEdit;
                //�����ı������ʾ��ʽ��
                //jlEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                //�����ı���ı༭��ʽ��
                jlEdit.EditMask = "f";
                

                #endregion

                #region ͣ��������ʽ��

                RepositoryItemCalcEdit tsEdit = CtlFun.CreateRepositoryItemCalcEdit(0);

                this.tlcTS.ColumnEdit = tsEdit;

                tsEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                tsEdit.Mask.EditMask = "d2";

                #endregion


                this.UseHelp("��ʼ�����!");
            }
            catch (Exception ex)
            {
                this.UseHelp("��ʼ��ʧ�ܣ�" + ex.Message);
            }
        }




        /// <summary>
        /// ��Ŀѡ���¼�
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SelectValue"></param>
        void cmbContent_AfterSelData(object Sender, Trasen.Base.Cmb.PubFun.ValueInfo SelectValue)
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
                tlItem.FocusedNode.SetValue("JL", selectRow["����"].ToString());      //��ʼ������
                tlItem.FocusedNode.SetValue("ZXKS", selectRow["ִ�п���"].ToString());      //��ʼ��ִ�п���
                tlItem.FocusedNode.SetValue("XMLY", selectRow["��Ŀ��Դ"].ToString());      //��ʼ����Ŀ��Դ
                tlItem.FocusedNode.SetValue("JLDW", selectRow["��λ"].ToString());          //��ʼ��������λ
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

                    dtBind.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["FZXH"] = DBNull.Value;
                    dtBind.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["Grouping"] = "";
                }

                //  JLDWID ������λID  δ����
                //  TS     ����        δ����
                //  YF     �÷�        ���û�����
                //  PC     Ƶ��        ���û�����
                //  ZT     ����        ���û�����
                //  BZBY   �Ա�ҩ      ���û�����

                tlItem.EndCurrentEdit();
                //������۽���ִ�����
                tlItem.FocusedColumn = tlcEXEC_TYPE;
                //tlItem.ShowEditor();
            }
            else
            {
                tlItem.FocusedNode.SetValue("CONTENT", SelectValue.InputText);
                tlItem.EndCurrentEdit();
                //������۽���ִ�����
                tlItem.FocusedColumn = tlcEXEC_TYPE;
            }
        }

        /// <summary>
        /// Ԫ��ɾ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pathWay_ItemDelete(object sender, EventArgs e)
        {
            try
            {
                //��ȡɾ����Ԫ��
                PathWay.GItemObj delObj = (PathWay.GItemObj)sender;
                //����obj.Name��ȡGUID
                string strGUID = delObj.Name.Substring(delObj.Type.Length + 1);
                //�ж�Ԫ������
                if (delObj.Type == "Item")
                {
                    if (dt.Rows.Find(strGUID) != null)
                        dt.Rows.Find(strGUID).Delete();
                }
                else
                {
                    if (dtItem.Rows.Find(strGUID) != null)
                        dtItem.Rows.Find(strGUID).Delete();
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("ɾ��ʧ�ܣ�" + ex.Message);
            }
        }

        /// <summary>
        /// ����ģ��
        /// </summary>
        private void LoadModel()
        {
            //����·��û���κν׶�,�����ģ��
            if (dt.Rows.Count + dtItem.Rows.Count == 0)
            {
                #region ��ʼ��������SQL���

                //��ʼ������������
                ArrayList tabAl = new ArrayList();
                tabAl.Add("PATH_STEP_MODEL");
                tabAl.Add("PATH_STEP_RALATE_MODEL");

                //��ʼ��SQL��������
                ArrayList sqlAl = new ArrayList();
                sqlAl.Add(string.Format("SELECT TOP {0} * FROM PATH_STEP_MODEL order by note", iPathWayMaxDay));
                sqlAl.Add(string.Format("SELECT TOP {0} * FROM PATH_STEP_RALATE_MODEL order by note", iPathWayMaxDay - 1));

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
                    drStep["PATHWAY_ID"] = this.sPathWayId;
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
                    drRelate["PATHWAY_ID"] = this.sPathWayId;
                    //���NOTE
                    drRelate["NOTE"] = DBNull.Value;
                }

                #endregion

                #region �ϲ����ݲ�����

                //��������ģ��ϲ�����ǰ·���Ľ׶κ͹�����
                dt.Merge(dsTmp.Tables["PATH_STEP_MODEL"]);
                dtItem.Merge(dsTmp.Tables["PATH_STEP_RALATE_MODEL"]);
                //ѭ�����ý׶α�����Ϊ����
                foreach (DataRow dr in dt.Rows)
                {
                    dr.AcceptChanges();
                    dr.SetAdded();
                }
                //ѭ�����ù���������Ϊ����
                foreach (DataRow dr in dtItem.Rows)
                {
                    dr.AcceptChanges();
                    dr.SetAdded();
                }
                //����׶κ͹���
                SavePath();

                #endregion

                this.UseHelp("ģ��������!");
            }
        }

        /// <summary>
        /// ����ͼ��
        /// </summary>
        public void SavePath()
        {
            try
            {
                //����ͼ��DataTable
                pathWay.SaveItem_ToDataTable(dt, dtItem, this.sPathWayId);
                //����DataTable
                this.BindingContext[dt].EndCurrentEdit();
                this.BindingContext[dtItem].EndCurrentEdit();
                int rows = DbOpt.Update(new DataTable[] { dt, dtItem }, new string[] { sSql, sSqlItem }, null, null);
                if (rows >= 0)
                {
                    dt.AcceptChanges();
                    dtItem.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("����ʧ�ܣ�" + ex.Message);
            }
        }

        /// <summary>
        /// ������Ŀ
        /// </summary>
        private void SaveStepItem()
        {
            try
            {
                //�жϰ������Ƿ����
                if (dtBind != null)
                {
                    //�������ؼ��ı༭״̬
                    tlItem.EndCurrentEdit();
                    //����������Դ�ı༭״̬
                    this.BindingContext[dtBind].EndCurrentEdit();

                    //��ʼ��һ���ڴ��,���ڱ�����Ŀ����   //��ʼ��һ��������,���ڱ���Ҫ����ķ�������
                    DataTable dtSaveItem = dtBind.Copy(); DataRow[] drRemoveItem = dtSaveItem.Select("lb in (-1,-10,2) or CONTENT is null or CONTENT = ''");
                    //ѭ������Ҫ����ķ�������,������Ŀ���н���ɾ��
                    foreach (DataRow dr in drRemoveItem)
                    {
                        //ɾ����Ŀ���еķ�������
                        dtSaveItem.Rows.Remove(dr);
                    }
                    //��ȡSQL������Զ����ֶε����һ���ֶε�����
                    int col = dtSaveItem.Columns.IndexOf("Grouping");
                    //ѭ�������Զ����ֶ�,��������Ŀ����ɾ��
                    for (int i = dtSaveItem.Columns.Count - 1; i >= 0; i--)
                    {
                        if (i <= col) dtSaveItem.Columns.RemoveAt(i);
                    }

                    //��ʼ��һ���ڴ��,���ڱ����������   //��ʼ��һ��������,���ڱ���Ҫ�������Ŀ����
                    DataTable dtSaveKind = dtBind.Copy(); DataRow[] drRemoveKind = dtSaveKind.Select("lb in (-1,-10,0,3) or CONTENT is null or CONTENT = ''");
                    //ѭ������Ҫ�������Ŀ����,���ڷ�����н���ɾ��
                    foreach (DataRow dr in drRemoveKind)
                    {
                        //ɾ��������е���Ŀ����
                        dtSaveKind.Rows.Remove(dr);
                    }

                    //��ȡSQL������Զ����ֶε����һ���ֶε�����
                    col = dtSaveItem.Columns.IndexOf("Grouping");
                    //ѭ�������Զ����ֶ�,�����ڷ������ɾ��
                    for (int i = dtSaveKind.Columns.Count - 1; i >= 0; i--)
                    {
                        if (i <= col) dtSaveKind.Columns.RemoveAt(i);
                    }

                    //����������Ŀ��ı༭״̬
                    this.BindingContext[dtSaveItem].EndCurrentEdit();
                    //������������ı༭״̬
                    this.BindingContext[dtSaveKind].EndCurrentEdit();

                    //����Ŀ��ͷ��������ݱ��浽���ݿ�,�������޸�����
                    int rows = DbOpt.Update(new DataTable[] { dtSaveItem, dtSaveKind }, new string[] { sSqlStepItem, sSqlStepItemKind }, null, null);
                    //�ж��޸������Ƿ���ڻ����0,����ˢ���ڴ��
                    if (rows >= 0)
                    {
                        dtSaveItem.AcceptChanges();
                        dtSaveKind.AcceptChanges();
                        dtBind.AcceptChanges();
                        this.UseHelp("����ɹ�!");
                    }
                    else
                    {
                        this.UseHelp("û��������Ҫ����");
                    }
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("����ʧ�ܣ�" + ex.Message);
            }

        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathWayModify_Load(object sender, EventArgs e)
        {
            //��ʼ��ͼ��
            this.Init();
            //�ж�·��״̬,
            if (isReadOnly)
            {
                this.panel1.Enabled = false;
                this.barSave.Enabled = false;
            }

        }

        /// <summary>
        /// �ڵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlItem_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
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

                if (!this.isReadOnly)
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
                        tlcContent.OptionsColumn.AllowEdit = true;
                        tlcSELECT_TYPE.OptionsColumn.AllowEdit = true;


                        tlcContent.ColumnEdit = null;
                    }
                    else if (sLb == "3")
                    {
                        //�����ؼ�����Ϊ�༭״̬
                        tlItem.ShowEditor();
                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlcContent.OptionsColumn.AllowEdit = true;
                        tlcEXEC_TYPE.OptionsColumn.AllowEdit = true;
                        tlcJL.OptionsColumn.AllowEdit = true;
                        tlcYF.OptionsColumn.AllowEdit = true;
                        tlcPC.OptionsColumn.AllowEdit = true;
                        tlcZT.OptionsColumn.AllowEdit = true;
                        tlcBZBY.OptionsColumn.AllowEdit = true;
                        tlcTS.OptionsColumn.AllowEdit = true;
                        tlcJLDW.OptionsColumn.AllowEdit = true;

                        tlcContent.ColumnEdit = cmbContent;
                    }
                    else if (sLb == "0")
                    {
                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlcTS.OptionsColumn.AllowEdit = true;
                    }


                    if (sLb == "-1" || sParentLb == "-1")
                    {
                        this.btnAddItem.Enabled = true;
                        this.btnAddKind.Enabled = true;
                    }
                    else if (sLb == "2" || sLb == "-1" || sLb == "3")
                    {
                        this.btnAddItem.Enabled = true;
                        this.btnAddKind.Enabled = false;
                    }
                    else
                    {
                        this.btnAddItem.Enabled = false;
                        this.btnAddKind.Enabled = false;
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
                    tlcJS.OptionsColumn.AllowEdit = dtContent.Select("ҩƷ���� = '03' and CODE = " + e.Node["CJID"] + " and ��Ŀ��Դ = " + e.Node["XMLY"]).Length > 0;
                    tlcJL.OptionsColumn.AllowEdit = dtContent.Select("��Ŀ��Դ = '1' and CODE = " + e.Node["CJID"] + "").Length > 0;

                    //������Ŀ�ĳ���ID��ִ�п��Ҳ�ѯ��Ŀ�ĵ�λ�͵�λ����
                    dtDW = InstanceForm.BDatabase.GetDataTable("exec SP_YF_SELECT_DW " + e.Node["CJID"] + "," + e.Node["ZXKS"] + "");

                    ////��ʼ��ִ�����������
                    //cmbDW = CtlFun.CreateRepositoryComboBox(true, dtDW.DefaultView, "s_ypdw");
                    //cmbDW.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


                    //��ʼ����λ����������
                    this.cmbDW.ShowPopupShadow = true;
                    this.cmbDW.PopupControl = this.spDW;
                    this.cmbDW.DisplayMember = "s_ypdw";
                    this.cmbDW.ValueMember = "s_ypdw";
                    //����Ŀ��������������Դ
                    this.cmbDW.DataSource = dtDW;
                    //����ɸѡ��
                    this.spDW.Filter = "s_ypdw like '{0}'";
                    //���������ֶ�
                    this.spDW.KeyMember = "dwlx";
                    //������
                    string[] strColNames = new string[] { "s_ypdw", "dwlx" };

                    //��ʾ����
                    string[] strHeadNames = new string[] { "��λ", "��λ����" };
                    //���õ���DataGridView
                    this.spDW.GridViewColumnInfo(strColNames, new int[] { 50, 0 }, strHeadNames);

                    cmbDW.ShowPopupCanPressKeyDown = true;
                    cmbDW.ShowPopupInputTextValueIsNull = true;
                    //���ñ��뷵��������
                    this.spDW.MustReturnDatarow = true;
                    //�󶨵�λ������
                    tlcJLDW.ColumnEdit = cmbDW;
                    //�󶨵�����ѡ���¼�
                    cmbDW.AfterSelData += new Trasen.Base.Cmb.PubFun.OnAfterSelDataHandle(cmbDW_AfterSelData);

                }
            }
        }

        /// <summary>
        /// ��λѡ���¼�
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SelectValue"></param>
        void cmbDW_AfterSelData(object Sender, Trasen.Base.Cmb.PubFun.ValueInfo SelectValue)
        {
            if (!SelectValue.CloseUpIsNotMatch)
            {
                tlItem.FocusedNode.SetValue("JLDW", SelectValue.datarow["s_ypdw"].ToString());
                tlItem.FocusedNode.SetValue("DWLX", SelectValue.datarow["dwlx"].ToString());
                tlItem.EndCurrentEdit();
                tlItem.FocusedColumn = tlcTS.OptionsColumn.AllowEdit ? tlcTS : tlcYF;
            }
       
        }



        private bool tlItem_ProcessCmd_Key(ref Message msg, Keys keyData)
        {
            bool flag = false;
            //switch (keyData)
            //{
            //    //case System.Windows.Forms.Keys.Tab:
            //    //    for (int i = 0; i < tlItem.VisibleColumnCount; i++)
            //    //    {
            //    //        DevExpress.XtraTreeList.Columns.TreeListColumn col = tlItem.FocusedColumn;
            //    //        if (col == null || col.VisibleIndex == tlItem.VisibleColumnCount - 1)
            //    //        {
            //    //            tlItem.FocusedColumn = tlItem.Columns[0];
            //    //        }
            //    //        else tlItem.FocusedColumn = tlItem.Columns[col.VisibleIndex + 1];
            //    //        if (col.VisibleIndex < 6) tlItem.FocusedColumn = tlItem.Columns[6];
            //    //        break;
            //    //    }
            //    //    tlItem.Focus();
            //    //    tlItem.ShowEditor();
            //    //    return true;
            //    case System.Windows.Forms.Keys.Enter:
            //        //string sColName = tlItem.FocusedColumn.Caption;
            //        //switch (sColName)
            //        //{
            //        //    case "��Ŀ����":
            //        //        tlItem.FocusedColumn = tlcSELECT_TYPE;
            //        //        break;
            //        //    case "ѡ�����":
            //        //        tlItem.FocusedColumn = tlcEXEC_TYPE;
            //        //        break;
            //        //    case "ִ�����":
            //        //        tlItem.FocusedColumn = tlcJS.OptionsColumn.AllowEdit ? tlcJS : tlcJL;
            //        //        break;
            //        //    case "����":
            //        //        tlItem.FocusedColumn = tlcJL;
            //        //        break;
            //        //    case "����":
            //        //        tlItem.FocusedColumn = tlcJLDW;
            //        //        break;
            //        //    case "��λ":
            //        //        tlItem.FocusedColumn = tlcYF;
            //        //        break;
            //        //    case "�÷�":
            //        //        tlItem.FocusedColumn = tlcPC;
            //        //        break;
            //        //    case "Ƶ��":
            //        //        tlItem.FocusedColumn = tlcZT;
            //        //        break;
            //        //    case "����":
            //        //        if (tlItem.FocusedNode.NextNode == null && tlItem.FocusedNode["CONTENT"].ToString().Length > 0)
            //        //        {
            //        //            NewItem(false);
            //        //        }
            //        //        break;
            //        //    default:
            //        //        break;
            //        //}
            //        break;
            //}
            return flag;
        }



        /// <summary>
        /// ������Ŀ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {

            NewItem(true);

            #region ��ʱ����

            ////�жϵ�ǰ�ڵ��Ƿ�Ϊ��,��Ϊ�ղ���ִ�в���
            //if (tlItem.FocusedNode != null)
            //{

            //    //��ʼ���ڵ����,�����ж��Ƿ�������ӷ���
            //    string sLb = tlItem.FocusedNode["lb"].ToString();
            //    //��ʼ�����ڵ����,�����ж��Ƿ�������ӷ���
            //    string sParentLb = "";//��ʼΪ���ַ���
            //    //�жϵ�ǰ�ڵ�ĸ��ڵ��Ƿ�Ϊ��
            //    if (tlItem.FocusedNode.ParentNode != null)
            //    {
            //        //�粻Ϊ��,���ȡ���ڵ�����
            //        sParentLb = tlItem.FocusedNode.ParentNode["lb"].ToString();
            //    }

            //    //����һ���ڵ�,���ڱ����½ڵ�ĸ��ڵ�
            //    TreeListNode tlnNow;
            //    //�жϵ�ǰ�ڵ������Ƿ�Ϊ3,�����½ڵ�ĸ��ڵ�Ϊ��ǰ�ڵ�ĸ��ڵ�,�����½ڵ�ĸ��ڵ�Ϊ��ǰ�ڵ�
            //    if (tlItem.FocusedNode["lb"].ToString() == "3") tlnNow = tlItem.FocusedNode.ParentNode;
            //    else tlnNow = tlItem.FocusedNode;
            //    //չ���½ڵ�ĸ��ڵ�
            //    ExpandNode(tlnNow);
            //    //�Ӱ󶨵�����Դ����һ��������
            //    DataRow drNew = dtBind.NewRow();
            //    //��ʼ��һ���µ�GUID,��Ϊ�½ڵ�ID
            //    string sID = Guid.NewGuid().ToString();
            //    //��ʼ���½ڵ�ĸ��ڵ�ID
            //    string sParentID = tlnNow["ID"].ToString();

            //    //��ʼ�����е�����
            //    drNew["ID"] = sID;//��ȡ�½ڵ�ID                                                                        //����[�ڵ�ID]
            //    drNew["ParentID"] = sParentID;//��ȡ�½ڵ�ĸ��ڵ�ID                                                    //����[���ڵ�ID]
            //    drNew["lb"] = 3;//�ڵ����(3Ϊ��Ŀ,2Ϊ����),�����Ƿ���,����Ϊ3                                          //����[�ڵ����]
            //    drNew["PATH_STEP_ITEM_ID"] = sID;//��ȡ�½ڵ�ID                                                         //����[��ĿID]
            //    //�ж��½ڵ�ĸ��ڵ�����Ƿ�Ϊ-1,�����½ڵ�ķ���IDΪNULL,�����½ڵ�ķ���IDΪ���ڵ�ID                  //������Ŀ[����ID]
            //    if (tlnNow["lb"].ToString() == "-1") drNew["STEP_ITEM_KIND_ID"] = DBNull.Value;
            //    else drNew["STEP_ITEM_KIND_ID"] = sParentID;
            //    drNew["PATH_STEP_ID"] = this.sCurrentStepID;//��ȡ��ǰѡ����ID                                        //������Ŀ���ڵ�[����ID]
            //    drNew["PATHAWAY_ID"] = this.sPathWayId;//��ȡ��ǰ·��ID                                                 //������Ŀ���ڵ�[·��ID]
            //    drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//��ȡ���ڵ���Ŀ����(1Ϊ���ƹ���,2Ϊҽ��,3Ϊ������) //������Ŀ��[��Ŀ����]
            //    drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//��ȡ���ڵ㳤�ٱ���(0Ϊ����ҽ��,1Ϊ��ʱҽ��)           //������Ŀ��[�����ڱ���]
            //    drNew["EXEC_TYPE"] = 0;//ָ��ִ�����(0Ϊ��ѡ,1Ϊ��ѡ),Ĭ��Ϊ��ѡ                                       //������Ŀ��[ִ�����]
            //    drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//��ȡ��ǰ����Ա                                //������Ŀ��[��¼��]
            //    drNew["OPER_DATE"] = DateTime.Now;//��ȡϵͳ��ǰʱ��                                                    //������Ŀ��[��¼����]
            //    drNew["DELETE_BIT"] = 0;//ָ��ɾ��״̬(0Ϊδɾ��,1Ϊ��ɾ��),������������,����Ϊ0                        //������Ŀ��[ɾ�����]
            //    drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//��ȡ�������                //������Ŀ��[�������]
            //    this.sNowGroup = Guid.NewGuid().ToString();//�����µ�GUID,��Ϊ��ǰ����ID
            //    //�ж��½ڵ�ĸ��ڵ��Ƿ������ӽڵ�
            //    if (tlnNow.HasChildren)
            //    {
            //        string sFZXH = tlnNow.LastNode["FZXH"].ToString();
            //        if (sFZXH != "" && dtBind.Select(string.Format("FZXH = '{0}'", sFZXH)).Length > 1)
            //        {
            //            tlnNow.LastNode["Grouping"] = "��";
            //        }
            //        else
            //        {
            //            tlnNow.LastNode["Grouping"] = "";
            //        }
            //    }

            //    drNew["FZXH"] = sNowGroup;//���÷���ID                                                                  //������Ŀ��[�������]
            //    drNew["Grouping"] = "��";                                                                               //������Ŀ��[������]

            //    //��������ӵ��󶨵�����Դ
            //    dtBind.Rows.Add(drNew);
            //    //����һ���ڵ�,���ڻ�ȡ�����Ľڵ�
            //    TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
            //    //�ж��½ڵ��Ƿ�Ϊ��,���򽫵�ǰ�۽��ڵ�����Ϊ�½ڵ�
            //    if (newNode != null) tlItem.FocusedNode = newNode;
            //    //����ǰ�۽�������Ϊ������
            //    tlItem.FocusedColumn = tlcContent;
            //    //��ȡ���ؼ�����
            //    tlItem.Focus();
            //    tlItem.ShowEditor();
            //}

            #endregion

            
        }


        /// <summary>
        /// ������Ŀ
        /// </summary>
        /// <param name="isNew">�Ƿ��¿�(trueΪ�¿�,falseΪ����)</param>
        private void NewItem(bool isNew)
        {
            //�жϵ�ǰ�ڵ��Ƿ�Ϊ��,��Ϊ�ղ���ִ�в���
            if (tlItem.FocusedNode != null)
            {
                //����һ���ڵ�,���ڱ����½ڵ�ĸ��ڵ�
                TreeListNode tlnNow;
                //�жϵ�ǰ�ڵ������Ƿ�Ϊ3,�����½ڵ�ĸ��ڵ�Ϊ��ǰ�ڵ�ĸ��ڵ�,�����½ڵ�ĸ��ڵ�Ϊ��ǰ�ڵ�
                if (tlItem.FocusedNode["lb"].ToString() == "3" || tlItem.FocusedNode["lb"].ToString() == "0") tlnNow = tlItem.FocusedNode.ParentNode;
                else tlnNow = tlItem.FocusedNode;

                //�ж��Ƿ�Ϊ�¿�
                if (isNew)
                {
                    this.sNowGroup = Guid.NewGuid().ToString();//�����µ�GUID,��Ϊ��ǰ����ID
                    spContent.DataSource = dtContent;
                }
                else
                {
                    this.sNowGroup = tlnNow.LastNode["FZXH"].ToString();

                    DataView dvContent = dtContent.DefaultView;
                    string strCjid = TrasenClasses.GeneralClasses.Convertor.IsInteger(tlnNow.LastNode["CJID"].ToString()) ? tlnNow.LastNode["CJID"].ToString() : "-1";
                    if (dtContent.Select("ҩƷ���� = '03' and CODE = " + strCjid + " and ��Ŀ��Դ = '" + tlnNow.LastNode["XMLY"]+"'").Length > 0)
                    {
                        dvContent.RowFilter = "ҩƷ���� = '03'";
                    }
                    else
                    {
                        dvContent.RowFilter = string.Format("��Ŀ��Դ = '{0}' and ҩƷ���� <> 3", tlnNow.LastNode["XMLY"].ToString());
                    }
                    spContent.DataSource = dvContent.ToTable();

                    //�ж���Ŀ��Դ�Ƿ�ΪҩƷ
                    if (tlnNow.LastNode["XMLY"].ToString() == "1")
                    {
                        string sFZXH = tlnNow.LastNode["FZXH"].ToString();
                        int iFZGS = dtBind.Select(string.Format("FZXH = '{0}'", sFZXH)).Length;

                        if (sFZXH != "" && iFZGS >= 1)
                        {
                            tlnNow.LastNode["Grouping"] = iFZGS > 1 ? "��" : "��";
                        }
                        else
                        {
                            tlnNow.LastNode["Grouping"] = "";
                            dtBind.Select("ID = '" + tlnNow.LastNode["ID"] + "'")[0]["FZXH"] = DBNull.Value;
                        }
                    }

                }

                //չ���½ڵ�ĸ��ڵ�
                ExpandNode(tlnNow);
                //�Ӱ󶨵�����Դ����һ��������
                DataRow drNew = dtBind.NewRow();
                //��ʼ��һ���µ�GUID,��Ϊ�½ڵ�ID
                string sID = Guid.NewGuid().ToString();
                //��ʼ���½ڵ�ĸ��ڵ�ID
                string sParentID = tlnNow["ID"].ToString();



                //��ʼ�����е�����
                drNew["ID"] = sID;//��ȡ�½ڵ�ID                                                                        //����[�ڵ�ID]
                drNew["ParentID"] = sParentID;//��ȡ�½ڵ�ĸ��ڵ�ID                                                    //����[���ڵ�ID]
                drNew["lb"] = 3;//�ڵ����(3Ϊ��Ŀ,2Ϊ����),�����Ƿ���,����Ϊ3                                          //����[�ڵ����]
                drNew["PATH_STEP_ITEM_ID"] = sID;//��ȡ�½ڵ�ID                                                         //����[��ĿID]
                //�ж��½ڵ�ĸ��ڵ�����Ƿ�Ϊ-1,�����½ڵ�ķ���IDΪNULL,�����½ڵ�ķ���IDΪ���ڵ�ID                  //������Ŀ[����ID]
                if (tlnNow["lb"].ToString() == "-1") drNew["STEP_ITEM_KIND_ID"] = DBNull.Value;
                else drNew["STEP_ITEM_KIND_ID"] = sParentID;
                drNew["PATH_STEP_ID"] = this.sCurrentStepID;//��ȡ��ǰѡ����ID                                        //������Ŀ���ڵ�[����ID]
                drNew["PATHAWAY_ID"] = this.sPathWayId;//��ȡ��ǰ·��ID                                                 //������Ŀ���ڵ�[·��ID]
                drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//��ȡ���ڵ���Ŀ����(1Ϊ���ƹ���,2Ϊҽ��,3Ϊ������) //������Ŀ��[��Ŀ����]
                drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//��ȡ���ڵ㳤�ٱ���(0Ϊ����ҽ��,1Ϊ��ʱҽ��)           //������Ŀ��[�����ڱ���]
                drNew["EXEC_TYPE"] = 0;//ָ��ִ�����(0Ϊ��ѡ,1Ϊ��ѡ),Ĭ��Ϊ��ѡ                                       //������Ŀ��[ִ�����]
                drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//��ȡ��ǰ����Ա                                //������Ŀ��[��¼��]
                drNew["OPER_DATE"] = DateTime.Now;//��ȡϵͳ��ǰʱ��                                                    //������Ŀ��[��¼����]
                drNew["DELETE_BIT"] = 0;//ָ��ɾ��״̬(0Ϊδɾ��,1Ϊ��ɾ��),������������,����Ϊ0                        //������Ŀ��[ɾ�����]
                drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//��ȡ�������                //������Ŀ��[�������]

                if (this.sNowGroup != "") drNew["FZXH"] = this.sNowGroup;                                               //������Ŀ��[�������]       

                string sGrouping;//��ʼ��������  
                if (isNew) sGrouping = "��";//����¿�
                else if (tlnNow.LastNode["XMLY"].ToString() == "1") sGrouping = "��";//�����һ����ĿΪҩƷ
                else sGrouping = "";//������϶�����,�����Ŀ����Ҫ������
                drNew["Grouping"] = sGrouping;                                                                          //������Ŀ��[������]

                //��������ӵ��󶨵�����Դ
                dtBind.Rows.Add(drNew);
                //����һ���ڵ�,���ڻ�ȡ�����Ľڵ�
                TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
                //�ж��½ڵ��Ƿ�Ϊ��,���򽫵�ǰ�۽��ڵ�����Ϊ�½ڵ�
                if (newNode != null) tlItem.FocusedNode = newNode;
                //����ǰ�۽�������Ϊ������
                tlItem.FocusedColumn = tlcContent;
                //��ȡ���ؼ�����
                tlItem.Focus();
                tlItem.ShowEditor();
            }
        }



        /// <summary>
        /// չ���ڵ㼰�临�ڵ�(ֱ�����ڵ�)
        /// </summary>
        /// <param name="node"></param>
        private void ExpandNode(TreeListNode node)
        {
            if (node != null) node.ExpandAll();
            if (node.PrevNode != null) node.PrevNode.ExpandAll();
        }

        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddKind_Click(object sender, EventArgs e)
        {
            NewKind();
        }

        private void NewKind()
        {
            //�жϵ�ǰ�ڵ��Ƿ�Ϊ��,��Ϊ�ղ���ִ�в���
            if (tlItem.FocusedNode != null)
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
                    DataRow drNew = dtBind.NewRow();
                    //��ʼ��һ���µ�GUID,��Ϊ�½ڵ�ID
                    string sID = Guid.NewGuid().ToString();

                    //��ʼ�����е�����
                    drNew["ID"] = sID;//��ȡ�½ڵ�ID                                                                        //����[�ڵ�ID]
                    drNew["ParentID"] = tlnNow["ID"].ToString();//��ȡ�½ڵ�ĸ��ڵ�ID                                      //����[���ڵ�ID]
                    drNew["lb"] = 2;//�ڵ����(3Ϊ��Ŀ,2Ϊ����),�����Ƿ���,����Ϊ2                                          //����[�ڵ����]
                    drNew["STEP_ITEM_KIND_ID"] = sID;//��ȡ�½ڵ�ID                                                         //����[����ID]
                    drNew["PATH_STEP_ID"] = this.sCurrentStepID;//��ȡ��ǰѡ����ID                                        //���÷������ڵ�[����ID]
                    drNew["PATHAWAY_ID"] = this.sPathWayId;//��ȡ��ǰ·��ID                                                 //���÷������ڵ�[·��ID]
                    drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//��ȡ���ڵ���Ŀ����(1Ϊ���ƹ���,2Ϊҽ��,3Ϊ������) //���÷����[��Ŀ����]
                    drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//��ȡ���ڵ㳤�ٱ���(0Ϊ����ҽ��,1Ϊ��ʱҽ��)           //���÷����[�����ڱ���]
                    drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//��ȡ��ǰ����Ա                                //���÷����[��¼��]
                    drNew["OPER_DATE"] = DateTime.Now;//��ȡϵͳ��ǰʱ��                                                    //���÷����[��¼����]
                    drNew["DELETE_BIT"] = 0;//ָ��ɾ��״̬(0Ϊδɾ��,1Ϊ��ɾ��),������������,����Ϊ0                        //���÷����[ɾ�����]
                    drNew["SELECT_TYPE"] = 1;//ָ��ѡ������(0Ϊ��ѡ,1Ϊ��ѡ),Ĭ��Ϊ��ѡ                                     //���÷����[ѡ������]
                    drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//��ȡ�������                //���÷����[�������]

                    //��������ӵ��󶨵�����Դ
                    dtBind.Rows.Add(drNew);

                    //����һ���ڵ�,���ڻ�ȡ�����Ľڵ�
                    TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
                    //�ж��½ڵ��Ƿ�Ϊ��,���򽫵�ǰ�۽��ڵ�����Ϊ�½ڵ�
                    if (newNode != null) tlItem.FocusedNode = newNode;
                    //����ǰ�۽�������Ϊ������
                    tlItem.FocusedColumn = tlcContent;
                    //��ȡ���ؼ�����
                    tlItem.Focus();
                }
            }
        }


        /// <summary>
        /// �Ҽ��˵������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsTree_Opening(object sender, CancelEventArgs e)
        {
            //�ж���Ŀ��ѡ�����Ƿ����1
            if (tlItem.Selection.Count > 1)
            {
                bool bFlag = true;//��ʼ�����ñ�־,Ĭ��true
                //ѭ��������ѡ�ڵ�,�жϷ������(FZXH)�Ƿ����
                foreach (TreeListNode node in tlItem.Selection)
                {
                    //�жϸýڵ��Ƿ��з������
                    if (node["FZXH"].ToString().Length > 0)
                        //����з������,�����ñ�־ΪFalse
                        bFlag = false;
                }
                //�����ñ�־��ֵ�����鰴ť.
                tsmiGrouping.Enabled = bFlag;
            }
            else
            {
                //���ѡ�������1,����鰴ť������
                tsmiGrouping.Enabled = false;
            }

            //�жϵ�ǰѡ�����ڵ��Ƿ�Ϊ��,���з������(FZXH),��������ʾ�ѷ���,����������ʾδ����,ͬʱ����ȡ�����鰴ť����״̬
            tsmiCancelGrouping.Enabled = tlItem.FocusedNode != null && tlItem.FocusedNode["FZXH"].ToString().Length > 0;
        }


        /// <summary>
        /// ҩƷ��Ŀ�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGrouping_Click(object sender, EventArgs e)
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
                    lstNodeID.Add(node.Id);
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
                            if (node.Id == lstNodeID[0])
                                node["Grouping"] = "��";
                            //�ж��Ƿ�Ϊ���һ���ڵ�,����ө���־
                            else if (node.Id == lstNodeID[tlItem.Selection.Count - 1])
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
        /// ҩƷ��Ŀȡ�������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCancelGrouping_Click(object sender, EventArgs e)
        {
            //�ж���ѡ�ڵ㲻Ϊ��
            if (tlItem.FocusedNode != null)
            {
                //��ȡ��ѡ�ڵ�ķ������
                string sGroupId = tlItem.FocusedNode["FZXH"].ToString();
                //���ݷ�����Ų�ѯ����Դ�е�ͬ������
                DataRow[] drGroup = dtBind.Select("FZXH = '" + sGroupId + "'");
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


        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SavePath();
            SaveStepItem();
        }

        private void barPathWayAssessment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new FrmPathWayAssessment(this.sPathWayId).ShowDialog();
        }

        private void barRuleDictionary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new FrmRuleDictionary().ShowDialog();
        }

        /// <summary>
        /// �иı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlItem_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            tlItem.ShowEditor();
        }

        private void tlItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ColIndexMove(e);
            }
            else if (e.KeyCode == Keys.F3 && btnAddItem.Enabled)
            {
                NewItem(true);
            }
            else if (e.KeyCode == Keys.F2 && btnAddKind.Enabled)
            {
                NewKind();
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
                    tlItem.FocusedColumn = tlcSELECT_TYPE;
                    break;
                case "ѡ�����":
                    tlItem.FocusedColumn = tlcEXEC_TYPE;
                    if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();
                    break;
                case "ִ�����":
                    tlItem.FocusedColumn = tlcJS.OptionsColumn.AllowEdit ? tlcJS : tlcJL;
                    if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();
                    break;
                case "����":
                    tlItem.FocusedColumn = tlcJL;
                    break;
                case "����":
                    tlItem.FocusedColumn = tlcJLDW;
                    break;
                case "��λ":
                    tlItem.FocusedColumn = tlcTS.OptionsColumn.AllowEdit ? tlcTS : tlcYF;
                    break;
                case "�ڼ���ĩͣ��":
                    tlItem.FocusedColumn = tlcYF;
                    break;
                case "�÷�":
                    tlItem.FocusedColumn = tlcPC;
                    break;
                case "Ƶ��":
                    tlItem.FocusedColumn = tlcZT;
                    break;
                case "����":
                    bool isItem = tlItem.FocusedNode["lb"].ToString() == "3";
                    if (tlItem.FocusedNode.NextNode == null && tlItem.FocusedNode["CONTENT"].ToString().Length > 0 && isItem)
                    {
                        NewItem(false);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ִ�����������ر��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmbEXEC_TYPE_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            dtBind.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["EXEC_TYPE"] = e.Value;
            tlItem.FocusedColumn = tlcJS.OptionsColumn.AllowEdit ? tlcJS : tlcJL;
        }

        /// <summary>
        /// ���ؼ���Ԫ��༭�����̰����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlItem_EditorKeyDown(object sender, KeyEventArgs e)
        {
            //�жϰ����Ƿ�ΪEnter�ҵ�ǰ�۽����в�Ϊִ�����
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn != tlcEXEC_TYPE)
            {
                ColIndexMove(e);
            }
        }


        #region �׶���Ϣ�޸�

        /// <summary>
        /// �׶������޸��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbStepName_TextChanged(object sender, EventArgs e)
        {
            //ִ�н׶���Ϣ�޸ķ���,�޸Ľ׶���
            ModifyItem(Enum.KindModifyItem.text);
        }

        /// <summary>
        /// �׶���ʼ״̬�޸��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbIsFirst_CheckedChanged(object sender, EventArgs e)
        {
            //ִ�н׶���Ϣ�޸ķ���,�޸���ʼ״̬
            ModifyItem(Enum.KindModifyItem.isFirst);
        }

        /// <summary>
        /// �׶ο�ʼ�����޸��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTimeUp_TextChanged(object sender, EventArgs e)
        {
            //ִ�н׶���Ϣ�޸ķ���,�޸Ŀ�ʼ����
            ModifyItem(Enum.KindModifyItem.time_up);
        }

        /// <summary>
        /// �׶ν��������޸��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTimeDown_TextChanged(object sender, EventArgs e)
        {
            //ִ�н׶���Ϣ�޸ķ���,�޸Ľ�������
            ModifyItem(Enum.KindModifyItem.time_down);
        }

        /// <summary>
        /// �׶���Ϣ�޸�
        /// </summary>
        /// <param name="kindModifyItem">�޸���Ϣ������</param>
        private void ModifyItem(Enum.KindModifyItem kindModifyItem)
        {
            //�жϵ�ǰѡ��׶�Ϊ��,�����ɸ�ֵ�����ĸ��¼�,�򷵻�..
            if (pathWay.LastGObj == null || tbStepName.Tag != null) return;

            //��ȡ��ǰѡ��׶ε���Ϣ
            string strText = pathWay.LastGObj.Text;
            int time_up = pathWay.LastGObj.TIME_UP;
            int time_down = pathWay.LastGObj.TIME_DOWN;
            bool isFirst = pathWay.LastGObj.IsFirst;
            //�����޸���Ϣ���������ж���Щ��Ϣ��Ҫ�޸�
            if (kindModifyItem == Enum.KindModifyItem.text) strText = tbStepName.Text;
            if (kindModifyItem == Enum.KindModifyItem.time_up) time_up = (int)tbTimeUp.Value > 0 ? (((int)tbTimeUp.Value) - 1) * 1440 : 0;
            if (kindModifyItem == Enum.KindModifyItem.time_down) time_down = ((int)tbTimeDown.Value) * 1440;
            if (kindModifyItem == Enum.KindModifyItem.isFirst) isFirst = cbIsFirst.Checked;
            //ִ�н׶���Ϣ�޸�
            pathWay.ModifyItem(pathWay.LastGObj, strText, isFirst, time_up, time_down);
        }

        #endregion

        /// <summary>
        /// ���ؼ���Ԫ��ֵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlItem_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column == tlcTS)
            {
                e.Node["CQYZTZTS"] = Convert.ToInt32(e.Value) * 1440;
            }
        }


        private void tlItem_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if ((e.Node == tlItem.FocusedNode && e.Column != tlItem.FocusedColumn) || e.Node == null || e.Column == null) return;
            if (e.Node["lb"].ToString().Equals("0"))//&& e.Node["PATH_STEP_ID"].ToString().Equals(this.sCurrentStepID)==false
            {
                //e.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Strikeout);
                e.Appearance.ForeColor = SystemColors.ControlDark;
                e.Appearance.BackColor = SystemColors.Control;
            }
        }


       
    }

}