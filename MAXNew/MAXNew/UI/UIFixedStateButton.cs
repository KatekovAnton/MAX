using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using MAXNew.ResourceProviders;

namespace MAXNew.UI
{
    public class UIFixedStateButton : UIMenuItem
    {
        public MenuItemAction onPressed;
        public MenuItemAction onNormaled;

        UIMenuItemButtonState state;

        UISprite IdleImage;
        UISprite PressedImage;

        public UIFixedStateButton(Rectangle zone, UIMenu baseController)
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
                IdleImage = new UISprite(image, Vector2.Zero);
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
                if (state == UIMenuItemButtonState.pressed)
                    AddChild(PressedImage);
            }
        }

        public void SetState(UIMenuItemButtonState newstate, bool runAction)
        {
            if (state == newstate)
                return;
            if (state == UIMenuItemButtonState.normal)
            {
                state = UIMenuItemButtonState.pressed;
                if (onPressed != null && runAction)
                    onPressed(this);


                if (IdleImage != null && childrens.Contains(IdleImage))
                {
                    RemoveChild(IdleImage);
                    IdleImage.SetParent(null);
                }

                if (PressedImage != null)
                    AddChild(PressedImage);
            }
            else
            {
                state = UIMenuItemButtonState.normal;
                if (onNormaled != null && runAction)
                    onNormaled(this);


                if (PressedImage != null && childrens.Contains(PressedImage))
                {
                    RemoveChild(PressedImage);
                    PressedImage.SetParent(null);
                }

                if (IdleImage != null)
                    AddChild(IdleImage);
            }
        }

        protected override void internalMouseDown(bool hisAction)
        {
            if (state == UIMenuItemButtonState.normal)
                SetState(UIMenuItemButtonState.pressed, true);
            else
                SetState(UIMenuItemButtonState.normal,true);
        }

        protected override void internalMouseDrag()
        {

        }

        protected override void internalMouseUp(bool hisAction)
        {
            
        }

        protected override void DisposeSelf()
        {
            isDisposedSelf = true;
        }

        ~UIFixedStateButton()
        {
            if (!isDisposedSelf)
                DisposeSelf();
        }
    }
}
