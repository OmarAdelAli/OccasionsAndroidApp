using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Tables
{
    public class service_provider_table
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string mobile { get; set; }
        public string tax_number { get; set; }
        public string address { get; set; }

        public string iban { get; set; }
        public string Category { get; set; }
        public string ShopName { get; set; }


    }
}
