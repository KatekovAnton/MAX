using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAXNew.Tools;
using MAXNew.Config;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.Game
{
    public sealed class Camera
    {
        //sataic camera scroll speed
        public static double scrollSpeed = 16.0;


        //for scale (in world coord)
        public Vector2 currentCenter;
        //current scale
        public double scale;


        //full map rectangle (without scale)
        public Rectangle mapBounds;
        //screen rectangle in screen coords
        public Rectangle visibleScreenBounds;
        //screen rectangle in world coords (scaled/moved)
        public Rectangle visibleMapBounds;
        //map cells in screen rectangle
        public Rectangle visibleMapCELLBounds;


        //coordSystem for drawing
        public Vector2 topleftPoint;

        public Camera(Map map)
        {
            mapBounds.X = mapBounds.Y = 0;
            mapBounds.Width = map.w * 64;
            mapBounds.Height = map.h * 64;

            //FIXME- add scale
            visibleMapBounds.Width = visibleMapBounds.X + (int)GameConfiguration.ScreenResolution.X;
            visibleMapBounds.Height = visibleMapBounds.Y + (int)GameConfiguration.ScreenResolution.Y;
            correctScreen();
        }

        public void updateScale(GameTime gt, Vector2 mousePos, float scaleRange)
        {
            if (scaleRange == 0)
                return;
        }

        public void updateMove(GameTime gt, Vector2 moveVector)
        {
            float moveRange = (float)(gt.ElapsedGameTime.TotalMilliseconds * scrollSpeed / 10);
            visibleMapBounds.X += (int)(moveVector.X * moveRange);
            visibleMapBounds.Y += (int)(moveVector.Y * moveRange);

            correctBounds();
            correctScreen();
        }

        public void correctScreen()
        {
            topleftPoint.X = visibleMapBounds.X;
            topleftPoint.Y = visibleMapBounds.Y;

            visibleMapCELLBounds.X = visibleMapBounds.X / 64;
            visibleMapCELLBounds.Y = visibleMapBounds.Y / 64;

            visibleMapCELLBounds.Width = (visibleMapBounds.Width+127) / 64 ;
            visibleMapCELLBounds.Height = (visibleMapBounds.Height+127) / 64 ;
        }

        public void correctBounds()
        {
            if (visibleMapBounds.Left < mapBounds.Left)
                visibleMapBounds.X = mapBounds.X;
            else if (visibleMapBounds.Right + GameConfiguration.ScreenResolution.X > mapBounds.Right)
                visibleMapBounds.X -= visibleMapBounds.Right + (int)GameConfiguration.ScreenResolution.X - mapBounds.Right;

            if (visibleMapBounds.Top < mapBounds.Top)
                visibleMapBounds.Y = mapBounds.Y;
            else if (visibleMapBounds.Bottom+GameConfiguration.ScreenResolution.Y > mapBounds.Bottom)
                visibleMapBounds.Y -= visibleMapBounds.Bottom + (int)GameConfiguration.ScreenResolution.Y - mapBounds.Bottom;
        }
    }
}
 