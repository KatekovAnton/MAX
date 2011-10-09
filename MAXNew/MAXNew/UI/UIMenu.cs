using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAXNew.UI
{
    public class UIMenu : UIControl
    {


        public override void AddChild(UIControl child)
        {
            UIMenuItem test = child as UIMenuItem;
            if (test != null)
                base.AddChild(child);
        }
        public override void AddChild(UIControl child, string name)
        {
            UIMenuItem test = child as UIMenuItem;
            if (test != null)
                base.AddChild(child, name);
        }
    }
}
