﻿namespace clinic.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
        public ICollection<Appointment> Appointments;
    }
}
