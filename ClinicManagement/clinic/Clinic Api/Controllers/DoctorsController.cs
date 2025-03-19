using clinic.ApplicationDbContext;
using Microsoft.AspNetCore.Mvc;
using clinic.Models;
using Microsoft.EntityFrameworkCore;
using clinic.DTOs;
using System.Data;
using clinic.Services.Iservices;
using clinic.Services;
using Microsoft.AspNetCore.Authorization;
namespace clinic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController( IDoctorService doctorService)
        {
           
            _doctorService = doctorService;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _doctorService.CreateDoctortAsync(doctorDto);


                return Ok();
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            
        }

        [Route("Show")]
        [HttpGet]
        
        public async Task<List<DoctorDto>> Show()
        {
            
            try
            {
                return await _doctorService.GetAllDoctorAsync();

                
            }
            catch (Exception E)
            {
                throw new Exception("there is error in Getting Doctors becase " + E.Message);
            }
        }

        [Route("Edit")]
        [HttpPut]
        public async Task<IActionResult> Edit(int Id , DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _doctorService.UpdateDoctorAsync(Id,doctorDto);


                return Ok();
            }
            catch (Exception E)
            {
                throw new Exception("there is error in Updateing Doctor becase " + E.Message);
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
                await _doctorService.DeleteDoctorAsync(id);


                return Ok();
            }
            catch (Exception E)
            {
                throw new Exception("there is error in Deleting Doctor becase " + E.Message);
            }
        }


    }
}
