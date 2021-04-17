using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.ApplicationServices.API.Domain.Delete;
using AnimalsShelter.ApplicationServices.API.Domain.Put;
using AnimalsShelter.DataAccess.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.Mappings
{
    public class BreedProfile : Profile
    {
        public BreedProfile()
        {
            this.CreateMap<AddBreedRequest, Breed>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.SpecieId, y => y.MapFrom(z => z.SpecieId));

            this.CreateMap<Breed, API.Domain.Models.Breed>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.SpecieId, y => y.MapFrom(z => z.SpecieId));

            this.CreateMap<RemoveBreedRequest, Breed>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<UpdateBreedRequest, Breed>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.SpecieId, y => y.MapFrom(z => z.SpecieId));
        }
    }
}
