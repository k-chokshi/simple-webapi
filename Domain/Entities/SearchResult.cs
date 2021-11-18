using System;
namespace Domain.Entities
{
    public class SearchResult
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ProvinceCode { get; set; }
        public string MedicationName { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
