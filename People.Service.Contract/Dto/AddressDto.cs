using System.Runtime.Serialization;

namespace People.Service.Contract.Dto
{
   [DataContract]
   public class AddressDto
   {
      [DataMember]
      public string Street { get; set; }
      [DataMember]
      public string HouseNumber { get; set; }
      [DataMember]
      public string AppartmentNumber { get; set; }
      [DataMember]
      public string PostalCode { get; set; }
   }
}