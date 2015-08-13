using System.Security.Principal;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace MvcPL.Global.Auth
{
    public class UserIndentity : IIdentity, IUserProvider
    {
        public UserEntity User { get; set; }

        public string AuthenticationType
        {
            get { return typeof(UserEntity).ToString(); }
        }



        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.UserName;
                }
                return "anonym";
            }
        }

        public void Init(string name, IUserService repository)
        {
            if (!string.IsNullOrEmpty(name))
            {
                User = repository.GetUserByName(name);
            }
        }
    }
}