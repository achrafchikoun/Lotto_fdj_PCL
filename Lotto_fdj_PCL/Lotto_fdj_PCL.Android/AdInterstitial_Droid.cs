using Android.Content;
using Xamarin.Forms;
using Lotto_fdj_PCL.Droid;
using Lotto_fdj_PCL.AdMob;
using Android.Gms.Ads;

[assembly: Dependency(typeof(AdInterstitial_Droid))]
namespace Lotto_fdj_PCL.Droid
{
    public class AdInterstitial_Droid : IAdInterstitial
    {
        InterstitialAd interstitialAd;

        public AdInterstitial_Droid()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context);

            // TODO: change this id to your admob id
            interstitialAd.AdUnitId = "ca-app-pub-3940256099942544/1033173712";
            ShowAd();
        }

        void LoadAd()
        {
            var requestbuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestbuilder.Build());
            interstitialAd.AdListener = new AdListener(Android.App.Application.Context, interstitialAd);
        }

        public void ShowAd()
        {
            LoadAd();
        }

        class AdListener : Android.Gms.Ads.AdListener
        {
            Context main;
            InterstitialAd interstitialAd;

            public AdListener(Context innerMain, InterstitialAd interstitial)
            {
                main = innerMain;
                interstitialAd = interstitial;
            }

            public override void OnAdLoaded()
            {
                base.OnAdLoaded();
                if (interstitialAd.IsLoaded)
                    interstitialAd.Show();
            }
        }
    }
}