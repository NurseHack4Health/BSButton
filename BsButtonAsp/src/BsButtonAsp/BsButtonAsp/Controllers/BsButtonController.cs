using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BsButtonAsp.Api;
using BsButtonAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BsButtonAsp.Controllers
{
    public class BsButtonController : Controller
    {
        public BsButtonController(IBsApi api)
        {
            Api = api;
        }

        private IBsApi Api { get; set; }



        public IActionResult Index()
        {
            var model = new List<BsCreateViewModel>();
            model = Api.GetUnverifiedBsItemList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View("CreateView");
        }


        public IActionResult CreateView(BsCreateViewModel viewModel)
        {
            var result = Api.Post(viewModel);
            return RedirectToAction("Index");
        }
    }
}
