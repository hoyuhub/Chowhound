using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public partial class SCity
    {
        [Key]
        public long CityId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public long? ProvinceId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
