using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.TextureCache
{
    public class CashedTexture2D
    {
        public Texture2D texture;
        public int userCount = 0;
        public CashedTexture2D()
        {
            userCount = 0;
        }
        ~CashedTexture2D()
        {
            texture.Dispose();
        }
    }
}
