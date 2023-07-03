using App1.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4_SignupForServiceProvider : ContentPage
    {
        public Page4_SignupForServiceProvider()
        {
            InitializeComponent();

            CategoryDDL.Items.Add("flower");
            CategoryDDL.Items.Add("makeup");
            CategoryDDL.Items.Add("wedding Tools");
            CategoryDDL.Items.Add("hotel");

            CategoryDDL.SelectedIndex = 0;
        }

        private async void signupBtn_Clicked(object sender, EventArgs e)
        {
            try
            {


                service_provider_table ServiceProvider = new service_provider_table()
                {
                    email = EmailTB.Text,
                    mobile = userMobileTB.Text,
                    password = password.Text,
                    username = userNameTB.Text,
                    address = addressTB.Text,
                    iban = IbanTB.Text,
                    tax_number = VatNoTB.Text,
                    Category = CategoryDDL.SelectedItem.ToString(),
                    ShopName = ShopName.Text
                };
                using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                {
                    conn.CreateTable<service_provider_table>();
                    int roweffected = conn.Insert(ServiceProvider);
                    await DisplayAlert("Message", "Saved successfully", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception)
            {

                await DisplayAlert("Error", "acoount created Before with similar User ID", "OK");
            }
        }
        

    }


}