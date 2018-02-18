using CoderDojoBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CoderDojoBot.Dialogs
{
    [Serializable]
    public class DojoDialog : LuisDialog<object>
    {
        public DojoDialog() : base(new LuisService( new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"],
            ConfigurationManager.AppSettings["LuisAPIKey"])))
        {

        }

        [LuisIntent("NextDojoSummary")]
        public async Task GetNextDojo(IDialogContext context, LuisResult result)
        {
            try
            {
                var nextDojo = DojoService.GetNextDojo();
                await context.PostAsync($"Next Dojo is at {nextDojo.Company} ({nextDojo.Adress}) on {nextDojo.Start.ToString("MMMM d")} between {nextDojo.Start.ToString("HH:mm")} - {nextDojo.End.ToString("HH:mm")}");
            }
            catch (Exception)
            {
                await context.PostAsync($"I... I don't know when the next dojo is 😢 \n\n Maybe it isn't planned yet?");
            }
        }

        [LuisIntent("AllUpcomingDojos")]
        public async Task GetAllComingDojos(IDialogContext context, LuisResult result)
        {
            string message = "The coming Dojos are";

            DojoService.GetDojos().Where(d => d.IsFuture).ToList().ForEach(d =>
            {
                message += $"\n\n" +
                $"{d.Company} ({d.Adress}) on {d.Start.ToString("MMMM d")} between {d.Start.ToString("HH:mm")} - {d.End.ToString("HH:mm")}";
            });

            await context.PostAsync(message);
        }


        [LuisIntent("none")]
        public async Task NoneAsync(IDialogContext context, LuisResult result)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task DefaultAsync(IDialogContext context, LuisResult result)
        {
            await NoneAsync(context, result);
        }
    }
}