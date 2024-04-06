using System.Collections;
using Controller.ArgParser.Models;
using Controller.ArgIterator.Entities;
using Controller.ArgIterator.Interfaces;

namespace Controller.ArgParser.Interfaces;

public interface IArgumentParser
{
    ParseResult Parse(IArgIterator iterator);
    void SetFirstLink(IParserLink parserLink);
}