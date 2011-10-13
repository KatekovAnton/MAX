using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MAXNew.ResourceProviders;

namespace MAXNew.UI
{
    public class UISprite:UIControl
    {
        public ImagePart image;
        public UISprite(CashedTexture2D _tex):base(new Rectangle(0,0,_tex.texture.Width,_tex.texture.Height))
        {
            ImagePart newimage = new ImagePart(_tex, null);
            SetSpriteImage(newimage);
        }

        public UISprite(CashedTexture2D _tex, Rectangle _sourceRect, Vector2 _position)
            : base(new Rectangle((int)_position.X, (int)_position.Y, _sourceRect.Width, _sourceRect.Height))
        {
            ImagePart newimage = new ImagePart(_tex, _sourceRect);
            SetSpriteImage(newimage);
        }

        public UISprite(ImagePart _tex, Vector2 _position)
            : base(_tex.sourceRct != null ? new Rectangle((int)_position.X, (int)_position.Y, _tex.sourceRct.Value.Width, _tex.sourceRct.Value.Y) : new Rectangle((int)_position.X, (int)_position.Y, _tex.texture.texture.Width, _tex.texture.texture.Height))
        {
            SetSpriteImage(_tex);
        }

        public void SetSpriteImage(ImagePart newimage)
        {
            if (image != null && !image.disposed)
                image.Dispose();
            image = newimage;
            if (image.sourceRct != null)
                drawMethod = DrawSelfPart;
            else
                drawMethod = DrawSelfMinimal;
        }

        private void DrawSelfFull(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture.texture, Position + _position, image.sourceRct, color, 0.0f, origin, scale, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0.0f);
        }

        private void DrawSelfMinimal(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture.texture, Position + _position, color);
        }

        private void DrawSelfToRect(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture.texture, new Rectangle(destinationRect.Value.X + (int)_position.X, destinationRect.Value.Y + (int)_position.Y, destinationRect.Value.Width, destinationRect.Value.Height), color);
        }

        private void DrawSelfPartToRect(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture.texture, new Rectangle(destinationRect.Value.X + (int)_position.X, destinationRect.Value.Y + (int)_position.Y, destinationRect.Value.Width, destinationRect.Value.Height), image.sourceRct, color);
        }

        private void DrawSelfPart(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture.texture, Position + _position, image.sourceRct, color);
        }

        protected override void DisposeSelf()
        {
            if (!image.disposed)
                image.Dispose();

            isDisposedSelf = true;
        }

        public override void Draw(Vector2 position)
        {
            base.Draw(position);
        }

        ~UISprite()
        {
            if (!isDisposedSelf)
                DisposeSelf();
        }
    }
}
