using System;
using System.Linq;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace TestingSystem.Providers
{
    //провайдер ролей указывает системе на статус пользователя и наделяет 
    //его определенные правами доступа
    public class CustomRoleProvider : RoleProvider
    {
        public CustomRoleProvider()
        {
        }
        public override bool IsUserInRole(string login, string roleName)
        {
            var roleService = (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));
            var userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(roleName)) return false;
            try
            {
                BLLUser user = (from u in userService.GetAll()
                             where u.Name == login
                             select u).FirstOrDefault();

                if (user == null) return false;

                BLLRole userRole = roleService.GetById(user.RoleId);

                if (userRole != null && userRole.Name == roleName)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public override string[] GetRolesForUser(string login)
        {
            if (login == null) return null;
            try
            {
                var userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
                var roles = new string[] { };
                var user = userService.GetAll().FirstOrDefault(u => u.Name == login);

                if (user == null) return roles;

                var userRole = user.Role;

                if (userRole != null)
                {
                    roles = new string[] { userRole.Name };
                }
                return roles;
            }
            catch
            {
                return null;
            }
        }

        public override void CreateRole(string roleName)
        {
            var roleService = (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));
            var newRole = new BLLRole() { Name = roleName };
            roleService.Add(newRole);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}