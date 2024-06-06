using System.Security.Claims;

namespace DotProducts.Services
{
    public static class AuthService
    {
        public static int UserId(this ClaimsPrincipal claims){
            if(claims == null) throw new ArgumentNullException(nameof(claims));
            return Int32.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
