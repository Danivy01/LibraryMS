using LibraryMS.Data;
using LibraryMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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
                member.fname = item["fname"].ToString();
                member.lname = item["lname"].ToString();
                member.email = item["email"].ToString();
                member.phone = item["address"].ToString();

                members.Add(member);
            }
            return members;
        }

        public void CreateMember(Members member)
        {
            sql.Query("INSERT INTO tbl_members (fname, lname, email, address) VALUES (@fname, @lname, @email, @address)", param =>
            {
                param.Add("@fname", member.fname);
                param.Add("@lname", member.lname);
                param.Add("@email", member.email);
                param.Add("@address", member.address);
            });
        }

        public Members Find(int Id)
        {
            var item = new Members();
            var dt = sql.Query("SELECT * FROM WHERE Id = @Id", param =>
            {
                param.Add("@Id", Id);
            });
            foreach (DataRow r in dt.Rows)
            {
                item = new Members() {
                    Id = Convert.ToInt32(r["Id"]),
                    fname = r["fname"].ToString(),
                    lname = r["lname"].ToString(),
                    email = r["email"].ToString(),
                    phone = r["phone"].ToString(),
                    address = r["address"].ToString()
                };

            }
            return item;
        }

        public void UpdateMember(Members member)
        {
            sql.Query("UPDATE tbl_members SET fname = @fname, lname = @lname, email = @email, phone = @phone, address = @address", param => {
                param.Add("@fname", member.fname);
                param.Add("@lname", member.lname);
                param.Add("@email", member.email);
                param.Add("@phone", member.phone);
                param.Add("@address", member.address);
            });
        }

        public void DeleteMember(Members member)
        {
            sql.Query("DELETE * FROM WHERE Id = @Id", param =>
            {
                param.Add("@Id", member.Id);
            });
        }
    }
}