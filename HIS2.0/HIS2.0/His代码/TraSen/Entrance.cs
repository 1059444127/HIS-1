using System;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace TraSen
{
	/// <summary>
	/// ϵͳ���
	/// </summary>
	public class Entrance
	{
		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			/*
			 * ����˵��:
			 * caption		�����������
			 * connectionType �� ���ݿ���������
			 * connectionString �����ַ���
			 * mainProgramname:��������
			 * checkRegister :�Ƿ���ע����Ϣ
			 * */
			string serverName = "mydb_svr";

			serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME","NAME",Constant.ApplicationDirectory + "\\ClientConfig.ini");
			if ( serverName == "" )
			{
				System.Windows.Forms.MessageBox.Show("ClientConfig.ini��[SERVER_NAME]��NAMEδ����,���������ó������õ�ǰ������","����");
				return;
			}
			string connectionString = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER,serverName);

		    TrasenMainWindow.FrmMdiMainWindow.StartupMain("���ǿƼ���Ϣϵͳ",ConnectionType.SQLSERVER,	connectionString,"Trasen",true);
		}
	}
}
