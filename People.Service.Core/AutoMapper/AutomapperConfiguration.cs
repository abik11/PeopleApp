using AutoMapper;
using People.Service.Contract.Dto;
using People.Domain;

namespace People.Service.Core.AutoMapper
{
   public class AutomapperConfiguration
   {
      public static void Configure()
      {
         Mapper.Initialize(ctg =>
         {
            ctg.CreateMap<Person, PersonDto>().ReverseMap();
            ctg.CreateMap<Address, AddressDto>().ReverseMap();
         });
      }
   }
}