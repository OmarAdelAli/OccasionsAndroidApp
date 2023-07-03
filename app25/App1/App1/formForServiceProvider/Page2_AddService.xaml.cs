using App1.Classes;
using App1.Tables;
using SQLite;
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
	public partial class Page2_AddService : ContentPage
	{
		public Page2_AddService ()
		{
			InitializeComponent ();
		}

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                services_table Class2_Service = new services_table()
                {
                    add_date = DateTime.Now,
                    description = descriptionTB.Text,
                    serviceProviderID = Page1_Splash.UserMobile,
                    Price =float.Parse(PriceTB.Text),
                    Service_name=Service_nameTB.Text,
                };
                using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                {
                    conn.CreateTable<services_table>();
                    int roweffected = conn.Insert(Class2_Service);
                    await DisplayAlert("Message", "Saved successfully", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception )
            {

                await DisplayAlert("Error", "acoount created Before with similar User ID", "OK");
            }
        }
    }
}