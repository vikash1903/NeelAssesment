using Neel.Core.DataAccess.Helpers;
using Neel.Core.Models.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neel.Core.DataAccess.Repository
{
    public class EmployeeServices : IEmployeeServices
    {
        ApplicationContext applicationContext = new ApplicationContext();
        public static string NeelDbConnectionString => ConfigurationManager.ConnectionStrings["EmployeeDB"].ToString();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        public bool DeleteRecord(int EmployeeId)
        {
            bool result = false;
            int resp = 0;
            SqlConnection cnn = new SqlConnection(NeelDbConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@empId", EmployeeId);
            cmd.CommandText = "Delete from EmployeeModels where EmployeeId = @empId ";
            cnn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resp = int.Parse(reader["result"].ToString());
            }
            if (reader.RecordsAffected > 0)
                result = true;
            cnn.Close();
            return result;
        }
    }
}
