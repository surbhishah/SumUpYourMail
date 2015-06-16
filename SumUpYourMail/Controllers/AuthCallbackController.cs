using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2.Responses;

namespace SumUpYourMail.Controllers
{
        // GET: AuthCallback
        public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
        {
            protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
            {
                get { return new AppFlowMetadata(); }
            }

            public override Task<ActionResult> IndexAsync(AuthorizationCodeResponseUrl authorizationCode, CancellationToken taskCancellationToken)
            {
                return base.IndexAsync(authorizationCode, taskCancellationToken);
            }
        }
    
}