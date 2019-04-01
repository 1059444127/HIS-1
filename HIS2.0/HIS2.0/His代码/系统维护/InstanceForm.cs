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

namespace ts_yp_xtwh				//���޸�ΪԼ���������ռ�
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
			switch(_functionName)
			{
				case "Fun_ts_yp_xtwh_sccj":
					Frmsccj Frmsccj=null;
					Frmsccj=new Frmsccj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmsccj.MdiParent = _mdiParent;
					}
					Frmsccj.Show();
					break;
				case "Fun_ts_yp_xtwh_ghdw":
					Frmghdw Frmghdw=null;
					Frmghdw=new Frmghdw(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmghdw.MdiParent = _mdiParent;
					}
					Frmghdw.Show();
					break;
				case "Fun_ts_yp_xtwh_ywy":
					Frmywy Frmywy=null;
					Frmywy=new Frmywy(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmywy.MdiParent = _mdiParent;
					}
					Frmywy.Show();
					break;
				case "Fun_ts_yp_xtwh_jx":
					Frmjx Frmjx=null;
					Frmjx=new Frmjx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmjx.MdiParent = _mdiParent;
					}
					Frmjx.Show();
					break;
				case "Fun_ts_yp_xtwh_ypdw":
					Frmypdw Frmypdw=null;
					Frmypdw=new Frmypdw(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmypdw.MdiParent = _mdiParent;
					}
					Frmypdw.Show();
					break;
				case "Fun_ts_yp_xtwh_gllx":
					Frmgllx Frmgllx=null;
					Frmgllx=new Frmgllx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmgllx.MdiParent = _mdiParent;
					}
					Frmgllx.Show();
					break;
				case "Fun_ts_yp_xtwh_bsyy":
					Frmbsyy Frmbsyy=null;
					Frmbsyy=new Frmbsyy(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmbsyy.MdiParent = _mdiParent;
					}
					Frmbsyy.Show();
					break;
				case "Fun_ts_yp_xtwh_byyy":
					Frmbyyy Frmbyyy=null;
					Frmbyyy=new Frmbyyy(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmbyyy.MdiParent = _mdiParent;
					}
					Frmbyyy.Show();
					break;
				case "Fun_ts_yp_xtwh_zbzt":
					Frmzbzt Frmzbzt=null;
					Frmzbzt=new Frmzbzt(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmzbzt.MdiParent = _mdiParent;
					}
					Frmzbzt.Show();
					break;
                case "Fun_ts_yp_xtwh_ylfl":
                    Frmylfl Frmylfl = null;
                    Frmylfl = new Frmylfl(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmylfl.MdiParent = _mdiParent;
                    }
                    Frmylfl.Show();
                    break;
                case "Fun_ts_yp_xtwh_lyks":
                    Frmaddlyks Frmaddlyks = null;
                    Frmaddlyks = new Frmaddlyks(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmaddlyks.MdiParent = _mdiParent;
                    }
                    Frmaddlyks.Show();
                    break;
                case "Fun_ts_yp_xtwh_addyjks_gx":
                    FrmAddyjks_zk FrmAddyjks_zk = null;
                    FrmAddyjks_zk = new FrmAddyjks_zk(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmAddyjks_zk.MdiParent = _mdiParent;
                    }
                    FrmAddyjks_zk.Show();
                    break;
                case "Fun_ts_yp_xtwh_config":
                case "Fun_ts_yp_xtwh_config_yf":
                    Frmconfig Frmconfig = null;
                    Frmconfig = new Frmconfig(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmconfig.MdiParent = _mdiParent;
                    }
                    Frmconfig.Show();
                    break;
				case "Fun_ts_yp_xtwh_kwsz":
                case "Fun_ts_yp_xtwh_kwsz_yf":
                    Frmhwsz Frmhwsz = null;
                    Frmhwsz = new Frmhwsz(_menuTag, _chineseName, _mdiParent);
					if(_mdiParent!=null)
					{
                        Frmhwsz.MdiParent = _mdiParent;
					}
                    Frmhwsz.Show();
					break;
				case "Fun_ts_yp_xtwh_addyjks":
                case "Fun_ts_yp_xtwh_addyjks_yf":
					FrmAddYjks FrmAddYjks=null;
					FrmAddYjks=new FrmAddYjks(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						FrmAddYjks.MdiParent = _mdiParent;
					}
					FrmAddYjks.Show();
					break;

				case "Fun_ts_yp_xtwh_kcsxx":
                case "Fun_ts_yp_xtwh_kcsxx_yf":
					Frmkcsxx Frmkcsxx=null;
					Frmkcsxx=new Frmkcsxx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkcsxx.MdiParent = _mdiParent;
					}
					Frmkcsxx.Show();
					break;
				case "Fun_ts_yp_ypcl":
					Frmypcl Frmypcl=null;
					Frmypcl=new Frmypcl(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmypcl.MdiParent = _mdiParent;
					}
					Frmypcl.Show();
					break;
                case "Fun_ts_yp_yptjmbwh":
                    Frmyptjmb Frmyptjmb = null;
                    Frmyptjmb = new Frmyptjmb(_menuTag, _chineseName, _mdiParent);
					if(_mdiParent!=null)
					{
                        Frmyptjmb.MdiParent = _mdiParent;
					}
                    Frmyptjmb.Show();
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
			objectInfo.Name="ts_yp_xtwh";
			objectInfo.Text="ϵͳά��";
			objectInfo.Remark="";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[22];
			objectInfos[0].Name="Fun_ts_yp_xtwh_sccj";
			objectInfos[0].Text="������������";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yp_xtwh_ghdw";
			objectInfos[1].Text="������λ����";
			objectInfos[1].Remark="";
			objectInfos[2].Name="Fun_ts_yp_xtwh_ywy";
			objectInfos[2].Text="ҵ��Ա����";
			objectInfos[2].Remark="";
			objectInfos[3].Name="Fun_ts_yp_xtwh_jx";
			objectInfos[3].Text="ҩƷ��������";
			objectInfos[3].Remark="";
			objectInfos[4].Name="Fun_ts_yp_xtwh_ypdw";
			objectInfos[4].Text="ҩƷ��λ����";
			objectInfos[4].Remark="";
			objectInfos[5].Name="Fun_ts_yp_xtwh_gllx";
			objectInfos[5].Text="ҩƷ������������";
			objectInfos[5].Remark="";
			objectInfos[6].Name="Fun_ts_yp_xtwh_bsyy";
			objectInfos[6].Text="����ԭ������";
			objectInfos[6].Remark="";
			objectInfos[7].Name="Fun_ts_yp_xtwh_byyy";
			objectInfos[7].Text="����ԭ������";
			objectInfos[7].Remark="";
			objectInfos[8].Name="Fun_ts_yp_xtwh_zbzt";
			objectInfos[8].Text="�б�״̬����";
			objectInfos[8].Remark="";
			objectInfos[9].Name="Fun_ts_yp_xtwh_ylfl";
			objectInfos[9].Text="ҩ���������";
			objectInfos[9].Remark="";
            objectInfos[10].Name = "Fun_ts_yp_xtwh_lyks";
            objectInfos[10].Text = "��ҩ��������";
            objectInfos[10].Remark = "";
            objectInfos[11].Name = "Fun_ts_yp_xtwh_addyjks_gx";
            objectInfos[11].Text = "����ҩ��Ͳֿ�����ϵ";
            objectInfos[11].Remark = "";

			objectInfos[12].Name="Fun_ts_yp_xtwh_config";
			objectInfos[12].Text="ҩ���������";
			objectInfos[12].Remark="";
            objectInfos[13].Name = "Fun_ts_yp_xtwh_config_yf";
            objectInfos[13].Text = "ҩ����������";
            objectInfos[13].Remark = "";


            objectInfos[14].Name = "Fun_ts_yp_xtwh_kwsz";
            objectInfos[14].Text = "ҩ���λ����";
            objectInfos[14].Remark = "";
            objectInfos[15].Name = "Fun_ts_yp_xtwh_kwsz_yf";
            objectInfos[15].Text = "ҩ����λ����";
            objectInfos[15].Remark = "";


			objectInfos[16].Name="Fun_ts_yp_xtwh_addyjks";
			objectInfos[16].Text="ҩ��ϵͳ��ʼ��";
			objectInfos[16].Remark="";
            objectInfos[17].Name = "Fun_ts_yp_xtwh_addyjks_yf";
            objectInfos[17].Text = "ҩ��ϵͳ��ʼ��";
            objectInfos[17].Remark = "";

			objectInfos[18].Name="Fun_ts_yp_xtwh_kcsxx";
			objectInfos[18].Text="ҩ��������������";
			objectInfos[18].Remark="";
            objectInfos[19].Name = "Fun_ts_yp_xtwh_kcsxx_yf";
            objectInfos[19].Text = "ҩ���������������";
            objectInfos[19].Remark = "";


			objectInfos[20].Name="Fun_ts_yp_ypcl";
			objectInfos[20].Text="ҩƷ����";
			objectInfos[20].Remark="";

            objectInfos[21].Name = "Fun_ts_yp_yptjmbwh";
            objectInfos[21].Text = "ҩƷͳ��ģ��ά��";
            objectInfos[21].Remark = "";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
