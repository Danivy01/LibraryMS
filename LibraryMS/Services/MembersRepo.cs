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
    public class MembersRepo
    {
        DbControl sql = new DbControl();


        public List<Members> GetAllMembers()
        {
            List<Members> members = new List<Members>();
            var dt = sql.Query("SELECT * FROM tbl_members");
            foreach (DataRow item in dt.Rows)
            {
                Members member = new Members();
                member.Id = Convert.ToInt32(item["Id"]);
                member.fname = item["FirstName"].ToString();
                member.lname = item["LastName"].ToString();
                member.email = item["Email"].ToString();
                member.phone = item["Phone"].ToString();
                member.address = item["Address"].ToString();

                members.Add(member);
            }
            return members;
        }

        public SelectList ListofMembers()
        {
            var list = new SelectList(GetAllMembers(), "Id", "fullName");
            return list;
        }

        public void CreateMember(Members member)
        {
            sql.Query("INSERT INTO tbl_members (FirstName, LastName, Email, Phone, address) VALUES (@FirstName, @LastName, @Email, @Phone, @address)", param =>
            {
                param.Add("@FirstName", member.fname);
                param.Add("@LastName", member.lname);
                param.Add("@email", member.email);
                param.Add("@Phone", member.phone);
                param.Add("@address", member.address);
            });
        }

        public Members Find(int Id)
        {
            var item = new Members();
            var dt = sql.Query("SELECT * FROM tbl_members WHERE Id = @Id", param =>
            {
                param.Add("@Id", Id);
            });
            foreach (DataRow r in dt.Rows)
            {
                item = new Members()
                {
                    Id = r["Id"].ToInt(),
                    fname = r["FirstName"].ToString(),
                    lname = r["LastName"].ToString(),
                    email = r["Email"].ToString(),
                    phone = r["Phone"].ToString(),
                    address = r["Address"].ToString()
                };

            }
            return item;
        }

        public void UpdateMember(Members member)
        {
            sql.Query("UPDATE tbl_members SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address WHERE Id = @Id", param => 
            {
                param.Add("@Id", member.Id);
                param.Add("@FirstName", member.fname);
                param.Add("@LastName", member.lname);
                param.Add("@Email", member.email);
                param.Add("@Phone", member.phone);
                param.Add("@Address", member.address);
            });
        }

        public void DeleteMember(Members member)
        {
            sql.Query("DELETE FROM tbl_members WHERE Id = @Id", param =>
            {
                param.Add("@Id", member.Id);
            });
        }
    }
}