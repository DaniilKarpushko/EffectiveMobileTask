using Controller.ArgParser.Entities;
using Controller.ArgParser.Extensions;
using Controller.ArgParser.Interfaces;
using Controller.ArgParser.Models;
using ArgIterator = Controller.ArgIterator.Entities.ArgIterator;

namespace Tests;

public class ParserTests
{
    private readonly IArgumentParser _argumentParser = new ArgumentParser().Configure();

    [Theory]
    [InlineData("--file-log a --file-output b",
        "ParsedArgs { FileLog = a, FileOutput = b, AddressStart = , AddressMask = , TimeStart = , TimeEnd =  }")]
    [InlineData("--file-log logs.txt --file-output result.txt --address-start 192.0.0.3 --address-mask 255.255.255.0 --time-start 11-03-2022 --time-end 22-12-2024",
        "ParsedArgs { FileLog = logs.txt, FileOutput = result.txt, AddressStart = 192.0.0.3, AddressMask = 255.255.255.0, TimeStart = 11-03-2022, TimeEnd = 22-12-2024 }")]
    public void SuccessParsingTests(string request, string expected)
    {
        var parsedRes = _argumentParser.Parse(new ArgIterator(request));
        var res = parsedRes as ParseResult.Success;
        Assert.Equal(expected, res!.ParsedArgsBuilder.Build().ToString());
    }

    [Theory]
    [InlineData("--file-log a.txt --time-end 04-03-2011", "Error: Necessary args are missing")]
    [InlineData("--file-log a.txt --file-output b.txt --address-mask 255.0.0.0", "Error: Necessary args are missing")]
    [InlineData("--file-log a.txt --file-output b.txt    zzzz", "Error: Unknown argument detected")]
    public void FailParsingTests(string request, string expected)
    {
        var parsedRes = _argumentParser.Parse(new ArgIterator(request));
        var res = parsedRes as ParseResult.Failure;
        Assert.Equal(expected, res!.Message);
    }
}