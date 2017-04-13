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

namespace Lotto_fdj_PCL
{
    public partial class MainPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public MainPage()
        {
            InitializeComponent();

            GlobalVariable.count++;
            if (GlobalVariable.count == 4)
            {
                GlobalVariable.count = 0;

                adInterstitial = DependencyService.Get<IAdInterstitial>();

                adInterstitial.ShowAd();
            }


            //callAPI();
        }

        /*private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Loading, Please wait...", MaskType.Black);
            try
            {
                HttpClient client = new HttpClient();
                var uri = new Uri("http://mobixapp.com/loto_usa_api/Api/getLastNew_york");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //megamillions
                    dynamic megamillions = output["mega_millions"];
                    megamillions_n1.Text = megamillions[0]["n1"];
                    megamillions_n2.Text = megamillions[0]["n2"];
                    megamillions_n3.Text = megamillions[0]["n3"];
                    megamillions_n4.Text = megamillions[0]["n4"];
                    megamillions_n5.Text = megamillions[0]["n5"];
                    megamillions_n6.Text = megamillions[0]["n6"];
                    megamillions_n7.Text = megamillions[0]["n7"];
                    megamillions_jackpot.Text = megamillions[0]["jackpot"];
                    megamillions_tirage_du.Text = megamillions[0]["tirage_du"];
                    megamillions_nextdraw.Text = megamillions[0]["prochain_tirage"];


                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Error", "An error has occurred, Please try again.", "OK");
                //Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }*/

        private void btnLotoHistorique_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLotoDetail_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEuromillionsDetail_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEuromillionsHistorique_Clicked(object sender, EventArgs e)
        {

        }

        private void btnKenoDetail_Clicked(object sender, EventArgs e)
        {

        }

        private void btnKenoHistorique_Clicked(object sender, EventArgs e)
        {

        }

        private void btnJokerDetail_Clicked(object sender, EventArgs e)
        {

        }

        private void btnJokerHistorique_Clicked(object sender, EventArgs e)
        {

        }
    }
}
