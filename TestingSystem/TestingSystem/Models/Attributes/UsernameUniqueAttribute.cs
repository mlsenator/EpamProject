using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BLL.Interface.Services;
using BLL.Interface.Entities;

namespace TestingSystem.Models.Attributes
{
    public class UsernameUniqueAttribute : ValidationAttribute
    {
        public UsernameUniqueAttribute()
        {
        }

        public override bool IsValid(object login)
        {
            var userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
            string stringLogin = Convert.ToString(login);
            var counter = userService.GetAll().Where(user => user.Name == stringLogin).Count();
            return counter > 0 ? false : true;
        }
    }
}