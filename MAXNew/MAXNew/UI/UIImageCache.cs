using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAXNew.TextureCache;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public enum TextureType
    {
        Simple,
        Paletted,
        OutherPng
    };
    public class UIImageCache
    {

        public static UIImageCache Instance = new UIImageCache();
        public Dictionary<string, CashedTexture2D> imageCashe;

        protected UIImageCache()
        {
            imageCashe = new Dictionary<string, CashedTexture2D>();
        }

        public Texture2D getImage(string name, TextureType type)
        {
            CashedTexture2D texture = null;
            bool alreadyloaded = imageCashe.TryGetValue(name, out texture);
            if (alreadyloaded && texture != null)
            {
                texture.userCount++;
                return texture.texture;
            }
            switch (type)
            {
                case TextureType.Simple:
                    texture = new CashedTexture2D(MAXRESImageProvider.Instance.loadSimpleImage(name));
                    break;
                case TextureType.Paletted:
                    texture = new CashedTexture2D(MAXRESImageProvider.Instance.loadPalettedImage(name));
                    break;
                case TextureType.OutherPng:
                    {
                        //TODO: set stream
                        texture = new CashedTexture2D(Texture2D.FromStream(Game1.device, null));
                    } break;
                default: break;

            }
            imageCashe.Add(name, texture);
            texture.userCount++;
            return texture.texture;
        }

        public void RemoveImage(string name)
        {
            CashedTexture2D image = null;
            if (!imageCashe.TryGetValue(name, out image))
             return;
            
            image.userCount--;
            if(image.userCount==0)
                imageCashe.Remove(name);
            
        }

        ~UIImageCache()
        {
            imageCashe.Clear();
        }
    }
}
