using AdoptMe.Repository.Models;
using AdoptMe.Web.Models.AdoptionRequests;
using AdoptMe.Web.Models.Animals;
using AdoptMe.Web.Models.Donations;
using AdoptMe.Web.Models.AdoptionsAtDistance;
using AdoptMe.Web.Models.Shelters;
using AutoMapper;
using AdoptMe.Web.Models.Users;

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
            this.CreateMap<AdoptionRequestAdditionModel, AdoptionRequest>().ReverseMap();
            this.CreateMap<AdoptionAtDistanceAdditionModel, AdoptionAtDistance>().ReverseMap();
            this.CreateMap<UserRegisterModel, User>().ReverseMap();
        }
    }
}
