using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesDataBase.Models.Entities
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(16)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        /*------------------------------------*/

        //This property uses in a details view, for selected employee for editing
        [NotMapped]
        public Employee CurrentEmployee { get; set; }

        [NotMapped]
        public IList<Employee>? Employees { get; set; }

        [NotMapped]
        public IList<Order>? Orders { get; set; }

        [NotMapped]
        public IList<Note>? Notes { get; set; }

        



    }
}
