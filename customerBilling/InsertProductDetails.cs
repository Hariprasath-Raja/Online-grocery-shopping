using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace customerBilling
{
    internal class InsertProductDetails
    {
        public static string p_name;
        public static int cgst;
        public static int sgst;
        public static int p_price;
        public static int p_quantity;
        public static DateTime exp_date;
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=customerbilling;Persist Security Info=True;User ID=sa;Password=sql@123;";
        public static void GetUserInput()
        {
            Console.WriteLine("Enter the product name :");
            p_name = Console.ReadLine();

            Console.WriteLine("Enter the cgst value :");
            cgst = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the sgst value :");
            sgst = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the p_price :");
            p_price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the product quantity :");
            p_quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the exp.date");
            exp_date=Convert.ToDateTime(Console.ReadLine());    
        }
   
            public static void GetProductByName()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getpropertybyname", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_name", p_name);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product id :{reader["p_id"]}," + "\n" +
                                $"Product name :{reader["p_name"]}," + "\n" +
                                $"cgst :{reader["cgst"]}," + "\n" +
                                $"sgst :{reader["sgst"]}," + "\n" +
                                $"Product Price :{reader["p_price"]}," + "\n" +
                                $"Product Quantity :{reader["p_quantity"]},"+"\n"+
                                $"Expiry Date: {reader["Exp_Date"]}");
                        }
                    }
                }
            }
        }
        public static void InsertProduct()
        {
            GetUserInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("insert_product", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_name", p_name);
                    cmd.Parameters.AddWithValue("@cgst", cgst);
                    cmd.Parameters.AddWithValue("@sgst", sgst);
                    cmd.Parameters.AddWithValue("@p_price", p_price);
                    cmd.Parameters.AddWithValue("@p_quantity", p_quantity);
                    cmd.Parameters.AddWithValue("@Exp_Date", exp_date);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Property details successfully added");
                    Console.WriteLine("Please find the property details below :");

                   
                    GetProductByName();


                }
            }
        }
    }
}
