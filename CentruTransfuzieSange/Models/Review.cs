namespace CentruTransfuzieSange.Models
{
    public class Review
    {
        public int ID { get; set; } 
        public string Description { get; set; }

        public int? MemberID { get; set; }
        public Member? Member { get; set; }
     
        public int? DoctorID { get; set; }
        public Doctor? Doctor { get; set; }
        public int? AppointmentID { get; set; }
        public Appointment? Appointment { get; set; }

    }
}
