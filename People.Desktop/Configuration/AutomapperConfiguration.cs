using AutoMapper;
using People.Desktop.Model;
using People.Desktop.PeopleService;

namespace People.Desktop.Configuration
{
   public class AutomapperConfiguration
   {
      public static void Configure()
      {
         Mapper.Initialize(ctg => 
         {
            ctg.CreateMap<PersonDto, Person>().ReverseMap();
            ctg.CreateMap<AddressDto, Address>().ReverseMap();
         });
      }
   }
}