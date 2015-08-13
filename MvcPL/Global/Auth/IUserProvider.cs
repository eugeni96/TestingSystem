using System.Web.Providers.Entities;
using BLL.Interface.Entities;

namespace MvcPL.Global.Auth
{
    public interface IUserProvider
    {
        UserEntity User { get; set; }
    }
}