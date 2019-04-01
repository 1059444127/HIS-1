using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralControls;
using ts_zyhs_classes;
using Ts_zyys_public;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_yj_qf
{
    public partial class FrmYJQF : Form
    {
        public FrmYJQF()
        {
            myFunc = new BaseFunc(InstanceForm._database);
            InitializeComponent();
        }
        #region �Զ������
        private DataView SelectDataView = new DataView();
        SystemCfg cfg29375 = new SystemCfg(29376);
        private DataGridEx GrdSel;
        private int GridWidth = 90;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private DataGridViewTextBoxEditingControl EditingControl;
        public Guid BinID = Guid.Empty;
        public long DeptID = 0;
        public long YS_ID = 0;
        public long DeptID_BR = 0;
        public long BABY_ID = 0;
        private TextBox txtBox = new TextBox();
        public int flag = 0;
        public string fylb = "";//add by chl
        private BaseFunc myFunc;
        private DbQuery myQuery = new DbQuery();
        #endregion

        private void btn_cx_Click(object sender, EventArgs e)
        {
            if (txt_zyh.Text.Trim() == "")
            {
                MessageBox.Show("������סԺ��");
                return;
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = GetInpatientinfo.GetInpatientInfo_zyh(txt_zyh.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.flag = Convert.ToInt32(dt.Rows[0]["FLAG"].ToString());
                        if (this.flag != 3)
                        {
                            MessageBox.Show("�ò����Ѿ���Ժ����δ���䴲λ��");
                            return;
                        }
                        else
                        {
                            lbl_name.Text = dt.Rows[0]["NAME"].ToString();
                            lbl_age.Text = dt.Rows[0]["AGE"].ToString() + "��";
                            lbl_sex.Text = dt.Rows[0]["SEX_NAME"].ToString();
                            lbl_dept.Text = dt.Rows[0]["CUR_DEPT_NAME"].ToString();
                            lbl_zyh.Text = dt.Rows[0]["INPATIENT_NO"].ToString();
                            this.lblbrlx.Text = Convert.ToString(dt.Rows[0]["JSFS_NAME"].ToString()).Trim();
                            if (Convert.ToString(dt.Rows[0]["JSFS_NAME"].ToString()).Trim().IndexOf("ҽ��", 0, Convert.ToString(dt.Rows[0]["JSFS_NAME"].ToString()).Trim().Length) >= 0)
                                this.lblbrlx.Text += "(" + Convert.ToString(dt.Rows[0]["YBLX_NAME"].ToString()).Trim() + ")";
                            if (Convert.ToString(dt.Rows[0]["JSFS_NAME"].ToString()).Trim().IndexOf("�Է�", 0, Convert.ToString(dt.Rows[0]["JSFS_NAME"].ToString()).Trim().Length) >= 0)
                                this.lblbrlx.Text += "(" + Convert.ToString(dt.Rows[0]["BRLX_NAME"].ToString()).Trim() + ")";
                            lblcwh.Text = Convert.ToString(dt.Rows[0]["BED_NO"].ToString()).Trim();
                            this.BinID = new Guid(dt.Rows[0]["INPATIENT_ID"].ToString());
                            this.DeptID = InstanceForm._currentDept.DeptId;
                            this.YS_ID = InstanceForm._currentUser.EmployeeId;
                            this.BABY_ID = Convert.ToInt32(dt.Rows[0]["BABY_ID"].ToString());
                            string[] deptarr = cfg29375.Config.Split(',');
                            foreach (string i in deptarr)
                            {
                                if (InstanceForm._currentDept.DeptId.ToString() == i.ToString())
                                {
                                    this.DeptID_BR = Convert.ToInt32(InstanceForm._currentDept.DeptId.ToString());
                                }
                                else
                                {
                                    this.DeptID_BR = Convert.ToInt32(dt.Rows[0]["DEPT_ID"].ToString());
                                }
                            }
                            refreshdata();
                        }
                    }
                    else
                    {
                        MessageBox.Show("��סԺ�Ų����ڣ�");
                        return;
                    }
                    

                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }
            }
        }

        private void FrmYJQF_Load(object sender, EventArgs e)
        {
            dv_item.AllowUserToDeleteRows = false;
            dv_item.AllowUserToAddRows = false;
            dv_orderitem.AllowUserToDeleteRows = false;
            dv_orderitem.AllowUserToAddRows = false;
            dv_orderitem.AllowUserToDeleteRows = false;
            this.dv_orderitem.ReadOnly = false;
            //DataTable dt = new DataTable();
            //dt = GetOrderItemInfo.GetItem(InstanceForm._currentDept.DeptId.ToString());
            //dv_item.DataSource = dt;
            SelectDataView_getdate();
            InitGrdSel();
        }
        /// <summary>
        /// ��ȡѡ�����
        /// </summary>
        private void SelectDataView_getdate()
        {
            //DataTable dt = new DataTable();
            //dt=GetOrderItemInfo.GetItem(InstanceForm._currentDept.DeptId.ToString());
            //SelectDataView = new DataView(dt.Copy());
        }

        #region ҽ������ѡ�
        /// <summary>
        /// ��ʾѡ�����
        /// </summary>
        /// <param name="SelData"></param>
        /// <param name="mydatagrid1"></param>
        private void ShowOrderSelCard( DataGridView mydatagrid1)
        {
            int nrow, ncol;
            string SelData = "";
            //���ȵõ���ǰ�������Ϣ
            string strFlag="PY_CODE";
            DataTable myTb = ((DataTable)mydatagrid1.DataSource);
            nrow = mydatagrid1.CurrentCell.RowIndex;
            ncol = mydatagrid1.CurrentCell.ColumnIndex;
            SelData = mydatagrid1.CurrentRow.Cells["order_name"].Value.ToString();

            if (SelData != "")
            {
                if (SelData.Substring(SelData.Length - 1, 1) != " ") SelData = "%" + SelData + "%";
            }

            //��ѯ�õ����� ��DATAVIEW ��ɸѡ
            DataView dv = new DataView();
            dv = SelectDataView;
            dv.RowFilter = "(" + strFlag + " like '" + SelData + "')";// Modify By Tany 2009-09-07
            dv.Table.TableName = "mTb";
            GrdSel.TableStyles[0].MappingName = "mTb";
            GrdSel.TableStyles[0].AllowSorting = false;
            GrdSel.TableStyles[0].AlternatingBackColor = Color.AliceBlue;
            GrdSel.BackgroundColor = Color.AliceBlue;
            GrdSel.TableStyles[0].GridColumnStyles.Clear();

            #region ����

            #endregion
            //ƴ���� 13 ��ǰ��1��ʼ
            //by add yaokx 2014-03-03����ҩƷ������������
            //Modify by jchl(��ҽ��ѡ���˵���ֶο��󡢹���ֶ�����һ��)
            string[] GrdMappingName = new string[] { "���", "ҽ������", "����", "�Ը���", "��Ʒ��", "���", "dwhl", "��λ", "����", "s_dw", "kcl", "kcdw", "ƴ��", "ȱ", "����", "deptName", "iscomplex", "default_dept", "type", "������", "��Ŀ����", "ƴ����", "����", "�÷�" };
            string[] GrdHeaderText = new string[] { "", "ҽ������", "����", "�Ը���", "��Ʒ��", "���", "��λ����", "������λ", "��װ����", "��װ��λ", "�����", "��浥λ", "ƴ��", "", "��", "ִ�п���", "�ײ�", "Ĭ�Ͽ���", "ҽ������", "������", "��Ŀ����", "ƴ����", "˵��", "�÷�" };
            int[] GrdWidth ={ 2, 20, 5, 5, 0, 30, 6, 6, 6, 6, 6, 6, 0, 2, 2, 10, 4, 0, 8, 8, 0, 6, 10, 8 };
            //jchl 
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
            int[] Readonly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                //if (GrdMappingName[i].ToString().Trim() == "ѡ")
                //{
                //    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                //    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetGrdSelEnableValues);
                //    GrdSel.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                //}
                //else
                //{
                //    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                //    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetGrdSelEnableValues);
                //    GrdSel.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);

                //}
                ////add by yao kx 2014-04-29 ҽ��¼��ʱ��ҽ��ѡ������и�ֵ
                //(GrdSel.TableStyles[0].GridColumnStyles[i] as DataGridEnableTextBoxColumn).TextBox.Click += new EventHandler(GrdSelTextBox_Click);
            }

            myFunc.InitGridEx(GrdMappingName, GrdHeaderText, GrdWidth, Alignment, Readonly, GrdSel);

            //���ݰ�
            GrdSel.DataSource = null;
            GrdSel.DataSource = dv;
            GrdSel.CaptionText = "ҽ������";
            GrdSel.CurrentRowIndex = 0;

            //int count = (dv.Count > 9) ? 9 : dv.Count;
            //for (int j = 0; j < count; j++)
            //{
            //    dv[j]["���"] = j + 1;
            //}

            //���������λ��
            GrdSel.BringToFront();
            GrdSel.Left = this.panel3.Left + 190 - 16;//mydatagrid1.GetCellBounds(nrow,ncol).Width ;Modify By Tany д�����
            GrdSel.Top = this.panel3.Top + dv_orderitem.GetCellDisplayRectangle(dv_orderitem.CurrentCell.ColumnIndex, dv_orderitem.CurrentCell.RowIndex, false).Top + dv_orderitem.GetCellDisplayRectangle(dv_orderitem.CurrentCell.ColumnIndex, dv_orderitem.CurrentCell.RowIndex, false).Height * 5 / 2;
            //��ʾ���
            GrdSel.Width = 10 * GridWidth + 80 + 22;

            this.GrdSel.Visible = true;
        }




        #endregion
        /// <summary>
        /// �Զ���ѡ�(������)
        /// </summary>
        private void InitGrdSel()
        {
            this.GrdSel = new DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).BeginInit();
            // 
            // GrdSel
            // 
            this.GrdSel.AllowSorting = false;
            this.GrdSel.AlternatingBackColor = Color.AliceBlue;
            this.GrdSel.BackgroundColor = Color.AliceBlue;//System.Drawing.SystemColors.Window;
            this.GrdSel.CaptionVisible = false;
            this.GrdSel.DataMember = "";
            this.GrdSel.HeaderForeColor = Color.Navy;//System.Drawing.SystemColors.ControlText;
            this.GrdSel.HeaderBackColor = Color.Gainsboro;
            this.GrdSel.Location = new System.Drawing.Point(192, 64);
            this.GrdSel.Name = "GrdSel";
            this.GrdSel.Size = new System.Drawing.Size(460, 200);//(408, 200);
            this.GrdSel.RowHeaderWidth = 20;
            this.GrdSel.TabIndex = 0;

            this.GrdSel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.GrdSel.ReadOnly = true;
            this.GrdSel.Visible = false;
            //this.GrdSel.myKeyDown += new myDelegate(this.GrdSel_myKeyDown);
            //this.GrdSel.CurrentCellChanged += new System.EventHandler(this.GrdSel_CurrentCellChanged);
            //this.GrdSel.Paint += new PaintEventHandler(GrdSel_Paint);
            //this.GrdSel.DoubleClick += new EventHandler(GrdSel_DoubleClick);

            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.GrdSel;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "";

            this.Controls.Add(this.GrdSel);
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).EndInit();
        }

        #region �����м����¼�
        private void dv_orderitem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            EditingControl = (DataGridViewTextBoxEditingControl)e.Control;

            EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
        }
        private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int nrow = dv_orderitem.CurrentCell.RowIndex;
            ////string swhere = dv_orderitem.Rows[nrow].Cells["order_name"].Value.ToString().Trim();
            //string swhere = "s";
            //label5.Focus();
            //ShowOrderSelCard(dv_orderitem);
            //int norw = dv_orderitem.CurrentCell.RowIndex;
            //string colname = dv_orderitem.CurrentCell.OwningColumn.Name.ToString();
            //if (colname == "order_name")
            //{
            //    if (e.KeyChar==(char)Keys.Enter)
            //    {
            //        btnGetitem.Focus();
            //        this.btnGetitem.PerformClick();
            //    }
            //}
            this.dv_orderitem.AllowUserToAddRows = false;
        }
        #endregion
        /// <summary>
        /// ����س��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dv_orderitem_KeyDown(object sender, KeyEventArgs e)
        {
            int norw = dv_orderitem.CurrentCell.RowIndex;
            string colname = dv_orderitem.CurrentCell.OwningColumn.Name.ToString();
            if (colname == "order_name")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnGetitem.Focus();
                    this.btnGetitem.PerformClick();
                }
            }
        }




        private void btn_new_Click(object sender, EventArgs e)
        {
            if(dv_item.DataSource==null||dv_item.RowCount<=0)
            {
                MessageBox.Show("δѡ����Ŀ��");
                return;
            }
            if(lbl_name.Text.Trim()=="")
            {
                MessageBox.Show("������סԺ��ָ�����ˣ�");
                return;
            }
            this.fylb = myQuery.GetTsxx(lbl_zyh.Text.Trim());
            //DataTable tempTb = (DataTable)this.dataGrid_TempOrder.DataSource;
            DataTable tempTb = new DataTable();
            tempTb = (DataTable)this.dv_orderitem.DataSource;
            DataRow tempRow = tempTb.NewRow();
            tempRow["order_context"] = dv_item.CurrentRow.Cells["item_name"].Value.ToString();
            tempRow["order_id"] = Guid.Empty;
            tempRow["hoitem_id"] = dv_item.CurrentRow.Cells["item_id"].Value.ToString();
            tempRow["d_code"] = dv_item.CurrentRow.Cells["d_code"].Value.ToString();
            //tempRow["group_id"] = myQuery.GetYzNum(this.BinID, this.DeptID);
            tempRow["Unit"] = dv_item.CurrentRow.Cells["ORDER_UNIT"].Value.ToString();
            tempRow["PRICE"] = dv_item.CurrentRow.Cells["dj"].Value.ToString();
            tempRow["num"] = Convert.ToDecimal("1.00");
            tempRow["sumprice"] = dv_item.CurrentRow.Cells["dj"].Value.ToString();



            #region//�人����ҽԺ(Modify by chl)
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
                    if (!myQuery.GetGfxx(type, lbl_zyh.Text, dv_item.CurrentRow.Cells["item_ID"].Value.ToString(), "2", dv_item.CurrentRow.Cells["item_name"].Value.ToString(), this.fylb, ref zfbl))
                    {
                        return;
                    }
                    else
                    {
                        tempRow["zfbl"] = zfbl;
                    }
                }
                catch (Exception ex)//Modify By Tany 2015-03-18 ���ϲ�����󲢷��أ�����������
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                tempRow["zfbl"]= zfbl;
            }
            #endregion
            //----------------------------------------------------------------------------------------
            int nrow = -1;
            if (dv_orderitem.Rows.Count > 0 && dv_orderitem.DataSource != null)
            {
                nrow = dv_orderitem.Rows.Count - 1;
            }
            tempTb.Rows.InsertAt(tempRow, nrow + 1);


            dv_orderitem.DataSource = tempTb.Copy();
            //dv_orderitem.Rows[nrow+1].DefaultCellStyle.BackColor = Color.Yellow;
            for (int i = 0; i < tempTb.Rows.Count; i++)
            {
                if (dv_orderitem.Rows[i].Cells["order_id"].Value.ToString() != Guid.Empty.ToString())
                {
                    if (tempTb.Rows[i]["cz_flag"].ToString() == "0")
                    {
                        dv_orderitem.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        dv_orderitem.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }

            }
            txt_item.Text = "";
            DataTable dt_clear = (DataTable)this.dv_item.DataSource;
            dt_clear.Rows.Clear();
            this.dv_item.DataSource = dt_clear;
            txt_item.Focus();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dv_orderitem.DataSource != null && dv_orderitem.Rows.Count > 0)
            {
                if (MessageBox.Show("�Ƿ��ύ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    for (int i = 0; i < dv_orderitem.Rows.Count; i++)
                    {
                        if (dv_orderitem.Rows[i].Cells["order_id"].Value.ToString() == Guid.Empty.ToString())
                        {
                            try
                            {
                                Guid order_id_yj = new Guid();
                                order_id_yj = PubStaticFun.NewGuid();
                                string[] BrInfo = Ts_zyys_public.DbQuery.GetBrzt(this.BinID);
                                int BrJgm = Convert.ToInt32(BrInfo[1]);
                                long group_no = myQuery.GetYzNum(this.BinID, this.DeptID);
                                group_no++;
                                InstanceForm._database.BeginTransaction();
                                //1.��ҽ��������
                                string Sql_order = "INSERT INTO ZY_ORDERRECORD(" +
                               "order_id,Group_ID,Inpatient_ID,Dept_ID,MNGTYPE,nType,Order_Doc," +
                               "HOItem_ID,xmly,Order_context,Num,Unit,book_date," +
                               "Order_bDate,First_times," +
                               "Operator,Delete_Bit,baby_id,dept_br,exec_dept,zsl,zfbl,ward_id,jgbm,price)" +
                               " VALUES('" + order_id_yj + "'," + group_no + ",'" + this.BinID.ToString() + "'," + this.DeptID_BR.ToString() + "," + "1" + ",5," + this.YS_ID.ToString() + "," +
                               "" + dv_orderitem.Rows[i].Cells["hoitem_id"].Value.ToString() + ",2,'" + dv_orderitem.Rows[i].Cells["order_context"].Value.ToString() + "','" + dv_orderitem.Rows[i].Cells["num"].Value.ToString() + "','" + dv_orderitem.Rows[i].Cells["unit"].Value.ToString() + "',GetDate()," +
                                "GetDate()" + ",'" + "0" + "'," +
                               "" + this.YS_ID.ToString() + ",1" + "," + this.BABY_ID.ToString() + "," + InstanceForm._currentDept.DeptId.ToString() + "," + InstanceForm._currentDept.DeptId.ToString() + "," + "1" + "," + dv_orderitem.Rows[i].Cells["zfbl"].Value.ToString() + ",'0'" + "," + BrJgm + ",'" + dv_orderitem.Rows[i].Cells["sumprice"].Value.ToString()+"'" + ")";
                                InstanceForm._database.DoCommand(Sql_order);
                                //���ʶ�����ݣ����������ľ���������������ҿ�����ĿID��
                                string sql_yj = string.Format("insert into tb_yjqf(order_id,place) values('{0}','{1}')", order_id_yj,dv_orderitem.Rows[i].Cells["place"].Value.ToString());
                                InstanceForm._database.DoCommand(sql_yj);
                                //3.�������ϸ������

                                //���ȼ������ײͣ����ǵ�����Ŀ
                                string ssql = string.Format(@"SELECT B.TC_FLAG FROM dbo.JC_HOITEMDICTION a INNER JOIN dbo.JC_HOI_HDI b ON a.ORDER_ID=b.HOITEM_ID where a.ORDER_ID='{0}' ", dv_orderitem.Rows[i].Cells["hoitem_id"].Value.ToString());
                                DataTable dtTCORItem = InstanceForm._database.GetDataTable(ssql);
                                string strTC_flag = string.Empty;
                                string strNewID = string.Empty;
                                if (dtTCORItem == null || dtTCORItem.Rows.Count <= 0)
                                {
                                    throw new Exception("��Ŀ����:" + dv_orderitem.Rows[i].Cells["hoitem_id"].Value.ToString() + ",δ�ҵ���Ӧ���շѱ��롾�ײ͡�");
                                }
                                else
                                {
                                    strTC_flag = dtTCORItem.Rows[0]["TC_FLAG"].ToString().Trim();
                                    strNewID = dv_orderitem.Rows[i].Cells["hoitem_id"].Value.ToString();
                                }
                                #region ������ϸ�����ײͣ�
                                //StringBuilder strSQL = new StringBuilder();
                                if (strTC_flag=="1")
                                {
                                    #region ��Ŀʱ�����ײͶ�Ӧ�ķ���

                                    string ssql_tc1 = string.Format(@" SELECT C.ITEM_ID,C.ITEM_CODE,C.ITEM_NAME,C.ITEM_UNIT,
                                                C.COST_PRICE,C.RETAIL_PRICE,C.STATITEM_CODE,C.STD_CODE,
                                                C.SCCJ,C.GG,B.NUM,A.ITEM_ID AS TCID,1 AS TC_FLAG
                                                FROM JC_TC_T A  INNER JOIN JC_TC_MX B ON A.ITEM_ID=B.MAINITEM_ID  
                                                LEFT JOIN JC_HSITEM C ON B.SUBITEM_ID=C.ITEM_ID WHERE  A.ITEM_ID='{0}'", strNewID);

                                    string ssql_tc = string.Format(@" SELECT  e.ITEM_ID,e.ITEM_CODE,e.ITEM_NAME,e.ITEM_UNIT,
                                                                    e.COST_PRICE,e.RETAIL_PRICE,e.STATITEM_CODE,e.STD_CODE,
                                                                    e.SCCJ,e.GG,d.NUM,c.ITEM_ID AS TCID,1 AS TC_FLAG
                                                                    FROM dbo.JC_HOITEMDICTION a
                                                                    INNER JOIN dbo.JC_HOI_HDI b ON a.ORDER_ID=b.HOITEM_ID
                                                                    INNER JOIN dbo.JC_TC_T c ON b.HDITEM_ID=c.ITEM_ID AND b.TC_FLAG=1 INNER JOIN JC_TC_MX d ON c.ITEM_ID=d.MAINITEM_ID
                                                                    left join JC_HSITEM e  on d.SUBITEM_ID=e.ITEM_ID
                                                                    WHERE a.ORDER_ID='{0}' ", strNewID);

                                    DataTable dtTcItem = InstanceForm._database.GetDataTable(ssql_tc);
                                    if (dtTcItem == null || dtTcItem.Rows.Count <= 0)
                                    {
                                        throw new Exception("δ�ҵ�����Ŀ��");
                                    }
                                    else
                                    {
                                        #region ���ײ�ʱ���������ϸ������
                                        string strSQLBuild = string.Empty;
                                        for (int K = 0; K < dtTcItem.Rows.Count; K++)
                                        {
                                            Guid str_ID = PubStaticFun.NewGuid();
                                            Guid str_INPATIENT_ID = this.BinID;
                                            long str_BABY_ID = this.BABY_ID;
                                            Guid str_ORDER_ID = order_id_yj;
                                            Guid str_ORDEREXEC_ID = order_id_yj;
                                            Guid str_PRESCRIPTION_ID = PubStaticFun.NewGuid();//Guid.Empty;
                                            decimal str_PRESC_NO = 0;
                                            DateTime str_PRESC_DATE = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                                            DateTime str_BOOK_DATE = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                                            long str_BOOK_USER = long.Parse(InstanceForm._currentUser.EmployeeId.ToString());
                                            string str_STATITEM_CODE = dtTcItem.Rows[K]["STATITEM_CODE"].ToString().Trim();//����Ŀ����
                                            string str_TCID = dtTcItem.Rows[K]["TCID"].ToString().Trim();
                                            string str_TC_FLAG = "1";
                                            string str_XMID = dtTcItem.Rows[K]["ITEM_ID"].ToString().Trim();
                                            int str_XMLY = 2;
                                            string str_SUBCODE = dtTcItem.Rows[K]["STD_CODE"].ToString().Trim();//��׼����
                                            string str_ITEM_NAME = dtTcItem.Rows[K]["ITEM_NAME"].ToString().Trim();
                                            string str_GG = dtTcItem.Rows[K]["GG"].ToString().Trim();
                                            string str_CJ = dtTcItem.Rows[K]["SCCJ"].ToString().Trim();
                                            string str_UNIT = dtTcItem.Rows[K]["ITEM_UNIT"].ToString().Trim();
                                            decimal str_UNITRATE = 1;
                                            decimal str_COST_PRICE = Convert.ToDecimal(dtTcItem.Rows[K]["COST_PRICE"].ToString().Trim());
                                            decimal str_RETAIL_PRICE = Convert.ToDecimal(dtTcItem.Rows[K]["RETAIL_PRICE"].ToString().Trim());
                                            decimal str_NUM = Convert.ToDecimal(dv_orderitem.Rows[i].Cells["num"].Value.ToString());
                                            decimal str_DOSAGE = 1;
                                            decimal str_SDVALUE = str_NUM * str_RETAIL_PRICE;
                                            decimal str_AGIO = 1;
                                            decimal str_ACVALUE = str_NUM * str_RETAIL_PRICE * str_AGIO;
                                            DateTime str_QDRQ = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                                            int str_CHARGE_BIT = 1; //�շѱ�־
                                            DateTime str_CHARGE_DATE = DateManager.ServerDateTimeByDBType(InstanceForm._database);//�շ�����
                                            int str_CHARGE_USER = int.Parse(InstanceForm._currentUser.EmployeeId.ToString()); ;
                                            int str_DELETE_BIT = 0;
                                            int str_CZ_FLAG = 0;
                                            Guid str_CZ_ID = Guid.Empty;
                                            int str_TYPE = 2;
                                            int str_DISCHARGE_BIT = 0;
                                            Guid str_DISCHARGE_ID = Guid.Empty;
                                            int str_SCBZ = 0;
                                            long str_DOC_ID = long.Parse(InstanceForm._currentUser.EmployeeId.ToString());
                                            long str_DEPT_ID = this.DeptID;
                                            long str_DEPT_BR =this.DeptID_BR;
                                            int str_EXECDEPT_ID = Convert.ToInt32(this.DeptID);

                                            string str_DEPT_LY = "0";//������Դ
                                            Guid str_GROUP_ID = Guid.Empty;
                                            int str_TLFS = 0;
                                            Guid str_APPLY_ID = Guid.Empty;
                                            int str_FY_BIT = 0;
                                            DateTime str_FY_DATE = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                                            int str_FY_USER = 0;
                                            int str_PY_USER = -1;
                                            string str_BZ = "0";
                                            string str_JGBM = "1000";
                                            string str_GCYS = "0";
                                            string str_FYID = "0";//����������ֵ strNewID

                                            // string str_ZFBL = GetitemZFBL(strOLd_InpatientNO, XMLY.ToString(), xmbm, strXMMC, _Database);//�˴�����ҽ��Ŀ¼��¼�Ը����� 2017-04-19 Add by HYD
                                            string str_ZFBL = dv_orderitem.Rows[i].Cells["zfbl"].Value.ToString();//�˴�����ҽ��Ŀ¼��¼�Ը����� 2017-04-19 Add by HYD

                                            string str_YBJS_BIT = "0";
                                            Guid str_YBJS_ID = Guid.Empty;
                                            Guid str_KCID = Guid.Empty;
                                            string str_is_PvsScn = "0";
                                            string str_pvs_xh = "-1";
                                            string str_pvs_zdb = "-1";

                                            strSQLBuild = string.Format(@" INSERT INTO ZY_FEE_SPECI(
                                ID, INPATIENT_ID, BABY_ID, ORDER_ID, ORDEREXEC_ID, PRESCRIPTION_ID, PRESC_NO,PRESC_DATE, BOOK_DATE, BOOK_USER, 
                                STATITEM_CODE, TCID, TC_FLAG, XMID, XMLY, SUBCODE,ITEM_NAME, GG, CJ, UNIT, 
                                UNITRATE, COST_PRICE, RETAIL_PRICE, NUM, DOSAGE, SDVALUE, AGIO, ACVALUE, QDRQ, CHARGE_BIT, 
                                CHARGE_DATE, CHARGE_USER, DELETE_BIT, CZ_FLAG, CZ_ID,TYPE, DISCHARGE_BIT, DISCHARGE_ID, SCBZ, DOC_ID,
                                DEPT_ID, DEPT_BR, EXECDEPT_ID, DEPT_LY,GROUP_ID, TLFS, APPLY_ID, FY_BIT, FY_DATE,FY_USER,
                                PY_USER, BZ, JGBM, GCYS, ZFBL, YBJS_BIT, YBJS_ID, KCID,is_PvsScn,
                                pvs_xh, pvs_zdb  )
                        VALUES ( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',
                                 '{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',
                                 '{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}',
                                 '{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}',
                                 '{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}',
                                 '{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}',
                                 '{60}') ;",
                                            str_ID, str_INPATIENT_ID, str_BABY_ID, str_ORDER_ID, str_ORDEREXEC_ID, str_PRESCRIPTION_ID, str_PRESC_NO, str_PRESC_DATE, str_BOOK_DATE, str_BOOK_USER,
                                            str_STATITEM_CODE, str_TCID, str_TC_FLAG, str_XMID, str_XMLY, str_SUBCODE, str_ITEM_NAME, str_GG, str_CJ, str_UNIT,
                                            str_UNITRATE, str_COST_PRICE, str_RETAIL_PRICE, str_NUM, str_DOSAGE, str_SDVALUE, str_AGIO, str_ACVALUE, str_QDRQ, str_CHARGE_BIT,
                                            str_CHARGE_DATE, str_CHARGE_USER, str_DELETE_BIT, str_CZ_FLAG, str_CZ_ID, str_TYPE, str_DISCHARGE_BIT, str_DISCHARGE_ID, str_SCBZ, str_DOC_ID,
                                            str_DEPT_ID, str_DEPT_BR, str_EXECDEPT_ID, str_DEPT_LY, str_GROUP_ID, str_TLFS, str_APPLY_ID, str_FY_BIT, str_FY_DATE, str_FY_USER,
                                            str_PY_USER, str_BZ, str_JGBM, str_GCYS, str_ZFBL, str_YBJS_BIT, str_YBJS_ID, str_KCID, str_is_PvsScn,
                                            str_pvs_xh, str_pvs_zdb);

                                            //  strSQL += strSQLBuild;
                                            InstanceForm._database.DoCommand(strSQLBuild);
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region  ��Ŀʱ������ñ�
                                    //��Ŀʱ������ñ�
                                    string ssql_xm = string.Format(@"SELECT c.* FROM dbo.JC_HOITEMDICTION a
                                                                    INNER JOIN dbo.JC_HOI_HDI b ON a.ORDER_ID=b.HOITEM_ID
                                                                    INNER JOIN dbo.JC_HSITEM c ON b.HDITEM_ID=c.ITEM_ID AND b.TC_FLAG=0 where a.ORDER_ID='{0}'", strNewID);
                                    DataTable dtTcItem = InstanceForm._database.GetDataTable(ssql_xm);
                                    if (dtTcItem == null || dtTcItem.Rows.Count <= 0)
                                    {
                                        throw new Exception("����סԺ��û���ҵ�������Ժ��Ϣ");
                                    }
                                    else
                                    {
                                        #region ����Ŀʱ���������ϸ������
                                        string strSQLBuild = string.Empty;
                                        for (int K = 0; K < dtTcItem.Rows.Count; K++)
                                        {
                                            Guid str_ID = PubStaticFun.NewGuid();
                                            Guid str_INPATIENT_ID = this.BinID;
                                            long str_BABY_ID = this.BABY_ID;
                                            Guid str_ORDER_ID = order_id_yj;
                                            Guid str_ORDEREXEC_ID = order_id_yj;
                                            Guid str_PRESCRIPTION_ID = PubStaticFun.NewGuid();//Guid.Empty;
                                            decimal str_PRESC_NO = 0;
                                            DateTime str_PRESC_DATE = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                                            DateTime str_BOOK_DATE = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                                            long str_BOOK_USER = long.Parse(InstanceForm._currentUser.EmployeeId.ToString());
                                            string str_STATITEM_CODE = dtTcItem.Rows[K]["STATITEM_CODE"].ToString().Trim();
                                            string str_TCID = "0";
                                            string str_TC_FLAG = "-1";

                                            string str_XMID = dtTcItem.Rows[K]["ITEM_ID"].ToString().Trim();
                                            int str_XMLY = 2;
                                            string str_SUBCODE = dtTcItem.Rows[K]["STD_CODE"].ToString().Trim();//��׼����
                                            string str_ITEM_NAME = dtTcItem.Rows[K]["ITEM_NAME"].ToString().Trim();
                                            string str_GG = dtTcItem.Rows[K]["GG"].ToString().Trim();
                                            string str_CJ = dtTcItem.Rows[K]["SCCJ"].ToString().Trim();
                                            string str_UNIT = dtTcItem.Rows[K]["ITEM_UNIT"].ToString().Trim();
                                            decimal str_UNITRATE = 1;
                                            decimal str_COST_PRICE = Convert.ToDecimal(dtTcItem.Rows[K]["COST_PRICE"].ToString().Trim());
                                            decimal str_RETAIL_PRICE = Convert.ToDecimal(dtTcItem.Rows[K]["RETAIL_PRICE"].ToString().Trim());
                                            decimal str_NUM = Convert.ToDecimal(dv_orderitem.Rows[i].Cells["num"].Value.ToString());
                                            decimal str_DOSAGE = 1;
                                            decimal str_SDVALUE = str_NUM * str_RETAIL_PRICE;
                                            decimal str_AGIO = 1;
                                            decimal str_ACVALUE = str_NUM * str_RETAIL_PRICE * str_AGIO;
                                            DateTime str_QDRQ = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                                            int str_CHARGE_BIT = 1; //�շѱ�־
                                            DateTime str_CHARGE_DATE = DateManager.ServerDateTimeByDBType(InstanceForm._database);//�շ�����
                                            int str_CHARGE_USER = int.Parse(InstanceForm._currentUser.EmployeeId.ToString()); ;
                                            int str_DELETE_BIT = 0;
                                            int str_CZ_FLAG = 0;
                                            Guid str_CZ_ID = Guid.Empty;
                                            int str_TYPE = 2;
                                            int str_DISCHARGE_BIT = 0;
                                            Guid str_DISCHARGE_ID = Guid.Empty;
                                            int str_SCBZ = 0;
                                            long str_DOC_ID = long.Parse(InstanceForm._currentUser.EmployeeId.ToString());
                                            long str_DEPT_ID = this.DeptID;
                                            long str_DEPT_BR = this.DeptID_BR;
                                            int str_EXECDEPT_ID = Convert.ToInt32(this.DeptID);

                                            string str_DEPT_LY = "0";//������Դ
                                            Guid str_GROUP_ID = Guid.Empty;
                                            int str_TLFS = 0;
                                            Guid str_APPLY_ID = Guid.Empty;
                                            int str_FY_BIT = 0;
                                            DateTime str_FY_DATE = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                                            int str_FY_USER = 0;
                                            int str_PY_USER = -1;
                                            string str_BZ = "0";
                                            string str_JGBM = "1000";
                                            string str_GCYS = "0";
                                            string str_FYID = "0";//����������ID 

                                            // string str_ZFBL = GetitemZFBL(strOLd_InpatientNO, XMLY.ToString(), xmbm, strXMMC, _Database);//�˴�����ҽ��Ŀ¼��¼�Ը����� 2017-04-19 Add by HYD

                                            string str_ZFBL = dv_orderitem.Rows[i].Cells["zfbl"].Value.ToString();//�˴�����ҽ��Ŀ¼��¼�Ը����� 2017-04-19 Add by HYD


                                            string str_YBJS_BIT = "0";
                                            Guid str_YBJS_ID = Guid.Empty;
                                            Guid str_KCID = Guid.Empty;
                                            string str_is_PvsScn = "0";
                                            string str_pvs_xh = "-1";
                                            string str_pvs_zdb = "-1";

                                            strSQLBuild = string.Format(@" INSERT INTO ZY_FEE_SPECI(
                                ID, INPATIENT_ID, BABY_ID, ORDER_ID, ORDEREXEC_ID, PRESCRIPTION_ID, PRESC_NO,PRESC_DATE, BOOK_DATE, BOOK_USER, 
                                STATITEM_CODE, TCID, TC_FLAG, XMID, XMLY, SUBCODE,ITEM_NAME, GG, CJ, UNIT, 
                                UNITRATE, COST_PRICE, RETAIL_PRICE, NUM, DOSAGE, SDVALUE, AGIO, ACVALUE, QDRQ, CHARGE_BIT, 
                                CHARGE_DATE, CHARGE_USER, DELETE_BIT, CZ_FLAG, CZ_ID,TYPE, DISCHARGE_BIT, DISCHARGE_ID, SCBZ, DOC_ID,
                                DEPT_ID, DEPT_BR, EXECDEPT_ID, DEPT_LY,GROUP_ID, TLFS, APPLY_ID, FY_BIT, FY_DATE,FY_USER,
                                PY_USER, BZ, JGBM, GCYS, ZFBL, YBJS_BIT, YBJS_ID, KCID,is_PvsScn,
                                pvs_xh, pvs_zdb  )
                       VALUES ( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',
                                 '{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',
                                 '{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}',
                                 '{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}',
                                 '{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}',
                                 '{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}',
                                 '{60}' ) ;",
                                            str_ID, str_INPATIENT_ID, str_BABY_ID, str_ORDER_ID, str_ORDEREXEC_ID, str_PRESCRIPTION_ID, str_PRESC_NO, str_PRESC_DATE, str_BOOK_DATE, str_BOOK_USER,
                                            str_STATITEM_CODE, str_TCID, str_TC_FLAG, str_XMID, str_XMLY, str_SUBCODE, str_ITEM_NAME, str_GG, str_CJ, str_UNIT,
                                            str_UNITRATE, str_COST_PRICE, str_RETAIL_PRICE, str_NUM, str_DOSAGE, str_SDVALUE, str_AGIO, str_ACVALUE, str_QDRQ, str_CHARGE_BIT,
                                            str_CHARGE_DATE, str_CHARGE_USER, str_DELETE_BIT, str_CZ_FLAG, str_CZ_ID, str_TYPE, str_DISCHARGE_BIT, str_DISCHARGE_ID, str_SCBZ, str_DOC_ID,
                                            str_DEPT_ID, str_DEPT_BR, str_EXECDEPT_ID, str_DEPT_LY, str_GROUP_ID, str_TLFS, str_APPLY_ID, str_FY_BIT, str_FY_DATE, str_FY_USER,
                                            str_PY_USER, str_BZ, str_JGBM, str_GCYS, str_ZFBL, str_YBJS_BIT, str_YBJS_ID, str_KCID, str_is_PvsScn,
                                            str_pvs_xh, str_pvs_zdb);

                                            // strSQL += strSQLBuild;
                                            InstanceForm._database.DoCommand(strSQLBuild);
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }

                                #endregion
                                InstanceForm._database.CommitTransaction();
                            }
                            catch (Exception err)
                            {
                                InstanceForm._database.RollbackTransaction();
                                MessageBox.Show(err.Message);
                                return;
                            }
                        }
                    }
                }
                refreshdata();
            }
            else
            {
                MessageBox.Show("û��Ҫ�ύ����Ŀ��");
                return;
            }
            
        }

        private void refreshdata()
        {
            string sql = "";
            DataTable dt = new DataTable();
            sql = string.Format(@"select a.order_id,order_context, hoitem_id,group_id,UNIT,zfbl,ORDER_BDATE,dbo.fun_GetDoctorName(OPERATOR) as OPERATOR,NUM,dbo.FUN_BASE_HOIPRICE(hoitem_id) as PRICE,PRICE as sumprice,a.place,(select top 1 cz_flag  from  ZY_FEE_SPECI where order_id=a.order_id) as cz_flag,(select  d_code from  JC_HOITEMDICTION where order_id=b.hoitem_id) as d_code from  tb_yjqf a  inner join ZY_ORDERRECORD b on a.order_id=b.ORDER_ID where delete_bit=1 and b.INPATIENT_ID='{0}' and EXEC_DEPT='{1}'", this.BinID.ToString(), InstanceForm._currentDept.DeptId.ToString());
            dt = InstanceForm._database.GetDataTable(sql);
            dv_orderitem.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["cz_flag"].ToString() == "0")
                {
                    dv_orderitem.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dv_orderitem.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }


            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dv_orderitem.DataSource != null && dv_orderitem.Rows.Count > 0)
            {
                if (MessageBox.Show("�Ƿ�ɾ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (dv_orderitem.CurrentRow.Cells["order_id"].Value.ToString() != Guid.Empty.ToString())
                    {
                        MessageBox.Show("�÷����Ѿ��ύ����,�޷�ɾ����");
                    }
                    else
                    {
                        dv_orderitem.Rows.Remove(dv_orderitem.CurrentRow);
                    }

                }
            }
            else
            {
                return;
            }


        }

        private void btn_cz_Click(object sender, EventArgs e)
        {
            if (dv_orderitem.DataSource != null && dv_orderitem.Rows.Count > 0)
            {
                try
                {
                    if (dv_orderitem.CurrentRow.Cells["order_id"].Value.ToString() == Guid.Empty.ToString())
                    {
                        MessageBox.Show("����Ŀδ�ύ,δ��������,���ܳ��");
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("�Ƿ���������¼��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            string sql = "";
                            DataTable dt = new DataTable();
                            sql = string.Format(@"select ID,CZ_FLAG  from ZY_FEE_SPECI where order_id='{0}'", dv_orderitem.CurrentRow.Cells["order_id"].Value.ToString());
                            dt = InstanceForm._database.GetDataTable(sql);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["CZ_FLAG"].ToString() == "0")
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        update_czxx(dt.Rows[i]["ID"].ToString());
                                    }
                                    MessageBox.Show("�����ɹ���");
                                    refreshdata();
                                }
                                else
                                {
                                    MessageBox.Show("�÷����ѳ���,�������ظ�������");
                                    return;
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            else
            {
                return;
            }
        }



        private void dv_orderitem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dv_orderitem.DataSource != null)
            {
                int nrow = this.dv_orderitem.CurrentCell.RowIndex;
                if (dv_orderitem.CurrentCell.ColumnIndex == 8)
                {
                    if (IsNumberic(dv_orderitem.CurrentRow.Cells["num"].Value.ToString().Trim()) || dv_orderitem.CurrentRow.Cells["num"].Value.ToString().Trim()=="0.5")
                    {
                        decimal sum = 0;
                        decimal num = Convert.ToDecimal(dv_orderitem.CurrentRow.Cells["num"].Value.ToString().Trim());
                        decimal dj = Convert.ToDecimal(dv_orderitem.CurrentRow.Cells["price"].Value.ToString().Trim());
                        sum = num * dj;
                        dv_orderitem.CurrentRow.Cells["sumprice"].Value = sum;
                    }
                    else
                    {
                        //dv_orderitem.CurrentCell = dv_orderitem[8, nrow];
                        dv_orderitem.Rows[nrow].Cells[8].Selected = true;
                        MessageBox.Show("���������֣�");
                        return;
                    }
                }
            }
        }

        private void update_czxx(string fyid)
        {
            string sql = "select *  from zy_fee_speci  where ID='" + fyid + "'";
            DataTable dt = new DataTable();
            dt = InstanceForm._database.GetDataTable(sql);
            string ITEM_NAME = dt.Rows[0]["ITEM_NAME"].ToString();
            try
            {
                string update_sql = "update zy_fee_speci  set CZ_FLAG=1,item_name='" + ITEM_NAME + "'where ID='" + fyid + "'and CZ_FLAG=0";
                InstanceForm._database.DoCommand(update_sql);


                string insert_sql = string.Format(@"insert into ZY_FEE_SPECI ([ID]
                                                                          ,[INPATIENT_ID]
                                                                          ,[BABY_ID]
                                                                          ,[ORDER_ID]
                                                                          ,[ORDEREXEC_ID]
                                                                          ,[PRESCRIPTION_ID]
                                                                          ,[PRESC_NO]
                                                                          ,[PRESC_DATE]
                                                                          ,[BOOK_DATE]
                                                                          ,[BOOK_USER]
                                                                          ,[STATITEM_CODE]
                                                                          ,[TCID]
                                                                          ,[TC_FLAG]
                                                                          ,[XMID]
                                                                          ,[XMLY]
                                                                          ,[SUBCODE]
                                                                          ,[ITEM_NAME]
                                                                          ,[GG]
                                                                          ,[CJ]
                                                                          ,[UNIT]
                                                                          ,[UNITRATE]
                                                                          ,[COST_PRICE]
                                                                          ,[RETAIL_PRICE]
                                                                          ,[NUM]
                                                                          ,[DOSAGE]
                                                                          ,[SDVALUE]
                                                                          ,[AGIO]
                                                                          ,[ACVALUE]
                                                                          ,[QDRQ]
                                                                          ,[CHARGE_BIT]
                                                                          ,[CHARGE_DATE]
                                                                          ,[CHARGE_USER]
                                                                          ,[DELETE_BIT]
                                                                          ,[CZ_FLAG]
                                                                          ,[CZ_ID]
                                                                          ,[TYPE]
                                                                          ,[DISCHARGE_BIT]
                                                                          ,[DISCHARGE_ID]
                                                                          ,[SCBZ]
                                                                          ,[DOC_ID]
                                                                          ,[DEPT_ID]
                                                                          ,[DEPT_BR]
                                                                          ,[EXECDEPT_ID]
                                                                          ,[DEPT_LY]
                                                                          ,[GROUP_ID]
                                                                          ,[TLFS]
                                                                          ,[APPLY_ID]
                                                                          ,[FY_BIT]
                                                                          ,[FY_DATE]
                                                                          ,[FY_USER]
                                                                          ,[PY_USER]
                                                                          ,[BZ]
                                                                          ,[JGBM]
                                                                          ,[GCYS]
                                                                          ,[ZFBL]
                                                                          ,[YBJS_BIT]
                                                                          ,[YBJS_ID]
                                                                          ,[KCID]
                                                                          ,[is_PvsScn]
                                                                          ,[pvs_xh]
                                                                          ,[pvs_zdb])
                                                                     select NEWID()
                                                                          ,[INPATIENT_ID]
                                                                          ,[BABY_ID]
                                                                          ,[ORDER_ID]
                                                                          ,[ORDEREXEC_ID]
                                                                          ,[PRESCRIPTION_ID]
                                                                          ,[PRESC_NO]
                                                                          ,[PRESC_DATE]
                                                                          ,GETDATE()
                                                                          ,'{1}'
                                                                          ,[STATITEM_CODE]
                                                                          ,[TCID]
                                                                          ,[TC_FLAG]
                                                                          ,[XMID]
                                                                          ,[XMLY]
                                                                          ,[SUBCODE]
                                                                          ,[ITEM_NAME]+'(�ѳ���)'
                                                                          ,[GG]
                                                                          ,[CJ]
                                                                          ,[UNIT]
                                                                          ,[UNITRATE]
                                                                          ,[COST_PRICE]
                                                                          ,[RETAIL_PRICE]
                                                                          ,[NUM]*(-1)
                                                                          ,[DOSAGE]
                                                                          ,[SDVALUE]*(-1)
                                                                          ,[AGIO]
                                                                          ,[ACVALUE]*(-1)
                                                                          ,[QDRQ]
                                                                          ,[CHARGE_BIT]
                                                                          ,GETDATE()
                                                                          ,[CHARGE_USER]
                                                                          ,[DELETE_BIT]
                                                                          ,2
                                                                          ,a.id
                                                                          ,[TYPE]
                                                                          ,[DISCHARGE_BIT]
                                                                          ,[DISCHARGE_ID]
                                                                          ,[SCBZ]
                                                                          ,[DOC_ID]
                                                                          ,[DEPT_ID]
                                                                          ,[DEPT_BR]
                                                                          ,[EXECDEPT_ID]
                                                                          ,[DEPT_LY]
                                                                          ,[GROUP_ID]
                                                                          ,[TLFS]
                                                                          ,[APPLY_ID]
                                                                          ,[FY_BIT]
                                                                          ,[FY_DATE]
                                                                          ,[FY_USER]
                                                                          ,[PY_USER]
                                                                          ,[BZ]
                                                                          ,[JGBM]
                                                                          ,[GCYS]
                                                                          ,[ZFBL]
                                                                          ,[YBJS_BIT]
                                                                          ,[YBJS_ID]
                                                                          ,[KCID]
                                                                          ,[is_PvsScn]
                                                                          ,[pvs_xh]
                                                                          ,[pvs_zdb] from ZY_FEE_SPECI a where ID='{0}'", fyid, InstanceForm._currentUser.EmployeeId);

                InstanceForm._database.DoCommand(insert_sql);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

        }
        private bool IsNumberic(string oText)
        {
            try
            {
                int var1 = Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// ��ǰ�е������Ͳ�λ�Ƿ�ɱ༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void dv_orderitem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dv_orderitem.DataSource == null && dv_orderitem.Rows.Count <= 0)
            {
                return;
            }
            if (dv_orderitem.CurrentRow.Cells["order_id"].Value.ToString() == Guid.Empty.ToString())
            {
                dv_orderitem.CurrentRow.Cells["num"].ReadOnly = false;
                dv_orderitem.CurrentRow.Cells["place"].ReadOnly = false;
            }
            else
            {
                dv_orderitem.CurrentRow.Cells["num"].ReadOnly = true;
                dv_orderitem.CurrentRow.Cells["place"].ReadOnly = true;
            }
        }

        private void txt_item_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                this.AcceptButton = btn_cxxm;
            }

        }

        private void txt_zyh_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.AcceptButton = btn_cx;
            }
        }

        private void btnGetitem_Click(object sender, EventArgs e)
        {
            if (dv_orderitem.RowCount <= 0 || dv_orderitem.DataSource == null)
            {
                MessageBox.Show("δѡ��ɳ���ķ��ü�¼��");
                return;
            }
            string order_id = dv_orderitem.CurrentRow.Cells["order_id"].Value.ToString();
            FrmFYCZ frmfycz = new FrmFYCZ();
            frmfycz.orderid = order_id;
            frmfycz.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter)    //�����س��¼�   
            {
                if (this.dv_orderitem.IsCurrentCellInEditMode)   //�����ǰ��Ԫ���ڱ༭ģʽ   
                {

                    if (this.dv_orderitem.CurrentCell.ColumnIndex == 8)
                    {
                        SendKeys.Send("{Tab}");
                    }
                    if (this.dv_orderitem.CurrentCell.ColumnIndex ==11)
                    {
                        SendKeys.Send("{Tab}");
                    }

                }
                if (this.dv_item.Focused)
                {
                    btn_new_Click(null, null);
                }
            }

            //����ԭ��base.ProcessCmdKey�еĴ���   
            return base.ProcessCmdKey(ref msg, keyData);  
        }

        private void btn_cxxm_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = GetOrderItemInfo.GetItem(InstanceForm._currentDept.DeptId.ToString(), txt_item.Text.ToString().Trim());
            dv_item.DataSource = dt;
            dv_item.Focus();
        }

        private void dv_item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_new_Click(null,null);
        }
    }
}