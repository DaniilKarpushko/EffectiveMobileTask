using Model.Services.Validator.Interfaces;

namespace Model.Services.FileReaderService.Interfaces;

public interface IReadService
{
    IDictionary<string, int> ReadFrom(string file, IDataValidator validator);
}