using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace AdoptMe.Repository
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        private readonly AdoptMeDbContext _context;

        public PetRepository(AdoptMeDbContext context) : base(context)
        {
            _context = context;
        }

        public PaginatedList<Pet> RetrievePets(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false)
        {
            var pets = _context.Pets.AsQueryable();
            pets = sortBy switch
            {
                PetSortingFields.Color => sortDesc ? pets.OrderByDescending(x => x.Color) : pets.OrderBy(x => x.Color),
                PetSortingFields.Birthdate => sortDesc ? pets.OrderByDescending(x => x.Birthdate) : pets.OrderBy(x => x.Birthdate),
                PetSortingFields.Description => sortDesc ? pets.OrderByDescending(x => x.Description) : pets.OrderBy(x => x.Description),
                PetSortingFields.Name or _ => sortDesc ? pets.OrderByDescending(x => x.Name) : pets.OrderBy(x => x.Name)
            };

            var animalCount = pets.Count();
            return new PaginatedList<Pet>
            {
                Entities = pets.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalNumberOfEntities = animalCount,
                TotalNumberOfPages = (int)Math.Ceiling(animalCount / (double)pageSize)
            };
        }
        
        public PaginatedList<Pet> RetrievePetsByShelter(int shelterId, int page = 0, int pageSize = 15)
        {
            var pets = _context.Pets.AsQueryable();
            pets = pets.Where(p => p.ShelterId == shelterId);

            var animalCount = pets.Count();
            return new PaginatedList<Pet>
            {
                Entities = pets.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalNumberOfEntities = animalCount,
                TotalNumberOfPages = (int)Math.Ceiling(animalCount / (double)pageSize)
            };
        }
        
        public List<Pet> GetAllPets()
        {
            return _context.Pets.Include(s => s.AdoptionRequests).ToList();
        }

        public void UpdatePet(Pet pet)
        {
            _context.Update(pet);
            _context.SaveChanges();
        }


        public void DeletePet(int petId)
        {
            var pet = _context.Pets.Find(petId);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();
            }
        }
    }
}
