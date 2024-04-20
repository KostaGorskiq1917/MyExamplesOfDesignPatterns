using System;
using System.Collections.Generic;

namespace Proxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SpriteProxy spriteProxy = new SpriteProxy();
            spriteProxy.LoadImage("Player");
            spriteProxy.LoadImage("Enemy");
            spriteProxy.LoadImage("Item");

            spriteProxy.DisplayImage("Player");
            spriteProxy.DisplayImage("Enemy");
            spriteProxy.DisplayImage("Item");

            Console.ReadKey();
        }
    }

    public class Sprite
    {
        private readonly string name;

        public Sprite(string name)
        {
            this.name = name;
            LoadImageFromDisk();
        }

        private void LoadImageFromDisk()
        {
            Console.WriteLine($"Loading image: {name}");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image: {name}");
        }
    }

    public class SpriteProxy
    {
        private readonly Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

        public void LoadImage(string name)
        {
            if (!sprites.ContainsKey(name))
            {
                sprites[name] = new Sprite(name);
            }
        }

        public void DisplayImage(string name)
        {
            if (sprites.ContainsKey(name))
            {
                sprites[name].Display();
            }
            else
            {
                Console.WriteLine($"Image {name} is not loaded.");
            }
        }
    }
}
