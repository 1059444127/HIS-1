/* ��׼ģ�� */
using TrasenClasses.DatabaseAccess;

namespace TrasenFrame.Classes
{
	/// <summary>
	/// ��׼ģ�ͽӿ�
	/// </summary>
	public interface IStdObject
	{
		/// <summary>
		/// ���淽��
		/// </summary>
		/// <returns></returns>
		bool Save();
		/// <summary>
		/// �ָ�
		/// </summary>
		/// <returns></returns>
		bool Retrieve();
		/// <summary>
		/// ɾ������
		/// </summary>
		/// <returns></returns>
		bool Delete();
		/// <summary>
		/// ���ݿ���ʶ���
		/// </summary>
		RelationalDatabase Database {get;set;}

	}/* END INTERFACE DEFINITION IStdObject */
}