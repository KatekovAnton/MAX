using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public class UIImagePart
    {
        public Texture2D texture;
        public Rectangle? sourceRct;
        public UIImagePart(Texture2D _texture, Rectangle? _sourceRct)
        {
            texture = _texture;
            sourceRct = _sourceRct;
        }
    }
}
