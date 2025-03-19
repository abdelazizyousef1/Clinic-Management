using clinic.DTOs;
using clinic.Models;
using clinic.Repository.IRepository;
using clinic.Services.Iservices;
using clinic.Helpers;
using AutoMapper;
using System.Numerics;
namespace clinic.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateDoctortAsync(DoctorDto doctorDto)
        {
            var newDoctor = _mapper.Map<Doctor>(doctorDto);
            if (newDoctor == null)
            {
                throw new Exception("Doctor not found");
            }
            await _unitOfWork.doctorRepository.AddAsync(newDoctor);
            //_unitOfWork.Commit();
        }
        public async Task<List<DoctorDto>> GetAllDoctorAsync()
        {
           return _mapper.Map<List< DoctorDto >> (await _unitOfWork.doctorRepository.GetAllAsync());
        }
        public async Task UpdateDoctorAsync(int Id, DoctorDto doctorDto)
        {
            var doctor = await _unitOfWork.doctorRepository.GetByIdAsync(Id);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            _mapper.Map(doctorDto, doctor);
            
            await _unitOfWork.doctorRepository.UpdateAsync(doctor);
            _unitOfWork.Commit();
        }
        public async Task DeleteDoctorAsync(int Id)
        {
            var doctor = await _unitOfWork.doctorRepository.GetByIdAsync(Id);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            await _unitOfWork.doctorRepository.DeleteAsync(Id);
            
        }
    }
}
