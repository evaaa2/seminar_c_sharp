using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    internal class Enemy
    {
        int healthBase;
        int health;
        int damageBase;
        int damage;
        int level;
        private Random rng;

        public Enemy(int healthBase, int damageBase, int level)
        {
            this.healthBase = healthBase;
            health = this.healthBase * level;

            this.damageBase = damageBase;
            damage = this.damageBase * level;
            this.level = level;
            rng = new Random();
        }

        public void Hurt(int amount)
        {
            health -= amount;
            Console.WriteLine("Enemy got hit for " + amount + " damage");
            if (health <= 0) 
            {
                Console.WriteLine("Enemy is dead");
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
        public bool IsDead()
        {
            return health <= 0;
        }
        public int GetRandomizedDamage()
        {
            return rng.Next(damage / 2, damage + 1);
        }
    }
}
