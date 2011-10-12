using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public class UIRootControl:UIControl
    {
        public static MyContainer<UIMenu> menus = new MyContainer<UIMenu>();


        public UIRootControl()
            : base(new Rectangle(0, 0, GameConfiguration.ScreenBounds.Width, GameConfiguration.ScreenBounds.Height))
        {
            drawMethod = Draw;
        }

        public void Draw(SpriteBatch _sb, Vector2 _position)
        {
 
        }
    }
}
