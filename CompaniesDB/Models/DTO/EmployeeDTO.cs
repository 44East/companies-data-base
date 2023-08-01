using System.ComponentModel.DataAnnotations;

namespace CompaniesDataBase.Models.DTO
{
    public class EmployeeDTO
    {

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(5)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

    }
}
