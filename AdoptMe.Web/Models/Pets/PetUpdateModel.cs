using AdoptMe.Repository.Models;

namespace AdoptMe.Web.Models.Pets
{
    public class PetUpdateModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ShelterId { get; set; }
        public List<AdoptionRequest> AdoptionRequests { get; set; }
    }
}
