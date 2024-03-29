using System.Collections.ObjectModel;
using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Inventory
    {
        public ObservableCollection<Item> Items { get; set; }

        public Inventory(ObservableCollection<Item> items)
        {
            Items = items;
        }

        //TODO
        public bool AddItem(Item item)
        {
            return true;
        }

        public bool RemoveItem(Item item)
        {
            return true;
        }
    }
}
