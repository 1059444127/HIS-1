using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class FrmDepartments : Form
    {
        public FrmDepartments()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ҳ�湹��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Department_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �����б���
        /// </summary>
        private void InitTree()
        {
            TreeDp.Nodes.Clear();
            TreeDp.Nodes.Add("Top", "�����б�");
            DataTable dt = GetDeparmentList(null, DeparmentType.һ������);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    TreeNode newtn = new TreeNode(item["name"].ToString());
                    newtn.Name = item["id"].ToString();
          
                    //newtn.Parent = TreeDp.Nodes["Top"];
                    TreeDp.Nodes["Top"].Nodes.Add(newtn);
                    TreeDp.Nodes["Top"].Expand();
                    InitTree(newtn);
                }
            }

        }

        /// <summary>
        /// �������б��������ɷ�һ�����ŵ������б�
        /// </summary>
        /// <param name="parentNodeKey"></param>
        private void InitTree(TreeNode node)
        {
            DataTable dt = GetDeparmentList(node.Name, null);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    TreeNode newtn = new TreeNode(item["name"].ToString());
                    newtn.Name = item["id"].ToString();
                     node.Nodes.Add(newtn);
                     node.Expand();
                     InitTree(newtn);
                }
            }

        }


        /// <summary>
        /// ȡ�ÿ����б�
        /// </summary>
        /// <param name="parentkey">�ϼ�����ID</param>
        /// <param name="type">��������</param>
        /// <returns></returns>
        private DataTable GetDeparmentList(string parentkey, DeparmentType? type)
        {
            string sql;
            if (type == DeparmentType.һ������ || type == DeparmentType.��������)
            {
                if (parentkey == "" || parentkey == null)
                {
                    sql = "select id , [name] , ParentID  from KS_DepartmentNode where type=" + ((int)type).ToString() + "  order by  type,[name]";
                }
                else
                {
                    sql = "select id , [name] , ParentID from KS_DepartmentNode where type=" + ((int)type).ToString() + "  and ParentID='" + parentkey + "' order by  type,[name]";
                }
            }
            else if (type == DeparmentType.��������)
            {
                if (parentkey == "" || parentkey == null)
                {
                    sql = "select a.id as id , b.name as [name] ,  ParentId  as ParentID   from KS_DepartmentLeaf   order by b.name";
                }
                else
                {
                    sql = "select a.id as id , b.name as [name] , ParentId  as ParentID    from KS_DepartmentLeaf  where ParentId='" + parentkey + "'  order by b.name";
                }
            }
            else
            {
                if (parentkey == "" || parentkey == null)
                {
                    sql = "select id , [name] , ParentID from KS_DepartmentNode where type=0 order by  type,[name]";
                }
                else
                {
                    sql = "select id , [name] , ParentID from KS_DepartmentNode where  ParentID='" + parentkey + "' order by  type,[name]";
                }
                DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    sql = "select id as id ,b.name as [name] , ParentId  as ParentID     from KS_DepartmentLeaf join JC_DEPT_PROPERTY b on id=b.dept_ID   where ParentId='" + parentkey + "'  order by name";
                    return FrmMdiMain.Database.GetDataTable(sql);
                }
            }
            return FrmMdiMain.Database.GetDataTable(sql);
        }

        /// <summary>
        /// ȡû�б�����Ŀ����б�
        /// </summary>
        /// <returns></returns>
        private DataTable GetRemainDepartmentList()
        {
            string sql = "select dept_id as id ,name from JC_DEPT_PROPERTY where layer=3 and dept_id not in(select id from KS_DepartmentLeaf) order by name";
            return FrmMdiMain.Database.GetDataTable(sql);
        }

        /// <summary>
        /// ����δ����������б�
        /// </summary>
        private void InitRemainDepartmentList()
        {
            RemainView.Items.Clear();
            DataTable dt = GetRemainDepartmentList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count;i++ )  
                {
                   DataRow item = dt.Rows[i];
                   RemainView.Items.Add(item["id"].ToString(), item["name"].ToString(), "");  
                }              
            }
        }


        /// <summary>
        /// ���쵱ǰ�����б�
        /// </summary>
        /// <param name="parentId"></param>
        private void InitCurDepartmentList(string parentId)
        {
            CurView.Items.Clear();
            DataTable dt = GetDeparmentList(parentId, null);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow item = dt.Rows[i];
                    //ListViewItem im = new ListViewItem(item["id"].ToString());
                    //im.SubItems.Add(item["name"].ToString());
                    //CurView.Items.Add(im);
                    CurView.Items.Add(item["id"].ToString(), item["name"].ToString(), "");
                    //CurView.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// ���һ����������
        /// </summary>
        /// <param name="name">������</param>
        /// <param name="parentId">�ϼ�����ID</param>
        /// <returns></returns>
        private string AddDepartment(string name, string parentId)
        {
            string sql;
            DeparmentType type;
            if (string.IsNullOrEmpty(parentId) || parentId == "Top")
            {
                type = DeparmentType.һ������;
                sql = "insert into KS_DepartmentNode(id , [name] , type) values ('" + Guid.NewGuid().ToString() + "' , '" + name.Replace("'","''") + "' , 0)";
            }
            else
            {
                sql = "select type from  KS_DepartmentNode where id='" + parentId + "'";
                DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count <= 0)
                {
                    return "�Ҳ���������ҵ��ϼ����ң�";
                }
                else
                {
                    if (int.Parse(dt.Rows[0][0].ToString()) == (int)DeparmentType.��������)
                    {
                        return "��������������ң����ڻ������ݹ���Ŀ���ά���н��д���";
                    }
                    else
                    {
                        type = (DeparmentType)(int.Parse(dt.Rows[0][0].ToString()) + 1);
                        sql = "insert into KS_DepartmentNode(id , [name] , ParentID , type) values ('" + Guid.NewGuid().ToString() + "' , '" + name + "' , '" + parentId + "'  ,  " + (int)type + ")";
                    }
                }
            }
            object err;
            FrmMdiMain.Database.InsertRecord(sql, out err);
            return "";
        }






        /// <summary>
        /// ѡ��Tree�ڵ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDp_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string parentid = TreeDp.SelectedNode.Name == "Top" ? null : TreeDp.SelectedNode.Name;
            InitCurDepartmentList(parentid);
            RemainView.Clear();
            if (!string.IsNullOrEmpty(parentid))
            {
                DeparmentType? type = GetDepartmentType(parentid);
                if (type == DeparmentType.��������)
                {
                    InitRemainDepartmentList();
                }
            }
        }

        /// <summary>
        /// ��ѯ���ҵȼ��������ڵĿ��ҷ���null
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        private DeparmentType? GetDepartmentType(string departmentId)
        {
            string sql = "select type from KS_DepartmentNode where id='" + departmentId + "'";
            DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return (DeparmentType)int.Parse(dt.Rows[0][0].ToString());
            }
            else
            {
                int id;
                if (!int.TryParse(departmentId, out id))
                {
                    return null;
                }
                sql = "select * from JC_DEPT_PROPERTY where layer=3 and dept_id=" + id + "";
                dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return DeparmentType.��������;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// �Ƴ����Ұ�Ŧ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CurView.SelectedItems.Count <= 0) return;
            if (MessageBox.Show("ȷ��ɾ��ѡ�����ң�", "ɾ��ȷ��", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DelDepartment(CurView.SelectedItems[0].Name);
                RemainView.Items.Clear();
                string parentid = TreeDp.SelectedNode.Name == "Top" ? null : TreeDp.SelectedNode.Name;
                DeparmentType? type = GetDepartmentType(parentid);
                if (type == DeparmentType.��������)
                {
                    InitRemainDepartmentList();
                }
            }
            InitCurDepartmentList(TreeDp.SelectedNode.Name);
            InitRemainDepartmentList();
        }

        /// <summary>
        /// �Ƴ����ң�һ����������ֱ��ɾ�������������Ƴ����ҹ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string DelDepartment(string id)
        {
            DeparmentType? type = GetDepartmentType(id);
            if (type != DeparmentType.��������)
            {
                string sql = "select * from KS_DepartmentNode where ParentID='" + id + "'";
                DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return "�ÿ��Ҵ����¼����ң����Ƚ��¼�����ɾ�����ٽ���ɾ������";
                }
                else
                {
                    sql = "select * from KS_DepartmentLeaf where ParentId='" + id + "'";
                    dt = FrmMdiMain.Database.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        return "�ÿ��Ҵ����¼����ң����Ƚ��¼�����ɾ�����ٽ���ɾ������";
                    }
                    sql = "Delete from KS_DepartmentNode where id='" + id + "'";
                    FrmMdiMain.Database.DoCommand(sql);
                }
            }
            else
            {
                string sql = "Delete from KS_DepartmentLeaf where id='" + id + "'";
                FrmMdiMain.Database.DoCommand(sql);
            }
            return null;
        }

        /// <summary>
        /// ���������ҽ��й���
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentid"></param>
        /// <returns></returns>
        private string AddDepartmentLeaf(string id, string parentid)
        {
            DeparmentType? type = GetDepartmentType(id);
            if (type != DeparmentType.��������)
            {
                MessageBox.Show("���ܽ����������ҽ��й�����");
            }
            type = GetDepartmentType(parentid);
            if (type != DeparmentType.��������)
            {
                MessageBox.Show("���ܽ���������ֱ�ӹ�����һ�����ң�");
            }
            string TopId = GetParentId(parentid, DeparmentType.��������);
            string sql = "insert into KS_DepartmentLeaf(id , ParentId ,TopId) values ('" + id + "' , '" + parentid + "' , '" + TopId + "')";
            object err=new object();
            FrmMdiMain.Database.InsertRecord(sql,out err) ;
            return "";
        }

        /// <summary>
        /// ȡ�ϼ�����ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetParentId(string id, DeparmentType type)
        {
            string sql;
            if (type == DeparmentType.һ������) return null;
            if (type == DeparmentType.��������)
            {
                sql = "select ParentID from KS_DepartmentNode where id='" + id + "'";
            }
            else
            {
                sql = "select ParentId as  ParentID from KS_DepartmentLeaf where id='" + id + "'";
            }
            return FrmMdiMain.Database.GetDataTable(sql).Rows[0]["ParentID"].ToString();
        }


        /// <summary>
        /// ������Ŧ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (RemainView.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in RemainView.CheckedItems)
                {
                    AddDepartmentLeaf(item.Name, TreeDp.SelectedNode.Name);
                }
            }
            InitCurDepartmentList(TreeDp.SelectedNode.Name);
            InitRemainDepartmentList();

        }

        private void FrmDepartments_Load(object sender, EventArgs e)
        {
            InitTree();
        }

        /// <summary>
        /// ��ӿ��Ұ�Ŧ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (btAdd.Enabled == false) return;
            if (TreeDp.SelectedNode == null) return;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("��������ӵĿ�������");
                return;
            }
            if (string.IsNullOrEmpty(TreeDp.SelectedNode.Name))
            {
                MessageBox.Show("��ѡ���������������Σ�")   ;
                return;
            }
            if (AddDepartment(tbName.Text, TreeDp.SelectedNode.Name) == "")
            {
                MessageBox.Show("��ӳɹ���");
            }

            string id = TreeDp.SelectedNode.Name;
            CurView.Items.Clear();
            RemainView.Items.Clear();
            InitTree();
            TreeDp.SelectedNode = TreeDp.Nodes[id];
            
        }

        private void TreeDp_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2_Click(sender, e);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_ItemGroup fm = new Frm_ItemGroup();
            fm.ShowDialog();
        }






    }

    public enum DeparmentType : int
    {
        һ������ = 0,
        �������� = 1,
        �������� = 2
    }
}