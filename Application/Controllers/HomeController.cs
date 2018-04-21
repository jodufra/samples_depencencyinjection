using Application.Core.Repositories;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository userRepository;

        public HomeController(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var model = new HomeIndexModel()
            {
                Users = userRepository.GetAll()
            };

            return View(model);
        }
    }
}