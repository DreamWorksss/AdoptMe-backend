using AdoptMe.Repository.Enums;

namespace AdoptMe.Web.Models.Pets
{
    public class PetAdditionModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Race { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public AdoptionStatus Status { get; set; }
        public int ShelterId { get; set; }
    }
}
