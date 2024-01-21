namespace AdoptMe.Repository.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<Pet> Animals { get; set; }

        public Shelter()
        {
            Animals = new List<Pet>();
        }

        public Shelter(int id, string name, List<Pet> animals)
        {
            Id = id;
            Name = name;
            Animals = animals ?? new List<Pet>();
        }

        public Shelter(string name, List<Pet> animals)
        {
            Name = name;
            Animals = animals ?? new List<Pet>();
        }
    }
}
