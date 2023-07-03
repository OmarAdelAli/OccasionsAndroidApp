using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1_Splash : ContentPage
    {
        public static string Category;
        public static string UserMobile;
        public static string ServiceProviderMobile;

        public static string OrderID;
        public static string OrderDate;
        public static string OrderTime;
        public static string Address;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OccationDB.db");

        public Page1_Splash()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(3000);

            await Navigation.PushAsync(new Page2_Login());

        }

        private void Label_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}