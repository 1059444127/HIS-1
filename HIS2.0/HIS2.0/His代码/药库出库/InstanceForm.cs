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

namespace ts_yk_ck				//���޸�ΪԼ���������ռ�
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
        public static string _functionName;
        public static string _chineseName;
        public static long _menuId;
        public static Form _mdiParent;
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
				case "Fun_ts_yk_ypck" :
                case "Fun_ts_yk_ypck_cx": //ҩƷ���ⵥ
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypck_qtly":
                case "Fun_ts_yk_ypck_qtly_cx": //������ҩ��
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypck_jzcfck": //���˴�����¼
                case "Fun_ts_yk_ypck_jzcfck_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypck_cfbl":   //���ﴦ����¼
                case "Fun_ts_yk_ypck_cfbl_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypck_wyylyd": //����ҩ��ҩ
                case "Fun_ts_yk_ypck_wyylyd_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
                case "Fun_ts_yk_ypck_dck":
                case "Fun_ts_yk_ypck_dck_cx"://ͬ���ⷿ������
                    Frmtitle = new Frmtitle(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
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
			objectInfo.Name="ts_yk_ck";						//��dll���ļ�����,�����������ռ䱣��һ��
			objectInfo.Text="ҩƷ����";								//����������,����Ϊ��
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
                case "Fun_ts_yk_ypck_cx":
                case "Fun_ts_yk_ypck_qtly_cx":
                case "Fun_ts_yk_ypck_jzcfck_cx":
                case "Fun_ts_yk_ypck_cfbl_cx":
                case "Fun_ts_yk_ypck_wyylyd_cx":
                case "Fun_ts_yk_ypck_dck_cx":
                    Frmypck Frmypck = new Frmypck((MenuTag)CommunicateValue[0], Convert.ToString(CommunicateValue[1]), _mdiParent, (DataTable)CommunicateValue[3],false);
                    if (_mdiParent != null)
                    {
                        Frmypck.MdiParent = _mdiParent;
                    }
                    Frmypck.FillDj(new Guid(Convert.ToString(CommunicateValue[2])), true);
                    Frmypck.Show();
                    Frmypck.FindRecord((int)CommunicateValue[4], 0);
                    return Frmypck;
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
			ObjectInfo[] objectInfos=new ObjectInfo[12];
			objectInfos[0].Name="Fun_ts_yk_ypck";
			objectInfos[0].Text="ҩƷ���ⵥ";
			objectInfos[0].Remark="";
            objectInfos[1].Name = "Fun_ts_yk_ypck_cx";
            objectInfos[1].Text = "ҩƷ���ⵥ(��ѯ)";
            objectInfos[1].Remark = "";
			objectInfos[2].Name="Fun_ts_yk_ypck_qtly";
			objectInfos[2].Text="������ҩ��";
			objectInfos[2].Remark="";
            objectInfos[3].Name = "Fun_ts_yk_ypck_qtly_cx";
            objectInfos[3].Text = "������ҩ��(��ѯ)";
            objectInfos[3].Remark = "";
			objectInfos[4].Name="Fun_ts_yk_ypck_jzcfck";
			objectInfos[4].Text="���ʴ�����¼";
			objectInfos[4].Remark="";
            objectInfos[5].Name = "Fun_ts_yk_ypck_jzcfck_cx";
            objectInfos[5].Text = "���ʴ�����¼(��ѯ)";
            objectInfos[5].Remark = "";
			objectInfos[6].Name="Fun_ts_yk_ypck_cfbl";
			objectInfos[6].Text="���ﴦ����¼";
			objectInfos[6].Remark="";
            objectInfos[7].Name = "Fun_ts_yk_ypck_cfbl_cx";
            objectInfos[7].Text = "���ﴦ����¼(��ѯ)";
            objectInfos[7].Remark = "";
			objectInfos[8].Name="Fun_ts_yk_ypck_wyylyd";
			objectInfos[8].Text="����ҩ��ҩ";
			objectInfos[8].Remark="";
            objectInfos[9].Name = "Fun_ts_yk_ypck_wyylyd_cx";
            objectInfos[9].Text = "����ҩ��ҩ(��ѯ)";
            objectInfos[9].Remark = "";

            objectInfos[10].Name = "Fun_ts_yk_ypck_dck";
            objectInfos[10].Text = "ͬ���ⷿ������";
            objectInfos[10].Remark = "";
            objectInfos[11].Name = "Fun_ts_yk_ypck_dck_cx";
            objectInfos[11].Text = "ͬ���ⷿ������(��ѯ)";
            objectInfos[11].Remark = "";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
