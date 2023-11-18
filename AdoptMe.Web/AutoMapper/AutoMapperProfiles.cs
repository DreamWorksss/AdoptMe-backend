using AdoptMe.Repository.Models;
using AdoptMe.Web.Models.Animals;
using AutoMapper;

namespace AdoptMe.Web.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            this.CreateMap<AnimalAdditionModel, Animal>().ReverseMap();
        }
    }
}
