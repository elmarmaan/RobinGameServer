using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using RobinGameServer.Models;

namespace RobinGameServer.Controllers
{
    public class HighScoreController : Controller
    {
        //
        // GET: /HighScore/

        Context context = new Context();

        public ActionResult Index()
        {
            var highScores = context.HighScores.OrderBy(h=> h.Score);

            ViewData.Model = highScores;
            return View();
        }

    }
}
