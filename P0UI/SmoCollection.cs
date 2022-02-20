using P0Model;
namespace P0UI;


public class SmoCollection : IMenu
{
    public new void Display() 
    {
        Console.WriteLine("There are 4 smoothies available to order.");
        Console.WriteLine();
        for (int i = 1; i < 5; i++)
        {
            SmoothieModel sm = new SmoothieModel(i);
            Console.WriteLine(sm.Name + " has an order number of " + i);
            Console.WriteLine(sm.Name + " contains the following ingredients.");
            foreach (Ingredients item in sm.Ingredients)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++");
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("The prices are:");
        Console.WriteLine("$5.00 for a small cup");
        Console.WriteLine("$6.50 for a medium cup");
        Console.WriteLine("$7.00 for a large cup");

        
    }

    public string UserChoice()
    {
        Console.WriteLine("Type [0] to return to Customer Menu");
        Console.WriteLine("Type [1] to order a smoothie");

        string userInput = Console.ReadLine();

        switch(userInput)
        {
            case "0":
            return "CustomerMenu";
            break;
            case "1":
            return "AddSmoothie";
            break;
            default:
            Console.WriteLine("Please input a valid response");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            return "MainMenu";
            break;

        }
        throw new NotImplementedException();
    }
}