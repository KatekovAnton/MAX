using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public delegate string GetString();
    public class UILabel:UIControl
    {
        GetString getstr;
        public UILabel(Rectangle rect)
            : base(rect)
        { }

        protected override void DisposeSelf()
        {
            
        }
    }
}
