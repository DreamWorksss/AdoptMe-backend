using AdoptMe.Repository.Models;
using AdoptMe.Web.Models.Animals;
using AdoptMe.Web.Models.Donations;
using AdoptMe.Web.Models.Shelters;
using AutoMapper;

namespace AdoptMe.Web.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            this.CreateMap<PetAdditionModel, Pet>().ReverseMap();
            this.CreateMap<ShelterAdditionModel, Shelter>().ReverseMap();
            this.CreateMap<ShelterUpdateModel, Shelter>().ReverseMap();
            this.CreateMap<DonationAdditionModel, Donation>().ReverseMap();
        }
    }
}
