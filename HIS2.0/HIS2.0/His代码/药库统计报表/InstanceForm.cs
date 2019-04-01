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
namespace ts_yk_tjbb				//���޸�ΪԼ���������ռ�
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
				case "Fun_ts_yk_tjbb_xspm" ://��������
					Frmxspm Frmxspm=new Frmxspm(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmxspm.MdiParent = _mdiParent;
					}
					Frmxspm.Show();
					break;
				case "Fun_ts_yk_tjbb_jhpm" ://��������
					Frmjhpm Frmjhpm=new Frmjhpm(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmjhpm.MdiParent = _mdiParent;
					}
					Frmjhpm.Show();
					break;
				case "Fun_ts_yk_tjbb_rkqk" :
					Frmdjqktj Frmdjqktj=new Frmdjqktj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmdjqktj.MdiParent = _mdiParent;
					}
					Frmdjqktj.Show();
					break;
				case "Fun_ts_yk_tjbb_jxcqkb" :
					Frmjxcqkb Frmjxcqkb=new Frmjxcqkb(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmjxcqkb.MdiParent = _mdiParent;
					}
					Frmjxcqkb.Show();
					break;
				case "Fun_ts_yk_tjbb_xqbj" :
					Frmxqbj Frmxqbj=new Frmxqbj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmxqbj.MdiParent = _mdiParent;
					}
					Frmxqbj.Show();
					break;
				case "Fun_ts_yk_tjbb_kcgdcbj" :
					Frmkcgdcbj Frmkcgdcbj=new Frmkcgdcbj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkcgdcbj.MdiParent = _mdiParent;
					}
					Frmkcgdcbj.Show();
					break;
				case "Fun_ts_yk_tjbb_yktkd" :
					Frmyktkd Frmyktkd=new Frmyktkd(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmyktkd.MdiParent = _mdiParent;
					}
					Frmyktkd.Show();
					break;
				case "Fun_ts_yk_tjbb_ylfltj_rk" : //ҩ�����ͳ��
				case "Fun_ts_yk_tjbb_ylfltj_ck" :
					Frmylfltj Frmylfltj=new Frmylfltj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmylfltj.MdiParent = _mdiParent;
					}
					Frmylfltj.Show();
					break;
				case "Fun_ts_yk_tjbb_rkhz" :
					Frmrkhztj Frmrkhztj=new Frmrkhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmrkhztj.MdiParent = _mdiParent;
					}
					Frmrkhztj.Show();
					break;
				case "Fun_ts_yk_tjbb_ckhz" :
					Frmckhztj Frmckhztj=new Frmckhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmckhztj.MdiParent = _mdiParent;
					}
					Frmckhztj.Show();
					break;
				case "Fun_ts_yk_tjbb_gzyp" :  //ҩƷ���Է���ͳ��
					Frmgzyptj Frmgzyptj=new Frmgzyptj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmgzyptj.MdiParent = _mdiParent;
					}
					Frmgzyptj.Show();
					break;
				case "Fun_ts_yk_tjbb_pdhz" :
					Frmpdhztj Frmpdhztj=new Frmpdhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmpdhztj.MdiParent = _mdiParent;
					}
					Frmpdhztj.Show();
					break;
				case "Fun_ts_yk_tjbb_tjhz" :
					Frmtjmx Frmtjmx=new Frmtjmx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtjmx.MdiParent = _mdiParent;
					}
					Frmtjmx.Show();
					break;
				case "Fun_ts_yk_tjbb_bshz" :
				case "Fun_ts_yk_tjbb_byhz" :
					Frmbsbyhztj Frmbsbyhztj=new Frmbsbyhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmbsbyhztj.MdiParent = _mdiParent;
					}
					Frmbsbyhztj.Show();
				break;
                case "Fun_ts_yk_tjbb_CG_RCQK":
                    FrmCG_RCQK FrmCG_RCQK = new FrmCG_RCQK(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmCG_RCQK.MdiParent = _mdiParent;
                    }
                    FrmCG_RCQK.Show();
                    break;
                case "Fun_ts_yk_tjbb_fkhztj_jy":
                    Frmrkhztj_jy frmrkhztj_jy = new Frmrkhztj_jy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmrkhztj_jy.MdiParent = _mdiParent;
                    }
                    frmrkhztj_jy.WindowState = FormWindowState.Maximized;
                    frmrkhztj_jy.Show();
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
			objectInfo.Name="ts_yk_tjbb";						//��dll���ļ�����,�����������ռ䱣��һ��
			objectInfo.Text="ͳ�Ʊ���";								//����������,����Ϊ��
			objectInfo.Remark="";							//������,����Ϊ��
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[18];
			objectInfos[0].Name="Fun_ts_yk_tjbb_xspm";
			objectInfos[0].Text="��������ͳ��";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yk_tjbb_jhpm";
			objectInfos[1].Text="��������ͳ��";
			objectInfos[1].Remark="";
			objectInfos[2].Name="Fun_ts_yk_tjbb_rkqk";
			objectInfos[2].Text="���ݻ��������";
			objectInfos[2].Remark="";
			objectInfos[3].Name="Fun_ts_yk_tjbb_jxcqkb";
			objectInfos[3].Text="�����������";
			objectInfos[3].Remark="";
			objectInfos[4].Name="Fun_ts_yk_tjbb_xqbj";
			objectInfos[4].Text="Ч�ڱ���";
			objectInfos[4].Remark="";
			objectInfos[5].Name="Fun_ts_yk_tjbb_kcgdcbj";
			objectInfos[5].Text="���ߵʹ�����";
			objectInfos[5].Remark="";
			objectInfos[6].Name="Fun_ts_yk_tjbb_yktkd";
			objectInfos[6].Text="ҩƷ�������ⵥ";
			objectInfos[6].Remark="";
			objectInfos[7].Name="Fun_ts_yk_tjbb_ylfltj_rk";
			objectInfos[7].Text="ҩ��ҩ�����ͳ��(���)";
			objectInfos[7].Remark="";
			objectInfos[8].Name="Fun_ts_yk_tjbb_ylfltj_ck";
			objectInfos[8].Text="ҩ��ҩ�����ͳ��(����)";
			objectInfos[8].Remark="";
			objectInfos[9].Name="Fun_ts_yk_tjbb_ckhz";
			objectInfos[9].Text="�������ͳ��";
			objectInfos[9].Remark="";
			objectInfos[10].Name="Fun_ts_yk_tjbb_rkhz";
			objectInfos[10].Text="������ͳ��";
			objectInfos[10].Remark="";
			objectInfos[11].Name="Fun_ts_yk_tjbb_gzyp";
			objectInfos[11].Text="����ҩƷͳ��";
			objectInfos[11].Remark="";
			objectInfos[12].Name="Fun_ts_yk_tjbb_pdhz";
			objectInfos[12].Text="�̵����ͳ��";
			objectInfos[12].Remark="";
			objectInfos[13].Name="Fun_ts_yk_tjbb_tjhz";
			objectInfos[13].Text="���ۻ���ͳ��";
			objectInfos[13].Remark="";
			objectInfos[14].Name="Fun_ts_yk_tjbb_bshz";
			objectInfos[14].Text="�������ͳ��";
			objectInfos[14].Remark="";
			objectInfos[15].Name="Fun_ts_yk_tjbb_byhz";
			objectInfos[15].Text="�������ͳ��";
			objectInfos[15].Remark="";
            objectInfos[16].Name = "Fun_ts_yk_tjbb_CG_RCQK";
            objectInfos[16].Text = "�ɹ�������ͳ��";
            objectInfos[16].Remark = "";
            objectInfos[17].Name = "Fun_ts_yk_tjbb_fkhztj_jy";
            objectInfos[17].Text = "����ҩ��������ͳ��";
            objectInfos[17].Remark = "";
			return objectInfos;

		}   
		#endregion
		
		#endregion
	}
}
