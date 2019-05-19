using Eds.Data;
using Eds.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eds.Repository
{
    public class RoleRepository: IRoleRepository
    {
        public Role GetRoleById(int roleId)
        {
            EdsDbContext db = new EdsDbContext();
            Role role = null;
            try
            {
                role = db.Roles.FirstOrDefault(o => o.ID == roleId);

            }
            catch (Exception ex)
            {
                //LogHelper.Error(ex.ToString());
            }
            finally
            {
                db.Dispose();
            }
            return role;
        }

        public List<Role> GetRoles()
        {
            EdsDbContext db = new EdsDbContext();

            List<Role> roleList = null;
            try
            {

                roleList = db.Roles.ToList();
            }
            catch (Exception ex)
            {
                //LogHelper.Error(ex.ToString());
            }
            finally
            {
                db.Dispose();
            }
            return roleList;
        }
    }
}
