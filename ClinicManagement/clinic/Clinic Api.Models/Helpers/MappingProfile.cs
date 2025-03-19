using AutoMapper;
using clinic.Models;
using clinic.DTOs;
namespace clinic.Helpers
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<PatientDto, Patient>().ReverseMap();

            CreateMap<DoctorDto, Doctor>().ReverseMap();

            CreateMap<AppointmentDto, Appointment>().ReverseMap();

            CreateMap<AccountDTO , ApplicationUser>().ReverseMap();

        }
    }
}
