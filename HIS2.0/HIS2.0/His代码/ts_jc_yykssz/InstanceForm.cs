using System;
using System.Data;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_jc_yykssz
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
		
		public static  MenuTag _menuTag;
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
			//FrmDepartmentSet frm = null;
			FrmMain frm = null;
            FrmMain2 frm2 = null;
			switch(_functionName)
			{
				case "Fun_ts_jc_yykssz_xxk":	//����ά��������Ϣ��
                case "Fun_ts_jc_yykssz_rs_ksry":
                case "Fun_ts_jc_yykssz_yw_ry":
					frm =  new  FrmMain(_menuTag,_chineseName);
					if(_mdiParent!=null)
					{
						frm.MdiParent = _mdiParent;

					}
					frm.Show();
					break;
                case "Fun_ts_jc_yykssz_ryk":	//����ά��������Ա��
                case "Fun_ts_jc_yykssz_ryk_qx":

                    frm2 = new FrmMain2(_menuTag, _chineseName);
                    if (_mdiParent != null)
                    {
                        frm2.MdiParent = _mdiParent;

                    }
                    frm2.Show();
                    break;

                case "Fun_ts_jc_PersonTel":

                    FrmUrgentOrdMsg frmPerTel = new FrmUrgentOrdMsg();
                    if (_mdiParent != null)
                    {
                        frmPerTel.MdiParent = _mdiParent;

                    }
                    frmPerTel.Show();
                    frmPerTel.WindowState = FormWindowState.Maximized;
                    break;
			}
		}
		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
            objectInfo.Name = "ts_jc_yykssz";
			objectInfo.Text="ҽԺ��Ա_��Ϣ��������";
			objectInfo.Remark="";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new  ObjectInfo[6];
            objectInfos[0].Name = "Fun_ts_jc_yykssz_xxk";
			objectInfos[0].Text = "���Ҽ���Աά��(��Ϣ��)";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_jc_yykssz_ryk";
            objectInfos[1].Text = "��Աά��";//ҽԺ��Ա����
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_jc_yykssz_ryk_qx";
            objectInfos[2].Text = "��ԱȨ������";//
            objectInfos[2].Remark = "";

            objectInfos[3].Name = "Fun_ts_jc_yykssz_rs_ksry";
            objectInfos[3].Text = "������Ա����(����)";//jianqg ���ҿ�������/ά���������������ÿ��ҽ�ɫ������/,��Ա��������ά��������������ҽ������
            objectInfos[3].Remark = "";



            objectInfos[4].Name = "Fun_ts_jc_yykssz_yw_ry";
            objectInfos[4].Text = "ҽ����Ա���Թ���(ҽ��)";//jianqg ��Ա��������ά��������������ҽ������
            objectInfos[4].Remark = "";




            objectInfos[5].Name = "Fun_ts_jc_PersonTel";
            objectInfos[5].Text = "��Ա�绰����ά��";
            objectInfos[5].Remark = "";





			return objectInfos;
		}

		#endregion
		
		#endregion
	}
}
