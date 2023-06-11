using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Player : Character
    {
        public int Xp { get; set; } = 0;
        public int NextLevelXp { get; set; } = 100;

        public Player(string name, int level, Class _class, Inventory inventory, Dictionary<string, double> stats, int gold = 0) :
            base(name, level, _class, inventory, stats, gold)
        {

        }

        /// <returns>True if new level</returns>
        public bool AddXp(int xpAmount)
        {
            Xp += xpAmount;
            if (Xp >= NextLevelXp)
            {
                NextLevelXp = (int)(NextLevelXp + ((BalanceConstants.BaseNextLevelXpAmount + Level) *
                                                   Math.Pow(Level, BalanceConstants.NextLevelXpMultiplier)));
                LvlUp();
                return true;
            }

            return false;
        }

    }

    public static class PlayerExtensions
    {
        //TODO
        public static void Buy(this Player player, Merchant merchant, Item item)
        {
            merchant.BuyItem(item, player);
        }

        public static void Sell(this Player player, Merchant merchant, Item item)
        {
            merchant.SellItem(item, player);
        }
    }
}
