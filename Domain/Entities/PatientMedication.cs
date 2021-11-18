using System;
namespace Domain.Entities
{
    public class PatientMedication
    {
        public int PatientMedicationId { get; set; }
        public int MedicationId { get; set; }
        public int PatientId { get; set; }
        public bool Status { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
