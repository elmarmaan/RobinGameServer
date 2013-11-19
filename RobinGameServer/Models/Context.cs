using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RobinGameServer.Models
{
    public class Context : DbContext 
    {
        public Context() : base()
        {
            
        }

        public DbSet<HighScore> HighScores { get; set; }
    }
}