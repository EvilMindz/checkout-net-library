using System.Collections.Generic;

namespace Checkout.ApiServices.Shopping.ResponseModels
{
    public class PagedList<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int CurrentPageCount { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasResults { get; set; } 
        public IEnumerable<T> Items { get; set; }
    }
}
