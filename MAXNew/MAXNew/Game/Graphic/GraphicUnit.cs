using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.Game.Graphic
{
    public struct FrameInfo
    {
        public Vector2 centerDelta;

        public Rectangle rect;
    }
    public class GraphicUnit
    {
        public FrameInfo[] frames;
        public Texture2D[] textures;

        public GraphicUnit(int frameCount)
        {
            frames = new FrameInfo[frameCount];
            textures = new Texture2D[frameCount];
        }

    }
}
