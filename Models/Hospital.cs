namespace MedicalDeviceTracking.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string GroupCode { get; set; }= null!;
        public int? ParentHospitalId { get; set; }
    }
}
