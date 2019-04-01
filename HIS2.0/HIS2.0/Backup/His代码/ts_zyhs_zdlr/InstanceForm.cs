using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_zdlr
{
	/// <summary>
	/// InstanceForm ��ժҪ˵����
	/// ������ÿ��DLL�������ʵĽӿں�����
	/// ���Ʋ��ܸģ�������Сд��
	/// </summary>
	public class InstanceForm : IInnerCommunicate
	{
		//������̬����
		public static RelationalDatabase BDatabase;
		public static User BCurrentUser;
		public static Department BCurrentDept;

		private MenuTag _menuTag;

		private string _functionName;
		private string _chineseName;
		private long _currentUserId;
		private long _currentDeptId;
		private long _menuId;
		private Form _mdiParent;
		private object[] _communicateValue;
		public InstanceForm()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			BDatabase =null;
			BCurrentUser=null;
			BCurrentDept=null;

			_functionName="";
			_chineseName="";
			_currentUserId=-1;
			_currentDeptId=-1;
			_menuId=-1;
			_mdiParent=null;
		}

		#region IInnerCommunicate ��Ա(һ��Ҫ�ڴ�ʵ��)

		#region ����
		/// <summary>
		/// ʵ�������庯������
		/// </summary>
		public string FunctionName
		{
			get
			{
				return _functionName;
			}
			set 
			{
				_functionName=value;
			}
		}
		/// <summary>
		/// ������������
		/// </summary>
		public string ChineseName
		{
			get
			{
				return _chineseName;
			}
			set 
			{
				_chineseName=value;
			}
		}
		/// <summary>
		/// ��ǰ����ԱID
		/// </summary>
		public User CurrentUser
		{
			get
			{
				return BCurrentUser;
			}
			set 
			{
				BCurrentUser=value;
			}
		}
		/// <summary>
		/// ��ǰ��������ID
		/// </summary>
		public Department CurrentDept
		{
			get
			{
				return BCurrentDept;
			}
			set 
			{
				BCurrentDept=value;
			}
		}
		/// <summary>
		/// �˵�ID
		/// </summary>
		public long MenuId
		{
			get
			{
				return _menuId;
			}
			set 
			{
				_menuId=value;
			}
		}
		/// <summary>
		/// �˵�ID
		/// </summary>
		public Form MdiParent
		{
			get
			{
				return _mdiParent;
			}
			set 
			{
				_mdiParent=value;
			}
		}
		public RelationalDatabase Database
		{
			get
			{
				return InstanceForm.BDatabase;
			}
			set
			{
				InstanceForm.BDatabase =value;
			}
		}
		public MenuTag FunctionTag
		{
			get
			{
				return _menuTag;
			}
			set
			{
				_menuTag = value ;
			}
		}
		/// <summary>
		/// �ڲ�ͨ�Ų���
		/// </summary>
		public object[] CommunicateValue
		{
			get
			{
				return _communicateValue;
			}
			set 
			{
				_communicateValue=value;
			}
		}
		#endregion

		#region ����
		/// <summary>
		/// ���ݺ�������ʵ��������
		/// </summary>
		public void InstanceWorkForm()
		{
			if(_functionName=="")
			{
				throw new Exception("��������������Ϊ�գ�");
			}
			frmZDLR frmZdlr=null;
			frmYZModel frmMbcx=null;
			string sSql="";
			if(_communicateValue!=null)
			{
				sSql=_communicateValue[0].ToString();
			}
			switch(_functionName)
			{
				case "Fun_ts_zyhs_zdlr" :
                    frmZdlr = new frmZDLR(_chineseName);
					if(_mdiParent!=null)
					{
						frmZdlr.MdiParent = _mdiParent;
					}
					frmZdlr.Show();
					break;
				case "Fun_ts_zyhs_zdlr_ssmz" :
					frmZdlr=new frmZDLR(_chineseName,sSql);
					if(_mdiParent!=null)
					{
						frmZdlr.MdiParent = _mdiParent;
					}
					frmZdlr.Show();
					break;
				case "Fun_ts_zyhs_mbcx" :
					frmMbcx=new frmYZModel(_chineseName);
					if(_mdiParent!=null)
					{
						frmMbcx.MdiParent = _mdiParent;
					}
					frmMbcx.Show();
					break;
				default :
					throw new Exception("�����������ƴ���");
			}
		
		}
		/// <summary>
		/// ����һ��FORM����
		/// </summary>
		/// <returns></returns>
		public object GetObject()
		{
			return null;
		}
		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="ts_zyhs_zdlr";
			objectInfo.Text="�ʵ�¼��";
			objectInfo.Remark="����¼�롢�鿴�����ʵ���ά���ʵ�ģ��";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[3];
			objectInfos[0].Name="Fun_ts_zyhs_zdlr";
			objectInfos[0].Text="�ʵ�¼��";
			objectInfos[0].Remark="�ʵ�¼��";
			objectInfos[1].Name="Fun_ts_zyhs_zdlr_ssmz";
			objectInfos[1].Text="�ʵ�¼��";
			objectInfos[1].Remark="�ʵ�¼��";
			objectInfos[2].Name="Fun_ts_zyhs_mbcx";
			objectInfos[2].Text="ģ���ѯ";
			objectInfos[2].Remark="�����鿴�ʵ�ģ��";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
