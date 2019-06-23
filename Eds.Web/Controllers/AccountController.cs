using Eds.Web;
using Eds.Web.Entities;
using Eds.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Eds.Web.Controllers
{
    public class AccountController : Controller
    {
        private MyEntity db = new MyEntity();
        public AccountController()
        {
        }

        public ActionResult Index()
        {
            return View(db.SysUsers);
        }
        public ActionResult Details(int id)
        {
            SysUser user= db.SysUsers.Find(id);
            return View(user);
        }
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string emial = fc["txtEmail"];
            string pwd = fc["txtPwd"];
            //todo
            ViewBag.LoginState = emial+"登录后";
            return View();
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        
        
      



    }
}