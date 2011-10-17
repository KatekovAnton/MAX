using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public enum UITextAlignment
    {
        Left,
        Right,
        Center
    };

    public class UILabel:UIControl
    {
        public UILabel(Rectangle rect)
            : base(rect)
        { }

        protected override void DisposeSelf()
        {
            
        }
    }
}
