using AdoptMe.Common.CommonConstants;

namespace AdoptMe.Web.Models.Common.SearchFields
{
    public class PetSearchFields : BaseSearchFields
    {
        public string SortBy { get; set; } = PetSortingFields.Name;
        public PetFilterFields? Filters { get; set; }
    }

    public class PetFilterFields
    {
        public bool IsAvailable { get; set; }
        public int Age { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}
