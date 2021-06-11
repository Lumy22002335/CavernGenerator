using System;
using System.Collections.Generic;
using System.Text;

namespace CavernGenerator
{
    class Generator
    {
        private int xSize;
        private int ySize;
        private int steps;

        private Tile[,] world;

        public Generator(string[] args) 
        {
            xSize = Convert.ToInt32(args[0]);
            ySize = Convert.ToInt32(args[1]);
            steps = Convert.ToInt32(args[2]);
        }

        public void InitializeWorld()
        {

        }

        public void Generate()
        {
            
        }
    }
}



