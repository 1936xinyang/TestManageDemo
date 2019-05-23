using Eds.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.IRepository
{
    public interface IRoleRepository
    {
        Role GetRoleById(int roleId);
        List<Role> GetRoles();
        int? AddRole(Role role);

        int? UpdateRole(Role role);

        int? DeleteRole(int id);
        
    }
}
