using System;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes
{
    /// <summary>
    /// ����Ա��
    /// </summary>
    public class User : Employee
    {
        private long _userID;
        private string _loginCode;
        private string _password;
        private bool _locked;
        private bool _isAdministrator;
        /// <summary>
        /// jianqg 2012-10�� emr-his������� ���� �Ƿ��ʵϰ��
        /// </summary>
        private bool _IsHouseman;
        /// <summary>
        /// jianqg 2012-10�� emr-his������� ���� ��������
        /// </summary>
        private string _PublicPwd;
        /// <summary>
        /// jianqg 2012-10�� emr-his������� ���� ʹ�ù��������½
        /// </summary>
        private bool _loginUsePublicPwd;
        private string _certificateCA;
        #region ����
        /// <summary>
        /// CA֤��
        /// </summary>
        public string CertificateCA
        {
            get
            {
                return _certificateCA;
            }
            set
            {
                _certificateCA = value;
            }
        }
        /// <summary>
        /// �û�ID
        /// </summary>
        public long UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }
        /// <summary>
        /// �û��ĵ�¼����
        /// </summary>
        public string LoginCode
        {
            get
            {
                return _loginCode;
            }
            set
            {
                _loginCode = value;
            }
        }
        /// <summary>
        /// ������������ԣ��õ���������ģ�
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
        }
        /// <summary>
        /// ��ʾ���û��Ƿ�����
        /// </summary>
        public bool Locked
        {
            get
            {
                return _locked;
            }
            set
            {
                _locked = value;
            }
        }
        /// <summary>
        /// �Ƿ�Ϊ�����û�
        /// </summary>
        public bool IsAdministrator
        {
            get
            {
                return _isAdministrator;
            }
        }
        /// <summary>
        /// �Ƿ��ʵϰҽ�� jianqg 2012-10�� emr-his������� ����
        /// </summary>
        public bool IsHouseman
        {
            get
            {
                return _IsHouseman;
            }
        }
        /// <summary>
        ///�õ��������룬������רΪʵϰҽ��ʹ�� jianqg 2012-10�� emr-his������� ����
        /// </summary>
        public string PulicPassword
        {
            get
            {
                return _PublicPwd;
            }
        }
        /// <summary>
        ///ʹ�ù��������½ jianqg 2012-10�� emr-his������� ����
        /// </summary>
        public bool LoginUsePublicPwd
        {
            get
            {
                return _loginUsePublicPwd;
            }
        }
        #endregion
        /// <summary>
        /// ����һ��Ա������
        /// </summary>
        public User()
        {
            _userID = -1;
            _loginCode = "";
            _password = "";
            _locked = false;
            _isAdministrator = false;
            // jianqg 2012-10�� emr-his������� ����
            _IsHouseman = false;
            _PublicPwd = "";
            _loginUsePublicPwd = false;
        }
        #region //jianqg ����Ҫ ��ע�� 2012-10��emr-his�������
        
        /// <summary>
        /// ����һ����Ա����
        /// </summary>
        /// <param name="userID">����ԱID</param>
        /// <param name="database">���ݿ���ʶ���</param>
        public User(int userID, RelationalDatabase database)
            : this()
        {
            this.Database = database;
            //GetUserInfo(userID);
            //jianqg 2012-10�� emr-his������� ���ù���up_GetUserInfo
            GetUserInfo("", userID.ToString());
        }
        /// <summary>
        /// ����һ����Ա����
        /// </summary>
        /// <param name="userID">����ԱID</param>
        /// <param name="database">���ݿ���ʶ���</param>
        public User(long userID, RelationalDatabase database)
            : this()
        {
            this.Database = database;
            //GetUserInfo(userID);
            //jianqg 2012-10�� emr-his������� ���ù���up_GetUserInfo
            GetUserInfo("", userID.ToString());
        }
        
        #endregion
        /// <summary>
        /// ����һ����Ա����
        /// </summary>
        /// <param name="loginCode">����Ա��¼��</param>
        /// <param name="database">���ݿ���ʶ���</param>
        public User(string loginCode, RelationalDatabase database)
            : this()
        {
            this.Database = database;
            //��ԭ �����û���Ϣ�Ĳ��� ������Ϊ����
            GetUserInfo(loginCode,"0");

        }
        /// <summary>
        ///jianqg 2012-10�� emr-his������� ���� ����userId
        /// </summary>
        /// <param name="loginCode"></param>
        /// <param name="userId"></param>
        private void GetUserInfo(string loginCode,string userId)
        {
            try
            {
                IDbCommand cmd = this.Database.GetCommand();
                //jianqg 2012-10�� emr-his������� ���ù���up_GetUserInfo��������UserCode��UserID��ԭ��ʹ��up_GetUserInfobyCode��ֻ��UserCode
                cmd.CommandText = "up_GetUserInfo";// "up_GetUserInfobyCode"; 
                cmd.CommandType = CommandType.StoredProcedure;
                ParameterEx[] paras = new ParameterEx[2];
                paras[0].Text = "@UserCode";
                loginCode=Convertor.IsNull(loginCode,"");
                paras[0].Value = loginCode.ToUpper();
                paras[1].Text = "@UserID";
                userId = Convertor.IsNumeric(userId) ? userId : "0";
                   
                paras[1].Value = userId;

                this.Database.SetParameters(cmd, paras);
                DataRow dataRow = this.Database.GetDataRow(cmd);

                if (dataRow != null)
                {
                    _userID = Convert.ToInt32(Convertor.IsNull(dataRow["userid"], "-1"));
                    _loginCode = Convertor.IsNull(dataRow["code"], "");
                    _password = Crypto.Instance().Decrypto(Convertor.IsNull(dataRow["password"], ""));
                    _locked = Convert.ToInt16(Convertor.IsNull(dataRow["locked_bit"], "0")) > 0 ? true : false;
                    _isAdministrator = Convert.ToInt16(Convertor.IsNull(dataRow["administrator_bit"], "0")) > 0 ? true : false;
                    //jianqg 2012-10�� emr-his������� ����
                    _IsHouseman = dataRow["H_id"].ToString().Length > 0 ? true : false;
                    _PublicPwd = Crypto.Instance().Decrypto(Convertor.IsNull(dataRow["public_pwd"], ""));
                    base.InitEmployee(Convert.ToInt32(Convertor.IsNull(dataRow["employee_id"], "-1")));
                }
                else
                {
                    throw new Exception("�û�����Ϊ" + loginCode.ToString() + "���û�������");
                }
                //��ȡ��Ӧ��CA֤��
                //try
                //{
                //    string sql = string.Format( "select Certificate from Pub_User_CA_Certificate where Employee_Id={0}" , EmployeeId );
                //    object obj = this.Database.GetDataResult( sql );
                //    _certificateCA = Convertor.IsNull( obj , "" );
                //}
                //catch
                //{
                //    _certificateCA = "";
                //}
            }
            catch (Exception err)
            {
                throw new Exception("User\\" + err.Message);
            }
        }

        #region //jianqg ����Ҫ ��ע�� 2012-10��emr-his�������
        /*
        /// <summary>
        /// ��ò���Ա��Ϣ
        /// </summary>
        /// <param name="userID">����ԱID</param>
        protected void GetUserInfo(long userID)
        {
            try
            {
                IDbCommand cmd = this.Database.GetCommand();
                cmd.CommandText = "up_GetUserInfobyUID";
                cmd.CommandType = CommandType.StoredProcedure;
                ParameterEx[] paras = new ParameterEx[1];
                paras[0].Text = "@UID";
                paras[0].Value = userID;
                this.Database.SetParameters(cmd, paras);
                DataRow dataRow = this.Database.GetDataRow(cmd);

                if (dataRow != null)
                {
                    _userID = userID;
                    _loginCode = Convertor.IsNull(dataRow["code"], "");
                    _password = Crypto.Instance().Decrypto(Convertor.IsNull(dataRow["password"], ""));
                    _locked = Convert.ToInt16(Convertor.IsNull(dataRow["locked_bit"], "0")) > 0 ? true : false;
                    _isAdministrator = Convert.ToInt16(Convertor.IsNull(dataRow["administrator_bit"], "0")) > 0 ? true : false;
                    base.InitEmployee(Convert.ToInt32(Convertor.IsNull(dataRow["employee_id"], "-1")));
                }
                else
                {
                    throw new Exception("�û�IDΪ" + userID.ToString() + "���û�������");
                }
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetUserInfo\\" + err.Message);
            }
        }
         */
        #endregion
        /// <summary>
        /// �˶������Ƿ������
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool CheckPassword(string pwd)
        {
            //return _password == pwd;
            //jianqg 2012-10�� emr-his������� �޸� 
            //���ӹ�������Ĵ�����ʵϰ�������������ƥ�� ��������

            _loginUsePublicPwd = false;
            if (_IsHouseman)
            {
                if (_PublicPwd == pwd)
                {
                    _loginUsePublicPwd = true;
                    return true;
                }
            }
            if (_password == pwd)
            {
                return true;
            }
            return false;
        }

        public bool CheckPassword( string pwd , bool IsCA )
        {
            if ( !IsCA )
            {
                return CheckPassword( pwd );
            }
            else
            {
                try
                {
                    string ca_user_id = "";//txtName.Text;
                    string ca_password = pwd;
                    //ʹ��CA��֤����
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile( Application.StartupPath + "\\ts_ca_Interface.dll" );
                    object obj = assembly.CreateInstance( "ts_ca_Interface.CAFactory" );
                    System.Reflection.MethodInfo mi = obj.GetType().GetMethod( "CreateCA" );
                    object objInstance = mi.Invoke( obj , null );
                    if ( objInstance != null )
                    {
                        mi = objInstance.GetType().GetInterface( "ts_ca_Interface.InterfaceCA" ).GetMethod( "VerifyLogin" , new Type[]{
                                typeof( string ) , typeof( string ) , typeof( string ).MakeByRefType() } );
                        try
                        {
                            string message = "";
                            object[] paramters = new object[] { ca_user_id , ca_password , message };
                            object objRet = mi.Invoke( objInstance , paramters );
                            if ( Convert.ToBoolean( objRet ) == false )
                            {
                                message = paramters[2].ToString();
                                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        catch ( Exception error )
                        {
                            throw error;
                        }
                    }
                    return false;
                }
                catch ( Exception error )
                {
                    throw error;
                }
            }
        }

        /// <summary>
        /// �û���¼
        /// </summary>
        /// <param name="ComputerName"></param>
        /// <param name="IPAddr"></param>
        /// <param name="MacAddr"></param>
        /// <param name="PortNum"></param>
        public void Login( string ComputerName , string IPAddr , string MacAddr , int PortNum )
        {
            string sql = "update pub_user set login_bit=1,login_time=getdate(),login_ip='{0}',login_mac='{1}',login_pcname='{2}',login_port={3} where id={4}";
            sql = string.Format( sql , IPAddr , MacAddr , ComputerName , PortNum , this._userID );
            this.Database.DoCommand( sql );
        }
        /// <summary>
        /// �˳���¼
        /// </summary>
        public void Loginout()
        {
            string sql = @"update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null ,login_port = 0
                            where id={0} ";
            sql = string.Format( sql , this.UserID );
            int ret = this.Database.DoCommand( sql );
        }
        /// <summary>
        /// ����û�����״̬
        /// </summary>
        /// <param name="database"></param>
        public static int ClearOnlineStatus( long UserId , int EmployeeId , string LoginCode , RelationalDatabase database )
        {
            string sql = @"update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null,login_port = 0 where 1=1";
            if ( UserId != 0 )
                sql += " and id=" + UserId.ToString();
            if ( EmployeeId != 0 )
                sql += " and employee_id=" + EmployeeId.ToString();
            if ( !string.IsNullOrEmpty( LoginCode ) )
                sql += " and code = '" + LoginCode + "'";

            int ret = database.DoCommand( sql );
            return ret;
        }

        /// <summary>
        /// �����޸�
        /// </summary>
        /// <param name="oldPWD">ԭ������</param>
        /// <param name="newPWD">������</param>
        public bool ChangePassword(string oldPWD, string newPWD)
        {
            if (oldPWD != _password)
            {
                throw new Exception("User\\ChangePassword\\ԭʼ�����������");
            }

            //�����Ժ������־ Modify By Tany 2010-01-21
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

            this.Database.BeginTransaction();
            try
            {
                string sql = "update pub_user set password='" + Crypto.Instance().Encrypto(newPWD) + "' where id=" + _userID;
                if (this.Database.DoCommand(sql) <= 0)
                {
                    throw new Exception("�����޸�ʧ�ܣ�");
                }

                //�����Ժ���ݴ������Ȳ��������־ Modify By Tany 2010-01-21
                string cznr = "�޸��û�����:��" + _loginCode + "��";
                ts.Save_log(ts_HospData_Share.czlx.jc_�û��޸�, cznr, "pub_user", "id", _userID.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, -999, "", out log_djid, this.Database);

                this.Database.CommitTransaction();
            }
            catch (Exception err)
            {
                this.Database.RollbackTransaction();
                throw new Exception("User\\ChangePassword\\" + err.Message);
            }

            try
            {
                //�鿴�����Ͳ����Ƿ���������ִ�� Modify By Tany 2010-01-21
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�û��޸�, this.Database);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                {
                    //����ִ�иò��� Modify By Tany 2010-01-21
                    ts.Pexec_log(log_djid, this.Database, out errtext);
                }
                if (errtext != "")
                {
                    throw new Exception(errtext);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("��������" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Retrieve();
            return true;
        }
        /// <summary>
        /// ��ȡ�û�����ʹ�õ�ϵͳ
        /// </summary>
        /// <returns></returns>
        public DataTable GetSystemInfo()
        {
            try
            {
                ParameterEx[] paras = new ParameterEx[3];
                paras[0].Text = "@UserCode";
                paras[0].Value = this._loginCode;
                paras[1].Text = "@UserID";
                paras[1].Value = this._userID;
                paras[2].Text = "@AdminFlag";
                if (_isAdministrator)		//�����ϵͳ����Ա����Բ���ȫ��ϵͳ
                {
                    paras[2].Value = 1;
                }
                else
                {
                    paras[2].Value = 0;
                }
                IDbCommand cmd = this.Database.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_GetSystemOfUser";
                this.Database.SetParameters(cmd, paras);
                return this.Database.GetDataTable(cmd);
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetSystemInfo\\" + err.Message);
            }
        }
        /// <summary>
        /// ��ȡ�û�����ʹ�õ�ģ��
        /// </summary>
        /// <returns></returns>
        public DataTable GetModuleInfo()
        {
            try
            {
                string sql = "";
                if (_isAdministrator)		//�����ϵͳ����Ա����Բ���ȫ��ģ��
                {
                    sql = "select id as module_id,name as module_name,module_image,system_id from pub_module where delete_bit=0 order by sort_id";
                }
                else
                {
                    sql = @"select a.id as module_id,a.name as module_name,a.module_image,a.system_id
							from pub_module as a
							inner join 
							(select distinct module_id
								from pub_module_menu as b
								inner join pub_group_access as c
								on b.id=c.module_menu_id
								inner join pub_group_user as d
								on c.group_id=d.group_id
								where d.user_id=" + _userID + @" and b.delete_bit=0 and c.delete_bit=0 and d.delete_bit=0
							) as f
							on a.id=f.module_id
							where a.delete_bit=0
							order by a.sort_id";
                }
                return this.Database.GetDataTable(sql);
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetModuleInfo\\" + err.Message);
            }
        }
        /// <summary>
        /// ��ȡ�û��Ĳ˵�ʹ��Ȩ��
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserRight()
        {
            try
            {
                string sql = "";
                if (_isAdministrator)		//�����ϵͳ����Ա����Բ���ȫ���˵�
                {
                    sql = @"select a.id as menu_id,a.name as menu_name,a.dll_name,a.function_name,a.icon,b.module_id,b.parent_id
							from pub_menu as a
							inner join pub_module_menu as b
							on a.id=b.menu_id
							where a.delete_bit=0 and b.delete_bit=0
							order by b.module_id,b.sort_id";
                }
                else
                {
                    sql = @"select a.id as menu_id,a.name as menu_name,a.dll_name,a.function_name,a.icon,b.module_id,b.parent_id
							from pub_menu as a
							inner join pub_module_menu as b
							on a.id=b.menu_id
							inner join pub_group_access as c
							on b.id=c.module_menu_id
							inner join pub_group_user as d
							on c.group_id=d.group_id
							where d.user_id=" + _userID + @" and a.delete_bit=0 and b.delete_bit=0 and c.delete_bit=0 and d.delete_bit=0
							order by b.module_id,b.sort_id";
                }
                return this.Database.GetDataTable(sql);
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetUserRight\\" + err.Message);
            }
        }
        /// <summary>
        /// ȡ�øò���Ա�Ľ�ɫ����
        /// </summary>
        /// <returns></returns>
        public override DataTable GetEmpRoleDept()
        {
            try
            {
                if (_isAdministrator)
                {
                    string sql = @"select dept_id,NAME AS dept_name,py_code,wb_code,d_code,0 as default_bit 
							from JC_DEPT_PROPERTY where scbz=0 ";
                    return this.Database.GetDataTable(sql);
                }
                else
                {
                    return base.GetEmpRoleDept();
                }
            }
            catch (Exception err)
            {
                throw new Exception("User\\GetEmpRoleDept\\" + err.Message);
            }

        }

        #region �ӿ�IStdObject��Ա
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            return false;
        }
        /// <summary>
        /// ˢ����Ϣ
        /// </summary>
        /// <returns></returns>
        public override bool Retrieve()
        {
            //GetUserInfo(_userID);
             //base.Retrieve();
            //jianqg 2012-10�� emr-his������� �޸� ͬһһ��ȡ�û���Ϣ ʹ��_loginCode ��ԭ�д���ע�� ��ֻ����true

            return true;
        }
        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <returns></returns>
        public override bool Delete()
        {
            return false;
        }
        #endregion


        
    }
}