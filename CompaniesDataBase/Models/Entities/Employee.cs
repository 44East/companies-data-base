using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesDataBase.Models.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        [Required]
        public int TitleId { get; set; }

        [ForeignKey(nameof(TitleId))]
        public EmployeeSalutation Title { get; set; }

        [Required]
        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public EmployeePosition Position { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        /*------------------------------------*/

        [NotMapped]
        public IList<Note>? Notes { get; set; }


    }
}
