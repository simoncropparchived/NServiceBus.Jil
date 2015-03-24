using System.Diagnostics;
using Jil;
using NUnit.Framework;

[TestFixture]
class JilTests
{
        Options options= new Options(false, false, false, DateTimeFormat.NewtonsoftStyleMillisecondsSinceUnixEpoch, true); 

    [Test]
    public void Simple()
    {
        var serialize = JSON.Serialize(new Person()
                                              {
                                                  Name = "Simon"
                                              }, options);
        Trace.WriteLine(serialize);
    }
    [Test]
    public void Inherited()
    {
        var serialize = JSON.Serialize(new Child()
                                              {
                                                  Name = "Simon"
                                              }, options);
        Trace.WriteLine(serialize);
    }
}

class Person
{
    public string Name { get; set; }
}
class Child: Person
{
}