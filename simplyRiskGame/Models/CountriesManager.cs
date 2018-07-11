using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dijkstra.NET.Contract;
using Dijkstra.NET.Model;
using Dijkstra.NET.ShortestPath;

namespace simplyRiskGame.Models
{
    public class CountriesManager
    {
        public Dictionary<int, Country> Countries = new Dictionary<int, Country>();
        public Graph<int, string> CountriesGraph = new Graph<int, string>();

        public CountriesManager()
        {
            FillMap();
        }
        public void FillMap()
        {   //North America
            Countries.Add(1, new Country("Alaska", 1, new List<int> { 6, 2, 32 }));
            Countries.Add(2, new Country("Alberta", 2, new List<int> { 1, 6, 7, 9 }));
            Countries.Add(3, new Country("México, América Central y el Caribe", 3, new List<int> { 9, 4, 13 }));
            Countries.Add(4, new Country("Estados Unidos del Este, compuesta por el Noreste y el Sudeste de Estados Unidos", 4, new List<int> { 3, 7, 8, 9 }));
            Countries.Add(5, new Country("Groenlandia", 5, new List<int> { 6, 7, 8, 21 }));
            Countries.Add(6, new Country("Territorios del Noroeste", 6, new List<int> { 1, 2, 7, 5 }));
            Countries.Add(7, new Country("Ontario", 7, new List<int> { 6, 2, 9, 4, 8, 5 }));
            Countries.Add(8, new Country("Quebec", 8, new List<int> { 5, 7, 4 }));
            Countries.Add(9, new Country("Estados Unidos del Oeste", 9, new List<int> { 2, 7, 4, 3 }));
            //South America
            Countries.Add(10, new Country("Argentina", 10, new List<int> { 11, 12 }));
            Countries.Add(11, new Country("Brasil", 11, new List<int> { 13, 12, 18, 10 }));
            Countries.Add(12, new Country("Perú", 12, new List<int> { 13, 11, 10 }));
            Countries.Add(13, new Country("Venezuela", 13, new List<int> { 3, 11, 12 }));
            //Africa
            Countries.Add(14, new Country("Congo", 14, new List<int> { 18, 15, 19 }));
            Countries.Add(15, new Country("África Oriental", 15, new List<int> { 33, 17, 19, 14, 18, 16 }));
            Countries.Add(16, new Country("Egipto", 16, new List<int> { 33, 15, 18, 24 }));
            Countries.Add(17, new Country("Madagascar", 17, new List<int> { 19, 15 }));
            Countries.Add(18, new Country("África del Norte", 18, new List<int> { 24, 26, 11, 14, 16, 15 }));
            Countries.Add(19, new Country("Sudáfrica", 19, new List<int> { 14, 15, 17 }));
            //Europe
            Countries.Add(20, new Country("Gran Bretaña", 20, new List<int> { 21, 23, 22, 26 }));
            Countries.Add(21, new Country("Islandia", 21, new List<int> { 5, 23, 20 }));
            Countries.Add(22, new Country("Europa del Norte", 22, new List<int> { 23, 25, 24, 20, 26 }));
            Countries.Add(23, new Country("Escandinavia", 23, new List<int> { 25, 22, 20, 21 }));
            Countries.Add(24, new Country("Europa del Sur", 24, new List<int> { 16, 18, 22, 25, 26, 33 }));
            Countries.Add(25, new Country("Ucrania", 25, new List<int> { 24, 23, 22, 37, 27, 33 }));
            Countries.Add(26, new Country("Europa Occidental", 26, new List<int> { 24, 20, 22, 18 }));
            //Asia
            Countries.Add(27, new Country("Afganistán", 27, new List<int> { 25, 37, 28, 29, 33 }));
            Countries.Add(28, new Country("China", 28, new List<int> { 35, 29, 27, 37, 36, 34 }));
            Countries.Add(29, new Country("India", 29, new List<int> { 35, 28, 27, 33 }));
            Countries.Add(30, new Country("Irkutsk", 30, new List<int> { 34, 32, 38, 36 }));
            Countries.Add(31, new Country("Japón", 31, new List<int> { 34, 32 }));
            Countries.Add(32, new Country("Kamchatka", 32, new List<int> { 1, 38, 30, 34, 31 }));
            Countries.Add(33, new Country("Oriente Medio", 33, new List<int> { 24, 25, 16, 15, 29, 27 }));
            Countries.Add(34, new Country("Mongolia", 34, new List<int> { 28, 31, 32, 30, 36 }));
            Countries.Add(35, new Country("Siam", 35, new List<int> { 40, 28, 29 }));
            Countries.Add(36, new Country("Siberia", 36, new List<int> { 28, 34, 30, 38, 37 }));
            Countries.Add(37, new Country("Ural", 37, new List<int> { 25, 36, 28, 27 }));
            Countries.Add(38, new Country("Yakutsk", 38, new List<int> { 36, 30, 32 }));
            //Australia
            Countries.Add(39, new Country("Australia Oriental, compuesta por Queensland y por la Nueva Gales del Sur", 39, new List<int> { 41, 42 }));
            Countries.Add(40, new Country("Indonesia", 40, new List<int> { 35, 41, 42 }));
            Countries.Add(41, new Country("Nueva Guinea", 41, new List<int> { 39, 40, 42 }));
            Countries.Add(42, new Country("Australia Occidental", 42, new List<int> { 40, 41, 39 }));

            UpdateCountriesList();
           // SetCountriesGraph();
        }

        #region Stuff 
        public int getIDbyName(string countryName)
        {
            for (int i = 1; i <= Countries.Count() ; i++)
            {
                if (Countries[i].CountryName == countryName)
                    return Countries[i].CountryID;
            }
            return 0;
        }

        public void UpdateCountriesList()
        {
            for (int i = 1; i <= Countries.Count(); i++)//update countries list
            {
                Countries[i].setNeighbors(setNeighborsCM(Countries[i]));
            }
        }

        public List<Country> setNeighborsCM(Country C)
        {
            List<Country> t = new List<Country>();
            for (int i = 0; i < C.Neighborsint.Count(); i++)
                t.Add(Countries[C.Neighborsint[i]]);
            return t;
        }

        public List<string> getPlayerCountries(int player) // number of the player who owns that country, 0 if its neutral 
        {
            List<string> t = new List<string>(); //countries ids list
            for (int i = 1; i <= Countries.Count(); i++)
            {
                if (Countries[i].Owner == player)
                    t.Add(i.ToString() + "|" + Countries[i].CountryName);
            }
            return t;
        }


        public List<string> getNeighborsstr(string countryName)
        {
            List<string> t = new List<string>();
            for (int i = 1; i <= Countries.Count(); i++)
                if (Countries[i].CountryName == countryName)
                {
                    for (int j = 0; j < Countries[i].Neighborsint.Count(); j++)
                        t.Add(Countries[i].Neighbors[j].CountryID.ToString() + "|" + Countries[i].Neighbors[j].CountryName);
                    return t;
                }
            return t;
        }

        public int getTroopsCount(string CountryName)
        {
            for (int i = 1; i <= Countries.Count(); i++)
            {
                if (Countries[i].CountryName == CountryName)
                    return Countries[i].TroopsCount;
            }
            return 0;
        }
        public int TroopdforAssign(int player)
        {
            int count = 0;
            for (int i = 1; i <= Countries.Count(); i++)
            {
                if (Countries[i].Owner == player)
                    count++;
            }
            if (count <= 5)
                return 5;
            else if (count <= 10)
                return 10;
            else if (count <= 15)
                return 15;
            else
                return 20;
        }
        public List<int> getNeighborsAlly(int cpuntryID, int player)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < Countries[cpuntryID].Neighborsint.Count(); i++)
                if (Countries[Countries[cpuntryID].Neighborsint[i]].Owner == player)
                    temp.Add(Countries[cpuntryID].Neighborsint[i]);
            return temp;
        }
        /// <summary>
        /// get the troops of the neighbors
        /// </summary>
        /// <param name="countryID"></param>
        /// <param name="player"></param>
        /// <returns> [neutral, ally, enemy]</returns>
        public int[] getNeighborsTroopsCount(int countryID, int player)
        {
            int[] t = new int[3];
            for (int i = 0; i < Countries[countryID].Neighborsint.Count(); i++)
            {
                if (Countries[Countries[countryID].Neighborsint[i]].Owner == 0)
                    t[0] += Countries[Countries[countryID].Neighborsint[i]].TroopsCount;
                else if(Countries[Countries[countryID].Neighborsint[i]].Owner == player)
                    t[1] += Countries[Countries[countryID].Neighborsint[i]].TroopsCount;
                else
                    t[2] += Countries[Countries[countryID].Neighborsint[i]].TroopsCount;
            }
            return t;
        }

        /// <summary>
        /// get the amount of neighbors of each kind
        /// </summary>
        /// <param name="countryID"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public int[] getNeighborsCount(int countryID, int player)
        {
            int[] t = new int[3];
            for (int i = 0; i < Countries[countryID].Neighborsint.Count(); i++)
            {
                if (Countries[Countries[countryID].Neighborsint[i]].Owner == 0)
                    t[0] ++;
                else if (Countries[Countries[countryID].Neighborsint[i]].Owner == player)
                    t[1] ++;
                else
                    t[2] ++;
            }
            return t;
        }
#endregion

        #region Dijkstra
        public void SetCountriesGraph()
        {
            for (int i = 1; i <= Countries.Count(); i++)
                CountriesGraph.AddNode(i);
            UInt16 to = 0;
            int cost = 0;
            
            for (int i = 1; i <= Countries.Count(); i++)
            {
                for (int j = 0; j < Countries[i].Neighborsint.Count(); j++)
                {
                    to = Convert.ToUInt16(Countries[i].Neighborsint[j]);
                    cost = Countries[Countries[i].Neighborsint[j]].TroopsCount;
                    CountriesGraph.Connect(Convert.ToUInt16(i-1), to , cost, "fuck yeah");
                }
            }
        }

        public int CalulateDistanceDijkstra(int OriginCountry, int targetCountry)
        {
            CountriesGraph = new Graph<int, string>();
            SetCountriesGraph();
            var dijkstra = new Dijkstra<int, string>(CountriesGraph);
            IShortestPathResult result = dijkstra.Process(Convert.ToUInt16(OriginCountry), Convert.ToUInt16(targetCountry)); //result contains the shortest path
            return result.Distance;
        }

        public int getDistance(int countryID)
        {

            int temp = 100;
            
            List<string> temporallsy = getPlayerCountries(2);
            List<int> result = new List<int>();
            
            for (int i = 0; i < temporallsy.Count(); i++)
            {
                string[] temparr = temporallsy[i].Split('|');
                result.Add(CalulateDistanceDijkstra(countryID, int.Parse(temparr[0]))); 
                   
            }
            temp = result.Min(); 

            return temp;
        }

        #endregion
    }
}