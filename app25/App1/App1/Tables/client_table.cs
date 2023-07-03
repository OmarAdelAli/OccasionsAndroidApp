using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Tables
{
    public class client_table
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string username { get; set; }
        public string Username { get; internal set; }
        public string password { get; set; }
        public string Password { get; internal set; }
        public string email { get; set; }
        public string Email { get; internal set; }
        public string mobile { get; set; }
        public string Mobile { get; internal set; }
    }
}
