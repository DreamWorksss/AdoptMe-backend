using AdoptMe.Common.CommonConstants;
using AdoptMe.Web.Models.Common;

namespace AdoptMe.Web.Models.Pets
{
    public class PetSearchFields : BaseSearchFields
    {
        public string SortBy { get; set; } = PetSortingFields.Name;
        public PetFilterFields? Filters { get; set; }
    }

    public class PetFilterFields : BaseSearchFields
    {
        public bool IsAvailable { get; set; }
        public int Age { get; set; }
        public string Color { get; set; } = string.Empty;
        public int ShelterId {  get; set; }
    }
}
