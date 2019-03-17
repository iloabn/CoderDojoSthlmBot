using CoderDojoBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoderDojoBot.Services
{
    public static class DojoService
    {
        public static List<Dojo> GetDojos()
        {
            var dojos = new List<Dojo>()
            {
                new Dojo{ Adress = "", Company = "Columbus OR Nordea", Start = new DateTime(2019,03,16,10,0,0)},
                new Dojo{ Adress = "Smålandsgatan 15", Company = "Nordea", Start = new DateTime(2019,03,23,10,0,0)},
                new Dojo{ Adress = "Drottninggatan 71D", Company = "Columbus", Start = new DateTime(2019,03,30,10,0,0)},
                new Dojo{ Adress = "Drottninggatan 95A", Company = "Dynabyte", Start = new DateTime(2019,03,09,10,0,0)},
                new Dojo{ Adress = "", Company = "Valtech", Start = new DateTime(2019,05,04,10,0,0)},
                new Dojo{ Adress = "Drottninggatan 95A", Company = "Dynabyte", Start = new DateTime(2019,05,11,10,0,0)},
                new Dojo{ Adress = "", Company = "Valtech", Start = new DateTime(2019,05,18,10,0,0)},
            };

            dojos.Add(new Dojo { Adress = "Hammarby Kaj 10D", Company = "FooCafe", Start = new DateTime(2018, 09, 12, 17, 30, 0), End = new DateTime(2018, 09, 12, 17, 30, 0).AddHours(1.5) });
            dojos.Add(new Dojo { Adress = "Hammarby Kaj 10D", Company = "FooCafe", Start = new DateTime(2018, 09, 19, 17, 30, 0), End = new DateTime(2018, 09, 12, 17, 30, 0).AddHours(1.5) });

            //var wednesdayStart = new DateTime(2018, 04, 11, 17, 30, 0);
            //do
            //{
            //    wednesdayStart = wednesdayStart.AddDays(7);
            //    dojos.Add(new Dojo { Adress = "Hammarby Kaj 10D", Company = "FooCafe", Start = wednesdayStart, End = wednesdayStart.AddHours(1.5) });
            //} while (wednesdayStart < new DateTime(2018, 06, 08));

            return dojos.OrderBy(dojo => dojo.Start).ToList();
        }

        public static Dojo GetNextDojo()
        {
            return GetDojos().First(d => d.IsFuture);
        }
    }
}