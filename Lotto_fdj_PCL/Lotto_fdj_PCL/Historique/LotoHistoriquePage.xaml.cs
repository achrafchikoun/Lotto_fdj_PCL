using Acr.UserDialogs;
using Lotto_fdj_PCL.AdMob;
using Lotto_fdj_PCL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lotto_fdj_PCL.Historique
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LotoHistoriquePage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public LotoHistoriquePage()
        {
            InitializeComponent();

            GlobalVariable.count++;
            if (GlobalVariable.count == 4)
            {
                GlobalVariable.count = 0;

                adInterstitial = DependencyService.Get<IAdInterstitial>();

                adInterstitial.ShowAd();
            }

            callAPI();
        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Veuillez patienter...", MaskType.Black);
            try
            {
                var lotos = new List<Loto>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://www.achrafchikoun.com/fdj/Api/getLotoHistorique.php");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonConvert.DeserializeObject(content);
                    JArray output = JArray.Parse(responseJson.ToString());

                    for (int i = 0; i < output.Count; i++)
                    {
                        string n1 = output.ElementAt(i)["n1"].ToString();
                        string n2 = output.ElementAt(i)["n2"].ToString();
                        string n3 = output.ElementAt(i)["n3"].ToString();
                        string n4 = output.ElementAt(i)["n4"].ToString();
                        string n5 = output.ElementAt(i)["n5"].ToString();
                        string n6 = output.ElementAt(i)["n6"].ToString();
                        string joker = output.ElementAt(i)["joker"].ToString();
                        string tirage_du = output.ElementAt(i)["tirage_du"].ToString();
                        lotos.Add(new Loto { n1 = n1, n2 = n2, n3 = n3, n4 = n4, n5 = n5, n6 = n6, joker = joker, tirage_du = tirage_du });

                    }
                    listView.ItemsSource = lotos;

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
