using System.Text.Json.Serialization;

namespace AdoptMe.Repository.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate {  get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int ShelterId {  get; set; }
        [JsonIgnore]
        public virtual Shelter Shelter { get; set; }
        public virtual List<AdoptionRequest> AdoptionRequests { get; set; }

        public Pet()
        {
            AdoptionRequests = new List<AdoptionRequest>();
        }

        public Pet(int id, string name, string gender, DateTime birthdate, string color, string description, int shelterId)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Color = color;
            Description = description;
            ShelterId = shelterId;
            AdoptionRequests = new List<AdoptionRequest>();
        }

        public Pet(string name, string gender, DateTime birthdate, string color, string description, int shelterId)
        {
            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Color = color;
            Description = description;
            ShelterId = shelterId;
            AdoptionRequests = new List<AdoptionRequest>();
        }
    }
}
