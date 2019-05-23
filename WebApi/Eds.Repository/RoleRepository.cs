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

        public int? AddRole(Role role)
        {
            int? result = 0;
            EdsDbContext db = new EdsDbContext();
            try
            {
                db.Roles.Add(role);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //LogHelper.Error(ex.ToString());
                result = null;
            }
            finally
            {
                db.Dispose();
            }
            return result;
        }

        public int? UpdateRole(Role role)
        {
            int? result = 0;
            EdsDbContext db = new EdsDbContext();
            try
            {

                var oldRole = db.Roles.FirstOrDefault(u => u.ID ==role.ID);
                if (oldRole != null)
                {
                    oldRole.RoleName = role.RoleName;
                    oldRole.RoleDesc = role.RoleDesc;
                    db.SaveChanges();
                }                
            }
            catch (Exception ex)
            {
                //LogHelper.Error(ex.ToString());
                result = null;
            }
            finally
            {
                db.Dispose();
            }
            return result;
        }

        public int? DeleteRole(int id)
        {
            int? result = 0;
            EdsDbContext db = new EdsDbContext();
            try
            {

                var oldRole = db.Roles.FirstOrDefault(u => u.ID == id);
                if (oldRole != null)
                {
                    db.Roles.Remove(oldRole);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error(ex.ToString());
                result = null;
            }
            finally
            {
                db.Dispose();
            }
            return result;
        }
    }
}
