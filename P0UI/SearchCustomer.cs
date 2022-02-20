using P0BL;
using P0Model;

namespace P0UI
{

    public class SearchCustomer : IMenu
    {
        private ICustomerBL _cusBL;
        List<Customer> ListOfCustomer = new List<Customer>();
        public SearchCustomer(ICustomerBL c_cusBL)
        {
            _cusBL = c_cusBL;
        }

        public void Display()
        {
           
           Console.WriteLine();
           Console.WriteLine("Type [1] to search for a customer.");
           Console.WriteLine("Type [2] to return to Manager Menu.");
        }

        public string UserChoice()
        {
            
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                Console.WriteLine("Type the name of the Customer to search.");
                string name = Console.ReadLine();
                try
                {
                    ListOfCustomer = _cusBL.SearchCustomer(name);
                }
                catch (System.Exception exe)
                {
                    Console.WriteLine(exe.Message);
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchSmoothie";
                    
                }
                
                foreach (Customer item in ListOfCustomer)
                {
                    Console.WriteLine("================");
                    Console.WriteLine(item); 
                }    
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();     
                return "MainMenu";

                case "2":
                return "ManagerMenu";
                default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "SearchSmoothie";      
            }
        }
    }

    
}