using clinic.DTOs;
using clinic.Models;

namespace clinic.Services.Iservices
{
    public interface IDoctorService
    {
        Task CreateDoctortAsync(DoctorDto doctorDto);
        Task<List<DoctorDto>> GetAllDoctorAsync();

        Task UpdateDoctorAsync(int Id, DoctorDto doctorDto);
        Task DeleteDoctorAsync(int Id);
    }
}
