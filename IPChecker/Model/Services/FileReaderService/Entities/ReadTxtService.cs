using System.Globalization;
using System.Net;
using Model.Models;
using Model.Services.FileReaderService.Interfaces;
using Model.Services.FileWriterService.Interfaces;
using Model.Services.Validator.Interfaces;
using Model.Services.ViewNotifier;
using View.View.Interfaces;

namespace Model.Services.FileReaderService.Entities;

public class ReadTxtService : IReadService
{
    private readonly IViewNotifierService _view;

    public ReadTxtService(IViewNotifierService view)
    {
        _view = view;
    }

    public IDictionary<string, int> ReadFrom(string file, IDataValidator validator)
    {
        IDictionary<string, int> ipDic = new Dictionary<string, int>();
        if (!File.Exists(file))
        {
            _view.Notify("Error: File with logs does not exists");
            return ipDic;
        }

        var reader = new StreamReader(file);
        while (!reader.EndOfStream)
        {
            var data = reader.ReadLine()?.Split(' ', ':');

            if (data is null) continue;

            var parsedData = new IpData(IPAddress.Parse(data[0]),
                DateTime.ParseExact(data[1], "yyyy-MM-dd", CultureInfo.InvariantCulture));
            if (!validator.IsValid(parsedData)) continue;
            if (ipDic.TryGetValue(data[0], out var value))
            {
                ipDic[data[0]] = ++value;
            }
            else
            {
                ipDic.Add(data[0], 1);
            }
        }

        return ipDic;
    }
}