namespace DiamondInvoiceViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.olvColUnitsShipped = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColItemCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDiscount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColItemDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColRetailPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColUnitPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvoiceAmount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCatagory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColOrderType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPAF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColOrderNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColUpc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColIsbn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColEan = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPO = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAllocated = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPublisher = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColSeriesCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openItemInPreviewsWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panelControlBox = new System.Windows.Forms.Panel();
            this.labelWindowTitle = new System.Windows.Forms.Label();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonMax = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbWindowicon = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.panelControlBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWindowicon)).BeginInit();
            this.SuspendLayout();
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.AllColumns.Add(this.olvColUnitsShipped);
            this.fastObjectListView1.AllColumns.Add(this.olvColItemCode);
            this.fastObjectListView1.AllColumns.Add(this.olvColDiscount);
            this.fastObjectListView1.AllColumns.Add(this.olvColItemDesc);
            this.fastObjectListView1.AllColumns.Add(this.olvColRetailPrice);
            this.fastObjectListView1.AllColumns.Add(this.olvColUnitPrice);
            this.fastObjectListView1.AllColumns.Add(this.olvColInvoiceAmount);
            this.fastObjectListView1.AllColumns.Add(this.olvColCatagory);
            this.fastObjectListView1.AllColumns.Add(this.olvColOrderType);
            this.fastObjectListView1.AllColumns.Add(this.olvColPAF);
            this.fastObjectListView1.AllColumns.Add(this.olvColOrderNum);
            this.fastObjectListView1.AllColumns.Add(this.olvColUpc);
            this.fastObjectListView1.AllColumns.Add(this.olvColIsbn);
            this.fastObjectListView1.AllColumns.Add(this.olvColEan);
            this.fastObjectListView1.AllColumns.Add(this.olvColPO);
            this.fastObjectListView1.AllColumns.Add(this.olvColAllocated);
            this.fastObjectListView1.AllColumns.Add(this.olvColPublisher);
            this.fastObjectListView1.AllColumns.Add(this.olvColSeriesCode);
            this.fastObjectListView1.AllowDrop = true;
            this.fastObjectListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColUnitsShipped,
            this.olvColItemCode,
            this.olvColDiscount,
            this.olvColItemDesc,
            this.olvColRetailPrice,
            this.olvColUnitPrice,
            this.olvColInvoiceAmount,
            this.olvColCatagory,
            this.olvColOrderType,
            this.olvColPAF,
            this.olvColOrderNum,
            this.olvColUpc,
            this.olvColPO,
            this.olvColAllocated,
            this.olvColPublisher,
            this.olvColSeriesCode});
            this.fastObjectListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.fastObjectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView1.FullRowSelect = true;
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(0, 55);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowCommandMenuOnRightClick = true;
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(1132, 395);
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.UseAlternatingBackColors = true;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.UseFilterIndicator = true;
            this.fastObjectListView1.UseFiltering = true;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            // 
            // olvColUnitsShipped
            // 
            this.olvColUnitsShipped.AspectName = "UnitsShipped";
            this.olvColUnitsShipped.Text = "Qty";
            this.olvColUnitsShipped.Width = 35;
            // 
            // olvColItemCode
            // 
            this.olvColItemCode.AspectName = "ItemCode";
            this.olvColItemCode.Text = "Item";
            this.olvColItemCode.Width = 85;
            // 
            // olvColDiscount
            // 
            this.olvColDiscount.AspectName = "DiscountCode";
            this.olvColDiscount.Text = "Discount";
            this.olvColDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColItemDesc
            // 
            this.olvColItemDesc.AspectName = "ItemDescription";
            this.olvColItemDesc.FillsFreeSpace = true;
            this.olvColItemDesc.Text = "Title";
            // 
            // olvColRetailPrice
            // 
            this.olvColRetailPrice.AspectName = "RetailPrice";
            this.olvColRetailPrice.Text = "Retail";
            this.olvColRetailPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColUnitPrice
            // 
            this.olvColUnitPrice.AspectName = "UnitPrice";
            this.olvColUnitPrice.Text = "Cost";
            this.olvColUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColInvoiceAmount
            // 
            this.olvColInvoiceAmount.AspectName = "InvoiceAmount";
            this.olvColInvoiceAmount.Text = "Invoice";
            this.olvColInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColCatagory
            // 
            this.olvColCatagory.AspectName = "CatagoryCode";
            this.olvColCatagory.Text = "Catagory";
            // 
            // olvColOrderType
            // 
            this.olvColOrderType.AspectName = "OrderType";
            this.olvColOrderType.Text = "Type";
            // 
            // olvColPAF
            // 
            this.olvColPAF.AspectName = "ProcessedAsField";
            this.olvColPAF.Text = "Original";
            // 
            // olvColOrderNum
            // 
            this.olvColOrderNum.AspectName = "OrderNumber";
            this.olvColOrderNum.Text = "Order#";
            this.olvColOrderNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColUpc
            // 
            this.olvColUpc.AspectName = "Upc";
            this.olvColUpc.Text = "Upc";
            this.olvColUpc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvColUpc.Width = 100;
            // 
            // olvColIsbn
            // 
            this.olvColIsbn.AspectName = "Isbn";
            this.olvColIsbn.DisplayIndex = 12;
            this.olvColIsbn.IsVisible = false;
            this.olvColIsbn.Text = "Isbn";
            this.olvColIsbn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColEan
            // 
            this.olvColEan.AspectName = "Ean";
            this.olvColEan.DisplayIndex = 13;
            this.olvColEan.IsVisible = false;
            this.olvColEan.Text = "Ean";
            this.olvColEan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColPO
            // 
            this.olvColPO.AspectName = "PoNumber";
            this.olvColPO.Text = "PO";
            this.olvColPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColAllocated
            // 
            this.olvColAllocated.AspectName = "AllocatedCode";
            this.olvColAllocated.Text = "Allocated";
            // 
            // olvColPublisher
            // 
            this.olvColPublisher.AspectName = "Publisher";
            this.olvColPublisher.Text = "Publisher";
            // 
            // olvColSeriesCode
            // 
            this.olvColSeriesCode.AspectName = "SeriesCode";
            this.olvColSeriesCode.Text = "Series";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItemInPreviewsWorldToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 26);
            // 
            // openItemInPreviewsWorldToolStripMenuItem
            // 
            this.openItemInPreviewsWorldToolStripMenuItem.Name = "openItemInPreviewsWorldToolStripMenuItem";
            this.openItemInPreviewsWorldToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.openItemInPreviewsWorldToolStripMenuItem.Text = "Open Item in PreviewsWorld";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.lblStatus);
            this.panelContent.Controls.Add(this.fastObjectListView1);
            this.panelContent.Controls.Add(this.SearchPanel);
            this.panelContent.Controls.Add(this.panelControlBox);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1132, 450);
            this.panelContent.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AllowDrop = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("MV Boli", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1132, 395);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Drag and drop your invoice csv file here";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.SearchTextBox);
            this.SearchPanel.Controls.Add(this.lblSearch);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchPanel.Location = new System.Drawing.Point(0, 25);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Padding = new System.Windows.Forms.Padding(5);
            this.SearchPanel.Size = new System.Drawing.Size(1132, 30);
            this.SearchPanel.TabIndex = 2;
            this.SearchPanel.Visible = false;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTextBox.Location = new System.Drawing.Point(55, 5);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(1072, 20);
            this.SearchTextBox.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearch.Location = new System.Drawing.Point(5, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 20);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelControlBox
            // 
            this.panelControlBox.Controls.Add(this.labelWindowTitle);
            this.panelControlBox.Controls.Add(this.buttonMin);
            this.panelControlBox.Controls.Add(this.buttonMax);
            this.panelControlBox.Controls.Add(this.buttonClose);
            this.panelControlBox.Controls.Add(this.menuStrip1);
            this.panelControlBox.Controls.Add(this.pbWindowicon);
            this.panelControlBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlBox.Location = new System.Drawing.Point(0, 0);
            this.panelControlBox.Name = "panelControlBox";
            this.panelControlBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panelControlBox.Size = new System.Drawing.Size(1132, 25);
            this.panelControlBox.TabIndex = 0;
            // 
            // labelWindowTitle
            // 
            this.labelWindowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWindowTitle.Location = new System.Drawing.Point(268, 0);
            this.labelWindowTitle.Name = "labelWindowTitle";
            this.labelWindowTitle.Size = new System.Drawing.Size(744, 22);
            this.labelWindowTitle.TabIndex = 0;
            this.labelWindowTitle.Text = "label1";
            this.labelWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonMin
            // 
            this.buttonMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMin.Location = new System.Drawing.Point(1012, 0);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(40, 22);
            this.buttonMin.TabIndex = 3;
            this.buttonMin.Text = "button3";
            this.buttonMin.UseVisualStyleBackColor = true;
            // 
            // buttonMax
            // 
            this.buttonMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMax.Location = new System.Drawing.Point(1052, 0);
            this.buttonMax.Name = "buttonMax";
            this.buttonMax.Size = new System.Drawing.Size(40, 22);
            this.buttonMax.TabIndex = 2;
            this.buttonMax.Text = "button2";
            this.buttonMax.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.Location = new System.Drawing.Point(1092, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(40, 22);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "button1";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(22, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(246, 22);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pbWindowicon
            // 
            this.pbWindowicon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbWindowicon.Location = new System.Drawing.Point(0, 0);
            this.pbWindowicon.Name = "pbWindowicon";
            this.pbWindowicon.Padding = new System.Windows.Forms.Padding(0, 0, 2, 5);
            this.pbWindowicon.Size = new System.Drawing.Size(22, 22);
            this.pbWindowicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWindowicon.TabIndex = 5;
            this.pbWindowicon.TabStop = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 450);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.panelControlBox.ResumeLayout(false);
            this.panelControlBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWindowicon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private BrightIdeasSoftware.OLVColumn olvColUnitsShipped;
        private BrightIdeasSoftware.OLVColumn olvColItemCode;
        private BrightIdeasSoftware.OLVColumn olvColDiscount;
        private BrightIdeasSoftware.OLVColumn olvColItemDesc;
        private BrightIdeasSoftware.OLVColumn olvColRetailPrice;
        private BrightIdeasSoftware.OLVColumn olvColUnitPrice;
        private BrightIdeasSoftware.OLVColumn olvColInvoiceAmount;
        private BrightIdeasSoftware.OLVColumn olvColCatagory;
        private BrightIdeasSoftware.OLVColumn olvColOrderType;
        private BrightIdeasSoftware.OLVColumn olvColPAF;
        private BrightIdeasSoftware.OLVColumn olvColOrderNum;
        private BrightIdeasSoftware.OLVColumn olvColUpc;
        private BrightIdeasSoftware.OLVColumn olvColIsbn;
        private BrightIdeasSoftware.OLVColumn olvColEan;
        private BrightIdeasSoftware.OLVColumn olvColPO;
        private BrightIdeasSoftware.OLVColumn olvColAllocated;
        private BrightIdeasSoftware.OLVColumn olvColPublisher;
        private BrightIdeasSoftware.OLVColumn olvColSeriesCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openItemInPreviewsWorldToolStripMenuItem;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelControlBox;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonMax;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelWindowTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pbWindowicon;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

