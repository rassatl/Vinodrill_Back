using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Stripe;
using System.Web.Mvc;

public class GoogleAuth : FlowMetadata
{
    private static readonly IAuthorizationCodeFlow flow =
        new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecrets = new ClientSecrets
            {
                ClientId = "my-app-client-id.apps.googleusercontent.com",
                ClientSecret = "my-app-client-secret"
            },
            Scopes = new[] {
                PlusService.Scope.UserinfoEmail,
                PlusService.Scope.UserinfoProfile
            },
            DataStore = new FileDataStore("Google.Apis.Sample.MVC")
        });

    public override string GetUserId(Controller controller)
    {
        return "user1";
    }

    public override string GetUserId(Controller controller)
    {
        throw new NotImplementedException();
    }

    public override IAuthorizationCodeFlow Flow
    {
        get { return flow; }
    }
}