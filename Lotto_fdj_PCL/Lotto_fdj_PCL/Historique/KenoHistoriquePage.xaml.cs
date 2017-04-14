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
    public partial class KenoHistoriquePage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public KenoHistoriquePage()
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
                var kenos = new List<Keno>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://www.achrafchikoun.com/fdj/Api/getKennoHistorique");
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
                        string n7 = output.ElementAt(i)["n7"].ToString();
                        string n8 = output.ElementAt(i)["n8"].ToString();
                        string n9 = output.ElementAt(i)["n9"].ToString();
                        string n10 = output.ElementAt(i)["n10"].ToString();
                        string n11 = output.ElementAt(i)["n11"].ToString();
                        string n12 = output.ElementAt(i)["n12"].ToString();
                        string n13 = output.ElementAt(i)["n13"].ToString();
                        string n14 = output.ElementAt(i)["n14"].ToString();
                        string n15 = output.ElementAt(i)["n15"].ToString();
                        string n16 = output.ElementAt(i)["n16"].ToString();
                        string n17 = output.ElementAt(i)["n17"].ToString();
                        string n18 = output.ElementAt(i)["n18"].ToString();
                        string n19 = output.ElementAt(i)["n19"].ToString();
                        string n20 = output.ElementAt(i)["n20"].ToString();
                        string multiplicateur = output.ElementAt(i)["multiplicateur"].ToString();
                        string tirage_du = output.ElementAt(i)["date_tirage"].ToString();
                        kenos.Add(new Keno { n1 = n1, n2 = n2, n3 = n3, n4 = n4, n5 = n5, n6 = n6, n7 = n7, n8 = n8, n9 = n9, n10 = n10, n11 = n11, n12 = n12, n13 = n13, n14 = n14, n15 = n15, n16 = n16, n17 = n17, n18 = n18, n19 = n19, n20 = n20, multiplicateur = multiplicateur, tirage_du = tirage_du });

                    }
                    listView.ItemsSource = kenos;

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
