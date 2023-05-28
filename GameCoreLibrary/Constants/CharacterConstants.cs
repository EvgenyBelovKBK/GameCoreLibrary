using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Constants
{
    public static class CharConstants
    {
        public static readonly Dictionary<string, double> BaseCharacterStats = new()
        {
            { StatName.TotalHp, 100 },
            { StatName.Hp, 100 },
            { StatName.TotalMana, 50 },
            { StatName.Mana, 50 },
            { StatName.Intelligence, 5 },
            { StatName.Agility, 5 },
            { StatName.Strength, 5 },
            { StatName.Armor, 10 },
            { StatName.BlockChance, 0 },
            { StatName.CritChance, 5 },
            { StatName.PhysDamage, 15 },
            { StatName.EvadeChance, 5 },
            { StatName.LifestealPercent, 0 },
            { StatName.CritDamageMultiplier, 135 },
        };

        public static readonly Dictionary<string, double> BaseLvlUpStatsIncrease = new()
        {
            { StatName.TotalHp, 10 },
            { StatName.TotalMana, 3 },
            { StatName.Intelligence, 1 },
            { StatName.Agility, 1 },
            { StatName.Strength, 1 },
            { StatName.PhysDamage, 2 },
            { StatName.SpellDamage, 2 },
            { StatName.CritDamageMultiplier, 1 },
        };

        public static readonly Dictionary<string,Dictionary<string, double>> AttrStatsIncrease = new()
        {
            { StatName.Strength, new Dictionary<string, double>
            {
                {StatName.TotalHp, 5},
                {StatName.PhysDamage, 1},
            }},
            { StatName.Agility, new Dictionary<string, double>
            {
                {StatName.PhysDamage, 0.5},
                {StatName.EvadeChance, 0.2},
                {StatName.CritChance, 0.2}
            }},
            { StatName.Intelligence, new Dictionary<string, double>
            {
                {StatName.TotalMana, 3},
                {StatName.MagicResistance, 0.3},
                {StatName.SpellDamage, 3}
            }},
        };

        public static readonly Dictionary<ClassType,Dictionary<string, double>> ClassLvlUpStatsIncrease = new()
        {
            { ClassType.Warrior, new Dictionary<string, double>
            {
                {StatName.Strength, 2},
            }},
            { ClassType.Mage, new Dictionary<string, double>
            {
                {StatName.Intelligence, 2},
            }},
            { ClassType.Archer, new Dictionary<string, double>
            {
                {StatName.Agility, 2},
            }},
            { ClassType.Swordsman, new Dictionary<string, double>
            {
                {StatName.Strength, 1},
                {StatName.Agility, 1}
            }},
            { ClassType.Shaman, new Dictionary<string, double>
            {
                {StatName.Strength, 1},
                {StatName.Intelligence, 1}
            }},
            { ClassType.Shadow, new Dictionary<string, double>
            {
                {StatName.Agility, 1},
                {StatName.Intelligence, 1}
            }},
        };
    }
}
