namespace P0UI;
public class MainMenu : IMenu
{
    public void Display()
    {
        Console.WriteLine("Welcome to the *.SmoothieShack.* App!");
        Console.WriteLine("Please type one of the following numbers to navigate through the app");
        
        Console.WriteLine();
        Console.WriteLine("Type [1] if you are a customer");
        Console.WriteLine();
        Console.WriteLine("~~~~~~~~~----------------~~~~~~~~~");
        Console.WriteLine();
        Console.WriteLine("Type [2] if you are a manager");
        Console.WriteLine();
        Console.WriteLine("~~~~~~~~~----------------~~~~~~~~~");
        Console.WriteLine();
        Console.WriteLine("Type [3] to exit app");
        Console.WriteLine();
        Console.WriteLine("~~~~~~~~~----------------~~~~~~~~~");
    }

    public string UserChoice()
    {
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1" :
            return "CustomerMenu";
            
            case "2" :
            bool correct = true;
            while (correct)
            {
            Console.WriteLine("Please enter password to access Manager Menu.");
            string pass = Console.ReadLine();
            if(pass == "admin")
            {
                correct = false;
            } else
            {
                Console.WriteLine("Incorrect password. Try again.");
            }
            }
            return "ManagerMenu";
            
            case "3" :
            return "Exit";
            
            default:
            Console.WriteLine("Please input a valid response");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            return "MainMenu";
            
        }
    }
}