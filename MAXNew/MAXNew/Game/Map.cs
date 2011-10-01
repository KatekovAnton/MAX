using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MAXNew.Game.Graphic;

namespace MAXNew.Game
{
    public sealed class Map
    {
        public string name;
        public int w, h;
        public short elementCount;
        
        public short[] map;
        public byte[] groundType;//0-ground 1-water 2-coast 3-unpassable


        public byte[][] mapElements;
        public byte[] minimap;
        public byte[] palette;
       

        public GraphicMap mapDraw;

        public void clearLoadData()
        {
            palette = null;
            minimap = null;
            mapElements = null;
        }

        public void draw()
        {
            SpriteBatch spr = GraphicMap.mapSprite;
            Camera cam = Game1.camera;

            spr.Begin(SpriteSortMode.Deferred,BlendState.Opaque,SamplerState.PointClamp,DepthStencilState.None,RasterizerState.CullNone);
            float dx = 0;
            float dy = 64 * cam.visibleMapCELLBounds.Y;
            Vector2 campoint = new Vector2((float)Math.Floor((double)cam.topleftPoint.X), (float)Math.Floor((double)cam.topleftPoint.Y));
            float camscale = cam.scale + 0.03f;
            for (int i = cam.visibleMapCELLBounds.Top; i < cam.visibleMapCELLBounds.Bottom; i++)
            {
                dx = 64 * cam.visibleMapCELLBounds.X;
                for (int j = cam.visibleMapCELLBounds.Left; j < cam.visibleMapCELLBounds.Right; j++)
                {
                    int index = i * w + j;
                    spr.Draw(mapDraw.mapElementsSingle,
                        (new Vector2(dx, dy)-cam.topleftPoint)*cam.scale,
                        mapDraw.rectangles[map[index]], 
                        Color.White,
                        0.0f,
                        Vector2.Zero,
                        camscale,
                        SpriteEffects.None,0);
                    dx += 64;
                }
                dy += 64;
            }

            spr.End();
        }
    }
}
