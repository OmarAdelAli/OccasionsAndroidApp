using App1.formForServiceProvider;
using App1.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.FormForClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5_Payment : ContentPage
    {
        int OrderID = 0;

        public Page5_Payment()
        {
            InitializeComponent();
            PaymentMethodDDL.Items.Add("Credit Card");
            PaymentMethodDDL.Items.Add("Debit Card");
            PaymentMethodDDL.SelectedIndex = 0;
        }
        private async void ConfirmBtn_Clicked(object sender, EventArgs e)
        {
            try
            {


                if (CardholderNameTB.Text == string.Empty)
                {
                    await DisplayAlert("error", "please write Card Holder Name", "return");

                }
                else if (CardNoTB.Text.Length != 10)
                {
                    await DisplayAlert("error", "Card Number should be 10 digits", "return");

                }
                else if (SecNoTB.Text.Length != 3)
                {
                    await DisplayAlert("error", "Card Security Number should be 3 digit", "return");

                }
                else
                {
                    try
                    {


                        Orders_Table Order = new Orders_Table()
                        {
                            OrderDate = Page1_Splash.OrderDate,
                            OrderStatus = "New",
                            ClientID = Page1_Splash.UserMobile,
                            Service_Provider = Page1_Splash.ServiceProviderMobile,
                        };
                        using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                        {
                            conn.CreateTable<Orders_Table>();
                            int roweffected = conn.Insert(Order);
                        }

                        using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                        {
                            conn.CreateTable<Orders_Table>();
                            OrderID = conn.ExecuteScalar<int>("Select MAX(OrderID) from Orders_Table");
                        }

                        foreach (DataRow row in Page3_Services.OrderDetailsDT.Rows)
                        {
                            OrderDetail_Table OrderDetail = new OrderDetail_Table()
                            {
                                ServiceName = row[1].ToString(),
                                OrderID = OrderID,
                                Price = row[2].ToString(),
                            };
                            using (SQLiteConnection conn = new SQLiteConnection(Page1_Splash.DbPath))
                            {
                                conn.CreateTable<OrderDetail_Table>();
                                int roweffected = conn.Insert(OrderDetail);
                            }
                        }
                        await DisplayAlert("Message", "Saved successfully", "OK");
                        await Navigation.PushAsync(new Page1_MainPageAfterLogin());

                    }
                    catch (Exception )
                    {

                        await DisplayAlert("Error", "acoount created Before with similar User ID", "OK");
                    }
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Message", "All Fields are mandatory", "exit");

            }

        }
    }
}