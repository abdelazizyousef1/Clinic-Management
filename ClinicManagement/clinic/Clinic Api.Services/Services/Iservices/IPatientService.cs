using clinic.Models;
using System;
using clinic.Repository.IRepository;
using clinic.ApplicationDbContext;
using clinic.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace clinic.Services.Iservices
{
    public interface IPatientService
    {
        Task CreatePatientAsync([FromBody] PatientDto patientDto);
        Task<List<PatientDto>> GetAllPatientAsync();

        Task UpdatePatientAsync(int Id , [FromBody] PatientDto patientDto);
        Task DeletePatientAsync(int Id);
    }
}
