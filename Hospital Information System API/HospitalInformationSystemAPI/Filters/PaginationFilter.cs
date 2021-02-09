using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Filters
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            validate();
        }

        public IQueryable<T> Paginate<T>(IQueryable<T> data)
        {
            return data.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        }

        protected void validate()
        {
            PageNumber = PageNumber < 1 ? 1 : PageNumber;
            PageSize = PageSize > 10 ? 10 : PageSize;
        }
    }
}
