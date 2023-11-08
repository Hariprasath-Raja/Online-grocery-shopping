using customerBilling;

public class program
{
    public void Menu()
    {
        Console.WriteLine("Choose \n 1.View All product \n 2.Insert Product \n 3.Update Product \n 4.Delete Product \n 5.Exit");
        Console.WriteLine("What do you Need ????");
        int options = Convert.ToInt32(Console.ReadLine());
       
        switch (options)
        {

            case 1:
                fetchDetails.GetProductDetails();
                break;
            case 2:
                InsertProductDetails.InsertProduct();
                break;
            case 3:
                updateDetails.UpdateProduct();
                break;
            case 4:
                DeleteProduct.DeleteProducts(); 
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Hari Department Store");
        Console.WriteLine("\n **************************************");
        program p = new program();
        Console.WriteLine("1.User,2.Admin");
        int choice=Convert.ToInt32(Console.ReadLine());
        switch(choice)
        {
            case 1:
                userDetails ud=new userDetails();
                ud.userlogincheck();
                break;
            case 2:
                login lg = new login();
                lg.logincheck();
                break;
            default : 
                Console.WriteLine("Invalid Options");
                break;

        }

        


    }
}