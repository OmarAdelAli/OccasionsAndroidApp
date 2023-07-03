using App1.FormForClient;
using App1.formForServiceProvider;
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
    public partial class Page2_Login : ContentPage
    {

        public Page2_Login()
        {
            InitializeComponent();
        }

        private async void signupForServiceProviderBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page4_SignupForServiceProvider());

        }

        private async void signupBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page3_SignupForClient());

        }

        private async void loginBtn_Clicked(object sender, EventArgs e)
        {
            try
            {

                using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                {
                    conn.CreateTable<client_table>();
                    var list = conn.Query<client_table>("select id,username from client_table where password=? and mobile=?", password.Text, clientMobileTB.Text);
                    int count = list.Count();
                    if (count != 0)
                    {
                        Page1_Splash.UserMobile = clientMobileTB.Text;
                        await Navigation.PushAsync(new Page1_MainPageAfterLogin());
                    }
                    else
                    {
                        using (SQLiteConnection conn2 = new SQLiteConnection(Page1_Splash.DbPath))
                        {
                            conn2.CreateTable<service_provider_table>();
                            var list2 = conn.Query<service_provider_table>("select id,username from service_provider_table where password=? and mobile=?", password.Text, clientMobileTB.Text);
                            int count2 = list2.Count();
                            if (count2 != 0)
                            {
                                Page1_Splash.UserMobile = clientMobileTB.Text;
                                await Navigation.PushAsync(new Page1_MainPageForServiceProvider());
                            }
                            else
                            {
                                await this.DisplayAlert("exit", "Incorrect Mobile Number or password", "OK");
                            }
                        }
                    }
                }

            }
            // }
            catch (Exception )
            {

            }
        }
    }
}