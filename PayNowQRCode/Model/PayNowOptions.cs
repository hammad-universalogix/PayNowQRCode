namespace PayNowQRCode.Model
{
    public class PayNowOptions
    {
        public string UEN { get; set; }
        public string CompanyName { get; set; }
        public bool IsEditable { get; set; }
        public string ExpiryDate { get; set; }
        public double Amount { get; set; }
        public string PaymentReference { get; set; }

    }
}
