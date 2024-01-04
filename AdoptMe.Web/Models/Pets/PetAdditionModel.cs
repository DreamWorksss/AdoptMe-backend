namespace AdoptMe.Web.Models.Animals
{
    public class PetAdditionModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int ShelterId { get; set; }
    }
}
