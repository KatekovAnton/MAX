using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.ResourceProviders
{
    public class ImagePart: IDisposable
    {
        public CashedTexture2D texture;
        public Rectangle? sourceRct;
        public bool disposed;

        public ImagePart(CashedTexture2D _texture, Rectangle? _sourceRct)
        {
            texture = _texture;
            texture.Retain();
            sourceRct = _sourceRct;
        }
        public void Dispose()
        {
            texture.Release();
            disposed = true;
        }
        ~ImagePart()
        {
            if (!disposed)
                Dispose();
        }
    }
}
