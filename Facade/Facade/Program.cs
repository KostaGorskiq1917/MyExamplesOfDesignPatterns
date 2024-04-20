using System;

namespace Facade
{
    public class Player
    {
        public void Move()
        {
            Console.WriteLine("Player is moving.");
        }

        public void Attack()
        {
            Console.WriteLine("Player is attacking.");
        }

        public void Defend()
        {
            Console.WriteLine("Player is defending.");
        }

        public void UseAbility()
        {
            Console.WriteLine("Player is using ability.");
        }
    }

    public class Enemy
    {
        public void Move()
        {
            Console.WriteLine("Enemy is moving.");
        }

        public void Attack()
        {
            Console.WriteLine("Enemy is attacking.");
        }

        public void Defend()
        {
            Console.WriteLine("Enemy is defending.");
        }

        public void UseAbility()
        {
            Console.WriteLine("Enemy is using ability.");
        }
    }

    public class CollisionManager
    {
        public void CheckCollisions()
        {
            Console.WriteLine("Checking collisions...");
        }
    }

    public class GameManagerFacade
    {
        private Player player;
        private Enemy enemy;
        private CollisionManager collisionManager;

        public GameManagerFacade()
        {
            player = new Player();
            enemy = new Enemy();
            collisionManager = new CollisionManager();
        }

        public void PlayerAction()
        {
            player.Move();
            player.Attack();
            player.UseAbility();
            collisionManager.CheckCollisions();
        }

        public void EnemyAction()
        {
            enemy.Move();
            enemy.Attack();
            enemy.UseAbility();
            collisionManager.CheckCollisions();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameManagerFacade gameManager = new GameManagerFacade();

            Console.WriteLine("Player's Turn:");
            gameManager.PlayerAction();

            Console.WriteLine("\nEnemy's Turn:");
            gameManager.EnemyAction();
            Console.ReadLine();
        }
    }
}
