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
            image = new ImagePart(_tex, null);
            drawMethod = DrawSelfMinimal;
        }

        public UISprite(CashedTexture2D _tex, Rectangle _sourceRect, Vector2 _position)
            : base(new Rectangle((int)_position.X, (int)_position.Y, _sourceRect.Width, _sourceRect.Height))
        {
            image = new ImagePart(_tex, _sourceRect);
            drawMethod = DrawSelfPart;
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


    }
}
