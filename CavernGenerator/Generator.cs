using System;

namespace CavernGenerator
{
    class Generator
    {
        private Random rand;

        public int XSize { get; private set; }
        public int YSize { get; private set; }

        private int steps;
        private int rockyNeighbors;

        private Tile[,] world;
        public Tile[,] World { get => world; }
        
        private Tile[,] newWorld;
        private Tile[,] auxWorld;

        public Generator(string[] args) 
        {
            XSize = Convert.ToInt32(args[0]);
            YSize = Convert.ToInt32(args[1]);
            steps = Convert.ToInt32(args[2]);

            rand = new Random();

            world = new Tile[XSize, YSize];
            newWorld = new Tile[XSize, YSize];

            rockyNeighbors = 0;
        }

        public void InitializeWorld()
        {
            for (int y = 0; y < YSize; y++)
            {
                for (int x = 0; x < XSize; x++)
                {
                    world[x, y] = 
                        new Tile(rand.NextDouble() > 0.5f ? TileType.Ground : TileType.Rock);
                }
            }
        }

        public void Generate()
        {
            for (int i = 0; i < steps; i++)
            {
                for (int y = 0; y < YSize; y++)
                {
                    for (int x = 0; x < XSize; x++)
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

                        newWorld[x, y] = new Tile(rockyNeighbors >= 5 ? TileType.Rock : TileType.Ground);

                        rockyNeighbors = 0;
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
                X = XSize -1;
            else if (X > XSize - 1)
                X = 0;
            if (Y < 0)
                Y = YSize - 1;
            else if (Y > YSize - 1)
                Y = 0;
            return world[X, Y].Type == TileType.Rock;
        }
    }
}



