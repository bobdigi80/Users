using System.Web.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Util.Store;
using Microsoft.AspNet.Identity;

namespace Users.Infrastructure
{
    public class AppAuthFlowMetadata : FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "PUT_YOUR_CLIENT_ID_HERE",
                    ClientSecret = "PUT_YOUR_CLIENT_SECRET_HERE"
                },
                Scopes = new[] { DriveService.Scope.Drive },
                // TODO: maybe in a future post I'll demonstrate a new EFDataStore usage.
                DataStore = new FileDataStore("Google.Apis.Sample.MVC")
            });

        public override string GetUserId(Controller controller)
        {
            return controller.User.Identity.GetUserName();
        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
    }
}