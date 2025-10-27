using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public record UpdateHospitalDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
