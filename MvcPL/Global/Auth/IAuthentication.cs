﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using BLL.Interface.Entities;

namespace MvcPL.Global.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        UserEntity Login(string login, string password, bool isPersistent);
        
        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}