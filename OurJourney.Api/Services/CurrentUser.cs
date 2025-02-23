using iTextSharp.text;
using OurJourney.Application.Common.Interface;
using System.Security.Claims;
using System.Xml.Linq;

namespace OurJourney.Api.Services
{
    public class CurrentUser : ICurrentUser
    {
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            Identifier = httpContextAccessor.HttpContext?.User?.FindFirstValue("identifier");
            Name = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            Nombres = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.GivenName || c.Type == "nombres")?.Value;
            ApellidoPaterno = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.Surname || c.Type == "apellido_paterno")?.Value;
            ApellidoPaterno = httpContextAccessor.HttpContext?.User?.FindFirstValue("apellido_materno");
            Username = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "username")?.Value;
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            Telefono = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.HomePhone || c.Type == "telefono")?.Value;
            Celular = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.MobilePhone || c.Type == "celular")?.Value;
            Rol = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
            CodigoEmpleado = httpContextAccessor.HttpContext?.User?.FindFirstValue("codigo_empleado");
            IsAuthenticated = Identifier != null;
            TraceIdentifier = httpContextAccessor.HttpContext?.TraceIdentifier;
            AccessToken = httpContextAccessor.HttpContext?.User?.FindFirstValue("access_token");
        }

        public string Identifier { get; }
        public string Name { get; }
        public string Nombres { get; }
        public string ApellidoPaterno { get; }
        public string ApellidoMaterno { get; }
        public string Username { get; }
        public string Email { get; }
        public string Telefono { get; }
        public string Celular { get; }
        public string Rol { get; }
        public string CodigoEmpleado { get; }
        public bool IsAuthenticated { get; }
        public string TraceIdentifier { get; }
        public string AccessToken { get; }
    }
}
