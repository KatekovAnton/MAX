using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public delegate void MenuItemAction(UIMenuItem sender);
    public enum UIMenuItemState
        {
            pressed,
            released
        };
    public abstract class UIMenuItem:UIControl
    {
        public int tag;
        public object objectTag;

        public MenuItemAction onMouseUp;

        protected UIMenuItemState currentstate;
        protected UIMenuItemState laststate;
        protected UIControlController baseController;
        public UIMenuItem(Rectangle zone, UIControlController basecontroller)
            : base(zone)
        {
            baseController = basecontroller;
            basecontroller.rootControl.AddChild(this);
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

        public void Update(UIMenuItemState actionType)
        {
            laststate = currentstate;
            currentstate = actionType;

            if (currentstate != laststate)
            {
                if (currentstate == UIMenuItemState.pressed && laststate == UIMenuItemState.released)
                    internalMouseDown();
                else if (currentstate == UIMenuItemState.released && laststate == UIMenuItemState.pressed)
                    internalMouseUp();
            }
            else
                if (currentstate == UIMenuItemState.pressed)
                    internalMouseDrag();
        }

        protected abstract void internalMouseUp();
        protected abstract void internalMouseDown();
        protected abstract void internalMouseDrag();

    }
}
