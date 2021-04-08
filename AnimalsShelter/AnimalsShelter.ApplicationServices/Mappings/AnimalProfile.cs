using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.DataAccess.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.Mappings
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            this.CreateMap<AddAnimalRequest, Animal>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Sex, y => y.MapFrom(z => z.Sex))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.BreedId, y => y.MapFrom(z => z.BreedId));

            this.CreateMap<Animal, API.Domain.Models.Animal>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Sex, y => y.MapFrom(z => z.Sex))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.BreedId, y => y.MapFrom(z => z.BreedId));
        }
    }
}
