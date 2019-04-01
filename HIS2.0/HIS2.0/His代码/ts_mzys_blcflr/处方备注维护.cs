using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_mzys_blcflr
{
    public partial class FrmZyMbWh : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public FrmZyMbWh(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void FrmZyMbWh_Load(object sender, EventArgs e)
        {
            treeView1.ImageList = this.imageList3;
            Bind();
        }

        private void Bind()
        {
            treeView1.Nodes.Clear();
            DataTable tb = ts_mz_class.jc_mb.SelectZyCfMb(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, 0, InstanceForm.BDatabase);
            TreeNode tn = new TreeNode();
            tn.Text = "ȫ������";
            tn.Tag = Guid.Empty.ToString();
            tn.ToolTipText = "1";
            tn.ImageIndex = 0;
            tn.Expand();
            ts_mzys_blcflr.Frmblcf.AddTreeMbfl(tb, tn, Guid.Empty);
            treeView1.Nodes.Add(tn);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("��ѡ�����ڵ������ģ��!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string _mbmc = "";
            string _pym = "";
            string _wbm = "";
            string _bz = "";
            string _djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            string _fid = "";
            if (treeView1.SelectedNode.ToolTipText == "1" || treeView1.SelectedNode.Tag.ToString() == Guid.Empty.ToString())
                _fid = treeView1.SelectedNode.Tag.ToString();
            else
                _fid = Guid.Empty.ToString();
            Guid _NewMbid = Guid.Empty;//�½�ģ��Guid
            //���ر���
            int _err_code = -1;
            string _err_text = "";

            Guid _Mbid = new Guid(Guid.Empty.ToString());//ģ��ID
            DlgInputBox Inputbox = new DlgInputBox("", "��������ҩ�巨ģ������                    ģ�彫�����<" + treeView1.SelectedNode.Text + ">�ڵ���!", "����ģ��");
            Inputbox.NumCtrl = false;
            Inputbox.ShowDialog();
            if (!DlgInputBox.DlgResult) return;
            _mbmc = DlgInputBox.DlgValue.ToString();
            if (_mbmc == "") return;
            _pym = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 0);
            _wbm = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 1);
            ts_mz_class.jc_mb.SaveZyCfMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm,
                _mbmc, _pym, _wbm, _bz, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _djsj, InstanceForm.BCurrentUser.EmployeeId,
               _fid, 0, ref _NewMbid, ref _err_code, ref _err_text, InstanceForm.BDatabase);
            if (_err_code != 0)
                throw new Exception(_err_text);
            MessageBox.Show(_err_text, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtbz.Text = "";
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

            Guid _Mbid = new Guid(Guid.Empty.ToString());//ģ��ID
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.ToolTipText == "0" && treeView1.SelectedNode.Tag.ToString() == Guid.Empty.ToString())
            {
                MessageBox.Show("��ѡ��Ҫ�������ҩ�巨����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (treeView1.SelectedNode.ToolTipText != "1")
                _Mbid = new Guid(treeView1.SelectedNode.Tag.ToString());
            if (txtbz.Text == "")
            {
                MessageBox.Show("������巨����!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string _mbmc = "";
            string _pym = "";
            string _wbm = "";
            string _bz = txtbz.Text;
            string _djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            string _fid = "";
            Guid _NewMbid = Guid.Empty;//�½�ģ��Guid
            //���ر���
            int _err_code = -1;
            string _err_text = "";



            if (treeView1.SelectedNode.ToolTipText == "0")
            {
                _fid = treeView1.SelectedNode.Parent.Tag.ToString();
                _mbmc = treeView1.SelectedNode.Text.ToString();
            }
            else if (treeView1.SelectedNode.ToolTipText == "1")
                _fid = treeView1.SelectedNode.Tag.ToString();
            else
            {
                _fid = Guid.Empty.ToString();
                _mbmc = treeView1.SelectedNode.Text;
            }
            if (treeView1.SelectedNode.ToolTipText == "1")
            {
                DlgInputBox Inputbox = new DlgInputBox("", "��������ҩ�巨ģ������                    ģ�彫�����<" + treeView1.SelectedNode.Text + ">�ڵ���!", "����ģ��");
                Inputbox.NumCtrl = false;
                Inputbox.ShowDialog();
                if (!DlgInputBox.DlgResult) return;
                _mbmc = DlgInputBox.DlgValue.ToString();
            }
            if (_mbmc == "") return;
            _pym = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 0);
            _wbm = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 1);
            ts_mz_class.jc_mb.SaveZyCfMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm,
                _mbmc, _pym, _wbm, _bz, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _djsj, InstanceForm.BCurrentUser.EmployeeId,
               _fid, 0, ref _NewMbid, ref _err_code, ref _err_text, InstanceForm.BDatabase);
            if (_err_code != 0)
                throw new Exception(_err_text);
            MessageBox.Show(_err_text, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode.ToolTipText == "1")
                txtbz.Text = "";
            else
            {
                DataRow dr = ts_mz_class.jc_mb.SelectZyMbBz(treeView1.SelectedNode.Tag.ToString(), InstanceForm.BDatabase);
                txtbz.Text = dr["BZ"].ToString();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void ��Ӽ巨����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.ToolTipText == "0")
                {
                    MessageBox.Show("�ýڵ���ģ��ڵ�,���ܹ���ӷ���!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string _mbmc = "";
                string _pym = "";
                string _wbm = "";
                string _bz = "��ҩ��������";
                string _djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string _fid = Guid.Empty.ToString();
                Guid _NewMbid = Guid.Empty;//�½�ģ��Guid
                //���ر���
                int _err_code = -1;
                string _err_text = "";

                Guid _Mbid = new Guid(Guid.Empty.ToString());//ģ��ID
                DlgInputBox Inputbox = new DlgInputBox("", "��������ҩ��������                  ���ཫ�����<" + treeView1.SelectedNode.Text + ">�ڵ���!", "����ģ��");
                Inputbox.NumCtrl = false;
                Inputbox.ShowDialog();
                if (!DlgInputBox.DlgResult) return;
                _mbmc = DlgInputBox.DlgValue.ToString();
                if (_mbmc == "") return;
                _pym = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 0);
                _wbm = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 1);
                ts_mz_class.jc_mb.SaveZyCfMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm,
                    _mbmc, _pym, _wbm, _bz, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _djsj, InstanceForm.BCurrentUser.EmployeeId,
                   _fid, 1, ref _NewMbid, ref _err_code, ref _err_text, InstanceForm.BDatabase);
                if (_err_code != 0)
                    throw new Exception(_err_text);
                MessageBox.Show(_err_text, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�����ҩ�������,ԭ��:" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void �޸ļ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.Text == "ȫ������")
                return;
            if (treeView1.SelectedNode.ToolTipText == "0")
            {
                MessageBox.Show("�ýڵ���ģ��ڵ�,���ܹ��޸ķ���!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string _mbmc = "";
            string _pym = "";
            string _wbm = "";
            string _bz = "��ҩ��������";
            string _djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            string _fid = treeView1.SelectedNode.Parent.Tag.ToString();
            Guid _NewMbid = Guid.Empty;//�½�ģ��Guid
            //���ر���
            int _err_code = -1;
            string _err_text = "";

            Guid _Mbid = new Guid(Convertor.IsNull(treeView1.SelectedNode.Tag.ToString(), Guid.Empty.ToString()));//ģ��ID
            DlgInputBox Inputbox = new DlgInputBox(treeView1.SelectedNode.Text, "��������Ҫ�޸ĵ���ҩ��������              ���ཫ������<" + treeView1.SelectedNode.Text + ">�ڵ���!", "����ģ��");
            Inputbox.NumCtrl = false;
            Inputbox.ShowDialog();
            if (!DlgInputBox.DlgResult) return;
            _mbmc = DlgInputBox.DlgValue.ToString();
            if (_mbmc == "") return;
            _pym = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 0);
            _wbm = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 1);
            ts_mz_class.jc_mb.SaveZyCfMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm,
                _mbmc, _pym, _wbm, _bz, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _djsj, InstanceForm.BCurrentUser.EmployeeId,
               _fid, 1, ref _NewMbid, ref _err_code, ref _err_text, InstanceForm.BDatabase);
            if (_err_code != 0)
                throw new Exception(_err_text);
            MessageBox.Show(_err_text, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void ɾ���巨����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("�÷���ڵ�������ģ��,����ɾ��ģ��!����ɾ���ڵ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ts_mz_class.jc_mb.DeleteZyCfMb(treeView1.SelectedNode.Tag.ToString(), InstanceForm.BDatabase);
            MessageBox.Show("ɾ���ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void �޸�ģ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            string _mbmc = "";
            DlgInputBox Inputbox = new DlgInputBox(treeView1.SelectedNode.Text, "��������Ҫ�޸ĵ�ģ������", "����ģ��");
            Inputbox.NumCtrl = false;
            Inputbox.ShowDialog();
            if (!DlgInputBox.DlgResult) return;
            _mbmc = DlgInputBox.DlgValue.ToString();
            if (_mbmc == "")
                return;
            ts_mz_class.jc_mb.UpdateZyCfMbMc(treeView1.SelectedNode.Tag.ToString(), _mbmc, InstanceForm.BDatabase);
            MessageBox.Show("�޸�ģ��ɹ�!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void ɾ��ģ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.ToolTipText == "0")
            {
                ts_mz_class.jc_mb.DeleteZyCfMb(treeView1.SelectedNode.Tag.ToString(), InstanceForm.BDatabase);
                MessageBox.Show("ɾ���ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bind();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.ToolTipText == "1")
            {
                ɾ���巨����ToolStripMenuItem.Visible = true;
                ��Ӽ巨����ToolStripMenuItem.Visible = true;
                �޸ļ����ToolStripMenuItem.Visible = true;
                ɾ��ģ��ToolStripMenuItem.Visible = false;
                �޸�ģ������ToolStripMenuItem.Visible = false;
            }
            else
            {
                ɾ���巨����ToolStripMenuItem.Visible = false;
                ��Ӽ巨����ToolStripMenuItem.Visible = false;
                �޸ļ����ToolStripMenuItem.Visible = false;
                ɾ��ģ��ToolStripMenuItem.Visible = true;
                �޸�ģ������ToolStripMenuItem.Visible = true;
            }
        }
    }
}