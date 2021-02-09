using HospitalInformationSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Filters
{
    public interface IFilter<T> where T : ModelBase
    {
        IQueryable<T> Filter(IQueryable<T> data);
    }
}
