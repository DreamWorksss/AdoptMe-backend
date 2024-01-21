using AdoptMe.Repository.Models;

namespace AdoptMe.Web.Models.Shelters
{
    public class ShelterUpdateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Pet> Animals { get; set; }
    }
}
