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

namespace ts_yj_tjbb				//���޸�ΪԼ���������ռ�
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
        public static string _functionName;
        public static string _chineseName;
        public static long _menuId;
        public static Form _mdiParent;
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
                case "Fun_ts_yj_tjbb_zyhz":
                    Frmzysqhz Frmzysqhz = new Frmzysqhz(_menuTag, _chineseName, _mdiParent);			
					if(_mdiParent!=null)
					{
                        Frmzysqhz.MdiParent = _mdiParent;
					}
                    Frmzysqhz.Show();
					break;
                case "Fun_ts_yj_tjbb_zyhz_je":
                    Frmzysqhz_je Frmzysqhz_je = new Frmzysqhz_je(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzysqhz_je.MdiParent = _mdiParent;
                    }
                    Frmzysqhz_je.Show();
                    break;
                case "Fun_ts_yj_tjbb_zyhz_sqks":
                    Frmzysqhz_ks Frmzysqhz_ks = new Frmzysqhz_ks(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzysqhz_ks.MdiParent = _mdiParent;
                    }
                    Frmzysqhz_ks.Show();
                    break;
                case "Fun_ts_yj_tjbb_zyhz_sqys":
                    Frmzysqhz_ys Frmzysqhz_ys = new Frmzysqhz_ys(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzysqhz_ys.MdiParent = _mdiParent;
                    }
                    Frmzysqhz_ys.Show();
                    break;
                case "Fun_ts_yj_tjbb_QueryKss":
                    FrmQueryKss frmKss = new FrmQueryKss();
                    if (_mdiParent != null)
                    {
                        frmKss.MdiParent = _mdiParent;
                    }
                    frmKss.Show();
                    break;
                case "Fun_ts_yj_tjbb_QueryKss_CJ":
                    MedicineSYS.MForm frmMed = new MedicineSYS.MForm(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    if (_mdiParent != null)
                    {
                        frmMed.MdiParent = _mdiParent;
                    }
                    frmMed.Show();
                    break;
                case "Fun_ts_GCP_CJ":
                    //GCP.ClassIN c = new GCP.ClassIN();
                    GCP.FormGCP c = new GCP.FormGCP(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    if (_mdiParent != null)
                    {
                        c.MdiParent = _mdiParent;
                    }
                    c.Show();
                    //c.openfprm(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    break;

                case "Fun_ts_OperInstruction_CJ":
                    OperatingInstruction.OperInstruction d = new OperatingInstruction.OperInstruction(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    if (_mdiParent != null)
                    {
                        d.MdiParent = _mdiParent;
                    }
                    d.Show();
                    break;

                case "Fun_ts_OperatingInstruction_CJ":
                    OperatingInstruction.ybb_yjxt e = new OperatingInstruction.ybb_yjxt(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    if (_mdiParent != null)
                    {
                        e.MdiParent = _mdiParent;
                    }
                    e.Show();
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
            objectInfo.Name = "ts_yj_tjbb";						//��dll���ļ�����,�����������ռ䱣��һ��
            objectInfo.Text = "ͳ�Ʊ���";								//����������,����Ϊ��
			objectInfo.Remark="";							//������,����Ϊ��
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[9];
            objectInfos[0].Name = "Fun_ts_yj_tjbb_zyhz";							
			objectInfos[0].Text="סԺ�������ͳ��";
            objectInfos[0].Remark = "סԺ�������ͳ��";
            objectInfos[1].Name = "Fun_ts_yj_tjbb_zyhz_sqks";
            objectInfos[1].Text = "סԺ������һ���ͳ��";
            objectInfos[1].Remark = "סԺ������һ���ͳ��";
            objectInfos[2].Name = "Fun_ts_yj_tjbb_zyhz_sqys";
            objectInfos[2].Text = "סԺ����ҽ������ͳ��";
            objectInfos[2].Remark = "סԺ����ҽ������ͳ��";
            objectInfos[3].Name = "Fun_ts_yj_tjbb_zyhz_je";
            objectInfos[3].Text = "סԺ������ͳ��";
            objectInfos[3].Remark = "סԺ������ͳ��";

            objectInfos[4].Name = "Fun_ts_yj_tjbb_QueryKss";
            objectInfos[4].Text = "����ҩ��ͳ��";
            objectInfos[4].Remark = "����ҩ��ͳ��";

            objectInfos[5].Name = "Fun_ts_yj_tjbb_QueryKss_CJ";
            objectInfos[5].Text = "�ٴ�ҩѧҩ��ͳ��";
            objectInfos[5].Remark = "�ٴ�ҩѧҩ��ͳ��";

            objectInfos[6].Name = "Fun_ts_GCP_CJ";
            objectInfos[6].Text = "ҩ���ٴ��������";
            objectInfos[6].Remark = "ҩ���ٴ��������";

            objectInfos[7].Name = "Fun_ts_OperInstruction_CJ";
            objectInfos[7].Text = "ҩ���ٴ��������";
            objectInfos[7].Remark = "ҩ���ٴ��������";

            objectInfos[8].Name = "Fun_ts_OperatingInstruction_CJ";
            objectInfos[8].Text = "�찲��׼��ƶԤ��ƽ̨";
            objectInfos[8].Remark = "�찲��׼��ƶԤ��ƽ̨";	

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
