using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAXNew.ResourceProviders;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.ResourceProviders
{
    public enum TextureType
    {
        Simple,
        Paletted,
        OutherPng
    };
    public class ImageCache
    {

        public static ImageCache Instance = new ImageCache();
        public Dictionary<string, CashedTexture2D> imageCashe;

        protected ImageCache()
        {
            imageCashe = new Dictionary<string, CashedTexture2D>();
        }

        public CashedTexture2D getImage(string name, TextureType type)
        {
            CashedTexture2D texture = null;
            bool alreadyloaded = imageCashe.TryGetValue(name, out texture);
            if (alreadyloaded && texture != null)
            {
                return texture;
            }
            switch (type)
            {
                case TextureType.Simple:
                    texture = new CashedTexture2D(MAXRESImageProvider.Instance.loadSimpleImage(name),name);
                    break;
                case TextureType.Paletted:
                    texture = new CashedTexture2D(MAXRESImageProvider.Instance.loadPalettedImage(name), name);
                    break;
                case TextureType.OutherPng:
                    {
                        //TODO: set stream
                        texture = new CashedTexture2D(Texture2D.FromStream(Game1.device, null), name);
                    } break;
                default: break;

            }
            imageCashe.Add(name, texture);
            return texture;
        }

        public void RemoveImage(string name)
        {
            CashedTexture2D image = null;
            if (!imageCashe.TryGetValue(name, out image))
                return;

            image.userCount--;
            if (image.userCount == 0)
            {
                imageCashe.Remove(name);
                image.texture.Dispose();
            }

        }

        ~ImageCache()
        {
            imageCashe.Clear();
        }
    }
}
