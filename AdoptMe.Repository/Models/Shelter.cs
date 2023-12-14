namespace AdoptMe.Repository.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Animal> Animals { get; set; }

        public Shelter()
        {
            Animals = new List<Animal>();
        }

        public Shelter(int id, string name, List<Animal> animals)
        {
            Id = id;
            Name = name;
            Animals = animals ?? new List<Animal>();
        }

        public Shelter(string name, List<Animal> animals)
        {
            Name = name;
            Animals = animals ?? new List<Animal>();
        }
    }
}
