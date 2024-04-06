namespace Controller.ArgParser.Models;

public record JsonArgs(
    string? FileLog,
    string? FileOutput,
    string? AddressStart,
    string? AddressMask,
    string? TimeStart,
    string? TimeEnd);