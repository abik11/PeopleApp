using People.Service.Contract.Dto;
using People.Service.Contract.Dto.Faults;
using System.Collections.Generic;
using System.ServiceModel;

namespace People.Service.Contract
{
   [ServiceContract]
   public interface IPeopleService
   {
      [OperationContract]
      IEnumerable<PersonDto> GetPeople();

      [OperationContract]
      int AddPerson(PersonDto person);

      [OperationContract]
      [FaultContract(typeof(PersonNotFoundFault))]
      bool EditPerson(PersonDto person, int id);

      [OperationContract]
      [FaultContract(typeof(PersonNotFoundFault))]
      bool DeletePerson(int id);

      [OperationContract]
      string GetPeopleXML();
   }
}