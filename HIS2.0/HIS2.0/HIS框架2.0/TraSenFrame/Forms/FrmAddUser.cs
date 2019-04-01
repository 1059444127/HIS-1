using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
namespace TrasenFrame.Forms
{
    /// <summary>
    /// ����û��Ի���
    /// </summary>
    public class FrmAddUser : System.Windows.Forms.Form
    {
        /// <summary>
        /// ��ǰ��Ա
        /// </summary>
        private TrasenFrame.Classes.Employee employee;

        /// <summary>
        /// ����������ݿ�����
        /// </summary>
        private RelationalDatabase db;//Add By Tany 2010-01-27
        /// <summary>
        /// ���������ӵĻ�������
        /// </summary>
        private int jgbm;//Add By Tany 2010-01-27

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox cklstGroup;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Button btnChangeCode;
        private System.Windows.Forms.Button btnDelPwd;
        private ComboBox cmbCode;
        private Button btNewCode;
        private Button btnDelLoginStat;
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="employeeId"></param>
        public FrmAddUser(int employeeId)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            //Modify By Tany 2010-01-27 ʹ�ñ������Լ�����������
            //������������Ļ������벢�����Ļ������벻���ڵ�ǰ���ӵĻ������룬������ʵ������������Ϊ�������ݿ�����
            if (FrmMdiMain.ZxJgbm != -1 && FrmMdiMain.ZxJgbm != FrmMdiMain.Jgbm)
            {
                db = WorkStaticFun.GetJgbmDb(FrmMdiMain.ZxJgbm);
                jgbm = FrmMdiMain.ZxJgbm;
            }
            else
            {
                db = FrmMdiMain.Database;
                jgbm = FrmMdiMain.Jgbm;
            }
            this.Text += "��" + jgbm + "��";
            employee = new TrasenFrame.Classes.Employee(employeeId, db);

            this.btnChangeCode.Visible = false;
            this.txtName.Text = employee.Name;
            this.txtName.Tag = employee;
            this.DialogResult = DialogResult.Cancel;
            LoadAllGroup();
            if (UserExists())
            {
                ShowUserInfo();
                this.btnChangeCode.Visible = true;
            }
            else
            {
                cmbCode.DropDownStyle = ComboBoxStyle.Simple;
                cmbCode.Text = GetDefaultCode();
            }

        }
        /// <summary>
        /// ����������
        /// </summary>
        private void LoadAllGroup()
        {
            DataTable table = db.GetDataTable("select * from pub_group where delete_bit=0");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TrasenFrame.Classes.CheckListBoxItem item = new TrasenFrame.Classes.CheckListBoxItem();
                item.ItemId = Convert.ToInt32(table.Rows[i]["id"]);
                item.ItemName = table.Rows[i]["name"].ToString();

                this.cklstGroup.Items.Add(item);
            }
        }
        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// ����û���
        /// </summary>
        /// <returns></returns>
        private bool CheckUserCode()
        {
            string sql = "select Id from pub_user where code='" + this.cmbCode.Text.Trim() + "'";
            if (UserExists())
                sql = "select Id from pub_user where code='" + this.cmbCode.Text.Trim() + "'";// and employee_id<>" + employee.EmployeeId;

            DataRow dr = db.GetDataRow(sql);
            if (dr != null)
            {
                sql = "select name from jc_employee_property where employee_id in (select employee_id from pub_user where code='" + this.cmbCode.Text.Trim() + "')";
                object obj = db.GetDataResult(sql);
                string val = "";
                if (obj != null || !Convert.IsDBNull(obj))
                {
                    val = obj.ToString().Trim();
                }

                MessageBox.Show("�û����Ѿ����ڣ�ʹ����[ " + val + " ]", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// �ж��û��Ƿ����
        /// </summary>
        /// <returns></returns>
        private bool UserExists()
        {
            string sql = "select employee_id from pub_user where employee_id=" + employee.EmployeeId;
            DataRow dr = db.GetDataRow(sql);
            return (dr == null ? false : true);
        }
        /// <summary>
        /// ��ʾ�û����е���
        /// </summary>
        private void ShowUserGroup()
        {
            for (int i = 0; i < this.cklstGroup.Items.Count; i++)
            {
                cklstGroup.SetItemChecked(i, false);
            }
            string sql = "select group_id from pub_group_user where user_id =" + cmbCode.SelectedValue.ToString();//in (select [id] from pub_user where employee_id=" + employee.EmployeeId + ")";
            DataTable table = db.GetDataTable(sql);
            for (int i = 0; i < this.cklstGroup.Items.Count; i++)
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (((TrasenFrame.Classes.CheckListBoxItem)cklstGroup.Items[i]).ItemId == Convert.ToInt32(table.Rows[j]["group_id"]))
                    {
                        cklstGroup.SetItemChecked(i, true);
                    }
                }

            }

        }
        private void ShowUserInfo()
        {
            string sql = "select * from pub_user where employee_id=" + employee.EmployeeId;
            DataTable dt = db.GetDataTable(sql);
            cmbCode.DisplayMember = "code";
            cmbCode.ValueMember = "id";
            cmbCode.DataSource = dt;
            cmbCode.SelectedIndex = 0;
            this.chkLock.Checked = Convert.ToBoolean(dt.Rows[0]["locked_bit"]);
            ShowUserGroup();
        }

        private string GetDefaultCode()
        {
            string sql = "select max(code) + 1 from (select cast(code as int) as code from pub_user where isnumeric(code)=1 ) a";
            object objCode = db.GetDataResult(sql);
            return objCode == null ? "1" : objCode.ToString();
        }

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cklstGroup = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            this.btnChangeCode = new System.Windows.Forms.Button();
            this.btnDelPwd = new System.Windows.Forms.Button();
            this.btNewCode = new System.Windows.Forms.Button();
            this.btnDelLoginStat = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "����:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "�û���:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 20);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(156, 26);
            this.txtName.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(20, 98);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(214, 16);
            this.lblInfo.TabIndex = 4;
            // 
            // chkLock
            // 
            this.chkLock.Location = new System.Drawing.Point(26, 390);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(104, 24);
            this.chkLock.TabIndex = 7;
            this.chkLock.Text = "�Ƿ�����";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(351, 466);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 26);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "ȷ��";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(422, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "ȡ��";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cklstGroup
            // 
            this.cklstGroup.Location = new System.Drawing.Point(20, 124);
            this.cklstGroup.Name = "cklstGroup";
            this.cklstGroup.Size = new System.Drawing.Size(442, 256);
            this.cklstGroup.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 452);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbCode);
            this.tabPage1.Controls.Add(this.btnChangeCode);
            this.tabPage1.Controls.Add(this.lblInfo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.cklstGroup);
            this.tabPage1.Controls.Add(this.chkLock);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(480, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "�û�����";
            // 
            // cmbCode
            // 
            this.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCode.FormattingEnabled = true;
            this.cmbCode.Location = new System.Drawing.Point(90, 62);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.Size = new System.Drawing.Size(156, 24);
            this.cmbCode.TabIndex = 9;
            this.cmbCode.SelectedIndexChanged += new System.EventHandler(this.cmbCode_SelectedIndexChanged);
            // 
            // btnChangeCode
            // 
            this.btnChangeCode.Location = new System.Drawing.Point(250, 62);
            this.btnChangeCode.Name = "btnChangeCode";
            this.btnChangeCode.Size = new System.Drawing.Size(100, 26);
            this.btnChangeCode.TabIndex = 8;
            this.btnChangeCode.Text = "�޸��û���";
            this.btnChangeCode.Click += new System.EventHandler(this.btnChangeCode_Click);
            // 
            // btnDelPwd
            // 
            this.btnDelPwd.Location = new System.Drawing.Point(136, 466);
            this.btnDelPwd.Name = "btnDelPwd";
            this.btnDelPwd.Size = new System.Drawing.Size(84, 26);
            this.btnDelPwd.TabIndex = 9;
            this.btnDelPwd.Text = "�������";
            this.btnDelPwd.Click += new System.EventHandler(this.btnDelPwd_Click);
            // 
            // btNewCode
            // 
            this.btNewCode.Location = new System.Drawing.Point(225, 466);
            this.btNewCode.Name = "btNewCode";
            this.btNewCode.Size = new System.Drawing.Size(121, 26);
            this.btNewCode.TabIndex = 10;
            this.btNewCode.Text = "�����û�����";
            this.btNewCode.Click += new System.EventHandler(this.btNewCode_Click);
            // 
            // btnDelLoginStat
            // 
            this.btnDelLoginStat.Location = new System.Drawing.Point(12, 466);
            this.btnDelLoginStat.Name = "btnDelLoginStat";
            this.btnDelLoginStat.Size = new System.Drawing.Size(119, 26);
            this.btnDelLoginStat.TabIndex = 11;
            this.btnDelLoginStat.Text = "�����½״̬";
            this.btnDelLoginStat.Click += new System.EventHandler(this.btnDelLoginStat_Click);
            // 
            // FrmAddUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(498, 503);
            this.Controls.Add(this.btnDelLoginStat);
            this.Controls.Add(this.btNewCode);
            this.Controls.Add(this.btnDelPwd);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "����û�";
            this.Load += new System.EventHandler(this.FrmAddUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (cmbCode.Text.Trim() == "")
            {
                MessageBox.Show("�û�������Ϊ�գ�", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //�����Ժ������־ Modify By Tany 2010-01-25
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;
            try
            {
                string sql = "";
                db.BeginTransaction();
                int userId = 0;
                if (UserExists() && cmbCode.SelectedValue != null && Convert.ToInt32(cmbCode.SelectedValue) != -1)
                {
                    //�����û�
                    sql = "update pub_user set locked_bit = " + (this.chkLock.Checked ? "1" : "0") + " where id=" + cmbCode.SelectedValue.ToString();//employee_id=" + employee.EmployeeId;
                    db.DoCommand(sql);
                    userId = Convert.ToInt32(this.cmbCode.SelectedValue);
                }
                else
                {
                    //����û�
                    sql = "insert into pub_user (employee_id,code,password) values (" + employee.EmployeeId + ",'" + cmbCode.Text.Trim() + "','')";
                    object obj;
                    db.InsertRecord(sql, out obj);
                    userId = Convert.ToInt32(obj);
                }
                //������
                sql = "delete from pub_group_user where user_id =" + userId;
                db.DoCommand(sql);
                for (int i = 0; i < this.cklstGroup.Items.Count; i++)
                {
                    if (this.cklstGroup.GetItemChecked(i))
                    {
                        int groupId = Convert.ToInt32(((TrasenFrame.Classes.CheckListBoxItem)cklstGroup.Items[i]).ItemId.ToString());

                        sql = "insert into pub_group_user (group_id,user_id,delete_bit) values (" + groupId + "," + userId + ",0)";
                        db.DoCommand(sql);
                    }
                }

                //�����Ժ���ݴ������Ȳ��������־ Modify By Tany 2010-01-25
                string cznr = "�޸��û���Ϣ:��" + txtName.Text.Trim() + "��";
                ts.Save_log(ts_HospData_Share.czlx.jc_�û��޸�, cznr, "pub_user", "id", userId.ToString(), jgbm, -999, "", out log_djid, db);

                db.CommitTransaction();

                try
                {
                    //�鿴�����Ͳ����Ƿ���������ִ�� Modify By Tany 2010-01-25
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�û��޸�, db);
                    if (ty.Bzx == 1 && log_djid != Guid.Empty)
                    {
                        //����ִ�иò��� Modify By Tany 2010-01-25
                        ts.Pexec_log(log_djid, db, out errtext);
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

                MessageBox.Show("����ɹ���");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                MessageBox.Show(err.Message);
            }
            //}
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCheck_Click(object sender, System.EventArgs e)
        {

        }

        private void FrmAddUser_Load(object sender, System.EventArgs e)
        {

        }

        private void btnChangeCode_Click(object sender, System.EventArgs e)
        {
            string newCode = "";
            string sql = "";

            newCode = DlgInputBoxStatic.InputBox("�������µ��û���", "�޸��û���", this.cmbCode.Text);
            if (DlgInputBoxStatic.dlgResult == DialogResult.Cancel) return;

            sql = "select * from pub_user where upper(code)='" + newCode.Trim().ToUpper() + "' and id <>" + this.cmbCode.SelectedValue.ToString();
            DataRow dr = db.GetDataRow(sql);
            while (dr != null)
            {
                object obj = db.GetDataResult("select name from jc_employee_property where employee_id in (select employee_id from pub_user where code='" + newCode + "')");

                newCode = DlgInputBoxStatic.InputBox("������û���[ " + newCode + " ]�Ѿ����ڣ�ʹ����[" + obj.ToString() + "]������������", "�޸��û���", this.cmbCode.Text);
                if (DlgInputBoxStatic.dlgResult == DialogResult.Cancel) return;
                sql = "select * from pub_user where upper(code)='" + newCode.Trim().ToUpper() + "' and id <>" + this.cmbCode.SelectedValue.ToString();
                dr = db.GetDataRow(sql);
            }

            //�����Ժ������־ Modify By Tany 2010-01-24
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

            db.BeginTransaction();
            try
            {
                //�����û�
                sql = "update pub_user set code ='" + newCode.Trim() + "' where id=" + cmbCode.SelectedValue.ToString();
                db.DoCommand(sql);

                //�����Ժ���ݴ������Ȳ��������־ Modify By Tany 2010-01-24
                string cznr = "�޸��û���:��" + txtName.Text.Trim() + "��";
                ts.Save_log(ts_HospData_Share.czlx.jc_�û��޸�, cznr, "pub_user", "id", cmbCode.SelectedValue.ToString(), jgbm, -999, "", out log_djid, db);

                db.CommitTransaction();
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                MessageBox.Show("�޸��û�������" + err.Message);
                return;
            }

            try
            {
                //�鿴�����Ͳ����Ƿ���������ִ�� Modify By Tany 2010-01-24
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�û��޸�, db);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                {
                    //����ִ�иò��� Modify By Tany 2010-01-24
                    ts.Pexec_log(log_djid, db, out errtext);
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

            MessageBox.Show("�û����޸ĳɹ���");

            ShowUserInfo();
        }

        private void btnDelPwd_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ȷ��Ҫ������û���������?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //�����Ժ������־ Modify By Tany 2010-01-24
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                Guid log_djid = Guid.Empty;

                db.BeginTransaction();
                try
                {
                    string sql = "update pub_user set [password]='' where id=" + cmbCode.SelectedValue.ToString() + " and employee_id=" + employee.EmployeeId + " and code = '" + this.cmbCode.Text + "'";
                    db.DoCommand(sql);

                    //�����Ժ���ݴ������Ȳ��������־ Modify By Tany 2010-01-24
                    string cznr = "����û�����:��" + txtName.Text.Trim() + "��";
                    ts.Save_log(ts_HospData_Share.czlx.jc_�û��޸�, cznr, "pub_user", "id", cmbCode.SelectedValue.ToString(), jgbm, -999, "", out log_djid, db);

                    db.CommitTransaction();
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    MessageBox.Show("����û����룺" + err.Message);
                    return;
                }

                try
                {
                    //�鿴�����Ͳ����Ƿ���������ִ�� Modify By Tany 2010-01-21
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�û��޸�, db);
                    if (ty.Bzx == 1 && log_djid != Guid.Empty)
                    {
                        //����ִ�иò��� Modify By Tany 2010-01-21
                        ts.Pexec_log(log_djid, db, out errtext);
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

                //д����־ Add By Tany 2012-02-02
                SystemLog systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "����û�����", FrmMdiMain.CurrentUser.Name + " ��ա�" + employee.Name + "(EmployeeId��" + employee.EmployeeId + ")������", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 0, "��������" + System.Environment.MachineName, (int)SystemModule.ϵͳ��������);
                systemLog.Save();
                systemLog = null;

                MessageBox.Show("�����Ѿ�������뼰ʱ֪ͨ���û��޸�����");
            }
        }

        private void btNewCode_Click(object sender, EventArgs e)
        {
            this.btnChangeCode.Visible = false;
            cmbCode.DataSource = null;
            cmbCode.DropDownStyle = ComboBoxStyle.Simple;
            cmbCode.Items.Add(GetDefaultCode());
            //cmbCode.SelectedValue = -1;
            cmbCode.Focus();
        }

        private void cmbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCode.SelectedValue != null && Convert.ToInt32(cmbCode.SelectedValue) != -1)
            {
                ShowUserGroup();
            }
        }

        private void btnDelLoginStat_Click(object sender, EventArgs e)
        {
            //�����¼״ֻ̬������ص�¼��¼����ʹ�ñ�������������
            if (MessageBox.Show("ȷ��Ҫ������û��ĵ�½״̬��?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //string sql = "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + cmbCode.SelectedValue.ToString() + " and employee_id=" + employee.EmployeeId + " and code = '" + this.cmbCode.Text + "'";
                //FrmMdiMain.Database.DoCommand(sql);
                int ret  = User.ClearOnlineStatus( Convert.ToInt64( cmbCode.SelectedValue ) , employee.EmployeeId , this.cmbCode.Text ,FrmMdiMain.Database );
                if ( ret != 0 )
                    MessageBox.Show( "��½״̬�Ѿ������" );
                else
                    MessageBox.Show( "���ʧ�ܣ�������" );
            }
        }
    }
}
