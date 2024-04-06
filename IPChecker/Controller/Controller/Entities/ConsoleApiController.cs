using System.Globalization;
using System.Net;
using Controller.ArgParser.Interfaces;
using Controller.ArgParser.Models;
using Controller.Controller.Interfaces;
using Model.Services.FileReaderService.Interfaces;
using Model.Services.FileWriterService.Interfaces;
using Model.Services.Validator.Entities;
using View.View.Interfaces;

namespace Controller.Controller.Entities;

public class ConsoleApiController : IConsoleApiController
{
    private readonly IArgumentParser _argumentParser;
    private readonly IReadService _readService;
    private readonly IWriteService _writeService;
    private readonly IView _view;

    public ConsoleApiController(IArgumentParser argumentParser,
        IReadService readService,
        IWriteService writeService,
        IView view)
    {
        _argumentParser = argumentParser;
        _readService = readService;
        _writeService = writeService;
        _view = view;
    }

    public void GetConsoleRequest()
    {
        var iterator = new ArgIterator.Entities.ArgIterator(_view.ReadArguments().Split(' ').Where(x => x.Length > 0).ToArray());
        var result = _argumentParser.Parse(iterator);
        if (result is ParseResult.Success success)
        {
            var args = success.ParsedArgsBuilder.Build();
            _readService.ReadFrom(args.FileLog!, new DataValidator(
                args.TimeStart is not null
                    ? DateTime.ParseExact(args.TimeStart, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                    : null,
                args.TimeEnd is not null
                    ? DateTime.ParseExact(args.TimeEnd, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                    : null,
                args.AddressStart is not null ? IPAddress.Parse(args.AddressStart) : null,
                args.AddressMask is not null ? IPAddress.Parse(args.AddressMask) : null));
        }else if (result is ParseResult.Failure failure)
        {
            _view.Update(failure.Message);
        }
    }
}