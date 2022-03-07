using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace MailModStardew
{
    public class ModEntry : Mod
    {
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            this.Config = helper.ReadConfig<ModConfig>();
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            helper.Events.Input.ButtonsChanged += this.OnButtonChanged;
            helper.Events.GameLoop.DayEnding += this.OnDayEnded;
        }
        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            //Add our custom mail to game mail data on launch.
            Helper.Content.AssetEditors.Add(new CustomMail());
        }
        private void OnButtonChanged(object sender, ButtonsChangedEventArgs e)
        {   //When config button is pressed
            if (this.Config.OpenMenuHotkey.JustPressed())
            {     //Add mail
                  Game1.addMailForTomorrow("MyMailGodGrant");
            }
        }

        private void OnDayEnded(object sender, DayEndingEventArgs e)
        {
            //Remove the mail so we can send it again.
            Game1.player.mailReceived.Remove("MyMailGodGrant");
        }

    }
}