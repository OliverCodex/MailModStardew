﻿using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace StardewMailMenu
{
    public class CustomMail : IAssetEditor
    {
        public CustomMail()
        {
        }
        public bool CanEdit<T>(IAssetInfo asset)
        {
            //Finding the mail data so we can edit it.
            return asset.AssetNameEquals("Data\\mail");
        }
        public void Edit<T>(IAssetData asset)
        {
            //Declaring us a variable for us to use when we want to add mail data.
            var data = asset.AsDictionary<string, string>().Data;

            data["MyMailGodGrant"] = "HEHEHEHAW LEVI %item object 71 1 %%";
        }
    }
}

