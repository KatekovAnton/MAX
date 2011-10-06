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
        private static UIStaticInfo instance;
        public static UIStaticInfo Instance
        {
            get
            {
                if (instance == null)
                    instance = new UIStaticInfo();
                return instance;
            }
        }
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
        public SpriteBatch spriteBatch;

        protected UIStaticInfo() 
        {
            scissorDisabledState = new RasterizerState();
            scissorEnabledState = new RasterizerState();
            scissorEnabledState.ScissorTestEnable = true;
            spriteBatch = new SpriteBatch(UIManager.Instance.mainDevice);
        }
    }
}
