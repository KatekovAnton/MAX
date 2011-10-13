using System;
using System.Collections;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public class UIMenu : UIControl
    {
        public static UIMenuPriorityComparer comparer = new UIMenuPriorityComparer();

        public int priority;
        private UIMenuItem receiver;

        public UIMenu(Rectangle zone)
            : base(zone)
        {
            UIManager.menus.Add(this);
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

        public bool AnyChildContainsPoint(Point p)
        {
            receiver = null;
            if (!HavePoint(p))
                return false;

            foreach (UIMenuItem item in childrens)
                if (item.HavePoint(p))
                {
                    receiver = item;
                    return true;
                }
            return false;
        }

        public void Update(UIMenuItemInputState itenState, bool toSameObject)
        {
            receiver.Update(itenState, toSameObject);
        }

        protected override void DisposeSelf()
        {
            UIManager.menus.Remove(this);
            isDisposedSelf = true;
        }

        ~UIMenu()
        {
            if (!isDisposedSelf)
                DisposeSelf();
        }
    }

    public class UIMenuPriorityComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            UIMenu X = x as UIMenu;
            UIMenu Y = y as UIMenu;
            if (X.priority > Y.priority)
                return 1;
            if (X.priority < Y.priority)
                return -1;
            return 0;
        }
    }

}
