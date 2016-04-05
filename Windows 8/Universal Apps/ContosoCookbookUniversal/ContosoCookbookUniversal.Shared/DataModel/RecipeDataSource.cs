using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace ContosoCookbookUniversal.Data
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class RecipeDataItem
    {
        public RecipeDataItem(String uniqueId, String title, String subtitle, String description, String imagePath, String tileImagePath, int prepTime, string directions, IEnumerable<string> ingredients)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.TileImagePath = tileImagePath;
            this.PrepTime = prepTime;
            this.Directions = directions;
            this.Ingredients = new ObservableCollection<string>(ingredients);
        }

        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string TileImagePath { get; private set; }
        public int PrepTime { get; private set; }
        public string Directions { get; private set; }
        public ObservableCollection<string> Ingredients { get; private set; }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class RecipeDataGroup
    {
        public RecipeDataGroup(String uniqueId, String title, String subtitle, String imagePath, String groupImagePath, String description)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.GroupImagePath = groupImagePath;
            this.Items = new ObservableCollection<RecipeDataItem>();
        }
        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string GroupImagePath { get; private set; }
        public ObservableCollection<RecipeDataItem> Items { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// RecipeDataSource initializes with data read from a static json file included in the 
    /// project.  This provides recipe data at both design-time and run-time.
    /// </summary>
    public sealed class RecipeDataSource
    {
        private static string _baseUri = "ms-appx:///"; // Default base URI
        private const string _key = "UseLocalDataSource"; // LocalSettings key
        private static RecipeDataSource _recipeDataSource = new RecipeDataSource();

        private ObservableCollection<RecipeDataGroup> _groups = new ObservableCollection<RecipeDataGroup>();
        public ObservableCollection<RecipeDataGroup> Groups
        {
            get { return this._groups; }
        }

        public static async Task<IEnumerable<RecipeDataGroup>> GetGroupsAsync()
        {
            await _recipeDataSource.GetRecipeDataAsync();

            return _recipeDataSource.Groups;
        }

        public static async Task<RecipeDataGroup> GetGroupAsync(string uniqueId)
        {
            await _recipeDataSource.GetRecipeDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _recipeDataSource.Groups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static async Task<RecipeDataItem> GetItemAsync(string uniqueId)
        {
            await _recipeDataSource.GetRecipeDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _recipeDataSource.Groups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task GetRecipeDataAsync()
        {
            if (this._groups.Count != 0)
                return;

            bool useLocalData = true;

            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(_key))
                useLocalData = (bool)ApplicationData.Current.LocalSettings.Values[_key];

            string jsonText = null;

            if (useLocalData)
            {
                Uri dataUri = new Uri(_baseUri + "DataModel/RecipeData.json");
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                jsonText = await FileIO.ReadTextAsync(file);
            }
            else
            {
                _baseUri = "http://contosorecipes8.blob.core.windows.net/";
                var cts = new CancellationTokenSource();
                cts.CancelAfter(5000); // Wait up to 5 seconds

                try
                {
                    var client = new HttpClient();
                    var response = await client.GetAsync(new Uri(_baseUri + "BlueRecipes")).AsTask(cts.Token);

                    if (!response.IsSuccessStatusCode)
                    {
                        await new MessageDialog("Unable to load remote data (request failed)").ShowAsync();
                        return;
                    }
                    
                    jsonText = await response.Content.ReadAsStringAsync();
                }
                catch (OperationCanceledException)
                {
                    new MessageDialog("Unable to load remote data (operation timed out)").ShowAsync();
                }
            }

            try
            {
                JsonObject jsonObject = JsonObject.Parse(jsonText);
                JsonArray jsonArray = jsonObject["Groups"].GetArray();

                foreach (JsonValue groupValue in jsonArray)
                {
                    JsonObject groupObject = groupValue.GetObject();
                    RecipeDataGroup group = new RecipeDataGroup(
                        groupObject["UniqueId"].GetString(),
                        groupObject["Title"].GetString(),
                        groupObject["Subtitle"].GetString(),
                        _baseUri + groupObject["ImagePath"].GetString(),
                        _baseUri + groupObject["GroupImagePath"].GetString(),
                        groupObject["Description"].GetString()
                    );

                    foreach (JsonValue itemValue in groupObject["Items"].GetArray())
                    {
                        JsonObject itemObject = itemValue.GetObject();

                        JsonArray array = itemObject["Ingredients"].GetArray();
                        var ingredients = (from i in array select i.GetString());

                        group.Items.Add(new RecipeDataItem(
                            itemObject["UniqueId"].GetString(),
                            itemObject["Title"].GetString(),
                            itemObject["Subtitle"].GetString(),
                            itemObject["Description"].GetString(),
                            _baseUri + itemObject["ImagePath"].GetString(),
                           _baseUri + itemObject["TileImagePath"].GetString(), // Tile images must be local
                            (int)itemObject["PrepTime"].GetNumber(),
                            itemObject["Directions"].GetString(),
                            ingredients
                        ));
                    }

                    this.Groups.Add(group);
                }
            }
            catch (Exception)
            {
                new MessageDialog("Invalid JSON data").ShowAsync();
            }
        }
    }
}