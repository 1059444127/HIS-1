using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_mz_class.PhysicalExamineCharge.Implement
{
    /// <summary>
    /// �����п����ϵͳ
    /// </summary>
    public class BeiJingZhongKePES : BasePhysicalExaminChargeProcess
    {
        private RelationalDatabase _pesDb = null;
        private RelationalDatabase pesDb
        {
            get
            {
                if ( _pesDb == null )
                {
                    _pesDb = new MsSqlServer();
                    string[] args = new string[4];
                    args[0] = ApiFunction.GetIniString( CONST_NODENAME , CONST_SERVERNAME , ClientWindowIni );
                    args[1] = ApiFunction.GetIniString( CONST_NODENAME , CONST_DBNAME , ClientWindowIni );
                    args[2] = ApiFunction.GetIniString( CONST_NODENAME , CONST_USERID , ClientWindowIni );
                    args[3] = ApiFunction.GetIniString( CONST_NODENAME , CONST_PASSWORD , ClientWindowIni );
                    //��ʼ������
                    string connectionString = "packet size=4096;user id={0};password={1};data source={2};persist security info=True;initial catalog={3}";
                    _pesDb.Initialize( string.Format( connectionString , args[2] , args[3] , args[0] , args[1] ) );
                    _pesDb.Open();
                   
                }
                return _pesDb;
            }
        }
        private string ClientWindowIni = System.Windows.Forms.Application.StartupPath + "\\ClientWindow.ini";
        private const string CONST_NODENAME = "�����п����ϵͳ��������";
        private const string CONST_SERVERNAME = "��������";
        private const string CONST_DBNAME = "���ݿ���";
        private const string CONST_USERID = "�û�ID";
        private const string CONST_PASSWORD = "����";
        /// <summary>
        /// ��ȡѡ��Ĳ���
        /// </summary>
        /// <returns></returns>
        public override PhysicalExaminePatient DoSelectPatient()
        {
            FrmPhysicalExaminePatientList formList = new FrmPhysicalExaminePatientList( this );
            if ( formList.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                return formList.SelectedPatient;
            else
                return null;
        }
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="qc"></param>
        /// <returns></returns>
        public override List<PhysicalExaminePatient> GetPatientList( QueryCondiction qc )
        {
            string sql = "select PatID,VIPID,PatName,Sex,Birth,PTFlag,RegDate,Charge,ChargeFlag from Pat_Info where ChargeFlag=0 and PTFlag='P' ";
            if ( !string.IsNullOrEmpty( qc.ExamineNo ) )
                sql = sql + string.Format( " and PatID='{0}'" , qc.ExamineNo );
            if ( !string.IsNullOrEmpty( qc.FileNo ) )
                sql = sql + string.Format( " and VIPID='{0}'" , qc.FileNo );
            if ( !string.IsNullOrEmpty( qc.Name ) )
                sql = sql + string.Format( " and PatName like '{0}%'" , qc.Name );
            if ( !string.IsNullOrEmpty( qc.Sex ) )
                sql = sql + string.Format( " and Sex='{0}'" , qc.Sex );
            if ( qc.ExamineBeginDate != null )
                sql = sql + string.Format( " and RegDate>='{0} 00:00:00'" , qc.ExamineBeginDate.Value.ToString( "yyyy-MM-dd" ) );
            if ( qc.ExamineEndDate != null )
                sql = sql + string.Format( " and RegDate<='{0} 23:59:59'" , qc.ExamineEndDate.Value.ToString( "yyyy-MM-dd" ) );
            List<PhysicalExaminePatient> list = new List<PhysicalExaminePatient>();
            DataTable tbList = pesDb.GetDataTable( sql );
            foreach ( DataRow row in tbList.Rows )
            {
                PhysicalExaminePatient pat = new PhysicalExaminePatient();
                pat.ExamineNo = Convertor.IsNull( row["PatID"] , "" );
                pat.FileNo = Convertor.IsNull( row["VIPID"] , "" );
                pat.Name = Convertor.IsNull( row["PatName"] , "" );
                pat.ExamineDate = Convert.ToDateTime( row["RegDate"] );
                if ( Convert.IsDBNull( row["Birth"] ) )
                    pat.BornDay = Convert.ToDateTime( row["Birth"] );
                pat.Sex = Convertor.IsNull( row["Sex"] , "δ֪" );
                pat.TotalCost = Convert.ToDecimal( row["Charge"]);
                list.Add( pat );
            }
            return list;
        }
        /// <summary>
        /// ִ�л���
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public override bool ExecPricing( PhysicalExaminePatient patient )
        {
            SystemCfg cfg1146 = new SystemCfg( 1146 , this.Database );
            SystemCfg cfg1148 = new SystemCfg( 1148 , this.Database );
            if ( string.IsNullOrEmpty( cfg1146.Config ) )
                throw new Exception( "��������շѷ������󣬸�����շ���Ҫ���ò���1146" );
            if ( !Convertor.IsNumeric( cfg1146.Config ) )
                throw new Exception( "����1146���ô��󣬱���Ϊ����" );

            if ( string.IsNullOrEmpty( cfg1148.Config ) )
                throw new Exception( "��������շѷ�������û���������ѵ�ִ�п���(����1148)" );
            if ( !Convertor.IsNumeric( cfg1148.Config ) )
                throw new Exception( "����1148���ô��󣬱���Ϊ����" );

            int itemId = Convert.ToInt32( cfg1146.Config );
            DataRow rowChargeItem = this.Database.GetDataRow(string.Format( "select * from jc_hsitemdiction where jgbm={0} and item_id={1}", CurrentDept.Jgbm,itemId ));
            DataRow rowOrdrItem = this.Database.GetDataRow( string.Format( "select * from JC_HOITEMDICTION where ORDER_ID in ( select HOITEM_ID from JC_HOI_HDI where TC_FLAG = 0 and TCID<=0 and HDITEM_ID = {0} )",itemId));

            int tjksdm = Convert.ToInt32( cfg1148.Config ); //�����Ҵ���
            DateTime serverDate = DateManager.ServerDateTimeByDBType( Database );
            Guid brxxid = Guid.Empty;
            Guid ghxxid = Guid.Empty;
            List<Guid> hjids = new List<Guid>();           
            string mzh = "";
            try
            {
                Database.BeginTransaction();
                //���没����Ϣ
                ts_mz_class.YY_BRXX brxx = base.SavePatientInfo( patient );
                //���ɹҺż�¼
                ghxxid = base.SaveRegisterRecord( brxx , tjksdm , 0 , 0 , serverDate , out mzh );
                //���ɻ�������
                classes.hjcf cf = new classes.hjcf();
                #region ...........
                cf.hjid = Guid.Empty;
                cf.jgbm = base.CurrentDept.Jgbm;
                cf.brxxid = brxx.Brxxid;
                cf.ghxxid = ghxxid;
                cf.blh = mzh;
                cf.cfrq = serverDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                cf.hjy = CurrentUser.EmployeeId;
                cf.hjck = "";
                cf.ysdm = 0;
                cf.ksdm = tjksdm;
                cf.zyksdm = 0;
                cf.cfje = patient.TotalCost;
                cf.zxks = tjksdm;
                cf.xmly = 2;
                cf.cfjs = 1;
                cf.byscf = 0;                
                mz_hj.SaveCf( cf , Database );
                if ( cf.err_code != 0 || cf.NewHjid == Guid.Empty )
                    throw new Exception( "���滮������ʧ��:" + cf.err_text );
                hjids.Add( cf.NewHjid );
                #endregion
                //���ɻ�����ϸ
                classes.hjcfmx cfmx = new ts_mz_class.classes.hjcfmx();
                #region .................
                cfmx.hjmxid = Guid.Empty;
                cfmx.hjid = cf.NewHjid;
                cfmx.pym = "";
                cfmx.bm = "";
                cfmx.pm = Convertor.IsNull( rowChargeItem["item_name"] , "" );
                cfmx.spm = Convertor.IsNull( rowChargeItem["item_name"] , "" );
                cfmx.gg = "";
                cfmx.cj = "";
                cfmx.dj = patient.TotalCost;
                cfmx.sl = 1;
                cfmx.dw = Convertor.IsNull( rowChargeItem["item_unit"] , "" );
                cfmx.ydwbl = 1;
                cfmx.js = 1;
                cfmx.je = patient.TotalCost;
                cfmx.tjdxmdm = Convertor.IsNull( rowChargeItem["statitem_code"] , "" );
                cfmx.xmid = itemId;
                cfmx.yl = 1;
                cfmx.yldw = Convertor.IsNull( rowChargeItem["item_unit"] , "" );
                cfmx.pcmc = "";
                cfmx.ts = 1;
                cfmx.zt = "";
                cfmx.pxxh = 1;
                cfmx.tcid = 0;
                cfmx.yzid = Convert.ToInt32( rowOrdrItem["order_id"] );
                cfmx.yzmc = Convertor.IsNull( rowOrdrItem["order_name"] , "" );
                mz_hj.SaveCfmx( cfmx , Database );
                if ( cfmx.err_code != 0 || cfmx.NewHjmxid == Guid.Empty )
                    throw new Exception( "���滮����ϸʧ��" );
                #endregion                
                Database.CommitTransaction();
                
            }
            catch ( Exception error )
            {
                Database.RollbackTransaction();
                throw error;
            }

            string sql = string.Format( "Update Pat_Info set His_RegNo = '{0}' where  ChargeFlag=0 and PTFlag='P' and PatID = '{1}'" , mzh , patient.ExamineNo );
            pesDb.DoCommand( sql );

            InvokeEvent( brxxid , ghxxid , hjids );

            return true;
            
        }
        /// <summary>
        /// ִ���շ�
        /// </summary>
        /// <param name="hjids"></param>
        /// <returns></returns>
        public override bool ExecBalance( List<Guid> hjids )
        {
            //����Ҫʵ�֣��շѴ�����ԭ�����շѽ�����ɣ�
            throw new NotImplementedException();
        }
        public override void SetChargeSuccessfull( Guid ghxxid )
        {
            string sql = string.Format( "select blh from mz_ghxx where ghlb =3 and ghxxid='{0}'" , ghxxid );
            object obj = Database.GetDataResult( sql );
            if ( obj == null )
                throw new Exception( "�������ϵͳ�շ�״̬ʧ�ܣ�û���ҵ����Ǽ���Ϣ" );

            sql = string.Format( "Update Pat_Info set ChargeFlag = 1 where  ChargeFlag=0 and PTFlag='P' and His_RegNo = '{0}'" , obj );
            pesDb.DoCommand( sql );
        }

        public override void ShowConfigUI( BasePhysicalExaminChargeProcess process )
        {
            FrmDBConfig frmDBConfig = new FrmDBConfig( process );           

            frmDBConfig.ShowDialog();
        }

        public override void SaveConfig( string[] args )
        {
            ApiFunction.WriteIniString( CONST_NODENAME , CONST_SERVERNAME , args[0] , ClientWindowIni );
            ApiFunction.WriteIniString( CONST_NODENAME , CONST_DBNAME , args[1] , ClientWindowIni );
            ApiFunction.WriteIniString( CONST_NODENAME , CONST_USERID , args[2] , ClientWindowIni );
            ApiFunction.WriteIniString( CONST_NODENAME , CONST_PASSWORD , args[3] , ClientWindowIni );
        }

        public override string[] LoadConfig()
        {
            string[] args = new string[4];
            args[0] = ApiFunction.GetIniString( CONST_NODENAME , CONST_SERVERNAME , ClientWindowIni );
            args[1] = ApiFunction.GetIniString( CONST_NODENAME , CONST_DBNAME , ClientWindowIni );
            args[2] = ApiFunction.GetIniString( CONST_NODENAME , CONST_USERID , ClientWindowIni );
            args[3] = ApiFunction.GetIniString( CONST_NODENAME , CONST_PASSWORD , ClientWindowIni );
            return args;
        }

        public override bool TestConfig( string[] args )
        {
            RelationalDatabase db = new MsSqlServer();
            try
            {
                string connectionString = "packet size=4096;user id={0};password={1};data source={2};persist security info=True;initial catalog={3}";
                db.Initialize( string.Format( connectionString , args[2] , args[3] , args[0] , args[1] ) );
                db.Open();
                db.Close();
                return true;
            }
            catch ( Exception error )
            {
                return false;
            }
            finally
            {
                db.Dispose();
                db = null;
            }
        }

        public override void SetRefundSuccessfull( object par )
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        
    }
}
