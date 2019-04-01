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
 * ���ƣ�סԺԤ�������ݿ������
 * ������������סԺԤ�����е����ݿ����
 * ��дʱ�䣺2013-10
 * ���ߣ�Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class AdvancePaymentDataBaseAccessClass
    {
        public static string ApGetDeposits(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        string sort = " ASC";
                        if (Convert.ToString(arrList[1]) == "1")
                            sort = " DESC";

                        sSql = sSql + @" SELECT ID,INPATIENT_ID,NTRANS,CASE NTRANS WHEN 10 THEN 'Ԥ��' WHEN 20 THEN '�˿�' ELSE 'δ֪' END AS OPERATORNTRANS,NVALUES,FEESOURCE, ";
                        sSql = sSql + " NMODE,DBO.FUN_ZY_GETFKFSNAME(NMODE) AS OPERATORNMODE,BILLNO,BOOK_DATE,DBO.FUN_ZY_SEEKEMPLOYEENAME(BOOK_USERID) AS BOOK_USER, ";
                        sSql = sSql + " BOOK_USERID,ARRIVE_BIT,ARRIVE_DATE,ARRIVE_USERID,SUNIT,CHECKNO,SBANK,DISCHARGE_BIT,DISCHARGE_ID,TURN_BIT,CANCEL_BIT,CANCEL_USERID, ";
                        sSql = sSql + " CANCEL_DATE,GATHERING_BIT,GATHERINGTURN_ID,CZ_FLAG,JGBM ";
                        sSql = sSql + " FROM ZY_DEPOSITS ";
                        sSql = String.Format("{0} WHERE DISCHARGE_BIT = 0 AND INPATIENT_ID = '{1}' ORDER BY BOOK_DATE {2} ", sSql, arrList[0], sort);
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
            //dataBase.AdapterFillDataSet(sSql, daSet, "depositsTable", 30);
            return sSql;
        }
        public static DataTable ApGetAllDeposits(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format(@"{0} SELECT 0 AS SEL,CANCEL_BIT AS NSTATUS,BILLNO,NVALUES,INPATIENT_NO = (SELECT TOP 1 INPATIENT_NO FROM VI_ZY_VINPATIENT_ALL WHERE INPATIENT_ID = ZY_DEPOSITS.INPATIENT_ID),PATITENNAME = (SELECT TOP 1 NAME FROM VI_ZY_VINPATIENT_ALL WHERE INPATIENT_ID = ZY_DEPOSITS.INPATIENT_ID) FROM ZY_DEPOSITS WHERE BOOK_USERID = {1} ", sSql, Convert.ToString(arrList[0]));
                            sSql = String.Format("{0} AND ARRIVE_DATE >= '{1}' AND ARRIVE_DATE <= '{2}' AND NTRANS = {3} ", sSql, arrList[1], arrList[2], Convert.ToInt32(arrList[3]));
                            sSql = sSql + " AND CZ_FLAG = 0 ORDER BY BILLNO ASC ";
                        }
                        else if (i == 2)
                        {
                            sSql = String.Format(@"{0} SELECT 0 AS SEL,CANCEL_BIT AS NSTATUS,BILLNO,NVALUES,INPATIENT_NO = (SELECT TOP 1 INPATIENT_NO FROM VI_ZY_VINPATIENT_ALL WHERE INPATIENT_ID = ZY_DEPOSITS.INPATIENT_ID),PATITENNAME = (SELECT TOP 1 NAME FROM VI_ZY_VINPATIENT_ALL WHERE INPATIENT_ID = ZY_DEPOSITS.INPATIENT_ID) FROM ZY_DEPOSITS WHERE BOOK_USERID = {1} ", sSql, Convert.ToInt32(arrList[0]));
                            sSql = String.Format("{0} AND BILLNO = {1} AND NTRANS = {2} AND CZ_FLAG = 0 ORDER BY BILLNO ASC ", sSql, Convert.ToInt32(arrList[1]), Convert.ToInt32(arrList[2]));
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
        public static string ApGetMedicalTypeName(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT YBLX_NAME FROM VI_ZY_VINPATIENT_ALL WHERE BABY_ID = 0 AND INPATIENT_ID = '{1}' ", sSql, arrList[0]);
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
            String isResult = dataBase.GetDataResult(sSql).ToString();
            return isResult;
        }
        public static string ApGetVouchFee(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT DBJE FROM ZY_INPATIENT WHERE INPATIENT_ID = '{1}' ", sSql, arrList[0]);
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
            string vouchFee = dataBase.GetDataRow(sSql)["DBJE"].ToString();
            return vouchFee;
        }
        public static void ApArriveDateModify(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format("{0} UPDATE ZY_DEPOSITS SET ARRIVE_DATE = GETDATE() + 1 WHERE ID = '{1}' ", sSql, arrList[0]);
                        }
                        else if (i == 2)
                        {
                            sSql = String.Format("{0} UPDATE ZY_DEPOSITS SET ARRIVE_DATE = GETDATE() WHERE ID = '{1}' ", sSql, arrList[0]);
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
            dataBase.DoCommand(sSql);
        }
        public static string ApModifyDepositsMode(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_DEPOSITS SET NMODE = {1} WHERE ID = {2}", sSql, arrList[0], arrList[1]);
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
            return sSql;
        }
        public static void ApModifyDepositsModeVoid(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} UPDATE ZY_DEPOSITS SET NMODE = {1} WHERE ID = '{2}' ", sSql, arrList[0], arrList[1]);
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
        public static string ApArriveDateModifyStr(int i, ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (i == 1)
                        {
                            sSql = String.Format("{0} UPDATE ZY_DEPOSITS SET ARRIVE_DATE = TIMESTAMP(CURRENT DATE + 1 DAYS,TIME(ARRIVE_DATE)) WHERE ID = {1}", sSql, arrList[0]);
                        }
                        else if (i == 2)
                        {
                            sSql = String.Format("{0} UPDATE ZY_DEPOSITS SET ARRIVE_DATE = TIMESTAMP(CURRENT DATE,TIME(ARRIVE_DATE)) WHERE ID = {1}", sSql, arrList[0]);
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
            return sSql;
        }
        public static DataTable ApGetDepositsListQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT CASE WHEN NTRANS = 10 THEN 'Ԥ��' WHEN NTRANS = 20 THEN '�˿�' ELSE 'δ֪' END AS ����, ";
                        sSql = sSql + " DBO.FUN_ZY_GETFKFSNAME(NMODE) ��ʽ,NVALUES AS ���,BILLNO AS Ʊ�ݺ�,ARRIVE_DATE AS ����ʱ��, ";
                        sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(ARRIVE_USERID) AS ����Ա FROM ZY_DEPOSITS ";
                        sSql = String.Format("{0} WHERE CZ_FLAG = 0 AND CANCEL_BIT = 0 AND NTRANS IN (10,20) AND INPATIENT_ID = '{1}' ", sSql, arrList[0]);
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
        public static DataTable ApGetVouchListQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT DBO.FUN_ZY_SEEKEMPLOYEENAME(OPERATEUSER) AS ����Ա,VOUCHVALUE AS ���,OPERATEDATE AS ����ʱ�� FROM ZY_VOUCH ";
                        sSql = sSql + " WHERE INPATIENT_ID = '" + arrList[0] + "' ";
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
        public static DataTable ApStatDeptPayment(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[3]) == -1)
                        {
                            sSql = sSql + " SELECT B.INPATIENT_NO AS סԺ��,B.NAME AS ����,DBO.FUN_GETDEPTNAME(B.DEPT_ID) ����,DBO.FUN_ZY_GETBEDNO(BED_ID) ����, ";
                            sSql = sSql + " CASE WHEN NTRANS = 10 THEN 'Ԥ��' WHEN NTRANS = 20 THEN '�˿�' ELSE 'δ֪' END AS ����,";
                            sSql = sSql + " NVALUES AS ���,BILLNO AS Ʊ�ݺ�,ARRIVE_DATE AS ����ʱ��,DBO.FUN_ZY_SEEKEMPLOYEENAME(ARRIVE_USERID) AS ����Ա ";
                            sSql = sSql + " FROM ZY_DEPOSITS A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                            sSql = String.Format("{0} WHERE NTRANS IN (10,20) AND A.CANCEL_BIT = 0 AND A.ARRIVE_DATE >= '{1}' AND A.ARRIVE_DATE <= '{2}' ORDER BY B.DEPT_ID ASC ", sSql, arrList[0], arrList[1]);
                        }
                        else
                        {
                            sSql = sSql + " SELECT B.INPATIENT_NO AS סԺ��,B.NAME AS ����,DBO.FUN_GETDEPTNAME(B.DEPT_ID) ����,DBO.FUN_ZY_GETBEDNO(BED_ID) ����, ";
                            sSql = sSql + " CASE WHEN NTRANS = 10 THEN 'Ԥ��' WHEN NTRANS = 20 THEN '�˿�' ELSE 'δ֪' END AS ����,";
                            sSql = sSql + " NVALUES AS ���,BILLNO AS Ʊ�ݺ�,ARRIVE_DATE AS ����ʱ��,DBO.FUN_ZY_SEEKEMPLOYEENAME(ARRIVE_USERID) AS ����Ա ";
                            sSql = sSql + " FROM ZY_DEPOSITS A LEFT JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID ";
                            sSql = String.Format("{0} WHERE NTRANS IN (10,20) AND A.CANCEL_BIT = 0 AND B.DEPT_ID = {1} AND A.ARRIVE_DATE >= '{2}' AND A.ARRIVE_DATE <= '{3}' ORDER BY B.DEPT_ID ASC ", sSql, Convert.ToInt32(arrList[2]), arrList[0], arrList[1]);
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
        public static DataTable ApLoadVouchHistoryInfo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT VOUCHUNIT ������λ,VOUCHPERSON AS ������,VOUCHVALUE �������,OPERATEDATE �Ǽ�ʱ��,DBO.FUN_ZY_SEEKEMPLOYEENAME(OPERATEUSER) AS ����Ա ";
                        sSql = String.Format("{0} FROM ZY_VOUCH WHERE INPATIENT_ID = '{1}' ", sSql, arrList[0]);
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
        public static int ApVouchListAdd(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " INSERT INTO ZY_VOUCH(ID,INPATIENT_ID,VOUCHUNIT,VOUCHPERSON,VOUCHVALUE,OPERATEDATE,OPERATEUSER,JGBM) VALUES ";
                        sSql = String.Format("{0} ('{1}','{2}','{3}','{4}','{5}',GETDATE(),{6},{7}) ", sSql, arrList[0], arrList[1], arrList[2], arrList[3], arrList[4], Convert.ToInt32(arrList[5]), Convert.ToInt32(arrList[6]));
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
            int i = dataBase.DoCommand(sSql);
            return i;
        }
        public static void ApInpatientVouchModify(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " UPDATE ZY_INPATIENT SET DBJE = DBJE + " + arrList[0] + " WHERE INPATIENT_ID = '" + arrList[1] + "' ";
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
        public static string ApGetVouchName(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT NAME FROM JC_EMPLOYEE_PROPERTY WHERE EMPLOYEE_ID = {1} ", sSql, arrList[0]);
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
            string employeeName = Convertor.IsNull(dataBase.GetDataResult(sSql), "");
            return employeeName;
        }
        public static DataTable ApDateTimeVouchStat(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT 0 AS ���,B.NAME ��������,INPATIENT_NO סԺ��,DBO.FUN_GETDEPTNAME(B.DEPT_ID) סԺ����,A.OPERATEDATE AS ����,A.VOUCHPERSON AS ������, ";
                        sSql = sSql + " A.VOUCHVALUE AS �������,A.VOUCHUNIT AS ������λ,DBO.FUN_ZY_SEEKEMPLOYEENAME(OPERATEUSER) AS ������ ";
                        sSql = sSql + " FROM ZY_VOUCH A INNER JOIN VI_ZY_VINPATIENT B ON A.INPATIENT_ID = B.INPATIENT_ID WHERE 1 = 1 ";
                        if (Convert.ToInt32(arrList[0]) != 0)
                        {
                            if ((bool)arrList[1] == true)
                            {
                                sSql = String.Format("{0} AND A.INPATIENT_ID = '{1}' ", sSql, arrList[2]);
                            }
                            else if ((bool)arrList[3] == true)
                            {
                                sSql = String.Format("{0} AND A.INPATIENT_ID IN (SELECT TOP 1 INPATIENT_ID FROM ZY_INPATIENT WHERE INPATIENT_NO = '{1}' ORDER BY INTIMES DESC)", sSql, arrList[4]);
                            }
                        }
                        if ((bool)arrList[5] == true)
                        {
                            sSql = String.Format("{0} AND B.IN_DATE > '{1}' AND B.IN_DATE<= '{2}' ", sSql, arrList[6], arrList[7]);
                        }
                        else
                        {
                            sSql = String.Format("{0} AND B.OUT_DATE > '{1}' AND B.OUT_DATE <= '{2}' ", sSql, arrList[6], arrList[7]);
                        }
                        if ((bool)arrList[1] == true)
                        {
                            sSql = sSql + " AND FLAG < 6 AND FLAG <> 2 ";
                        }
                        else
                        {
                            sSql = sSql + " AND (FLAG >= 6 OR FLAG = 2) ";
                        }
                        sSql = sSql + " ORDER BY A.OPERATEDATE ASC ";
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
        public static DataTable ApVouchStatAll(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if ((bool)arrList[0] == true)
                        {
                            sSql = sSql + " SELECT 0 AS ���,A.NAME AS ����,A.INPATIENT_NO AS סԺ��,DBO.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS סԺ����,A.IN_DATE AS ��Ժʱ��, ";
                            sSql = String.Format("{0} A.OUT_DATE AS ��Ժʱ��,WARRANTAMOUNT AS �������,��ǰ�������� = (SELECT SUM(ACVALUE) FROM ZY_FEE_SPECI B WHERE B.INPATIENT_ID = A.INPATIENT_ID AND B.DELETE_BIT = 0 AND B.CHARGE_BIT = 1 AND B.CHARGE_DATE <= '{1} 23:59:59'),Ƿ�� = ((SELECT SUM(ACVALUE) FROM ZY_FEE_SPECI B WHERE B.INPATIENT_ID = A.INPATIENT_ID AND B.DELETE_BIT = 0 AND B.CHARGE_BIT = 1 AND B.CHARGE_DATE <= '{1} 23:59:59') - (SELECT SUM(NVALUES) FROM ZY_DEPOSITS C WHERE C.INPATIENT_ID = A.INPATIENT_ID AND C.CANCEL_BIT = 0 AND C.DISCHARGE_BIT = 0 AND C.BOOK_DATE <= '{1} 23:59:59')),NULL AS ��Ʊ�� ", sSql, arrList[1]);
                            sSql = sSql + " FROM VI_ZY_VINPATIENT A WHERE FLAG < 6 AND FLAG <> 2 ";

                            if ((bool)arrList[2] == true)
                            {
                                sSql = String.Format("{0} AND A.IN_DATE > '{1} 00:00:00' AND A.IN_DATE <= '{2} 23:59:59' ", sSql, arrList[3], arrList[4]);
                            }
                            else
                            {
                                sSql = String.Format("{0} AND A.OUT_DATE > '{1} 00:00:00' AND A.OUT_DATE <= '{2} 23:59:59' ", sSql, arrList[3], arrList[4]);
                            }
                            sSql = sSql + " AND WARRANTAMOUNT > 0 GROUP BY INPATIENT_ID,NAME,INPATIENT_NO,A.DEPT_ID,IN_DATE,OUT_DATE,WARRANTAMOUNT ";
                        }
                        else
                        {
                            sSql = sSql + " SELECT 0 AS ���,A.NAME AS ����,A.INPATIENT_NO AS סԺ��,DBO.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS סԺ����, ";
                            sSql = sSql + " A.IN_DATE AS ��Ժʱ��,A.OUT_DATE AS ��Ժʱ��,WARRANTAMOUNT AS �������,NFEE AS �ܷ���, ";
                            sSql = sSql + " SUM(B.SELF_FEE - B.DEPTOSITS - B.PATCH_FEE) AS Ƿ��,BILLNO AS ��Ʊ�� ";
                            sSql = sSql + " FROM VI_ZY_VINPATIENT A LEFT JOIN ZY_DISCHARGE B ON A.INPATIENT_ID = B.INPATIENT_ID WHERE (FLAG >= 6 OR FLAG = 2) ";

                            if ((bool)arrList[2] == true)
                            {
                                sSql = String.Format("{0} AND A.IN_DATE > '{1} 00:00:00' AND A.IN_DATE <= '{2} 23:59:59' ", sSql, arrList[3], arrList[4]);
                            }
                            else
                            {
                                sSql = String.Format("{0} AND A.OUT_DATE > '{1} 00:00:00' AND A.OUT_DATE <= '{2} 23:59:59' ", sSql, arrList[3], arrList[4]);
                            }
                            sSql = sSql + " AND WARRANTAMOUNT > 0 GROUP BY NAME,INPATIENT_NO,A.DEPT_ID,IN_DATE,OUT_DATE,BILLNO,WARRANTAMOUNT,NFEE ";
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
        public static DataTable ApGetVouchNameFuzzy(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT NAME AS NAME,EMPLOYEE_ID  AS ID,PY_CODE,WB_CODE FROM JC_EMPLOYEE_PROPERTY WHERE 1 = 1 AND (PY_CODE LIKE '{1}%' OR WB_CODE LIKE '%{1}%') ORDER BY LEN(PY_CODE) ", sSql, arrList[0]);
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
        public static DataTable ApGetCardNoAndCardType(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT * FROM YY_KDJB WHERE SDBZ = 0 AND ZFBZ = 0 AND BRXXID IN (SELECT PATIENT_ID FROM ZY_INPATIENT WHERE INPATIENT_ID = '{1}') ORDER BY KLX ", sSql, arrList[0]);
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
        public static DataTable ApGetCardNoAndCardTypeSimple(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0} SELECT * FROM YY_KDJB WHERE SDBZ = 0 AND ZFBZ = 0 AND KH = '{1}' AND KLX = {2} ORDER BY KLX ", sSql, arrList[0], Convert.ToInt32(arrList[1]));                       
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
