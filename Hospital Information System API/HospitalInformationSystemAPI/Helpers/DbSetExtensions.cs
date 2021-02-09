using HospitalInformationSystemAPI.Filters;
using HospitalInformationSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Helpers
{
    public static class DbSetExtensions
    {
        public static IQueryable<TEntity> Filter<TEntity>(this DbSet<TEntity> data, IFilter<TEntity> filter) where TEntity : ModelBase
        {
            return filter.Filter(data.AsQueryable());
        }
    }
}
