using System;
using System.Linq;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;

namespace SAAPU.Web.Ldap
{
    public class LdapAuthenticationService : IAuthenticationService
    {
        private const string MemberOfAttribute = "memberOf";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        private readonly LdapConfig _config;
        private readonly LdapConnection _connection;

        public LdapAuthenticationService(IOptions<LdapConfig> config)
        {
            _config = config.Value;
            _connection = new LdapConnection
            {
                SecureSocketLayer = false
            };
        }

        public AppUser Login(string username, string password)
        {
            _connection.Connect(_config.Url, LdapConnection.DEFAULT_PORT);
            _connection.Bind(LdapConnection.Ldap_V3, String.Format(@"USERSAD\{0}", username), password);

            var searchFilter = _config.SearchFilter;
            
            var result = _connection.Search(
                _config.SearchBase,
                LdapConnection.SCOPE_SUB,
                searchFilter,
                new[] { MemberOfAttribute, DisplayNameAttribute, SAMAccountNameAttribute },
                false
            );

            try
            {
                var user = result.next();
                if (user != null)
                {
                    _connection.Bind(user.DN, password);
                    if (_connection.Bound)
                    {
                        return new AppUser
                        {
                            DisplayName = user.getAttribute(DisplayNameAttribute).StringValue,
                            Username = user.getAttribute(SAMAccountNameAttribute).StringValue,
                            IsAdmin = user.getAttribute(MemberOfAttribute).StringValueArray.Contains(_config.AdminCn)
                        };
                    }
                }
            }
            catch
            {
                throw new Exception("Login failed.");
            }
            _connection.Disconnect();
            return null;
        }
    }
}