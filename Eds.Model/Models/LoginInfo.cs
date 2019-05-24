using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Common.Models
{
    public class LoginInfo : BaseDataEntity
    {
        public string LoginAccountId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
