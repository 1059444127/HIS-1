using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_yzzc
{
	/// <summary>
	/// frmJmcx ��ժҪ˵����
	/// </summary>
	public class frmJmcx : System.Windows.Forms.Form
	{
		//�Զ������
		public DataTable inTb = new DataTable();
        private SystemCfg cfg7161 = new SystemCfg(7161);
        public ArrayList _orderlist;
		bool IsSave = false;
		
		private BaseFunc myFunc;

		private DataGridEx myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btOpenModel;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmJmcx()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//

			myFunc=new BaseFunc();
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.myDataGrid1 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btOpenModel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.AllowSorting = false;
			this.myDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid1.CaptionText = "������Ѫ����";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.Size = new System.Drawing.Size(800, 552);
			this.myDataGrid1.TabIndex = 0;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid1.myKeyDown += new myDelegate(this.myDataGrid1_myKeyDown);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnExit.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnExit.ImageIndex = 4;
			this.btnExit.Location = new System.Drawing.Point(720, 568);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(64, 24);
			this.btnExit.TabIndex = 66;
			this.btnExit.Text = "�˳�(&E)";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnSave.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.ImageIndex = 9;
			this.btnSave.Location = new System.Drawing.Point(648, 568);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(64, 24);
			this.btnSave.TabIndex = 65;
			this.btnSave.Text = "����(&S)";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btOpenModel
			// 
			this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOpenModel.Enabled = false;
			this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btOpenModel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btOpenModel.ImageIndex = 1;
			this.btOpenModel.Location = new System.Drawing.Point(640, 560);
			this.btOpenModel.Name = "btOpenModel";
			this.btOpenModel.Size = new System.Drawing.Size(152, 40);
			this.btOpenModel.TabIndex = 64;
			// 
			// frmJmcx
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(800, 605);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btOpenModel);
			this.Controls.Add(this.myDataGrid1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(808, 632);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(808, 632);
			this.Name = "frmJmcx";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "������Ѫ����";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmJmcx_Closing);
			this.Load += new System.EventHandler(this.frmJmcx_Load);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmJmcx_Load(object sender, System.EventArgs e)
		{
			string[] GrdMappingName={"Inpatient_ID","Baby_ID","����","סԺ��","����","����","ʱ��","ҽ��","ҽ������","��Ѫ�Ѵ���","��Ѫ�ܴ���","dept_br","dept_id"};															
			int[]    GrdWidth =     {0,0,4,9,8,6,6,8,42,10,10,0,0};
			int[]    Alignment     ={0,0,0,0,0,0,0,0,0, 0,0,0,0};
			int[]	 ReadOnly      ={0,0,0,0,0,0,0,0,0, 1,1,0,0};
            //����ʵҽ������
            if (cfg7161.Config.Trim() == "1")
                GrdWidth[8] = 0;
			myFunc.InitGrid(GrdMappingName,GrdWidth,Alignment,ReadOnly,this.myDataGrid1);
            //add by zouchihua 2013-8-27
            if (cfg7161.Config.Trim() == "0")
            {
                int i = 0;
                for (i = 0; i < inTb.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        inTb.Rows[i]["��Ѫ�Ѵ���"] = "1";
                        inTb.Rows[i]["��Ѫ�ܴ���"] = "1";
                    }
                    if (!(i != 0 && inTb.Rows[i]["����"].ToString().Trim() == inTb.Rows[i - 1]["����"].ToString().Trim()))
                    {
                        inTb.Rows[i]["��Ѫ�Ѵ���"] = "1";
                        inTb.Rows[i]["��Ѫ�ܴ���"] = "1";
                    }
                }
                myDataGrid1.DataSource = inTb;
            }
            else
            {
                //��������������Ѫ��
                DataTable tbBfz=new DataTable();
                try
                {
                    tbBfz = FrmMdiMain.Database.GetDataTable("select * from JC_JYBBFLMX_bfl ");
                }
                catch { }
                string tj = "  (";
                for (int i = 0; i < _orderlist.Count; i++)
                {
                    if(i!=_orderlist.Count-1)
                       tj += "'" + _orderlist[i].ToString() + "',";
                    else
                       tj += "'" + _orderlist[i].ToString() + "' )";
                }
                string sql = "select a.ORDER_ID ,CONVERT(varchar,a.ORDER_BDATE,23) sqrq,a.INPATIENT_ID,a.baby_id ,RTRIM(B.ORDER_EXTENSION) �걾����,B.FJSM  ˵��,cast(ISNULL( cast(ISNULL(d.FLID,-B.ID) as  varchar(36) ),a.ORDER_ID ) as varchar(36)) ���� ,"
                           + "  case when B.ORDER_CONTEXT not like '%��%' OR b.ORDER_CONTEXT IS null then   case when a.MEMO like '%��%' then SUBSTRING(a.MEMO,0,CHARINDEX('��',a.memo)) else '' end  else   "
                           + "  (case when a.MEMO like '%��%' then SUBSTRING(a.MEMO,0,CHARINDEX('��',a.memo)) else '' end)+'[��]' end  as ����˵��, "
                           + " b.ORDER_CONTEXT,a.HOITEM_ID YZXMID from ZY_ORDERRECORD a left join ZY_JY_PRINT b on a.ORDER_ID=b.ORDER_ID   "
                           + "  left join JC_ASSAY c on a.HOITEM_ID=c.YZID left join JC_JYBBFLMX d on a.HOITEM_ID=d.YZXMID ";
                sql += " where a.order_id in " + tj;
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                #region//add by zouchihua 2013-6-27 ���ܴ���һ��
                try
                {
                    if (tbBfz.Rows.Count > 0)
                    {
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            //�����Ŀid��tbBfz����
                            DataRow[] row = tbBfz.Select("YZXMID=" + tb.Rows[i]["YZXMID"].ToString() + "");
                            if (row.Length > 0)
                            {
                                for (int j = i; j < tb.Rows.Count; j++)
                                {
                                    if (i != j &&
                                        tb.Rows[i]["INPATIENT_ID"].ToString().Trim() == tb.Rows[j]["INPATIENT_ID"].ToString().Trim() &&
                                        tb.Rows[i]["����"].ToString() == tb.Rows[j]["����"].ToString()
                                        )
                                    {
                                        for (int k = 0; k < row.Length; k++)
                                        {
                                            if (tbBfz.Select("bflid=" + row[k]["bflid"] + "  and  yzxmid=" + tb.Rows[j]["YZXMID"].ToString()).Length > 0)//����������ڷ����� ˵�����ܴ���һ��
                                                //����ͬ����Ÿ�Ϊ��ͬ
                                                tb.Rows[j]["����"] = "-1" + tb.Rows[j]["ORDER_ID"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex) { }
                #endregion
                #region 
                string[] GroupbyField ={ "inpatient_id", "baby_id", "����", "����˵��", "sqrq", "�걾����" };
                string[] ComputeField ={ };
                string[] CField ={ };
                TrasenFrame.Classes.TsSet tsset = new TrasenFrame.Classes.TsSet();
                tsset.TsDataTable = tb;
                DataTable patTb = tsset.GroupTable(GroupbyField, ComputeField, CField, "");
                ArrayList argroup = new ArrayList();
                for (int k = 0; k < patTb.Rows.Count; k++)
                {
                    DataRow[] row = tb.Select(" inpatient_id='" + patTb.Rows[k]["inpatient_id"].ToString() + "' and baby_id=" + patTb.Rows[k]["baby_id"].ToString() + " and ����='" + patTb.Rows[k]["����"].ToString() +
                                   "' and ����˵��='" + patTb.Rows[k]["����˵��"].ToString() + "'  and sqrq='" + patTb.Rows[k]["sqrq"].ToString() + "'  and  �걾����='" + patTb.Rows[k]["�걾����"].ToString() + "'");
                    for (int i = 0; i < row.Length; i++)
                    {
                        row[i]["����"] = 90000 + k + 1;
                    }
                }

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = i; j < tb.Rows.Count; j++)
                    {
                        if (i != j &&
                            tb.Rows[i]["INPATIENT_ID"].ToString().Trim() == tb.Rows[j]["INPATIENT_ID"].ToString().Trim() &&
                            tb.Rows[i]["����"].ToString() == tb.Rows[j]["����"].ToString()
                            &&
                            tb.Rows[i]["YZXMID"].ToString() == tb.Rows[j]["YZXMID"].ToString()
                            // &&(tb.Rows[j]["����˵��"].ToString().Trim()!=""&&  tb.Rows[i]["����˵��"].ToString().Trim() != tb.Rows[j]["����˵��"].ToString().Trim() )  //����˵����һ��Ҫ�ֿ� Mofiby by zouchihua 2013-7-3
                            )
                        {
                            //����ͬ����Ÿ�Ϊ��ͬ
                            tb.Rows[j]["����"] = "-1" + tb.Rows[j]["ORDER_ID"].ToString();
                        }
                    }
                }
                string[] GroupbyField1 ={ "inpatient_id", "baby_id", "����",};
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
                tsset1.TsDataTable = tb;
                DataTable patTbtemp = tsset.GroupTable(GroupbyField1, ComputeField1, CField1, "");
                DataTable newinTb=inTb.Clone();
                string oldinpatientid="";
                string oldbabyid = "";
                //ÿ����Ӧ��ֻ��һ��ҽ��
                for (int j = 0; j < patTbtemp.Rows.Count; j++)
                {
                    if (oldbabyid == "")
                    {
                        DataRow[] row = patTbtemp.Select(" inpatient_id='" + patTbtemp.Rows[j]["inpatient_id"].ToString() + "' and baby_id=" + patTbtemp.Rows[j]["baby_id"].ToString() + " ");
                        inTb.Rows[j]["��Ѫ�Ѵ���"] = "1";
                        inTb.Rows[j]["��Ѫ�ܴ���"] = row.Length.ToString();
                        oldbabyid = patTbtemp.Rows[j]["baby_id"].ToString();
                        oldinpatientid = patTbtemp.Rows[j]["inpatient_id"].ToString();
                        newinTb.Rows.Add(inTb.Rows[j].ItemArray);
                    }
                    else
                        if (oldinpatientid == patTbtemp.Rows[j]["inpatient_id"].ToString() && oldbabyid == patTbtemp.Rows[j]["baby_id"].ToString())
                        {
                            continue;
                        }
                        else
                        {
                            DataRow[] row = patTbtemp.Select(" inpatient_id='" + patTbtemp.Rows[j]["inpatient_id"].ToString() + "' and baby_id=" + patTbtemp.Rows[j]["baby_id"].ToString() + " ");
                            inTb.Rows[j]["��Ѫ�Ѵ���"] = "1";
                            inTb.Rows[j]["��Ѫ�ܴ���"] = row.Length.ToString();
                            oldbabyid = patTbtemp.Rows[j]["baby_id"].ToString();
                            oldinpatientid = patTbtemp.Rows[j]["inpatient_id"].ToString();
                            newinTb.Rows.Add(inTb.Rows[j].ItemArray);
                        }
                     
                }
                #endregion
                myDataGrid1.DataSource = newinTb;

            }

			DataGridCell myCel = new DataGridCell(0,9);
			myDataGrid1.CurrentCell=myCel;
		}

		private void frmJmcx_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(IsSave==false)
				if(MessageBox.Show("���棺�������˳���������ȡ�κξ�����Ѫ���ã����ܻᵼ��©�ѣ�\nȷ�ϲ������˳���","����",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
					e.Cancel=true;
		}

		private bool myDataGrid1_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			long keyInt=Convert.ToInt32(keyData);
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			int ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
			string ColumnName=this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

			if(nrow>=myTb.Rows.Count) 
			{
				btnSave.Focus();
				return true;
			}

			if(ColumnName=="��Ѫ�Ѵ���")		 
			{
				if((keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105) || (keyInt==8) || (keyInt>=37 && keyInt<=40)) return false;

				//��Ч���ж�
				if(keyInt==13)
				{
					try
					{
						this.myDataGrid1.EndEdit(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol],nrow,false);
						if (myTb.Rows[nrow]["��Ѫ�Ѵ���"].ToString()!="")	//ȷ�������˴���
						{														
							if(Convert.ToDouble(myTb.Rows[nrow]["��Ѫ�Ѵ���"].ToString())<0)
							{
								MessageBox.Show(this, "��Ѫ�Ѵ�������Ϊ������", "����", MessageBoxButtons.OK,MessageBoxIcon.Error);								
								myTb.Rows[nrow]["��Ѫ�Ѵ���"]=0;								
							}							
						}
						else
						{
							myTb.Rows[nrow]["��Ѫ�Ѵ���"]=0;
						}
//						if(nrow==myTb.Rows.Count-1)
//						{
//							btnSave.Focus();
//						}
//						else
//						{
							SendKeys.Send("{right}");
//						}
					}
					catch(System.Data.OleDb.OleDbException err)
					{
						MessageBox.Show(err.ToString());
					}
					catch(System.Exception err)
					{
						MessageBox.Show(err.ToString());
					}
				}
			}

			if(ColumnName=="��Ѫ�ܴ���")		 
			{
				if((keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105) || (keyInt==8) || (keyInt>=37 && keyInt<=40)) return false;

				//��Ч���ж�
				if(keyInt==13)
				{
					try
					{
						this.myDataGrid1.EndEdit(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol],nrow,false);
						if (myTb.Rows[nrow]["��Ѫ�ܴ���"].ToString()!="")	//ȷ�������˴���
						{														
							if(Convert.ToDouble(myTb.Rows[nrow]["��Ѫ�ܴ���"].ToString())<0)
							{
								MessageBox.Show(this, "��Ѫ�ܴ�������Ϊ������", "����", MessageBoxButtons.OK,MessageBoxIcon.Error);								
								myTb.Rows[nrow]["��Ѫ�ܴ���"]=0;								
							}							
						}
						else
						{
							myTb.Rows[nrow]["��Ѫ�ܴ���"]=0;
						}
						if(nrow==myTb.Rows.Count-1)
						{
							btnSave.Focus();
						}
						else
						{
							SendKeys.Send("{left}");
							SendKeys.Send("{down}");
						}
					}
					catch(System.Data.OleDb.OleDbException err)
					{
						MessageBox.Show(err.ToString());
					}
					catch(System.Exception err)
					{
						MessageBox.Show(err.ToString());
					}
				}
			}

			return true;
		}

		private void SendTabKey(int num)
		{
			for(int i=0;i<=num-1;i++)
			{
				SendKeys.Send("{tab}");
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{

			if(MessageBox.Show("�Ƿ�ȷ�����澲����Ѫ��ط��ã�","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;

			IsSave=true;
			
			string sSql="";
			string strSql="";
			DataTable myTempTb = new DataTable();
			bool IsErr=false;
			DataTable myTb = (DataTable)myDataGrid1.DataSource;

			//ȡ������Ѫ��
			sSql=@"Select a.order_id,a.order_name,a.order_unit,a.order_type "+
				"from jc_hoitemdiction a,jc_CONFIG b "+
				"where a.order_id=convert(bigint,b.config) and b.id=7015 ";
			DataTable myJTb=InstanceForm.BDatabase.GetDataTable(sSql);

			//ȡ������Ѫ�ܷ�
			sSql=@"Select a.order_id,a.order_name,a.order_unit,a.order_type "+
				"from jc_hoitemdiction a,jc_CONFIG b "+
				"where a.order_id=convert(bigint,b.config) and b.id=7016";
			DataTable myGTb=InstanceForm.BDatabase.GetDataTable(sSql);

			//���û�����þ�����Ѫ�Ѵ��룬���������ҩ��
			if (myJTb.Rows.Count==0 || myJTb==null) 
			{
				MessageBox.Show("û�����þ�����Ѫ�Ѵ��룬���ֹ����뾲����Ѫ�ѣ�","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				IsErr=true;
			}
			else if (myGTb.Rows.Count==0 || myGTb==null) 
			{
				MessageBox.Show("û�����þ�����Ѫ�ܴ��룬���ֹ����뾲����Ѫ�ܷѣ�","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				IsErr=true;
			}
			else					
			{
				decimal v_hoitem_id=Convert.ToDecimal(myJTb.Rows[0]["order_id"].ToString());
				string v_order_context=myJTb.Rows[0]["order_name"].ToString().Trim();
				string v_unit=myJTb.Rows[0]["order_unit"].ToString().Trim();
				int v_order_type=Convert.ToInt32(myJTb.Rows[0]["order_type"].ToString().Trim());

				decimal v_hoitem_id1=Convert.ToDecimal(myGTb.Rows[0]["order_id"].ToString());
				string v_order_context1=myGTb.Rows[0]["order_name"].ToString().Trim();
				string v_unit1=myGTb.Rows[0]["order_unit"].ToString().Trim();
				int v_order_type1=Convert.ToInt32(myGTb.Rows[0]["order_type"].ToString().Trim());

				int i=0;
				int iYZH=0;
								
//				//�������ݷ��ʶ���
//				RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
//				database.Initialize("");
//				database.Open();
//				//��ʼһ������
//				database.BeginTransaction();

				InstanceForm.BDatabase.BeginTransaction();

				try
				{
					for(i=0;i<myTb.Rows.Count;i++)
					{
						if(myTb.Rows[i]["��Ѫ�Ѵ���"].ToString().Trim()!="0" && myTb.Rows[i]["��Ѫ�Ѵ���"].ToString().Trim()!="")
						{
							//ȡ���
							sSql=@"select max(Group_Id) as YZH "+
								"  from Zy_OrderRecord " +
                                " where inpatient_id='" + myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'" +
								"       and baby_id=" + myTb.Rows[i]["baby_id"].ToString().Trim() ;//+
//								"       and mngtype=3";
							myTempTb.Clear();
							myTempTb=InstanceForm.BDatabase.GetDataTable(sSql);
							if ( myTempTb.Rows[0]["YZH"].ToString().Trim()=="") 
							{
								iYZH=0;
							}
							else					
							{
								iYZH=Convert.ToInt32(myTempTb.Rows[0]["YZH"])+1;
							}

							//����ҽ����¼��
                            strSql = @"INSERT INTO ZY_ORDERRECORD( " +
                                "order_id,jgbm,xmly,INPATIENT_ID,Baby_ID,WARD_ID,DEPT_BR,DEPT_ID, " +
                                "MNGTYPE,ORDER_BDATE,GROUP_ID,NTYPE, " +
                                "HOITEM_ID,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_USAGE,FREQUENCY, " +
                                "EXEC_DEPT,FIRST_TIMES,STATUS_FLAG, " +
                                "AUDITING_USER,AUDITING_DATE,OPERATOR,BOOK_DATE,SERIAL_NO ) " +
                                "VALUES('" + PubStaticFun.NewGuid() + "'," + FrmMdiMain.Jgbm + ",2, '" +
                                myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'," + Convert.ToDecimal(myTb.Rows[i]["baby_id"].ToString().Trim()) +
                                ",'" + InstanceForm.BCurrentDept.WardId + "'," + Convert.ToDecimal(myTb.Rows[i]["dept_br"].ToString().Trim()) + "," + Convert.ToDecimal(myTb.Rows[i]["dept_id"].ToString().Trim()) +
                                ",3,getdate()," + iYZH.ToString() + "," + v_order_type + "," +
                                v_hoitem_id + ",'" + v_order_context + "'," + myTb.Rows[i]["��Ѫ�Ѵ���"] + ",1,'" + v_unit + "','',''," +
                                Convert.ToDecimal(myTb.Rows[i]["dept_br"].ToString().Trim()) + ", 1,2," +
                                InstanceForm.BCurrentUser.EmployeeId + ",getdate() ," + InstanceForm.BCurrentUser.EmployeeId + ",getdate(),0)";

							InstanceForm.BDatabase.DoCommand(strSql);
						}
						//Add By Tany 2004-11-13
						if(myTb.Rows[i]["��Ѫ�ܴ���"].ToString().Trim()!="0" && myTb.Rows[i]["��Ѫ�ܴ���"].ToString().Trim()!="")
						{
							//ȡ���
							sSql=@"select max(Group_Id) as YZH "+
								"  from Zy_OrderRecord " +
                                " where inpatient_id='" + myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'" +
								"       and baby_id=" + myTb.Rows[i]["baby_id"].ToString().Trim() ;//+
//								"       and mngtype=3";
							myTempTb.Clear();
							myTempTb=InstanceForm.BDatabase.GetDataTable(sSql);
							if ( myTempTb.Rows[0]["YZH"].ToString().Trim()=="") 
							{
								iYZH=0;
							}
							else					
							{
                                iYZH = Convert.ToInt32(myTempTb.Rows[0]["YZH"]) + 1;
							}

							//����ҽ����¼��
                            strSql = @"INSERT INTO ZY_ORDERRECORD( " +
                                "order_id,jgbm,xmly,INPATIENT_ID,Baby_ID,WARD_ID,DEPT_BR,DEPT_ID, " +
                                "MNGTYPE,ORDER_BDATE,GROUP_ID,NTYPE, " +
                                "HOITEM_ID,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_USAGE,FREQUENCY, " +
                                "EXEC_DEPT,FIRST_TIMES,STATUS_FLAG, " +
                                "AUDITING_USER,AUDITING_DATE,OPERATOR,BOOK_DATE,SERIAL_NO ) " +
                                "VALUES( '" + PubStaticFun.NewGuid() + "'," + FrmMdiMain.Jgbm + ",2,'" +
                                myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'," + myTb.Rows[i]["baby_id"].ToString().Trim() +
                                ",'" + InstanceForm.BCurrentDept.WardId + "'," + Convert.ToDecimal(myTb.Rows[i]["dept_br"].ToString().Trim()) + "," + Convert.ToDecimal(myTb.Rows[i]["dept_id"].ToString().Trim()) +
                                ",3,getdate()," + iYZH.ToString() + "," + v_order_type1 + "," +
                                v_hoitem_id1 + ",'" + v_order_context1 + "'," + myTb.Rows[i]["��Ѫ�ܴ���"] + ",1,'" + v_unit1 + "','',''," +
                                Convert.ToDecimal(myTb.Rows[i]["dept_br"].ToString().Trim()) + ", 1,2," +
                                InstanceForm.BCurrentUser.EmployeeId + ",getdate() ," + InstanceForm.BCurrentUser.EmployeeId + ",getdate(),0)";

							InstanceForm.BDatabase.DoCommand(strSql);
						}
					}	
					
					InstanceForm.BDatabase.CommitTransaction();
				}
				catch(Exception err)
				{
					InstanceForm.BDatabase.RollbackTransaction();

					//д������־ Add By Tany 2005-01-12
					SystemLog _systemErrLog=new SystemLog(-1,InstanceForm.BCurrentDept.DeptId,InstanceForm.BCurrentUser.EmployeeId,"�������","���澲����Ѫ���ô���"+err.Message+"  Source��"+err.Source,DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase),1,"��������"+System.Environment.MachineName,39);
					_systemErrLog.Save();
					_systemErrLog=null;

					MessageBox.Show("���󣺽�������Ѫ��ط��ò�����ʱ�˵��������ֹ����ɾ�����Ѫ��ط��ã�\nϵͳ��"+err.Message,"��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					IsErr=true;
				}
				
//				database.Close();
				
			}

			if(IsErr==false)
				MessageBox.Show("�Ѿ��ɹ����ɾ�����Ѫ��ط�����ʱ�˵���","�ɹ�",MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.Close();
		}
	}
}
