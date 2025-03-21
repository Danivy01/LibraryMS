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
    public class BookRepo
    {
        DbControl sql = new DbControl();

        public List<Books> GetAllBooks()
        {
            List<Books> books = new List<Books>();
            var dt = sql.Query("SELECT * FROM tbl_books");
            foreach (DataRow r in dt.Rows)
            {
                Books b = new Books();
                b.Id = Convert.ToInt32(r["Id"]);
                b.title = r["Title"].ToString();
                b.author = r["Author"].ToString();
                b.ISBN = r["ISBN"].ToString();
                b.publishedYear = Convert.ToInt32(r["PublishedYear"]);
                b.genre = r["Genre"].ToString();
                b.copiesAvailable = Convert.ToInt32(r["CopiesAvailable"]);

                books.Add(b);

            }
            return books;
        }

        public SelectList ListofBooks()
        {
            var list = new SelectList(GetAllBooks(), "Id", "title");
            return list;
        }

        public void CreateBook(Books book)
        {
            sql.Query("INSERT INTO tbl_books (Title, Author, ISBN, PublishedYear, Genre, CopiesAvailable) VALUES (@Title, @Author, @ISBN, @PublishedYear, @Genre, @CopiesAvailable)", param => {
                param.Add("@Title", book.title);
                param.Add("@Author", book.author);
                param.Add("@ISBN", book.ISBN);
                param.Add("@PublishedYear", book.publishedYear);
                param.Add("@Genre", book.genre);
                param.Add("@CopiesAvailable", book.copiesAvailable);
            });
        }

        public Books Find(int Id)
        {
            var item = new Books();
            var dt = sql.Query("SELECT * FROM tbl_books WHERE Id = @Id", param => {
                param.Add("@Id", Id);
            });
            foreach (DataRow r in dt.Rows)
            {
                item = new Books()
                {
                    Id = Convert.ToInt32(r["Id"]),
                    title = r["Title"].ToString(),
                    author = r["Author"].ToString(),
                    ISBN = r["ISBN"].ToString(),
                    publishedYear = Convert.ToInt32(r["PublishedYear"]),
                    genre = r["Genre"].ToString(),
                    copiesAvailable = Convert.ToInt32(r["CopiesAvailable"])
                };

            }
            return item;

        }

        public void UpdateBook(Books book)
        {
            sql.Query("UPDATE tbl_books SET Title = @Title, Author = @Author, ISBN = @ISBN, PublishedYear = @PublishedYear, Genre = @Genre, CopiesAvailable = @CopiesAvailable WHERE Id = @Id", param =>
            {
                param.Add("@Id", book.Id);
                param.Add("@Title", book.title);
                param.Add("@Author", book.author);
                param.Add("@ISBN", book.ISBN);
                param.Add("@PublishedYear", book.publishedYear);
                param.Add("@Genre", book.genre);
                param.Add("@CopiesAvailable", book.copiesAvailable);
            });
        }

        public void DeleteBook(Books book)
        {
            sql.Query("DELETE FROM tbl_books WHERE Id = @Id", param => {
                param.Add("@Id", book.Id);
            });
        }
    }
}