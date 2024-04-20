using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameManager.Instance().StartGame();
            GameManager.Instance().PauseGame();

            Console.ReadKey();
        }
    }

    public class GameManager
    {
        private static GameManager instance;

        private GameManager()
        {
        }

        public static GameManager Instance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }

        public void StartGame()
        {
            Console.WriteLine("Game started!");
        }

        public void PauseGame()
        {
            Console.WriteLine("Game paused!");
        }
    }
}
