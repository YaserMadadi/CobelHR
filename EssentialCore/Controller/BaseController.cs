using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Mvc;
using EssentialCore.Tools.Security;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Security.JWT;
using EssentialCore.Tools.Security.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EssentialCore.Controllers
{
    [Authorize()]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
            //this.userService = new UserService();
        }

        //public IUserService userService { get; set; }

        private UserCredit userCredit;

        public UserCredit UserCredit
        {
            get
            {
                if (this.userCredit == null)

                    this.userCredit = this.HttpContext.Items["userCredit"] as UserCredit;

                return this.userCredit;
            }
        }

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    //var identity = context.HttpContext.User.Identity as ClaimsIdentity;

        //    //var userName = identity.FindFirst(ClaimTypes.Name);

        //    var userName = context.HttpContext.User.Identity.Name;

        //    var userCreditResult = this.userService.RetrieveByUserName(userName);

        //    this.UserCredit = userCreditResult.Result.IsSucceeded ? userCreditResult.Result.Data : null;



        //    base.OnActionExecuting(context);
        //}

        private void updateToken()
        {
            //var accessToken = this.tokenHelper.CreateToken(userCheck.Data);

            //if (accessToken == null || accessToken == default)

            //    return new ErrorDataResult<AccessToken>(accessToken);

            //return new SuccessfulDataResult<AccessToken>(accessToken);
        }
    }
}
