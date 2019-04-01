using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
namespace TrasenHIS.BLL
{
    /// <summary>
    /// �����ϵͳ����ϵͳ������Ϣ�Ƿ�ƥ��
    /// </summary>
    public class CheckPatientInfo
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        private static TrasenClasses.DatabaseAccess.RelationalDatabase InFomixDb;
        private static object lockob = new object();

        public CheckPatientInfo(TrasenClasses.DatabaseAccess.RelationalDatabase _Database)
        {
            Database = _Database;
        }

        /// <summary>
        /// ʵ������ϵͳ����
        /// </summary>
        private static void InstanceOldHISDb()
        {
            if (InFomixDb == null)
            {
                lock (lockob)
                {
                    if (InFomixDb == null)
                        InFomixDb = TrasenHIS.DAL.BaseDal.GetDb_InFormix();
                }
            }
        }

        /// <summary>
        /// ��鲢����������Ϣ
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool Check(string zyh, RelationalDatabase db)
        {
            //Modify By Tany 2015-01-30 ������Ӳ�����ʽ�⣬����֤
            string conn = db.ConnectionString;
            string[] s = conn.Split(';');
            if (s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].IndexOf("initial catalog=") >= 0)
                    {
                        if (s[i].Replace("initial catalog=", "").ToLower() != "trasen")
                        {
                            return true;
                        }
                    }
                }
            }

            InstanceOldHISDb();

            string oldzyh = "";
            string sql = "";

            try
            {
                if (zyh.Trim() == "")
                {
                    throw new Exception("סԺ��Ϊ�գ����飡");
                }
                oldzyh = Convert.ToInt64(zyh).ToString();
                sql = "select * from vi_zy_vinpatient_all where flag<>10 and inpatient_no='" + zyh + "' and dept_id in (select deptid from vi_zy_newhishsz)";
                DataTable newPatTb = db.GetDataTable(sql);
                //�����»�ʿվ�Ĳ��˲Ž�����֤
                if (newPatTb != null && newPatTb.Rows.Count > 0)
                {
                    sql = "select * from zy_zybrxx where zyh='" + oldzyh + "'";
                    DataTable oldPatTb = InFomixDb.GetDataTable(sql);
                    if (oldPatTb == null || oldPatTb.Rows.Count == 0)
                    {
                        throw new Exception("����ϵͳδ�ҵ�סԺ��Ϊ��" + oldzyh + "���Ĳ��ˣ�");
                    }
                    string oldKs = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, oldPatTb.Rows[0]["ks"].ToString().Trim(), db);
                    if (oldKs == "")
                    {
                        throw new Exception("δ�ҵ��ÿ���[" + oldPatTb.Rows[0]["ks"].ToString().Trim() + "]��Ӧ�Ŀ�����Ϣ��");
                    }
                    string oldCwh = oldPatTb.Rows[0]["cwh"].ToString().Trim();

                    bool isTs = false;
                    //�����ϵͳ���Һ���ϵͳ��һ�����������ϵͳ����ϵͳ��ת���¼�
                    if (oldKs != newPatTb.Rows[0]["dept_id"].ToString())
                    {
                        isTs = true;
                        MessageBox.Show("�ò�������ϵͳ�еĿ�������ϵͳ�Ŀ��Ҳ�����ϵͳ�������޸���ϵͳ���ݣ�\r\n\r\n���ȷ���󽫼�������......", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //���ܵ���ת��WS��ֻ��ֱ�Ӹ�������
                        string _ks = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, newPatTb.Rows[0]["dept_id"].ToString(), db); ;
                        sql = "SELECT BQ FROM zy_bqksdzb Where KS = '" + _ks + "'";
                        string _bq = Convertor.IsNull(InFomixDb.GetDataResult(sql), "");

                        System.Data.Odbc.OdbcConnection connection = new System.Data.Odbc.OdbcConnection(DAL.BaseDal.oldhis_constr);
                        System.Data.Odbc.OdbcTransaction tx = null;
                        System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand();
                        try
                        {
                            connection.Open();
                            cmd.Connection = connection;
                            tx = connection.BeginTransaction();
                            cmd.Transaction = tx;

                            //����ϴ�λ��Ϣ
                            sql = "UPDATE ZY_CWXX Set zyh = '',xm = '',APZ = '',ZT = '����' Where zyh = '" + oldzyh + "'";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            //���²�����Ϣ
                            sql = "UPDATE ZY_ZYBRXX SET CWH='',BQ='" + _bq + "',ks='" + _ks + "',bf='',sfapcw='N' WHERE ZYH='" + oldzyh + "'";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            tx.Commit();
                        }
                        catch (Exception err)
                        {
                            tx.Rollback();
                            throw err;
                        }
                        finally
                        {
                            cmd.Dispose();
                            connection.Close();
                        }
                    }
                    //������Ҫ�ڼ��һ��������˵Ĵ�λ�������Ϊ�յ�����£�����ϵͳ��λ�����ǲ�������Ϣ Modify By Tany 2015-01-22
                    string cwZyh = "";
                    if (oldCwh != "")
                    {
                        sql = "select zyh from zy_cwxx where ks='" + oldPatTb.Rows[0]["ks"].ToString() + "' and cwh='" + oldCwh + "'";
                        cwZyh = Convertor.IsNull(InFomixDb.GetDataResult(sql), "");
                    }
                    //�����ϵͳ���Һ���ϵͳ���ߴ�λ��һ�����������ϵͳ����ϵͳ��ת���¼�
                    //if (oldKs != newPatTb.Rows[0]["dept_id"].ToString() || oldCwh != newPatTb.Rows[0]["bed_no"].ToString() || cwZyh != oldzyh)
                    //Modify By Tany 2015-05-05 ����������жϣ���Ϊ����ϵͳ��λ���ƿ��ܲ�һ�£��жϴ�λ��ʱ����Ҫͨ����Ӧ��ϵȥ��֤�����Ƿ���ȷ
                    string mapCwh = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.ZY_BEDDICTION, newPatTb.Rows[0]["bed_id"].ToString(), db);
                    string[] ss = mapCwh.Replace("||", "|").Split("|".ToCharArray());
                    if (ss.Length > 1)
                    {
                        mapCwh = ss[1];
                    }
                    if (oldKs != newPatTb.Rows[0]["dept_id"].ToString() || oldCwh != mapCwh || cwZyh != oldzyh)
                    {
                        if (!isTs)
                        {
                            isTs = true;
                            MessageBox.Show("�ò�������ϵͳ�еĴ�λ����ϵͳ�Ĵ�λ������ϵͳ�������޸���ϵͳ���ݣ�\r\n\r\n���ȷ���󽫼�������......", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                        string strXML = "";
                        strXML = ws.GetXml("n2oZc.HIS", newPatTb.Rows[0]["inpatient_id"].ToString());
                        strXML = ws.ExeWebService("n2oZc.HIS", strXML);
                        DataSet dset = HisFunctions.ConvertXmlToDataSet(strXML);
                        if (dset.Tables["HEAD"].Rows.Count > 0)
                        {
                            if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                            {
                                throw new Exception("����WSת��ʱ���ִ���" + dset.Tables["HEAD"].Rows[0]["ERRTEXT"].ToString());
                            }
                        }
                    }
                    if (isTs)
                    {
                        MessageBox.Show("��ϵͳ�����޸���ɣ�������������Ĳ�����");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("�������ϵͳ����״̬ʱ�������Ĳ��������ܼ�����\r\n\r\n" + ex.Message);
                return false;
            }
        }

        //Add By Tany 2015-04-28
        /// <summary>
        /// �Ƿ�����ϵͳ��Ժ�����
        /// </summary>
        /// <returns></returns>
        public static bool isCysh(string zyh)
        {
            InstanceOldHISDb();

            bool iscysh = false;

            string sql = "select * from yw_zybrzh where zyh='" + Convert.ToInt64(zyh) + "'";
            DataTable tb = InFomixDb.GetDataTable(sql);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (Convertor.IsNull(tb.Rows[0]["shbz"], "").ToUpper() == "Y")
                {
                    iscysh = true;
                }
            }

            return iscysh;
        }

        //Add By Tany 2016-04-13
        /// <summary>
        ///  ��鲡����ϵͳ�Ƿ���㣬�����ϵͳ������ϵͳδ���㣬��ͬ�����ý��㷽��
        /// </summary>
        /// <param name="zyh">סԺ��</param>
        /// <param name="db">��ϵͳ���ݿ�����</param>
        public static void CheckPatJszt(string zyh, RelationalDatabase db)
        {
            try
            {
                InstanceOldHISDb();

                bool iscyjs = false;

                string sql = "select * from yw_zybrzh where zyh='" + Convert.ToInt64(zyh) + "'";
                DataTable tb = InFomixDb.GetDataTable(sql);
                if (tb != null && tb.Rows.Count > 0)
                {
                    if (Convertor.IsNull(tb.Rows[0]["bz"], "").ToUpper() == "Y")
                    {
                        iscyjs = true;
                    }
                }
                if (!iscyjs)
                {
                    MessageBox.Show("סԺ�š�" + zyh + "���Ĳ�������ϵͳ��δ���㣡");
                    return;
                }
                else
                {
                    sql = "select * from vi_zy_vinpatient_all where convert(bigint,inpatient_no)='" + Convert.ToInt64(zyh) + "'";
                    tb = db.GetDataTable(sql);
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        MessageBox.Show("סԺ�š�" + zyh + "���Ĳ�������ϵͳδ�ҵ���Ϣ��");
                        return;
                    }
                    int flag = Convert.ToInt32(tb.Rows[0]["flag"]);
                    if (flag == 2 || flag == 6)
                    {
                        MessageBox.Show("סԺ�š�" + zyh + "���Ĳ�������ϵͳ�Ѿ����㣡");
                        return;
                    }
                    else
                    {
                        //����WSͬ������״̬
                        string xml = "";
                        sql = "select zyh,id as patientid,xm,zt as jszt,jsdjh,cyrq,ryrq as ksrq,jsrq,0 as yjj,zfy as ylzfy,gfje as ybzf,zfje,djrq,czy as djybm from v_brfy where zyh='" + Convert.ToInt64(zyh) + "'";
                        tb = InFomixDb.GetDataTable(sql);
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            xml = ConvertToXML.DataTableToXmlEx(tb, "message");
                            TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                            string strXML = "";
                            strXML = ws.ExeWebService("SaveCyzt", xml);
                            DataSet dset = HisFunctions.ConvertXmlToDataSet(strXML);
                            if (dset.Tables["HEAD"].Rows.Count > 0)
                            {
                                if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                                {
                                    throw new Exception("����WS��Ժ����ʱ���ִ���" + dset.Tables["HEAD"].Rows[0]["ERRTEXT"].ToString());
                                }
                            }
                            MessageBox.Show("ͬ������״̬�ɹ�����������Ĳ�����");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
