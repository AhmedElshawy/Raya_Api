using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class EmployeeToAddDTO
    {
        [Required]
        public string FisrtName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
