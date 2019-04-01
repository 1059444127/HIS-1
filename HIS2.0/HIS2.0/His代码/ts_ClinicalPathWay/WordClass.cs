using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace ts_ClinicalPathWay
{
    public class WordClass : IDisposable
    {
        #region �ֶ�
        private _Application m_WordApp = null;
        private _Document m_Document = null;
        private object missing = System.Reflection.Missing.Value;
        #endregion
        #region ���캯������������
        public WordClass()
        {
            m_WordApp = new ApplicationClass();
        }
        ~WordClass()
        {
            try
            {
                if (m_WordApp != null)
                    m_WordApp.Quit(ref missing, ref missing, ref missing);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
        }
        #endregion
        #region ����
        public _Document Document
        {
            get
            {
                return m_Document;
            }
        }
        public _Application WordApplication
        {
            get
            {
                return m_WordApp;
            }
        }
        public int WordCount
        {
            get
            {
                if (m_Document != null)
                {
                    Range rng = m_Document.Content;
                    rng.Select();
                    return m_Document.Characters.Count;
                }
                else
                    return -1;
            }
        }
        public object Missing
        {
            get
            {
                return missing;
            }
        }
        #endregion
        #region ��������
        #region �����ĵ�
        public void CreateDocument(string template)
        {
            object obj_template = template;
            if (template.Length <= 0) obj_template = missing;
            m_Document = m_WordApp.Documents.Add(ref obj_template, ref missing, ref missing, ref missing);
        }
        public void CreateDocument()
        {
            this.CreateDocument("");
        }
        #endregion
        #region ���ĵ�
        public void OpenDocument(string fileName, bool readOnly)
        {
            object obj_FileName = fileName;
            object obj_ReadOnly = readOnly;
            m_Document = m_WordApp.Documents.Open(ref obj_FileName, ref missing, ref obj_ReadOnly, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing);
        }
        public void OpenDocument(string fileName)
        {
            this.OpenDocument(fileName, false);
        }
        #endregion
        #region Save & SaveAs
        public void Save()
        {
            if (m_Document != null)
                m_Document.Save();
        }
        public void SaveAs(string fileName)
        {
            object obj_FileName = fileName;
            if (m_Document != null)
            {
                m_Document.SaveAs(ref obj_FileName, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
            }
        }
        #endregion
        #region Close
        public void Close(bool isSaveChanges)
        {
            object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
            if (isSaveChanges)
                saveChanges = WdSaveOptions.wdSaveChanges;
            if (m_Document != null)
                m_Document.Close(ref saveChanges, ref missing, ref missing);
        }
        #endregion
        #region �������
        /// <summary>
        /// ���ͼƬ
        /// </summary>
        /// <param name="picName"></param>
        public void AddPicture(string picName)
        {
            if (m_WordApp != null)
                m_WordApp.Selection.InlineShapes.AddPicture(picName, ref missing, ref missing, ref missing);
        }
        /// <summary>
        /// ����ҳü
        /// </summary>
        /// <param name="text"></param>
        /// <param name="align"></param>
        public void SetHeader(string text, WdParagraphAlignment align)
        {
            this.m_WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
            this.m_WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(text); //�����ı�
            this.m_WordApp.Selection.ParagraphFormat.Alignment = align;  //���ö��뷽ʽ
            this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // ����ҳü����
        }
        /// <summary>
        /// ����ҳ��
        /// </summary>
        /// <param name="text"></param>
        /// <param name="align"></param>
        public void SetFooter(string text, WdParagraphAlignment align)
        {
            this.m_WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryFooter;
            this.m_WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(text); //�����ı�
            this.m_WordApp.Selection.ParagraphFormat.Alignment = align;  //���ö��뷽ʽ
            this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // ����ҳü����
        }
        #endregion
        #region Print

        public void PrintOut()
        {
            object copies = "1";
            object pages = "";
            object range = WdPrintOutRange.wdPrintAllDocument;
            object items = WdPrintOutItem.wdPrintDocumentContent;
            object pageType = WdPrintOutPages.wdPrintAllPages;
            object oTrue = true;
            object oFalse = false;
            this.m_Document.PrintOut(
                ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
                ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);
        }
        public void PrintPreview()
        {
            if (m_Document != null)
                m_Document.PrintPreview();
        }
        #endregion
        public void Paste()
        {
            try
            {
                if (m_Document != null)
                {
                    m_Document.ActiveWindow.Selection.Paste();
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
        #endregion
        #region �ĵ��е��ı��Ͷ���
        public void AppendText(string text)
        {
            Selection currentSelection = this.m_WordApp.Selection;
            // Store the user's current Overtype selection
            bool userOvertype = this.m_WordApp.Options.Overtype;
            // Make sure Overtype is turned off.
            if (this.m_WordApp.Options.Overtype)
            {
                this.m_WordApp.Options.Overtype = false;
            }
            // Test to see if selection is an insertion point.
            if (currentSelection.Type == WdSelectionType.wdSelectionIP)
            {
                currentSelection.TypeText(text);
                currentSelection.TypeParagraph();
            }
            else
                if (currentSelection.Type == WdSelectionType.wdSelectionNormal)
                {
                    // Move to start of selection.
                    if (this.m_WordApp.Options.ReplaceSelection)
                    {
                        object direction = WdCollapseDirection.wdCollapseStart;
                        currentSelection.Collapse(ref direction);
                    }
                    currentSelection.TypeText(text);
                    currentSelection.TypeParagraph();
                }
                else
                {
                    // Do nothing.
                }
            // Restore the user's Overtype selection
            this.m_WordApp.Options.Overtype = userOvertype;
        }
        #endregion
        #region �������滻�ĵ��е��ı�
        public void Replace(string oriText, string replaceText)
        {
            object replaceAll = WdReplace.wdReplaceAll;
            this.m_WordApp.Selection.Find.ClearFormatting();
            this.m_WordApp.Selection.Find.Text = oriText;
            this.m_WordApp.Selection.Find.Replacement.ClearFormatting();
            this.m_WordApp.Selection.Find.Replacement.Text = replaceText;
            this.m_WordApp.Selection.Find.Execute(
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref replaceAll, ref missing, ref missing, ref missing, ref missing);
        }

        #endregion
        #region �ĵ��е�Word���
        /// <summary>
        /// ���ĵ��в�����
        /// </summary>
        /// <param name="startIndex">��ʼλ��</param>
        /// <param name="endIndex">����λ��</param>
        /// <param name="rowCount">����</param>
        /// <param name="columnCount">����</param>
        /// <returns></returns>
        public Table AppendTable(int startIndex, int endIndex, int rowCount, int columnCount)
        {
            object start = startIndex;
            object end = endIndex;
            Range tableLocation = this.m_Document.Range(ref start, ref end);
            return this.m_Document.Tables.Add(tableLocation, rowCount, columnCount, ref missing, ref missing);
        }
        /// <summary>
        /// �����
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Row AppendRow(Table table)
        {
            object row = table.Rows[1];
            return table.Rows.Add(ref row);
        }
        /// <summary>
        /// �����
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Column AppendColumn(Table table)
        {
            object column = table.Columns[1];
            return table.Columns.Add(ref column);
        }
        /// <summary>
        /// ���õ�Ԫ����ı��Ͷ��뷽ʽ
        /// </summary>
        /// <param name="cell">��Ԫ��</param>
        /// <param name="text">�ı�</param>
        /// <param name="align">���뷽ʽ</param>
        public void SetCellText(Cell cell, string text, WdParagraphAlignment align)
        {
            cell.Range.Text = text;
            cell.Range.ParagraphFormat.Alignment = align;
        }
        #endregion
        #region IDisposable ��Ա
        public void Dispose()
        {
            try
            {
                if (m_WordApp != null)
                    m_WordApp.Quit(ref missing, ref missing, ref missing);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
        }
        #endregion
    }
}
