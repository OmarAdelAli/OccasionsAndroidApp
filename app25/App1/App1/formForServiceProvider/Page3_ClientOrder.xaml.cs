using App1.Classes;
using App1.FormForClient;
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
	public partial class Page3_ClientOrder : ContentPage
	{
		public Page3_ClientOrder ()
		{
			InitializeComponent ();
            ServiceProviderList();
        }
        public void ServiceProviderList()
        {

            try
            {


                using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                {
                    conn.CreateTable<Orders_Table>();
                    var list = conn.Query<Orders_Table>("select * from Orders_Table where Service_Provider=?", Page1_Splash.UserMobile);
                    int count = list.Count();
                    if (count != 0)
                    {
                        List<Class3_Orders_Table> tempList = new List<Class3_Orders_Table>();
                        foreach (var item in list)
                        {
                            tempList.Add(new Class3_Orders_Table
                            {
                                ClientID = item.ClientID,
                                OrderDate = item.OrderDate,
                                Address = item.Address,
                                OrderID = item.OrderID,
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
                var timeTableData = e.Item as Class3_Orders_Table;
                Page1_Splash.OrderID = timeTableData.OrderID.ToString();
                await Navigation.PushAsync(new Page4_OrderDetail());
            }
            catch (Exception ee)
            {

            }
        }
    }
}