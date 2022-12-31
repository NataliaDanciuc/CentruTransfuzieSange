namespace CentruTransfuzieSange.Models
{
    public class Specialization
    {
        public int ID { get; set; } 
        public string Name { get; set; }  
         public ICollection<MedicalService>? MedicalServices { get; set; }
    }
}
