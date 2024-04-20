using System;

namespace Decorator.GameDev
{
    public class BaseWeapon
    {
        public virtual void Attack()
        {
            Console.WriteLine("Base weapon attack!");
        }
    }

    public abstract class WeaponDecorator : BaseWeapon
    {
        protected BaseWeapon weapon;

        public WeaponDecorator(BaseWeapon weapon)
        {
            this.weapon = weapon;
        }

        public override void Attack()
        {
            weapon.Attack();
        }
    }

    public class FireDecorator : WeaponDecorator
    {
        public FireDecorator(BaseWeapon weapon) : base(weapon) { }

        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("Adding fire damage!");
        }
    }

    public class PoisonDecorator : WeaponDecorator
    {
        public PoisonDecorator(BaseWeapon weapon) : base(weapon) { }

        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("Applying poison effect!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BaseWeapon baseWeapon = new BaseWeapon();

            BaseWeapon fireWeapon = new FireDecorator(baseWeapon);
            fireWeapon.Attack();

            Console.WriteLine();

            BaseWeapon poisonWeapon = new PoisonDecorator(baseWeapon);
            poisonWeapon.Attack();

            Console.WriteLine();

            BaseWeapon fireAndPoisonWeapon = new FireDecorator(new PoisonDecorator(baseWeapon));
            fireAndPoisonWeapon.Attack();
            Console.ReadLine();
        }
    }
}
