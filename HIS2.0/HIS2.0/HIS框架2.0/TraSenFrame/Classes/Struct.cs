using System;
using TrasenClasses.DatabaseAccess;
using System.Runtime.InteropServices;

namespace TrasenFrame.Classes
{
	/// <summary>
	///  ���ݿ���ֶ���Ϣ
	/// </summary>
	public struct TableField
	{
		/// <summary>
		/// ���ݿ��ֶ�����
		/// </summary>
		public string DatabaseName;
		/// <summary>
		/// ��ʾ�б���
		/// </summary>
		public string ChineseName;
		/// <summary>
		/// ��ʾ���
		/// </summary>
		public int ViewWidth;		
		/// <summary>
		/// ����ShowCardѡ�SQL���(������item_id,item_name,py_code,wb_code,d_code��)
		/// </summary>
		public string ShowCardSql;	
		/// <summary>
		/// Ĭ��ֵ
		/// </summary>
		public string DefaultValue;
		/// <summary>
		/// ������ʽ
		/// </summary>
		public string RegularExpressions;
		/// <summary>
		/// �Ƿ�ΪΨһ�����ֶ�
		/// </summary>
		public bool IsUniqueKey;	
		/// <summary>
		/// �Ƿ�Ϊɾ������ֶ�
		/// </summary>
		public bool IsDeleteField;	
		/// <summary>
		/// �Ƿ��Զ������ֶ�
		/// </summary>
		public bool IsAutoIncrease;	
		/// <summary>
		/// ƴ�����ֶ�
		/// </summary>
		public bool IsPYField;		
		/// <summary>
		/// ������ֶ�
		/// </summary>
		public bool IsWBField;		
		/// <summary>
		/// ��Ҫ�������ƴ�����ֶ�
		/// </summary>
		public bool IsNameField;
		/// <summary>
		/// �Ƿ������ظ�
		/// </summary>	
		public bool UnAllowRepeat;
		/// <summary>
		/// �ֶ���������
		/// </summary>
		public FieldSpeciType SpeciType;
		/// <summary>
		/// �ֶ�����
		/// </summary>
		public Type FieldType;
	}
	/// <summary>
	/// �Զ���˵��ĸ���ֵ�ṹ
	/// </summary>
	public struct MenuTag
	{
		/// <summary>
		/// ��Ӧ��dll����
		/// </summary>
		public string DllName;
		/// <summary>
		/// ������������
		/// </summary>
		public string Function_Name;
		/// <summary>
		/// ������������ֵ
		/// </summary>
		public string FunctionTag;
		/// <summary>
		/// ����ģ����
		/// </summary>
		public int ModuleId;
		/// <summary>
		/// �˵�������
		/// </summary>
		public string MenuName;
		/// <summary>
		/// ϵͳ�˵����
		/// </summary>
		public SystemInfo System;
        /// <summary>
        /// �˵����ݿ�ָ���������
        /// </summary>
        public int Jgbm;
        /// <summary>
        /// ����ʹ�� �������� jianqg 2012-10-6 emr-his�������  ����
        /// </summary>
        public bool CanUsePublicPwd;
        /// <summary>
        /// �˵���Ȩ��
        /// </summary>
        public string AuthCode;

        public static MenuTag GetTag(string dllName,string functionName,string functionTag,string name,RelationalDatabase database)
        {
            string sql = string.Format( "select * from pub_menu where Name='{0}' and Dll_Name = '{1}' and Function_Name='{2}'" , name , dllName , functionName );
            if ( !string.IsNullOrEmpty( functionTag ) )
                sql += string.Format( " and Function_Tag = '{0}'" , functionTag );
            else
                sql += " and ( Function_Tag = '' or Function_Tag is null) ";
            System.Data.DataRow row = database.GetDataRow( sql );
            
            MenuTag tag = new MenuTag();
            if ( row != null )
            {
                tag.Function_Name = row["Function_Name"].ToString().Trim();
                tag.FunctionTag = row["function_tag"].ToString().Trim();
                tag.DllName = row["Dll_name"].ToString().Trim();
                tag.MenuName = row["name"].ToString().Trim();
                tag.System = new TrasenFrame.Classes.SystemInfo( Convert.ToInt32( row["menu_id"] ) ,database );
                tag.Jgbm = Convert.ToInt32( row["jgbm"] ) == -1 ? TrasenFrame.Forms.FrmMdiMain.Jgbm : Convert.ToInt32( row["jgbm"] );//Add By Tany 2010-01-14 Modify By Tany ���û�����û������룬��Ĭ�ϻ�����������Ϊ��¼��������
                //jianqg emr-his ������ʱע��
                tag.CanUsePublicPwd = Convert.ToInt32( row["CanUsePublicPwd"] ) == 1 ? true : false;//�Ƿ�����ù������� jianqg 2012-10-6 emr-his�������  ����
                
                if( row.Table.Columns.Contains("AuthCode") )
                    tag.AuthCode = Convert.IsDBNull( row["AuthCode"] ) ? "" : row["AuthCode"].ToString();
                else
                    tag.AuthCode = "";                
            }
            return tag;
        }
	}

	/// <summary>
	/// TextBoxTag
	/// </summary>
	public struct TEXTBOXTAG
	{
		/// <summary>
		/// �ֶ�����
		/// </summary>
		public TableField FieldProperty;
		/// <summary>
		/// �ֶε�ǰֵ
		/// </summary>
		public object Value;
	}


    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public int cbData;
        [MarshalAs( UnmanagedType.LPStr )]
        public string lpData;
    }
}
