using System;
namespace Domain.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ProvinceCode { get; set; }
        public bool Status { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
