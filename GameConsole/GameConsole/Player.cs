using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    internal class Player
    {
        private int health;
        public int damage;
        public string name;
        private Random rng;

        public Player(int health, int damage, string name)
        {
            SetHealth(health);
            this.damage = damage;
            this.name = name;
            rng = new Random();
        }

        public Player()
        {
            health = 100;
            damage = 20;
            name = "Player";
        }

        public void SetHealth(int value)
        {
            health = value;
            if (health < 0)
            {
                health = 0;
            }
        }

        public int GetHealth()
        {
            return health;
        }
        public int GetDamage()
        {
            return damage;
        }

        public void Hurt(int amount)
        {
            health -= amount;
            Console.WriteLine("Player got hit for " + amount + " damage");
            if (health <= 0)
            {
                Console.WriteLine("Player is dead");
            }
        }
        public bool IsDead()
        {
            return health <= 0;
        }

        public int GetRandomizedDamage()
        {
            return rng.Next(damage / 2, Convert.ToInt32(damage*3/2));
        }
    }
}
