using App1.Classes;
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

namespace App1.FormForClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page6_viewOrdersForCustomer : ContentPage
    {
        public Page6_viewOrdersForCustomer()
        {
            InitializeComponent();
            ServiceProviderList();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public void ServiceProviderList()
        {

            try
            {


                using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                {
                    conn.CreateTable<OrderDetail_Table>();
                    var list = conn.Query<OrderDetail_Table>("select * from OrderDetail_Table where OrderID=?", Page1_Splash.OrderID);
                    int count = list.Count();
                    if (count != 0)
                    {
                        List<Class4_OrderDetails_Table> tempList = new List<Class4_OrderDetails_Table>();
                        foreach (var item in list)
                        {
                            tempList.Add(new Class4_OrderDetails_Table
                            {
                                Price = item.Price,
                                ServiceName = item.ServiceName,
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
