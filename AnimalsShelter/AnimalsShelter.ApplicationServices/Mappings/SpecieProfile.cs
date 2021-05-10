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
    public class SpecieProfile : Profile
    {
        public SpecieProfile()
        {
            this.CreateMap<AddSpecieRequest, Specie>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<Specie, API.Domain.Models.Specie>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Breeds, y => y.MapFrom(z => z.Name != null ? z.Breeds.Select(x => x.Name) : new List<string>()))
                .ForMember(x => x.Animals, y => y.MapFrom(z => z.Name != null ? z.Breeds.Select(x => x.Animals.Select(p => p.Name)) : new List<string>()));

            this.CreateMap<RemoveSpecieRequest, Specie>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<UpdateSpecieRequest, Specie>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
