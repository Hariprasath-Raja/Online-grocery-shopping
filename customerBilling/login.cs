using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerBilling
{
    internal class login
    {
        public string username;


        public string pwd { get; set; }

        static SqlCommand cmd;

        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=customerbilling;Persist Security Info=True;User ID=sa;Password=sql@123";

        public void ShowMenu()
        {

           program obj= new program();
            obj.Menu();
            Console.WriteLine("Would you like to continue (Y / N)");
            char choice = Convert.ToChar(Console.ReadLine());
            while (choice == 'Y' && choice != 'N')
            {
                obj.Menu();
            }
        }
        public void LoginUserInput()
        {
            Console.WriteLine("Enter Admin name");
            username = Console.ReadLine();
            Console.WriteLine("Enter password");
            pwd = Console.ReadLine();
            Console.WriteLine("_____________________________________");
            //  pwd = Console.ReadLine();
        }

        public void UserRegistration()
        {
            LoginUserInput();
            using (var con = new SqlConnection(connectionString))
            {


                using (var cmd = new SqlCommand("userregistration", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@userid", pwd);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User registration successfull");
                    ShowMenu();

                }
            }
        }


        public void logincheck()
        {
            using (var con = new SqlConnection(connectionString))
            {

                LoginUserInput();

                using (var cmd = new SqlCommand("select dbo.adminlogincheck(@username,@pwd)", con))
                {


                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());


                    if (count == 1)
                    {

                        Console.WriteLine("welcome " + username);
                        ShowMenu();


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
