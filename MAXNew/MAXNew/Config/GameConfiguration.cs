using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.Config
{
    public sealed class GameConfiguration
    {
        public static Vector2 halfCell = new Vector2(32, 32);
        public static Rectangle ScreenBounds;
        public static Vector2 ScreenResolution;
        public static float scaleFullMin = 0.1f;

        public static Dictionary<string, string> rules = new Dictionary<string,string>();
    }
}
