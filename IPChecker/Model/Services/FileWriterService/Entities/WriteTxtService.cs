using Model.Services.FileWriterService.Interfaces;
using Model.Services.ViewNotifier;
using View.View.Interfaces;

namespace Model.Services.FileWriterService.Entities;

public class WriteTxtService : IWriteService
{
    private readonly IViewNotifierService _view;

    public WriteTxtService(IViewNotifierService view)
    {
        _view = view;
    }

    public void Write(string fileName, IDictionary<string, int> data)
    {
        if (!File.Exists(fileName))
        {
            _view.Notify("Error: Input file does not exists");
            return;
        }
        using (var streamWriter = new StreamWriter(fileName))
        {
            foreach (var el in data)
            {
                streamWriter.WriteLine(el.Key + " " + el.Value);
            }
        }

        _view.Notify("All is Done!");
    }
}