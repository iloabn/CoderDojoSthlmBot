using CoderDojoBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CoderDojoBot.Dialogs
{
    [LuisModel("f48c3579-7859-40ad-9260-ef9ec67df3ba", "28d98303e0fe480491397858764a186f")]
    [Serializable]
    public class DojoDialog : LuisDialog<object>
    {
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
                await context.PostAsync($"I... I don't know :( \n\n Maybe it isn't planned yet?");
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