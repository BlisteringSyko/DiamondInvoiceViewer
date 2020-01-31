namespace DiamondInvoiceViewer.Services
{
    public class CsvRow
    {
        public int UnitsShipped { get; set; }

        public string ItemCode { get; set; }

        public string DiscountCode { get; set; }

        public string ItemDescription { get; set; }

        public string RetailPrice { get; set; }

        public string UnitPrice { get; set; }

        public string InvoiceAmount { get; set; }

        public int CatagoryCode { get; set; }

        public int OrderType { get; set; }

        public string ProcessedAsField { get; set; }

        public string OrderNumber { get; set; }

        public string Upc { get; set; }

        public string Isbn { get; set; }

        public string Ean { get; set; }

        public string PoNumber { get; set; }

        public int AllocatedCode { get; set; }

        public string Publisher { get; set; }

        public string SeriesCode { get; set; }

    }
}
