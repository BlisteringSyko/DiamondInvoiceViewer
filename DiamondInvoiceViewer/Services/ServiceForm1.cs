using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DiamondInvoiceViewer.Services;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace DiamondInvoiceViewer
{
    class ServiceForm1 : IDisposable
    {

        public List<CsvRow> csvRows { get; set; }

        public String Title { get; set; }

        readonly string SettingsPath;

        public ServiceForm1()
        {
            Title = "Diamond Invoice Parser";
            SettingsPath = Application.StartupPath + @"/Settings.json";
        }

        public void LoadSettings(object sender)
        {
            if (System.IO.File.Exists(SettingsPath))
            {
                String raw = System.IO.File.ReadAllText(SettingsPath);
                SettingsJson Settings = JsonConvert.DeserializeObject<SettingsJson>(raw);

                if (!(Settings.OlvState is null))
                {
                    ((FastObjectListView)((Form)sender).Tag).RestoreState(Settings.OlvState);
                }
                if (Settings.LocationX.HasValue && Settings.LocationY.HasValue)
                {
                    ((Form)sender).Location = new Point(Settings.LocationX.Value, Settings.LocationY.Value);
                }
                if (Settings.Height.HasValue)
                {
                    ((Form)sender).Height = Settings.Height.Value;
                }
                if (Settings.Width.HasValue)
                {
                    ((Form)sender).Width = Settings.Width.Value;
                }
            }
        }

        internal void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsJson Settings = new SettingsJson();
            Settings.OlvState = ((FastObjectListView)((Form)sender).Tag).SaveState();
            Settings.LocationX = ((Form)sender).Location.X;
            Settings.LocationY = ((Form)sender).Location.Y;
            Settings.Height = ((Form)sender).Height;
            Settings.Width = ((Form)sender).Width;

            string raw = JsonConvert.SerializeObject(Settings, Formatting.Indented);

            System.IO.File.WriteAllText(SettingsPath, raw);
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
                        Title = $"Diamond Invoice Parser (Invoice: {fields[0]})"; // <<< The value is set, the binding for form1 is not taking the value.
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
                                    if (field == "") csvRow.OrderType = 8;
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
