using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.formForServiceProvider
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1_MainPageForServiceProvider : ContentPage
	{
		public Page1_MainPageForServiceProvider ()
		{
			InitializeComponent ();
		}

        private async void AddServiceBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2_AddService());

        }

        private async void SavedServicesBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page5_ServiceProviderServices());
        }


        private async void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2_Login());

        }

        private async void ClientOrderBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page3_ClientOrder());

        }
    }
}