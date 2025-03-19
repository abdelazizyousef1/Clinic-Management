using clinic.DTOs;
using clinic.Models;
using clinic.Services.Iservices;
using clinic.Repository.IRepository;
using clinic.ApplicationDbContext;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace clinic.Services
{
    public class PatientService : IPatientService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        

        public PatientService(AppDbContext context,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task CreatePatientAsync(PatientDto patientDto)
        {
            
            var found = _context.Patients.Any(p => p.Phone == patientDto.Phone);
            if(found)
            {
                throw new Exception("Patient with this phone number already exists");
            }
            var newPatient = _mapper.Map<Patient>(patientDto);
           await _unitOfWork.patientRepository.AddAsync(newPatient);
             _unitOfWork.Commit();
        }

        public async Task<List<PatientDto>> GetAllPatientAsync()
        {
          var allPatients= await _unitOfWork.patientRepository.GetAllAsync();
            var finalPatients = _mapper.Map<List<PatientDto>>(allPatients);
            return finalPatients;
        }

        public async Task UpdatePatientAsync(int Id, PatientDto patientDto)
        {
            var patient_found =await _unitOfWork.patientRepository.GetByIdAsync(Id);
            if(patient_found == null)
            {
                throw new Exception($"the patient of ID {Id} not found");
            }
            _mapper.Map(patientDto, patient_found);
            
            await _unitOfWork.patientRepository.UpdateAsync(patient_found);
            
        }
        public async Task DeletePatientAsync(int Id)
        {
            var patient_found = await _unitOfWork.patientRepository.GetByIdAsync(Id);
            if (patient_found == null)
            {
                throw new Exception($"the patient of ID {Id} not found");
            }
            await _unitOfWork.patientRepository.DeleteAsync(Id);
        }
    }
}
