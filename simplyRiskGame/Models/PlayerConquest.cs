using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simplyRiskGame.Models
{
    public class PlayerConquest
    {
        public List<Country> itsCountries = new List<Country>();

        public int player { get; set; } //1 user, 2 IA
    }
}