using App1.Classes;
using App1.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.FormForClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2_ServiceProviders : ContentPage
    {
        public Page2_ServiceProviders()
        {
            InitializeComponent();
            ServiceProviderList();
        }
        public void ServiceProviderList()
        {

            try
            {


                using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                {
                    conn.CreateTable<service_provider_table>();
                    var list = conn.Query<service_provider_table>("select * from service_provider_table where Category=?",Page1_Splash.Category);
                    int count = list.Count();
                    if (count != 0)
                    {
                        List<Class1_ServiceProvider_Table> tempList = new List<Class1_ServiceProvider_Table>();
                        foreach (var item in list)
                        {
                            tempList.Add(new Class1_ServiceProvider_Table
                            {

                                ShopName = item.ShopName,
                                ID = item.ID,
                                address = item.address,
                                mobile = item.mobile,
                            });
                        }
                        timetableLV.ItemsSource = tempList;
                    }
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        private async void timetableLV_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var timeTableData = e.Item as Class1_ServiceProvider_Table;
                Page1_Splash.ServiceProviderMobile = timeTableData.mobile.ToString();
                await Navigation.PushAsync(new Page3_Services());
            }
            catch (Exception ee)
            {

            }
        }
    }
}