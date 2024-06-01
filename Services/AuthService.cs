using System.Security.Claims;

namespace DotProducts.Services
{
    public static class AuthService
    {
        public static string UserId(this ClaimsPrincipal claims){
            if(claims == null) throw new ArgumentNullException(nameof(claims));
            return claims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
