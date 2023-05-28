using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Class
    {
        public string Description { get; }
        public ClassType ClassType { get; }
        public Dictionary<string, double> LvlUpStatsIncrease { get; }

        public Class(string description, ClassType classType)
        {
            Description = description;
            ClassType = classType;
            LvlUpStatsIncrease = CharConstants.ClassLvlUpStatsIncrease[classType];
        }
    }
}
