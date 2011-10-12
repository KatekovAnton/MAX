using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using MAXNew.ResourceProviders;

namespace MAXNew.UI
{
    public class UIMenuItemButton : UIMenuItem
    {
        public MenuItemAction onMouseUp;
        public MenuItemAction onMouseDown;

        ImagePart IdleImage;
        ImagePart PressedImage;

        public UIMenuItemButton(Rectangle zone, UIControlController baseController)
            : base(zone, baseController)
        { }

        protected override void internalMouseDown()
        {
            onMouseDown(this);
        }
        protected override void internalMouseDrag()
        {

        }
        protected override void internalMouseUp()
        {
            onMouseUp(this);
        }

        private void _draw(SpriteBatch sb, Vector2 position)
        {
        }
    }
}
