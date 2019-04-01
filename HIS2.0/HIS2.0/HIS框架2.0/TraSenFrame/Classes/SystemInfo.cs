using System;

namespace TrasenFrame.Classes
{
	/// <summary>
	/// SystemInfo ��ժҪ˵����
	/// </summary>
	public class SystemInfo
	{
		/// <summary>
		/// ϵͳ��Ϣ
		/// </summary>
		public SystemInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ϵͳ��Ϣ
		/// </summary>
		/// <param name="systemId">ϵͳ���</param>
		/// <param name="database">database</param>
		public SystemInfo(int systemId,TrasenClasses.DatabaseAccess.RelationalDatabase database)
		{
			string sql = "select * from pub_system where system_id=" + systemId;
			System.Data.DataRow dr = database.GetDataRow(sql);
			if ( dr != null )
			{
				_systemId = Convert.ToInt32( dr["system_id"] );
				_systemName = dr["name"].ToString().Trim();
                //add by wangzhi 2010-11-27
                autoLocktime = Convert.IsDBNull( dr["auto_lock_time"] ) ? 0 : Convert.ToInt32( dr["auto_lock_time"] );
			}
		}

		private int _systemId;
		private string _systemName;
        
		/// <summary>
		/// ϵͳ���
		/// </summary>
		public int SystemId
		{
			get
			{
				return _systemId;
			}
			set
			{
				_systemId = value;
			}
		}
		/// <summary>
		/// ϵͳ����
		/// </summary>
		public string SystemName
		{
			get
			{
				return _systemName;
			}
			set
			{
				_systemName = value;
			}
		}
        //add by wangzhi 2010-11-27
        private int autoLocktime;
        /// <summary>
        /// ϵͳ�Զ�����ʱ�䣬��λ�����ӣ�
        /// </summary>
        public int AutoLockTime
        {
            get
            {
                return autoLocktime;
            }
        }
        //end add

        public static System.Data.DataTable GetList(string filter , TrasenClasses.DatabaseAccess.RelationalDatabase database )
        {
            string sql = "select * from pub_system where 1=1";
            if ( !string.IsNullOrEmpty( filter ) )
                sql += filter;
            return database.GetDataTable( sql );
        }
	}
}
