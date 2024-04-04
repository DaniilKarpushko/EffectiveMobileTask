namespace Controller.ArgParser.Models;

public record ParseResult
{
    protected ParseResult(){}

    public sealed record Success(ParsedArgs ParsedArgs) : ParseResult;

    public sealed record Failure(string Message) : ParseResult;
};