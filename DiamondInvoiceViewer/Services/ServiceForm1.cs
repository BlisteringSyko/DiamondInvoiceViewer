using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DiamondInvoiceViewer.Services;
using Microsoft.VisualBasic.FileIO;

namespace DiamondInvoiceViewer
{
    class ServiceForm1 : IDisposable
    {

        public List<CsvRow> csvRows { get; set; }

        public String Title { get; set; }

        public ServiceForm1()
        {
            Title = "Diamond Invoice Parser";
        }

        OLVListItem OlvSelectedItem { get; set; }
        internal void fastObjectListView1_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (!(e.Item is null))
            {
                OlvSelectedItem = e.Item;
            }
            else
            {
                OlvSelectedItem = null;
            }

        }

        internal void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (OlvSelectedItem is null)
            {
                e.Cancel = true;
            }
        }

        internal void openItemInPreviewsWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(OlvSelectedItem is null))
            {
                CsvRow row = (CsvRow)OlvSelectedItem.RowObject;
                Process.Start($"https://www.previewsworld.com/Catalog/{row.ItemCode}");
            }
        }

        internal void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        internal void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!(fileList is null) && System.IO.File.Exists(fileList[0]))
            {
                ParseCsv(fileList[0]);
                ((FastObjectListView)((Form)sender).Tag).SetObjects(csvRows);
                ((Form)sender).Text = Title;
            }

        }

        internal void fastObjectListView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!(fileList is null) && System.IO.File.Exists(fileList[0]))
            {
                ParseCsv(fileList[0]);
                ((FastObjectListView)sender).SetObjects(csvRows);
                ((Form)((FastObjectListView)sender).Tag).Text = Title; // The binding would not take the new value assigned in ParseCsv
            }
        }

        internal void fastObjectListView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        internal void ParseCsv(string PathToFile)
        {
            using (TextFieldParser parser = new TextFieldParser(PathToFile))
            {
                csvRows = new List<CsvRow>();

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool invoiceData = false;
                int row = 0;
                while (!parser.EndOfData)
                {

                    string[] fields = parser.ReadFields();
                    int column = 0;

                    if (fields[0] == "Invoice on Disk") invoiceData = true;

                    if (invoiceData && fields.Count() == 1 && row == 1)
                    {
                        Title = $"Diamond Invoice Parser (Invoice: {fields[0]})";
                    }
                    if (invoiceData) row += 1;

                    //Normal Invoice
                    if (invoiceData && fields.Count() == 9)
                    {
                        CsvRow csvRow = new CsvRow();
                        foreach (string field in fields)
                        {
                            switch (column)
                            {
                                case 0:
                                    csvRow.UnitsShipped = int.Parse(field);
                                    break;
                                case 1:
                                    csvRow.ItemCode = field;
                                    break;
                                case 2:
                                    csvRow.ItemDescription = field;
                                    break;
                                case 3:
                                    csvRow.RetailPrice = field;
                                    break;
                                case 4:
                                    csvRow.UnitPrice = field;
                                    break;
                                case 5:
                                    csvRow.InvoiceAmount = field;
                                    break;
                                case 6:
                                    csvRow.CatagoryCode = int.Parse(field);
                                    break;
                                case 7:
                                    csvRow.OrderType = int.Parse(field);
                                    break;
                                case 8:
                                    csvRow.Publisher = field;
                                    break;
                            }
                            column += 1;
                        }
                        csvRows.Add(csvRow);
                    }



                    //Extended Invoice
                    if (invoiceData && fields.Count() == 18)
                    {
                        CsvRow csvRow = new CsvRow();
                        foreach (string field in fields)
                        {
                            switch (column)
                            {
                                case 0:
                                    csvRow.UnitsShipped = int.Parse(field);
                                    break;
                                case 1:
                                    csvRow.ItemCode = field;
                                    break;
                                case 2:
                                    csvRow.DiscountCode = field;
                                    break;
                                case 3:
                                    csvRow.ItemDescription = field;
                                    break;
                                case 4:
                                    csvRow.RetailPrice = field;
                                    break;
                                case 5:
                                    csvRow.UnitPrice = field;
                                    break;
                                case 6:
                                    csvRow.InvoiceAmount = field;
                                    break;
                                case 7:
                                    csvRow.CatagoryCode = int.Parse(field);
                                    break;
                                case 8:
                                    csvRow.OrderType = int.Parse(field);
                                    break;
                                case 9:
                                    csvRow.ProcessedAsField = field;
                                    break;
                                case 10:
                                    csvRow.OrderNumber = field;
                                    break;
                                case 11:
                                    csvRow.Upc = field;
                                    break;
                                case 12:
                                    csvRow.Isbn = field;
                                    break;
                                case 13:
                                    csvRow.Ean = field;
                                    break;
                                case 14:
                                    csvRow.PoNumber = field;
                                    break;
                                case 15:
                                    csvRow.AllocatedCode = int.Parse(field);
                                    break;
                                case 16:
                                    csvRow.Publisher = field;
                                    break;
                                case 17:
                                    csvRow.SeriesCode = field;
                                    break;
                            }
                            column += 1;
                        }
                        csvRows.Add(csvRow);
                    }

                }


            }
        }

        public string GetAllocatedString(int value)
        {
            switch (value)
            {
                case 1:
                    return "Allocated";
                case 0:
                    return "Not Allocated";
            }
            return "";

        }

        public string GetOrderTypeString(int value)
        {
            switch (value)
            {
                case 2:
                    return "in-stock Reorder received via reship through a Diamond Distribution Center.";
                case 3:
                    return "Order Increase";
                case 4:
                    return "Advance Reorder filled from extras";
                case 5:
                    return "Back Order";
                case 6:
                    return "Credit[s]";
                case 7:
                    return "in-stock Reorder sent via direct ship from The Reorder Universe (TRU)/Star System";
                default:
                    return "Initial Order";
            }
        }

        public string GetCatgoryString(int value)
        {
            switch (value)
            {
                case 1:
                    return "Comimcs";
                case 2:
                    return "Magazines";
                case 3:
                    return "Trades";
                case 4:
                    return "Novels";
                case 5:
                    return "Games";
                case 6:
                    return " Cards:";
                case 7:
                    return "Novelties - Comics";
                case 8:
                    return "Novelties - Non Comics";
                case 9:
                    return "Apparel";
                case 10:
                    return "Toys & Models";
                case 11:
                    return "Suplies - Card";
                case 12:
                    return "Supplies - Comic";
                case 13:
                    return "Sales Tools";
                case 14:
                    return "Diamond Publications";
                case 15:
                    return "Posters/Prints/Portfolies/Calendars";
                case 16:
                    return "Video/Audio/Video Games";
            }

            return "";
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    csvRows = null;
                }



                disposedValue = true;
            }
        }

        ~ServiceForm1()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }

}
