using System.ComponentModel.DataAnnotations;

namespace CompaniesDataBase.Models.DTO
{
    public class CompanyDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(16)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
