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

namespace ts_yk_tjbb
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class FrmCG_RCQK : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComboBox cmbyjks;
        private Label label6;
        private ComboBox cmbck;
        private Label lblck;
        private RadioButton rdoall;
        private RadioButton rdoysh;
        private RadioButton rdowsh;
        private Label lblrq;
        private DataGridView dataGridView1;
        private Button butexcel;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FrmCG_RCQK(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butexcel = new System.Windows.Forms.Button();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.rdoysh = new System.Windows.Forms.RadioButton();
            this.rdowsh = new System.Windows.Forms.RadioButton();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.lblck = new System.Windows.Forms.Label();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.lblrq = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.rdoall);
            this.groupBox1.Controls.Add(this.rdoysh);
            this.groupBox1.Controls.Add(this.rdowsh);
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.lblck);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.lblrq);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ѯ";
            // 
            // butexcel
            // 
            this.butexcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butexcel.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butexcel.Location = new System.Drawing.Point(738, 46);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(89, 32);
            this.butexcel.TabIndex = 261;
            this.butexcel.Text = "����(&E)";
            this.butexcel.UseVisualStyleBackColor = false;
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // rdoall
            // 
            this.rdoall.AutoSize = true;
            this.rdoall.Location = new System.Drawing.Point(177, 56);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(47, 16);
            this.rdoall.TabIndex = 43;
            this.rdoall.Text = "ȫ��";
            this.rdoall.UseVisualStyleBackColor = true;
            this.rdoall.CheckedChanged += new System.EventHandler(this.rdowsh_CheckedChanged);
            // 
            // rdoysh
            // 
            this.rdoysh.AutoSize = true;
            this.rdoysh.Location = new System.Drawing.Point(101, 56);
            this.rdoysh.Name = "rdoysh";
            this.rdoysh.Size = new System.Drawing.Size(59, 16);
            this.rdoysh.TabIndex = 42;
            this.rdoysh.Text = "�����";
            this.rdoysh.UseVisualStyleBackColor = true;
            this.rdoysh.CheckedChanged += new System.EventHandler(this.rdowsh_CheckedChanged);
            // 
            // rdowsh
            // 
            this.rdowsh.AutoSize = true;
            this.rdowsh.Checked = true;
            this.rdowsh.Location = new System.Drawing.Point(24, 57);
            this.rdowsh.Name = "rdowsh";
            this.rdowsh.Size = new System.Drawing.Size(59, 16);
            this.rdowsh.TabIndex = 41;
            this.rdowsh.TabStop = true;
            this.rdowsh.Text = "δ���";
            this.rdowsh.UseVisualStyleBackColor = true;
            this.rdowsh.CheckedChanged += new System.EventHandler(this.rdowsh_CheckedChanged);
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Location = new System.Drawing.Point(325, 19);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(141, 20);
            this.cmbck.TabIndex = 40;
            // 
            // lblck
            // 
            this.lblck.Location = new System.Drawing.Point(271, 24);
            this.lblck.Name = "lblck";
            this.lblck.Size = new System.Drawing.Size(67, 16);
            this.lblck.TabIndex = 39;
            this.lblck.Text = "�ֿ�����";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(87, 19);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(177, 20);
            this.cmbyjks.TabIndex = 30;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "ҩ������";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(833, 46);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(64, 32);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(576, 118);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(97, 32);
            this.butprint.TabIndex = 10;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(668, 46);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(64, 32);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "ͳ��(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(487, 51);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(142, 21);
            this.dtp2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(469, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "��";
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(325, 51);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(141, 21);
            this.dtp1.TabIndex = 3;
            // 
            // lblrq
            // 
            this.lblrq.Location = new System.Drawing.Point(271, 56);
            this.lblrq.Name = "lblrq";
            this.lblrq.Size = new System.Drawing.Size(67, 16);
            this.lblrq.TabIndex = 44;
            this.lblrq.Text = "�Ǽ�ʱ��";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(944, 23);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 1000;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 413);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ͳ�����";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(938, 393);
            this.dataGridView1.TabIndex = 0;
            // 
            // FrmCG_RCQK
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCG_RCQK";
            this.Text = "�ɹ�������ͳ��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>


		private void Frmxspm_Load(object sender, System.EventArgs e)
		{
			try
			{
                dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
                dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

				//��ʼ��
				//FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");


                Yp.AddCmbYjks(false, InstanceForm.BCurrentDept.DeptId, cmbyjks, InstanceForm.BDatabase);



			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}


		}

		private void buttj_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				this.buttj.Enabled=false;

                int shbz = 0;
                if (rdoysh.Checked == true) shbz = 1;
                if (rdoall.Checked == true) shbz = 2;
				ParameterEx[] parameters=new ParameterEx[6];
                parameters[0].Value = shbz;
				parameters[1].Value=dtp1.Value.ToString()+"";
                parameters[2].Value = dtp2.Value.ToString() + "";
				parameters[3].Value=0;
                parameters[4].Value =Convertor.IsNull(cmbyjks.SelectedValue,"0");

				parameters[0].Text="@shbz";
				parameters[1].Text="@rq1";
				parameters[2].Text="@rq2";
				parameters[3].Text="@ghdw";
                parameters[4].Text = "@deptid";
                parameters[5].Text = "@deptid_ck";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YK_TJ_CG_RCQK", parameters, 30);
				FunBase.AddRowtNo(tb);
				tb.TableName="Tb";
				this.dataGridView1.DataSource=tb;
				this.buttj.Enabled=true;
			}
			catch(System.Exception err)
			{
				this.buttj.Enabled=true;
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
            //try
            //{
            //    string where1 = "";
            //    if (cmbck.Visible == true) where1 = "�ֿ�����:" + cmbck.Text.Trim() + "  ";
            //    where1=where1+"����:" + dtp1.Value.ToShortDateString();
            //    where1=where1+" ��:"+dtp2.Value.ToShortDateString();
            //    where1=where1+"   ҩƷ����:"+cmbyplx.Text;

            //    string title=TrasenFrame.Classes.Constant.HospitalName+"("+cmbyjks.Text.Trim()+")";

            //    title=title+cmbypsx.Text+"ͳ��";

            //    DataTable tb=(DataTable)this.myDataGrid1.DataSource;
            //    ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();

            //    DataRow myrow;
            //    for(int i=0;i<=tb.Rows.Count-1;i++)
            //    {
            //        myrow=Dset.����ҩƷͳ��.NewRow();
            //        myrow["xh"]=Convert.ToInt32(tb.Rows[i]["���"]);
            //        myrow["yppm"]=Convert.ToString(tb.Rows[i]["Ʒ��"]);
            //        myrow["ypspm"]=Convert.ToString(tb.Rows[i]["��Ʒ��"]);
            //        myrow["ypgg"]=Convert.ToString(tb.Rows[i]["���"]);
            //        myrow["sccj"]=Convert.ToString(tb.Rows[i]["����"]);
            //        myrow["lsj"]=Convert.ToString(tb.Rows[i]["���ۼ�"]);
            //        myrow["ypdw"]=Convert.ToString(tb.Rows[i]["��λ"]);
            //        myrow["rksl"]=Convert.ToDecimal(tb.Rows[i]["�����"]);
            //        myrow["cksl"]=Convert.ToString(tb.Rows[i]["������"]);
            //        myrow["kcsl"]=Convert.ToDecimal(tb.Rows[i]["�����"]);
            //        Dset.����ҩƷͳ��.Rows.Add(myrow);
            //    }
            //    ParameterEx[] parameters=new ParameterEx[3];
            //    parameters[0].Text="where1";
            //    parameters[0].Value=where1.Trim();
            //    parameters[1].Text="where2";
            //    parameters[1].Value="";
            //    parameters[2].Text="title";
            //    parameters[2].Value = title.Trim();
            //    TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.����ҩƷͳ��,Constant.ApplicationDirectory+"\\Report\\YP_����ҩͳ��.rpt",parameters);
            //    if (f.LoadReportSuccess) f.Show();else  f.Dispose();
            //}
            //catch(System.Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
		}

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbyplx, InstanceForm.BDatabase);
          

            Yp.AddCmbYjks_ck(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbck, InstanceForm.BDatabase);
            if (cmbck.Items.Count == 1)
            {
                cmbck.Visible = false;
                lblck.Visible = false;
            }
            else
            {
                cmbck.Visible = true;
                lblck.Visible = true;
            }
        }

        private void rdogz_Click(object sender, EventArgs e)
        {
           // DataTable tb = (DataTable)myDataGrid1.DataSource;
           // tb.Rows.Clear();
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                // ����Excel����                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel�޷�����");
                    return;
                }
                // ����Excel������
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // ������������������������������
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count + 1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    colCount = colCount + 1;
                }


                //��ѯ����
                string shzt = " ";
                shzt = rdowsh.Checked == true ? "(δ���)" : "";
                shzt = rdoysh.Checked == true ? "(�����)" : "";
                shzt = rdoall.Checked == true ? "(ȫ��)" : "";

                string swhere = "ҩ������:"+cmbyjks.Text+"    �ֿ�����:"+cmbck.Text +"";
                if (rdowsh.Checked == true) swhere = swhere+" �Ǽ�ʱ��:" + dtp1.Value.ToString() + " �� " + dtp2.Value.ToString();
                if (rdoysh.Checked == true) swhere = swhere+" ���ʱ��:" + dtp1.Value.ToString() + " �� " + dtp2.Value.ToString();
                if (rdoall.Checked == true) swhere = swhere+" �Ǽ�ʱ��:" + dtp1.Value.ToString() + " �� " + dtp2.Value.ToString();

                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "�ɹ�������ͳ��"+shzt;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // ��������
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;
                //xlApp.ActiveCell.FormulaR1C1 = swhere;
                //xlApp.ActiveCell.Font.Size = 20;
                //xlApp.ActiveCell.Font.Bold = true;
                //xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // ������������
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // ��ȡ�б���
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    objData[1, colIndex++] = tb.Columns[i].Caption;
                }
                // ��ȡ����
                objData[0, 0] = swhere;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        //if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width>0)
                        //{
                        if (tb.Columns[j].Caption == "�����")
                            objData[i + 2, colIndex++] = "'" + tb.Rows[i][j].ToString();
                        else
                            objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                        //}
                    }
                    Application.DoEvents();
                }
                // д��Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //���ñ�����Ϊ����Ӧ���
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdowsh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdowsh.Checked == true) lblrq.Text = "�Ǽ�ʱ��";
            if (rdoysh.Checked == true) lblrq.Text = "���ʱ��";
            if (rdoall.Checked == true) lblrq.Text = "�Ǽ�ʱ��";

        }
		
		
	}
}
