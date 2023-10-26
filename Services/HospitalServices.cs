using MediPortal_Hospital.Data;
using MediPortal_Hospital.Models;
using MediPortal_Hospital.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Hospital.Services
{

    public class HospitalServices : IHospitalInterface
    {
        private readonly ApplicationDbContext _context;


        public HospitalServices(ApplicationDbContext context)
        {
            _context = context;


        }
        public async Task<string> AddHospital(Hospital hospital)
        {

            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            return "Hospital Added successfully";
        }

        public async Task<string> DeleteHospital(Hospital hospital)
        {
            _context.Remove(hospital);
            await _context.SaveChangesAsync();
            return "product deleted successfully";
        }

        public async Task<Hospital> GetHospitalById(Guid HospitalId)
        {
            return await _context.Hospitals.FirstOrDefaultAsync(h => h.HospitalId == HospitalId);
        }

        public async Task<IEnumerable<Hospital>> GetHospitals()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task<string> UpdateHospital(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
            await _context.SaveChangesAsync();
            return "Product update successfully";
        }
    }
}
