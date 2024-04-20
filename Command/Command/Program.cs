using System;
using System.Collections.Generic;

namespace Command.GameDev
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Player player = new Player();
            Enemy enemy = new Enemy();

            var attackCommand = new AttackCommand(player, enemy);
            var defendCommand = new DefendCommand(player);
            var specialAttackCommand = new SpecialAttackCommand(player, enemy);

            var inputHandler = new InputHandler();
            inputHandler.SetCommand("A", attackCommand);
            inputHandler.SetCommand("D", defendCommand);
            inputHandler.SetCommand("S", specialAttackCommand);

            inputHandler.ProcessInput("A");
            inputHandler.ProcessInput("D");
            inputHandler.ProcessInput("S");

            Console.ReadKey();
        }
    }

    public class Player
    {
        public void Attack(Enemy enemy)
        {
            Console.WriteLine("Player attacks the enemy.");
        }

        public void Defend()
        {
            Console.WriteLine("Player defends against incoming attacks.");
        }

        public void SpecialAttack(Enemy enemy)
        {
            Console.WriteLine("Player uses a special attack against the enemy.");
        }
    }

    public class Enemy
    {
        public void TakeDamage()
        {
            Console.WriteLine("Enemy takes damage.");
        }
    }

    public class AttackCommand
    {
        private readonly Player player;
        private readonly Enemy enemy;

        public AttackCommand(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void Execute()
        {
            player.Attack(enemy);
            enemy.TakeDamage();
        }
    }

    public class DefendCommand
    {
        private readonly Player player;

        public DefendCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Defend();
        }
    }

    public class SpecialAttackCommand
    {
        private readonly Player player;
        private readonly Enemy enemy;

        public SpecialAttackCommand(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void Execute()
        {
            player.SpecialAttack(enemy);
            enemy.TakeDamage();
        }
    }

    public class InputHandler
    {
        private readonly Dictionary<string, dynamic> commands = new Dictionary<string, dynamic>();

        public void SetCommand(string key, dynamic command)
        {
            commands[key] = command;
        }

        public void ProcessInput(string key)
        {
            if (commands.ContainsKey(key))
            {
                commands[key].Execute();
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
