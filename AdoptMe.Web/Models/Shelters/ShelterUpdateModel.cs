using AdoptMe.Repository.Models;

namespace AdoptMe.Web.Models.Shelters
{
    public class ShelterUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Animals { get; set; }
    }
}
