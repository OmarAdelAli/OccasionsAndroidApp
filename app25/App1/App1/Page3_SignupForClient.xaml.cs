using App1.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3_SignupForClient : ContentPage
    {
        public Page3_SignupForClient()
        {
            InitializeComponent();
        }

        private async void signupBtn_Clicked(object sender, EventArgs e)
        {
            try
            {


                client_table Pelgrims = new client_table()
                {
                    email = emailEntry.Text,
                    mobile = userMobileTB.Text,
                    password = password.Text,
                    username = usernameErrorLabel.Text,
                };
                using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                {
                    conn.CreateTable<client_table>();
                    int roweffected = conn.Insert(Pelgrims);
                    await DisplayAlert("Message", "Saved successfully", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "acoount created Before with similar User ID", "OK");
            }
        }
        private void OnUsernameEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string username = e.NewTextValue.Trim();

            // Check if the username is valid
            if (!string.IsNullOrEmpty(username) && !IsValidUsername(username))
            {
                usernameErrorLabel.Text = "Username can only contain letters";
                usernameErrorLabel.IsVisible = true;
            }
            else
            {
                usernameErrorLabel.IsVisible = false;
            }
        }

        private bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z]+$");
        }
        private void OnEmailEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string email = e.NewTextValue.Trim();

            // Check if the email address is valid
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                emailErrorLabel.Text = "Invalid email address";
                emailErrorLabel.IsVisible = true;
            }
            else
            {
                emailErrorLabel.IsVisible = false;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}
