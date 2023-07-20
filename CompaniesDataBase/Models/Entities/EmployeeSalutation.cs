using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesDataBase.Models.Entities
{
    [Table("Employees.Titles")]
    public class EmployeeSalutation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string Salutation { get; set; }

        /*------------------------------------*/

        [NotMapped]
        public IList<Employee>? Employees { get; set; }
    }
}
