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
namespace ts_yf_mzfy			//���޸�ΪԼ���������ռ�
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
			//Frmmzfy Frmmzfy = null;					//����Ҫ���õĴ�����
			switch(_functionName)
            {
                case "Fun_ts_yf_mzfy":
                case "Fun_ts_yf_mzfy_ZCY":
                case "Fun_ts_yf_mzfy_YFFY":
				case "Fun_ts_yf_mzfy_eyf" :
//					Frmmzfy=new Frmmzfy(_menuTag,_chineseName,_mdiParent);
//					Frmmzfy.MdiParent=_mdiParent;
//					Frmmzfy.Show();

                    //Frmcffy Frmcffy = new Frmcffy(_menuTag, _chineseName, _mdiParent);
                    //Frmcffy.MdiParent = _mdiParent;
                    //Frmcffy.Show();

                    YpConfig s = new YpConfig(TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId, InstanceForm.BDatabase);
                    string add = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();


                    DataTable tb = MZYF.Get_fyck(add, "", InstanceForm.BDatabase);
                    if (tb.Rows.Count == 0)
                    {
                        if (s.��ҩģʽ == true)
                        {
                            Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
                            f.ShowDialog();
                            return;
                        }
                    }

                    if (tb.Rows.Count > 0)
                    {
                        if (tb.Rows[0]["bscbz"].ToString() == "1")
                        {
                            MessageBox.Show("�ô����ѱ�ͣ��,����ʹ����������������", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            if (s.��ҩģʽ == true)
                            {
                                Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
                                f.ShowDialog();
                                return;
                            }
                        }
                    }

                    string fyckh = "";
                    string fyckmc = "";

                    if (tb.Rows.Count!=0) fyckh=tb.Rows[0]["CODE"].ToString().Trim();
                    if (tb.Rows.Count != 0) fyckmc = tb.Rows[0]["name"].ToString().Trim();
                    Frmcffy Frmcffy = new Frmcffy(_menuTag, _chineseName, _mdiParent);
                    Frmcffy._Fyckh = fyckh.Trim();
                    Frmcffy._Fyckmc = fyckmc;
                    MZYF.Update_fyck(add, Frmcffy._Fyckh, 1, InstanceForm.BDatabase);
                    if (_mdiParent != null)
                    {
                        Frmcffy.MdiParent = _mdiParent;
                    }
                    Frmcffy.Show();



                    break;
                case "Fun_ts_yf_SetFyckUse":
                    FrmSetFyckUse frm = new FrmSetFyckUse(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.Show();
                    break;
				default :
					throw new Exception("��������������");
			}
		
		}
		/// <summary>
		/// ��ø�Dll����Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="ts_yf_mzfy";
			objectInfo.Text="���ﴦ����ҩ";
			objectInfo.Remark="���ﴦ����ҩ";
			return objectInfo;
		}
		/// <summary>
		/// ��ø�Dll��������������Ϣ
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[5];
			objectInfos[0].Name="Fun_ts_yf_mzfy";
			objectInfos[0].Text="���ﴦ����ҩ";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yf_mzfy_eyf";
			objectInfos[1].Text="�����ҩ����ҩ";
			objectInfos[1].Remark="";

            objectInfos[2].Name = "Fun_ts_yf_mzfy_ZCY";
            objectInfos[2].Text = "���ﴦ����ҩ����á�";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_yf_mzfy_YFFY";
            objectInfos[3].Text = "���ﴦ����ҩ��ҩ����";
            objectInfos[3].Remark = "";

            objectInfos[4].Name = "Fun_ts_yf_SetFyckUse";
            objectInfos[4].Text = "���÷�ҩ����";
            objectInfos[4].Remark = "";

			return objectInfos;
		}
		#endregion
		
		#endregion

        internal static void DebugView(DataTable table)
        {
            return;

            Form f = new Form();
            DataGrid grd = new DataGrid();
            grd.DataSource = table;
            grd.Dock = DockStyle.Fill;
            f.Controls.Add(grd);
            f.ShowDialog();
        }
	}
}
