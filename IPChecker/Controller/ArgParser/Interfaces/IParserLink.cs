using System.Collections;
using Controller.ArgParser.Models;

namespace Controller.ArgParser.Interfaces;

public interface IParserLink
{
    void Handle(IEnumerator iterator, ParsedArgs.Builder argumentCollector);
    void SetNext(IParserLink link);
}