using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DiamondInvoiceViewer.Misc_Classes;
using DiamondInvoiceViewer.Services;
using formCustomizer;

namespace DiamondInvoiceViewer
{
    public partial class Form1 : Form
    {
        ServiceForm1 service;

        FormCustomizer formCustomizer;

        public Form1()
        {
            InitializeComponent();
            service = new ServiceForm1();

            Tags tag = new Tags(this, lblStatus, fastObjectListView1, SearchPanel, SearchTextBox, progressBar1);

            this.Tag = tag;
            fastObjectListView1.Tag = tag;
            lblStatus.Tag = tag;
            openToolStripMenuItem.Tag = tag;
            SearchPanel.Tag = tag;
            SearchTextBox.Tag = tag;
            searchToolStripMenuItem.Tag = tag;
            clearToolStripMenuItem.Tag = tag;
            showImagesToolStripMenuItem.Tag = tag;

            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Sizable;

            if (formCustomizer is null) formCustomizer = new FormCustomizer(base.Handle, this);

            service.LoadSettings(this);

            RegisterEvents();

            SetOlvAspectGetters();

            RegisterBindings();

            SetFormCustomizerInitialColors();

            UpdateFormCustomizer();

            formCustomizer._exclusions.Add(lblStatus);

            formCustomizer.updateControlStyles(this);

            if (olvColUnitsShipped.IsVisible) olvColUnitsShipped.DisplayIndex = 0;
            if (olvColImage.IsVisible) olvColImage.DisplayIndex = 1;
            if (olvColItemCode.IsVisible) olvColItemCode.DisplayIndex = 2;
            if (olvColDiscount.IsVisible) olvColDiscount.DisplayIndex = 3;
            if (olvColItemDesc.IsVisible) olvColItemDesc.DisplayIndex = 4;
            if (olvColCustomerFirstName.IsVisible) olvColCustomerFirstName.DisplayIndex = 5;
            if (olvColCustomerLastName.IsVisible) olvColCustomerLastName.DisplayIndex = 6;
            if (olvColCustomerEmail.IsVisible) olvColCustomerEmail.DisplayIndex = 7;
            if (olvColRetailPrice.IsVisible) olvColRetailPrice.DisplayIndex = 8;
            if (olvColUnitPrice.IsVisible) olvColUnitPrice.DisplayIndex = 9;
            if (olvColInvoiceAmount.IsVisible) olvColInvoiceAmount.DisplayIndex = 10;
            if (olvColCatagory.IsVisible) olvColCatagory.DisplayIndex = 11;
            if (olvColOrderType.IsVisible) olvColOrderType.DisplayIndex = 12;
            if (olvColPAF.IsVisible) olvColPAF.DisplayIndex = 13;
            if (olvColOrderNum.IsVisible) olvColOrderNum.DisplayIndex = 14;
            if (olvColUpc.IsVisible) olvColUpc.DisplayIndex = 15;
            if (olvColIsbn.IsVisible) olvColIsbn.DisplayIndex = 16;
            if (olvColEan.IsVisible) olvColEan.DisplayIndex = 17;
            if (olvColPO.IsVisible) olvColPO.DisplayIndex = 18;
            if (olvColAllocated.IsVisible) olvColAllocated.DisplayIndex = 19;
            if (olvColPublisher.IsVisible) olvColPublisher.DisplayIndex = 20;
            if (olvColSeriesCode.IsVisible) olvColSeriesCode.DisplayIndex = 21;


            //olvColUnitsShipped.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColImage.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColItemCode.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColDiscount.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColItemDesc.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColCustomerFirstName.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColCustomerLastName.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColCustomerEmail.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColRetailPrice.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColUnitPrice.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColInvoiceAmount.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColCatagory.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColOrderType.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColPAF.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColOrderNum.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColUpc.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColIsbn.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColEan.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColPO.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColAllocated.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColPublisher.DisplayIndex = fastObjectListView1.Columns.Count - 1;
            //olvColSeriesCode.DisplayIndex = fastObjectListView1.Columns.Count - 1;

            showImagesToolStripMenuItem.Checked = service.ShowImages;
            downloadImagesToolStripMenuItem.Checked = service.DownloadImages;

        }

        void RegisterEvents()
        {
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(service.Form1_FormClosing);

            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(service.contextMenuStrip1_Opening);

            this.openItemInPreviewsWorldToolStripMenuItem.Click += new System.EventHandler(service.openItemInPreviewsWorldToolStripMenuItem_Click);

            this.lblStatus.DragDrop += new System.Windows.Forms.DragEventHandler(service.label1_DragDrop);
            this.lblStatus.DragEnter += new System.Windows.Forms.DragEventHandler(service.label1_DragEnter);

            this.fastObjectListView1.DragDrop += new System.Windows.Forms.DragEventHandler(service.fastObjectListView1_DragDrop);
            this.fastObjectListView1.DragEnter += new System.Windows.Forms.DragEventHandler(service.fastObjectListView1_DragEnter);
            this.fastObjectListView1.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(service.fastObjectListView1_CellRightClick);

            this.exitToolStripMenuItem.Click += new System.EventHandler(service.exitToolStripMenuItem_Click);

            this.aboutToolStripMenuItem.Click += new System.EventHandler(service.aboutToolStripMenuItem_Click);

            this.openToolStripMenuItem.Click += new System.EventHandler(service.openToolStripMenuItem_Click);

            this.lblStatus.Click += new System.EventHandler(service.label1_Click);

            this.SearchTextBox.TextChanged += new System.EventHandler(service.textBox1_TextChanged);

            this.searchToolStripMenuItem.Click += new System.EventHandler(service.searchToolStripMenuItem_Click);

            this.clearToolStripMenuItem.Click += new System.EventHandler(service.clearToolStripMenuItem_Click);

            this.fastObjectListView1.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(service.fastObjectListView1_CellClick);

            this.showImagesToolStripMenuItem.CheckStateChanged += new System.EventHandler(service.showImagesToolStripMenuItem_CheckStateChanged);

            this.downloadImagesToolStripMenuItem.CheckStateChanged += new System.EventHandler(service.downloadImagesToolStripMenuItem_CheckStateChanged);
        }

        void RegisterBindings()
        {
            this.DataBindings.Add(new Binding("Text", service, "Title", false, DataSourceUpdateMode.OnPropertyChanged));
            labelWindowTitle.DataBindings.Add(new Binding("Text", service, "Title", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        void SetOlvAspectGetters()
        {
            olvColItemCode.AspectGetter = delegate (object x)
            {
                if (!(((CsvRow)x).ProcessedAsField is null) && ((CsvRow)x).ProcessedAsField.Trim() != "")
                {
                    return ((CsvRow)x).ProcessedAsField;
                }
                return ((CsvRow)x).ItemCode;
            };
            olvColCatagory.AspectGetter = delegate (object x)
            {
                return Enums.GetEnumDescription((Catagory)((CsvRow)x).CatagoryCode);
            };
            olvColOrderType.AspectGetter = delegate (object x)
            {
                return Enums.GetEnumDescription((OrderType)((CsvRow)x).OrderType);
            };
            olvColPAF.AspectGetter = delegate (object x)
            {
                if (!(((CsvRow)x).ProcessedAsField is null) && ((CsvRow)x).ProcessedAsField.Trim() != "")
                {
                    return ((CsvRow)x).ItemCode;
                }
                return ((CsvRow)x).ProcessedAsField;
            };
            olvColAllocated.AspectGetter = delegate (object x)
            {
                return Enums.GetEnumDescription((Allocated)((CsvRow)x).AllocatedCode);
            };
            olvColImage.ImageGetter = delegate (object x)
            {
                if (service.ShowImages)
                {
                    string path = Application.StartupPath + @"\Thumbs\" + ((CsvRow)x).ItemCode + ".jpg";
                    if (File.Exists(path))
                    {
                        return (Bitmap)Bitmap.FromFile(path);
                    }
                }
                return null;
            };
        }

        void SetFormCustomizerInitialColors()
        {
            formCustomizer.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            formCustomizer.TextColor = ColorTranslator.FromHtml("#000000");
            formCustomizer.InputTextColor = ColorTranslator.FromHtml("#000000");
            formCustomizer.TitleTextColor = ColorTranslator.FromHtml("#DCDCDC");
            formCustomizer.MenuTextColor = ColorTranslator.FromHtml("#DCDCDC");
            formCustomizer.ControlButtonTextColor = ColorTranslator.FromHtml("#FFFFFF");
            formCustomizer.BorderColor = ColorTranslator.FromHtml("#0A4F94");
            formCustomizer.ShadowColor = ColorTranslator.FromHtml("#D0D3D4");
            formCustomizer.TextStatusStripColor = Color.White;
            formCustomizer.TitleBarColor = ColorTranslator.FromHtml("#2A6FB4");
        }

        void UpdateFormCustomizer()
        {
            formCustomizer.setTitleBar(panelControlBox);
            formCustomizer.setTitleLabel(labelWindowTitle);
            formCustomizer.setMenuStrip(menuStrip1);
            formCustomizer.setIcon(pbWindowicon);
            formCustomizer.setCloseButton(buttonClose);
            formCustomizer.setMaxiButton(buttonMax);
            formCustomizer.setMiniButton(buttonMin);

            panelContent.BackColor = formCustomizer.BackColor;
            lblStatus.ForeColor = formCustomizer.TitleBarColor;

            fastObjectListView1.BackColor = formCustomizer.BackColor;
            fastObjectListView1.ForeColor = formCustomizer.TextColor;
            fastObjectListView1.AlternateRowBackColor = formCustomizer.ShadowColor;

            fastObjectListView1.SelectedBackColor = formCustomizer.TitleBarColor;
            fastObjectListView1.SelectedForeColor = formCustomizer.TitleTextColor;
        }

        protected override void WndProc(ref Message m)
        {
            if (formCustomizer is null) formCustomizer = new FormCustomizer(base.Handle, this);
            if (formCustomizer.pWndProc(ref m)) base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (service != null)) service.Dispose();
            if (disposing && (components != null)) components.Dispose();

            base.Dispose(disposing);
        }


    }
}
