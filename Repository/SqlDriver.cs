using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlDriver : IDisposable
    {
        SqlConnection connection;
        public SqlDriver(string connStr)
        {
            connection = new SqlConnection(connStr);
            connection.Open();
        }
        SqlCommand InitCommand(string sql, Dictionary<string, string> parameters)
        {
            SqlCommand cmd = null;
            cmd = new SqlCommand(sql, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> current in parameters)
                {
                    SqlParameter p = cmd.CreateParameter();
                    p.ParameterName = current.Key;
                    p.Value = current.Value;
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }

        public int ExecOther(string sql, Dictionary<string, string> parameters = null)
        {
            SqlCommand cmd = InitCommand(sql, parameters);
            return cmd.ExecuteNonQuery();
        }

        public List<Dictionary<string, object>> ExecSelect(string sql, Dictionary<string, string> parameters = null)
        {
            SqlCommand cmd = InitCommand(sql, parameters);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Dictionary<string, object>> res = new List<Dictionary<string, object>>();
            string[] columns = null;
            int fnum = 0, i;
            while (reader.Read())
            {
                if (columns == null)
                {
                    fnum = reader.FieldCount;
                    columns = new string[fnum];
                    for (i = 0; i < fnum; i++)
                    {
                        columns[i] = reader.GetName(i).ToUpper();
                    }
                }
                string[] values = new string[fnum];
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (i = 0; i < fnum; i++)
                {
                    row.Add(columns[i], reader.GetValue(i));
                }
                res.Add(row);
            }
            if (reader != null && !reader.IsClosed) reader.Close();
            return res;
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
