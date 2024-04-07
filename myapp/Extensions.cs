using myapp.Dtos;
using myapp.Models;

namespace myapp{
    public static class Extensions{
        public static UnitDto AsDto(this Unit unit){
            return new UnitDto{
                Id = unit.Id,
                Name = unit.Name,
                Points = unit.Points,
                CreatedDate = unit.CreatedDate
            };
        }
    }
}