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

        public PatientsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Actions


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PatientFilter filter)
        {
            var validFilter = new PatientFilter(filter);


            var filteredData = context.Patients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(validFilter.Name))
                filteredData = filteredData.Where(p => p.Name.ToUpper().Contains(validFilter.Name.ToUpper()));

            if (validFilter.FileNo > 0)
                filteredData = filteredData.Where(p => p.FileNo == validFilter.FileNo);

            if (!string.IsNullOrWhiteSpace(validFilter.PhoneNumber))
                filteredData = filteredData.Where(p => p.PhoneNumber.ToUpper().Contains(validFilter.PhoneNumber.ToUpper()));


            var pagedData = await filteredData
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecords = await filteredData.CountAsync();

            var pagedResponse = new PagedResponse<List<Patient>>(pagedData, validFilter.PageNumber, validFilter.PageSize, totalRecords);
            
            return Ok(pagedResponse);
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

                Patient patient = new Patient();

                patient.UpdateDetails(patientRequest);

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

                patient.UpdateDetails(patientRequest);

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
