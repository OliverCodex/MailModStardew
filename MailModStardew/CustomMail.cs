using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace MailModStardew
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
            //  Remember to add space syntax to mail string.
            data["MyMailGodGrant"] = "I can see your house @^^Placeholder, right?^^^ -Oliver Clarke %item object 155 1 %%[#]I see you";
        }
    }
}


