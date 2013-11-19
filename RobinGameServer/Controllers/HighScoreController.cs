using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml;
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

        [ValidateInput(false)]
        public void AddHighScore(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            var nameElement = document.GetElementById("name");
            var scoreElement = document.GetElementById("score");
            var keyElement = document.GetElementById("key");

            if (nameElement != null && scoreElement != null && keyElement != null)
            {
                if (keyElement.Value == "123456abcdefg")
                {
                    var name = nameElement.Value;
                    var score = Convert.ToInt32(scoreElement.Value);

                    var highScore = new HighScore
                    {
                        Name = name,
                        Score = score
                    };

                    context.HighScores.Add(highScore);
                    context.SaveChanges();
                }
            }
        }

    }
}
