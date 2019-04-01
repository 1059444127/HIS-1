using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;

namespace TrasenHIS.BLL
{
    public class SyncPatientInfo
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        private static TrasenClasses.DatabaseAccess.RelationalDatabase InFomixDb;
        private static object lockob = new object();

        public SyncPatientInfo(TrasenClasses.DatabaseAccess.RelationalDatabase _Database)
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

        public static void SyncPat(RelationalDatabase db)
        {
            TrasenFrame.Forms.DlgInputBox dlgInput = new TrasenFrame.Forms.DlgInputBox("", "������סԺ�ţ�", "ͬ��������Ϣ");
            dlgInput.NumCtrl = true;
            dlgInput.ShowDialog();
            if (DlgInputBox.DlgResult)
            {
                string zyh = DlgInputBox.DlgValue;
                GetOldHISInpatientInfo(zyh, db);
            }
        }

        public static bool GetOldHISInpatientInfo(string zyh, RelationalDatabase db)
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
            string msg = "";
            string xml = "";

            try
            {
                if (zyh.Trim() == "")
                {
                    throw new Exception("סԺ��Ϊ�գ����飡");
                }
                oldzyh = Convert.ToInt64(zyh).ToString();
                sql = @" select a.zyh zyh,b.id as patientid,b.xm xm,b.xb xb,b.rq as csrq,b.jg jg,b.mz mz,
                        b.hk hk,b.zycs zycs,b.zy zy,b.csd csd,b.blh blh,b.gj gj,1 zjlx,b.sfzh sfzh,b.dwmc dwmc,b.dwdz dwdz,
                        b.dwdh dwdh,b.dwyzbm dwyzbm,b.jtdz jtdz,b.jtdh jtdh,b.jtyzbm jtyzbm,b.lxr lxr,b.gx gx,b.lxrdz lxrdz,
                        b.lxrdh lxrdh,b.gfdwbm gfdwbm,b.ylzh ylzh,b.gflb as gflbmc,a.ks as deptid,a.rybq as szbq,
                        a.ryrq as inhostime,a.cyrq as outhostime,a.ryzd ryzd,a.cwh as bedno,a.zrys zrys,'Pat_In' as event
                        from zy_zybrxx a inner join zy_brjbxx b on a.zyh=b.zyh
                        inner join yw_zybrzh AS C on a.zyh=c.zyh 
                        where a.ks not in ('000041','000034','000172') and c.bz='N' and  a.zyh='" + oldzyh + "'";
                DataTable oldPatTb = InFomixDb.GetDataTable(sql);
                if (oldPatTb == null || oldPatTb.Rows.Count == 0)
                {
                    throw new Exception("����ϵͳδ�ҵ�סԺ��Ϊ��" + oldzyh + "���Ĳ�����Ϣ��");
                }
                else
                {
                    string ss = "����ϵͳ�ҵ�������Ϣ���£�\r\n";
                    ss += "סԺ�ţ�" + oldPatTb.Rows[0]["zyh"].ToString().Trim() + "\r\n";
                    ss += "������" + oldPatTb.Rows[0]["xm"].ToString().Trim() + "\r\n";
                    ss += "��Ժ���ڣ�" + oldPatTb.Rows[0]["inhostime"].ToString().Trim() + "\r\n";
                    ss += "\r\n��˶Բ�����Ϣ�Ƿ���ȷ���Լ����������Ƿ����루��������������˳�������\r\n�Ƿ������";
                    if (MessageBox.Show(ss, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return false;
                    }
                }

                msg = GetPatMsg(oldPatTb);

                sql = "select * from vi_zy_vinpatient_all where flag<>10 and inpatient_no like '%" + zyh + "%'";
                DataTable newPatTb = db.GetDataTable(sql);

                TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
                if (newPatTb == null || newPatTb.Rows.Count == 0)
                {
                    //���û���ҵ�������Ϣ����Ҫ����WS��ȡ
                    xml = ws.ExeWebService("SaveInpatient", msg);
                    DataSet dset = HisFunctions.ConvertXmlToDataSet(xml);
                    if (dset.Tables["HEAD"].Rows.Count > 0)
                    {
                        if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                        {
                            throw new Exception("����WS���没����Ϣʱ���ִ�����Ϣ��ʽ��" + msg);
                        }
                        else if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "0")
                        {
                            MessageBox.Show("ͬ���ɹ�����ˢ�²����б�");
                        }
                    }
                }
                else
                {
                    //����в�����Ϣ��Ҳ����WS Add By Tany 2015-02-11
                    ws.ExeWebService("SaveInpatient", msg);//ֻ�ǵ��ã����ܽ��

                    //����ҵ��ˣ�����Ҫ��֤����ϵͳ����һ����
                    sql = "select deptid from vi_zy_newhishsz where deptid=" + newPatTb.Rows[0]["dept_id"].ToString();
                    DataTable hszTb = db.GetDataTable(sql);
                    if (hszTb != null && hszTb.Rows.Count > 0)
                    {
                        //throw new Exception("�ò����Ѿ��������»�ʿվ�Ŀ��ң�������ϵͳ������Ϊ׼��");
                        //���������ϵͳ������ü�鲡����Ϣ
                        if (CheckPatientInfo.Check(newPatTb.Rows[0]["inpatient_no"].ToString(), db))
                        {
                            MessageBox.Show("ͬ������ϵͳ�ɹ���������ϵͳ�м�鲡����Ϣ��");
                        }
                    }
                    string oldKs = HisFunctions.ConvertOldhisidToNewHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, oldPatTb.Rows[0]["deptid"].ToString().Trim(), db);
                    if (oldKs == "")
                    {
                        throw new Exception("δ�ҵ��ÿ���[" + oldPatTb.Rows[0]["deptid"].ToString().Trim() + "]��Ӧ�Ŀ�����Ϣ��");
                    }
                    string oldCwh = oldPatTb.Rows[0]["bedno"].ToString().Trim();

                    //�����ϵͳ���Һ���ϵͳ��һ�����������ϵͳ����ϵͳ��ת���¼�
                    if (oldKs != newPatTb.Rows[0]["dept_id"].ToString())
                    {
                        MessageBox.Show("�ò�������ϵͳ�еĿ�������ϵͳ�Ŀ��Ҳ�����ϵͳ�������޸���ϵͳ���ݣ�\r\n\r\n���ȷ���󽫼�������......", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        xml = ws.ExeWebService("TransDept", msg);
                        DataSet dset = HisFunctions.ConvertXmlToDataSet(xml);
                        if (dset.Tables["HEAD"].Rows.Count > 0)
                        {
                            if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                            {
                                throw new Exception("����WS����ת��ʱ���ִ�����Ϣ��ʽ��" + msg);
                            }
                            else if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "0")
                            {
                                MessageBox.Show("ͬ���ɹ�����ˢ�²����б�");
                            }
                        }
                    }
                    else if (oldCwh != "" && oldCwh != newPatTb.Rows[0]["bed_no"].ToString())
                    {
                        //�����λ��ͬ�������ת��
                        MessageBox.Show("�ò�������ϵͳ�еĴ�λ����ϵͳ�Ĵ�λ������ϵͳ�������޸���ϵͳ���ݣ�\r\n\r\n���ȷ���󽫼�������......", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        xml = ws.ExeWebService("ChangeBed", msg);
                        DataSet dset = HisFunctions.ConvertXmlToDataSet(xml);
                        if (dset.Tables["HEAD"].Rows.Count > 0)
                        {
                            if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                            {
                                throw new Exception("����WS����ת��ʱ���ִ�����Ϣ��ʽ��" + msg);
                            }
                            else if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "0")
                            {
                                MessageBox.Show("ͬ���ɹ�����ˢ�²����б�");
                            }
                        }
                    }
                }

                try
                {
                    //����һ��EMR�ķ��� Modify By Tany 2016-01-20
                    sql = "select inpatient_id from zy_inpatient where flag<>10 and inpatient_no like '%" + zyh + "%'";
                    msg = ws.GetXml("n2oFpcw.EMR", Convertor.IsNull(db.GetDataResult(sql), Guid.Empty.ToString()));
                    xml = ws.ExeWebService("n2oFpcw.EMR", msg);

                    MessageBox.Show("ͬ��EMR�ɹ�����ˢ��EMR������Ϣ��");
                }
                catch
                {
                    throw new Exception("ͬ��EMRʱ�������ֹ�ͬ����");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static string GetPatMsg(DataTable oldPatTb)
        {
            string msg = "<message>";
            msg += "<zyh>" + oldPatTb.Rows[0]["zyh"].ToString().Trim() + "</zyh>";
            msg += "<patientid>" + oldPatTb.Rows[0]["patientid"].ToString().Trim() + "</patientid>";
            msg += "<xm>" + oldPatTb.Rows[0]["xm"].ToString().Trim() + "</xm>";
            msg += "<xb>" + oldPatTb.Rows[0]["xb"].ToString().Trim() + "</xb>";
            string csrq = "";
            if (oldPatTb.Rows[0]["csrq"].ToString().Trim() != "")
            {
                csrq = Convert.ToDateTime(oldPatTb.Rows[0]["csrq"]).ToString("yyyyMMdd");
            }
            msg += "<csrq>" + csrq + "</csrq>";
            msg += "<jg>" + oldPatTb.Rows[0]["jg"].ToString().Trim() + "</jg>";
            msg += "<mz>" + oldPatTb.Rows[0]["mz"].ToString().Trim() + "</mz>";
            msg += "<hk>" + oldPatTb.Rows[0]["hk"].ToString().Trim() + "</hk>";
            msg += "<zycs>" + oldPatTb.Rows[0]["zycs"].ToString().Trim() + "</zycs>";
            msg += "<zy>" + oldPatTb.Rows[0]["zy"].ToString().Trim() + "</zy>";
            msg += "<csd>" + oldPatTb.Rows[0]["csd"].ToString().Trim() + "</csd>";
            msg += "<blh>" + oldPatTb.Rows[0]["blh"].ToString().Trim() + "</blh>";
            msg += "<gj>" + oldPatTb.Rows[0]["gj"].ToString().Trim() + "</gj>";
            msg += "<zjlx>" + oldPatTb.Rows[0]["zjlx"].ToString().Trim() + "</zjlx>";
            msg += "<sfzh>" + oldPatTb.Rows[0]["sfzh"].ToString().Trim() + "</sfzh>";
            msg += "<dwmc>" + oldPatTb.Rows[0]["dwmc"].ToString().Trim() + "</dwmc>";
            msg += "<dwdz>" + oldPatTb.Rows[0]["dwdz"].ToString().Trim() + "</dwdz>";
            msg += "<dwdh>" + oldPatTb.Rows[0]["dwdh"].ToString().Trim() + "</dwdh>";
            msg += "<dwyzbm>" + oldPatTb.Rows[0]["dwyzbm"].ToString().Trim() + "</dwyzbm>";
            msg += "<jtdz>" + oldPatTb.Rows[0]["jtdz"].ToString().Trim() + "</jtdz>";
            msg += "<jtdh>" + oldPatTb.Rows[0]["jtdh"].ToString().Trim() + "</jtdh>";
            msg += "<jtyzbm>" + oldPatTb.Rows[0]["jtyzbm"].ToString().Trim() + "</jtyzbm>";
            msg += "<lxr>" + oldPatTb.Rows[0]["lxr"].ToString().Trim() + "</lxr>";
            msg += "<gx>" + oldPatTb.Rows[0]["gx"].ToString().Trim() + "</gx>";
            msg += "<lxrdz>" + oldPatTb.Rows[0]["lxrdz"].ToString().Trim() + "</lxrdz>";
            msg += "<lxrdh>" + oldPatTb.Rows[0]["lxrdh"].ToString().Trim() + "</lxrdh>";
            msg += "<gfdwbm>" + oldPatTb.Rows[0]["gfdwbm"].ToString().Trim() + "</gfdwbm>";
            msg += "<ylzh>" + oldPatTb.Rows[0]["ylzh"].ToString().Trim() + "</ylzh>";
            msg += "<gflbmc>" + oldPatTb.Rows[0]["gflbmc"].ToString().Trim() + "</gflbmc>";
            msg += "<deptid>" + oldPatTb.Rows[0]["deptid"].ToString().Trim() + "</deptid>";
            msg += "<szbq>" + oldPatTb.Rows[0]["szbq"].ToString().Trim() + "</szbq>";
            string indate = "";
            if (oldPatTb.Rows[0]["inhostime"].ToString().Trim() != "")
            {
                indate = Convert.ToDateTime(oldPatTb.Rows[0]["inhostime"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            msg += "<inhostime>" + indate + "</inhostime>";
            string outdate = "";
            if (oldPatTb.Rows[0]["outhostime"].ToString().Trim() != "")
            {
                outdate = Convert.ToDateTime(oldPatTb.Rows[0]["outhostime"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            msg += "<outhostime>" + outdate + "</outhostime>";
            msg += "<ryzd>" + oldPatTb.Rows[0]["ryzd"].ToString().Trim() + "</ryzd>";
            msg += "<bedno>" + oldPatTb.Rows[0]["bedno"].ToString().Trim() + "</bedno>";
            msg += "<zrys>" + oldPatTb.Rows[0]["zrys"].ToString().Trim() + "</zrys>";
            msg += "</message>";

            return msg;
        }

        //Add BY Tany 2015-04-01
        /// <summary>
        /// ͬ����ϵͳ��ҽ������ϵͳ
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static void SyncDoc(Guid inpatientId, RelationalDatabase db)
        {
            string ssql = @"select inpatient_no,inpatient_id,zy_doc doc_id from zy_inpatient where inpatient_id='" + inpatientId + "'";
            DataTable tb = db.GetDataTable(ssql);
            if (tb == null || tb.Rows.Count == 0)
            {
                throw new Exception("��ͬ����ϵͳ����ҽ����������ϵͳ��δ�ҵ��ò�����Ϣ�����飡");
            }
            string zyh = Convert.ToInt64(tb.Rows[0]["inpatient_no"].ToString()).ToString();
            string zrys = HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_EMPLOYEE_PROPERTY, tb.Rows[0]["doc_id"].ToString(), db);
            if (zrys == "")
            {
                throw new Exception("��ͬ����ϵͳ����ҽ������δ�ҵ���Ӧ������ҽ�������飡");
            }

            InstanceOldHISDb();
            ssql = "UPDATE ZY_ZYBRXX SET zrys='" + zrys + "' WHERE ZYH='" + zyh + "'";
            InFomixDb.DoCommand(ssql);
        }
    }
}
