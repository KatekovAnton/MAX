using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAXNew.TextureCache;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public class UIImageCache
    {
        public static UIImageCache Instance = new UIImageCache();

        
        public Dictionary<string, CashedTexture2D> imageCashe;

        protected UIImageCache()
        {
            imageCashe = new Dictionary<string, CashedTexture2D>();
        }

        public Texture2D getImage(string name)
        {
            CashedTexture2D texture = null;
            bool alreadyloaded = imageCashe.TryGetValue(name, out texture);
            if (alreadyloaded && texture != null)
            {
                texture.userCount++;
                return texture.texture;
            }

            return null;
        }
    }
}
