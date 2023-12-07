namespace Monry.UnifiedCSharpSample.Model
{
    public class Player
    {
        public Player(string name, int level, int hp)
        {
            Name = name;
            Level = level;
            Hp = hp;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
    }
}
