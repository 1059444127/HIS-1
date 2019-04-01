using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Data;
using System.Net;
using System.Xml;

namespace ts_yf_mzkf
{
    public class ts_whzxyyNy_mzkf : IMzkf
    {
        #region IMzkf ��Ա

        private TrasenClasses.DatabaseAccess.RelationalDatabase _db;
        public TrasenClasses.DatabaseAccess.RelationalDatabase DataBase
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        private string _xm;
        public string Brxm
        {
            get
            {
                return _xm;
            }
            set
            {
                _xm = value;
            }
        }

        private string _brxxid;
        public string Brxxid
        {
            get
            {
                return _brxxid;
            }
            set
            {
                _brxxid = value;
            }
        }

        private string WanIp
        {
            get
            {
                try
                {
                    System.Net.IPAddress addr;
                    addr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                    return addr.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbInfo"></param>
        /// <param name="strWinid"></param>
        /// <param name="strManno"></param>
        /// <param name="strManname"></param>
        /// <param name="strIP"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public int SendMedicine(System.Data.DataTable tbInfo, string strWinid, string strManno, string strManname, string strIP, int deptid, string str_HH_Flag)
        {
            if (tbInfo.Rows.Count <= 0)
            {
               // ThrowTechError("MZYF.SelectMzcfk�������ص�����Ϊ��", 1, new List<string>(), strWinid, WanIp, deptid);
                return 101;
            }
            StringBuilder strXml = new StringBuilder();
            //strXml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            strXml.Append("<ROOT>");
            strXml.Append("<OPSYSTEM>HIS</OPSYSTEM>");
            strXml.Append("<OPWINID>" + strWinid + "</OPWINID>");
            strXml.Append("<OPTYPE>202</OPTYPE>");          
            strXml.Append("<OPIP>" + WanIp + "</OPIP>");
            strXml.Append("<OPMANNO>" + strManno + "</OPMANNO>");
            strXml.Append("<OPMANNAME>" + strManname + "</OPMANNAME>");           
            string _prescNo = "";
            bool param = false;
            List<string> cfdList = new List<string>();
            List<string> cache = new List<string>();



            for (int k = 0; k < tbInfo.Rows.Count; k++)
            {
                object cfid = tbInfo.Rows[k]["CFXH"];   //mz_cfb cfid
                object hjid = tbInfo.Rows[k]["������"]; //mz_cfb hjid
                if (cfid == null || cfid.ToString().Trim() == string.Empty)
                {
                    //ThrowTechError("tbInfo.Rows[k][CFXH]Ϊ��", 1, new List<string>(), strWinid, WanIp, deptid);
                    continue;
                }
                else
                {
                    //ҩ��ֱ����ֱ��ȡ����2.0��Ĵ���ID������ͨ��WSȡ3.0������ Add By HYD 2017-11-22
                    string strIDDh = tbInfo.Rows[k]["cfxh"].ToString();
                    strXml.Append("<CONSIS_PRESC_MSTVW>");
                    // strXml.Append("<PRESC_DATE>" + Convert.ToDateTime( tbInfo.Rows[k]["¼������"]).ToString("yyyy-MM-dd HH:mm:ss") + "</PRESC_DATE>");
                    strXml.Append("<PRESC_DATE>" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</PRESC_DATE>");//add by hyd �췢Ҫ��˴�����ǰ����ʱ�� 2016-12-22
                    // strXml.Append("<PRESC_NO>" + dt.Rows[0][0] + "</PRESC_NO>");// ԭ��
                    strXml.Append("<PRESC_NO>" + strIDDh + "</PRESC_NO>");
                    strXml.Append("<INVOICE_NO></INVOICE_NO>");
                    strXml.Append("<DISPENSARY>" + deptid + "</DISPENSARY>");
                    strXml.Append("</CONSIS_PRESC_MSTVW>");
                    // cfdList.Add(dt.Rows[0][0].ToString());//ԭ��
                    cfdList.Add(strIDDh);

                    cache.Add(tbInfo.Rows[k]["cfxh"].ToString());
                    _prescNo = tbInfo.Rows[k]["cfxh"] != null ? tbInfo.Rows[k]["cfxh"].ToString().Trim() : ""; //tbInfo.Rows[k]["������"].ToString().Trim();
                    param = true;
                }

                /*
                if (cache.Count == 0 || string.IsNullOrEmpty(cache.Find(delegate(string s) { return s == tbInfo.Rows[k]["cfxh"].ToString(); })))
                {
                    int num = 0;
                Label001:
                    {
                        string sql = string.Format("select dh,djhm from whzxyy_mz_cfb_zb where cfid = '{0}'", tbInfo.Rows[k]["cfxh"]);
                        DataTable dt = DataBase.GetDataTable(sql); 

                        if (dt != null && dt.Rows.Count > 0)
                        {

                            //*******************************2017-01-06 HYD*****************************************
                            ts_yf_mzkf.TrasenWS.TrasenWS TsWs = new ts_yf_mzkf.TrasenWS.TrasenWS();
                            string strIDDh = string.Empty;
                            string strdjhm = dt.Rows[0]["dh"].ToString();
                            string PostString = "<root><djhm>" + dt.Rows[0]["djhm"].ToString() + "</djhm><dh>" + dt.Rows[0]["dh"].ToString() + "</dh></root>";

                            string strNewDh = TsWs.ExeWebService("GetKfPrescNoByDh", PostString);
                            if (strNewDh != "")
                            {
                                strIDDh = strNewDh;
                            }
                            else
                            {
                                strIDDh = strdjhm;
                            }
                            //***********************************2017-01-06 HYD************************************

                            strXml.Append("<CONSIS_PRESC_MSTVW>");
                           // strXml.Append("<PRESC_DATE>" + Convert.ToDateTime( tbInfo.Rows[k]["¼������"]).ToString("yyyy-MM-dd HH:mm:ss") + "</PRESC_DATE>");
                            strXml.Append("<PRESC_DATE>" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</PRESC_DATE>");//add by hyd �췢Ҫ��˴�����ǰ����ʱ�� 2016-12-22
                           // strXml.Append("<PRESC_NO>" + dt.Rows[0][0] + "</PRESC_NO>");// ԭ��
                            strXml.Append("<PRESC_NO>" + strIDDh + "</PRESC_NO>");
                            strXml.Append("<INVOICE_NO></INVOICE_NO>");
                            strXml.Append("<DISPENSARY>" + deptid + "</DISPENSARY>");
                            strXml.Append("</CONSIS_PRESC_MSTVW>");

                           // cfdList.Add(dt.Rows[0][0].ToString());//ԭ��
                            cfdList.Add(strIDDh);

                            cache.Add(tbInfo.Rows[k]["cfxh"].ToString());
                            _prescNo = tbInfo.Rows[k]["cfxh"] != null ? tbInfo.Rows[k]["cfxh"].ToString().Trim() : ""; //tbInfo.Rows[k]["������"].ToString().Trim();
                            param = true;
                        }
                        else if (num <= 3)
                        {
                            num++;
                            Thread.Sleep(2000);
                            goto Label001;
                        }
                        else
                        {
                           //ThrowTechError("δ�ҵ�����", 1, new List<string>(), strWinid, WanIp, deptid);
                            return 102;
                        }
                    }
                }*/
            }
            strXml.Append("</ROOT>");
            if (param == false)
                return 103;
            string result = string.Empty;
            string retValue = "0";
            string retMsg = "";
            try
            {
                NyMzkf.ServiceHis ws = new NyMzkf.ServiceHis();
                HHMZKF.ServiceHis wsHH = new ts_yf_mzkf.HHMZKF.ServiceHis();

                //��1 ��ʾ����Ժ�Ŀ췢�����ַ�������ú���Ŀ췢�����ַ
                if (str_HH_Flag.Equals("1"))
                {
                    result = wsHH.HisTransData(strXml.ToString());
                }
                else
                {                    
                    result = ws.HisTransData(strXml.ToString());
                }

                //if (!string.IsNullOrEmpty(result) && result.IndexOf("�Ŷ�����") >= 0)
                //{
                //    return 200;
                //}
               // return Convert.ToInt32( result);

                StringBuilder RetXml = new StringBuilder();
                RetXml.Append(result);
                XmlDocument xx = new XmlDocument();
                xx.LoadXml(RetXml.ToString());

                XmlNodeList xxlist = xx.SelectNodes("/ROOT");
                retValue = (xxlist[0].SelectSingleNode("//RETCODE")).InnerText.Trim();
                retMsg = (xxlist[0].SelectSingleNode("//RETMSG")).InnerText.Trim();


                return Convert.ToInt32(retValue);
            }
            catch (Exception err)
            {
               // ThrowTechError(result + " " + err.Message, 1, cfdList, strWinid, WanIp, deptid);
                return 104;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbInfo"></param>
        /// <param name="strWinid"></param>
        /// <param name="strManno"></param>
        /// <param name="strManname"></param>
        /// <param name="strIP"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public string EndToMedicine(System.Data.DataTable tbInfo, string strWinid, string strManno, string strManname, string strIP, int deptid,string str_HH_Flag)
        {
            if (tbInfo.Rows.Count <= 0)
            {
                //ThrowTechError("DataTable������Ϊ��", 2, new List<string>(), strWinid, WanIp, deptid);
                return "101";
            }
            StringBuilder strXml = new StringBuilder();
            //strXml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");        
            strXml.Append("<ROOT>");
            strXml.Append("<OPSYSTEM>HIS</OPSYSTEM>");
            strXml.Append("<OPWINID>" + strWinid + "</OPWINID>");
            strXml.Append("<OPTYPE>203</OPTYPE>");            
            strXml.Append("<OPIP>" + WanIp + "</OPIP>");
            strXml.Append("<OPMANNO>" + strManno + "</OPMANNO>");
            strXml.Append("<OPMANNAME>" + strManname + "</OPMANNAME>");
            bool param = false;
            List<string> cfdList = new List<string>();
            List<string> cache = new List<string>();
            for (int k = 0; k < tbInfo.Rows.Count; k++)
            {
                object cfid = tbInfo.Rows[k]["CFXH"];   //mz_cfb cfid
                object hjid = tbInfo.Rows[k]["������"]; //mz_cfb hjid
                if (cfid == null || cfid.ToString().Trim() == string.Empty)
                {
                    continue;
                }
                else
                {
                    //ҩ��ֱ����ֱ��ȡ����2.0��Ĵ���ID������ͨ��WSȡ3.0������ Add By HYD 2017-11-22
                    string strIDDh = tbInfo.Rows[k]["CFXH"].ToString();

                    strXml.Append("<CONSIS_PRESC_MSTVW>");
                    // strXml.Append("<PRESC_DATE>" + Convert.ToDateTime(tbInfo.Rows[k]["¼������"]).ToString("yyyy-MM-dd HH:mm:ss") + "</PRESC_DATE>");
                    strXml.Append("<PRESC_DATE>" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</PRESC_DATE>");
                    // strXml.Append("<PRESC_NO>" + dt.Rows[0][0] + "</PRESC_NO>");//ԭ��
                    strXml.Append("<PRESC_NO>" + strIDDh + "</PRESC_NO>");
                    strXml.Append("<INVOICE_NO></INVOICE_NO>");
                    strXml.Append("<DISPENSARY>" + deptid + "</DISPENSARY>");
                    strXml.Append("</CONSIS_PRESC_MSTVW>");
                    cache.Add(tbInfo.Rows[k]["CFXH"].ToString().Trim());
                    // cfdList.Add(dt.Rows[0][0].ToString());//ԭ��
                    cfdList.Add(strIDDh);
                    param = true;
                }

                /*
                if ((cache.Count == 0 || string.IsNullOrEmpty(cache.Find(delegate(string s) { return s == tbInfo.Rows[k]["CFXH"].ToString(); }))) &&
                    tbInfo.Rows[k]["���"].ToString().Trim() != "С��")
                {
                    int num = 0;
                Label001:
                    {
                        string sql = string.Format("select dh,djhm from whzxyy_mz_cfb_zb where cfid = '{0}'", tbInfo.Rows[k]["CFXH"]);
                        DataTable dt = DataBase.GetDataTable(sql);                        


                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //*************************2017-01-06 HYD *********************************************
                            ts_yf_mzkf.TrasenWS.TrasenWS TsWs = new ts_yf_mzkf.TrasenWS.TrasenWS();
                            string strIDDh = string.Empty;
                            string strdjhm = dt.Rows[0]["dh"].ToString();
                            string PostString = "<root><djhm>" + dt.Rows[0]["djhm"].ToString() + "</djhm><dh>" + dt.Rows[0]["dh"].ToString() + "</dh></root>";

                            string strNewDh = TsWs.ExeWebService("GetKfPrescNoByDh", PostString);
                            if (strNewDh != "")
                            {
                                strIDDh = strNewDh;
                            }
                            else
                            {
                                strIDDh = strdjhm;
                            }
                            //**************************************************************************************

                            strXml.Append("<CONSIS_PRESC_MSTVW>");
                           // strXml.Append("<PRESC_DATE>" + Convert.ToDateTime(tbInfo.Rows[k]["¼������"]).ToString("yyyy-MM-dd HH:mm:ss") + "</PRESC_DATE>");
                            strXml.Append("<PRESC_DATE>" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</PRESC_DATE>");
                           // strXml.Append("<PRESC_NO>" + dt.Rows[0][0] + "</PRESC_NO>");//ԭ��
                            strXml.Append("<PRESC_NO>" + strIDDh + "</PRESC_NO>");
                            strXml.Append("<INVOICE_NO></INVOICE_NO>");
                            strXml.Append("<DISPENSARY>" + deptid + "</DISPENSARY>");
                            strXml.Append("</CONSIS_PRESC_MSTVW>");
                            cache.Add(tbInfo.Rows[k]["CFXH"].ToString().Trim());
                           // cfdList.Add(dt.Rows[0][0].ToString());//ԭ��
                            cfdList.Add(strIDDh);
                            param = true;
                        }
                        else if (num <= 3)
                        {
                            num++;
                            Thread.Sleep(2000);
                            goto Label001;
                        }
                        else
                        {
                           // ThrowTechError("δ�ҵ�����", 2, new List<string>(), strWinid, WanIp, deptid);
                            return "102";
                        }
                    }
                }*/
            }
            strXml.Append("</ROOT>");
            if (param == false)
                return "103";
            string result = string.Empty;
            string retValue = "0";
            string retMsg = "";
            try
            {
                NyMzkf.ServiceHis ws = new NyMzkf.ServiceHis();
                HHMZKF.ServiceHis wsHH = new ts_yf_mzkf.HHMZKF.ServiceHis();

                //��1 ��ʾ����Ժ�Ŀ췢�����ַ�������ú���Ŀ췢�����ַ
                if (str_HH_Flag.Equals("1"))
                {
                    result = wsHH.HisTransData(strXml.ToString());
                }
                else
                {                    
                    result = ws.HisTransData(strXml.ToString());
                }

                StringBuilder RetXml = new StringBuilder();
                RetXml.Append(result);
                XmlDocument xx = new XmlDocument();
                xx.LoadXml(RetXml.ToString());

                XmlNodeList xxlist = xx.SelectNodes("/ROOT");
                retValue = (xxlist[0].SelectSingleNode("//RETCODE")).InnerText.Trim();
                retMsg = (xxlist[0].SelectSingleNode("//RETMSG")).InnerText.Trim();


                return retValue;
            }
            catch (Exception err)
            {
                //ThrowTechError(result + " " + err.Message, 2, cfdList, strWinid, WanIp, deptid);
                return "104";
            }
        }

        #endregion
    }
}
