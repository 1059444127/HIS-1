using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SystemUpdate
{
	/// <summary>
	/// Frmflash ��ժҪ˵����
	/// </summary>
	public class Frmflash : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public Frmflash()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

        public Frmflash(string message)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.label1.Text = message;
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
            this.components = new System.ComponentModel.Container( );
            this.label1 = new System.Windows.Forms.Label( );
            this.timer1 = new System.Windows.Forms.Timer( this.components );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.label1.Font = new System.Drawing.Font( "����" , 18F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point( 16 , 32 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 337 , 24 );
            this.label1.TabIndex = 0;
            this.label1.Text = "���ڻ�ȡ�����ļ�,���Ժ�...";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler( this.timer1_Tick );
            // 
            // Frmflash
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size( 360 , 96 );
            this.ControlBox = false;
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frmflash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout( false );
            this.PerformLayout( );

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Refresh();
		}
	}
}
