using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using MediatR;
using Societly.Features.Account;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterUserCommand();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterUserCommand model)
        {
            var claims = _mediator.Send(model);
            SetClaims(claims.Identity);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            var model = new LoginUserCommand();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LoginUserCommand model)
        {
            var claims = _mediator.Send(model);
            SetClaims(claims.Identity);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            var securityContext = Request.GetOwinContext();
            securityContext.Authentication.SignOut(LoginResult.CookieName);

            return RedirectToAction("Index", "Home");
        }

        private void SetClaims(ClaimsIdentity claims)
        {
            var securityContext = Request.GetOwinContext();
            securityContext.Authentication.SignIn(claims);
        }
    }
}
