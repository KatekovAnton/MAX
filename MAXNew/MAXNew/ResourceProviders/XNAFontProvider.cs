using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MAXNew.ResourceProviders
{
    public class XNAFontProvider
    {
        public static SpriteFont CourierNew12RegularBold;
        public XNAFontProvider(ContentManager content)
        {
            if (CourierNew12RegularBold == null)
                CourierNew12RegularBold = content.Load<SpriteFont>("SpriteFont1");
        }
    }
}
