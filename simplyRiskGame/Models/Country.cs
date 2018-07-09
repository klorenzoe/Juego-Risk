using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simplyRiskGame.Models
{
    public class Country
    {
        //public string name { get; set; }
        //public int number { get; set; }
        //public List<Country> adjacentCountries { get; set; }

        public string CountryName { get; set; }
        public int CountryID { get; set; }
        public int TroopsCount { get; set; }
        public int Owner { get; set; } // number of the player who owns that country, 0 if its neutral 
        /// <summary>
        /// Never use this, doesnt work
        /// </summary>
        public List<Country> Neighbors = new List<Country>(); 
        public List<int> Neighborsint = new List<int>();

        Random rnd = new Random();

        public Country(String name, int id, List<int> neighbors)
        {
            CountryName = name;
            CountryID = id;
           // TroopsCount = rnd.Next(2,5);

            neighbors.Sort();
            Neighborsint = neighbors;
        }
        public void setNeighbors(List<Country> Neighborslst)
        {
            Neighbors = Neighborslst;
        }

        public List<int> getNeighborsIDs()
        {
            return Neighborsint;
        }
    }
}