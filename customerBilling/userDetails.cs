using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerBilling
{
    internal class userDetails
    {
        public static string username;
        public static string userid;
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=customerbilling;Persist Security Info=True;User ID=sa;Password=sql@123";

        public void Userinput()
        {
            Console.WriteLine("Enter username");
            username = Console.ReadLine();
            Console.WriteLine("Enter userid");
            userid = (Console.ReadLine());
            Console.WriteLine("_____________________________________");
            //  pwd = Console.ReadLine();
        }
        public void UserRegistration()
        {
            Userinput();
            using (var con = new SqlConnection(connectionString))
            {


                using (var cmd = new SqlCommand("customerregistration", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", userid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("customer registration successfull");
                    

                }
            }
        }
        public void userlogincheck()
        {
            using (var con = new SqlConnection(connectionString))
            {

                Userinput();

                using (var cmd = new SqlCommand("select dbo.userlogincheck(@username,@userid)", con))
                {


                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());


                    if (count == 1)
                    {

                        Console.WriteLine("welcome " + username);



                    }
                    else
                    {
                        Console.WriteLine("User profile not available,Register Yourself");
                        Console.WriteLine("Choose \n 1.Register Yourself \n 2.Exit");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                UserRegistration();
                                break;

                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }
    }
}
        
