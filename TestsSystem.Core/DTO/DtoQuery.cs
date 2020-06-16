using Microsoft.AspNetCore.Mvc;

using TestsSystem.Core.Enums;

namespace TestsSystem.Core.DTO
{
    public class DtoQuery
    {
        [FromQuery(Name = "id")]
        public int Id { get; set; }

        [FromQuery(Name = "email")]
        public string Email { get; set; }

        [FromQuery(Name = "role")]
        public EUserRole Role { get; set; }
    }
}
