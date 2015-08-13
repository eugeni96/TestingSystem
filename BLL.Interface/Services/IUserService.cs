using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<UserEntity> GetAllUserEntities();
        UserEntity GetUserByName(string name);
        ICollection<RoleEntity> GetRoles(UserEntity user);
        void CreateUser(UserEntity user);
    }
}