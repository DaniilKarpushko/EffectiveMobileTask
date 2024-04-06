using Model.Models;

namespace Model.Services.Validator.Interfaces;

public interface IDataValidator
{
    bool IsValid(IpData data);
}