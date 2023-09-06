using System.Collections.Generic;
using GFA.TPS.UI.Popups;

namespace GFA.TPS.UI
{
    public static class PopupChannel
    {
        private static List<Popup> _popups = new List<Popup>();
        
        public static Popup GetPopup(string name)
        {
            foreach (var pop in _popups)
            {
                if (pop.Name == name)
                {
                    return pop;
                }
            }

            return null;
        }
        
        public static bool TryGetPopup(string name, out Popup popup)
        {
            foreach (var pop in _popups)
            {
                if (pop.Name == name)
                {
                    popup = pop;
                    return true;
                }
            }

            popup = null;
            return false;
        }

        public static T GetPopup<T>() where T: Popup
        {
            foreach (var popup in _popups)
            {
                if (popup is T casted)
                {
                    return casted;
                }
            }
            return null;
        }
        
        public static bool TryGetPopup<T>(out T popup) where T: Popup
        {
            foreach (var p in _popups)
            {
                if (p is T casted)
                {
                    popup = casted;
                    return true;
                }
            }
            
            popup = null;
            return false;
        }

        public static void RequestPopup<T>() where T: Popup
        {
            if (TryGetPopup<T>(out T popup))
            {
                popup.Open();
            }
        }

        public static void RegisterPopup(Popup popup)
        {
            if(!_popups.Contains(popup))
            {
                _popups.Add(popup);
            }
        }

        public static void UnregisterPopup(Popup popup)
        {
            _popups.Remove(popup);
        }
    }
}
