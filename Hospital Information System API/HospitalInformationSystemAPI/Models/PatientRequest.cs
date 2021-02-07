using System;
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


        [Range(1, int.MaxValue)]
        [Display(Name = "File No")]
        public int FileNo { get; set; }

        
        [StringLength(maximumLength: 50, ErrorMessage = "Citizen Id Should be maximum of 50 characters")]
        public string CitizenId { get; set; }


        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }



        [Range(0,1, ErrorMessage = "Gender should be 0 for male or 1 for female.")]
        public byte Gender { get; set; }


        [DataType(DataType.Text)]
        public string Natinality { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


        [DataType(DataType.Text)]
        public string Country { get; set; }


        [DataType(DataType.Text)]
        public string City { get; set; }


        [DataType(DataType.Text)]
        public string Street { get; set; }


        [DataType(DataType.MultilineText)]
        public string Address1 { get; set; }


        [DataType(DataType.MultilineText)]
        public string Address2 { get; set; }


        [Display(Name = "Contact Person")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Contact Person Should be minimum 3 characters and a maximum of 100 characters")]
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
