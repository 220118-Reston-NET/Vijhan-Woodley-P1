using P0BL;

namespace P0UI
{
    public class ViewStoreInventory : IMenu
    {
         private ISmoothieBL _smoBL;

         public ViewStoreInventory(ISmoothieBL s_smoBL)
         {
             _smoBL = s_smoBL;
         }
        public void Display()
        {
            Console.WriteLine("Type [1] to view inventory for SmoothieShackBronx");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [2] to view inventory for SmoothieShackMan");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [3] to go back to Manager Menu");
            Console.WriteLine("-----------------------------------");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                _smoBL.ViewInventory(1);
                
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.WriteLine("Would you like to increase inventory by ten?");
                Console.WriteLine("Type [1] for yes");
                Console.WriteLine("Type [0] for no");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    _smoBL.AddInventory(1);
                    _smoBL.ViewInventory(1);
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ViewStoreInventory";
                    case "0":
                    return "ViewStoreInventory";
                    default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ViewStoreInventory";
                    
                }

                case "2":
                _smoBL.ViewInventory(2);
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.WriteLine("Would you like to increase inventory by ten?");
                Console.WriteLine("Type [1] for yes");
                Console.WriteLine("Type [0] for no");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    _smoBL.AddInventory(2);
                    _smoBL.ViewInventory(2);
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ViewStoreInventory";
                    case "0":
                    return "ViewStoreInventory";
                    default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ViewStoreInventory";
                    
                }
                
                case "3":
                return "ManagerMenu";
                default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "ViewStoreInventory";
            }
        }
    }
}