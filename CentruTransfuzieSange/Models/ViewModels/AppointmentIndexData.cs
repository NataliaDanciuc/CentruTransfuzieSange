namespace CentruTransfuzieSange.Models.ViewModels
{
    public class AppointmentIndexData
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public ICollection<Doctor> Doctor { get; set; }
    }
}
