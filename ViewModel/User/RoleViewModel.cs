using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.User
{
    public class RoleViewModel
    {
        public int ID { get; set; }
        [DisplayName("Tên Vai Trò")]
        public string Name { get; set; }
        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }
    }
}