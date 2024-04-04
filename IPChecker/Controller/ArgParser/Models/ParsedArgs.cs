using SourceKit.Generators.Builder.Annotations;

namespace Controller.ArgParser.Models;

[GenerateBuilder]
public partial record ParsedArgs(string FileLog, string FileOutput, string? AddressStart, string? AddressMask);