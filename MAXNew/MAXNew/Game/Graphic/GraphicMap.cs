using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAXNew.Tools;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.Game.Graphic
{
    public class GraphicMap
    {
        public static SpriteBatch mapSprite;
        public Texture2D minimap;
        public Texture2D mapElementsSingle;
        public Microsoft.Xna.Framework.Rectangle[] rectangles;
        public GraphicMap(Map map)
        {
            minimap = GraphicTools.TextureFromIndexAndPalette(map.w, map.h, map.minimap, map.palette);


            int w = 20;
            int h = map.elementCount / w;
            if (w * h < map.elementCount)
                h++;

            byte[] singleArray = new byte[w * h * 64 * 64];
            rectangles = new Microsoft.Xna.Framework.Rectangle[map.elementCount];
            //по блокам
            for (int i = 0; i < map.elementCount; i++)
            {
                int x = i % w;
                int y = i / w;
                //каждый блок по строчке
                for (int j = 0; j < 64; j++)
                    Buffer.BlockCopy(map.mapElements[i], j * 64, singleArray, x * 64 + w * 64 * 64 * y + j * 64 * w, 64);
                rectangles[i].X = x * 64;
                rectangles[i].Y = y * 64;
                rectangles[i].Width = 64;
                rectangles[i].Height = 64;
            }

            mapElementsSingle = GraphicTools.TextureFromIndexAndPalette(64 * w, 64 * h, singleArray, map.palette);
        }
    }
}
