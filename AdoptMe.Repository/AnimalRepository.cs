﻿using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;

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

            var petCount = pets.Count();
            return new PaginatedList<Pet>
            {
                Entities = pets.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalNumberOfEntities = petCount,
                TotalNumberOfPages = (int)Math.Ceiling(petCount / (double)pageSize)
            };
        }
    }
}
