

namespace UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Common
{
    public class FilterQueryParams
    {
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string[] SortOptions { get; set; }
        public bool SortingDirection { get; set; } //false = asc, true = desc
        public string SearchValue { get; set; }
    }

    
}
