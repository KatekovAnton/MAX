using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAXNew;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public sealed class UIStaticInfo
    {
        public static UIStaticInfo Instance = new UIStaticInfo();
        public RasterizerState scissorEnabledState
        {
            get;
            private set;
        }
        public RasterizerState scissorDisabledState
        {
            get;
            private set;
        }

        protected UIStaticInfo() 
        {
            scissorDisabledState = new RasterizerState();
            scissorEnabledState = new RasterizerState();
            scissorEnabledState.ScissorTestEnable = true;
        }
    }
}
