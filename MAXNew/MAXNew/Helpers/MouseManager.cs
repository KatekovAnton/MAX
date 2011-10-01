using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MAXNew.Helpers
{
    public class MouseManager
    {
        public int scrollWheelSTARTValue;
        public int scrollWheelValue;
        public int scrollWheelDelta;

        public Vector2 mousePos;

        public MouseManager()
        {
            MouseState state = Mouse.GetState();
            scrollWheelValue = state.ScrollWheelValue;
            scrollWheelSTARTValue = state.ScrollWheelValue;
        }
        public void Update()
        {
            MouseState state = Mouse.GetState();

            mousePos.X = state.X;
            mousePos.Y = state.Y;

            scrollWheelDelta = scrollWheelValue - state.ScrollWheelValue;
            scrollWheelValue = state.ScrollWheelValue;
            
        }
    }
}
