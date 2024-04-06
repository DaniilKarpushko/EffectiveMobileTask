// See https://aka.ms/new-console-template for more information


using System.Globalization;

string? time = null;
var a = new A(time is null ? null : DateTime.ParseExact(time, "yyyy-MM-dd", CultureInfo.InvariantCulture));
class A
{
    private DateTime? time;

    public A(DateTime? time)
    {
        this.time = time;
    }
}