using System;

namespace Chain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EnemyHandler weakEnemyHandler = new WeakEnemyHandler();
            EnemyHandler mediumEnemyHandler = new MediumEnemyHandler();
            EnemyHandler strongEnemyHandler = new StrongEnemyHandler();

            weakEnemyHandler.SetSuccessor(mediumEnemyHandler);
            mediumEnemyHandler.SetSuccessor(strongEnemyHandler);

            Enemy weakEnemy = new Enemy("Goblin", 5);
            Enemy mediumEnemy = new Enemy("Orc", 15);
            Enemy strongEnemy = new Enemy("Troll", 30);

            weakEnemyHandler.HandleAttack(weakEnemy);
            weakEnemyHandler.HandleAttack(mediumEnemy);
            weakEnemyHandler.HandleAttack(strongEnemy);

            Console.ReadKey();
        }
    }

    public class Enemy
    {
        public string Name { get; }
        public int Strength { get; }

        public Enemy(string name, int strength)
        {
            Name = name;
            Strength = strength;
        }
    }

    public abstract class EnemyHandler
    {
        protected EnemyHandler successor;

        public void SetSuccessor(EnemyHandler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleAttack(Enemy enemy);
    }

    public class WeakEnemyHandler : EnemyHandler
    {
        public override void HandleAttack(Enemy enemy)
        {
            if (enemy.Strength < 10)
            {
                Console.WriteLine($"{enemy.Name} (Strength: {enemy.Strength}) - Weak enemy handled.");
            }
            else if (successor != null)
            {
                successor.HandleAttack(enemy);
            }
        }
    }

    public class MediumEnemyHandler : EnemyHandler
    {
        public override void HandleAttack(Enemy enemy)
        {
            if (enemy.Strength >= 10 && enemy.Strength < 20)
            {
                Console.WriteLine($"{enemy.Name} (Strength: {enemy.Strength}) - Medium enemy handled.");
            }
            else if (successor != null)
            {
                successor.HandleAttack(enemy);
            }
        }
    }

    public class StrongEnemyHandler : EnemyHandler
    {
        public override void HandleAttack(Enemy enemy)
        {
            if (enemy.Strength >= 20)
            {
                Console.WriteLine($"{enemy.Name} (Strength: {enemy.Strength}) - Strong enemy handled.");
            }
            else if (successor != null)
            {
                successor.HandleAttack(enemy);
            }
        }
    }
}
