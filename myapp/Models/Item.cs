using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;
namespace myapp.Models
{
    public record Unit{
        public Guid Id {get; init;}
        public string? Name {get; init;}
        public Int32 Points {get; init;}
        public DateTimeOffset CreatedDate {get; init;}
    }
}