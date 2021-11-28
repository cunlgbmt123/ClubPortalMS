using System;

namespace ClubPortalMS.Models.Models
{
    public class UserRoles
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> RoleID { get; set; }

        public virtual Roles Roles { get; set; }
        public virtual Users Users { get; set; }
    }
}