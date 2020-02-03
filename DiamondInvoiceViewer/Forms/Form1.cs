using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
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

            Tags tag = new Tags(this, lblStatus, fastObjectListView1, SearchPanel, SearchTextBox);

            this.Tag = tag;
            fastObjectListView1.Tag = tag;
            lblStatus.Tag = tag;
            openToolStripMenuItem.Tag = tag;
            SearchPanel.Tag = tag;
            SearchTextBox.Tag = tag;
            searchToolStripMenuItem.Tag = tag;
            clearToolStripMenuItem.Tag = tag;

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
