using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ith.Domain.Abstract;
using Ninject;

namespace Ith.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IPostRepository PostRepository;

        public HomeController(IPostRepository Repository)
        {
            PostRepository = Repository;
        }

        public ActionResult Index()
        {
            return View(PostRepository.Posts());
        }
    }
}