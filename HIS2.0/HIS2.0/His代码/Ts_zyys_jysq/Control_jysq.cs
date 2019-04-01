using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Xml;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Xml;
using System.Drawing.Printing;
using System.Drawing;
using System.Drawing.Text;
namespace Ts_zyys_jysq
{
    public delegate void DelClose(); 
    public partial class Control_jysq : UserControl
    {

        public string _Zyid = "";//add by jchl
        public string fylb = "";//add by jchl
        private DbQuery myQuery = new DbQuery();//add by jchl

        public bool IsSfy = false;
        public brxx _brxx;
        public Typely typely ;
        DataGridView Serchdgv = new DataGridView();
        public Guid BinID;
        public int BabyID;
        DataTable tbdisease;
        /// <summary>
        /// ��ʶ�Ƿ����޸ĵĽ���,true ��ʶ�޸Ľ���ģ����ܽ������ɾ��
        /// </summary>
        public bool Xg = false;
        JYfun jyfun;
        /// <summary>
        /// ����˵��
        /// </summary>
        DataTable Tbfjsm;
        public event  DelClose  Close;
        public Control_jysq(Typely tpyle)
        {
            InitializeComponent();
            typely = tpyle;
            
        }
        public Control_jysq()
        {
            InitializeComponent();
             
        }

        public void Control_jysq_Load(object sender, EventArgs e)
        {
            try
            {
                //if (BinID==Guid.Empty)
                //   BinID=
                this.TextLczd.textBox1.Text = _brxx.lczd;
               // Serchdgv.DoubleClick += new EventHandler(Serchdgv_DoubleClick);
                Serchdgv.Click += new EventHandler(Serchdgv_Click);
                Serchdgv.MouseClick += new MouseEventHandler(Serchdgv_MouseClick);
                Serchdgv.ReadOnly = true;
                this.TextLczd.Js += new Ts_Ba_tj.Mydelegte(TextLczd_Js);
                this.TextLczd.TextChage += new Ts_Ba_tj.Mydelegte(TextLczd_TextChage);
                this.TextLczd.fz += new Ts_Ba_tj.Mydelegte(TextLczd_fz);

                try
                {
                    //���Ժ��
                    this.cmbYQ.ValueMember = "jgbm";
                    this.cmbYQ.DisplayMember = "jgmc";
                    DataTable tbyqjg =  FrmMdiMain.Database.GetDataTable("select  JGMC,JGBM  from  JC_JGBM");
                    this.cmbYQ.DataSource = tbyqjg;
                    this.cmbYQ.SelectedIndexChanged += new EventHandler(cmbYQ_SelectedIndexChanged);
                }
                catch { }
                //
                int jgbm = int.Parse(this.cmbYQ.SelectedValue.ToString() == "" ? "-1" : this.cmbYQ.SelectedValue.ToString());

                jyfun = new JYfun();
                Tbfjsm = jyfun.Get_Jg("select ' ' name ,'' py union all select mc NAME,pym py from jc_param where lx=2");
                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.AutoGenerateColumns = false;
               
                this.textBoxEx1.TextChanged += new EventHandler(textBoxEx1_TextChanged);
                this.chkListBox.KeyDown += new KeyEventHandler(chkListBox_KeyDown);
                //this.TextJYks.TextChage+=new Ts_Ba_tj.Mydelegte(TextJYks_TextChage);
                this.panel1.Dock = DockStyle.Fill;
                this.panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                //���ؿ���
                DataTable tbdept = jyfun.Getjydept(jgbm);
                this.TextJYks.BindData(tbdept, 0);
                //��ø���˵��
                string sql1 = "select -1 bb , ' ' SAMP_NAME union all select SAMP_CODE bb,rtrim(SAMP_NAME) from LS_AS_SAMPLE where DELETE_BIT=0";// " select mc NAME,pym py from jc_param where lx=2 ";
                DataGridViewComboBoxColumn dgvcbc = this.dataGridView1.Columns["�걾"] as DataGridViewComboBoxColumn;
                dgvcbc.ValueMember = "bb";
                dgvcbc.DisplayMember = "SAMP_NAME";
                dgvcbc.DataSource = jyfun.Get_Jg(sql1);
                //��ñ�ṹ
                string sql = "select 0 checked,'' name,-1 bb,1 sl,'' dw,0.00 dj,0.00 je,'' fjsm,0 zksid ,'' zxksmc ,'' bbmc,'' orderid where 1=2";
                //string sql = "select 0 checked,'dddd' name,-1 bb,1 sl,'' dw,0 dj,0 je,'' fjsm,0 zksid ,'' zxksmc ,'' bbmc,'' orderid ";
                this.dataGridView1.DataSource = jyfun.Get_Jg(sql);
                textBoxEx1.Focus();
                if (Typely.סԺ == typely)
                {
                    DataTable dataTable = FrmMdiMain.Database.GetDataTable("select * from vi_zy_vinpatient_all where baby_id=0 and inpatient_id='" + this.BinID + "'");
                    string lczd = Convert.ToString(Convertor.IsNull(dataTable.Rows[0]["RYZD"], ""));
                    this.TextLczd.textBox1.Text = lczd;
                    this.button4.Visible = true;//�˳���ť�Լ�д
                    //toolStripButton5.Visible = true;modify by jchl 2015-03-25ʹ��Ⱥ��͵���   ���δ�ӡ����
                    toolStripButton5.Visible = false;

                    ((DateTimePicker)this.Parent.Controls["DtpbeginDate"]).Value = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);//ȡ���ݿ�ʱ��
                    ((DateTimePicker)this.Parent.Controls["DtpbeginDate"]).MinDate = Convert.ToDateTime(Convertor.IsNull(dataTable.Rows[0]["in_date"], "1900-01-01 00:00:00"));

                    this.chcekbl.Visible = true;
                    ((DateTimePicker)this.Parent.Controls["DtpbeginDate"]).Visible = true;
                }
                else
                {
                    this.chcekbl.Visible = false;
                    if (((DateTimePicker)this.Parent.Controls["DtpbeginDate"])!=null)
                        ((DateTimePicker)this.Parent.Controls["DtpbeginDate"]).Visible = false;
                    this.panel4.Visible = false;
                    this.panel4.Height = 0;
                   // this.chkListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))));
                    this.button4.Visible = false;//�˳���ť�Լ�д
                    this.toolStripButton4.Visible = false;
                    toolStripButton5.Visible = false;
                    //this.dataGridView1.Columns[3].ReadOnly = true;

                }
                 
                //����ٴ����
                tbdisease = jyfun.Get_Jg("select NAME ����,CODING ���� ,PY_CODE ƴ����,WB_CODE ����� from JC_DISEASE");
                //this.TextLczd.tb = tbdisease;
                TextLczd_TextChage();
                this.textBoxEx1.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
             
        }

        void cmbYQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int jgbm = int.Parse(this.cmbYQ.SelectedValue.ToString() == "" ? "-1" : this.cmbYQ.SelectedValue.ToString());
            //���ؿ���
            DataTable tbdept = jyfun.Getjydept(jgbm);
            if (tbdept.Rows.Count == 1)
            {
                DataTable temp = tbdept.Clone();
                DataRow r = temp.NewRow();
                r["id"] = -99;
                r["name"] = "";
                temp.Rows.Add(r);
                this.TextJYks.BindData(temp, 0);
                this.serchText3.BindData(temp.Copy(),0);
                return;
            }
            this.TextJYks.BindData(tbdept, 0);
            TextJYks_TextChage();
        }

        void Serchdgv_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{Enter}");
        }

        void TextLczd_TextChage()
        {
            tbdisease.DefaultView.RowFilter = "���� like '%" + TextLczd.textBox1.Text.Trim() + "%'  or ƴ���� like '%" + TextLczd.textBox1.Text.Trim() + "%' or ����� like '%" + TextLczd.textBox1.Text.Trim() + "%'";
            DataTable temptb = tbdisease.DefaultView.ToTable();
            TextLczd.tb = temptb;
        }

        void TextLczd_fz()
        {
            try
            {
                this.TextLczd.textBox1.Text = this.TextLczd.row["����"].ToString();
                this.TextLczd.textBox1.Tag = this.TextLczd.row["����"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void TextLczd_Js()
        {
            
        }

        void Serchdgv_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        void Serchdgv_DoubleClick(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chkListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            if (this.chkListBox.GetItemChecked(this.chkListBox.SelectedIndex) == false)
            {
                this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, true);

            }
            else
            {
                this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, false);
            }
           // chkListBox_SelectedIndexChanged(sender, e);
        }

        void textBoxEx1_TextChanged(object sender, EventArgs e)
        {
            Item item = null;
            for (int i = 0; i < this.chkListBox.Items.Count; i++)
            {
                item = (Item)chkListBox.Items[i];
                if (item.pym.IndexOf(textBoxEx1.Text.Trim().ToLower(), 0) == 0)
                {
                    this.chkListBox.SelectedIndex = i;
                    break;
                }
                if (item.Szm.IndexOf(textBoxEx1.Text.Trim().ToLower(), 0) == 0)
                {
                    this.chkListBox.SelectedIndex = i;
                    break;
                }
                if (item.Wbm.IndexOf(textBoxEx1.Text.Trim().ToLower(), 0) == 0)
                {
                    this.chkListBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void Control_jysq_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.panel1.Dock = DockStyle.Fill;
                this.panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                // this.panel3.Anchor = AnchorStyles.Left | AnchorStyles.Right  | AnchorStyles.Top;
            }
            catch { }
        }

        private void TextJYks_TextChage()
        {
            try
            {
                DataTable tbhylx = jyfun.Gethylx(int.Parse(this.TextJYks.textBox1.Tag.ToString()));
                this.TextXmfl.BindData(tbhylx, 0);
                //if (this.TextXmfl.textBox1.Text.Trim() == "ȫ��")
                {
                    TextXmfl_TextChage();
                }
                
            }
            catch
            {
 
            }
        }

        private void TextXmfl_TextChage()
        {
            try
            {
                DataTable itemTb = jyfun.Gethyxm(Convert.ToInt64(this.TextJYks.textBox1.Tag.ToString()), Convert.ToInt16(this.TextXmfl.textBox1.Tag.ToString()), FrmMdiMain.CurrentDept.DeptId);
                chkListBox.Items.Clear();
                Item jyItem = null;
                for (int i = 0; i <= itemTb.Rows.Count - 1; i++)
                {
                    jyItem = new Item();
                    jyItem.orderID = Convert.ToInt32(itemTb.Rows[i]["order_id"]);
                    jyItem.orderName = itemTb.Rows[i]["order_name"].ToString().Trim();
                    jyItem.orderUnit = itemTb.Rows[i]["order_unit"].ToString();
                    jyItem.defaultUsage = itemTb.Rows[i]["default_usage"].ToString();
                    jyItem.execDept = Convert.ToInt32(itemTb.Rows[i]["default_dept"]);
                    jyItem.pym = itemTb.Rows[i]["py_code"].ToString();
                    jyItem.Szm = itemTb.Rows[i]["D_CODE"].ToString();
                    jyItem.Wbm = itemTb.Rows[i]["WB_CODE"].ToString();
                    jyItem.zxksmc = itemTb.Rows[i]["zxksmc"].ToString();
                    jyItem.code = Convert.ToInt32(Convertor.IsNull(itemTb.Rows[i]["code"], "-1"));
                    jyItem.sample = itemTb.Rows[i]["sample"].ToString();
                    jyItem.BZ = itemTb.Rows[i]["BZ"].ToString();
                    jyItem.FJSMBT = Convert.ToInt32(itemTb.Rows[i]["FJSMBT"].ToString());//add by zouchihua 2012-11-21 ����˵������
                    chkListBox.Items.Add(jyItem);

                }
                //����ײ�
                string commandtext="";
                if(this.TextXmfl.textBox1.Tag.ToString()!="0")
                    commandtext = string.Concat(new object[] { "select 0 as id,'' as name union all select id,name from JC_JCHYTC_T where  class_id>0 and  jgbm=", FrmMdiMain.Jgbm, " and class_id=", Convert.ToInt32(this.TextXmfl.textBox1.Tag.ToString()), " and (tclx=0 or (tclx=1 and syid=", FrmMdiMain.CurrentDept.DeptId, ") or (tclx=2 and syid=", FrmMdiMain.CurrentUser.EmployeeId, "))" });
                else
                    commandtext = string.Concat(new object[] { "select 0 as id,'' as name union all select id,name from JC_JCHYTC_T where  class_id>0 and  jgbm=", FrmMdiMain.Jgbm, " and class_id=", 9999, " and (tclx=0 or (tclx=1 and syid=", FrmMdiMain.CurrentDept.DeptId, ") or (tclx=2 and syid=", FrmMdiMain.CurrentUser.EmployeeId, "))" });
                DataTable dataTable = jyfun.Get_Jg(commandtext);
                DataRow row;
                //if (dataTable.Rows.Count == 0)
                //{
                //    row = dataTable.NewRow();
                //    row["id"] = 9999;
                //    row["name"] = "ȫ��";
                //    dataTable.Rows.InsertAt(row, 0);
                //}
                //row = dataTable.NewRow();
                //row["id"] = -999;
                //row["name"] = " ";
                //dataTable.Rows.InsertAt(row, 0);
                this.serchText3.BindData(dataTable, 0);

                this.textBoxEx1.Focus();
            }
            catch { }
        }

        private void textBoxEx1_KeyDown(object sender, KeyEventArgs e)
        {
            //ȫ����ѡ��
            for (int i = 0; i < this.chkListBox.Items.Count; i++)
            {
                this.chkListBox.SetItemChecked(i, false);
            }
            int sel = this.chkListBox.SelectedIndex;
            if (e.KeyValue == 13 && this.chkListBox.SelectedItems.Count != 0)
            {
                if (this.chkListBox.GetItemChecked(sel) == false)
                {
                    this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, true);
                }
                else this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, false);
                //chkListBox_SelectedIndexChanged(sender, e);
                textBoxEx1.Text = "";
                this.chkListBox.SelectedIndex = sel;
            }
            if (e.KeyValue == 40)
            {
                if (sel < this.chkListBox.Items.Count - 1) this.chkListBox.SelectedIndex++;
            }
            if (e.KeyValue == 39)
            {
                if (sel + 8 < this.chkListBox.Items.Count) this.chkListBox.SelectedIndex += 8;
            }
            if (e.KeyValue == 38)
            {
                if (sel > 0) this.chkListBox.SelectedIndex--;
            }
            if (e.KeyValue == 37)
            {
                if (sel - 8 >= 0) this.chkListBox.SelectedIndex -= 8;
            }

        }

        private void chkListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //this.dataGridView1.Rows[0].Cells[0].ini
               // chkListBox.SelectedItems
               //if(((Item)chkListBox.SelectedItem))
            }
            catch { }
        }

        private void chkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!IsSfy)
            {
                if (Xg)
                    return;
            }
            try
            {
                if (e.NewValue == CheckState.Checked)
                {
                    Item item = ((Item)chkListBox.Items[e.Index]);
                    if (Isexist(item.orderID))
                    {
                        if (MessageBox.Show("��" + item.orderName + "���Ѿ����ڣ��Ƿ������ӣ�", "��ʾ", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    if (item.orderID.ToString()== "137429")
                    {
                        Inpatient_tz Inpatient_tz = new Inpatient_tz(InstanceForm._database);
                        Inpatient_tz.BinID = this.BinID;
                        Inpatient_tz.ShowDialog();
                        if (Inpatient_tz.isclose)
                        {
                            return;
                        }

                    }
                    DataTable temp = (DataTable)this.dataGridView1.DataSource;
                    DataRow row = temp.NewRow();
                    row["checked"] = 0;
                    row["name"] = item.orderName;
                    row["bb"] = item.code;
                    row["bbmc"] = item.sample;
                    row["sl"] = 1;
                    row["fjsm"] = "";
                    row["dw"] = item.orderUnit;
                    row["dj"] = jyfun.GetorderPrice(item.orderID);
                    row["je"] = jyfun.GetorderPrice(item.orderID) * long.Parse(row["sl"].ToString());
                    row["zksid"] = item.execDept;
                    row["zxksmc"] = item.zxksmc;
                    row["orderid"] = item.orderID;
                    temp.Rows.Add(row);
                }
                Gethj();
                
            }
            catch { }
            
        }
        /// <summary>
        /// ��úϼƽ��
        /// </summary>
        private void Gethj()
        {
            DataTable temp1 = (DataTable)this.dataGridView1.DataSource;
            temp1.DefaultView.Sort = "zxksmc ";
            DataTable temp = temp1.DefaultView.ToTable();
            temp1.Dispose();
            this.dataGridView1.DataSource = temp;
            decimal hjje=0;
            for(int i=0;i<temp.Rows.Count;i++)
            {
                if(temp.Rows[i]["orderid"].ToString().Trim()!="0")
                {
                    hjje+=decimal.Parse(temp.Rows[i]["je"].ToString().Trim());
                }
            }
            DataRow[] rowGroup=temp.Select("orderid=0");
            if (rowGroup.Length > 0)
            {
                temp.Rows.Remove(rowGroup[0]);
            }
            {
                DataRow row = temp.NewRow();
                row["name"] = "�ϼƽ��";
                row["je"] = hjje;
                row["orderid"] = 0;
                temp.Rows.Add(row);
            }
            this.dataGridView1.Rows[temp.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
            this.dataGridView1.Rows[temp.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkRed;
            if (temp.Rows[temp.Rows.Count - 1]["name"].ToString() == "�ϼƽ��")
                this.dataGridView1.Rows[temp.Rows.Count - 1].ReadOnly = true;
        }
        private bool Isexist(long orderid)
        {
            DataTable temp = (DataTable)this.dataGridView1.DataSource;
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (temp.Rows[i]["orderid"].ToString() == orderid.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.Cancel = true;
           
            //e.ThrowException = false;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Serchdgv.Visible = false;
            if (this.dataGridView1.HitTest(e.X, e.Y).RowIndex.ToString() == "-1")
                return;
            if (Xg||typely== Typely.����)
            {
                this.dataGridView1.Columns[3].ReadOnly = true;
            }
            if (this.dataGridView1.CurrentCell == null)
                return;
           
            if (this.dataGridView1.CurrentCell.ColumnIndex==7||this.dataGridView1.CurrentCell.ColumnIndex == 3)// || 
            {

                SendKeys.Send("{F2}");
                return;
            }
            if (this.dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                SendKeys.Send("{F2}");
                return;
            }
            //this.Serchdgv.Visible = false;
        }
        int showflag = 0;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            this.Serchdgv.Visible = false;
            //if ((e.Control as ComboBox) != null)
            //{
            //    SendKeys.Send("{F4}");
            //    return;
            //}
            if (this.dataGridView1.CurrentCell.ColumnIndex == 7)
            {
                SendKeys.Send("{F2}");
                //���Ƹ���˵����¼��
                TextBox txt = e.Control as TextBox;
                txt.Leave += new EventHandler(txt_Leave);
                txt.Leave -= new EventHandler(txt_Leave);
                txt.KeyUp -= new KeyEventHandler(txt_KeyUp);
               // if (showflag == 0)
                {
                    txt.KeyUp += new KeyEventHandler(txt_KeyUp);
                }
                //else
                //    showflag = 0;
            }
            else
                this.Serchdgv.Visible = false;
        }

        void txt_Leave(object sender, EventArgs e)
        {
           // this.Serchdgv.Visible = false;
        }
        void txt_KeyUp(object sender, KeyEventArgs e)
        {

            TextBox txt = sender as TextBox;
            if ((Keys)e.KeyData == Keys.Escape) return;
            if ((Keys)e.KeyData == Keys.Left)
            {
                if (txt.SelectionStart != 0)
                    txt.SelectionStart = txt.SelectionStart - 1;
                else
                    txt.SelectionStart = 0;
            }
            if ((Keys)e.KeyData == Keys.Right)
            {
                if (txt.SelectionStart != txt.Text.Length)
                    txt.SelectionStart = txt.SelectionStart + 1;
                else
                    return;
            }
           
            Serchdgv.ColumnHeadersVisible = false;
            Serchdgv.RowHeadersVisible = false;
            Serchdgv.AllowUserToAddRows = false;
            Serchdgv.AllowUserToResizeRows = false;
           
            //this.Serchdgv.DefaultView.RowFilter = "py_code like '%" + txt.Text + "%' or  wb_code like  '%" + txt.Text + "%'";//��������
            
            this.Serchdgv.Visible = true;
            this.Serchdgv.Width = txt.Width + 30;
            this.Serchdgv.DataSource = Tbfjsm;
            try {
                if (this.dataGridView1.CurrentCell.ColumnIndex == 3)
                    this.Serchdgv.Visible = false;
                if ((Keys)e.KeyData != Keys.Up && (Keys)e.KeyData != Keys.Down)
                {
                    this.Serchdgv.CurrentCell = this.Serchdgv.Rows[0].Cells[0];
                }
                this.Serchdgv.Rows[0].Cells[0].Value = txt.Text;
            }
            catch { }
            //��λ��Ƭ
            SetCardGridTopAndLeft((TextBox)sender, this.Serchdgv, ((TextBox)sender).Parent, ((TextBox)sender).Top, ((TextBox)sender).Left);
        }
        /// <summary>
        /// �������ؼ�Ϊ�ı��������Ͽ�ʱ�趨ѡ��������ϱ߾�����߾�
        /// </summary>
        /// <param name="occurTextBox">�����ı���</param>
        /// <param name="cardGrid">ѡ������</param>
        /// <param name="parentCtrl">�����ؼ�</param>
        /// <param name="oppositeTop">�ڸ��ؼ��е����������</param>
        /// <param name="oppositeLeft">�ڸ��ؼ��е���Ժ�����</param>
        public static void SetCardGridTopAndLeft(Control occurTextBox, DataGridView cardGrid, Control parentCtrl, int oppositeTop, int oppositeLeft)
        {
            //��������ڴ����ı�����������涼������
            if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop && oppositeTop < cardGrid.Height)
            {
                #region �߶Ȳ��ʺ�
                if (parentCtrl.Parent != null)
                {
                    SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                }
                #endregion
            }
            else
            {
                #region �߶��ʺ�
                cardGrid.Parent = parentCtrl;//���ø��ؼ�
                cardGrid.BringToFront();
                if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop)		//������±߽糬���������ױ߽���ײ��븸�����ױ߽����
                {
                    cardGrid.Top = oppositeTop - cardGrid.Height;
                }
                else
                {
                    cardGrid.Top = oppositeTop + occurTextBox.Height;
                }
                if (parentCtrl.Width < cardGrid.Width + oppositeLeft)
                {
                    cardGrid.Left = oppositeLeft - (cardGrid.Width - occurTextBox.Width);
                    if (cardGrid.Left < 0)	//��Ȳ��ʺ�
                    {
                        if (parentCtrl.Parent != null)
                        {
                            SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                        }
                    }
                }
                else
                {
                    cardGrid.Left = oppositeLeft;
                }
                #endregion
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && e.RowIndex >= 0)
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[6].Value = long.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) * decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    Gethj();
                }
                if (e.ColumnIndex == 2 && e.RowIndex >= 0)
                {
                    DataGridViewComboBoxCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    ((DataTable)this.dataGridView1.DataSource).Rows[e.RowIndex]["bbmc"] =cell.FormattedValue.ToString();//ͬʱ�����ڴ���еı걾����
                }
            }
            catch { }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            bool IsdgvInput = false;
            #region ����ҩ�� ��ע��������

            if (this.Serchdgv.Visible == true&&this.textBoxEx1.Focused!=true)
            {

                switch (keyData)
                {
                    case Keys.Up:
                         
                         
                            if (this.Serchdgv.CurrentCell != null && this.Serchdgv.CurrentCell.RowIndex != 0)
                            {
                                this.Serchdgv.CurrentCell = this.Serchdgv.Rows[this.Serchdgv.CurrentCell.RowIndex - 1].Cells[0];
                            }
                        break;
                    case Keys.Down:
                         
                        {
                            if (this.Serchdgv.CurrentCell != null && this.Serchdgv.CurrentCell.RowIndex != this.Serchdgv.Rows.Count - 1)
                            {
                                this.Serchdgv.CurrentCell = this.Serchdgv.Rows[this.Serchdgv.CurrentCell.RowIndex + 1].Cells[0];

                            }
                        }
                        break;
                    case Keys.Enter:

                        try
                        {
                            if (this.dataGridView1.CurrentCell.ColumnIndex == 7)
                            {
                                this.dataGridView1.EndEdit();
                                this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[this.dataGridView1.CurrentCell.ColumnIndex].Value = this.Serchdgv.Rows[this.Serchdgv.CurrentCell.RowIndex].Cells[0].Value;

                                showflag = 1;//����ʾ
                                // SendKeys.Send("{F2}");
                            }
                        }
                        catch 
                        {

                        }
                        this.Serchdgv.Visible = false;
                        break;
                    case Keys.Escape:
                         
                        this.Serchdgv.Visible = false;
                        this.dataGridView1.Focus();
                        //comb.Parent.Controls.Remove(comb);
                        break;
                    default: return base.ProcessCmdKey(ref msg, keyData);//���Ա༭
                        break;
                }
                return true;//���Ա༭
            }
            #endregion
            else
                return base.ProcessCmdKey(ref msg, keyData);

            return true;
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Xg)
                return;
            //˫�� ɾ��
            //DataTable temp = (DataTable)this.dataGridView1.DataSource;
            //if (temp.Rows[e.RowIndex]["orderid"].ToString().Trim() != "0")
            //{
            //    temp.Rows.Remove(temp.Rows[e.RowIndex]);
            //    Gethj();
            //}
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = 1;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[0].Value.ToString() == "0")
                {
                    this.dataGridView1.Rows[i].Cells[0].Value = 1;
                }
                else
                    this.dataGridView1.Rows[i].Cells[0].Value = 0;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Xg == true)
                return;
            this.dataGridView1.EndEdit();
            DataTable temp = (DataTable)this.dataGridView1.DataSource;
            int j = 0;
            for (int i = 0; i-j < temp.Rows.Count; i++)
            {
                if (temp.Rows[i - j]["orderid"].ToString().Trim() != "0" && this.dataGridView1.Rows[i - j].Cells[0].Value.ToString() == "1")
                {
                    temp.Rows.Remove(temp.Rows[i-j]);
                    j++;
                    
                }
            }
            Gethj();
        }
        /// <summary>
        /// ����ײ�
        /// </summary>
        private void serchText3_TextChage()
        {
            if (this.serchText3.textBox1.Tag.ToString() == "0")
            {
                TextXmfl_TextChage();
                this.btnqx.Visible = false;
                this.button2.Visible = false;
                return;
            }
            this.btnqx.Visible = true;
            this.button2.Visible = true;
            int num;
            object obj2;
            string commandtext = "SELECT ORDER_ID, ORDER_NAME, ORDER_UNIT, DEFAULT_DEPT,LOWER(PY_CODE) PY_CODE,BZ,DEFAULT_USAGE,SAMPLE,CODE ,FJSMBT,   (select top 1 NAME from JC_DEPT_PROPERTY where JC_DEPT_PROPERTY.DEPT_ID=AA.DEFAULT_DEPT)  as DeptName ,AA.HYLXID,    (select top 1 name from jc_jcclassdiction where jc_jcclassdiction.ID=AA.HYLXID) as JCLXNaMe   FROM  (      SELECT A.ORDER_ID, A.ORDER_NAME, A.ORDER_UNIT, A.PY_CODE, A.BZ, A.DEFAULT_USAGE,      D.EXEC_DEPT AS DEFAULT_DEPT,SAMP_NAME SAMPLE,0 SORT_INDEX,C.SAMP_CODE CODE,FJSMBT,b.HYLXID       FROM (SELECT *      FROM JC_HOITEMDICTION      WHERE DELETE_BIT = 0 AND ORDER_TYPE = 5) A      INNER JOIN      JC_ASSAY B ON A.ORDER_ID = B.YZID ";
            if (this.TextXmfl.textBox1.Tag.ToString() != "0")
            {
                obj2 = commandtext;
                commandtext = string.Concat(new object[] { obj2, "  AND B.HYLXID= ", Convert.ToInt32(this.TextXmfl.textBox1.Tag.ToString()), " " });
            }
            obj2 = commandtext;
            commandtext = string.Concat(new object[] { obj2, "     INNER JOIN      JC_JCHYTC_MX F ON A.ORDER_ID = F.XMID      INNER JOIN      JC_JCHYTC_T E ON F.TCID = E.ID AND E.ID=", Convert.ToInt32(this.serchText3.textBox1.Tag.ToString()), "     INNER JOIN      JC_HOI_DEPT D ON A.ORDER_ID = D.ORDER_ID " });
            if (this.TextJYks.textBox1.Tag.ToString() != "0")
            {
                commandtext = commandtext + "  AND D.EXEC_DEPT= " + Convert.ToInt32(this.TextJYks.textBox1.Tag.ToString());
            }
            //else
            //    commandtext = commandtext + "  AND D.EXEC_DEPT= " + 9999;
            commandtext = commandtext + "     LEFT JOIN      LS_AS_SAMPLE C ON B.BBID=C.SAMP_CODE   ) AA  ORDER BY PY_CODE";
            DataTable  itemTb = FrmMdiMain.Database.GetDataTable(commandtext);
            this.chkListBox.Items.Clear();
            Item item = null;
            for (num = 0; num <= (itemTb.Rows.Count - 1); num++)
            {
                item = new Item();
                item.orderID = Convert.ToInt32(itemTb.Rows[num]["order_id"]);
                item.orderName = itemTb.Rows[num]["order_name"].ToString().Trim();
                item.orderUnit = itemTb.Rows[num]["order_unit"].ToString();
                item.defaultUsage = itemTb.Rows[num]["default_usage"].ToString();
                item.execDept = Convert.ToInt32(itemTb.Rows[num]["default_dept"]);
                item.pym = itemTb.Rows[num]["py_code"].ToString();
                item.code = Convert.ToInt32(Convertor.IsNull(itemTb.Rows[num]["code"], "-1"));
                item.sample = itemTb.Rows[num]["sample"].ToString();
                item.BZ = itemTb.Rows[num]["BZ"].ToString();
                item.FJSMBT = Convert.ToInt32(itemTb.Rows[num]["FJSMBT"].ToString());
                item.zxksmc = itemTb.Rows[num]["DeptName"].ToString();
                this.chkListBox.Items.Add(item);
            }
            this.textBoxEx1.Focus();
        }

        private void btnSaveTc_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            DataRow[] rowGroup = tb.Select("orderid<>0");
            if ((rowGroup.Length != 0) && (MessageBox.Show("�Ƿ���ѡ��Ŀ����Ϊ�ײͣ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No))
            {
                 
                FrmModelSave save = new FrmModelSave("�ײͱ���");
                save.ShowDialog();
                if (save.DialogResult != DialogResult.Cancel)
                {
                    string modelName = save.ModelName;
                    int num = save.model_type;
                    string commandtext = "";
                    int num2 = 0;
                    int deptId = 0;
                    switch (num)
                    {
                        case 1:
                            deptId = FrmMdiMain.CurrentDept.DeptId;
                            break;

                        case 2:
                            deptId = FrmMdiMain.CurrentUser.EmployeeId;
                            break;
                    }
                    FrmMdiMain.Database.BeginTransaction();
                    try
                    {
                        commandtext = string.Concat(new object[] { "insert into jc_jchytc_t(NAME, CLASS_ID, JGBM, TCLX, SYID) values ('", modelName, "',", Convert.ToInt32(this.TextJYks.textBox1.Tag.ToString() == "0" ? "9999" : this.TextXmfl.textBox1.Tag.ToString() ), ",", FrmMdiMain.Jgbm, ",", num, ",", deptId, ")" });
                        FrmMdiMain.Database.DoCommand(commandtext);
                        commandtext = "Select IDENT_CURRENT('jc_jchytc_t')";
                        num2 = Convert.ToInt32(Convertor.IsNull(FrmMdiMain.Database.GetDataResult(commandtext), "0"));
                        if (num2 <= 0)
                        {
                            throw new Exception("�����ײ�ͷ�����");
                        }
                        for (int i = 0; i < rowGroup.Length; i++)
                        {
                            commandtext = string.Concat(new object[] { "insert into jc_jchytc_mx(TCID, XMID) values (", num2, ",", Convert.ToInt32(rowGroup[i]["orderid"].ToString()), ")" });
                            FrmMdiMain.Database.DoCommand(commandtext);
                        }
                        FrmMdiMain.Database.CommitTransaction();
                        MessageBox.Show("����ɹ���");
                        TextXmfl_TextChage();
                    }
                    catch (Exception exception)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(this.serchText3.textBox1.Tag.ToString()) !=0) && (MessageBox.Show("�Ƿ�ɾ�����ײͣ�\n\n�ײ����ƣ�" + this.serchText3.textBox1.Text.Trim(), "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No))
            {
                string commandtext = "select * from jc_jchytc_t where id=" + Convert.ToInt32(this.serchText3.textBox1.Tag.ToString());
                DataTable dataTable = FrmMdiMain.Database.GetDataTable(commandtext);
                if ((dataTable.Rows.Count > 0) && !(FrmMdiMain.CurrentUser.IsAdministrator || (Convert.ToInt32(dataTable.Rows[0]["tclx"]) != 0)))
                {
                    MessageBox.Show("��û��Ȩ��ɾ��Ժ��ģ�壡");
                }
                else
                {
                    string[] commandTexts = new string[] { "delete from jc_jchytc_mx where tcid=" + Convert.ToInt32(this.serchText3.textBox1.Tag.ToString()), "delete from jc_jchytc_t where id=" + Convert.ToInt32(this.serchText3.textBox1.Tag.ToString()) };
                    FrmMdiMain.Database.DoCommand(null, null, null, commandTexts);
                    MessageBox.Show("ɾ���ɹ���");
                    SystemLog log = new SystemLog(-1L, (long)FrmMdiMain.CurrentDept.DeptId, (long)FrmMdiMain.CurrentUser.EmployeeId, "ɾ�������ײ�", "ɾ����Ϊ " + this.serchText3.textBox1.Text.Trim() + " ���ײ���Ϣ", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + Environment.MachineName, 6);
                    log.Save();
                    log = null;
                    TextXmfl_TextChage();
                }
            }
        }

        private void btnqx_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkListBox.Items.Count; i++)
            {
                this.chkListBox.SetItemChecked(i, true);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkListBox.Items.Count; i++)
            {
                if (this.chkListBox.GetItemChecked(i) == false)
                {
                    this.chkListBox.SetItemChecked(i, true);
                }
                else this.chkListBox.SetItemChecked(i, false);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex == 3&&dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim()!="�ϼƽ��")
            {
                try
                {

                    int i = int.Parse(e.FormattedValue.ToString());
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                    if (i <= 0)
                    {
                        
                        MessageBox.Show("���������0������");
                        e.Cancel = true;
                    }
                }
                catch
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "��������������";
                    e.Cancel = true;
                    MessageBox.Show("���������0������");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //richTextBoxEx1

            this.BindingContext[((DataTable)this.dataGridView1.DataSource)].EndCurrentEdit();
            DataTable tb = ((DataTable)this.dataGridView1.DataSource);
            //((DataTable)this.dataGridView1.DataSource).data
            #region//�����Ƿ��б걾
            int num;
            string str = "";
            for (num = 0; num <= (this.dataGridView1.Rows.Count - 2); num++)
            {
                if (tb.Rows[num]["bbmc"].ToString().Trim() == "")
                {
                    str += "��" + tb.Rows[num]["name"].ToString().Trim() + "��\r\n";
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num].Cells[2];//MessageBox.Show("�ü�����Ŀû�����ñ걾�����ܱ��棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                //item.sampleCode = item.code;
            }
            if (str != "")
            {
                MessageBox.Show(str + "���ϼ�����Ŀû�����ñ걾�����ܱ��棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.dataGridView1.Focus();
                return;
            }
            #endregion
            string[] GroupbyField ={ "name", "fjsm", "bbmc" };
            string[] ComputeField ={ };
            string[] CField ={ };
            TrasenFrame.Classes.TsSet tsset = new TrasenFrame.Classes.TsSet();
            tsset.TsDataTable = tb;
            DataTable patTb = tsset.GroupTable(GroupbyField, ComputeField, CField, "");
            for (int x = 0; x < patTb.Rows.Count; x++)
            {
                DataRow[] _row = tb.Select("name='" + patTb.Rows[x]["name"].ToString() + "' and fjsm='" + patTb.Rows[x]["fjsm"].ToString() + "' and bbmc='" + patTb.Rows[x]["bbmc"].ToString().Trim() + "'");
                if (_row.Length >= 2)
                {
                    MessageBox.Show("��Ŀ����:[" + patTb.Rows[x]["name"].ToString() + "],����˵��:[" + patTb.Rows[x]["fjsm"].ToString() + "],�걾����:[" + patTb.Rows[x]["bbmc"].ToString() + "] ����" + _row.Length + "����ͬ��ϵͳ�������ظ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            if (typely == Typely.���� && (this.dataGridView1.Rows.Count == 0 || (this.dataGridView1.Rows.Count == 1 && tb.Rows[0]["name"].ToString() == "�ϼƽ��")))
            {
                MessageBox.Show("����û��ѡ�������Ŀ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if(typely==Typely.סԺ)
            {
                if (string.IsNullOrEmpty(richTextBoxEx1.Text.TrimStart().TrimEnd().Trim()))
                {
                    MessageBox.Show("���뵥û����д�������������棬�뽫ҳ��ȫ��������д�������������ύ������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if (string.IsNullOrEmpty(richTextBoxEx1.Text.TrimStart().TrimEnd().Trim()))
                    {
                        richTextBoxEx1.Focus();
                    }
                    return;
                }

                if (this.dataGridView1.Rows.Count-1 <= 0)
                {
                    MessageBox.Show("����û��ѡ�������Ŀ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else if (MessageBox.Show("��ȷ��Ҫ����ҽ����", "��ʾ", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    //this.cmbDept_SelectedIndexChanged(sender, e);
                    //this.lbPrice.Text = "0.00 Ԫ";
                }
                else
                {
                    DataTable dataTable = FrmMdiMain.Database.GetDataTable("select * from vi_zy_vinpatient_all where baby_id=0 and inpatient_id='" + this.BinID + "'");

                    //Add By Tany 2015-07-06 �����ʱ����֤һ�²��˵ķѱ��Ƿ����˱仯������仯��ˢ�µ�û�����
                    #region ��֤�ѱ�仯���
                    //Modify By Tany 2015-03-18 �������try catch������Ļ�����
                    try
                    {
                        TrasenHIS.BLL.Judgeorder jo = new TrasenHIS.BLL.Judgeorder(FrmMdiMain.Database);
                        string strFb = jo.GetLb(dataTable.Rows[0]["inpatient_no"].ToString().Trim());
                        string oldFb = "";
                        bool isChangeFb = false;
                        if (strFb == "�Է�")
                        {
                            if (strFb != fylb)
                            {
                                isChangeFb = true;
                                oldFb = fylb;
                            }
                        }
                        else if (strFb == "����")
                        {
                            if (strFb != fylb)
                            {
                                isChangeFb = true;
                                oldFb = fylb;
                            }
                        }
                        else
                        {
                            if (strFb != fylb)
                            {
                                isChangeFb = true;
                                oldFb = fylb;
                            }
                        }

                        //Modify by jchl (ëë���Է�)
                        //if (isChangeFb )
                        if (isChangeFb && BabyID == 0)
                        {
                            string ts = "�ò��˵ķѱ����仯������\r\n\r\n";
                            ts += "ԭ�ѱ�" + oldFb + "\r\n";
                            ts += "�ַѱ�" + strFb + "\r\n\r\n";
                            ts += "��������׼ȷ�Կ��ǣ��ڵ��ȷ����ϵͳ���˳����沢��������ѡ�е�ҽ����";
                            MessageBox.Show(ts, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (Close != null)
                                Close();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    #endregion

                    #region//�人����ҽԺ(Modify by jchl)
                    if (!tb.Columns.Contains("zfbl".ToUpper()))
                    {
                        tb.Columns.Add("zfbl".ToUpper(), typeof(decimal));
                    }

                    for (int i = 0; i < (this.dataGridView1.Rows.Count - 1); i++)
                    {
                        tb.Rows[i]["zfbl"] = 1;
                        decimal zfbl = 1;
                        if (this.fylb != "" && this.fylb != "�Է�")
                        {
                            int type = 0;
                            if (this.fylb.Contains("����"))
                                type = 1;
                            else
                                type = 2;

                            try
                            {
                                //2,001064725,7935,2,
                                if (!myQuery.GetGfxx(type, _Zyid, tb.Rows[i]["orderid"].ToString(), "2", tb.Rows[i]["name"].ToString(), this.fylb, ref zfbl))
                                {
                                    this.dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                                    continue;
                                }
                                else
                                {
                                    tb.Rows[i]["zfbl"] = zfbl;
                                }
                            }
                            catch (Exception ex)//Modify By Tany 2015-03-18 ���ϲ�����󲢷��أ�����������
                            {
                                MessageBox.Show(ex.Message);
                                this.dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                                continue;
                            }
                        }
                    }
                    #endregion
                  
                    long yzNum = 0L;
                    string str1 = "";
                    bool flag = true;
                    FrmMdiMain.Database.BeginTransaction();
                    yzNum = JYfun.myQuery.GetYzNum(FrmMdiMain.Database, this.BinID);
                    
                    long Dept_Br = Convert.ToInt32(Convertor.IsNull(dataTable.Rows[0]["DEPT_ID"], "0"));
                    int num4 = Convert.ToInt32(Convertor.IsNull(dataTable.Rows[0]["ybjklx"], "0"));
                    int yblx = Convert.ToInt32(Convertor.IsNull(dataTable.Rows[0]["yblx"], "0"));
                    int num6 = Convert.ToInt32(DbQuery.GetBrzt(this.BinID)[1]);
                    try
                    {
                        for (int i = 0; i < (this.dataGridView1.Rows.Count - 1); i++)
                        {

                            //#region//�人����ҽԺ(Modify by jchl)
                            //decimal zfbl = 1;
                            //if (this.fylb != "" && this.fylb != "�Է�")
                            //{
                            //    int type = 0;
                            //    if (this.fylb.Contains("����"))
                            //        type = 1;
                            //    else
                            //        type = 2;

                            //    //2,001064725,7935,2,
                            //    if (!myQuery.GetGfxx(type, _Zyid, tb.Rows[i]["orderid"].ToString(), "2", tb.Rows[i]["name"].ToString(), this.fylb, ref zfbl))
                            //    {
                            //        FrmMdiMain.Database.RollbackTransaction();
                            //        return;
                            //    }
                            //}
                            //#endregion
                            
                            string xmid = "";
                            if (!((!(new SystemCfg(0x1785).Config == "1") || (num4 <= 0)) || JYfun.myQuery.isPP(long.Parse(tb.Rows[i]["orderid"].ToString()), yblx, ref xmid)))
                            {
                                MessageBox.Show(tb.Rows[i]["name"].ToString() + "[" + xmid + "]û�н���ҽ��ƥ�䣬���������룬�����ᱣ�棡");
                            }
                            else
                            {
                                yzNum += 1L;
                                string commandtext = string.Concat(new object[] { 
                                    "INSERT INTO ZY_ORDERRECORD(order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc,HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date,Order_bDate,First_times,Order_Usage,frequency,Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,dwlx,MEMO,MEMO1,jgbm,zsl,zfbl) "
                                   +" VALUES('", PubStaticFun.NewGuid(), "',", yzNum.ToString(), ",'", this.BinID.ToString(), "',", FrmMdiMain.CurrentDept.DeptId, ",'", FrmMdiMain.CurrentDept.WardId, "',1,5,",FrmMdiMain.CurrentUser.EmployeeId, ",", tb.Rows[i]["orderid"].ToString(), ",2,'",tb.Rows[i]["fjsm"].ToString(), 
                                    tb.Rows[i]["name"].ToString(), "',", tb.Rows[i]["sl"].ToString(), ",1,'", tb.Rows[i]["dw"].ToString(), "',GetDate(),"+(this.chcekbl.Checked ? ("'" + ((DateTimePicker)this.Parent.Controls["DtpbeginDate"]).Value.ToString() + "'") : "GetDate()")+",0,'", "", "','',", FrmMdiMain.CurrentUser.EmployeeId, ",0,"+ (this.chcekbl.Checked ? 9 : 0) + ",", this.BabyID.ToString(), ",", (Dept_Br == 0) ? FrmMdiMain.CurrentDept.DeptId :Dept_Br, ",", tb.Rows[i]["zksid"].ToString(), ",", 
                                    tb.Rows[i]["bb"].ToString(), ",'",  tb.Rows[i]["fjsm"].ToString(), "��", this.TextLczd.textBox1.Text.Trim(), "','", this.TextLczd.Text.Trim(), "',", num6, ","+tb.Rows[i]["sl"].ToString()+","+tb.Rows[i]["zfbl"].ToString()+")"
                                 });
                                FrmMdiMain.Database.DoCommand(commandtext);
                                str1 = str1 + tb.Rows[i]["name"].ToString() + "\n";
                            }
                        }
                        FrmMdiMain.Database.CommitTransaction();
                    }
                    catch (Exception exception)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        flag = false;
                        MessageBox.Show("����\n" + exception.ToString() + "\n\n��������ʧ�ܣ�");
                        return;
                    }
                    finally
                    {
                        if (flag)
                        {
                            MessageBox.Show(str1 + "����������ɣ�\n�ɹ�����ҽ����", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        chcekbl.Checked = false;
                       // this.btTJ.Enabled = true;
                    }
                    //this.SelectOne();
                    //this.lbPrice.Text = "0.00 Ԫ";
                    //base.Close();
                }
            }
            if (Close != null)
                Close();
        }
        private int pagecount = 0;
        private int currentpageno = 0;
        private int currentitem = 0;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count - 1 <= 0)
                return;
            this.pagecount = ((this.dataGridView1.Rows.Count-1) / 4) + 1;
            if (((this.dataGridView1.Rows.Count-1) % 4) == 0)
            {
                this.pagecount =( this.dataGridView1.Rows.Count-1) / 4;
            }
            if (this.dataGridView1.Rows.Count - 1 != 0)
            {
                try
                {
                    button3_Click(null, null);
                }
                catch { }

                this.currentpageno = 0;
                this.currentitem = 0;
                this.printDocument1.DocumentName = this.pagecount.ToString();
                this.printDocument1.PrintPage -= new PrintPageEventHandler(this.printDocument1_PrintPage);
                this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
                PrintPreviewDialogEx ex = new PrintPreviewDialogEx();
                ex.Document = this.printDocument1;
                ex.OnPrintDy += new Exdy(this.prdlg_OnPrintDy);
                ex.ShowDialog();
            }
        }
        #region  yaokx 2012-12-03 ���鵥�����ӡ

        private void print()
        {
            string datenow = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString();
            DsJySq.rptAPPDataTable tb = new DsJySq.rptAPPDataTable();
            DataTable dt = (DataTable)this.dataGridView1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = tb.NewRow();
                dr["binname"] = _brxx.brxm;
                dr["sex"] = _brxx.xb;
                dr["age"] = _brxx.nl;
                dr["yqDoc"] = FrmMdiMain.CurrentUser.Name;
                dr["yqDate"] = datenow;
                dr["deptName"] = FrmMdiMain.CurrentDept.DeptName;
                dr["wardName"] = FrmMdiMain.CurrentDept.DeptName;
                dr["bedID"] = _brxx.bedno;
                dr["symptom"] = richTextBoxEx1.Text;
                dr["diagnosis"] = _brxx.lczd;
                if (!dt.Rows[i][1].ToString().Equals("�ϼƽ��"))
                    dr["itemName"] = dt.Rows[i][1].ToString() + "(���ã�" + dt.Rows[i][5].ToString() + "Ԫ)";// chkListBox.CheckedItems;
                dr["inpatientid"] = _brxx.inpatient_no;
                dr["price"] = dt.Rows[i][6].ToString();
                dr["place"] = dt.Rows[i][10].ToString();
                dr["bz"] = dt.Rows[i][7].ToString();
                dr["yymc"] = (new SystemCfg(2)).Config;
                dr["lxmc"] = (Typely.סԺ==typely? "סԺ����":"���ﲡ��") + this.lbCaption.Text.Trim();
                for (int j = 1; j < 7; j++)
                {
                    dr["col" + j.ToString()] = "";
                }

                tb.Rows.Add(dr);
            }
            string printFile = "Zy_��������.rpt";
            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
            rv.ShowDialog();
        }
        #endregion
        public System.Drawing.Brush brush;
        public System.Drawing.Font font;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int num = 0;
            string datenow= DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString();
            this.brush = new SolidBrush(Color.FromArgb(0xec, 0xec, 0xec));
            this.font = new Font("����", 20f, FontStyle.Italic);
            for (int i = 0; i <= 5; i++)
            {
                for (int k = 0; k <= 40; k++)
                {
                    if ((k % 2) == 0)
                    {
                        num = (i * 160) + 30;
                    }
                    else
                    {
                        num = (i * 160) - 30;
                    }
                    e.Graphics.DrawString("�������뵥", this.font, this.brush, (float)num, (float)(k * 0x23));
                }
            }
            string s =  "�������뵥";
            int num4 = 0;
            int num5 = 1;
            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int num8 = Convert.ToInt16((int)((e.MarginBounds.Width - (s.Length * 0x1b)) / 2));
            string commandtext = "select name from jc_employee_property where employee_id=" + FrmMdiMain.CurrentUser.EmployeeId;
            string str3 = FrmMdiMain.Database.GetDataTable(commandtext).Rows[0]["name"].ToString().Trim();
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            for (int j = this.currentitem; j <= (tb.Rows.Count - 2); j++)
            {
                s = tb.Rows[j]["zxksmc"].ToString() + "�������뵥";
                this.brush = new SolidBrush(Color.SteelBlue);
                this.font = new Font("����_GB2312", 20f, FontStyle.Bold);
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(s, this.font, this.brush, (float)(left + num8), (float)(top + num4), StringFormat.GenericTypographic);
                this.brush = new SolidBrush(Color.Black);
                this.font = new Font("����", 11f, FontStyle.Bold);
                e.Graphics.DrawString("������" + _brxx.brxm, this.font, this.brush, (float)left, (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("�Ա�" + _brxx.xb, this.font, this.brush, (float)(130 + left), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("���䣺" + _brxx.nl, this.font, this.brush, (float)(220 + left), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("������" + _brxx.bq, this.font, this.brush, (float)(300 + left), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("���ţ�" + _brxx.bedno, this.font, this.brush, (float)((390 + left) + 80), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("סԺ�ţ�" + _brxx.inpatient_no, this.font, this.brush, (float)((470 + left) + 80), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("�ٴ���ϣ�" + TextLczd.textBox1.Text, this.font, this.brush, (float)left, (float)((100 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("�ͼ�걾��" + tb.Rows[j]["bbmc"].ToString(), this.font, this.brush, (float)(300 + left), (float)((100 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("�������ڣ�" + datenow, this.font, this.brush, (float)(470 + left), (float)((100 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("������Ŀ��" + tb.Rows[j]["name"].ToString(), this.font, this.brush, (float)left, (float)((140 + top) + num4), StringFormat.GenericTypographic);

                e.Graphics.DrawString("����˵����" + tb.Rows[j]["fjsm"].ToString(), this.font, this.brush, (float)(300+left), (float)((140 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("����ҽʦ��" + str3, this.font, this.brush, (float)(470 + left), (float)((190 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawLine(new Pen(Color.Black, 1f), (int)(20 + left), (int)((230 + top) + num4), (int)((left + e.MarginBounds.Width) - 20), (int)((230 + top) + num4));
                if (((j + 1) % 4) == 0)
                {
                    this.currentpageno++;
                    num5++;
                    this.currentitem++;
                    num4 -= num5 * (e.MarginBounds.Bottom - e.MarginBounds.Top);
                    break;
                }
                num4 += 280;
                this.currentitem++;
                if (j == (tb.Rows.Count - 2))
                {
                    this.currentpageno++;
                }
            }
            if (this.pagecount > this.currentpageno)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                return;
            }
            this.brush.Dispose();
            this.font.Dispose();
        }
        private void prdlg_OnPrintDy()
        {
            this.currentitem = 0;
            this.currentpageno = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Close != null)
                Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            print();
        }

        private void chcekbl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcekbl.Checked)
            {
                ((DateTimePicker)this.Parent.Controls["DtpbeginDate"]).Enabled = true;
            }
            else
                ((DateTimePicker)this.Parent.Controls["DtpbeginDate"]).Enabled = false;
        }
    }
    public enum Typely
    {
        סԺ = 1,
        ���� = 2,
    }
    public struct brxx
    {
        public Guid inpatient_id;
        public long baby_id;
        /// <summary>
        /// ��������
        /// </summary>
        public string brxm;
        /// <summary>
        /// �����Ա�
        /// </summary>
        public string xb;
        /// <summary>
        /// ����
        /// </summary>
        public string nl;
        /// <summary>
        /// ����
        /// </summary>
        public string bq;
        /// <summary>
        /// ����
        /// </summary>
        public string bedno;
        /// <summary>
        /// סԺ��
        /// </summary>
        public string inpatient_no;
        /// <summary>
        /// �ٴ����
        /// </summary>
        public string lczd;
    }
    #region �Զ�����
    /// <summary>
    /// �Զ�����
    /// </summary>
    public class Item
    {
        private long _id;
        private string _name;
        private string _unit;
        private string _usage;
        private long _dept;
        private string _pym;
        private string _szm;

        public string Szm
        {
            get { return _szm; }
            set { _szm = value; }
        }
        private string _wbm;

        public string Wbm
        {
            get { return _wbm; }
            set { _wbm = value; }
        }
        private int _code;
        private string _sample;
        private string _bz;
        private int _tempcode;
        private int _FJSMBT;
        private string _zxksmc;
        public Item()
        {
            _id = 0;
            _name = "";
            _unit = "";
            _usage = "";
            _dept = 0;
            _pym = "";
            _szm = "";
            _wbm = "";
            _code = 1;
            _sample = "";
            _bz = "";
            _tempcode = 1;
            _zxksmc = "";
        }
        /// <summary>
        /// ִ�п�������
        /// </summary>
        public string zxksmc
        {
            get { return _zxksmc; }
            set { _zxksmc = value; }
        }
        public int FJSMBT
        {
            get { return _FJSMBT; }
            set { _FJSMBT = value; }
        }

        /// <summary>
        /// ������ĿID
        /// </summary>
        public long orderID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string orderName
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// ������Ŀ��λ
        /// </summary>
        public string orderUnit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        /// <summary>
        /// ������Ŀ�÷�
        /// </summary>
        public string defaultUsage
        {
            get { return _usage; }
            set { _usage = value; }
        }
        /// <summary>
        /// ��Ŀ��ִ�п���
        /// </summary>
        public long execDept
        {
            get { return _dept; }
            set { _dept = value; }
        }
        /// <summary>
        /// ƴ����
        /// </summary>
        public string pym
        {
            get { return _pym; }
            set { _pym = value; }
        }
        /// <summary>
        /// �걾ID
        /// </summary>
        public int code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// �걾����
        /// </summary>
        public string sample
        {
            get { return _sample; }
            set { _sample = value; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string BZ
        {
            get { return _bz; }
            set { _bz = value; }
        }
        /// <summary>
        /// ѡ��ı걾ID
        /// </summary>
        public int sampleCode
        {
            get { return _tempcode; }
            set { _tempcode = value; }
        }
        public override string ToString()
        {
            return _name.Trim();
        }
    }
    #endregion
}
