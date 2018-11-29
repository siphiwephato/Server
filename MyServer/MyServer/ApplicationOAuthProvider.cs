﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using MyServer;
using System.Data.Entity;



namespace MyServer
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var db = new MyServer.Models.travelstartEntities();

            var user = db.Users.FirstOrDefault(x => x.UserName == context.UserName && x.Password == context.Password);
          //var administrator = db.Administrators.FirstOrDefault(x => x.UserName == context.UserName && x.Password == context.Password);

            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("UserId",user.UserId.ToString()));
              identity.AddClaim(new Claim("UserName", user.UserName));
               identity.AddClaim(new Claim("Email", user.Email));
              identity.AddClaim(new Claim("Password", user.Password));
               identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));
                      identity.AddClaim(new Claim("card_no", user.card_no));
            identity.AddClaim(new Claim("account_no", user.account_no));
               
               context.Validated(identity);
            }
            /*else if (administrator != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("AdministratorID", administrator.AdministratorID.ToString()));
                identity.AddClaim(new Claim("Firstname", administrator.Firstname));
                identity.AddClaim(new Claim("Lastname", administrator.Lastname));
                identity.AddClaim(new Claim("UserName", administrator.UserName));
                identity.AddClaim(new Claim("Password", administrator.Password));
                context.Validated(identity);

            }*/
            else
            {
                return;
            }
        }
    }
}