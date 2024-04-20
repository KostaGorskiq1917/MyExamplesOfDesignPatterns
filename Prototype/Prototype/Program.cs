using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            EnemyPrototype basicEnemyPrototype = new BasicEnemy("Basic Enemy", 100, 10);

            Enemy enemy1 = basicEnemyPrototype.Clone();
            enemy1.Position = new Vector2(10, 20);

            Enemy enemy2 = basicEnemyPrototype.Clone();
            enemy2.Position = new Vector2(30, 40);

            Console.WriteLine("Enemy 1: " + enemy1);
            Console.WriteLine("Enemy 2: " + enemy2);

            Console.ReadKey();
        }
    }

    abstract class EnemyPrototype
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public abstract Enemy Clone();
    }

    class BasicEnemy : EnemyPrototype
    {
        public BasicEnemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public override Enemy Clone()
        {
            return new Enemy(Name, Health, Damage);
        }
    }

    class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Vector2 Position { get; set; }

        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public Enemy(Enemy enemy)
        {
            Name = enemy.Name;
            Health = enemy.Health;
            Damage = enemy.Damage;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Health: {Health}, Damage: {Damage}, Position: {Position}";
        }
    }

    class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

}
