using P0BL;
using P0Model;

namespace P0UI
{
    public class ViewOrderHistory : IMenu
    {
        private Customer _customer = new Customer();
        private ICustomerBL _cusBL;
        public ViewOrderHistory(ICustomerBL c_cusBL)
        {
            _cusBL = c_cusBL;
        }
        public void Display()
        {
            Console.WriteLine("Type [1] to view order history for Customer.");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [2] to view order history for SmoothieShackBronx.");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [3] to view order history for SmoothieShackMan.");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Type [4] to go back to Manager Menu.");
            Console.WriteLine("-----------------------------------");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                Console.WriteLine("What is your email to begin?");
                Console.WriteLine("Format: name@gmail.com");
                string _email = Console.ReadLine();
                try
                {
                    _customer = _cusBL.SearchSpecificCustomer(_email);
                }
                catch (System.Exception exe)
                {
                
                    Console.WriteLine(exe.Message);
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ViewOrderHistory";
                }
               List<Orders> OrdersList = _cusBL.GetAllOrdersByCustomer(_customer.cusID);
               Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
               foreach (Orders order in OrdersList)
               {
                   
                   Console.WriteLine("Order: " + order.OrderID + "  Total Price: $" + order.totalPrice);
                   Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
                   List<SmoothieModel> SmoothieList = _cusBL.GetOrderByCustomer(order.OrderID);
                   foreach (SmoothieModel item in SmoothieList)
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(item);
                    Console.WriteLine("--------------------------------");

                }
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
               }

                
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "ViewOrderHistory";
                
                case "2":
                Console.WriteLine("Here are the orders for SmoothieShackBronx");

                OrdersList = _cusBL.GetAllOrdersByStore(1);
               Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
               foreach (Orders order in OrdersList)
               {
                   
                   Console.WriteLine("Order: " + order.OrderID + "  Total Price: $" + order.totalPrice);
                   Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
                   List<SmoothieModel> SmoothieList = _cusBL.GetOrderByCustomer(order.OrderID);
                   foreach (SmoothieModel item in SmoothieList)
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(item);
                    Console.WriteLine("--------------------------------");

                }
                 Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
               }
               
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();

                return "ViewOrderHistory";
                case "3":
                Console.WriteLine("Here are the orders for SmoothieShackMan");

                 OrdersList = _cusBL.GetAllOrdersByStore(2);
               Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
               foreach (Orders order in OrdersList)
               {
                   
                   Console.WriteLine("Order: " + order.OrderID + "  Total Price: $" + order.totalPrice);
                   Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
                   List<SmoothieModel> SmoothieList = _cusBL.GetOrderByCustomer(order.OrderID);
                   foreach (SmoothieModel item in SmoothieList)
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(item);
                    Console.WriteLine("--------------------------------");

                }
                 Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
               }
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "ViewOrderHistory";
                case "4":
                return "ManagerMenu";
                default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "ViewOrderHistory";
            }
        }
    }
}