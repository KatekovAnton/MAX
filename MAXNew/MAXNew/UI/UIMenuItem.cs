using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public delegate void MenuItemAction(UIMenuItem sender);
    public class UIMenuItem:UIControl
    {
        public int tag;
        public object objectTag;
        public UIMenuItem(Rectangle zone)
            : base(zone)
        { }

        public MenuItemAction onMouseUp;
    }
}
