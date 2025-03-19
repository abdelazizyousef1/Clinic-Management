using clinic.Models;
using Microsoft.EntityFrameworkCore;
namespace clinic.Repository.IRepository
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        IQueryable<Appointment> GetAllAppointmentAsync();
        

    }
}
