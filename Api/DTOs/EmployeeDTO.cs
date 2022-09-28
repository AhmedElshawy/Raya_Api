using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public double Salary { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
