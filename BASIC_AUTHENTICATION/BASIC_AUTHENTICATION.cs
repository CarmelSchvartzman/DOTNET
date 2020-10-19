https://www.base64encode.org/
http://csharp-video-tutorials.blogspot.com/2016/10/implementing-basic-authentication-in.html

using EmployeeDataAccess;
using System;
using System.Linq;

namespace EmployeeService
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Users.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password);
            }
        }
    }
}




-------
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeService
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers
                                            .Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];

                if (EmployeeSecurity.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}




-------

[BasicAuthentication]
public HttpResponseMessage Get(string gender = "All")
{
    string username = Thread.CurrentPrincipal.Identity.Name;

    using (EmployeeDBEntities entities = new EmployeeDBEntities())
    {
        switch (username.ToLower())
        {
            case "male":
                return Request.CreateResponse(HttpStatusCode.OK,
                    entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
            case "female":
                return Request.CreateResponse(HttpStatusCode.OK,
                    entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
            default:
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
