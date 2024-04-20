using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterGameExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BasicEnemy basicEnemy = new BasicEnemy();
            basicEnemy.Attack();

            PowerfulEnemy powerfulEnemy = new PowerfulEnemy();
            EnemyAdapter enemyAdapter = new EnemyAdapter(powerfulEnemy);
            enemyAdapter.Attack();

            Console.ReadKey();
        }
    }

    public class BasicEnemy
    {
        public void Attack()
        {
            Console.WriteLine("Basic enemy attacks!");
        }
    }

    public class PowerfulEnemy
    {
        public void Crush()
        {
            Console.WriteLine("Powerful enemy crushes!");
        }
    }

    public class EnemyAdapter
    {
        private PowerfulEnemy _powerfulEnemy;

        public EnemyAdapter(PowerfulEnemy powerfulEnemy)
        {
            _powerfulEnemy = powerfulEnemy;
        }

        public void Attack()
        {
            _powerfulEnemy.Crush();
        }
    }
}
