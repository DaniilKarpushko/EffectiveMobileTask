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
        var request = _view.ReadArguments();
        if (request.Length == 0)
        {
            _view.Update("Error: Empty request");
            return;
        }
        var iterator = new ArgIterator.Entities.ArgIterator(request);
        var result = _argumentParser.Parse(iterator);
        
        switch (result)
        {
            case ParseResult.Success success:
            {
                var args = success.ParsedArgsBuilder.Build();
                var readData = _readService.ReadFrom(args.FileLog!, new DataValidator(
                    args.TimeStart is not null
                        ? DateTime.ParseExact(args.TimeStart, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                        : null,
                    args.TimeEnd is not null
                        ? DateTime.ParseExact(args.TimeEnd, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                        : null,
                    args.AddressStart is not null ? IPAddress.Parse(args.AddressStart) : null,
                    args.AddressMask is not null ? IPAddress.Parse(args.AddressMask) : null));
                _writeService.Write(args.FileOutput!, readData);
                break;
            }
            case ParseResult.Failure failure:
                _view.Update(failure.Message);
                break;
        }
    }
}