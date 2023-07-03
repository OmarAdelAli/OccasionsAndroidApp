using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Tables
{
   public class services_table
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Service_name { get; set; }
        public string description { get; set; }
        public DateTime add_date { get; set; }
        public string serviceCategoryID { get; set; }
        public string serviceProviderID { get; set; }
        public float Price { get; set; }


    }
}
