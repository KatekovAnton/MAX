using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAXNew.UI
{
    public class UIFontHelper
    {
        public static UIFont CourierNew12RegularBold;
        public UIFontHelper()
        {
            if(CourierNew12RegularBold==null)
                CourierNew12RegularBold = new UIFont(ResourceProviders.XNAFontProvider.CourierNew12RegularBold);
        }
    }
}
