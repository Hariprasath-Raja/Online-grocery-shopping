using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace customerBilling
{
    internal class updateDetails:InsertProductDetails
    {
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=customerbilling;Persist Security Info=True;User ID=sa;Password=sql@123;";
        public static string id;
        public static void GetProductById()
        {
            Console.WriteLine("Enter the property Id :");
            id = Console.ReadLine();
            Console.WriteLine("*************************************************");
            Console.WriteLine("Please find the property details below :");
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getproductbyid", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product id :{reader["p_id"]}," + "\n" +
                                $"Product name :{reader["p_name"]}," + "\n" +
                                $"cgst :{reader["cgst"]}," + "\n" +
                                $"sgst :{reader["sgst"]}," + "\n" +
                                $"Product Price :{reader["p_price"]}," + "\n" +
                                $"Product Quantity :{reader["p_quantity"]}," + "\n" +
                                $"Expiry Date: {reader["Exp_Date"]}");
                        }
                    }
                }
            }
        }
            public static void UpdateProduct()
        {
            GetProductById();
            Console.WriteLine("Please enter the details to be updated");
            GetUserInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("updateProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_id", id);
                    cmd.Parameters.AddWithValue("@p_name", p_name);
                    cmd.Parameters.AddWithValue("@cgst", cgst);
                    cmd.Parameters.AddWithValue("@sgst", sgst);
                    cmd.Parameters.AddWithValue("@p_price", p_price);
                    cmd.Parameters.AddWithValue("@p_quantity", p_quantity);
                    cmd.Parameters.AddWithValue("@exp_Date", exp_date);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Property details successfully updated");


                }
            }
        }
    }
}
