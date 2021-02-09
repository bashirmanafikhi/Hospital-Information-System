using HospitalInformationSystemAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PagedResponse(T data, PaginationFilter filter, int totalRecords) : base(data)
        {
            this.PageNumber = filter.PageNumber;
            this.PageSize = filter.PageSize;

            this.TotalRecords = totalRecords;
            this.TotalPages = totalRecords / this.PageSize + (totalRecords % this.PageSize > 0 ? 1 : 0);
        }
    }
}
