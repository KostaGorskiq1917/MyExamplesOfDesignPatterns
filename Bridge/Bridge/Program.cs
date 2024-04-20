using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public abstract class Weapon
    {
        protected AttackStrategy attackStrategy;

        public Weapon(AttackStrategy attackStrategy)
        {
            this.attackStrategy = attackStrategy;
        }

        public abstract void Attack();
    }

    public class Sword : Weapon
    {
        public Sword(AttackStrategy attackStrategy) : base(attackStrategy)
        {
        }

        public override void Attack()
        {
            Console.WriteLine("Sword attack!");
            attackStrategy.Execute();
        }
    }

    public class BowAndArrow : Weapon
    {
        public BowAndArrow(AttackStrategy attackStrategy) : base(attackStrategy)
        {
        }

        public override void Attack()
        {
            Console.WriteLine("Bow and arrow attack!");
            attackStrategy.Execute();
        }
    }

    public abstract class AttackStrategy
    {
        public abstract void Execute();
    }

    public class MeleeAttack : AttackStrategy
    {
        public override void Execute()
        {
            Console.WriteLine("Performing melee attack!");
        }
    }

    public class RangedAttack : AttackStrategy
    {
        public override void Execute()
        {
            Console.WriteLine("Performing ranged attack!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AttackStrategy melee = new MeleeAttack();
            Weapon sword = new Sword(melee);
            sword.Attack();

            AttackStrategy ranged = new RangedAttack();
            Weapon bowAndArrow = new BowAndArrow(ranged);
            bowAndArrow.Attack();

            Console.ReadKey();
        }
    }
}
