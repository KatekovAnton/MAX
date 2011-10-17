using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.UI
{
    public class UIManager
    {
        public static UIControl test;
        public static UIManager Instance;
        public UIRootControl maincontrol;

        public GraphicsDevice mainDevice
        {
            get;
            private set;
        }

        public UIManager(GraphicsDevice device)
        {
            Instance = this;
            mainDevice = device;
            UIStaticInfo inf = UIStaticInfo.Instance;
            maincontrol = new UIRootControl();
        }

        public void Draw()
        {
            UIStaticInfo.Instance.spriteBatch.Begin();
            Vector2 position = Vector2.Zero;
            maincontrol.Draw(position);

            UIStaticInfo.Instance.spriteBatch.End();
        }


        public static MyContainer<UIMenu> menus = new MyContainer<UIMenu>();
        public static MyContainer<UIMenu> buffer = new MyContainer<UIMenu>();
        public UIMenu mouseOvnerMenu;
        public UIMenuItem mouseOvnerItem;
        public void Update()
        {
            if (!(Game1.mouseManager.lmbState == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Game1.mouseManager.isJustReleased))//мышка не нажата и не отпущена
            {
                mouseOvnerItem = null;
                mouseOvnerMenu = null;
                return;
            }

            Point mouseLocation = new Point((int)Game1.mouseManager.mousePos.X, (int)Game1.mouseManager.mousePos.Y);
            //мышка или нажата или токачто отпущена
            if (Game1.mouseManager.lmbState == Microsoft.Xna.Framework.Input.ButtonState.Pressed)//мышка нажата
            {
                if (mouseOvnerItem == null && Game1.mouseManager.isJustPressed)//мышка токачто нажата - ищем в кого пошел тычок
                {

                    UIMenu topMenu = null;
                    foreach (UIMenu menu in menus)
                    {
                        if (menu.AnyChildContainsPoint(mouseLocation))
                        {
                            if (topMenu == null)
                                topMenu = menu;
                            else if (topMenu.priority < menu.priority)
                                topMenu = menu;

                            buffer.Add(menu);
                        }
                    }

                    if (buffer.IsEmpty)//тык никуда не пошел
                    {
                        mouseOvnerItem = null;
                        mouseOvnerMenu = null;
                        return;
                    }
                    //тут надо найти самое верхнее меню в которое пошел тык
                    //тычок кудато пошел
                    //определить куда пошел тычок
                    mouseOvnerItem = topMenu.GetChildInPoint(mouseLocation) as UIMenuItem;
                    mouseOvnerMenu = topMenu;

                    mouseOvnerItem.Update(UIMenuItemInputState.pressed, true);

                    buffer.Clear();
                }
                else if (mouseOvnerItem == null && !Game1.mouseManager.isJustPressed) // мышка давно нажата и тычок никуда не пошел
                    return;
                else if (mouseOvnerItem != null && !Game1.mouseManager.isJustPressed) // мышка давно нажата и тычок кудато пошел
                    if (mouseOvnerItem.HavePoint(mouseLocation))
                        mouseOvnerItem.Update(UIMenuItemInputState.pressed, true);
                    else
                        mouseOvnerItem.Update(UIMenuItemInputState.pressed, false);

            }
            else // отпущена
            {
                if (mouseOvnerItem == null && Game1.mouseManager.isJustReleased)//мышка токачто отпущена а тычок ни в кого не шел
                    return;
                else if (mouseOvnerItem == null && !Game1.mouseManager.isJustReleased) // мышка давно нажата и тычок никуда не шел
                    return;
                else if (mouseOvnerItem != null && Game1.mouseManager.isJustReleased) // мышка токачто отпущена а тычок кудато шел
                {
                    //тычок кудато пришел
                    //и если пришел тудаже, то выполнить действия
                    if (mouseOvnerItem.HavePoint(mouseLocation))//тык пришел в этот объект
                        mouseOvnerItem.Update(UIMenuItemInputState.released, true);
                    else
                        mouseOvnerItem.Update(UIMenuItemInputState.released, false);
                    //обнуляем инфу
                    mouseOvnerItem = null;
                    mouseOvnerMenu = null;
                }
            }
        }
    }
}
