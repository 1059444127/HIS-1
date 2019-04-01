using System;
using System.Data;
using System.Collections;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
namespace ts_jc_yzxmwh
{
	/// <summary>
	/// ��������
	/// </summary>
	public enum OP_TYPE
	{
		������Ŀ = 1,
		������Ŀ = 2,
		ͣ����Ŀ = 3,
		������Ŀ = 4
	}
	/// <summary>
	/// ChargeItem ��ժҪ˵����
	/// </summary>
	public class OrderItem : ICloneable
	{
		/// <summary>
		/// ʵ������Ŀ
		/// </summary>
		public OrderItem()
		{
			_order_id = 0;
			_order_name = "";
			_py_code = "";
			_wb_code = "";
            _d_code = "";
			_order_unit = "";
			_order_type_id = 0;
			_order_type_name = "";
			_delete_bit = 0;

            _fjsmbt = byte.Parse("0");//2012-11-21 ���� ����˵������
			_execdeptList = new ArrayList();


		}
		/// <summary>
		/// ����ָ�����ʵ������Ŀ
		/// </summary>
		/// <param name="ItemId"></param>
		public OrderItem(int OrderID)
		{
			try
			{
                // sql ������� �����շ���Ŀ�Ƿ���ɾ��
                string sql = @"select a.*,b.name,c.hditem_id,c.tc_flag,c.num ,e.yzid,e.jclxid,f.bbid,f.hylxid 
                        ,(select top 1 DELETE_BIT from 
                        (
                           (select DELETE_BIT from jc_hsitem  where ITEM_ID =c.hditem_id and c.TC_FLAG=0)
                           union
                           (select DELETE_BIT from jc_tc_t  where ITEM_ID =c.HDITEM_ID and c.TC_FLAG=1)
                        ) as aa) as DELETE_BIT_sfxm
                        from jc_hoitemdiction a  left join jc_ordertype b on a.order_type=b.code left join jc_hoi_hdi c on a.order_id=c.hoitem_id  
                        left join jc_jc_item e on a.order_id=e.yzid  left join jc_assay f on a.order_id=f.yzid where a.order_id = " + OrderID;
				DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
				if ( dr != null )
				{
					_order_id = OrderID;
					_order_name = Convert.IsDBNull(dr["order_name"]) ? "":dr["order_name"].ToString().Trim();
					_py_code = Convert.IsDBNull(dr["py_code"]) ? "":dr["py_code"].ToString().Trim();
					_wb_code = Convert.IsDBNull( dr["wb_code"]) ? "" : dr["wb_code"].ToString().Trim();
					_order_unit = Convert.IsDBNull(dr["order_unit"]) ? "" : dr["order_unit"].ToString();
					_order_type_id = Convert.IsDBNull(dr["order_type"]) ? 0 : Convert.ToInt32( Convertor.IsNull( dr["order_type"], "0" ) );
					_order_type_name = Convert.IsDBNull(dr["name"]) ? "" : Convertor.IsNull( dr["name"],"") ;
					_delete_bit = Convert.IsDBNull( dr["delete_bit"]) ? 0 : Convert.ToInt32( Convertor.IsNull( dr["delete_bit"],"0"));
					_default_exec_dept = Convert.ToInt32( Convertor.IsNull( dr["default_dept"],"0"));
					_usage = Convert.IsDBNull(dr["default_usage"]) ? "" : dr["default_usage"].ToString().Trim();
					_item_exec_num = Convert.IsDBNull( dr["num"] ) ? 1 : Convert.ToInt32( dr["num"] );
					bz = Convert.IsDBNull(dr["bz"]) ? "" : dr["bz"].ToString().Trim();
                    _d_code = Convert.IsDBNull(dr["d_code"]) ? "" : dr["d_code"].ToString().Trim();
                    //2012-11-21 ���� ����˵������
                    if ( Convert.IsDBNull(dr["FJSMBT"])==false && dr["FJSMBT"].ToString()=="1" ) _fjsmbt=byte.Parse( "1");

                    else _fjsmbt = byte.Parse("0");
                    _sfxm_delete_bit =int.Parse(  Convert.IsDBNull(dr["DELETE_BIT_sfxm"]) ? "0" : dr["DELETE_BIT_sfxm"].ToString().Trim());
					if ( dr["hditem_id"] != null && !Convert.IsDBNull(dr["hditem_id"]))
					{
						_charge_item_id = Convert.IsDBNull(dr["hditem_id"]) ? 0 : Convert.ToInt32( dr["hditem_id"] );
						_match_type = Convert.IsDBNull(dr["tc_flag"]) ? 0 : Convert.ToInt32( dr["tc_flag"] );
						if ( _match_type == 0 )
							sql = "select item_name from jc_hsitem where item_id=" + _charge_item_id;
						else
							sql = "select item_name from jc_tc_t where item_id=" + _charge_item_id;

						DataRow drItem = InstanceForm.BDatabase.GetDataRow(sql);
						if ( drItem != null )
							_charge_item_name = Convert.IsDBNull(drItem[0]) ? "" : drItem[0].ToString().Trim();
						else
							_charge_item_name = "";
					}
					else
					{
						_charge_item_id = 0 ;
					}
					_execdeptList = new ArrayList();
					DataTable tableDept = this.GetExecDeptDataTable();
					for ( int i=0;i<tableDept.Rows.Count;i++)
					{
						TrasenFrame.Classes.Department dept = new TrasenFrame.Classes.Department();
						dept.DeptId = Convert.IsDBNull(tableDept.Rows[i]["dept_id"]) ? 0 : Convert.ToInt32(tableDept.Rows[i]["dept_id"]);
						dept.DeptName = Convert.IsDBNull(tableDept.Rows[i]["name"]) ? "" : tableDept.Rows[i]["name"].ToString().Trim();
						if ( dept.DeptId == _default_exec_dept ) 
							dept.Default = 1;
						_execdeptList.Add( dept );
					}
					//�ж��Ǽ�黹�ǻ�����Ŀ
					this.isJCorHy = 0;
                    //////////////////////
					sql = "select * from jc_jc_item where yzid=" + OrderID;
					DataRow drTmp = InstanceForm.BDatabase.GetDataRow( sql );
					if ( drTmp != null ) isJCorHy = 1;
					sql = "select * from jc_assay where yzid=" + OrderID;
					drTmp = InstanceForm.BDatabase.GetDataRow( sql );
					if ( drTmp != null ) isJCorHy = 2;
                    this.jclx = Convert.IsDBNull(dr["jclxid"]) ? 0 : Convert.ToInt32(dr["jclxid"]);
                    // this.sample = Convert.IsDBNull(dr["bbid"]) ? "" : dr["bbid"].ToString().Trim();
                    this.sample = Convert.IsDBNull(dr["bbid"]) ? 0 : Convert.ToInt32(dr["bbid"]);
                    this.hylx = Convert.IsDBNull(dr["hylxid"]) ? 0 : Convert.ToInt32(dr["hylxid"]);
				}
				else
				{
					throw new Exception("û�ж�Ӧ��ҽ����Ŀ");
				}
			}
			catch(Exception err)
			{
				throw new Exception("OrderItem()/r/n" + err.Message);
			}
		}
		#region ����
		/// <summary>
		/// ��Ŀ���
		/// </summary>
		private int _order_id;
		/// <summary>
		/// ����
		/// </summary>
		private string _order_name;
		/// <summary>
		/// ƴ����
		/// </summary>
		private string _py_code;
		/// <summary>
		/// �����
		/// </summary>
		private string _wb_code;
        /// <summary>
        ///  ������
        /// </summary>
        private string _d_code;
		/// <summary>
		/// ��λ
		/// </summary>
		private string _order_unit;
		/// <summary>
		/// ҽ�����ͱ��
		/// </summary>
		private int _order_type_id;
		/// <summary>
		/// ҽ����������
		/// </summary>
		private string _order_type_name;
		/// <summary>
		/// �Ƿ�ɾ��
		/// </summary>
		private int _delete_bit;
		/// <summary>
		/// ִ�п���
		/// </summary>
		private ArrayList _execdeptList;
		/// <summary>
		/// �÷�
		/// </summary>
		private string _usage;
		/// <summary>
		/// Ĭ��ִ�п���
		/// </summary>
		private int _default_exec_dept;
		/// <summary>
		/// ��Ӧ�շ���Ŀ
		/// </summary>
		private int _charge_item_id;
		/// <summary>
		/// ��Ӧ���շ���Ŀ����
		/// </summary>
		private string _charge_item_name;

		/// <summary>
		/// ��Ӧ��ʽ (0-���շ���Ŀ��Ӧ��1-���ײ���Ŀ��Ӧ)
		/// </summary>
		private int _match_type;
		/// <summary>
		/// �շ���Ŀִ�д���
		/// </summary>
		private int _item_exec_num;
		/// <summary>
		/// ��黹�ǻ�����Ŀ
		/// </summary>
		private int isJCorHy;
		/// <summary>
		/// �������
		/// </summary>
		private int jclx;
		/// <summary>
		/// ԤԼ���
		/// </summary>
		private int bookingBit;
		/// <summary>
		/// ��������
		/// </summary>
		private int hylx;
		/// <summary>
		/// ����
		/// </summary>
		private int sample;
		/// <summary>
		/// ��ע
		/// </summary>
		private string bz;
        /// <summary>
        /// 2012-11-21 ���� ����˵������
        /// </summary>
        private byte _fjsmbt;
        /// <summary>
        /// 2012-11-21 ���� ����˵������
        /// </summary>
        public byte FJSMBT
        {
            get
            {
                return _fjsmbt;
            }
            set
            {
                _fjsmbt = value;
            }
        }
        /// <summary>
        /// ��Ӧ���շ���Ŀ �Ƿ���ɾ�� 2012-12-16 ����
        /// </summary>
        private int _sfxm_delete_bit;
        /// <summary>
        /// ��Ӧ���շ���Ŀ �Ƿ���ɾ�� 2012-12-16 ����
        /// </summary>
        public int sfxm_delete_bit
        {
            get
            {
                return _sfxm_delete_bit;
            }
            set
            {
                _sfxm_delete_bit = value;
            }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        /// 
		public string BZ
		{
			get
			{
				return bz;
			}
			set
			{
				bz = value;
			}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int Sample
		{
			get
			{
				return sample;
			}
			set
			{
				sample =value;
			}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int HYLX
		{
			get
			{
				return hylx;
			}
			set
			{
				hylx = value;
			}
		}
		/// <summary>
		/// ԤԼ���
		/// </summary>
		public int BookingBit
		{
			get
			{
				return bookingBit;
			}
			set
			{
				bookingBit = value;
			}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int JCLX
		{
			get
			{
				return jclx;
			}
			set
			{
				jclx = value;
			}
		}
		/// <summary>
		/// ��黹�ǻ�����Ŀ(0�� 1-��� 2-����)
		/// </summary>
		public int IsJCorHY
		{
			get
			{
				return isJCorHy;
			}
			set
			{
				isJCorHy = value;
			}
		}
		/// <summary>
		/// ��Ӧ���շ���Ŀ����
		/// </summary>
		public string ChargeItemName
		{
			get
			{
				return _charge_item_name;
			}
			set
			{
				_charge_item_name = value;
			}
		}
		/// <summary>
		/// �շ���Ŀִ�д���
		/// </summary>
		public int ItemExecNum
		{
			get
			{
				return _item_exec_num;
			}
			set
			{
				_item_exec_num = value;
			}
		}
		/// <summary>
		/// ��Ӧ��ʽ (0-���շ���Ŀ��Ӧ��1-���ײ���Ŀ��Ӧ)
		/// </summary>
		public int MatchType
		{
			get
			{
				return _match_type;
			}
			set
			{
				_match_type = value;
			}
		}
		/// <summary>
		/// Ĭ��ִ�п���
		/// </summary>
		public int DefaultExecDept
		{
			get
			{
				return _default_exec_dept;
			}
			set
			{
				_default_exec_dept = value;
			}
		}
		/// <summary>
		/// ��Ӧ�շ���Ŀ
		/// </summary>
		public int ChargeItemId
		{
			get
			{
				return _charge_item_id;
			}
			set
			{
				_charge_item_id = value;
			}
		}
		/// <summary>
		/// �÷�
		/// </summary>
		public string Usage
		{
			get
			{
				return _usage;
			}
			set
			{
				_usage = value;
			}
		}
		/// <summary>
		/// ��Ŀ���
		/// </summary>
		public int Order_Id
		{
			get
			{
				return _order_id;
			}
			set
			{
				_order_id = value;
			}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Order_Name
		{
			get
			{
				return _order_name;
			}
			set
			{
				_order_name = value;
			}
		}
		/// <summary>
		/// ƴ����
		/// </summary>
		public string Py_Code
		{
			get
			{
				return _py_code;
			}
			set
			{
				_py_code = value;
			}
		}
		/// <summary>
		/// �����
		/// </summary>
		public string Wb_Code
		{
			get
			{
				return _wb_code;
			}
			set
			{
				_wb_code = value;
			}
		}
        /// <summary>
		/// ������
		/// </summary>
		public string D_Code
		{
			get
			{
                return _d_code;
			}
			set
			{
                _d_code = value;
			}
		}
		/// <summary>
		/// ��λ
		/// </summary>
		public string Order_Unit
		{
			get
			{
				return _order_unit;
			}
			set
			{
				_order_unit = value;
			}
		}
        
		/// <summary>
		/// ��Ч���
		/// </summary>
		public int Delete_Bit
		{
			get
			{
				return _delete_bit;
			}
			set
			{
				_delete_bit = value;
			}
		}
		/// <summary>
		/// ִ�п��Ҽ���
		/// </summary>
		public ArrayList ExecDeptList
		{
			get
			{
				return _execdeptList;
			}
			set
			{
				_execdeptList = value;
			}
		}
		/// <summary>
		/// ҽ�����ͱ��
		/// </summary>
		public int OrderTypeID
		{
			get
			{
				return _order_type_id;
			}
			set
			{
				_order_type_id = value;
			}
		}
		/// <summary>
		/// ҽ����������
		/// </summary>
		public string OrderTypeName
		{
			get
			{
				return _order_type_name;
			}
			set
			{
				_order_type_name= value;
			}
		}
		#endregion
		/// <summary>
		///  ����
		/// </summary>
		/// <returns></returns>
		public bool Save(OP_TYPE OpType)
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

			try
			{
				string sql = "";
				InstanceForm.BDatabase.BeginTransaction();

				if ( OpType == OP_TYPE.������Ŀ)
				{
					//�����¼�¼
                    sql = "insert into jc_hoitemdiction ( order_name,order_unit,order_type,default_usage,default_dept,py_code,wb_code,bz,FJSMBT,d_code)";
					sql+= " values ('" + _order_name + "','" + _order_unit + "'," + _order_type_id + ",'" + _usage + "'," +_default_exec_dept+ ",'"+_py_code+"','"+_wb_code+"','"+bz+"',"+ _fjsmbt.ToString() +",'"+_d_code+"')";
					object obj;
					InstanceForm.BDatabase.InsertRecord( sql,out obj);
					_order_id = Convert.ToInt32(obj);

				}	
				if ( OpType == OP_TYPE.������Ŀ )
				{
					sql = "update jc_hoitemdiction set order_name='" + _order_name + "',order_unit='" + _order_unit + "',order_type=" + _order_type_id + ",default_usage='" + _usage + "',default_dept=" + _default_exec_dept + ",py_code='" + _py_code + "',wb_code='" + _wb_code + "',bz='"+bz+"',FJSMBT=" + _fjsmbt.ToString() + ",d_code='"+_d_code+"'";
					sql += " where order_id=" + _order_id;
					InstanceForm.BDatabase.DoCommand( sql );
				}
				//ִ�п���
				sql = "delete from jc_hoi_dept where order_id = " + _order_id;
				InstanceForm.BDatabase.DoCommand( sql );
				for ( int i=0;i< _execdeptList.Count; i ++)
				{
					sql = "insert into jc_hoi_dept ( order_id,exec_dept ) values (" + _order_id + "," + ((TrasenFrame.Classes.Department)_execdeptList[i]).DeptId + ")";
					InstanceForm.BDatabase.DoCommand( sql );
				}
				//���շ���Ŀ��Ӧ
				sql = "delete from jc_hoi_hdi where hoitem_id=" + _order_id ;
				InstanceForm.BDatabase.DoCommand( sql );
				if ( _match_type == 1 )
				{
					if ( _charge_item_id != 0 )
					{
						sql = "insert into jc_hoi_hdi ( hoitem_id,hditem_id,num,tc_flag,tcid ) values (" + _order_id + "," +_charge_item_id+ ","+_item_exec_num+",1," + _charge_item_id + ")";
						InstanceForm.BDatabase.DoCommand( sql );
					}
				}
				else
				{
					if ( _charge_item_id != 0 )
					{
						sql = "insert into jc_hoi_hdi ( hoitem_id,hditem_id,num,tc_flag,tcid ) values (" + _order_id + "," +_charge_item_id+ ","+_item_exec_num+",0,-1)";
						InstanceForm.BDatabase.DoCommand( sql );
					}
				}
				//ͬ�����¼�黯���
				sql = "delete from jc_jc_item where yzid=" + _order_id;
				InstanceForm.BDatabase.DoCommand( sql );
				sql = "delete from jc_assay where yzid="+ _order_id;
				InstanceForm.BDatabase.DoCommand( sql );
				if ( this.isJCorHy == 1 )
				{
					sql = "insert into jc_jc_item(yzid,jclxid) values (" + _order_id + "," +jclx+ ")";
					InstanceForm.BDatabase.DoCommand( sql );
				}
				else if ( this.isJCorHy == 2)
				{
                    sql = "insert into jc_assay(yzid,bbid,hylxid) values (" + _order_id + "," + sample + ", " + hylx + ")";
                    InstanceForm.BDatabase.DoCommand(sql);
				}

                string _bz = "";
                if (OpType == OP_TYPE.������Ŀ) _bz = "����ҽ����Ŀ:��" + _order_name + "��"; else _bz = "�޸�ҽ����Ŀ:��" + _order_name + "��";
                ts.Save_log(ts_HospData_Share.czlx.jc_ҽ����Ŀ�޸�, _bz, "jc_hoitemdiction", "order_id", _order_id.ToString(),InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
				InstanceForm.BDatabase.CommitTransaction();
				
			}
			catch(Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				throw err;
			}


            //��Ժ���ݴ���
            try
            {
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_ҽ����Ŀ�޸�, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                {
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                }
                if (errtext != "") throw new Exception(errtext);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("����ɹ� " + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            return true;

		}
		/// <summary>
		/// �������á�ͣ��״̬
		/// </summary>
		/// <param name="Used"></param>
		/// <returns></returns>
        public bool SetUseable(bool Used)
        {
           //2014-7-15 jianqg ���Ӻ��������ù����ĺ���
           return SetUseable(Used, InstanceForm.BDatabase, true, InstanceForm._menuTag.Jgbm);
        }
        /// <summary>
        ///  2014-7-15 jianqg ���Ӻ����������շ���Ŀ��������ҽ����Ŀ״̬���շ���Ŀͣ�õ��ñ�����������ҽ����Ŀͣ�ã�
        /// ʹ��ǰ ��Ҫʵ�����࣬��Ҫ�ǣ�_order_id��_order_name
        /// </summary>
        /// <param name="Used"></param>
        /// <param name="db">���ݿ�����</param>
        /// <param name="bTransaction">�Ƿ���������(ҽ����Ŀֱ�ӱ�����true,�շ���Ŀ����������false)</param>
        /// <param name="jgbm">��������(ҽ����Ŀֱ�ӱ�����InstanceForm._menuTag.Jgbm,�շ���Ŀ�������洫��)</param>
        /// <returns></returns>
        public bool SetUseable(bool Used, RelationalDatabase db, bool bTransaction,int jgbm)
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;
            string bz = "";
			try
			{
                //InstanceForm.BDatabase.BeginTransaction();
                if (bTransaction) db.BeginTransaction();//2014-7-15 �޸ģ����ò����жϴ���
				string sql = "update jc_hoitemdiction set delete_bit=" + (Used ? "0" : "1") + " where order_id=" + this._order_id;
                //InstanceForm.BDatabase.DoCommand(sql);
                db.DoCommand(sql); //2014-7-15 �޸ģ����ò�������

                //��Ժ���ݴ���
                bz = Used == true ? "����ҽ����Ŀ:" + _order_name : "ͣ��ҽ����Ŀ:" + _order_name;
                //ts.Save_log(ts_HospData_Share.czlx.jc_�������ݵ����޸�, bz, "jc_hoitemdiction", "order_id", _order_id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
                ts.Save_log(ts_HospData_Share.czlx.jc_�������ݵ����޸�, bz, "jc_hoitemdiction", "order_id", _order_id.ToString(), jgbm, 0, "", out log_djid, db);//2014-7-15 �޸ģ����ò�������

                //InstanceForm.BDatabase.CommitTransaction();
                if (bTransaction) db.CommitTransaction();//2014-7-15 �޸ģ����ò����жϴ���

                //��Ժ���ݴ���
                try
                {
                    string errtext = "";
                    //ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�������ݵ����޸�, InstanceForm.BDatabase);
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�������ݵ����޸�, db);//2014-7-15 �޸ģ����ò�������
                    if (ty.Bzx == 1)
                    {
                        //ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                        ts.Pexec_log(log_djid, db, out errtext);//2014-7-15 �޸ģ����ò�������
                    }
                    if (errtext != "") throw new Exception(errtext);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(bz + "�ɹ�  ." + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

			
				
			}
			catch(Exception err)
			{
                //InstanceForm.BDatabase.RollbackTransaction();
                if (bTransaction) db.RollbackTransaction();//2014-7-15 �޸ģ����ò����жϴ���
				throw new Exception("Setҽ����ĿUseable/" + err.Message );
			}


            return true;
		}
		#region ICloneable ��Ա

		public object Clone()
		{
			// TODO:  ��� ChargeItem.Clone ʵ��
			return new OrderItem(this._order_id);
		}

		#endregion
		/// <summary>
		/// ��ȡִ�п���
		/// </summary>
		/// <returns></returns>
		private DataTable GetExecDeptDataTable()
		{
			string sql = "select b.dept_id,b.name  from jc_hoi_dept a left join jc_dept_property b on a.exec_dept=b.dept_id where a.order_id=" + this._order_id;
			return InstanceForm.BDatabase.GetDataTable(sql);
		}
				
	}
}
