using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using simplyRiskGame.Models;

namespace simplyRiskGame.Controllers
{
    public class HomeController : Controller
    {
        public static CountriesManager manager = new CountriesManager();
        DecisionTree DTree = new DecisionTree();

        public int[] rowNumbers = new int[3];
        public string path = "D:/GitHub/SECOND/Juego-Risk/dataSet.xlsx";
        public static List<int> initialiceCountries = new List<int>();

        public HomeController() {

        }
        public ActionResult Index()
        {
            manager = new CountriesManager();
            initialiceCountries = new List<int>();
            ViewBag.myTroopLimit = manager.TroopdforAssign(1);
            ViewBag.IATroopLimit = manager.TroopdforAssign(2);

            return View();
        }

        private bool nearbyCountry(int actualCountry, int nearCountry)
        {
            if (manager.Countries[actualCountry].Neighborsint.Contains(nearCountry))
                return true;
            return false;

            #region  switch
            //bool verifyNearbyCountry = false;
            //switch (actualCountry)
            //{
            //    case 1:
            //        if (nearCountry == 2 || nearCountry == 6 || nearCountry == 32)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 2:
            //        if (nearCountry == 1 || nearCountry == 6 || nearCountry == 7 || nearCountry == 9)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 3:
            //        if (nearCountry == 9 || nearCountry == 4 || nearCountry == 13)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 4:
            //        if (nearCountry == 9 || nearCountry == 3 || nearCountry == 7 || nearCountry == 8)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 5:
            //        if (nearCountry == 6 || nearCountry == 7 || nearCountry == 8 || nearCountry == 21)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 6:
            //        if (nearCountry == 1 || nearCountry == 2 || nearCountry == 7 || nearCountry == 5)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 7:
            //        if (nearCountry == 5 || nearCountry == 6 || nearCountry == 2 || nearCountry == 9 || nearCountry == 4 || nearCountry == 8)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 8:
            //        if (nearCountry == 5 || nearCountry == 4 || nearCountry == 7)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 9:
            //        if (nearCountry == 2 || nearCountry == 4 || nearCountry == 3 || nearCountry == 7)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 10:
            //        if (nearCountry == 12 || nearCountry == 11)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 11:
            //        if (nearCountry == 10 || nearCountry == 12 || nearCountry == 13 || nearCountry == 18)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 12:
            //        if (nearCountry == 10 || nearCountry == 11 || nearCountry == 13)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 13:
            //        if (nearCountry == 3 || nearCountry == 12 || nearCountry == 11)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 14:
            //        if (nearCountry == 19 || nearCountry == 15 || nearCountry == 18)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 15:
            //        if (nearCountry == 17 || nearCountry == 19 || nearCountry == 14 || nearCountry == 18 || nearCountry == 16)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 16:
            //        if (nearCountry == 24 || nearCountry == 18 || nearCountry == 15 || nearCountry == 33)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 17:
            //        if (nearCountry == 19 || nearCountry == 15)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 18:
            //        if (nearCountry == 11 || nearCountry == 26 || nearCountry == 24 || nearCountry == 14 || nearCountry == 15 || nearCountry == 16)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 19:
            //        if (nearCountry == 14 || nearCountry == 15 || nearCountry == 17)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 20:
            //        if (nearCountry == 26 || nearCountry == 22 || nearCountry == 23 || nearCountry == 21)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 21:
            //        if (nearCountry == 5 || nearCountry == 20 || nearCountry == 23)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 22:
            //        if (nearCountry == 26 || nearCountry == 24 || nearCountry == 25 || nearCountry == 23 || nearCountry == 20)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 23:
            //        if (nearCountry == 21 || nearCountry == 20 || nearCountry == 22 || nearCountry == 25)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 24:
            //        if (nearCountry == 18 || nearCountry == 16 || nearCountry == 26 || nearCountry == 22 || nearCountry == 25 || nearCountry == 33)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 25:
            //        if (nearCountry == 23 || nearCountry == 22 || nearCountry == 24 || nearCountry == 33 || nearCountry == 27 || nearCountry == 37)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 26:
            //        if (nearCountry == 18 || nearCountry == 20 || nearCountry == 22 || nearCountry == 24)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 27:
            //        if (nearCountry == 25 || nearCountry == 33 || nearCountry == 37 || nearCountry == 28 || nearCountry == 29)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 28:
            //        if (nearCountry == 34 || nearCountry == 35 || nearCountry == 27 || nearCountry == 29)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 29:
            //        if (nearCountry == 33 || nearCountry == 27 || nearCountry == 28 || nearCountry == 35)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 30:
            //        if (nearCountry == 32 || nearCountry == 38 || nearCountry == 36 || nearCountry == 34)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 31:
            //        if (nearCountry == 32 || nearCountry == 34)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 32:
            //        if (nearCountry == 1 || nearCountry == 38 || nearCountry == 30 || nearCountry == 34 || nearCountry == 31)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 33:
            //        if (nearCountry == 16 || nearCountry == 24 || nearCountry == 25 || nearCountry == 27 || nearCountry == 29)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 34:
            //        if (nearCountry == 30 || nearCountry == 31 || nearCountry == 32 || nearCountry == 36 || nearCountry == 28)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 35:
            //        if (nearCountry == 28 || nearCountry == 29 || nearCountry == 40)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 36:
            //        if (nearCountry == 37 || nearCountry == 38 || nearCountry == 30 || nearCountry == 28 || nearCountry == 34)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 37:
            //        if (nearCountry == 25 || nearCountry == 27 || nearCountry == 28 || nearCountry == 36)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 38:
            //        if (nearCountry == 32 || nearCountry == 30 || nearCountry == 36)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 39:
            //        if (nearCountry == 42 || nearCountry == 41)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 40:
            //        if (nearCountry == 42 || nearCountry == 41 || nearCountry == 35)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 41:
            //        if (nearCountry == 40 || nearCountry == 42 || nearCountry == 39)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    case 42:
            //        if (nearCountry == 40 || nearCountry == 41 || nearCountry == 39)
            //        {
            //            verifyNearbyCountry = true;
            //        }
            //        break;
            //    default:
            //        verifyNearbyCountry = false;
            //        break;
            //}

            //return verifyNearbyCountry;
            #endregion

        }


        [HttpPost]
        /// <summary>
        /// This method returns if the country belongs to the player.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public ActionResult isTheCountryMine(int player, int country)
        {
            bool response = manager.Countries[country].Owner == player;
            return Json(new { belongs = response });
        }

        [HttpPost]
        public ActionResult nearbyCountryJson(int actualCountry, int nearCountry)
        {
            return Json(new { isNear = nearbyCountry(actualCountry, nearCountry) });
        }





        [HttpPost]
        public ActionResult initialCountries()
        {
            int number = 0;
            int countryNumberPlayer = 0;
            int countryNumberIA = 0;
            Random random = new Random();

            number = random.Next(3, 5);

            //ARRAY WITH THE INITIAL COUNTRIES FOR THE PLAYER
            int[] countriesPlayer = new int[number];
            //IA
            int[] countriesIA = new int[number];

            countriesPlayer[0] = 0;
            countriesIA[0] = 0;

            while (countriesPlayer.Contains(0) || countriesIA.Contains(0))
            {
                countryNumberPlayer = random.Next(1, 42);
                countriesPlayer[0] = countryNumberPlayer;

                for (int i = 1; i < number; i++)
                {
                    int temp = 0;
                    temp = random.Next(1, 42);
                    if (nearbyCountry(countryNumberPlayer, temp) && !countriesPlayer.Contains(temp))
                    {
                        countriesPlayer[i] = temp;
                    }
                    else
                    {
                        countriesPlayer[i] = 0;
                        i--;
                    }
                }

                //ARRAY WITH THE INITITAL COUNTRIES FOR THE IA

                countriesIA[0] = countryNumberIA;
                bool condition = true;
                while (condition)
                {
                    if (!countriesPlayer.Contains(countryNumberIA))

                    {
                        countryNumberIA = random.Next(1, 42);
                        if (!countriesPlayer.Contains(countryNumberIA))
                        {
                            countriesIA[0] = countryNumberIA;
                            condition = false;
                        }
                        else
                        {
                            condition = true;
                        }
                    }
                    for (int i = 1; i < number; i++)
                    {
                        int temp = 0;
                        temp = random.Next(1, 42);
                        if (nearbyCountry(countryNumberIA, temp) && !countriesPlayer.Contains(temp) && !countriesIA.Contains(temp))
                        {

                            countriesIA[i] = temp;
                        }
                        else
                        {
                            countriesIA[i] = 0;
                            i--;
                        }
                    }
                }


                foreach (var c in countriesIA)

                {
                    manager.Countries[c].Owner = 2;
                    initialiceCountries.Add(c);
                }

                foreach (var c in countriesPlayer)
                {
                    manager.Countries[c].Owner = 1;
                    initialiceCountries.Add(c);
                }
    
            }
            return Json(new { enemy = countriesIA, player = countriesPlayer });
        }

        [HttpPost]
        public ActionResult getMovementLogbook(string _data, bool player = false)
        {

            string[] data = _data.Split('|');
            var country1 = 0;
            var country2 = 0;
            string troopsNumber = data[2];
            string values = "";


            if (player)
            {
                for (int i = 1; i <= manager.Countries.Count; i++)
                {
                    //get deployer's country id
                    if (manager.Countries[i].CountryName == data[0])
                    {
                        manager.Countries[i].TroopsCount -= int.Parse(data[2]);
                        country1 = manager.Countries[i].CountryID;
                    }
                    //get receiver's country id
                    if (manager.Countries[i].CountryName == data[1])
                        country2 = manager.Countries[i].CountryID;
                }
            }
            else
            {
                country1 = int.Parse(data[0]);
                country2 = int.Parse(data[2]);
            }

            // look if the countries are neighbors
            int[] troops = manager.getNeighborsTroopsCount(country1, manager.Countries[country1].Owner);
            if (manager.Countries[country1].Owner == 1)
            {
                rowNumbers[1]++;
            }
            else
            {
                rowNumbers[2]++;
            }
            if (manager.getNeighborsAlly(country1, manager.Countries[country1].Owner).Contains(country2))
            {
                manager.Countries[country2].TroopsCount += int.Parse(data[2]);
                values = "1";
            }
            // neutral or enemies
            else
            {
                // condition if the country was conquered
                if (manager.Countries[country2].TroopsCount < int.Parse(data[2]))
                {
                    manager.Countries[country2].Owner = manager.Countries[country1].Owner;
                    values = "1";
                }
                // still neutral or enemy 
                else
                    values = "0";

                manager.Countries[country2].TroopsCount = Math.Abs(int.Parse(data[2]) - manager.Countries[country2].TroopsCount);
                //manager.Countries[country2].TroopsCount = Math.Abs(manager.Countries[country2].TroopsCount - int.Parse(data[2]));

            }
            // values = one if the country was conquered + id deployer + deployer remaining troops + id receiver + receiver remaining troops + player
            values += "|" + country1 + "|" + manager.Countries[country1].TroopsCount + "|" + country2 + "|" +
               manager.Countries[country2].TroopsCount + "|" + manager.Countries[country1].Owner;


            return Json(new { _values = values });
        }

        [HttpPost]
        public ActionResult getNewTroops(string _data)// ID, Troops count
        {
            string[] temp = _data.Split('|');
            int id = int.Parse(temp[0]);
            int[] neighbors = manager.getNeighborsCount(id, manager.Countries[id].Owner);
            int[] troops = manager.getNeighborsTroopsCount(int.Parse(temp[0]), manager.Countries[int.Parse(temp[0])].Owner);
            int priority = int.Parse(temp[1]) * manager.TroopdforAssign(1) / 100;
            manager.Countries[Convert.ToInt16(temp[0])].TroopsCount = Convert.ToInt16(temp[1]);

           

            return Json(new { something = true });
        }

        [HttpPost]
        public ActionResult troopsAssign(int troopsAmount)
        {
            int[] troops;
            if (troopsAmount == 0)
            {
                troops = new int[1];
                troops[0] = 0;
            }
            else
            {
                troops = new int[troopsAmount + 1];
                troops[0] = troopsAmount;
                int temp = troopsAmount - 1;
                for (int i = 1; i < troops.Length; i++)
                {
                    troops[i] = temp;
                    temp = temp - 1;
                }
            }

            return Json(new { troopsOptions = troops });
        }

        [HttpPost]
        public ActionResult getIdByName(string name)
        {
            int _id = manager.getIDbyName(name);
            return Json(new { id = _id });
        }  

        /// <summary>
        /// this method returns the troop number of each country
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult countryTroops()
        {
            int[] TroopsCount = new int[42];
            Random rnd = new Random();
            int troops = 0;
            for (int i = 0; i < 42; i++)
            {
                troops = rnd.Next(2, 5);
                TroopsCount[i] = troops;
                manager.Countries[i + 1].TroopsCount = troops;
            }
            return Json(new { initialTroops = TroopsCount });
        }

        [HttpPost]
        public ActionResult playerCountries(int player)
        {
            var countriesList = manager.getPlayerCountries(player);
            return Json(new { countries = countriesList });
        }

        [HttpPost]
        public ActionResult getNeighboor(string country)
        {
            var ListNeighboor = manager.getNeighborsstr(country);
            return Json(new { Neighboor = ListNeighboor });
        }

        [HttpPost]
        public ActionResult getTroopNumber(string country)
        {
            var number_ = manager.getTroopsCount(country);
            return Json(new { number = number_ });
        }

        [HttpPost]
        public ActionResult assignTroops()
        {
            //ViewBag.myTroopLimit = manager.TroopdforAssign(1);
            ViewBag.IATroopLimit = manager.TroopdforAssign(2);
            var troops = manager.TroopdforAssign(1);
            return Json(new { Troops = troops });
        }

        /// <summary>
        /// this method returns the movements of country
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult enemyMovements()
        {
            var assign_ = DTree.SetWhereAssignTroops(manager.Countries); //31|2
            Update(assign_);
            var movements_ = DTree.SetWhereToMove(manager.Countries); //31|2|32

            var result = "";
            foreach (var m in movements_) {
                result += getMovementLogbook_(m)+"*";
            }


            return Json(new { assign = assign_, movements = result });
        }

        private void Update(List<string> moves) {

            for (int i = 0; i < moves.Count(); i++) {
                string[] temp = moves[i].Split('|');
                manager.Countries[int.Parse(temp[0])].TroopsCount += int.Parse(temp[1]); 
            }

        }

        public string getMovementLogbook_ (string _data, bool player = false)
        {
            string[] data = _data.Split('|');
            var country1 = 0;
            var country2 = 0;
            string troopsNumber = data[2];
            string values = "";

            if (player)
            {
                for (int i = 1; i <= manager.Countries.Count; i++)
                {
                    //get deployer's country id
                    if (manager.Countries[i].CountryName == data[0])
                    {
                        manager.Countries[i].TroopsCount -= int.Parse(data[2]);
                        country1 = manager.Countries[i].CountryID;
                    }
                    //get receiver's country id
                    if (manager.Countries[i].CountryName == data[1])
                        country2 = manager.Countries[i].CountryID;
                }
            }
            else
            {
                country1 = int.Parse(data[0]);
                manager.Countries[country1].TroopsCount -= int.Parse(data[2]);
                country2 = int.Parse(data[1]);
            }

            // look if the countries are neighbors
            int[] troops = manager.getNeighborsTroopsCount(country1, manager.Countries[country1].Owner);
            if (manager.Countries[country1].Owner == 1)
            {

                rowNumbers[1]++;
            }
            else
            {

                rowNumbers[2]++;
            }
            if (manager.getNeighborsAlly(country1, manager.Countries[country1].Owner).Contains(country2))
            {
                manager.Countries[country2].TroopsCount += int.Parse(data[2]);
                values = "1";
            }
            // neutral or enemies
            else
            {
                // condition if the country was conquered
                if (manager.Countries[country2].TroopsCount < int.Parse(data[2]))
                {
                    manager.Countries[country2].Owner = manager.Countries[country1].Owner;
                    values = "1";
                }
                // still neutral or enemy 
                else
                    values = "0";

                manager.Countries[country2].TroopsCount = Math.Abs(int.Parse(data[2]) - manager.Countries[country2].TroopsCount);
                //manager.Countries[country2].TroopsCount = Math.Abs(manager.Countries[country2].TroopsCount - int.Parse(data[2]));

            }
            // values = one if the country was conquered + id deployer + deployer remaining troops + id receiver + receiver remaining troops + player
            values += "|" + country1 + "|" + manager.Countries[country1].TroopsCount + "|" + country2 + "|" +
               manager.Countries[country2].TroopsCount + "|" + manager.Countries[country1].Owner;


            return values;
        }

        [HttpGet]

        public ActionResult getWinner()
        {

            if (manager.getPlayerCountries(1).Count() == 0)
            {
                return Json(new { redirect = "https://photos.bandsintown.com/thumb/6285178.jpeg" }, JsonRequestBehavior.AllowGet);
            }
            else if (manager.getPlayerCountries(2).Count() == 0)
            {
                return Json(new { redirect = "https://ih1.redbubble.net/image.113831110.0284/flat,550x550,075,f.u4.jpg" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { hello = true });
            }
            return Json(new { hello = true });
        }

        /*
          1) Colocar lineas de union entre paises (vista) o arreglar los paises??? fuck no se... pero uno se confunde
          2) Al iniciar no siempre cargan los paises
          3) Indicar Fin de juego (ganador y perdedor)
         */
    }
}