using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository, IRoleRepository roleRepository)
        {
            this.uow = uow;
            this.userRepository = repository;
            this.roleRepository = roleRepository;
            //Debug.WriteLine("service create!");
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            //using (uow)
            {
                return userRepository.GetAll().Select(user => user.ToBllUser()); 
            }
        }

        public void CreateUser(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            uow.Commit();
        }

        public UserEntity GetUserByName(string name)
        {
            return userRepository.GetUserByName(name).ToBllUser();
        }

        public ICollection<RoleEntity> GetRoles(UserEntity user)
        {
            throw new NotImplementedException();
            //return roleRepository.GetById(user.RoleId).ToBllRole();
        }
    }
}
