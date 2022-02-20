namespace P0UI
{
    public class ManagerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("❥•°❀°•༢");
            Console.WriteLine("Type [1] to search for a customer.");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [2] to view order history.");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [3] to view inventory");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [4] to Go Back to Main Menu.");
            Console.WriteLine("❥•°❀°•༢");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                return "SearchCustomer";

                case "2":
                return "ViewOrderHistory";

                case "3":
                return "ViewStoreInventory";

                case "4":
                return "MainMenu";

                default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "ManagerMenu";
            }
        }
    }
}