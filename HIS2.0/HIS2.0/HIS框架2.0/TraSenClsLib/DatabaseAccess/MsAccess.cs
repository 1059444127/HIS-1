using System;
using System.Data.OleDb;

namespace TrasenClasses.DatabaseAccess
{
	/// <summary>
	/// MsAccess ��ժҪ˵����
	/// </summary>
	public class MsAccess : OleDB
	{
		/// <summary>
		/// ���ݿ�ƽ̨����
		/// </summary>
		new protected const string VENDOR_NAME = "MsAccess";
		/// <summary>
		/// ����һIbmDb2
		/// </summary>
		public MsAccess()
		{
			this.Vendor = VENDOR_NAME;
		}
		private MsAccess (string name ,string connectionString )
		{
			this.Vendor = VENDOR_NAME;
			this.cnnString = connectionString;
			this.connection = new OleDbConnection (connectionString);
			this.Name = name;
		}
		/// <summary>
		/// ��ȡ�ö��󸱱�
		/// </summary>
		/// <returns></returns>
		public override RelationalDatabase GetCopy()
		{	
			return new MsAccess(this.Name,this.cnnString);
		}

        public override ConnectType ConnectionType
        {
            get
            {
                return ConnectType.MSACCESS;
            }
        }
		/// <summary>
		/// ��ȡ������ʱ���SQL���
		/// </summary>
		/// <returns></returns>
		public override string GetIdentityString()
		{
			return null;
		}
		/// <summary>
		/// ��ȡ������ʱ���SQL���
		/// </summary>
		/// <returns></returns>
		public override string GetServerTimeString()
		{
			return "SELECT NOW()";
		}
	}
}
