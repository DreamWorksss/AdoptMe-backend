using AdoptMe.Repository.Models;

namespace AdoptMe.Web.Models.Shelters
{
    public class ShelterAdditionModel
    {
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
