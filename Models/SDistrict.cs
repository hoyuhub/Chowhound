using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public partial class SDistrict
    {
        [Key]
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }
        public long? CityId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
