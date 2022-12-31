using System.ComponentModel.DataAnnotations;

namespace CentruTransfuzieSange.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? MedicalServiceID { get; set; }
        public MedicalService? MedicalService { get; set; }
        public int? DoctorID { get; set; }
        public Doctor? Doctor { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
