using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstract class representing an enemy
abstract class Enemy
{
    public abstract void Attack();
}

// Concrete enemy classes
class Goblin : Enemy
{
    public override void Attack()
    {
        Console.WriteLine("Goblin attacks with a club!");
    }
}

class Skeleton : Enemy
{
    public override void Attack()
    {
        Console.WriteLine("Skeleton attacks with a sword!");
    }
}

// Abstract factory class for creating enemies
abstract class EnemySpawner
{
    public abstract Enemy CreateEnemy();
}

// Concrete factory classes for creating specific types of enemies
class GoblinSpawner : EnemySpawner
{
    public override Enemy CreateEnemy()
    {
        return new Goblin();
    }
}

class SkeletonSpawner : EnemySpawner
{
    public override Enemy CreateEnemy()
    {
        return new Skeleton();
    }
}

class MainApp
{
    static void Main()
    {
        // An array of enemy
        EnemySpawner[] enemyFactories = new EnemySpawner[2];
        enemyFactories[0] = new GoblinSpawner();
        enemyFactories[1] = new SkeletonSpawner();

        foreach (EnemySpawner factory in enemyFactories)
        {
            Enemy enemy = factory.CreateEnemy();
            enemy.Attack();
        }

        Console.ReadKey();
    }
}