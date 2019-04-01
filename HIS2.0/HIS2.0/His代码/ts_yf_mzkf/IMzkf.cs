using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;

namespace ts_yf_mzkf
{
    public interface IMzkf
    {
        RelationalDatabase DataBase
        {
            get;
            set;
        }

        string Brxm
        {
            get;
            set;
        }

        string Brxxid
        {
            get;
            set;
        }       
       
 

        /// <summary>
        /// ������ʼ��ҩ
        /// </summary>
        /// <param name="tbInfo">������Ϣ</param>
        /// <param name="strWinid">���ں�</param>
        /// <param name="strManno">����Ա���</param>
        /// <param name="strManname">����Ա</param>
        /// <param name="strIP">IP��ַ</param>
        int SendMedicine(DataTable tbInfo, string strWinid, string strManno, string strManname, string strIP,int deptid,string str_HH_Flag);

        /// <summary>
        /// ����������ҩ
        /// </summary>
        /// <param name="tbInfo">������Ϣ</param>
        /// <param name="strWinid">���ں�</param>
        /// <param name="strManno">����Ա���</param>
        /// <param name="strManname">����Ա</param>
        /// <param name="strIP">IP��ַ</param>
        string EndToMedicine(DataTable tbInfo, string strWinid, string strManno, string strManname, string strIP, int deptid, string str_HH_Flag);


    }
}
