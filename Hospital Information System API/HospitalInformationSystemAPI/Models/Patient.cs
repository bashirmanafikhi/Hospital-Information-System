﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int FileNo { get; set; }
        public string CitizenId { get; set; }
        public DateTime Birthdate { get; set; }
        public byte Gender { get; set; }
        public string Natinality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactPerson { get; set; }
        public string ContactRelation { get; set; }
        public string ContactPhone { get; set; }
        public DateTime FirstVisitDate { get; set; }
        public DateTime RecordCreationDate { get; set; }

        public Patient()
        {
            this.Id = Guid.NewGuid();
            this.RecordCreationDate = DateTime.Now;
        }


        public void UpdateDetails(PatientRequest patientRequest)
        {
            this.Name = patientRequest.Name;
            this.FileNo = patientRequest.FileNo;
            this.CitizenId = patientRequest.CitizenId;
            this.Birthdate = patientRequest.Birthdate;
            this.Gender = patientRequest.Gender;
            this.Natinality = patientRequest.Natinality;
            this.PhoneNumber = patientRequest.PhoneNumber;
            this.Email = patientRequest.Email;
            this.Country = patientRequest.Country;
            this.City = patientRequest.City;
            this.Street = patientRequest.Street;
            this.Address1 = patientRequest.Address1;
            this.Address2 = patientRequest.Address2;
            this.ContactPerson = patientRequest.ContactPerson;
            this.ContactRelation = patientRequest.ContactRelation;
            this.ContactPhone = patientRequest.ContactPhone;
            this.FirstVisitDate = patientRequest.FirstVisitDate;
        }
    }
}
