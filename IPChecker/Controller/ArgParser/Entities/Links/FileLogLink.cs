﻿using System.Collections;
using Controller.ArgIterator.Interfaces;
using Controller.ArgParser.Interfaces;
using Controller.ArgParser.Models;

namespace Controller.ArgParser.Entities.Links;

public class FileLogLink : ParserLinkBase
{
    public override ParseResult Handle(IArgIterator iterator, ParsedArgs.Builder argumentCollector)
    {
        if ((string)iterator.Current == "--file-log" && iterator.MoveNext())
        {
            argumentCollector.WithFileLog((string)iterator.Current);
            if (!iterator.MoveNext())
            {
                return new ParseResult.Success(argumentCollector);
            }
        }

        return Next is not null ? Next.Handle(iterator, argumentCollector) : new ParseResult.Success(argumentCollector);
    }
}