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
    public class Books
    {
        
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Author")]
        public string author { get; set; }

        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Published Year")]
        public int publishedYear { get; set; }

        [Display(Name = "Genre")]
        public string genre { get; set; }

        [Display(Name = "Copies Available")]
        public int copiesAvailable { get; set; }


       


    }
}