namespace MedicalDeviceTracking.Models
{
    public class CentralRequest
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string RequestTitle { get; set; } = null!;
        public DateTime RequestDate { get; set; }
    }
}
