using System;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace Ts_ss_brcx
{
	/// <summary>
	/// InstanceForm ��ժҪ˵����
	/// ������ÿ��DLL�������ʵĽӿں�����
	/// ���Ʋ��ܸģ�������Сд��
	/// </summary>
	public class InstanceForm : IInnerCommunicate
	{
		private string _functionName;
		private string _chineseName;
		private User _currentUser;
		private Department _currentDept;
		public static long _menuId;
		public static RelationalDatabase _database;
		public static MenuTag _functions;
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
		/// �Ƿ������������
		/// </summary>
		/// <returns></returns>
		private bool IsSsDept()
		{
			string ssql="SELECT 1 FROM SS_DEPT WHERE DEPTID="+this._currentDept.DeptId+"";
			DataTable tb=FrmMdiMain.Database.GetDataTable(ssql);
			try
			{
				if(tb.Rows.Count==0)
				{
					MessageBox.Show ("������������Ҳ���ʹ�ñ�ϵͳ��","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;
				}
				return true;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
				return false;
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
			frmBrcx frmBrcx=null;
            object [] _value=new object[1];
			switch(_functionName)
			{
				case "Fun_Ts_ss_brcx" :
                    if(IsSsDept()==false)
			        {
				       return;
			        }
                    _value[0]=0;//0 �������� 1=��������
					frmBrcx=new frmBrcx(_currentUser.UserID,_currentDept.DeptId,_chineseName,_value);
					if(_mdiParent!=null)
					{
						frmBrcx.MdiParent=_mdiParent;
					}
					frmBrcx.WindowState=FormWindowState.Maximized;
					frmBrcx.BringToFront();
					frmBrcx.Show();
					break;
                case "Fun_Ts_tszl_brcx":
                    _value[0]=1;//0 �������� 1=��������
                    frmBrcx = new frmBrcx(_currentUser.UserID, _currentDept.DeptId, _chineseName,_value);
                    if (_mdiParent != null)
                    {
                        frmBrcx.MdiParent = _mdiParent;
                    }
                    frmBrcx.WindowState = FormWindowState.Maximized;
                    frmBrcx.BringToFront();
                    frmBrcx.Show();
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
			if(IsSsDept()==false)
			{
				return null;
			}
			if(_functionName=="")
			{
				throw new Exception("��������������Ϊ�գ�");
			}
			frmBrcx frmBrcx=null;
			switch(_functionName)
			{
				case "Fun_Ts_ss_Brcx" :
					if(_communicateValue!=null)
					{						
						frmBrcx=new frmBrcx(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmBrcx=new frmBrcx(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmBrcx.MdiParent = _mdiParent;
					}
//					frmSsapcx.WindowState=FormWindowState.Maximized;
//					frmSsapcx.BringToFront();
					frmBrcx.Show();
					break;
                case "Fun_Ts_tszl_brcx":
                    if (_communicateValue != null)
                    {
                        frmBrcx = new frmBrcx(_currentUser.UserID, _currentDept.DeptId, _chineseName, _communicateValue);
                    }
                    else
                        frmBrcx = new frmBrcx(_currentUser.UserID, _currentDept.DeptId, _chineseName);

                    if (_mdiParent != null)
                    {
                        frmBrcx.MdiParent = _mdiParent;
                    }
                    //					frmSsapcx.WindowState=FormWindowState.Maximized;
                    //					frmSsapcx.BringToFront();
                    frmBrcx.Show();
                    break;
				default :
					throw new Exception("�����������ƴ���");
			}
			return frmBrcx;
		}
		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo ;//=new ObjectInfo[2];
			objectInfo.Name="Ts_ss_brcx";
			objectInfo.Text="�������˲�ѯ";
			objectInfo.Remark="�������˲�ѯ";
            //objectInfo[1].Name = "Ts_tszl_brcx";
            //objectInfo[1].Text = "���ⲡ�˲�ѯ";
            //objectInfo[1].Remark = "���ⲡ�˲�ѯ";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[2];
			objectInfos[0].Name="Fun_Ts_ss_brcx";
			objectInfos[0].Text="�������˲�ѯ";
			objectInfos[0].Remark="�������˲�ѯ";
            objectInfos[1].Name = "Fun_Ts_tszl_brcx";
            objectInfos[1].Text = "�������Ʋ��˲�ѯ";
            objectInfos[1].Remark = "�������Ʋ��˲�ѯ";
			
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
