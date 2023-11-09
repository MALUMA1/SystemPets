using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static bool HasPermission(this ClaimsPrincipal user, string permission)
    {
        var claim = user.FindFirst(ClaimTypes.AuthenticationMethod);
        if (claim != null && claim.Value == permission)
        {
            return true;
        }
        return false;
    }

    public static bool HasPermisionRole(this ClaimsPrincipal user, string role)
    {
        var claim = user.FindFirst(ClaimTypes.Role);
        if (claim != null && claim.Value == role)
        {
            return true;
        }
        return false;
    }
}
