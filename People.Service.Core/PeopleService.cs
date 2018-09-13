using AutoMapper;
using People.Service.Contract;
using People.Service.Contract.Dto;
using People.Domain;
using People.Logic;
using People.Service.Core.AutoMapper;
using System.Collections.Generic;
using System.IO;
using People.Logic.Exceptions;
using People.Service.Contract.Dto.Faults;
using System.ServiceModel;

namespace People.Service.Core
{
   [AutomapServiceBehavior]
   public partial class PeopleService : IPeopleService
   {
      private readonly string path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "\\file.xml";
      private readonly string personNotFoundFaultMessage = "Person could not be found";

      public IEnumerable<PersonDto> GetPeople()
      {
         PeopleLogic.CreateXMLFileIfNotExists(this.path, "people");
         PeopleLogic logic = new PeopleLogic(this.path);
         logic.Save(this.path);
         List<Person> people = logic.GetPeople();

         return Mapper.Map<List<PersonDto>>(people);
      }

      public int AddPerson(PersonDto person)
      {
         PeopleLogic logic = new PeopleLogic(this.path);
         Person p = Mapper.Map<Person>(person);
         int personId = logic.AddPerson(p);
         logic.Save(this.path);

         return personId;
      }

      public bool EditPerson(PersonDto person, int id)
      {
         PeopleLogic logic = new PeopleLogic(this.path);
         Person p = Mapper.Map<Person>(person);
         try
         {
            logic.EditPerson(id, p);
            logic.Save(this.path);
         }
         catch (PersonNotFoundException)
         {
            PersonNotFoundFault fault = new PersonNotFoundFault();
            fault.Id = id;
            fault.Message = personNotFoundFaultMessage;
            throw new FaultException<PersonNotFoundFault>(fault);
         }

         return true;
      }

      public bool DeletePerson(int id)
      {
         PeopleLogic logic = new PeopleLogic(this.path);
         try
         {
            logic.DeletePerson(id);
            logic.Save(this.path);
         }
         catch (PersonNotFoundException)
         {
            PersonNotFoundFault fault = new PersonNotFoundFault();
            fault.Id = id;
            fault.Message = personNotFoundFaultMessage;
            throw new FaultException<PersonNotFoundFault>(fault);
         }

         return true;
      }

      public string GetPeopleXML()
      {
         return File.ReadAllText(this.path);
      }
   }
}