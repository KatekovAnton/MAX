using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.ResourceProviders
{
    public class ImagePart
    {
        public CashedTexture2D texture;
        public Rectangle? sourceRct;
        public ImagePart(CashedTexture2D _texture, Rectangle? _sourceRct)
        {
            texture = _texture;
            sourceRct = _sourceRct;
        }
        ~ImagePart()
        {
            ImageCache.Instance.RemoveImage(texture.name);
            texture = null;
        }
    }
}
