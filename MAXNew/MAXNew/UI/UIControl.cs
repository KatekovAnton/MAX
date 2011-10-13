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
    public abstract class UIControl: IDisposable
    {
        public int level;

        private UIControl parent = null;
        protected MyContainer<UIControl> childrens;
        protected Dictionary<string, UIControl> childByNames;

        private Rectangle controlZone;
        private Rectangle globalControlZone;

        public bool useScissorrect = false;
        public Rectangle scissorRect;
        public Rectangle? destinationRect;
        private Vector2 position = Vector2.Zero;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                Vector2 delta = value - position;
                Move(delta);
            }
        }

        public void Move(Vector2 delta)
        {
            position += delta;
            controlZone.X += (int)delta.X;
            controlZone.Y += (int)delta.Y;

            globalControlZone.X += (int)delta.X;
            globalControlZone.Y += (int)delta.Y;

            if (useScissorrect)
            {
                scissorRect.X += (int)delta.X;
                scissorRect.Y += (int)delta.Y;
            }


            foreach (UIControl child in childrens)
                child.Move(delta);
        }

        protected Vector2 origin = Vector2.Zero;

        public Color color = Color.White;
        public Vector2 scale = new Vector2(1, 1);

        

        protected DrawDelegate drawMethod;

        protected UIControl(Rectangle zone)
        {
            controlZone = zone;
            globalControlZone = zone;
            childrens = new MyContainer<UIControl>(10, 1);
            childByNames = new Dictionary<string, UIControl>();
            position = new Vector2(zone.X, zone.Y);
        }

        public void SetControlZone(Rectangle zone)
        {
            Point delta = new Point(zone.X - controlZone.X, zone.Y - controlZone.Y);


            controlZone = zone;
            globalControlZone.X = parent.globalControlZone.X + controlZone.X;
            globalControlZone.Y = parent.globalControlZone.Y + controlZone.Y;

           
            if (useScissorrect)
            {
                scissorRect.X += delta.X;
                scissorRect.Y += delta.Y;
            }

            foreach (UIControl c in childrens)
                c.SetParent(this);
        }

        public void SetParent(UIControl control)
        {
            Point delta;
            if (control != null)
            {
                if (parent == null)
                    delta = new Point(control.globalControlZone.X, control.globalControlZone.Y);
                else
                    delta = new Point(control.globalControlZone.X - parent.globalControlZone.X, control.globalControlZone.Y - parent.globalControlZone.Y);
            }
            else
            {
                if (parent == null)
                    delta = new Point(0,0);
                else
                    delta = new Point(- parent.globalControlZone.X, -parent.globalControlZone.Y);
            }
            globalControlZone.X = controlZone.X + delta.X;
            globalControlZone.Y = controlZone.Y + delta.Y;
            parent = control;

            if (useScissorrect)
            {
                scissorRect.X += delta.X;
                scissorRect.Y += delta.Y;
            }

            foreach (UIControl c in childrens)
                c.SetParent(this);
        }

        public virtual void Draw(Vector2 position)
        {
            if(drawMethod!=null)
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
                child.SetParent(this);
                child.level = level + 1;
            }
        }

        public virtual void AddChild(UIControl child, string name)
        {
            if (child.parent != null)
                throw new Exception("You are trying to add already added control");
            if (!childrens.Contains(child))
            {
                childrens.Add(child);
                child.SetParent(this);
                childByNames.Add(name, child);
                child.level = level + 1;
            }
            else if (!childByNames.ContainsKey(name))
                childByNames.Add(name, child);
            
        }

        public UIControl GetChildByName(string name)
        {
            UIControl control = null;
            if (childByNames.TryGetValue(name, out control))
                return control;
            return null;
        }

        public UIControl GetChildInPoint(Point point)
        {
            foreach(UIControl c in childrens)
                if(c.HavePoint(point))
                    return c;
            return null;
        }

        public bool RemoveChild(UIControl child)
        {
            Dictionary<string, UIControl>.KeyCollection keys = childByNames.Keys;
            foreach (string str in keys)
            {
                UIControl control = null;
                if (childByNames.TryGetValue(str, out control) && control == child)
                    childByNames.Remove(str);
                
            }
            return (childrens.Remove(child));
     
        }

        public bool HavePoint(Point p)
        {
            return globalControlZone.Contains(p);
        }

        protected bool isDisposedSelf;
        protected bool isDisposedBase;

        protected abstract void DisposeSelf();
        protected void DisposeBase()
        {
            DisposeSelf();
            foreach (UIControl contr in childrens)
            {
                contr.DisposeBase();
                contr.DisposeSelf();
            }
            isDisposedBase = true;
        }
        public void Dispose()
        {
            if(!isDisposedBase)
                DisposeBase();
        }
        ~UIControl()
        {
            Dispose();
        }
    }
}
