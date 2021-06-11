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
        private Tile[,] newWorld;
        private Tile[,] auxWorld;

        private int rockyNeighbors;

        public Generator(string[] args) 
        {
            xSize = Convert.ToInt32(args[0]);
            ySize = Convert.ToInt32(args[1]);
            steps = Convert.ToInt32(args[2]);

            rand = new Random();

            world = new Tile[ySize, xSize];
            newWorld = new Tile[ySize, xSize];

            rockyNeighbors = 0;
        }

        public void InitializeWorld()
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    world[y, x] = 
                        new Tile(rand.NextDouble() > 0.5f ? TileType.Ground : TileType.Rock);
                }
            }
        }

        public void Generate()
        {
            for (int i = 0; i < steps; i++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    for (int x = 0; x < xSize; x++)
                    {
                        // Check Neighbors
                        for (int yn = -1; yn <= 1; yn++)
                        {
                            for (int xn = -1; xn <= 1; xn++)
                            {
                                if (PeekNeighbors(y + yn, x + xn))
                                {
                                    rockyNeighbors++;
                                }
                            }
                        }

                        newWorld[y, x] = new Tile(rockyNeighbors >= 5 ? TileType.Rock : TileType.Ground);
                    }
                }

                auxWorld = newWorld;
                newWorld = world;
                world = auxWorld;
            }
        }

        public bool PeekNeighbors(int X, int Y)
        {
            if (X < 0)
                X += xSize;
            else if (X > xSize - 1)
                X -= xSize;
            if (Y < 0)
                Y += ySize;
            else if (Y > ySize - 1)
                Y -= ySize;
            return world[Y, X].Type == TileType.Rock;
        }
    }
}



