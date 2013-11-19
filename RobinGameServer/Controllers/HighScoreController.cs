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
            var highScores = context.HighScores.OrderByDescending(h=> h.Score);

            ViewData.Model = highScores;
            return View();
        }

        [ValidateInput(false)]
        public void AddHighScore(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            var nameElement = document.FirstChild["name"];
            var scoreElement = document.FirstChild["score"];
            var keyElement = document.FirstChild["key"];

            if (nameElement != null && scoreElement != null && keyElement != null)
            {
                if (keyElement.InnerText == "123456abcdefg")
                {
                    var name = nameElement.InnerText;
                    var score = Convert.ToInt32(scoreElement.InnerText);

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
