using System;
namespace Domain.Entities
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public bool Status { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
