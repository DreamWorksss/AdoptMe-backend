using AdoptMe.Repository.Enums;
using System.Text.Json.Serialization;

namespace AdoptMe.Repository.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate {  get; set; }
        public string Race { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public AdoptionStatus Status { get; set; } = AdoptionStatus.Unadopted;
        public int ShelterId {  get; set; }
        [JsonIgnore]
        public virtual Shelter Shelter { get; set; }

        public Pet()
        {
        }

        public Pet(int id, string name, string gender, DateTime birthdate, string race, string color, string description, int shelterId)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Race = race;
            Color = color;
            Description = description;
            ShelterId = shelterId;
        }

        public Pet(string name, string gender, DateTime birthdate, string race, string color, string description, int shelterId)
        {
            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Race = race;
            Color = color;
            Description = description;
            ShelterId = shelterId;
        }
    }
}
