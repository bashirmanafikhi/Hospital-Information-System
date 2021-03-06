﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Models
{
    public class PatientRequest
    {
        [Required(ErrorMessage = "Patient Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name Should be minimum 3 characters and a maximum of 100 characters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "File Number is required")]
        [Range(1, int.MaxValue)]
        [Display(Name = "File No")]
        public int FileNo { get; set; }

        
        [StringLength(maximumLength: 50, ErrorMessage = "Citizen Id Should be maximum of 50 characters")]
        public string CitizenId { get; set; }


        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }



        [Range(0,1, ErrorMessage = "Gender should be either 0 for male or 1 for female.")]
        public Gender Gender { get; set; }


        [DataType(DataType.Text)]
        public string Natinality { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Country Should be minimum 1 characters and a maximum of 50 characters")]
        public string Country { get; set; }


        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City Should be minimum 1 characters and a maximum of 50 characters")]
        public string City { get; set; }


        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Street Should be minimum 1 characters and a maximum of 50 characters")]
        public string Street { get; set; }


        [DataType(DataType.MultilineText)]
        public string Address1 { get; set; }


        [DataType(DataType.MultilineText)]
        public string Address2 { get; set; }


        [Display(Name = "Contact Person")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Contact Person Should be maximum of 100 characters")]
        public string ContactPerson { get; set; }


        [Display(Name = "Contact Relation")]
        [DataType(DataType.Text)]
        public string ContactRelation { get; set; }


        [Display(Name = "Contact Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string ContactPhone { get; set; }


        [Display(Name = "First Visit Date")]
        [DataType(DataType.Date)]
        public DateTime FirstVisitDate { get; set; }
    }
}
