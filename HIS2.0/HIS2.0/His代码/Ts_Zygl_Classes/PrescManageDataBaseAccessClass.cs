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
 * ���ƣ�סԺ�����������ݿ������
 * ������������סԺ���������е����ݿ����
 * ��дʱ�䣺2013-10
 * ���ߣ�Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class PrescManageDataBaseAccessClass
    {
        /// <summary>
        /// ��ѯ�Ƿ���ҩƷ
        /// </summary>
        /// <param name="deptId">����ID</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static int ApplyDrugLeadingDrug(int isPosition,ArrayList arrList, RelationalDatabase dataBase)  
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (isPosition == 1)
                        {
                            sSql = String.Format("{0} SELECT COUNT(1) FROM ZY_FEE_SPECI WHERE STATITEM_CODE IN ('01','02') AND CHARGE_BIT = 1 AND FY_BIT = 0 AND (APPLY_ID IS NULL OR APPLY_ID = '{1}') ", sSql, Guid.Empty);
                            sSql = String.Format("{0} AND DEPT_ID = {1}", sSql, arrList[0]);
                        }
                        else if (isPosition == 2)
                        {
                            sSql = sSql + " SELECT COUNT(1) FROM ZY_FEE_SPECI WHERE CZ_FLAG != 2 AND STATITEM_CODE IN ('01','02') AND CHARGE_BIT = 1 AND FY_BIT = 0 ";
                            sSql = String.Format("{0} AND EXECDEPT_ID = {1} AND (APPLY_ID IS NULL OR APPLY_ID = '{3}') AND DEPT_ID = {2} ", sSql, arrList[1], arrList[0], Guid.Empty);
                        }
                        else if (isPosition == 3)
                        {
                            sSql = sSql + " SELECT COUNT(1) FROM ZY_FEE_SPECI WHERE CZ_FLAG = 2 AND STATITEM_CODE IN ('01','02') AND CHARGE_BIT = 1 AND FY_BIT = 0 ";
                            sSql = String.Format("{0} AND EXECDEPT_ID = {1} AND (APPLY_ID IS NULL OR APPLY_ID = '{3}') AND DEPT_ID = {2} ", sSql, arrList[1], arrList[0], Guid.Empty);
                        }
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

            return Convert.ToInt32(dataBase.GetDataRow(sSql)[0]);
        }
        /// <summary>
        /// ��ȡִ�п���
        /// </summary>
        /// <param name="dataBase">��������</param>
        /// <returns></returns>
        public static DataTable ApplyDrugGetDept(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT DEPTID,KSMC FROM YP_YJKS WHERE KSLX = 'ҩ��' ";
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
        /// <summary>
        /// ������ҩͳ�쵥/������ҩͳ�쵥
        /// </summary>
        /// <param name="applyTime">����ʱ��</param>
        /// <param name="employeeId">��ԱID</param>
        /// <param name="wardId">����ID</param>
        /// <param name="deptId">����ID</param>
        /// <param name="msgType">����</param>
        /// <param name="dataBase">���ݿ�����</param>
        public static void ApplyDrugGenerationSingleMedicatinGuideOfWithdrawal(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string[] sSql = new string[2];

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql[0] = sSql[0] + " INSERT INTO ZY_APPLY_DRUG (APPLY_DATE,APPLY_NURSE,APPLY_WARD,EXECDEPT_ID,MSG_TYPE) ";
                        sSql[0] = String.Format("{0} VALUES ('{1}',{2},'{3}',{4},{5}) ", sSql[0], Convert.ToDateTime(arrList[0]), Convert.ToInt32(arrList[1]), arrList[2], Convert.ToInt32(arrList[3]), Convert.ToInt32(arrList[4]));


                        sSql[1] = String.Format("{0} UPDATE ZY_FEE_SPECI SET TLFS = 0,APPLY_ID = SELECT IDENT_CURRENT('ZY_APPLY_DRUG'),APPLY_DATE = '{1}', ", sSql[1], Convert.ToDateTime(arrList[0]));
                        sSql[1] = String.Format("{0} DEPT_LY = {1} WHERE APPLY_ID = 0 AND STATITEM_CODE IN ('01','02') AND CZ_FLAG != 2 ", sSql[1], Convert.ToInt32(arrList[3]));
                        sSql[1] = String.Format("{0} AND FY_BIT = 0 AND DELETE_BIT = 0 AND CHARGE_BIT = 1 AND DEPT_ID = {1} ", sSql[1], Convert.ToInt32(arrList[3]));

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

            dataBase.DoCommand(null,null,null,sSql);
        }
        /// <summary>
        /// ͳ����Ϣ��ѯ
        /// </summary>
        /// <param name="arrList">��������</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable ApplyDrugQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            DataTable daTable = null;

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if ((bool)arrList[0] == true && (bool)arrList[2] == true)//�ѷ�ҩ ��ҩ
                        {
                            sSql = sSql + " SELECT RTRIM(B.ITEM_NAME) AS ҩƷ����,RTRIM(UNIT) AS ��λ,SUM(NUM) AS ����,RETAIL_PRICE AS ����,SUM(ACVALUE) AS ���, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(DOC_ID) AS ��ҩҽ��,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS ������, ";
                            sSql = sSql + " DBO.FUN_GETDATE(CHARGE_DATE) AS ����ʱ��,DBO.FUN_ZY_SEEKDEPTNAME(A.EXECDEPT_ID) AS ִ�п���, ";
                            sSql = sSql + " (CASE FY_BIT WHEN 1 THEN '�ѷ�' WHEN 0 THEN 'δ��' ELSE 'δ֪' END) AS �Ƿ�ҩ ";
                            sSql = sSql + " FROM ZY_APPLY_DRUG A INNER JOIN ZY_FEE_SPECI B ON A.APPLY_ID = B.APPLY_ID ";
                            sSql = String.Format("{0} WHERE B.FY_BIT = 1 AND B.CZ_FLAG != 2 AND CAST ( DBO.FUN_GETDATE(A.APPLY_DATE)As datetime) = cast('{1}' as datetime)", sSql, arrList[4]);
                            sSql = String.Format("{0} AND DEPT_ID = {1} ", sSql, Convert.ToInt32(arrList[5]));
                            sSql = sSql + " GROUP BY B.ITEM_NAME,B.UNIT,RETAIL_PRICE,DOC_ID,CHARGE_USER,DBO.FUN_GETDATE(CHARGE_DATE),A.EXECDEPT_ID,FY_BIT ";
                        }
                        else if ((bool)arrList[0] == true && (bool)arrList[3] == true)  //�ѷ�ҩ ��ҩ
                        {
                            sSql = sSql + " SELECT RTRIM(B.ITEM_NAME) AS ҩƷ����,RTRIM(UNIT) AS ��λ,SUM(NUM) AS ����,RETAIL_PRICE AS ����,SUM(ACVALUE) AS ���, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(DOC_ID) AS ��ҩҽ��,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS ������, ";
                            sSql = sSql + " DBO.FUN_GETDATE(CHARGE_DATE) AS ����ʱ��,DBO.FUN_ZY_SEEKDEPTNAME(A.EXECDEPT_ID) AS ִ�п���, ";
                            sSql = sSql + " (CASE FY_BIT WHEN 1 THEN '�ѷ�' WHEN 0 THEN 'δ��' ELSE 'δ֪' END) AS �Ƿ�ҩ ";
                            sSql = sSql + " FROM ZY_APPLY_DRUG A INNER JOIN ZY_FEE_SPECI B ON A.APPLY_ID = B.APPLY_ID ";
                            sSql = String.Format("{0} WHERE B.FY_BIT = 1 AND B.CZ_FLAG = 2 AND CAST ( DBO.FUN_GETDATE(A.APPLY_DATE)As datetime) = cast('{1}' as datetime) ", sSql, arrList[4]);
                            sSql = String.Format("{0} AND DEPT_ID = {1} ", sSql, Convert.ToInt32(arrList[5]));
                            sSql = sSql + " GROUP BY B.ITEM_NAME,B.UNIT,RETAIL_PRICE,DOC_ID,CHARGE_USER,DBO.FUN_GETDATE(CHARGE_DATE),A.EXECDEPT_ID,FY_BIT ";
                        }
                        else if ((bool)arrList[1] == true && (bool)arrList[2] == true) //δ��ҩ ��ҩ
                        {
                            sSql = sSql + " SELECT RTRIM(B.ITEM_NAME) AS ҩƷ����,RTRIM(UNIT) AS ��λ,SUM(NUM) AS ����,RETAIL_PRICE AS ����,SUM(ACVALUE) AS ���, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(DOC_ID) AS ��ҩҽ��,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS ������, ";
                            sSql = sSql + " DBO.FUN_GETDATE(CHARGE_DATE) AS ����ʱ��,DBO.FUN_ZY_SEEKDEPTNAME(A.EXECDEPT_ID) AS ִ�п���, ";
                            sSql = sSql + " (CASE FY_BIT WHEN 1 THEN '�ѷ�' WHEN 0 THEN 'δ��' ELSE 'δ֪' END) AS �Ƿ�ҩ ";
                            sSql = sSql + " FROM ZY_APPLY_DRUG A INNER JOIN ZY_FEE_SPECI B ON A.APPLY_ID = B.APPLY_ID ";
                            sSql = String.Format("{0} WHERE B.FY_BIT = 0 AND B.CZ_FLAG != 2 AND CAST ( DBO.FUN_GETDATE(A.APPLY_DATE)As datetime) = cast('{1}' as datetime) ", sSql, arrList[4].ToString());
                            sSql = String.Format("{0} AND DEPT_ID = {1} ", sSql, Convert.ToInt32(arrList[5]));
                            sSql = sSql + " GROUP BY B.ITEM_NAME,B.UNIT,RETAIL_PRICE,DOC_ID,CHARGE_USER,DBO.FUN_GETDATE(CHARGE_DATE),A.EXECDEPT_ID,FY_BIT ";

                        }
                        else if ((bool)arrList[1] == true && (bool)arrList[3] == true) //δ��ҩ ��ҩ
                        {

                            sSql = sSql + " SELECT RTRIM(B.ITEM_NAME) AS ҩƷ����,RTRIM(UNIT) AS ��λ,SUM(NUM) AS ����,RETAIL_PRICE AS ����,SUM(ACVALUE) AS ���, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(DOC_ID) AS ��ҩҽ��,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS ������, ";
                            sSql = sSql + " DBO.FUN_GETDATE(CHARGE_DATE) AS ����ʱ��,DBO.FUN_ZY_SEEKDEPTNAME(A.EXECDEPT_ID) AS ִ�п���, ";
                            sSql = sSql + " (CASE FY_BIT WHEN 1 THEN '�ѷ�' WHEN 0 THEN 'δ��' ELSE 'δ֪' END) AS �Ƿ�ҩ ";
                            sSql = sSql + " FROM ZY_APPLY_DRUG A INNER JOIN ZY_FEE_SPECI B ON A.APPLY_ID = B.APPLY_ID ";
                            sSql = String.Format("{0} WHERE B.FY_BIT = 0 AND B.CZ_FLAG = 2 AND CAST ( DBO.FUN_GETDATE(A.APPLY_DATE)As datetime) = cast('{1}' as datetime) ", sSql, arrList[4]);
                            sSql = String.Format("{0} AND DEPT_ID = {1} ", sSql, Convert.ToInt32(arrList[5]));
                            sSql = sSql + " GROUP BY B.ITEM_NAME,B.UNIT,RETAIL_PRICE,DOC_ID,CHARGE_USER,DBO.FUN_GETDATE(CHARGE_DATE),A.EXECDEPT_ID,FY_BIT ";
                        }
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

            daTable = dataBase.GetDataTable(sSql);
            return daTable;
        }
        /// <summary>
        /// ���˷�����Ϣ
        /// </summary>
        /// <param name="arrList">��������</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable PrescManageCancelFeeCreate(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT 0 ���,CAST(0 AS SMALLINT) ѡ,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) ������,ITEM_NAME ��Ŀ����,UNIT ��λ, ";
                        sSql = sSql + " CAST(NUM AS FLOAT) ����,CAST(COST_PRICE AS FLOAT) ����,CAST(SDVALUE AS FLOAT) ���,CHARGE_DATE ����ʱ��, ";
                        sSql = sSql + " BOOK_DATE,DBO.FUN_GETEMPNAME(CHARGE_USER) ����Ա,FY_DATE ��ҩʱ��,DBO.FUN_GETEMPNAME(FY_USER) ��ҩԱ, ";
                        sSql = sSql + " INPATIENT_ID,ID,PRESCRIPTION_ID PRESCID,CZ_FLAG,DEPT_BR,DOSAGE ����,DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS ִ�п���, ";
                        sSql = sSql + " DEPT_ID FROM ZY_FEE_SPECI ";
                        sSql = String.Format("{0} WHERE INPATIENT_ID = '{1}' AND DELETE_BIT = 0 ", sSql, arrList[0]);
                        if ((bool)arrList[1] == true)
                            sSql = sSql + " AND CZ_FLAG = 2 ";
                        if ((bool)arrList[4] == true)
                            sSql = String.Format("{0} AND CHARGE_DATE >= '{1}' AND CHARGE_DATE <= '{2}' AND XMLY = 1 AND CHARGE_BIT = 1 ", sSql, arrList[2], arrList[3]);
                        if ((bool)arrList[5] == true)
                            sSql = String.Format("{0} AND CHARGE_DATE >= '{1}' AND CHARGE_DATE <= '{2}' AND XMLY = 2 AND CHARGE_BIT = 1 ", sSql, arrList[2], arrList[3]);
                        if ((bool)arrList[6] == true)
                        {
                            sSql = "";
                            sSql = sSql + " SELECT 0 ���,CAST(0 AS SMALLINT) ѡ,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) ������,S_YPPM ��Ŀ����,UNIT ��λ, ";
                            sSql = sSql + " CAST(NUM AS FLOAT) ����,CAST(LSJ/UNITRATE AS FLOAT) ����,CAST((LSJ/UNITRATE*NUM*DOSAGE) AS FLOAT) ���,'' ����ʱ��, ";
                            sSql = sSql + " '' ����Ա,BOOK_DATE,'' ��ҩʱ��,'' ��ҩԱ,INPATIENT_ID,0,ID,ID PRESCID,0 CZ_FLAG,DEPT_ID,DOSAGE ����, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS ִ�п���,DEPT_ID FROM ZY_PRESCRIPTION A,YP_YPCJD B ";
                            sSql = String.Format("{0} WHERE A.HDITEM_ID = B.CJID AND INPATIENT_ID = '{1}' AND CHARGE_BIT <> 1 AND XMLY = 1 ", sSql, arrList[0]);
                        }
                        if (arrList[7].ToString() != "" && (bool)arrList[6] == false)
                            sSql = String.Format("{0} AND SDVALUE = {1}", sSql, arrList[7]);
                        sSql = sSql + " ORDER BY PRESC_DATE,ORDER_ID,TYPE ASC ";
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
        /// <summary>
        /// ��ȡ������ϸ
        /// </summary>
        /// <param name="inpatientId">סԺID</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable HccsGetFeeClass(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT B.ITEM_NAME,SUM(ACVALUE) AS ACVALUE FROM ZY_FEE_SPECI AS A ";
                        sSql = sSql + " LEFT JOIN (SELECT * FROM JC_STAT_ITEM) AS B ON A.STATITEM_CODE = B.CODE ";
                        sSql = String.Format("{0} WHERE A.DISCHARGE_BIT = 0 AND A.CHARGE_BIT = 1 AND A.DELETE_BIT = 0 AND A.INPATIENT_ID = '{1}' ", sSql, arrList[0]);
                        sSql = sSql + " GROUP BY B.ITEM_NAME ";
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
        /// <summary>
        /// ���شʵ�
        /// �洢����--SP_ZY_ITEM_SELECT
        /// </summary>
        /// <param name="isJgbm">��������</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable HccsZyItemSelect(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT D_CODE AS ITEMCODE,ITEMNAME,STANDARD,UNIT,PRICE,PY_CODE,WB_CODE,D_CODE, ";
                        sSql = sSql + " EXECDEPTID, EXECDEPT,'' AS SELFRATE ,'' AS INSURETYPE, ITEMID,TCID,BIGITEMCODE,1 AS ZFBL, '' AS S_SCCJ, 1 DWBL, 2 XMLY ";
                        sSql = sSql + " FROM ( ";
                        sSql = sSql + " SELECT 0 ROWNO,B.STD_CODE AS ITEMCODE,B.ITEM_NAME AS ITEMNAME,'' AS STANDARD, B.ITEM_UNIT AS UNIT,1 AS DWBL, ";
                        sSql = sSql + " B.RETAIL_PRICE AS PRICE,B.PY_CODE,B.ITEM_CODE AS D_CODE,B.WB_CODE,  ";
                        sSql = sSql + " CASE WHEN D.EXEC_DEPT_ID>0 THEN D.EXEC_DEPT_ID ELSE B.ZXDD_ID END AS EXECDEPTID, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(CASE WHEN D.EXEC_DEPT_ID>0 THEN D.EXEC_DEPT_ID ELSE B.ZXDD_ID END) AS EXECDEPT,'' AS PROD_AREA, B.ITEM_ID AS ITEMID, ";
                        sSql = sSql + " -1 AS UNIT_ID, B.RETAIL_PRICE AS ITEMPFJ,B.RETAIL_PRICE AS ITEMYHJ, B.STATITEM_CODE AS BIGITEMCODE ,-1 AS TCID,C.CFLX_CODE AS PRESCTYPE,B.JGBM ";
                        sSql = sSql + " FROM JC_HSITEMDICTION AS B ";
                        sSql = sSql + " INNER JOIN JC_STAT_ITEM AS C ON B.STATITEM_CODE=C.CODE ";
                        sSql = sSql + " LEFT JOIN JC_HSITEM_DEPT D ON B.ITEM_ID=D.HSITEM_ID AND D.TCID<=0 ";
                        sSql = String.Format("{0} LEFT JOIN JC_DEPT_PROPERTY E ON D.EXEC_DEPT_ID=E.DEPT_ID AND E.JGBM={1} AND", sSql, Convert.ToInt32(arrList[0]));
                        sSql = String.Format("{0} B.DELETE_BIT=0 AND B.JGBM={1} ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = sSql + " UNION ALL ";
                        sSql = sSql + " SELECT 0 ROWNO,'' AS ITEMCODE,B.ITEM_NAME AS ITEMNAME,'' AS STANDARD,B.ITEM_UNIT AS UNIT,1 AS DWBL,TCPRICE AS PRICE,B.PY_CODE,B.CODE AS D_CODE, ";
                        sSql = sSql + " B.WB_CODE,CASE WHEN D.EXEC_DEPT_ID>0 THEN D.EXEC_DEPT_ID ELSE B.EXEC_DEPT END AS EXECDEPTID, ";
                        sSql = sSql + " DBO.FUN_GETDEPTNAME(CASE WHEN D.EXEC_DEPT_ID>0 THEN D.EXEC_DEPT_ID ELSE B.EXEC_DEPT END) AS EXECDEPT, ";
                        sSql = sSql + " '' AS PROD_AREA,B.ITEM_ID AS ITEMID,-1 AS UNIT_ID,TCPRICE AS ITEMPFJ,TCPRICE AS ITEMYHJ, '0' AS BIGITEMCODE , ";
                        sSql = sSql + " B.ITEM_ID AS TCID,'-1' AS PRESCTYPE,B.JGBM ";
                        sSql = sSql + " FROM ( ";
                        sSql = String.Format("{0} SELECT A.*,PRICE AS TCPRICE FROM JC_TC AS A WHERE JGBM='{1}' ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = sSql + " ) AS B ";
                        sSql = sSql + " LEFT JOIN JC_HSITEM_DEPT D ON B.ITEM_ID=D.HSITEM_ID AND B.ITEM_ID=D.TCID ";
                        sSql = String.Format("{0} LEFT JOIN JC_DEPT_PROPERTY E ON D.EXEC_DEPT_ID=E.DEPT_ID AND E.JGBM={1} ", sSql, Convert.ToInt32(arrList[0]));
                        sSql = sSql + " WHERE B.DELETE_BIT=0 ";
                        sSql = sSql + " ) A ";
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
        /// <summary>
        /// ����ҩƷ
        /// �洢����--SP_ZY_DRUGITEM_SELECT
        /// </summary>
        /// <param name="deptId">����ID</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable HccsZyDrugitemSelect(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT A.STATITEM_CODE AS ITEMID, ";
                        sSql = sSql + " (RTRIM(A.YPPM)+( CASE WHEN A.YPPM=A.YPSPM THEN '' ELSE '('+A.YPSPM+')'  END )+ RTRIM((CASE WHEN A.YPSPMBZ IS NULL THEN '' ELSE A.YPSPMBZ END)))AS ITEMNAME, ";
                        sSql = sSql + " A.YPGG AS STANDARD, DBO.FUN_YP_YPDW(A.ZXDW) AS UNIT, A.LSJ/A.DWBL AS PRICE, ";
                        sSql = sSql + " B.PYM AS PY_CODE , B.WBM AS WB_CODE, A.SHH AS ITEMCODE, A.DEPTID AS EXECDEPTID, ";
                        sSql = sSql + " DBO.FUN_JC_DEPTNAME(A.DEPTID) AS EXECDEPT, A.ZFBL, A.YBLX AS INSURETYPE, ";
                        sSql = sSql + " A.MZYP AS ISMZ, A.DJYP AS ISDJ, A.SYXL AS YP_LIMIT, -1 AS XDCFID, -1 AS TCID, ";
                        sSql = sSql + " A.STATITEM_CODE AS BIGITEMCODE, A.CJID, A.S_SCCJ, A.DWBL, KCL, 1 XMLY ";
                        sSql = sSql + " FROM VI_YF_KCMX A ";
                        sSql = sSql + " INNER JOIN YP_YPBM AS B ON A.GGID = B.GGID ";
                        sSql = String.Format("{0} WHERE BDELETE_KC=0 AND DEPTID = {1} AND KCL>0 ORDER BY B.PYM ", sSql, Convert.ToInt32(arrList[0]));

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
        /// <summary>
        /// IDתNAME
        /// </summary>
        /// <param name="isConvert">����ORҽ��</param>
        /// <param name="deptId">ID</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable HccsIdConvertName(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 1)  //����
                            sSql = String.Format("{0} SELECT DBO.FUN_GETDEPTNAME('{1}') AS ִ�п��� ", sSql, Convertor.IsNull(arrList[1], "0"));
                        else if (Convert.ToInt32(arrList[0]) == 2)  //ҽ��
                            sSql = String.Format("{0} SELECT DBO.FUN_GETEMPNAME('{1}') AS ҽ�� ", sSql, Convertor.IsNull(arrList[1], "0"));
                        else if (Convert.ToInt32(arrList[0]) == 3) //ͳ�ƴ���Ŀ
                            sSql = String.Format("{0}SELECT ITEM_CODE FROM JC_HSITEMDICTION WHERE DELETE_BIT = 0 AND ITEM_ID = '{1}' ", sSql, arrList[1]);
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
        /// <summary>
        /// ��ȡ����
        /// �洢����--SP_ZY_GET_PRESCCOLL_EX
        /// </summary>
        /// <param name="inpatientId">סԺID</param>
        /// <param name="isType">����</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable HccsZyGetPresccoll(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[1]) == 0)  //δ���ʵ���Ŀ
                        {
                            sSql = sSql + " SELECT ID AS PROSECID,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) AS PRESC_NO,CAST(HDITEM_ID AS VARCHAR(50)) AS ITEMCODE, ";
                            sSql = sSql + " (CASE WHEN (SELECT ITEM_NAME FROM JC_HSITEMDICTION WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID AND TCID <= 0 AND JGBM=ZY_PRESCRIPTION.JGBM) IS NULL THEN (SELECT ITEM_NAME FROM JC_TC  WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID AND JGBM=ZY_PRESCRIPTION.JGBM) ELSE (SELECT ITEM_NAME FROM JC_HSITEMDICTION WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID AND JGBM=ZY_PRESCRIPTION.JGBM) END) AS ITEMNAME, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS EXECDEPT,CAST(STANDARD AS VARCHAR(50)) AS STANDARD,CAST(UNIT AS VARCHAR(50)) AS UNIT,  ";
                            sSql = sSql + " CAST(PRICE AS FLOAT)  AS PRICE, CAST(NUM AS VARCHAR(10)) AS NUM,CAST(AGIO AS VARCHAR(50)) AS AGIO, CAST(DOSAGE AS VARCHAR(50)) AS DOSAGE, ";
                            sSql = sSql + " CAST(PRICE*NUM*DOSAGE AS FLOAT) AS [VALUES],DBO.FUN_ZY_SEEKEMPLOYEENAME(PRESC_DOC) AS PREDOC,PRESC_DATE AS PREDATE, HDITEM_ID AS HSITEMID, EXECDEPT_ID AS EXECDEPTID, ";
                            sSql = sSql + " CAST(PRESC_DOC AS VARCHAR(50)) AS PREDOCID,CAST(TCID AS VARCHAR(50)) AS TCID, 'YPHH' AS YPHH, 'LIMIT'  AS LIMIT,CAST(UNITRATE AS VARCHAR(50)) AS UNITRATE, ";
                            sSql = sSql + " STATITEM_CODE  AS BIGITEMCODE,  CAST(CHARGE_BIT AS SMALLINT) AS CHARGE_BIT,XMLY ";
                            sSql = sSql + " FROM ZY_PRESCRIPTION ";
                            sSql = String.Format("{0} WHERE (ORDER_ID=DBO.FUN_GETEMPTYGUID() OR ORDER_ID IS NULL)  AND CHARGE_BIT<>1 AND INPATIENT_ID = '{1}' ", sSql, arrList[0]);
                            sSql = sSql + " AND XMLY=2 ORDER BY PRESC_NO DESC ";
                        }
                        else if (Convert.ToInt32(arrList[1]) == 1)  //δ���ʵ�ҩƷ
                        {

                            sSql = sSql + " SELECT ID AS PROSECID,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) AS PRESC_NO,CAST(HDITEM_ID AS VARCHAR(50)) AS ITEMCODE, ";
                            sSql = sSql + " (SELECT YPPM FROM VI_YP_YPCD WHERE CJID = ZY_PRESCRIPTION.HDITEM_ID) AS ITEMNAME,DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS EXECDEPT, ";
                            sSql = sSql + " CAST(STANDARD AS VARCHAR(50)) AS STANDARD, CAST(UNIT AS VARCHAR(50)) AS UNIT,CAST(PRICE AS FLOAT) AS PRICE,CAST(NUM AS VARCHAR(10)) AS NUM, ";
                            sSql = sSql + " CAST(AGIO AS VARCHAR(50)) AS AGIO,CAST(DOSAGE AS VARCHAR(50)) AS DOSAGE,CAST(PRICE*NUM*DOSAGE AS FLOAT) AS [VALUES], ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(PRESC_DOC) AS PREDOC,PRESC_DATE AS PREDATE,HDITEM_ID AS HSITEMID,EXECDEPT_ID AS EXECDEPTID, ";
                            sSql = sSql + " CAST(PRESC_DOC AS VARCHAR(50)) AS PREDOCID,CAST(TCID AS VARCHAR(50)) AS TCID,SUBCODE AS YPHH,'LIMIT'  AS LIMIT, ";
                            sSql = sSql + " CAST(UNITRATE AS VARCHAR(50)) AS UNITRATE,STATITEM_CODE AS BIGITEMCODE, CAST(CHARGE_BIT AS SMALLINT) AS CHARGE_BIT,XMLY ";
                            sSql = sSql + " FROM ZY_PRESCRIPTION ";
                            sSql = String.Format("{0} WHERE (ORDER_ID=DBO.FUN_GETEMPTYGUID() OR ORDER_ID IS NULL) AND CHARGE_BIT<>1 AND INPATIENT_ID = '{1}' ", sSql, arrList[0]);
                            sSql = sSql + " AND XMLY=1 ORDER BY PRESC_NO DESC ";
                        }
                        else if (Convert.ToInt32(arrList[1]) == 2)  //�Ѽ��ʵ���Ŀ
                        {
                            sSql = sSql + " SELECT ID AS PROSECID,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) AS PRESC_NO,CAST(HDITEM_ID AS VARCHAR(50)) AS ITEMCODE, ";
                            sSql = sSql + " (CASE WHEN (SELECT ITEM_NAME FROM JC_HSITEMDICTION WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID AND TCID <= 0) IS NULL THEN (SELECT ITEM_NAME FROM JC_TC  WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID) ELSE (SELECT ITEM_NAME FROM JC_HSITEMDICTION WHERE ITEM_ID = ZY_PRESCRIPTION.HDITEM_ID) END) AS ITEMNAME, ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS EXECDEPT,CAST(STANDARD AS VARCHAR(50)) AS STANDARD,CAST(UNIT AS VARCHAR(50)) AS UNIT, ";
                            sSql = sSql + " CAST(PRICE AS FLOAT)  AS PRICE, CAST(NUM AS VARCHAR(10)) AS NUM, CAST(AGIO AS VARCHAR(50)) AS AGIO, CAST(DOSAGE AS VARCHAR(50)) AS DOSAGE, ";
                            sSql = sSql + " CAST(PRICE*NUM*DOSAGE AS FLOAT) AS [VALUES],DBO.FUN_ZY_SEEKEMPLOYEENAME(PRESC_DOC) AS PREDOC, ";
                            sSql = sSql + " PRESC_DATE AS PREDATE, HDITEM_ID AS HSITEMID, EXECDEPT_ID AS EXECDEPTID,CAST(PRESC_DOC AS VARCHAR(50)) AS PREDOCID, ";
                            sSql = sSql + " CAST(TCID AS VARCHAR(50)) AS TCID, 'YPHH' AS YPHH, 'LIMIT'  AS LIMIT,CAST(UNITRATE AS VARCHAR(50)) AS UNITRATE,  ";
                            sSql = sSql + " STATITEM_CODE  AS BIGITEMCODE,  CAST(CHARGE_BIT AS SMALLINT) AS CHARGE_BIT,XMLY ";
                            sSql = sSql + " FROM ZY_PRESCRIPTION ";
                            sSql = String.Format("{0} WHERE CHARGE_BIT=1 AND INPATIENT_ID = '{1}' AND XMLY=2 ORDER BY PRESC_NO DESC ", sSql, arrList[0]);
                        }
                        else if (Convert.ToInt32(arrList[1]) == 3)  //�Ѽ��ʵ�ҩƷ
                        {
                            sSql = sSql + " SELECT ID AS PROSECID,CAST(CAST(PRESC_NO AS BIGINT) AS VARCHAR(50)) AS PRESC_NO,CAST(HDITEM_ID AS VARCHAR(50)) AS ITEMCODE, ";
                            sSql = sSql + " (SELECT YPPM FROM VI_YP_YPCD WHERE CJID = ZY_PRESCRIPTION.HDITEM_ID) AS ITEMNAME,DBO.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) AS EXECDEPT, ";
                            sSql = sSql + " CAST(STANDARD AS VARCHAR(50)) AS STANDARD, CAST(UNIT AS VARCHAR(50)) AS UNIT,CAST(PRICE AS FLOAT) AS PRICE,CAST(NUM AS VARCHAR(10)) AS NUM, ";
                            sSql = sSql + " CAST(AGIO AS VARCHAR(50)) AS AGIO,CAST(DOSAGE AS VARCHAR(50)) AS DOSAGE,CAST(PRICE*NUM*DOSAGE AS FLOAT) AS [VALUES], ";
                            sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(PRESC_DOC) AS PREDOC,PRESC_DATE AS PREDATE,HDITEM_ID AS HSITEMID,EXECDEPT_ID AS EXECDEPTID, ";
                            sSql = sSql + " CAST(PRESC_DOC AS VARCHAR(50)) AS PREDOCID,CAST(TCID AS VARCHAR(50)) AS TCID,SUBCODE AS YPHH,'LIMIT'  AS LIMIT, ";
                            sSql = sSql + " CAST(UNITRATE AS VARCHAR(50)) AS UNITRATE,STATITEM_CODE AS BIGITEMCODE, CAST(CHARGE_BIT AS SMALLINT) AS CHARGE_BIT,XMLY ";
                            sSql = sSql + " FROM ZY_PRESCRIPTION ";
                            sSql = String.Format("{0} WHERE CHARGE_BIT=1  AND INPATIENT_ID = '{1}' AND XMLY=1 ", sSql, arrList[0]);
                            sSql = sSql + " ORDER BY PRESC_NO DESC ";
                        }
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
        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="prosecId">����ID</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static void HccsZyPrescriptionDelete(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} DELETE ZY_PRESCRIPTION WHERE ID = '{1}'", sSql, arrList[0]);
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

            dataBase.DoCommand(sSql);
        }
        /// <summary>
        /// ��ʼ��������
        /// </summary>
        /// <param name="dataBase">���ݿ�����</param>
        public static void HccsInitPresNo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " USE TRASEN DBCC CHECKIDENT (ZY_PRESCNO,RESEED,0) DELETE FROM ZY_PRESCNO ";
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
            dataBase.DoCommand(sSql);
        }
        /// <summary>
        /// �������շѴ�����ѯ
        /// Modify by tck 2014-04-27 �����ҽ�����ˣ�����Ƿ�ƥ��ҽ��
        /// </summary>
        /// <param name="isOutpatient">�����</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable HccsChargeHaveBeenQuery(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 0)
                        {
                            //sSql = sSql + " SELECT * FROM ( ";
                            //sSql = sSql + " SELECT '' ���,1 ѡ��,ISNULL(A.FPH,'') ��Ʊ��,A.BLH �����,BRXM ����,BM ����,RTRIM(PM) ��Ŀ����,SPM ��Ʒ��,GG ���, ";
                            //sSql = sSql + " CJ ����, DJ ����, SL ����, RTRIM(DW) ��λ,JS ����,JE ���, ";
                            //sSql = sSql + " (CASE WHEN BPSBZ = -1 THEN '����' WHEN BPSBZ = 0 THEN 'Ƥ��' ELSE '' END) Ƥ��, ";
                            //sSql = sSql + " C.YFMC �÷�,ZT ����,B.KSDM ����,B.YSDM ҽ��,B.ZXKS ִ�п���,TCID �ײ�ID,HJRQ ��������,HJYXM ����Ա,A.SFRQ �շ�����, ";
                            //sSql = sSql + " SFYXM �շ�Ա,FYRQ ��ҩ����,C.XMID ��ĿID,FYRXM ��ҩԱ,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, ";
                            //sSql = sSql + " PXXH,HJMXID,CFMXID,XMLY ��Ŀ��Դ,TJDXMDM ͳ�ƴ���Ŀ,YDWBL,1 CHARGE_BIT ";
                            //sSql = sSql + " FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID ";
                            //sSql = sSql + " INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID ";
                            //sSql = String.Format("{0} WHERE A.BSCBZ = 0 AND A.BLH = '{1}' ", sSql, arrList[1]);
                            //sSql = sSql + " ) A ORDER BY ��Ʊ��,��������,PXXH,CFMXID ";
                            sSql = @" SELECT * FROM ( 
                              SELECT '' ���,1 ѡ��,ISNULL(A.FPH,'') ��Ʊ��,A.BLH �����,BRXM ����,BM ����,RTRIM(PM) ��Ŀ����,SPM ��Ʒ��,GG ���,CJ ����,DJ ����
                              ,SL+(SELECT ISNULL(SUM(SL),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ����, RTRIM(DW) ��λ
                              ,JS+(SELECT ISNULL(SUM(JS),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ����
                              ,JE+(SELECT ISNULL(SUM(JE),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ���,
                             (CASE WHEN BPSBZ = -1 THEN '����' WHEN BPSBZ = 0 THEN 'Ƥ��' ELSE '' END) Ƥ��, 
                              C.YFMC �÷�,ZT ����,B.KSDM ����,B.YSDM ҽ��,B.ZXKS ִ�п���,TCID �ײ�ID,HJRQ ��������,HJYXM ����Ա,A.SFRQ �շ�����,
                              SFYXM �շ�Ա,FYRQ ��ҩ����,C.XMID ��ĿID,FYRXM ��ҩԱ,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID,
                              PXXH,HJMXID,CFMXID,XMLY ��Ŀ��Դ,TJDXMDM ͳ�ƴ���Ŀ,YDWBL,1 CHARGE_BIT
                              FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID
                                INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID ";
                            sSql = String.Format("{0} WHERE A.BSCBZ = 0 AND TYID IS NULL AND A.BLH = '{1}' ", sSql, arrList[1]);
                            sSql = sSql + " ) A WHERE ���>0 ORDER BY ��Ʊ��,��������,PXXH,CFMXID ";
                        }
                        else if (Convert.ToInt32(arrList[0]) == 1)
                        {
//                            sSql = @"SELECT * FROM (SELECT '' ���,1 ѡ��,ISNULL(A.FPH,'') ��Ʊ��,A.BLH �����,BRXM ����,BM ����,RTRIM(PM) ��Ŀ����
//                                    ,SPM ��Ʒ��,GG ���,CJ ����, DJ ����, SL ����, RTRIM(DW) ��λ,JS ����,JE ���, 
//                                    (CASE WHEN BPSBZ = -1 THEN '����' WHEN BPSBZ = 0 THEN 'Ƥ��' ELSE '' END) Ƥ��, 
//                                    C.YFMC �÷�,ZT ����,B.KSDM ����,B.YSDM ҽ��,B.ZXKS ִ�п���,TCID �ײ�ID,HJRQ ��������,HJYXM ����Ա,A.SFRQ �շ�����,
//                                    SFYXM �շ�Ա,FYRQ ��ҩ����,C.XMID ��ĿID,FYRXM ��ҩԱ,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, 
//                                    PXXH,HJMXID,CFMXID,b.XMLY ��Ŀ��Դ,TJDXMDM ͳ�ƴ���Ŀ,C.YDWBL,
//                                    CASE WHEN(D.XMID IS NULL) THEN 0 
//                                    ELSE 1 END CHARGE_BIT,b.XMLY
//                                    FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID 
//                                    INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID LEFT JOIN JC_YB_BL D ON C.XMID=D.XMID and B.XMLY=D.XMLY AND D.YBLX='" + arrList[2] + @"'
//                                    WHERE B.XMLY=2 AND A.BSCBZ = 0 AND A.BLH = '" + arrList[1] + @"'
//                                    UNION ALL
//                                    SELECT '' ���,1 ѡ��,ISNULL(A.FPH,'') ��Ʊ��,A.BLH �����,BRXM ����,BM ����,RTRIM(PM) ��Ŀ����
//                                    ,SPM ��Ʒ��,GG ���,CJ ����, DJ ����, SL ����, RTRIM(DW) ��λ,JS ����,JE ���, 
//                                    (CASE WHEN BPSBZ = -1 THEN '����' WHEN BPSBZ = 0 THEN 'Ƥ��' ELSE '' END) Ƥ��, 
//                                    C.YFMC �÷�,ZT ����,B.KSDM ����,B.YSDM ҽ��,B.ZXKS ִ�п���,TCID �ײ�ID,HJRQ ��������,HJYXM ����Ա,A.SFRQ �շ�����,
//                                    SFYXM �շ�Ա,FYRQ ��ҩ����,C.XMID ��ĿID,FYRXM ��ҩԱ,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, 
//                                    PXXH,HJMXID,CFMXID,b.XMLY ��Ŀ��Դ,TJDXMDM ͳ�ƴ���Ŀ,C.YDWBL,
//                                    CASE WHEN(D.XMID IS NULL) THEN 0 
//                                    ELSE 1 END CHARGE_BIT,b.XMLY
//                                    FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID 
//                                    INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID  
//                                    LEFT JOIN yp_ypcjd YP ON C.XMID=YP.CJID AND B.XMLY=1
//                                    LEFT JOIN JC_YB_BL D ON YP.GGID=D.XMID and B.XMLY=D.XMLY AND D.YBLX='" + arrList[2] + @"'
//                                    WHERE B.XMLY=1 AND A.BSCBZ = 0 AND A.BLH = '" + arrList[1] + @"'
//                                    ) A ORDER BY ��Ʊ��,��������,PXXH,CFMXID";
                            sSql = @"SELECT * FROM (SELECT '' ���,1 ѡ��,ISNULL(A.FPH,'') ��Ʊ��,A.BLH �����,BRXM ����,BM ����,RTRIM(PM) ��Ŀ����
                                        ,SPM ��Ʒ��,GG ���,CJ ����,DJ ����
                                        ,SL+(SELECT ISNULL(SUM(SL),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ����, RTRIM(DW) ��λ
                                        ,JS+(SELECT ISNULL(SUM(JS),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ����
                                        ,JE+(SELECT ISNULL(SUM(JE),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ���, 
                                        (CASE WHEN BPSBZ = -1 THEN '����' WHEN BPSBZ = 0 THEN 'Ƥ��' ELSE '' END) Ƥ��, 
                                        C.YFMC �÷�,ZT ����,B.KSDM ����,B.YSDM ҽ��,B.ZXKS ִ�п���,TCID �ײ�ID,HJRQ ��������,HJYXM ����Ա,A.SFRQ �շ�����,
                                        SFYXM �շ�Ա,FYRQ ��ҩ����,C.XMID ��ĿID,FYRXM ��ҩԱ,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, 
                                        PXXH,HJMXID,CFMXID,b.XMLY ��Ŀ��Դ,TJDXMDM ͳ�ƴ���Ŀ,C.YDWBL,
                                        CASE WHEN(D.XMID IS NULL) THEN 0 
                                        ELSE 1 END CHARGE_BIT,b.XMLY
                                            FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID 
                                              INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID LEFT JOIN JC_YB_BL D ON C.XMID=D.XMID and B.XMLY=D.XMLY AND D.YBLX='" + arrList[2] + @"'
                                                WHERE B.XMLY=2 AND A.BSCBZ = 0 AND A.BLH = '" + arrList[1] + @"'
                                    UNION ALL
                                    SELECT '' ���,1 ѡ��,ISNULL(A.FPH,'') ��Ʊ��,A.BLH �����,BRXM ����,BM ����,RTRIM(PM) ��Ŀ����
                                        ,SPM ��Ʒ��,GG ���,CJ ���� ,DJ ����
                                        ,SL+(SELECT ISNULL(SUM(SL),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ����, RTRIM(DW) ��λ
                                        ,JS+(SELECT ISNULL(SUM(JS),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ����
                                        ,JE+(SELECT ISNULL(SUM(JE),0) FROM MZ_CFB_MX H WHERE H.TYID=C.CFMXID) ���,
                                        (CASE WHEN BPSBZ = -1 THEN '����' WHEN BPSBZ = 0 THEN 'Ƥ��' ELSE '' END) Ƥ��, 
                                        C.YFMC �÷�,ZT ����,B.KSDM ����,B.YSDM ҽ��,B.ZXKS ִ�п���,TCID �ײ�ID,HJRQ ��������,HJYXM ����Ա,A.SFRQ �շ�����,
                                        SFYXM �շ�Ա,FYRQ ��ҩ����,C.XMID ��ĿID,FYRXM ��ҩԱ,ISNULL(CAST(HJID AS VARCHAR(50)),'0') CFID, 
                                        PXXH,HJMXID,CFMXID,b.XMLY ��Ŀ��Դ,TJDXMDM ͳ�ƴ���Ŀ,C.YDWBL,
                                        CASE WHEN(D.XMID IS NULL) THEN 0 
                                        ELSE 1 END CHARGE_BIT,b.XMLY
                                           FROM MZ_FPB A INNER JOIN MZ_CFB B ON A.FPID = B.FPID 
                                              INNER JOIN MZ_CFB_MX C ON B.CFID = C.CFID  
                                                 LEFT JOIN yp_ypcjd YP ON C.XMID=YP.CJID AND B.XMLY=1
                                                    LEFT JOIN JC_YB_BL D ON YP.GGID=D.XMID and B.XMLY=D.XMLY AND D.YBLX='" + arrList[2] + @"'
                                                       WHERE B.XMLY=1 AND A.BSCBZ = 0 AND A.BLH = '" + arrList[1] + @"'
                                                         ) A WHERE ���>0 ORDER BY ��Ʊ��,��������,PXXH,CFMXID";
                        }
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

        /// <summary>
        /// �Ƿ�ҽ��ƥ��
        /// ADD BY TCK 2014-04-27
        /// </summary>
        /// <param name="arrList"></param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static bool IsYbHccsChargeHaveBeenQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (arrList[0].ToString() == "1")
                        {
                            sSql = String.Format("select HSBM from JC_YB_BL WHERE XMLY={0} AND YBLX={1} AND XMID=(SELECT TOP 1 GGID FROM yp_ypcjd WHERE CJID='{2}') ", arrList[0], arrList[1], arrList[2]);
                        }
                        else
                        {
                            sSql = String.Format("select HSBM from JC_YB_BL WHERE XMLY={0} AND YBLX={1} AND XMID={2}", arrList[0], arrList[1], arrList[2]);
                        }
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
            if (daTable.Rows.Count > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// ���벡�˲�ѯ
        /// </summary>
        /// <param name="applyTime">��������</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable ApplyThePatientQuery(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT B.INPATIENT_NO AS סԺ��,B.NAME ����,DBO.FUN_ZY_SEEKDEPTNAME(B.DEPT_ID) AS ���ڿ���,A.YSSS AS ��������, ";
                        sSql = sSql + " DBO.FUN_GETDATE(YSSSRQ) AS �������� FROM SS_APPRECORD A INNER JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                        sSql = String.Format("{0} WHERE DBO.FUN_GETDATE(YSSSRQ) = '{1}'", sSql, arrList[0]);
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
        /// <summary>
        /// �����������ű�־
        /// </summary>
        /// <param name="inpatientId">סԺID</param>
        /// <param name="dataBase">���ݿ�����</param>
        public static void OaacUpdateOperationMarks(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE SS APPRECORD SET APBJ = 1 WHERE INPATIENT_ID = '{1}'", sSql, arrList[0]);
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
            dataBase.DoCommand(sSql);
        }
        /// <summary>
        /// ���شʵ�
        /// </summary>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable OaacLoadItemDiction(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT D_CODE AS ITEMCODE,ITEMNAME,STANDARD,UNIT,PRICE,PY_CODE,WB_CODE,D_CODE, EXECDEPTID, EXECDEPT,'' AS SELFRATE ,'' AS INSURETYPE, ITEMID,TCID,BIGITEMCODE, 1 AS ZFBL, '' AS S_SCCJ, 1 DWBL FROM  VI_JC_ITEMS ";
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
    }
}
