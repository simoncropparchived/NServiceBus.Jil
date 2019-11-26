using System.Diagnostics;
using Jil;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

public class JilTests :
    VerifyBase
{
    Options options = new Options(
        prettyPrint: false,
        excludeNulls: false,
        jsonp: false,
        dateFormat: DateTimeFormat.MicrosoftStyleMillisecondsSinceUnixEpoch,
        includeInherited: true);

    [Fact]
    public void Simple()
    {
        var person = new Person
        {
            Name = "Simon"
        };
        var serialize = JSON.Serialize(person, options);
        Trace.WriteLine(serialize);
    }

    [Fact]
    public void Inherited()
    {
        var child = new Child
        {
            Name = "Simon"
        };
        var serialize = JSON.Serialize(child, options);
        Trace.WriteLine(serialize);
    }

    public JilTests(ITestOutputHelper output) :
        base(output)
    {
    }
}

class Person
{
    public string? Name { get; set; }
}

class Child :
    Person
{
}