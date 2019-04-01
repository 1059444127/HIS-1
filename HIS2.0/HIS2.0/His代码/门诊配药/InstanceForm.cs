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
using YpClass;
using System.Data;
using System.Data.OleDb;

namespace ts_yf_mzpy				//���޸�ΪԼ���������ռ�
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
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            switch (_functionName)
            {
                case "Fun_ts_yf_mzpy":
                    string add = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
                    DataTable tb = MZPY.Get_pyck(add, "", InstanceForm.BDatabase);
                    if (tb.Rows.Count == 0)
                    {
                        Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
                        f.ShowDialog();
                    }
                    else
                    {
                        Frmmzpy Frmmzpy = null;
                        Frmmzpy = new Frmmzpy(_menuTag, _chineseName, _mdiParent);
                        Frmmzpy._Pyckh = tb.Rows[0]["CODE"].ToString().Trim();
                        MZPY.Update_pyck(add, Frmmzpy._Pyckh, 1, InstanceForm.BDatabase);
                        if (_mdiParent != null)
                        {
                            Frmmzpy.MdiParent = _mdiParent;
                        }
                        Frmmzpy.Show();
                    }
                    break;
                case "Fun_ts_yf_cfdy":
                    Frmcfdy fm = new Frmcfdy();
                    
                    fm.MdiParent = _mdiParent;
                    fm.WindowState = FormWindowState.Maximized;
                    //fm.Dock = DockStyle.Fill;
                    fm.Show();
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
            objectInfo.Name = "ts_yf_mzpy";
            objectInfo.Text = "������ҩ";
            objectInfo.Remark = "";
            return objectInfo;
        }

		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[2];
            objectInfos[0].Name = "Fun_ts_yf_mzpy";
            objectInfos[0].Text = "������ҩ";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_yf_cfdy";
            objectInfos[1].Text = "������ӡ";
            objectInfos[1].Remark = "";
            return objectInfos;
        }
		#endregion
		
		#endregion
	}
}
