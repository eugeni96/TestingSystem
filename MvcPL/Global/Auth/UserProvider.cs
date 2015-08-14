using System;
using System.Linq;
using System.Security.Principal;
using BLL.Interface.Services;

namespace MvcPL.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIndentity UserIdentity { get; set; }
        private IUserService UserService { get; set; }
        public UserProvider(string name, IUserService userService)
        {
            UserService = userService;
            UserIdentity = new UserIndentity();
            UserIdentity.Init(name, userService);
        }


        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return UserIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (UserIdentity.User == null)
            {
                return false;
            }
            return UserIdentity.User.Roles.Any(m => m.Name.Equals(role,StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        public override string ToString()
        {
            return UserIdentity.Name;
        }

    }
}