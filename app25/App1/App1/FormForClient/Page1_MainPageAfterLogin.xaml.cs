using App1.formForServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.FormForClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1_MainPageAfterLogin : ContentPage
    {
        public Page1_MainPageAfterLogin()
        {
            InitializeComponent();

            var images = new List<string>
            {
            "Slide1.png",
            "Slide2.png",
            "Slide3.png"
            };
            CVMenu.ItemsSource = images;

            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {

                CVMenu.Position = (CVMenu.Position + 1) % images.Count;

                return true;
            }));
        }
        async private void flower_Tapped(object sender, EventArgs e)
        {
            Page1_Splash.Category = "flower";
            await Navigation.PushAsync(new Page2_ServiceProviders());
        }
        async private void hotel_Tapped(object sender, EventArgs e)
        {
            Page1_Splash.Category = "hotel";
            await Navigation.PushAsync(new Page2_ServiceProviders());
        }
        async private void makeup_Tapped(object sender, EventArgs e)
        {
            Page1_Splash.Category = "makeup";
            await Navigation.PushAsync(new Page2_ServiceProviders());
        }
        async private void weddingTools_Tapped(object sender, EventArgs e)
        {
            Page1_Splash.Category = "wedding Tools";
            await Navigation.PushAsync(new Page2_ServiceProviders());
        }
        private async void ClientOrderBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page6_viewOrdersForCustomer());

        }
    }
}
