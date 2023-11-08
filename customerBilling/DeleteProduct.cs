using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace customerBilling
{
    internal class DeleteProduct
    {
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=customerbilling;Persist Security Info=True;User ID=sa;Password=sql@123;";
        public static string id; 
        public static void  DeleteProducts()
        {
            Console.WriteLine("enter your product id");
            id = Console.ReadLine();
            //public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=customerbilling;Persist Security Info=True;User ID=sa;Password=sql@123;";

            Console.WriteLine("Are you sure that you want to delete this property ? (Y /N)");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'Y')
            {
                using (var con = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("deleteproduct", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Product successfully deleted");
            }
            else
            {
                Console.WriteLine("Product not deleted ");
                fetchDetails.GetProductDetails();
            }
        }
    }
}
