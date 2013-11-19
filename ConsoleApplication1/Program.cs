using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobinGameServer.Models;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Context())
            {
                var highScore = new HighScore{Name = "Elmar", Score = 11};
                ctx.HighScores.Add(highScore);
                ctx.SaveChanges();

                Console.WriteLine("Aantal higscores: " + ctx.HighScores.First().Name);
            }
        }
    }
}
