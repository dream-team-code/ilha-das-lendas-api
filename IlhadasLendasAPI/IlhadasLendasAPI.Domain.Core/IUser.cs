using System.Security.Claims;

namespace IlhadasLendasAPI.Domain.Core
{
    public interface IUser
    {
        string Name { get; }

        bool IsAuthenticated();

        bool IsInRole(string role);

        Guid GetUserId();

        string GetUserEmail();

        string GetUserRole();

        IEnumerable<string> GetUserClaims();

        IEnumerable<Claim> GetClaimsIdentity();
    }
}