using System;
using System.Collections.Generic;

namespace Models
{
    public partial class SProvince
    {
        public long ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
