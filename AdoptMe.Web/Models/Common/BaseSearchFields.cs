using AdoptMe.Common.CommonConstants;

namespace AdoptMe.Web.Models.Common
{
    public class BaseSearchFields
    {
        public int Page { get; set; } = DefaultConstants.DefaultPage;
        public int PageSize { get; set; } = DefaultConstants.DefaultPageSize;
        public bool SortDesc { get; set; } = false;
    }
}
