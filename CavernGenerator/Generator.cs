using System;

namespace CavernGenerator
{
    class Generator
    {
        private Random rand;

        private int xSize;
        public int XSize { get => xSize; }
        private int ySize;
        public int YSize { get => ySize; }

        private int steps;
        private int rockyNeighbors;

        private Tile[,] world;
        public Tile[,] World { get => world; }
        
        private Tile[,] newWorld;
        private Tile[,] auxWorld;

        public Generator(string[] args) 
        {
            // Tries to parse args[0] to get the xSize value
            if (args.Length != 3 || !Int32.TryParse(args[0], out xSize)) {
                // If failed set the default xSize to 30
                xSize = 30;
            }
            // Tries to parse args[1] to get the ySize value
            if (args.Length != 3 || !Int32.TryParse(args[1], out ySize))
            {
                // If failed set the default ySize to 10
                ySize = 10;
            }
            // Tries to parse args[2] to get the steps value
            if (args.Length != 3 || !Int32.TryParse(args[2], out steps))
            {
                // If failed set the default steps to 5
                steps = 5;
            }

            rand = new Random();

            world = new Tile[XSize, YSize];
            newWorld = new Tile[XSize, YSize];

            rockyNeighbors = 0;
        }

        private void InitializeWorld()
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
            InitializeWorld();

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



