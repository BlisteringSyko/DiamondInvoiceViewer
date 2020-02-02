using BrightIdeasSoftware;
using System.Windows.Forms;

namespace DiamondInvoiceViewer.Misc_Classes
{
    class Tags
    {
        public Form Form { get; set; }
        public FastObjectListView FastObjectListView { get; set; }
        public Label StatusLabel { get; set; }
        public Panel SearchPanel { get; set; }
        public TextBox SearchTextBox { get; set; }

        public Tags(Form form, Label statusLabel, FastObjectListView fastObjectListView, Panel searchPanel, TextBox searchTextBox)
        {
            this.Form = form;
            this.StatusLabel = statusLabel;
            this.FastObjectListView = fastObjectListView;
            this.SearchPanel = searchPanel;
            this.SearchTextBox = searchTextBox;
        }

    }
}
