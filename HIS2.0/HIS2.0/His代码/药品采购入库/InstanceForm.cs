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
using System.Data;

namespace ts_yk_cgrk				//���޸�ΪԼ���������ռ�
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
				case "Fun_ts_yk_cgrk" :						//���Զ�����ú�����,����ĺ�����������GetFunctionsInfo�����ڵ�ObjectInfo.Nameһ��
                case "Fun_ts_yk_cgrk_cx":	
                case "Fun_ts_yk_cgrk_yf" :
                case "Fun_ts_yk_cgrk_yf_cx":
                case "Fun_ts_yk_cgrk_yf_h":
					Frmtitle = new Frmtitle(_menuTag,_chineseName,_mdiParent);			
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_cgrk_th" :						//���Զ�����ú�����,����ĺ�����������GetFunctionsInfo�����ڵ�ObjectInfo.Nameһ��
                case "Fun_ts_yk_cgrk_th_cx":
                case "Fun_ts_yk_cgrk_th_yf":
                case "Fun_ts_yk_cgrk_th_yf_cx":
					Frmtitle = new Frmtitle(_menuTag,_chineseName,_mdiParent);			
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
                case "Fun_ts_yk_cgrk_h":
                case "Fun_ts_yk_cgrk_th_h":
                    Frmtitle_h frm_h = new Frmtitle_h(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_h.MdiParent = _mdiParent;
                    }
                    frm_h.Show();
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
			objectInfo.Name="ts_yk_cgrk";						//��dll���ļ�����,�����������ռ䱣��һ��
			objectInfo.Text="ҩƷ�ɹ����";								//����������,����Ϊ��
			objectInfo.Remark="";							//������,����Ϊ��
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
            ObjectInfo[] objectInfos = new ObjectInfo[10];
            objectInfos[0].Name = "Fun_ts_yk_cgrk";
            objectInfos[0].Text = "ҩ��ҩƷ�ɹ����";
            objectInfos[0].Remark = "������ҩ��ɹ����";
            objectInfos[1].Name = "Fun_ts_yk_cgrk_cx";
            objectInfos[1].Text = "ҩ��ҩƷ�ɹ����(��ѯ)";
            objectInfos[1].Remark = "������ҩ��ɹ����(��ѯ)";

            objectInfos[2].Name = "Fun_ts_yk_cgrk_yf";
            objectInfos[2].Text = "ҩ��ҩƷ�ɹ����";
            objectInfos[2].Remark = "������ҩ���ɹ����";
            objectInfos[3].Name = "Fun_ts_yk_cgrk_yf_cx";
            objectInfos[3].Text = "ҩ��ҩƷ�ɹ����(��ѯ)";
            objectInfos[3].Remark = "������ҩ���ɹ����(��ѯ)";


            objectInfos[4].Name = "Fun_ts_yk_cgrk_th";
            objectInfos[4].Text = "ҩ��ҩƷ�˻���";
            objectInfos[4].Remark = "������ҩƷ�˹�����";
            objectInfos[5].Name = "Fun_ts_yk_cgrk_th_cx";
            objectInfos[5].Text = "ҩ��ҩƷ�˻���(��ѯ)";
            objectInfos[5].Remark = "������ҩƷ�˹�����(��ѯ)";

            objectInfos[6].Name = "Fun_ts_yk_cgrk_th_yf";
            objectInfos[6].Text = "ҩ��ҩƷ�˻���";
            objectInfos[6].Remark = "������ҩƷ�˹�����";
            objectInfos[7].Name = "Fun_ts_yk_cgrk_th_yf_cx";
            objectInfos[7].Text = "ҩ��ҩƷ�˻���(��ѯ)";
            objectInfos[7].Remark = "������ҩƷ�˹�����(��ѯ)";

            objectInfos[8].Name = "Fun_ts_yk_cgrk_h";
            objectInfos[8].Text = "ҩ��ҩƷ�ɹ����(������)";
            objectInfos[8].Remark = "";

            objectInfos[9].Name = "Fun_ts_yk_cgrk_th_h";
            objectInfos[9].Text = "ҩ��ҩƷ�˻���(����˻�)";
            objectInfos[9].Remark = "";

            return objectInfos;
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
                case "Fun_ts_yk_cgrk_cx":
                case "Fun_ts_yk_cgrk_th_cx":
                    Frmyprk Frmyprk = new Frmyprk((MenuTag)CommunicateValue[0], Convert.ToString(CommunicateValue[1]), _mdiParent, (DataTable)CommunicateValue[3]);
                    if (_mdiParent != null)
                    {
                        Frmyprk.MdiParent = _mdiParent;
                    }
                    Frmyprk.FillDj(new Guid(Convert.ToString(CommunicateValue[2])), true);
                    Frmyprk.Show();
                    Frmyprk.FindRecord((int)CommunicateValue[4], 0);
                    return Frmyprk;

                case "Fun_ts_yk_cgrk_h":   //ҩ��ɹ����(������) ���治���п���������˲���� 
                    Frmtitle_h frm_h = new Frmtitle_h(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_h.MdiParent = _mdiParent;
                    }
                    frm_h.Show();
                    break;
                case "Fun_ts_yk_cgrk_th_h":   //ҩ��ҩƷ�˻���(����˻�) 
                    Frmtitle_h frm_th_h = new Frmtitle_h(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_th_h.MdiParent = _mdiParent;
                    }
                    frm_th_h.Show();
                    break;

                default:
                    throw new Exception("�����������ƴ���");
            }
            return f;
        }
		#endregion
		
		#endregion
	}
}
