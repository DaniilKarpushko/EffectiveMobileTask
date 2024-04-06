using System.Collections;
using Controller.ArgIterator.Interfaces;
using Controller.ArgParser.Interfaces;
using Controller.ArgParser.Models;

namespace Controller.ArgParser.Entities.Links;

public class StartLink : ParserLinkBase
{
    private int _prevPosition = -1;

    public override ParseResult Handle(IArgIterator iterator, ParsedArgs.Builder argumentCollector)
    {
        if (iterator.CurrentPosition() == _prevPosition && !iterator.MoveNext())
        {
            return new ParseResult.Failure("Error: Unknown argument detected");
        }
        _prevPosition = iterator.CurrentPosition();
        return Next?.Handle(iterator, argumentCollector)!;
    }
}