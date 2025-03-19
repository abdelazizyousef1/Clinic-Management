using clinic.Models;
using clinic.ApplicationDbContext;
using clinic.Repository.IRepository;
namespace clinic.Repository
{
    public class DoctorRepository : BaseRepository<Doctor> , IDoctorRepository 
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {

        }
    }
}
