

using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Department:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string FloorNumber { get; set; }

        // Navigation properties
        public List<Employee> Employees { get; set; }
    }
}
