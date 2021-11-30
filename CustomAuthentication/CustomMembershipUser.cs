using ClubPortalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ClubPortalMS.CustomAuthentication
{
    public class CustomMembershipUser : MembershipUser
    {
        ApplicationDbContext db = new ApplicationDbContext();
        #region User Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<DBUserRoles> DBUserRoles { get; set; }
        
        #endregion
        public CustomMembershipUser(DBUser user) : base("CustomMembership", user.Username, user.ID, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            //ID = user.AccountSystems.FirstOrDefault(s=>s.ID == user.ID).ID;
            ID = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DBUserRoles = user.DBUserRoles;
        }
    }
}