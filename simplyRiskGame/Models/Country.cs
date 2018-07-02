using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simplyRiskGame.Models
{
    public class Country
    {
        public string name { get; set; }

        public int number { get; set; }

        public List<Country> adjacentCountries { get; set; }
    }
}