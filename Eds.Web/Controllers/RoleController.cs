using Eds.Data;
using log4net;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Eds.Web.Controllers
{
    public class RoleController : Controller
    {
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Assembly, MethodBase.GetCurrentMethod().DeclaringType);

        // GET: Role
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private EdsDbContext db = new EdsDbContext();
        // GET: Role
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var roles = from u in db.Roles
                        select u;
            if (!string.IsNullOrEmpty(searchString))
            {
                roles = roles.Where(u => u.RoleName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    roles = roles.OrderByDescending(u => u.RoleName);
                    break;
                default:
                    roles = roles.OrderBy(u => u.RoleName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(roles.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Login()
        {
            log.Info("登录前");
            ViewBag.LoginState = "登录前。。。";
            return View();
        }
        /*
        [HttpPost]  //表示这个Action只会接受http post请求,Action Method Selector, HttpPost就是其中之一
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];
            List<SysUser> user = null;
            TransactionOptions transactionOption = new TransactionOptions();
            //设置事务隔离级别
            transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            //设置事务超时时间，这里设置为8分钟
            transactionOption.Timeout = new TimeSpan(0, 8, 0);
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOption))
            {
                try
                {
                    user = db.Sysroles.Where(b => b.Email == email && b.PassWord == password).ToList();
                    scope.Complete();
                }
                catch (Exception objErr)
                {
                    //发生异常时候的处理
                }
            }
            if (user.Count() > 0)
            {
                ViewBag.LoginState = email + "登录后。。。";
            }
            else
            {
                ViewBag.LoginState = email + "用户不存在。。。";
            }

            return View();
        }
        */

        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Role role = db.Roles.Find(id);
            return View(role);
        }

        //新建用户
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Role sysUser)
        {
            db.Roles.Add(sysUser);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //删除用户
        public ActionResult Delete(int id)
        {

            Role sysUser = db.Roles.Find(id);

            return View(sysUser);

        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {

            Role sysUser = db.Roles.Find(id);

            db.Roles.Remove(sysUser);

            db.SaveChanges();

            return RedirectToAction("Index");

        }


        //修改用户  

        public ActionResult Edit(int id)
        {

            Role sysUser = db.Roles.Find(id);

            return View(sysUser);

        }

        [HttpPost]

        public ActionResult Edit(Role sysUser)
        {

            db.Entry(sysUser).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}