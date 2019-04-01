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
namespace ts_yp_ypbl				//���޸�ΪԼ���������ռ�
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
                //case "Fun_ts_ypks_zy_khbl_info"://סԺ����ҩƷ���˱�������
                //case "Fun_ts_yp_mzys_khbl_info"://����ҽ��ҩƷ���˱�������
                //    JC_YPKHBL Frmypkhbl=new JC_YPKHBL(_menuTag,_chineseName,_mdiParent);
                //    if(_mdiParent!=null)
                //    {
                //        //Frmypkhbl.MdiParent = _mdiParent;
                //    }
                //    Frmypkhbl.WindowState = FormWindowState.Normal;
                //    Frmypkhbl.ShowDialog();
                   
                //    break;
                //case "Fun_ts_ypks_zy_khbl_AddBL"://���ӱ���ҩƷ���˻�������
                //    JC_UpdateYPBL frmUpdateYPBL = new JC_UpdateYPBL(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        //frmUpdateYPBL.MdiParent = _mdiParent;
                //    }
                //    frmUpdateYPBL.WindowState = FormWindowState.Normal;
                //    frmUpdateYPBL.ShowDialog();
                //   // frmUpdateYPBL.WindowState = FormWindowState.Maximized;
                //    break;
                //case "Fun_ts_ypks_mzys_khbl_Query_ys"://����ҽ��ҩƷ������ѯ(��ҽ��)
                //case "Fun_ts_ypks_mzys_khbl_Query_all"://����ҽ��ҩƷ������ѯ
                //case "Fun_ts_ypks_zyks_khbl_Query_ks"://סԺ����ҩƷ������ѯ(������)
                //case "Fun_ts_ypks_zyks_khbl_Query_all"://סԺ����ҩƷ������ѯ
                //    FrmYPKH_Rept frmypkh_rept = new FrmYPKH_Rept(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        frmypkh_rept.MdiParent = _mdiParent;
                //    }
                //    frmypkh_rept.WindowState = FormWindowState.Maximized;
                //    frmypkh_rept.Show();
                //    // frmUpdateYPBL.WindowState = FormWindowState.Maximized;
                //    break;
                case "Fun_ts_yp_ypbl_khblsz":
                    FrmMain FrmMain = new FrmMain(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmMain.MdiParent = _mdiParent;
                    }
                    FrmMain.WindowState = FormWindowState.Maximized;
                    FrmMain.Show();
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
			ObjectInfo[] objectInfos=new ObjectInfo[1];

            objectInfos[0].Name = "Fun_ts_yp_ypbl_khblsz";
            objectInfos[0].Text = "���˱�������";
            objectInfos[0].Remark = "";

            //objectInfos[0].Name = "Fun_ts_yp_mzys_khbl_info";
            //objectInfos[0].Text = "����ҽ��ҩƷ���˱�������";
            //objectInfos[0].Remark="";

            //objectInfos[1].Name = "Fun_ts_ypks_zy_khbl_info";
            //objectInfos[1].Text = "סԺ����ҩƷ���˱�������";
            //objectInfos[1].Remark="";

            //objectInfos[2].Name = "Fun_ts_ypks_zy_khbl_AddBL";
            //objectInfos[2].Text = "���ӱ���ҩƷ���˻�������";
            //objectInfos[2].Remark = "";

            //objectInfos[3].Name = "Fun_ts_ypks_mzys_khbl_Query_ys";
            //objectInfos[3].Text = "����ҽ��ҩƷ������ѯ(��ҽ��)";
            //objectInfos[3].Remark = "";

            //objectInfos[4].Name = "Fun_ts_ypks_mzys_khbl_Query_all";
            //objectInfos[4].Text = "����ҽ��ҩƷ������ѯ";
            //objectInfos[4].Remark = "";

            //objectInfos[5].Name = "Fun_ts_ypks_zyks_khbl_Query_ks";
            //objectInfos[5].Text = "סԺ����ҩƷ������ѯ(������)";
            //objectInfos[5].Remark = "";

            //objectInfos[6].Name = "Fun_ts_ypks_zyks_khbl_Query_all";
            //objectInfos[6].Text = "סԺ����ҩƷ������ѯ";
            //objectInfos[6].Remark = "";

            ////objectInfos[7].Name = "Fun_ts_yp_mzys_khbl_infoUpdate";
            ////objectInfos[7].Text = "����ҽ��ҩƷ���˱������޸ģ�";
            ////objectInfos[7].Remark = "";

            ////objectInfos[8].Name = "Fun_ts_ypks_zy_khbl_infoUpdate";
            ////objectInfos[8].Text = "סԺ����ҩƷ���˱������޸ģ�";
            ////objectInfos[8].Remark = "";
			
			return objectInfos;

		}   
		#endregion
		
		#endregion
	}
}
