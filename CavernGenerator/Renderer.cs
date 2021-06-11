using System;
using System.Collections.Generic;
using System.Text;

namespace CavernGenerator
{
    class Renderer
    {
        private Generator generator;
        public Renderer (Generator generator)
        {
            this.generator = generator;
        }

        public void RenderCavern()
        {
            for (int y = 0; y < generator.YSize; y++)
            {
                for (int x = 0; x < generator.XSize; x++)
                {
                    Console.Write(generator.World[x, y].Sprite);
                }
                Console.WriteLine();
            }
        }
    }
}
