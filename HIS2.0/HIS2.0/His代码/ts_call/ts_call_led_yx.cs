using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.IO;
using System.Runtime.Remoting.Channels.Tcp;
using ICommon;
using System.Runtime.Remoting.Channels;

namespace ts_call
{
    public class ts_call_led_yx:Icall
    {
        public static int isRegChannel = 0;
        public ts_call_led_yx()
        {

        }

        //public static readonly string tcpIp = "tcp://localhost:8080/";
        public static readonly string tcpIp = ApiFunction.GetIniString("�������ļ�·��", "����IP��ַ", Constant.ApplicationDirectory + "//ClientWindow.ini");

        public static readonly string showWind = ApiFunction.GetIniString("�������ļ�·��", "��ʾ����", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string WindCode = ApiFunction.GetIniString("�������ļ�·��", "���ڱ��", Constant.ApplicationDirectory + "//ClientWindow.ini");

        #region ע�ͣ�����
        //public static int A = 0;
        //public static readonly string debugFlag = ApiFunction.GetIniString("�������ļ�·��", "dll·��", Constant.ApplicationDirectory + "//ClientWindow.ini");
        //public static readonly string coms = ApiFunction.GetIniString("�������ļ�·��", "���ں�", Constant.ApplicationDirectory + "//ClientWindow.ini");
        //public static readonly string comType = ApiFunction.GetIniString("�������ļ�·��", "ͨѶ��������", Constant.ApplicationDirectory + "//ClientWindow.ini");
        //public static readonly string sIPs = ApiFunction.GetIniString("�������ļ�·��", "���ƿ�IP��ַ", Constant.ApplicationDirectory + "//ClientWindow.ini"); //���ػ�Զ�̿��ƿ�Ԥ���趨��IP��ַ
        //public static readonly string port_baud = ApiFunction.GetIniString("�������ļ�·��", "���Ӷ˿ں�", Constant.ApplicationDirectory + "//ClientWindow.ini"); //���������Ӧʱ��
        //public static readonly string delays = ApiFunction.GetIniString("�������ļ�·��", "���������Ӧʱ��", Constant.ApplicationDirectory + "//ClientWindow.ini"); //���������Ӧʱ��
        //public static readonly string addrs = ApiFunction.GetIniString("�������ļ�·��", "��ʾ����ַ", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ

        //public static readonly string effect = ApiFunction.GetIniString("�������ļ�·��", "���ŷ�ʽ", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ
        //public static readonly string level = ApiFunction.GetIniString("�������ļ�·��", "�ٶȼ���", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ
        //public static readonly string speed = ApiFunction.GetIniString("�������ļ�·��", "�����ٶ�", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ
        //public static readonly string delay = ApiFunction.GetIniString("�������ļ�·��", "ͣ��ʱ��", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ
        //public static readonly string font = ApiFunction.GetIniString("�������ļ�·��", "�����С", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ
        //public static readonly string showTitle = ApiFunction.GetIniString("�������ļ�·��", "�Ƿ���ʾ����", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ
        //public static readonly string titleColor = ApiFunction.GetIniString("�������ļ�·��", "������ɫ", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ
        //public static readonly string wordColor = ApiFunction.GetIniString("�������ļ�·��", "������ɫ", Constant.ApplicationDirectory + "//ClientWindow.ini"); //��ʾ����ַ

        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Com")]
        //private static extern int SS_Open_Com(int addr, int com, int baud, int delay);//�򿪴��ں���
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Tcp")]
        //private static extern int SS_Open_Tcp(string sIP, int port, int delay);//��TCP���Ӻ���
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Udp")]
        //private static extern int SS_Open_Udp(string sIP, int port, int delay);//��UDP���Ӻ���
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Close")]
        //private static extern void SS_Close();//�ر�ͨѶ����

        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Time")]
        //private static extern int SS_Send_Time();//���ƿ�ʱ��У��
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Reset")]
        //private static extern int SS_Send_Reset();//���ƿ���λ
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Replay")]
        //private static extern int SS_Send_Replay();
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List")]
        //private static extern string SS_Get_Window_List();//��ȡ���Ŵ����б�
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_File")]
        //private static extern int SS_Send_File(int W_index, ref TFileParam param, string ListFile, bool IsSave);//��ָ���Ĵ����д���ָ���ļ��б�����
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Buffer")]
        //private static extern int SS_Send_Buffer(int W_index, ref TFileParam param, string Buffer, bool IsSave);//��ָ���Ĵ����д���ָ���ַ�������
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Delete_File")]
        //private static extern int SS_Delete_File(int W_index);//ɾ��ָ���Ĵ����еı���Ĳ�������
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Buffer_Ex")]
        //private static extern int SS_Send_Buffer_Ex(int W_index, int Effect, int Speed, int Delay, int FontSize, int Color, string Buffer, bool IsSave);//�����ַ���
        ////[DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List_Ex")]
        ////private static extern int SS_Get_Window_List_Ex(string win_list);//��ȡ����
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Power_Off")]
        //private static extern int SS_Send_Power_Off();//�ر���ʾ��
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Power_On")]
        //private static extern int SS_Send_Power_On();//����ʾ��
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List_Ex")]
        //private static extern int SS_Get_Window_List_Ex(ref string win_list);//��ȡ���Ŵ����б�

        //[StructLayout(LayoutKind.Sequential,CharSet = CharSet.Auto) ]  
        //public struct TFileParam
        //{
        //    public byte Effect;		//���ŷ�ʽ 1~17������ע3��
        //    public byte Level;		//�ٶȼ��� 0~7 ��0����/7��죬�ٶȴֵ���
        //    public byte Speed;		//�����ٶ� 0~31��0���/31�������ٶ�΢����
        //    public byte Delay;		//ͣ��ʱ�� 0~99
        //    //���²��������ı��ļ���Ч��ͼ���ļ���Ϊ����ֵ
        //    public byte Font;	    //�����С 16��24
        //    public byte ShowTitle;	//�Ƿ���ʾ���� 0����/1��ʾ
        //    public byte TitleColor; //������ɫ 0��/1��/2��
        //    public byte WordColor;	//������ɫ 0��/1��/2��
        //}
        #endregion

        #region Icall ��Ա
        public ILedShow obj = null;
        private Thread currentThread;
        public Thread CurrentThread
        {
            get
            {
                return currentThread;
            }
            set
            {
                currentThread = value;
            }
        }

        public void Call(DmType dmtype, string callstring)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void Call(string ss, string zl)
        {
            //throw new Exception("The method or operation is not implemented.");
        }
    
        public void Call(DmType dmtype, string callstring, double je)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// ҩ����ҩ
        /// </summary>
        /// <param name="dmtype"></param>
        /// <param name="callstring"></param>
        /// <param name="je"></param>
        /// <param name="CFMX"></param>
        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            if (dmtype == DmType.��ҩ����)
            {
                try
                {
                    if (isRegChannel == 0)
                    {
                        ChannelServices.RegisterChannel(new TcpClientChannel(), false);
                        isRegChannel = 1;
                    }
                }
                catch (Exception ex)
                {
                    isRegChannel = 0;
                }
                try
                {
                    obj = (ILedShow)Activator.GetObject(typeof(ILedShow), tcpIp + "LED");
                    if (obj != null)
                    {
                        obj.SendMessage(CFMX[0].brxm, showWind, WindCode, CFMX[0].deptid.ToString());
                    }
                        //string patientName = "";
                        //string ssql = "select '' ";
                        //if (dmtype == DmType.��ҩ)
                        //{
                        //    patientName = "��ҩ����" + CFMX[0].fyck + "����Ϊ" + callstring + "��ҩ ";//+ "�ܽ��Ϊ��" + je.ToString()+"Ԫ";
                        //    //Display(patientName, 1);
                        //}
                        //string ss = "��" + CFMX[0].brxm + "��" + CFMX[0].fyck + "��ȡҩ";
                }
                catch (Exception er)
                {

                }
            }

         
            //if (dmtype == DmType.��ӭ)
            //{
            //    Get_Window_List();
            //}
            //if (dmtype == DmType.����ֵ)
            //{
            //    Send_Reset();
            //}
            //if (dmtype == DmType.���)
            //{
            //    Delete_File();
            //}
        }

        public void SetPicture(string picturename)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

    }
}
