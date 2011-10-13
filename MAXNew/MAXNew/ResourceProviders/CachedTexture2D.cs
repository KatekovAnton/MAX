using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.ResourceProviders
{
    public class CashedTexture2D
    {
        public Texture2D texture;
        public int userCount = 0;
        public string name;

        public CashedTexture2D(Texture2D _texture, string nm)
        {
            name = nm;
            texture = _texture;
        }

        public void retain()
        {
            userCount++;
        }

        public void release()
        {
            userCount--;
        }
    }
}
