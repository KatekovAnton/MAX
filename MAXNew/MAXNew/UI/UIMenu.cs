using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public class UIMenu : UIControl
    {
        public int priority;

        public UIMenu(Rectangle zone)
            : base(zone)
        {
            UIRootControl.menus.Add(this);
        }

        public override void AddChild(UIControl child)
        {
            UIMenu test1 = child as UIMenu;
            if (test1 != null)
                throw new Exception("unable to add menu in menu!!");

            UIMenuItem test = child as UIMenuItem;
            if (test != null)
                base.AddChild(child);
        }
        public override void AddChild(UIControl child, string name)
        {
            UIMenu test1 = child as UIMenu;
            if (test1 != null)
                throw new Exception("unable to add menu in menu!!");

            UIMenuItem test = child as UIMenuItem;
            if (test != null)
                base.AddChild(child, name);
        }
    }
}
