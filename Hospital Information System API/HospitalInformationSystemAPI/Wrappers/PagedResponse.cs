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

        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords) : base(data)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;

            this.TotalRecords = totalRecords;
            this.TotalPages = totalRecords / pageSize + (totalRecords % pageSize > 0 ? 1 : 0);
        }
    }
}
