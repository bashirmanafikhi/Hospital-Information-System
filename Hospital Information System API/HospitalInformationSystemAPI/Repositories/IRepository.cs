using HospitalInformationSystemAPI.Filters;
using HospitalInformationSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Repositories
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetFiltered(IFilter<T> filter);
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(Guid id, T entity);
        Task<T> Delete(Guid id);

        Task<int> Count();

    }
}
