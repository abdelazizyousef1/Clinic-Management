namespace clinic.Models
{
    public class Patient
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<Appointment> Appointments;
    }
}
