using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1.Classes;
using App1.Tables;
using SQLite;
using System.Linq;
namespace App1.formForServiceProvider
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5_ServiceProviderServices : ContentPage
    {
        public Page5_ServiceProviderServices()
        {
            InitializeComponent();
            Services();
        }

        public void Services()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                {
                    conn.CreateTable<services_table>();
                    var list = conn.Query<services_table>("select * from services_table where serviceProviderID=?", Page1_Splash.ServiceProviderMobile);
                    int count = list.Count();
                    if (count != 0)
                    {
                        List<Class2_Service_Table> tempList = new List<Class2_Service_Table>();
                        foreach (var item in list)
                        {
                            tempList.Add(new Class2_Service_Table
                            {
                                Service_name = item.Service_name,
                                ID = item.ID,
                                Price = "Price : " + item.Price,
                                description = item.description,
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
    }
}