using System;

namespace CavernGenerator
{
    class Program
    {
        private static Generator caveGenerator;

        static void Main(string[] args)
        {
            caveGenerator = new Generator(args);
            caveGenerator.InitializeWorld();
            caveGenerator.Generate();
        }
    }
}