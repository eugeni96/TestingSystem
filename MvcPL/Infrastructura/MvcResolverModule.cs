using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyResolver;
using MvcPL.Global.Auth;
using MvcPL.Mappers;
using Ninject.Web.Common;

namespace MvcPL.Infrastructura
{
    public class MvcResolverModule : ResolverModule
    {
        public override void Load()
        {
            base.Load();
            Bind<IAuthentication>().To<CustomAuthentication>().InRequestScope();
        }
    }
}