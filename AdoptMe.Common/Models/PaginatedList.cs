namespace AdoptMe.Common.Models
{
    public class PaginatedList<T>
    {
        public PaginatedList() { } // Empty constructor is needed if we want to do bracket initialization

        public PaginatedList(List<T> entities, int totalNumberOfPages, int totalNumberOfEntities)
        {
            Entities = entities;
            TotalNumberOfPages = totalNumberOfPages;
            TotalNumberOfEntities = totalNumberOfEntities;
        }

        public List<T> Entities { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfEntities { get; set; }
    }
}
