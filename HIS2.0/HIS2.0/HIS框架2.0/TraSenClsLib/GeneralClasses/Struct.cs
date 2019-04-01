using System;

namespace TrasenClasses.GeneralClasses
{
	/// <summary>
	/// ��Ŀ��������Ŀֵ
	/// </summary>
	public struct ItemEx
	{
		/// <summary>
		/// ��Ŀ����
		/// </summary>
		public string Text;
		/// <summary>
		/// ��Ŀֵ
		/// </summary>
		public object Value;
	}
	/// <summary>
	/// ����
	/// </summary>
	public struct ParameterEx
	{
		/// <summary>
		/// ��������
		/// </summary>
		public string Text;
		/// <summary>
		/// ����ֵ
		/// </summary>
		public object Value;
		/// <summary>
		/// ������������
		/// </summary>
		public object DataType;
		/// <summary>
		/// �������봫������
		/// </summary>
		public object ParaDirection;
		/// <summary>
		/// ������С
		/// </summary>
		public object ParaSize;
	}
	/// <summary>
	/// ������Ϣ
	/// </summary>
	public struct ObjectInfo
	{
		/// <summary>
		/// ��������
		/// </summary>
		public string Name;
		/// <summary>
		/// ��������
		/// </summary>
		public string Text;
		/// <summary>
		/// ����ע
		/// </summary>
		public string Remark;
	}

	/// <summary>
	/// ʱ���ʽ
	/// </summary>
	public struct SystemTime 
	{ 
		/// <summary>
		/// ��
		/// </summary>
		public short wYear; 
		/// <summary>
		/// ��
		/// </summary>
		public short wMonth; 
		/// <summary>
		/// ����
		/// </summary>
		public short wDayOfWeek; 
		/// <summary>
		/// ��
		/// </summary>
		public short wDay; 
		/// <summary>
		/// Сʱ
		/// </summary>
		public short wHour; 
		/// <summary>
		/// ��
		/// </summary>
		public short wMinute; 
		/// <summary>
		/// ��
		/// </summary>
		public short wSecond; 
		/// <summary>
		/// ����
		/// </summary>
		public short wMilliseconds; 
	}


    public struct FrameEnvironment
    {
        public TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        public object User;
        public object Department;
        public object CSystem;
    }
}