using View.View.Interfaces;

namespace View.View.Entities;

public class ConsoleView : IView
{
   public string ReadArguments()
    {
        Console.WriteLine("Please, make a request: ");
        return Console.ReadLine() ?? string.Empty;
        
        
    }

    public void Update(string data)
    {
        Console.WriteLine(data);
    }
}