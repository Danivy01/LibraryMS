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

        [Display(Name = "Book Name")]
        public string bookName { get; set; }

        [Required]
        [Display(Name = "Member Name")]
        public int memberId { get; set; }

        [Display(Name = "Member Name")]
        public string memberName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Rental Date")]
        public DateTime rentalDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime returnDate { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }
    }

    public class RentalModelView: Rental
    {

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MMMM dd, yyyy}")]
        public new DateTime rentalDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MMMM dd, yyyy}")]
        public new DateTime returnDate { get; set; }
    }
}