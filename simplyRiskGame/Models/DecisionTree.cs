using Dijkstra.NET.Contract;
using Dijkstra.NET.Model;
using Dijkstra.NET.ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simplyRiskGame.Models
{
    public class DecisionTree
    {
        public Dictionary<int, Country> Countries = new Dictionary<int, Country>();

        /// <summary>
        /// returns where and how many troops assign separated by "|"
        /// </summary>
        /// <param name="Countries"></param>
        /// <returns></returns>
        public List<string> SetWhereAssignTroops(Dictionary<int, Country> countries)
        {
            Countries = countries;
            List<int> AICountries = getPlayerCountries(2); //countries ids 
            int TroopsAvailable = TroopdforAssign(2);
            List<string> movements = new List<string>();

            int temp = 0;

            #region If the AI have nearby enemies
            if (NearbyEnemies()) // If the AI have nearby enemies
            {
                List<int> NearbyEnemiesIDs = new List<int>(); //Neighbor Enemies
                List<int> NearbyEnemiesTroopsCount = new List<int>(); //Neighbor Enemies
                List<int> NeighborsIDs = getPlayerNeighbors(2);
                Dictionary<int, double> priority = new Dictionary<int, double>(); // percentage
                int totalEnemyTroops = 0;
                for (int i = 0; i < NeighborsIDs.Count(); i++)
                    if (countries[NeighborsIDs[i]].Owner == 1)
                    {
                        NearbyEnemiesIDs.Add(NeighborsIDs[i]);
                        NearbyEnemiesTroopsCount.Add(countries[NeighborsIDs[i]].TroopsCount);
                        totalEnemyTroops += countries[NeighborsIDs[i]].TroopsCount;
                    }

                for (int i = 0; i < NearbyEnemiesIDs.Count(); i++)
                {
                    priority.Add(NearbyEnemiesIDs[i], (NearbyEnemiesTroopsCount[i] / totalEnemyTroops) * 100); // ID, percentage
                }
                var prioritylst = priority.Keys.ToList(); // id, percentage
                prioritylst.Sort();


                foreach (var key in prioritylst)
                {
                    if (TroopsAvailable != 0)
                    {
                        temp = Convert.ToInt16(Math.Round(priority[key] * TroopsAvailable, MidpointRounding.AwayFromZero));
                        movements.Add(key.ToString() + "|" + temp);
                    }
                }

                return movements;
            }
            #endregion

            #region If the AI dont have nearby enemies
            List<int> PriorityAlliesIDs = getTopNear();
            int a = Convert.ToInt16(Math.Round(TroopsAvailable * 0.5, MidpointRounding.AwayFromZero)); //give the half to the nearest 
            int b = Convert.ToInt16(Math.Round(TroopsAvailable * 0.25, MidpointRounding.AwayFromZero));//give 1/4 for the other two nearest

            movements.Add(PriorityAlliesIDs[0].ToString() + "|" + a.ToString());
            movements.Add(PriorityAlliesIDs[1].ToString() + "|" + b.ToString());
            movements.Add(PriorityAlliesIDs[2].ToString() + "|" + b.ToString());

            return movements;
            #endregion
        }
        /// <summary>
        /// returns from, how many troops and where  to move/atack separated by "|"
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public List<string> SetWhereToMove(Dictionary<int, Country> countries)
        {
            Countries = countries;
            List<string> movements = new List<string>();
            #region War phase
            //if (NearbyEnemies())
            //{

            //    return movements;
            //}
            #endregion
            #region Peace times
            List<int> AICentre = getCentreBorderCountries(true); //move the troops from the inside
            for (int i = 0; i < AICentre.Count(); i++)
            {
                if (countries[AICentre[i]].TroopsCount != 0)//move troops to border
                    movements.Add(AICentre[i] + "|" + countries[AICentre[i]].TroopsCount + "|" + GetNearestCountry(AICentre[i]));
            }
            List<int> AIBorder = getCentreBorderCountries(false); // move the troops from the border
            //List<int> VistitedNeighbors = new List<int>();
            int tempN = 0;
            for (int i = 0; i < AIBorder.Count(); i++)
            {
                tempN = GetNearestCountry(AIBorder[i]);
                if (countries[AIBorder[i]].TroopsCount > countries[tempN].TroopsCount)//move troops from the border if it a secure win
                    movements.Add(AIBorder[i] + "|" + countries[AIBorder[i]].TroopsCount + "|" + tempN);
                else
                {
                    movements.Add(AIBorder[i] + "|" + countries[AIBorder[i]].TroopsCount + "|" + getWeakestEnemy(AIBorder[i])); 
                }
            }
            return movements;
            #endregion
        }



        #region Important Stuff

        /// <summary>
        /// get the neighbor with less troops
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        public int getWeakestEnemy(int countryID)
        {
            int result = 0;
            int weakesttroops = 100;
            int temp = 0;
            List<int> neighborsint = Countries[countryID].Neighborsint;
            for (int i = 0; i < neighborsint.Count(); i++)
            {
                if(Countries[neighborsint[i]].Owner != 2)
                {
                    temp = Countries[neighborsint[i]].TroopsCount;
                    if (temp < weakesttroops)
                    {
                        weakesttroops = temp;
                        result = neighborsint[i];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// get the nearest enemy country for the AI
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        public int GetNearestCountry(int countryID)
        {
            int dist = 100;
            int result = 0;
            int temp = 0;
            for (int i = 0; i < Countries[countryID].Neighborsint.Count(); i++)
            {
                temp = getDistance(Countries[countryID].Neighborsint[i]); //distance to the nearest enemy (player 1)
                if(temp < dist)
                {
                    dist = temp;
                    result = Countries[countryID].Neighborsint[i];
                }
            }
            return result;
        }

        /// <summary>
        /// get if the AI have nearby enemies
        /// </summary>
        /// <returns></returns>
        public bool NearbyEnemies()
        {
            List<int> AINeighbors = getPlayerNeighbors(2);
            for (int i = 0; i < AINeighbors.Count(); i++)
                if (Countries[AINeighbors[i]].Owner == 1)
                    return true;
            return false;
        }

        /// <summary>
        /// get a sort list of the AI counties that have the nearest enemy
        /// </summary>
        /// <returns></returns>
        public List<int> getTopNear()
        {
            List<int> result = new List<int>();
            Dictionary<int, int> NearEnemies = new Dictionary<int, int>(); // ID, Distance
            List<int> AIcountiresIDs = getPlayerCountries(2);

            for (int i = 0; i < AIcountiresIDs.Count(); i++)
                NearEnemies.Add(AIcountiresIDs[i], getDistance(AIcountiresIDs[i]));

            var prioritylst = NearEnemies.Keys.ToList();
            prioritylst.Sort();

            foreach (var key in prioritylst)
                result.Add(key);

            return result;
        }

        /// <summary>
        /// if true get all the AI countries that are in the middle of the empire.
        /// if false  get all the AI countries that have a neutral or a enemy near.
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public List<int> getCentreBorderCountries(bool flag)
        {
            List<int> AICountries = getPlayerCountries(2);
            List<int> CentreCountries = new List<int>();
            List<int> BorderCountries = new List<int>();

            for (int i = 0; i < AICountries.Count(); i++)
            {
                if (haveEnemies(AICountries[i]))
                    BorderCountries.Add(AICountries[i]);
                else
                    CentreCountries.Add(AICountries[i]);

            }
            if(flag)
                return CentreCountries;
            return BorderCountries;
        }

        #endregion

        #region Stuff

        public bool haveEnemies(int countryID)
        {
            for (int i = 0; i < Countries[countryID].Neighborsint.Count(); i++)
            {
                if (Countries[Countries[countryID].Neighborsint[i]].Owner !=2)// 1 & 0 are the enemy for the AI
                    return true;
            }
            return false;
        }

        public List<int> getPlayerNeighbors(int player)
        {
            List<int> AICountries = getPlayerCountries(player); //countries ids list
            List<int> AINeighbors = new List<int>();

            for (int i = 0; i < AICountries.Count(); i++)
                foreach (var C in Countries[AICountries[i]].Neighborsint)
                    if (!AINeighbors.Contains(C))
                        AINeighbors.Add(C);
            return AINeighbors;
        }

        public List<int> getPlayerCountries(int player) // number of the player who owns that country, 0 if its neutral 
        {
            List<int> t = new List<int>(); //countries ids list
            for (int i = 1; i <= Countries.Count(); i++)
            {
                if (Countries[i].Owner == player)
                    t.Add(i);//.ToString() + "|" + Countries[i].CountryName);
            }
            return t;// ID
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
        #endregion

        #region Dijkstra
        public Graph<int, string> CountriesGraph = new Graph<int, string>();
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
                    CountriesGraph.Connect(Convert.ToUInt16(i - 1), to, cost, "fuck yeah");
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
        /// <summary>
        /// get the distance from the selected country to the nearest enemy
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        public int getDistance(int countryID)
        {
            int temp = 100;
            List<int> temporallsy = getPlayerCountries(1);
            List<int> result = new List<int>();

            for (int i = 0; i < temporallsy.Count(); i++)
            {
                result.Add(CalulateDistanceDijkstra(countryID, temporallsy[i]));
            }
            temp = result.Min();
            return temp;
        }
        #endregion

    }
}