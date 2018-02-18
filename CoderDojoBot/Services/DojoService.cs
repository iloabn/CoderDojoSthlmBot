using CoderDojoBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoderDojoBot.Services
{
    public static class DojoService
    {
        public static List<Dojo> GetDojos()
        {
            var dojos = new List<Dojo>()
            {
                new Dojo{ Adress = "Östermalmsgatan 26A", Company = "Iteam", Start = new DateTime(2018,02,03,10,0,0)},
                new Dojo{ Adress = "Östermalmsgatan 26A", Company = "Iteam", Start = new DateTime(2018,02,10,10,0,0)},
                new Dojo{ Adress = "Östermalmsgatan 26A", Company = "ÅF", Start = new DateTime(2018,03,10,10,0,0)},
                new Dojo{ Adress = "Sveavägen 46", Company = "Klarna", Start = new DateTime(2018,03,17,10,0,0)},
                new Dojo{ Adress = "Sveavägen 46", Company = "Klarna", Start = new DateTime(2018,03,24,10,0,0)},
                new Dojo{ Adress = "Drottninggatan 71D", Company = "iStone", Start = new DateTime(2018,04,14,10,0,0)},
            };

            var wednesdayStart = new DateTime(2018, 02, 03, 17, 30, 0);

            while (wednesdayStart < new DateTime(2018, 06, 08))
            {
                wednesdayStart = wednesdayStart.AddDays(7);
                dojos.Add(new Dojo { Adress = "Hammarby Kaj 10D", Company = "FooCafe", Start = wednesdayStart, End = wednesdayStart.AddHours(1.5) });
            }

            return dojos.OrderBy(dojo => dojo.Start).ToList();
        }

        public static Dojo GetNextDojo()
        {
            return GetDojos().First(d => d.IsFuture);
        }
    }
}