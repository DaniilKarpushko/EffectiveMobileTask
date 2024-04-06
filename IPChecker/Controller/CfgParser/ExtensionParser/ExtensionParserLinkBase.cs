using Controller.ArgParser.Models;

namespace Controller.CfgParser.ExtensionParser;

public abstract class ExtensionParserLinkBase : IExtensionParserLink
{
    protected IExtensionParserLink? Next;
    public abstract ParseResult Handle(string fileName, ParsedArgs.Builder args);

    public void SetNext(IExtensionParserLink link)
    {
        if (Next is null)
        {
            Next = link;
            return;
        }

        Next.SetNext(link);
    }
}