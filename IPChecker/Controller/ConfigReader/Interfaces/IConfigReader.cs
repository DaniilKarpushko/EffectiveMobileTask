using Controller.ArgParser.Models;

namespace Controller.ConfigReader.Interfaces;

public interface IConfigReader
{
    ParseResult ParseFile(string cfgName, ParsedArgs.Builder argsBuilder);
}