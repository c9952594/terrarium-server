﻿using System.Web.Mvc;
using Terrarium.Server.Repositories;
using Terrarium.Server.ViewModels;

namespace Terrarium.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITipRepository _tipRepository;

        public HomeController(ITipRepository tipRepository)
        {
            _tipRepository = tipRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Charts()
        {
            return View();
        }

        public ActionResult Usage()
        {
            var vm = new UsageViewModel();

            var alias = Request.QueryString["Alias"] ?? "Context.User.Identity.Name";
            vm.UserAliasLabel = alias;
            vm.UserTodayLabel = "0 hours";
            vm.UserWeekLabel = "0 hours";
            vm.UserTotalLabel = "0 hours";

            return View(vm);
        }

        [ChildActionOnly]
        public ActionResult RandomTip()
        {
            var tip = _tipRepository.GetRandomTip();
            return PartialView("_RandomTips", new RandomTipViewModel {Tip = tip.Tip});
        }
    }
}
