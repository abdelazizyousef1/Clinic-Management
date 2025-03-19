using clinic.ApplicationDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clinic.Models;
using clinic.DTOs;
using System;
using clinic.Services.Iservices;
using Microsoft.EntityFrameworkCore;
namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        

        public PatientsController( IPatientService patientService)
        {
            
            _patientService = patientService;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _patientService.CreatePatientAsync(patientDto);
                return Ok();


                
            }
            catch (Exception E)
            {
                throw new Exception("there is error in Adding Patient becase " + E.Message);
            }
            
        }

        [Route("Show")]
        [HttpGet]
        public async Task<IEnumerable<PatientDto>> Show()
        {
            try
            {
                var patients = await _patientService.GetAllPatientAsync();
                return patients;
            }
            catch(Exception E)
            {
                throw new Exception("there is error in Getting Patients becase " + E.Message);
            }
            
        }

        [Route("Edit")]
        [HttpPut]
        public async Task<IActionResult> Edit(int Id ,[FromBody]PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
                {
                    await _patientService.UpdatePatientAsync(Id, patientDto);


                    return Ok();
                }
            catch (Exception E)
                {
                    throw new Exception("there is error in Updateing Patient becase " + E.Message);
                }
            
            
                
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _patientService.DeletePatientAsync(id);
                return Ok();

            }
            catch (Exception E)
            {
                throw new Exception("there is error in Deleteing Patient becase " + E.Message);
            }
            
            
        }


    }
}
