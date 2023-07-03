using App1.Tables;
using SQLite;
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
    public partial class Page4_PlaceOrder : ContentPage
    {
        public Page4_PlaceOrder()
        {
            InitializeComponent();
        }

        private async void NextBtn_Clicked(object sender, EventArgs e)
        {
            Page1_Splash.Address = AddressTB.Text;
            Page1_Splash.OrderDate = OrderDateTB.Date.ToString("yyyy-MM-dd");
            Page1_Splash.OrderTime = "12:00";
            await Navigation.PushAsync(new Page5_Payment());


        }
    }
}