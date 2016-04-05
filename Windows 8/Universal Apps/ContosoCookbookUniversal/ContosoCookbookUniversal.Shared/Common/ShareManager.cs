using ContosoCookbookUniversal.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;

namespace ContosoCookbookUniversal.Common
{
    public class ShareManager
    {
        public RelayCommand ShareCommand
        {
            get
            {
                return new RelayCommand(() => DataTransferManager.ShowShareUI());
            }
        }
        
        public static void ShareRecipe(DataRequest request, RecipeDataItem item)
        {
            request.Data.Properties.Title = item.Title;
            request.Data.Properties.Description = "Recipe ingredients and directions";

            // Share recipe text
            var recipe = "\r\nINGREDIENTS\r\n";
            recipe += String.Join("\r\n", item.Ingredients);
            recipe += ("\r\n\r\nDIRECTIONS\r\n" + item.Directions);
            request.Data.SetText(recipe);

            // Share recipe image
            var reference = RandomAccessStreamReference.CreateFromUri(new Uri(item.ImagePath));
            request.Data.Properties.Thumbnail = reference;
            request.Data.SetBitmap(reference);
        }
    }
}
