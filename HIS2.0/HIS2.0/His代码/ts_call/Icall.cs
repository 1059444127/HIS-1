using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ts_call
{
    public enum DmType
    {
        Ӧ��,
        ʵ��,
        ����,
        ����,
        ��ӭ,
        ���,
        ��ҩ,
        ��ҩ����,
        ����ֵ,
        �ܷ���
    }
    public struct CFMX
    {
        public string PM;
        public string GG;
        public decimal DJ;
        public decimal SL;
        public string DW;
        public decimal JE;
        public string fph;
        public string brxm;
        //public string blh;
        //public string fpid;
        //public string brxxid;
        public int deptid;
        public string fyck;
       
    }
    public interface Icall
    {
        Thread CurrentThread
        {
            get;
            set;
        }
        /// <summary>
        /// ������ʾ
        /// </summary>
        /// <param name="dmtype">ö������</param>
        /// <param name="callstring">��ʾ�ַ���</param>
        void Call(DmType dmtype, string callstring);
        /// <summary>
        /// ʵ������������ʾ
        /// </summary>
        /// <param name="ss">ʵ��</param>
        /// <param name="zl">����</param>
        void Call(string ss, string zl);
        /// <summary>
        /// ������ʾ
        /// </summary>
        /// <param name="dmtype">ö������</param>
        /// <param name="callstring">��ʾ�ַ���</param>
        /// <param name="je">���</param>
        void Call(DmType dmtype, string callstring, double je);
        void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX);

        
        /// <summary>
        /// ͼƬ����
        /// </summary>
        /// <param name="picturename"></param>
        void SetPicture(string picturename);
    }       
}
