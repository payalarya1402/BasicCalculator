using BasicCalculator.Service;

public class Program
{
     
    static void Main(string[] args)
    {
        System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");
        Calculator c = new Calculator();
        Console.WriteLine( c.currOutput.CurrValue);
        while (true)
        {
            Console.Write(">");
            string s = Console.ReadLine();
            try
            {
                Console.WriteLine(c.Invoke(s));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  "+ ex.Message);
            }
        }
    }
}