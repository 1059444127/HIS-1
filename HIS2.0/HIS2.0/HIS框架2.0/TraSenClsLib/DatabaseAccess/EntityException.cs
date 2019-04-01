using System;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.DatabaseAccess
{
	/// <summary>
	///	EntityException ʵ����Ʋ��쳣����ʵ��㷢�����쳣������EntityException�쳣�׳���
	/// </summary>
	public class EntityException:Exception
	{
		private ErrorTypes _errorType;
		private Exception  _errorSource;

		/// <summary>
		///		����һ��PlException�쳣ʵ��
		/// </summary>
		/// <param name="message">�쳣��Ϣ</param>
		public EntityException(string message):base(message)
		{
			this._errorType = ErrorTypes.Unknown;
		}
		
		/// <summary>
		///		����һ��PlException�쳣ʵ��
		/// </summary>
		/// <param name="message">�쳣��Ϣ</param>
		/// <param name="errorType">�쳣����</param>
		public EntityException(string message,ErrorTypes errorType):base(message)
		{
			this._errorType = errorType;
		}

		/// <summary>
		///		����һ��PlException�쳣ʵ��
		/// </summary>
		/// <param name="e">�쳣ʵ��</param>
		public EntityException(Exception e):base("ʵ���δ����Ĵ���")
		{
			this._errorType=ErrorTypes.Unknown;
			this._errorSource=e;
		}

		/*����*/
		
		/// <summary>
		///		���ص�ǰPlExcetpionʵ���Ĵ������(ö������)
		/// </summary>
		public ErrorTypes ErrorType
		{
			get{return this._errorType;}
		}
		
		/// <summary>
		///		���������׳�PlExcetpion��Exception������PlException�޷��õ��㹻�Ĵ�����Ϣ��
		///		�ɴ������������쳣��ԭʼException��
		/// </summary>
		public Exception ErrorSource
		{
			get{return this._errorSource;}
		}
	}

}
