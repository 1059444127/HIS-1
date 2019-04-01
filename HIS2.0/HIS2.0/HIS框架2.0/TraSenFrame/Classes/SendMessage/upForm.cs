using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes.SendMessage
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class upForm : System.Windows.Forms.Form
	{
		
		private bool openwindow=true;
		private DataTable dt=new DataTable();
		private System.Drawing.Icon tempIcon;
		/// <summary>
		/// �����û�ID
		/// </summary>
		public long YS=0;
		/// <summary>
		/// ��������ID
		/// </summary>
		public long DeptID=0;
		/// <summary>
		/// ��Ϣ�������ͣ�0=����ģ�� 1= 2= 3=(ϵͳģ��ID)��
		/// </summary>
		public int mtype=0;
		/// <summary>
		/// �����������ʾ���ʱ��
		/// </summary>
		public int JGSJ=-1;
		/// <summary>
		/// IP��ַ
		/// </summary>
		public static string AddressIP=Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
		/// <summary>
		/// ��������
		/// </summary>
		public string WardID="";
		/// <summary>
		/// �Ƿ񵯳���Ϣ��
		/// </summary>
		public static bool IsUp=true;
		/// <summary>
		/// �Ƿ������ʾ������Ϣ
		/// </summary>
		public static bool IsOpen=false;
		/// <summary>
		/// ��Ϣ����
		/// </summary>
		public static string title="";


		private System.Windows.Forms.Timer timer1;//����ͼ����˸
		private System.Windows.Forms.Timer timer2;//���Ƶ������ڿ�ʼ�ر�
		private System.Timers.Timer timer3;//������Ϣ����ʾ
		private System.Windows.Forms.Timer timer4;//�������ڿ����ض�̬����
		private System.Windows.Forms.Timer timer5;//����֪ͨ����Ϣ��ʵʱ��ʾ
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;	
		/// <summary>
		/// GroupBox�ؼ�
		/// </summary>
		public System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel linkLabel1;		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		/// <summary>
		/// LinkLabel�ؼ�
		/// </summary>
		public System.Windows.Forms.LinkLabel Lk;
		
		
		private System.ComponentModel.IContainer components;
		
		/// <summary>
		/// upForm��ժҪ˵��
		/// </summary>
		/// <param name="MessageStr">upForm�ı���</param>
		/// <param name="deptID">����ID</param>
		/// <param name="operate">����Ա</param>
		/// <param name="type">��Ϣ���ͣ���������0=����ģ�� 1=  2=  3=  ����(ʹ��ģ��ID)��</param>
		/// <param name="interval">�����ļ��ʱ��</param>
		/// <param name="icon">Ҫ��˸��ͼ��</param>
		/// <return></return>
		public upForm(string MessageStr,long deptID,long operate,int type,int interval,Icon icon)
		{
			//
			// Windows ���������֧���������
			//
			
			InitializeComponent();  
			
			this.groupBox1.Text=MessageStr.Trim();
			this.DeptID=deptID;
			this.YS=operate;
			this.mtype=type;	
			this.JGSJ=interval;
			this.Icon=icon;
		
			
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}
		/// <summary>
		/// upForm��ժҪ˵��
		/// </summary>
		/// <param name="MessageStr">upForm�ı���</param>
		/// <param name="wardID">����ID</param>
		/// <param name="operate">����Ա</param>
		/// <param name="type">��Ϣ���ͣ���������0=����ģ�� 1=  2=  3=  ����(ʹ��ģ��ID)��</param>
		/// <param name="interval">�����ļ��ʱ��</param>
		public upForm(string MessageStr,string wardID,long operate,int type,int interval)
		{
			
			InitializeComponent();  
			
			this.groupBox1.Text=MessageStr.Trim();
			this.WardID=wardID;
			this.YS=operate;
			this.mtype=type;	
			this.JGSJ=interval;	
		}

		/// <summary>
		/// upForm��ժҪ˵��
		/// </summary>
		public upForm()
		{
			InitializeComponent();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(upForm));
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.Lk = new System.Windows.Forms.LinkLabel();
			this.timer4 = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer5 = new System.Windows.Forms.Timer(this.components);
			this.timer3 = new System.Timers.Timer();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timer3)).BeginInit();
			this.SuspendLayout();
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "�ر�(&X)";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Interval = 4000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(208, 80);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.Lk);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 17);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(202, 60);
			this.panel1.TabIndex = 2;
			this.panel1.Click += new System.EventHandler(this.mClick);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(168, 45);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(29, 17);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "�ر�";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Lk
			// 
			this.Lk.Location = new System.Drawing.Point(9, 4);
			this.Lk.Name = "Lk";
			this.Lk.Size = new System.Drawing.Size(184, 32);
			this.Lk.TabIndex = 2;
			this.Lk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lk_LinkClicked);
			// 
			// timer4
			// 
			this.timer4.Interval = 30;
			this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "��Ϣ";
			this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
			// 
			// timer5
			// 
			this.timer5.Enabled = true;
			this.timer5.Interval = 3000;
			this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
			// 
			// timer3
			// 
			this.timer3.Interval = 30000;
			this.timer3.SynchronizingObject = this;
			this.timer3.Elapsed += new System.Timers.ElapsedEventHandler(this.timer3_Elapsed);
			// 
			// upForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(208, 80);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "upForm";
			this.Opacity = 0.8;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "��Ϣ";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.upFrom_Load);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.timer3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

//		/// <summary>
//		/// Ӧ�ó��������ڵ㡣
//		/// </summary>
//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new upForm("��Ϣ",6,0,2,10000,new System.Drawing.Icon(System.Environment.CurrentDirectory+"\\123.ico")));
//		}
		
 		

		private void upFrom_Load(object sender, System.EventArgs e)
		{	
			tempIcon=this.notifyIcon1.Icon;
			this.Text=System.DateTime.Now.ToString();
			this.Height=0;
			this.Opacity=0;			
			if(JGSJ>0) this.timer3.Interval=JGSJ;
			this.WindowState=System.Windows.Forms.FormWindowState.Normal;
			this.notifyIcon1.Visible=false;
		}

		//��˸ͼ��
		private void timer1_Tick(object sender, System.EventArgs e)
		{			
			if(this.notifyIcon1.Icon==tempIcon) this.notifyIcon1.Icon=this.Icon;
			else this.notifyIcon1.Icon=tempIcon;
		}
		private void menuItem1_Click(object Sender, EventArgs e) 
		{
			IsOpen=false;
			this.notifyIcon1.Visible=false;
			this.timer1.Enabled=false;
		}
	
		//��ʼ�رմ���
		private void timer2_Tick(object sender, System.EventArgs e)
		{
			this.timer2.Enabled=false;
			this.openwindow=false;
			this.timer4.Enabled=true;			
		}

		//���رա���ť�¼�
		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{		
			IsOpen=false;

			this.notifyIcon1.Visible=false;	
			this.timer1.Enabled=false;

			this.openwindow=false;
			this.timer4.Enabled=true;	
		}

		private void Lk_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			mClick(null,null);		
		}
		// ��ʾ��Ϣ		
		private  void ShowXX()
		{			
			//�Ƿ�������Ϣ
			if(SendMessageClass.NewMessage==true)
			{
				this.notifyIcon1.Visible=true;
				this.timer1.Enabled=true;
				
				Lk.Text=title;
				Lk.LinkBehavior=System.Windows.Forms.LinkBehavior.HoverUnderline;
				Lk.Top=15;
				Lk.Left=5;	

				this.Height=0;
				this.Top=System.Windows.Forms.Screen.AllScreens[0].Bounds.Height-28;
				this.Left=System.Windows.Forms.Screen.AllScreens[0].Bounds.Width-218;
				this.openwindow=true;
				this.Opacity=0.8;
				this.TopMost=true;
				this.TopLevel=true;
				this.timer4.Enabled=true;
				this.timer2.Enabled=true;	
			}
		}
		
		private void timer3_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if(!(IsOpen && SendMessageClass.AcceptMessage)) 
			{
				this.notifyIcon1.Visible=false;	
				this.timer1.Enabled=false;
				return;
			}				
			else 
			{	
				ShowXX();
			}		
		}
		//��Ϣ��֪ͨ��ʵʱ��ʾ
		private void timer5_Tick(object sender, System.EventArgs e)
		{	
			if(SendMessageClass.AcceptMessage==true)
			{
				//����Ϣ
				if(IsUp )
				{		
					ShowXX();
					IsUp=false;
					timer3.Enabled=true;
				}
				//��֪ͨ
				if(SendMessageClass.NewInFormation==true)
				{
					SendMessageClass.NewInFormation=false;;
					dt=upForm.selMessage(SendMessageType.֪ͨ,mtype,DeptID);
					if(dt!=null)
					{
						FrmInform fi=new FrmInform(title);
						fi.dt=dt;
						fi.ShowDialog();
					}
				}
			}
		
		}

		//���ڿ����ض�̬����
		private void timer4_Tick(object sender, System.EventArgs e)
		{
			if(openwindow==true)//��
			{
				if(this.Height<80) 
				{
					this.Height+=4;
					this.Top-=4;
				}
				else this.timer4.Enabled=false;				
			}
			else//��
			{
				if(this.Opacity>0) 
				{
					this.Opacity-=0.02;
				}
				else 
				{
					this.timer4.Enabled=false;
				}
			}
		}
		private DataTable selMessage(SendMessageType sType) 
		{			
			DataTable myTb=new DataTable();
			string sSql="";
			try
			{
				sSql="SELECT A.Title ����, Content ����,inform ֪ͨ���� ,case flag when 0 then 'δ��' else '�Ѷ�' end ״̬ , A.ID,Bdate ����ʱ��, edate ����ʱ�� "+
					"FROM MZ_MESSAGE A INNER JOIN MZ_MESSAGE_DEPT B ON B.P_ID = A.ID AND mtype in (0,"+mtype.ToString()+") AND bdate<'" +DateTime.Now.ToString("yyyy-MM-dd")+ " 00:00:00' AND edate >'" +DateTime.Now.ToString("yyyy-MM-dd")+ " 23:59:59' ";
				switch(sType.ToString())
				{						
					case "��Ϣ":									
						if(this.WardID.Trim()=="")
						{							
							sSql+="WHERE XTYPE=0 and (B.dept_id = 0 OR B.dept_id = "+DeptID.ToString()+") order by Bdate";
						}
						else 
						{
							sSql+="WHERE XTYPE=0 and (B.dept_id = 0 OR B.dept_id in (select dept_id from base_wardrdept where ward_id='"+WardID.Trim()+"')) order by Bdate";
						}
						break;
					case "֪ͨ":
						if(this.WardID.Trim()=="")
						{
							sSql+="WHERE XTYPE=1 and (B.dept_id = 0 OR B.dept_id = "+DeptID.ToString()+") order by Bdate";
						}
						else 
						{
							sSql+="WHERE XTYPE=1 and (B.dept_id = 0 OR B.dept_id in (select dept_id from base_wardrdept where ward_id='"+WardID.Trim()+"')) order by Bdate";
						}
						break;
					default:
						sSql+="WHERE B.dept_id = 0 order by Bdate";	
						break;			
				}
				myTb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
				return myTb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"������ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Error);		
				return null;
			}
		}
		/// <summary>
		/// ��ȡ��Ϣ�б�
		/// </summary>
		/// <param name="sType">��Ϣ���ͣ�֪ͨ����Ϣ��</param>
		/// <param name="MessageType">��Ϣ�Ĺ������ͣ�0=����ģ�� 1= 2=  3= ϵͳģ��ID��</param>
		/// <param name="deptID">��Ϣ�����Ŀ���ID</param>
		/// <param name="ipAddress">��Ϣ�����Ļ���IP��ַ</param>
		/// <returns></returns>
		public static DataTable selMessage(SendMessageType sType,int MessageType,long deptID) 
		{
			DataTable myTb=new DataTable();
			string sSql="";
			try
			{
				sSql="SELECT A.Title ����, Content ����,inform ֪ͨ����,case flag when 0 then 'δ��' else '�Ѷ�' end ״̬ , A.ID,Bdate ����ʱ��, edate ����ʱ��,A.tlsj "+
					"FROM MZ_MESSAGE A INNER JOIN MZ_MESSAGE_DEPT B ON B.P_ID = A.ID AND mtype in (0,"+MessageType.ToString()+") AND bdate< '" + DateTime.Now.ToString("yyyy-MM-dd") + "  00:00:00' AND edate > '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59' ";
				switch(sType.ToString())
				{						
					case "��Ϣ":									
												
						sSql+="WHERE XTYPE=0 and (B.dept_id = 0 OR B.dept_id = "+deptID.ToString()+") and (B.ip_address='' OR B.ip_address='"+AddressIP+"') order by book_date";
						
						break;
					case "֪ͨ":
						
						sSql+="WHERE XTYPE=1 and (B.dept_id = 0 OR B.dept_id = "+deptID.ToString()+") and (B.ip_address='' OR B.ip_address='"+AddressIP+"') order by book_date";
						
						break;
					default:
						sSql+="WHERE B.dept_id = 0 order by book_date";	
						break;			
				}
				myTb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
				return myTb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"������ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Error);		
				return null;
			}
		}

		/// <summary>
		/// ��ȡ��Ϣ�б�
		/// </summary>
		/// <param name="xType">��Ϣ���ͣ�1=֪ͨ��0=��Ϣ��</param>
		/// <returns></returns>
		public static DataTable selMessage(int xType) 
		{
			DataTable myTb=new DataTable();
			string sSql="";
			try
			{
				sSql="SELECT A.Title ����, Content ����,inform ֪ͨ����,case flag when 0 then 'δ��' else '�Ѷ�' end ״̬ ,A.ID,Bdate ����ʱ��, edate ����ʱ��,A.tlsj "+ 
                     "FROM (select * from MZ_MESSAGE where xtype="+xType+" and bdate<'" +DateTime.Now.ToString("yyyy-MM-dd") + "' 00:00:00' AND edate >'" +DateTime.Now.ToString("yyyy-MM-dd")+ " 23:59:59') A "+ 
                     "     INNER JOIN "+
	                 "     MZ_MESSAGE_DEPT B ON B.P_ID = A.ID  "+
	                 "     INNER JOIN "+
                     "     (Select dtype,d_dept_id,d_user from MZ_IPINFORMATION where use_flag=1 and IP_ADDRESS='"+upForm.AddressIP+"') C on A.mtype in (0,C.dtype) ";
				myTb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
				return myTb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"������ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Error);		
				return null;
			}
		}
		/// <summary>
		/// ��ȡ��Ϣ�б�
		/// </summary>
		/// <param name="xType">��Ϣ���ͣ�1=֪ͨ��0=��Ϣ��</param>
		/// <param name="level">��Ϣ����0=��ͨ��1=ϵͳ��</param>
		/// <returns></returns>
		public static DataTable selMessage(int xType,short level) 
		{
			DataTable myTb=new DataTable();
			string sSql="";
			try
			{
				sSql="SELECT A.Title ����, Content ����,inform ֪ͨ����,case flag when 0 then 'δ��' else '�Ѷ�' end ״̬ ,A.ID,Bdate ����ʱ��, edate ����ʱ��,A.tlsj "+ 
					"FROM (select * from MZ_MESSAGE where xtype="+xType+" and level="+level+" and bdate<'" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00' AND edate >'" +DateTime.Now.ToString("yyyy-MM-dd")+ " 23:59:59') A "+ 
					"     INNER JOIN "+
					"     MZ_MESSAGE_DEPT B ON B.P_ID = A.ID  "+
					"     INNER JOIN "+
					"     (Select dtype,d_dept_id,d_user from MZ_IPINFORMATION where use_flag=1 and IP_ADDRESS='"+upForm.AddressIP+"') C on A.mtype in (0,C.dtype) ";
				myTb=TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sSql);
				return myTb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString(),"������ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Error);		
				return null;
			}
		}

		private void notifyIcon1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Left) mClick(null,null);
			else return;
		}

		/// <summary>
		/// ����Ϣ��ѯ����																																												
		/// </summary>
		private void mClick(object sender, System.EventArgs e)
		{
			SendMessageClass.NewMessage=false;
			dt=selMessage(SendMessageType.��Ϣ);
			if(dt!=null)
			{
				FrmMessage fm=new FrmMessage();
				fm.myTb=dt;
				fm.YS=YS;
				fm.Show();			
				fm.Activate();
			}
			this.notifyIcon1.Visible=false;	
			this.timer1.Enabled=false;

			this.timer2.Enabled=false;
			this.openwindow=false;
			this.timer4.Enabled=true; 
		}

		
//		/// <summary>
//		/// ��ʾupForm
//		/// </summary>	
//		/// <param name="MessageStr">upForm�ı���</param>
//		/// <param name="wardID">����ID</param>
//		/// <param name="operate">����Ա</param>
//		/// <param name="type">��Ϣ���ͣ�������</param>
//		/// <param name="interval">�����ļ��ʱ��</param>
//		/// <param name="formicon">��˸��ͼ��</param>
//		/// <returns></returns>	
//		public static void showupform(string MessageStr,string wardID,long operate,int type,int interval,System.Drawing.Icon formicon)
//		{
//			upForm uf=new upForm();
//			uf.groupBox1.Text=MessageStr.Trim();
//			uf.WardID=wardID;
//			uf.YS=operate;
//			uf.mtype=type;	
//			uf.JGSJ=interval;
//			if(formicon!=null) uf.Icon=formicon;
//			uf.Show();
//			
//		}

		
	}

}
