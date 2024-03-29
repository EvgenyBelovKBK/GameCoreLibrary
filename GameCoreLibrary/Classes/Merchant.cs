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

            if (player.Gold < item.Cost)
            {
                //TODO
                throw new NotImplementedException();
            }

            player.Gold -= item.Cost;
            stock.Remove(item);

        }
        public void SellItem(Item item, Player player)
        {
            //TODO
            player.Gold += item.Cost;
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
