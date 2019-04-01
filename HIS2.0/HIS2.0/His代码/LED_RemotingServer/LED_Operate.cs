using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.IO;

namespace LED_RemotingServer
{
    public class LED_Operate
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public LED_Operate()
        {
 
        }

        public static int A = 0;
        public static readonly string debugFlag = ApiFunction.GetIniString("LED������", "dll·��", Constant.ApplicationDirectory + "//LedCalling.ini");
        public static readonly string coms = ApiFunction.GetIniString("LED������", "���ں�", Constant.ApplicationDirectory + "//LedCalling.ini");
        public static readonly string comType = ApiFunction.GetIniString("LED������", "ͨѶ��������", Constant.ApplicationDirectory + "//LedCalling.ini");
        public static readonly string sIPs = ApiFunction.GetIniString("LED������", "���ƿ�IP��ַ", Constant.ApplicationDirectory + "//LedCalling.ini"); //���ػ�Զ�̿��ƿ�Ԥ���趨��IP��ַ
        public static readonly string port_baud = ApiFunction.GetIniString("LED������", "���Ӷ˿ں�", Constant.ApplicationDirectory + "//LedCalling.ini"); //���������Ӧʱ��
        public static readonly string delays = ApiFunction.GetIniString("LED������", "���������Ӧʱ��", Constant.ApplicationDirectory + "//LedCalling.ini"); //���������Ӧʱ��
        public static readonly string addrs = ApiFunction.GetIniString("LED������", "��ʾ����ַ", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ

        public static readonly string effect = ApiFunction.GetIniString("LED������", "���ŷ�ʽ", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ
        public static readonly string level = ApiFunction.GetIniString("LED������", "�ٶȼ���", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ
        public static readonly string speed = ApiFunction.GetIniString("LED������", "�����ٶ�", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ
        public static readonly string delay = ApiFunction.GetIniString("LED������", "ͣ��ʱ��", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ
        public static readonly string font = ApiFunction.GetIniString("LED������", "�����С", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ
        public static readonly string showTitle = ApiFunction.GetIniString("LED������", "�Ƿ���ʾ����", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ
        public static readonly string titleColor = ApiFunction.GetIniString("LED������", "������ɫ", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ
        public static readonly string wordColor = ApiFunction.GetIniString("LED������", "������ɫ", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ
        public static readonly string sfzy = ApiFunction.GetIniString("LED������", "�ͷ���Դ", Constant.ApplicationDirectory + "//LedCalling.ini"); //��ʾ����ַ

        public static readonly string qingpingshijian = ApiFunction.GetIniString("LED������", "����ʱ��", Constant.ApplicationDirectory + "//LedCalling.ini"); //����ʱ�� ����
        public static readonly string yuying_xuhao = ApiFunction.GetIniString("LED������", "�������", Constant.ApplicationDirectory + "//LedCalling.ini"); //�������
        public static readonly string yuying_sudu = ApiFunction.GetIniString("LED������", "�����ٶ�", Constant.ApplicationDirectory + "//LedCalling.ini"); //�����ٶ�
        public static readonly string yuying_yingliang = ApiFunction.GetIniString("LED������", "��������", Constant.ApplicationDirectory + "//LedCalling.ini"); //��������

        [StructLayout(LayoutKind.Sequential)]
        public struct TFileParam
        {
            public byte Effect;		//���ŷ�ʽ 1~17������ע3��
            public byte Level;		//�ٶȼ��� 0~7 ��0����/7��죬�ٶȴֵ���
            public byte Speed;		//�����ٶ� 0~31��0���/31�������ٶ�΢����
            public byte Delay;		//ͣ��ʱ�� 0~99
            //���²��������ı��ļ���Ч��ͼ���ļ���Ϊ����ֵ
            public byte Font;	    //�����С 16��24
            public byte ShowTitle;	//�Ƿ���ʾ���� 0����/1��ʾ
            public byte TitleColor; //������ɫ 0��/1��/2��
            public byte WordColor;	//������ɫ 0��/1��/2��
        }

        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Com")]
        private static extern int SS_Open_Com(int addr, int com, int baud, int delay);//�򿪴��ں���
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Tcp")]
        private static extern int SS_Open_Tcp(string sIP, int port, int delay);//��TCP���Ӻ���
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Udp")]
        private static extern int SS_Open_Udp(string sIP, int port, int delay);//��UDP���Ӻ���
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Close")]
        private static extern void SS_Close();//�ر�ͨѶ����

        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Time")]
        private static extern int SS_Send_Time();//���ƿ�ʱ��У��
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Reset")]
        private static extern int SS_Send_Reset();//���ƿ���λ
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Replay")]
        private static extern int SS_Send_Replay();
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List")]
        private static extern string SS_Get_Window_List();//��ȡ���Ŵ����б�
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_File")]
        private static extern int SS_Send_File(int W_index, ref TFileParam param, string ListFile, bool IsSave);//��ָ���Ĵ����д���ָ���ļ��б�����
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Buffer")]
        private static extern int SS_Send_Buffer(int W_index, ref TFileParam param, string Buffer, bool IsSave);//��ָ���Ĵ����д���ָ���ַ�������
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Delete_File")]
        private static extern int SS_Delete_File(int W_index);//ɾ��ָ���Ĵ����еı���Ĳ�������
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Buffer_Ex")]
        private static extern int SS_Send_Buffer_Ex(int W_index, int Effect, int Speed, int Delay, int FontSize, int Color, string Buffer, bool IsSave);//�����ַ���
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List_Ex")]
        //private static extern int SS_Get_Window_List_Ex(string win_list);//��ȡ����
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Power_Off")]
        private static extern int SS_Send_Power_Off();//�ر���ʾ��
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Power_On")]
        private static extern int SS_Send_Power_On();//����ʾ��
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List_Ex")]
        private static extern int SS_Get_Window_List_Ex(ref string win_list);//��ȡ���Ŵ����б�

        //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
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

      
        /// <summary>
        /// ��ʾ������Ϣ
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="w_index"></param>
        /// <returns></returns>
        public bool Display(string strName, int w_index)
        {
            try
            {
                toText("������־", "LED��ʾ��" + strName);
                if (!Open_Led())
                    return false;
                //System.Threading.Thread.Sleep(50);
                if (!Send_Buffer(strName, w_index))
                    return false;
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                toText("������־", "LED��ʾ���ݷ���ʧ�ܣ�" + ex.Message);
                return false;
            }
        }

        #region ���Ժ���
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        private bool Get_Window_List()
        {
            string win_list = "";
            try
            {
                if (!Open_Led())
                    return false;
                int i = SS_Get_Window_List_Ex(ref win_list);
                if (i != 0)
                {
                    toText("������־", "��ȡ���ڴ���LED����" + i.ToString());
                    return false;
                }
                else
                    toText("������־", win_list);
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                toText("������־", "��ȡ���ڴ���" + ex.Message);
                return false;
            }
        }

        /// <summary>
        ///  ɾ���ļ�
        /// </summary>
        /// <returns></returns>
        private bool Delete_File()
        {
            try
            {
                if (!Open_Led())
                    return false;
                int i = SS_Delete_File(0);
                if (i != 0)
                {
                    throw new Exception(i.ToString());
                    //return false;
                }
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                throw new Exception(ex.Message);
                //return false;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public bool Send_Reset()
        {
            try
            {
                if (!Open_Led())
                    return false;
                int i = SS_Send_Reset();
                if (i != 0)
                {
                    
                    return false;
                }
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                //throw new Exception(ex.Message);
                return false;
            }
        }



        /// <summary>
        /// У׼ʱ��
        /// </summary>
        /// <returns></returns>
        private bool Send_Time()
        {
            try
            {
                if (!Open_Led())
                    return false;
                int i = SS_Send_Time();
                if (i != 0)
                {
                    throw new Exception(i.ToString());
                    //return false;
                }
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                throw new Exception(ex.Message);
                //return false;
            }
        }
        #endregion

        #region ��������
        /// <summary>
        /// ����ʾ����
        /// </summary>
        /// <param name="comType">1Ϊ�������ӣ�2ΪTCP���ӣ�3ΪUDP����</param>
        /// <returns></returns>
        private bool Open_Led()
        {
            try
            {
                int i = -1;
                int port;
                int delay;
                switch (comType)
                {
                    case "1":
                        int com = Convert.ToInt32(coms);
                        int addr = Convert.ToInt32(addrs);
                        int baud = Convert.ToInt32(port_baud);
                        delay = Convert.ToInt32(delays);
                        i = SS_Open_Com(addr, com, baud, delay);
                        break;
                    case "2":
                        port = Convert.ToInt32(port_baud);
                        delay = Convert.ToInt32(delays);
                        i = SS_Open_Tcp(sIPs, port, delay);
                        break;
                    case "3":
                        port = Convert.ToInt32(port_baud);
                        delay = Convert.ToInt32(delays);
                        i = SS_Open_Tcp(sIPs, port, delay);
                        break;
                    default:
                        break;
                }
                if (i == 0)
                    return true;
                else
                {
                    toText("������־", "LED��ʾ����ʧ��LED����" + i.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                toText("������־", "LED��ʾ����ʧ�ܣ�" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="sendstr"></param>
        /// <param name="w_index"></param>
        /// <returns></returns>
        private bool Send_Buffer(string sendstr, int w_index)
        {
            try
            {
                int i = -1;
                //TFileParam param = new TFileParam();
                //param.Effect = Convert.ToByte(effect);
                //param.Level = Convert.ToByte(level);
                //param.Speed = Convert.ToByte(speed);
                //param.Delay = Convert.ToByte(delay);
                //param.Font = Convert.ToByte(font);
                //param.ShowTitle = Convert.ToByte(showTitle);
                //param.TitleColor = Convert.ToByte(titleColor);
                //param.WordColor = Convert.ToByte(wordColor);
                //i = SS_Send_Buffer(w_index, ref param, sendstr, false);
                i = SS_Send_Buffer_Ex(w_index, Convert.ToInt32(effect), Convert.ToInt32(speed), Convert.ToInt32(delay), Convert.ToInt32(font), Convert.ToInt32(wordColor), sendstr, false);
                if (i == 0)
                    return true;
                else
                {
                    toText("������־", "LED���������ڲ������������" + i.ToString() + ",���ں�" + w_index.ToString() + ",���ŷ�ʽ" + effect + ",�����ٶ�" + speed + ",ͣ��ʱ��" + delay + ",�����С" + font + ",������ɫ" + wordColor + sendstr);
                    return false;
      
                }
            }
            catch (Exception ex)
            {
                toText("������־", "LED��ʾ��������ʧ�ܣ�" + ex.Message);
                return false;
            }

        }
        /// <summary>
        /// ɾ�� 5��ǰ����־
        /// </summary>
        /// <param name="FILE_NAME"></param>
        public static void DeleteFile_Log(string FILE_NAME)
        {
            DateTime dtime=DateTime.Now.Date.AddDays(-5);
            for(int i=30;i>=0;i--)
            {

                try
                {
                    string file_name = Constant.ApplicationDirectory + " \\" + FILE_NAME + dtime.AddDays(i * -1).ToString("yyyyMMdd") + ".txt";
                    if (System.IO.File.Exists(file_name))
                    {
                        System.IO.File.Delete(file_name);
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// д��־��¼
        /// </summary>
        /// <param name="FILE_NAME"></param>
        /// <param name="text"></param>
        public static void toText(string FILE_NAME, string text)
        {
            try
            {

                string file_name = Constant.ApplicationDirectory + " \\" + FILE_NAME + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (File.Exists(file_name))
                {
                    using (StreamWriter sw = File.AppendText(file_name))
                    {
                        text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + ":" + text;
                        sw.WriteLine(text + "\n");
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    StreamWriter sr = File.CreateText(file_name);
                    sr.Close();
                }
            }
            catch
            { 
               

            }
            finally           
            { 
               ShiFangZiYuan();
            }            
        }
        #endregion



        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// �ͷ���Դ 2014-4-28
        /// </summary>
        public static void ShiFangZiYuan()
        {
            try
            {
                if (sfzy == "1")
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    //if (System.Environment.OSVersion.Platform == PlatformID.Win32NT)
                    //{
                    //    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                    //}
                }
            }
            catch { }
        }

    }

}
