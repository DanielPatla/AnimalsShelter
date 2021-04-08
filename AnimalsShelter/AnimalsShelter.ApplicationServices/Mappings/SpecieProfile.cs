using AnimalsShelter.Controllers;
using AnimalsShelter.DataAccess.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.Mappings
{
    public class SpecieProfile : Profile
    {
        public SpecieProfile()
        {
            this.CreateMap<AddSpecieRequest, Specie>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<Specie, API.Domain.Models.Specie>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
