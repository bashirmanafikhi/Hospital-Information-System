using AutoMapper;
using HospitalInformationSystemAPI.Filters;
using HospitalInformationSystemAPI.Models;
using HospitalInformationSystemAPI.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        #region Fields And Constructors
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PatientsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Actions


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PatientFilter filter)
        {
            try
            {
                var validFilter = new PatientFilter(filter);

                var filteredData = validFilter.Filter(context.Patients.AsQueryable());

                var totalRecords = await filteredData.CountAsync();

                var pagedData = await validFilter.Paginate(filteredData).ToListAsync();

                var pagedResponse = new PagedResponse<List<Patient>>(pagedData, validFilter.PageNumber, validFilter.PageSize, totalRecords);

                return Ok(pagedResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While Retriving Patient.");
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                Patient patient = await context.Patients.Where(a => a.Id == id).FirstOrDefaultAsync();

                var response = new Response<Patient>(patient);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While Retriving Patient.");
            }
        }





        [HttpPost]
        public async Task<IActionResult> Post(PatientRequest patientRequest)
        {
            try
            {
                // add validate
                if (patientRequest == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var patient = mapper.Map<Patient>(patientRequest);

                var patientId = await context.Patients.AddAsync(patient);

                await context.SaveChangesAsync();

                var response = new Response<Guid>(patientId.Entity.Id);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While Adding Patient.");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PatientRequest patientRequest)
        {
            try
            {
                // add validate
                if (patientRequest == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == id);

                if (patient == null)
                {
                    return NotFound($"Patient with Id = '{id}' is not found.");
                }

                patient = mapper.Map<Patient>(patientRequest);

                await context.SaveChangesAsync();

                var response = new Response<Patient>(patient);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While Editing Patient.");
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == id);

                if (patient == null)
                {
                    return NotFound($"Patient with Id = '{id}' is not found.");
                }

                context.Patients.Remove(patient);

                await context.SaveChangesAsync();

                var response = new Response<Guid>(patient.Id);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While Deleting Patient.");
            }
        }



        #endregion
    }
}
