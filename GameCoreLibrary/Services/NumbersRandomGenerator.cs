namespace GameCoreLibrary.Services
{
    public class NumbersRandomGenerator
    {
        public Random Random { get; init; } = new Random();
        public int GetRandomNumber(int minValue = 1, int maxValue = 100)
        {
            return Random.Next(minValue, maxValue + 1);
        }

        public bool IsRolled(double chance)
        {
            return chance != 0 && GetRandomNumber() <= chance;
        }
    }
}
