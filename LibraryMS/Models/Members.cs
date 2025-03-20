using LibraryMS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryMS.Models
{
    public class Members
    {

        public int Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        
    }
}