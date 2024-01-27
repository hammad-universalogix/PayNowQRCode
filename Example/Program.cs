using PayNowQRCode;
using PayNowQRCode.Model;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using QRCodeGenerator = QRCoder.QRCodeGenerator;

namespace Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PayNowOptions options = new PayNowOptions()
            {
                UEN = "123456789A",                 //UEN of the company
                CompanyName = "ABC Pte Ltd",     //Name of the Company
                Amount = 100,                       //Amount
                IsEditable = true,                  //User can edit the amount, false otherwise
                ExpiryDate = "20241231",            //Expiry date for the QR Code
                PaymentReference = "TQINV-10001"    //Extra payment reference, if any
            };
            string paynowQrCode = PayNowCodeGenerator.GeneratePayNowStr(options);

            Color darkColor = ColorTranslator.FromHtml("#90137b");
            Color lightColor = ColorTranslator.FromHtml("#ffffff");

            //QR using QRCoder lib
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(paynowQrCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            //Add paynow logo as icon in the center of image
            Bitmap original = qrCode.GetGraphic(24, darkColor, lightColor, (Bitmap)Bitmap.FromFile($@"{AppDomain.CurrentDomain.BaseDirectory}\\paynow_logo.png"), 30, 0, true, Color.White);
            //resize the generated bitmap
            Bitmap resized = new Bitmap(original, new Size(original.Width / 5, original.Height / 5));
            resized.Save("paynowQR.png", ImageFormat.Png);
        }
    }
}
