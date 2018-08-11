using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4;

namespace IdServer.Configuration
{
    public class Config
    {

        //defining the Audience
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
            new ApiResource("moviesApi", "movies api")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }


        public static IEnumerable<Client> getApiClients()
        {
            return new List<Client>
           {
               new Client
               {
                   ClientId="movieresource",
                   AllowedGrantTypes=GrantTypes.ClientCredentials,
                   ClientSecrets={new Secret("apiSecret".Sha256())},

                   //define scopes
                   AllowedScopes={"moviesApi"},
                   AllowOfflineAccess=true

               }
           };
        }

    }
}
