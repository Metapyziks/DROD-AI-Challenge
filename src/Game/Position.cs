﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    struct Position
    {
        public int X;
        public int Y;

        public Position( int x, int y )
        {
            X = x;
            Y = y;
        }

        public static Position operator +( Position a, Position b )
        {
            return new Position( a.X + b.X, a.Y + b.Y );
        }

        public static Position operator -( Position a, Position b )
        {
            return new Position( a.X - b.X, a.Y - b.Y );
        }

        public Position BestVector( Position pos )
        {
            Position dist = pos.Wrap() - this.Wrap();

            if ( dist.X >= GameState.MapWidth >> 1 )
                dist.X -= GameState.MapWidth;
            else if ( dist.X < -( GameState.MapWidth >> 1 ) )
                dist.X += GameState.MapWidth;

            if ( dist.Y >= GameState.MapHeight >> 1 )
                dist.Y -= GameState.MapHeight;
            else if ( dist.Y < -( GameState.MapHeight >> 1 ) )
                dist.Y += GameState.MapHeight;

            return dist;
        }

        public Position Wrap()
        {
            return new Position(
                X - (int) Math.Floor( (double) X / GameState.MapWidth ) * GameState.MapWidth,
                Y - (int) Math.Floor( (double) Y / GameState.MapHeight ) * GameState.MapHeight
            );
        }
    }
}
