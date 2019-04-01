using System;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes
{
	/// <summary>
	/// ISet ��ժҪ˵����
	/// </summary>
	public interface ISet
	{
		/// <summary>
		/// ȡ�úϼ�
		/// </summary>
		/// <param name="index">�ֶ�����</param>
		/// <param name="filter">��������</param>
		/// <returns></returns>
		decimal Sum(int index,string filter);
		/// <summary>
		/// ȡ�úϼ�
		/// </summary>
		/// <param name="fieldName">�ֶ�����</param>
		/// <param name="filter">��������</param>
		/// <returns></returns>
		decimal Sum(string fieldName,string filter);
		/// <summary>
		/// �õ������е�����
		/// </summary>
		/// <param name="filter">���¹�������</param>
		/// <returns></returns>
		long Count(string filter);
		/// <summary>
		/// ���һ��
		/// </summary>
		/// <returns></returns>
		bool Add();
		/// <summary>
		/// ���¼����е��ֶ�
		/// </summary>
		/// <param name="Items">���µ�ֵ</param>
		/// <param name="filter">���¹�������</param>
		/// <returns>Ӱ�������</returns>
		long UpdateField(ItemEx[] Items,string filter);
		/// <summary>
		/// ����filter�������˱��¼
		/// </summary>
		/// <param name="filter">ɸѡ����</param>
		/// <returns></returns>
		DataTable FilterTable(string filter);
		/// <summary>
		/// ���鲢���ݾۺϺ������ʽ��ֵ
		/// </summary>
		/// <param name="groupByFieldsName">���鷽ʽ</param>
		/// <param name="computerFieldsName">����������</param>
		/// <param name="computerFormularsName">���㺯������</param>
		/// <param name="filter">ɸѡ����</param>
		/// <returns></returns>
		DataTable GroupTable(string[] groupByFieldsName,string[] computerFieldsName,string[] computerFormularsName,string filter);
		/// <summary>
		/// �Ѷ����ݵĸ���д�����ݿ���ȥ���Ա����ϵ��޸���������ø÷����򲻻�д���ݿ�
		/// </summary>
		/// <returns></returns>
		bool Flash();
	}
}
