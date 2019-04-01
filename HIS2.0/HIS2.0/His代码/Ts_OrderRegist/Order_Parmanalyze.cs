using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace Ts_OrderRegist
{
    /// <summary>
    /// ������ƽ̨���صĳ��� add by zp 2013-01-04
    /// </summary>
    public class Order_Parmanalyze
    {
        DataTable dt_orderTime;
        XmlDocument doc = new XmlDocument();
        /// <summary>
        /// ��ȡԤԼ���溯�����صĽ�� true�ɹ� falseʧ��
        /// </summary>
        /// <param name="post">webservice���صĳ���</param>
        /// <param name="record_id">ƽ̨������ˮ��</param>
        /// <param name="msg">ʧ�ܷ��ص�ԭ�� �ɹ����ص�ȡ������</param>
        /// <param name="hisorderid">hisԤԼid</param>
        /// <returns></returns>
        public bool GetOrderSaveResult(string post,ref string record_id,ref string msg,ref string hisorderid)
        {
            bool savevalue = false;
            try
            {
                savevalue = IsResult(post, ref msg);
                if (!savevalue)
                {
                    return false;
                }
                XmlElement Chid_Elent = doc.DocumentElement;
                foreach (XmlElement _childet in Chid_Elent.ChildNodes)
                {
                    if (_childet.Name == "DATA")
                    {
                        foreach (XmlElement _et_Data in _childet.ChildNodes)
                        {
                            if (_et_Data.Name == "tsResePw") //��ȡȡ������
                            {
                                msg += _et_Data.InnerText;                                
                            }

                            if (_et_Data.Name == "tsReseID")
                            {
                                record_id = _et_Data.InnerText; //��ȡƽ̨������ˮ��
                            }

                            if (_et_Data.Name == "tsReseHisID")
                            {
                                hisorderid = _et_Data.InnerText;
                            }
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                msg += ea.ToString();
            }
            return savevalue;
        }
        /// <summary>
        /// ��ȡ����ԤԼ�������صĽ��
        /// </summary>
        /// <param name="post">webservice���صĳ���</param>
        /// <param name="msg">��Ϣ</param>
        /// <returns></returns>
        public bool GetRevoSubmResult(string post, ref string msg)
        {
            bool Result = false;
            try
            {
                Result = IsResult(post,ref msg);
            }
            catch (Exception ea)
            {
                msg += ea.ToString();
            }
            return Result;

        }
        /// <summary>
        /// ���ؾ���һ��ʱ�ε�ҽ����Դ���Լ�rowidֵ
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public DataTable GetOrderTimes(string post)
        {
            bool Result=false;
             string msg = string.Empty;
            if (dt_orderTime == null)
            {
                dt_orderTime = new DataTable();
                DataColumn dc1 = new DataColumn("NumberID");
                DataColumn dc2 = new DataColumn("rowid");
                DataColumn dc3 = new DataColumn("tsTimeRange");
                DataColumn dc4 = new DataColumn("tsTimeSlot");
                DataColumn dc5 = new DataColumn("tsRegisterCount");
                DataColumn dc6 = new DataColumn("tsSumCount");
                dt_orderTime.Columns.Add(dc1);
                dt_orderTime.Columns.Add(dc2);
                dt_orderTime.Columns.Add(dc3);
                dt_orderTime.Columns.Add(dc4);
                dt_orderTime.Columns.Add(dc5);
                dt_orderTime.Columns.Add(dc6);
            }
            dt_orderTime.Clear();
            try
            {
                Result = IsResult(post, ref msg);
                if (!Result)
                {
                    throw new Exception("���ִ���:" + msg);
                }
                 doc.LoadXml(post);
                 XmlElement Chid_Elent = doc.DocumentElement;
                 DataRow dr = null;
                 foreach (XmlElement et in Chid_Elent.SelectSingleNode("DATA").ChildNodes)
                 {
                     dr = dt_orderTime.NewRow();
                        foreach (XmlElement _et_data in et.ChildNodes)
                         {
                                 switch (_et_data.Name)
                                 {
                                     case "NumberID":
                                         dr["NumberID"] = _et_data.InnerText;
                                         break;
                                     case "tsRowID":
                                         dr["rowid"] = _et_data.InnerText;
                                         break;
                                     case "tsTimeRange":
                                         dr["tsTimeRange"] = _et_data.InnerText.Trim();
                                         break;
                                     case "tsTimeSlot"://ʱ��
                                         dr["tsTimeSlot"] = _et_data.InnerText;
                                         break;
                                     case "tsRegisterCount": //�ѹҺ���
                                         dr["tsRegisterCount"] = _et_data.InnerText;
                                         break;
                                     case "tsSumCount": //ԤԼ�޺�����
                                         dr["tsSumCount"] = _et_data.InnerText;
                                         break;
                                 }
                         }
                         if (dr != null)
                         {
                             dt_orderTime.Rows.Add(dr);
                         }
                 }
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt_orderTime;
        }

        /// <summary>
        /// ���س��ε�ִ�н��
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public bool IsResult(string post,ref string msg)
        {
            bool Result = false;
            doc.LoadXml(post);
            XmlElement Chid_Elent = doc.DocumentElement;
            foreach (XmlElement et in Chid_Elent.ChildNodes)
            {
                if (et.Name == "HEAD")
                {
                    foreach(XmlElement _et_head in et.ChildNodes)
                        if (_et_head.Name == "RESPONSECODE")
                    {
                        if (Convertor.IsNull(_et_head.InnerText, "1") != "0")//ʧ���򷵻�
                        {
                            msg = et.SelectSingleNode("RESPONSEMSG").InnerText;
                            return Result;
                        }
                        Result = true;
                        break;
                    }
                }
            }
            return Result;
            
        }

    }
}
