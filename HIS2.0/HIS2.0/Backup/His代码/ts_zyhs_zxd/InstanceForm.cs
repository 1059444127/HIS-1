using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_zxd
{
	/// <summary>
	/// InstanceForm ��ժҪ˵����
	/// ������ÿ��DLL�������ʵĽӿں�����
	/// ���Ʋ��ܸģ�������Сд��
	/// </summary>
	public class InstanceForm : IDllInformation
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

		#region IDllInformation ��Ա(һ��Ҫ�ڴ�ʵ��)

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
			frmZXD frmZxd=null;
            Frmzxdprint frmzld = null;
			switch(_functionName)
			{
				case "Fun_ts_zyhs_zxd" :
					frmZxd=new frmZXD(_chineseName);
					if(_mdiParent!=null)
					{
						frmZxd.MdiParent = _mdiParent;
					}
					frmZxd.Show();
					break;
                case "Fun_ts_zyhs_zxd_allward":
                    frmZxd = new frmZXD(_chineseName,1);
                    if (_mdiParent != null)
                    {
                        frmZxd.MdiParent = _mdiParent;
                    }
                    frmZxd.Show();
                    break;
                    

                case "Fun_ts_zyhs_zxd_zld":
                    frmzld = new Frmzxdprint("���Ƶ���ӡ");
                    if (_mdiParent != null)
                    {
                        frmzld.MdiParent = _mdiParent;
                    }
                    frmzld.Show();
                    break;
				default :
					throw new Exception("�����������ƴ���");
			}
		
		}
		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="ts_zyhs_zxd";
			objectInfo.Text="ִ�е�";
			objectInfo.Remark="ִ�е��ݴ�ӡ������Һ������ҩ���ȣ�";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[3];
			objectInfos[0].Name="Fun_ts_zyhs_zxd";
			objectInfos[0].Text="ִ�е�";
			objectInfos[0].Remark="ִ�е��ݴ�ӡ������Һ������ҩ���ȣ�";

            objectInfos[1].Name = "Fun_ts_zyhs_zxd_allward";
            objectInfos[1].Text = "ִ�е�(���в���)";
            objectInfos[1].Remark = "ִ�е��ݴ�ӡ������Һ������ҩ���ȣ�";

            objectInfos[2].Name = "Fun_ts_zyhs_zxd_zld";
            objectInfos[2].Text = "���Ƶ���ӡ";
            objectInfos[2].Remark = "���Ƶ���ӡ";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
