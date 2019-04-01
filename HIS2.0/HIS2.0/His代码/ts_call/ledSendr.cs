using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices; // �� DllImport ���ô� �����ռ�

namespace ts_call
{
    //�豸ͨѶ����
    public struct TDeviceParam
    {
        public ushort devType;
        public ushort comSpeed;
        public ushort comPort;
        public ushort comFlow;
        public ushort locPort;
        public ushort rmtPort;
        public ushort srcAddr;
        public ushort dstAddr;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public String rmtHost;
        public uint txTimeo;   //���ͺ�ȴ�Ӧ��ʱ�� ====��ʱʱ��ӦΪtxTimeo*txRepeat
        public uint txRepeat;  //ʧ���ط�����
        public uint txMovewin; //��������
        public uint key;       //ͨѶ��Կ
        public int pkpLength;  //���ݰ���С

    }

    //�豸���Ʋ���
    public struct TSenderParam
    {
        public TDeviceParam devParam;
        public UInt32 wmHandle;
        public UInt32 wmMessage;
        public UInt32 wmLParam;
        public UInt32 notifyMode;
    }

    //�豸Ӧ����Ϣ����
    public struct TNotifyParam
    {
        public ushort notify;
        public ushort command;
        public Int32 result;
        public Int32 status;
        public TDeviceParam param;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] buffer;
        public UInt32 size;
    }

    //SYSTEMTIME������ʱ��ṹ
    public struct TSystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;
    }

    //TimeStamp������ʱ��ṹ
    public struct TTimeStamp
    {
        public Int32 time;
        public Int32 date;
    }

    class CLEDSender
    {
        //ͨѶ�豸����
        public readonly ushort DEVICE_TYPE_COM = 0;  //����ͨѶ
        public readonly ushort DEVICE_TYPE_UDP = 1;  //����ͨѶ
        public readonly ushort DEVICE_TYPE_485 = 2;  //485ͨѶ

        //���ڻ���485ͨѶʹ�õ�ͨѶ�ٶ�(������)
        public readonly ushort SBR_57600 = 0;
        public readonly ushort SBR_38400 = 1;
        public readonly ushort SBR_19200 = 2;
        public readonly ushort SBR_9600 = 3;

        //�Ƿ�ȴ���λ��Ӧ��ֱ�ӷ�����������
        public readonly UInt32 NOTIFY_NONE = 1;
        //�Ƿ�������ʽ������ȵ�������ɻ��߳�ʱ���ŷ��أ�������������
        public readonly UInt32 NOTIFY_BLOCK = 2;
        //�Ƿ񽫷��ͽ����Windows������Ϣ��ʽ�͵����õ�Ӧ��
        public readonly UInt32 NOTIFY_EVENT = 4;
        //ʹ��1�����ض˿ڣ��Ͷ��Ŀ��IP��ַͨѶ
        public readonly UInt32 NOTIFY_MULTI = 8;

        public readonly Int32 R_DEVICE_READY = 0;
        public readonly Int32 R_DEVICE_INVALID = -1;
        public readonly Int32 R_DEVICE_BUSY = -2;
        public readonly Int32 R_FONTSET_INVALID = -3;
        public readonly Int32 R_DLL_INIT_IVALID = -4;
        public readonly Int32 R_IGNORE_RESPOND = -5;

        //��λ��Ӧ���ʶ
        public readonly ushort LM_RX_COMPLETE = 1;
        public readonly ushort LM_TX_COMPLETE = 2;
        public readonly ushort LM_RESPOND = 3;
        public readonly ushort LM_TIMEOUT = 4;
        public readonly ushort LM_NOTIFY = 5;
        public readonly ushort LM_PARAM = 6;
        public readonly ushort LM_TX_PROGRESS = 7;
        public readonly ushort LM_RX_PROGRESS = 8;
        public readonly ushort RESULT_FLASH = 0xff;

        public readonly Int32 NOTIFY_ROOT_UPDATE = 0x00010001;  //���߸��¿��ƿ�����
        public readonly Int32 NOTIFY_ROOT_UPDATE_ERROR = 0x00020001;  //�����ֿ�ʧ��
        public readonly Int32 NOTIFY_ROOT_FONTSET = 0x00010002;  //�����ֿ�ɹ�
        public readonly Int32 NOTIFY_ROOT_FONTSET_ERROR = 0x00020002;  //�����ֿ�ʧ��
        public readonly Int32 NOTIFY_ROOT_DOWNLOAD = 0x00010003;  //����Flash���Ž�Ŀ
        public readonly Int32 NOTIFY_SET_PARAM = 0x00010004;  //���ò���
        public readonly Int32 NOTIFY_SET_POWER_SCHEDULE = 0x00010005;  //���ö�ʱ������
        public readonly Int32 NOTIFY_SET_BRIGHT_SCHEDULE = 0x00010006;  //���ö�ʱ���ȵ���
        public readonly Int32 NOTIFY_SET_POWER_FLASH = 0x0001000a;  //���õ�Դ״̬�����浽Flash
        public readonly Int32 NOTIFY_SET_BRIGHT_FLASH = 0x0001000b;  //�������Ȳ����浽Flash
        public readonly Int32 NOTIFY_GET_PLAY_BUFFER = 0x00011001;  //��ȡ���ƿ���ʾ����

        //������붨��
        public readonly ushort PKC_RESPOND = 3;
        public readonly ushort PKC_QUERY = 4;
        public readonly ushort PKC_OVERFLOW = 5;
        public readonly ushort PKC_ADJUST_TIME = 6;
        public readonly ushort PKC_GET_PARAM = 7;
        public readonly ushort PKC_SET_PARAM = 8;
        public readonly ushort PKC_GET_POWER = 9;
        public readonly ushort PKC_SET_POWER = 10;
        public readonly ushort PKC_GET_BRIGHT = 11;
        public readonly ushort PKC_SET_BRIGHT = 12;
        public readonly ushort PKC_COM_TRANSFER = 21;
        public readonly ushort PKC_MODEM_TRANSFER = 22;
        public readonly ushort PKC_GET_TEMPERATURE_HUMIDITY = 24;

        //��Դ���ز���ֵ
        public readonly Int32 LED_POWER_ON = 1;
        public readonly Int32 LED_POWER_OFF = 0;

        //Chapter��Leaf�У�����ʱ�����
        public readonly ushort WAIT_USE_TIME = 0;  //����ָ����ʱ�䳤�Ȳ��ţ���ʱ����е���һ��
        public readonly ushort WAIT_CHILD = 1;  //�ȴ�����Ŀ�Ĳ��ţ��������ָ����ʱ�䳤�ȣ�������Ŀ��û�в��꣬��ȴ�����

        //����TRUE/FALSEֵ
        public readonly Int32 V_FALSE = 0;
        public readonly Int32 V_TRUE = 1;

        //��ʾ����ɫ����
        public readonly Int32 COLOR_MODE_MONO = 1;  //��ɫ
        public readonly Int32 COLOR_MODE_DOUBLE = 2;  //˫ɫ
        public readonly Int32 COLOR_MODE_FULL_16BIT = 3;  //16λȫ��
        public readonly Int32 COLOR_MODE_FULL_32BIT = 4;  //32λȫ��

        //��ʾ��������
        public readonly Int32 ROOT_UPDATE = 0x13;  //������λ������
        public readonly Int32 ROOT_FONTSET = 0x14;  //�����ֿ�
        public readonly Int32 ROOT_PLAY = 0x21;  //��Ŀ���ݣ����浽RAM�����綪ʧ
        public readonly Int32 ROOT_DOWNLOAD = 0x22;  //��Ŀ���ݣ����浽Flash
        public readonly Int32 ROOT_PLAY_CHAPTER = 0x23;  //������߸���ĳһ��Ŀ
        public readonly Int32 ROOT_PLAY_REGION = 0x25;  //������߸���ĳһ����/����
        public readonly Int32 ROOT_PLAY_LEAF = 0x27;  //������߸���ĳһҳ��
        public readonly Int32 ROOT_PLAY_OBJECT = 0x29;  //������߸���ĳһ����

        public readonly Int32 ACTMODE_INSERT = 0;     //�������
        public readonly Int32 ACTMODE_REPLACE = 1;     //�滻����

        //RAM��Ŀ����
        public readonly Int32 SURVIVE_ALWAYS = -1;

        //Windows�������Ͷ���
        public readonly Int32 WFS_NONE = 0x0;   //��ͨ��ʽ
        public readonly Int32 WFS_BOLD = 0x01;  //����
        public readonly Int32 WFS_ITALIC = 0x02;  //б��
        public readonly Int32 WFS_UNDERLINE = 0x04;  //�»���
        public readonly Int32 WFS_STRIKEOUT = 0x08;  //ɾ����

        //�������ִ�С
        public readonly Int32 FONT_SET_16 = 0;      //16�����ַ�
        public readonly Int32 FONT_SET_24 = 1;      //24�����ַ�

        //����ʱ������ʱtype����
        public readonly Int32 CT_COUNTUP = 0;      //����ʱ
        public readonly Int32 CT_COUNTDOWN = 1;      //����ʱ
        public readonly Int32 CT_COUNTUP_EX = 2;     //����ʱ
        public readonly Int32 CT_COUNTDOWN_EX = 3;   //����ʱ

        //����ʱ������ʱformat����
        public readonly Int32 CF_HNS = 0;      //ʱ���루���ֵ��
        public readonly Int32 CF_HN = 1;      //ʱ�֣����ֵ��
        public readonly Int32 CF_NS = 2;      //���루���ֵ��
        public readonly Int32 CF_H = 3;      //ʱ�����ֵ��
        public readonly Int32 CF_N = 4;      //�֣����ֵ��
        public readonly Int32 CF_S = 5;      //�루���ֵ��
        public readonly Int32 CF_DAY = 6;      //����������������
        public readonly Int32 CF_HOUR = 7;      //Сʱ��������������
        public readonly Int32 CF_MINUTE = 8;     //������������������
        public readonly Int32 CF_SECOND = 9;      //����������������

        //ģ��ʱ�ӱ߿���״
        public readonly Int32 SHAPE_RECTANGLE = 0;      //����
        public readonly Int32 SHAPE_ROUNDRECT = 1;      //Բ�Ƿ���
        public readonly Int32 SHAPE_CIRCLE = 2;      //Բ��

        //��Ŀ���żƻ�һ����Ч���ڶ���
        public readonly ushort CS_SUN = 1;
        public readonly ushort CS_MON = 2;
        public readonly ushort CS_TUE = 4;
        public readonly ushort CS_WED = 8;
        public readonly ushort CS_THU = 16;
        public readonly ushort CS_FRI = 32;
        public readonly ushort CS_SAT = 64;

        ////////////////////////////////////////////////////////////////////////////////////////////
        //�ӿں�������
        ////////////////////////////////////////////////////////////////////////////////////////////

        //��̬���ӿ��ʼ��
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Startup();

        //��̬���ӿ�����
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cleanup();

        //�������ƿ����߼�������
        //  serverindex ���ƿ����߼���������(�����ڶ��socket udp�˿ڼ���)
        //  localport ���ض˿�
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Report_CreateServer(Int32 serverindex, Int32 localport);

        //ɾ�����ƿ����߼�������
        //  serverindex ���ƿ����߼���������
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Report_RemoveServer(Int32 serverindex);

        //ɾ��ȫ�����ƿ����߼�������
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Report_RemoveAllServer();

        //��ÿ��ƿ������б�
        //�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
        //  serverindex ���ƿ����߼���������
        //  plist ��������б���û��ⲿ��������
        //        ��������(NULL/0)�����������̬���ӿ��ڲ��Ļ�������������������Ľӿ�ȡ����ϸ��Ϣ
        //  count ����ȡ����
        //--����ֵ-- С��0��ʾʧ��(δ���������߼�������)�����ڵ���0��ʾ���ߵĿ��ƿ�����
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Report_GetOnlineList(Int32 serverindex, Int32 listaddr, Int32 count);

        //���ĳ�����߿��ƿ����ϱ����ƿ�����
        //�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
        //  serverindex ���ƿ����߼���������
        //  itemindex �ü�������������б��У����߿��ƿ��ı��
        //--����ֵ-- ���߿��ƿ����ϱ����ƿ�����
        [DllImport("LEDSender2010.dll")]
        private static extern String LED_Report_GetOnlineItemName(Int32 serverindex, Int32 itemindex);

        //���ĳ�����߿��ƿ����ϱ����ƿ�IP��ַ
        //�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
        //  serverindex ���ƿ����߼���������
        //  itemindex �ü�������������б��У����߿��ƿ��ı��
        //--����ֵ-- ���߿��ƿ���IP��ַ
        [DllImport("LEDSender2010.dll")]
        private static extern String LED_Report_GetOnlineItemHost(Int32 serverindex, Int32 itemindex);

        //���ĳ�����߿��ƿ����ϱ����ƿ�Զ��UDP�˿ں�
        //�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
        //  serverindex ���ƿ����߼���������
        //  itemindex �ü�������������б��У����߿��ƿ��ı��
        //--����ֵ-- ���߿��ƿ���Զ��UDP�˿ں�
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Report_GetOnlineItemPort(Int32 serverindex, Int32 itemindex);

        //���ĳ�����߿��ƿ����ϱ����ƿ���ַ
        //�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
        //  serverindex ���ƿ����߼���������
        //  itemindex �ü�������������б��У����߿��ƿ��ı��
        //--����ֵ-- ���߿��ƿ���Ӳ����ַ
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Report_GetOnlineItemAddr(Int32 serverindex, Int32 itemindex);

        //Ԥ����ʾ����
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Preview(Int32 index, Int32 width, Int32 height, string previewfile);

        //Ԥ����ʾ����
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_PreviewFile(Int32 width, Int32 height, string previewfile);

        //����ÿ������ִ����ɺ��Ƿ�ر��豸��=0��ʾ���رգ�=1��ʾ�رա�
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_CloseDeviceOnTerminate(int AValue);

        //��ȡ���ƿ�Ӧ����������
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_GetNotifyParam(ref TNotifyParam param, Int32 index);

        //��ȡ���ƿ�Ӧ���������ݣ������������ݱ��浽ָ���ļ���
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_GetNotifyParam_BufferToFile(ref TNotifyParam param, String filename, int index);

        //��λ���ƿ���Ŀ���ţ�������ʾ���ƿ�Flash�д洢�Ľ�Ŀ
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_ResetDisplay(ref TSenderParam param);

        //�������ƿ�
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Reboot(ref TSenderParam param);

        //��ȡ���ƿ���ʪ��ֵ
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_GetTemperatureHumidity(ref TSenderParam param);

        //���ÿ��ƿ���Դ value=LED_POWER_ON��ʾ������Դ value=LED_POWER_OFF��ʾ�رյ�Դ
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_SetPower(ref TSenderParam param, Int32 value);

        //��ȡ���ƿ���Դ״̬
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_GetPower(ref TSenderParam param);

        //���ÿ��ƿ����� valueȡֵ��Χ0-7
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_SetBright(ref TSenderParam param, Int32 value);

        //��ȡ���ƿ�����
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_GetBright(ref TSenderParam param);

        //У��ʱ�䣬�Ե�ǰ�������ϵͳʱ��У�����ƿ���ʱ��
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_AdjustTime(ref TSenderParam param);

        //У��ʱ����չ����ָ����ʱ��У�����ƿ���ʱ��
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_AdjustTimeEx(ref TSenderParam param, ref TSystemTime time);

        //���ͽ�Ŀ���� indexΪMakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�����ķ���ֵ
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_SendToScreen(ref TSenderParam param, Int32 index);

        //ֱ�ӷ����ַ���UDP������ʾ��
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_SendStringDirectly(ref TSenderParam param, string text);

        //ֱ�ӷ���ʮ�������ַ���UDP������ʾ��
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_SendHexDirectly(ref TSenderParam param, string text);

        //232��ת��Э�����ݣ����ڿ�������豸��
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_ComTransferHex(ref TSenderParam param, string text, Int32 delayaftertransfer);

        //485��ת��Э�����ݣ����ڿ�������豸��
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_ModemTransferHex(ref TSenderParam param, string text, Int32 delayaftertransfer);

        //����UDPͨѶ�Ĳ���
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_UDP_SenderParam(Int32 param_index, Int32 locport, string host, Int32 rmtport, Int32 address, Int32 notifymode, Int32 wmhandle, Int32 wmmessage);

        //���ô���ͨѶ�Ĳ���
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_COM_SenderParam(Int32 paramindex, Int32 comport, Int32 baudrate, Int32 address, Int32 notifymode, Int32 wmhandle, Int32 wmmessage);

        //���ͽ�Ŀ���� indexΪMakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�����ķ���ֵ
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_SendToScreen2(Int32 param_index, Int32 index);

        //ѹ������
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Compress(Int32 param_index);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //���ƿ�������ȡ���������API

        //��ȡ���ƿ���������ȡ���Ľ�����浽��̬���ӿ���
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cache_GetBoardParam(ref TSenderParam param);

        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cache_GetBoardParam2(Int32 param_index);

        //ȡ�ÿ��ƿ�IP��ַ
        [DllImport("LEDSender2010.dll")]
        private static extern String LED_Cache_GetBoardParam_IP();

        //ȡ�ÿ��ƿ�MAC��ַ
        [DllImport("LEDSender2010.dll")]
        private static extern String LED_Cache_GetBoardParam_Mac();

        //ȡ�ÿ��ƿ��豸��ַ
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cache_GetBoardParam_Addr();

        //ȡ�ÿ��ƿ��豸���
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cache_GetBoardParam_Width();

        //ȡ�ÿ��ƿ��豸�߶�
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cache_GetBoardParam_Height();

        //ȡ�ÿ��ƿ��豸����
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cache_GetBoardParam_Brightness();

        //���ÿ��ƿ�IP��ַ
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Cache_SetBoardParam_IP(String value);

        //���ÿ��ƿ�MAC��ַ
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Cache_SetBoardParam_Mac(String value);

        //���ÿ��ƿ��豸��ַ
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Cache_SetBoardParam_Addr(Int32 value);

        //���ÿ��ƿ��豸���
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Cache_SetBoardParam_Width(Int32 value);

        //���ÿ��ƿ��豸�߶�
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Cache_SetBoardParam_Height(Int32 value);

        //���ÿ��ƿ��豸����
        [DllImport("LEDSender2010.dll")]
        private static extern void LED_Cache_SetBoardParam_Brightness(Int32 value);

        //���ÿ��ƿ�����
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cache_SetBoardParam(ref TSenderParam param);

        [DllImport("LEDSender2010.dll")]
        private static extern int LED_Cache_SetBoardParam2(Int32 param_index);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //��ȡ���ƿ���ǰ��ʾ�������API

        //��ȡ���ƿ���ǰ��ʾ����
        [DllImport("LEDSender2010.dll")]
        private static extern int LED_GetPlayContent(ref TSenderParam param);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //��Ŀ������֯��ʽ
        //  ROOT
        //   |
        //   |---Chapter(��Ŀ)
        //   |      |
        //   |      |---Region(����/����)
        //   |      |     |
        //   |      |     |---Leaf(ҳ��)
        //   |      |     |    |
        //   |      |     |    |---Object(����[���֡�ʱ�ӡ�ͼƬ��])
        //   |      |     |    |
        //   |      |     |    |---Object(����[���֡�ʱ�ӡ�ͼƬ��])
        //   |      |     |    |
        //   |      |     |    |   ......
        //   |      |     |    |
        //   |      |     |
        //   |      |     |---Leaf(ҳ��)
        //   |      |     |
        //   |      |     |   ......
        //   |      |     |
        //   |      |
        //   |      |---Region(����/����)
        //   |      |
        //   |      |   ......
        //   |      |
        //   |---Chapter(��Ŀ)
        //   |
        //   |   ......

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //������ʾ����ת 
        //  rotate ��ת��ʽ =0����ת =1��ʱ����ת90�� =2˳ʱ����ת90��
        //  metrix_width ��ʾ�����
        //  metrix_height ��ʾ���߶�
        [DllImport("LEDSender2010.dll")]
        private static extern int SetRotate(Int32 rotate, Int32 metrix_width, Int32 metrix_height);

        //���ɽ�Ŀ���ݣ���VisionShow����༭��Vsq�ļ����룬������Ҫ�·��Ľ�Ŀ���ݣ�
        //  RootType Ϊ��Ŀ���ͣ�=ROOT_PLAY��ʾ���¿��ƿ�RAM�еĽ�Ŀ(���綪ʧ)��=ROOT_DOWNLOAD��ʾ���¿��ƿ�Flash�еĽ�Ŀ(���粻��ʧ)
        //  ColorMode Ϊ��ɫģʽ��ȡֵΪCOLOR_MODE_MONO����COLOR
        //  survive ΪRAM��Ŀ����ʱ�䣬��RootType=ROOT_PLAYʱ��Ч����RAM��Ŀ���Ŵﵽʱ��󣬻ָ���ʾFLASH�еĽ�Ŀ
        //  filename ��VisionShow����༭�Ľ�Ŀ�ļ�
        [DllImport("LEDSender2010.dll")]
        private static extern int MakeFromVsqFile(string filename, Int32 RootType, Int32 ColorMode, Int32 survive);

        //���ɽ�Ŀ����
        //  RootType Ϊ��Ŀ���ͣ�=ROOT_PLAY��ʾ���¿��ƿ�RAM�еĽ�Ŀ(���綪ʧ)��=ROOT_DOWNLOAD��ʾ���¿��ƿ�Flash�еĽ�Ŀ(���粻��ʧ)
        //  ColorMode Ϊ��ɫģʽ��ȡֵΪCOLOR_MODE_MONO����COLOR
        //  survive ΪRAM��Ŀ����ʱ�䣬��RootType=ROOT_PLAYʱ��Ч����RAM��Ŀ���Ŵﵽʱ��󣬻ָ���ʾFLASH�еĽ�Ŀ
        [DllImport("LEDSender2010.dll")]
        private static extern int MakeRoot(Int32 RootType, Int32 ColorMode, Int32 survive);

        //���ɽ�Ŀ���ݣ�������Ҫ����[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
        //  RootType ������ΪROOT_PLAY_CHAPTER
        //  ActionMode ������Ϊ0
        //  ChapterIndex Ҫ���µĽ�Ŀ���
        //  ColorMode ͬMakeRoot�еĶ���
        //  time ���ŵ�ʱ�䳤��
        //  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
        //                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
        [DllImport("LEDSender2010.dll")]
        private static extern int MakeChapter(Int32 RootType, Int32 ActionMode, Int32 ChapterIndex, Int32 ColorMode, UInt32 time, ushort wait);

        //��������/������������Ҫ����[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
        //  RootType ������ΪROOT_PLAY_REGION
        //  ActionMode ������Ϊ0
        //  ChapterIndex Ҫ���µĽ�Ŀ���
        //  RegionIndex Ҫ���µ�����/�������
        //  ColorMode ͬMakeRoot�еĶ���
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  border ��ˮ�߿�
        [DllImport("LEDSender2010.dll")]
        private static extern int MakeRegion(Int32 RootType, Int32 ActionMode, Int32 ChapterIndex, Int32 RegionIndex,
            Int32 ColorMode, Int32 left, Int32 top, Int32 width, Int32 height, Int32 border);

        //����ҳ�棬������Ҫ����[AddObject]->[AddWindows/AddDateTime��]
        //  RootType ������ΪROOT_PLAY_LEAF
        //  ActionMode ������Ϊ0
        //  ChapterIndex Ҫ���µĽ�Ŀ���
        //  RegionIndex Ҫ���µ�����/�������
        //  LeafIndex Ҫ���µ�ҳ�����
        //  ColorMode ͬMakeRoot�еĶ���
        //  time ���ŵ�ʱ�䳤��
        //  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
        //                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
        [DllImport("LEDSender2010.dll")]
        private static extern int MakeLeaf(Int32 RootType, Int32 ActionMode, Int32 ChapterIndex, Int32 RegionIndex, Int32 LeafIndex,
            Int32 ColorMode, UInt32 time, ushort wait);

        //���ɲ��Ŷ��󣬺�����Ҫ����[AddWindows/AddDateTime��]
        //  RootType ������ΪROOT_PLAY_LEAF
        //  ActionMode ������Ϊ0
        //  ChapterIndex Ҫ���µĽ�Ŀ���
        //  RegionIndex Ҫ���µ�����/�������
        //  LeafIndex Ҫ���µ�ҳ�����
        //  ObjectIndex Ҫ���µĶ������
        //  ColorMode ͬMakeRoot�еĶ���
        [DllImport("LEDSender2010.dll")]
        private static extern int MakeObject(Int32 RootType, Int32 ActionMode, Int32 ChapterIndex, Int32 RegionIndex, Int32 LeafIndex, Int32 ObjectIndex, Int32 ColorMode);

        //��ӽ�Ŀ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot�ķ���ֵ
        //  time ���ŵ�ʱ�䳤��(��λΪ����)
        //  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
        //                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
        [DllImport("LEDSender2010.dll")]
        private static extern int AddChapter(ushort num, UInt32 time, ushort wait);

        //��ӽ�Ŀ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot�ķ���ֵ
        //  time ���ŵ�ʱ�䳤��(��λΪ����)
        //  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
        //                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
        //  kind ���żƻ����ͣ�=0ʼ�ղ��ţ�=1����һ��ÿ��ʱ�䲥�ţ�=2����ָ����ֹ����ʱ�䲥�ţ�=3������
        //  week һ����Ч���ڣ�bit0��bit6��ʾ���յ�������Ч����kind=1ʱ��������������
        //  fromtime ��Ч��ʼʱ��
        //  totime ��Ч����ʱ��
        [DllImport("LEDSender2010.dll")]
        private static extern int AddChapterEx(ushort num, UInt32 time, ushort wait, ushort kind, ushort week, ref TTimeStamp fromtime, ref TTimeStamp totime);

        //�������/����
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  border ��ˮ�߿�
        [DllImport("LEDSender2010.dll")]
        private static extern int AddRegion(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 border);

        //���ҳ��
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion�ķ���ֵ
        //  time ���ŵ�ʱ�䳤��(��λΪ����)
        //  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
        //                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
        [DllImport("LEDSender2010.dll")]
        private static extern int AddLeaf(ushort num, UInt32 time, ushort wait);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //�������ʱ����ʾ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        //  year_offset ��ƫ����
        //  month_offset ��ƫ����
        //  day_offset ��ƫ����
        //  sec_offset ��ƫ����
        //  format ��ʾ��ʽ 
        //      #y��ʾ�� #m��ʾ�� #d��ʾ�� #h��ʾʱ #n��ʾ�� #s��ʾ�� #w��ʾ���� #c��ʾũ��
        //      ������ format="#y��#m��#d�� #hʱ#n��#s�� ����#w ũ��#c"ʱ����ʾΪ"2009��06��27�� 12ʱ38��45�� ������ ũ�����³���"
        [DllImport("LEDSender2010.dll")]
        private static extern int AddDateTime(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle,
            Int32 year_offset, Int32 month_offset, Int32 day_offset, Int32 sec_offset, string format);

        //�������ʱ����ʾ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  vertical �Ƿ�������ʾ =0���� =1��ʱ����ת������ʾ =2˳ʱ����ת������ʾ
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        //  year_offset ��ƫ����
        //  month_offset ��ƫ����
        //  day_offset ��ƫ����
        //  sec_offset ��ƫ����
        //  format ��ʾ��ʽ 
        //      #y��ʾ�� #m��ʾ�� #d��ʾ�� #h��ʾʱ #n��ʾ�� #s��ʾ�� #w��ʾ���� #c��ʾũ��
        //      ������ format="#y��#m��#d�� #hʱ#n��#s�� ����#w ũ��#c"ʱ����ʾΪ"2009��06��27�� 12ʱ38��45�� ������ ũ�����³���"
        [DllImport("LEDSender2010.dll")]
        private static extern int AddDateTimeEx(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, Int32 vertical,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle,
            Int32 year_offset, Int32 month_offset, Int32 day_offset, Int32 sec_offset, string format);

        //�����սʱ����ʾ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        //  format ��ʾ��ʽ 
        //      #y��ʾ�� #m��ʾ�� #d��ʾ�� #h��ʾʱ #n��ʾ�� #s��ʾ�� #w��ʾ����
        //  basetime ��սʱ��
        //  fromtime ��ʼʱ��
        //  totime ����ʱ��
        //  step ��ʱ����ʱ�䲽�������ٺ�����һ�룩
        [DllImport("LEDSender2010.dll")]
        private static extern int AddCampaignEx(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle,
            string format, ref TTimeStamp basetime, ref TTimeStamp fromtime, ref TTimeStamp totime, Int32 step);

        //��ӵ���ʱ��ʾ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  countertype ��ʱ���� 0(CT_COUNTUP)Ϊ����ʱ��1(CT_COUNTDOWN)Ϊ����ʱ
        //  format ��ʾ��ʽ 
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        //  basetime ��սʱ��
        [DllImport("LEDSender2010.dll")]
        private static extern int AddCounter(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, Int32 countertype, Int32 format,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, ref TTimeStamp basetime);

        //���ģ��ʱ��
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  offset ��ƫ����
        //  bkcolor: ������ɫ
        //  bordercolor: �߿���ɫ
        //  borderwidth: �߿���ɫ
        //  bordershape: �߿���״ =0��ʾ�����Σ�=1��ʾԲ�Ƿ��Σ�=2��ʾԲ��
        //  dotradius: �̶Ⱦ���������İ뾶
        //  adotwidth: 0369��̶ȴ�С
        //  adotcolor: 0369��̶���ɫ
        //  bdotwidth: ������̶ȴ�С
        //  bdotcolor: ������̶���ɫ
        //  hourwidth: ʱ���ϸ
        //  hourcolor: ʱ����ɫ
        //  minutewidth: �����ϸ
        //  minutecolor: ������ɫ
        //  secondwidth: �����ϸ
        //  secondcolor: ������ɫ
        [DllImport("LEDSender2010.dll")]
        private static extern int AddClock(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, Int32 offset,
            UInt32 bkcolor, UInt32 bordercolor, UInt32 borderwidth, Int32 bordershape,
            Int32 dotradius, Int32 adotwidth, UInt32 adotcolor, Int32 bdotwidth, UInt32 bdotcolor,
            Int32 hourwidth, UInt32 hourcolor, Int32 minutewidth, UInt32 minutecolor, Int32 secondwidth, UInt32 secondcolor);

        //���ģ��ʱ��
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  vertical �Ƿ�������ʾ =0���� =1��ʱ����ת������ʾ =2˳ʱ����ת������ʾ
        //  offset ��ƫ����
        //  bkcolor: ������ɫ
        //  bordercolor: �߿���ɫ
        //  borderwidth: �߿���ɫ
        //  bordershape: �߿���״ =0��ʾ�����Σ�=1��ʾԲ�Ƿ��Σ�=2��ʾԲ��
        //  dotradius: �̶Ⱦ���������İ뾶
        //  adotwidth: 0369��̶ȴ�С
        //  adotcolor: 0369��̶���ɫ
        //  bdotwidth: ������̶ȴ�С
        //  bdotcolor: ������̶���ɫ
        //  hourwidth: ʱ���ϸ
        //  hourcolor: ʱ����ɫ
        //  minutewidth: �����ϸ
        //  minutecolor: ������ɫ
        //  secondwidth: �����ϸ
        //  secondcolor: ������ɫ
        [DllImport("LEDSender2010.dll")]
        private static extern int AddClockEx2(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, Int32 vertical, Int32 offset,
            UInt32 bkcolor, UInt32 bordercolor, UInt32 borderwidth, Int32 bordershape,
            Int32 dotradius, Int32 adotwidth, UInt32 adotcolor, Int32 bdotwidth, UInt32 bdotcolor,
            UInt32 cdotvisible, Int32 cdotwidth, UInt32 cdotcolor,
            Int32 hourwidth, UInt32 hourcolor, Int32 minutewidth, UInt32 minutecolor, Int32 secondwidth, UInt32 secondcolor);

        //��Ӷ���
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  filename avi�ļ���
        //  stretch: ͼ���Ƿ���������Ӧ�����С
        [DllImport("LEDSender2010.dll")]
        private static extern int AddMovie(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, string filename, Int32 stretch);

        //���ͼƬ�鲥��
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddWindows(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border);

        //���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  dc ԴͼƬDC���
        //  width ͼƬ���
        //  height ͼƬ�߶�
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddChildWindow(ushort num, UInt32 dc, Int32 width, Int32 height, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  filename ͼƬ�ļ���
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddChildPicture(ushort num, string filename, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  str �����ַ���
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        //  wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddChildText(ushort num, string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 wordwrap, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  str �����ַ���
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        //  wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddChildTextEx(ushort num, string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 autofitsize, Int32 wordwrap, Int32 vertical, Int32 alignment, Int32 verticalspace, Int32 horizontalfit,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //������������鲥��
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddStrings(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border);

        //���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  str �����ַ���
        //  fontset �ֿ� =FONTSET_16P��ʾ16�����ֿ⣻=FONTSET_24P��ʾ24�����ֿ�
        //  color ��ɫ
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddChildString(ushort num, string str, Int32 fontset, Int32 color,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //���ͼƬ���󲥷�
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  dc ԴͼƬDC���
        //  src_width ͼƬ���
        //  src_height ͼƬ�߶�
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddWindow(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            UInt32 dc, Int32 src_width, Int32 src_height, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //���ͼƬ�ļ�����
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  filename ͼƬ�ļ�
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddPicture(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, string filename, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //��ӱ��
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  profile ��������ļ�
        //  content ������ݣ���֮���Իس����зָ��֮����'|'�ָ�
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddTable(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, string profile, string content,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //������ֲ���
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  str �����ַ���
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        //  wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddText(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 wordwrap, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //������ֲ���
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  str �����ַ���
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        //  autofitsize ��������Ӧ��ʾ����
        //  wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
        //  vertical �Ƿ�������ʾ =0���� =1��ʱ����ת������ʾ =2˳ʱ����ת������ʾ
        //  alignment ���뷽ʽ =0���� =1���� =2����
        //  verticalspace �м��
        //  horizontalfit ��������Ӧ
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddTextEx3(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 flag,
            string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 bkcolor, Int32 autofitsize, Int32 wordwrap,
            Int32 vertical, Int32 alignment, Int32 verticalspace, Int32 horizontalfit,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //����������ֲ���
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  str �����ַ���
        //  fontset �ֿ� =FONTSET_16P��ʾ16�����ֿ⣻=FONTSET_24P��ʾ24�����ֿ�
        //  color ��ɫ
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddString(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string str, Int32 fontset, Int32 color,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //����¶���ʾ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        [DllImport("LEDSender2010.dll")]
        private static extern int AddTemperature(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle);

        //���ʪ����ʾ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        [DllImport("LEDSender2010.dll")]
        private static extern int AddHumidity(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle);

        //>>----------------------------------------------------------------------------------------------------------
        // ���漸�����������û��Զ��������ؽӿ�

        //��ʼ���û��Զ�����ƵĻ���ͼƬ��С
        //  width ����ͼƬ���
        //  height ����ͼƬ�߶�
        [DllImport("LEDSender2010.dll")]
        private static extern int UserCanvas_Init(Int32 width, Int32 height);

        //����ֱ��
        //  X, Y ���
        //  X1, Y1 �յ�
        //  linewidth �߿�
        //  linecolor ��ɫ
        [DllImport("LEDSender2010.dll")]
        private static extern int UserCanvas_Draw_Line(Int32 X, Int32 Y, Int32 X1, Int32 Y1, Int32 linewidth, Int32 linecolor);

        //���ƾ���
        //  X, Y, X1, Y1 �����Խǵ�����
        //  linewidth �߿�
        //  linecolor �߿���ɫ
        //  fillcolor �����ɫ
        [DllImport("LEDSender2010.dll")]
        private static extern int UserCanvas_Draw_Rectangle(Int32 X, Int32 Y, Int32 X1, Int32 Y1, Int32 linewidth, Int32 linecolor, Int32 fillcolor);

        //������Բ��
        //  X, Y, X1, Y1 �����Խǵ�����
        //  linewidth �߿�
        //  linecolor �߿���ɫ
        //  fillcolor �����ɫ
        [DllImport("LEDSender2010.dll")]
        private static extern int UserCanvas_Draw_Ellipse(Int32 X, Int32 Y, Int32 X1, Int32 Y1, Int32 linewidth, Int32 linecolor, Int32 fillcolor);

        //����Բ�Ǿ���
        //  X, Y, X1, Y1 �����Խǵ�����
        //  linewidth �߿�
        //  linecolor �߿���ɫ
        //  fillcolor �����ɫ
        //  roundx, roundy Բ�ǻ���
        [DllImport("LEDSender2010.dll")]
        private static extern int UserCanvas_Draw_RoundRect(Int32 X, Int32 Y, Int32 X1, Int32 Y1, Int32 linewidth, Int32 linecolor, Int32 fillcolor, Int32 roundx, Int32 roundy);

        //��������
        //  left, top, width, height ���ϡ���ȡ��߶ȣ������ڻ����ϵ���ʾ����
        //  str �����ַ���
        //  fontname ��������
        //  fontsize �����С
        //  fontcolor ������ɫ
        //  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
        [DllImport("LEDSender2010.dll")]
        private static extern int UserCanvas_Draw_Text(Int32 left, Int32 top, Int32 width, Int32 height, string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 alignment);

        //����û��Զ�����ƻ���ͼƬ
        //  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
        //  left��top��width��height ���ϡ���ȡ��߶�
        //  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
        //  border ��ˮ�߿�(δʵ��)
        //  inmethod ���뷽ʽ(�������б�˵��)
        //  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  outmethod ������ʽ(�������б�˵��)
        //  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stopmethod ͣ����ʽ(�������б�˵��)
        //  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
        //  stoptime ͣ��ʱ��(��λ����)
        [DllImport("LEDSender2010.dll")]
        private static extern int AddUserCanvas(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime);

        //----------------------------------------------------------------------------------------------------------<<


        // ====���붯����ʽ�б�(��ֵ��0��ʼ)====
        //    0 = '���',
        //    1 = '������ʾ',
        //    2 = '�����ʾ',
        //    3 = '�Ϲ���ʾ',
        //    4 = '�ҹ���ʾ',
        //    5 = '�¹���ʾ',
        //    6 = '���������ʾ',
        //    7 = '�����¹���ʾ',
        //    8 = '�м�������չ��',
        //    9 = '�м�������չ��',
        //   10 = '�м�������չ��',
        //   11 = '������������',
        //   12 = '������������',
        //   13 = '��������չ��',
        //   14 = '��������չ��',
        //   15 = '�����Ͻ�����',
        //   16 = '�����½�����',
        //   17 = '�����Ͻ�����',
        //   18 = '�����½�����',
        //   19 = '������������',
        //   20 = '������������',
        //   21 = '�����Ҷ��',
        //   22 = '�����Ҷ��',
        // =====================================

        // ====����������ʽ�б�(��ֵ��0��ʼ)====
        //    0 = '���',
        //    1 = '����ʧ',
        //    2 = '������ʧ',
        //    3 = '�������м��£',
        //    4 = '�������м��£',
        //    5 = '�������м��£',
        //    6 = '���������Ƴ�',
        //    7 = '���������Ƴ�',
        //    8 = '���������£',
        //    9 = '�������Һ�£',
        //   10 = '�����Ͻ��Ƴ�',
        //   11 = '�����½��Ƴ�',
        //   12 = '�����Ͻ��Ƴ�',
        //   13 = '�����½��Ƴ�',
        //   14 = '���������Ƴ�',
        //   15 = '���������Ƴ�',
        //   16 = '�����Ҷ��',
        //   17 = '�����Ҷ��'
        // =====================================

        // ====ͣ��������ʽ�б�(��ֵ��0��ʼ)====
        //    0 = '��̬��ʾ',
        //    1 = '��˸��ʾ'
        // =====================================

        public int Do_LED_Startup()
        {
            return LED_Startup();
        }

        public int Do_LED_Cleanup()
        {
            return LED_Cleanup();
        }

        public int Do_LED_GetPlayContent(ref TSenderParam param)
        {
            return LED_GetPlayContent(ref param);
        }

        public int Do_LED_Cache_GetBoardParam(ref TSenderParam param)
        {
            return LED_Cache_GetBoardParam(ref param);
        }

        public String Do_LED_Cache_GetBoardParam_IP()
        {
            return LED_Cache_GetBoardParam_IP();
        }

        public String Do_LED_Cache_GetBoardParam_Mac()
        {
            return LED_Cache_GetBoardParam_Mac();
        }

        public int Do_LED_Cache_GetBoardParam_Addr()
        {
            return LED_Cache_GetBoardParam_Addr();
        }

        public int Do_LED_Cache_GetBoardParam_Width()
        {
            return LED_Cache_GetBoardParam_Width();
        }

        public int Do_LED_Cache_GetBoardParam_Height()
        {
            return LED_Cache_GetBoardParam_Height();
        }

        public int Do_LED_Cache_GetBoardParam_Brightness()
        {
            return LED_Cache_GetBoardParam_Brightness();
        }

        public void Do_LED_Cache_SetBoardParam_IP(String value)
        {
            LED_Cache_SetBoardParam_IP(value);
        }

        public void Do_LED_Cache_SetBoardParam_Mac(String value)
        {
            LED_Cache_SetBoardParam_Mac(value);
        }

        public void Do_LED_Cache_SetBoardParam_Addr(int value)
        {
            LED_Cache_SetBoardParam_Addr(value);
        }

        public void Do_LED_Cache_SetBoardParam_Width(int value)
        {
            LED_Cache_SetBoardParam_Width(value);
        }

        public void Do_LED_Cache_SetBoardParam_Height(int value)
        {
            LED_Cache_SetBoardParam_Height(value);
        }

        public void Do_LED_Cache_SetBoardParam_Brightness(int value)
        {
            LED_Cache_SetBoardParam_Brightness(value);
        }

        public int Do_LED_Cache_SetBoardParam(ref TSenderParam param)
        {
            return LED_Cache_SetBoardParam(ref param);
        }

        public int Do_LED_Report_CreateServer(Int32 serverindex, Int32 localport)
        {
            return LED_Report_CreateServer(serverindex, localport);
        }

        public void Do_LED_Report_RemoveServer(Int32 serverindex)
        {
            LED_Report_RemoveServer(serverindex);
        }

        public void Do_LED_Report_RemoveAllServer()
        {
            LED_Report_RemoveAllServer();
        }

        public int Do_LED_Report_GetOnlineList(Int32 serverindex)
        {
            return LED_Report_GetOnlineList(serverindex, 0, 0);
        }

        public String Do_LED_Report_GetOnlineItemName(Int32 serverindex, Int32 itemindex)
        {
            return LED_Report_GetOnlineItemName(serverindex, itemindex);
        }

        public String Do_LED_Report_GetOnlineItemHost(Int32 serverindex, Int32 itemindex)
        {
            return LED_Report_GetOnlineItemHost(serverindex, itemindex);
        }

        public int Do_LED_Report_GetOnlineItemPort(Int32 serverindex, Int32 itemindex)
        {
            return LED_Report_GetOnlineItemPort(serverindex, itemindex);
        }

        public int Do_LED_Report_GetOnlineItemAddr(Int32 serverindex, Int32 itemindex)
        {
            return LED_Report_GetOnlineItemAddr(serverindex, itemindex);
        }

        public void Do_LED_Preview(Int32 index, Int32 width, Int32 height, string previewfile)
        {
            LED_Preview(index, width, height, previewfile);
        }

        public void Do_LED_PreviewFile(Int32 width, Int32 height, string previewfile)
        {
            LED_PreviewFile(width, height, previewfile);
        }

        public void Do_LED_CloseDeviceOnTerminate(int AValue)
        {
            LED_CloseDeviceOnTerminate(AValue);
        }

        public int Do_LED_GetNotifyParam(ref TNotifyParam param, Int32 index)
        {
            return LED_GetNotifyParam(ref param, index);
        }

        public int Do_LED_GetNotifyParam_BufferToFile(ref TNotifyParam param, String filename, Int32 index)
        {
            return LED_GetNotifyParam_BufferToFile(ref param, filename, index);
        }

        public int Do_LED_ResetDisplay(ref TSenderParam param)
        {
            return LED_ResetDisplay(ref param);
        }

        public int Do_LED_Reboot(ref TSenderParam param)
        {
            return LED_Reboot(ref param);
        }

        public int Do_LED_GetTemperatureHumidity(ref TSenderParam param)
        {
            return LED_GetTemperatureHumidity(ref param);
        }

        public int Do_LED_SetPower(ref TSenderParam param, Int32 value)
        {
            return LED_SetPower(ref param, value);
        }

        public int Do_LED_GetPower(ref TSenderParam param)
        {
            return LED_GetPower(ref param);
        }

        public int Do_LED_SetBright(ref TSenderParam param, Int32 value)
        {
            return LED_SetBright(ref param, value);
        }

        public int Do_LED_GetBright(ref TSenderParam param)
        {
            return LED_GetBright(ref param);
        }

        public int Do_LED_AdjustTime(ref TSenderParam param)
        {
            return LED_AdjustTime(ref param);
        }

        public int Do_LED_AdjustTimeEx(ref TSenderParam param, ref TSystemTime time)
        {
            return LED_AdjustTimeEx(ref param, ref time);
        }

        public int Do_LED_Compress(Int32 index)
        {
            return LED_Compress(index);
        }

        public int Do_LED_SendToScreen(ref TSenderParam param, Int32 index)
        {
            return LED_SendToScreen(ref param, index);
        }

        public int Do_LED_SendStringDirectly(ref TSenderParam param, string text)
        {
            return LED_SendStringDirectly(ref param, text);
        }

        public int Do_LED_SendHexDirectly(ref TSenderParam param, string text)
        {
            return LED_SendHexDirectly(ref param, text);
        }

        public int Do_LED_ComTransferHex(ref TSenderParam param, string text, Int32 delayaftertransfer)
        {
            return LED_ComTransferHex(ref param, text, delayaftertransfer);
        }

        public int Do_LED_ModemTransferHex(ref TSenderParam param, string text, Int32 delayaftertransfer)
        {
            return LED_ModemTransferHex(ref param, text, delayaftertransfer);
        }

        public int Do_LED_UDP_SenderParam(Int32 param_index, Int32 locport, string host, Int32 rmtport, Int32 address, Int32 notifymode, Int32 wmhandle, Int32 wmmessage)
        {
            return LED_UDP_SenderParam(param_index, locport, host, rmtport, address, notifymode, wmhandle, wmmessage);
        }

        public int Do_LED_COM_SenderParam(Int32 param_index, Int32 comport, Int32 baudrate, Int32 address, Int32 notifymode, Int32 wmhandle, Int32 wmmessage)
        {
            return LED_COM_SenderParam(param_index, comport, baudrate, address, notifymode, wmhandle, wmmessage);
        }

        public int Do_LED_SendToScreen2(Int32 param_index, Int32 index)
        {
            return LED_SendToScreen2(param_index, index);
        }

        public int Do_SetRotate(Int32 rotate, Int32 metrix_width, Int32 metrix_height)
        {
            return SetRotate(rotate, metrix_width, metrix_height);
        }

        public int Do_MakeFromVsqFile(string filename, Int32 RootType, Int32 ColorMode, Int32 survive)
        {
            return MakeFromVsqFile(filename, RootType, ColorMode, survive);
        }

        public int Do_MakeRoot(Int32 RootType, Int32 ColorMode, Int32 survive)
        {
            return MakeRoot(RootType, ColorMode, survive);
        }

        public int Do_MakeChapter(Int32 RootType, Int32 ActionMode, Int32 ChapterIndex, Int32 ColorMode, UInt32 time, ushort wait)
        {
            return MakeChapter(RootType, ActionMode, ChapterIndex, ColorMode, time, wait);
        }

        public int Do_MakeRegion(Int32 RootType, Int32 ActionMode, Int32 ChapterIndex, Int32 RegionIndex,
            Int32 ColorMode, Int32 left, Int32 top, Int32 width, Int32 height, Int32 border)
        {
            return MakeRegion(RootType, ActionMode, ChapterIndex, RegionIndex, ColorMode, left, top, width, height, border);
        }

        public int Do_MakeLeaf(Int32 RootType, Int32 ActionMode, Int32 ChapterIndex, Int32 RegionIndex, Int32 LeafIndex,
            Int32 ColorMode, UInt32 time, ushort wait)
        {
            return MakeLeaf(RootType, ActionMode, ChapterIndex, RegionIndex, LeafIndex, ColorMode, time, wait);
        }

        public int Do_MakeObject(Int32 RootType, Int32 ActionMode, Int32 ChapterIndex, Int32 RegionIndex, Int32 LeafIndex, Int32 ObjectIndex, Int32 ColorMode)
        {
            return MakeObject(RootType, ActionMode, ChapterIndex, RegionIndex, LeafIndex, ObjectIndex, ColorMode);
        }

        public int Do_AddChapter(ushort num, UInt32 time, ushort wait)
        {
            return AddChapter(num, time, wait);
        }

        public int Do_AddChapterEx(ushort num, UInt32 time, ushort wait, ushort kind, ushort week, ref TTimeStamp fromtime, ref TTimeStamp totime)
        {
            return AddChapterEx(num, time, wait, kind, week, ref fromtime, ref totime);
        }

        public int Do_AddRegion(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 border)
        {
            return AddRegion(num, left, top, width, height, border);
        }

        public int Do_AddLeaf(ushort num, UInt32 time, ushort wait)
        {
            return AddLeaf(num, time, wait);
        }

        public int Do_AddDateTime(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle,
            Int32 year_offset, Int32 month_offset, Int32 day_offset, Int32 sec_offset, string format)
        {
            return AddDateTime(num, left, top, width, height, transparent, border, fontname, fontsize, fontcolor, fontstyle,
                year_offset, month_offset, day_offset, sec_offset, format);
        }

        public int Do_AddDateTimeEx(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, Int32 vertical,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle,
            Int32 year_offset, Int32 month_offset, Int32 day_offset, Int32 sec_offset, string format)
        {
            return AddDateTimeEx(num, left, top, width, height, transparent, border, vertical, fontname, fontsize, fontcolor, fontstyle,
                year_offset, month_offset, day_offset, sec_offset, format);
        }

        public int Do_AddCampaign(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle,
            string format, ref TTimeStamp basetime, ref TTimeStamp fromtime, ref TTimeStamp totime, Int32 step)
        {
            return AddCampaignEx(num, left, top, width, height, transparent, border, fontname, fontsize, fontcolor, fontstyle,
                format, ref basetime, ref fromtime, ref totime, step);
        }

        public int Do_AddCounter(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, Int32 countertype, Int32 format,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, ref TTimeStamp basetime)
        {
            return AddCounter(num, left, top, width, height, transparent, border, countertype, format, fontname, fontsize, fontcolor, fontstyle, ref basetime);
        }

        public int Do_AddClock(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, Int32 offset,
            UInt32 bkcolor, UInt32 bordercolor, UInt32 borderwidth, Int32 bordershape,
            Int32 dotradius, Int32 adotwidth, UInt32 adotcolor, Int32 bdotwidth, UInt32 bdotcolor,
            Int32 hourwidth, UInt32 hourcolor, Int32 minutewidth, UInt32 minutecolor, Int32 secondwidth, UInt32 secondcolor)
        {
            return AddClock(num, left, top, width, height, transparent, border, offset, bkcolor, bordercolor, borderwidth, bordershape,
                dotradius, adotwidth, adotcolor, bdotwidth, bdotcolor,
                hourwidth, hourcolor, minutewidth, minutecolor, secondwidth, secondcolor);
        }

        public int Do_AddClockEx2(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, Int32 vertical, Int32 offset,
            UInt32 bkcolor, UInt32 bordercolor, UInt32 borderwidth, Int32 bordershape,
            Int32 dotradius, Int32 adotwidth, UInt32 adotcolor, Int32 bdotwidth, UInt32 bdotcolor,
            UInt32 cdotvisible, Int32 cdotwidth, UInt32 cdotcolor,
            Int32 hourwidth, UInt32 hourcolor, Int32 minutewidth, UInt32 minutecolor, Int32 secondwidth, UInt32 secondcolor)
        {
            return AddClockEx2(num, left, top, width, height, transparent, border, vertical, offset, bkcolor, bordercolor, borderwidth, bordershape,
                dotradius, adotwidth, adotcolor, bdotwidth, bdotcolor, cdotvisible, cdotwidth, cdotcolor,
                hourwidth, hourcolor, minutewidth, minutecolor, secondwidth, secondcolor);
        }

        public int Do_AddMovie(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, string filename, Int32 stretch)
        {
            return AddMovie(num, left, top, width, height, transparent, border, filename, stretch);
        }

        public int Do_AddWindows(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border)
        {
            return AddWindows(num, left, top, width, height, transparent, border);
        }

        public int Do_AddChildWindow(ushort num, UInt32 dc, Int32 width, Int32 height, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddChildWindow(num, dc, width, height, alignment, inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddChildPicture(ushort num, string filename, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddChildPicture(num, filename, alignment, inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddChildText(ushort num, string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 wordwrap, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddChildText(num, str, fontname, fontsize, fontcolor, fontstyle, wordwrap, alignment,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddChildTextEx(ushort num, string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 wordwrap, Int32 alignment, Int32 verticalspace,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddChildTextEx(num, str, fontname, fontsize, fontcolor, fontstyle, 0, wordwrap, 0, alignment, verticalspace, 0,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddStrings(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border)
        {
            return AddStrings(num, left, top, width, height, transparent, border);
        }

        public int Do_AddChildString(ushort num, string str, Int32 fontset, Int32 color,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddChildString(num, str, fontset, color,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddWindow(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            UInt32 dc, Int32 src_width, Int32 src_height, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddWindow(num, left, top, width, height, transparent, border, dc, src_width, src_height, alignment,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddPicture(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border, string filename, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddPicture(num, left, top, width, height, transparent, border, filename, alignment,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddTable(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, string profile, string content,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddTable(num, left, top, width, height, transparent, profile, content,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddText(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 wordwrap, Int32 alignment,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddText(num, left, top, width, height, transparent, border,
                str, fontname, fontsize, fontcolor, fontstyle, wordwrap, alignment,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddTextEx(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 wordwrap, Int32 vertical, Int32 alignment, Int32 verticalspace,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddTextEx3(num, left, top, width, height, transparent, 0,
                str, fontname, fontsize, fontcolor, fontstyle, 0, 0, wordwrap, vertical, alignment, verticalspace, 0,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddString(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string str, Int32 fontset, Int32 color,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddString(num, left, top, width, height, transparent, border, str, fontset, color,
                inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

        public int Do_AddTemperature(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle)
        {
            return AddTemperature(num, left, top, width, height, transparent, border, fontname, fontsize, fontcolor, fontstyle);
        }

        public int Do_AddHumidity(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle)
        {
            return AddHumidity(num, left, top, width, height, transparent, border, fontname, fontsize, fontcolor, fontstyle);
        }

        public int Do_UserCanvas_Init(Int32 width, Int32 height)
        {
            return UserCanvas_Init(width, height);
        }

        public int Do_UserCanvas_Draw_Line(Int32 X, Int32 Y, Int32 X1, Int32 Y1, Int32 linewidth, Int32 linecolor)
        {
            return UserCanvas_Draw_Line(X, Y, X1, Y1, linewidth, linecolor);
        }

        public int Do_UserCanvas_Draw_Rectangle(Int32 X, Int32 Y, Int32 X1, Int32 Y1, Int32 linewidth, Int32 linecolor, Int32 fillcolor)
        {
            return UserCanvas_Draw_Rectangle(X, Y, X1, Y1, linewidth, linecolor, fillcolor);
        }

        public int Do_UserCanvas_Draw_Ellipse(Int32 X, Int32 Y, Int32 X1, Int32 Y1, Int32 linewidth, Int32 linecolor, Int32 fillcolor)
        {
            return UserCanvas_Draw_Ellipse(X, Y, X1, Y1, linewidth, linecolor, fillcolor);
        }

        public int Do_UserCanvas_Draw_RoundRect(Int32 X, Int32 Y, Int32 X1, Int32 Y1, Int32 linewidth, Int32 linecolor, Int32 fillcolor, Int32 roundx, Int32 roundy)
        {
            return UserCanvas_Draw_RoundRect(X, Y, X1, Y1, linewidth, linecolor, fillcolor, roundx, roundy);
        }

        public int Do_UserCanvas_Draw_Text(Int32 left, Int32 top, Int32 width, Int32 height, string str, string fontname, Int32 fontsize, Int32 fontcolor, Int32 fontstyle, Int32 alignment)
        {
            return UserCanvas_Draw_Text(left, top, width, height, str, fontname, fontsize, fontcolor, fontstyle, alignment);
        }

        public int Do_AddUserCanvas(ushort num, Int32 left, Int32 top, Int32 width, Int32 height, Int32 transparent, Int32 border,
            Int32 inmethod, Int32 inspeed, Int32 outmethod, Int32 outspeed, Int32 stopmethod, Int32 stopspeed, Int32 stoptime)
        {
            return AddUserCanvas(num, left, top, width, height, transparent, border, inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime);
        }

    }
}
