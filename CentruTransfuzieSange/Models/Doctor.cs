using System.ComponentModel.DataAnnotations;

namespace CentruTransfuzieSange.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public string? Phone { get; set; }
        public ICollection<MedicalService>? MedicalServices { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
