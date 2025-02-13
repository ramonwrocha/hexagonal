namespace Payment.Application.Adapters.PayPal;

public class PayPalConfiguration
{
    public string Environment { get; set; }
    public string MerchantID { get; set; }
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }
}
