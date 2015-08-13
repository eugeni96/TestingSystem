using System.Linq;
using System.Security.Principal;
using System.Web.Providers.Entities;
using BLL.Interface.Services;

namespace MvcPL.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIndentity userIdentity { get; set; }
        private IUserService UserService { get; set; }
        public UserProvider(string name, IUserService userService)
        {
            UserService = userService;
            userIdentity = new UserIndentity();
            userIdentity.Init(name, userService);
        }


        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            var userRole = UserService.GetRoles(userIdentity.User);
            return userRole.Any(m => m.Name == role); 
        }

        #endregion

        public override string ToString()
        {
            return userIdentity.Name;
        }

    }
}