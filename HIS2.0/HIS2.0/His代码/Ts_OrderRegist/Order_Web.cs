using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using Ts_Visit_Class;

namespace Ts_OrderRegist
{
    /// <summary>
    /// ����ԤԼƽ̨webservice����ʵ���� add by zp 2013-01-04
    /// </summary>
    public class Order_Web
    {
        /// <summary>
        /// ԤԼƽ̨webservice������
        /// </summary>
       // TrasenWebService Ts_Order = new TrasenWebService();// TrasenWebService(0);
        Web_OrderClient Ts_Order = null; 
        /// <summary>
        /// ����ԤԼƽ̨���ص�xml����
        /// </summary>
        Order_Parmanalyze Analy = new Order_Parmanalyze();
        SystemCfg cfg;

        private string HosptId = string.Empty;

        //private DataTable dt_time;


        public Order_Web(SystemCfg _cfg)
        {
            this.cfg = _cfg;
            SystemCfg cfg3063 = new SystemCfg(3063);
            Ts_Order = new Web_OrderClient(cfg3063.Config); ;
        }
        /// <summary>
        /// ԤԼ�Ǽ�
        /// </summary>
        /// <param name="cardno">����</param>
        /// <param name="name">ԤԼ����</param>
        /// <param name="sfzh">���֤��</param>
        /// <param name="sex">�Ա�</param>
        /// <param name="birthday">����������</param>
        /// <param name="phone">�绰</param>
        /// <param name="address">��ַ</param>
        /// <param name="rowid">�Ű�����</param>
        /// <param name="czyh">����Ա</param>
        /// <param name="klxid">������id</param>
        /// <param name="msg">���������ص��ַ�ֵ �ɹ��洢ƽ̨������ˮ�� ʧ�ܴ洢ʧ����Ϣ</param>
        /// <param name="qhpassword">ȡ������</param>
        /// <param name="hisorderid">ԤԼid</param>
        /// <param name="numberid">ƽ̨���������</param>
        /// <param name="Bz">��ע��Ϣ Add by zp 2014-09-25</param>
        /// <returns></returns>
        public bool SaveOrder(string cardno,string name,string sfzh,string sex,
            string birthday,string phone,string address,string rowid,string czyh,int klxid,ref string msg,
            ref string qhpassword,ref string hisorderid,ref string numberid,string Bz)
        {
            bool save_value = false;
            try
            {
                if (string.IsNullOrEmpty(HosptId))
                {
                    HosptId = cfg.Config;
                }
               //string post = "<PAYMENT><HEAD><ResponseCode></ResponseCode><ResponseMsg></ResponseMsg><Date></Date><tsCliePw>-1</tsCliePw></HEAD><DATA><tsMediCardId>" + cardno + "</tsMediCardId><tsUserName>" + name + "</tsUserName><tsUserCardID>" + sfzh + "</tsUserCardID><tsUserSex>"+sex+"</tsUserSex><tsUserBD>" + birthday + "</tsUserBD><tsUserContNum>" + phone + "</tsUserContNum><tsUserContAdd>" + address + "</tsUserContAdd><tsRowID>" + rowid + "</tsRowID><tsReseTime></tsReseTime><NumberID>" + numberid + "</NumberID><tsInMemo></tsInMemo></DATA></PAYMENT>";
                string post = @"<PAYMENT>
                                  <HEAD>
                                     <ResponseCode></ResponseCode>
                                     <ResponseMsg></ResponseMsg>
                                     <Date></Date>
                                     <tsCliePw>" + czyh + @"</tsCliePw>
                                  </HEAD>
                                  <DATA>
                                     <tsMediCardId>" + cardno + @"</tsMediCardId>
                                     <tsUserName>" + name + @"</tsUserName>
                                     <tsUserCardID>" + sfzh + @"</tsUserCardID>
                                     <tsUserSex>" + sex + @"</tsUserSex>
                                     <tsUserBD>" + birthday + @"</tsUserBD>
                                     <tsUserContNum>" + phone + @"</tsUserContNum>
                                     <tsUserContAdd>" + address + @"</tsUserContAdd>
                                     <tsRowID>" + rowid + @"</tsRowID>
                                     <tsReseTime></tsReseTime>
                                     <NumberID>" + numberid + @"</NumberID>
                                     <tsInMemo>" + Bz + @"</tsInMemo>
                                     <tsCardType>" + klxid + @"</tsCardType>  
                                  </DATA>
                               </PAYMENT>";
                string values = Ts_Order.GetReseSubm(post);
                string record = "0";
                save_value = Analy.GetOrderSaveResult(values, ref record, ref msg, ref hisorderid);
                if (save_value == true) //���ԤԼ�ɹ�����ƽ̨���׺Ÿ���Ϣ����
                {
                    qhpassword = msg;  //ȡ������
                    msg = record.ToString(); //������ˮ��
                }
            }
            catch (Exception ea)
            {
                msg = ea.ToString();
            }
            return save_value;
        }
        /// <summary>
        /// ��ȡƽ̨��ʱ�α��
        /// </summary>
        /// <param name="rowid"></param>
        /// <returns></returns>
        public string GetNumberId(string rowid,string czyh)//2012-11-5|12|14605|2|8.00|1
        {
            string value = string.Empty;
            try
            {
                string _xml = @"<PAYMENT>
                              <HEAD>
                                <ResponseCode></ResponseCode>
                                <ResponseMsg></ResponseMsg>
                                <Date></Date>
                                <tsCliePw>"+czyh+@"</tsCliePw>
                              </HEAD>
��                            <DATA>
����                            <sRowID>" + rowid + @"</sRowID>
����                            <tsInMemo></tsInMemo>
��                            </DATA>
                            </PAYMENT>";
                            value = Ts_Order.GetNumber(_xml);
                return value;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        /// <summary>
        /// ��ȡƽ̨���Ű�����(���û�з����Ű�������ʾƽ̨�޵�ǰҽ�����Ű���Ϣ)
        /// </summary>
        /// <param name="bdate"></param>
        /// <param name="edate"></param>
        /// <param name="docid"></param>
        /// <param name="deptid"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
//        public string GetScheInfo(string bdate,string edate,string docid,string deptid, ref string msg)
//        {
//            string value = string.Empty;
//            try
//            {
//                string post = @"<PAYMENT>
//                                  <HEAD>
//                                    <ResponseCode></ResponseCode>
//                                    <ResponseMsg></ResponseMsg>
//                                    <Date></Date>
//                                    <tsCliePw>-1</tsCliePw>
//                                  </HEAD>
//                                  <DATA>
//                                    <tsQuerDate1></tsQuerDate1>
//                                    <tsQuerDate2></tsQuerDate2>
//                                    <DepId></DepId>
//                                    <tsIsNumber></tsIsNumber>
//                                    <tsInMemo></tsInMemo>
//                                  </DATA>
//                               </PAYMENT>";
//                value = Ts_Order.GetScheInfo(post);
//            }
//            catch (Exception ea)
//            {
//                msg += "��ȡƽ̨��ҽ���Ű����!ԭ��:" + ea.ToString();
//            }
//            return value;
//        }

        /// <summary>
        /// ����ԤԼ
        /// </summary>
        /// <param name="post">���xml</param>
        /// <param name="msg">ִ�к󷵻ص���Ϣ</param>
        /// <returns></returns>
        public bool CancelOrder(string ptid,string qhpwd,string czyh, ref string msg)
        {
            bool cancel_value = false;
            try
            {
                string post = @"<PAYMENT>
                                  <HEAD>
                                    <ResponseCode></ResponseCode>
                                    <ResponseMsg></ResponseMsg>
                                    <Date></Date>
                                    <tsCliePw>" + czyh + @"</tsCliePw>
                                  </HEAD>
                                  <DATA>
                                    <tsReseID>" + ptid + @"</tsReseID>
                                    <tsResePw>" + qhpwd + @"</tsResePw>
                                    <tsInMemo></tsInMemo>
                                  </DATA>
                                </PAYMENT>";
                string value = Ts_Order.GetRevoSubm(post);
                cancel_value = Analy.GetRevoSubmResult(value, ref msg);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return cancel_value;
        }

        /// <summary>
        /// �ͷ�ԤԼ��Դ
        /// </summary>
        /// <param name="_cfg3059"></param>
        /// <param name="_DataBase"></param>
        public static void UpdateYyResource(SystemCfg _cfg3059, RelationalDatabase _DataBase)
        {
            /*�ͷ�ָ��ʱ����ڻ�δȡ�ŵ�ԤԼ��Դ,�統ǰʱ��Ϊ8�� 8���ĺŻ�δ����ȡ�� �����������Ϊ
             ���Сʱδȡ�ž��ͷ�,���ͷŰ˵��ĺ�Դ*/
            string sql = @"  SELECT convert(varchar(10),getdate(),120),
            convert(varchar(16),DATEADD(MINUTE,(SELECT CAST(CONFIG AS INT)
            FROM JC_CONFIG WHERE ID=1127),GETDATE()),120),
            SUBSTRING(convert(varchar(16),getdate(),120),11,16) ";
            DataTable dt_Date = _DataBase.GetDataTable(sql);
            string Date_Now = dt_Date.Rows[0][0].ToString();
            string Time_Now = dt_Date.Rows[0][1].ToString();
            string HourMinute = dt_Date.Rows[0][2].ToString();
            sql = @"SELECT *,substring(YYSD,1,5) AS KSSJ ,substring(YYSD,7,5) as JSSJ FROM MZ_YYGHLB 
            WHERE CONVERT(VARCHAR(10),YYRQ,120)='" + Date_Now + @"' AND substring('" + Time_Now + @"',12,len('" + Time_Now + @"')) >=
            substring(YYSD,7,5) AND BQHBZ=0 AND BSCBZ=0";
            //��ȡ��Ҫ�ͷ���Դ��ԤԼ��¼
            DataTable dt_YYxx = _DataBase.GetDataTable(sql);
            Order_Web _orderMeans = new Order_Web(_cfg3059);
            for (int i = 0; i < dt_YYxx.Rows.Count; i++)
            {
                /*����ԤԼ��Ϣ,����Ҫ����ʱ���ж��Ƿ��ͷŷ�ʱ����Ϣ,���ԤԼ�ķ�ʱ��
                  ����ʱ��С�ڵ�ǰʱ������Ҫ�ͷ�
                 */
                try
                {
                    string ptid = Convertor.IsNull(dt_YYxx.Rows[i]["PTID"], "");
                    string qhyzm = dt_YYxx.Rows[i]["YZM"].ToString();
                    string czyh = dt_YYxx.Rows[i]["DJY"].ToString();
                    string msg = "";
                    _orderMeans.CancelOrder(ptid, qhyzm, czyh, ref msg);
                    //����ԤԼ��,��Ҫ�Է�ʱ����Դ���д���
                    //��ȡ��Դid
                    int ghks = Convert.ToInt32(dt_YYxx.Rows[i]["GHKS"]);
                    int ghjb = Convert.ToInt32(dt_YYxx.Rows[i]["GHJB"]);
                    int ghys = Convert.ToInt32(dt_YYxx.Rows[i]["GHYS"]);
                    string yydate = dt_YYxx.Rows[i]["YYRQ"].ToString();
                    VisitResource _Resource = new VisitResource(ghks, ghjb, ghys, yydate, _DataBase);
                    if (_Resource.Resid <= 0) return;

                    string kssj = dt_YYxx.Rows[i]["KSSJ"].ToString().Trim();
                    string jssj = dt_YYxx.Rows[i]["JSSJ"].ToString().Trim();
                    FsdClass.UpdateFsdStatus(_Resource.Resid, kssj, jssj, yydate, _DataBase);
                }
                catch (Exception ea)
                {
                    throw ea;
                }
            }

        }

    }
}

