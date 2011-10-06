using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public class UIManager
    {
        public static UIManager Instance;

        public GraphicsDevice mainDevice
        {
            get;
            private set;
        }

        public UIManager(GraphicsDevice device)
        {
            Instance = this;
            mainDevice = device;

        }
    }
}
