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
    public partial class Page4_OrderDetail : ContentPage
    {
        public Page4_OrderDetail()
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
            catch (Exception )
            {
                throw;
            }
        }

    }
}