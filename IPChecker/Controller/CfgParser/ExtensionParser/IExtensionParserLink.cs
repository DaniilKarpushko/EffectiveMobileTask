using Controller.ArgParser.Models;

namespace Controller.CfgParser.ExtensionParser;

public interface IExtensionParserLink
{
    ParseResult Handle(string fileName, ParsedArgs.Builder args);
    void SetNext(IExtensionParserLink link);
}