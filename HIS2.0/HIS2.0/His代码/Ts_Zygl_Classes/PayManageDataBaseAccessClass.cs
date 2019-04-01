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
 * ���ƣ�סԺ���˹������ݿ������
 * ������������סԺ���˹����е����ݿ����
 * ��дʱ�䣺2013-10
 * ���ߣ�Kevin
 * **/

namespace Ts_Zygl_Classes
{
    public class PayManageDataBaseAccessClass
    {
        /*
         * ���˹����д洢����δ����
         */


        /// <summary>
        /// סԺ�����ѯ
        /// �洢����--SP_ZY_CX_JKJL
        /// </summary>
        /// <param name="beginDateTime">��ʼ����</param>
        /// <param name="endDateTime">��������</param>
        /// <param name="employeeId">�շ�ԱID</param>
        /// <param name="isType">״̬����</param>
        /// <param name="isConfirm">�Ƿ�ȷ��</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable ZpqZyPaymentQuery(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        if (Convert.ToInt32(arrList[3]) == 2)  //ȫ��
                        {
                            sSql = sSql + " SELECT * FROM  ";
                            sSql = sSql + " ( ";
                            sSql = sSql + " SELECT '0' ���,CASE WHEN TURN_USERID=-1 THEN 'ȫ��' ELSE DBO.FUN_GETEMPNAME(TURN_USERID) END �շ�Ա,TURN_BDATE ��ʼʱ��, ";
                            sSql = sSql + " TURN_EDATE ����ʱ��,TURN_DATE �ɿ�ʱ��,DEPOSITS ��Ԥ����,POS POS, [CHECK] ֧Ʊ,ISNULL([BATCH],0) ����,ISNULL(FCCACCOUNT,0) �������,PATCHFEE ���㲹��, RECEDEFEE �����˿�, INSUREFEE ҽ��֧��, ";
                            //Modify By Kevin 2014-05-20 ���Ӽ�����
                            sSql = sSql + " CXDEPOSITS ����Ԥ��,DEBTFEE Ƿ��,BLANCE ���, NFEE �����ܷ���,INCOME ����, CASHTOTAL �ֽ�ϼ�,ISNULL(DERATEFEE,0) ������, ";
                            sSql = sSql + " (CASE WHEN A.ISJK = 0 THEN 'δȷ��' WHEN A.ISJK = 1 THEN '��ȷ��' ELSE '' END) ȷ�ϱ�־, ";
                            sSql = sSql + " DBO.FUN_GETEMPNAME(A.AFFUSER) ȷ����,A.AFFDATE ȷ��ʱ��,TURN_USERID,A.TURN_ID,PAYNUMBER,PAYFLAG ";
                            sSql = sSql + " FROM ZY_TURNACCOUNT A ";
                            sSql = String.Format("{0} WHERE A.TURN_DATE BETWEEN '{1}' AND '{2}' AND (TURN_USERID={3} OR {3}=-1) ", sSql, arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
                            sSql = sSql + " UNION ALL ";
                            sSql = sSql + " SELECT '99999' ���,NULL �շ�Ա,NULL ��ʼʱ��,NULL ����ʱ��,NULL �ɿ�ʱ��,SUM(DEPOSITS) ��Ԥ����, SUM(POS) POS, SUM([CHECK]) ֧Ʊ,ISNULL(SUM([BATCH]),0) ����,ISNULL(SUM(FCCACCOUNT),0) �������, SUM(PATCHFEE) ���㲹��, ";
                            sSql = sSql + " SUM(RECEDEFEE) �����˿�, SUM(INSUREFEE) ҽ��֧��, SUM(CXDEPOSITS) ����Ԥ��, SUM(DEBTFEE) Ƿ��,SUM(BLANCE) ���, ";
                            //Modify By Kevin 2014-05-20 ���Ӽ�����
                            sSql = sSql + " SUM(NFEE) �����ܷ���, SUM(INCOME) ����, SUM(CASHTOTAL) �ֽ�ϼ�,ISNULL(SUM(DERATEFEE),0) ������,NULL ȷ�ϱ�־,NULL ȷ����,NULL ȷ��ʱ��,NULL TURN_USERID,NULL,NULL PAYNUMBER,NULL PAYFLAG ";
                            sSql = sSql + " FROM ZY_TURNACCOUNT A ";
                            sSql = String.Format("{0} WHERE A.TURN_DATE BETWEEN '{1}' AND '{2}' AND (TURN_USERID={3} OR {3}=-1) ", sSql, arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
                            sSql = sSql + " ) A ";
                            sSql = sSql + " ORDER BY ���,�ɿ�ʱ�� ";
                        }
                        else
                        {
                            sSql = sSql + " SELECT * FROM ";
                            sSql = sSql + " ( ";
                            sSql = sSql + " SELECT '0' ���,CASE WHEN TURN_USERID=-1 THEN 'ȫ��' ELSE DBO.FUN_GETEMPNAME(TURN_USERID) END �շ�Ա,TURN_BDATE ��ʼʱ��, ";
                            sSql = sSql + " TURN_EDATE ����ʱ��,TURN_DATE �ɿ�ʱ��,DEPOSITS ��Ԥ����,POS POS, [CHECK] ֧Ʊ,ISNULL([BATCH],0) ����,ISNULL(FCCACCOUNT,0) �������,PATCHFEE ���㲹��, RECEDEFEE �����˿�, INSUREFEE ҽ��֧��, ";
                            //Modify By Kevin 2014-05-20 ���Ӽ�����
                            sSql = sSql + " CXDEPOSITS ����Ԥ��,DEBTFEE Ƿ��,BLANCE ���, NFEE �����ܷ���,INCOME ����, CASHTOTAL �ֽ�ϼ�,ISNULL(DERATEFEE,0) ������, ";
                            sSql = sSql + " (CASE WHEN A.ISJK = 0 THEN 'δȷ��' WHEN A.ISJK = 1 THEN '��ȷ��' ELSE '' END) ȷ�ϱ�־, ";
                            sSql = sSql + " DBO.FUN_GETEMPNAME(A.AFFUSER) ȷ����,A.AFFDATE ȷ��ʱ��,TURN_USERID,A.TURN_ID,PAYNUMBER,PAYFLAG ";
                            sSql = sSql + " FROM ZY_TURNACCOUNT A ";
                            sSql = String.Format("{0} WHERE A.ISJK = {1} AND A.TURN_DATE BETWEEN '{2}' AND '{3}' AND (TURN_USERID={4} OR {4}=-1) ", sSql, Convert.ToInt32(arrList[4]), arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
                            sSql = sSql + " UNION ALL ";
                            sSql = sSql + " SELECT '99999' ���,NULL �շ�Ա,NULL ��ʼʱ��,NULL ����ʱ��,NULL �ɿ�ʱ��,SUM(DEPOSITS) ��Ԥ����, SUM(POS) POS, SUM([CHECK]) ֧Ʊ, ISNULL(SUM([BATCH]),0) ����,ISNULL(SUM(FCCACCOUNT),0) �������,SUM(PATCHFEE) ���㲹��, ";
                            sSql = sSql + " SUM(RECEDEFEE) �����˿�, SUM(INSUREFEE) ҽ��֧��, SUM(CXDEPOSITS) ����Ԥ��, SUM(DEBTFEE) Ƿ��,SUM(BLANCE) ���, ";
                            //Modify By Kevin 2014-05-20 ���Ӽ�����
                            sSql = sSql + " SUM(NFEE) �����ܷ���, SUM(INCOME) ����, SUM(CASHTOTAL) �ֽ�ϼ�,ISNULL(SUM(DERATEFEE),0) ������,NULL ȷ�ϱ�־,NULL ȷ����,NULL ȷ��ʱ��,NULL TURN_USERID,NULL TURN_ID ,NULL PAYNUMBER,NULL PAYFLAG ";
                            sSql = sSql + " FROM ZY_TURNACCOUNT A ";
                            sSql = String.Format("{0} WHERE A.ISJK = {1} AND A.TURN_DATE BETWEEN '{2}' AND '{3}' AND (TURN_USERID={4} OR {4}=-1) ", sSql, Convert.ToInt32(arrList[4]), arrList[0], arrList[1], Convert.ToInt32(arrList[2]));
                            sSql = sSql + " ) A ";
                            sSql = sSql + " ORDER BY ���,�ɿ�ʱ�� ";
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
        /// ����ȷ����Ϣ
        /// </summary>
        /// <param name="employeeId">ȷ����Ա</param>
        /// <param name="confirmTime">ȷ��ʱ��</param>
        /// <param name="paymentId">����ID</param>
        /// <param name="dataBase">���ݿ�����</param>
        public static void ZpqModifyConfirmBit(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";

            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = String.Format("{0}UPDATE ZY_TURNACCOUNT SET ISJK = 1,AFFUSER = {1},AFFDATE = '{2:yyyy-MM-dd HH:mm:ss}' WHERE TURN_ID = '{3}'", sSql, Convert.ToInt32(arrList[0]), arrList[1], arrList[2]);
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
        /// ��ȡ������С�Ľ��㷢Ʊ��
        /// </summary>
        /// <param name="beginDateTime">��ʼʱ��</param>
        /// <param name="endDateTime">����ʱ��</param>
        /// <param name="nType">��Ʊ����</param>
        /// <param name="employeeId">��ԱID</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable ZpqGetMaxAndMinBillNo(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT MIN(BILLNO) AS MINBILLNO,MAX(BILLNO) AS MAXBILLNO FROM ZY_BILLLIST ";
                        sSql = String.Format("{0} WHERE NTYPE = {1} AND USED_DATE >= '{2}' ", sSql, Convert.ToInt32(arrList[2]), arrList[0]);
                        sSql = String.Format("{0} AND USED_DATE <= '{1}' ", sSql, arrList[1]);
                        if (Convert.ToInt32(arrList[3]) != -1)
                            sSql = String.Format("{0} AND USERID = {1} GROUP BY NBATCH ", sSql, Convert.ToInt32(arrList[3]));
                        else
                            sSql = sSql + " GROUP BY NBATCH ";
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
        /// ��ȡҽ�����ü���
        /// </summary>
        /// <param name="arrList">����ID</param>
        /// <param name="dataBase">���ݿ�����</param>
        /// <returns></returns>
        public static DataTable ZpqGetMedicalAssemble(ArrayList arrList, RelationalDatabase dataBase)
        {
            string sSql = "";
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        sSql = sSql + " SELECT SUM(ZHZF) GRZHZF,SUM(TCZF) + SUM(QTZF) YBJJZF FROM ZY_YB_JSB ";
                        sSql = String.Format("{0} WHERE DISCHARGE_BIT = 1 AND DELETE_BIT = 0 AND DISCHARGE_ID IN (SELECT ID FROM ZY_DISCHARGE WHERE CZ_FLAG = 0 AND TURN_BIT = 1 AND TURN_ID = '{1}') ", sSql, arrList[0]);
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
        public static DateTime ZpqGetLastTurnDate(ArrayList arrList, RelationalDatabase dataBase)
        {
            DateTime minDate = new DateTime();
            switch (dataBase.ConnectionType)
            {
                case ConnectType.SQLSERVER:
                    {
                        string turnCountSql = String.Format(" SELECT TOP 1 * FROM ZY_TURNACCOUNT WHERE TURN_USERID = {0} ORDER BY TURN_DATE DESC ", Convert.ToInt32(arrList[0]));
                        DataTable tb = dataBase.GetDataTable(turnCountSql);
                        if (tb.Rows.Count == 0)
                        {
                            DateTime disDate = Convert.ToDateTime(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT MIN(DISCHARGE_DATE) FROM ZY_DISCHARGE WHERE USERID = {0} AND TURN_BIT = 0", Convert.ToInt32(arrList[0]))), "1900-01-01 00:00:00"));
                            DateTime depDate = Convert.ToDateTime(Convertor.IsNull(dataBase.GetDataResult(String.Format("SELECT MIN(ARRIVE_DATE) FROM ZY_DEPOSITS WHERE ARRIVE_USERID = {0} AND TURN_BIT = 0", Convert.ToInt32(arrList[0]))), "1900-01-01 00:00:00"));
                            minDate = disDate;
                            if (disDate == Convert.ToDateTime("1900-01-01 00:00:00"))
                            {
                                minDate = depDate;
                            }
                            else if (depDate == Convert.ToDateTime("1900-01-01 00:00:00"))
                            {
                                minDate = disDate;
                            }
                            else if (disDate > depDate)
                            {
                                minDate = depDate;
                            }
                            else
                            {
                                minDate = disDate;
                            }
                            //return minDate;//Convert.ToDateTime("1900-01-01 00:00:00");
                        }
                        else
                        {
                            minDate = Convert.ToDateTime(tb.Rows[0]["turn_edate"]);
                            //return Convert.ToDateTime(tb.Rows[0]["turn_edate"]);
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
            return minDate;
        }
    }
}