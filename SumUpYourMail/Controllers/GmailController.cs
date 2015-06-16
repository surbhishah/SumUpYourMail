using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace SumUpYourMail.Controllers
{
    public class GmailController : Controller
    {
        //private static readonly string RedirectUri = ConfigurationManager.AppSettings["RedirectUri"];
        //private static readonly string ClientId = ConfigurationManager.AppSettings["ClientId"];
        //private static readonly string ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
        //private static readonly string RedirectUri = "http://localhost:44509/gmail/callback";
        //private static readonly string ClientId = "908938248598-bsvc6nutubocvm07td27k5lhtuj1iivl.apps.googleusercontent.com";
        //private static readonly string ClientSecret = "9mbqGCcFMNW0FTFxGGtvHz0l";
        
        //public static GoogleClientSecrets GetClientConfiguration()
        //{
        //    using (var stream = new FileStream("Secret.json", FileMode.Open, FileAccess.Read))
        //    {
        //        return GoogleClientSecrets.Load(stream);
        //    }
        //}
        //private string GetGoogleUrl()
        //{
        //    string url = @"https://accounts.google.com/o/oauth2/auth?scope=email%20profile&redirect_uri=https%3A%2F%2Foauth2-login-demo.appspot.com%2Foauthcallback&response_type=token&client_id=812741506391.apps.googleusercontent.com&access_type=offline";
        //    var uriBuilder = new UriBuilder(url);
        //    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        //    query["scope"] = "https://www.googleapis.com/auth/gmail.readonly";
        //    //query["state"] = "11";
        //    query["redirect_uri"] = "http://localhost:44509/gmail/callback";
        //    query["response_type"] = "code";
        //    query["client_id"] = ClientId;
        //    query["access_type"] = "offline";
        //    uriBuilder.Query = query.ToString();
        //    url = uriBuilder.ToString();
        //   return url;
        //}
        
//        public ActionResult Index()
//        {
//            return Redirect(GetGoogleUrl());
//            //TokenResponse response = flow.ExchangeCodeForTokenAsync("", code, "postmessage", CancellationToken.None).Result; // response.accessToken now should be populated
//            //var accessToken = response.AccessToken;
//            //var refreshToken = response.RefreshToken;
////            return null;
//        }

        //private static GmailService GetGmailService(TokenResponse credentials)
        //{
        //    IAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        //                                                                    {
        //                                                                        ClientSecrets = GetClientConfiguration().Secrets,
        //                                                                        Scopes = new string[] { GmailService.Scope.GmailReadonly }
        //                                                                    });
        //    UserCredential credential = new UserCredential(flow, "user", credentials);
        //    return new GmailService(
        //        new Google.Apis.Services.BaseClientService.Initializer()
        //        {
        //            ApplicationName = "SumUpYourMail",
        //            HttpClientInitializer = credential                    
        //        });
        //}        

        //public ActionResult Callback()
        //{
        //    //extract authcode from here and call GetAccessTokenByAuthCode
        //    if (HttpContext.Request.Url != null)
        //    {
        //        var uri = HttpContext.Request.Url.ToString();
        //    }
        //    var error = Request["error"];
        //    if (error == "access_denied")
        //    {
        //        //TODO
        //    }
        //    var code = Request["code"]; //code returned via querystring  
        //    if (code == null)
        //    {
        //        //TODO
        //    }
        //    var accessToken = GetAccessTokenByAuthCode(code);
        //    return null;
        //}

        //private string GetAccessTokenByRefreshToken(string refreshToken)
        //{
        //    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/oauth2/v3/token");
        //    ASCIIEncoding encoding = new ASCIIEncoding();
        //    string postData = "refresh_token=" + refreshToken;
        //    postData += "&client_id=" + ClientId;
        //    postData += "&client_secret=" + ClientSecret;
        //    postData += "&redirect_uri=" + RedirectUri;
        //    postData += "&grant_type=refresh_token";
        //    byte[] data = encoding.GetBytes(postData);
        //    httpWReq.Method = "POST";
        //    httpWReq.ContentType = "application/x-www-form-urlencoded";
        //    httpWReq.ContentLength = data.Length;
        //    using (Stream stream = httpWReq.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

        //    string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    var authResponse = (AuthorizationJsonResponse)JsonConvert.DeserializeObject(responseString);
        //    var accessToken = authResponse.AccessToken;
        //    //var refreshToken = authResponse.RefreshToken;
        //    return accessToken;
        //}
        //private string GetAccessTokenByAuthCode(string authCode)
        //{
        //    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/oauth2/v3/token");
        //    ASCIIEncoding encoding = new ASCIIEncoding();
        //    string postData = "code="+authCode;
        //    postData += "&client_id=" + ClientId;
        //    postData += "&client_secret=" + ClientSecret;
        //    postData += "&redirect_uri=" + RedirectUri;
        //    postData += "&grant_type=authorization_code";
        //    byte[] data = encoding.GetBytes(postData);
        //    httpWReq.Method = "POST";
        //    httpWReq.ContentType = "application/x-www-form-urlencoded";
        //    httpWReq.ContentLength = data.Length;
        //    using (Stream stream = httpWReq.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

        //    string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    var authResponse = (AuthorizationJsonResponse) JsonConvert.DeserializeObject(responseString);
        //    var accessToken = authResponse.AccessToken;
        //    var refreshToken = authResponse.RefreshToken;
        //    return accessToken;
        //}


        public async Task<ActionResult> Index()
        {
            var uri = Request.Url.GetLeftPart(UriPartial.Authority);
            var ui = uri + "/AuthCallback/IndexAsync";
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).AuthorizeAsync(CancellationToken.None);
            if (result.Credential != null)
            {
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "SumUpYourMail"
                });

            }
            else
            {
                return Redirect(result.RedirectUri);
            }

           return null;
        }
    }
    

}