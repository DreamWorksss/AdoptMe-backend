namespace AdoptMe.Repository.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Pet> Pets { get; set; }

        public Shelter()
        {
            Pets = new List<Pet>();
        }

        public Shelter(int id, string name, List<Pet> pets)
        {
            Id = id;
            Name = name;
            Pets = pets ?? new List<Pet>();
        }

        public Shelter(string name, List<Pet> pets)
        {
            Name = name;
            Pets = pets ?? new List<Pet>();
        }
    }
}
