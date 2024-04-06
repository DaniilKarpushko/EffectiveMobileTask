using System.Collections;
using Controller.ArgIterator.Interfaces;
using Controller.ArgParser.Models;

namespace Controller.ArgParser.Interfaces;

public abstract class ParserLinkBase : IParserLink
{
    protected IParserLink? Next;
    
    public abstract ParseResult Handle(IArgIterator iterator, ParsedArgs.Builder argumentCollector);

    public void SetNext(IParserLink link)
    {
        if (Next is null)
        {
            Next = link;
            return;
        }

        Next.SetNext(link);
    }
}