using MediPortal_Hospital.Models;

namespace MediPortal_Hospital.Services.IServices
{
    public interface IHospitalInterface
    {
        Task<string> AddHospital(Hospital hospital);
        Task<string> DeleteHospital(Hospital hospital);

        Task<Hospital> GetHospitalById(Guid HospitalId);
        Task<IEnumerable<Hospital>> GetHospitals();

        Task<string> UpdateHospital(Hospital hospital);
    }
}
