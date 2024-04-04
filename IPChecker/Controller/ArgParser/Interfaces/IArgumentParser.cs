using System.Collections;
using Controller.ArgParser.Models;
using Controller.ArgIterator.Entities;

namespace Controller.ArgParser.Interfaces;

public interface IArgumentParser
{
    ParseResult Parse(IEnumerator iterator);
}