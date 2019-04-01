using System;
using System.Drawing;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.DatabaseAccess;

namespace Ts_zyys_main
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
		private long _menuId;
		public static RelationalDatabase _database;
		private MenuTag _functions;
		public static Form _mdiParent;
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
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            frmMain frmmain = null;
            switch (_functionName)
            {
                case "Fun_Ts_zyys_main_1":
                    frmmain = new frmMain(_currentUser.UserID, _currentDept.DeptId, _chineseName, 1, FunctionTag);  //update 2015-8-12
                    break;
                case "Fun_Ts_zyys_main_2":
                    frmmain = new frmMain(_currentUser.UserID, _currentDept.DeptId, _chineseName, 2);
                    break;
                case "Fun_Ts_zyys_main_3":
                    frmmain = new frmMain(_currentUser.UserID, _currentDept.DeptId, _chineseName, 3);
                    break;
                case "Fun_Ts_zyys_main_4":
                    frmmain = new frmMain(_currentUser.UserID, _currentDept.DeptId, _chineseName, 4);
                    break;
                default:
                    throw new Exception("��������������");
            }
            if (_mdiParent != null)
            {
                frmmain.MdiParent = _mdiParent;
            }
            frmmain.WindowState = FormWindowState.Maximized;
            frmmain.BringToFront();
            frmmain.Show();
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
			frmMain frmmain=null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_main_1" :							
					frmmain=new frmMain(_currentUser.UserID,_currentDept.DeptId,_chineseName,1);					
					break;
				case "Fun_Ts_zyys_main_2" :							
					frmmain=new frmMain(_currentUser.UserID,_currentDept.DeptId,_chineseName,2);					
					break;
				case "Fun_Ts_zyys_main_3" :							
					frmmain=new frmMain(_currentUser.UserID,_currentDept.DeptId,_chineseName,3);				
					break;
				case "Fun_Ts_zyys_main_4" :							
					frmmain=new frmMain(_currentUser.UserID,_currentDept.DeptId,_chineseName,4);				
					break;
				default :
					throw new Exception("�����������ƴ���");
			}
			return frmmain;
		}

		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="Ts_zyys_main";
			objectInfo.Text="������";
			objectInfo.Remark="סԺҽ��վ������";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[4];
			objectInfos[0].Name="Fun_Ts_zyys_main_1";
			objectInfos[0].Text="������";
			objectInfos[0].Remark="��ͨסԺҽ����";
			objectInfos[1].Name="Fun_Ts_zyys_main_2";
			objectInfos[1].Text="������";
			objectInfos[1].Remark="��סԺҽ����";
			objectInfos[2].Name="Fun_Ts_zyys_main_3";
			objectInfos[2].Text="������";
			objectInfos[2].Remark="����������";
			objectInfos[3].Name="Fun_Ts_zyys_main_4";
			objectInfos[3].Text="������";
			objectInfos[3].Remark="��ѯ��";
			return objectInfos;
		}
		#endregion

		#endregion
	}
}
