using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Filters
{
    public class PatientFilter : PaginationFilter
    {
        public string Name { get; set; }
        public int FileNo { get; set; }
        public string PhoneNumber { get; set; }

        public PatientFilter() { }
        public PatientFilter(PatientFilter filter) : base(filter.PageNumber, filter.PageSize)
        {
            this.Name = filter.Name;
            this.FileNo = filter.FileNo;
            this.PhoneNumber = filter.PhoneNumber;
        }
    }
}
