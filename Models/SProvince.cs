using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public partial class SProvince
    {
        [Key]
        public long ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
