using LibraryMS.Data;
using LibraryMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LibraryMS.Services
{
    public class RentalRepo
    {
        DbControl sql = new DbControl();

        public List<Rental> GetAllRental()
        {
            List<Rental> rental = new List<Rental>();
            var dt = sql.Query("SELECT * FROM vw_rental");
            foreach (DataRow row in dt.Rows)
            {
                Rental rent = new Rental();
                rent.Id = row["Id"].ToInt();
                rent.bookId = row["bookId"].ToInt();
                rent.bookName = row["bookName"].ToString();
                rent.memberId = row["memberId"].ToInt();
                rent.memberName = row["memberName"].ToString();
                rent.rentalDate = row["rentalDate"].ToDateTime();
                rent.returnDate = row["returnDate"].ToDateTime();
                rent.status = row["status"].ToBool();

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
            var dt = sql.Query("SELECT * FROM tbl_rental WHERE Id = @Id", param =>
            {
                param.Add("@Id", rental.Id);
            });
            foreach (DataRow r in dt.Rows)
            {
                rental = new Rental();
                rental.bookId = r["bookId"].ToInt();
                rental.bookName = r["bookname"].ToString();
                rental.memberId = r["memberId"].ToInt();
                rental.rentalDate = r["rentalDate"].ToDateTime();
                rental.returnDate = r["returnDate"].ToDateTime();
                rental.status = r["status"].ToBool();
            }
            return rental;
        }

        public void UpdateRent(Rental rental)
        {
            sql.Query("UPDATE tbl_rental SET bookId = @bookId, bookName = @bookName, memberId = @memberId, memberName = @memberName, rentalDate = @rentalDate, returnDate = @returnDate, status = @status", param =>
            {
                param.Add("@bookId", rental.bookId);
                param.Add("@bookName", rental.bookName);
                param.Add("@memberId", rental.memberId);
                param.Add("@memberName", rental.memberName);
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
    }
}