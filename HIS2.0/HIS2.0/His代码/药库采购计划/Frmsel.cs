using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;

namespace ts_yk_cgjh
{
    public partial class Frmsel : Form
    {
        public bool bok = false;
        public string ssql = "";
        public string ssql_bz = "";
        public Frmsel()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ������Ա�־��
        /// </summary>
        private void AddTreeYpsx()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;
            TreeNode node = treeView1.Nodes.Add("����״̬", "����״̬");
            TreeNode Cnode2 = node.Nodes.Add("����ҩƷ");
            Cnode2.Tag = " or djyp=1 ";
            Cnode2.ImageIndex = 1;
            TreeNode Cnode3 = node.Nodes.Add("����ҩƷ");
            Cnode3.Tag = " or mzyp=1 ";
            Cnode3.ImageIndex = 1;
            TreeNode Cnode4 = node.Nodes.Add("Ƥ��ҩƷ");
            Cnode4.Tag = " or psyp=1 ";
            Cnode4.ImageIndex = 1;
            TreeNode Cnode5 = node.Nodes.Add("����ҩƷ");
            Cnode5.Tag = " or jsyp=1 ";
            Cnode5.ImageIndex = 1;
            TreeNode Cnode6 = node.Nodes.Add("����ҩƷ");
            Cnode6.Tag = " or gzyp=1 ";
            Cnode6.ImageIndex = 1;
            TreeNode Cnode21 = node.Nodes.Add("����ҩƷ");
            Cnode21.Tag = " or rsyp=1 ";
            Cnode21.ImageIndex = 1;

            TreeNode Cnode32 = node.Nodes.Add("����ҩ��");
            Cnode32.Tag = " or GJJBYW=1 ";
            Cnode32.ImageIndex = 1;
            node.Expand();

            //ͳ�����
            TreeNode node1 = treeView1.Nodes.Add("��ҩ����", "��ҩ����");

            string ssql = "select * from yp_tlfl ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode Cnode30 = node1.Nodes.Add("��" + Convertor.IsNull(tb.Rows[i]["name"], ""));
                Cnode30.Tag = " or b.tlfl='" + Convertor.IsNull(tb.Rows[i]["code"], "") + "' ";

                Cnode30.ImageIndex = 1;
            }
            node1.Expand();

            //����
            TreeNode node2 = treeView1.Nodes.Add("����", "����");
            string ksssql = "select * from YP_YPJX ";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(ksssql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode Cnode31 = node2.Nodes.Add("��" + Convertor.IsNull(dt.Rows[i]["MC"], ""));
                Cnode31.Tag = " or YPJX=" + Convertor.IsNull(dt.Rows[i]["ID"], "") + " ";

                Cnode31.ImageIndex = 1;
            }


            


        }



        private void Frmsel_Load(object sender, EventArgs e)
        {
            AddTreeYpsx();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            for (int i = 0; i <= e.Node.Nodes.Count - 1; i++)
            {
                if (e.Node.Checked==true)
                    e.Node.Nodes[i].Checked = true;
                else
                    e.Node.Nodes[i].Checked = false;
            }

        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
            bok = false;
            ssql = "";
            ssql_bz = "";
        }

        private void butok_Click(object sender, EventArgs e)
        {
            bok = true;

            string str1 = "";
            string str2 = "";
            string str3 = "";
            for (int i = 0; i <= treeView1.Nodes["����״̬"].Nodes.Count - 1; i++)
            {
                if (Convertor.IsNull(treeView1.Nodes["����״̬"].Nodes[i].Tag, "") != "" && treeView1.Nodes["����״̬"].Nodes[i].Checked==true)
                {
                    str1 = str1 + " " + Convertor.IsNull(treeView1.Nodes["����״̬"].Nodes[i].Tag, "");
                    ssql_bz = ssql_bz + "," + Convertor.IsNull(treeView1.Nodes["����״̬"].Nodes[i].Text, "");
                }
            }

            for (int i = 0; i <= treeView1.Nodes["��ҩ����"].Nodes.Count - 1; i++)
            {
                if (Convertor.IsNull(treeView1.Nodes["��ҩ����"].Nodes[i].Tag, "") != "" && treeView1.Nodes["��ҩ����"].Nodes[i].Checked == true)
                {
                    str2 = str2 + " " + Convertor.IsNull(treeView1.Nodes["��ҩ����"].Nodes[i].Tag, "");
                    ssql_bz = ssql_bz + "," + Convertor.IsNull(treeView1.Nodes["��ҩ����"].Nodes[i].Text, "");
                }
            }

            for (int i = 0; i <= treeView1.Nodes["����"].Nodes.Count - 1; i++)
            {
                if (Convertor.IsNull(treeView1.Nodes["����"].Nodes[i].Tag, "") != "" && treeView1.Nodes["����"].Nodes[i].Checked == true)
                {
                    str3 = str3 + " " + Convertor.IsNull(treeView1.Nodes["����"].Nodes[i].Tag, "");
                    ssql_bz = ssql_bz + "," + Convertor.IsNull(treeView1.Nodes["����"].Nodes[i].Text, "");
                }
            }

            if (str1!="")
                str1 = "("+str1.Substring(3,str1.Length-3)+")";
            if (str2 != "")
               str2 = "(" + str2.Substring(3, str2.Length - 3) + ")";
           if (str3 != "")
                str3 = "(" + str3.Substring(3, str3.Length - 3) + ")";

             
            if (str1 != "")  ssql = ssql + " and "+str1;
            if (str2 != "") ssql = ssql + " and " + str2;
            if (str3 != "") ssql = ssql + " and " + str3;

            this.Close();
        }



    }
}