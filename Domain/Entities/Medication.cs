using System;
namespace Domain.Entities
{
    public class Medication
    {
        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDetails { get; set; }
        public bool Status { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
