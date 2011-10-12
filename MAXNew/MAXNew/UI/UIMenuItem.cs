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

        public MenuItemAction onMouseUp;


        public UIMenuItem(Rectangle zone)
            : base(zone)
        {
            
        }

        public override void AddChild(UIControl child)
        {
            UIMenu test1 = child as UIMenu;
            if (test1 != null)
                throw new Exception("unable to add menu in menu item!!");

            UIMenuItem test = child as UIMenuItem;
            if (test != null)
                throw new Exception("unable to add menu item in menu item!!");

            base.AddChild(child);
        }
        public override void AddChild(UIControl child, string name)
        {
            UIMenu test1 = child as UIMenu;
            if (test1 != null)
                throw new Exception("unable to add menu in menu item!!");

            UIMenuItem test = child as UIMenuItem;
            if (test != null)
                throw new Exception("unable to add menu item in menu item!!");

            base.AddChild(child, name);
        }
    }
}
