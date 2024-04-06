using System.Collections;
using Controller.ArgIterator.Interfaces;
using Controller.ArgParser.Interfaces;
using Controller.ArgParser.Models;
using Controller.CfgParser.ExtensionParser;

namespace Controller.ArgParser.Entities.Links;

public class WithConfigFileLink : ParserLinkBase
{
    private readonly IExtensionParserLink _extensionParserLink;

    public WithConfigFileLink(IExtensionParserLink extensionParserLink)
    {
        _extensionParserLink = extensionParserLink;
    }

    public override ParseResult Handle(IArgIterator iterator, ParsedArgs.Builder argumentCollector)
    {
        if ((string)iterator.Current == "--file-cfg" && iterator.MoveNext())
        {
            var res = _extensionParserLink.Handle((string)iterator.Current, argumentCollector);
            if (res is not ParseResult.Success)
            {
                return res;
            }
            
            if (!iterator.MoveNext())
            {
                return new ParseResult.Success(argumentCollector);
            }
        }

        return Next is not null ? Next.Handle(iterator, argumentCollector) : new ParseResult.Success(argumentCollector);
    }
}