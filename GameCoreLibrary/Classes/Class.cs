using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Class
    {
        public string Description { get; set; }
        public ClassType ClassType { get; set; }
        public Dictionary<string, int> BaseStats { get; }

        public Class(string description, ClassType classType, Dictionary<string, int> baseStats)
        {
            Description = description;
            ClassType = classType;
            BaseStats = baseStats;
        }
    }
}
