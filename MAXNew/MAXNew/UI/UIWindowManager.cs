using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAXNew.UI
{
    public class UIWindowManager
    {
        List<UIControlController> _windowsQueue;
        List<UIControlController> _showingWindowsList;
        UIControl _rootScene;

        static UIWindowManager _instance;

        protected UIWindowManager()
        {
            _rootScene = UIManager.Instance.maincontrol;
            _windowsQueue = new List<UIControlController>();
            _showingWindowsList = new List<UIControlController>();
        }

        public static UIWindowManager Instance()
        {
            if (_instance == null)
                _instance = new UIWindowManager();
            return _instance;
        }

        private bool AppearWindow(UIControlController window)
        {
            _rootScene.AddChild(window.rootControl);
            _showingWindowsList.Add(window);
            return true;
        }

        public void DiscardWindow(UIControlController window)
        {
            _rootScene.RemoveChild(window.rootControl);
            _showingWindowsList.Remove(window);
            if (_showingWindowsList.Count == 0)
                ProcessQueue();
        }

        public void ProcessQueue()
        {
            //bool windowAppeared = true;
            if (_windowsQueue.Count > 0)
            {
                UIControlController window = _windowsQueue[0];
                AppearWindow(window);
                _windowsQueue.RemoveAt(0);
            }
            // else // show them
            //    windowAppeared = false;
            //NSDictionary *userInfo = [NSDictionary dictionaryWithObject:[NSNumber numberWithBool:windowAppeared] forKey:@"windowAppeared"];
            //[[NSNotificationCenter defaultCenter] postNotificationName:NOTIFICATION_WINDOW_STATE_CHANGED object:nil userInfo:userInfo];
        }

        public void QueueWindow(UIControlController window)
        {
            _windowsQueue.Add(window);

            if (_showingWindowsList.Count == 0)
                ProcessQueue();

        }

        public void PopupWindow(UIControlController window)
        {
            AppearWindow(window);            
        }
    }
}
