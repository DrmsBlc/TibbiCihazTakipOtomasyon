using System;

namespace MedicalDeviceTracking.Models
{
    public class BudgetRequest
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public Hospital Hospital { get; set; } = null!;
    }
}
