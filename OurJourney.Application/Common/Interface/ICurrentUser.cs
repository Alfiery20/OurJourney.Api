using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurJourney.Application.Common.Interface
{
    public interface ICurrentUser
    {
        string Identifier { get; }
        string Name { get; }
        string Nombres { get; }
        string ApellidoPaterno { get; }
        string ApellidoMaterno { get; }
        string Username { get; }
        string Email { get; }
        string Celular { get; }
        string CodigoEmpleado { get; }
        bool IsAuthenticated { get; }
        string TraceIdentifier { get; }
        string AccessToken { get; }
    }
}
