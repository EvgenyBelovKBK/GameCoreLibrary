using GameCoreLibrary.Constants;

namespace GameCoreLibrary.Classes
{
    public class Level
    {
        public string LevelName { get;}
        public List<Enemy> Enemies { get; set; }

        public Level(int number, string levelName, List<Enemy> enemies)
        {
            LevelName = levelName;
            Enemies = enemies;
        }
    }
}
