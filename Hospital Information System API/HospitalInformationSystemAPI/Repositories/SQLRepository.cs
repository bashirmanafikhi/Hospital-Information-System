using AutoMapper;
using HospitalInformationSystemAPI.Filters;
using HospitalInformationSystemAPI.Helpers;
using HospitalInformationSystemAPI.Models;
using HospitalInformationSystemAPI.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : ModelBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly DbSet<T> table;

        public SQLRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.table = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetFiltered(IFilter<T> filter)
        {
            //var entities = filter.Filter(table);  // Normal Method 

            var entities = table.Filter(filter);  // Extension Method

            return await entities.ToListAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            table.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(Guid id, T entity)
        {
            var patient = await table.FindAsync(id);

            if (patient != null)
            {
                patient = mapper.Map<T>(entity);

                await context.SaveChangesAsync();
            }

            return patient;
        }

        public async Task<T> Delete(Guid id)
        {
            var patient = await table.FirstOrDefaultAsync(p => p.Id == id);
            if (patient != null)
            {
                table.Remove(patient);
                await context.SaveChangesAsync();
            }
            return patient;
        }

        public async Task<int> Count()
        {
            return await table.CountAsync();
        }
    }
}
