using Jil;

public class JilTests
{
    Options options = new(
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
}

class Person
{
    public string? Name { get; set; }
}

class Child :
    Person
{
}