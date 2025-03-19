using clinic.Repository.IRepository;

namespace clinic.Repository.IRepository
{
    public interface IUnitOfWork
    {
        
        IPatientRepository patientRepository { get; }
        IDoctorRepository doctorRepository { get; }

        IAppointmentRepository appointmentRepository { get; }
        void Commit();



    }
}
