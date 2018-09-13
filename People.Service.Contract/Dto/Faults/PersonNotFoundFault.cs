using System.Runtime.Serialization;

namespace People.Service.Contract.Dto.Faults
{
   [DataContract]
   public class PersonNotFoundFault
   {
      [DataMember]
      public int Id { get; set; }

      [DataMember]
      public string Message { get; set; }
   }
}
