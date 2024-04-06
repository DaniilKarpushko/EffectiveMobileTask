using System.Text.Json;
using Controller.ArgParser.Models;
using Controller.ConfigReader.Interfaces;

namespace Controller.ConfigReader.Entities;

public class JsonConfigReader : IConfigReader
{
    public ParseResult ParseFile(string cfgName, ParsedArgs.Builder argsBuilder)
    {
        var jsonContent = File.ReadAllText(cfgName);
        var args = JsonSerializer.Deserialize<JsonArgs>(jsonContent);
        var temp = argsBuilder.Build();

        if (args is null)
        {
            return new ParseResult.Failure("Error: Wrong cfg construction");
        }
        
        argsBuilder.WithFileOutput(args.FileOutput ?? temp.FileOutput);
        argsBuilder.WithFileLog(args.FileLog ?? temp.FileLog);
        argsBuilder.WithAddressStart(args.AddressStart ?? temp.AddressStart);
        argsBuilder.WithAddressMask(args.AddressMask ?? temp.AddressMask);
        argsBuilder.WithTimeStart(args.TimeStart ?? temp.TimeStart);
        argsBuilder.WithTimeEnd(args.TimeEnd ?? temp.TimeEnd);
        
        return new ParseResult.Success(argsBuilder);
    }
}