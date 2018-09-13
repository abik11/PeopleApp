using System;

namespace People.Domain
{
   public class Person
   {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
      public DateTime Birthday { get; set; }
      public Address Address { get; set; }
   }
}