using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAXNew;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public delegate void DrawDelegate(SpriteBatch sb, Vector2 position);
    public abstract class UIControl
    {
        private UIControl parent = null;
        private MyContainer<UIControl> childrens;
        private Dictionary<string, UIControl> childByNames;


        public Rectangle? scissorRect;
        public Rectangle? destinationRect;
        public Vector2 position = Vector2.Zero;
        public Vector2 origin = Vector2.Zero;
        public Color color = Color.White;
        public Vector2 scale = new Vector2(1, 1);

        

        protected DrawDelegate drawMethod;

        protected UIControl()
        {
            childrens = new MyContainer<UIControl>(10, 1);
            childByNames = new Dictionary<string, UIControl>();
        }

        public void Draw(Vector2 position)
        {
            drawMethod(UIStaticInfo.Instance.spriteBatch, position);
            foreach (UIControl child in childrens)
                child.Draw(position+this.position);
        }

        public virtual void AddChild(UIControl child)
        {
            if (child.parent != null)
                throw new Exception("You are trying to add already added control");
            if (!childrens.Contains(child))
            {
                childrens.Add(child);
                child.parent = this;
            }
        }


        public virtual void AddChild(UIControl child, string name)
        {
            if (child.parent != null)
                throw new Exception("You are trying to add already added control");
            if (!childrens.Contains(child))
            {
                childrens.Add(child);
                childByNames.Add(name, child);
            }
            else if (!childByNames.ContainsKey(name))
            {
                childByNames.Add(name, child);
                child.parent = this;
            }
        }

        public UIControl getChildByName(string name)
        {
            UIControl control = null;
            if (childByNames.TryGetValue(name, out control))
                return control;
            return null;
        }
    }
}
