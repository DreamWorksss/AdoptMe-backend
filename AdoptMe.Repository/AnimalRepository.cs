using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        private readonly AdoptMeDbContext _context;

        public AnimalRepository(AdoptMeDbContext context) : base(context)
        {
            _context = context;
        }

        public PaginatedList<Animal> RetrieveAnimals(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false)
        {
            var animals = _context.Animals.AsQueryable();
            animals = sortBy switch
            {
                AnimalSortingFields.Color => sortDesc ? animals.OrderByDescending(x => x.Color) : animals.OrderBy(x => x.Color),
                AnimalSortingFields.Birthdate => sortDesc ? animals.OrderByDescending(x => x.Birthdate) : animals.OrderBy(x => x.Birthdate),
                AnimalSortingFields.Description => sortDesc ? animals.OrderByDescending(x => x.Description) : animals.OrderBy(x => x.Description),
                AnimalSortingFields.Name or _ => sortDesc ? animals.OrderByDescending(x => x.Name) : animals.OrderBy(x => x.Name)
            };

            var animalCount = animals.Count();
            return new PaginatedList<Animal>
            {
                Entities = animals.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalNumberOfEntities = animalCount,
                TotalNumberOfPages = (int)Math.Ceiling(animalCount / (double)pageSize)
            };
        }
    }
}
