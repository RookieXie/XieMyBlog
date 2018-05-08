using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xie_MyBlog
{
    public class Config
    {

        public static IEnumerable<Scope> GetScopes()
        {
            return new List<Scope>
            {
                new Scope
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
