using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalInformationSystemAPI.Models
{
    public class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime RecordCreationDate { get; set; }

        public ModelBase()
        {
            this.Id = Guid.NewGuid();
            this.RecordCreationDate = DateTime.Now;
        }
    }
}
