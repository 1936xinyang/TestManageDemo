using Eds.Data;
using Eds.IRepository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class RoleController : ApiController
    {
        [Dependency]
        public IRoleRepository roleRepository { get; set; }
        // GET: api/Role
        public List<Role> GetRoles()
        {
            return roleRepository.GetRoles(); ;
        }

        // GET: api/Role/5
        public Role GetRoleById(int id)
        {
            return roleRepository.GetRoleById(id); 
        }

        // POST: api/Role
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Role/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Role/5
        public void Delete(int id)
        {
        }
    }
}
