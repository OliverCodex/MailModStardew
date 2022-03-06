using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace StardewMailMenu
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.DayEnding += this.OnDayEnded;
        }
        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            //Add our custom mail to game mail data on launch.
            Helper.Content.AssetEditors.Add(new CustomMail());
        }
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            //For every specified toggle key proceed with our code.
            bool isOpenBracketPressed = this.Helper.Input.IsDown(SButton.OemOpenBrackets);
            if (isOpenBracketPressed)
            {
                //Send our mail to player 
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