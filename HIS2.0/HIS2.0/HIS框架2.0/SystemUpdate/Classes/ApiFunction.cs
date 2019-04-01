using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SystemUpdate
{
	/// <summary>
	/// SECURITY_ATTRIBUTES ��˵��
	/// </summary>
	[StructLayout( LayoutKind.Sequential)]
	public class SECURITY_ATTRIBUTES 
	{
		/// <summary>nLength</summary>
		public int nLength; 
		/// <summary>lpSecurityDescriptor</summary>
		public int lpSecurityDescriptor; 
		/// <summary>bInheritHandle</summary>
		public int bInheritHandle; 
	}
	/// <summary>
	/// ApiFunction ��ժҪ˵����
	/// </summary>
	public class ApiFunction
	{
		//��������
		private static int WM_VSCROLL  = 0x115;
		private static int SB_LINEUP = 0;
		private static int SB_LINEDOWN = 1;
		private static int SB_PAGEUP = 2;
		private static int SB_PAGEDOWN = 3;
		/// <summary>
		/// ������
		/// </summary>
		public const int ERROR_ALREADY_EXISTS = 0183;

		//API��������
		[DllImport("kernel32")] 
		private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
		[DllImport("kernel32")] //EntryPoint="WritePrivateProfileString"
		private static extern int WritePrivateProfileString(string lpApplicationName ,string lpKeyName, string lpString, string lpFileName);
		/// <summary>
		/// �����������ߴ������ƻ�þ��
		/// </summary>
		/// <param name="lpClassName">����</param>
		/// <param name="lpWindowName">��������</param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(String lpClassName,String lpWindowName);
		/// <summary>
		/// ���ݾ���رմ���
		/// </summary>
		/// <param name="hwnd">���</param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern long CloseWindow(IntPtr hwnd);
		/// <summary>
		/// ��ô�����Ϣ��ʶ
		/// </summary>
		/// <returns></returns>
		[DllImport("kernel32")]
		public static extern int GetLastError();
		/// <summary>
		/// ����һ�����
		/// </summary>
		/// <param name="lpMutexAttributes"></param>
		/// <param name="bInitialOwner"></param>
		/// <param name="lpName"></param>
		/// <returns></returns>
		[DllImport("kernel32")]
		public static extern IntPtr CreateMutex(SECURITY_ATTRIBUTES lpMutexAttributes,bool bInitialOwner,string lpName);
		/// <summary>
		/// �ͷ�ָ���ľ��
		/// </summary>
		/// <param name="hMutex">���</param>
		/// <returns></returns>
		[DllImport("kernel32")]
		public static extern int ReleaseMutex(IntPtr hMutex);

		/// <summary>
		/// ������Ϣ
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="wMsg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hwnd ,int wMsg ,int wParam, int lParam);
		
		/// <summary>
		/// ������Ϣ
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool UpdateWindow(IntPtr hWnd);

		
		private ApiFunction()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ȡINI�ļ�
		/// </summary>
		/// <param name="lpApplicationName">����</param>
		/// <param name="lpKeyName">�ؼ���</param>
		/// <param name="lpFileName">INI�ļ�·��</param>
		/// <returns></returns>
		public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
		{
			System.Text.StringBuilder strReturn=new StringBuilder(255);
			int nSize=GetPrivateProfileString(lpApplicationName,lpKeyName,"",strReturn,255,lpFileName);
			return strReturn.ToString();
		}
		/// <summary>
		/// дIni�ļ�
		/// </summary>
		/// <param name="lpApplicationName">����</param>
		/// <param name="lpKeyName">�ؼ���</param>
		/// <param name="lpString">ֵ</param>
		/// <param name="lpFileName">INI�ļ�·��</param>
		public static void WriteIniString(string lpApplicationName ,string lpKeyName, string lpString, string lpFileName)
		{
			WritePrivateProfileString(lpApplicationName ,lpKeyName, lpString, lpFileName);
		}
		/// <summary>
		/// �Զ�����
		/// </summary>
		/// <param name="handle">���</param>
		public static void SelfSrcoll(IntPtr handle)
		{
			SendMessage(handle,WM_VSCROLL,SB_PAGEDOWN,0);
			UpdateWindow(handle);
		}
	}
}
