using Lotto_fdj_PCL.AdMob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lotto_fdj_PCL.Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JokerDetailPage : ContentPage
    {
        public JokerDetailPage()
        {
            InitializeComponent();

            GlobalVariable.count++;

            if (GlobalVariable.count == 4)
            {
                GlobalVariable.count = 0;

                Device.BeginInvokeOnMainThread(() =>
                {
                    IAdInterstitial adInterstitial = DependencyService.Get<IAdInterstitial>();

                    adInterstitial.ShowAd();
                });
            }
        }
    }
}
