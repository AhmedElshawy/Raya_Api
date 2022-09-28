using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class DepartmentToCreateDTO
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
        [Required, MaxLength(10)]
        public string FloorNumber { get; set; }
    }
}
