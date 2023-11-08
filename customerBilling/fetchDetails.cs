using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerBilling
{
    internal class fetchDetails
    {
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=customerbilling;Persist Security Info=True;User ID=sa;Password=sql@123;";
        public static void GetProductDetails()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("fetchDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product id :{reader["p_id"]}," + "\n" +
                                 $"Product name :{reader["p_name"]}," + "\n" +
                                 $"cgst :{reader["cgst"]}," + "\n" +
                                 $"sgst :{reader["sgst"]}," + "\n" +
                                 $"Product Price :{reader["p_price"]}," + "\n" +
                                 $"Product Quantity :{reader["p_quantity"]} kg," + "\n" +
                                 $"Expiry Date: {reader["Exp_Date"]}");
                        }
                    }
                }

            }
        }
    }
}
