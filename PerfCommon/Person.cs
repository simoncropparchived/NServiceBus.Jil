using System;
using System.Collections.Generic;
using NServiceBus;

public class CreatePerson:IMessage
{
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Employer { get; set; }
    public List<Child> Children { get; set; }
}