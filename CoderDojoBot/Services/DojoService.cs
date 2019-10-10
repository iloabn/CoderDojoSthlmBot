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
                new Dojo{ Adress = "Barks Väg 15", Company = "IF", Start = new DateTime(2019,11,09,10,0,0)},
                new Dojo{ Adress = "Barks Väg 15", Company = "IF", Start = new DateTime(2019,12,07,10,0,0)},
                new Dojo{ Adress = "Hantverkargatan 5", Company = "Valtech", Start = new DateTime(2019,10,12,10,0,0)},
                new Dojo{ Adress = "Sveavägen 13", Company = "Wise IT", Start = new DateTime(2019,10,19,10,0,0)},
                new Dojo{ Adress = "Årstaängsvägen 21B", Company = "Cisco", Start = new DateTime(2019,11,16,10,0,0)},
                new Dojo{ Adress = "Årstaängsvägen 21B", Company = "Cisco", Start = new DateTime(2019,11,23,10,0,0)},
                new Dojo{ Adress = "Regeringsgatan 29", Company = "Netlight", Start = new DateTime(2019,11,23,10,0,0)},
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