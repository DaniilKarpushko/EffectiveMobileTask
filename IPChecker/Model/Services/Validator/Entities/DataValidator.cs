using System.Net;
using Model.Models;
using Model.Services.Validator.Interfaces;

namespace Model.Services.Validator.Entities;

public class DataValidator : IDataValidator
{
    private readonly IPAddress? _addressStart;
    private readonly IPAddress? _addressMask;
    private readonly DateTime? _timeStart;
    private DateTime? _timeEnd;

    public DataValidator(DateTime? timeStart,DateTime? timeEnd, IPAddress? addressStart, IPAddress? addressMask)
    {
        _addressStart = addressStart;
        _addressMask = addressMask;
        _timeStart = timeStart ?? DateTime.MinValue;
        _timeEnd = timeEnd ?? DateTime.MaxValue;
    }

    public bool IsValid(IpData data)
    {
        return GreaterOrEquals(data.Address) && IsSatisfyMask(data.Address)
            && data.Time >= _timeStart && data.Time < _timeEnd;
    }

    private bool GreaterOrEquals(IPAddress address)
    {
        if (_addressStart is null)
        {
            return true;
        }
        
        var bytesIp1 = address.GetAddressBytes();
        var bytesIp2 = _addressStart.GetAddressBytes();
        for (var i = 0; i < bytesIp1.Length; ++i)
        {
            if (bytesIp1[i] > bytesIp2[i])
            {
                return true;
            }

            if (bytesIp1[i] < bytesIp2[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool IsSatisfyMask(IPAddress address)
    {
        if (_addressMask == null)
        {
            return true;
        }
        
        var bytesIp1 = address.GetAddressBytes();
        var bytesIp2 = _addressStart!.GetAddressBytes();
        var mask = _addressMask.GetAddressBytes();

        return !bytesIp1.Where((t, i) => (byte)(t & mask[i]) != (byte)(bytesIp2[i] & mask[i])).Any();
    }
}