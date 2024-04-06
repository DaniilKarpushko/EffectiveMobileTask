using System.Net;
using Model.Models;

namespace Model.Services.FileWriterService.Interfaces;

public interface IWriteService
{
    void Write(string fileName, IDictionary<string, int> data);
}