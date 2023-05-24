using System.Collections.ObjectModel;
using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Inventory
    {
        public ObservableCollection<Item> Items { get; set; }
        public Dictionary<ItemType, int> ItemRestrictions { get; set; }

        public Inventory(ObservableCollection<Item> items)
        {
            Items = items;
            ItemRestrictions = new Dictionary<ItemType, int>(ItemConstants.DefaultItemRestrictions);
        }
    }
}
