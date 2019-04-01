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
    public partial class Frm_ItemGroup : Form
    {
        private DataTable _dt;
        public Frm_ItemGroup()
        {
            InitializeComponent();
        }

        private void Frm_ItemGroup_Load(object sender, EventArgs e)
        {
            lv.View = View.Details;
            lv.GridLines = true;

            ColumnHeader ch0 = new ColumnHeader();
            ch0.Text = "ѡ��";
            ch0.Width = 30;
            ch0.TextAlign = HorizontalAlignment.Left;
            this.lv.Columns.Add(ch0);

            ColumnHeader ch = new ColumnHeader(); 
            ch.Text = "���";  
            ch.Width = 30;    
            ch.TextAlign = HorizontalAlignment.Left;
            this.lv.Columns.Add(ch);

            ColumnHeader ch1 = new ColumnHeader();
            ch1.Text = "��Ŀ����";
            ch1.Width = (lv.Width-60)/2;
            ch1.TextAlign = HorizontalAlignment.Left;
            this.lv.Columns.Add(ch1);

            ColumnHeader ch2 = new ColumnHeader();
            ch2.Text = "��������";
            ch2.Width = (lv.Width - 60) / 2;
            ch2.TextAlign = HorizontalAlignment.Left;
            this.lv.Columns.Add(ch2);  

            InitLv();         
        }


        private void InitLv()
        {
            this._dt = GetItemList();

            lv.Items.Clear();
            if (this._dt.Rows.Count > 0)
            {
                for( int i=0;i<this._dt.Rows.Count;i++)
                {
                    DataRow item = this._dt.Rows[i];
                    ListViewItem tmp = new ListViewItem();
                    tmp.SubItems.Add(item["sort"].ToString());
                    tmp.SubItems.Add(item["item_name"].ToString());
                    tmp.SubItems.Add(item["Type"].ToString()==""?"": Enum.GetName(typeof(EN_ItemGroup),((EN_ItemGroup)int.Parse(item["Type"].ToString()))));
                    
lv.Items.Add(tmp);
                  }
            }
                
        }

        /// <summary>
        /// ȡ��Ŀ�б�
        /// </summary>
        /// <returns></returns>
        private DataTable GetItemList()
        {
            string sql = "select ROW_NUMBER() over (order by a.code) as sort, a.code, a.item_name ,b.[Type] from jc_stat_item a left join jc_itemGroup b on a.code=b.code";
            return FrmMdiMain.Database.GetDataTable(sql);
        }

        /// <summary>
        /// �趨��Ŀ����
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type"></param>
        private void setItemGroup(string code,EN_ItemGroup type)
        {
           EN_ItemGroup? oldType=bSetGroup(code);
           string sql;
           if (oldType != null)
           {
               if (oldType.Value == type) return;
               sql = "update  jc_itemGroup set type= " + (int)type + " where code='"+code.Replace("'","''")+"' ";
               object err = new object();
               FrmMdiMain.Database.InsertRecord(sql, out err);
           }
           else
           { 
             //������ֵ
               sql = "insert into jc_itemGroup(code ,[type]) values ( '" + code.Replace("'", "''") + "' , " + (int)type + " ) ";
               object err=new object();
               FrmMdiMain.Database.InsertRecord(sql, out err);
           }
           
        }

        /// <summary>
        /// �ж���Ŀ�Ƿ��ѷ���
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private EN_ItemGroup? bSetGroup(string code)
        {
            string sql="select top 1 type from jc_itemGroup where code='"+code.Replace("'","''")+"'"  ;
            DataTable dt=FrmMdiMain.Database.GetDataTable(sql);
            if(dt.Rows.Count>0)
            {
                return (EN_ItemGroup)int.Parse(dt.Rows[0][0].ToString());    
            }
            else
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�Ƿ�ѡ����Ŀ�趨Ϊ" + cb.Text + "?", "ȷ������", MessageBoxButtons.YesNo) == DialogResult.No) return;
            if (lv.CheckedItems.Count > 0)
            {
                for (int i = 0; i < lv.CheckedItems.Count; i++)
                {
                    setItemGroup(this._dt.Rows[lv.CheckedItems[i].Index]["code"].ToString(), (EN_ItemGroup)cb.SelectedIndex);
                }
            }
            InitLv();
        }
    }
    public enum EN_ItemGroup
    { 
        ҩƷ=0,
        ҽ��=1,
        ҽ��ҵ��=2
    }
}