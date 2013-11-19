using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RobinGameServer.Models
{
    public class HighScore
    {
        [Key] 
        public long Id { get; set; }

        public string Name { get; set; }
        public int Score { get; set; }
    }
}