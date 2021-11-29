using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubPortalMS.Models.Models
{
    public class UserRoles
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Roles Roles { get; set; }
        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
    }
}