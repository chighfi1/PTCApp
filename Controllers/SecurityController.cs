using Microsoft.AspNetCore.Mvc;
using PTCApp.Entities;
using PTCApp.ManagerClasses;
using PTCApp.Models;

namespace PTCApp.Controllers
{
    public class SecurityController: AppControllerBase
    {
        public SecurityController(PtcDbContext context)
        {
            _DbContext = context;
        }

        private readonly PtcDbContext _DbContext;

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AppUser user)
        {
            IActionResult ret = null;

            AppUserAuth auth = new AppUserAuth();
            SecurityManager mgr = new SecurityManager(
                _DbContext, auth
                );
            auth = (AppUserAuth)mgr.ValidateUser(user.UserName, user.Password);
            if(auth.IsAuthenticated)
            {
                ret = StatusCode(200, auth);
            }
            else
            {
                ret = StatusCode(401, "Invalid User Name/Password.");
            }

            return ret;
        }
    }
}
