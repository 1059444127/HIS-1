using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_jc_wardbed
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
		public static TrasenFrame.Classes.User BCurrentUser;
		public static Department BCurrentDept;

        public static MenuTag _menuTag;
		private string _functionName;
		private string _chineseName;
        private long _menuId;
		private Form _mdiParent;
		private object[] _communicateValue;	
		public InstanceForm()
		{
			BDatabase =null;
			BCurrentUser=null;
			BCurrentDept=null;

			_functionName="";
			_chineseName="";
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
		public TrasenFrame.Classes.User CurrentUser
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
			FrmWardBed frm=null;
			switch(_functionName)
			{
				case "Fun_ts_jc_wardbed" :
                case "Fun_ts_jc_wardbed_view":
                    if (_functionName == "Fun_ts_jc_wardbed_view") frm = new FrmWardBed(_chineseName, true);	
                    else frm=new FrmWardBed(_chineseName,false);				
					//FrmBrjbxxdj.ShowDialog();
					if(_mdiParent!=null)
					{
						frm.MdiParent=_mdiParent;
					}
				
					frm.WindowState=FormWindowState.Maximized;
					frm.BringToFront();
					frm.Show();	
					break;
                case "Fun_ts_jc_wardbed_hs":
                    frm = new FrmWardBed( _chineseName ,1 );
                    //FrmBrjbxxdj.ShowDialog();
                    if ( _mdiParent != null )
                    {
                        frm.MdiParent = _mdiParent;
                    }

                    frm.WindowState = FormWindowState.Maximized;
                    frm.BringToFront( );
                    frm.Show( );
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
			return null;
		}

		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="ts_jc_wardbed";
			objectInfo.Text="������λ����";
			objectInfo.Remark="������λ����";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[3];
			objectInfos[0].Name="Fun_ts_jc_wardbed";
			objectInfos[0].Text="������λ����";
			objectInfos[0].Remark="������λ����";

            objectInfos[1].Name = "Fun_ts_jc_wardbed_hs";
            objectInfos[1].Text = "��������λ����";
            objectInfos[1].Remark = "��������λ����";

            //2012-5-7 jianqg ����
            objectInfos[2].Name = "Fun_ts_jc_wardbed_view";
            objectInfos[2].Text = "������λ�鿴";
            objectInfos[2].Remark = "������λ�鿴";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
