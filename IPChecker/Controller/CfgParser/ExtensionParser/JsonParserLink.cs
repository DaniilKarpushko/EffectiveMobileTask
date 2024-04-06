using Controller.ArgParser.Models;
using Controller.ConfigReader.Entities;
using Controller.ConfigReader.Interfaces;

namespace Controller.CfgParser.ExtensionParser;

public class JsonParserLink : ExtensionParserLinkBase
{
    private IConfigReader _configReader = new JsonConfigReader();

    public override ParseResult Handle(string fileName, ParsedArgs.Builder args)
    {
        if (Path.GetExtension(fileName) == ".json")
        {
            return _configReader.ParseFile(fileName, args);
        }

        return Next is not null ? Next.Handle(fileName, args) : new ParseResult.Failure("Error: Unknown cfg extension");
    }
}