using LibraryMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryMS.Models
{
    public class Members
    {

        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lname { get; set; }

        public string fullName
        {
            get
            {
                var output = fname + " " + lname;
                return output;
            }
        }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        
    }

    public class MemberDeleteModelView
    {
        public int Id { get; set; }
    }
}