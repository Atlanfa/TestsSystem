using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class ResponseThemes : ResponseBase
    {
        public List<DtoTheme> Themes { get; set; }
    }
}
