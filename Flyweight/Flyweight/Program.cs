using System;
using System.Collections.Generic;

namespace Flyweight
{
    public class TreeType
    {
        private string name;
        private string texture;

        public TreeType(string name, string texture)
        {
            this.name = name;
            this.texture = texture;
        }

        public void Render(int x, int y)
        {
            Console.WriteLine($"Rendering {name} tree at ({x}, {y}) with texture '{texture}'");
        }
    }

    public class TreeFactory
    {
        private Dictionary<string, TreeType> treeTypes = new Dictionary<string, TreeType>();

        public TreeType GetTreeType(string name, string texture)
        {
            if (!treeTypes.ContainsKey(name))
            {
                treeTypes[name] = new TreeType(name, texture);
            }
            return treeTypes[name];
        }
    }

    public class Tree
    {
        private int x;
        private int y;
        private TreeType type;

        public Tree(int x, int y, TreeType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public void Render()
        {
            type.Render(x, y);
        }
    }

    public class Game
    {
        public static void Main(string[] args)
        {
            TreeFactory factory = new TreeFactory();

            TreeType oakType = factory.GetTreeType("Oak", "oak_texture.png");
            TreeType pineType = factory.GetTreeType("Pine", "pine_texture.png");

            Tree oak1 = new Tree(10, 20, oakType);
            Tree oak2 = new Tree(30, 40, oakType);
            Tree pine1 = new Tree(50, 60, pineType);

            oak1.Render();
            oak2.Render();
            pine1.Render();

            Console.ReadKey();
        }
    }
}
