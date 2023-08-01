using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesDataBase.Models.Entities
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string InvoiceNumber { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        /*---------------------------------------*/

        [NotMapped]
        public IList<Employee> EmpoyeesInCompany { get; set; }
    }
}
