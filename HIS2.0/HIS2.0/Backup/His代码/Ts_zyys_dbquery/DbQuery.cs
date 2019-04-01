using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace Ts_zyys_public
{

    /// <summary>
    /// ���ݿ��ѯ ��ժҪ˵����
    /// </summary>
    public class DbQuery
    {
        public static long Dept_ID = 0;
        public static long Ward_dep = 0;
        public static DataTable SelectTb = new DataTable();
        private RelationalDatabase database;
        public ArrayList Cpform = new ArrayList();

        /// <summary>
        /// �жϻ�ʿվ�Ƿ�����
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public bool IsDeptOk(string deptId)
        {
            try
            {
                string strSql = "select * from vi_zy_newhishsz";
                DataTable dt = database.GetDataTable(strSql);

                if (dt.Columns.Contains("deptid"))
                {
                    dt.PrimaryKey = new DataColumn[1] { dt.Columns["deptid"] };
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows.Contains(deptId);
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// �ٴ�·���ӿ�
        /// </summary>
        Ts_Clinicalpathway_Factory.ts_cp_interface Cpinterface;
        public DbQuery()
        {
            database = FrmMdiMain.Database;
        }

        //Add By tany 2011-06-20 �������ݿ�����
        public DbQuery(RelationalDatabase db)
        {
            database = db;

        }

        #region ˢ��ѡ�
        /// <summary>
        /// ˢ��ѡ�
        /// </summary>
        public void NewSelectTb(int Jgbm)
        {
            SelectTb = GetSelCard(Dept_ID, Ward_dep, Jgbm);
        }
        #endregion

        #region ��ȡ���Ҳ���
        /// <summary>
        /// ��ȡ���Ҳ���
        /// </summary>
        /// <param name="sign">1=ҽ����Ͻ�ڲ��ˡ�2=�����ҵĲ��ˡ�3=���뵽�����һ���Ĳ���</param>
        /// <param name="deptid">������ID</param>
        /// <param name="docid">ҽ������ID</param>
        /// <returns></returns>
        public DataTable GetInpatient(int sign, long deptid, long docid)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptid;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = docid;
            parameters[2].Text = "@DOC";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_INPATIENT", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ҽ��ѡ�
        /// <summary>
        /// ҽ��ѡ�
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <param name="wardDept">��������ҩ��</param>
        /// <returns></returns>
        public DataTable GetSelCard(long deptID, long wardDept, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = deptID;
            parameters[0].Text = "@DEPTID";
            parameters[1].Value = wardDept;
            parameters[1].Text = "@WARD_DEPT";
            parameters[2].Value = Jgbm;
            parameters[2].Text = "@Jgbm";
            try
            {
                return database.GetDataTable("SP_ZYYS_ORDERS_SELCARD", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ɾ��ҽ��
        /// <summary>
        /// ɾ��ҽ��
        /// </summary>
        /// <param name="OrderID">һ����¼ID</param>
        /// <param name="GroupNum">һ��ҽ�����</param>
        /// <param name="InpatientID">����סԺID</param>
        /// <param name="sign">0=ɾһ����¼��1=ɾ��һ��ҽ��</param>
        /// <returns></returns>
        public int DeleOrders(Guid OrderID, int GroupNum, Guid InpatientID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = OrderID;
            parameters[1].Text = "@ORDERID";
            parameters[2].Value = GroupNum;
            parameters[2].Text = "@GROUPNUM";
            parameters[3].Value = InpatientID;
            parameters[3].Text = "@INPATIENTID";
            try
            {
                return database.DoCommand("SP_ZYYS_DELETE_ORDER", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        #endregion

        #region ͣҽ�����˵�
        /// <summary>
        /// ͣһ��ҽ��
        /// </summary>
        /// <param name="DocID">����ҽ��ID</param>
        /// <param name="EndNum">ĩ�մ���</param>
        /// <param name="GroupNum">ҽ�����</param>
        /// <param name="InpatientID">����ID</param>
        /// <param name="BabyID">Ӥ��ID</param>
        /// <param name="sign">0=ͣһ��ҽ����¼,1=ȡ��ͣһ��ҽ����2=ͣһ���е�һ����¼��3=ȡ��ͣһ����¼</param>
        /// <returns></returns>
        public int StopOrders(long DocID, int EndNum, long GroupNum, Guid OrderId, Guid InpatientID, long BabyID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Value = DocID;
            parameters[0].Text = "@DOC";
            parameters[1].Value = EndNum;
            parameters[1].Text = "@ENDNUM";
            parameters[2].Value = GroupNum;
            parameters[2].Text = "@GROUPNUM";
            parameters[3].Value = OrderId;
            parameters[3].Text = "@ORDER_ID";
            parameters[4].Value = InpatientID;
            parameters[4].Text = "@INPATIENTID";
            parameters[5].Value = BabyID;
            parameters[5].Text = "@BABYID";
            parameters[6].Value = sign;
            parameters[6].Text = "@SIGN";
            try
            {
                return database.DoCommand("SP_ZYYS_STOP_GROUP", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        /// <summary>
        /// ͣһ��ҽ��
        /// </summary>
        /// <param name="DocID">����ҽ��ID</param>
        /// <param name="dtime">ͣ��ʱ��</param>
        /// <param name="EndNum">ĩ�մ���</param>
        /// <param name="GroupNum">ҽ�����</param>
        /// <param name="InpatientID">����ID</param>
        /// <param name="BabyID">Ӥ��ID</param>
        /// <param name="sign">0=ͣһ��ҽ����¼,1=ȡ��ͣһ��ҽ����2=ͣһ���е�һ����¼��3=ȡ��ͣһ����¼</param>
        /// <returns></returns>
        public int StopOrders(long DocID, DateTime dtime, int EndNum, long GroupNum, Guid OrderId, Guid InpatientID, long BabyID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[8];
            parameters[0].Value = DocID;
            parameters[0].Text = "@DOC";
            parameters[1].Value = dtime;
            parameters[1].Text = "@DATE";
            parameters[2].Value = EndNum;
            parameters[2].Text = "@ENDNUM";
            parameters[3].Value = GroupNum;
            parameters[3].Text = "@GROUPNUM";
            parameters[4].Value = OrderId;
            parameters[4].Text = "@ORDER_ID";
            parameters[5].Value = InpatientID;
            parameters[5].Text = "@INPATIENTID";
            parameters[6].Value = BabyID;
            parameters[6].Text = "@BABYID";
            parameters[7].Value = sign;
            parameters[7].Text = "@SIGN";
            try
            {
                return database.DoCommand("SP_ZYYS_STOP_GROUP1", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        /// <summary>
        /// ͣ����ҽ��
        /// </summary>
        /// <param name="_Database">���ݿ���ʶ���</param>
        /// <param name="EndDate">ͣ��ʱ��</param>
        /// <param name="DocID">����ҽ��</param>
        /// <param name="InpatientID">����ID</param>
        /// <param name="BabyID">Ӥ��ID</param>
        /// <param name="EndNum">ĩ��ִ�д���</param>
        /// <returns></returns>
        public int StopOrders(RelationalDatabase _Database, string EndDate, long DocID, Guid InpatientID, long BabyID, int EndNum)
        {
            string sSql = "where inpatient_id='" + InpatientID + "' and baby_id=" + BabyID + " and status_flag=2 and MNGTYPE=0";  //ͣҽ��
            if (EndNum == -1)
            {
                sSql = "UPDATE zy_orderrecord SET order_edoc=" + DocID + ",order_edate=case when '" + EndDate + "'<order_bdate then order_bdate else '" + EndDate + "' end,terminal_times=dbo.FUN_EXECTIMES(COALESCE(frequency ,'Qd'),CAST('" + EndDate + "' AS DATETIME),1),status_flag=3 " + sSql;
            }
            else
            {
                sSql = "UPDATE zy_orderrecord SET order_edoc=" + DocID + ",order_edate=case when '" + EndDate + "'<order_bdate then order_bdate else '" + EndDate + "' end,terminal_times=" + Convert.ToInt16(EndNum) + ",status_flag=3 " + sSql;
            }
            return _Database.DoCommand(sSql);
        }

        /// <summary>
        /// ͣ�����˵�
        /// </summary>
        /// <param name="_Database">���ݿ���ʶ���</param>
        /// <param name="EndDate">ͣ��ʱ��</param>
        /// <param name="DocID">����ҽ��</param>
        /// <param name="InpatientID">����ID</param>
        /// <param name="BabyID">Ӥ��ID</param>
        /// <param name="EndNum">ĩ��ִ�д���</param>
        /// <param name="zd"></param>
        /// <returns></returns>

        public int StopOrders_ZD(RelationalDatabase _Database, string EndDate, long DocID, Guid InpatientID, long BabyID, int EndNum, int zd)
        {
            string sSql = "where inpatient_id='" + InpatientID + "' and baby_id=" + BabyID + " and status_flag=2 and MNGTYPE=2";   //ͣ�ʵ�
            if (EndNum == -1)
            {
                sSql = "UPDATE zy_orderrecord SET order_edoc=" + DocID + ",order_edate=case when '" + EndDate + "'<order_bdate then order_bdate else '" + EndDate + "' end,terminal_times=dbo.FUN_EXECTIMES(COALESCE(frequency ,'Qd'),CAST('" + EndDate + "' AS DATETIME),1),status_flag=4 " + sSql;
            }
            else
            {
                sSql = "UPDATE zy_orderrecord SET order_edoc=" + DocID + ",order_edate=case when '" + EndDate + "'<order_bdate then order_bdate else '" + EndDate + "' end,terminal_times=" + Convert.ToInt16(EndNum) + ",status_flag=4 " + sSql;
            }
            return _Database.DoCommand(sSql);
        }
        #endregion

        #region �õ�ҽ�����������ʹ���
        /// <summary>
        /// �õ�ҽ����������
        /// </summary>
        /// <param name="nType">���ʹ���</param>
        /// <returns></returns>
        public string GetyzType(long nType)
        {
            string sSql = "select name from JC_OrderType where code=" + nType.ToString();
            DataTable myTb = new DataTable();

            myTb = database.GetDataTable(sSql);
            if (myTb.Rows.Count > 0)
            {
                string kk = myTb.Rows[0]["name"].ToString().Trim();
                return kk;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// �õ�ҽ�������͵Ĵ���
        /// </summary>
        /// <param name="s_Type">������</param>
        /// <returns></returns>
        public string GetyzTypeCode(string s_Type)
        {
            if (s_Type == "") return "0";

            string s_temp = "00-��Ժ11-��ҩ22-�г�ҩ33-�в�ҩ44-����55-ҽ��66-����77-˵��88-����99-����1010-С����";
            int pos = s_temp.IndexOf(s_Type);
            if (s_Type == "10-С����")
            {
                return s_temp.Substring(pos - 2, 2);
            }
            else
            {
                return s_temp.Substring(pos - 1, 1);
            }
        }
        #endregion

        #region ҽ��ѡ��
        /// <summary>
        /// ҽ��ѡ��
        /// </summary>
        /// <param name="n_SelType">1=������2=������3=��Ч������4=����վ����,5=�ʵ�¼��</param>
        /// <param name="BabyID">Ӥ��ID</param>
        /// <param name="InpatientID">����ID</param>
        /// <param name="deptId">��������ID</param>
        /// <returns></returns>
        public DataTable GetBinOrders(int n_SelType, long BabyID, Guid InpatientID, long deptId)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = n_SelType;
            parameters[0].Text = "@SELTYPE";
            parameters[1].Value = BabyID;
            parameters[1].Text = "@BABYID";
            parameters[2].Value = InpatientID;
            parameters[2].Text = "@BINID";
            parameters[3].Value = deptId;
            parameters[3].Text = "@deptid";
            try
            {
                DataTable tb = database.GetDataTable("SP_ZYYS_ORDERS_SELECT", parameters, 30);
                int groupId = 0;
                int j = 0;
                SystemCfg cfg6084 = new SystemCfg(6084);
                if ((n_SelType == 1 || n_SelType == 3) && cfg6084.Config.Trim() == "0")
                {
                    //����ҽ��Ҳ����ʾ��ϸ 
                    for (int i = 0; i - j < tb.Rows.Count; i++)
                    {
                        if (groupId == int.Parse(tb.Rows[i - j]["����"].ToString()))
                        {
                            tb.Rows.RemoveAt(i - j);
                            j++;
                        }
                        else if (int.Parse(tb.Rows[i - j]["STATUS_FLAG"].ToString()) >= 2 && int.Parse(tb.Rows[i - j]["ntype"].ToString()) == 3)
                        {
                            tb.Rows[i - j]["ID"] = new Guid("99999999-9999-9999-9999-999999999999");
                            tb.Rows[i - j]["��λ"] = "��";
                            tb.Rows[i - j]["����"] = tb.Rows[i - j]["����"];
                            tb.Rows[i - j]["ҽ������"] = (tb.Rows[i - j]["ҽ������"].ToString().Contains("ȡ��") ? "��ȡ����" : "") + "�в�ҩ����";
                            groupId = int.Parse(tb.Rows[i - j]["����"].ToString());
                        }

                    }
                }
                return tb;
            }
            catch (Exception err)
            {
                MessageBox.Show("" + err.ToString().Trim(), "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SaveLog(0, 0, "��ѯҽ������", "ҽ�����ͣ�" + n_SelType.ToString() + "�����ˣ�" + InpatientID.ToString() + "��" + BabyID.ToString() + "������" + err.ToString(), 1, 41);
                return null;
            }
        }
        #endregion

        #region ҽ���ٻ�
        /// <summary>
        /// ҽ���ٻ�
        /// </summary>
        /// <param name="n_SelType">0=������1=����</param>
        /// <param name="InpatientID">����ID</param>
        /// <param name="GroupID">ҽ�����</param>
        /// <param name="orderid">ҽ��id add by zouchihua 2011-11-02</param>
        /// <param name="type"> ���� 0=һ�� 1=һ�� add by zouchihua 2011-11-02 </param>
        /// <returns></returns>
        public DataTable GetOrdersRecall(int n_SelType, Guid InpatientID, int GroupID, Guid orderid, int type)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Value = n_SelType;
            parameters[0].Text = "@SELTYPE";
            parameters[1].Value = InpatientID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = GroupID;
            parameters[2].Text = "@GROUPID";
            //add by zouchihua  2011-11-02 ���ڸ���ҽ��ҽ����һ��ҽ��
            parameters[3].Value = orderid;
            parameters[3].Text = "@orderid";
            parameters[4].Value = type;
            parameters[4].Text = "@type";
            try
            {
                return database.GetDataTable("SP_ZYYS_ORDERS_RECALL", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ��Ժ����ҽ��
        /// <summary>
        /// ��Ժ����ҽ����������
        /// </summary>
        /// <param name="InpatientID">����ID</param>
        /// <param name="GroupID">��������</param>
        public bool HoldOrder(Guid InpatientID, int GroupID)
        {
            try
            {
                database.DoCommand("update zy_orderrecord set order_edate=null,Order_eDoc=null,status_flag=5 where inpatient_id='" + InpatientID + "' and mngtype=0 and group_id=" + GroupID + " and delete_bit=0 ");
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("����ҽ������\n" + err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        #endregion

        #region ��ȡ�������ҽ�����
        /// <summary>
        /// ��ȡ�������ҽ�����
        /// </summary>
        /// <param name="BinID">����ID</param>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public long GetYzNum(Guid binID, long deptID)
        {
            string sSql;
            long BaseGroupID = 0;

            sSql = "select max(Group_Id) as YZH from Zy_OrderRecord(nolock) where inpatient_id='" + binID.ToString() + "'";
            BaseGroupID = 1;

            DataTable myTb = database.GetDataTable(sSql);
            if (myTb.Rows[0]["YZH"].ToString().Trim() == "")
            {
                return BaseGroupID;
            }
            else
            {
                return Convert.ToInt32(myTb.Rows[0]["YZH"].ToString());
            }
        }

        /// <summary>
        /// ��ȡ�������ҽ�����
        /// </summary>
        /// <param name=" database">���ݿ���ʶ���</param>
        /// <param name="BinID">����ID</param>
        /// <returns></returns>
        public long GetYzNum(RelationalDatabase _DataAcc, Guid BinID)
        {
            string sSql;
            long BaseGroupID = 0;

            sSql = "select max(Group_Id) as YZH from Zy_OrderRecord where inpatient_id='" + BinID.ToString() + "'";
            BaseGroupID = 1;

            DataTable myTb = database.GetDataTable(sSql);
            if (myTb.Rows[0]["YZH"].ToString().Trim() == "")
            {
                return BaseGroupID;
            }
            else
            {
                return Convert.ToInt32(myTb.Rows[0]["YZH"].ToString());
            }
        }
        #endregion

        #region ͬ���е�ҽ����¼����
        /// <summary>
        /// ͬ���е�ҽ����¼����
        /// </summary>
        /// <param name="BinID">����ID</param>
        /// <param name="BabyID">Ӥ��ID</param>
        /// <param name="DeptID"></param>
        /// <param name="GroupID">ҽ�����</param>
        /// <returns></returns>
        public int GetMaxZYnum(Guid binID, long babyID, long deptID, long groupID)
        {
            string sSql = "select count(*) from zy_orderrecord where delete_bit=0 and (mngtype<2 or mngtype=5) and inpatient_id= '" + binID.ToString() + "' and baby_id=" + babyID.ToString() + " and group_id=" + groupID.ToString() + "";
            int i = Convert.ToInt32(database.GetDataResult(sSql));
            return i;
        }
        #endregion

        #region ȡ������
        //ȡ������
        public DataTable GetContent(long id, Guid inpatientID)
        {
            string sSql = "select id,p_id,name,content from CASE_MAIN_IDX where p_id=" + id + " and inpatient_id='" + inpatientID + "' order by id";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region ȡ�������б�
        //ȡ�������б�
        public DataTable GetContent(long id)
        {
            string sSql = "select id,Content from CASE_MAIN_IDX where id=" + id + " order by id";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region ȡ���в�ҩ�б�
        /// <summary>
        /// ȡ���в�ҩ�б�
        /// </summary>
        /// <param name="inpatientid">����ID</param>
        /// <param name="groupNum">ҽ�����</param>
        /// <returns></returns>
        public DataTable GetMedList(Guid inpatientid, int groupNum)
        {
            string sSql = "select group_id ����,order_bdate ��ʼִ��ʱ��,order_context ҽ������,num ����,unit ��λ,dosage ����," +
                "order_usage �÷�,(select name from jc_employee_property where auditing_user=employee_id) У�Ի�ʿ," +
                "auditing_date У��ʱ��,order_edate ͣ��ʱ��,(select name from jc_employee_property where order_doc=employee_id) ����ҽ��," +
                "dbo.fun_getdeptname(EXEC_DEPT) AS ִ�п���,status_flag from zy_orderrecord " +
                "where  inpatient_id='" + inpatientid + "'  and group_id=" + groupNum + " and ntype=3 and status_flag<>-1 and delete_bit=0";//Modify by zouchihua 2013-3-11 �����ҽ��Ҳ���Կ���  ��ǰstatus_flag<>0 ����status_flag<>-1

            return database.GetDataTable(sSql);
        }
        #endregion

        #region ����ָ������len�Ŀո��ַ���
        /// <summary>
        /// ����ָ������len�Ŀո��ַ���
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public string Repeat_Space(int len)
        {
            string s = "";
            if (len > 0)
            {
                for (int i = 0; i <= len - 1; i++)
                {
                    s += " ";
                }
            }
            return s;
        }
        #endregion

        #region ���뵥���͵�ҽ������
        /// <summary>
        /// ���뵥���͵�ҽ������
        /// </summary>
        /// <param name="_Database">���ݿ���ʶ���</param>
        /// <param name="BinID">����ID</param>
        /// <param name="OrderID">ҽ����¼ID</param>
        /// <returns></returns>
        public int apply(RelationalDatabase _Database, Guid BinID, Guid OrderID, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = BinID;
            parameters[0].Text = "@BINID";
            parameters[1].Value = OrderID;
            parameters[1].Text = "@ORDERID";
            parameters[2].Value = Jgbm;
            parameters[2].Text = "@Jgbm";
            try
            {
                return database.DoCommand("SP_ZYYS_REFER_APP", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region ȡ��ҽ������
        /// <summary>
        /// ȡ��ҽ������
        /// </summary>
        /// <param name="ysID">����ҽ��</param>
        /// <param name="OrderID">ҽ����¼ID</param>
        /// <returns></returns>
        public int DelApply(long ysID, Guid OrderID)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = ysID;
            parameters[0].Text = "@YSID";
            parameters[1].Value = OrderID;
            parameters[1].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_APP", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region ɾ������¼
        /// <summary>
        /// ɾ������¼(ZY_JC_RECORD)
        /// </summary>
        /// <param name="BinID">����ID</param>
        /// <param name="GroupID">ҽ�����</param>
        /// <returns></returns>
        public int DelJCrecord(Guid BinID, long GroupID)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = 1;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = BinID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = Convert.ToInt64(GroupID);
            parameters[2].Text = "@GROUPID";
            parameters[3].Value = Guid.Empty;
            parameters[3].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_JC_JY_RECORD", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region ȡ�������ӡ���¼
        /// <summary>
        /// ȡ�������ӡ���¼ (ZY_JY_PRINT)
        /// </summary>
        /// <param name="OrderID">ҽ����¼ID</param>
        /// <returns></returns>
        public int DelJY(Guid OrderID)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = 2;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = Guid.Empty;
            parameters[1].Text = "@BINID";
            parameters[2].Value = 0;
            parameters[2].Text = "@GROUPID";
            parameters[3].Value = OrderID;
            parameters[3].Text = "@ORDERID";
            try
            {
                deleteLisSqd(OrderID.ToString());//��ɾ��ҽ���Ľӿ����� add by zouchihua 2014-4-27
                return database.DoCommand("SP_ZYYS_DEL_JC_JY_RECORD", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region ɾ����˼�¼
        /// <summary>
        /// ɾ����˼�¼
        /// </summary>
        /// <param name="OrderID">һ����¼ID</param>
        /// <param name="GroupNum">һ��ҽ�����</param>
        /// <param name="InpatientID">����סԺID</param>
        /// <param name="sign">0=ɾһ����¼��1=ɾ��һ��ҽ��</param>
        /// <returns></returns>
        public int DeleKssSh(Guid OrderID, int GroupNum, Guid InpatientID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = InpatientID;
            parameters[0].Text = "@BINID";
            parameters[1].Value = GroupNum;
            parameters[1].Text = "@GROUPID";
            parameters[2].Value = OrderID;
            parameters[2].Text = "@ORDERID";
            parameters[3].Value = sign;
            parameters[3].Text = "@SIGN";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_KSS_SH", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        #endregion

        #region ɾ�����⿹����ǼǼ�¼
        /// <summary>
        /// ɾ��������ǼǼ�¼
        /// </summary>
        /// <param name="GroupNum">һ��ҽ�����</param>
        /// <param name="OrderID">һ����¼ID</param>
        /// <param name="InpatientID">����סԺID</param>
        /// <returns></returns>
        public int DeleKssDj(Guid OrderID, int GroupNum, Guid InpatientID)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = GroupNum;
            parameters[0].Text = "@GROUPID";
            parameters[1].Value = InpatientID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = OrderID;
            parameters[2].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_KSS_SQB", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        #endregion

        #region ɾ����ͨ������ǼǼ�¼
        /// <summary>
        /// ɾ����ͨ������ǼǼ�¼
        /// </summary>
        /// <param name="GroupNum">һ��ҽ�����</param>
        /// <param name="OrderID">һ����¼ID</param>
        /// <param name="InpatientID">����סԺID</param>
        /// <returns></returns>
        public int DelePtKssDj(Guid OrderID, int GroupNum, Guid InpatientID)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = GroupNum;
            parameters[0].Text = "@GROUPID";
            parameters[1].Value = InpatientID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = OrderID;
            parameters[2].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_KSS_DJ", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }

        /// <summary>
        /// ɾ�� ������ҩ �����¼
        /// </summary>
        /// <param name="GroupNum">һ��ҽ�����</param>
        /// <param name="OrderID">һ����¼ID</param>
        /// <param name="InpatientID">����סԺID</param>
        /// <returns></returns>
        public int DeleFzyyApply(Guid OrderID, int GroupNum, Guid InpatientID)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = GroupNum;
            parameters[0].Text = "@GROUPID";
            parameters[1].Value = InpatientID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = OrderID;
            parameters[2].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_Fzyy_sq", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        #endregion

        #region ������������������ӡ��
        /// <summary>
        /// ������������������ӡ��
        /// </summary>
        /// <param name="_Database">���ݿ�����</param>
        /// <param name="BinID">����ID</param>
        /// <param name="BabyID">Ӥ��ID</param>
        /// <param name="OrderID">ҽ��ID</param>
        /// <returns></returns>
        public int insertJY(RelationalDatabase _Database, Guid BinID, long BabyID, Guid OrderID)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = BinID;
            parameters[0].Text = "@BINID";
            parameters[1].Value = OrderID;
            parameters[1].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_INSERT_JY", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region ȡ��Ƥ�Թ���
        /// <summary>
        /// ȡ��Ƥ�Թ���
        /// </summary>
        /// <param name="BinID">����ID</param>
        /// <param name="ps">Ƥ�Զ�Ӧ��</param>
        /// <returns></returns>
        public int DelPS(Guid BinID, Guid ps)
        {
            if (ps == null) return -1;
            return database.DoCommand("update zy_orderrecord set ps_flag=-1,ps_orderid=DBO.FUN_GETEMPTYGUID() where inpatient_id='" + BinID.ToString() + "' and ps_orderid='" + ps + "'");
        }
        #endregion

        #region �����ҩ��Ϣ
        /// <summary>
        /// �����ҩ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewYP()
        {
            return database.GetDataTable("SP_ZYYS_GET_YP_NEW", null, 10);
        }
        #endregion

        #region ���ҩƷ����Ŀ�۸�
        /// <summary>
        /// ���ҩƷ����Ŀ�۸�
        /// </summary>
        /// <param name="num">����</param>
        /// <param name="str">��ĿID ҩƷ=����ID����ҩƷ=ҽ����ĿID</param>
        /// <param name="dwType">��λ����</param>
        /// <param name="deptID">ִ�п���</param>
        /// <param name="sign">0=ҩƷ��1=��Ŀ</param>
        /// <returns></returns>
        public DataTable getJG(decimal num, string str, int dwType, int deptID, int sign, int Jgbm)
        {
            ParameterEx[] parameters;
            try
            {
                if (sign == 1)
                {
                    parameters = new ParameterEx[6];
                    parameters[0].Value = sign;
                    parameters[0].Text = "@SIGN";
                    parameters[1].Value = str;
                    parameters[1].Text = "@XMID";
                    parameters[2].Value = num;
                    parameters[2].Text = "@NUM";
                    parameters[3].Value = dwType;
                    parameters[3].Text = "@DWTYPE";
                    parameters[4].Value = deptID;
                    parameters[4].Text = "@DEPTID";
                    parameters[5].Value = Jgbm;
                    parameters[5].Text = "@Jgbm";
                    return database.GetDataTable("SP_ZYYS_GET_PRICE", parameters, 10);
                }
                else
                {
                    parameters = new ParameterEx[8];
                    parameters[0].Value = dwType > 4 ? 1 : dwType;
                    parameters[0].Text = "@dwtype";
                    parameters[1].Value = num;
                    parameters[1].Text = "@num";
                    parameters[2].Value = 1;
                    parameters[2].Text = "@zxcs";
                    parameters[3].Value = 1;
                    parameters[3].Text = "@jgts";
                    parameters[4].Value = 1;
                    parameters[4].Text = "@ts";
                    parameters[5].Value = str;
                    parameters[5].Text = "@CJID";
                    parameters[6].Value = deptID;
                    parameters[6].Text = "@DEPTID";
                    parameters[7].Value = 0;
                    parameters[7].Text = "@DWBL";
                    return database.GetDataTable("SP_FUN_DW_NUM", parameters, 10);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ���ҽ��ģ������
        /// <summary>
        /// ���ҽ��ģ������
        /// </summary>
        /// <param name="ModelName">ģ������</param>
        /// <param name="DeptID">����ID</param>
        /// <param name="YsID">ҽ��ID</param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public DataTable GetModel(string ModelName, long DeptID, long YsID, int sign)
        {

            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = ModelName;
            parameters[1].Text = "@MODELNAME";
            parameters[2].Value = DeptID;
            parameters[2].Text = "@DEPTID";
            parameters[3].Value = YsID;
            parameters[3].Text = "@YSID";
            try
            {
                return database.GetDataTable("SP_ZYYS_ORDER_MODEL", parameters, 10);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion
        #region ��������ģ�� Add by zouchihua 2011-11-14
        /// <summary>
        /// ��������ģ�� Add by zouchihua 2011-11-14
        /// </summary>
        /// <param name="mbid">ģ��id</param>
        /// <param name="jgbm">��������</param>
        /// <returns></returns>
        public DataTable GetModel(DataTable Mbtabe)
        {
            //DataTable Mbtabe = new DataTable();
            //ParameterEx[] parameters = new ParameterEx[2];
            //parameters[0].Value = mbid;
            //parameters[0].Text = "@MBID";
            //parameters[1].Value = jgbm;
            //parameters[1].Text = "@JGBM";
            try
            {
                // Mbtabe= database.GetDataTable("SP_JC_CFMB_SELECT", parameters, 10);
                //ת��
                string sql = "SELECT  '' as ��ʼʱ��, '' as ����,NTYPE,ORDER_CONTEXT ҽ������,NUM ����,DOSAGE ����,UNIT ��λ,ORDER_USAGE �÷�,FREQUENCY Ƶ��, 0 ����ִ�д���, HOITEM_ID,XMLY,ITEM_CODE,EXEC_DEPT ִ�п���,DWLX ��λ����,(CASE WHEN XMLY=1 THEN (SELECT S_YPGG FROM YP_YPCJD WHERE CJID=HOITEM_ID) ELSE '' END) ���  FROM ZY_ORDERRECORD_MODEL "
                      + "  WHERE 1=2";
                DataTable temptb = database.GetDataTable(sql);
                int flagindex = 0;
                Guid cfxh = Guid.Empty;
                int i = 0;
                SystemCfg cfg7132 = new SystemCfg(7132);
                for (i = 0; i < Mbtabe.Rows.Count; i++)
                {
                    if (Mbtabe.Rows[i]["ѡ��"].ToString() == "1")
                    {

                        int ntype = 0;
                        DataRow dr = temptb.NewRow();
                        string yznr = Mbtabe.Rows[i]["ҽ������"].ToString();
                        dr["ҽ������"] = yznr;// yznr.Substring(0, yznr.IndexOf(' '));
                        if (Mbtabe.Rows[i]["��Ŀ��Դ"].ToString().Trim() == "1")//ΪҩƷ
                        {
                            if (Mbtabe.Rows[i]["cjid"].ToString() == "-1" && Mbtabe.Rows[i]["ִ�п���id"].ToString() == "-1")
                            {
                                //����ҩƷ
                                dr["HOITEM_ID"] = -1;
                                try
                                {
                                    dr["���"] = yznr.Substring(yznr.IndexOf("[") + 1, yznr.IndexOf("]") - yznr.IndexOf("[") - 1);
                                }
                                catch { dr["���"] = ""; }
                                dr["ITEM_CODE"] = -1;
                                dr["NTYPE"] = Mbtabe.Rows[i]["�Ա�ҩ"].ToString();//�������洢ҩƷ������
                            }
                            else
                            {
                                dr["HOITEM_ID"] = Mbtabe.Rows[i]["cjid"];//
                                //ͨ������idѰ��ҩƷ����
                                string ssid = " select N_YPLX,S_YPGG,ggid from YP_YPCJD where CJID=" + Mbtabe.Rows[i]["cjid"].ToString();
                                DataTable tb = database.GetDataTable(ssid);
                                ntype = Convert.ToInt32(tb.Rows[0]["N_YPLX"].ToString());
                                dr["���"] = tb.Rows[0]["S_YPGG"];
                                dr["ITEM_CODE"] = tb.Rows[0]["ggid"];
                                string str = "";
                                if (cfg7132.Config.ToString().Trim() == "")
                                    str = "(0)";
                                else
                                    str = "(0," + cfg7132.Config.ToString() + ")";
                                DataTable tbtb = FrmMdiMain.Database.GetDataTable("select * from YP_YPLX where tjdxm in " + str);

                                if (tbtb.Rows.Count > 0)//�����������ʱ
                                {
                                    dr["NTYPE"] = 3;
                                }
                                else
                                    if (ntype <= 3)
                                        dr["NTYPE"] = ntype;
                                    else
                                    {
                                        DataTable yptj = FrmMdiMain.Database.GetDataTable("select STATITEM_CODE from VI_YP_YPCD where cjid=" + Mbtabe.Rows[i]["cjid"].ToString());
                                        if (yptj.Rows.Count > 0 && yptj.Rows[0]["STATITEM_CODE"].ToString() == "03")
                                            dr["NTYPE"] = 3;
                                        else
                                            dr["NTYPE"] = 1;
                                    }
                            }
                        }
                        else//��Ŀ
                        {
                            if (Mbtabe.Rows[i]["��Ŀ��Դ"].ToString().Trim() == "2")
                            {
                                //�������Ŀ����Ҫ���� Modify by zouchihua 2014-3-27
                                Mbtabe.Rows[i]["cfxh"] = Guid.NewGuid();
                                dr["HOITEM_ID"] = Mbtabe.Rows[i]["��Ŀid"];
                                string ssid = " select a.ORDER_TYPE,b.HDITEM_ID from JC_HOITEMDICTION a left join JC_HOI_HDI b on a.ORDER_ID=b.HOITEM_ID  where order_id=" + Mbtabe.Rows[i]["��Ŀid"].ToString();
                                DataTable tb1 = database.GetDataTable(ssid);
                                if (tb1.Rows.Count > 0)
                                {
                                    ntype = Convert.ToInt32(tb1.Rows[0]["ORDER_TYPE"].ToString());
                                    dr["ITEM_CODE"] = tb1.Rows[0]["HDITEM_ID"];
                                    dr["NTYPE"] = tb1.Rows[0]["ORDER_TYPE"];
                                }
                                else
                                {
                                    ntype = 7;//˵��
                                    dr["ITEM_CODE"] = -1;
                                    dr["NTYPE"] = 7;
                                }
                            }
                            else
                                continue;
                        }
                        string sstype = "SELECT NAME FROM JC_ORDERTYPE WHERE CODE= " + dr["NTYPE"].ToString() + "";
                        DataTable tbtype = FrmMdiMain.Database.GetDataTable(sstype);
                        if (tbtype.Rows.Count > 0)
                            dr["����"] = tbtype.Rows[0]["NAME"];
                        dr["����"] = Mbtabe.Rows[i]["����"];
                        dr["����"] = 1;//Ĭ��Ϊһ
                        dr["��λ"] = Mbtabe.Rows[i]["������λ"];
                        dr["�÷�"] = Mbtabe.Rows[i]["�÷�"];
                        dr["Ƶ��"] = Mbtabe.Rows[i]["Ƶ��"];
                        dr["xmly"] = Mbtabe.Rows[i]["��Ŀ��Դ"];
                        dr["ִ�п���"] = Mbtabe.Rows[i]["ִ�п���id"];
                        dr["��λ����"] = Mbtabe.Rows[i]["dwlx"];
                        //if (Mbtabe.Rows[i]["dwlx"])

                        if (flagindex == 0)
                        {
                            cfxh = new Guid(Mbtabe.Rows[i]["cfxh"].ToString());
                            dr["��ʼʱ��"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {
                            if (cfxh.ToString() == Mbtabe.Rows[i]["cfxh"].ToString())//��ͬ
                            {

                            }
                            else
                            {
                                dr["��ʼʱ��"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString("yyyy-MM-dd HH:mm");
                                cfxh = new Guid(Mbtabe.Rows[i]["cfxh"].ToString());
                            }
                        }
                        dr["����ִ�д���"] = 1;
                        temptb.Rows.Add(dr);
                        flagindex++;

                    }
                }
                return temptb;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion
        #region �ж��Ƿ�Ϊȱҩ
        /// <summary>
        /// �ж��Ƿ�Ϊȱҩ
        /// </summary>
        /// <param name="cjid">����ID</param>
        /// <param name="exec_dept">ҩƷִ�п���</param>
        /// <returns></returns>
        public bool GetQYinfo(int cjid, long exec_dept)
        {
            decimal num = Convert.ToDecimal(database.GetDataResult("Select kcl from YF_KCMX where cjid=" + cjid.ToString() + " and bdelete=0 and deptid=" + exec_dept.ToString()));
            if (num > 0) return false;
            else return true;
        }
        #endregion

        /// <summary>
        /// �õ�ҩƷ�۸�ÿ����ҩ����Ϣ
        /// </summary>
        /// <param name="_cjid">����ID</param>
        /// <param name="_num">ҩƷ����</param>
        /// <param name="_dwlx">��λ����</param>
        /// <param name="_execdeptID">ִ��ҩ�����Ҵ���</param>
        /// <returns></returns>
        public DataTable GetYPInfo(int _cjid, double _num, int _dwlx, long _execdeptID)
        {
            DataTable myTb = new DataTable();
            string sSql = "";

            try
            {
                sSql = "EXEC SP_FUN_DW_NUM " + _dwlx + "," + _num + ",1,1,1," + _cjid + "," + _execdeptID + ",0";
                myTb = database.GetDataTable(sSql);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //�������ݱ����
            return myTb;
        }

        #region ��ȡ��������ʱ��
        /// <summary>
        /// ��ȡ��������ʱ��
        /// </summary>
        /// <param name="BinID">����ID</param>
        /// <returns></returns>
        public DateTime GetSSRQ(Guid BinID)
        {
            DataTable dt = database.GetDataTable("SELECT YXSSRQ FROM ss_arrrecord WHERE sno IN (SELECT sno FROM ss_apprecord WHERE inpatient_id ='" + BinID.ToString() + "' AND bdelete = 0 AND apbj = 1) AND bdelete = 0 AND wcbj = 0 ");
            if (dt.Rows.Count > 0) return Convert.ToDateTime(dt.Rows[0][0].ToString());
            else return Convert.ToDateTime("0001-1-1");
        }
        #endregion

        #region ��ȡ�������ʱ��
        /// <summary>
        /// ��ȡ�������ʱ��
        /// </summary>
        /// <param name="BinID">����ID</param>
        /// <returns></returns>
        public DateTime GetWCRQ(Guid BinID)
        {
            DataTable dt = database.GetDataTable("SELECT MAX(SSENDRQ) AS EXPR1 FROM SS_ARRRECORD WHERE (sno IN (SELECT sno FROM SS_APPRECORD WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND apbj = 1)) AND (bdelete = 0) AND (wcbj = 1)");
            if (dt.Rows.Count > 0) return Convert.ToDateTime(dt.Rows[0][0].ToString());
            else return Convert.ToDateTime("0001-1-1");
        }
        #endregion

        #region ��ȡ��ҩ��λ����
        /// <summary>
        /// ��ȡ��ҩ��λ����
        /// </summary>
        /// <param name="cjid">ҩƷ����ID</param>
        /// <returns></returns>
        public decimal GetDose(string cjid)
        {
            string sSql = "select hlxs from yp_ypggd where ggid=(select ggid from yp_ypcjd where cjid= " + cjid + ")";
            return Convert.ToDecimal(Convertor.IsNull(database.GetDataResult(sSql), "0"));
        }
        #endregion

        #region ��ȡҽ����Ŀ
        /// <summary>
        /// ��ȡҽ����Ŀ
        /// </summary>
        /// <param name="dept_id">ִ�п���</param>
        /// <param name="type">ҽ������</param>
        /// <param name="sign">0=˵��ҽ����1=����ҽ��</param>
        /// <returns></returns>
        public DataTable GetExplain(long dept_id, int type, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = dept_id;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = type;
            parameters[2].Text = "@TYPE";

            try
            {
                return database.GetDataTable("SP_ZYYS_GET_EXPLAIN", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ������ѯ
        /// <summary>
        /// ������ѯ
        /// </summary>
        /// <param name="deptID">����ID</param>
        /// <param name="bDate">��ʼʱ��</param>
        /// <param name="eDate">����ʱ��</param>
        /// <param name="sign">1=δ�������,2=�Ѱ�������,3=��ȡ������,4=���������,5=���������,6=��������,</param>
        /// <returns></returns>
        public DataTable SSapp(long deptID, DateTime bDate, DateTime eDate, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = bDate;
            parameters[2].Text = "@BDATE";
            parameters[3].Value = eDate;
            parameters[3].Text = "@EDATE";
            try
            {
                return database.GetDataTable("SP_ZYYS_SS_QUERY", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ��ȡ�����������
        /// <summary>
        /// ��ȡ�����������
        /// </summary>
        /// <returns></returns>
        public long[] GetSSDept()
        {
            DataTable tempTb = database.GetDataTable("select deptid from ss_dept");
            if (tempTb.Rows.Count == 0) return null;
            long[] dept = new long[tempTb.Rows.Count];
            for (int i = 0; i < tempTb.Rows.Count; i++)
            {
                dept[i] = Convert.ToInt64(tempTb.Rows[i]["deptid"]);
            }
            return dept;
        }
        #endregion

        #region ��ȡ�Ա����������
        /// <summary>
        /// ��ȡ�Ա����������
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <returns></returns>
        public string SexName(Guid inpatient_id)
        {
            object ob = database.GetDataResult("select sex from VI_ZY_VINPATIENT where inpatient_id='" + inpatient_id.ToString() + "'").ToString();
            return ob.ToString();
        }
        #endregion

        #region ��ִ��״̬���Ƿ�ҽ��ִ��
        /// <summary>
        /// ��ִ��״̬���Ƿ�ҽ��ִ��
        /// </summary>
        /// <param name="Orderid">ҽ��ID</param>
        /// <returns></returns>
        public bool OrderFlag(Guid Orderid)
        {
            int flag = Convert.ToInt32(database.GetDataResult("select status_flag from zy_orderrecord where order_id='" + Orderid.ToString() + "' and delete_bit=0"));
            if (flag > 1) return true;
            else return false;
        }
        #endregion

        #region �ж��Ƿ��ǳ�Ժ������״̬
        /// <summary>
        /// �ж��Ƿ��ǳ�Ժ������״̬
        /// </summary>
        /// <param name="inpatientID"></param>
        /// <returns></returns>
        public bool OutFlag(Guid inpatientID)
        {
            int outflag = Convert.ToInt32(database.GetDataResult("select flag from zy_inpatient where inpatient_id='" + inpatientID.ToString() + "' and cancel_bit=0"));
            if (outflag >= 4) return true;
            else return false;
        }
        public bool OutFlag(Guid inpatientID, long BabyID)
        {
            int outflag = Convert.ToInt32(database.GetDataResult("select flag from zy_inpatient_baby where inpatient_id='" + inpatientID.ToString() + "' and baby_id=" + BabyID.ToString() + ""));
            if (outflag >= 4) return true;
            else return false;
        }
        #endregion

        #region �ж�ת��״̬��ȡ��ת��
        /// <summary>
        /// �ж�ת��״̬
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="inpatientID"></param>
        /// <returns></returns>
        public bool TurnFlag(long deptID, Guid inpatientID)
        {
            int turn = Convert.ToInt32(database.GetDataResult("select count(*) from zy_transfer_dept where inpatient_id='" + inpatientID.ToString() + "' and s_dept_id=" + deptID.ToString() + " and cancel_bit=0 and finish_bit=0"));
            if (turn == 1) return true;
            else return false;
        }

        /// <summary>
        /// ȡ��ת��
        /// </summary>
        /// <param name="BinID"></param>
        /// <param name="DeptID"></param>
        /// <param name="YS_ID"></param>
        /// <returns></returns>
        public bool DelTurn(Guid BinID, long DeptID, long YS_ID)
        {
            string er = "";
            database.BeginTransaction();
            try
            {
                database.DoCommand("delete from zy_transfer_dept where finish_bit=0 and inpatient_id='" + BinID.ToString() + "' and s_dept_id=" + DeptID.ToString());//+" and operator="+YS_ID.ToString()+""
                database.DoCommand("update zy_orderrecord set status_flag=2,order_edate = NULL, order_edoc = NULL ,TERMINAL_TIMES=NULL where mngtype=0 and delete_bit=0 and status_flag=3 and inpatient_id='" + BinID.ToString() + "' and dept_id=" + DeptID.ToString() + "");
                database.CommitTransaction();
                MessageBox.Show("ȡ��ת�Ƴɹ���");
                return true;
            }
            catch (System.Exception err)
            {
                database.RollbackTransaction();
                MessageBox.Show("ȡ��ת��ʧ�ܣ�\n" + err.ToString(), "ʧ����ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                er = err.ToString();
                return false;
            }
            finally
            {
                if (er.Trim() == "") SaveLog(DeptID, YS_ID, "ȡ��ת��ҽ��", BinID.ToString(), 0, 41);
                else SaveLog(DeptID, YS_ID, "ȡ��ת��ҽ��ʧ��", BinID.ToString() + "��" + er.Trim(), 1, 41);
            }
        }
        #endregion

        #region ȡ����Ժ������
        /// <summary>
        /// ȡ����Ժ������
        /// </summary>
        /// <param name="BinID"></param>
        /// <param name="DeptID"></param>
        /// <param name="BabyID"></param>
        /// <param name="YS_ID"></param>
        /// <returns></returns>
        public bool DelOut(Guid BinID, long DeptID, long BabyID, long YS_ID)
        {
            string er = "";
            database.BeginTransaction();
            try
            {
                //add by zouchihua 2013-3-13
                SaveAllInpatientLog(BinID, "", "", 10);
                if (BabyID == 0)
                {
                    database.DoCommand("update zy_inpatient set out_mode=null,out_date=null,out_diagnosis=null,out_diagnosis_h=null,flag=3 where inpatient_id='" + BinID.ToString() + "'");
                }
                else
                {
                    database.DoCommand("update zy_inpatient_baby set out_mode=null,out_date=null,out_diagnosis=null,flag=3 where inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + "");
                }

                database.DoCommand("update zy_orderrecord set status_flag=2, order_edate = NULL, order_edoc = NULL,TERMINAL_TIMES=NULL where mngtype=0 and delete_bit=0 and status_flag=3 and inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and dept_id=" + DeptID.ToString() + "");

                //Modify By Tany 2010-05-31 ȡ����ҽ��ͣ���˵�
                database.DoCommand("update zy_orderrecord set status_flag=2, order_edate = NULL, order_edoc = NULL,TERMINAL_TIMES=NULL where mngtype=2 and delete_bit=0 and status_flag=4 and order_edoc=" + YS_ID + " and inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and dept_id=" + DeptID.ToString() + "");

                database.CommitTransaction();
                MessageBox.Show("ȡ���ɹ���");
                return true;
            }
            catch (System.Exception err)
            {
                database.RollbackTransaction();
                MessageBox.Show("ȡ��ʧ�ܣ�\n" + err.ToString(), "ʧ����ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                er = err.ToString();
                return false;
            }
            finally
            {
                if (er.Trim() == "") SaveLog(DeptID, YS_ID, "ȡ����Ժ������ҽ��", "���ˣ�" + BinID.ToString() + "��" + BabyID.ToString() + "", 0, 41);
                else SaveLog(DeptID, YS_ID, "ȡ����Ժ������ʧ��", "���ˣ�" + BinID.ToString() + "��" + BabyID.ToString() + "��" + er.Trim() + "", 1, 41);
            }
        }
        #endregion
        /// <summary>
        /// ���漲�������䣬�Ա�
        /// </summary>
        /// <param name="inpatientid"></param>
        /// <param name="oldjslx"></param>
        /// <param name="oldyblx"></param>
        /// <param name="newjslx"></param>
        /// <param name="newyblx"></param>
        /// <param name="type">0 ���� 1 ���� 2 �Ա�</param>
        private void SaveAllInpatientLog(Guid inpatientid, string oldstr, string newstr, int type)
        {
            try
            {
                string out_time = "";
                if (type == 10)
                {
                    string ss = "select out_date from zy_inpatient(nolock) where inpatient_id='" + inpatientid.ToString() + "'";
                    DataTable temptb = FrmMdiMain.Database.GetDataTable(ss);
                    if (temptb.Rows.Count > 0)
                    {
                        out_time = temptb.Rows[0]["out_date"].ToString();
                    }
                    else
                        return;
                }
                string sql = "insert into ZY_ALLINPATIENT_LOG(INPATIENT_ID, OLD_STR, NEW_STR, TYPE, BOOK_DATE, BOOK_USER, IP, PCNAME)";
                sql += "values ('" + inpatientid + "','" + out_time + "','" + newstr + "'," + type + ",getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",'" + Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString() + "','" + System.Environment.MachineName + "')";
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch (Exception err)
            {
                MessageBox.Show("���没�˵ǼǱ����Ϣʱ����" + err.Message);
            }
        }
        #region ɾ�������¼
        /// <summary>
        /// ɾ�������¼
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="DeptID"></param>
        /// <param name="YS_ID"></param>
        /// <returns></returns>
        public bool DelCon(Guid OrderID, long DeptID, long YS_ID)
        {
            int i;
            string er = "";
            try
            {
                i = database.DoCommand("update ZY_CONSULTATION set FINISH_FLAG=3 where order_id='" + OrderID.ToString() + "'");
                if (i == 1) return true;
                else return false;
            }
            catch (System.Exception err)
            {
                er = err.ToString();
                return false;
            }
            finally
            {
                if (er.Trim() == "") SaveLog(DeptID, YS_ID, " ȡ�������¼", "ҽ��order_id=" + OrderID.ToString(), 0, 41);
                else SaveLog(DeptID, YS_ID, "ȡ������ʧ��", "ҽ��order_id=" + OrderID.ToString(), 1, 41);
            }

        }
        #endregion

        #region ��ȡҽ����Ŀ�۸�
        /// <summary>
        /// ��ȡҽ����Ŀ�۸�
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public decimal GetPrice(long orderID, int Jgbm)
        {
            decimal p = Convert.ToDecimal(database.GetDataResult("select dbo.FUN_ZY_SEEKHOITEMPRICE(" + orderID + "," + Jgbm + ")"));
            return p;
        }
        #endregion

        #region �Ƿ�ΪƤ��ҩƷ����ҩ��
        /// <summary>
        ///�Ƿ�ΪƤ��ҩƷ����ҩ��
        ///</summary>
        public bool PSYP(string CJID)
        {
            int i = Convert.ToInt32(database.GetDataResult(" Select psyp from dbo.VI_YP_YPCD where bdelete=0 and cjid=" + CJID));
            if (i == 1) return true;
            else return false;
        }
        #endregion

        #region ��ȡҩƷ����
        /// <summary>
        /// ��ȡҩƷ����
        ///</summary>
        public DataTable GetYPXL()
        {
            string sSql = "SELECT a.N_XL, a.S_HH, case a.DWHL when 0 then 1 else a.DWHL end DWHL, a.S_SPM,case when a.RELATEUNIT IS NULL then 'g' else a.RELATEUNIT end RELATEUNIT,a.YFBZS " +
                "FROM (SELECT m.n_xl, m.s_hh, m.dwhl, m.s_spm, m.relateunit, m.yfbzs FROM yk_xyd m " +
                "      UNION " +
                "      SELECT n.n_xl, n.s_hh, n.dwhl, n.s_spm, n.relateunit, n.yfbzs FROM yk_cyd n " +
                "      UNION " +
                "      SELECT k.n_xl, k.s_hh, k.dwhl, k.s_spm, k.relateunit, k.yfbzs FROM yk_zyd k) a " +
                "WHERE (a.N_XL <> 0)";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region �Ƿ�Ϊ��ת��ִ�е�ҽ��
        /// <summary>
        /// �Ƿ�Ϊ��ת��ִ�е�ҽ��
        /// </summary>
        public bool ISexecute(Guid OrderID)
        {
            int flag = Convert.ToInt32(database.GetDataResult("select status_flag from zy_orderrecord where order_id='" + OrderID.ToString() + "'"));
            if (flag > 1) return true;
            else return false;
        }
        #endregion

        #region ͨ��Bed_id��ȡ�������ڲ�������
        /// <summary>
        /// ͨ��Bed_id��ȡ�������ڲ�������(Bed_No)
        /// </summary>
        public string GetBedNO(Guid BedID)
        {
            string sSql = "select Bed_NO from zy_beddiction where bed_id='" + BedID.ToString() + "'";
            return Convertor.IsNull(database.GetDataResult(sSql), "");
        }
        #endregion

        #region ͨ��ward_id��ȡ�������ڲ���name
        /// <summary>
        /// ͨ��ward_id��ȡ�������ڲ���name
        /// </summary>
        public string GetWardName(int WardID)
        {
            string str = Convertor.IsNull(database.GetDataResult("select ward_name from jc_ward where ward_id='" + WardID + "'"), "");
            return str;
        }
        #endregion

        #region ͨ��dept_id��ȡ�������ڿ���name
        /// <summary>
        /// ͨ��dept_id��ȡ�������ڿ���name
        /// </summary>
        public string GetDeptName(long DeptID)
        {
            string str = Convertor.IsNull(database.GetDataResult("select name from jc_dept_property where DEPT_ID=" + DeptID.ToString() + ""), "");
            return str.Trim();
        }
        #endregion

        #region ��ȡ�ò��˵Ļ���ҽ��
        /// <summary>
        ///��ȡ�ò��˵Ļ���ҽ��
        /// </summary>
        public DataTable GetConDoc(Guid binID)
        {
            string sSql = "SELECT con_doc ys_id,code ys_code FROM (select * from ZY_CONSULTATION aa left join zy_con_mx bb on aa.id=bb.p_id where aa.inpatient_ID='" + binID + "' and aa.finish_flag<>3) A left join JC_USER B on A.con_doc=B.employee_id order by A.con_date desc";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region ��ȡ����������ҵ�ҽ��
        /// <summary>
        ///��ȡ����������ҵ�ҽ��
        /// </summary>
        public DataTable GetConDeptDoc(Guid binID)
        {
            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Value = binID;
            parameters[0].Text = "@BINID";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_CON_EMP", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ��ȡ���Ｖ��ҽ����Ŀ��
        /// <summary>
        /// ��ȡ���Ｖ��ҽ����Ŀ��
        /// </summary>
        /// <returns></returns>
        public DataTable GetConLevel()
        {
            //string sSql = "select order_id ID,order_name NAME, case when order_name like '%Ժ�ڻ���%' then 0 else 1 end level_type from jc_hoitemdiction where order_name not like '%��%����%' and delete_bit=0 and order_name like '%����%' and order_type=4";
            //Modify by jchl
            //Modify By tany 2015-05-26 ���ӱ����������ˣ�����ѡ���������4,8,9
            string sSql = "select *,order_id ID,order_name NAME, case when order_name like '%Ժ�ڻ���%' or order_name like '%����%' then 0 else 1 end level_type from jc_hoitemdiction where  delete_bit=0 and order_name like '%����%' and order_type in (4,8,9)";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region ��ȡ����������
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <param name="con_ID">����ID</param>
        /// <returns></returns>
        public DataTable GetConOutcome(Guid con_ID)
        {
            string sSql = "select p_id,dbo.FUN_ZY_SEEKDEPTNAME(con_dept) con_deptname,dbo.FUN_ZY_SEEKEMPLOYEENAME(con_doc) con_docname,con_dept,con_doc,con_date,content,accept_doc,accept_date from zy_con_mx where p_id='" + con_ID.ToString() + "' ";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region ��˻���ջ�������
        /// <summary>
        /// ��˻���ջ�������
        /// </summary>
        /// <param name="con_ID">��������ID</param>
        /// <param name="deptID">����ID</param>
        /// <param name="docID">ҽ��ID</param>
        /// <param name="sign">"���"��"����"</param>
        /// <returns></returns>
        public int SetConFlag(Guid con_ID, long deptID, long docID, string sign)
        {
            string sSql = "";
            switch (sign)
            {
                case "���":
                    sSql = "update ZY_CONSULTATION set finish_flag=1 where id='" + con_ID.ToString() + "'";
                    break;
                case "����":
                    sSql = "update zy_con_mx set accept_doc=" + docID + ",accept_date=GetDate() where p_id='" + con_ID + "' and con_dept=" + deptID + "";
                    break;
                default:
                    return -1;
            }
            return database.DoCommand(sSql);
        }
        #endregion

        #region ͨ�����Ż�ȡ����
        /// <summary>
        /// ͨ�����Ż�ȡ����
        /// </summary>
        public string GetDocPW(string code)
        {
            string sSql = "select password from JC_user where code='" + code + "'";
            DataTable tb = database.GetDataTable(sSql);

            if (tb.Rows.Count > 0) return tb.Rows[0][0].ToString();
            else return "��";
        }
        #endregion

        #region ����ҽ���÷�
        /// <summary>
        ///����ҽ���÷�
        /// </summary>
        public void ChangeUsage(Guid BinID, long BabyID, long GroupID, string str)
        {
            string sSql = "update zy_orderrecord set order_usage='" + str + "' where inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and group_id=" + GroupID.ToString() + " and delete_bit=0";
            database.DoCommand(sSql);
        }
        #endregion

        #region ����ҽ��ҩƷ
        /// <summary>
        ///����ҽ��ҩƷ
        /// </summary>
        public int ChangeItem(Guid orderID, string Context, string hh)
        {
            string sSql = "update zy_orderrecord set order_context='" + Context + "',item_code='" + hh + "' where order_id='" + orderID.ToString() + "'";
            try
            {
                return database.DoCommand(sSql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region ͨ��Ƶ�ʻ�ȡÿ������ִ�д���
        /// <summary>
        ///ͨ��Ƶ�ʻ�ȡÿ������ִ�д���
        ///</summary>
        public int GetexecNum(string FF)
        {
            string sSql = "select execnum  ��ִ�д��� from JC_Frequency where upper(name)='" + FF.Trim().ToUpper() + "'";

            return Convert.ToInt32(database.GetDataResult(sSql));
        }
        #endregion

        #region �Ƿ����ѱ���δ���͵�ҽ��
        /// <summary>
        /// �Ƿ����ѱ���δ���͵�ҽ��
        ///</summary>
        public bool IsNotSend(Guid BinID, long BabyID)
        {
            string sSql = "select count(*) from zy_orderrecord where inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and dept_id=" + FrmMdiMain.CurrentDept.DeptId + " and status_flag=0 and delete_bit=0";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        #region �Ƿ���δת����ҽ��
        /// <summary>
        /// �Ƿ���δת����ҽ��
        ///</summary>
        public bool IsNotExec(Guid BinID, long BabyID)
        {
            //Modify by zouchihua 
            string sSql = "select count(*) from zy_orderrecord where inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and status_flag=1 and delete_bit=0";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        #region �жϸò����Ƿ�������˵���������
        /// <summary>
        /// �жϸò����Ƿ�������˵���������
        ///</summary>
        public bool IsSSapp(Guid BinID, long BabyID)
        {
            //Modify By Tany 2015-04-25 ����������Ҫ�󣬲���֤
            //return false; Modify By Tany 2015-05-11 ������ɷ�ʽ��������֤
            //Modify By Tany 2015-06-03 �ٴθ���������OAҪ�󣬲���֤
            return false;

            string sSql = "select count(*) FROM SS_APPRECORD WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND (shbj = 1 or jzss=1) and apbj = 0 ";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        #region �жϸò����Ƿ����Ѱ��ŵ���������
        /// <summary>
        /// �жϸò����Ƿ����Ѱ��ŵ���������
        ///</summary>
        public bool IsSSarr(Guid BinID, long BabyID)
        {
            //Modify By Tany 2015-04-25 ����������Ҫ�󣬲���֤
            //return false; Modify By Tany 2015-05-11 ������ɷ�ʽ��������֤
            //Modify By Tany 2015-06-03 �ٴθ���������OAҪ�󣬲���֤
            return false;

            string sSql = "select count(*) FROM SS_ARRRECORD WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND wcbj = 0 ";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        #region �жϸò����Ƿ����Ѱ���δ��ɵ���������
        //Add By Tany 2015-04-08
        /// <summary>
        /// �жϸò����Ƿ����Ѱ���δ��ɵ���������
        ///</summary>
        public bool IsMZarr(Guid BinID, long BabyID)
        {
            return false;//Modify By Tany 2015-06-15 ������֤�����������Ҫ��
            //Modify By Tany 2015-04-23
            //�������֤�����߼�
            //�������û����ɣ���������ʽ��Ϊ�ջ򡰾��顱������Ҫ��֤���ñ��Ƿ�������ƿ����ķ��ã�������У�û������ʾ

            //Modify By Tany 2015-04-27 Ӥ�����ж�
            if (BabyID > 0)
            {
                return false;
            }

            bool isWwc = true;
            string sSql = "select * FROM SS_ARRRECORD a left join SS_ANESTHESIACODE b on a.YSMZ=b.ID WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND mzwcbj = 0 ";
            DataTable arrTb = database.GetDataTable(sSql);
            if (arrTb == null || arrTb.Rows.Count == 0)
            {
                isWwc = false;
            }
            else
            {
                string mz = Convertor.IsNull(arrTb.Rows[0]["name"], "");
                //Modify By Tany 2015-04-27 �ò���������Щ������Ҫ��֤����
                SystemCfg cfg9100 = new SystemCfg(9100);
                //if (mz != "" && mz != "����")
                if (mz != "" && !cfg9100.Config.Contains(mz))
                {
                    //��֤���ã����û������ʾ����
                    sSql = "select count(1) from zy_fee_speci where inpatient_id = '" + BinID.ToString() + "' and baby_id=" + BabyID + " and delete_bit=0 and dept_id in (select deptid from ss_dept where type=1)";
                    int i = Convert.ToInt32(database.GetDataResult(sSql));
                    if (i == 0)
                    {
                        isWwc = true;
                        MessageBox.Show("�ò���������ʽΪ��" + mz + "��������δ��ɣ������ڲ��˵ķ�����δ�ҵ��κ�����Ƽ��˵ķ��ã�����ϵ�����ȷ�ϣ�");
                    }
                    else
                    {
                        isWwc = false;
                    }
                }
                else
                {
                    isWwc = false;
                }
            }

            return isWwc;
        }
        #endregion

        #region �жϸò����Ƿ�����������
        /// <summary>
        /// �жϸò����Ƿ�����������
        /// </summary>
        public bool IsSSapply(Guid BinID, long BabyID)
        {
            //3��֮���Ƿ�����������
            string sSql = "select count(*) FROM SS_APPRECORD WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND (shbj = 1 or jzss=1) and sqdjrq> DATEADD(dd,-3,GetDate()) ";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        /// <summary>
        /// �����б�ҩ��ͣ�õ�ҩƷ
        /// </summary>summary>
        //		public DataTable StopYP(long BinID,long BabyID)
        //		{ 
        //			string sSql="SELECT A.order_id, A.order_doc,A.item_code, A.order_context "+
        //				"FROM (SELECT * FROM ZY_ORDERRECORD WHERE (ntype IN (1, 2, 3)) AND (MNGTYPE = 0) AND (Inpatient_ID ="+BinID.ToString()+") AND (Baby_ID ="+BabyID.ToString()+") AND (delete_bit = 0) AND (Status_Flag = 2)) "+
        //				"      A INNER JOIN mzyf_kcmx B  "+
        //				"      ON A.ITEM_CODE = B.s_hh AND B.deptid IN (42, 43, 44) AND B.B_clear = 1 ";
        //			return  database.GetDataTable(sSql);
        //		}

        #region ��ҩƷ�Ƿ�ҩ��ͣ��
        /// <summary>
        /// ��ҩƷ�Ƿ�ҩ��ͣ��
        /// </summary>
        /// <param name="YPcode">ҩƷ����</param>
        /// <param name="execDept">ҩƷִ�п���</param>
        /// <returns></returns>
        public bool StopYP(string cjid, string execDept)
        {
            string sSql = "SELECT count(*) FROM yf_kcmx WHERE cjid = " + cjid + " AND deptid=" + execDept + " and bdelete=0";
            int yp = Convert.ToInt32(database.GetDataResult(sSql));
            if (yp == 0) return true;
            else return false;
        }
        #endregion

        #region ��ȡ����
        /// <summary>
        /// ��ȡ����
        ///</summary>
        ///<param name="sign">0=������ң�1=������,2=���ƿ���,3=�������</param>
        ///<returns>table</returns>
        public DataTable GetDept(int sign, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = Jgbm;
            parameters[1].Text = "@Jgbm";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_DEPT", parameters, 0);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ͨ����Ŀ���ͣ�����ң���ȡ��Ŀ
        /// <summary>
        /// ͨ����Ŀ���ͣ�����ң���ȡ��Ŀ
        ///</summary>
        ///<param name="deptID">����ID</param>
        ///<param name="itemClass">��Ŀ����ID/param>
        ///<param name="sign">0=������Ŀ��1=������Ŀ ��2=�����Ŀ,5=�걾</param>
        public DataTable GetItem(long deptID, short itemClass, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = itemClass;
            parameters[2].Text = "@TYPE";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_ITEM", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        //add by jchl 
        /// <summary>
        /// ͨ����Ŀ���ͣ�����ң���ȡ��Ŀ(Modify by jchl���Ӳ���MyDept�����˱�����Ȩ��)
        ///</summary>
        ///<param name="deptID">����ID</param>
        ///<param name="itemClass">��Ŀ����ID/param>
        ///<param name="sign">0=������Ŀ��1=������Ŀ ��2=�����Ŀ,5=�걾</param>
        public DataTable GetItem(long deptID, short itemClass, int sign, long MyDept)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = itemClass;
            parameters[2].Text = "@TYPE";
            parameters[3].Value = MyDept;
            parameters[3].Text = "@MyDept";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_ITEM_JCHL", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        #endregion

        #region ��ȡ���˵ļ��顢���ҽ��
        /// <summary>
        /// ��ȡ���˵ļ��顢���ҽ��
        ///</summary>
        ///<param name="binID">����ID</param>
        ///<param name="sign">0=����ҽ����1=���ҽ��</param>
        public DataTable GetItemOrders(Guid binID, int sign, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = binID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = Jgbm;
            parameters[2].Text = "@Jgbm";
            try
            {
                return database.GetDataTable("SP_ZYYS_SHOW_ORDERS", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ��ȡ���鱨��
        /// <summary>
        /// ��ȡ���鱨��
        /// </summary>
        /// <param name="orderID">ҽ��ID</param>
        /// <param name="binID">����ID</param>
        /// <returns></returns>
        public DataTable GetReport(Guid orderID, Guid binID)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = orderID;
            parameters[0].Text = "";
            parameters[1].Value = binID;
            parameters[1].Text = "";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_LISREPORT", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show("���ڽ����С�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }
        }
        #endregion

        #region ��ȡ��������
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="sign">1=�����������(����û��˷��͵�)��2=������������ģ�3=�����������룬δ��ɵ�</param>
        /// <param name="deptID">����ID</param>
        /// <param name="bdate">��ѯ��ʼ����</param>
        /// <param name="edate">��ѯ��������</param>
        /// <returns></returns>
        public DataTable GetConApp(int sign, long deptID, DateTime bdate, DateTime edate)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = bdate.Date;
            parameters[2].Text = "@BDATE";
            parameters[3].Value = edate.Date;
            parameters[3].Text = "@EDATE";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_CON", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ��ȡ����ͳ��
        /// <summary>
        /// ��ȡ����ͳ��
        /// </summary>
        /// <param name="sign">1=��������ͳ�ƣ�2=��Ժ���˷���ͳ�ƣ�3=��������Ժ���˷���ͳ�ƣ�4=��Ŀ������ϸ(û��)��5=��Ŀ������ϸ��6=��Ժ���˷���ͳ��(������ʷ��) </param>
        /// <param name="deptID">����ID</param>
        /// <param name="ysID">ҽ��ID</param>
        /// <param name="bdate">��ʼʱ��</param>
        /// <param name="edate">����ʱ��</param>
        /// <returns></returns>
        public DataTable GetStat(int sign, long deptID, long ysID, DateTime bdate, DateTime edate)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Value = sign;
            parameters[0].Text = "@SELTYPE";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = ysID;
            parameters[2].Text = "@YSID";
            parameters[3].Value = bdate;
            parameters[3].Text = "@BDATE";
            parameters[4].Value = edate;
            parameters[4].Text = "@EDATE";
            try
            {
                return database.GetDataTable("SP_ZYYS_FEE_STAT", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region ��ȡ���˷�����ϸ
        /// <summary>
        /// ��ȡ���˷�����ϸ
        /// </summary>
        /// <param name="binID">����ID</param>
        /// <param name="beginDate">��ѯ��ʼ����</param>
        /// <param name="endDate">��ѯ��������</param>
        /// <param name="flag">����״̬��1=���� 0=δ����</param>
        /// <returns></returns>
        public DataTable GetBinFee(Guid binID, string beginDate, string endDate, int flag)
        {
            string sSql = "SELECT  ��Ŀ���, ��Ŀ����,��Ŀ����, ���, ��λ,dbo.FUN_ZY_CHGDECIMALTOCHAR(����) ����, dbo.FUN_ZY_CHGDECIMALTOCHAR(����) ����,���, (rtrim(DATEPART(mm,b.presc_date)) + '-' + rtrim(DATEPART(dd,b.presc_date))) AS ִ������,dbo.FUN_ZY_SEEKEMPLOYEENAME(������)������," +
            "	 (case cz_flag when 1 then '�������' when 2 then '���ʷ���' else '' end) AS ��������,dbo.FUN_ZY_SEEKDEPTNAME(ִ�п���) ִ�п���, dbo.FUN_ZY_SEEKDEPTNAME(���˿���) ���˿���,code " +
            "FROM (" +
            "			SELECT NSITEM_CODE AS ��Ŀ���, ��Ŀ���� , b1.Item_Name AS ��Ŀ����, '' ���,UNIT AS ��λ, retail_Price AS ����,NUM AS ����, ACVALUE AS ���,charge_date,������,cz_flag, execdept_id AS ִ�п���,DEPT_ID AS ���˿���,code,prescription_id,1 as kk" +
            "			FROM(" +
            "					SELECT xmly,xmid,unit,retail_Price,num,acValue,SUBCODE,charge_date,charge_user AS ������,cz_flag,execdept_id, prescription_id,DEPT_ID, c.code, c.��Ŀ���� " +
            "					FROM ZY_Fee_speci a " +
            "					LEFT JOIN jc_stat_item b ON a.statitem_code = b.code " +
            "					LEFT JOIN ( " +
            "									SELECT code, item_name AS ��Ŀ���� FROM jc_zyfp_xm" +
            "							  ) AS c ON c.code = b.zyfp_code" +
            "					WHERE xmly=2 AND  delete_bit = 0 AND " +
            "						inpatient_id ='" + binID + "' AND baby_id = 0 AND a.charge_bit =" + flag.ToString() + " AND a.charge_date BETWEEN '" + beginDate + "' AND '" + endDate + "' " +
            "				) AS A1 " +
            "			INNER JOIN (SELECT Item_Name, Item_ID, NSitem_ID FROM JC_HSItemDiction where jgbm=" + FrmMdiMain.Jgbm + ") AS B1 ON A1.xmid = B1.Item_ID " +
            "			LEFT JOIN (SELECT NATION_CODE AS NSITEM_CODE, ITEM_ID FROM JC_NSITEMDICTION) AS B3 ON B1.Item_ID = B3.ITEM_ID " +

            "			UNION ALL " +

            "			SELECT B1.SUBCODE AS ��Ŀ���,��Ŀ����, S_YPSPM AS ��Ŀ����, S_YPGG AS ���, unit AS ��λ,retail_Price AS ����,num AS ����, ACVALUE AS ���, charge_date,������, cz_flag,execdept_id AS ִ�п���, DEPT_ID AS ���˿���,code,prescription_id,2 as kk " +
            "			FROM (" +
            "					SELECT xmly,xmid,SUBCODE, unit,retail_Price, num, acValue,charge_date,charge_user AS ������,cz_flag, execdept_id, prescription_id, DEPT_ID,'0' AS code,'��ҩ��' AS ��Ŀ���� " +
            "					FROM ZY_Fee_speci a WHERE xmly=1 and statitem_code='01' and  delete_bit = 0 AND inpatient_id = '" + binID + "' AND baby_id = 0  AND a.charge_bit =" + flag.ToString() + " AND  a.charge_date BETWEEN '" + beginDate + "' AND '" + endDate + "' " +
            "				 ) AS B1 " +
            "			INNER JOIN (" +
            "							SELECT S_YPGG, S_YPSPM, SHH,cjid FROM YP_YPCJD " +
            "						) AS B2 ON b1.xmid=b2.cjid  " +

            "			UNION ALL " +

            "			SELECT B1.SUBCODE AS ��Ŀ���,��Ŀ����, S_YPSPM AS ��Ŀ����, S_YPGG AS ���, unit AS ��λ, retail_Price AS ����, num AS ����,ACVALUE AS ���, charge_date, ������, cz_flag,execdept_id AS ִ�п���, DEPT_ID AS ���˿���, code,prescription_id,3 as kk " +
            "			FROM (" +
            "					SELECT xmly,xmid,SUBCODE,unit, retail_Price,num,acValue,charge_date,charge_user AS ������,cz_flag, execdept_id, prescription_id, DEPT_ID, '2' AS code,'�г�ҩ' AS ��Ŀ���� " +
            "					FROM ZY_Fee_speci a " +
            "					WHERE xmly=1 and statitem_code='02' and  delete_bit = 0 AND inpatient_id ='" + binID + "' AND baby_id = 0 AND " +
            "					a.charge_bit =" + flag.ToString() + " AND a.charge_date BETWEEN '" + beginDate + "' AND '" + endDate + "' " +
            "				 ) AS B1 " +
            "			INNER JOIN (" +
            "							SELECT S_YPGG,S_YPSPM,SHH,cjid FROM YP_YPCJD " +
            "						) AS B2 ON  B1.xmid = B2.cjid " +

            "			UNION ALL " +

            "			SELECT B1.SUBCODE AS ��Ŀ���,��Ŀ����, S_YPSPM AS ��Ŀ����, S_YPGG AS ���,(rtrim(char(dosage)) + unit) AS ��λ , retail_Price AS ����,num AS ����,ACVALUE AS ���,charge_date,������,cz_flag,execdept_id AS ִ�п���, DEPT_ID AS ���˿���,code,prescription_id,4 AS kk " +
            "			FROM (" +
            "						SELECT xmly,xmid,SUBCODE,unit,retail_Price,num, dosage,acValue,charge_date,charge_user AS ������,cz_flag,execdept_id,prescription_id,DEPT_ID,'1' AS code,'��ҩ��' AS ��Ŀ���� " +
            "						FROM ZY_Fee_speci a " +
            "						WHERE xmly=1  and statitem_code='03'  AND delete_bit = 0 AND inpatient_id ='" + binID + "' AND baby_id = 0 AND " +
            "						a.charge_bit =" + flag.ToString() + " AND a.charge_date BETWEEN '" + beginDate + "' AND '" + endDate + "' " +
            "				  ) AS B1 INNER JOIN (" +
            "											SELECT S_YPGG,S_YPSPM,SHH,cjid FROM YP_YPCJD" +
            "									 ) AS B2 ON B1.xmid = B2.cjid" +
            "	 ) AS TMP " +
            "	INNER JOIN zy_prescription b ON tmp.prescription_id = b.id " +
            "	ORDER BY code, ��Ŀ���, charge_date";

            return database.GetDataTable(sSql, 180);
        }
        #endregion

        #region ��ȡ��Ϣ
        /// <summary>
        /// ��ȡ��Ϣ
        ///</summary>
        public DataTable GetMessage(long deptID)
        {
            string sSql = "SELECT A.Title ����, Content ����, Bdate ����ʱ��, edate ����ʱ�� FROM ZY_MESSAGE A INNER JOIN ZY_MESSAGE_DEPT B ON B.P_ID = A.ID AND mtype in (0,2) AND bdate<CURRENT TIMESTAMP AND edate >CURRENT TIMESTAMP " +
                " WHERE B.dept_id = 0 OR B.dept_id = " + deptID.ToString() + " and level=1" +//ֻ��ʾϵͳ����Ϣ Modify By Tany 2005-03-14
                " order by A.ID";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region ����ҽ����Ϣ
        /// <summary>
        /// ����ҽ����Ϣ
        ///</summary>
        public void sendMessage(Guid BinID, long YS_ID, long DeptID, string content)
        {
            database.BeginTransaction();
            try
            {
                string sSql = "select";
                sSql = "insert into mz_message (bdate,edate,title,content,book_user,book_date,mtype,sdept_ID,xtype) " +
                    "values(GetDate(),dateadd(hh,1,getdate()),'" + "����ҽ��" + "'," +
                    "(SELECT bed_no + '�� ' + rtrim(name) + ' ���µ�" + content.Trim() + "' AA FROM VI_ZY_VINPATIENT_BED WHERE inpatient_id='" + BinID.ToString() + "')" +
                    "," + YS_ID.ToString() + ",GetDate(),1," + DeptID.ToString() + ",0)";
                database.DoCommand(sSql);

                long ID = Convert.ToInt64(database.GetDataResult("SELECT IDENT_CURRENT('mz_message')"));

                string sSql1 = "insert into mz_message_dept (P_ID,dept_id) values (" + ID.ToString() + "," + DeptID.ToString() + ")";
                database.DoCommand(sSql1);

                database.CommitTransaction();
            }
            catch
            {
                database.RollbackTransaction();
                MessageBox.Show("��Ϣ����ʧ�ܣ�");
            }
        }
        #endregion

        #region ������Ϣ
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="BinID">����id</param>
        /// <param name="YS_ID">����Ϣҽ��id</param>
        /// <param name="sDeptID">����Ϣ����</param>
        /// <param name="DeptID">Ŀ�Ŀ���</param>
        /// <param name="title">��Ϣ����</param>
        /// <param name="content">��Ϣ����</param>
        /// <param name="mtype">��Ϣ����</param>
        /// <param name="hours">��Ϣ����ʱ��(Сʱ)</param>
        //public void sendMessage(Guid BinID, long YS_ID, long sDeptID, long DeptID, string title, string content, int mtype, int hours)
        //{
        //    return;
        //    database.BeginTransaction();
        //    try
        //    {
        //        string sSql = "insert into mz_message (bdate,edate,title,content,book_user,book_date,mtype,sdept_ID) " +
        //            "values(GetDate(),dateadd(hh," + hours.ToString() + ",getdate()),'" + title + "','" + content.Trim() + "'," + YS_ID.ToString() +
        //            ",GetDate()," + mtype.ToString() + "," + sDeptID.ToString() + " )";
        //        database.DoCommand(sSql);

        //        long ID = Convert.ToInt64(database.GetDataResult("SELECT IDENT_CURRENT('mz_message')"));

        //        string sSql1 = "insert into zy_message_dept (P_ID,dept_id) values (" + ID.ToString() + "," + DeptID.ToString() + ")";
        //        database.DoCommand(sSql1);

        //        database.CommitTransaction();
        //    }
        //    catch
        //    {
        //        database.RollbackTransaction();
        //        MessageBox.Show("��Ϣ����ʧ�ܣ�");
        //    }
        //}

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="BinID">����id</param>
        /// <param name="YS_ID">����Ϣҽ��id</param>
        /// <param name="sDeptID">����Ϣ����</param>
        /// <param name="DeptID">Ŀ�Ŀ��Ҽ���</param>
        /// <param name="title">��Ϣ����</param>
        /// <param name="content">��Ϣ����</param>
        /// <param name="mtype">��Ϣ����</param>
        /// <param name="hours">��Ϣ����ʱ��(Сʱ)</param>
        //public void sendMessage(Guid BinID, long YS_ID, long sDeptID, long[] DeptID, string title, string content, int mtype, int hours)
        //{
        //    return;
        //    database.BeginTransaction();
        //    try
        //    {
        //        string sSql = "insert into mz_message (bdate,edate,title,content,book_user,book_date,mtype,sdept_ID) " +
        //            "values(GetDate(),dateadd(hh," + hours.ToString() + ",getdate()),'" + title + "','" + content.Trim() + "'," + YS_ID.ToString() +
        //            ",GetDate()," + mtype.ToString() + "," + sDeptID.ToString() + " )";

        //        database.DoCommand(sSql);

        //        long ID = Convert.ToInt64(database.GetDataResult("SELECT IDENT_CURRENT('mz_message')"));
        //        for (int i = 0; i < DeptID.Length; i++)
        //        {
        //            string sSql1 = "insert into mz_message_dept (P_ID,dept_id) values (" + ID.ToString() + "," + DeptID[i].ToString() + ")";
        //            database.DoCommand(sSql1);
        //        }

        //        database.CommitTransaction();
        //    }
        //    catch
        //    {
        //        database.RollbackTransaction();
        //        MessageBox.Show("������Ϣ����ʧ�ܣ�");
        //    }
        //}
        #endregion

        #region �ύ�������
        /// <summary>
        /// �ύ�������
        /// </summary>
        /// <param name="conID">��������ID</param>
        /// <param name="docID">����ҽ��ID</param>
        /// <param name="deptID">�������ID</param>
        /// <param name="notion">�����������</param>
        /// <returns></returns>
        public int CommitConNotion(Guid conID, long docID, long deptID, string notion)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Value = conID;
            parameters[0].Text = "@CON_ID";
            parameters[1].Value = docID;
            parameters[1].Text = "@DOC_ID";
            parameters[2].Value = deptID;
            parameters[2].Text = "@DEPT_ID";
            parameters[3].Value = notion;
            parameters[3].Text = "@CONTENT";
            parameters[4].Value = "";
            parameters[4].Text = "@ERR";
            parameters[4].ParaDirection = ParameterDirection.Output;
            parameters[4].ParaSize = 2;

            database.DoCommand("SP_ZYYS_CHANGE_CON", parameters, 20);
            return Convert.ToInt16(parameters[4].Value);
        }
        #endregion

        #region �ʵ�¼�벡��ҽ����ѯ
        /// <summary>
        /// �ʵ�¼�벡��ҽ����ѯ
        /// </summary>
        /// <param name="sSql"></param>
        /// <param name="BinID">����ID</param>
        /// <param name="BabyID">Ӥ��ID</param>
        /// <param name="SelType">ҽ������ 0=�����������ʵ� 1=��������ʱ�ʵ�</param>
        /// <param name="SelKind">���� 0=��Ч 1=���� 2=����δ���͵�ҽ��</param>
        /// <param name="Doc"></param>
        /// <param name="ExecDate">ִ��ʱ��</param>
        /// <param name="ward_id">����ID</param>
        /// <returns></returns>
        public DataTable GetBinOrdrss(string sSql, Guid BinID, long BabyID, int SelType, int SelKind, long Doc, DateTime ExecDate, string ward_id)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[7];

            sSql = "sp_zyhs_orders_select";
            parameters[0].Value = BinID;
            parameters[0].Text = "@binid";
            parameters[1].Value = BabyID;
            parameters[1].Text = "@babyid";
            parameters[2].Value = SelType;
            parameters[2].Text = "@seltype";
            parameters[3].Value = SelKind;
            parameters[3].Text = "@selkind";
            parameters[4].Value = Doc;
            parameters[4].Text = "@doc";
            parameters[5].Value = ExecDate;
            parameters[5].Text = "@execdate";
            parameters[6].Value = ward_id;
            parameters[6].Text = "@wardid";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //�������ݱ����
            return myTb;
        }
        #endregion

        #region ��ѯҽ����Ŀ����Ϣ
        /// <summary>
        /// ��ѯҽ����Ŀ����Ϣ
        /// </summary>
        /// <param name="sSql"></param>
        /// <param name="HOitemID">ҽ����ĿID</param>
        /// <param name="num">����</param>
        /// <param name="Use_Name">�÷�</param>
        /// <returns></returns>
        public DataTable SetItemInfo(string sSql, long HOitemID, double num, string Use_Name, int Jgbm)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[4];

            sSql = "sp_zyhs_order_getfee";
            parameters[0].Value = HOitemID;
            parameters[0].Text = "@hoitemid";
            parameters[1].Value = num;
            parameters[1].Text = "@num";
            parameters[2].Value = Use_Name;
            parameters[2].Text = "@use_name";
            parameters[3].Value = Jgbm;
            parameters[3].Text = "@Jgbm";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //�������ݱ����
            return myTb;
        }
        #endregion

        #region �����ݽ������������
        /// <summary>
        /// �����ݽ�����ҽ��
        /// </summary>
        /// <param name="_Database">���ݿ������</param>
        /// <param name="inpatientID">����ID</param>
        /// <param name="babyID">Ӥ��ID</param>
        /// <param name="wardID">����ID</param>
        /// <param name="deptBR">����ID</param>
        /// <param name="deptID">����ID</param>
        /// <param name="applyDOC">����ҽ��</param>
        /// <param name="applyTime">����ʱ��</param>
        /// <param name="content">���˲�ʷ���������</param>
        /// <param name="intent">��������</param>
        /// <param name="orderID"></param>
        /// <param name="finishFlag">����״̬</param>
        /// <param name="conClass"></param>
        /// <param name="conDept">���뵽����Ŀ���</param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public string CommitConApply(RelationalDatabase _Database, Guid inpatientID, long babyID, string wardID, long deptBR, long deptID, long applyDOC, DateTime applyTime,
                                     string content, string intent, Guid orderID, short finishFlag, short conClass, long conDept, short flag, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[16];
            parameters[0].Value = inpatientID;
            parameters[0].Text = "@INPATIENT_ID";
            parameters[1].Value = babyID;
            parameters[1].Text = "@BABY_ID";
            parameters[2].Value = wardID;
            parameters[2].Text = "@WARD_ID";
            parameters[3].Value = deptBR;
            parameters[3].Text = "@DEPT_BR";
            parameters[4].Value = deptID;
            parameters[4].Text = "@DEPT_ID";
            parameters[5].Value = applyDOC;
            parameters[5].Text = "@APPLY_DOC";
            parameters[6].Value = applyTime;
            parameters[6].Text = "@APPLY_DATE";
            parameters[7].Value = content;
            parameters[7].Text = "@CONTENT";
            parameters[8].Value = intent;
            parameters[8].Text = "@INTENT";
            parameters[9].Value = orderID;
            parameters[9].Text = "@ORDER_ID";
            parameters[10].Value = finishFlag;
            parameters[10].Text = "@FINISH_FLAG";
            parameters[11].Value = conClass;
            parameters[11].Text = "@LEVEL";
            parameters[12].Value = conDept;
            parameters[12].Text = "@CON_DEPT";
            parameters[13].Value = flag;
            parameters[13].Text = "@FLAG";
            parameters[14].Text = "@OUT_MSG";
            parameters[14].Value = "";
            parameters[14].ParaDirection = ParameterDirection.Output;
            parameters[14].ParaSize = 100;
            parameters[15].Value = Jgbm;
            parameters[15].Text = "@Jgbm";

            database.DoCommand("SP_ZYYS_CON_APPLY", parameters, 30);
            return parameters[14].Value.ToString();
        }
        #endregion

        #region �����ݽ�����ҽ��

        /// <summary>
        /// �����ݽ�����ҽ��
        /// </summary>
        /// <param name="_Database"></param>
        /// <param name="ID"></param>
        /// <param name="GROUP_ID"></param>
        /// <param name="INPATIENT_ID"></param>
        /// <param name="DEPT_ID"></param>
        /// <param name="WARD_ID"></param>
        /// <param name="MNGTYPE"></param>
        /// <param name="NTYPE"></param>
        /// <param name="ORDER_DOC"></param>
        /// <param name="HOITEM_ID"></param>
        /// <param name="ITEM_CODE"></param>
        /// <param name="CJID"></param>
        /// <param name="ORDER_CONTEXT"></param>
        /// <param name="NUM"></param>
        /// <param name="DOSAGE"></param>
        /// <param name="UNIT"></param>
        /// <param name="SPEC"></param>
        /// <param name="BOOK_DATE"></param>
        /// <param name="ORDER_BDATE"></param>
        /// <param name="FIRST_TIMES"></param>
        /// <param name="ORDER_USAGE"></param>
        /// <param name="FREQUENCY"></param>
        /// <param name="OPERATOR"></param>
        /// <param name="DELETE_BIT"></param>
        /// <param name="STATUS_FLAG"></param>
        /// <param name="BABY_ID"></param>
        /// <param name="DEPT_BR"></param>
        /// <param name="EXEC_DEPT"></param>
        /// <param name="DROPSPER"></param>
        /// <param name="SERIAL_NO"></param>
        /// <param name="PS_FLAG"></param>
        /// <param name="PS_ORDERID"></param>
        /// <param name="DWLX"></param>
        /// <param name="JZ">ҩƷ��1=��Ժ��ҩ����Ŀ 1=ֱ�Ӽ���</param>
        /// <param name="GROUP_TMP"></param>
        /// <param name="flag"></param>
        /// <param name="outStr"></param>
        /// <returns></returns>		
        public string CommitOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
            long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
            DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
            long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
            int ts, decimal zsl, string zsldw, string jldwlx)
        {
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("��Ŀ��Դ�������1��2��3�����飡");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_ZYYS_ORDERCOMMIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 ���ֱ������������ҽ��
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 ������ҩ��ʾ��
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 ��ʱҽ�����죬����������������
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = _Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "����";
            }
        }

        public string CommitOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
           long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
           DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
           long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
           int ts, decimal zsl, string zsldw, string jldwlx, Guid newguid, decimal price
        #region"Modify By jchl(���ϰ汾)"
, decimal zfbl
        #endregion
)
        {
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("��Ŀ��Դ�������1��2��3�����飡");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_ZYYS_ORDERCOMMIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 ���ֱ������������ҽ��
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 ������ҩ��ʾ��
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 ��ʱҽ�����죬����������������
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));
                cmd.Parameters.Add(_Database.GetParameter("@newguid", newguid));
                cmd.Parameters.Add(_Database.GetParameter("@price", price));
                #region"Modify by jchl"
                cmd.Parameters.Add(_Database.GetParameter("@zfbl", decimal.Parse(zfbl.ToString())));
                #endregion

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = _Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "����";
            }
        }

        public string CommitOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
          long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
          DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
          long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
          int ts, decimal zsl, string zsldw, string jldwlx, Guid newguid, decimal price
        #region"Modify By jchl(���ϰ汾)"
, decimal zfbl
        #endregion
        #region"Modify By chenl(���ϰ汾)"
, string psypbm
         #endregion
)
        {
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("��Ŀ��Դ�������1��2��3�����飡");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_ZYYS_ORDERCOMMIT_PSYPBM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 ���ֱ������������ҽ��
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 ������ҩ��ʾ��
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 ��ʱҽ�����죬����������������
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));
                cmd.Parameters.Add(_Database.GetParameter("@newguid", newguid));
                cmd.Parameters.Add(_Database.GetParameter("@price", price));
                #region"Modify by jchl"
                cmd.Parameters.Add(_Database.GetParameter("@zfbl", decimal.Parse(zfbl.ToString())));
                #endregion
                #region"Modify by jchl"
                cmd.Parameters.Add(_Database.GetParameter("@psypbm", decimal.Parse(psypbm.ToString())));
                 #endregion

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = _Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "����";
            }
        }


        public string CommitOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
           long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
           DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
           long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
           int ts, decimal zsl, string zsldw, string jldwlx, Guid newguid, decimal price
        #region"Modify By jchl(���ϰ汾2 ������ҩ��˰汾)"
, decimal zfbl, int iFzyy_Bit, int iCheck_bit
        #endregion
)
        {
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("��Ŀ��Դ�������1��2��3�����飡");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_ZYYS_ORDERCOMMIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 ���ֱ������������ҽ��
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 ������ҩ��ʾ��
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 ��ʱҽ�����죬����������������
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));
                cmd.Parameters.Add(_Database.GetParameter("@newguid", newguid));
                cmd.Parameters.Add(_Database.GetParameter("@price", price));
                #region"Modify by jchl"
                cmd.Parameters.Add(_Database.GetParameter("@zfbl", decimal.Parse(zfbl.ToString())));
                cmd.Parameters.Add(_Database.GetParameter("@fzyy_Bit", iFzyy_Bit));
                cmd.Parameters.Add(_Database.GetParameter("@SH_Bit", iCheck_bit));
                #endregion

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = _Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "����";
            }
        }

        #endregion

        #region ����ҽ����¼
        /// <summary>
        /// ����ҽ����¼
        ///</summary>
        public void InsertOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
            long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
            DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
            long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int Jgbm)
        {
            if (XMLY != 1 && XMLY != 2 && XMLY != 3)
            {
                throw new Exception("��Ŀ��Դ�������1��2��3�����飡");
            }
            IDbCommand cmd = _Database.GetCommand();
            cmd.CommandText = "SP_ZYYS_INSERT_ORDERRECORD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
            cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
            cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
            cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
            cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
            cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
            cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
            cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
            cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
            cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
            cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
            cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
            cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
            cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
            cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
            cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
            cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
            cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
            cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
            cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
            cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
            cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
            cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
            cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
            cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
            cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
            cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
            cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
            cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
            cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
            cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
            cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
            cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
            cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
            cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));

            int itemp = _Database.DoCommand(cmd);
            cmd.Dispose();
        }
        #endregion

        #region ���������Ϣ��־
        /// <summary>
        /// ���������Ϣ��־
        /// </summary>
        public int SaveLog(long DeptID, long Operator, string typestr, string Content, int errlevel, int type)
        {
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            string workstation = "��������" + Dns.GetHostName() + "  IP��" + addressList[0].ToString();

            string sSql = "insert into his_log (dept_ID,operator_id,operator_type,Contents,starttime,errlevel,workstation,module_id) " +
                "values(" + DeptID.ToString() + "," + Operator.ToString() + ",'" + typestr.Trim() + "','" + Content.Trim() + "',GetDate()," + errlevel.ToString() + ",'" + workstation + "'," + type.ToString() + ")";
            try
            {
                return database.DoCommand(sSql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region ��ȡ��������
        /// <summary>
        /// ��ȡ�������� Modify by zouchihua 2011-11-30
        /// </summary>
        /// <param name="deptID">����ID</param>
        /// <param name="sign"></param>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public DataTable GetTSapply(long deptID, int sign, string wardId, Guid inpatient_id, long baby_id)
        {
            try
            {
                string sSql = "";
                string order = "";
                if (sign == 0)
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,case when A.BABY_ID=0 then B.NAME else C.BABYNAME end BinName,E.bed_no," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,dbo.FUN_ZY_SEEKDEPTNAME(A.TS_DEPT) ts_deptname,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG " +
                        "from (select * from ZY_TS_APPLY where dept_id=" + deptID.ToString() + " and delete_bit=0 and inpatient_id='" + inpatient_id + "' and baby_id=" + baby_id + " ) A " + // Modify by zouchihua ȥ���������ƣ�ֻ�ܿ����ò��˵���Ϣ (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) 
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID " +
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "     left join " +
                        "     VI_ZY_VINPATIENT_BED E on A.INPATIENT_ID=E.INPATIENT_ID and A.BABY_ID=E.BABY_ID " +
                        "order by apply_date";
                }
                else
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,case when A.BABY_ID=0 then B.NAME else C.BABYNAME end BinName," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG, " +
                        "       CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.DEPT_ID AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from (select * from ZY_TS_APPLY where TS_DEPT=" + deptID.ToString() + " and (ward_id='" + wardId + "' or '" + wardId + "'='-1') and status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) A " +
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID and b.flag in (1,3,4) " +//Modify By Tany 2010-03-26 ������Ժ���ж�
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "order by apply_date";
                }
                return database.GetDataTable(sSql);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��ȡ�������!\n" + err.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// ��ȡ��������ȫ���ҵ� Modify by zouchihua 2011-11-30
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="sign"></param>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public DataTable GetTSapply(long deptID, int sign, string wardId)
        {
            try
            {
                string sSql = "";
                if (sign == 0)
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName,E.bed_no," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,dbo.FUN_ZY_SEEKDEPTNAME(A.TS_DEPT) ts_deptname,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG " +
                        "from (select * from ZY_TS_APPLY where dept_id=" + deptID.ToString() + " and delete_bit=0 ) A " + // Modify by zouchihua ȥ���������ƣ�ֻ�ܿ����ò��˵���Ϣ (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) 
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID " +
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "     left join " +
                        "     VI_ZY_VINPATIENT_BED E on A.INPATIENT_ID=E.INPATIENT_ID and A.BABY_ID=E.BABY_ID " +
                        "order by apply_date";
                }
                else
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG, " +
                        "       CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.DEPT_ID AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from (select * from ZY_TS_APPLY where TS_DEPT=" + deptID.ToString() + " and (ward_id='" + wardId + "' or '" + wardId + "'='-1') and status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) A " +
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID and b.flag in (1,3,4) " +//Modify By Tany 2010-03-26 ������Ժ���ж�
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "order by apply_date";
                }
                return database.GetDataTable(sSql);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��ȡ�������!\n" + err.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// ��ȡ��������ȫ���ҵİ����ң��������� Modify by yaokx 2011-11-30
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="sign"></param>
        /// <param name="wardId"></param>
        /// <param name="type">0�����ڣ�1�ǿ���</param>
        /// <returns></returns>
        public DataTable GetTSapply(int type, long deptID, int sign, string wardId)
        {
            try
            {
                string sSql = "";
                string order = "order by apply_date";
                if (sign == 0)
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName,E.bed_no," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,dbo.FUN_ZY_SEEKDEPTNAME(A.TS_DEPT) ts_deptname,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG " +
                        "from (select * from ZY_TS_APPLY where dept_id=" + deptID.ToString() + " and delete_bit=0 ) A " + // Modify by zouchihua ȥ���������ƣ�ֻ�ܿ����ò��˵���Ϣ (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) 
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID " +
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "     left join " +
                        "     VI_ZY_VINPATIENT_BED E on A.INPATIENT_ID=E.INPATIENT_ID and A.BABY_ID=E.BABY_ID ";
                }
                else
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG, " +
                        "       CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.DEPT_ID AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from (select * from ZY_TS_APPLY where TS_DEPT=" + deptID.ToString() + " and (ward_id='" + wardId + "' or '" + wardId + "'='-1') and status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) A " +
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID and b.flag in (1,3,4) " +//Modify By Tany 2010-03-26 ������Ժ���ж�
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID ";
                }

                if (type == 1)
                {
                    order = "order by D.NAME";
                }
                return database.GetDataTable(sSql + order);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��ȡ�������!\n" + err.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion



        #region ����������������
        /// <summary>
        /// ����������������
        /// </summary>
        /// <param name="sign">0=������1=�޸ģ�2=ȡ����3=��ˣ�4=ȡ�����</param>
        /// <returns></returns>
        public int SaveTS(Guid BinID, long BabyID, string WardID, long DeptBR, long DeptID, long ApplyDoc, DateTime ApplyDate,
            string Content, long ExecDept, long SH_Doc, ref Guid id, int sign, int Jgbm)
        {

            string str = "";
            ParameterEx[] parameters = new ParameterEx[13];
            parameters[0].Text = "@SIGN";
            parameters[0].Value = sign;
            parameters[1].Text = "@BIN_ID";
            parameters[1].Value = BinID;
            parameters[2].Text = "@BABY_ID";
            parameters[2].Value = BabyID;
            parameters[3].Text = "@WARD_ID";
            parameters[3].Value = WardID;
            parameters[4].Text = "@DEPT_BR";
            parameters[4].Value = DeptBR;
            parameters[5].Text = "@DEPT_ID";
            parameters[5].Value = DeptID;
            parameters[6].Text = "@APPLY_DOC";
            parameters[6].Value = ApplyDoc;
            parameters[7].Text = "@APPLY_DATE";
            parameters[7].Value = ApplyDate;
            parameters[8].Text = "@CONTENT";
            parameters[8].Value = Content;
            parameters[9].Text = "@TS_DEPT";
            parameters[9].Value = ExecDept;
            parameters[10].Text = "@SH_USER";
            parameters[10].Value = SH_Doc;
            parameters[11].Text = "@ID";
            parameters[11].Value = id;
            parameters[11].ParaDirection = ParameterDirection.InputOutput;
            parameters[12].Text = "@JGBM";
            parameters[12].Value = Jgbm;
            try
            {
                switch (sign)
                {
                    case 0://����
                        str = "����";
                        break;
                    case 1://�޸�
                        str = "�޸�";
                        break;
                    case 2://ȡ��
                        str = "ȡ��";
                        break;
                    case 3://���
                        str = "���";
                        break;
                    case 4://ȡ�����
                        str = "ȡ�����";
                        break;
                }
                database.DoCommand("SP_ZYYS_SAVE_TSZL", parameters, 20);
                id = new Guid(parameters[11].Value.ToString());//�����������id
                return 1;
            }
            catch (Exception err)
            {
                MessageBox.Show(str + "����!\n" + err.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                id = new Guid(parameters[11].Value.ToString());
                return -1;
            }
        }
        #endregion

        #region ����Ϣ֪ͨ��ʿվ
        /// <summary>
        /// ����Ϣ֪ͨ��ʿվ
        /// </summary>
        /// <param name="warddept">����deptid</param>
        /// <param name="information">֪ͨ����</param>
        public void InformHS(long warddept, string information)
        {
            //string sSql = "Select a.ip_address from MZ_IPINFORMATION a,JC_MODULE b " +
            //    "where a.dtype=b.module_id and a.d_dept_id=" + warddept + " and a.use_flag=1 and b.name like '%������ʿվϵͳ%'";
            //DataTable myTb = database.GetDataTable(sSql);
            //for (int i = 0; i < myTb.Rows.Count; i++)
            //{
            //    System.Diagnostics.Process.Start("net.exe", "send " + myTb.Rows[i][0].ToString().Trim() + information);
            //}
        }
        public void InformHS(DataTable myTb, string information)
        {
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                System.Diagnostics.Process.Start("net.exe", "send " + myTb.Rows[i][0].ToString().Trim() + information);
            }
        }
        #endregion

        #region ��ȡ������ʿվIP��ַ
        /// <summary>
        /// ��ȡ������ʿվIP��ַ
        /// </summary>
        /// <param name="warddept">����deptid</param>
        /// <returns></returns>
        public DataTable WardIP(long warddept)
        {
            //string sSql = "Select a.ip_address from MZ_IPINFORMATION a,JC_MODULE b " +
            //    "where a.dtype=b.module_id and a.d_dept_id=" + warddept + " and a.use_flag=1 and b.name like '%������ʿվϵͳ%'";
            //return database.GetDataTable(sSql);
            return new DataTable();
        }
        #endregion

        public void InitGridSQL(string sSql, string[] GrdMappingName, int[] GrdWidth, int[] Alignment, DataGridEx myDataGrid)
        {
            DataTable myTb = database.GetDataTable(sSql);
            myTb.TableName = "yyy";
            myDataGrid.DataSource = myTb;
            myDataGrid.TableStyles[0].MappingName = myTb.TableName;
            myDataGrid.TableStyles[0].RowHeaderWidth = 5;

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                this.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
            }
        }

        public void InitGrid(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            DataGridEnableTextBoxColumn aColumnTextColumn;

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "ѡ")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.NullValue = false;
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
                    myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    aColumnTextColumn.NullText = "";
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    this.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                    else myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        public void InitGrid_Sub(int i, string[] GrdMappingName, int[] GrdWidth, int[] Alignment, DataGridEx myDataGrid)
        {
            string s = "";

            myDataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
            myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
            if (GrdWidth[i] != 0)
            {
                s = this.Repeat_Space((GrdWidth[i] - GrdMappingName[i].ToString().Trim().Length * 2) / 2);
                switch (Alignment[i])
                {
                    case 0:  //��
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = s + GrdMappingName[i].ToString().Trim();
                        break;
                    case 1:  //��
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                        myDataGrid.TableStyles[0].GridColumnStyles[i].Alignment = HorizontalAlignment.Center;
                        break;
                    case 2:  //��
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim() + s;
                        myDataGrid.TableStyles[0].GridColumnStyles[i].Alignment = HorizontalAlignment.Right;
                        break;
                }
            }
        }
        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
        }

        /// <summary>
        /// ��֤�Ƿ�ƥ��
        /// </summary>
        /// <param name="hoitem_id">ҽ����ĿID</param>
        /// <param name="yblx">ҽ������</param>
        /// <returns></returns>
        public bool isPP(long hoitem_id, int yblx, ref string xmid)
        {
            string sql = "select * from jc_hoitemdiction a " +
                        "INNER JOIN JC_HOI_HDI R " +
                        "ON R.HOITEM_ID =A.order_id " +
                        "INNER JOIN " +
                        "VI_JC_ITEMS H " +
                        "ON H.ITEMID=R.HDITEM_ID AND H.TCID=R.TCID " +
                        "left join jc_yb_bl c on h.ITEMID=c.xmid and c.xmly=2 and c.zybz=1 and c.yblx=" + yblx +
                        "where h.jgbm=" + FrmMdiMain.Jgbm + " and a.order_id=" + hoitem_id;
            DataTable tb = database.GetDataTable(sql);

            if (tb == null || tb.Rows.Count == 0)
            {
                xmid = "";
                return false;
            }
            else
            {
                xmid = Convertor.IsNull(tb.Rows[0]["hsbm"], "");
                //if (Convert.ToInt32(tb.Rows[0]["tc_flag"]) > 0 || tb.Rows[0]["zfbl"].ToString().Trim() != "")
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                //Modify By Tany �б�����ϵ˵����ƥ���ϵ
                return true;
            }
        }

        //Add by Tany 2010-01-11 �ж��Ƿ�Ϊ�ڷ���
        /// <summary>
        /// �Ƿ�ڷ�ҩƷ
        /// </summary>
        /// <param name="cjid">ҩƷ����ID</param>
        /// <returns></returns>
        public bool isKfyp(long cjid)
        {
            string tlfl = GetYpTlfl(cjid);//database.GetDataResult("select b.tlfl from vi_yp_ypcd a inner join yp_ypjx b on a.ypjx=b.id where a.cjid=" + cjid.ToString()).ToString().Trim();
            string kfy = new SystemCfg(7048).Config;
            if (kfy.IndexOf(tlfl) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// �Ƿ�ڷ�ҩƷ
        /// </summary>
        /// <param name="cjid">ҩƷ����ID</param>
        /// <param name="_kfyConfig">�ڷ�ҩ����7048</param>
        /// <returns></returns>
        public bool isKfyp(long cjid, string _kfyConfig)
        {
            string tlfl = GetYpTlfl(cjid);//database.GetDataResult("select b.tlfl from vi_yp_ypcd a inner join yp_ypjx b on a.ypjx=b.id where a.cjid=" + cjid.ToString()).ToString().Trim();
            if (_kfyConfig.IndexOf(tlfl) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Add by Tany 2010-01-19 ��ȡCJID��ͳ�����
        /// <summary>
        /// ��ȡҩƷͳ�����
        /// </summary>
        /// <param name="cjid">ҩƷ����ID</param>
        /// <returns></returns>
        public string GetYpTlfl(long cjid)
        {
            string tlfl = Convertor.IsNull(database.GetDataResult("select tlfl from vi_yp_ypcd where cjid=" + cjid.ToString()), "");
            //���û���ҵ��͸�Ϊ-1 add by zouchihua 2013-11-13
            if (tlfl.Trim() == "")
                tlfl = "-1";
            return tlfl;
        }

        public void ReadPacsInfo(Guid id)
        {
            string pacsName = "";
            try
            {
                pacsName = ApiFunction.GetIniString("PACS", "PACS����", Constant.ApplicationDirectory + "\\pacs.ini");
                ts_pacs_interface.Ipacs pacs = ts_pacs_interface.PacsFactory.Pacs(pacsName);
                pacs.ShowPacsInfo(id.ToString(), ts_pacs_interface.PatientSource.סԺ);

                //GetPacsInfo(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("û���ҵ���Ч�ļ�¼�������²�֤��\n" + ex.Message + pacsName, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GetPacsInfo(Guid id)
        {
            try
            {
                string pacsName = ApiFunction.GetIniString("PACS", "PACS����", Constant.ApplicationDirectory + "\\pacs.ini");
                ts_pacs_interface.Ipacs pacs = ts_pacs_interface.PacsFactory.Pacs(pacsName);

                DataTable tb = pacs.GetPacsInfo(id.ToString(), ts_pacs_interface.PatientSource.סԺ);
            }
            catch (Exception ex)
            {
                MessageBox.Show("û���ҵ���Ч�ļ�¼�������²�֤��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #region ���Ӽ�鲿λ��Ϣ   Modify By lwl 2011-09-13
        /// <summary>
        /// ���Ӽ�鲿λ��Ϣ
        /// </summary>
        /// <param name="ORDER_ID">�����ĿID</param>
        /// <param name="info">��鲿λ��Ϣ</param>
        /// <returns></returns>
        public int InsertCheckSite(string ORDER_ID, CheckSiteInfo info)
        {
            string sql = "insert into JC_HOITEMDICTIONCHILD (ORDER_ID,ORDER_POSITION,REMAKER) VALUES (" + ORDER_ID + ",'" + info.Checksitename + "','" + info.Checksiteremarker + "')";
            try
            {
                return database.DoCommand(sql);
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// ��ȡ��鲿λ��Ϣ
        /// </summary>
        /// <param name="order_id">�����ĿID</param>
        /// <returns></returns>
        public DataTable GetCheckSite(string order_id)
        {
            try
            {
                string sql = "select * from JC_HOITEMDICTIONCHILD where ORDER_ID=" + order_id;
                return database.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("û���ҵ���Ч�ļ�¼�������²�֤��\n" + ex.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }
        /// <summary>
        /// ��ȡ�����Ŀ��С����鲿λ
        /// </summary>
        /// <param name="order_id">�����ĿID</param>
        /// <returns></returns>
        public DataTable GetMaxAndMinItem(string order_id)
        {
            try
            {
                string sql = "select isnull(MINITEM,0) as MINITEM,isnull(MAXITEM,0) as MAXITEM from JC_JC_ITEM where YZID=" + order_id;
                return database.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("û���ҵ���Ч�ļ�¼�������²�֤��\n" + ex.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        #endregion
        /// <summary>
        /// ��ȡ���˵�״̬ >1������״̬ 2���������ڿ��ҵĻ�������
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <returns>rtnStr[0] ����״̬��rtnStr[1] �������� rtnStr[2] δ��ɿ�Ժ���������� </returns>
        public static string[] GetBrzt(Guid inpatient_id)
        {
            //Add By Tany 2011-10-11 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
            string patSql = "select a.freeze_flag,b.jgbm from zy_inpatient a inner join jc_dept_property b on a.dept_id=b.dept_id where a.inpatient_id='" + inpatient_id + "'";
            DataTable patTb = FrmMdiMain.Database.GetDataTable(patSql);
            string tszlSql = "select count(*) as sl from ZY_TS_APPLY "
            + "  where cast(id as varchar(36)) in (select yzj from ts_update_log where CZLX in (501,502) and BSCBZ=0 ) "
            + " and inpatient_id='" + inpatient_id + "'  and  status_flag!=2 and delete_bit=0 ";
            DataTable TszlTb = FrmMdiMain.Database.GetDataTable(tszlSql);

            string[] rtnStr = new string[3];
            if (patTb != null && patTb.Rows.Count > 0)
            {

                rtnStr[0] = patTb.Rows[0]["freeze_flag"].ToString();
                rtnStr[1] = patTb.Rows[0]["jgbm"].ToString();
                if (TszlTb.Rows.Count > 0)
                    rtnStr[2] = TszlTb.Rows[0]["sl"].ToString();
                else
                    rtnStr[2] = "0";
            }
            else
            {
                throw new Exception("δ�ҵ���Ч�Ĳ��˼�¼��");
            }

            return rtnStr;
        }
        #region �ٴ�·��
        /// <summary>
        /// ���cp״̬
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="bayb_id"></param>
        /// <returns>0��ʾ����</returns>
        public string GetCpzt(string inpatient_id, string bayb_id)
        {
            try
            {
                string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
                if (ifqy == "0")
                    return "0";
                string typename = ApiFunction.GetIniString("Tpype", "typename", Constant.ApplicationDirectory + "\\Cpset.ini");
                Cpinterface = Ts_Clinicalpathway_Factory.Ts_Cp_factory.Cpinterface(typename);
                return Cpinterface.GetCpstatus(new Guid(inpatient_id), Int16.Parse(bayb_id));
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        /// <summary>
        /// ����ٴ�·��ҽ���ƻ�����
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="bayb_id"></param>
        public object GetFrmCpinfo(Int32 Handle, string inpatient_id, string bayb_id, string dept_br, string ward_id, DataView dv, int Iscp)
        {
            object[] _values = new object[] { dept_br, ward_id, dv };
            try
            {
                string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
                if (ifqy == "0")
                    return null;
                string typename = ApiFunction.GetIniString("typename", "Tpype", Constant.ApplicationDirectory + "\\Cpset.ini");
                typename = ApiFunction.GetIniString("Tpype", "typename", Constant.ApplicationDirectory + "\\Cpset.ini");
                Cpinterface = Ts_Clinicalpathway_Factory.Ts_Cp_factory.Cpinterface(typename);

                if (Cpform.Count == 0)
                {
                    try
                    {
                        object frm = Cpinterface.ShowStepItems(Handle, inpatient_id, bayb_id, _values, Iscp);
                        Cpform.Add(frm);

                        (frm as Form).FormClosed += delegate
                        {
                            DelFrm(inpatient_id, bayb_id);
                        };
                        return frm;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("����" + ex.Message);
                        return null;
                    }

                }
                else
                {
                    int i = 0;
                    for (i = 0; i < Cpform.Count; i++)
                    {
                        if ((Cpform[i] as Ts_Clinicalpathway_Factory.FrmTsCpInfo)._inpatient_id == inpatient_id)
                        {
                            (Cpform[i] as Ts_Clinicalpathway_Factory.FrmTsCpInfo).Show();
                            (Cpform[i] as Ts_Clinicalpathway_Factory.FrmTsCpInfo).WindowState = FormWindowState.Normal;
                            break;
                        }
                    }
                    if (Cpform.Count == i)
                    {
                        object frm = Cpinterface.ShowStepItems(Handle, inpatient_id, bayb_id, _values, Iscp);
                        Cpform.Add(frm);

                        (frm as Form).FormClosed += delegate
                        {
                            DelFrm(inpatient_id, bayb_id);
                        };
                        return frm;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {

                return null;
            }
            return null;
        }
        private void DelFrm(string inpatient_id, string bayb_id)
        {
            for (int i = 0; i < Cpform.Count; i++)
            {
                if ((Cpform[i] as Ts_Clinicalpathway_Factory.FrmTsCpInfo)._inpatient_id == inpatient_id)
                    Cpform.RemoveAt(i);
            }
        }


        /// <summary>
        /// ��ȡ�ٴ�·�����Ҳ���
        /// </summary>
        /// <param name="sign">1=ҽ����Ͻ�ڲ��ˡ�2=�����ҵĲ��ˡ�3=���뵽�����һ���Ĳ���</param>
        /// <param name="deptid">������ID</param>
        /// <param name="docid">ҽ������ID</param>
        /// <returns></returns>
        public DataTable GetInpatientCp(int sign, long deptid, long docid, int Iscp)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptid;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = docid;
            parameters[2].Text = "@DOC";
            try
            {
                DataTable tb = database.GetDataTable("SP_ZYYS_GET_INPATIENT", parameters, 20);
                string tj = "";
                if (Iscp == 1)
                    tj = " STATUS=9";
                else
                    if (Iscp == 0)
                        tj = " STATUS in(1,4) ";
                DataTable Cpintb = database.GetDataTable("select inpatient_id from PATH_WAY_EXE where  " + tj);
                DataTable returntb = tb.Clone();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < Cpintb.Rows.Count; j++)
                    {
                        if (tb.Rows[i]["inpatient_id"].ToString().Trim() == Cpintb.Rows[j]["inpatient_id"].ToString().Trim())
                        {
                            returntb.Rows.Add(tb.Rows[i].ItemArray);
                        }
                    }
                }
                return returntb;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public void GetIntoPathway(string inpatient_id, string baby_id, int IScp)
        {
            object[] _value = new object[] { FrmMdiMain.CurrentDept, FrmMdiMain.CurrentUser, IScp };//Iscp  ������ Ϊ 1 ��Ĭ�� Ϊ0
            string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
            if (ifqy == "0")
                return;
            string typename = ApiFunction.GetIniString("Tpype", "typename", Constant.ApplicationDirectory + "\\Cpset.ini");
            Cpinterface = Ts_Clinicalpathway_Factory.Ts_Cp_factory.Cpinterface(typename);
            Form f = (Form)Cpinterface.IntoPathway(inpatient_id, baby_id, _value);
            f.ShowDialog();
        }

        //�ж��Ƿ���Ҫ�����ٴ�·��
        /// <summary>
        /// �ж��Ƿ���Ҫ�����ٴ�·��
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="baby_id"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public bool IsIntoPathWay(string inpatient_id, string baby_id, int deptid)
        {
            try
            {
                //�ж��Ƿ�����·��
                string ss = "select * from PATH_WAY_EXE where INPATIENT_ID='" + inpatient_id + "' ";
                DataTable isIntocp = FrmMdiMain.Database.GetDataTable(ss);
                if (isIntocp.Rows.Count > 0)
                    return false;

                string sql = "select * from PATH_WAY_DISEASE a join PATH_WAY b on a.PATHWAY_ID=b.PATHWAY_ID where isnull(b.DELETED,0)=0  and b.STATUS=21 and (b.DEPTID is null or b.DEPTID=" + deptid + ")";
                DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                sql = "select IN_DIAGNOSIS from ZY_INPATIENT where INPATIENT_ID='" + inpatient_id + "' ";
                DataTable zdtb = FrmMdiMain.Database.GetDataTable(sql);
                if (zdtb.Rows[0]["IN_DIAGNOSIS"].ToString() == "")
                    return false;
                DataRow[] row = tb.Select("ICD_CODE like '%" + zdtb.Rows[0]["IN_DIAGNOSIS"] + "%'");
                if (row != null && row.Length >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// �Ƿ������ͬ��Ŀid
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsExsitsorderid(DataTable tbyz, string order_xmid, DateTime dt, string inpatient_id, string baby_id)
        {
            string sql = "select * from ZY_ORDERRECORD where ((status_flag>=3 and (TERMINAL_TIMES<>0 and WZX_FLAG<=0)) or  status_flag<=2) and INPATIENT_ID='" + inpatient_id + "' and xmly=2 and mngtype=0 and baby_id=" + baby_id + " and  hoitem_id=" + order_xmid + " and delete_bit=0 and CONVERT(varchar,ORDER_BDATE,112)=CONVERT(varchar,cast('" + dt + "' as datetime),112)";
            DataTable tb = database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                return true;
            }
            else
                if (tbyz.Select("status_flag=0 and xmly=2 and hoitem_id=" + order_xmid + " ").Length > 0)
                {
                    return true;
                }
            return false;
        }
        /// <summary>
        /// ���ҩƷ����
        /// </summary>
        /// <returns></returns>
        public DataTable GetYplx()
        {
            string sql = "select ID,MC from yp_yplx where TJDXM in('01','02','03')";
            DataTable tb = database.GetDataTable(sql);
            return tb;
        }
        /// <summary>
        /// סԺ��ȥ��ǰ���0
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private string ConvertNo(string zyh)
        {
            int leng = zyh.Length;
            for (int i = 0; i < leng; i++)
            {
                if (zyh.Substring(0, 1) == "0")
                {
                    zyh = zyh.Substring(1, zyh.Length - 1);
                }
                else
                    break;
            }
            return zyh;
        }
        /// <summary>
        /// �人����ҽԺ��ȡlis�ӿں��Ҹ������뵥��
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public DataTable UpdateSqdh(DataTable tb, string zyh, string zd, RelationalDatabase rb, Guid inpatient_id, long baby_id
            , string xb, string csrq, string ch, string brxm)
        {
            if (tb.Rows.Count == 0)
                return null;
            rb.BeginTransaction();
            try
            {

                //��ýṹ��
                Ts_HisVsLis_interface.LisInfo[] lisInfo = new Ts_HisVsLis_interface.LisInfo[tb.Rows.Count];
                int i = 0;
                for (i = 0; i < tb.Rows.Count; i++)
                {
                    lisInfo[i].crtDateTime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString("yyyy-MM-dd HH:mm");
                    lisInfo[i].deptid = FrmMdiMain.CurrentDept.DeptId.ToString();
                    lisInfo[i].deptname = FrmMdiMain.CurrentDept.DeptName;
                    lisInfo[i].employeeName = tb.Rows[i]["����ҽ��"].ToString();
                    lisInfo[i].employeeId = FrmMdiMain.CurrentUser.EmployeeId.ToString();
                    lisInfo[i].hisid = tb.Rows[i]["id"].ToString();
                    lisInfo[i].itemid = tb.Rows[i]["hoitem_id"].ToString();
                    lisInfo[i].itemName = tb.Rows[i]["ҽ������"].ToString();
                    lisInfo[i].zd = zd;
                    lisInfo[i].zyh = ConvertNo(zyh);
                    lisInfo[i].xb = xb;
                    lisInfo[i].csrq = csrq;
                    lisInfo[i].ch = ch;
                    lisInfo[i].brxm = brxm;

                    //Modify By Tany 2015-08-04 ���ӱ걾����
                    lisInfo[i].bbmc = Convertor.IsNull(rb.GetDataResult("select ORDER_EXTENSION from ZY_JY_PRINT where order_id='" + tb.Rows[i]["id"].ToString() + "'"), "");
                }

                //Modify by jchl ��������ʱ�򣬴���lis����Ϣ --2017-11-08 
                //DataTable returntb = Ts_HisVsLis_interface.Ws_lis.LisServiceInput(lisInfo);
                string strMsg = "";
                //DataTable returntb = Ts_HisVsLis_interface.Ws_lis.LisServiceInput(lisInfo, out strMsg);
                string sql_tz = "select vomiting,paralyticileus,Bowelsoundsweakened,intestinalischemia,diarrhea,Ogilvie,Gastroparesis,Gastrointestinalbleeding,Feedingintolerance,Intraperitonealpressure,brlx from  zy_jy_brtz a  left join  zy_inpatient b on a.inpatient_id=b.inpatient_id where b.inpatient_no='00" + lisInfo[0].zyh + "'";
                DataTable dt_tz = database.GetDataTable(sql_tz);
                DataTable returntb = Ts_HisVsLis_interface.Ws_lis.LisServiceInput(lisInfo, dt_tz, out strMsg);

                returntb.TableName = "jy";
                returntb.WriteXml("jy.xml");
                string[] sql = new string[tb.Rows.Count];
                string sqlstr = "";
                i = 0;
                foreach (DataRow r in tb.Rows)
                {
                    //insertJY(rb,inpatient_id,baby_id ,new Guid( r["order_id"].ToString()));
                    //�Ȼ����ҽ��id��ȡorder
                    //�ٸ���zy_jy_print ��apply_no
                    DataRow[] selrow = returntb.Select("TestItem='" + r["id"].ToString() + "'");
                    if (selrow.Length > 0)
                    {
                        //������ص�ֵ�ǿ�ֵ��Ҳ�׳����� Modify By Tany 2015-03-31
                        if (selrow[0]["OrderID"].ToString().Trim() == "")
                        {
                            //throw new Exception("��" + r["ҽ������"].ToString().Trim() + "��û���ҵ���Ӧ��Lis���뵥��");
                            //������Ŀ��ͣ�ã�����ϵ����ƻ���Ϣ��
                            string orderid = tb.Rows[i]["hoitem_id"].ToString();
                            string ssql = string.Format(@"select D_CODE,* from JC_HOITEMDICTION where ORDER_ID='{0}' ", orderid);
                            string dCode = Convertor.IsNull(rb.GetDataResult(ssql),"").ToString();

                            //Modify by jchl ��������ʱ�򣬴���lis����Ϣ --2017-11-08 
                            //throw new Exception("��" + r["ҽ������"].ToString().Trim() + "-" + dCode + "��û���ҵ���Ӧ��Lis���뵥�ţ�����Ŀ������ͣ�ã�����ϵ����ƻ���Ϣ��");
                            throw new Exception(strMsg);
                        }
                        sqlstr = "update ZY_JY_PRINT set apply_no='" + selrow[0]["OrderID"].ToString() + "' where ORDER_ID='" + r["id"].ToString() + "'";
                        i++;
                    }
                    else
                    {
                        string orderid = tb.Rows[i]["hoitem_id"].ToString();
                        string ssql = string.Format(@"select D_CODE,* from JC_HOITEMDICTION where ORDER_ID='{0}' ", orderid);
                        string dCode = Convertor.IsNull(rb.GetDataResult(ssql), "").ToString();

                        //Modify by jchl ��������ʱ�򣬴���lis����Ϣ --2017-11-08 
                        //throw new Exception("��" + r["ҽ������"].ToString().Trim() + "-" + dCode + "��û���ҵ���Ӧ��Lis���뵥�ţ�����Ŀ������ͣ�ã�����ϵ����ƻ���Ϣ��");
                        throw new Exception(strMsg);
                    }
                    rb.DoCommand(sqlstr);
                }
                // rb.DoCommand(null, null, null, sql);
                rb.CommitTransaction();
                return returntb;
            }
            catch (Exception ex)
            {
                rb.RollbackTransaction();
                //����ѷ��͵ĸ��»���
                foreach (DataRow r in tb.Rows)
                {
                    //����д������¸��»���
                    string sqlstr = "update ZY_ORDERRECORD  set  STATUS_FLAG=0 where ORDER_ID='" + r["id"].ToString() + "'";
                    rb.DoCommand(sqlstr);
                }
                throw ex;
            }
        }
        public void deleteLisSqd(string orderid)
        {
            try
            {
                Ts_HisVsLis_interface.LisInfo lisInfo = new Ts_HisVsLis_interface.LisInfo();
                string sql = "select apply_no,b.HOITEM_ID from ZY_JY_PRINT a(nolock) inner join ZY_ORDERRECORD b(nolock) on a.ORDER_ID=b.ORDER_ID where a.ORDER_ID='" + orderid + "'";
                DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                if (tb.Rows.Count > 0)
                {
                    lisInfo.hisid = tb.Rows[0]["apply_no"].ToString();
                    lisInfo.itemid = tb.Rows[0]["HOITEM_ID"].ToString();
                    Ts_HisVsLis_interface.Ws_lis.LisDelete(lisInfo);
                }
                else
                {
                    //throw new Exception("û���ҵ���Ӧ��Lis���뵥��");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ��ù�������
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        public string GetTsxx(string zyh)
        {
            TrasenHIS.BLL.Judgeorder judge = new TrasenHIS.BLL.Judgeorder();
            return judge.GetLb(zyh);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">1=����ҽ�ƣ�2=ҽ��</param>
        /// <param name="zyh"></param>
        /// <param name="Hoitmeid"></param>
        /// <returns></returns>
        public bool GetGfxx(int type, string zyh, string Hoitmeid, string xmly, string mc, string gflb, ref decimal zfbl)
        {
            //����ҽ�Ʋ����Է�  Modify by jchl
            if (gflb == "����ҽ��")
            {
                zfbl = 1;
                return true;
            }

            bool bSnh = gflb.Equals("����ʡ��ũ��ת��") || gflb.Equals("��תũ��(ʡ��ũ��)");

            TrasenHIS.BLL.ReturnInfo rinfo = new TrasenHIS.BLL.ReturnInfo();
            TrasenHIS.BLL.Judgeorder judge = new TrasenHIS.BLL.Judgeorder();
            if (type == 1 || bSnh)
            {
                if (xmly == "2")
                    rinfo = judge.gf_pu_getzysfbl(zyh, Hoitmeid, mc);
                else
                    rinfo = judge.gf_pu_getzyypsfbl(zyh, Hoitmeid, mc);
                if (rinfo.ReturnCode == -99)
                {
                    MessageBox.Show(rinfo.ReurnShowInfo);
                    return false;
                }
                if (rinfo.ReturnCode < 0 && rinfo.ReurnShowInfo.Trim() == "")
                {
                    zfbl = 1;
                    return false;
                }
                if (rinfo.ReturnCode < 0)
                {
                    if (MessageBox.Show(rinfo.ReurnShowInfo + ",�Ƿ����?",
                  "��ʾ:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.No)
                    {
                        zfbl = 1;
                        return false;
                    }
                    else
                    {
                        zfbl = 1;
                        return true;
                    }
                }
                else
                {
                    //MessageBox.Show(mc + " ���ѱ���Ϊ��" + rinfo.ReturnValue + "��");
                    zfbl = decimal.Parse(rinfo.ReturnValue);
                    return true;
                }
            }
            else
                if (type == 2)
                {
                    //�����ҽ��
                    string fylb = "";
                    if (xmly == "2")
                        fylb = "XM";
                    else
                        if (xmly == "1")
                            fylb = "YP";
                    int ad_zff = 0;
                    rinfo = judge.ybnb_srxz(zyh, gflb, Hoitmeid, 0, ref ad_zff, fylb, mc);
                    //rinfo = judge.gf_pu_getzyypsfbl(zyh, Hoitmeid, mc);
                    if (rinfo.ReturnCode == -99)
                    {
                        MessageBox.Show(rinfo.ReurnShowInfo);
                        return false;
                    }
                    if (rinfo.ReturnCode < 0 && rinfo.ReurnShowInfo.Trim() == "")
                        return false;
                    if (rinfo.ReturnCode < 0 && rinfo.ReurnShowInfo.Trim() != "")
                    {
                        if (MessageBox.Show(rinfo.ReurnShowInfo + ",�Ƿ����?", "��ʾ:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            zfbl = 1;
                            return false;
                        }
                        else
                        {
                            zfbl = 1;
                            return true;
                        }
                    }
                    if (rinfo.ReturnCode > 0)
                    {
                        //MessageBox.Show(gflb + "[" + mc + "] ����Ϊ��" + rinfo.ReturnValue + "��");
                        zfbl = decimal.Parse(rinfo.ReturnValue);
                        return true;
                    }
                }
            return true;
        }
        #endregion

        /// <summary>
        /// �õ���ǰ����+1�����µ�ǰ����+1
        /// </summary>
        /// <param name="type"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static int UpdateNowNoAndGetNewNo(int type, RelationalDatabase database)
        {
            //return Convert.ToInt32(Convertor.IsNull(database.GetDataResult("select no + 1 from JC_IDENTITY where rowtype=" + type + ";update JC_IDENTITY set no = no + 1 where rowtype=" + type), "0"));

            int outId = 0;
            //string strSql = string.Format(@"update JC_IDENTITY set {0}=NO,NO=NO+1 where rowtype={1} ", iRet, type);

            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = type;
            parameters[0].Text = "@type";
            parameters[1].Value = outId;
            parameters[1].Text = "@outId";
            parameters[1].ParaDirection = ParameterDirection.Output;
            parameters[1].ParaSize = 2;

            try
            {
                database.DoCommand("SP_Get_JC_ID", parameters, 20);
            }
            catch (Exception err)
            {
                throw err;
            }

            int iret = Convert.ToInt32(parameters[1].Value);

            //if (iret == -1 && type == 13)
            //{
            //    throw new Exception("������ ���ҽ�� ʱ�쳣,��ɾ����ҽ�������¿���!");
            //}

            return iret;

        }

        public bool DoGetApplyInfo(string order_id)
        {
            try
            {
                string strSql = string.Format(@"select count(1) as num from YJ_ZYSQ where yzid='{0}' and bscbz=0", order_id);

                int i = int.Parse(database.GetDataResult(strSql).ToString().Trim());

                return i > 0;
            }
            catch
            {
                return false;
            }
        }

    }
}

