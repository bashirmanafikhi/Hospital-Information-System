using AutoMapper;
using HospitalInformationSystemAPI.Filters;
using HospitalInformationSystemAPI.Helpers;
using HospitalInformationSystemAPI.Models;
using HospitalInformationSystemAPI.Repositories;
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
        private readonly IRepository<Patient> repository;
        private readonly IMapper mapper;

        public PatientsController(IRepository<Patient> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetFiltered([FromQuery] PatientFilter filter)
        {
            try
            {
                var patients = await repository.GetFiltered(filter);

                var totalRecords = await repository.Count();

                var pagedResponse = new PagedResponse<IEnumerable<Patient>>(patients, filter, totalRecords);

                return Ok(pagedResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While Retriving Patients.");
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var patient = await repository.Get(id);

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
                if (!ModelState.IsValid || patientRequest == null)
                    return BadRequest();

                var patient = mapper.Map<Patient>(patientRequest);

                patient = await repository.Add(patient);

                var response = new Response<Guid>(patient.Id);

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
                if (!ModelState.IsValid || patientRequest == null)
                    return BadRequest();

                var patient = mapper.Map<Patient>(patientRequest);

                patient = await repository.Update(id, patient);

                var response = new Response<Guid>(patient.Id);

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
                var patient = await repository.Delete(id);

                var response = new Response<Guid>(patient.Id);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While Deleting Patient.");
            }
        }


    }
}
