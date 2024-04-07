namespace myapp.Dtos{
     public record UnitDto{
        public Guid Id {get; init;}
        public string? Name {get; init;}
        public Int32 Points {get; init;}
        public DateTimeOffset CreatedDate {get; init;}
    }
}