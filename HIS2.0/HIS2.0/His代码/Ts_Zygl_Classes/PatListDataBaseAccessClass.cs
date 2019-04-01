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
 * ���ƣ������嵥���ݿ������
 * �����������ڲ����嵥�е����ݿ����
 * ��дʱ�䣺2013-10
 * ���ߣ�Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class PatListDataBaseAccessClass
    {
        /// <summary>
        /// ��Ժ�����嵥������ӡ--ͨ��סԺ�Ų�ѯ���˻�����Ϣ
        /// </summary>
        /// <param name="inpatientNo">סԺ��</param>
        /// <returns></returns>
        public static DataTable ZyPatientHospitalInfoQueryInventory(ArrayList arrList, RelationalDatabase dataBase)  
        {
            string sSql = "";
            //RelationalDatabase dataBase = null;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT DISTINCT CAST(0 AS SMALLINT) AS SELECTED,A.INPATIENT_NO,A.NAME,DBO.FUN_ZY_SEEKSEXNAME(CAST(A.SEXCODE AS CHAR(4))) AS SEX,";
                        sSql = sSql + " DBO.FUN_ZY_AGE(CAST(A.BIRTHDAY AS DATETIME),CAST(4 AS SMALLINT),GETDATE()) AS AGE,";
                        sSql = sSql + " A.DEPT_ID,DBO.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS DEPTNAME,";
                        sSql = sSql + " (CASE WHEN A.DISCHARGETYPE=0 THEN '�Է�' WHEN A.DISCHARGETYPE=1 THEN 'ҽ��' WHEN A.DISCHARGETYPE=2 THEN '����' ELSE '����' END) AS DISCHARGETYPE,";
                        sSql = sSql + " A.INPATIENT_ID,BED_ID,0 AS NSTATUS,0 AS DISCHARGE_BIT,DOB.FUN_GETDATE(A.IN_DATE) AS IN_DATE,A.OUT_DATE,DBO.FUN_GETEMPTYGUID() AS DISCHARGE_ID";
                        sSql = String.Format("{0} FROM (SELECT * FROM VI_ZY_VINPATIENT WHERE CANCEL_BIT<>1 AND FLAG=1 AND INPATIENT_NO = '{1}') A", sSql, arrList[0]);
                        sSql = sSql + " ORDER BY A.INPATIENT_NO";
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
        /// ��Ժ�����嵥������ӡ--ͳ��
        /// </summary>
        /// <returns></returns>
        public static DataTable ZyPatientHospitalStatInventory(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            //RelationalDatabase dataBase = null;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT DISTINCT CAST(0 AS SMALLINT) AS SELECTED,A.INPATIENT_NO,A.NAME,DBO.FUN_ZY_SEEKSEXNAME(CAST(A.SEXCODE AS CHAR(4))) AS SEX,";
                        sSql = sSql + " DBO.FUN_ZY_AGE(CAST(A.BIRTHDAY AS DATETIME),CAST(4 AS SMALLINT),GETDATE()) AS AGE,A.DEPT_ID,DBO.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS DEPTNAME,";
                        sSql = sSql + " (CASE WHEN A.DISCHARGETYPE=0 THEN '�Է�' WHEN A.DISCHARGETYPE=1 THEN 'ҽ��' WHEN A.DISCHARGETYPE=2 THEN '����' ELSE '����' END) AS DISCHARGETYPE,";
                        sSql = sSql + " A.INPATIENT_ID,BED_ID,0 AS NSTATUS,0 AS DISCHARGE_BIT,DBO.FUN_GETDATE(A.IN_DATE) AS IN_DATE,A.OUT_DATE,DBO.FUN_GETEMPTYGUID() AS DISCHARGE_ID";
                        sSql = sSql + " FROM (SELECT * FROM VI_ZY_VINPATIENT WHERE CANCEL_BIT<>1 AND FLAG < 6 AND FLAG != 2) A";
                        sSql = sSql + " ORDER BY A.INPATIENT_NO";
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
        /// ��Ժ�����嵥������ӡ--��ȡ�����ܷ���
        /// </summary>
        /// <param name="inpatientId">סԺID</param>
        /// <returns></returns>
        public static Decimal ZyPatientHospitalDischargeFeeInventory(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            //RelationalDatabase dataBase = null;
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format(" SELECT SUM(NFEE) AS NFEE FROM ZY_DISCHARGE WHERE CANCEL_BIT = 0 AND INPATIENT_ID = '{0}'", arrList[0]);
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
            decimal nFee = Convert.ToDecimal(Convertor.IsNull(dataBase.GetDataResult(sSql), "0"));
            return nFee;
        }
        /// <summary>
        /// ��Ժ�����嵥������ӡ--ˮ�������ӡ
        /// �洢����--SP_ZY_STAT_AllPATIENTFEE
        /// </summary>
        /// <returns></returns>
        public static String ZyPatientHospitalRptPrint(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[5]) == 0)   //��ʾҩƷ(��ǰ��)
                        {
                            if (Convert.ToInt32(arrList[2]) == 1)
                            {
                                sSql = sSql + " SELECT PRESC_NO,RTRIM(YPSPM) + RTRIM(YPSPMBZ) AS ITEM_NAME,SHH AS NSITEM_CODE,UNIT AS UNIT,RETAIL_PRICE AS PRICE,NUM AS NUM,";
                                sSql = sSql + " ACVALUE AS ACVALUE,DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT AS BABY_BIT,CHARGE_DATE AS CHARGE_DATE,";
                                sSql = String.Format("{0} DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,HSITEM_ID AS HSITEM_ID,'{1}' AS ZYH,", sSql, arrList[6]);
                                sSql = String.Format("{0} '{1}' AS NAME,'{2}' AS DEPTNAME,'{3}' AS TOTALFEE,'{4}' AS TOTALDEPOSITS,", sSql, arrList[7], arrList[8], Convert.ToDecimal(arrList[9]), Convert.ToDecimal(arrList[10]));
                                sSql = String.Format("{0} '{1}' AS BDATE,'{2}' AS EDATE,DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE", sSql, Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " FROM ( ";
                                sSql = sSql + " SELECT XMID AS CJID,UNIT,UNITRATE,COST_PRICE,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CHARGE_DATE,CHARGE_USER,CZ_FLAG, ";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,XMID AS HSITEM_ID,PRESC_NO,PRESC_DATE";
                                sSql = sSql + " FROM ZY_FEE_SPECI ";
                                sSql = String.Format("{0} WHERE DELETE_BIT = 0 AND CZ_FLAG = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1", sSql, arrList[1]);
                                sSql = String.Format("{0} AND CHARGE_DATE >= '{1} 00:00:00'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString());
                                sSql = String.Format("{0} AND CHARGE_DATE< '{1} 23:59:59' AND (STATITEM_CODE = '01' OR STATITEM_CODE = '02')", sSql, Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = sSql + " ) AS B1 INNER JOIN ( ";
                                sSql = sSql + " SELECT CJID,YPSPM,YPSPMBZ,YPGG,SHH FROM VI_YP_YPCD ) AS B2 ON B1.CJID = B2.CJID ";
                                sSql = sSql + " UNION ALL "; //--�в�ҩ����ʾ��ϸ
                                sSql = sSql + " SELECT PRESC_NO,'�в�ҩ����' AS ITEM_NAME,'' AS STANDARD,'��' AS UNIT,SUM(RETAIL_PRICE) AS PRICE,0 AS NUM,SUM(ACVALUE) AS ACVALUE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT AS BABY_BIT,CHARGE_DATE AS CHARGE_DATE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[7], arrList[8], arrList[9], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE";
                                sSql = sSql + " FROM ( ";
                                sSql = sSql + " SELECT UNIT,UNITRATE,COST_PRICE,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CHARGE_DATE AS CHARGE_DATE,CHARGE_USER,CZ_FLAG,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,XMID HSITEM_ID,PRESC_NO,DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE";
                                sSql = sSql + " FROM ZY_FEE_SPECI ";
                                sSql = String.Format("{0} WHERE DELETE_BIT = 0 AND CZ_FLAG = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1", sSql, arrList[1]);
                                sSql = String.Format("{0} AND CHARGE_DATE >= '{1} 00:00:00'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString());
                                sSql = String.Format("{0} AND CHARGE_DATE< '{1} 23:59:59' AND (STATITEM_CODE = '03')", sSql, Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = sSql + " ) AS B1 GROUP BY PRESC_NO,DOSAGE,CZ_FLAG,CHARGE_DATE,CHARGE_USER,BABY_BIT,HSITEM_ID,PRESC_DATE ORDER BY CHARGE_DATE ASC";
                            }
                            else
                            {
                                sSql = sSql + " SELECT PRESC_NO,B1.ITEM_NAME AS ITEM_NAME,B1.STD_CODE AS NSITEM_CODE,UNIT,RETAIL_PRICE AS PRICE,NUM AS NUM,ACVALUE AS ACVALUE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT AS BABY_BIT,CHARGE_DATE AS CHARGE_DATE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,A1.HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE FROM ( ";
                                sSql = sSql + " SELECT INPATIENT_ID,XMID HSITEM_ID,UNIT,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CZ_FLAG,CHARGE_DATE,CHARGE_USER,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,PRESC_NO,PRESC_DATE FROM ZY_FEE_SPECI";
                                sSql = String.Format("{0} WHERE DELETE_BIT = 0 AND CZ_FLAG = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1", sSql, arrList[1]);
                                sSql = String.Format("{0} AND CHARGE_DATE >= '{1} 00:00:00' ", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString());
                                sSql = String.Format("{0} AND CHARGE_DATE < '{1} 23:59:59' AND STATITEM_CODE <> '01' ", sSql, Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = sSql + " AND STATITEM_CODE <> '02' AND STATITEM_CODE <> '03' ) AS A1 ";
                                sSql = sSql + " INNER JOIN ";
                                sSql = sSql + " (SELECT ITEM_ID,ITEM_NAME,STD_CODE FROM JC_HSITEMDICTION) AS B1 ON A1.HSITEM_ID = B1.ITEM_ID ORDER BY CHARGE_DATE ASC";
                            }
                        }
                        else
                        {
                            //��ʷ���ѯ
                            //��ʾҩƷ(��ʷ��)
                            if (Convert.ToInt32(arrList[2]) == 1)
                            {
                                sSql = sSql + " SELECT PRESC_NO,RTRIM(YPSPM) + RTRIM(YPSPMBZ) AS ITEM_NAME,SHH AS NSITEM_CODE,UNIT AS UNIT,RETAIL_PRICE AS PRICE,NUM AS NUM,";
                                sSql = sSql + " ACVALUE AS ACVALUE,DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT AS BABY_BIT,CHARGE_DATE AS CHARGE_DATE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,HSITEM_ID AS HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE FROM ( ";
                                sSql = sSql + " SELECT XMID AS CJID,UNIT,UNITRATE,COST_PRICE,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CHARGE_DATE,CHARGE_USER,CZ_FLAG,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,XMID AS HSITEM_ID,PRESC_NO,PRESC_DATE ";
                                sSql = sSql + " FROM ZY_FEE_SPECI_H ";
                                sSql = String.Format("{0} WHERE DELETE_BIT = 0 AND CZ_FLAG = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1 AND", sSql, arrList[1]);
                                sSql = String.Format("{0} CHARGE_DATE >= '{1} 00:00:00' AND ", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString());
                                sSql = String.Format("{0} CHARGE_DATE < '{1} 23:59:59' AND (STATITEM_CODE = '01' OR STATITEM_CODE = '02')", sSql, Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = sSql + " ) AS B1 INNER JOIN ( ";
                                sSql = sSql + " SELECT CJID,YPSPM,YPSPMBZ,YPGG,SHH FROM VI_YP_YPCD ) AS B2 ON B1.CJID = B2.CJID";
                                sSql = sSql + " UNION ALL ";  //--�в�ҩ����ʾ��ϸ
                                sSql = sSql + " SELECT PRESC_NO,'�в�ҩ����' AS ITEM_NAME,'' AS STANDARD,'��' AS UNIT,SUM(RETAIL_PRICE) AS PRICE,0 AS NUM,SUM(ACVALUE) AS ACVALUE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT,CHARGE_DATE AS CHARGE_DATE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,HSITEM_ID AS HSITEM,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[9]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE FROM ( ";
                                sSql = sSql + " SELECT UNIT,UNITRATE,COST_PRICE,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CHARGE_DATE AS CHARGE_DATE,CHARGE_USER,CZ_FLAG,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,XMID HSITEM_ID,PRESC_NO,DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE";
                                sSql = sSql + " FROM ZY_FEE_SPECI_H ";
                                sSql = String.Format("{0} WHERE DELETE_BIT = 0 AND CZ_FLAG = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1", sSql, arrList[1]);
                                sSql = String.Format("{0} AND CHARGE_DATE > = '{1} 00:00:00' AND ", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString());
                                sSql = String.Format("{0} CHARGE_DATE < '{1} 23:59:59' AND (STATITEM_CODE = '03')) AS B1", sSql, Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = sSql + " GROUP BY PRESC_NO,DOSAGE,CZ_FLAG,CHARGE_DATE,CHARGE_USER,BABY_BIT,HSITEM_ID,PRESC_DATE ORDER BY CHARGE_DATE ASC";
                            }
                            else
                            {
                                //��������Ŀ��ʾ������ϸ
                                sSql = sSql + " SELECT PRESC_NO,B1.ITEM_NAME AS ITEM_NAME,B1.STD_CODE AS NSITEM_CODE,UNIT AS UNIT,RETAIL_PRICE AS PRICE,NUM AS NUM,";
                                sSql = sSql + " ACVALUE AS ACVALUE,DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT AS BABY_BIT,CHARGE_DATE AS CHARGE_DATE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,A1.HSITEM_ID AS HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + "DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE FROM ( ";
                                sSql = sSql + " SELECT INPATIENT_ID,XMID HSITEM_ID,UNIT,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CZ_FLAG,CHARGE_DATE,CHARGE_USER,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,PRESC_NO,PRESC_DATE FROM ZY_FEE_SPECI_H";
                                sSql = String.Format("{0} WHERE DELETE_BIT = 0 AND CZ_FLAG = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1", sSql, arrList[1]);
                                sSql = String.Format("{0} AND CHARGE_DATE >= '{1} 00:00:00'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString());
                                sSql = String.Format("{0} AND CHARGE_DATE < '{1} 23:59:59'", sSql, Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = sSql + " AND STATITEM_CODE <> '01' AND STATITEM_CODE <> '02' AND STATITEM_CODE <> '03' ) AS A1";
                                sSql = sSql + " INNER JOIN ";
                                sSql = sSql + " (SELECT ITEM_ID,ITEM_NAME,STD_CODE FROM JC_HSITEMDICTION) AS B1";
                                sSql = sSql + " ON A1.HSITEM_ID = B1.ITEM_ID ORDER BY CHARGE_DATE ASC";
                            }
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
        /// <summary>
        /// ��Ժ�����嵥������ӡ--ͳ��
        /// �洢����--SP_ZY_STAT_OUTPATIENTS
        /// </summary>
        /// <param name="isType">����</param>
        /// <param name="startDate">��ʼʱ��</param>
        /// <param name="endDate">����ʱ��</param>
        /// <param name="inpatientNo">סԺ��</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable ZyPatientHospitalStatLeave(ArrayList arrList, RelationalDatabase dataBase)  
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[0]) == 1)  //����ʱ��
                        {
                            sSql = sSql + " SELECT DISTINCT CAST(0 AS SMALLINT) AS SELECTED,A.INPATIENT_NO,A.NAME,DBO.FUN_ZY_SEEKSEXNAME(CAST(A.SEXCODE AS CHAR(4))) AS SEX,";
                            sSql = sSql + " DBO.FUN_ZY_AGE(CAST(A.BIRTHDAY AS DATETIME),CAST(4 AS SMALLINT),GETDATE()) AS AGE,A.DEPT_ID,DBO.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS DEPTNAME,";
                            sSql = sSql + " (CASE WHEN A.DISCHARGETYPE=0 THEN '�Է�' WHEN A.DISCHARGETYPE=1 THEN 'ҽ��' WHEN A.DISCHARGETYPE=2 THEN '����' ELSE '����' END) AS DISCHARGETYPE, A.INPATIENT_ID,(CASE WHEN C.NSTATUS IS NULL THEN 0 ELSE C.NSTATUS END) AS NSTATUS,(CASE WHEN C.NSTATUS IS NULL THEN 0 ELSE 1 END) AS DISCHARGE_BIT,A.IN_DATE,A.OUT_DATE,C.ID AS DISCHARGE_ID  ";
                            sSql = sSql + " FROM (SELECT * FROM VI_ZY_VINPATIENT WHERE CANCEL_BIT<>1 AND FLAG<>2 AND FLAG>=5 ) AS A";
                            sSql = sSql + " LEFT JOIN ";
                            sSql = sSql + " (SELECT * FROM ZY_DISCHARGE WHERE CANCEL_BIT=0 AND CZ_FLAG=0 ) AS C ON A.INPATIENT_ID=C.INPATIENT_ID ORDER BY A.INPATIENT_NO";
                        }
                        else if (Convert.ToInt32(arrList[0]) == 2) //��Ժʱ��
                        {
                            sSql = sSql + " SELECT DISTINCT CAST(0 AS SMALLINT) AS SELECTED,A.INPATIENT_NO,A.NAME,dbo.FUN_ZY_SEEKSEXNAME(CAST(A.SEXCODE AS CHAR(4))) AS SEX,";
                            sSql = sSql + " DBO.FUN_ZY_AGE(CAST(A.BIRTHDAY AS DATETIME),CAST(4 AS SMALLINT),GETDATE()) AS AGE,  ";
                            sSql = sSql + " A.DEPT_ID,dbo.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS DEPTNAME,(CASE WHEN A.DISCHARGETYPE=0 THEN '�Է�' WHEN A.DISCHARGETYPE=1 THEN 'ҽ��' WHEN A.DISCHARGETYPE=2 THEN '����' ELSE '����' END)  AS DISCHARGETYPE, A.INPATIENT_ID,(CASE WHEN B.NSTATUS IS NULL THEN 0 ELSE B.NSTATUS END) AS NSTATUS,(CASE WHEN B.NSTATUS IS NULL THEN 0 ELSE 1 END) AS DISCHARGE_BIT,A.IN_DATE,A.OUT_DATE ,B.ID AS DISCHARGE_ID";
                            sSql = String.Format("{0} FROM (SELECT * FROM VI_ZY_VINPATIENT WHERE CANCEL_BIT<>1 AND FLAG<>2 AND FLAG>=5 AND OUT_DATE >= '{1} 00:00:00' AND OUT_DATE < '{2} 23:59:59' ) AS A  ", sSql, Convert.ToDateTime(arrList[1]).ToShortDateString(), Convert.ToDateTime(arrList[2]).ToShortDateString());
                            sSql = sSql + " LEFT JOIN ";
                            sSql = sSql + " (SELECT * FROM ZY_DISCHARGE WHERE CANCEL_BIT=0 AND CZ_FLAG=0 ) AS B ON A.INPATIENT_ID=B.INPATIENT_ID ORDER BY A.INPATIENT_NO ";
                        }
                        else if (Convert.ToInt32(arrList[0]) == 3)  //����ʱ��
                        {
                            sSql = sSql + " SELECT CAST(0 AS SMALLINT) AS SELECTED,A.INPATIENT_NO,A.NAME,dbo.FUN_ZY_SEEKSEXNAME(CAST(A.SEXCODE AS CHAR(4))) AS SEX,";
                            sSql = sSql + " DBO.FUN_ZY_AGE(CAST(A.BIRTHDAY AS DATETIME),CAST(4 AS SMALLINT),GETDATE()) AS AGE, ";
                            sSql = sSql + " A.DEPT_ID,DBO.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS DEPTNAME,(CASE WHEN A.DISCHARGETYPE=0 THEN '�Է�' WHEN A.DISCHARGETYPE=1 THEN 'ҽ��'WHEN A.DISCHARGETYPE=2 THEN '����' ELSE '����' END) AS DISCHARGETYPE,A.INPATIENT_ID,(CASE WHEN B.NSTATUS IS NULL THEN 0 ELSE B.NSTATUS END) AS NSTATUS,(CASE WHEN B.NSTATUS IS NULL THEN 0 ELSE 1 END) AS DISCHARGE_BIT,A.IN_DATE,A.OUT_DATE,B.ID AS DISCHARGE_ID ";
                            sSql = sSql + " FROM (SELECT * FROM VI_ZY_VINPATIENT WHERE CANCEL_BIT<>1 AND FLAG<>2 AND FLAG>=5) AS A ";
                            sSql = sSql + " INNER JOIN ";
                            sSql = String.Format("{0} (SELECT * FROM ZY_DISCHARGE WHERE CANCEL_BIT=0 AND CZ_FLAG=0 AND DISCHARGE_DATE >= '{1} 00:00:00' AND DISCHARGE_DATE < '{2} 23:59:59' ) AS B", sSql, Convert.ToDateTime(arrList[1]).ToShortDateString(), Convert.ToDateTime(arrList[2]).ToShortDateString());
                            sSql = sSql + " ON A.INPATIENT_ID=B.INPATIENT_ID ORDER BY A.INPATIENT_NO";
                        }
                        else  //סԺ��
                        {
                            sSql = sSql + " SELECT CAST(0 AS SMALLINT) AS SELECTED,A.INPATIENT_NO,A.NAME,DBO.FUN_ZY_SEEKSEXNAME(CAST(A.SEXCODE AS CHAR(4))) AS SEX,DBO.FUN_ZY_AGE(CAST(A.BIRTHDAY AS DATETIME),CAST(4 AS SMALLINT),GETDATE()) AS AGE,  A.DEPT_ID,DBO.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS DEPTNAME,(CASE WHEN A.DISCHARGETYPE=0 THEN '�Է�' WHEN A.DISCHARGETYPE=1 THEN 'ҽ��'WHEN A.DISCHARGETYPE=2 THEN '����' ELSE '����' END) AS DISCHARGETYPE,  A.INPATIENT_ID,(CASE WHEN B.NSTATUS IS NULL THEN 0 ELSE B.NSTATUS END) AS NSTATUS,(CASE WHEN B.NSTATUS IS NULL THEN 0 ELSE 1 END) AS DISCHARGE_BIT,A.IN_DATE,A.OUT_DATE,B.ID AS DISCHARGE_ID ";
                            sSql = String.Format("{0} FROM (SELECT * FROM VI_ZY_VINPATIENT WHERE INPATIENT_NO = '{1}' AND CANCEL_BIT<>1 AND FLAG<>2 AND FLAG>=5) AS A ", sSql, arrList[3]);
                            sSql = sSql + " INNER JOIN ";
                            sSql = sSql + " (SELECT * FROM ZY_DISCHARGE WHERE CANCEL_BIT=0 AND CZ_FLAG=0) AS B ";
                            sSql = sSql + "  ON A.INPATIENT_ID=B.INPATIENT_ID ORDER BY A.INPATIENT_NO";
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
        /// ��Ժ�����嵥������ӡ--��ȡԤ����
        /// </summary>
        /// <param name="inpatientId">סԺID</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static Decimal ZyPatientHospitalDepositsLeave(ArrayList arrList, RelationalDatabase dataBase) 
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format(" SELECT SUM(DEPTOSITS) AS NFEE FROM ZY_DISCHARGE WHERE CANCEL_BIT = 0 AND INPATIENT_ID = '{0}'", arrList[0]);
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
            decimal nFee = Convert.ToDecimal(Convertor.IsNull(dataBase.GetDataResult(sSql), "0"));
            return nFee;
        }
        /// <summary>
        /// ��Ժ�����嵥������ӡ--ˮ�������ӡ
        /// �洢����--SP_ZY_STAT_DISCHARGEFEE
        /// </summary>
        /// <returns></returns>
        public static String ZyPatientHospitalRptPrintLeave(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[5]) == 0)  //��ʾҩƷ(��ǰ��)
                        {
                            if (Convert.ToInt32(arrList[2]) == 1)
                            {
                                sSql = sSql + " SELECT CAST(PRESC_NO AS DECIMAL(18,0)) AS PRESC_NO,RTRIM(YPSPM) + RTRIM(YPSPMBZ) AS ITEM_NAME,YPGG AS STANDARD,UNIT AS UNIT,";
                                sSql = sSql + " RETAIL_PRICE AS PRICE,NUM AS NUM,DOSAGE AS DOSAGE,ACVALUE AS ACVALUE,DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,";
                                sSql = sSql + " BABY_BIT AS BABY_BIT,CHARGE_DATE AS CHARGE_DATE,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,HSITEM_ID AS HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE ";
                                sSql = sSql + " FROM ( ";
                                sSql = sSql + " SELECT XMID CJID,UNIT,UNITRATE,COST_PRICE,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CHARGE_DATE,CHARGE_USER,CZ_FLAG,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,XMID HSITEM_ID,PRESC_NO,PRESC_DATE ";
                                sSql = sSql + " FROM ZY_FEE_SPECI ";
                                sSql = String.Format("{0} WHERE CHARGE_DATE BETWEEN '{1} 00:00:00 ' AND '{2} 23:59:59'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString(), Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = String.Format("{0} AND DELETE_BIT = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1 AND DISCHARGE_ID = '{2}'", sSql, arrList[1], arrList[0]);
                                sSql = sSql + " AND (STATITEM_CODE = '01' OR STATITEM_CODE = '02') ) AS B1";
                                sSql = sSql + " INNER JOIN ( ";
                                sSql = sSql + " SELECT CJID,YPSPM,YPSPMBZ,YPGG FROM VI_YP_YPCD ) AS B2 ON B1.CJID = B2.CJID";
                                sSql = sSql + " UNION ALL "; //�в�ҩ����ʾ��ϸ
                                sSql = sSql + " SELECT CAST(PRESC_NO AS DECIMAL(18,0)) AS PRESC_NO,'�в�ҩ����' AS ITEM_NAME,'' AS STANDARD,'��' AS UNIT,";
                                sSql = sSql + " SUM(RETAIL_PRICE) AS PRICE,0 AS NUM,DOSAGE AS DOSAGE,SUM(ACVALUE) AS ACVALUE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT AS BABY_BIT,CHARGE_DATE AS CHARGE_DATE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,HSITEM_ID AS HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' TOTALDEPOSITS,'{2}' AS BDATE,'{3}'AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE ";
                                sSql = sSql + " FROM ( ";
                                sSql = sSql + " SELECT UNIT,UNITRATE,COST_PRICE,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CHARGE_DATE,CHARGE_USER,CZ_FLAG,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,XMID HSITEM_ID,PRESC_NO,DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE";
                                sSql = sSql + " FROM ZY_FEE_SPECI ";
                                sSql = String.Format("{0} WHERE CHARGE_DATE BETWEEN '{1} 00:00:00'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString());
                                sSql = String.Format("{0} AND '{1} 23:59:59' AND DELETE_BIT = 0 ", sSql, Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = String.Format("{0} AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1 AND DISCHARGE_ID = '{2}' AND (STATITEM_CODE = '03') ) AS B1", sSql, arrList[1], arrList[0]);
                                sSql = sSql + " GROUP BY PRESC_NO,DOSAGE,CZ_FLAG,CHARGE_DATE,CHARGE_USER,BABY_BIT,HSITEM_ID,PRESC_DATE ORDER BY CHARGE_DATE ASC";

                            }
                            else  //��������Ŀ��ʾ������ϸ
                            {
                                sSql = sSql + " SELECT CAST(PRESC_NO AS DECIMAL(18,0)) AS PRESC_NO,B1.ITEM_NAME AS ITEM_NAME,B1.STD_CODE AS NSITEM_CODE,UNIT AS UNIT,";
                                sSql = sSql + " RETAIL_PRICE AS PRICE,NUM AS NUM,ACVALUE AS ACVALUE,DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT AS BABY_BIT,";
                                sSql = sSql + " CHARGE_DATE AS CHARGE_DATE,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,A1.HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}'AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE FROM ( ";
                                sSql = sSql + " SELECT INPATIENT_ID,XMID HSITEM_ID,UNIT,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CZ_FLAG,CHARGE_DATE,CHARGE_USER,";
                                sSql = sSql + "(CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,PRESC_NO,PRESC_DATE FROM ZY_FEE_SPECI";
                                sSql = String.Format("{0} WHERE CHARGE_DATE BETWEEN '{1} 00:00:00' AND '{2} 23:59:59'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString(), Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = String.Format("{0} AND DELETE_BIT = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1 AND DISCHARGE_ID = '{2}'", sSql, arrList[1], arrList[0]);
                                sSql = sSql + " AND STATITEM_CODE <> '01' AND STATITEM_CODE <> '02' AND STATITEM_CODE <> '03' ) AS A1";
                                sSql = sSql + " INNER JOIN ( ";
                                sSql = sSql + " SELECT ITEM_ID,ITEM_NAME,STD_CODE FROM JC_HSITEMDICTION ) AS B1 ";
                                sSql = sSql + " ON A1.HSITEM_ID = B1.ITEM_ID ORDER BY CHARGE_DATE ASC ";

                            }
                        }
                        else  //��ʷ���ѯ  ��ʾҩƷ
                        {
                            if (Convert.ToInt32(arrList[2]) == 1)
                            {
                                sSql = sSql + " SELECT CAST(PRESC_NO AS DECIMAL(18,0)) AS PRESC_NO,RTRIM(YPSPM) + RTRIM(YPSPMBZ) AS ITEM_NAME,YPGG AS STANDARD,UNIT AS UNIT,";
                                sSql = sSql + " RETAIL_PRICE AS PRICE,NUM AS NUM,DOSAGE AS DOSAGE,ACVALUE AS ACVALUE,DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,";
                                sSql = sSql + " BABY_BIT AS BABY_BIT,CHARGE_DATE AS CHARGE_DATE,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,HSITEM_ID AS HSITEM,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE FROM ( ";
                                sSql = sSql + " SELECT XMID CJID,UNIT,UNITRATE,COST_PRICE,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CHARGE_DATE,CHARGE_USER,CZ_FLAG,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,XMID HSITEM_ID,PRESC_NO,PRESC_DATE FROM ZY_FEE_SPECI_H ";
                                sSql = String.Format("{0} WHERE CHARGE_DATE BETWEEN '{1} 00:00:00' AND '{2} 23:59:59'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString(), Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = String.Format("{0} AND DELETE_BIT = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1 AND DISCHARGE_ID = '{2}'", sSql, arrList[1], arrList[0]);
                                sSql = sSql + " AND (STATITEM_CODE = '01' OR STATITEM_CODE = '02') ) AS B1 INNER JOIN ( ";
                                sSql = sSql + " SELECT CJID,YPSPM,YPSPMBZ,YPGG FROM VI_YP_YPCD ) AS B2 ON B1.CJID = B2.CJID ";
                                sSql = sSql + " UNION ALL ";  //�в�ҩ����ʾ��ϸ
                                sSql = sSql + " SELECT CAST(PRESC_NO AS DECIMAL(18,0)) AS PRESC_NO,'�в�ҩ����' AS ITEM_NAME,'' AS STANDARD,'��' AS UNIT,SUM(RETAIL_PRICE) AS PRICE,";
                                sSql = sSql + " 0 AS NUM,DOSAGE AS DOSAGE,SUM(ACVALUE) AS ACVALUE,DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT AS BABY_BIT,";
                                sSql = sSql + " CHARGE_DATE AS CHARGE_DATE,DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE FROM ( ";
                                sSql = sSql + " SELECT UNIT,UNITRATE,COST_PRICE,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CHARGE_DATE,CHARGE_USER,CZ_FLAG,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,XMID HSITEM_ID,PRESC_NO,DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE ";
                                sSql = sSql + " FROM ZY_FEE_SPECI_H ";
                                sSql = String.Format("{0} WHERE CHARGE_DATE BETWEEN '{1} 00:00:00' AND '{2} 23:59:59'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString(), Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = String.Format("{0} AND DELETE_BIT = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1 AND DISCHARGE_ID = '{2}'", sSql, arrList[1], arrList[0]);
                                sSql = sSql + " AND (STATITEM_CODE = '03') ) AS B1 ";
                                sSql = sSql + " GROUP BY PRESC_NO,DOSAGE,CZ_FLAG,CHARGE_DATE,CHARGE_USER,BABY_BIT,HSITEM_ID,PRESC_DATE ORDER BY CHARGE_DATE ASC ";
                            }
                            else  //��������Ŀ��ʾ������ϸ
                            {
                                sSql = sSql + " SELECT CAST(PRESC_NO AS DECIMAL(18,0)) AS PRESC_NO,B1.ITEM_NAME AS ITEM_NAME,B1.STD_CODE AS NSITEM_CODE,UNIT AS UNIT,";
                                sSql = sSql + " ACVALUE AS ACVALUE,DBO.FUN_ZY_SEEKFEETYPENAME(CZ_FLAG) AS TYPE,BABY_BIT,CHARGE_DATE AS CHARGE_DATE,";
                                sSql = sSql + " DBO.FUN_ZY_SEEKEMPLOYEENAME(CHARGE_USER) AS CHARGE_USER,A1.HSITEM_ID,";
                                sSql = String.Format("{0} '{1}' AS ZYH,'{2}' AS NAME,'{3}' AS DEPTNAME,'{4}' AS TOTALFEE,", sSql, arrList[6], arrList[7], arrList[8], Convert.ToDecimal(arrList[9]));
                                sSql = String.Format("{0} '{1}' AS TOTALDEPOSITS,'{2}' AS BDATE,'{3}' AS EDATE,", sSql, Convert.ToDecimal(arrList[10]), Convert.ToDateTime(arrList[3]), Convert.ToDateTime(arrList[4]));
                                sSql = sSql + " DBO.FUN_GETDATE(PRESC_DATE) AS PRESC_DATE FROM ( ";
                                sSql = sSql + " SELECT INPATIENT_ID,XMID HSITEM_ID,UNIT,RETAIL_PRICE,NUM,DOSAGE,SDVALUE,ACVALUE,CZ_FLAG,CHARGE_DATE,CHARGE_USER,";
                                sSql = sSql + " (CASE WHEN BABY_ID > 0 THEN 1 ELSE 0 END) AS BABY_BIT,PRESC_NO,PRESC_DATE FROM ZY_FEE_SPECI_H ";
                                sSql = String.Format("{0} WHERE CHARGE_DATE BETWEEN '{1} 00:00:00' AND '{2} 23:59:59'", sSql, Convert.ToDateTime(arrList[3]).ToShortDateString(), Convert.ToDateTime(arrList[4]).ToShortDateString());
                                sSql = String.Format("{0} AND DELETE_BIT = 0 AND INPATIENT_ID = '{1}' AND CHARGE_BIT = 1 AND DISCHARGE_ID = '{2}'", sSql, arrList[1], arrList[0]);
                                sSql = sSql + " AND STATITEM_CODE <>  '01' AND STATITEM_CODE <> '02'AND STATITEM_CODE <> '03' ) AS A1 INNER JOIN ";
                                sSql = sSql + " (SELECT ITEM_ID,ITEM_NAME,STD_CODE FROM JC_HSITEMDICTION ) AS B1 ON A1.HSITEM_ID = B1.ITEM_ID ORDER BY CHARGE_DATE ASC";
                            }
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
        /// <summary>
        /// ��Ժ�����嵥������ӡ--סԺ�Ų�ѯ
        /// </summary>
        /// <param name="inpatientNo">סԺ��</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable ZyPatientHospitalNumberQueryLeave(ArrayList arrList, RelationalDatabase dataBase)  
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT DISTINCT CAST(0 AS SMALLINT) AS SELECTED,A.INPATIENT_NO,A.NAME,DBO.FUN_ZY_SEEKSEXNAME(CAST(A.SEXCODE AS CHAR(4))) AS SEX,";
                        sSql = sSql + " DBO.FUN_ZY_AGE(CAST(A.BIRTHDAY AS DATETIME),CAST(4 AS SMALLINT),GETDATE()) AS AGE, A.DEPT_ID,DBO.FUN_ZY_SEEKDEPTNAME(A.DEPT_ID) AS DEPTNAME,";
                        sSql = sSql + " (CASE WHEN A.DISCHARGETYPE=0 THEN '�Է�' WHEN A.DISCHARGETYPE=1 THEN 'ҽ��' WHEN A.DISCHARGETYPE=2 THEN '����' ELSE '����' END) AS DISCHARGETYPE,";
                        sSql = sSql + "  A.INPATIENT_ID,(CASE WHEN C.NSTATUS IS NULL THEN 0 ELSE C.NSTATUS END) AS NSTATUS,(CASE WHEN C.NSTATUS IS NULL THEN 0 ELSE 1 END) AS DISCHARGE_BIT,C.DISCHARGE_BDATE AS IN_DATE,C.DISCHARGE_EDATE AS OUT_DATE,C.ID as DISCHARGE_ID ";
                        sSql = sSql + " FROM (SELECT * FROM VI_ZY_VINPATIENT WHERE CANCEL_BIT<>1 AND FLAG<>2 AND FLAG>=5 ) AS A ";
                        sSql = sSql + " INNER JOIN (SELECT * FROM ZY_DISCHARGE WHERE CANCEL_BIT=0 AND CZ_FLAG=0 ) AS C ";
                        sSql = String.Format("{0}  ON A.INPATIENT_ID=C.INPATIENT_ID WHERE INPATIENT_NO = '{1}'", sSql, arrList[0]);
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
