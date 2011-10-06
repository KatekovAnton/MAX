using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAXNew;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public abstract class UIControl
    {
        public UIControl parent;
        public MyContainer<UIControl> childrens;

        public Rectangle? scissorRect;
        public Vector2 position;
        private Action drawAction;


        protected UIControl(UIControl parent)
        {
            this.parent = parent;
            childrens = new MyContainer<UIControl>(10, 1);
        }
        
        

    }
}
