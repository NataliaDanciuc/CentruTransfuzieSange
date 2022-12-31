using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CentruTransfuzieSange.Models
{
    public class MedicalService
    {
        public int ID { get; set; }
        [Display(Name = "Medical Service")]
        public string ServiceName { get; set; }
        public int? DoctorID { get; set; }
        public Doctor? Doctor { get; set; }

        
    }
}
