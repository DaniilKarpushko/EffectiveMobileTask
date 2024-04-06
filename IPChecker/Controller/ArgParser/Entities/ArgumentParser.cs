using System.Collections;
using Controller.ArgIterator.Interfaces;
using Controller.ArgParser.Interfaces;
using Controller.ArgParser.Models;
using Controller.CfgParser.ExtensionParser;

namespace Controller.ArgParser.Entities;

public class ArgumentParser : IArgumentParser
{
    private IParserLink? _firstLink;

    public ArgumentParser(IParserLink firstLink)
    {
        _firstLink = firstLink;
    }

    public ArgumentParser()
    {
    }

    public ParseResult Parse(IArgIterator iterator)
    {
        var argumentBuilder = new ParsedArgs.Builder();
        iterator.MoveNext();
        var res = _firstLink?.Handle(iterator, argumentBuilder);
        if (res is ParseResult.Success && !CheckNecessaryArgs(argumentBuilder.Build()))
        {
            return new ParseResult.Failure("Error: Necessary args are missing");
        }

        return res!;
    }

    public void SetFirstLink(IParserLink parserLink)
    {
        _firstLink = parserLink;
    }

    private bool CheckNecessaryArgs(ParsedArgs args)
    {
        return args.FileLog == null || args.FileOutput == null
                                    || args is { AddressMask: not null, AddressStart: null };
        
    }
}