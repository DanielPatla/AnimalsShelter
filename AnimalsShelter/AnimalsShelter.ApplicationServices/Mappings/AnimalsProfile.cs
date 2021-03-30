using AnimalsShelter.ApplicationServices.API.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.Mappings
{
    public class AnimalsProfile : Profile
    {
        public AnimalsProfile()
        {
            this.CreateMap<AnimalsShelter.DataAccess.Entities.Animal, Animal>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.Sex, y => y.MapFrom(z => z.Sex))
                .ForMember(x => x.BreedId, y => y.MapFrom(z => z.BreedId));
        }
    }
}
