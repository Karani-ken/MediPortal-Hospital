namespace MediPortal_Hospital.Models
{
    public class Hospital
    {
        public Guid HospitalId { get; set; }

        public string Hospitalname { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        
    }
}
