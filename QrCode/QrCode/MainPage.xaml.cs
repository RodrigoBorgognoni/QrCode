using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QrCode
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnScan_Clicked(object sender, EventArgs e)
        {

            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) => {
                // Parar de escanear
                ScannerPage.IsScanning = false;
                
                // Puxa o valor do código escaneado
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    txtBarcode.Text = result.Text;
                });
            };


            await Navigation.PushAsync(ScannerPage);
        }
    }
}
