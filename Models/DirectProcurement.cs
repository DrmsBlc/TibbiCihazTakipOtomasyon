using System;

namespace MedicalDeviceTracking.Models
{
    public class DirectProcurement
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Hospital Hospital { get; set; } = null!;
    }
}
