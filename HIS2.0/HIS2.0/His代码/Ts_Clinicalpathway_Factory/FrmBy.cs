using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace Ts_Clinicalpathway_Factory
{
    public partial class FrmBy : Form
    {
        public  DataTable tb;
        public string pathway_exe_id = "";
        public string pathway_id = "";
        public string EXE_STEP_ID = "";
        public bool _completePath = false;
        public bool _DialogResult = false;
        public FrmBy()
        {
            InitializeComponent();
            this.gridControl1.DataSource = tb;
        }
        public FrmBy(bool completePath)
        {
            InitializeComponent();
            this.gridControl1.DataSource = tb;
            _completePath = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void FrmBy_Load(object sender, EventArgs e)
        {
            
            tb = PublicFunction.GetVARIANTReason();
            this.gridControl1.DataSource = tb;
            
            
        }

        void ColumnEdit_MouseDown(object sender, MouseEventArgs e)
        {

           // MessageBox.Show("sss");
            tb.Rows[this.gridView1.FocusedRowHandle]["values"] = 2;
            
           
        }

       
         

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            
            //if (e.Column == this.gridColumn2)
            //{
            //    if (e.RowHandle == gridView1.FocusedRowHandle)
            //    {
            //        e.Appearance.ForeColor = Color.DarkRed;
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Appearance.ForeColor = Color.Blue;
            //        e.Handled = true;
            //    }
            //}
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle != gridView1.FocusedRowHandle || e.Column.AbsoluteIndex == gridView1.FocusedColumn.AbsoluteIndex)
            {
                if (e.Column.FieldName == "��������")
                {
                   // e.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    e.Appearance.ForeColor = Color.DarkRed;
                }
                
            }
            
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void gridControl1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void gridControl1_MouseLeave(object sender, EventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //����
            string sql = "insert into PATH_VARIANT_EX ([ID],[PATHWAY_EXE_ID],[EXE_STEP_ID],[Reason],[VARIANT_TYPE_ID] ) values(newid(),'" + pathway_exe_id + "','" + EXE_STEP_ID + "','" + tb.Rows[this.gridView1.FocusedRowHandle]["��������"] + "'," + tb.Rows[this.gridView1.FocusedRowHandle]["VARIANT_TYPE_ID"] + ")";
            FrmMdiMain.Database.DoCommand(sql);
            if (_completePath)
            {
                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    //�׶�ִ�и���״̬ (1:�����,2:������,3:Ԥ��ִ��,4:δִ��)
                    sql = "update   PATH_WAY_EXE_STEP set EXE_STATUS=1,END_DATE=getdate() where EXE_STEP_ID='" + EXE_STEP_ID + "' ";
                    int C = FrmMdiMain.Database.DoCommand(sql);
                    if (C == 0)
                    {
                        MessageBox.Show("���µ�ǰ·���׶�״̬ʧ�ܣ���������");
                        return;
                    }
                    //·����� 1:������2:�����3:�˳�4:��ͣ ,
                    PublicFunction.UpdatePathWayStatus(FrmMdiMain.Database, pathway_exe_id, 2);
                    FrmMdiMain.Database.CommitTransaction();
                    this._DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
                this._DialogResult = true;
                this.Close();
                return;
            }
            this._DialogResult = false;
            this.Close();
        }
    }
}