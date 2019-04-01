using System;

namespace TrasenClasses.GeneralClasses
{
	/// <summary>
	/// Convert ��ժҪ˵����
	/// </summary>
	public class Convertor
	{
		/// <summary>
		/// ��Nullֵת��Ϊָ��ֵ
		/// </summary>
		/// <param name="obj">���жϵ�ֵ</param>
		/// <param name="nValue">ָ��ֵ</param>
		/// <returns></returns>
		public static string IsNull(object obj, string nValue)
		{
			try
			{
				return Convert.ToString(obj).Trim()=="" ? nValue:obj.ToString().Trim();
			}
			catch(System.InvalidCastException err)
			{
				err.ToString();
				return "";
			}
			catch(System.Exception err)
			{
				err.ToString();
				return "";
			}		
		}

		/// <summary>
		///�ж������ַ����Ƿ�Ϊ����
		/// </summary>
		/// <param name="nValue">�ַ���</param>
		/// <returns></returns>
		public static bool IsNumeric(string nValue)
		{
			int i,iAsc,idecimal=0;
			if(nValue.Trim()=="") return false;
			for(i=0;i<=nValue.Length-1;i++)
			{
				iAsc=(int)Convert.ToChar(nValue.Substring(i,1));
				//'-'45 '.'46 '''0-9' 48-57
				if(iAsc==45)		
				{
					if(nValue.Length ==1)//����ֻ��һ������
					{
						return false;
					}
					if(i!=0)			//'-'�������ַ����м�
					{
						return false;
					}
				}
				else if(iAsc==46)
				{
					idecimal++;
					if(idecimal>1)		//������������ϵ�С����
						return false;
				}
				else if(iAsc<48 || iAsc>57)
				{
						return false;
				}
			}
			return true;	
		}

		/// <summary>
		///�ж������ַ����Ƿ�Ϊ����
		/// </summary>
		/// <param name="nValue">�ַ���</param>
		/// <returns></returns>
		public static bool IsInteger(string nValue)
		{
			int i,iAsc;
			if(nValue.Trim()=="") return false;
			for(i=0;i<=nValue.Length-1;i++)
			{
				iAsc=(int)Convert.ToChar(nValue.Substring(i,1));
				//'-' 45 '0-9' 48-57
				if(iAsc==45)		
				{
					if(nValue.Length ==1)//����ֻ��һ������
					{
						return false;
					}
					if(i!=0)			//'-'�������ַ����м�
					{
						return false;
					}
				}
				else if(iAsc<48 || iAsc>57)
				{
					return false;
				}
			}
			return true;	
		}
	}
}
