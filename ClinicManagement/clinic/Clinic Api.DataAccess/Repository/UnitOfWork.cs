using clinic.Repository.IRepository;
using clinic.ApplicationDbContext;
namespace clinic.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IPatientRepository patientRepository { get; private set; }
        public IDoctorRepository doctorRepository { get; private set; }

        public IAppointmentRepository appointmentRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
             _context = context;
            this.appointmentRepository = new AppointmentRepository(_context);
            this.patientRepository = new PatientRepository(_context);
            this.doctorRepository =new DoctorRepository(_context);
        }
        public void Commit()
        {
            _context.SaveChangesAsync();
        }
    }
}
