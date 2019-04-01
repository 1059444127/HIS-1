using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace TrasenMessage
{
    public partial class FrmMsgRelease : Form
    {
        private TrasenClasses.DatabaseAccess.RelationalDatabase dataBase;
        /// <summary>
        /// ע�⣺�˴���currentUserId����EmployeeId,��FrmMdiMain����
        /// </summary>
        private int currentUserId;

        private int currentSystemId;

        private int currentDeptId;

        private int step = 1; //��������

        private int operatorType = 0;// 0������ 1���޸�
        /// <summary>
        /// �Ƿ�����ɾ�����˵���Ϣ
        /// </summary>
        private bool ALLOW_DELETE_ALL = false; // add by wangzhi 2010-10-19
        /// <summary>
        /// �Ƿ�����༭���˵���Ϣ
        /// </summary>
        private bool ALLOW_EDIT_ALL = false;// add by wangzhi 2010-10-19
        /// <summary>
        /// �Ƿ����������з���������Ϣ
        /// </summary>
        private bool ALLOW_RELEASE_ALLSERVER = false;// add by wangzhi 2010-10-19

        private void LoadMessageTitle()
        {
            string sql = "select msgid,title,releasedate,dbo.fun_getempname(releaseor) as releaseor from pub_message where DeleteBit = 0 order by sort desc,releasedate desc ";//Modify By Tany 2012-04-17 �����ö�����
            if (dtpReleaseDate.Checked)
            {
                sql = "select msgid,title,releasedate,dbo.fun_getempname(releaseor) as releaseor from pub_message where DeleteBit = 0 and releasedate >='" + dtpReleaseDate.Value.ToString("yyyy-MM-dd") + " 00:00:00' and releasedate<='" + dtpReleaseDate.Value.ToString("yyyy-MM-dd") + " 23:59:59' order by sort desc,releasedate desc ";//Modify By Tany 2012-04-17 �����ö�����
            }
            DataTable tbMsg = dataBase.GetDataTable(sql);
            lvwTitleList.Items.Clear();
            for (int i = 0; i < tbMsg.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tbMsg.Rows[i]["title"].ToString().Trim();
                item.Tag = Convert.ToInt32(tbMsg.Rows[i]["msgid"]);
                item.SubItems.Add(Convert.ToDateTime(tbMsg.Rows[i]["releasedate"]).ToString("yyyy-MM-dd"));
                item.SubItems.Add(tbMsg.Rows[i]["releaseor"].ToString());
                lvwTitleList.Items.Add(item);
            }
        }

        private string GetRTFStringFromDB(int MsgId)
        {
            try
            {
                MemoryStream ms = null;
                string sql = "select Content from pub_message where msgid=" + MsgId;
                object objContent = dataBase.GetDataResult(sql);
                Byte[] rtf = (byte[])objContent;
                ms = new MemoryStream((byte[])objContent);
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                return encoding.GetString(rtf, 0, Convert.ToInt32(ms.Length));
            }
            catch (Exception err)
            {
                return "��ʾ��Ϣ����\n" + err.Message;
            }
        }

        private void ShowContent()
        {
        }

        private void LoadSystem()
        {
            string sql = "select system_id as id,name from pub_system where delete_bit=0 order by name";
            DataTable table = dataBase.GetDataTable(sql);
            AddReciveObjectToList(table);
        }

        private void LoadDepartment()
        {
            string sql = "select dept_id as  id ,name from jc_dept_property where deleted=0 and layer=3 order by name";
            DataTable table = dataBase.GetDataTable(sql);
            AddReciveObjectToList(table);
        }

        private void LoadEmployee()
        {
            string sql = "select employee_id as id,name from jc_employee_property where delete_bit=0 order by name";
            DataTable table = dataBase.GetDataTable(sql);
            AddReciveObjectToList(table);
        }

        private void AddReciveObjectToList(DataTable tb)
        {
            lvwSelectList.Items.Clear();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tb.Rows[i]["name"].ToString().Trim();
                item.Tag = Convert.ToInt32(tb.Rows[i]["id"]);
                lvwSelectList.Items.Add(item);
            }
        }

        private void CheckBoxChanged(object sender, EventArgs e)
        {
            if (rdSystem.Checked)
            {
                LoadSystem();
            }
            if (rdDept.Checked)
            {
                LoadDepartment();
            }
            if (rdEmployee.Checked)
            {
                LoadEmployee();
            }
            lvwReciveList.Items.Clear();
        }

        private Byte[] GetRTF()
        {
            string fileName = Application.StartupPath + "\\��Ϣ" + FrmMdiMain.CurrentUser.EmployeeId.ToString() + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".rtf";
            
            try
            {
               if(System.IO.File.Exists(fileName)) System.IO.File.Delete(fileName);
            }
            catch { }

            try
            {

                this.txtMsgEdit.SaveFile(fileName, RichTextBoxStreamType.RichText);

                System.IO.FileInfo finifo = new FileInfo(fileName);

            }
            catch { }
            //try
            //{
            //    if (System.IO.File.Exists(fileName)) System.IO.File.Delete(fileName);
            //}
            //catch { }

            System.IO.MemoryStream ms = new MemoryStream();
            this.txtMsgEdit.SaveFile(ms, RichTextBoxStreamType.RichText);
            int size = Convert.ToInt32(ms.Length);
            Byte[] rtf = new Byte[size];
            ms.Position = 0;
            ms.Read(rtf, 0, size);
            ms.Close();
            return rtf;
        }

        private bool SaveMessage()
        {
            try
            {
                string sql = "insert into pub_message(title,content,releasedate,invalidday,releaseor) values (@title,@content,getdate(),@invalidday,@releaseor);";
                sql += "set @msgId = scope_identity()";

                IDbCommand cmd = dataBase.GetCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                IDataParameter parameter;
                #region ������Ϣ����
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@title";
                parameter.Value = this.txtMsgTitle.Text;
                cmd.Parameters.Add(parameter);

                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@content";
                parameter.Value = GetRTF();
                cmd.Parameters.Add(parameter);

                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@invalidday";
                parameter.Value = Convert.ToInt32(txtDay.Text);
                cmd.Parameters.Add(parameter);

                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@releaseor";
                parameter.Value = currentUserId;
                cmd.Parameters.Add(parameter);

                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@msgId";
                parameter.Value = 0;
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                #endregion
                int ret = cmd.ExecuteNonQuery();
                if (ret == 0)
                {
                    MessageBox.Show("����֪ͨ����ʧ�ܣ�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    int newMsgId = Convert.ToInt32(((IDataParameter)cmd.Parameters["@msgId"]).Value);
                    //���淢������
                    int releaseType = 0;
                    if (rdDept.Checked)
                    {
                        releaseType = 1;
                    }
                    else if (rdEmployee.Checked)
                    {
                        releaseType = 2;
                    }
                    try
                    {
                        dataBase.BeginTransaction();

                        foreach (ListViewItem item in lvwReciveList.Items)
                        {
                            int reciver_id = Convert.ToInt32(item.Tag);
                            sql = "insert into pub_message_recivelist(msgid,reciver_type,reciver_id) values (" + newMsgId + "," + releaseType + "," + reciver_id + ")";
                            dataBase.DoCommand(sql);
                        }
                        dataBase.CommitTransaction();
                        return true;
                    }
                    catch
                    {
                        dataBase.RollbackTransaction();
                        MessageBox.Show("��Ϣ֪ͨ������ɵ��������ɹ���", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("����֪ͨ���ݷ�������\n" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool UpdateMessage()
        {
            try
            {
                //modify by wangzhi 2010-10-20
                //int msgId = Convert.ToInt32(lvwTitleList.SelectedItems[0].Tag);
                if (plEdit.Tag == null)
                {
                    MessageBox.Show("��ϢIDû�л�ȡ��,������");
                    return false;
                }
                int msgId = Convert.ToInt32(plEdit.Tag);
                //end modify

                string sql = "update pub_message set title=@title,content=@content,invalidday=@invalidday where msgid=@msgId";

                IDbCommand cmd = dataBase.GetCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                IDataParameter parameter;
                #region ������Ϣ����
                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@title";
                parameter.Value = this.txtMsgTitle.Text;
                cmd.Parameters.Add(parameter);

                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@content";
                parameter.Value = GetRTF();
                cmd.Parameters.Add(parameter);

                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@invalidday";
                parameter.Value = Convert.ToInt32(txtDay.Text);
                cmd.Parameters.Add(parameter);

                parameter = cmd.CreateParameter();
                parameter.ParameterName = "@msgId";
                parameter.Value = msgId;
                cmd.Parameters.Add(parameter);
                #endregion
                int ret = cmd.ExecuteNonQuery();

                if (ret == 0)
                {
                    MessageBox.Show("����֪ͨ����ʧ�ܣ�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    //���淢������
                    int releaseType = 0;
                    if (rdDept.Checked)
                    {
                        releaseType = 1;
                    }
                    else if (rdEmployee.Checked)
                    {
                        releaseType = 2;
                    }
                    try
                    {
                        dataBase.BeginTransaction();
                        sql = "delete from pub_message_recivelist where msgid=" + msgId;
                        dataBase.DoCommand(sql);
                        foreach (ListViewItem item in lvwReciveList.Items)
                        {

                            int reciver_id = Convert.ToInt32(item.Tag);
                            sql = "insert into pub_message_recivelist(msgid,reciver_type,reciver_id) values (" + msgId + "," + releaseType + "," + reciver_id + ")";
                            dataBase.DoCommand(sql);
                        }
                        dataBase.CommitTransaction();
                        return true;
                    }
                    catch
                    {
                        dataBase.RollbackTransaction();
                        MessageBox.Show("��Ϣ֪ͨ������ɵ��������ɹ���", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("����֪ͨ���ݷ�������\n" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public FrmMsgRelease()
        {
            InitializeComponent();
            plBrower.Dock = DockStyle.Fill;
            plEdit.Dock = DockStyle.Fill;
            plRecvieObject.Dock = DockStyle.Fill;
        }

        private void SetPlanVisable(int Step)
        {
            switch (Step)
            {
                case 1:
                    plBrower.Visible = true;
                    plEdit.Visible = false;
                    plRecvieObject.Visible = false;
                    break;
                case 2:
                    plBrower.Visible = false;
                    plEdit.Visible = true;
                    plRecvieObject.Visible = false;
                    break;
                case 3:
                    plBrower.Visible = false;
                    plEdit.Visible = false;
                    plRecvieObject.Visible = true;
                    break;
            }
        }

        private void FrmMsgRelease_Load(object sender, EventArgs e)
        {
            SetPlanVisable(1);
            btnRelease.Enabled = false;
            btnProvious.Enabled = false;
            btnNext.Enabled = false;

            TrasenClasses.GeneralClasses.FrameEnvironment fEvt = (TrasenClasses.GeneralClasses.FrameEnvironment)this.Tag;

            dataBase = fEvt.Database;
            currentDeptId = (int)fEvt.Department;
            currentSystemId = (int)fEvt.CSystem;
            currentUserId = (int)fEvt.User; //����������Employee_Id,��ֵλ���� FrmMdiMain.cs ��menuReleaseMsg_Click����

            LoadJgbm();

            LoadMessageTitle();

            // add by wangzhi 2010-10-19
            DataRow dr = dataBase.GetDataRow("select * from pub_message_releasor where employee_id=" + currentUserId);
            if (dr != null)
            {
                ALLOW_DELETE_ALL = Convert.IsDBNull(dr["allow_delete_all"]) ? false : (Convert.ToInt32(dr["allow_delete_all"]) == 1 ? true : false);
                ALLOW_EDIT_ALL = Convert.IsDBNull(dr["allow_edit_all"]) ? false : (Convert.ToInt32(dr["allow_edit_all"]) == 1 ? true : false);
                ALLOW_RELEASE_ALLSERVER = Convert.IsDBNull(dr["release_allserver"]) ? false : (Convert.ToInt32(dr["release_allserver"]) == 1 ? true : false);
            }

            if (ALLOW_RELEASE_ALLSERVER)
            {
                cmbJgbm.Enabled = true;
            }
            else
            {
                cmbJgbm.Enabled = false;
                cmbJgbm.SelectedValue = FrmMdiMain.Jgbm;
            }

            //end add
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (step == 3)
            {
                return;
            }
            if (step == 2)
            {
                if (txtMsgTitle.Text == "")
                {
                    MessageBox.Show("��Ϣ���ⲻ��Ϊ�գ�", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtMsgEdit.Text == "")
                {
                    MessageBox.Show("���ݲ���Ϊ�գ�", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            step++;
            SetPlanVisable(step);

            if (step == 3)
            {
                btnNext.Enabled = false;
                btnRelease.Enabled = true;
            }
            else
            {

                btnProvious.Enabled = true;
                btnNext.Enabled = true;
                btnRelease.Enabled = false;
            }

        }

        private void btnProvious_Click(object sender, EventArgs e)
        {
            if (step == 1)
            {
                return;
            }

            step--;
            SetPlanVisable(step);

            if (step == 1)
            {
                btnProvious.Enabled = false;
                btnNext.Enabled = false;
                btnRelease.Enabled = false;
            }
            else
            {
                btnProvious.Enabled = true;
                btnNext.Enabled = true;
                btnRelease.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "";
            string condiction = txtSearch.Text;

            if (rdSystem.Checked)
            {
                sql = "select system_id as id,name from pub_system where name like '" + condiction + "%' or py_code like '%" + condiction + "%'";
            }
            if (rdDept.Checked)
            {
                sql = "select dept_id as id,name from jc_dept_property where deleted=0 and layer=3 and name like '%" + condiction + "%' or py_code like '%" + condiction + "%'";
            }
            if (rdEmployee.Checked)
            {
                sql = "select employee_id as id,name from jc_employee_property where delete_bit=0 and name like '%" + condiction + "%' or py_code like '%" + condiction + "%'";
            }
            DataTable table = dataBase.GetDataTable(sql);
            AddReciveObjectToList(table);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwSelectList.SelectedItems)
            {
                bool add = true;
                foreach (ListViewItem _item in lvwReciveList.Items)
                {
                    if (Convert.ToInt32(item.Tag) == Convert.ToInt32(_item.Tag))
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    ListViewItem selItem = new ListViewItem();
                    selItem.Text = item.Text;
                    selItem.Tag = item.Tag;
                    lvwReciveList.Items.Add(selItem);
                }
            }
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            this.txtMsgEdit.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            this.txtMsgEdit.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            this.txtMsgEdit.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtMsgEdit.SelectionFont = dlg.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtMsgEdit.SelectionColor = dlg.Color;

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            operatorType = 0;
            txtMsgTitle.Text = "";
            txtDay.Text = "3";
            txtMsgEdit.Text = "";
            step = 2;
            SetPlanVisable(step);
            btnProvious.Enabled = true;
            btnNext.Enabled = true;
            btnRelease.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwTitleList.SelectedItems.Count == 0)
                return;

            operatorType = 1;
            int msgId = Convert.ToInt32(lvwTitleList.SelectedItems[0].Tag);
            //add by wangzhi 2010-10-19
            if (AllowOperateMessage(msgId, 1) == false)
            {
                MessageBox.Show("��û���޸ı����ѷ�������Ϣ��Ȩ�ޣ�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //end add

            string sql = "select * from pub_message where msgId=" + msgId;
            DataRow dr = dataBase.GetDataRow(sql);
            txtMsgTitle.Text = dr["title"].ToString().Trim();
            txtDay.Text = dr["invalidday"].ToString().Trim();
            txtMsgEdit.Rtf = GetRTFStringFromDB(Convert.ToInt32(dr["msgid"]));
            //��������
            sql = "select msgid,reciver_type from pub_message_recivelist where msgid=" + msgId + " group by msgid,reciver_type";
            DataRow drMsg = dataBase.GetDataRow(sql);
            if (drMsg != null)
            {

                switch (Convert.ToInt32(drMsg["reciver_type"]))
                {
                    case 0:
                        rdSystem.Checked = true;
                        sql = "select system_id as id,name  from pub_system where system_id in (select reciver_id from pub_message_recivelist where msgid=" + Convert.ToInt32(drMsg["msgid"]) + ")";
                        break;
                    case 1:
                        sql = "select dept_id as id,name  from jc_dept_property where dept_id in (select reciver_id from pub_message_recivelist where msgid=" + Convert.ToInt32(drMsg["msgid"]) + ")";
                        rdDept.Checked = true;
                        break;
                    case 2:
                        sql = "select employee_id as id,name  from jc_employee_property where employee_id in (select reciver_id from pub_message_recivelist where msgid=" + Convert.ToInt32(drMsg["msgid"]) + ")";
                        rdEmployee.Checked = true;
                        break;
                }

                DataTable tbReciveList = dataBase.GetDataTable(sql);
                lvwReciveList.Items.Clear();
                for (int i = 0; i < tbReciveList.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = tbReciveList.Rows[i]["name"].ToString().Trim();
                    item.Tag = Convert.ToInt32(tbReciveList.Rows[i]["id"]);
                    lvwReciveList.Items.Add(item);
                }
            }
            btnNext_Click(null, null);
            plEdit.Tag = msgId;
        }

        private void dtpReleaseDate_ValueChanged(object sender, EventArgs e)
        {
            LoadMessageTitle();
        }

        private void lvwTitleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMsgBrower.Rtf = "";
            if (lvwTitleList.SelectedItems.Count == 0)
                return;

            int msgId = Convert.ToInt32(lvwTitleList.SelectedItems[0].Tag);
            txtMsgBrower.Rtf = GetRTFStringFromDB(msgId);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (lvwReciveList.Items.Count == 0)
            {
                MessageBox.Show("û��ָ��֪ͨ��Ϣ�Ľ��ն���", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //add by wangzhi 2010-10-19
            if (ALLOW_RELEASE_ALLSERVER == false)
            {
                if (FrmMdiMain.Jgbm != Convert.ToInt32(cmbJgbm.SelectedValue))
                {
                    MessageBox.Show("��û�������з�����������Ϣ��Ȩ�ޣ�������ѡ�������", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //end add

            if (operatorType == 0)
            {
                //Modify By Tany 2010-08-23 ���ݻ�������ѭ����������
                string sql = "select * from jc_jgbm where jgbm=" + cmbJgbm.SelectedValue.ToString() + " or " + cmbJgbm.SelectedValue.ToString().Trim() + "=-1";
                DataTable tb = dataBase.GetDataTable(sql);
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dataBase = WorkStaticFun.GetJgbmDb(Convert.ToInt32(tb.Rows[i]["jgbm"]));

                    success = SaveMessage();

                    TrasenClasses.GeneralClasses.FrameEnvironment fEvt = (TrasenClasses.GeneralClasses.FrameEnvironment)this.Tag;

                    dataBase = fEvt.Database;
                }
            }
            else
            {
                success = UpdateMessage();
            }

            if (success)
            {
                step = 1;
                plBrower.Visible = true;
                plEdit.Visible = false;

                txtMsgTitle.Text = "";
                txtMsgEdit.Text = "";

                plRecvieObject.Visible = false;
                lvwReciveList.Items.Clear();

                btnProvious.Enabled = false;
                btnNext.Enabled = false;
                btnRelease.Enabled = false;
                LoadMessageTitle();
            }
        }

        private void lvwSelectList_DoubleClick(object sender, EventArgs e)
        {
            btnAddToList_Click(null, null);
        }

        private void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwReciveList.SelectedItems)
            {
                lvwReciveList.Items.Remove(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            int keyInt = (int)e.KeyChar;

            if (keyInt >= 48 && keyInt <= 57 || keyInt == 8)
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            if (txtDay.Text == "")
            {
                txtDay.Text = "1";
                txtDay.SelectAll();
            }
        }

        private void lvwTitleList_DoubleClick(object sender, EventArgs e)
        {
            if (lvwTitleList.SelectedItems.Count == 0)
                return;

            btnEdit_Click(null, null);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lvwTitleList.SelectedItems.Count == 0)
                return;
            if (MessageBox.Show("ȷ��Ҫɾ��ѡ�е���Ϣ��֪ͨ��", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int msgId = Convert.ToInt32(lvwTitleList.SelectedItems[0].Tag);
                //add by wangzhi 2010-10-19
                if (!AllowOperateMessage(msgId, 0))
                {
                    MessageBox.Show("��û��ɾ�����˷�������Ϣ��Ȩ�ޣ�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //end add
                try
                {
                    //string sql = "delete from pub_message where msgid=" + msgId;
                    //dataBase.DoCommand(sql);
                    //sql = "delete from pub_message_recivelist where msgid=" + msgId;
                    //dataBase.DoCommand(sql);
                    string sql = "update pub_message set deletebit =1,deleteuser=" + currentUserId + ",deletedate =getdate() where msgid=" + msgId;
                    dataBase.DoCommand(sql);

                    lvwTitleList.Items.Remove(lvwTitleList.SelectedItems[0]);
                }
                catch
                {
                    MessageBox.Show("ɾ���������ɹ���");
                }

            }
        }

        private void LoadJgbm()
        {
            string sql = "select jgbm,jgmc from jc_jgbm union all select -1,'ȫ��'";
            DataTable tb = dataBase.GetDataTable(sql);

            cmbJgbm.DisplayMember = "jgmc";
            cmbJgbm.ValueMember = "jgbm";
            cmbJgbm.DataSource = tb;
            cmbJgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;
        }

        private void cmbJgbm_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbJgbm.SelectedValue != null && Convert.ToInt32(cmbJgbm.SelectedValue) != -1)
            {
                dataBase = WorkStaticFun.GetJgbmDb(Convert.ToInt32(cmbJgbm.SelectedValue));

                LoadMessageTitle();
            }
        }
        /// <summary>
        /// �Ƿ��������Ϣ���в���
        /// </summary>
        /// <param name="flag">0-ɾ�� 1-�޸�</param>
        /// <remarks>add by wangzhi 2010-10-19</remarks>
        /// <returns></returns>
        private bool AllowOperateMessage(int msgId, int flag)
        {
            string sql = "select releaseor from pub_message where msgid=" + msgId; //������Ϣ��ԭ������
            object obj = dataBase.GetDataResult(sql);
            if (obj == null)
                throw new Exception("��ȡ��Ϣԭ�����˷�������ֵΪ��");
            int releaseor = Convert.ToInt32(obj); //ԭ��Ϣ������
            //�鿴��ǰ�û��Ƿ�����Ϣ������Ա�б�
            DataRow dr = dataBase.GetDataRow("select * from pub_message_releasor where employee_id=" + currentUserId);
            if (dr == null)
                return false;//�����б�Ļ���Ϊû�й�����ϢȨ��

            if (releaseor == currentUserId) //���ԭ��Ϣ�������Ǳ��ˣ����Բ���
            {
                return true;
            }
            else
            {
                //���Ǳ��˷���������Ȩ������
                if (flag == 0)
                {
                    return ALLOW_DELETE_ALL;
                }
                else
                {
                    //�޸�
                    return ALLOW_EDIT_ALL;
                }
            }
        }

        private void �ö�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwTitleList.SelectedItems.Count == 0)
            {
                return;
            }

            int msgId = Convert.ToInt32(lvwTitleList.SelectedItems[0].Tag);
            try
            {
                Int64 maxSort = Convert.ToInt64(dataBase.GetDataResult("select max(sort) from pub_message"));
                maxSort += 1;
                string sql = "update pub_message set sort=" + maxSort + " where msgid=" + msgId;
                dataBase.DoCommand(sql);

                LoadMessageTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ȡ���ö�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwTitleList.SelectedItems.Count == 0)
            {
                return;
            }

            int msgId = Convert.ToInt32(lvwTitleList.SelectedItems[0].Tag);
            try
            {
                string sql = "update pub_message set sort=0 where msgid=" + msgId;
                dataBase.DoCommand(sql);

                LoadMessageTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}