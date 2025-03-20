using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryMS.Data
{
    public class DbControl
    {
        public DataTable Query(string Command, Action<Dictionary<string, object>> parameters = null)
        {
            var data = new Dictionary<string, object>();
            parameters?.Invoke(data);
            var dt = new DataTable();
            var cn = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbLMS;INTEGRATED SECURITY=TRUE");
            cn.Open();
            var cm = new SqlCommand(Command, cn);
            foreach (KeyValuePair<string, object> d in data)
            {
                cm.Parameters.Add(new SqlParameter(d.Key, d.Value ?? DBNull.Value));
            }
            dt.Load(cm.ExecuteReader());
            cn.Close();
            return dt;
        }
    }
}