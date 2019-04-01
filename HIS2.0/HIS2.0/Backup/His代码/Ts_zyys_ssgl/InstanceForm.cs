using System;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;

namespace Ts_zyys_ssgl
{
	/// <summary>
	/// InstanceForm ��ժҪ˵����
	/// ������ÿ��DLL�������ʵĽӿں�����
	/// ���Ʋ��ܸģ�������Сд��
	/// </summary>
	public class InstanceForm:IInnerCommunicate//IDllInformation
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
			if(_functionName=="")
			{
				throw new Exception("��������������Ϊ�գ�");
			}
			FrmSSApply frmSSApply=null;
			FrmSSQuery frmSSQuery=null;
            FrmTssSh frmtssh = null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_sssq" :
					frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmSSApply.MdiParent=_mdiParent;
					}
					frmSSApply.BringToFront();
					frmSSApply.ShowDialog();
					break;
				case "Fun_Ts_zyys_sscx" :
					frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmSSQuery.MdiParent=_mdiParent;
					}
					frmSSQuery.BringToFront();
					frmSSQuery.ShowDialog();
					break;
				case "Fun_Ts_zyys_ssapcx" :
					frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmSSQuery.MdiParent=_mdiParent;
					}
					frmSSQuery.WindowState=FormWindowState.Maximized;
					frmSSQuery.BringToFront();
					frmSSQuery.Show();
					break;
                case "Fun_Ts_zyys_tssssh":
                    frmtssh = new FrmTssSh();
                    if (_mdiParent != null)
                    {
                        frmtssh.MdiParent = _mdiParent;
                    }
                    frmtssh.WindowState = FormWindowState.Maximized;
                    frmtssh.BringToFront();
                    frmtssh.Show();
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
			FrmSSApply frmSSApply=null;
			FrmSSQuery frmSSQuery=null;
			Form ff=new Form();
			switch(_functionName)
			{
				case "Fun_Ts_zyys_sssq" :
					if(_communicateValue!=null)
					{						
						frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmSSApply.MdiParent = _mdiParent;
					}
					ff=frmSSApply;
					break;
                    //add by zouchihua 2013-8-28 ���������ѯ
                case "Fun_Ts_zyys_sssq_cx":
                    if (_communicateValue != null)
                    {						
						frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName);
                    frmSSApply._ck = true;
					if(_mdiParent!=null)
					{
						frmSSApply.MdiParent = _mdiParent;
					}
					ff=frmSSApply;
                    break;
				case "Fun_Ts_zyys_sscx" :
					if(_communicateValue!=null)
					{						
						frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmSSQuery.MdiParent = _mdiParent;
					}
					ff=frmSSQuery;
					break;
				case "Fun_Ts_zyys_ssapcx" :
					frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmSSQuery.MdiParent = _mdiParent;
					}
					ff=frmSSQuery;
					break;
                case "Fun_Ts_zyys_sssq_hs"://�����������������ʿ��ҽ��ʹ�� Add By Tany 2007-09-20
                    frmSSApply = new FrmSSApply(_currentUser.UserID, _currentDept.DeptId, _chineseName, true, _communicateValue);
                    
                    if (_mdiParent != null)
                    {
                        frmSSApply.MdiParent = _mdiParent;
                    }
                    ff = frmSSApply;
                    break;
                case "Fun_Ts_zyys_sssq_cp"://����������������ٴ�·��ʹ�� Add By Tany 2012-09-28
                    frmSSApply = new FrmSSApply(_currentUser.UserID, _currentDept.DeptId, _chineseName, 1, _communicateValue);

                    if (_mdiParent != null)
                    {
                        frmSSApply.MdiParent = _mdiParent;
                    }
                    ff = frmSSApply;
                    break;
                case "Fun_Ts_zyys_tssssh":
                    FrmTssSh frmtssh = new FrmTssSh();
                    if (_mdiParent != null)
                    {
                        frmtssh.MdiParent = _mdiParent;
                    }
                    frmtssh.WindowState = FormWindowState.Maximized;
                    frmtssh.BringToFront();
                    frmtssh.Show();
                    ff = frmtssh;
                    break;
				default :
					throw new Exception("�����������ƴ���");
			}
			return ff;
		}
		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="Ts_zyys_ssgl";
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
			ObjectInfo[] objectInfos=new ObjectInfo[4];
			objectInfos[0].Name="Fun_Ts_zyys_sssq";
			objectInfos[0].Text="��������";
			objectInfos[0].Remark="��������";
			objectInfos[1].Name="Fun_Ts_zyys_sscx";
			objectInfos[1].Text="������ѯ";
			objectInfos[1].Remark="������ѯ";
			objectInfos[2].Name="Fun_Ts_zyys_ssapcx";
			objectInfos[2].Text="�������Ų�ѯ";
			objectInfos[2].Remark="�������Ų�ѯ";

            objectInfos[3].Name = "Fun_Ts_zyys_tssssh";
            objectInfos[3].Text = "�����������";
            objectInfos[3].Remark = "�����������";
			
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
