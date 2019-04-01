using System;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace Ts_zyys_jysq
{
	/// <summary>
	/// InstanceForm ��ժҪ˵����
	/// ������ÿ��DLL�������ʵĽӿں�����
	/// ���Ʋ��ܸģ�������Сд��
	/// </summary>
	public class InstanceForm:IInnerCommunicate
	{
		private string _functionName;
		private string _chineseName;
		public static User _currentUser;
		public static Department _currentDept;
        public static long _menuId;
		public static RelationalDatabase _database;
		private MenuTag _functions;
		private Form _mdiParent;
		private object[] _communicateValue;

		public InstanceForm()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			_functionName="";
			_chineseName="";
			_database=null;
			_currentUser=null;
			_currentDept=null;
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
				return _currentUser;
			}
			set
			{
				_currentUser = value;
			}
		}

		/// <summary>
		/// ��ǰ��������ID
		/// </summary>
		public Department CurrentDept
		{
			get
			{
				return _currentDept;
			}
			set
			{
				_currentDept = value;
			}
		}

		/// <summary>
		/// Database���ݿ�ʵ����
		/// </summary>
		public RelationalDatabase Database
		{
			get
			{
				return _database;
			}
			set
			{
				_database = value;
			}
		}

		/// <summary>
		/// FuncationTag����������ֵ
		/// </summary>
		public MenuTag FunctionTag
		{
			get
			{
				return _functions;
			}
			set
			{
				_functions = value;
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
		/// MDI������
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
			FrmJYSQ frmjysq=null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_jcsq" :
					frmjysq=new FrmJYSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmjysq.MdiParent=_mdiParent;
					}
					frmjysq.BringToFront();
					frmjysq.ShowDialog();
					break;
                case "Fun_Ts_zyys_jysq_bmwh":
                   FrmJyxmBm  frmybm = new FrmJyxmBm();// new FrmJYSQ(_currentUser.UserID, _currentDept.DeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmybm.MdiParent = _mdiParent;
                    }
                    frmybm.BringToFront();
                    frmybm.WindowState = FormWindowState.Maximized;
                    frmybm.Show();
                    break;		
				default :
					throw new Exception("��������������");
			}
		
		}
		/// <summary>
		/// ����һ��FORM����
		/// </summary>
		/// <returns></returns>
		public object GetObject()
		{ 
			if(_functionName=="")
			{
				throw new Exception("��������������Ϊ�գ�");
			}
			FrmJYSQ frmjysq=null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_jysq" :
					if(_communicateValue!=null)
					{						
						frmjysq=new FrmJYSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmjysq=new FrmJYSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmjysq.MdiParent = _mdiParent;
					}

					break;
                case "Fun_Ts_zyys_jysq_bmwh":
                    FrmJyxmBm frmjysqbm = new FrmJyxmBm();
                    if (_mdiParent != null)
                    {
                        frmjysqbm.MdiParent = _mdiParent;
                    }
                    return frmjysqbm;
                    break;
				default :
					throw new Exception("�����������ƴ���");
			}
			return frmjysq;
		}
		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="Ts_zyys_jysq";
			objectInfo.Text="��������";
			objectInfo.Remark="��������";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[2];
			objectInfos[0].Name="Fun_Ts_zyys_jysq";
			objectInfos[0].Text="��������";
			objectInfos[0].Remark="��������";
            objectInfos[1].Name = "Fun_Ts_zyys_jysq_bmwh";
            objectInfos[1].Text = "������Ŀ���Ƽ�дά��";
            objectInfos[1].Remark = "������Ŀ���Ƽ�дά��";
			
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
