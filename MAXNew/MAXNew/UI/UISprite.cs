using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public class UISprite:UIControl
    {
        public UIImagePart image;
        public UISprite(Texture2D _tex)
        {
            image = new UIImagePart(_tex, null);
            drawMethod = DrawSelfMinimal;
        }

        public UISprite(Texture2D _tex, Rectangle _sourceRect, Vector2 _position)
        {
            image = new UIImagePart(_tex, _sourceRect);
            drawMethod = DrawSelfPart;
        }

        private void DrawSelfFull(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture, position + _position, image.sourceRct, color, 0.0f, origin, scale, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0.0f);
        }

        private void DrawSelfMinimal(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture, position + _position, color);
        }

        private void DrawSelfToRect(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture, new Rectangle(destinationRect.Value.X + (int)_position.X, destinationRect.Value.Y + (int)_position.Y, destinationRect.Value.Width, destinationRect.Value.Height), color);
        }

        private void DrawSelfPartToRect(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture, new Rectangle(destinationRect.Value.X + (int)_position.X, destinationRect.Value.Y + (int)_position.Y, destinationRect.Value.Width, destinationRect.Value.Height), image.sourceRct, color);
        }

        private void DrawSelfPart(SpriteBatch _activeSpriteBatch, Vector2 _position)
        {
            _activeSpriteBatch.Draw(image.texture, position + _position, image.sourceRct, color);
        }


    }
}
