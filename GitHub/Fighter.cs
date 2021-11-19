using System;

namespace Box
{
    public class Fighter
    {
        public string Name { get; private set; }

        public int Health { get; set; }

        public int DamagePerAttack { get; private set; }

        public Fighter(string name, int health, int damage)
        {
            this.Name = name;
            this.Health = health;
            this.DamagePerAttack = damage;
        }
        public static void Fight(Fighter first, Fighter second, int random_value)
        {
            if (random_value == 0)
            {
                Console.WriteLine($"По результатам жеребьевки первым наносит удар игрок под именем:  {first.Name}");
                second.Health -= first.DamagePerAttack;
            }
            else
                Console.WriteLine($"По результатам жеребьевки первым наносит удар игрок под именем:  {second.Name}");

            while (first.Health > 0 && second.Health > 0)
            {
                first.Health -= second.DamagePerAttack;
                second.Health -= first.DamagePerAttack;
            }
            string name_win = first.Health > 1 ? first.Name : second.Name;
            Console.WriteLine($"Победу в битве одержал игрок под именем: {name_win}");
        }
    }
}
