/*
 * �����ռ�:Ĭ��Ϊ��������,�������dll�ļ�ͬ��
 * ��Ҫ�޸ĵĲ���Ϊ
 *		InstanceWorkForm������ʵ��
 *		GetDllInfo �����ڵ���Ϣ
 *		GetFunctionsInfo �����ڵ���Ϣ
 * ����μ������д��ŵ�ע��
*/
using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_yp_pd				//���޸�ΪԼ���������ռ�
{
	/// <summary>
	/// InstanceBForm ��ժҪ˵��
	/// ʵ����ҵ����
	/// </summary>
    public class InstanceForm : IDllInformation, IInnerCommunicate
	{
		//������̬����
		public static RelationalDatabase BDatabase;
		public static User BCurrentUser;
		public static Department BCurrentDept;

        public static MenuTag _menuTag;
		private string _functionName;
		private string _chineseName;
		private long _menuId;
		private Form _mdiParent;
        private object[] _communicateValue;
		/// <summary>
		/// ���캯��
		/// </summary>
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
                _communicateValue = value;
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
			Frmtitle Frmtitle = null;					//����Ҫ���õĴ�����
			switch(_functionName)
			{
				case "Fun_ts_yp_pd" :						
                case "Fun_ts_yp_pd_yf":
                case "Fun_ts_yp_pd_cx":
                case "Fun_ts_yp_pd_yf_cx":
					Frmtitle = new Frmtitle(_menuTag,_chineseName,_mdiParent);			
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
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
			objectInfo.Name="ts_yp_pd";						//��dll���ļ�����,�����������ռ䱣��һ��
			objectInfo.Text="ҩƷ�̵㵥";								//����������,����Ϊ��
			objectInfo.Remark="";							//������,����Ϊ��
			return objectInfo;
		}

        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            Form f = null;
            switch (_functionName)
            {
                case "Fun_ts_yp_pd_cx":
                case "Fun_ts_yp_pd_yf_cx":
                    Frmpdsh Frmpdsh = new Frmpdsh((MenuTag)CommunicateValue[0], Convert.ToString(CommunicateValue[1]), _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmpdsh.MdiParent = _mdiParent;
                    }
                    Frmpdsh.FillDj(new Guid(Convert.ToString(CommunicateValue[2])), true);
                    Frmpdsh.Show();
                    Frmpdsh.FindRecord((int)CommunicateValue[4], 0);
                    return Frmpdsh;
                default:
                    throw new Exception("�����������ƴ���");
            }
            return f;
        }

		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[4];
			objectInfos[0].Name="Fun_ts_yp_pd";							
			objectInfos[0].Text="ҩ���̵����";							
			objectInfos[0].Remark="";
            objectInfos[1].Name = "Fun_ts_yp_pd_cx";
            objectInfos[1].Text = "ҩ���̵����(��ѯ)";
            objectInfos[1].Remark = "";	
							
            objectInfos[2].Name = "Fun_ts_yp_pd_yf";				
            objectInfos[2].Text = "ҩ���̵����";					
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_yp_pd_yf_cx";
            objectInfos[3].Text = "ҩ���̵����(��ѯ)";
            objectInfos[3].Remark = "";			
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
