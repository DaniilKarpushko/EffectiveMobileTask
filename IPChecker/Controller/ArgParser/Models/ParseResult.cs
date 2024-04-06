namespace Controller.ArgParser.Models;

public record ParseResult
{
    protected ParseResult(){}

    public sealed record Success(ParsedArgs.Builder ParsedArgsBuilder) : ParseResult;

    public sealed record Failure(string Message) : ParseResult;
};