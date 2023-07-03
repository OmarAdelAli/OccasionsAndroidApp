using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Tables
{
    internal class Orders_Table
    {
        [AutoIncrement, PrimaryKey]
        public int OrderID { get; set; }
        public string OrderDate { get; set; }

        public string Service_Provider { get; set; }
        public string ClientID { get; set; }

        public string OrderStatus { get; set; }

        public string Address { get; set; }
    }
}
