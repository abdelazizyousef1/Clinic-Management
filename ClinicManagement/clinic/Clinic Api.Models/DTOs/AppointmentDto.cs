namespace clinic.DTOs
{
    public class AppointmentDto
    {
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
