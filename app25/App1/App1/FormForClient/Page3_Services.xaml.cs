using App1.Classes;
using App1.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.FormForClient
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page3_Services : ContentPage
	{
        public static DataTable OrderDetailsDT = new DataTable("myTable");
        public static DataTable TempOrderDetailsDT = new DataTable("myTable");
        public Page3_Services ()
		{
			InitializeComponent ();
            Services();
            OrderDetailsDT.Columns.Clear();
            OrderDetailsDT.Rows.Clear();

            //.........just for checking.............
            int rowindex = OrderDetailsDT.Rows.Count;
            OrderDetailsDT.Columns.Add("ServiceID");
            OrderDetailsDT.Columns.Add("ServiceName");
            OrderDetailsDT.Columns.Add("Price");

            timetableLV.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                // don't do anything if we just de-selected the row.
                if (e.Item == null) return;

                // Optionally pause a bit to allow the preselect hint.
                Task.Delay(500);

                // Deselect the item.
                if (sender is ListView lv) lv.SelectedItem = null;
            };


        }
        private async void absentSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            try
            {
                int ID = (int)((Switch)sender).BindingContext;
                if (e.Value == true)
                {
                    foreach (DataRow row in TempOrderDetailsDT.Rows)
                    {
                        if (row["OrderID"].ToString().Trim().Equals(ID.ToString()))
                        {
                            string ServiceName = row["ServiceName"].ToString();
                            string Price = row["Price"].ToString();
                            OrderDetailsDT.Rows.Add(ID,ServiceName, Price);
                            break;
                        }
                    }
                }
                else
                {

                    foreach (DataRow row in OrderDetailsDT.Rows)
                    {
                        if (row["ServiceID"].ToString().Trim().Equals(ID.ToString()))
                            OrderDetailsDT.Rows.Remove(row);
                        break;
                    }
                }
                // int rowNo = OrderDetailsDT.Rows.Count;
            }
            catch (Exception ee)
            {
            }
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
                        //..................another datatable to store students information............
                        TempOrderDetailsDT.Columns.Clear();
                        TempOrderDetailsDT.Rows.Clear();

                        //.........just for checking.............
                        TempOrderDetailsDT.Columns.Add("OrderID");
                        TempOrderDetailsDT.Columns.Add("ServiceName");
                        TempOrderDetailsDT.Columns.Add("Price");
                        List<Class2_Service_Table> tempList = new List<Class2_Service_Table>();
                        foreach (var item in list)
                        {
                            tempList.Add(new Class2_Service_Table
                            {
                                Service_name = item.Service_name,
                                ID = item.ID,
                                Price ="Price : "+ item.Price,
                                description = item.description,
                            });
                            TempOrderDetailsDT.Rows.Add(item.ID, item.Service_name,item.Price);

                        }
                        timetableLV.ItemsSource = tempList;
                        //TempOrderDetailsDT.Rows.Add(tempList);
                    }
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (OrderDetailsDT.Rows.Count == 0)
            {
                await this.DisplayAlert("exit", "Please Select Services", "OK");

            }
            else
            {
                await Navigation.PushAsync(new Page4_PlaceOrder());

            }

        }
    }
}