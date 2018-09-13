using People.Domain;
using People.Logic.Base;
using People.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace People.Logic
{
   public class PeopleLogic : XMLLogic
   {
      protected List<Person> people;

      public PeopleLogic() : base()
      { }

      public PeopleLogic(string path) : base(path)
      { }

      public List<Person> GetPeople()
      {
         if (people == null || people.Count == 0)
            return GetAllPepole();

         else if (people.Count < xdoc.Descendants("person").Count())
            return GetAllPepole();

         else
            return people;
      }

      protected List<Person> GetAllPepole()
      {
         var people =
            from person in xdoc.Descendants("person")
            let address = person.Element("address")
            select new Person()
            {
               Id = Convert.ToInt32(person.Attribute("id").Value),
               FirstName = person.Element("firstName").Value,
               LastName = person.Element("lastName").Value,
               PhoneNumber = person.Element("phoneNumber").Value,
               Birthday = DateTime.Parse(person.Element("birthday").Value),
               Address = new Address()
               {
                  Street = address.Element("street").Value,
                  HouseNumber = address.Element("houseNumber").Value,
                  AppartmentNumber = address.Element("appartmentNumber")?.Value,
                  PostalCode = address.Element("postalCode").Value
               }
            };

         return people.ToList();
      }

      public void DeletePerson(int id, bool save = false)
      {
         var person = xdoc.Descendants("person")
            .FirstOrDefault(x => x.Attribute("id").Value == id.ToString());

         if (person == null)
            throw new PersonNotFoundException();
         else
            person.Remove();

         if (save)
            xdoc.Save(this.path);
      }

      public int AddPerson(Person person, bool save = false)
      {
         Random rnd = new Random();
         int id = rnd.Next(1, int.MaxValue);
         while (PersonExists(id))
            id = rnd.Next(1, int.MaxValue);

         XElement newPerson =
            new XElement("person",
               new XAttribute("id", id),
               new XElement("firstName", person.FirstName),
               new XElement("lastName", person.LastName),
               new XElement("phoneNumber", person.PhoneNumber),
               new XElement("birthday", person.Birthday)
            );

         XElement newAddress =
            new XElement("address", 
               new XElement("street", person.Address.Street),
               new XElement("houseNumber", person.Address.HouseNumber),
               new XElement("appartmentNumber", person.Address.AppartmentNumber),
               new XElement("postalCode", person.Address.PostalCode)
            );

         newPerson.Add(newAddress);
         xdoc.Element("people").Add(newPerson);

         if (save)
            xdoc.Save(this.path);

         return id;
      }

      public void EditPerson(int id, Person person, bool save = false)
      {
         XElement oldPerson = xdoc.Descendants("person")
            .FirstOrDefault(x => x.Attribute("id").Value == id.ToString());
         XElement oldAddress = oldPerson.Descendants("address").FirstOrDefault();

         if (oldPerson != null)
         {
            oldPerson.Element("firstName").Value = person.FirstName;
            oldPerson.Element("lastName").Value = person.LastName;
            oldPerson.Element("phoneNumber").Value = person.PhoneNumber;
            oldPerson.Element("birthday").Value = person.Birthday.ToString("yyyy-MM-ddThh:mm:ss");
            oldPerson.Element("firstName").Value = person.FirstName;

            if (oldAddress != null)
            {
               oldAddress.Element("street").Value = person.Address.Street;
               oldAddress.Element("houseNumber").Value = person.Address.HouseNumber;
               oldAddress.Element("postalCode").Value = person.Address.PostalCode;
               oldAddress.Element("appartmentNumber").Value = person.Address.AppartmentNumber;
            }

            if (save)
               xdoc.Save(this.path);
         }
         else
         {
            throw new PersonNotFoundException();
         }
      }

      public bool PersonExists(int id)
      {
         return xdoc.Descendants("person")
            .Any(x => x.Attribute("id").Value == id.ToString());
      }
   }
}