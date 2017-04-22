using Acr.UserDialogs;
using Lotto_fdj_PCL.AdMob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lotto_fdj_PCL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LotoCodesGagnantPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public LotoCodesGagnantPage()
        {
            InitializeComponent();

            GlobalVariable.count++;

            if (GlobalVariable.count == 4)
            {
                GlobalVariable.count = 0;

                Device.BeginInvokeOnMainThread(() =>
                {
                    callAPI();

                    IAdInterstitial adInterstitial = DependencyService.Get<IAdInterstitial>();

                    adInterstitial.ShowAd();
                });
            }
        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Veuillez patienter...", MaskType.Black);
            try
            {
                HttpClient client = new HttpClient();
                var uri = new Uri("http://www.achrafchikoun.com/fdj/Api/getLastFrance");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //loto
                    dynamic loto = output["loto"];
                    loto_n1_g.Text = loto[0]["n1_g"].Value;
                    loto_n2_g.Text = loto[0]["n2_g"].Value;
                    loto_n3_g.Text = loto[0]["n3_g"].Value;
                    loto_n4_g.Text = loto[0]["n4_g"].Value;
                    loto_n5_g.Text = loto[0]["n5_g"].Value;
                    loto_n6_g.Text = loto[0]["n6_g"].Value;
                    loto_n7_g.Text = loto[0]["n7_g"].Value;
                    loto_n8_g.Text = loto[0]["n8_g"].Value;
                    loto_n9_g.Text = loto[0]["n9_g"].Value;
                    loto_n10_g.Text = loto[0]["n10_g"].Value;

                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Erreur", "Une erreur s'est produite, réessayer à nouveau.", "OK");
                //Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
}
