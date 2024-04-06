using Controller.ArgParser.Entities;
using Controller.ArgParser.Entities.Links;
using Controller.ArgParser.Interfaces;
using Controller.CfgParser.ExtensionParser;

namespace Controller.ArgParser.Extensions;

public static class ArgParserExtension
{
    public static IArgumentParser Configure(this ArgumentParser parser)
    {
        var extensionLink = new JsonParserLink();
        var startLink = new StartLink();
        var cfgLink = new WithConfigFileLink(extensionLink);
        cfgLink.SetNext(startLink);

        startLink.SetNext(new AddressStartLink());
        startLink.SetNext(new AddressMaksLink());
        startLink.SetNext(new FileLogLink());
        startLink.SetNext(new FileOutputLink());
        startLink.SetNext(new TimeStartLink());
        startLink.SetNext(new TimeEndLink());
        startLink.SetNext(cfgLink);
        
        parser.SetFirstLink(startLink);
        return parser;
    }
}