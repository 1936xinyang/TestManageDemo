using Eds.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Common.Models
{
    [TableAttribute(TableName = "T_SLOGINLOG", IsLogicValid = false, TableDesc = "用户登录日志")]
    public class LoginLog : BaseDataEntity
    {
        [ColumnAttribute(Name = "LOGINLOGID", IsPrimaryKey = true, LogicName = "登录日志Id")]
        public string LoginLogId { get; set; }

        [ColumnAttribute(Name = "USERID", IsPrimaryText = true, LogicName = "用户Id")]
        public string UserId { get; set; }

        [ColumnAttribute(Name = "USERNAME", LogicName = "用户名称")]
        public string UserName { get; set; }
        [ColumnAttribute(Name = "ROLEID", LogicName = "角色Id")]
        public string RoleId { get; set; }
        [ColumnAttribute(Name = "ROLENAME", LogicName = "角色名称")]
        public string RoleName { get; set; }
        [ColumnAttribute(Name = "SERVERSESSIONID", LogicName = "服务器sessionId")]
        public string ServerSessionId { get; set; }
        [ColumnAttribute(Name = "IP", LogicName = "登录IP")]
        public string IP { get; set; }
    }
}
