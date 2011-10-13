using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MAXNew.UI
{
    public abstract class UIControlController
    {
        public UIControl rootControl;

        public UIControlController(Rectangle zone)
        {
            //rootControl = new 
        }

        /// <summary>
        /// при закрытии окна - удалить, освобадить ресурсы
        /// </summary>
        public abstract void OnClosingWindow();

        /// <summary>
        /// при показе окна - создать содержимое
        /// </summary>
        public abstract void OnShowingWindow();
    }
}
