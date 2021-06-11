using System;
using System.Collections.Generic;
using System.Text;

namespace CavernGenerator
{
    class Generator
    {
        private Random rand;

        private int xSize;
        private int ySize;
        private int steps;

        private Tile[,] world;

        public Generator(string[] args) 
        {
            xSize = Convert.ToInt32(args[0]);
            ySize = Convert.ToInt32(args[1]);
            steps = Convert.ToInt32(args[2]);

            rand = new Random();

            world = new Tile[ySize, xSize];
        }

        public void InitializeWorld()
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    world[y, x] = 
                        new Tile(rand.NextDouble() > 0.5f ? TileType.Ground : TileType.Rock);
                    Console.Write(world[y, x].Sprite);
                }
                Console.WriteLine();
            }
        }

        public void Generate()
        {
            
        }
    }
}



