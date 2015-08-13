using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {

        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }


        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(user => new DalRole()
            {
                Id = user.Id,
                Name = user.Name
            });
        }

        public DalRole GetById(int key)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(role => role.Id == key);
            return new DalRole()
            {
                Id = ormRole.Id,
                Name = ormRole.Name
            };
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRole e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
