using Acr.UserDialogs;
using Lotto_fdj_PCL.AdMob;
using Lotto_fdj_PCL.Detail;
using Lotto_fdj_PCL.Historique;
using Newtonsoft.Json;
using Plugin.Connectivity;
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

            adInterstitial = DependencyService.Get<IAdInterstitial>();

            adInterstitial.ShowAd();

            callAPI();
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
                    loto_n1.Text = loto[0]["n1"].Value;
                    loto_n2.Text = loto[0]["n2"].Value;
                    loto_n3.Text = loto[0]["n3"].Value;
                    loto_n4.Text = loto[0]["n4"].Value;
                    loto_n5.Text = loto[0]["n5"].Value;
                    loto_n6.Text = loto[0]["n6"].Value;
                    loto_joker.Text = loto[0]["joker"].Value;
                    loto_tirage_du.Text = loto[0]["tirage_du"].Value;
                    loto_prochain_tirage.Text = loto[0]["prochain_tirage"].Value;
                    loto_montant.Text = loto[0]["montant"].Value;

                    //euro_million
                    dynamic euro_million = output["euro_million"];
                    euromillions_n1.Text = euro_million[0]["n1"].Value;
                    euromillions_n2.Text = euro_million[0]["n2"].Value;
                    euromillions_n3.Text = euro_million[0]["n3"].Value;
                    euromillions_n4.Text = euro_million[0]["n4"].Value;
                    euromillions_n5.Text = euro_million[0]["n5"].Value;
                    euromillions_n6.Text = euro_million[0]["n6"].Value;
                    euromillions_n7.Text = euro_million[0]["n7"].Value;
                    euromillions_my_million.Text = euro_million[0]["numero_my_million"].Value;
                    euromillions_tirage_du.Text = euro_million[0]["tirage_du"].Value;
                    euromillions_prochain_tirage.Text = euro_million[0]["prochain_tirage"].Value;
                    euromillions_montant.Text = euro_million[0]["montant"].Value;

                    //keno
                    dynamic keno = output["kenno_fr"];
                    keno_n1.Text = keno[0]["n1"].Value;
                    keno_n2.Text = keno[0]["n2"].Value;
                    keno_n3.Text = keno[0]["n3"].Value;
                    keno_n4.Text = keno[0]["n4"].Value;
                    keno_n5.Text = keno[0]["n5"].Value;
                    keno_n6.Text = keno[0]["n6"].Value;
                    keno_n7.Text = keno[0]["n7"].Value;
                    keno_n8.Text = keno[0]["n8"].Value;
                    keno_n9.Text = keno[0]["n9"].Value;
                    keno_n10.Text = keno[0]["n10"].Value;
                    keno_n11.Text = keno[0]["n11"].Value;
                    keno_n12.Text = keno[0]["n12"].Value;
                    keno_n13.Text = keno[0]["n13"].Value;
                    keno_n14.Text = keno[0]["n14"].Value;
                    keno_n15.Text = keno[0]["n15"].Value;
                    keno_n16.Text = keno[0]["n16"].Value;
                    keno_n17.Text = keno[0]["n17"].Value;
                    keno_n18.Text = keno[0]["n18"].Value;
                    keno_n19.Text = keno[0]["n19"].Value;
                    keno_n20.Text = keno[0]["n20"].Value;
                    keno_multiplicateur.Text = keno[0]["multiplicateur"].Value;
                    keno_tirage_du.Text = keno[0]["tirage_du"].Value;

                    //joker
                    dynamic joker = output["joker_plus"];
                    joker_n1.Text = joker[0]["n1"].Value;
                    joker_n2.Text = joker[0]["n2"].Value;
                    joker_n3.Text = joker[0]["n3"].Value;
                    joker_n4.Text = joker[0]["n4"].Value;
                    joker_n5.Text = joker[0]["n5"].Value;
                    joker_n6.Text = joker[0]["n6"].Value;
                    joker_n7.Text = joker[0]["n6"].Value;
                    joker_tirage_du.Text = joker[0]["tirage_du"].Value;

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

        private void btnLotoHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new LotoHistoriquePage());
        }

        private void btnLotoDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new LotoDetailPage());
        }

        private void btnEuromillionsDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new EuromillionsDetailPage());
        }

        private void btnEuromillionsHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new EuromillionsHistoriquePage());
        }

        private void btnKenoDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new KenoDetailPage());
        }

        private void btnKenoHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new KenoHistoriquePage());
        }

        private void btnJokerDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new JokerDetailPage());
        }

        private void btnJokerHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new JokerHistoriquePage());
        }

        private void btnLotoCodesGagnants_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Erreur", "Connectez vous à internet et réessayer.", "OK");
                return;
            }
            Navigation.PushAsync(new LotoCodesGagnantPage());
        }
    }
}
