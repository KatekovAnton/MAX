using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using MAXNew.UI;
using MAXNew.ResourceProviders;

namespace MAXNew.Game.Windows
{
    public class TestWindow: UIControlController
    {
        public TestWindow()
            : base(new Rectangle(0, 0, (int)GameConfiguration.ScreenResolution.X, (int)GameConfiguration.ScreenResolution.Y))
        { }

        public override void OnClosingWindow()
        {

        }

        public override void OnShowingWindow()
        {
                
        }
    }
}
