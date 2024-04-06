using System.Collections;
using Controller.ArgIterator.Interfaces;
using Controller.ArgParser.Models;

namespace Controller.ArgParser.Interfaces;

public interface IParserLink
{
    ParseResult Handle(IArgIterator iterator, ParsedArgs.Builder argumentCollector);
    void SetNext(IParserLink link);
}