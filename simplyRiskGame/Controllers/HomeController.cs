using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace simplyRiskGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.myTroopLimit = 10;
            ViewBag.IATroopLimit = 10;
            return View();
        }

        //this methods are called with ajax
        [HttpPost]
        public ActionResult commit()
        {
            return Json(new { success = false, });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public bool nearbyCountry(int actualCountry, int nearCountry)
        {
            bool verifyNearbyCountry = false;

            switch(actualCountry)
            {
                case 1:
                    if(nearCountry == 2 || nearCountry == 6 || nearCountry == 32)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 2:
                    if (nearCountry == 1 || nearCountry == 6 || nearCountry == 7 || nearCountry == 9)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 3:
                    if (nearCountry == 9 || nearCountry == 4 || nearCountry == 13)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 4:
                    if (nearCountry == 9 || nearCountry == 3 || nearCountry == 7 || nearCountry == 8)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 5:
                    if (nearCountry == 6 || nearCountry == 7 || nearCountry == 8 || nearCountry == 21)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 6:
                    if (nearCountry == 1 || nearCountry == 2 || nearCountry == 7 || nearCountry == 5)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 7:
                    if (nearCountry == 5 || nearCountry == 6 || nearCountry == 2 || nearCountry == 9 || nearCountry == 4 || nearCountry == 8)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 8:
                    if (nearCountry == 5 || nearCountry == 4 || nearCountry == 7)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 9:
                    if (nearCountry == 2 || nearCountry == 4 || nearCountry == 3 || nearCountry == 7)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 10:
                    if (nearCountry == 12 || nearCountry == 11)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 11:
                    if (nearCountry == 10 || nearCountry == 12 || nearCountry == 13 || nearCountry == 18)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 12:
                    if (nearCountry == 10 || nearCountry == 11 || nearCountry == 13)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 13:
                    if (nearCountry == 3 || nearCountry == 12 || nearCountry == 11)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 14:
                    if (nearCountry == 19 || nearCountry == 15 || nearCountry == 18)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 15:
                    if (nearCountry == 17 || nearCountry == 19 || nearCountry == 14 || nearCountry == 18 || nearCountry == 16)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 16:
                    if (nearCountry == 24 || nearCountry == 18 || nearCountry == 15 || nearCountry == 33)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 17:
                    if (nearCountry == 19 || nearCountry == 15)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 18:
                    if (nearCountry == 11 || nearCountry == 26 || nearCountry == 24 || nearCountry == 14 || nearCountry == 15 || nearCountry == 16)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 19:
                    if (nearCountry == 14 || nearCountry == 15 || nearCountry == 17)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 20:
                    if (nearCountry == 26 || nearCountry == 22 || nearCountry == 23 || nearCountry == 21)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 21:
                    if (nearCountry == 5 || nearCountry == 20 || nearCountry == 23)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 22:
                    if (nearCountry == 26 || nearCountry == 24 || nearCountry == 25 || nearCountry == 23 || nearCountry == 20)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 23:
                    if (nearCountry == 21 || nearCountry == 20 || nearCountry == 22 || nearCountry == 25)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 24:
                    if (nearCountry == 18 || nearCountry == 16 || nearCountry == 26 || nearCountry == 22 || nearCountry == 25 || nearCountry == 33)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 25:
                    if (nearCountry == 23 || nearCountry == 22 || nearCountry == 24 || nearCountry == 33 || nearCountry == 27 || nearCountry == 37)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 26:
                    if (nearCountry == 18 || nearCountry == 20 || nearCountry == 22 || nearCountry == 24)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 27:
                    if (nearCountry == 25 || nearCountry == 33 || nearCountry == 37 || nearCountry == 28 || nearCountry == 29)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 28:
                    if (nearCountry == 34 || nearCountry == 35 || nearCountry == 27 || nearCountry == 29)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 29:
                    if (nearCountry == 33 || nearCountry == 27 || nearCountry == 28 || nearCountry == 35)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 30:
                    if (nearCountry == 32 || nearCountry == 38 || nearCountry == 36 || nearCountry == 34)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 31:
                    if (nearCountry == 32 || nearCountry == 34)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 32:
                    if (nearCountry == 1 || nearCountry == 38 || nearCountry == 30 || nearCountry == 34 || nearCountry == 31)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 33:
                    if (nearCountry == 16 || nearCountry == 24 || nearCountry == 25 || nearCountry == 27 || nearCountry == 29)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 34:
                    if (nearCountry == 30 || nearCountry == 31 || nearCountry == 32 || nearCountry == 36 || nearCountry == 28)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 35:
                    if (nearCountry == 28 || nearCountry == 29 || nearCountry == 40)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 36:
                    if (nearCountry == 37 || nearCountry == 38 || nearCountry == 30 || nearCountry == 28 || nearCountry == 34)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 37:
                    if (nearCountry == 25 || nearCountry == 27 || nearCountry == 28 || nearCountry == 36)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 38:
                    if (nearCountry == 32 || nearCountry == 30 || nearCountry == 36)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 39:
                    if (nearCountry == 42 || nearCountry == 41)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 40:
                    if (nearCountry == 42 || nearCountry == 41 || nearCountry == 35)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 41:
                    if (nearCountry == 40 || nearCountry == 42 || nearCountry == 39)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                case 42:
                    if (nearCountry == 40 || nearCountry == 41 || nearCountry == 39)
                    {
                        verifyNearbyCountry = true;
                    }
                    break;
                default:
                    verifyNearbyCountry = false;
                    break;
            }

            return verifyNearbyCountry;
        }

        public int[] initialCountries()
        {
            int number = 0;
            int countryNumberPlayer = 0;
            int countryNumberIA = 0;
            Random random = new Random();
            number = random.Next(3, 5);

            //ARRAY WITH THE INITIAL COUNTRIES FOR THE PLAYER
            int[] countriesPlayer = new int[number];

            countryNumberPlayer = random.Next(1, 42);
            countriesPlayer[0] = countryNumberPlayer;

            for (int i = 1; i < number; i++)
            {
                int temp = 0;
                temp = random.Next(1, 42);
                if (nearbyCountry(countryNumberPlayer, temp) == true && !countriesPlayer.Contains(temp))
                {
                    countriesPlayer[i] = temp;
                }
                else
                {
                    i--;
                }
            }

            //ARRAY WITH THE INITITAL COUNTRIES FOR THE IA
            int[] countriesIA = new int[number];

            countryNumberIA = random.Next(1, 42);
            countriesIA[0] = countryNumberPlayer;
            countriesIA[0] = 0;
            while (countriesIA[0] == 0)
            {
                if (!countriesPlayer.Contains(countryNumberIA))
                {
                    countriesIA[0] = countryNumberIA;
                }
                else
                {
                    countriesIA[0] = 0;
                }
            }
            for (int i = 1; i < number; i++)
            {
                int temp = 0;
                temp = random.Next(1, 42);
                if (nearbyCountry(countryNumberIA, temp) == true && !countriesPlayer.Contains(temp) && !countriesIA.Contains(temp))
                {
                    countriesIA[i] = temp;
                }
                else
                {
                    i--;
                }
            }

            return countriesPlayer;
        }
    }
}