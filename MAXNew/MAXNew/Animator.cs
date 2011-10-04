using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew
{
    public class Animator
    {
        public static Animator Instance = new Animator();
        List<AnimatedObject> aobjects;
        public Animator()
        {
            aobjects = new List<AnimatedObject>();
        }
        public void Update(GameTime gtime)
        {
            foreach (AnimatedObject ao in aobjects)
                ao.Update(gtime);
        }
        public void AddAObject(object key,Action act,double freq)
        {
            aobjects.Add(new AnimatedObject(act, freq, key));
        }
    }
    public class AnimatedObject
    {
        public Action action;
        public double lastUpdateTime;
        public double updateFreq;
        public object key;
        public AnimatedObject(Action _action, double _updateFreq, object _key)
        {
            this.action = _action;
            updateFreq = _updateFreq;
 key = _key;
        }
        public void Update(GameTime gtime)
        {
            if (gtime.TotalGameTime.TotalMilliseconds - lastUpdateTime >= updateFreq)
            {
                lastUpdateTime = gtime.TotalGameTime.TotalMilliseconds;
                action();
            }

        }
    }
}
