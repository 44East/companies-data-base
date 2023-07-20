using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesDataBase.Models.Entities
{
    [Table("Employees.Positions")]
    public class EmployeePosition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        /*------------------------------------*/

        [NotMapped]
        public IList<Employee>? Employees { get; set; }
    }
}
