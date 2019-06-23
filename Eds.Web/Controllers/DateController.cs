using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eds.Web.Controllers
{
    public class DateController : Controller
    {
        // GET: MVCDemo
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ShowWidget()
        {
            return PartialView("~/Views/Shared/_PartialPageWidget.cshtml");
        }

        //不同方式显示时间值
        public ActionResult SharedDateDemo()
        {
            ViewBag.DateTime = DateTime.Now;
            return View();
        }
        [ChildActionOnly]
        public ActionResult PartialViewDate()
        {
            ViewBag.DateTime = DateTime.Now.AddMinutes(10);
            return PartialView("_PartialPageDateTime");
        }
    }
}