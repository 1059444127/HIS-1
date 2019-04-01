using System;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;

namespace Ts_zyys_jcsq
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
			FrmJCSQ frmjcsq=null;
            FrmJCBWSZ frmjcbwsz = null;
            FrmYGXX frmjybs = null;
            FrmJCSQBW frmjcsqbw = null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_jcsq" :
					frmjcsq=new FrmJCSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmjcsq.MdiParent=_mdiParent;
					}
					frmjcsq.BringToFront();
					frmjcsq.ShowDialog();
					break;
                case "Fun_Ts_zyys_jcsqbw":
                    frmjcsqbw = new FrmJCSQBW(_currentUser.UserID, _currentDept.DeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmjcsqbw.MdiParent = _mdiParent;
                    }
                    frmjcsqbw.BringToFront();
                    frmjcsqbw.ShowDialog();
                    break;
                //���Ӽ�鲿λ����
                //Modify By lwl 2011-09-13
                case "Fun_Ts_zyys_jcbwsz":
                    frmjcbwsz = new FrmJCBWSZ();
                    if (_mdiParent != null)
                    {
                        frmjcbwsz.MdiParent = _mdiParent;
                    }
                    frmjcbwsz.BringToFront();
                    frmjcbwsz.Show();
                    break;
                case "Fun_Ts_zyys_Jwbssz":
                    frmjybs = new FrmYGXX();
                    if (_mdiParent != null)
                    {
                        frmjybs.MdiParent = _mdiParent;
                    }
                    frmjybs.BringToFront();
                    frmjybs.Show();
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
            Form frm = new Form();
			FrmJCSQ frmjcsq=null;
            FrmJCBWSZ frmjcbwsz = null;
            FrmYGXX frmjybs = null;
            FrmJCSQBW frmjcsqbw = null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_jcsq" :
					if(_communicateValue!=null)
					{						
						frmjcsq=new FrmJCSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmjcsq=new FrmJCSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmjcsq.MdiParent = _mdiParent;
					}
                    frm = frmjcsq;
					break;
                case "Fun_Ts_zyys_jcsqbw":
                    if (_communicateValue != null)
                    {
                        frmjcsqbw = new FrmJCSQBW(_currentUser.UserID, _currentDept.DeptId, _chineseName, _communicateValue);
                    }
                    else
                        frmjcsqbw = new FrmJCSQBW(_currentUser.UserID, _currentDept.DeptId, _chineseName);

                    if (_mdiParent != null)
                    {
                        frmjcsqbw.MdiParent = _mdiParent;
                    }
                    frm = frmjcsqbw;
                    break;


                //���Ӽ�鲿λ����
                //Modify By lwl 2011-09-13
                case "Fun_Ts_zyys_jcbwsz":
                    frmjcbwsz = new FrmJCBWSZ();
                    if (_mdiParent != null)
                    {
                        frmjcbwsz.MdiParent = _mdiParent;
                    }
                   // ff = frmjcbwsz;
                    break;
                case "Fun_Ts_zyys_Jwbssz":
                    frmjybs = new FrmYGXX();
                    if (_mdiParent != null)
                    {
                        frmjybs.MdiParent = _mdiParent;
                    }
                    break;

				default :
					throw new Exception("�����������ƴ���");
			}
            return frm;
		}
		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="Ts_zyys_jcsq";
			objectInfo.Text="�������";
			objectInfo.Remark="�������";
			return objectInfo;
		}

        //public ObjectInfo GetDllInfo()
        //{
        //    ObjectInfo objectInfo;
        //    objectInfo.Name = "Ts_zyys_jcsqbw";
        //    objectInfo.Text = "�������(��λ)";
        //    objectInfo.Remark = "�������(��λ)";
        //    return objectInfo;
        //}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[4];
			objectInfos[0].Name="Fun_Ts_zyys_jcsq";
			objectInfos[0].Text="�������";
			objectInfos[0].Remark="�������";
            //���Ӽ�鲿λ����
            //Modify By lwl 2011-09-13
            objectInfos[1].Name = "Fun_Ts_zyys_jcbwsz";
            objectInfos[1].Text = "��鲿λ����";
            objectInfos[1].Remark = "��鲿λ����";
            //���Ӽ�鲿λ����
            //Modify By zouchihua 2011-09-13
            objectInfos[2].Name = "Fun_Ts_zyys_Jwbssz";
            objectInfos[2].Text = "��Ҫ��ʷ����";
            objectInfos[2].Remark = "��Ҫ��ʷ����";
            objectInfos[3].Name = "Fun_Ts_zyys_jcsqbw";
            objectInfos[3].Text = "�������(��λ)";
            objectInfos[3].Remark = "�������(��λ)";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
