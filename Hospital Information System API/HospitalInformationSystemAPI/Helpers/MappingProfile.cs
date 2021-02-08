using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalInformationSystemAPI.Models;

namespace HospitalInformationSystemAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientRequest, Patient>(); // means you want to map from PatientRequest to Patient
        }
    }
}
