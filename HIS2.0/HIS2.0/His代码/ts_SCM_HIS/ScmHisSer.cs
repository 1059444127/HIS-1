using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;


namespace ts_SCM_HIS
{
    /// <summary>
    /// ************************************************************
    /// ˵������HIS�д��ݽ��ɹ��ƻ���SCM,���Ӳɹ��ƻ����޸Ĳɹ��ƻ�,
    ///       ��ҩƷ�ֵ�������ҩƷ���޸�ҩƷ��ɾ��ҩƷ�ֵ䣬
    ///       ��ҩƷ�ֵ���Ϣ���͵�SCMϵͳ�����õ��ķ���
    /// ���ƣ�ScmHisSer.cs
    /// ����ˣ�HuangYD
    /// ���ʱ�䣺2016-09-03
    /// ���һ���޸�ʱ�䣺
    /// ���һ���޸��ˣ�     
    /// 
    /// ***********************************************************
    /// </summary>
    public class ScmHisSer
    {
        /// <summary>
        /// ��HIS�вɹ��ƻ���Ϣ�͵�SCMϵͳ������SCM�ӿ��з���
        /// </summary>
        /// <param name="CheasePlan">�ɹ��ƻ�����</param>
        /// <param name="ActionFlag">����ɾ�������ַ�</param>
        /// <param name="Suc_Flag">�ɹ�����ʶ</param>
        /// <param name="err_Flag">Ĭ�ϴ�true</param>
        public static void HisPushChasePlanToSCM(List<SCMPurchasePlan> CheasePlan, string ActionFlag, out bool Suc_Flag,out bool err_Flag)
        {
            Suc_Flag = false;
            err_Flag = false;

            if (CheasePlan.Count>0)
            {
                try
                {

                    /*�ɹ�ƾ֤��	        EBELN	string
                   ��Ŀ���	        EBELP	string
                   ��Ӧ���˻�	        LIFNR	string
                   ���ص�	        NAME	string
                   ҩƷ���	        MATNR	string
                   ҩƷ����	        TXZ01	string
                   Ժ��ID	            WERKS	string
                   Ժ������	        WERKST	string
                   ��棨�ͻ����ص�	LGORT	string
                   �ͻ�����	        MENGE	Decimal��17,4��
                   ������λID	        MEINS	string
                   ������λ����	    MSEHT	string
                   ���ۣ������ۣ�	    NETPR	Decimal��14,4��
                   ��������	        EINDT	string
                   �ɹ���������	    BEDAT	string 
                   ��ע	            COMMENTS	string
                   Ԥ���ֶ�	        FREEUSE	    string  */

                    WebReference.SAPtoSCM ScmSer = new WebReference.SAPtoSCM();
                    List<ts_SCM_HIS.WebReference.Sap_PurchasePlan> ScmHisinfoAll = new List<ts_SCM_HIS.WebReference.Sap_PurchasePlan>();

                    foreach (SCMPurchasePlan infomx in CheasePlan)
                    {
                        ts_SCM_HIS.WebReference.Sap_PurchasePlan SCMinfo = new ts_SCM_HIS.WebReference.Sap_PurchasePlan();
                        SCMinfo.EBELN = infomx.EBELN;
                        SCMinfo.EBELP = infomx.EBELP;
                        SCMinfo.LIFNR = infomx.LIFNR;
                        SCMinfo.NAME = infomx.NAME;
                        SCMinfo.MATNR = infomx.MATNR;
                        SCMinfo.TXZ01 = infomx.TXZ01;
                        SCMinfo.WERKS = infomx.WERKS;
                        SCMinfo.WERKST = infomx.WERKST;
                        SCMinfo.LGORT = infomx.LGORT;
                        SCMinfo.MENGE = infomx.MENGE.ToString();
                        SCMinfo.MEINS = infomx.MEINS;
                        SCMinfo.MSEHT = infomx.MSEHT.ToString();
                        SCMinfo.NETPR = infomx.NETPR.ToString();
                        SCMinfo.EINDT = infomx.EINDT;
                        SCMinfo.BEDAT = infomx.BEDAT;
                        SCMinfo.COMMENTS = infomx.COMMENTS;
                        SCMinfo.FREEUSE = infomx.FREEUSE;

                        ScmHisinfoAll.Add(SCMinfo);
                    }
                    
                    ScmSer.GetPucharseFromSap(ScmHisinfoAll.ToArray(), ActionFlag, out Suc_Flag, out err_Flag);


                }
                catch (System.Exception err)
                {                    
                    throw new System.Exception(err.ToString());
                }
            }
        }



        /// <summary>
        /// ��HIS��ҩƷ�ֵ䴫��SCMϵͳ���õ��ķ���
        /// </summary>
        /// <param name="DrugItem">ҩƷ�ֵ����</param>
        /// <param name="ActFlag">����ɾ�������ַ�</param>
        /// <param name="Suc_Flag">�ɹ�����ʶ</param>
        /// <param name="err_Flag">Ĭ�ϴ�true</param>
        public static void HisPushDrugItemToSCM(List<SCMHisDrugItem> DrugItem, string ActFlag,out bool Suc_Flag,out bool err_Flag)
        {
            Suc_Flag = false;
            err_Flag = false;
            if (DrugItem.Count>0)
            {
                try
                {                    
                  
                    WebReference.SAPtoSCM ScmSer = new WebReference.SAPtoSCM();
                    List<ts_SCM_HIS.WebReference.HIS_DRUG> HISDrugAll = new List<ts_SCM_HIS.WebReference.HIS_DRUG>();

                    foreach(SCMHisDrugItem druginfo in DrugItem)
                    {
                          /*    ҩƷ����	NAME	string
                                ҩƷ����	CODE	string
                                ҩƷ���	SPEC	string
                                ��������	FACTORY	string
                                ҩƷ����	MRJJ	Decimal��14��4�� */
                        ts_SCM_HIS.WebReference.HIS_DRUG ScmDrug = new ts_SCM_HIS.WebReference.HIS_DRUG();
                        ScmDrug.NAME = druginfo.NAME;
                        ScmDrug.CODE = druginfo.CODE;
                        ScmDrug.SPEC = druginfo.SPEC;
                        ScmDrug.FACTORY = druginfo.FACTORY;
                        ScmDrug.MRJJ = druginfo.MRJJ.ToString();
                        HISDrugAll.Add(ScmDrug);
                    }
                    ScmSer.GetDrugFromHIS(HISDrugAll.ToArray(), ActFlag,out Suc_Flag,out err_Flag);

                }
                catch (System.Exception err)
                {
                    throw new System.Exception(err.ToString());
                }
            }
        }


        /// <summary>
        /// ͨ���ɹ��ƻ���˺�õ�SCM�ӿ�Ҫ�����Ϣ����SCM
        /// </summary>
        /// <param name="strDeptID">��¼�����ڵĿ���</param>
        /// <param name="strDjh">���ݺ�</param>
        /// <param name="ZbID">����ID</param>
        /// <param name="db">���ݿ�����</param>
        /// <returns>���ݱ�</returns>
        public static DataTable GetCgmxByDeptAndId(string strDeptID, string strDjh, string ZbID,RelationalDatabase db)
        {
            string strSQL = " SELECT A.DJH AS EBELN ,B.ID AS EBELP,(10000000+B.WLDW) AS LIFNR,C.NAME AS NAME ,B.CJID AS MATNR,D.S_YPPM AS TXZ01," +
                            " C.YQID AS WERKS,C.YQMC AS WERKST,A.DEPTID AS LGORT,B.JHS AS MENGE,E.ID AS MEINS,B.YPDW AS MSEHT,B.CKJJ AS NETPR,A.JHCGRQ AS EINDT, " +
                            " A.JHCGRQ AS BEDAT  " +
                            " FROM YF_CG AS A LEFT JOIN YF_CGMX AS B ON A.ID=B.DJID LEFT JOIN JC_DEPT_PROPERTY AS C ON A.DEPTID=C.DEPT_ID " +
                            " LEFT JOIN YP_YPCJD AS D ON B.CJID=D.CJID LEFT JOIN YP_YPDW AS E ON B.YPDW=E.DWMC " +
                            " WHERE  A.SHBZ='1' And A.DJH='" + strDjh + "' and A.DEPTID='" + strDeptID + "' ";
                            // " where  A.SHBZ='1' And A.DJH='" + strDjh + "' and A.DEPTID='" + strDeptID + "' and A.ID='" + ZbID + "'";
            DataTable tab = db.GetDataTable(strSQL);
            return tab;
        }

        /// <summary>
        /// ͨ��CJID�õ�ҩƷ��Ϣ
        /// </summary>
        /// <param name="strCjID">ҩƷID</param>
        /// <param name="db">���ݿ�����</param>
        /// <returns>���ݱ�</returns>
        public static DataTable GetDrugInfoByCjid(string strCjID, RelationalDatabase db)
        {
            string strSQL = " SELECT S_YPPM AS NAME,CJID AS CODE,S_YPGG AS SPEC,S_SCCJ AS FACTORY,PFJ AS MRJJ FROM YP_YPCJD " +
                            " WHERE  CJID='" + strCjID + "' ";
            DataTable tab = db.GetDataTable(strSQL);
            return tab;
        }


        
    }
}
