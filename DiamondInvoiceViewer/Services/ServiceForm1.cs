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
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DiamondInvoiceViewer
{
    class ServiceForm1 : IDisposable
    {
        public string Title { get; set; }

        readonly string SettingsPath;

        public bool ShowImages { get; set; }
        public bool DownloadImages { get; set; }

        public ServiceForm1()
        {
            Title = "Diamond Invoice Viewer";
            SettingsPath = Application.StartupPath + @"/Settings.json";
            ShowImages = true;
            DownloadImages = true;
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
                    //((Form)sender).Location = new Point(Settings.LocationX.Value, Settings.LocationY.Value);
                }
                if (Settings.Height.HasValue)
                {
                    //((Form)sender).Height = Settings.Height.Value;
                }
                if (Settings.Width.HasValue)
                {
                    //((Form)sender).Width = Settings.Width.Value;
                }
                if (Settings.ShowImages.HasValue)
                {
                    ShowImages = Settings.ShowImages.Value;
                }

                if (Settings.DownloadImages.HasValue)
                {
                    DownloadImages = Settings.DownloadImages.Value;
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
            Settings.ShowImages = ShowImages;
            Settings.DownloadImages = DownloadImages;

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


        internal void fastObjectListView1_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                string itemcode = ((CsvRow)e.Model).ItemCode;
                ItemDetails iD = new ItemDetails(Application.StartupPath + $"\\Images\\{itemcode}.jpg", itemcode);
                iD.WindowState = FormWindowState.Maximized;
                iD.Show();
            }
        }

        internal void showImagesToolStripMenuItem_CheckStateChanged(object sender, System.EventArgs e)
        {
            ShowImages = ((ToolStripMenuItem)sender).Checked;
            if (((ToolStripMenuItem)sender).Checked)
            {
                ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.RowHeight = 100;
            }
            else
            {
                ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.RowHeight = 20;
                ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.Refresh();
            }
        }

        internal void downloadImagesToolStripMenuItem_CheckStateChanged(object sender, System.EventArgs e)
        {
            DownloadImages = ((ToolStripMenuItem)sender).Checked;
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
            ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.Hide();
            ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.SetObjects(null);
            ((Tags)((ToolStripMenuItem)sender).Tag).StatusLabel.Text = "Drag and drop your invoice csv file here";
            ((Tags)((ToolStripMenuItem)sender).Tag).Form.Refresh();
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
        internal async void openToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Value (*.csv)|*.csv";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.Hide();
                ((Tags)((ToolStripMenuItem)sender).Tag).StatusLabel.Show();
                ((Tags)((ToolStripMenuItem)sender).Tag).StatusLabel.Text = "Loading Invoice" + Environment.NewLine;
                ((Tags)((ToolStripMenuItem)sender).Tag).Form.Refresh();
                ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.SetObjects(await ParseCsvAsync(ofd.FileName, ((Tags)((ToolStripMenuItem)sender).Tag).Form, ((Tags)((FastObjectListView)sender).Tag).Progressbar, ((Tags)((FastObjectListView)sender).Tag).StatusLabel));
                ((Tags)((ToolStripMenuItem)sender).Tag).Form.Text = Title;
                ((Tags)((ToolStripMenuItem)sender).Tag).Progressbar.Hide();
                ((Tags)((ToolStripMenuItem)sender).Tag).StatusLabel.Hide();
                ((Tags)((ToolStripMenuItem)sender).Tag).FastObjectListView.Show();
                ((Tags)((ToolStripMenuItem)sender).Tag).Form.Refresh();
            }
        }

        internal async void label1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Value (*.csv)|*.csv";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ((Tags)((Label)sender).Tag).FastObjectListView.Hide();
                ((Tags)((Label)sender).Tag).StatusLabel.Show();
                ((Tags)((Label)sender).Tag).StatusLabel.Text = "Loading Invoice" + Environment.NewLine;
                ((Tags)((Label)sender).Tag).Form.Refresh();
                ((Tags)((Label)sender).Tag).FastObjectListView.SetObjects(await ParseCsvAsync(ofd.FileName, ((Tags)((Label)sender).Tag).Form, ((Tags)((FastObjectListView)sender).Tag).Progressbar, ((Tags)((FastObjectListView)sender).Tag).StatusLabel));
                ((Tags)((Label)sender).Tag).Form.Text = Title;
                ((Tags)((Label)sender).Tag).Progressbar.Hide();
                ((Tags)((Label)sender).Tag).StatusLabel.Hide();
                ((Tags)((Label)sender).Tag).FastObjectListView.Show();
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
        internal async void fastObjectListView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!(fileList is null) && System.IO.File.Exists(fileList[0]))
            {
                ((FastObjectListView)sender).Hide();
                ((Tags)((FastObjectListView)sender).Tag).StatusLabel.Show();
                ((Tags)((FastObjectListView)sender).Tag).StatusLabel.Text = "Loading Invoice" + Environment.NewLine;
                ((Tags)((FastObjectListView)sender).Tag).Form.Refresh();
                ((FastObjectListView)sender).SetObjects(await ParseCsvAsync(fileList[0], ((Tags)((FastObjectListView)sender).Tag).Form, ((Tags)((FastObjectListView)sender).Tag).Progressbar, ((Tags)((FastObjectListView)sender).Tag).StatusLabel));
                ((Tags)((FastObjectListView)sender).Tag).Form.Text = Title;
                ((Tags)((FastObjectListView)sender).Tag).Progressbar.Hide();
                ((Tags)((FastObjectListView)sender).Tag).StatusLabel.Hide();
                ((FastObjectListView)sender).Show();
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
        internal async void label1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!(fileList is null) && System.IO.File.Exists(fileList[0]))
            {
                ((Tags)((Label)sender).Tag).FastObjectListView.Hide();
                ((Tags)((Label)sender).Tag).StatusLabel.Text = "Loading Invoice" + Environment.NewLine;
                ((Tags)((Label)sender).Tag).Form.Refresh();
                ((Tags)((Label)sender).Tag).FastObjectListView.SetObjects(await ParseCsvAsync(fileList[0], ((Tags)((Label)sender).Tag).Form,((Tags)((Label)sender).Tag).Progressbar, ((Tags)((Label)sender).Tag).StatusLabel));
                ((Tags)((Label)sender).Tag).Form.Text = Title;
                ((Label)sender).Hide();
                ((Tags)((Label)sender).Tag).Progressbar.Hide();
                ((Tags)((Label)sender).Tag).FastObjectListView.Show();
                ((Tags)((Label)sender).Tag).Form.Refresh();
            }
        }
        #endregion

        #region "Parse Csv"
        internal async System.Threading.Tasks.Task<List<CsvRow>> ParseCsvAsync(string PathToFile, Form form, ProgressBar progressBar, Label label)
        {
            List<CsvRow> csvRows = new List<CsvRow>();
            int numofitems;
            using (TextFieldParser parser = new TextFieldParser(PathToFile))
            {
                numofitems = parser.ReadToEnd().Split('\n').Length;
                progressBar.Minimum = 0;
                progressBar.Maximum = numofitems - 1;
                progressBar.Value = 0;
                progressBar.Show();
            }
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

                    if (invoiceData && fields.Length == 9) csvRows.Add(await ParseNormalInvoiceAsync(fields));

                    if (pullboxData && fields.Length == 11 && fields[0] != "Customer Email")
                    {
                        csvRows.Add(await ParsePullBoxInvoiceAsync(fields));
                        Title = "Diamond Invoice Parser";
                    }
                    if (invoiceData && fields.Length == 18) csvRows.Add(await ParseExtendedInvoiceAsync(fields));
                    label.Text = "Loading Invoice" + Environment.NewLine + row + "/" + numofitems;
                    if (DownloadImages) label.Text += Environment.NewLine + "(The first time downloading images" + Environment.NewLine + "can take some time)";
                    progressBar.Value = row;
                    form.Refresh();
                    
                }
            }
            return csvRows;
        }

        async System.Threading.Tasks.Task<CsvRow> ParsePullBoxInvoiceAsync(string[] fields)
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
            if (DownloadImages && (!File.Exists(Application.StartupPath + $"\\Images\\{csvRow.ItemCode}.jpg") || !File.Exists(Application.StartupPath + $"\\Thumbs\\{csvRow.ItemCode}.jpg")))
            {
                await Task.Delay(10);
                string img = await GetItemImageUrlAsync($"https://www.previewsworld.com/Catalog/{csvRow.ItemCode}");
                SaveImage(img, Application.StartupPath + $"\\Images\\{csvRow.ItemCode}.jpg", csvRow.ItemCode);
            }
            return csvRow;
        }

        async System.Threading.Tasks.Task<CsvRow> ParseNormalInvoiceAsync(string[] fields)
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
                        if (Char.IsLetter(field[field.Length - 1]))
                        {
                            csvRow.ItemCode = field.Substring(0, field.Length - 1);
                        }
                        else
                        {
                            csvRow.ItemCode = field;
                        }
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
            
            if (DownloadImages && (!File.Exists(Application.StartupPath + $"\\Images\\{csvRow.ItemCode}.jpg") || !File.Exists(Application.StartupPath + $"\\Thumbs\\{csvRow.ItemCode}.jpg")))
            {
                await Task.Delay(10);
                string img = await GetItemImageUrlAsync($"https://www.previewsworld.com/Catalog/{csvRow.ItemCode}");
                SaveImage(img, Application.StartupPath + $"\\Images\\{csvRow.ItemCode}.jpg", csvRow.ItemCode);
            }
            return csvRow;
        }

        async System.Threading.Tasks.Task<CsvRow> ParseExtendedInvoiceAsync(string[] fields)
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
            if (DownloadImages && (!File.Exists(Application.StartupPath + $"\\Images\\{csvRow.ItemCode}.jpg") || !File.Exists(Application.StartupPath + $"\\Thumbs\\{csvRow.ItemCode}.jpg")))
            {
                await Task.Delay(10);
                string img = await GetItemImageUrlAsync($"https://www.previewsworld.com/Catalog/{csvRow.ItemCode}");
                SaveImage(img, Application.StartupPath + $"\\Images\\{csvRow.ItemCode}.jpg", csvRow.ItemCode);
            }
            return csvRow;
        }
        #endregion

        async System.Threading.Tasks.Task<string> GetItemImageUrlAsync(string address)
        {
            var config = Configuration.Default.WithDefaultLoader();
            string imageUrl = (await BrowsingContext.New(config).OpenAsync(address))
                .DocumentElement.Descendents()
                .Where(x => x.NodeType == NodeType.Element)
                .OfType<IHtmlMetaElement>()
                .Where(x => x.Attributes["property"]?.Value == "og:image")
                .Select(x => x.Attributes["content"]?.Value)
                .FirstOrDefault();

            return imageUrl;
        }

        public void SaveImage(string imageUrl, string filename, string itemcode)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Images"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Images");
            }
            if (!Directory.Exists(Application.StartupPath + @"\Thumbs"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Thumbs");
            }

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(imageUrl), filename);
                Bitmap original = (Bitmap)Bitmap.FromFile(filename);
                int w = original.Width / (original.Height / 100);
                Bitmap resized = new Bitmap(original, new Size(w, 100));
                resized.Save(Application.StartupPath + @"\Thumbs\" + itemcode + ".jpg");
                original.Dispose();
                resized.Dispose();
            }

        }

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
