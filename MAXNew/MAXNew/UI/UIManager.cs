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
        public UIRootControl maincontrol;

        public GraphicsDevice mainDevice
        {
            get;
            private set;
        }

        public UIManager(GraphicsDevice device)
        {
            Instance = this;
            mainDevice = device;
            UIStaticInfo inf = UIStaticInfo.Instance;
            maincontrol = new UIRootControl();
        }

        public void Draw()
        {
            UIStaticInfo.Instance.spriteBatch.Begin();
            Vector2 position = Vector2.Zero;
            maincontrol.Draw(position);

            UIStaticInfo.Instance.spriteBatch.End();
        }
    }
}
