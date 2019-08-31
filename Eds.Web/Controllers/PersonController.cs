using Eds.Web.Models;
using Eds.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eds.Web.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            Book book = new Book { Author=new Author {  Name="Martin"}, Title="企业级应用"};
            var dest= AutoMapper.Mapper.Map<BookViewModel>(book);

            var book2 = AutoMapper.Mapper.Map<Book>(dest);


            return View();
        }
    }
}