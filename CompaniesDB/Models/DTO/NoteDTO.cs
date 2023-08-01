using System.ComponentModel.DataAnnotations;

namespace CompaniesDataBase.Models.DTO
{
    public class NoteDTO
    {
        [Required]
        [StringLength(10)]
        public string InvoiceNumber { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}
