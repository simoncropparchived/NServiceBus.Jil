using System;
using System.Collections.Generic;

public static class PersonCreater
{
    public static CreatePerson Create()
    {
        return new CreatePerson
               {
                   FamilyName = "Smith",
                   GivenName = "John",
                   Children = new List<Child>
                              {
                                  new Child
                                  {
                                      FamilyName = "Smith",
                                      GivenName = "One"
                                  },
                                  new Child
                                  {
                                      FamilyName = "Smith",
                                      GivenName = "Two"
                                  },
                                  new Child
                                  {
                                      FamilyName = "Smith",
                                      GivenName = "Three"
                                  },
                                  new Child
                                  {
                                      FamilyName = "Smith",
                                      GivenName = "Four"
                                  },
                                  new Child
                                  {
                                      FamilyName = "Smith",
                                      GivenName = "Five"
                                  },
                              },
                   DateOfBirth = DateTime.Now,
                   Employer = "Google",
                   Gender = Gender.Male,
               };
    }
}