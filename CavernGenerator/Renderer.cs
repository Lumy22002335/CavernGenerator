using System;

namespace CavernGenerator
{
    /// <summary>
    /// Render Class is responsible for rendering the final cavern shape
    /// </summary>
    class Renderer
    {
        /// <value>
        /// Reference to the generator class
        /// </value>
        private Generator generator;

        /// <summary>
        /// Renderer constructor that gets a reference to the generator class
        /// </summary>
        /// <param name="generator">reference to the generator class</param>
        public Renderer (Generator generator)
        {
            this.generator = generator;
        }

        /// <summary>
        /// Renders the Cavern
        /// </summary>
        public void RenderCavern()
        {
            // Runs through the array
            for (int y = 0; y < generator.YSize; y++)
            {
                for (int x = 0; x < generator.XSize; x++)
                {
                    // Render the sprite for the current tile
                    Console.Write(generator.World[x, y].Sprite);
                }
                // Line break
                Console.WriteLine();
            }
        }
    }
}
