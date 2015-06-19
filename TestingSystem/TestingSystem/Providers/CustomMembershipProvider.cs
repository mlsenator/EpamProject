//Select Assemblies - > Extensions -> System.Web.Helpers
using System;
using System.Drawing.Design;
using System.Linq;
using System.Security.Principal;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace TestingSystem.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public CustomMembershipProvider ()
        {
        }
        public MembershipUser CreateUser(BLLUser user)
        {
            var userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
            MembershipUser membershipUser = GetUser(user.Name, false);

            if (membershipUser != null)
            {
                return null;
            }

            //user.Password = Crypto.HashPassword(user.Password);

            userService.Add(user);
            membershipUser = GetUser(user.Name, false);
            return membershipUser;
        }

        public override bool ValidateUser(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password)) return false;

            var userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

            try
            {
                BLLUser user = (from u in userService.GetAll()
                                where u.Name == login
                                select u).FirstOrDefault();

                if (user != null && Crypto.VerifyHashedPassword(Crypto.HashPassword(user.Password), password))
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

        public override MembershipUser GetUser(string login, bool userIsOnline)
        {
            var userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
            var user = (from u in userService.GetAll()
                        where u.Name == login
                        select u).FirstOrDefault();

            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider", user.Name, null, user.Email,
                null, null,
                false, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);

            return memberUser;

        }

        #region Stabs
        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}