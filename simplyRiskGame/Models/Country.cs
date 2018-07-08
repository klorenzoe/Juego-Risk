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

        public int[] getNeighborsTroopsCount()//[neutral, ally, enemy]
        {
            int[] t = new int[3];
            for (int i = 0; i < Neighbors.Count(); i++)
            {
                if (Neighbors[i].Owner == 0)
                    t[0] = + Neighbors[i].TroopsCount;
                else if (Neighbors[i].Owner == 1)
                    t[1] = + Neighbors[i].TroopsCount;
                else
                    t[2] = + Neighbors[i].TroopsCount;
            }
            return t;
        }

        public List<int> getNeighborsIDs()
        {
            return Neighborsint;
        }
    }
}