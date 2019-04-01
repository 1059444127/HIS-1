using System;
using System.Data;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes
{
	/// <summary>
	/// ZYSet ��ժҪ˵����
	/// </summary>
	public class TsSet:ISet
	{
		private RelationalDatabase _database = TrasenFrame.Forms.FrmMdiMain.Database;
		private DataSet _dataSet;
		/// <summary>
		/// ����������
		/// </summary>
		protected IDataAdapter _dataAdapter;
		/// <summary>
		/// TsSet��DataTable
		/// </summary>
		public DataTable TsDataTable;
		/// <summary>
        /// ����һ��TsSet
		/// </summary>
		public TsSet()
		{

		}
		/// <summary>
        /// ����IDbCommand�����ݿ����͹���TsSet
		/// </summary>
		/// <param name="selectCommand"></param>
		public TsSet(IDbCommand selectCommand)
		{
			_dataAdapter=_database.GetAdapter(selectCommand);
			_dataSet=new DataSet();
			_dataAdapter.Fill(_dataSet);
			TsDataTable=_dataSet.Tables[0];

		}
		/// <summary>
        ///  ����SQL����ַ��������ݿ����͹���TsSet
		/// </summary>
		/// <param name="selectCommand"></param>
		/// <param name="dbType"></param>
		public TsSet(string selectCommand)
		{
			_dataAdapter=_database.GetAdapter(selectCommand);
			_dataSet=new DataSet();
			_dataAdapter.Fill(_dataSet);
			TsDataTable=_dataSet.Tables[0];
		}
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="table">������</param>
		/// <param name="colume">������</param>
		public void SetPrimaryKey(string table,string colume)
		{
			DataColumn[] dc={_dataSet.Tables[table].Columns[colume]};
			_dataSet.Tables[table].PrimaryKey=dc;
		}
		#region ISet ��Ա
		/// <summary>
		/// ȡ�úϼ�
		/// </summary>
		/// <param name="index">�ֶ�����</param>
		/// <param name="filter">��������</param>
		/// <returns></returns>
		public virtual decimal Sum(int index,string filter)
		{
			// TODO:  ��� ZYSet.Sum ʵ��
			if(TsDataTable==null) throw new EntityException("����δ����ʼ��");
			if(TsDataTable.Columns.Count<=index) throw new EntityException("�Ƿ��ֶ�������");
			return Convert.ToDecimal(Convertor.IsNull(TsDataTable.Compute("sum("+TsDataTable.Columns[index].ColumnName.Trim()+")",filter),"0"));
		}
		/// <summary>
		/// ȡ�úϼ�
		/// </summary>
		/// <param name="fieldName">�ֶ�����</param>
		/// <param name="filter">��������</param>
		/// <returns></returns>
		public virtual decimal Sum(string fieldName,string filter)
		{
			// TODO:  ��� ZYSet.Sum ʵ��
			if(TsDataTable==null) throw new EntityException("����δ����ʼ��");
			return Convert.ToDecimal(Convertor.IsNull(TsDataTable.Compute("sum("+fieldName+")",filter),"0"));
		}
		/// <summary>
		/// �õ������е�����
		/// </summary>
		/// <param name="filter">���¹�������</param>
		/// <returns></returns>
		public virtual long Count(string filter)
		{
			// TODO:  ��� ZYSet.Count ʵ��
			if(TsDataTable==null) throw new EntityException("����δ����ʼ��");
			return Convert.ToInt64(Convertor.IsNull(TsDataTable.Compute("count(*)",filter),"0"));
		}
		/// <summary>
		/// ���һ��
		/// </summary>
		/// <returns></returns>
		public virtual bool Add()
		{
			// TODO:  ��� ZYSet.Add ʵ��
			return false;
		}

		/// <summary>
		/// ���¼���
		/// </summary>
		/// <param name="items">��Ҫ���µ�����</param>
		/// <param name="filter">��������</param>
		/// <returns>����Ӱ��ļ�¼��</returns>
		public virtual long UpdateField(ItemEx[] items,string filter)
		{
			if(TsDataTable==null) throw new EntityException("����δ����ʼ��");
			DataRow[] rows=TsDataTable.Select(filter);
			TsDataTable.BeginLoadData();
			for(long i=0;i<rows.GetLongLength(0);i++)
				for(int j=0;j<items.GetLength(0);j++)
					rows[i][items[j].Text]=items[j].Value;
			return 0;
		}
		/// <summary>
		/// ����filter�������˱��¼
		/// </summary>
		/// <param name="filter">ɸѡ����</param>
		/// <returns></returns>
		public virtual DataTable FilterTable(string filter)
		{
			// TODO:  ��� ZYSet.FilterTable ʵ��
			if(TsDataTable==null) throw new EntityException("����δ����ʼ��");
			DataTable tb=TsDataTable.Clone();
			DataRow[] rows=TsDataTable.Select(filter);
			for(int i=0;i<rows.Length;i++)
			{
				tb.Rows.Add(rows[i].ItemArray);
			}
			return tb;
		}
		/// <summary>
		/// ����filter�������˱��¼
		/// </summary>
		/// <param name="filter">ɸѡ����</param>
		/// <param name="sort">��������</param>
		/// <returns></returns>
		public virtual DataTable FilterTable(string filter,string sort)
		{
			// TODO:  ��� ZYSet.FilterTable ʵ��
			if(TsDataTable==null) throw new EntityException("����δ����ʼ��");
			DataTable tb=TsDataTable.Clone();
			DataRow[] rows=TsDataTable.Select(filter,sort);
			for(int i=0;i<rows.Length;i++)
			{
				tb.Rows.Add(rows[i].ItemArray);
			}
			return tb;
		}
		/// <summary>
		/// ���鲢���ݾۺϺ������ʽ��ֵ
		/// </summary>
		/// <param name="groupByFieldsName">���鷽ʽ</param>
		/// <param name="computerFieldsName">����������</param>
		/// <param name="computerFormularsName">���㺯������</param>
		/// <param name="filter">ɸѡ����</param>
		/// <returns></returns>
		public virtual DataTable GroupTable(string[] groupByFieldsName,string[] computerFieldsName,string[] computerFormularsName,string filter)
		{
			// TODO:  ��� ZYSet.GroupTable ʵ��
			if(TsDataTable==null) throw new EntityException("����δ����ʼ��");
			DataTable tb=this.FilterTable(filter);
			DataTable tbResult=TsDataTable.Clone();
			object[] oldValue=new object[computerFieldsName.Length];
			int i,j,m,n,k;
			for(i=0;i<tb.Rows.Count;i++)
			{
				
				
				for(j=0;j<computerFieldsName.Length;j++)		//�������
				{
					oldValue[j]=tb.Rows[i][computerFieldsName[j]];
					tb.Rows[i][computerFieldsName[j]]=tb.Compute(computerFormularsName[j]+"("+computerFieldsName[j]+")",GetGroupByString(groupByFieldsName,tb.Rows[i]));
				}
				bool existSameRow=false;			//������ͬ��
				for(m=0;m<=tbResult.Rows.Count-1;m++)			//ģ�������㣬���Ŀ���tbResult���Ѵ�����ͬ���������ļ�¼�������tbResult��
				{
					for(n=0;n<groupByFieldsName.Length;n++)
					{
						//��һ�ȽϷ���������ֻҪ����һ���������������Ϊ������ͬ��
						if(tbResult.Rows[m][groupByFieldsName[n]].ToString()!=tb.Rows[i][groupByFieldsName[n]].ToString())
						{
							existSameRow=false;
							break;
						}
						else
						{
							existSameRow=true;
						}
					}
					if(existSameRow)//ֻҪ������ͬ�У�������ѭ��
					{
						break;
					}
				}
				if(!existSameRow)
				{
					tbResult.Rows.Add(tb.Rows[i].ItemArray);
				}
				//���лָ�ԭֵ
				for(j=0;j<computerFieldsName.Length;j++)		
				{
					tb.Rows[i][computerFieldsName[j]]=oldValue[j];
				}
				if(groupByFieldsName.Length ==0)	//�����������Ϊ��������ֻ��һ��
				{
					break;
				}
			}
			//ȥ����groupByFieldsName��Ԫ���ҷ�computerFieldsName��Ԫ�ص��ֶ�
			for(k=0;k<tbResult.Columns.Count;k++)
			{
				if(!Contains(groupByFieldsName,tbResult.Columns[k].ColumnName) && !Contains(computerFieldsName,tbResult.Columns[k].ColumnName))
				{
					tbResult.Columns.Remove(tbResult.Columns[k]);
				}
			}						
			return tbResult;
		}
		/// <summary>
		/// ���ݷ��������ֶ��������ɷ�����������ַ���
		/// </summary>
		/// <param name="groupByFieldsName"></param>
		/// <param name="dr"></param>
		/// <returns></returns>
		private string GetGroupByString(string[] groupByFieldsName,DataRow dr)
		{
			string strGroupFields="";
			//�������������ַ���
			for(int i=0;i<groupByFieldsName.Length;i++)
			{
				if(i==0)
				{
					if ( dr[groupByFieldsName[i]].ToString().Trim() !="")
					{
						strGroupFields+=groupByFieldsName[i]+"='"+dr[groupByFieldsName[i]].ToString().Trim()+"'";	
					}
				}
				else
				{
					if ( dr[groupByFieldsName[i]].ToString().Trim() !="")
					{
						strGroupFields+=" and "+groupByFieldsName[i]+"='"+dr[groupByFieldsName[i]].ToString().Trim()+"'";	
					}
				}
			}
			return strGroupFields;
		}
		/// <summary>
		/// ���鲢���ݾۺϺ������ʽ��ֵ
		/// </summary>
		/// <param name="groupByFieldsName">���鷽ʽ</param>
		/// <param name="computerFieldsName">����������</param>
		/// <param name="computerFormularsName">���㺯������</param>
		/// <param name="filter">�����ֶ�</param>
		/// <param name="removeSpilthColumn">�Ƿ��Ƴ������ֶ�</param>
		/// <returns></returns>
		public virtual DataTable GroupTable(string[] groupByFieldsName,string[] computerFieldsName,string[] computerFormularsName,string filter,bool removeSpilthColumn)
		{
			if(TsDataTable==null) throw new EntityException("����δ����ʼ��");
			DataTable tmpTable =  TsDataTable.Copy();
			DataTable newTable = TsDataTable.Clone();
			if ( computerFieldsName.Length != computerFormularsName.Length ) 
				throw new Exception ("ָ���ļ����ֶ����������Ӧ��һ��");

			//��������־
			DataColumn colGroup = new DataColumn();
			colGroup.ColumnName="GroupFlag";
			colGroup.DataType = Type.GetType("System.Int32");
			colGroup.DefaultValue = 0;
			tmpTable.Columns.Add(colGroup);
			//�����������¼
			string _filter = "GroupFlag=0";
			if (filter!="") _filter += " and " + filter;
			while ( tmpTable.Select(_filter).Length> 0 )
			{
				DataRow[] drs = tmpTable.Select(_filter);
				string selectString = GetGroupString(groupByFieldsName,drs[0]) ;
				drs = tmpTable.Select(selectString);
				if (drs.Length > 0 )
				{
					//���������
					DataRow newRow = newTable.NewRow();
					for ( int i=0;i<newTable.Columns.Count;i++)
						newRow[newTable.Columns[i].ColumnName]=drs[0][newTable.Columns[i].ColumnName];
					newTable.Rows.Add(newRow);
					//���ݼ���������ֵ�����µ�ǰ������
					for(int i=0;i<computerFieldsName.Length;i++)
					{
						string computeString = computerFormularsName[i] + "(" + computerFieldsName[i] + ")";
						string computCondictionString = selectString + (filter==""?"": (" and " + filter));
						if ( selectString.Trim() == "" )
							computCondictionString = filter;
						object objValue = tmpTable.Compute(computeString,computCondictionString);
						newTable.Rows[newTable.Rows.Count-1][computerFieldsName[i]]=objValue;
					}
				}
				else
					break;
				//��������ļ�¼�����
				for ( int i=0;i<drs.Length;i++)
					drs[i]["GroupFlag"]=1;
				
			}
			//�Ƴ���group�ֶκ�computer�ֶ�
			DataTable retTable = newTable.Copy();
			if ( removeSpilthColumn )
			{
				foreach(DataColumn col in newTable.Columns)
				{
					string columnName = col.ColumnName;
					if ( NotInColumnCollection(columnName,groupByFieldsName) && NotInColumnCollection(columnName,computerFieldsName) )
						retTable.Columns.Remove(columnName);
				}
			}
			tmpTable.Dispose();
			tmpTable = null;
			newTable.Dispose();
			newTable=null;
			return retTable;
		}
		/// <summary>
		/// ��ȡ����ѡ������
		/// </summary>
		/// <param name="GroupFields"></param>
		/// <param name="dr"></param>
		/// <returns></returns>
		private string GetGroupString(string[] GroupFields,DataRow dr)
		{
			StringBuilder sb = new StringBuilder();
			Type type;
			for ( int i =0;i<GroupFields.Length;i++)
			{
				if (i !=0) sb.Append(" and ");
				type = dr[GroupFields[i]].GetType();
				if ( type.ToString() == "System.String" || type.ToString()=="System.DateTime")
				{
					sb.Append( GroupFields[i] + "='" + dr[GroupFields[i]].ToString().Trim() + "'");
				}
				else
				{
					sb.Append( GroupFields[i] + "=" + dr[GroupFields[i]].ToString().Trim());
				}
			}
			return sb.ToString();
		}
		/// <summary>
		/// �ж��Ƿ����м�����
		/// </summary>
		/// <param name="columnName"></param>
		/// <param name="srcColumnNames"></param>
		/// <returns></returns>
		private bool NotInColumnCollection(string columnName,string[] srcColumnNames)
		{
			for ( int i=0; i < srcColumnNames.Length; i ++ )
			{
				if ( srcColumnNames[i].ToUpper() == columnName.ToUpper() )
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// �ж�array�Ƿ����findString
		/// </summary>
		/// <param name="array"></param>
		/// <param name="findString"></param>
		/// <returns></returns>
		private bool Contains(string[] array,string findString)
		{
			for(int i=0;i<array.Length;i++)
			{
				if(findString.ToUpper().Trim()==array[i].ToUpper().Trim())
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// �Ѷ����ݵĸ���д�����ݿ���ȥ���Ա����ϵ��޸���������ø÷����򲻻�д���ݿ�
		/// </summary>
		/// <returns></returns>
		public virtual bool Flash()
		{
			if(_dataAdapter==null) throw new EntityException("����������δ����");
			if(_dataSet==null) throw new EntityException("���ݼ���δ����");
			try
			{
				_database.CreateCommandBuilder(_dataAdapter);
				_dataAdapter.Update(_dataSet);
			}
			catch(System.Exception err)
			{
				throw new EntityException(""+err.Message);
			}
			return true;
		}

		#endregion
	}
}
