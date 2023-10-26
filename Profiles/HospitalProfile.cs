using AutoMapper;
using MediPortal_Hospital.Models;
using MediPortal_Hospital.Models.Dtos;

namespace MediPortal_Hospital.Profiles
{
    public class HospitalProfile:Profile
    {
        public HospitalProfile()
        {
            CreateMap<HospitalRequestDto, Hospital>().ReverseMap();
        }
    }
}
