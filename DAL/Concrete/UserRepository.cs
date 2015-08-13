using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            Password = user.Password
                        });
        }

        public DalUser GetById(int key)
        {
            var ormUser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return new DalUser()
            {
                Id = ormUser.Id,
                Name = ormUser.Name,
                Email = ormUser.Email,
                Password = ormUser.Password
            };
        }

        public DalUser GetByPredicate(System.Linq.Expressions.Expression<Func<DalUser, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUser e)
        {
            var user = new User()
            {
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                Roles = new List<Role>()
            };
            foreach (var dalRole in e.Roles)
            {
                user.Roles.Add(context.Set<Role>().FirstOrDefault(m => m.Name == dalRole.Name));
            }
            context.Set<User>().Add(user);
            context.SaveChanges();
        }

        public void Delete(DalUser e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public DalUser GetUserByName(string name)
        {
            var ormUser = context.Set<User>().FirstOrDefault(user => user.Name == name);
            return ormUser.ToDal();
        }
    }
}
