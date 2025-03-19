using Microsoft.AspNetCore.Mvc;
using System.Data;
using clinic.ApplicationDbContext;
using clinic.DTOs;
using clinic.Models;
using System;
using clinic.Services.Iservices;
namespace clinic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        
        private readonly IAppointmentService _appointmentService;
        public AppointmentsController( IAppointmentService appointmentService)
        {
               _appointmentService = appointmentService;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var service = await _appointmentService.CreateAppointmentAsync(appointmentDto);
                return Ok(service);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Show")]
        [HttpGet]
        public async Task<IActionResult> Show(int? patientId = null, int? doctorId = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var appointment = await _appointmentService.GetAppointmentAsync(patientId, doctorId);
                return Ok(appointment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("Update")]
        [HttpPut]
        
        public async Task<IActionResult> Update(int id, [FromBody] AppointmentDto appointmentDto )
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
              var appointment= await _appointmentService.UpdateAppointmentAsync(id , appointmentDto);
                
                return Ok(appointment);
            }
            catch(Exception E)
            {
                return BadRequest(E.Message);
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
               var proccess = await _appointmentService.DeleteAppointmentAsync(id);
                return Ok("Appointment deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }   


    }
}
