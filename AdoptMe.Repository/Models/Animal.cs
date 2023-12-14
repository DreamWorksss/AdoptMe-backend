using System.Text.Json.Serialization;

namespace AdoptMe.Repository.Models
{
    public class Animal
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

        public Animal()
        {
        }

        public Animal(int id, string name, string gender, DateTime birthdate, string color, string description, int shelterId)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Color = color;
            Description = description;
            ShelterId = shelterId;
        }

        public Animal(string name, string gender, DateTime birthdate, string color, string description, int shelterId)
        {
            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Color = color;
            Description = description;
            ShelterId = shelterId;
        }
    }
}
