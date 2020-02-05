namespace DiamondInvoiceViewer
{
    class SettingsJson
    {
        public byte[] OlvState { get; set; }
        public bool? ShowImages { get; set; }
        public bool? DownloadImages { get; set; }
        public int? LocationX { get; set; }
        public int? LocationY { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
}
