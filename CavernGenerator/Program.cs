using System;

namespace CavernGenerator
{
    /// <summary>
    /// Initializes the program
    /// </summary>
    class Program
    {
        // Declare a generator
        private static Generator caveGenerator;
        // Declare a renderer
        private static Renderer renderer;

        /// <summary>
        /// Runs at the start of the program
        /// </summary>
        /// <param name="args">Arguments passed in from the command line</param>
        static void Main(string[] args)
        {
            // Initialize the generator
            caveGenerator = new Generator(args);
            // Initialize the renderer
            renderer = new Renderer(caveGenerator);

            // Generate a new Cavern
            caveGenerator.Generate();

            // Render the Cavern
            renderer.RenderCavern();
        }
    }
}
