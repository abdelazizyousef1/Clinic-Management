using clinic.Models;
using clinic.Repository.IRepository;
using clinic.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
namespace clinic.Repository
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        private readonly AppDbContext _context;
        public AppointmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Appointment> GetAllAppointmentAsync()
        {
           return _context.Appointments.AsQueryable();
        }
    }
}
