using P0BL;
using P0Model;

namespace P0UI
{
    public class CustomerInfo : IMenu
    {
        string name;
        string email;
        int age;
        private static Customer _customer = new Customer();

        private ICustomerBL _cusBL;

        public CustomerInfo(ICustomerBL c_cusBL)
        {
            _cusBL = c_cusBL;
        }
        
        public void Display()
        {
            Console.WriteLine("Enter your information.");
            Console.WriteLine("Type [4] to enter Name - " + _customer.Name);
            Console.WriteLine("Type [3] to enter Age - " + _customer.Age);
            Console.WriteLine("Type [2] to enter Email - " + _customer.Email);
            Console.WriteLine("Type [1] to View and Save.");
            Console.WriteLine("Type [0] to Go Back.");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                return "CustomerMenu";
                case "1":
                Console.WriteLine("Your info is:");
                Console.WriteLine("Name : " + _customer.Name);
                Console.WriteLine("Age : " + _customer.Age);
                Console.WriteLine("Email : " + _customer.Email);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.WriteLine("Must create a password to save customer information.");
                bool passequal = true;
                while (passequal)
                {
                Console.WriteLine("Please enter password below.");
                _customer.passwordd =  Console.ReadLine();
                Console.WriteLine("Please confirm password by typing it a second time.");
                string pass = Console.ReadLine();
                if (_customer.passwordd == pass)
                {
                    passequal = false;
                } else
                {
                    Console.WriteLine("The passwords entered do not match.\nPlease try again.");
                } 
                } 
                
                
                Log.Information("Adding customer " + _customer);
                try
                {
                   _cusBL.AddCustomer(_customer); 
                }
                catch (System.Exception exe)
                {
                    
                    Console.WriteLine(exe.Message);
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "CustomerInfo";
                }
                

                return "MainMenu";
                case "2":
                Console.WriteLine("Please enter the beginning of your email");
                Console.WriteLine("The beginning will be attatched to @gmail.com");
                string em = Console.ReadLine();
                _customer.Email = em + "@gmail.com";
                return "CustomerInfo";
                case "3":
                Console.WriteLine("Please enter your age.");
                _customer.Age = Convert.ToInt32(Console.ReadLine());
                return "CustomerInfo";
                case "4":
                Console.WriteLine("Please enter your name.");
                _customer.Name = Console.ReadLine();
                return "CustomerInfo";
                default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "CustomerInfo";
            }
        }
    }
}