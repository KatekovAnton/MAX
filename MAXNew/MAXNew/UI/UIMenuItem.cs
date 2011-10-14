using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public delegate void MenuItemAction(UIMenuItem sender);
    public enum UIMenuItemInputState
        {
            pressed,
            released
        };
    public abstract class UIMenuItem:UIControl
    {
        public int tag;
        public object objectTag;

        protected UIMenuItemInputState currentstate= UIMenuItemInputState.released;
        protected UIMenuItemInputState laststate = UIMenuItemInputState.released;
        public UIMenuItem(Rectangle zone, UIMenu baseMenu)
            : base(zone)
        {
            baseMenu.AddChild(this);
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

        public void Update(UIMenuItemInputState actionType, bool isToThisObject)
        {
            if (actionType != laststate)
            {
                if (currentstate == UIMenuItemInputState.pressed && laststate == UIMenuItemInputState.released)
                    internalMouseDown(isToThisObject);
                else if (currentstate == UIMenuItemInputState.pressed && laststate == UIMenuItemInputState.pressed)
                    internalMouseUp(isToThisObject);
            }
            else
                if (currentstate == UIMenuItemInputState.pressed)
                    internalMouseDrag();
            
            laststate = currentstate;
            currentstate = actionType;
        }

        protected abstract void internalMouseUp(bool hisAction);
        protected abstract void internalMouseDown(bool hisAction);
        protected abstract void internalMouseDrag();

    }
}
