using EPiServer.ContentApi.Core.Internal;
using EPiServer.Security;
using EPiServer.Security.Internal;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer.AlloyDemo.GraphAPI.Auth
{
    [ServiceConfiguration(typeof(UserService))]
    public class CustomUserService : UserService
    {
        public CustomUserService(IContentAccessEvaluator accessEvaluator) : base(accessEvaluator)
        {
        }
        /// <summary>
        /// Check whether an user is valid
        /// </summary>
        public override bool IsUserValid(string name)
        {
            var synUserRepo = ServiceLocator.Current.GetInstance<ISynchronizedUsersRepository>();
            var users = synUserRepo.FindUsers(name);
            return users != null && users.Any();
        }
    }
}