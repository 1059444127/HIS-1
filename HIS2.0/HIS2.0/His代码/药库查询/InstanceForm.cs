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

namespace ts_yk_cx				//���޸�ΪԼ���������ռ�
{
	/// <summary>
	/// InstanceBForm ��ժҪ˵��
	/// ʵ����ҵ����
	/// </summary>
	public class InstanceForm:IDllInformation
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
				//����Ҫ���õĴ�����
			switch(_functionName)
			{
				case "Fun_ts_yk_cx_flmxz" :
					Frmypmxz Frmypmxz=null;
					Frmypmxz=new Frmypmxz(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmypmxz.MdiParent = _mdiParent;
					}
					Frmypmxz.Show();
					break;
				case "Fun_ts_yk_cx_kccx" :
					Frmkccx Frmkccx=null;
					Frmkccx=new Frmkccx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkccx.MdiParent = _mdiParent;
					}
					Frmkccx.Show();
					break;
				case "Fun_ts_yk_cx_qykccx" :
					Frmqykccx Frmqykccx=null;
					Frmqykccx=new Frmqykccx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmqykccx.MdiParent = _mdiParent;
					}
					Frmqykccx.Show();
					break;
				case "Fun_ts_yk_cx_djcx" :
					Frmdjcx Frmdjcx=null;
					Frmdjcx=new Frmdjcx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmdjcx.MdiParent = _mdiParent;
					}
					Frmdjcx.Show();
					break;
				case "Fun_ts_yk_kcjygl" :
					Frmkcjygl Frmkcjygl=null;
					Frmkcjygl=new Frmkcjygl(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkcjygl.MdiParent = _mdiParent;
					}
					Frmkcjygl.Show();
					break;
                case "Fun_ts_yf_djhz_fkbl":
                    Frmdjhz_fkbl frmdjhz_fkbl = null;
                    frmdjhz_fkbl = new Frmdjhz_fkbl(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmdjhz_fkbl.MdiParent = _mdiParent;
                    }
                    frmdjhz_fkbl.Show();
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
			objectInfo.Name="ts_yk_cx";						//��dll���ļ�����,�����������ռ䱣��һ��
			objectInfo.Text="��ѯ";								//����������,����Ϊ��
			objectInfo.Remark="";							//������,����Ϊ��
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[6];
			objectInfos[0].Name="Fun_ts_yk_cx_flmxz";
			objectInfos[0].Text="������ϸ��";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yk_cx_kccx";
			objectInfos[1].Text="����ѯ";
			objectInfos[1].Remark="";
			objectInfos[2].Name="Fun_ts_yk_cx_qykccx";
			objectInfos[2].Text="ȫԺ����ѯ";
			objectInfos[2].Remark="";
			objectInfos[3].Name="Fun_ts_yk_cx_djcx";
			objectInfos[3].Text="���ݲ�ѯ";
			objectInfos[3].Remark="";
			objectInfos[4].Name="Fun_ts_yk_kcjygl";
			objectInfos[4].Text="�����ù���";
			objectInfos[4].Remark="";
            objectInfos[5].Remark = "";
            objectInfos[5].Name = "Fun_ts_yf_djhz_fkbl";
            objectInfos[5].Text = "ҩ���ۿۻ���(�������)";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
