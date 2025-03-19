using clinic.Models;
using Microsoft.AspNetCore.Mvc;
using clinic.DTOs;
namespace clinic.Services.Iservices
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> CreateAppointmentAsync(AppointmentDto appointmentDto);

        Task<List<AppointmentDto>> GetAppointmentAsync(int? PatientId, int? DoctorId);
        

        Task<AppointmentDto> UpdateAppointmentAsync(int id, AppointmentDto appointmentDto);

        Task<bool> DeleteAppointmentAsync(int id);

    }
}
