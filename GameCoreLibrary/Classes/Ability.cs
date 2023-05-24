namespace GameCoreLibrary.Classes
{
    public abstract class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual bool IsAffecting { get; set; }
        public Dictionary<string, int> ValueIncreases { get; }
        public Dictionary<string, double> PercentIncreases { get; }
        public bool IsActiveType { get; }

        protected Ability(string name, string description, Dictionary<string, int> valueIncreases, Dictionary<string, double> percentIncreases, bool isActiveType) 
        {
            Name = name;
            Description = description;
            ValueIncreases = valueIncreases;
            PercentIncreases = percentIncreases;
            IsActiveType = isActiveType;
        }

        public abstract void Activate(Character character);

        public abstract void DeActivate(Character character);
    }
}
