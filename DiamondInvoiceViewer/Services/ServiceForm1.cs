using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DiamondInvoiceViewer.Services;
using DiamondInvoiceViewer.Forms;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using DiamondInvoiceViewer.Misc_Classes;

namespace DiamondInvoiceViewer
{
    class ServiceForm1 : IDisposable
    {
        public string Title { get; set; }

        readonly string SettingsPath;

        public ServiceForm1()
        {
            Title = "Diamond Invoice Viewer";
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
                    ((Tags)((Form)sender).Tag).FastObjectListView.RestoreState(Settings.OlvState);
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
            Settings.OlvState = ((Tags)((Form)sender).Tag).FastObjectListView.SaveState();
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
        internal void clearToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.SetObjects(null);
            ((Tags)((ToolStripMenuItem)sender).Tag).StatusLabel.Visible = true;
        }
        internal void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        internal void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        #region "OpenFile"
        internal void openToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Value (*.csv)|*.csv";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.SetObjects(ParseCsv(ofd.FileName));
                ((Tags)((ToolStripMenuItem)sender).Tag).Form.Text = Title;
                ((Tags)((ToolStripMenuItem)sender).Tag).StatusLabel.Hide();
                ((Tags)((ToolStripMenuItem)sender).Tag).Form.Refresh();
            }
        }

        internal void label1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Value (*.csv)|*.csv";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ((Tags)((Label)sender).Tag).FastObjectListView.SetObjects(ParseCsv(ofd.FileName));
                ((Tags)((Label)sender).Tag).Form.Text = Title;
                ((Tags)((Label)sender).Tag).StatusLabel.Hide();
                ((Tags)((Label)sender).Tag).Form.Refresh();
            }
        }
        #endregion

        #region "Filter and Search"
        internal void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (((TextBox)sender).Text.Trim() != "")
            {
                TextMatchFilter filter = TextMatchFilter.Contains(((Tags)((TextBox)sender).Tag).FastObjectListView, ((TextBox)sender).Text);
                ((Tags)((TextBox)sender).Tag).FastObjectListView.ModelFilter = filter;
            }
            else
            {
                ((Tags)((TextBox)sender).Tag).FastObjectListView.ModelFilter = null;
            }
        }

        internal void searchToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (((Tags)((ToolStripMenuItem)sender).Tag).SearchPanel.Visible)
            {
                ((Tags)((ToolStripMenuItem)sender).Tag).SearchPanel.Visible = false;
                ((Tags)((ToolStripMenuItem)sender).Tag).SearchTextBox.Text = "";
                ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.ModelFilter = null;
            }
            else
            {
                ((Tags)((ToolStripMenuItem)sender).Tag).SearchPanel.Visible = true;
                ((Tags)((ToolStripMenuItem)sender).Tag).SearchTextBox.Focus();
            }
        }
        #endregion

        #region "Drag & Drop"
        internal void fastObjectListView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!(fileList is null) && System.IO.File.Exists(fileList[0]))
            {
                ((FastObjectListView)sender).SetObjects(ParseCsv(fileList[0]));
                ((Tags)((FastObjectListView)sender).Tag).Form.Text = Title;
                ((Tags)((FastObjectListView)sender).Tag).Form.Refresh();
            }
        }
        internal void fastObjectListView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        internal void label1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        internal void label1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!(fileList is null) && System.IO.File.Exists(fileList[0]))
            {
                ((Tags)((Label)sender).Tag).FastObjectListView.SetObjects(ParseCsv(fileList[0]));
                ((Tags)((Label)sender).Tag).Form.Text = Title;
                ((Label)sender).Hide();
                ((Tags)((Label)sender).Tag).Form.Refresh();
            }
        }
        #endregion

        #region "Parse Csv"
        internal List<CsvRow> ParseCsv(string PathToFile)
        {
            List<CsvRow> csvRows = new List<CsvRow>();
            using (TextFieldParser parser = new TextFieldParser(PathToFile))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool invoiceData = false;
                bool pullboxData = false;
                int row = 0;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields[0] == "Invoice on Disk") invoiceData = true;
                    if (fields[0] == "Customer Email" && fields[10] == "Qty") pullboxData = true;

                    if (invoiceData && fields.Length == 1 && row == 1) Title = $"Diamond Invoice Parser (Viewer: {fields[0]})"; // <<< The value is set, but the binding for form1 is not taking the value.

                    if (invoiceData) row += 1;

                    if (invoiceData && fields.Length == 9) csvRows.Add(ParseNormalInvoice(fields));

                    if (pullboxData && fields.Length == 11 && fields[0] != "Customer Email") csvRows.Add(ParsePullBoxInvoice(fields));

                    if (invoiceData && fields.Length == 18) csvRows.Add(ParseExtendedInvoice(fields));
                }
            }
            return csvRows;
        }

        CsvRow ParsePullBoxInvoice(string[] fields)
        {
            int column = 0;
            CsvRow csvRow = new CsvRow();
            foreach (string field in fields)
            {
                switch (column)
                {
                    case 0:
                        csvRow.CustomerEmail = field;
                        csvRow.CatagoryCode = 16;
                        csvRow.AllocatedCode = 3;
                        break;
                    case 1:
                        csvRow.CustomerFirstName = field;
                        break;
                    case 2:
                        csvRow.CustomerLastName = field;
                        break;
                    case 8:
                        csvRow.ItemCode = field;
                        break;
                    case 9:
                        csvRow.ItemDescription = field;
                        break;
                    case 10:
                        csvRow.UnitsShipped = int.Parse(field);
                        break;
                }
                column += 1;
            }
            return csvRow;
        }

        CsvRow ParseNormalInvoice(string[] fields)
        {
            int column = 0;
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
            return csvRow;
        }

        CsvRow ParseExtendedInvoice(string[] fields)
        {
            int column = 0;
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
            return csvRow;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
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
