using Controller.ArgParser.Entities;
using Controller.ArgParser.Extensions;
using Controller.Controller.Entities;
using Controller.Controller.Interfaces;
using Model.Services.FileReaderService.Entities;
using Model.Services.FileReaderService.Interfaces;
using Model.Services.FileWriterService.Entities;
using Model.Services.FileWriterService.Interfaces;
using Model.Services.ViewNotifier;
using View.View.Entities;
using View.View.Interfaces;

namespace IPChecker;

public class Startup
{
    private IConsoleApiController _controller;
    private IView _view;
    private IReadService _txtReadService;
    private IWriteService _writeService;
    private IViewNotifierService _viewNotifier;

    public Startup()
    {
        _view = new ConsoleView();
        _viewNotifier = new ViewNotifierService(_view);
        _txtReadService = new ReadTxtService(_viewNotifier);
        _writeService = new WriteTxtService(_viewNotifier);
        _controller = new ConsoleApiController(
            new ArgumentParser().Configure(),
            _txtReadService,
            _writeService,
            _view);
    }

    public void Run()
    {
        while (true)
        {
            _controller.GetConsoleRequest();
        }
    }
}