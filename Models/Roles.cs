using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubPortalMS.Models.Models
{
    public class Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Roles()
        {
            this.UserRoles = new HashSet<UserRoles>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string MoTa { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> NgayXoa { get; set; }
        public Nullable<int> UserDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }


}