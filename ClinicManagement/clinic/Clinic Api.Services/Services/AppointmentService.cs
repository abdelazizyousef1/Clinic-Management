using clinic.Models;
using clinic.DTOs;
using Microsoft.EntityFrameworkCore;
using clinic.ApplicationDbContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using clinic.Repository;
using clinic.Repository.IRepository;
using clinic.Services.Iservices;
using AutoMapper;
namespace clinic.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public AppointmentService(AppDbContext context , IUnitOfWork unitOfWork , IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<AppointmentDto> CreateAppointmentAsync(AppointmentDto appointmentDto)
        {
            var doctor = await _unitOfWork.doctorRepository.GetByIdAsync(appointmentDto.DoctorId);
            var patient = await _unitOfWork.patientRepository.GetByIdAsync(appointmentDto.DoctorId);

            if (doctor == null || patient == null)
            {
                throw new Exception("Doctor OR  Patient Not Exist");
            }
            var appoint = await _context.Appointments.AnyAsync(a => a.Date == appointmentDto.Date && (a.DoctorId == appointmentDto.DoctorId || a.PatientId == appointmentDto.PatientId));

            if (appoint)
            {
                throw new Exception("Doctor or patient are not available in this time");
            }
            var new_appointment = _mapper.Map<Appointment>(appointmentDto);

            await _unitOfWork.appointmentRepository.AddAsync(new_appointment);

            _unitOfWork.Commit();
            
            return (appointmentDto);


        }

        public async Task< List<AppointmentDto>> GetAppointmentAsync(int? patientId = null, int? doctorId = null)
        {
            var query = _unitOfWork.appointmentRepository.GetAllAppointmentAsync();

            if (patientId.HasValue)
            {
                query = query.Where(q => q.PatientId == patientId);
                
            }

            if (doctorId.HasValue)
            {
                query = query.Where(q => q.DoctorId == doctorId);
            }

            var appointments = await query.Select(q => new AppointmentDto
            {
                Date = q.Date,
                DoctorId = q.DoctorId,
                PatientId = q.PatientId,
                Notes = q.Notes,
                Status = q.Status
            }).ToListAsync();

            return appointments;
        }

        public async Task<AppointmentDto> UpdateAppointmentAsync(int id, AppointmentDto appointmentDto)
        {

            var doctor = await _unitOfWork.doctorRepository.GetByIdAsync(appointmentDto.DoctorId);
            var patient = await _unitOfWork.patientRepository.GetByIdAsync(appointmentDto.PatientId);

            if (doctor == null || patient == null)
            {
                throw new Exception("Doctor OR  Patient Not Exist");
            }
            var appointment_N = await _unitOfWork.appointmentRepository.GetByIdAsync(id);

            if (appointment_N == null )
            {
                throw new Exception("The Appointment Not Found");
            }

            var appoint =await  _context.Appointments.AnyAsync(a => a.Id != id &&  a.Date == appointmentDto.Date && ( a.DoctorId == appointmentDto.DoctorId || a.PatientId == appointmentDto.PatientId));

            if(appoint )
            {
                throw new Exception("Doctor or patient are not available in this time");
            }



            _mapper.Map(appointmentDto, appointment_N);
            
            
             await _unitOfWork.appointmentRepository.UpdateAsync(appointment_N);
            _unitOfWork.Commit();
            return appointmentDto;

        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointment =await _unitOfWork.appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                throw new Exception($"This Appointment with ID {id} Not Found");
            }
            await _unitOfWork.appointmentRepository.DeleteAsync(id);
             _unitOfWork.Commit();
            return true;

        }

    }
}
