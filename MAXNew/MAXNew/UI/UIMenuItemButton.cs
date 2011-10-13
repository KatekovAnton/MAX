using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using MAXNew.ResourceProviders;

namespace MAXNew.UI
{
    public enum UIMenuItemButtonState
    {
        normal,
        pressed
    };
    public class UIMenuItemButton : UIMenuItem
    {
        public MenuItemAction onMouseUp;
        public MenuItemAction onMouseDown;

        UIMenuItemButtonState state;

        UISprite IdleImage;
        UISprite PressedImage;

        public UIMenuItemButton(Rectangle zone, UIMenu baseController)
            : base(zone, baseController)
        { }

        public void SetIdleImage(ImagePart image)
        {
            if (IdleImage != null)
            {
                IdleImage.SetSpriteImage(image);                
            }
            else
            {
                IdleImage = new UISprite(image,Vector2.Zero);
                if (state == UIMenuItemButtonState.normal)
                AddChild(IdleImage);
            }
        }

        public void SetPressedImage(ImagePart image)
        {
            if (PressedImage != null)
            {
                PressedImage.SetSpriteImage(image);
            }
            else
            {
                PressedImage = new UISprite(image, Vector2.Zero);
                if(state == UIMenuItemButtonState.pressed)
                AddChild(PressedImage);
            }
        }

        protected override void internalMouseDown(bool hisAction)
        {
            state = UIMenuItemButtonState.pressed;
            if(onMouseDown!=null && hisAction)
                onMouseDown(this);


            if (IdleImage != null && childrens.Contains(IdleImage))
            {
                RemoveChild(IdleImage);
                IdleImage.SetParent(null);
            }

            if (PressedImage != null)
                AddChild(PressedImage);
        }

        protected override void internalMouseDrag()
        {

        }

        protected override void internalMouseUp(bool hisAction)
        {
            state = UIMenuItemButtonState.normal;
            if(onMouseUp!=null && hisAction)
                onMouseUp(this);


            if (PressedImage != null && childrens.Contains(PressedImage))
            {
                RemoveChild(PressedImage);
                PressedImage.SetParent(null);
            }

            if (IdleImage != null)
                AddChild(IdleImage);
        }

        protected override void DisposeSelf()
        {
            isDisposedSelf = true;
        }

        ~UIMenuItemButton()
        {
            if (!isDisposedSelf)
                DisposeSelf();
        }
    }
}
