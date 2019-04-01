using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ts_ReadCard
{
    public class ts_card_ShenSi:Icard
    {
        #region api
        /*
         * jianqg xiayu ��˼�����֤�ӿ�,��ʵ��ȫ�����������µ�
         * ,ֻ��Ҫ��װUsb����,����3��WltRS.dll,sdtapi.dll�ļ�(����������dll),����˼ ��װ����,��Ҫ��Ȩ
         * /
        * 
        ************************API�� *************************/

        //0x41:	��ʼ���˿�
            //0x42:	�رն˿�
            //0x43:	��֤��
            //0x44:	��������Ϣ
            //0x45:	������סַ��Ϣ
            //0x46:	����������Ϣ
            //0x47:	��������Ϣ��������ͼ�����
        [DllImport("ShenSi_RdCard.dll")]
        public static extern int UCommand(ref byte pcmd, ref int parg0, ref int parg1, ref int parg2);
        #endregion
        private int iPort;//USB�˿ں�
        private  int para1 = 8811, para2 = 9986;

        #region �򿪶˿� ��رն˿�
        /// <summary>
        /// �򿪶˿�
        /// </summary>
        /// <param name="err_text"></param>
        /// <returns></returns>
        public bool Openport(out string err_text)
        {

            iPort = 0;
            //USB
            for (int i = 1001; i < 1017; i++)
            {
                if (Testport(i, true, out err_text))
                {
                    iPort = i;
                    return true;
                }
            }
            //����
            for (int i = 1; i < 17; i++)
            {
                if (Testport(i, false, out err_text))
                {
                    iPort = i;
                    return true;
                  }

            }
            Closeport(iPort); //�رն˿ڻ򴮿�
            err_text = "��˼����������ʧ��";
            return false;
        }
        /// <summary>
        /// �رն˿ڻ򴮿ڷ���
        /// </summary>
        /// <param name="port">�˿ڻ��ߴ��ں�ID</param>
        /// <returns></returns>
        private bool Closeport(int port)
        {
            byte cmd = 0x42;//0x42 �رն˿ڲ���
            int  para1 = 8811, para2 = 9986;
            int iRetVal = UCommand(ref cmd, ref port, ref para1, ref para2);
            if (iRetVal == 62171) return true;
            else return false;
        }
        #endregion
        #region ���Զ˿�����(�򿪲��ر�)
        /// <summary>
        /// ���Զ˿�����(�򿪲��ر�)
        /// </summary>
        private bool Testport(int portTmp,bool IsUsb, out string err_text)
        {
            byte cmd = 65;//0x41��ʼ���˿�;
            int para0 = portTmp;
            int iRetVal = UCommand(ref cmd, ref para0, ref para1, ref para2);
            string msg = "����";
            if (IsUsb) msg = "USB";

            if (iRetVal == 62171)
            {
                Closeport(portTmp);
                err_text = "��˼���������ӳɹ�, ��" + portTmp.ToString() +  msg + "�˿���";
                return true;
            }
            else
            {
                Closeport(portTmp);
                err_text = "";
                return false;
            }
        }
        #endregion
        

        

        #region ��ȡ���֤��Ϣ
        /// <summary>
        /// ��ȡ���֤��Ϣ
        /// </summary>
        /// <param name="CardMsg">IDCardData���֤��Ϣ</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <returns>����false��ʾ�д���</returns>
        public bool ReadCard(ref IDCardData CardMsg, ref string msg)
        {

            try
            {
                #region �򿪶˿�-��֤��-����
                bool bok = Openport(out msg);
                if (bok == false)
                {
                    return bok;
                }

                byte cmd = 67; //0x43 //��֤��
                int nRet = UCommand(ref cmd, ref iPort, ref para1, ref para2);  //��֤��
                if (nRet != 62171)
                {
                    msg = "��֤��ʧ��,�����·ſ�����";
                    return false;
                }
                cmd = 68;//0x44 ��������Ϣ
                nRet = UCommand(ref cmd, ref iPort, ref para1, ref para2);  //����
                Closeport(iPort);
                #endregion
                #region ��ȡ��Ϣ
                if (nRet == 62171)
                {
                    #region ��ȡ��ϸ��Ϣ
                    string fileName = Application.StartupPath + "\\wx.txt";//��ȡ�ļ�·��
                    System.IO.StreamReader streamReader = new System.IO.StreamReader(fileName, Encoding.GetEncoding("GBK"));//���ļ��������

                    string[] sData = streamReader.ReadToEnd().ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);//���ַ�����ȡ�����뵽���鵱��

                    streamReader.Close();
                    if (sData.Length >= 9)
                    {
                        CardMsg.Name = sData[0].Trim();//�������Ϣ��ֵ
                        CardMsg.Sex = sData[1].Trim();
                        CardMsg.Nation = sData[2].Trim();
                        CardMsg.Born = sData[3].Trim();
                        CardMsg.Born = Convert.ToDateTime(CardMsg.Born).ToString("yyyy��MM��dd��");
                        CardMsg.Address = sData[4].Trim();
                        CardMsg.IDCardNo = sData[5].Trim();
                        CardMsg.GrantDept = sData[6].Trim();
                        CardMsg.UserLifeBegin = sData[7].Trim();
                        CardMsg.UserLifeBegin = Convert.ToDateTime(CardMsg.UserLifeBegin).ToString("yyyyMMdd");
                        CardMsg.UserLifeEnd = sData[8].Trim();
                        CardMsg.UserLifeEnd = Convert.ToDateTime(CardMsg.UserLifeEnd).ToString("yyyyMMdd");
                        CardMsg.PhotoFileName = Application.StartupPath + "\\zp.bmp";//��ȡ��Ƭ�ļ�·��
                        return true;
                    }
                    else
                    {
                        msg = "��ȡ���֤��Ϣ������";
                        return false;
                    }
                    #endregion
                }
                else if (nRet == -5)
                {
                    msg = "��˼������û����Ȩ";
                    return false;

                }
                else
                {
                    msg = "����ʧ��";
                    return false;
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("��������" + ex.Message);
            }



     

        }
        #endregion

        #region  ��ȡ���֤��Ϣ���ؼ�
        /// <summary>
        /// ��ȡ���֤��Ϣ���ؼ�
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="msg">������ʾ��Ϣ</param>
        /// <param name="errAutoMsg">����ʱ�Ƿ��Զ�������ʾ����</param>
        /// <param name="txtName">����</param>
        /// <param name="combXb">�Ա�</param>
        /// <param name="txtYear">���������£���</param>
        /// <param name="txtMonth">���������£���</param>
        /// <param name="txtDay">���������£���</param>
        /// <param name="txtDz">סַ����ַ</param>
        /// <param name="txtSfz">���֤��</param>
        /// <param name="comMz">����</param>
        /// <returns></returns>
        public bool ReadCardToControl(ref IDCardData CardMsg, ref string msg, bool errAutoMsg,
            Control txtName, Control combXb, Control txtYear, Control txtMonth, Control txtDay, Control txtDz, Control txtSfz, Control comMz)
        {

            bool flag = this.ReadCard(ref CardMsg, ref msg);
            if (flag)
            {
                this.ReadCardToControl(CardMsg, txtName, combXb, txtYear, txtMonth, txtDay, txtDz, txtSfz, comMz);
            }
            else if (errAutoMsg == true)
            {
                MessageBox.Show(msg, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            return flag;

        }
        #endregion
        #region  ��ȡ���֤��Ϣ���ؼ�
        /// <summary>
        /// ��CardMsg��Ϣ ���õ��ؼ�
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="txtName">����</param>
        /// <param name="combXb">�Ա�</param>
        /// <param name="txtYear">���������£���</param>
        /// <param name="txtMonth">���������£���</param>
        /// <param name="txtDay">���������£���</param>
        /// <param name="txtDz">סַ����ַ</param>
        /// <param name="txtSfz">���֤��</param>
        /// <param name="comMz">����</param>
        /// <returns></returns>
        public void ReadCardToControl(IDCardData CardMsg,
            Control txtName, Control combXb, Control txtYear, Control txtMonth, Control txtDay, Control txtDz, Control txtSfz, Control comMz)
        {

            bool flag = false;
            PubFun.ReadCardToControl(CardMsg, txtName, combXb, txtYear, txtMonth, txtDay, txtDz, txtSfz, comMz);
        }
        #endregion


 
    }
}
