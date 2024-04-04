using View.View.Interfaces;

namespace View.View.Entities;

public class ConsoleView : IView
{
    public void Listen()
    {
        var argsString = Console.ReadLine();
        
        
    }

    public void Update(string data)
    {
        Console.WriteLine(data);
    }
}