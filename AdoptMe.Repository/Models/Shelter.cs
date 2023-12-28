using System.Buffers.Text;
using System.Drawing;

namespace AdoptMe.Repository.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Shelter(int id, string name, string description, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
        }

        public Shelter(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }
    }
}
