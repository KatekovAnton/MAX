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
        public float scale;
        public float scaleSpeed;
        public float scaleMinBound;


        //map cell counts
        int w, h;

        //full map rectangle (without scale)
        public Rectangle mapBounds;
        //screen rectangle in screen coords
        public Rectangle visibleScreenBounds;

        //screen rectangle in world coords (scaled/moved)
        public Rectangle visibleMapBounds;
        //screen rectangle in world coords (not scaled/not moved)
        public Rectangle basicVisibleMapBounds;


        //map cells in screen rectangle
        public Rectangle visibleMapCELLBounds;


        //coordSystem for drawing (in world coord)
        public Vector2 topleftPoint;

        public Camera(Map map)
        {
            scale = 1.0f;
            scaleSpeed = 1.0f;
            mapBounds.X = mapBounds.Y = 0;
            mapBounds.Width = map.w * 64;
            mapBounds.Height = map.h * 64;

            w = map.w;
            h = map.h;

            //FIXME- add scale
            visibleMapBounds.Width = visibleMapBounds.X + (int)GameConfiguration.ScreenResolution.X;
            visibleMapBounds.Height = visibleMapBounds.Y + (int)GameConfiguration.ScreenResolution.Y;

            basicVisibleMapBounds.Width = (int)GameConfiguration.ScreenResolution.X;
            basicVisibleMapBounds.Height = (int)GameConfiguration.ScreenResolution.Y;
            
            float scaleMinBoundX,scaleMinBoundY;
            scaleMinBoundX = GameConfiguration.ScreenResolution.X / (map.w * 64);
            scaleMinBoundY = GameConfiguration.ScreenResolution.Y / (map.h * 64);
            scaleMinBound = scaleMinBoundX > scaleMinBoundY ? scaleMinBoundX : scaleMinBoundY;
            correctScreen();
        }

        public void updateScale(GameTime gt, Vector2 mousePos, float scaleRange)
        {
            if (scaleRange == 0)
                return;
            float moveRange = (float)(gt.ElapsedGameTime.TotalMilliseconds * scaleRange * scaleSpeed / 100);
            Vector2 moseWorldScreenDeltaPos = new Vector2(mousePos.X / scale,  mousePos.Y / scale);
            float oldscale = scale;

            scale += moveRange;
            if (scale < 0.1f)
                scale = 0.1f;
            if (scale > 1.0f)
                scale = 1.0f;

            if (scale < scaleMinBound)
                scale = scaleMinBound;

            //если удаляем то отрицательное
           // Vector2 moseWorldScreenDeltaPosNew = moseWorldScreenDeltaPos  - new Vector2(mousePos.X / scale,  mousePos.Y / scale);

            visibleMapBounds.X += (int)(moseWorldScreenDeltaPos.X - mousePos.X / scale);
            visibleMapBounds.Y += (int)(moseWorldScreenDeltaPos.Y - mousePos.Y / scale);

            visibleMapBounds.Width = (int)((float)basicVisibleMapBounds.Width / scale);
            visibleMapBounds.Height = (int)((float)basicVisibleMapBounds.Height / scale);
        }

        public void updateMove(GameTime gt, Vector2 moveVector)
        {
            float moveRange = (float)(gt.ElapsedGameTime.TotalMilliseconds * scrollSpeed / 10);
            visibleMapBounds.X += (int)(moveVector.X * moveRange);
            visibleMapBounds.Y += (int)(moveVector.Y * moveRange);
        }

        public void UpdateFinalInfo()
        {
            correctBounds();
            correctScreen();
        }

        public void correctScreen()
        {
            topleftPoint.X = visibleMapBounds.X;
            topleftPoint.Y = visibleMapBounds.Y;

            visibleMapCELLBounds.X = visibleMapBounds.X / 64;
            visibleMapCELLBounds.Y = visibleMapBounds.Y / 64;

            visibleMapCELLBounds.Width = (visibleMapBounds.Width+128) / 64 ;
            visibleMapCELLBounds.Height = (visibleMapBounds.Height+128) / 64 ;

            if (visibleMapCELLBounds.Right >= w)
                visibleMapCELLBounds.Width = w - visibleMapCELLBounds.Left;
            if (visibleMapCELLBounds.Bottom >= h)
                visibleMapCELLBounds.Height = h - visibleMapCELLBounds.Top;
        }

        public void correctBounds()
        {
            float wlength = GameConfiguration.ScreenResolution.X / scale;
            float hlength = GameConfiguration.ScreenResolution.Y / scale;


            if (visibleMapBounds.Left < mapBounds.Left)
                visibleMapBounds.X = mapBounds.X;
            else if (visibleMapBounds.Right> mapBounds.Right)
                visibleMapBounds.X -= visibleMapBounds.Right - mapBounds.Right;
            

            if (visibleMapBounds.Top < mapBounds.Top)
                visibleMapBounds.Y = mapBounds.Y;
            else if (visibleMapBounds.Bottom > mapBounds.Bottom)
                visibleMapBounds.Y -= visibleMapBounds.Bottom - mapBounds.Bottom;
        }
    }
}
 