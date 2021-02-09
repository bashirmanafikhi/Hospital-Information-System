using HospitalInformationSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HospitalInformationSystemAPI.Filters
{
    public class PatientFilter : PaginationFilter, IFilter<Patient>
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


        public IQueryable<Patient> Filter(IQueryable<Patient> data)
        {
            validate();

            if (!string.IsNullOrWhiteSpace(Name))
                data = data.Where(p => p.Name.ToUpper().Contains(Name.ToUpper()));

            if (FileNo > 0)
                data = data.Where(p => p.FileNo == FileNo);

            if (!string.IsNullOrWhiteSpace(PhoneNumber))
                data = data.Where(p => p.PhoneNumber.ToUpper().Contains(PhoneNumber.ToUpper()));

            return Paginate(data);
        }

        public IQueryable<Patient> Filter(DbSet<Patient> data)
        {
            return Filter(data.AsQueryable<Patient>());
        }
    }
}
