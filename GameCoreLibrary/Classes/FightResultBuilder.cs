using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class FightResultBuilder
    {
        private FightResult FightResult { get; }

        public FightResultBuilder()
        {
            FightResult = new FightResult();
        }

        public FightResult SetDamage(bool isCrit)
        {
            FightResult.AttackOutcome = isCrit ? FightAction.CriticalStrike : FightAction.Damage;
            return FightResult;
        }

        public FightResult SetBlock()
        {
            FightResult.AttackOutcome = FightAction.Block;
            return FightResult;
        }

        public FightResult SetEvasion()
        {
            FightResult.AttackOutcome = FightAction.Evade;
            return FightResult;
        }
    }
}
