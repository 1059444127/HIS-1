using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;

namespace YpClass
{
	/// <summary>
	/// ҩƷϵͳ�����ṹ��
	///		�ɹ�����Ƿ񱣴漴���ӿ��
	///		ǿ�ƿ��ƿ��
	/// </summary>
	public class YpConfig
	{
		public bool �ɹ�����Ƿ񱣴漴���ӿ��;
		public bool ǿ�ƿ��ƿ��;
		public bool ��������;
		public bool ��λ����;
		public bool ��ҩģʽ;
		public bool ϵͳ����;
		public bool ����ϵͳ;
		public bool ҵ�񵥾ݽ��ܷ��Ƿ�����ֹ�������;
		public bool �Ƿ������û�п���¼��ҩƷ�����̴�;
		public bool �Ƿ������û�п���¼��ҩƷ���е���;
		public bool ֱ��¼��������;
		public bool ����������ʾ��Ʒ��;
		public bool ��ӡ����ʱ������ʾ��Ʒ��;
		public bool ͳ�쵥��ҩ����ҩ�Ƿ�ֿ�;
		public bool ���﷢ҩ����ҩʱĬ�ϴ�ӡСƱ;
        public bool ������ҩʱ��ӡ�嵥;
        public bool ������ҩʱ��ӡ����;
        public bool ������ҩʱ��ӡע�䵥;
        public bool ���﷢ҩʱ��ӡ�嵥;
        public bool ���﷢ҩʱ��ӡ����;
        public bool ���﷢ҩʱ��ӡע�䵥;
        public bool ���﷢ҩʱĬ�ϴ�ӡ����;
        public bool ���﷢ҩ��ť�Ƿ�������ý���;
        public bool �ɹ���ⵥ��ʾ�����ۺ��������;
        public bool ���﷢ҩ����ܴ�ӡ����;
        public bool ҩ���췢; 
        public string �̴淽ʽ;// 0-�����ο���̴�,1-���ܿ���̴�
        public static bool �Ƿ�ҩ��(long deptid, RelationalDatabase _DataBase)
		{
				string ssql="select * from yp_yjks where deptid="+deptid+"";
				DataTable tb=_DataBase.GetDataTable(ssql);
				if (tb.Rows.Count!=0)
				{
					if (tb.Rows[0]["kslx"].ToString().Trim()=="ҩ��")
						return true;
					else
						return false;
				}
				else
				{
                    ssql = "select * from yp_yjks_gx where p_deptid=" + deptid + "";
                    DataTable tab = _DataBase.GetDataTable(ssql);
                    if (tab.Rows.Count > 0)
                        return true;
                    else
                        return false;
				}
		}

        public static DeptType kslx(int deptid, RelationalDatabase _DataBase)
        {
            string ssql = "select * from yp_yjks where deptid=" + deptid +
                " ";
			DataTable tb=_DataBase.GetDataTable(ssql);
            if (tb.Rows.Count != 0)
            {
                switch (tb.Rows[0]["kslx"].ToString().Trim())
                {
                    case "ҩ��":
                        return DeptType.ҩ��;
                    case "ҩ��":
                        return DeptType.ҩ��;
                    case "�Ƽ�":
                        return DeptType.�Ƽ�;
                    default:
                        return DeptType.δ֪;
                }
            }
            else
            {
                return DeptType.δ֪;
            }
        }


        public YpConfig(long deptid, RelationalDatabase _DataBase)
		{
			string ssql="select * from yk_config where deptid="+deptid+"";
			DataTable tb=_DataBase.GetDataTable(ssql);
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				switch(tb.Rows[i]["bh"].ToString().Trim())
				{
					case "100":
						�ɹ�����Ƿ񱣴漴���ӿ��=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "101":
						ǿ�ƿ��ƿ��=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "102":
						��������=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "103":
						��λ����=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "104":
						ϵͳ����=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "105":
						����ϵͳ=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "106":
						��ҩģʽ=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "108":
						ҵ�񵥾ݽ��ܷ��Ƿ�����ֹ�������=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "109":
						�Ƿ������û�п���¼��ҩƷ�����̴�=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "110":
						�Ƿ������û�п���¼��ҩƷ���е���=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "111":
						ֱ��¼��������=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "112":
						����������ʾ��Ʒ��=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "113":
						��ӡ����ʱ������ʾ��Ʒ��=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "114":
						ͳ�쵥��ҩ����ҩ�Ƿ�ֿ�=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "115":
						���﷢ҩ����ҩʱĬ�ϴ�ӡСƱ=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
                    case "116":
                        ������ҩʱ��ӡ�嵥 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "117":
                        ������ҩʱ��ӡ���� = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "118":
                        ������ҩʱ��ӡע�䵥 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "119":
                        ���﷢ҩʱ��ӡ�嵥 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "120":
                        ���﷢ҩʱ��ӡ���� = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "121":
                        ���﷢ҩʱ��ӡע�䵥 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "122":
                        ���﷢ҩʱĬ�ϴ�ӡ����= Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "124":
                        ���﷢ҩ��ť�Ƿ�������ý��� = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "125":
                        �ɹ���ⵥ��ʾ�����ۺ�������� = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "151":
                        ���﷢ҩ����ܴ�ӡ���� = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "998":
                        �̴淽ʽ = Convert.ToString(tb.Rows[i]["zt"]);
                        break;
                    case "997":
                        ҩ���췢 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
				}
			}
		}

	}
}
