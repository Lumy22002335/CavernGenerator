using System;

namespace CavernGenerator
{
    /// <summary>
    /// Generator Class responsible for generating the cavern
    /// </summary>
    class Generator
    {
        // Declare a Random
        private Random rand;

        private int xSize;
        /// <value> The X size of the world</value>
        public int XSize { get => xSize; }

        private int ySize;
        /// <value> The Y size of the world</value>
        public int YSize { get => ySize; }

        // The number of steps to run the generation
        private int steps;
        // The number of neighbors a tile has that are Rock type
        private int rockyNeighbors;

        private Tile[,] world;
        /// <value>The world array</value>
        public Tile[,] World { get => world; }
        
        // Array for the newWorld
        private Tile[,] newWorld;
        // Auxiliar array for the world
        private Tile[,] auxWorld;

        /// <summary>
        /// Generator constructor initializes all the necessary values
        /// </summary>
        /// <param name="args">Array of arguments passed in through the command line</param>
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

            // Initialize the random
            rand = new Random();

            // Initialize the world array with the X and Y sizes
            world = new Tile[XSize, YSize];
            // Initialize the newWorld array with the X and Y sizes
            newWorld = new Tile[XSize, YSize];

            // Initialize the number of Rocky Neighbors at 0
            rockyNeighbors = 0;
        }

        /// <summary>
        /// Initializes the world array, setting a tile type for every tile in the array
        /// </summary>
        private void InitializeWorld()
        {
            // Runs throught the array
            for (int y = 0; y < YSize; y++)
            {
                for (int x = 0; x < XSize; x++)
                {
                    // Gives a 50/50 chance for a tile to be either Ground or Rock
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



