using System;
using System.Collections.Generic;
using System.Text;

namespace CavernGenerator
{
    struct Tile
    {
        public char Sprite { get => Type == TileType.Ground ? '.' : '#'; }

        public TileType Type { get; set; }
    }
}
