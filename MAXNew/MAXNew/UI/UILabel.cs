using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public enum UITextAlignment
    {
        Left,
        Right,
        Center
    };

    public class UILabel:UIControl
    {
        string baseText;
        string text;
        UIFont font;
        Color color = Color.White;

        public string Text
        {
            get
            { 
                return baseText; 
            }
            set
            {
                SetText(value);
            }
        }

        public UIFont Font
        {
            get
            { 
                return font; 
            }
            set
            {
                SetFont(value);
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public void SetFont(UIFont _font)
        {
            font = _font;
        }

        public void SetText(string _text)
        {
            text = _text;
            baseText = _text;
        }

        public UILabel(Rectangle rect)
            : base(rect)
        {
            text = baseText = "";
            drawMethod = Draw;
        }

        private void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb, Vector2 position)
        {
            sb.DrawString(font.font, text, position+ Position, color);
        }

        protected override void DisposeSelf()
        {
            
        }
    }
}
