using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Xml;
using System.Management;
 

namespace TrasenFrame.Classes
{
    public delegate void OnProcessingEventHandler(string message );
    public delegate void OnDetectingPrinterChanged(string message);
    public class Printer
    {
        public string Name;
        public PrinterType Type;
        public string Port;
        public bool IsNetPrinter;
    }
    public enum PrinterType : int
    {
        δ֪���� = 0,
        ��ʽ��ӡ�� = 1,
        ��ī��ӡ�� = 2,
        �����ӡ�� = 3
    }
    /// <summary>
    /// ��ӡ��������
    /// </summary>
    public class PrinterManager
    {
        private string xmlPath = System.Windows.Forms.Application.StartupPath + "\\InstalledPrinter.xml";        
        public event OnProcessingEventHandler OnProcessing;
        public event OnDetectingPrinterChanged DetectingPrinterChanged;
        /// <summary>
        /// ��ȡ�Ѱ�װ�Ĵ�ӡ���б�
        /// </summary>
        public List<string> GetInstanlledPrinters()
        {
            PrintDocument pd = new PrintDocument();
            List<string> printers = new List<string>();
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                printers.Add(printerName);
            }
            return printers;




        }
        /// <summary>
        /// ��ȡ���������еĴ�ӡ���б�
        /// </summary>
        /// <returns></returns>
        public List<Printer> GetConfiguredPrinters()
        {
            XmlDocument document = new XmlDocument();
            if ( !System.IO.File.Exists( xmlPath ) )
                return new List<Printer>();
            document.Load( xmlPath );
            List<Printer> printers = new List<Printer>();
            XmlNodeList xnlstPrinters = document.GetElementsByTagName( "Printer" );
            foreach( XmlNode xn in xnlstPrinters )
            {
                Printer printer = new Printer();
                printer.Name = xn.Attributes["name"].Value;
                printer.Type = (PrinterType)Convert.ToInt32( xn.Attributes["printertype"].Value );
                printer.Port = xn.Attributes["port"].Value;
                printer.IsNetPrinter = Convert.ToBoolean( xn.Attributes["netprinter"].Value );
                printers.Add( printer );
            }

            return printers;
        }
        /// <summary>
        /// �������ƻ�ȡ�����еĴ�ӡ��
        /// </summary>
        /// <param name="PrinterName"></param>
        /// <returns></returns>
        public Printer GetConfiguredPrinter( string PrinterName )
        {
            List<Printer> lstPrinters = GetConfiguredPrinters();
            Printer printer = lstPrinters.Find( delegate( Printer p )
            {
                return p.Name == PrinterName;
            } );
            return printer;
        }
        /// <summary>
        /// ��Ȿ����װ�Ĵ�ӡ����������������Ϣ
        /// </summary>
        public void Detecting()
        {
            //�Ѱ�װ�Ĵ�ӡ��
            List<string> installedPrinters = GetInstanlledPrinters();
            if( !System.IO.File.Exists( xmlPath ) )
            {
                if( !CreateXmlConfig( installedPrinters , xmlPath ) )
                {
                    throw new Exception( "������ӡ�������ļ���������" );
                }
                else
                {
                    if( DetectingPrinterChanged != null )
                        DetectingPrinterChanged( "��ʼ����ӡ���������,���ڲ˵�����[ϵͳ]=>[��������]�н�������" );
                    return;
                }
            }

            //�����õĴ�ӡ��
            List<Printer> configuedPrinters = GetConfiguredPrinters();

            //��ⰲװ�Ĵ�ӡ�����������Ƿ�һ��
            StringBuilder sbInfo = new StringBuilder();
            bool haschanged = false;
            foreach( string printer in installedPrinters )
            {
                if( configuedPrinters.Find( delegate( Printer p )
                {
                    return p.Name == printer;
                } ) == null )
                {
                    sbInfo.Append( "��װ�Ĵ�ӡ��[" + printer + "]û��������������\r" );
                    haschanged = true;
                }
            }

            if( haschanged )
            {
                if( DetectingPrinterChanged != null )
                {
                    sbInfo.Append( "���ڲ˵�����[ϵͳ]=>[��������]�н�������" );
                    DetectingPrinterChanged( sbInfo.ToString() );
                }
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="Printers"></param>
        public void Save( List<Printer> Printers )
        {
            if( !System.IO.File.Exists( xmlPath ) )
            {
                CreateXmlConfig( new List<string>() , xmlPath );
            }

            XmlDocument document = new XmlDocument();
            document.Load( xmlPath );
            XmlNodeList lst = document.GetElementsByTagName( "InstalledPrinter" );
            XmlNode root = document.GetElementsByTagName( "InstalledPrinter" )[0];
            root.RemoveAll();
            foreach( Printer printer in Printers )
            {
                XmlNode xnPrinter = document.CreateNode( XmlNodeType.Element , "Printer" , "" );
                XmlAttribute attrName = document.CreateAttribute( "name" );
                attrName.Value = printer.Name;
                XmlAttribute attrType = document.CreateAttribute( "printertype" );
                attrType.Value = Convert.ToString( (int)printer.Type );
                XmlAttribute attrPort = document.CreateAttribute( "port" );
                attrPort.Value = printer.Port;
                XmlAttribute attrNet = document.CreateAttribute( "netprinter" );
                attrNet.Value = printer.IsNetPrinter ? "true" : "false";
                xnPrinter.Attributes.Append( attrName );
                xnPrinter.Attributes.Append( attrType );
                xnPrinter.Attributes.Append( attrPort );
                xnPrinter.Attributes.Append( attrNet );

                root.AppendChild( xnPrinter );
            }
            document.AppendChild( root );
            try
            {
                document.Save( xmlPath );
            }
            catch( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// ɾ����ӡ������
        /// </summary>
        /// <param name="PrintName"></param>
        public void Delete( string PrinterName )
        {
            XmlDocument document = new XmlDocument();
            document.Load( xmlPath );
            XmlNode printers = document.GetElementsByTagName( "InstalledPrinter" )[0];
            XmlNodeList xnlstPrinters = document.GetElementsByTagName( "Printer" );
            foreach( XmlNode xn in xnlstPrinters )
            {
                if( PrinterName == xn.Attributes["name"].Value )
                {
                    printers.RemoveChild( xn );
                    break;
                }

            }
            document.Save( xmlPath );
        }
        /// <summary>
        /// ������ӡ�������ļ�
        /// </summary>
        /// <param name="printers"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool CreateXmlConfig( List<string> printers , string path )
        {
            XmlDocument document = new XmlDocument();

            XmlNode root = document.CreateNode( XmlNodeType.Element , "InstalledPrinter" , "" );
            
            foreach( string name in printers )
            {
                XmlNode xnPrinter = document.CreateNode( XmlNodeType.Element , "Printer" , "" );
                XmlAttribute attrName = document.CreateAttribute( "name" );
                attrName.Value = name;
                XmlAttribute attrType = document.CreateAttribute( "printertype" );
                attrType.Value = "0";
                XmlAttribute attrPort = document.CreateAttribute( "port" );
                attrPort.Value = "unknown";
                XmlAttribute attrNet = document.CreateAttribute( "netprinter" );
                attrNet.Value = "false";

                xnPrinter.Attributes.Append( attrName );
                xnPrinter.Attributes.Append( attrType );
                xnPrinter.Attributes.Append( attrPort );
                xnPrinter.Attributes.Append( attrNet );

                root.AppendChild( xnPrinter );
            }
            document.AppendChild( root );
            try
            {
                document.Save( path );
                return true;
            }
            catch( Exception err )
            {
                throw err;
            }
            
        }

        public static string CurrentDefaultPrinter
        {
            get
            {
                PrintDocument printDocument = new PrintDocument();
                return printDocument.PrinterSettings.PrinterName;
            }
        }
    }
}
