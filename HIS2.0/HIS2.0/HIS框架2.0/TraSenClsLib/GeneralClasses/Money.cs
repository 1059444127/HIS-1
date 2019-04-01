using System;

namespace TrasenClasses.GeneralClasses
{
	/// <summary>
	/// ����ʵ�ְ��������ֵ���д���ĵ�ת��
	/// ����û�жԷǷ����ֽ����б�
	/// �����NumToChn����
	/// </summary>
	public class Money
	{
		/// <summary>
		/// �����
		/// </summary>
		public Money()
		{
		
		}
		private static char chrToNum(char x)
		{
			string chnNames="��Ҽ��������½��ƾ�";
			string numNames="0123456789";
			return chnNames[numNames.IndexOf(x)];
		}
		private static string TenthousandToNum(string x)
		{
			string[] stringArrayLevelNames=new string[4] {"","ʰ","��","Ǫ"};
			string ret="";
			int i;
			for (i=x.Length-1;i>=0;i--)
				if (x[i]=='0')
					ret=chrToNum(x[i])+ret;
				else
					ret=chrToNum(x[i])+stringArrayLevelNames[x.Length-1-i]+ret;
			while ((i=ret.IndexOf("����"))!=-1)
				ret=ret.Remove(i,1);
			if (ret[ret.Length-1]=='��' && ret.Length>1)
				ret=ret.Remove(ret.Length-1,1);
			//			if (ret.Length>=2 && ret.Substring(0,2)=="Ҽʰ")
			//				ret=ret.Remove(0,1);
			return ret;
		}
		private static string chgIntegerPart(string x)
		{
			int len=x.Length;
			string ret,temp;
			if (len<=4)
				ret=TenthousandToNum(x);
			else if (len<=8)
			{
				ret=TenthousandToNum(x.Substring(0,len-4))+"��";
				temp=TenthousandToNum(x.Substring(len-4,4));
				if (temp.IndexOf("Ǫ")==-1 && temp!="")
					ret+="��"+temp;
				else
					ret+=temp;
			}
			else
			{
				ret=TenthousandToNum(x.Substring(0,len-8))+"��";
				temp=TenthousandToNum(x.Substring(len-8,4));
				if (temp.IndexOf("Ǫ")==-1 && temp!="")
					ret+="��"+temp;
				else
					ret+=temp;
				ret+="��";
				temp=TenthousandToNum(x.Substring(len-4,4));
				if (temp.IndexOf("Ǫ")==-1 && temp!="")
					ret+="��"+temp;
				else
					ret+=temp;
			}
			int i;
			if ((i=ret.IndexOf("����"))!=-1)
				ret=ret.Remove(i+1,1);
			while ((i=ret.IndexOf("����"))!=-1)
				ret=ret.Remove(i,1);
			if (ret[ret.Length-1]=='��' && ret.Length>1)
				ret=ret.Remove(ret.Length-1,1);
			return ret;
		}

		private static string chgDecimalPart(string x)
		{
			string ret="";
			for (int i=0;i<x.Length && i<2;i++)
			{
				switch(i)
				{
					case 0:
						ret+=chrToNum(x[i])+"��";
						break;
					case 1:
						ret+=chrToNum(x[i])+"��";
						break;
				}
			}
			return ret;
		}
		/// <summary>
		/// ��������Сд���ת���ɴ�д���
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static string NumToChn(string x)
		{
			if (x.Length==0)
				return "";
			string ret="";
			if (x[0]=='-')
			{
				ret="��";
				x=x.Remove(0,1);
			}
			if (x[0].ToString()==".")
				x="0"+x;
			if (x[x.Length-1].ToString()==".")
				x=x.Remove(x.Length-1,1);
			//if (x.IndexOf(".")>-1) 2005-09-13,Szg,Modify
			if (x.IndexOf(".")>-1)
			{
				if(Convert.ToDecimal("0"+x.Substring(x.IndexOf(".")))>0)
				{
					ret+=chgIntegerPart(x.Substring(0,x.IndexOf(".")))+"Ԫ"+chgDecimalPart(x.Substring(x.IndexOf(".")+1));
				}
				else
				{
					ret+=chgIntegerPart(Convert.ToDecimal(x).ToString("0"))+"Ԫ��";
				}
			}
			else
			{
				ret+=chgIntegerPart(x)+"Ԫ��";
			}
			return ret;
		}
	}
	/* END CLASS DEFINITION Money */
}
