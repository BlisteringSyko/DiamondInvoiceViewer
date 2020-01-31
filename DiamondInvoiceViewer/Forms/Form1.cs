using System;
using System.Drawing;
using System.Windows.Forms;
using DiamondInvoiceViewer.Services;
using Newtonsoft.Json;

namespace DiamondInvoiceViewer
{
    public partial class Form1 : Form
    {
        ServiceForm1 service;
        readonly string SettingsPath;


        public Form1()
        {
            InitializeComponent();
            service = new ServiceForm1();


            this.fastObjectListView1.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(service.fastObjectListView1_CellRightClick);

            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(service.contextMenuStrip1_Opening);

            this.openItemInPreviewsWorldToolStripMenuItem.Click += new System.EventHandler(service.openItemInPreviewsWorldToolStripMenuItem_Click);

            this.DragDrop += new System.Windows.Forms.DragEventHandler(service.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(service.Form1_DragEnter);

            this.fastObjectListView1.DragDrop += new System.Windows.Forms.DragEventHandler(service.fastObjectListView1_DragDrop);
            this.fastObjectListView1.DragEnter += new System.Windows.Forms.DragEventHandler(service.fastObjectListView1_DragEnter);

            this.Tag = fastObjectListView1;
            fastObjectListView1.Tag = this;

            olvColumn2.AspectGetter = delegate (object x)
            {
                CsvRow csvRow = (CsvRow)x;
                if (!(csvRow.ProcessedAsField is null) && csvRow.ProcessedAsField.Trim() != "") return csvRow.ProcessedAsField;
                return csvRow.ItemCode;
            };
            olvColumn8.AspectGetter = delegate (object x)
            {
                return service.GetCatgoryString(((CsvRow)x).CatagoryCode);
            };
            olvColumn9.AspectGetter = delegate (object x)
            {
                return service.GetOrderTypeString(((CsvRow)x).OrderType);
            };
            olvColumn16.AspectGetter = delegate (object x)
            {
                return service.GetAllocatedString(((CsvRow)x).AllocatedCode);
            };

            this.DataBindings.Add(new Binding("Text", service, "Title", false, DataSourceUpdateMode.OnPropertyChanged));
            SettingsPath = Application.StartupPath + @"/Settings.json";

            LoadSettings();
        }

        void LoadSettings()
        {
            if (System.IO.File.Exists(SettingsPath))
            {
                String raw = System.IO.File.ReadAllText(SettingsPath);
                Json Settings = JsonConvert.DeserializeObject<Json>(raw);

                if (!(Settings.OlvState is null))
                {
                    fastObjectListView1.RestoreState(Settings.OlvState);
                }
                if (!(Settings.LocationX is null) && !(Settings.LocationY is null))
                {
                    this.Location = new Point(Settings.LocationX.Value, Settings.LocationY.Value);
                }
            }
        }

        void SaveSettings()
        {
            Json Settings = new Json();

            Settings.OlvState = fastObjectListView1.SaveState();
            Settings.LocationX = this.Location.X;
            Settings.LocationY = this.Location.Y;

            string raw = JsonConvert.SerializeObject(Settings, Formatting.Indented);

            System.IO.File.WriteAllText(SettingsPath, raw);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
