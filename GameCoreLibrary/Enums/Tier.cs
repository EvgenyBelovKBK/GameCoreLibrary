using GameCoreLibrary.Constants;

namespace GameCoreLibrary.Enums
{
    public enum Tier
    {
        Tier1,
        Tier2,
        Tier3,
        Tier4,
        Tier5,
    }

    public static class TierExtensions
    {
        public static Range GetLevels(this Tier tier)
        {
            return BalanceConstants.TierLevels[tier];
        }
    }
}
