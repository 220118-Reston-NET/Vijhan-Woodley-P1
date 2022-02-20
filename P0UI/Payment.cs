using P0Model;
public class Payment 
{
    public void _purchase(SmoothieModel sm, int money)
    {
        if(money > sm.Price)
        {
            double change = money - sm.Price;
            Console.WriteLine("Transaction Complete!");
            Console.WriteLine("Your change is $" + change);
            Console.WriteLine("Here is your " + sm.Name);
        } else if(money == sm.Price)
        {
            Console.WriteLine("Transaction Complete!");
            Console.WriteLine("No change, you provided exact amount.");
            Console.WriteLine("Here is your " + sm.Name);
        } else if(money < sm.Price)
        {
            Console.WriteLine("Unable to complete transaction.");
            Console.WriteLine("Insufficent funds.");
            Console.WriteLine("You provided less than " + sm.Price);
        } else
        {
            Console.WriteLine("Unable to complete transaction.");
            Console.WriteLine("Please type the money to pay for " + sm.Price);
        }
    }
}