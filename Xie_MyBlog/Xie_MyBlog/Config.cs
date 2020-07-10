using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xie_MyBlog
{
    public class Config
    {

        public static IEnumerable<ApiScope> GetScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope
                {
                    Name="webapi",
                    Description="Asp.net core web api"

                }
            };
        }
        public static IEnumerable<Client> Get()
        {
            return new List<Client>{
                new Client
                {
                    ClientId="oauthClient",
                    ClientName="Example Client Credentials Client Application",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets=new List<Secret>
                    {
                        new Secret("superSecretPassWord".Sha256()),
                        
                    },
                    AllowedScopes=new List<string>{ "webapi" }
                }
            };
        }
    }
}
