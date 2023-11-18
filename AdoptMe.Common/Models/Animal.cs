namespace AdoptMe.Common.Models
{
    public class Animal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string ShelterId {  get; set; }

        public Animal(string id, string name, string gender, DateTime dateOfBirth, string color, string description, string shelterId)
        {
            Id = id;
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Color = color;
            Description = description;
            ShelterId = shelterId;
        }

        public Animal(string name, string gender, DateTime dateOfBirth, string color, string description, string shelterId)
        {
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Color = color;
            Description = description;
            ShelterId = shelterId;
        }
    }
}
