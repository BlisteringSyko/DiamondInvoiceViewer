using System.Windows.Forms;

namespace DiamondInvoiceViewer.Forms
{
    public partial class ItemDetails : Form
    {
        public ItemDetails(string imagepath, string itemcode)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = imagepath;
            this.Text = itemcode;
        }
    }
}
