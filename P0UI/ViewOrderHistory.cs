using P0BL;
using P0Model;

namespace P0UI
{
    public class ViewOrderHistory : IMenu
    {
        private Customer _customer = new Customer();
        private ICustomerBL _cusBL;

        string store;
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
                   if(order.fstore == 1)
                   {
                       store = "SmoothieShackBronx";
                   } else if(order.fstore == 2)
                   {
                       store = "SmoothieShackMan";
                   }
                   
                   Console.WriteLine("Order ID: " + order.OrderID + "  Total Price: $" + order.totalPrice + " Store Name: " + store);
                   Console.WriteLine("Date and Time: " + order.datet);
                   Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
                   List<SmoothieModel> SmoothieList = _cusBL.GetOrderByCustomer(order.OrderID);
                   foreach (SmoothieModel item in SmoothieList)
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(item);
                    Console.WriteLine("--------------------------------");

                }
                    
                    var coco = from smothiecoco in SmoothieList
                                                where smothiecoco.Name == "CoconutFusion"
                                                select smothiecoco;
                    if(coco.Count() > 0)
                    {
                        double total = 0;
                        foreach (var item in coco)
                        {
                            total += item.Price;
                        }
                        Console.WriteLine("There are " + coco.Count() + " CoconutFusion's that cost $" + total + " in total.");

                    }
                    var berry = from smothiecoco in SmoothieList
                                                where smothiecoco.Name == "VeryBerry"
                                                select smothiecoco;
                    if(berry.Count() > 0)
                    {
                        double total = 0;
                        foreach (var item in berry)
                        {
                            total += item.Price;
                        }
                        Console.WriteLine("There are " + berry.Count() + " VeryBerry's that cost $" + total + " in total.");

                    }

                    var trop = from smothiecoco in SmoothieList
                                                where smothiecoco.Name == "TropicalBreeze"
                                                select smothiecoco; 

                    if(trop.Count() > 0)
                    {
                        double total = 0;
                        foreach (var item in trop)
                        {
                            total += item.Price;
                        }
                        Console.WriteLine("There are " + trop.Count() + " TropicalBreeze's that cost $" + total + " in total.");

                    }

                    var protien = from smothiecoco in SmoothieList
                                                where smothiecoco.Name == "ProtienShake"
                                                select smothiecoco;  

                    if(protien.Count() > 0)
                    {
                        double total = 0;
                        foreach (var item in protien)
                        {
                            total += item.Price;
                        }
                        Console.WriteLine("There are " + protien.Count() + " ProtienShake's that cost $" + total + " in total.");

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