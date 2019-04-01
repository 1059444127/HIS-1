using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_fyxx
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
			frmFYXX frmFyxx=null;
            FrmNcycf frmncycf = null;
            FrmncycfPgc frmpgc = null;
            FrmZfxmQd frmzfxm = null;
			switch(_functionName)
			{
				case "Fun_ts_zyhs_fyxx" :
					frmFyxx=new frmFYXX(_chineseName);
					if(_mdiParent!=null)
					{
						frmFyxx.MdiParent = _mdiParent;
					}
					frmFyxx.Show();
					break;
				case "Fun_ts_zyhs_fyxx_ssmz" :
					frmFyxx=new frmFYXX(_chineseName,true);
					if(_mdiParent!=null)
					{
						frmFyxx.MdiParent = _mdiParent;
					}
					frmFyxx.Show();
					break;
				case "Fun_ts_zyhs_fyxx_all" :
					frmFyxx=new frmFYXX(_chineseName,1);
					if(_mdiParent!=null)
					{
						frmFyxx.MdiParent = _mdiParent;
					}
					frmFyxx.Show();
					break;

                case "Fun_ts_zyhs_fyxx_Ncycf":
                    frmncycf = new FrmNcycf(); 
                    if (_mdiParent != null)
                    {
                        frmncycf.MdiParent = _mdiParent;
                    }
                    frmncycf.WindowState = FormWindowState.Maximized;
                    frmncycf.Show();
                    break;
                case"Fun_ts_zyhs_fyxx_Ncycf_pgc":
                    frmpgc = new FrmncycfPgc();
                    if (_mdiParent != null)
                    {
                        frmpgc.MdiParent = _mdiParent;
                    }
                    frmpgc.WindowState = FormWindowState.Maximized;
                    frmpgc.Show();
                    break;
                case "Fun_ts_zyhs_fyxx_Ybzfxm":
                    frmzfxm = new FrmZfxmQd();
                    if (_mdiParent != null)
                    {
                        frmzfxm.MdiParent = _mdiParent;
                    }
                    frmzfxm.WindowState = FormWindowState.Maximized;
                    frmzfxm.Show();
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
			objectInfo.Name="ts_zyhs_fyxx";
			objectInfo.Text="������Ϣ";
			objectInfo.Remark="���˷�����ϸ��Ϣ";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[6];
			objectInfos[0].Name="Fun_ts_zyhs_fyxx";
			objectInfos[0].Text="���˷��ò�ѯ";
			objectInfos[0].Remark="��ѯ���˷�����ϸ��Ϣ";
			objectInfos[1].Name="Fun_ts_zyhs_fyxx_ssmz";
			objectInfos[1].Text="���˷��ò�ѯ(��������)";
			objectInfos[1].Remark="��ѯ���˷�����ϸ��Ϣ";
			objectInfos[2].Name="Fun_ts_zyhs_fyxx_all";
			objectInfos[2].Text="���˷��ò�ѯ(���в���)";
			objectInfos[2].Remark="��ѯ���˷�����ϸ��Ϣ";

            objectInfos[3].Name = "Fun_ts_zyhs_fyxx_Ncycf";
            objectInfos[3].Text = "ũ���в�������嵥(ƽ��)";
            objectInfos[3].Remark = "ũ���в�������嵥(ƽ��)";


            objectInfos[4].Name = "Fun_ts_zyhs_fyxx_Ncycf_pgc";
            objectInfos[4].Text = "ũ���в�������嵥(�ʹ���)";
            objectInfos[4].Remark = "ũ���в�������嵥(�ʹ���)";

            objectInfos[5].Name = "Fun_ts_zyhs_fyxx_Ybzfxm";
            objectInfos[5].Text = "ҽ���Է���Ŀͬ��ǩ�ֵ�";
            objectInfos[5].Remark = "ҽ���Է���Ŀͬ��ǩ�ֵ�";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
