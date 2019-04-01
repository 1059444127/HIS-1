using System;
using System.Collections.Generic;
using System.Text;

namespace LED_RemotingServer
{
    /// <summary>
    /// ״̬
    /// </summary>
    public enum StateInfo
    {
        /// <summary>
        /// δ����
        /// </summary>
        none=0,
        /// <summary>
        /// ����
        /// </summary>
        runing 
    }
    public class WindowsInfo
    {
        public WindowsInfo(string winnum)
        {
            this.wincode = winnum;
        }

        private string wincode = string.Empty;
        private string calling = string.Empty;
        private string winname = string.Empty;
        private DateTime callTime = DateTime.Now;
        private StateInfo state = StateInfo.none;

        /// <summary>
        /// ��������
        /// </summary>
        public string WinName
        {
            get { return winname; }
            set { winname = value; }
        }

        /// <summary>
        /// ���ڱ���
        /// </summary>
        public string WinCode
        {
            get { return wincode; }
            set { wincode = value; }
        }

        /// <summary>
        /// ��ǰ���ڽкŻ�������
        /// </summary>
        public string Calling
        {
            get { return calling; }
            set { calling = value; }
        }


        /// <summary>
        /// �к�ʱ��
        /// </summary>
        public DateTime CallTime
        {
            get { return callTime; }
            set { callTime = value; }
        }

        ///// <summary>
        ///// ����״̬
        ///// </summary>
        //public StateInfo State
        //{
        //    get { return state; }
        //    set { state = value; }
        //}
    }
}
