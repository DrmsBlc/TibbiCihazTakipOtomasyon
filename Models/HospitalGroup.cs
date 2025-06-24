using System.Collections.Generic;

namespace MedicalDeviceTracking.Models
{
    public class HospitalGroup
    {
        public string GroupCode { get; set; } = null!;
        public List<Hospital> Hospitals { get; set; }= null!;
    }
}
