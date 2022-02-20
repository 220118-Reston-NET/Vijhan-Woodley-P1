namespace P0UI
{
    public class CustomerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("Type [1] to view our collection of smoothies and prices");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [2] to create new account");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [3] to make a smoothie order");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [4] to Go Back to Main Menu.");
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°");
        }

        public string UserChoice()
        {
           string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                return "ViewSmoothies";

                case "2":
                return "CustomerInfo";

                case "3":
                return "AddSmoothie";

                case "4":
                return "MainMenu";

                default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "CustomerMenu";
            }
        }
    }
}