using clinic.Models;
using clinic.Repository.IRepository;
using clinic.ApplicationDbContext;

namespace clinic.Repository
{
    public class PatientRepository : BaseRepository<Patient> , IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {

        }
    }
}
