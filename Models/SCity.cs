using System;
using System.Collections.Generic;

namespace Models
{
    public partial class SCity
    {
        public long CityId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public long? ProvinceId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
