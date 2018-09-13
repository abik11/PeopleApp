using System;
using System.Runtime.Serialization;

namespace People.Service.Contract.Dto
{
   [DataContract]
   public class PersonDto
   {
      [DataMember]
      public int Id { get; set; }
      [DataMember]
      public string FirstName { get; set; }
      [DataMember]
      public string LastName { get; set; }
      [DataMember]
      public string PhoneNumber { get; set; }
      [DataMember]
      public DateTime Birthday { get; set; }
      [DataMember]
      public AddressDto Address { get; set; }
   }
}