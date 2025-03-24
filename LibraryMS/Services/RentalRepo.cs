using LibraryMS.Data;
using LibraryMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMS.Services
{
    public class RentalRepo
    {
        DbControl sql = new DbControl();

        public List<RentalModelView> GetAllRental()
        {
            List<RentalModelView> rental = new List<RentalModelView>();
            var dt = sql.Query("SELECT * FROM vw_rental");
            foreach (DataRow row in dt.Rows)
            {
                RentalModelView rent = new RentalModelView();
                rent.Id = row["Id"].ToInt();
                rent.bookId = row["bookId"].ToInt();
                rent.bookName = row["bookTitle"].ToString();
                rent.memberName = row["memberName"].ToString();
                rent.memberId = row["memberId"].ToInt();
                rent.rentalDate = row["rentalDate"].ToDateTime();
                rent.returnDate = row["returnDate"].ToDateTime();
                rent.status = row["status"].ToString();

                rental.Add(rent);
            }
            return rental;

        }

        public void CreateRental(Rental rent)
        {
            sql.Query("INSERT INTO tbl_rental (BookId, MemberId, RentalDate, ReturnDate, Status) VALUES (@BookId, @MemberId, @RentalDate, @ReturnDate, @Status)", param => {
                param.Add("@BookId", rent.bookId);
                param.Add("@MemberId", rent.memberId);
                param.Add("@RentalDate", rent.rentalDate);
                param.Add("@ReturnDate", rent.returnDate);
                param.Add("@Status", rent.status);

            });
        }

        public Rental Find(int Id)
        {
            var rental = new Rental();
            var dt = sql.Query("SELECT * FROM vw_rental WHERE Id = @Id", param =>
            {
                param.Add("@Id", Id);
            });
            foreach (DataRow r in dt.Rows)
            {
                rental = new Rental();
                rental.bookId = r["bookId"].ToInt();
                rental.bookName = r["bookTitle"].ToString();
                rental.memberName = r["memberName"].ToString();
                rental.memberId = r["memberId"].ToInt();
                rental.rentalDate = r["rentalDate"].ToDateTime();
                rental.returnDate = r["returnDate"].ToDateTime();
                rental.status = r["status"].ToString();
            }
            return rental;
        }

        public void UpdateRent(Rental rental)
        {
            sql.Query("UPDATE tbl_rental SET bookId = @bookId, memberId = @memberId, rentalDate = @rentalDate, returnDate = @returnDate, status = @status", param =>
            {
                param.Add("@bookId", rental.bookId);
                param.Add("@memberId", rental.memberId);
                param.Add("@rentalDate", rental.rentalDate);
                param.Add("@returnDate", rental.returnDate);
                param.Add("@status", rental.status);
            });
        }

        public void DeleteRent(Rental rental)
        {
            sql.Query("DELETE FROM tbl_rental WHERE Id = @Id", param =>
            {
                param.Add("@Id", rental.Id);
            });
        }

        public List<SelectListItem> StatusOptions()
        {
            var statusOptions = new List<SelectListItem>();
            statusOptions.Add(new SelectListItem { Text = "Available", Value = "Available" });
            statusOptions.Add(new SelectListItem { Text = "Rented", Value = "Rented" });
            return statusOptions;
        }
    }
}