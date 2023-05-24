using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Shop
    {
        public string Name { get; set; }
        public List<Item> Stock { get; set; }
        public Tiers Tier { get; set; }

        public Shop(Tiers tier, string name, List<Item> stock)
        {
            Tier = tier;
            Name = name;
            Stock = stock;
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
            Stock.Remove(item);

        }
        public void SellItem(Item item, Player player)
        {
            //TODO
            player.Gold += item.Cost;
            player.Inventory.Items.Remove(item);
            Stock.Add(item);
        }

        private void ShowStock()
        {
           //TODO
        }
    }
}
