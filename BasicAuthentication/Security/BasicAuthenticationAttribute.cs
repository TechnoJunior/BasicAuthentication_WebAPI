using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthentication.Security
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                //401 Forbidden
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "username or password not supplied");
            }
            else
            {
                String authInfo = actionContext.Request.Headers.Authorization.Parameter;
                String decodeAuthoInfo = Encoding.UTF8.GetString(Convert.FromBase64String(authInfo));

                String[] authInfoArray = decodeAuthoInfo.Split(':');
                String username = authInfoArray[0];
                String password = authInfoArray[1];

                if (UserValidate.login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.BadGateway, "Invalid Login");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}