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
                new Dojo{ Adress = "Östermalmsgatan 26A", Company = "Iteam", Start = new DateTime(2018,09,08,10,0,0)},
                new Dojo{ Adress = "Östermalmsgatan 26A", Company = "Iteam", Start = new DateTime(2018,09,15,10,0,0)},
                new Dojo{ Adress = "Årstaängsvägen 21B, 5tr", Company = "Cisco", Start = new DateTime(2018,10,06,10,0,0)},
                new Dojo{ Adress = "Årstaängsvägen 21B, 5tr", Company = "Cisco", Start = new DateTime(2018,10,13,10,0,0)},
                new Dojo{ Adress = "Årstaängsvägen 21B, 5tr", Company = "Cisco", Start = new DateTime(2018,10,20,10,0,0)},
                new Dojo{ Adress = "Drottninggatan 95A", Company = "Dynabyte", Start = new DateTime(2018,11,10,10,0,0)},
                new Dojo{ Adress = "Kungstensgatan 23", Company = "Active Solution", Start = new DateTime(2018,11,17,10,0,0)},
                new Dojo{ Adress = "Kungstensgatan 23", Company = "Active Solution", Start = new DateTime(2018,11,24,10,0,0)},
                new Dojo{ Adress = "Drottninggatan 95A", Company = "Dynabyte", Start = new DateTime(2018,12,01,10,0,0)},
                new Dojo{ Adress = "Frösundaleden 2", Company = "ÅF", Start = new DateTime(2018,12,08,10,0,0)},
                new Dojo{ Adress = "Frösundaleden 2", Company = "ÅF", Start = new DateTime(2018,12,15,10,0,0)},
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