using System;

namespace CavernGenerator
{
    class Program
    {
        private static Generator caveGenerator;
        private static Renderer renderer;

        static void Main(string[] args)
        {
            caveGenerator = new Generator(args);
            renderer = new Renderer(caveGenerator);

            caveGenerator.InitializeWorld();
            caveGenerator.Generate();

            renderer.RenderCavern();
        }
    }
}