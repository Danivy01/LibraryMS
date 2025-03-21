using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMS.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        public int bookId { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        public string bookName { get; set; }

        [Required]
        [Display(Name = "Member Name")]
        public int memberId { get; set; }

        [Required]
        [Display(Name = "Member Name")]
        public string memberName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MMM dd, yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Rental Date")]
        public DateTime rentalDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MMM dd, yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime returnDate { get; set; }

        [Display(Name = "Status")]
        public bool status { get; set; }
    }
}