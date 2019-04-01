using System;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;
using System.Collections;

/*
 * ���ƣ�סԺ���������ݿ�����ࣨts_zygl_report��
 * ������������סԺ�������е����ݿ����
 * ��дʱ�䣺2013-10
 * ���ߣ�Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class ReportManageDataBaseAccessClass
    {
        public static DataTable RmPatientWasDischargedStatisticsDivision(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT ��Ժ����,סԺ��,����,����,��Ժ����,��Ժ����,��Ʊ��,��������,SUM(CASE ��Ŀ WHEN '+ITEM_NAME+' THEN ��� END)['+RTRIM(CAST(ITEM_NAME AS VARCHAR(100)))+'] FROM (SELECT DISTINCT ITEM_NAME FROM JC_STAT_ITEM) AS A, ";
                        sSql = sSql + " ҽ��֧��,�ܷ���,Ԥ��,�Ը�,����,SUM(CASE WHEN CODE IN ('01','02','03') THEN ��� END) AS ҩƷ�ϼ�, ";
                        sSql = sSql + " SUM(CASE WHEN CODE NOT IN ('01','02','03') THEN ��� END) AS ҽ�ƺϼ�,SUM(���) AS �ϼ� ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT A.INPATIENT_NO AS סԺ��,A.NAME AS ����,A.BRLX_NAME AS ����,A.IN_DATE AS ��Ժ����,A.OUT_DATE AS ��Ժ����, ";
                        sSql = sSql + " A.CUR_DEPT_NAME AS ��Ժ����,A.BILLNO AS ��Ʊ��,B.DISCHARGE_DATE AS ��������,C.ITEM_NAME AS ��Ŀ, ";
                        sSql = sSql + " ACVALUE AS ���,B.YB_FEE AS ҽ��֧��,B.NFEE AS �ܷ���,B.DEPTOSITS AS Ԥ��,B.SELF_FEE AS �Ը�, ";
                        sSql = sSql + " B.PATCH_FEE AS ����,C.CODE ";
                        sSql = sSql + " FROM VI_ZY_VINPATIENT_ALL A  ";
                        sSql = sSql + " INNER JOIN ZY_DISCHARGE B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                        sSql = sSql + " INNER JOIN ZY_FEE_SPECI E ON A.INPATIENT_ID = E.INPATIENT_ID ";
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM C ON C.CODE = E.STATITEM_CODE ";
                        sSql = sSql + " WHERE E.DELETE_BIT = 0 AND E.CHARGE_BIT = 1 AND B.CANCEL_BIT = 0 ";
                        sSql = String.Format("{0} AND B.DISCHARGE_DATE >= '{1}' AND B.DISCHARGE_DATE < '{2}' ", sSql, arrList[0], arrList[1]);
                        sSql = sSql + " ) AA ";
                        sSql = sSql + " GROUP BY ��Ժ����,סԺ��,����,����,��Ժ����,��Ժ����,��Ʊ��,��������,ҽ��֧��,�ܷ���,Ԥ��,�Ը�,���� ";
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT '' AS ��Ժ����,'�ϼ�' AS סԺ��,'' AS ����,'' AS ����,NULL AS ��Ժ����,NULL AS ��Ժ����,NULL AS ��Ʊ��, ";
                        sSql = sSql + " NULL AS ��������,SUM(CASE ��Ŀ WHEN '+ITEM_NAME+' THEN ��� END)['+RTRIM(CAST(ITEM_NAME AS VARCHAR(100)))+'] FROM (SELECT DISTINCT ITEM_NAME FROM JC_STAT_ITEM) AS A, ";
                        sSql = sSql + " SUM(CASE WHEN ҽ��֧�� IS NULL THEN 0 ELSE ҽ��֧�� END) AS ҽ��֧��, ";
                        sSql = sSql + " SUM(CASE WHEN �ܷ��� IS NULL THEN 0 ELSE �ܷ��� END) AS �ܷ���, ";
                        sSql = sSql + " SUM(CASE WHEN Ԥ�� IS NULL THEN 0 ELSE Ԥ�� END) AS Ԥ��, ";
                        sSql = sSql + " SUM(CASE WHEN �Ը� IS NULL THEN 0 ELSE �Ը� END) AS �Ը�, ";
                        sSql = sSql + " SUM(CASE WHEN ���� IS NULL THEN 0 ELSE ���� END) AS ����, ";
                        sSql = sSql + " SUM(CASE WHEN CODE IN ('01','02','03') THEN ��� END) AS ҩƷ�ϼ�, ";
                        sSql = sSql + " SUM(CASE WHEN CODE NOT IN ('01','02','03') THEN ��� END) AS ҽ�ƺϼ�, ";
                        sSql = sSql + " SUM(���) AS �ϼ� ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT A.INPATIENT_NO AS סԺ��,A.NAME AS ����,A.BRLX_NAME AS ����,A.IN_DATE AS ��Ժ����,A.OUT_DATE AS ��Ժ����, ";
                        sSql = sSql + " A.CUR_DEPT_NAME AS ��Ժ����,A.BILLNO AS ��Ʊ��,B.DISCHARGE_DATE AS ��������,C.ITEM_NAME AS ��Ŀ, ";
                        sSql = sSql + " ACVALUE AS ���,B.YB_FEE AS ҽ��֧��,B.NFEE AS �ܷ���,B.DEPTOSITS AS Ԥ��,B.SELF_FEE AS �Ը�, ";
                        sSql = sSql + " B.PATCH_FEE AS ����,C.CODE ";
                        sSql = sSql + " FROM VI_ZY_VINPATIENT_ALL A  ";
                        sSql = sSql + " INNER JOIN ZY_DISCHARGE B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                        sSql = sSql + " INNER JOIN ZY_FEE_SPECI E ON A.INPATIENT_ID = E.INPATIENT_ID ";
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM C ON C.CODE = E.STATITEM_CODE ";
                        sSql = sSql + " WHERE E.DELETE_BIT = 0 AND E.CHARGE_BIT = 1 AND B.CANCEL_BIT = 0 ";
                        sSql = String.Format("{0} AND B.DISCHARGE_DATE >= '{1}' AND B.DISCHARGE_DATE < '{2}' ", sSql, arrList[0], arrList[1]);
                        sSql = sSql + " ) BB ";

                    }
                    break;
                case ConnectType.ORACLE:
                    {
                    }
                    break;
                case ConnectType.IBMDB2:
                    {
                    }
                    break;
                case ConnectType.MSACCESS:
                    {
                    }
                    break;
                case ConnectType.OTHER:
                    {
                    }
                    break;
            }
            DataTable daTable = dataBase.GetDataTable(sSql);
            return daTable;
        }
        public static DataTable RmProjectCostsAreBasedOnStatisticsOfThePatient(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT * FROM ( ";
                        sSql = sSql + " SELECT '�ϼ�' ���,'' ҽ������,'' ����,'' סԺ��,'' ��������,'' ��Ʊ��,SUM(YB_FEE) ҽ��֧��,SUM(LACK_FEE) Ƿ��,'' ����Ա ";
                        sSql = sSql + " FROM YY_BRXX A INNER JOIN ZY_INPATIENT B ON A.BRXXID = B.PATIENT_ID INNER JOIN ZY_DISCHARGE C ON B.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE ((B.YBLX = {1} AND {1} > 0) OR (B.YBLX > 0 AND {1} = 0 )) ", sSql, arrList[2]);
                        sSql = String.Format("{0} AND C.DISCHARGE_DATE >= '{1}' AND C.DISCHARGE_DATE <= '{2}' ", sSql, arrList[0], arrList[1]);
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT '' ���,(SELECT AA.NAME FROM JC_YBLX AA WHERE ID = B.YBLX) ҽ������,A.BRXM ����,INPATIENT_NO סԺ��, ";
                        sSql = sSql + " DBO.FUN_GETDATE(C.DISCHARGE_DATE ) ��������,CAST(BILLNO AS VARCHAR(50)) ��Ʊ��,YB_FEE ҽ��֧��,LACK_FEE Ƿ��, ";
                        sSql = sSql + " DBO.FUN_GETEMPNAME(USERID) ����Ա ";
                        sSql = sSql + " FROM YY_BRXX A INNER JOIN ZY_INPATIENT B ON A.BRXXID = B.PATIENT_ID ";
                        sSql = sSql + " INNER JOIN ZY_DISCHARGE C ON B.INPATIENT_ID = C.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE ((B.YBLX = {1} AND {1} > 0) OR (B.YBLX > 0 AND {1} = 0 )) ", sSql, arrList[2]);
                        sSql = String.Format("{0} AND C.DISCHARGE_DATE >= '{1}' AND C.DISCHARGE_DATE <= '{2}' ", sSql, arrList[0], arrList[1]);
                        sSql = sSql + " ) A ORDER BY ���,ҽ������,�������� ";
                    }
                    break;
                case ConnectType.ORACLE:
                    {
                    }
                    break;
                case ConnectType.IBMDB2:
                    {
                    }
                    break;
                case ConnectType.MSACCESS:
                    {
                    }
                    break;
                case ConnectType.OTHER:
                    {
                    }
                    break;
            }
            DataTable daTable = dataBase.GetDataTable(sSql);
            return daTable;
        }
        public static DataTable RmPatientsDischargedFromTheHospitalAndClassifiedByProject(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            DataTable tempTable = null;
            string tempSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 0)
                        {
                            tempSql = tempSql + " SELECT 0,B.DEPT_ID,A.INPATIENT_ID,STATITEM_CODE,SUN(SDVALUE) FROM ZY_FEE_SPECI A ";
                            tempSql = tempSql + " INNER JOIN ZY_INPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                            tempSql = String.Format("{0} WHERE FLAG NOT IN (2,6) AND CHARGE_DATE >= '{1}' AND CHARGE_DATE <= '{2}' ", tempSql, arrList[1], arrList[2]);
                            tempSql = tempSql + " AND CHARGE_BIT = 1 AND DELETE_BIT = 0 AND DISCHARGE_BIT = 0 ";
                            tempSql = String.Format("{0} (({1} > 0 AND B.DEPT_ID = {1}) OR ({1} = 0)) ", tempSql, Convert.ToInt32(arrList[3]));
                            tempSql = tempSql + " GROUP BY B.DEPT_ID,A.INPATIENT_ID,STATITEM_CODE ";
                        }
                        else
                        {
                            tempSql = tempSql + " SELECT A.ID,A.DEPT_ID,A.INPATIENT_ID,STATITEM_CODE,SUM(ITEMVALUES) FROM ZY_DISCHARGE A ";
                            tempSql = tempSql + " INNER JOIN ZY_DISCHARGELIST B ON A.ID = B.DISCHARGE_ID ";
                            tempSql = String.Format("{0} WHERE DISCHARGE_DATE >= '{1}' AND DISCHARGE_DATE <= '{2}' ", tempSql, arrList[1], arrList[2]);
                            tempSql = String.Format("{0} AND (({1} > 0 AND B.DEPT_ID = {1} = 0)) ", tempSql, Convert.ToInt32(arrList[3]));
                            tempSql = tempSql + " GROUP BY A.ID,A.DEPT_ID,A.INPATIENT_ID,STATITEM_CODE ";
                        }
                    }
                    break;
            }

            DataTable daTable = dataBase.GetDataTable(sSql);
            return daTable;
        }
    }
}