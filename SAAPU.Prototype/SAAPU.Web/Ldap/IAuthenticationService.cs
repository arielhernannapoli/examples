namespace SAAPU.Web.Ldap
{
    public interface IAuthenticationService
    {
        AppUser Login(string username, string password);
    }
}