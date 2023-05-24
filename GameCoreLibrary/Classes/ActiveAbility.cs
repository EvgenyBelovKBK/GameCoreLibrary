﻿using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class ActiveAbility : Ability
    {
        public ActiveAbilityType AbilityType { get; }
        public int CurrentDuration { get; set; }
        public int TurnDuration { get; }
        public int Cooldown { get;}
        public int CurrentCooldown { get; set; }
        public bool IsPermanent { get; }
        private bool _isAffecting;
        public override bool IsAffecting
        {
            get => _isAffecting;
            set
            {
                CurrentDuration = 0;
                _isAffecting = value;
            }
        }

        public override void Activate(Character character)
        {
            if(IsAffecting || CurrentCooldown > 0)
                return;
            CurrentCooldown = Cooldown;

            character.AddStats(ValueIncreases);

            foreach (var percent in PercentIncreases)
            {
                character.Stats[percent.Key] = int.Parse(Math.Round(character.Stats[percent.Key] * (1 + percent.Value)).ToString());
            }
            IsAffecting = true;
        }

        public override void DeActivate(Character character)
        {
            if(!IsAffecting || IsPermanent)
                return;
            foreach (var value in ValueIncreases)
            {
                character.Stats[value.Key] -= value.Value;
            }
            foreach (var percent in PercentIncreases)
            {
                character.Stats[percent.Key] = int.Parse(Math.Round(character.Stats[percent.Key] / (1 + percent.Value)).ToString());
            }
            IsAffecting = false;
        }

        public ActiveAbility(string name, string description, Dictionary<string, int> valueIncreases, Dictionary<string, double> percentIncreases, ActiveAbilityType abilityType, int cooldown, int turnDuration = 0, bool isPermanent = false) : base(name, description,valueIncreases,percentIncreases,true)
        {
            AbilityType = abilityType;
            Cooldown = cooldown;
            TurnDuration = turnDuration;
            IsPermanent = isPermanent;
        }
    }
}
