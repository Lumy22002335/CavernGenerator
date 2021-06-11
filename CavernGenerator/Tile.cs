using System;
using System.Collections.Generic;
using System.Text;

namespace CavernGenerator
{
    /// <summary>
    /// Tile to represent a defined place in the cavern
    /// </summary>
    struct Tile
    {
        /// <value> 
        /// Hold the char value so this tile can be "." or "#" depending on the type 
        /// </value>
        public char Sprite { get => Type == TileType.Ground ? '.' : '#'; }

        /// <value> 
        /// The type of tile can be Rock or Ground
        /// </value>
        public TileType Type { get; set; }

        /// <summary>
        /// Tile constructor that defines the tile type
        /// </summary>
        /// <param name="type">The type for this tile can be Rock or Ground</param>
        public Tile(TileType type)
        {
            Type = type;
        }
    }
}
