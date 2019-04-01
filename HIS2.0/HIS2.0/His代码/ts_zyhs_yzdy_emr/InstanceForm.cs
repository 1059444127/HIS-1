using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_yzdy
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
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            frmYZDY frmYzdy = null;
            switch (_functionName)
            {
                case "Fun_ts_zyhs_yzdy":
                    frmYzdy = new frmYZDY(_chineseName);
                    if (_mdiParent != null)
                    {
                        frmYzdy.MdiParent = _mdiParent;
                    }
                    frmYzdy.Show();
                    break;
                case "Fun_ts_zyhs_yzdy_xgjl":
                    frmYzdy = new frmYZDY(_chineseName);
                    if (_mdiParent != null)
                    {
                        frmYzdy.MdiParent = _mdiParent;
                    }
                    frmYzdy.xgjl = true;
                    frmYzdy.Show();
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }
		
		}

        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            frmYZDY frmYzdy = null;
           
            switch (_functionName)
            {
                case "Fun_ts_zyhs_yzdy_emr": 
                    if (_communicateValue != null)
                    {
                        frmYzdy = new frmYZDY(_chineseName,_communicateValue);
                    }
                    else
                    {
                        frmYzdy = new frmYZDY(_chineseName);
                    }
                    break;
                case "Fun_ts_zyhs_yzdy_xgjl":
                    if (_communicateValue != null)
                    {
                        frmYzdy = new frmYZDY(_chineseName, _communicateValue);
                    }
                    else
                    {
                        frmYzdy = new frmYZDY(_chineseName);
                    }
                    frmYzdy.xgjl = true;
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }
            return frmYzdy;
        }

		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
            objectInfo.Name = "ts_zyhs_yzdy";
			objectInfo.Text="ҽ����ӡ";
			objectInfo.Remark="ҽ����ӡ";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[2];
            objectInfos[0].Name = "Fun_ts_zyhs_yzdy";
			objectInfos[0].Text="ҽ����ӡ(emr)";
			objectInfos[0].Remark="ҽ����ӡ(emr)";


            objectInfos[1].Name = "Fun_ts_zyhs_yzdy_xgjl";
            objectInfos[1].Text = "ҽ����ӡ(�޸ļ���)";
            objectInfos[1].Remark = "ҽ����ӡ(�޸ļ���)";
			return objectInfos;
		}
		#endregion
		
		#endregion

        #region IInnerCommunicate ��Ա

        public object[] CommunicateValue
        {
            get
            {
                return _communicateValue;
            }
            set
            {
                _communicateValue = value;
            }
        }

      
        #endregion
    }
}
