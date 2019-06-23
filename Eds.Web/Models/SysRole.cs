using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eds.Web.Models
{
    [Table("SysRole")]
    public class SysRole
    {
        public int ID { get; set; }
        public string RoleName { get; set; }

        public string RoleDesc { get; set; }

        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }

    }
}