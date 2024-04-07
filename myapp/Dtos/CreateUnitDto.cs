using System.ComponentModel.DataAnnotations;

namespace myapp.Dtos{
    public record CreateUnitDto{
      
        public string? Name {get; init;}
        [Required]
        [Range(1, 1000)]
        public Int32 Points {get; init;}
    }
}