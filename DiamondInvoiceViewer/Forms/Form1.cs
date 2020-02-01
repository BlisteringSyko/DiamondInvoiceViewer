using System.Windows.Forms;
using DiamondInvoiceViewer.Misc_Classes;
using DiamondInvoiceViewer.Services;

namespace DiamondInvoiceViewer
{
    public partial class Form1 : Form
    {
        ServiceForm1 service;

        public Form1()
        {
            InitializeComponent();
            service = new ServiceForm1();

            this.Tag = fastObjectListView1;
            fastObjectListView1.Tag = this;

            service.LoadSettings(this);

            RegisterEvents();

            SetOlvAspectGetters();

            RegisterBindings();
        }

        void RegisterEvents()
        {
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(service.Form1_FormClosing);

            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(service.contextMenuStrip1_Opening);

            this.openItemInPreviewsWorldToolStripMenuItem.Click += new System.EventHandler(service.openItemInPreviewsWorldToolStripMenuItem_Click);

            this.DragDrop += new System.Windows.Forms.DragEventHandler(service.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(service.Form1_DragEnter);

            this.fastObjectListView1.DragDrop += new System.Windows.Forms.DragEventHandler(service.fastObjectListView1_DragDrop);
            this.fastObjectListView1.DragEnter += new System.Windows.Forms.DragEventHandler(service.fastObjectListView1_DragEnter);
            this.fastObjectListView1.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(service.fastObjectListView1_CellRightClick);
        }

        void RegisterBindings()
        {
            this.DataBindings.Add(new Binding("Text", service, "Title", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        void SetOlvAspectGetters()
        {
            olvColumn2.AspectGetter = delegate (object x)
            {
                CsvRow csvRow = (CsvRow)x;
                if (!(csvRow.ProcessedAsField is null) && csvRow.ProcessedAsField.Trim() != "") return csvRow.ProcessedAsField;
                return csvRow.ItemCode;
            };
            olvColumn8.AspectGetter = delegate (object x)
            {
                return Enums.GetEnumDescription((Catagory)((CsvRow)x).CatagoryCode);
            };
            olvColumn9.AspectGetter = delegate (object x)
            {
                return Enums.GetEnumDescription((OrderType)((CsvRow)x).OrderType);
            };
            olvColumn16.AspectGetter = delegate (object x)
            {
                return Enums.GetEnumDescription((Allocated)((CsvRow)x).AllocatedCode);
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (service != null)) service.Dispose();
            if (disposing && (components != null)) components.Dispose();

            base.Dispose(disposing);
        }

    }
}
