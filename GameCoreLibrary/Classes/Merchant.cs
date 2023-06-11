using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    //TODO
    public class Merchant
    {
        private List<Item> stock = new();
        public int Level { get; set; }

        public Merchant(int level)
        {
            Level = level;
            GenerateStock();
        }

        public void BuyItem (Item item,Player player)
        {
            var isAllowedToBuy = false;
            isAllowedToBuy = player.Inventory.Items.Count(x => x.Type == item.Type) + 1 <= player.Inventory.ItemRestrictions[item.Type];

            if (!isAllowedToBuy)
            {
                //TODO
                throw new NotImplementedException();
            }

            if (player.Gold < item.Cost)
            {
                //TODO
                throw new NotImplementedException();
            }

            player.Gold -= item.Cost;
            player.Inventory.Items.Add(item);
            stock.Remove(item);

        }
        public void SellItem(Item item, Player player)
        {
            //TODO
            player.Gold += item.Cost;
            player.Inventory.Items.Remove(item);
            stock.Add(item);
        }

        private List<Item> GetStock()
        {
           //TODO
           return null;
        }

        private void GenerateStock()
        {
            stock = new List<Item>();
        }
    }
}
